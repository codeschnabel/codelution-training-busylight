using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CodelutionXUnitTestFramework.Others
{
    public class CodelutionTestFrameworkExecutor : XunitTestFrameworkExecutor
    {
        public CodelutionTestFrameworkExecutor(
            AssemblyName assemblyName,
            ISourceInformationProvider sourceInformationProvider,
            IMessageSink diagnosticMessageSink)
            : base(assemblyName, sourceInformationProvider, diagnosticMessageSink)
        { }

        protected override async void RunTestCases(
            IEnumerable<IXunitTestCase> testCases,
            IMessageSink executionMessageSink,
            ITestFrameworkExecutionOptions executionOptions)
        {
            using (var assemblyRunner = new CodelutionTestAssemblyRunner(
                TestAssembly,
                testCases,
                DiagnosticMessageSink,
                executionMessageSink,
                executionOptions,
                new HttpClient()))
            {
                await assemblyRunner.RunAsync();
            }
        }
    }
}