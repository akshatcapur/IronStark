using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SystemInformation S1 = new SystemInformation();
            S1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 F1 = new Form2();
            F1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void systemInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void hardwareInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemInformation S1 = new SystemInformation();
            S1.ShowDialog();
        }

        private void softwareInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 F1 = new Form2();
            F1.ShowDialog();
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void endToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
