using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Church.TestingCommon
{
    [TestClass]
    public abstract class MsTestAssemblySetup
    {
        [AssemblyInitialize]
        public virtual void InitializeAssembly()
        {
            TestFrameworkProvider.TestFramework = TestFrameworkProvider.Frameworks[TestFrameworkProvider.MsTestKey];
        }
    }
}
