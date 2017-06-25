using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BankingApp.BLL.Interfaces;
using BankingApp.WEB.Controllers;
using BankingApp.BLL.ViewModels;

namespace UnitTestProject.Controllers
{
    [TestClass]
    public class BankControllerTest
    {
        [TestMethod]
        public void PutReturnsContentResult()
        {
            var mock = new Mock<IUserService>();
            var controller = new BankController(mock.Object);

            IHttpActionResult actionResult = controller.Deposit(new UserDTO { Id = 1, Balance = 1 });
            var contentResult = actionResult as NegotiatedContentResult<UserDTO>;

            Assert.IsNotNull(contentResult);
            Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }
    }
}
