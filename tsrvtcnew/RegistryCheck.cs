﻿using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace tsrvtcnew
{
    class RegistryCheck
    {
        public static void Read()
        {
            try
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                using (var key = hklm.OpenSubKey(@"SOFTWARE\TruckersMP"))
                {
                    if (key != null)
                    {
                        Properties.Settings.Default.ETS2Location = (string)key.GetValue("InstallLocationETS2");
                        Properties.Settings.Default.launcherpath = (string)key.GetValue("InstallDir");
                        Properties.Settings.Default.Save();

                        if (Properties.Settings.Default.ETS2Location != null && Properties.Settings.Default.launcherpath != null)
                        {
                            GameHandle.Launch();
                        }
                        else if (Properties.Settings.Default.ETS2Location == null)
                        {
                            string error = "Euro Truck Simulator 2 is not installed on this system";
                            Loghandling.Logerror(error);
                            Environment.Exit(1);
                        }
                    }
                    else if (Properties.Settings.Default.launcherpath == null)
                    {
                        DialogResult dialogResult = MessageBox.Show("TruckersMP has not been installed!\n\nPlease run the TruckersMP installer once.\n\nWant to do it now? ", "TruckersMP gamecheck", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("http://truckersmp.com/en_US/download");
                            Environment.Exit(1);
                        }
                        else
                        {
                            Environment.Exit(1);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.ToString();
                Loghandling.Logerror(error);
            }
        }
    }
}
