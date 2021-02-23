using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using TestEntity2.Models;
using TestEntity2.Repositories;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.Collections.Generic;

namespace TestEntity2.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        UserRepostory _repo;
        public AuthController(UserRepostory userRepository)
        {
            _repo = userRepository;
        }


        


        //[Route("ApiLogin")]
        //public string ApiLogin()
        //{
        //    string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
        //    var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(Secret));
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var myIssuer = "http://mysite.com";
        //    var myAudience = "http://myaudience.com";
        //    var tokenDescriptor = new SecurityTokenDescriptor {
        //        Subject = new ClaimsIdentity(new Claim[] {
        //                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //                    }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        Issuer = myIssuer,
        //        Audience = myAudience,
        //        SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            bool isLogged = false;
            if (username != null && password != null)
            {
                Users user = this._repo.getByUsername(username);
                if (user != null)
                {
                    string hashPassword = this.hashPassword(password);
                    if (hashPassword == user.Password)
                    {
                        HttpContext.Session.SetInt32("userId", user.Id);
                        HttpContext.Session.SetString("userName", user.Username);
                    } else
                    {
                        return View();
                    }
                } 
            } else
            {
                return View();
            }
            return Redirect("/");
        }


        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userId"); 
            HttpContext.Session.Remove("userName");
            return Redirect("/");
        }


        private string hashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("X2"));
                }
                return builder.ToString();
            }
        }
    }
}
