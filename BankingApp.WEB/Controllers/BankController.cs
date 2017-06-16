using BankingApp.BLL.Interfaces;
using BankingApp.BLL.ViewModels;
using System.Web.Http;
using BankingApp.WEB.ActionResults;
using System.IdentityModel.Tokens;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.IdentityModel.Claims;

namespace BankingApp.WEB.Controllers
{
    [Authorize]
    public class BankController : ApiController
    {
        private UserDTO CurrentUser { get; set; }
        private UserDTO getCurrentUser()
        {
            HttpRequestMessage request = this.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(authorization.Parameter) as JwtSecurityToken;
            var userName = token.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            return userService.GetUserByName(userName);
        }

        IUserService userService;
        public BankController(IUserService service)
        {
            userService = service;
        }

        [HttpPut]
        [Route("api/bank/deposit/{money}")]
        public IHttpActionResult Deposit(double money)
        {
            if (money <= 0)
            {
                return new WrongEnterResult();
            }

            var answer = userService.DepositMoney(CurrentUser.Id, money);
            return new AnswerResult(answer);
        }

        [HttpPut]
        [Route("api/bank/withdraw/{money}")]
        public IHttpActionResult Withdraw(double money)
        {
            if (money <= 0)
            {
                return new WrongEnterResult();
            }

            var answer = userService.WithdrawMoney(CurrentUser.Id, money);
            return new AnswerResult(answer);
        }

        [HttpPut]
        [Route("api/bank/transfer/{name}/{money}")]
        public IHttpActionResult Transfer(string name, double money)
        {
            if (money <= 0)
            {
                return new WrongEnterResult();
            }

            var answer = userService.TransferMoney(CurrentUser.Id, name, money);
            return new AnswerResult(answer);
        }
    }
}