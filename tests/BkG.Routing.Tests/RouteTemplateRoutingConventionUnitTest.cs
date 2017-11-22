using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BkG.Routing.Tests
{
    [TestClass]
    public class RouteTemplateRoutingConventionUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_Route_Template_Missing_Then_Exception_Thrown()
        {
            var vRoutingConvention = new RouteTemplateRoutingConvention(null);
        }
    }
}