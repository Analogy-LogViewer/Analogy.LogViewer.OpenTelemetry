
namespace Analogy.LogViewer.OpenTelemetry.IAnalogy
{
    partial class OtelMetricsViewerUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMetric = new System.Windows.Forms.Label();
            btnGenerator = new System.Windows.Forms.Button();
            btnGeneratorHide = new System.Windows.Forms.Button();
            treeViewMetrics = new System.Windows.Forms.TreeView();
            BtnRefresh = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            lblSelection = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblMetric
            // 
            lblMetric.Dock = System.Windows.Forms.DockStyle.Top;
            lblMetric.Location = new System.Drawing.Point(0, 29);
            lblMetric.Name = "lblMetric";
            lblMetric.Size = new System.Drawing.Size(501, 20);
            lblMetric.TabIndex = 0;
            lblMetric.Text = "Select Metric:";
            // 
            // btnGenerator
            // 
            btnGenerator.Enabled = false;
            btnGenerator.Location = new System.Drawing.Point(507, 104);
            btnGenerator.Name = "btnGenerator";
            btnGenerator.Size = new System.Drawing.Size(131, 29);
            btnGenerator.TabIndex = 8;
            btnGenerator.Text = "View Metric";
            btnGenerator.UseVisualStyleBackColor = true;
            btnGenerator.Click += btnGenerator_Click;
            // 
            // btnGeneratorHide
            // 
            btnGeneratorHide.Location = new System.Drawing.Point(644, 104);
            btnGeneratorHide.Name = "btnGeneratorHide";
            btnGeneratorHide.Size = new System.Drawing.Size(131, 29);
            btnGeneratorHide.TabIndex = 7;
            btnGeneratorHide.Text = "Close Metric";
            btnGeneratorHide.UseVisualStyleBackColor = true;
            btnGeneratorHide.Click += btnGeneratorHide_Click;
            // 
            // treeViewMetrics
            // 
            treeViewMetrics.Dock = System.Windows.Forms.DockStyle.Fill;
            treeViewMetrics.Location = new System.Drawing.Point(0, 49);
            treeViewMetrics.Name = "treeViewMetrics";
            treeViewMetrics.Size = new System.Drawing.Size(501, 340);
            treeViewMetrics.TabIndex = 11;
            treeViewMetrics.AfterSelect += treeViewMetrics_AfterSelect;
            // 
            // BtnRefresh
            // 
            BtnRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            BtnRefresh.Location = new System.Drawing.Point(0, 0);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new System.Drawing.Size(501, 29);
            BtnRefresh.TabIndex = 12;
            BtnRefresh.Text = "Refresh List";
            BtnRefresh.UseVisualStyleBackColor = true;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(treeViewMetrics);
            panel1.Controls.Add(lblMetric);
            panel1.Controls.Add(BtnRefresh);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(501, 389);
            panel1.TabIndex = 13;
            // 
            // lblSelection
            // 
            lblSelection.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblSelection.Location = new System.Drawing.Point(507, 49);
            lblSelection.Name = "lblSelection";
            lblSelection.Size = new System.Drawing.Size(430, 40);
            lblSelection.TabIndex = 14;
            lblSelection.Text = "Selected Metric: N/A";
            // 
            // OtelMetricsViewerUC
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(lblSelection);
            Controls.Add(panel1);
            Controls.Add(btnGenerator);
            Controls.Add(btnGeneratorHide);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "OtelMetricsViewerUC";
            Size = new System.Drawing.Size(940, 389);
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMetric;
        private System.Windows.Forms.Button btnGenerator;
        private System.Windows.Forms.Button btnGeneratorHide;
        private System.Windows.Forms.TreeView treeViewMetrics;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSelection;
    }
}
