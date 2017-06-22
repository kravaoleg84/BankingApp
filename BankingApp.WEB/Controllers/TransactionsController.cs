using System.Web.Http;
using BankingApp.BLL.Interfaces;

namespace BankingApp.WEB.Controllers
{
    [Authorize]
    public class TransactionsController : ApiController
    {
        IUserService userService;
        public TransactionsController(IUserService service)
        {
            userService = service;
        }

        public IHttpActionResult Get(int userId)
        {
            var transactions = userService.GetTransactions(userId);
            return Ok(transactions);
        }
    }
}