using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainAspects;
using Church.BusinessRules.Photos;

namespace Church.IntegrationTests.Framework
{
    internal sealed class TestFlickrApi : IFlickrApi
    {
        [RunInDifferentAppDomain]
        public void UploadPhoto(Stream stream)
        {
            new FlickrApi().UploadPhoto(stream);
        }
    }
}
