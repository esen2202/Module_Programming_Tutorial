using ModuleManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleWPF
{
    public partial class Form1 : Form
    {
        public static List<Parameter> list = new List<Parameter>(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
                list.Add(new Parameter { Key = textBox1.Text, Value = textBox2.Text});
            dataGridView1.EndEdit();
            dataGridView1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            dataGridView1.DataSource = list;
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            list.Clear();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
             this.Close();
        }
    }
}
