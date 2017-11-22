using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BkG.Routing.Tests
{
    [TestClass]
    public class ControllerSpecificRoutingConventionUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_Mapping_Function_Missing_Then_Exception_Thrown()
        {
            var vRoutingConvention = new ControllerSpecificRoutingConvention(null);
        }
    }
}
