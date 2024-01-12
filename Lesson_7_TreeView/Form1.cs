using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lesson_7_TreeView
{
    public partial class Form1 : Form
    {
       public ImageList imageList = new ImageList();//лист иконок для отображения
        public Form1()
        {
            InitializeComponent();
            AddTree();
        }
        private void AddTree()
        {
           
            string s = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"icon\";//адоес debug папки из текущего репозитория
            string[] df = Directory.GetFiles(s);
            foreach (var item in df)
            {
                imageList.Images.Add(Image.FromFile(item));
            }
            treeView.ImageList = imageList;//нужно проинициализировать лист каритнок именно этого treeView
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode node = new TreeNode(drive.Name);
                    treeView.Nodes.Add(string.Empty, node.Text,0);
                    AddNodes(node);
                    node.Toggle();
                }
            }
            catch (Exception ex) { }

        }
      private void AddNodes(TreeNode node)
        {
            if(node.Nodes.Count==0)
            {
                try
                {
                    string[] dirs = Directory.GetDirectories(node.FullPath);
                    string[] df = Directory.GetFiles(node.FullPath);
                    int ind = 0;
                    foreach (string s in dirs)
                    {
                        node.Nodes.Add(string.Empty, Path.GetFileName(s),1);
                    }
                    foreach (string s in df)
                    {
                        node.Nodes.Add(string.Empty, Path.GetFileName(s),2);
                    }
                }
                catch
                {
                    Exception exception = new Exception();//вылетает при обращении к определенным папкам
                }
            }
        }
        private void BackMenu_Click(object sender, EventArgs e)
        {
            MenuTextBox.Text = Directory.GetDirectoryRoot(MenuTextBox.Text);
        }
        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string str = e.Node.FullPath;
            AddNodes(e.Node);
            e.Node.Toggle();
        }
    }
}
