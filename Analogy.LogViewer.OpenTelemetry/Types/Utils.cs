#if NET
using Analogy.Interfaces.DataTypes;
using OpenTelemetry.Proto.Metrics.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Analogy.LogViewer.OpenTelemetry.Types
{
    public static class Utils
    {
        public static string GetServiceNameFromMetricResource(ResourceMetrics resourceMetric)
        {
            var service = resourceMetric.Resource.Attributes.FirstOrDefault(a => a.Key.Equals("service.name"));
            var key = service?.Value.StringValue ?? "";
            return key;
        }

        public static IEnumerable<AnalogyPlottingPointData> GetMetricData(Metric metric)
        {
            AnalogyPlottingPointData? GetData(string metricName, NumberDataPoint val, DateTimeOffset time)
            {
                if (val.HasAsDouble)
                {
                    return new AnalogyPlottingPointData(metric.Name, val.AsDouble, time);
                }
                if (val.HasAsInt)
                {
                    return new AnalogyPlottingPointData(metric.Name, val.AsInt, time);
                }

                return null;
            }

            switch (metric.DataCase)
            {
                case Metric.DataOneofCase.None:
                    break;
                case Metric.DataOneofCase.Gauge:
                    foreach (var val in metric.Gauge.DataPoints)
                    {
                        var unixTimeMilliseconds = val.TimeUnixNano / 1_000_000;
                        var time = DateTimeOffset.FromUnixTimeMilliseconds((long)unixTimeMilliseconds);
                        var d = GetData(metric.Name, val, time);
                        if (d is not null)
                        {
                            yield return d;
                        }
                    }
                    break;
                case Metric.DataOneofCase.Sum:
                    foreach (var val in metric.Sum.DataPoints)
                    {
                        var unixTimeMilliseconds = val.TimeUnixNano / 1_000_000;
                        var time = DateTimeOffset.FromUnixTimeMilliseconds((long)unixTimeMilliseconds);
                        var d = GetData(metric.Name, val, time);
                        if (d is not null)
                        {
                            yield return d;
                        }
                    }
                    break;
                case Metric.DataOneofCase.Histogram:
                    foreach (var val in metric.Histogram.DataPoints)
                    {
                        var unixTimeMilliseconds = val.TimeUnixNano / 1_000_000;
                        var time = DateTimeOffset.FromUnixTimeMilliseconds((long)unixTimeMilliseconds);
                        
                        //var d = GetData(metric.Name, val.Sum, time);
                        //if (d is not null)
                        //{
                        //    yield return d;
                        //}
                    }
                    break;
                case Metric.DataOneofCase.ExponentialHistogram:
                    break;
                case Metric.DataOneofCase.Summary:
                    break;
                default:
                    break;
            }
        }
    }
}
#endif