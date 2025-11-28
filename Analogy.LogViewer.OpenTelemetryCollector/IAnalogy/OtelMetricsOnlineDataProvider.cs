using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.OpenTelemetryCollector.Properties;
using Analogy.LogViewer.Template.WinForms;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace Analogy.LogViewer.OpenTelemetryCollector.IAnalogy
{
    public sealed class OtelMetricsOnlineDataProvider : OnlineDataProviderWinForms
    {
        public override string? OptionalTitle { get; set; }
        public override Guid Id { get; set; } = new Guid("aa448f92-07e1-4664-a597-25398877294a");
        public override Image? ConnectedLargeImage { get; set; } = Resources.Analogy_otel_icon32x32;
        public override Image? ConnectedSmallImage { get; set; } = Resources.Analogy_otel_icon16x16;
        public override Image? DisconnectedLargeImage { get; set; } = Resources.Analogy_otel_icon32x32;
        public override Image? DisconnectedSmallImage { get; set; } = Resources.Analogy_otel_icon16x16;

        public override Task<bool> CanStartReceiving() => Task.FromResult(true);
        public OtelMetricsOnlineDataProvider()
        {
            OptionalTitle = "Metrics";
        }

        public override async Task InitializeDataProvider(ILogger logger)
        {
            await base.InitializeDataProvider(logger);
#if NET
            Analogy.LogViewer.OpenTelemetryCollector.Otel.OtelGrpcHosting.InitializeIfNeeded();
            Analogy.LogViewer.OpenTelemetryCollector.Otel.MetricReporter.Instance.NewMetric += (s, e) =>
            {
                AnalogyLogMessage m = new AnalogyLogMessage
                {
                    Text = e.ToString(),
                    Level = AnalogyLogLevel.Information,
                    Class = AnalogyLogClass.General,
                    Source = e.Metric.Description,
                    User = Environment.UserName,
                    Module = "",
                    MachineName = Environment.MachineName,
                    ThreadId = Thread.CurrentThread.ManagedThreadId,
                };
                
                //m.AddOrReplaceAdditionalProperty("Random Column", random.Next(0, 10).ToString());
                //m.AddOrReplaceAdditionalProperty("Random Column 2", random.Next(0, 10).ToString());
                MessageReady(this, new AnalogyLogMessageArgs(m, Environment.MachineName, "Example", Id));
            };
#endif
        }

        public override Task StartReceiving()
        {
            return Task.CompletedTask;
        }

        public override Task StopReceiving()
        {
            Disconnected(this, new AnalogyDataSourceDisconnectedArgs("user disconnected", Environment.MachineName, Id));
            return Task.CompletedTask;
        }

        public override Task ShutDown()
        {
            return Task.CompletedTask;
        }
    }
}