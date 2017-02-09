using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Microsoft.VisualBasic.Devices;
using System.IO;
using Microsoft.Win32;

namespace Redento
{
    public partial class SystemInformation : Form
    {
        public SystemInformation()
        {
            InitializeComponent();
        }

        private void Summary_Load(object sender, EventArgs e)
        {
            label2.Text = System.Environment.OSVersion.Platform.ToString();
            label4.Text = System.Environment.OSVersion.Version.ToString();
            label6.Text = System.Environment.OSVersion.ServicePack.ToString();
            label8.Text = System.Environment.OSVersion.VersionString.ToString();
            label10.Text = System.Environment.Is64BitOperatingSystem.ToString();
            label12.Text = System.Environment.MachineName.ToString();
            label14.Text = System.Environment.Version.ToString();
            label16.Text = System.Environment.UserName.ToString();
            label18.Text = System.Environment.ProcessorCount.ToString();
            label20.Text = System.TimeZone.CurrentTimeZone.StandardName.ToString();
            ComputerInfo CI = new ComputerInfo();
            ulong mem = ulong.Parse(CI.TotalPhysicalMemory.ToString());
            label22.Text = (mem / (1024 * 1024) + " MB").ToString();
            ulong mem1 = ulong.Parse(CI.TotalVirtualMemory.ToString());
            label24.Text = (mem1 / (1024 * 1024) + " MB").ToString();
            ulong mem2 = ulong.Parse(CI.AvailableVirtualMemory.ToString());
            label26.Text = (mem2 / (1024 * 1024) + " MB").ToString();
            ulong mem3 = ulong.Parse(CI.AvailablePhysicalMemory.ToString());
            label28.Text = (mem3 / (1024 * 1024) + " MB").ToString();
            label30.Text = CI.OSFullName.ToString();
            label32.Text = System.Environment.SystemDirectory.ToString();
            label34.Text = System.Environment.SystemPageSize.ToString();
            
        }

       
    }
} 