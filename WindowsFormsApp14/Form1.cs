using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp14.studentDataSetTableAdapters;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void studentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.studentDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.studentDataSet.student);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            student c = new student();
            bool resLog = false;
            studentDataSet ds = studentDataSet;
            resLog = c.checkLogin(textBox1.Text, textBox2.Text, ds);
            if (resLog)
            {
                Form2 frm1 = new Form2();
                frm1.ShowDialog();
                frm1.Activate();
                this.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show("ใส่ข้อมูลผิด");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
