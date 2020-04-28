using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DSC_management
{
    public partial class Form1 : Form
    {
        SQLiteCommand sqlite_cmd;
        SQLiteConnection m_dbConnection;
        int but_stat = 0;
        public Form1(SQLiteConnection m_db)
        {
            m_dbConnection = m_db;
            sqlite_cmd = m_db.CreateCommand();
            sqlite_cmd.CommandType = CommandType.Text;
            but_stat = 0;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 3;

            button6.BackColor = System.Drawing.Color.Tomato;
            button7.BackColor = System.Drawing.Color.GreenYellow;
            button8.BackColor = System.Drawing.Color.Tomato;
            button9.BackColor = System.Drawing.Color.Tomato;
            button10.BackColor = System.Drawing.Color.Tomato;
            button11.BackColor = System.Drawing.Color.Tomato;


            label3.Text = "Activity:";
            label7.Text = "Status:";
            comboBox3.Items.Add("Active");
            comboBox3.Items.Add("Inactive");
            comboBox3.SelectedItem="Active";
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label17.Visible = false;

            textBox1.Text = "";
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;


        }

        private void button11_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 1;

            button6.BackColor = System.Drawing.Color.Tomato;
            button7.BackColor = System.Drawing.Color.Tomato;
            button8.BackColor = System.Drawing.Color.Tomato;
            button9.BackColor = System.Drawing.Color.Tomato;
            button10.BackColor = System.Drawing.Color.Tomato;
            button11.BackColor = System.Drawing.Color.GreenYellow;


            label3.Text = "Location:";
            label4.Text = "Inward Date:";
            label5.Text = "Inward By:";
            label6.Text = "Receive mode:";
            label7.Text = "Activity:";
            label8.Text = "DSC model:";
            label9.Text = "DSC make:";
            label10.Text = "DSC color:";
            label11.Text = "Inward charge:";
            label12.Text = "Initialize return:";
            label13.Text = "Return on";
            label14.Text = "or in ";
            label15.Text = "days";
         //   label16.Text = "";
            label17.Text = "DSC UID:";

            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label17.Visible = true;

            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;

            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;
            comboBox6.Visible = true;
            comboBox7.Visible = true;

            comboBox3.ResetText();
            comboBox3.Items.Clear();



        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 2;

            button6.BackColor = System.Drawing.Color.GreenYellow;
            button7.BackColor = System.Drawing.Color.Tomato;
            button8.BackColor = System.Drawing.Color.Tomato;
            button9.BackColor = System.Drawing.Color.Tomato;
            button10.BackColor = System.Drawing.Color.Tomato;
            button11.BackColor = System.Drawing.Color.Tomato;


            label3.Text = "Emp Name:";
            label7.Text = "Status:";
            comboBox3.Items.Add("Active");
            comboBox3.Items.Add("Inactive");
            comboBox3.SelectedItem = "Active";
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label17.Visible = false;

            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
        }

        private void button8_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 4;

            button6.BackColor = System.Drawing.Color.Tomato;
            button7.BackColor = System.Drawing.Color.Tomato;
            button8.BackColor = System.Drawing.Color.GreenYellow;
            button9.BackColor = System.Drawing.Color.Tomato;
            button10.BackColor = System.Drawing.Color.Tomato;
            button11.BackColor = System.Drawing.Color.Tomato;



            label3.Text = "Mfg Name:";
            
            label4.Text = "Model:";
            label5.Text = "Color:";
            label7.Text = "Status:";
            comboBox3.Items.Add("Active");
            comboBox3.Items.Add("Inactive");
            comboBox3.SelectedItem = "Active";
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label17.Visible = false;

            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = false;
            textBox8.Visible = false;

            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
        }

        private void button9_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 5;

            button6.BackColor = System.Drawing.Color.Tomato;
            button7.BackColor = System.Drawing.Color.Tomato;
            button8.BackColor = System.Drawing.Color.Tomato;
            button9.BackColor= System.Drawing.Color.GreenYellow;
            button10.BackColor = System.Drawing.Color.Tomato;
            button11.BackColor = System.Drawing.Color.Tomato;



            label3.Text = "Name:";
            label4.Text = "Address1:";
            label6.Text = "Address2:";
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = true;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label17.Visible = false;

            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = true;
            textBox8.Visible = true;

            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
        }

        private void button10_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 6;


            button6.BackColor = System.Drawing.Color.Tomato;
            button7.BackColor = System.Drawing.Color.Tomato;
            button8.BackColor = System.Drawing.Color.Tomato;
            button9.BackColor = System.Drawing.Color.Tomato;
            button10.BackColor = System.Drawing.Color.GreenYellow;
            button11.BackColor = System.Drawing.Color.Tomato;
        }

        private void button12_MouseClick(object sender, MouseEventArgs e)
        {
            if(but_stat==3)
            {
                if(comboBox3.SelectedItem.Equals("Active"))
                {
                    sqlite_cmd.CommandText = "INSERT INTO activity_master (activity, active) VALUES('"+textBox1.Text+"', 1); ";
                    MessageBox.Show("INSERT INTO activity_master (activity, active) VALUES('" + textBox1.Text + "', 1); ");
                }
                else
                {
                    sqlite_cmd.CommandText = "INSERT INTO activity_master (activity, active) VALUES('" + textBox1.Text + "', 0); ";

                }
                if(textBox1.Text.Equals(""))
                {
                    MessageBox.Show("Activity field cannot be empty");
                }
                else
                {
                    try
                    {
                        MessageBox.Show("Activity field cannot be empty");
                        sqlite_cmd.ExecuteNonQuery();
                    }
                    catch(Exception e1)
                    {
                        MessageBox.Show(e1+"");
                    }
                }
                textBox1.Text = "";
            }

            
        }
    }
}
