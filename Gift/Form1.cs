using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gift
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static StringCollection names = new StringCollection();
        
        Random rnd = new Random();
        
        private void btnGO_Click(object sender, EventArgs e)
        {
            if (!tmrDisplay.Enabled)
            {
                tmrDisplay.Enabled = true;
                //btnConfig.Enabled = false;
                return;
            }
            if (names.Count > 0)
            {
                tmrDisplay.Enabled = false;
                
                names.Remove(lblName.Text);
            }                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            names = Properties.Settings.Default.names;
            lblNums.Text = names.Count.ToString();
        }

        private void tmrDisplay_Tick(object sender, EventArgs e)
        {
            int nums = names.Count;
            lblNums.Text = nums.ToString();
            if(nums > 0)
                lblName.Text = names[rnd.Next(nums)];
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            tmrDisplay.Enabled = false;
            frmConfig cfg = new frmConfig();
            cfg.ShowDialog();
            if (cfg.DialogResult == DialogResult.OK)
            {
                btnConfig.Enabled = true;
                Properties.Settings.Default.Reload();
                names = Properties.Settings.Default.names;
                //tmrDisplay.Enabled = true;
            }              
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
