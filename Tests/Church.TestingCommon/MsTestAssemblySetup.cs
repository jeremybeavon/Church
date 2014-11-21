using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Church.TestingCommon
{
    public static class MsTestAssemblySetup
    {
        public static void Initialize()
        {
            TestFrameworkProvider.TestFramework = TestFrameworkProvider.Frameworks[TestFrameworkProvider.MsTestKey];
        }
    }
}
