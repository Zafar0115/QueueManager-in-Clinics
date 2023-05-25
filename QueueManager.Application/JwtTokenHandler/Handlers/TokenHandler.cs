using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QueueManager.Application.Extensions;
using QueueManager.Application.Interfaces.role;
using QueueManager.Application.JwtTokenHandler.Entities;
using QueueManager.Domain.Models.UserModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace QueueManager.Application.JwtTokenHandler.Handlers
{
    public class TokenHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public TokenHandler(IUserRepository userRepository, IConfiguration configuration)
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
                new Claim("Password",credentials.Password)
            };
            User? detailedUser = users.Include(u => u.UserRoles)?
                                                     .ThenInclude(ur => ur.Role)?
                                                     .ThenInclude(r => r.RolePermissions)?
                                                     .ThenInclude(rp => rp.Permission).FirstOrDefault();
            ICollection<string>? permissions = new List<string>();
            if (detailedUser is not null && detailedUser.UserRoles is not null)
                foreach (UserRole userRole in detailedUser.UserRoles)
                {
                    foreach (RolePermission rolePermission in userRole.Role.RolePermissions)
                    {
                        permissions.Add(rolePermission.Permission.PermissionName);
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


        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
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
