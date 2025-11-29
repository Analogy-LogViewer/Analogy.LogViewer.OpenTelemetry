#if NET
using Analogy.LogViewer.OpenTelemetry.Otel;
using Analogy.LogViewer.OpenTelemetry.Types;
using OpenTelemetry.Proto.Metrics.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Analogy.LogViewer.OpenTelemetry.Managers
{
    internal class MetricsManager
    {
        private static Lazy<MetricsManager> _instance = new Lazy<MetricsManager>(() => new MetricsManager());

        public static MetricsManager Instance { get; } = _instance.Value;
        public Dictionary<string, MetricRecords> Metrics = new Dictionary<string, MetricRecords>();
        private bool Initialized { get; set; }
        private object Padlock = new();
        public void InitializeIfNeeded()
        {
            if (Initialized)
            {
                return;
            }

            Initialized = true;
#if NET
            MetricReporter.Instance.NewMetric += (s, e) =>
            {
                var serviceName = Utils.GetServiceNameFromMetricResource(e.ResourceMetric);
                lock (Padlock)
                {
                    if (Metrics.TryGetValue(serviceName, out var record))
                    {
                        record.AddMetric(e);
                    }
                    else
                    {
                        Metrics[serviceName] = new MetricRecords(serviceName, e);
                    }
                }
            };
#endif
        }

        public IEnumerable<Metric> GetHistory(string source, string metricName)
        {
            List<Metric> data = [];
            if (Metrics.TryGetValue(source, out var record))
            {
                lock (Padlock)
                {
                    data.AddRange(record.GetMetrics(metricName));
                }
            }
            return data;
        }
    }
}
#endif