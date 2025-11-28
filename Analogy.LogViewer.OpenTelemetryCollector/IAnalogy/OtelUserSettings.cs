using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.WinForms.DataTypes;
using Analogy.LogViewer.OpenTelemetryCollector.Properties;
using Analogy.LogViewer.Template.WinForms;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.OpenTelemetryCollector.IAnalogy
{
    public class OtelUserSettings : TemplateUserSettingsFactoryWinForms
    {
        public override Guid FactoryId { get; set; } = OtelPrimaryFactory.Id;
        public override Guid Id { get; set; } = new Guid("ae479d49-dcf1-45e2-af98-816bdee1712e");
        public override UserControl DataProviderSettings { get; set; }
        public override string Title { get; set; } = "Otel User Settings";
        public override Image? SmallImage { get; set; } = Resources.Analogy_otel_icon16x16;
        public override Image? LargeImage { get; set; } = Resources.Analogy_otel_icon32x32;
        public override AnalogyToolTip ToolTip { get; set; } = new AnalogyToolTipWithImages("Otel user settings", "", "", Resources.Analogy_image_16x16, Resources.Analogy_image_32x32);

        public override void CreateUserControl(ILogger logger)
        {
            DataProviderSettings = new OtelpUserSettingsUC();
        }

        public override Task SaveSettingsAsync()
        {
            return Task.CompletedTask;
        }
    }
}