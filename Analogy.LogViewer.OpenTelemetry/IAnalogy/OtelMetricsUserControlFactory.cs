using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.DataTypes;
using Analogy.Interfaces.WinForms.Factories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.OpenTelemetry.IAnalogy
{
    public class OtelMetricsUserControlFactory : IAnalogyCustomUserControlsFactoryWinForms
    {
        public Guid FactoryId { get; set; } = OtelPrimaryFactory.Id;
        public string Title { get; set; } = "Metrics Viewer";

        public IEnumerable<IAnalogyCustomUserControlWinForms> UserControls { get; } = new List<IAnalogyCustomUserControlWinForms>
        {
            new MetricsUserControl(),
        };
    }

    public class MetricsUserControl : IAnalogyCustomUserControlWinForms
    {
        public Task InitializeUserControl(Control hostingControl, ILogger logger)
        {
#if NET
            Analogy.LogViewer.OpenTelemetry.Otel.OtelGrpcHosting.InitializeIfNeeded();
#endif
            return Task.CompletedTask;
        }

        public Task UserControlRemoved()
        {
            return Task.CompletedTask;
        }

        public UserControl UserControl => new OtelMetricsViewerUC();
        public Guid Id { get; set; } = new Guid("afa58e94-db5b-461e-982c-a3802e291b37");
        public Image? SmallImage { get; set; }
        public Image? LargeImage { get; set; }
        public string Title { get; set; } = "Otel Metrics Viewer";
        public AnalogyToolTipWithImages? ToolTip { get; set; }
    }
}