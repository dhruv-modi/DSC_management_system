using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSC_management
{
    public partial class Form6 : Form
    {
        Form1 f1;
        public Form6(Form1 fa1)
        {
            f1 = fa1;
            f1.Enabled = false;
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {


            if (keyData == (Keys.Alt | Keys.X))
            {
                this.Close();
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Enabled = true;
            f1.BringToFront();
        }
    }
}
