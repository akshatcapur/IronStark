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
using Microsoft.Win32;
using System.IO;

namespace Redento
{
    public partial class Form2 : Form
    {
        private DriveInfo Drive_Info;

        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "";
            comboBox2.SelectedItem = "";
            comboBox3.SelectedItem = "";
        }

        private void InsertInfo(string Key, ref ListView lst, bool DontInsertNull)
        {
            lst.Items.Clear();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + Key);

            try
            {
                foreach (ManagementObject share in searcher.Get())
                {

                    ListViewGroup grp;
                    try
                    {
                        grp = lst.Groups.Add(share["Name"].ToString(), share["Name"].ToString());
                    }
                    catch
                    {
                        grp = lst.Groups.Add(share.ToString(), share.ToString());
                    }

                    if (share.Properties.Count <= 0)
                    {
                        MessageBox.Show("No Information Available", "No Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    foreach (PropertyData PC in share.Properties)
                    {

                        ListViewItem item = new ListViewItem(grp);
                        if (lst.Items.Count % 2 != 0)
                            item.BackColor = Color.White;
                        else
                            item.BackColor = Color.WhiteSmoke;

                        item.Text = PC.Name;

                        if (PC.Value != null && PC.Value.ToString() != "")
                        {
                            switch (PC.Value.GetType().ToString())
                            {
                                case "System.String[]":
                                    string[] str = (string[])PC.Value;

                                    string str2 = "";
                                    foreach (string st in str)
                                        str2 += st + " ";

                                    item.SubItems.Add(str2);

                                    break;
                                case "System.UInt16[]":
                                    ushort[] shortData = (ushort[])PC.Value;


                                    string tstr2 = "";
                                    foreach (ushort st in shortData)
                                        tstr2 += st.ToString() + " ";

                                    item.SubItems.Add(tstr2);

                                    break;

                                default:
                                    item.SubItems.Add(PC.Value.ToString());
                                    break;
                            }
                        }
                        else
                        {
                            if (!DontInsertNull)
                                item.SubItems.Add("No Information available");
                            else
                                continue;
                        }
                        lst.Items.Add(item);
                    }
                }
            }


            catch (Exception exp)
            {
                MessageBox.Show("can't get data because of the followeing error \n" + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void RemoveNullValue(ref ListView lst)
        {
            foreach (ListViewItem item in lst.Items)
                if (item.SubItems[1].Text == "No Information available")
                    item.Remove();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                RemoveNullValue(ref listView1);
            else
                InsertInfo(comboBox1.SelectedItem.ToString(), ref listView1, checkBox1.Checked);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(comboBox1.SelectedItem.ToString(), ref listView1, checkBox1.Checked);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(comboBox2.SelectedItem.ToString(), ref listView2, checkBox2.Checked);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                RemoveNullValue(ref listView2);
            else
                InsertInfo(comboBox2.SelectedItem.ToString(), ref listView2, checkBox2.Checked);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(comboBox3.SelectedItem.ToString(), ref listView3, checkBox3.Checked);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                RemoveNullValue(ref listView3);
            else
                InsertInfo(comboBox3.SelectedItem.ToString(), ref listView3, checkBox3.Checked);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(comboBox4.SelectedItem.ToString(), ref listView4, checkBox4.Checked);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                RemoveNullValue(ref listView4);
            else
                InsertInfo(comboBox4.SelectedItem.ToString(), ref listView4, checkBox4.Checked);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(comboBox5.SelectedItem.ToString(), ref listView5, checkBox5.Checked);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
                RemoveNullValue(ref listView5);
            else
                InsertInfo(comboBox5.SelectedItem.ToString(), ref listView5, checkBox5.Checked);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
                RemoveNullValue(ref listView6);
            else
                InsertInfo(comboBox6.SelectedItem.ToString(), ref listView6, checkBox6.Checked);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            InsertInfo(comboBox6.SelectedItem.ToString(), ref listView6, checkBox6.Checked);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            for (int i = 0; i <= drives.Length - 1; i++)
            {
                comboBox7.Items.Add(drives[i].Name);
            }
            comboBox7.SelectedIndex = -1;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Drive_Info = new DriveInfo(comboBox7.Text);
            label9.Text = Drive_Info.Name;
            if (Drive_Info.IsReady)
            {
                if (Drive_Info.VolumeLabel.Length > 0)
                {
                    label10.Text = Drive_Info.VolumeLabel;
                }
                else
                {
                    label10.Text = "None";
                }
                label11.Text = Drive_Info.DriveFormat;
                label12.Text = Drive_Info.DriveType.ToString();
                label13.Text = Drive_Info.RootDirectory.FullName;
                label14.Text = Drive_Info.TotalSize + " (Bytes)";
                label15.Text = Drive_Info.TotalFreeSpace + " (Bytes)";
                long usedSpace = 0;
                usedSpace = Drive_Info.TotalSize - Drive_Info.TotalFreeSpace;
                label16.Text = usedSpace + " (Bytes)";
            }

        }

    }
}
