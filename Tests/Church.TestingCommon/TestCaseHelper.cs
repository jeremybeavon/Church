using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Core.Extensibility;

namespace Church.TestingCommon
{
    internal static class TestCaseHelper
    {
        public static IEnumerable<object[]> GetTestCaseArguments(ITestCaseProvider provider, MethodInfo testMethod)
        {
            return provider.HasTestCasesFor(testMethod) ?
                provider.GetTestCasesFor(testMethod).Cast<ParameterSet>().Select(testCase => testCase.Arguments) :
                new object[0][];
        }
    }
}
