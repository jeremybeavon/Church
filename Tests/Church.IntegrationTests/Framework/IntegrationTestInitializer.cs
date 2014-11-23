using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AppDomainAspects;

namespace Church.IntegrationTests.Framework
{
    internal sealed class IntegrationTestInitializer : MarshalByRefObject
    {
        public void Initialize(AppDomain destinationDomain)
        {
            Trace.Listeners.Add(new CrossDomainTraceListener(destinationDomain));
            HttpApplication.RegisterModule(typeof(IntegrationTestModule));
            RunInDifferentAppDomainAttribute.AppDomainProvider = new IntegrationTestAppDomainProvider(destinationDomain);
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
