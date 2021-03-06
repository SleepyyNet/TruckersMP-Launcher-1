﻿using System;
using System.Windows.Forms;

namespace tsrvtcnew
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        //handler for moving the form around
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Help_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //exit button control
        private void Btn_help_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //transparent background for when the user leaves the hovering button
        private void Btn_help_exit_Leave(object sender, EventArgs e)
        {
            this.btn_help_exit.BackgroundImage = Properties.Resources.leave_img;
        }

        //hover-over image for basic buttons
        void Btn_help_exit_MouseMove(object sender, MouseEventArgs e)
        {
            this.btn_help_exit.BackgroundImage = Properties.Resources.cross_hover;
        }

        //tutorial button controls
        private void Btnhelpvids_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/playlist?list=PL1QbbJCBdwOJ10bgBPLyPD7m8MA8lzB7V");
        }
        private void Btnhelpvids_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnhelpvids.ForeColor = System.Drawing.Color.FromArgb(255, 192, 128);
        }
        private void Btnhelpvids_Leave(object sender, EventArgs e)
        {
            this.btnhelpvids.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
        }

        //bug button controls
        private void Btn_bf_MouseMove(object sender, MouseEventArgs e)
        {
            this.btn_bf.ForeColor = System.Drawing.Color.FromArgb(255, 192, 128);
        }
        private void Btn_bf_Leave(object sender, EventArgs e)
        {
            this.btn_bf.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
        }
        private void Btn_bf_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://goo.gl/forms/MCuur032uOhz77wM2");
        }
    }
}
