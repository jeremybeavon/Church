using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainAspects;
using PostSharp.Aspects;

namespace Church.IntegrationTests.Framework
{
    internal sealed class IntegrationTestAppDomainProvider : IAppDomainProvider
    {
        private AppDomain destinationDomain;

        public IntegrationTestAppDomainProvider(AppDomain destinationDomain)
        {
            this.destinationDomain = destinationDomain;
        }

        public AppDomain GetDomain(MethodExecutionArgs args)
        {
            return args.Method.DeclaringType == typeof(TestFlickrApi) ? destinationDomain : null;
        }
    }
}
