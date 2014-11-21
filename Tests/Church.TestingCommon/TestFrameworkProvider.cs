using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Church.TestingCommon
{
    internal static class TestFrameworkProvider
    {
        public const string NUnitKey = "nunit";
        public const string MsTestKey = "mstest";
        private const BindingFlags PrivateStaticFlags = BindingFlags.NonPublic | BindingFlags.Static;

        private static readonly Type TestFrameworkProviderType = 
            typeof(ObjectAssertionsExtensions).Assembly.GetType("FluentAssertions.Execution.TestFrameworkProvider");

        private static readonly FieldInfo FrameworksField =
            TestFrameworkProviderType.GetField("frameworks", PrivateStaticFlags);

        private static readonly FieldInfo TestFrameworkField =
            TestFrameworkProviderType.GetField("testFramework", PrivateStaticFlags);

        public static readonly IDictionary Frameworks = (IDictionary)FrameworksField.GetValue(null);

        public static object TestFramework
        {
            set { TestFrameworkField.SetValue(null, value); }
        }
    }
}
