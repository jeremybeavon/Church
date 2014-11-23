using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Church.BusinessRules.Photos;
using Church.Common;

namespace Church.IntegrationTests.Framework
{
    internal sealed class IntegrationTestModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            DependencyManager.Bind<IFlickrApi>().To<TestFlickrApi>();
        }

        public void Dispose()
        {
        }
    }
}
