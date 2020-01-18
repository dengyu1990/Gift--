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
using System.IO;

namespace Gift
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }
        StringCollection tmps = new StringCollection();
        private void frmConfig_Load(object sender, EventArgs e)
        {
            tmps = Properties.Settings.Default.names;
            foreach (string name in tmps)
            {
                lstName.Items.Add(name);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (name != "" && !lstName.Items.Contains(name))
            {
                Form1.names.Add(name);
                lstName.Items.Add(name);
                tmps.Add(name);
            }
            txtName.Text = "";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstName.SelectedItems.Count > 0)
            {
                string strSelected = lstName.SelectedItem.ToString();
                if (lstName.Items.Contains(strSelected))
                {
                    Form1.names.Remove(strSelected);
                    lstName.Items.Remove(strSelected);
                    tmps.Remove(strSelected);
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.names = tmps;
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            MessageBox.Show("抽奖名单更新已生效！", "配置成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.names.Clear();
            lstName.Items.Clear();
            tmps.Clear();
            MessageBox.Show("已经清除所有抽奖人！", "清除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"D:\names.txt", Encoding.Default);
            Form1.names.Clear();
            lstName.Items.Clear();
            tmps.Clear();

            foreach (string line in lines)
            {
                lstName.Items.Add(line);
                tmps.Add(line);
            }
            Properties.Settings.Default.names = tmps;
            Properties.Settings.Default.Save();
            MessageBox.Show("导入成功，已实时生效！", "抽奖人导入", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

    }
}
