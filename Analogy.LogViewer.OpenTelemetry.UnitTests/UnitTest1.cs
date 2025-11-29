using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.OpenTelemetry.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTelemetry.Proto.Metrics.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.OpenTelemetry.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            TaskCompletionSource<AnalogyLogMessage> taskReceived = new();

            Analogy.LogViewer.OpenTelemetry.Otel.OtelGrpcHosting.InitializeIfNeeded();
            Analogy.LogViewer.OpenTelemetry.Otel.MetricReporter.Instance.NewMetric += (s, e) =>
            {
                var serviceName = Utils.GetServiceNameFromMetricResource(e.ResourceMetric);
                AnalogyLogMessage m = new AnalogyLogMessage
                {
                    Text = e.ToString(),
                    Level = AnalogyLogLevel.Information,
                    Class = AnalogyLogClass.General,
                    Source = e.Metric.Description,
                    User = Environment.UserName,
                    Module = serviceName,
                    MachineName = Environment.MachineName,
                    ThreadId = Thread.CurrentThread.ManagedThreadId,
                };
                var data = Utils.GetMetricData(e.Metric).ToList();
                taskReceived.TrySetResult(m);
            };
            await Task.Delay(TimeSpan.FromSeconds(1000));
            var metric = await taskReceived.Task;
            Assert.IsNotNull(metric);
        }
    }
}