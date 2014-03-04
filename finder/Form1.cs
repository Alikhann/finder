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
        DirectoryInfo dir = new DirectoryInfo(@"G:\breezy.kz");
        String[] files = Directory.GetFiles(@"G:\breezy.kz");
        String[] folders = Directory.GetDirectories(@"G:\breezy.kz");
        List<string> listFilesFound = new List<string>();

        bool flag = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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

        private void xButton1_Click(object sender, EventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xButton2_Click(object sender, EventArgs e)
        {
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void xButton3_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                for (int i = 0; i <= 18; i++)
                {
                    panel2.Location = new Point(panel2.Location.X + i, panel2.Location.Y);
                    System.Threading.Thread.Sleep(10);
                }
                flag = true;
                xButton3.Text = "<";
            }
            else
            {
                for (int i = 0; i <= 18; i++)
                {
                    panel2.Location = new Point(panel2.Location.X - i, panel2.Location.Y);
                    System.Threading.Thread.Sleep(10);
                }
                flag = false;
                xButton3.Text = ">";
            }
        }

        private void xButton2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void xButton6_Click(object sender, EventArgs e)
        {

        }

        private void xButton4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath;
        }






    }
}
