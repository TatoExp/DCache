using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace DCache
{
    public partial class Form1 : Form
    {
        string discordCache = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Discord\\Cache");

        private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                pictureBox1.ImageLocation = listView1.SelectedItems[0].SubItems[2].Text;
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] discordFiles = Directory.GetFiles(discordCache);
            foreach (string path in discordFiles)
            {
                string fileName = Path.GetFileName(path);
                string date = File.GetCreationTime(path).ToString("dd/mm/yyyy HH:mm:ss");

                ListViewItem item = new ListViewItem(fileName);
                item.SubItems.Add(date);
                item.SubItems.Add(path);
                item.ForeColor = SystemColors.ControlLightLight;

                listView1.Items.Add(item);
            }
            listView1.ItemSelectionChanged += ListView1_ItemSelectionChanged;
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
