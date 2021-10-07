using ASC_1.Web.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using ASC_1.Controllers;
using Xunit;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ASC.Tests.TestUtilities;
using ASC.Utilities;

namespace ASC.Tests
{
    public class HomeControllerTest
    {
        private readonly Mock<IOptions<ApplicationSettings>> optionsMock;
        private readonly Mock<HttpContext> mockHttpContext;
        public HomeControllerTest()
        {
            optionsMock = new Mock<IOptions<ApplicationSettings>>();
            mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(p => p.Session).Returns(new FakeSession());
            optionsMock.Setup(ap => ap.Value).Returns(new ApplicationSettings { ApplicationTitle = "ASC" });
        }
        [Fact]
        public void HomeController_Index_View_Test()
        {
            var controller = new HomeController(optionsMock.Object);
            controller.ControllerContext.HttpContext = mockHttpContext.Object;
            Assert.IsType(typeof(ViewResult), controller.Index());
           
        }
        [Fact]
        public void HomeController_Index_NoModel_Test() {
            var controller = new HomeController(optionsMock.Object);
            controller.ControllerContext.HttpContext = mockHttpContext.Object;
            Assert.Null((controller.Index() as ViewResult).ViewData.Model);
         
        }
        [Fact]
        public void HomeController_Index_Validation_Test() {
            var controller = new HomeController(optionsMock.Object);
            controller.ControllerContext.HttpContext = mockHttpContext.Object;
            Assert.Equal(0, (controller.Index() as ViewResult).ViewData.ModelState.ErrorCount);
        }
        [Fact]
        public void HomeController_Index_Session_Test()
        {
            var controller = new HomeController(optionsMock.Object);
            controller.ControllerContext.HttpContext = mockHttpContext.Object;
            controller.Index();
            // Session value with key "Test" should not be null.
            Assert.NotNull(controller.HttpContext.Session.GetSession<ApplicationSettings>("Test"));
        }
    }
}
