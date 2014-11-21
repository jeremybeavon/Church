using Church.TestingCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Church.UnitTests
{
    [TestClass]
    public sealed class UnitTestAssemblySetup
    {
        [AssemblyInitialize]
        public static void InitializeAssembly()
        {
            MsTestAssemblySetup.Initialize();
        }
    }
}
