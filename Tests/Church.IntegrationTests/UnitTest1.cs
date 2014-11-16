using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Church.Common;
using Church.Common.Dependencies;
using Church.Data;
using Church.Web;
using Church.Web.Identity;

namespace Church.IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void SetUp()
        {
            DependencyManager.Current = new NinjectDependencyManager();
        }

        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }
}
