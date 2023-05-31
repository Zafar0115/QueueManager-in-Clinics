using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QueueManager.Application.Extensions;
using QueueManager.Application.Interfaces.Administration;
using QueueManager.Application.TokenModels;
using QueueManager.Domain.Models.UserModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace QueueManager.Application.JwtTokenHandler.Handlers
{
    public class TokenService:ITokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public TokenService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<Token?> GenerateAccessTokenAsync(UserCredentials credentials)
        {

            IQueryable<User>? users = await _userRepository.Get(o =>
                                                              o.UserName == credentials.UserName &&
                                                              o.Password == credentials.Password.ComputeHash() &&
                                                              o.PhoneNumber == credentials.PhoneNumber);
            User? user = users.FirstOrDefault();
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,credentials.UserName),
                new Claim(ClaimTypes.GivenName,user.FullName),
                new Claim("PhoneNumber",credentials.PhoneNumber),
                new Claim("Password",credentials.Password),
            };
            User? userDetails = users.Include(u => u.Roles)?
                                                     .ThenInclude(r => r.Permissions)?
                                                     .FirstOrDefault();
            ICollection<string>? permissions = new List<string>();
            if (userDetails is not null && userDetails.Roles is not null)
                foreach (Role role in userDetails.Roles)
                {
                    foreach (Permission permission in role.Permissions)
                    {
                        permissions.Add(permission.PermissionName);
                    }
                }
            if (permissions is not null)
                permissions = permissions.Distinct().ToList();

            foreach (string item in permissions)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int.TryParse(_configuration["Jwt:AccessExpirationTime"], out int lifetime);

            SecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.UtcNow.AddMinutes(lifetime),
                claims: claims,
                signingCredentials: signingCredentials
                );

            string? accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            string? refreshToken = GenerateRefreshToken();
            return new Token() { AccessToken = accessToken, RefreshToken = refreshToken };
        }


        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidAudience = _configuration["Jwt:Audience"],
                ValidIssuer = _configuration["Jwt:Issuer"],
                RequireExpirationTime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return principal;

        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
