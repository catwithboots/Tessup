﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Tessup;

namespace Tessup
{
    public partial class ClientForm1 : Form
    {
        readonly LogHandler _myLogger = new LogHandler();
        string _logLevel = "Info";

        public ClientForm1()
        {
            InitializeComponent();

        }

        //private void button1_Click(object sender, EventArgs e)
        private void button1_Click(object sender, EventArgs e)
        {
            bool useInfluxDb=false, useGraphite=false, useLogFile=false;
            foreach(var itemChecked in checkedListBox1.CheckedItems){
                if ((string)itemChecked == "InfluxDb") { useInfluxDb = true; }
                if ((string)itemChecked == "Graphite") { useGraphite = true; }
                if ((string)itemChecked == "LogFile") { useLogFile = true; }
            }
            var mymetric = new Metrics(useLogFile,useInfluxDb,useGraphite);
            var mylist= (from DataGridViewRow dr in dataGridView1.Rows where dr.Cells["targetName"].Value != null select new Metric((string) dr.Cells["targetName"].Value, (string) dr.Cells["objectName"].Value, (string) dr.Cells["valueName"].Value, dr.Cells["Value"].Value)).ToList();
            mymetric.WriteMetric(mylist);
            mymetric = null;    
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            var firstOrDefault = logLevelGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (firstOrDefault == null) return;
            var level=firstOrDefault.Text;
            try
            {
                var method = _myLogger.GetType().GetMethod(level, new[] { typeof(string) });
                method.Invoke(_myLogger, new Object[] { logTextBox.Text });
            }
            catch (Exception ex)
            {
                _myLogger.Error(string.Format("Unable to log message \"{0}\" with level \"{1}\"; {2}",logTextBox.Text,level,ex.Message));
            }
        }

        private void logLevel_Changed(object sender, EventArgs e)
        {
            var checkedButton = logLevelGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            Debug.Assert(checkedButton != null, "checkedButton != null");
            _logLevel = checkedButton.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
