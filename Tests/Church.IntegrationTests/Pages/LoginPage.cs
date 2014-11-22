using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Church.IntegrationTests.Pages
{
    public abstract class LoginPage : DefaultPage
    {
        public const string UserName = "#userName";

        public const string Password = "#password";

        public const string LogInButton = "#logInButton";
    }
}
