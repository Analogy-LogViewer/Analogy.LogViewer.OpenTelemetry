#if NET
using Analogy.Interfaces.DataTypes;
using OpenTelemetry.Proto.Metrics.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Analogy.LogViewer.OpenTelemetryCollector.Otel
{
    public class MetricReporter
    {
        private static Lazy<MetricReporter> _instance = new Lazy<MetricReporter>(() => new MetricReporter());

        public static MetricReporter Instance { get; } = _instance.Value;

        public event EventHandler<(ResourceMetrics ResourceMetric, ScopeMetrics ScopeMetric, Metric Metric)> NewMetric;
        public event EventHandler<AnalogyLogMessageArgs> OnMessageReady;
        public event EventHandler<AnalogyLogMessagesArgs> OnManyMessagesReady;


        public void RaiseNewMetric(ResourceMetrics resourceMetric, ScopeMetrics scopeMetric, Metric metric)
        {
            NewMetric?.Invoke(this, (resourceMetric, scopeMetric, metric));
        }
    }
}
#endif