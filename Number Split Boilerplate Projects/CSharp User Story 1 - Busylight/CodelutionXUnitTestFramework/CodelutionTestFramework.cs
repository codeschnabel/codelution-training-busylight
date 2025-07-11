using CodelutionXUnitTestFramework.Others;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CodelutionXUnitTestFramework
{
    public class CodelutionTestFramework : XunitTestFramework
    {
        public CodelutionTestFramework(IMessageSink messageSink) : base(messageSink)
        {
        }

        protected override ITestFrameworkExecutor CreateExecutor(AssemblyName assemblyName)
            => new CodelutionTestFrameworkExecutor(assemblyName, SourceInformationProvider, DiagnosticMessageSink);
    }
}