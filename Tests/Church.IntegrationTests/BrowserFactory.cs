using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortlessWebHost;
using Zombie.Net;
using ZombieBrowserFactory = Zombie.Net.PortlessWebHost.BrowserFactory;

namespace Church.IntegrationTests
{
    public static class BrowserFactory
    {
        public static Task<Browser> CreateAsync()
        {
            BrowserOptions options = new BrowserOptions()
            {
                WaitDuration = TimeSpan.FromSeconds(30)
            };
            return ZombieBrowserFactory.CreateAsync(WebHost.Current, options);
        }
    }
}
