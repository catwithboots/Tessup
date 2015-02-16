namespace Tessup
{
    partial class ClientForm1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MetricName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.logButton = new System.Windows.Forms.Button();
            this.traceRadioButton = new System.Windows.Forms.RadioButton();
            this.debugRadioButton = new System.Windows.Forms.RadioButton();
            this.infoRadioButton = new System.Windows.Forms.RadioButton();
            this.warningRadioButton = new System.Windows.Forms.RadioButton();
            this.errorRadioButton = new System.Windows.Forms.RadioButton();
            this.fatalRadioButton = new System.Windows.Forms.RadioButton();
            this.verboseRadioButton = new System.Windows.Forms.RadioButton();
            this.logLevelGroupBox = new System.Windows.Forms.GroupBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.logTabPage = new System.Windows.Forms.TabPage();
            this.metricsTabPage = new System.Windows.Forms.TabPage();
            this.statusTabPage = new System.Windows.Forms.TabPage();
            this.sharedTabPage = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.logLevelGroupBox.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.logTabPage.SuspendLayout();
            this.metricsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "WriteMetric";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MetricName,
            this.Value});
            this.dataGridView1.Location = new System.Drawing.Point(6, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // MetricName
            // 
            this.MetricName.HeaderText = "Name";
            this.MetricName.Name = "MetricName";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "InfluxDb",
            "Graphite",
            "LogFile"});
            this.checkedListBox1.Location = new System.Drawing.Point(252, 91);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 2;
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(6, 60);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(335, 20);
            this.logTextBox.TabIndex = 3;
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(348, 57);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(75, 23);
            this.logButton.TabIndex = 4;
            this.logButton.Text = "Log Me!";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // traceRadioButton
            // 
            this.traceRadioButton.AutoSize = true;
            this.traceRadioButton.Location = new System.Drawing.Point(6, 19);
            this.traceRadioButton.Name = "traceRadioButton";
            this.traceRadioButton.Size = new System.Drawing.Size(53, 17);
            this.traceRadioButton.TabIndex = 6;
            this.traceRadioButton.TabStop = true;
            this.traceRadioButton.Text = "Trace";
            this.traceRadioButton.UseVisualStyleBackColor = true;
            this.traceRadioButton.CheckedChanged += new System.EventHandler(this.logLevel_Changed);
            // 
            // debugRadioButton
            // 
            this.debugRadioButton.AutoSize = true;
            this.debugRadioButton.Location = new System.Drawing.Point(65, 19);
            this.debugRadioButton.Name = "debugRadioButton";
            this.debugRadioButton.Size = new System.Drawing.Size(57, 17);
            this.debugRadioButton.TabIndex = 7;
            this.debugRadioButton.TabStop = true;
            this.debugRadioButton.Text = "Debug";
            this.debugRadioButton.UseVisualStyleBackColor = true;
            this.debugRadioButton.CheckedChanged += new System.EventHandler(this.logLevel_Changed);
            // 
            // infoRadioButton
            // 
            this.infoRadioButton.AutoSize = true;
            this.infoRadioButton.Checked = true;
            this.infoRadioButton.Location = new System.Drawing.Point(128, 19);
            this.infoRadioButton.Name = "infoRadioButton";
            this.infoRadioButton.Size = new System.Drawing.Size(43, 17);
            this.infoRadioButton.TabIndex = 8;
            this.infoRadioButton.TabStop = true;
            this.infoRadioButton.Text = "Info";
            this.infoRadioButton.UseVisualStyleBackColor = true;
            this.infoRadioButton.CheckedChanged += new System.EventHandler(this.logLevel_Changed);
            // 
            // warningRadioButton
            // 
            this.warningRadioButton.AutoSize = true;
            this.warningRadioButton.Location = new System.Drawing.Point(174, 19);
            this.warningRadioButton.Name = "warningRadioButton";
            this.warningRadioButton.Size = new System.Drawing.Size(65, 17);
            this.warningRadioButton.TabIndex = 9;
            this.warningRadioButton.Text = "Warning";
            this.warningRadioButton.UseVisualStyleBackColor = true;
            this.warningRadioButton.CheckedChanged += new System.EventHandler(this.logLevel_Changed);
            // 
            // errorRadioButton
            // 
            this.errorRadioButton.AutoSize = true;
            this.errorRadioButton.Location = new System.Drawing.Point(245, 19);
            this.errorRadioButton.Name = "errorRadioButton";
            this.errorRadioButton.Size = new System.Drawing.Size(47, 17);
            this.errorRadioButton.TabIndex = 10;
            this.errorRadioButton.Text = "Error";
            this.errorRadioButton.UseVisualStyleBackColor = true;
            this.errorRadioButton.CheckedChanged += new System.EventHandler(this.logLevel_Changed);
            // 
            // fatalRadioButton
            // 
            this.fatalRadioButton.AutoSize = true;
            this.fatalRadioButton.Location = new System.Drawing.Point(298, 19);
            this.fatalRadioButton.Name = "fatalRadioButton";
            this.fatalRadioButton.Size = new System.Drawing.Size(48, 17);
            this.fatalRadioButton.TabIndex = 11;
            this.fatalRadioButton.Text = "Fatal";
            this.fatalRadioButton.UseVisualStyleBackColor = true;
            this.fatalRadioButton.CheckedChanged += new System.EventHandler(this.logLevel_Changed);
            // 
            // verboseRadioButton
            // 
            this.verboseRadioButton.AutoSize = true;
            this.verboseRadioButton.Location = new System.Drawing.Point(352, 19);
            this.verboseRadioButton.Name = "verboseRadioButton";
            this.verboseRadioButton.Size = new System.Drawing.Size(64, 17);
            this.verboseRadioButton.TabIndex = 12;
            this.verboseRadioButton.Text = "Verbose";
            this.verboseRadioButton.UseVisualStyleBackColor = true;
            this.verboseRadioButton.CheckedChanged += new System.EventHandler(this.logLevel_Changed);
            // 
            // logLevelGroupBox
            // 
            this.logLevelGroupBox.Controls.Add(this.traceRadioButton);
            this.logLevelGroupBox.Controls.Add(this.verboseRadioButton);
            this.logLevelGroupBox.Controls.Add(this.debugRadioButton);
            this.logLevelGroupBox.Controls.Add(this.fatalRadioButton);
            this.logLevelGroupBox.Controls.Add(this.infoRadioButton);
            this.logLevelGroupBox.Controls.Add(this.errorRadioButton);
            this.logLevelGroupBox.Controls.Add(this.warningRadioButton);
            this.logLevelGroupBox.Location = new System.Drawing.Point(6, 6);
            this.logLevelGroupBox.Name = "logLevelGroupBox";
            this.logLevelGroupBox.Size = new System.Drawing.Size(417, 48);
            this.logLevelGroupBox.TabIndex = 13;
            this.logLevelGroupBox.TabStop = false;
            this.logLevelGroupBox.Text = "LogLevel";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.logTabPage);
            this.mainTabControl.Controls.Add(this.metricsTabPage);
            this.mainTabControl.Controls.Add(this.statusTabPage);
            this.mainTabControl.Controls.Add(this.sharedTabPage);
            this.mainTabControl.Location = new System.Drawing.Point(0, 1);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1014, 523);
            this.mainTabControl.TabIndex = 15;
            // 
            // logTabPage
            // 
            this.logTabPage.Controls.Add(this.logLevelGroupBox);
            this.logTabPage.Controls.Add(this.logTextBox);
            this.logTabPage.Controls.Add(this.logButton);
            this.logTabPage.Location = new System.Drawing.Point(4, 22);
            this.logTabPage.Name = "logTabPage";
            this.logTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.logTabPage.Size = new System.Drawing.Size(1006, 497);
            this.logTabPage.TabIndex = 0;
            this.logTabPage.Text = "Logging";
            this.logTabPage.UseVisualStyleBackColor = true;
            // 
            // metricsTabPage
            // 
            this.metricsTabPage.Controls.Add(this.button1);
            this.metricsTabPage.Controls.Add(this.dataGridView1);
            this.metricsTabPage.Controls.Add(this.checkedListBox1);
            this.metricsTabPage.Location = new System.Drawing.Point(4, 22);
            this.metricsTabPage.Name = "metricsTabPage";
            this.metricsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.metricsTabPage.Size = new System.Drawing.Size(1006, 497);
            this.metricsTabPage.TabIndex = 1;
            this.metricsTabPage.Text = "Metrics";
            this.metricsTabPage.UseVisualStyleBackColor = true;
            // 
            // statusTabPage
            // 
            this.statusTabPage.Location = new System.Drawing.Point(4, 22);
            this.statusTabPage.Name = "statusTabPage";
            this.statusTabPage.Size = new System.Drawing.Size(1006, 497);
            this.statusTabPage.TabIndex = 2;
            this.statusTabPage.Text = "Status";
            this.statusTabPage.UseVisualStyleBackColor = true;
            // 
            // sharedTabPage
            // 
            this.sharedTabPage.Location = new System.Drawing.Point(4, 22);
            this.sharedTabPage.Name = "sharedTabPage";
            this.sharedTabPage.Size = new System.Drawing.Size(1006, 497);
            this.sharedTabPage.TabIndex = 3;
            this.sharedTabPage.Text = "Shared";
            this.sharedTabPage.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 527);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1014, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ClientForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 549);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainTabControl);
            this.Name = "ClientForm1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.logLevelGroupBox.ResumeLayout(false);
            this.logLevelGroupBox.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.logTabPage.ResumeLayout(false);
            this.logTabPage.PerformLayout();
            this.metricsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.RadioButton traceRadioButton;
        private System.Windows.Forms.RadioButton debugRadioButton;
        private System.Windows.Forms.RadioButton infoRadioButton;
        private System.Windows.Forms.RadioButton warningRadioButton;
        private System.Windows.Forms.RadioButton errorRadioButton;
        private System.Windows.Forms.RadioButton fatalRadioButton;
        private System.Windows.Forms.RadioButton verboseRadioButton;
        private System.Windows.Forms.GroupBox logLevelGroupBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetricName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage logTabPage;
        private System.Windows.Forms.TabPage metricsTabPage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage statusTabPage;
        private System.Windows.Forms.TabPage sharedTabPage;
    }
}

