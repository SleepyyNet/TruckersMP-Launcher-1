﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace tsrvtcnew
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            //gets application directory
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string fullPath = Path.Combine(exeDir, "custom gui");

            Properties.Settings.Default.datapath = fullPath;
            Properties.Settings.Default.Save();

            txtdatapath.Text = Properties.Settings.Default.datapath;

            if (Properties.Settings.Default.tbchk == true)
            {
                cb_tb.Checked = true;
            }
            else
            {
                cb_tb.Checked = false;
            }

            if (Properties.Settings.Default.singleplayer == true)
            {
                cb_etssingle.Checked = true;
            }
            else
            {
                cb_etssingle.Checked = false;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnsave_Click(object sender, EventArgs e)
        {
            if (txtdatapath.Text == "")
            {
                MessageBox.Show("Please select gui location before saving!");
                Form1.errorsound();
                return;
            }

            Properties.Settings.Default.datapath = txtdatapath.Text;
            Properties.Settings.Default.Save();

            Form1.goodsound();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            String Dir = Properties.Settings.Default.datapath;
            Process.Start("explorer.exe", Dir);
        }
        private void btnsave_Leave(object sender, EventArgs e)
        {
            this.btnsave.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }

        void btnsave_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnsave.BackgroundImage = ((Image)(Properties.Resources.hover_img));
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void settings_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnclose_Leave(object sender, EventArgs e)
        {
            this.btnclose.BackgroundImage = ((Image)(Properties.Resources.leave_img));
        }
        void btnclose_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnclose.BackgroundImage = ((Image)(Properties.Resources.cross_hover));
        }

        private void cb_tb_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_tb.Checked == true)
            {
                Properties.Settings.Default.tbchk = true;
                Properties.Settings.Default.Save();
            }
        }

        //resets the program to default... no checks so there can't be any errors coming back when resetting to defaults
        private void btn_reset_Click(object sender, EventArgs e)
        {
            cb_tb.Checked = false;
            cb_etssingle.Checked = false;

            Properties.Settings.Default.tbchk = false;
            Properties.Settings.Default.singleplayer = false;
            Properties.Settings.Default.agreed = false;
            Properties.Settings.Default.launcherpath = "";
            Properties.Settings.Default.message = "";
            Properties.Settings.Default.Save();

            MessageBox.Show("All settings have been set to their Default setting.");
        }

        private void cb_etssingle_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_etssingle.Checked == true)
            {
                Properties.Settings.Default.singleplayer = true;
            }
            else
            {
                Properties.Settings.Default.singleplayer = false;
            }
        }
    }
}
