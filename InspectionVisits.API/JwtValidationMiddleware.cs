using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace InspectionVisits.API
{
    public class JwtValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _handler = new();
        private readonly TokenValidationParameters _validationParameters;

        public JwtValidationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _configuration["JWT:Issuer"],
                ValidAudience = _configuration["JWT:Audience"],
                // ClockSkew = TimeSpan.Zero
            };
        }

        public async Task Invoke(HttpContext context)
        {
            
            
var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(authHeader))
            {
                // Extract raw token if header uses "Bearer <token>"
                const string bearerPrefix = "Bearer ";
                var token = authHeader.StartsWith(bearerPrefix, StringComparison.OrdinalIgnoreCase)
                    ? authHeader.Substring(bearerPrefix.Length).Trim()
                    : authHeader.Trim();

                if (!string.IsNullOrEmpty(token))
                {
                    try
                    {
                        _handler.ValidateToken(token, _validationParameters, out SecurityToken validatedToken);
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync($"Invalid or expired token: {ex.Message}");
                        return;
                    }
                }
            }

            await _next(context);
        }
    }

}
