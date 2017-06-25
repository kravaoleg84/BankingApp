using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApp.WEB.Controllers;
using BankingApp.BLL.Interfaces;
using Moq;
using BankingApp.BLL.ViewModels;

namespace BankingApp.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        [TestMethod]
        public void GetReturnsUserDTOWithSameId()
        {
            int id = 1;
            var mock = new Mock<IUserService>();
            mock.Setup(a => a.GetUser(id)).Returns(new UserDTO { Id = 1 });
            var controller = new UsersController(mock.Object);

            IHttpActionResult actionResult = controller.Get(id);
            var contentResult = actionResult as OkNegotiatedContentResult<UserDTO>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }

        [TestMethod]
        public void GetReturnsNotFound()
        {
            int id = 1;
            var mock = new Mock<IUserService>();
            var controller = new UsersController(mock.Object);

            IHttpActionResult actionResult = controller.Get(id);

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}
