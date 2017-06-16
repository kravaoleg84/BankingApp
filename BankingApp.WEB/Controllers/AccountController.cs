using BankingApp.BLL.Interfaces;
using BankingApp.BLL.ViewModels;
using BankingApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Thinktecture.IdentityModel.Tokens;

namespace BankingApp.WEB.Controllers
{
    public class AccountController : ApiController
    {
        public const string Secret = "856FECBA3B06519C8DDDBC80BB080553";

        IUserService userService;
        public AccountController(IUserService service)
        {
            userService = service;
        }

        [AllowAnonymous]
        [Route("signup")]
        [HttpPost]
        public HttpResponseMessage Register(RegisterViewModel model)
        {
            HttpResponseMessage response;
            if (ModelState.IsValid)
            {
                var existingUser = userService.GetUserByName(model.UserName);
                if (existingUser != null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "User with this name already exists.");
                }

                userService.AddUser(model.UserName, model.Password);

                var symmetricKey = Encoding.ASCII.GetBytes(Secret);
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, model.UserName));

                JwtSecurityToken jwtToken = new JwtSecurityToken
                (
                    claims: claims,
                    signingCredentials: new HmacSigningCredentials(symmetricKey),
                    expires: DateTime.Now.AddDays(1)
                );

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                string token = tokenHandler.WriteToken(jwtToken);
                response = Request.CreateResponse(new { token, model.UserName });
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
            }
            return response;
        }

        [AllowAnonymous]
        [Route("signin")]
        [HttpPost]
        public HttpResponseMessage Login(LoginViewModel model)
        {
            HttpResponseMessage response = null;
            if (ModelState.IsValid)
            {
                var existingUser = userService.GetUserByNameAndPassword(model.UserName, model.Password);

                if (existingUser == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    //var symmetricKey = Convert.FromBase64String(Secret);
                    var symmetricKey = Encoding.ASCII.GetBytes(Secret);
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, model.UserName));

                    JwtSecurityToken jwtToken = new JwtSecurityToken
                    (
                        claims: claims,
                        signingCredentials: new HmacSigningCredentials(symmetricKey),
                        expires: DateTime.Now.AddDays(1)
                    );

                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    string token = tokenHandler.WriteToken(jwtToken);
                    response = Request.CreateResponse(new { token, model.UserName });
                }
            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return response;
        }
    }
}