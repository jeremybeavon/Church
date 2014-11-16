using System;
using System.IO;
using AppDomainAspects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortlessWebHost;
using CommonMsTestAssemblySetup = Church.TestingCommon.MsTestAssemblySetup;

namespace Church.IntegrationTests
{
    [TestClass]
    public sealed class MsTestAssemblySetup : CommonMsTestAssemblySetup
    {
        private WebHost host;

        [AssemblyInitialize]
        public override void InitializeAssembly()
        {
            base.InitializeAssembly();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string physicalPath = Path.Combine(baseDirectory, @"..\Church.Web");
            host = new WebHost("/", physicalPath);
            DefaultAppDomainProvider.AppDomain = host.Domain;
        }

        [AssemblyCleanup]
        public void CleanUpAssembly()
        {
            DefaultAppDomainProvider.AppDomain = null;
            host.Dispose();
        }
    }
}
