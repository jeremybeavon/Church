using System;
using System.IO;
using System.Net;
using AppDomainAspects;
using AppDomainCallbackExtensions;
using Church.TestingCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortlessWebHost;

namespace Church.IntegrationTests.Framework
{
    [TestClass]
    public static class IntegrationTestAssemblySetup
    {
        private static WebHost host;

        [AssemblyInitialize]
        public static void InitializeAssembly(TestContext context)
        {
            MsTestAssemblySetup.Initialize();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string physicalPath = Path.GetFullPath(Path.Combine(baseDirectory, @"..\Church.Web\"));
            host = new WebHost("/", physicalPath, Protocol.Https);
            RunInDifferentAppDomainAttribute.AppDomainProvider = new IntegrationTestWebAppDomainProvider(host.Domain);
            host.Domain.CreateInstanceFromAndUnwrap<IntegrationTestInitializer>().Initialize(AppDomain.CurrentDomain);
            InitializeFlickr();
        }

        [AssemblyCleanup]
        public static void CleanUpAssembly()
        {
            DefaultAppDomainProvider.AppDomain = null;
            host.Dispose();
        }

        private static void InitializeFlickr()
        {
            WebRequest.RegisterPrefix("https", new FlickrRequestFactory());
        }
    }
}
