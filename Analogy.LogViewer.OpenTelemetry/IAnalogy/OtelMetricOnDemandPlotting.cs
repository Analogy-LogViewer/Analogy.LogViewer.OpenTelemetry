using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.OpenTelemetry.Managers;
using Analogy.LogViewer.Template.Managers;
using Microsoft.Extensions.Logging;
#if NET
using Analogy.LogViewer.OpenTelemetry.Types;
using OpenTelemetry.Proto.Metrics.V1;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.OpenTelemetry.IAnalogy
{
    public class OtelMetricOnDemandPlotting(string source, string metricName, Guid id) : IAnalogyOnDemandPlotting
    {
        public string Source { get; } = source;
        public string MetricName { get; } = metricName;
        public Guid Id { get; } = id;
        public event EventHandler<(Guid Id, IEnumerable<AnalogyPlottingPointData> PointsData)> OnNewPointsData;
        private bool enable;
        private UserControl UI;
        private IAnalogyOnDemandPlottingInteractor Interactor { get; set; }
        public Task InitializeOnDemandPlotting(IAnalogyOnDemandPlottingInteractor onDemandPlottingInteractor, ILogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            Interactor = onDemandPlottingInteractor;
#if NET
            Otel.MetricReporter.Instance.NewMetric += Instance_NewMetric;
#endif
            return Task.CompletedTask;
        }
#if NET
        private void Instance_NewMetric(object? sender, (ResourceMetrics ResourceMetric, ScopeMetrics ScopeMetric, Metric Metric) e)
        {
                if (!enable)
                {
                    return;
                }

                var serviceName = Types.Utils.GetServiceNameFromMetricResource(e.ResourceMetric);
                if (source.Equals(serviceName) && e.Metric.Name.Equals(MetricName))
                {
                    ProcessData(e.Metric);
                }
        }
#endif
#if NET
        private void ProcessData(Metric metric)
        {
            var data = Utils.GetMetricData(metric).ToList();
            if (data.Any())
            {
                if (UI.InvokeRequired)
                {
                    UI.Invoke(new MethodInvoker(() =>
                    {
                        OnNewPointsData?.Invoke(this, (Id, data));
                    }));
                }
                else
                {
                    OnNewPointsData?.Invoke(this, (Id, data));
                }
            }
        }
#endif
        public void StartPlotting(UserControl ui)
        {
            UI = ui;
#if NET
            _ = Task.Run(async () =>
            {
                await Task.Delay(100);
                var history = MetricsManager.Instance.GetHistory(Source, MetricName).ToList();
                foreach (Metric metric in history)
                {
                    ProcessData(metric);
                }
                enable = true;
            });
#endif
        }

        public void StopPlotting() => enable = false;

        public void ShowPlot()
        {
            Interactor.ShowPlot(Id, MetricName, AnalogyOnDemandPlottingStartupType.TabbedWindow);
        }

        public void ClosePlot()
        {
            HidePlot();
        }

        public void RemoveSeriesFromPlot(string seriesName)
        {
            Interactor.RemoveSeriesFromPlot(Id, seriesName);
        }

        public void ClearSeriesData(string seriesNameToClear)
        {
            Interactor.ClearSeriesData(Id, seriesNameToClear);
        }

        public void ClearAllData()
        {
            Interactor.ClearAllData(Id);
        }

        public void HidePlot()
        {
#if NET
            Otel.MetricReporter.Instance.NewMetric -= Instance_NewMetric;
#endif
            Interactor.ClosePlot(Id);
        }
    }
}