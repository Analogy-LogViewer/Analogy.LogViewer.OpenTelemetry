using Analogy.Interfaces.DataTypes;
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
    public sealed class MetricsOnlineDataProvider : OnlineDataProviderWinForms
    {
        public override string? OptionalTitle { get; set; }
        public override Guid Id { get; set; } = new Guid("aa448f92-07e1-4664-a597-25398877294a");

        public override Task<bool> CanStartReceiving() => Task.FromResult(true);
        public MetricsOnlineDataProvider()
        {
            OptionalTitle = "Metrics Data";
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
                    Source = e.Description,
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