#if NET
using OpenTelemetry.Proto.Metrics.V1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analogy.LogViewer.OpenTelemetry.Types
{
    internal class MetricRecords
    {
        public string ServiceName { get; }
        private List<Metric> Records { get; } = [];
        private List<string> RecordsName { get; } = [];
        public MetricRecords(string serviceName, (ResourceMetrics ResourceMetric, ScopeMetrics ScopeMetric, Metric Metric) valueTuple)
        {
            ServiceName = serviceName;
        }

        public void AddMetric((ResourceMetrics ResourceMetric, ScopeMetrics ScopeMetric, Metric Metric) e)
        {
            Records.Add(e.Metric);
            if (!RecordsName.Contains(e.Metric.Name))
            {
                RecordsName.Add(e.Metric.Name);
            }
        }
        public List<string> GetMetricsTypes() => RecordsName.ToList();

        public IEnumerable<Metric> GetMetrics(string metricName)
        {
            foreach (Metric metric in Records)
            {
                if (metric.Name == metricName)
                {
                    yield return metric;
                }
            }
        }
    }
}
#endif