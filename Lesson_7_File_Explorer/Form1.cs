using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace File_Explorer_Tree
{
    public partial class Form1 : Form
    {
        List <string> fullpath = new List <string> ();
        public string begin_str {  get; set; }
        public string end_str { get; set; }
        public Form1()
        {
            InitializeComponent();
            AddTree();
        }
        private void AddTree()
        {
            try
            {
                int ind = 0;
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    treeView.Nodes.Add(drive.Name);
                    string[] dirs = Directory.GetDirectories(drive.Name);
                    foreach (string s in dirs)
                    {
                        treeView.Nodes[ind].Nodes.Add(Path.GetFileName(s));
                    }
                    ind++;
                }
            }
            catch(Exception ex) { }        
        }
        private void AddDirectoris(string str)//заполнение ListView
        {
            fullpath.Clear();
            try
            {
                string[] dirs = Directory.GetDirectories(str);
                string[] df = Directory.GetFiles(str);
                int ind = 0;
                foreach (string s in dirs)
                {
                    listView.Items.Add(Path.GetFileName(s)).SubItems.Add(Convert.ToString(Directory.GetLastWriteTime(s)));
                    listView.Items[ind].SubItems.Add("Папка с файлами");
                    fullpath.Add(s);
                    ind++;
                }
                foreach (string s in df)
                {
                    listView.Items.Add(Path.GetFileName(s)).SubItems.Add(Convert.ToString(Directory.GetLastWriteTime(s)));
                    listView.Items[ind].SubItems.Add("Файл");
                    fullpath.Add(s);
                    ind++;
                }
            }
            catch
            {
                Exception exception = new Exception();//вылетает при обращении к определенным папкам
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (listView.Items.Count > 0) { listView.Items.Clear(); }
            DirectoryText.Text = treeView.SelectedNode.Text;
            string str = treeView.SelectedNode.FullPath;
            AddDirectoris(str);
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            int ind = (sender as System.Windows.Forms.ListView).SelectedItems[0].Index;
            string str = (sender as System.Windows.Forms.ListView).SelectedItems[0].Text;
            DirectoryText.Text = Path.GetFileName(str);
            if (listView.Items.Count > 0)
            { 
                listView.Items.Clear();
                AddDirectoris(fullpath[ind]);
               
            }
            
        }

        private void Backward_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.Items.Count > 0) { listView.Items.Clear(); }
                string str = Directory.GetDirectoryRoot(DirectoryText.Text);//сразу в корневой каталог
                DirectoryText.Text = str;
                AddDirectoris(str);
            }
           catch(Exception ex) { }
        }

        private void Forward_Click(object sender, EventArgs e)//пока не знаю как
        {
            try
            {
                if (listView.Items.Count > 0) { listView.Items.Clear(); }
                AddDirectoris(DirectoryText.Text);
            }
            catch (Exception ex) { }
        }

    }
}
