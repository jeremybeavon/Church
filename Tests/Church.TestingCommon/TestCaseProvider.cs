using System;
using System.Collections.Generic;
using System.Reflection;
using MSTestCaseExtensions;
using NUnit.Core.Builders;

namespace Church.TestingCommon
{
    public sealed class TestCaseProvider : ITestCaseProvider
    {
        public IEnumerable<object[]> GetTestCases(MethodInfo methodToInvoke)
        {
            return TestCaseHelper.GetTestCaseArguments(new TestCaseParameterProvider(), methodToInvoke);
        }
    }
}
