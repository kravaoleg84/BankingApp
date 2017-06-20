using System.Web.Http;
using BankingApp.BLL.Interfaces;

namespace BankingApp.WEB.Controllers
{
    public class UsersController : ApiController
    {
        IUserService userService;
        public UsersController(IUserService service)
        {
            userService = service;
        }

        public IHttpActionResult Get(int id)
        {
            var user = userService.GetUser(id);
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        public IHttpActionResult GetUserByName(string name)
        {
            var user = userService.GetUserByName(name);
            if (user != null)
                return Ok(user);
            return NotFound();
        }
    }
}