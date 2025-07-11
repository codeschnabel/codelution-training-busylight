using Xunit.Abstractions;
using Xunit.Sdk;

namespace CodelutionXUnitTestFramework.Others
{
    public class CodelutionTestAssemblyRunner : XunitTestAssemblyRunner
    {
        readonly Dictionary<Type, object> assemblyFixtureMappings = new Dictionary<Type, object>();
        private readonly HttpClient httpClient;

        public CodelutionTestAssemblyRunner(ITestAssembly testAssembly,
                                            IEnumerable<IXunitTestCase> testCases,
                                            IMessageSink diagnosticMessageSink,
                                            IMessageSink executionMessageSink,
                                            ITestFrameworkExecutionOptions executionOptions,
                                            HttpClient httpClient)
            : base(testAssembly, testCases, diagnosticMessageSink, executionMessageSink, executionOptions)
        {
            this.httpClient = httpClient;
        }


        protected override async Task<RunSummary> RunTestCollectionAsync(IMessageBus messageBus, ITestCollection testCollection, IEnumerable<IXunitTestCase> testCases, CancellationTokenSource cancellationTokenSource)
        {
            var summary = base.RunTestCollectionAsync(messageBus, testCollection, testCases, cancellationTokenSource);

            var result = await summary;

            if (result.Failed > 0)
                await httpClient.GetAsync("http://localhost:8989/?action=light&red=255&green=0&blue=0");
            else
                await httpClient.GetAsync("http://localhost:8989/?action=light&red=0&green=255&blue=0");

            return result;
        }

        //protected override async Task AfterTestAssemblyStartingAsync()
        //{
        //    // Let everything initialize
        //    await base.AfterTestAssemblyStartingAsync();

        //    // Go find all the AssemblyFixtureAttributes adorned on the test assembly
        //    Aggregator.Run(() =>
        //    {
        //        var fixturesAttrs = ((IReflectionAssemblyInfo)TestAssembly.Assembly).Assembly
        //                                                                            .GetCustomAttributes(typeof(AssemblyFixtureAttribute), false)
        //                                                                            .Cast<AssemblyFixtureAttribute>()
        //                                                                            .ToList();

        //        // Instantiate all the fixtures
        //        foreach (var fixtureAttr in fixturesAttrs)
        //            assemblyFixtureMappings[fixtureAttr.FixtureType] = Activator.CreateInstance(fixtureAttr.FixtureType);
        //    });
        //}

        //protected override Task BeforeTestAssemblyFinishedAsync()
        //{
        //    // Make sure we clean up everybody who is disposable, and use Aggregator.Run to isolate Dispose failures
        //    foreach (var disposable in assemblyFixtureMappings.Values.OfType<IDisposable>())
        //        Aggregator.Run(disposable.Dispose);

        //    return base.BeforeTestAssemblyFinishedAsync();
        //}

        //protected override Task<RunSummary> RunTestCollectionAsync(IMessageBus messageBus,
        //                                                           ITestCollection testCollection,
        //                                                           IEnumerable<IXunitTestCase> testCases,
        //                                                           CancellationTokenSource cancellationTokenSource)
        //    => new XunitTestCollectionRunnerWithAssemblyFixture(assemblyFixtureMappings, testCollection, testCases, DiagnosticMessageSink, messageBus, TestCaseOrderer, new ExceptionAggregator(Aggregator), cancellationTokenSource).RunAsync();
    }
}