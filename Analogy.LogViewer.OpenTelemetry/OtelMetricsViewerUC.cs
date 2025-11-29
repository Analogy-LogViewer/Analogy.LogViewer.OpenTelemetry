using Analogy.LogViewer.OpenTelemetry.Managers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Analogy.LogViewer.OpenTelemetry.IAnalogy
{
    public partial class OtelMetricsViewerUC : UserControl
    {
        private OtelMetricOnDemandPlotting? p;
#if NET
        private Types.MetricRecords? MetricRecords { get; set; }
#endif
        private string MetricName { get; set; }
        public OtelMetricsViewerUC()
        {
            InitializeComponent();
        }

        private void btnGenerator_Click(object sender, EventArgs e)
        {
            if (p is not null)
            {
                p.HidePlot();
                p.StopPlotting();
            }
#if NET
            p = new OtelMetricOnDemandPlotting(MetricRecords.ServiceName, MetricName, Guid.NewGuid());
            OnDemandPlottingContainer.Instance.AddOnDemandPlotting(p);
            p.ShowPlot();
            p.StartPlotting(this);
#endif
        }

        private void btnGeneratorHide_Click(object sender, EventArgs e)
        {
            if (p is null)
            {
                return;
            }
            p.HidePlot();
            p.StopPlotting();
            p = null;
        }
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            treeViewMetrics.Nodes.Clear();
#if NET
            foreach (KeyValuePair<string, Types.MetricRecords> metric in MetricsManager.Instance.Metrics)
            {
                var root = new TreeNode(metric.Key) { Tag = metric };
                treeViewMetrics.Nodes.Add(root);
                foreach (string name in metric.Value.GetMetricsTypes())
                {
                    root.Nodes.Add(new TreeNode(name)
                    {
                        Tag = metric.Value,
                    });
                }
            }
#endif
        }

        private void treeViewMetrics_AfterSelect(object sender, TreeViewEventArgs e)
        {
#if NET
            if (e.Node?.Tag is Types.MetricRecords metric)
            {
                MetricName = e.Node.Text;
                MetricRecords = metric;
                lblSelection.Text = $"{metric.ServiceName}: {e.Node.Text}";
                btnGenerator.Enabled = true;
            }
#endif
        }
    }
}