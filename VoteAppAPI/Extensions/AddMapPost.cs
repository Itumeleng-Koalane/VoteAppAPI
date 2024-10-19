using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VoteAppAPI.Domain_Model;
using VoteAppAPI.Models;

namespace VoteAppAPI.Extensions
{
    public class UserRegistrationModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class UserLoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public static class AddMapPost
    {
        public static IEndpointRouteBuilder ConfigureMapPost(this IEndpointRouteBuilder app, IConfiguration configuration)
        {
            app.MapPost("/signup", CreateUser);

            app.MapPost("/signin", SignIn);

            return app;
        }

        public static async Task<IResult> CreateUser(UserManager<Register> UserManager, [FromBody] UserRegistrationModel userRegistrationModel)
        {
            Register registerUser = new Register()
            {
                UserName = userRegistrationModel.Email,
                Email = userRegistrationModel.Email,
                IdentificationNumber = userRegistrationModel.IdentificationNumber,
                Name = userRegistrationModel.Name,
                Surname = userRegistrationModel.Surname,
            };

            var result = await UserManager.CreateAsync(registerUser, userRegistrationModel.Password);

            if (result.Succeeded)
            {
                return Results.Ok(result);
            }
            else
            {
                return Results.BadRequest(result);
            }
        }

        public static async Task<IResult> SignIn(UserManager<Register> userManager,
                                                 [FromBody] UserLoginModel userLoginModel, IOptions<AppSettings> appSettings)
        {
            var user = await userManager.FindByEmailAsync(userLoginModel.Email);

            if (user != null && await userManager.CheckPasswordAsync(user, userLoginModel.Password))
            {
                var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Value.JWTSecret));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(10),
                    SigningCredentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return Results.Ok(new { token });
            }
            else
            {
                return Results.BadRequest(new { message = "Email or Password is incorrect!!" });
            }
        }
    }
}
