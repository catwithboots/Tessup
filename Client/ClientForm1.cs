using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Tessup;

namespace Tessup
{
    public partial class ClientForm1 : Form
    {
        LogHandler myLogger = new LogHandler();
        string logLevel = "Info";

        public ClientForm1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool useInfluxDb=false, useGraphite=false, useLogFile=false;
            foreach(object itemChecked in checkedListBox1.CheckedItems){
                if ((string)itemChecked == "InfluxDb") { useInfluxDb = true; }
                if ((string)itemChecked == "Graphite") { useGraphite = true; }
                if ((string)itemChecked == "LogFile") { useLogFile = true; }
            }
            MetricHandler mymetric = new MetricHandler(useLogFile,useInfluxDb,useGraphite);
            
            List<Metric> mylist=new List<Metric>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells["targetName"].Value != null)
                {
                    mylist.Add(new Metric((string)dr.Cells["targetName"].Value, (string)dr.Cells["objectName"].Value, (string)dr.Cells["valueName"].Value, (object)dr.Cells["Value"].Value));
                }
            }
            mymetric.WriteMetric(mylist);
            mymetric = null;
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            string level=logLevelGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            try
            {
                MethodInfo method = myLogger.GetType().GetMethod(level, new Type[] { typeof(string) });
                method.Invoke(myLogger, new Object[] { logTextBox.Text });
            }
            catch (Exception ex)
            {
                myLogger.Error(string.Format("Unable to log message \"{0}\" with level \"{1}\"; {2}",logTextBox.Text,level,ex.Message));
            }
            //myLogger.Info(logTextBox.Text);
            //logTextBox.Text = System.Reflection.MethodBase.GetCurrentMethod().Name;
        }

        private void logLevel_Changed(object sender, EventArgs e)
        {
            var checkedButton = logLevelGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            logLevel = checkedButton.Text;
        }
    }
}
