using Analogy.LogViewer.OpenTelemetryCollector.Managers;
using System;
using System.Windows.Forms;

namespace Analogy.LogViewer.OpenTelemetryCollector
{
    public partial class OtelpUserSettingsUC : UserControl
    {
        public OtelpUserSettingsUC()
        {
            InitializeComponent();
        }

        private void grpcUserSettingsUC_Load(object sender, EventArgs e)
        {
            txtbRealTimeServerURL.Text = UserSettingsManager.UserSettings.Settings.GRPCAddress;
            txtbSelfHostingServerURL.Text = UserSettingsManager.UserSettings.Settings.SelfHostingServerPort.ToString();
        }

        private void txtbRealTimeServerURL_TextChanged(object sender, EventArgs e)
        {
            UserSettingsManager.UserSettings.Settings.GRPCAddress = txtbRealTimeServerURL.Text;
        }

        private void txtbSelfHostingServerURL_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtbSelfHostingServerURL.Text, out int port))
            {
                UserSettingsManager.UserSettings.Settings.SelfHostingServerPort = port;
            }
        }
    }
}