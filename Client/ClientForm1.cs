using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Tessup;

namespace Tessup
{
    public partial class ClientForm1 : Form
    {
        public ClientForm1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MetricHandler mymetric = new MetricHandler();
            List<Metric> mylist=new List<Metric>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                Metric m = new Metric();
                m.Name = (string)dr.Cells["Name"].Value;
                m.Value = dr.Cells["Value"].Value;
                mylist.Add(m);
            }
            mymetric.WriteMetric(mylist);
        }
    }
}
