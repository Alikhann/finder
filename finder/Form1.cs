using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace finder
{
    public partial class Form1 : Form
    {
        DirectoryInfo dir = new DirectoryInfo(@"D:\Ali");
        String[] files = Directory.GetFiles(@"D:\Ali");
        String[] folders = Directory.GetDirectories(@"D:\Ali");
        List<string> listFilesFound = new List<string>();

        private Point mouseOffset;
        private bool isMouseDown = false;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Items.Clear();
            foreach (var folder in folders)
                listBox1.Items.Add(folder);

            foreach (var file in files)
            {
                var res = Path.GetFileName(file);
                listBox1.Items.Add(file);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            string fileName = listBox1.SelectedItem.ToString();
            //string fullPath = Path.GetFullPath(fileName); 
            //FileInfo f = new FileInfo(fileName);
            //string fullName = f.FullName;
            //textBox1.Text = fileName;
            if (!File.Exists(fileName))
            {
                Process.Start("explorer.exe", @fileName);
                //throw new FileNotFoundException("The file was not found", fileName);
            }
            else
            {
                Process.Start(fileName);

            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string asd = textBox1.Text;

        }

        private void DirSearch(string sDir) 
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                        listBox1.Items.Add(f);
                    DirSearch(d);
                }
            }
            catch (System.Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            this.Opacity = 0.6; //добавил
            Message m = Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
            /*
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }

            if (e.Button == MouseButtons.Right)
                this.Opacity = 0.5;
             */ 
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
             */ 
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Changes the isMouseDown field so that the form does
            // not move unless the user is pressing the left mouse button.
                
                this.Opacity = 1;
                textBox1.Text = "UP";
        }
    }
}
