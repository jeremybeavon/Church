using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Church.IntegrationTests.Framework
{
    internal sealed class TraceInitializer : MarshalByRefObject
    {
        public void InitializeTracing(AppDomain destinationDomain)
        {
            Trace.Listeners.Add(new CrossDomainTraceListener(destinationDomain));
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
