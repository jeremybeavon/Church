using System;
using System.Collections.Generic;
using System.Reflection;
using MSTestCaseExtensions;
using NUnitTestCaseSourceProvider = NUnit.Core.Builders.TestCaseSourceProvider;

namespace Church.TestingCommon
{
    public sealed class TestCaseSourceProvider : ITestCaseProvider
    {
        public IEnumerable<object[]> GetTestCases(MethodInfo methodToInvoke)
        {
            return TestCaseHelper.GetTestCaseArguments(new NUnitTestCaseSourceProvider(), methodToInvoke);
        }
    }
}
