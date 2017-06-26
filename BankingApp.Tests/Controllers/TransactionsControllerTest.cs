using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApp.BLL.Interfaces;
using BankingApp.BLL.ViewModels;
using BankingApp.WEB.Controllers;
using Moq;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Web.Http;

namespace UnitTestProject.Controllers
{
    [TestClass]
    public class TransactionsControllerTest
    {
        [TestMethod]
        public void GetReturnsContentResult()
        {
            string name = "";
            var mock = new Mock<IUserService>();
            mock.Setup(a => a.GetTransactions(name)).Returns(new List<TransactionDTO>());
            var controller = new TransactionsController(mock.Object);

            IHttpActionResult actionResult = controller.Get(name);
            var contentResult = actionResult as OkNegotiatedContentResult<UserDTO>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
        }
    }
}
