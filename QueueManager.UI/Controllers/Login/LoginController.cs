using Microsoft.AspNetCore.Mvc;
using QueueManager.Application.Interfaces.Administration;
using QueueManager.Application.TokenModels;
using QueueManager.Domain.Models.UserModels;

namespace QueueManager.UI.Controllers.Login
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRefreshTokenService _userRefreshTokenService;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public LoginController(
            ITokenService tokenService,
            IUserRefreshTokenService userRefreshTokenService,
            IConfiguration configuration,
            IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRefreshTokenService = userRefreshTokenService;
            _configuration = configuration;
            _userRepository = userRepository;
        }



        [HttpPost("Login")]
        public async Task<ActionResult<Token>> Login([FromBody] UserCredentials credentials)
        {
            Token? token = await _tokenService.GenerateAccessTokensAsync(credentials);
            if (token == null)
                return Unauthorized($"{credentials.UserName} not found in the system");

            var refreshTokens = await _userRefreshTokenService.GetSavedRefreshToken(credentials);
            int.TryParse(_configuration["Jwt:RefreshExpirationTime"], out int lifetime);

            if (refreshTokens is not null)
            {
                await _userRefreshTokenService.DeleteUserRefreshToken(refreshTokens);
            }
            else
            {
                refreshTokens = new UserRefreshToken();
            }

            User? user = await GetUser(credentials.UserName);

            refreshTokens.User= user;
            refreshTokens.RefreshToken = token.RefreshToken;
            refreshTokens.ExpiryDate = DateTime.UtcNow.AddMinutes(lifetime);
            await _userRefreshTokenService.AddUserRefreshToken(refreshTokens);
            return Ok(token);
        }


        [HttpPost("Refresh")]
        public async Task<ActionResult<Token?>> RefreshToken([FromBody] Token token)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(token.AccessToken);
            if (principal is null) return Unauthorized();

            string? userName = principal?.Identity?.Name;
            if (userName is null)
                return Unauthorized();

           User? user=await GetUser(userName);
            if (user is null) return Unauthorized();

            UserCredentials credentials = new UserCredentials()
            {
                UserName = user.UserName,
                Password = user.Password,
            };

            Token? refreshToken=await _tokenService.GenerateRefreshTokens(credentials);
            if (token is null) return Unauthorized();
            return Ok(refreshToken);
        }


        private async Task<User?> GetUser(string userName)
        {
            return (await _userRepository.Get(u => u.UserName == userName)).FirstOrDefault();
        }

    }
}
