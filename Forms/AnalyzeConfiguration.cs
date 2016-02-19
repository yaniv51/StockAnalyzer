using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class AnalyzeConfiguration : Form
    {
        MyConfiguration config;
        bool offlineView;
        public string OfflinePath { get; set; }
        int minimumDays, minimumParams;
        float t1, t2;

        public AnalyzeConfiguration(bool offline = false)
        {
            InitializeComponent();
            config = null;
            offlineView = offline;
            minimumDays = 30;
            minimumParams = 1;
            t1 = 8.0f;
            t2 = 1.0f;
            ChangeStocksValue();
            //this.BackgroundImage = Properties.Resources.free_stock;
        }

        private void clusterTrackBar_Scroll(object sender, EventArgs e)
        {
            clusterNumberLable.Text = clusterTrackBar.Value.ToString();
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            if(!(openCheckBox.Checked || closeCheckBox.Checked || highCheckBox.Checked || lowCheckBox.Checked))
            {
                MessageBox.Show("Could not execute. Need to choose at least one param.");
                return;
            }
            config = new MyConfiguration(clusterTrackBar.Value, Convert.ToInt32(stocksInput.Value), Convert.ToInt32(daysNumericUpDown.Value), openCheckBox.Checked, closeCheckBox.Checked, highCheckBox.Checked, lowCheckBox.Checked);
            config.T1 = (float)Convert.ToDouble(t1TextBox.Text);
            config.T2 = (float)Convert.ToDouble(t2TextBox.Text);
            this.DialogResult = DialogResult.OK;
            if(offlineView)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    OfflinePath = ofd.FileName;
                }
            }
            this.Hide();
        }

        public MyConfiguration Config
        {
            get { return config; }
        }

        private void autoTCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(autoTCheckBox.Checked)
            {
                t1TextBox.Enabled = false;
                t2TextBox.Enabled = false;
            }
            else
            {
                t1TextBox.Enabled = true;
                t2TextBox.Enabled = true;
            }
        }

        private void stocksInput_ValueChanged(object sender, EventArgs e)
        {
            ChangeStocksValue();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangeStocksValue();
        }

        private void ChangeStocksValue()
        {
            t1TextBox.Text = String.Format("{0:00.0}",(t1 * ((Convert.ToDouble(daysNumericUpDown.Value) / minimumDays) + (CountChecks() / 2) / minimumParams)));
            t2TextBox.Text = String.Format("{0:00.0}",((t2 * ((Convert.ToDouble(daysNumericUpDown.Value) / minimumDays) + (CountChecks() / 2) / minimumParams))));
        }

        private int CountChecks()
        {
            int counter = 0;
            if (openCheckBox.Checked)
                counter++;
            if (closeCheckBox.Checked)
                counter++;
            if (highCheckBox.Checked)
                counter++;
            if (lowCheckBox.Checked)
                counter++;
            if (counter == 0)
                counter = 1;
            return counter;
        }
    }
}
