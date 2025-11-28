#if NET
using Analogy.Interfaces.DataTypes;
using OpenTelemetry.Proto.Metrics.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Analogy.LogViewer.OpenTelemetryCollector.Otel
{
    internal class MetricReporter
    {
        private static Lazy<MetricReporter> _instance = new Lazy<MetricReporter>(() => new MetricReporter());

        public static MetricReporter Instance { get; } = _instance.Value;

        public event EventHandler<Metric> NewMetric;
        public event EventHandler<AnalogyLogMessageArgs> OnMessageReady;
        public event EventHandler<AnalogyLogMessagesArgs> OnManyMessagesReady;

        public void RaiseNewMetric(Metric metric)
        {
            NewMetric?.Invoke(this, metric);
        }
    }
}
#endif