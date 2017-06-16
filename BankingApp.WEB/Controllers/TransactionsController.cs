using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BankingApp.BLL.Interfaces;
using BankingApp.BLL.ViewModels;

namespace BankingApp.WEB.Controllers
{
    public class TransactionsController : ApiController
    {
        IUserService userService;
        public TransactionsController(IUserService service)
        {
            userService = service;
        }

        public IHttpActionResult Get(int id)
        {
            var transactions = userService.GetTransactions(id);
            return Ok(transactions);
        }
    }
}