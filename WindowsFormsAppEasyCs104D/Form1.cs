using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsAppEasyCs104D
{
    public partial class Form1 : Form
    {
        private TreeView tv;
        private string path = "C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs104D\\WindowsFormsAppEasyCs104D\\";
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "XML Viewer Tree";
            tv = new TreeView();
            tv.Dock = DockStyle.Fill;

            XmlDocument doc = new XmlDocument();
            doc.Load(path + "Sample.xml");

            XmlNode xmlroot = doc.DocumentElement; // Get Root Node
            TreeNode treeroot = new TreeNode();
            treeroot.Text = xmlroot.Name; // Assign Root Node as Tree's Root
            tv.Nodes.Add(treeroot);

            walk(xmlroot, treeroot); // Children
            tv.Parent = this;
        }

        public static void walk(XmlNode xn, TreeNode tn)
        {
            for (XmlNode ch = xn.FirstChild; ch != null; ch = ch.NextSibling)
            {
                TreeNode n = new TreeNode();
                tn.Nodes.Add(n);
                walk(ch, n); // children loop
                if (ch.NodeType == XmlNodeType.Element)
                {
                    n.Text = ch.Name;
                }
                else
                {
                    n.Text = ch.Value;
                }
            }
        }
    }
}