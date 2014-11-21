﻿using System;
using System.IO;
using AppDomainAspects;
using Church.TestingCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortlessWebHost;

namespace Church.IntegrationTests
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
            host = new WebHost("/", physicalPath);
            DefaultAppDomainProvider.AppDomain = host.Domain;
        }

        [AssemblyCleanup]
        public static void CleanUpAssembly()
        {
            DefaultAppDomainProvider.AppDomain = null;
            host.Dispose();
        }
    }
}
