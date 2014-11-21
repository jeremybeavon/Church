using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCallbackExtensions;
using TextSerialization;

namespace Church.IntegrationTests.Framework
{
    internal sealed class CrossDomainTraceListener : TraceListener
    {
        private readonly AppDomain destinationDomain;

        public CrossDomainTraceListener(AppDomain destinationDomain)
        {
            this.destinationDomain = destinationDomain;
        }

        public override void Write(string message)
        {
            destinationDomain.DoCallBack(message, WriteTrace, new DataContractSerialization());
        }

        public override void WriteLine(string message)
        {
            destinationDomain.DoCallBack(message, WriteTraceLine, new DataContractSerialization());
        }

        private static void WriteTrace(string message)
        {
            Trace.Write(message);
        }

        private static void WriteTraceLine(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
