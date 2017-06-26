using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankingApp.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        [TestMethod]
        public void GetActionResultNotNull()
        {
            UsersController controller = new UsersController();
        }
    }
}
