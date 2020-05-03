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
        int inco = 0;
        int id = 0;
        int updt = 0;
        SQLiteCommand sqlite_cmd;
        SQLiteConnection m_dbConnection;
        SQLiteDataReader sqlite_datareader;
        int but_stat = 0;
        public Form1(SQLiteConnection m_db)
        {
            m_dbConnection = m_db;
            sqlite_cmd = m_db.CreateCommand();
            
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
            
            but_stat = 7;

            button1.Enabled = false;
            button2.Enabled=false;

            button1.BackColor = System.Drawing.Color.White;
            button2.BackColor = System.Drawing.Color.White;
            button6.BackColor = System.Drawing.Color.Tomato;
            button7.BackColor = System.Drawing.Color.GreenYellow;
            button8.BackColor = System.Drawing.Color.Tomato;
            button9.BackColor = System.Drawing.Color.Tomato;
            button10.BackColor = System.Drawing.Color.Tomato;
            button11.BackColor = System.Drawing.Color.Tomato;

            button12.Text = "Submit";
            button13.Text = "Reset";

            label3.Text = "Activity:";
            label7.Text = "Status:";

            comboBox3.Items.Clear();
            comboBox3.Items.Add("Active");
            comboBox3.Items.Add("Inactive");
            comboBox3.SelectedItem="Active";
            {
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = true;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;

                textBox1.Text = "";
                textBox1.Visible = true;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;
                textBox21.Visible = false;
                textBox22.Visible = false;


                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;

                comboBox1.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = true;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                label3.Enabled = true;
                label4.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                label7.Enabled = true;
                label8.Enabled = true;
                label9.Enabled = true;
                label10.Enabled = true;
                label12.Enabled = true;
                label13.Enabled = true;
                label14.Enabled = true;
                label15.Enabled = true;
                label17.Enabled = true;
                label18.Enabled = true;
                label19.Enabled = true;
                label20.Enabled = true;


                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                textBox12.Enabled = true;



                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;


                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;


                label22.Enabled = true;
                label23.Enabled = true;
                label24.Enabled = true;
                label25.Enabled = true;
                label26.Enabled = true;
                label27.Enabled = true;
                label28.Enabled = true;

                textBox19.Enabled = true;
                textBox20.Enabled = true;
                textBox21.Enabled = true;
                textBox22.Enabled = true;


                comboBox12.Enabled = true;
                comboBox13.Enabled = true;

                dateTimePicker3.Enabled = true;
            }
                changeDG();

        }

        private void button11_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 11;

            button1.Enabled = true;
            button2.Enabled = true;

            button1.BackColor = System.Drawing.Color.GreenYellow;
            button2.BackColor = System.Drawing.Color.Tomato;
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
            label22.Text = "Outward Charge:";
            label23.Text = "Collected By:";
            label25.Text = "Outward date:";
            label26.Text = "Outward Mode:";
            label24.Text = "Courier Name:";
            label28.Text = "Courier Track id:";

            {  label3.Visible = true;
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
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = true;
            label23.Visible = true;
            label24.Visible = true;
            label25.Visible = true;
            label26.Visible = true;
            label27.Visible = true;
            label28.Visible = true;

            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox15.Visible = false;
            textBox16.Visible = false;
            textBox17.Visible = false;
            textBox18.Visible = false;
            textBox19.Visible = true;
            textBox20.Visible = true;
            textBox21.Visible = true;
            textBox22.Visible = true;


            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            dateTimePicker3.Visible = true;

            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;
            comboBox6.Visible = true;
            comboBox7.Visible = true;
            comboBox8.Visible = false;
            comboBox9.Visible = false;
            comboBox10.Visible = false;
            comboBox11.Visible = false;
            comboBox12.Visible = true;
            comboBox13.Visible = true;
            comboBox3.ResetText();
            comboBox3.Items.Clear();

            label22.Enabled = false;
            label23.Enabled = false;
            label24.Enabled = false;
            label25.Enabled = false;
            label26.Enabled = false;
            label27.Enabled = false;
            label28.Enabled = false;

            textBox19.Enabled = false;
            textBox20.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;


            comboBox12.Enabled = false;
            comboBox13.Enabled = false;

            dateTimePicker3.Enabled = false;


            label3.Enabled = true;
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            label8.Enabled = true;
            label9.Enabled = true;
            label10.Enabled = true;
            label12.Enabled = true;
            label13.Enabled = true;
            label14.Enabled = true;
            label15.Enabled = true;
            label17.Enabled = true;
            label18.Enabled = true;
            label19.Enabled = true;
            label20.Enabled = true;


            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;



            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
            comboBox6.Enabled = true;
            comboBox7.Enabled = true;


            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;

            label22.Enabled = false;
            label23.Enabled = false;
            label24.Enabled = false;
            label25.Enabled = false;
            label26.Enabled = false;
            label27.Enabled = false;
            label28.Enabled = false;

            textBox19.Enabled = false;
            textBox20.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;


            comboBox12.Enabled = false;
            comboBox13.Enabled = false;

            dateTimePicker3.Enabled = false;
        }
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 6;

            button1.Enabled = false;
            button2.Enabled = false;

            button1.BackColor = System.Drawing.Color.White;
            button2.BackColor = System.Drawing.Color.White;
            button6.BackColor = System.Drawing.Color.GreenYellow;
            button7.BackColor = System.Drawing.Color.Tomato;
            button8.BackColor = System.Drawing.Color.Tomato;
            button9.BackColor = System.Drawing.Color.Tomato;
            button10.BackColor = System.Drawing.Color.Tomato;
            button11.BackColor = System.Drawing.Color.Tomato;

            button12.Text = "Submit";
            button13.Text = "Reset";

            label3.Text = "Emp Name:";
            label7.Text = "Status:";

            comboBox3.Items.Clear();
            comboBox3.Items.Add("Active");
            comboBox3.Items.Add("Inactive");
            comboBox3.SelectedItem = "Active";
            {
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = true;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;

                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;
                textBox21.Visible = false;
                textBox22.Visible = false;

                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;


                comboBox1.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = true;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                label3.Enabled = true;
                label4.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                label7.Enabled = true;
                label8.Enabled = true;
                label9.Enabled = true;
                label10.Enabled = true;
                label12.Enabled = true;
                label13.Enabled = true;
                label14.Enabled = true;
                label15.Enabled = true;
                label17.Enabled = true;
                label18.Enabled = true;
                label19.Enabled = true;
                label20.Enabled = true;


                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                textBox12.Enabled = true;



                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;


                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;


                label22.Enabled = true;
                label23.Enabled = true;
                label24.Enabled = true;
                label25.Enabled = true;
                label26.Enabled = true;
                label27.Enabled = true;
                label28.Enabled = true;

                textBox19.Enabled = true;
                textBox20.Enabled = true;
                textBox21.Enabled = true;
                textBox22.Enabled = true;


                comboBox12.Enabled = true;
                comboBox13.Enabled = true;

                dateTimePicker3.Enabled = true;
            }

                changeDG();
        }

        private void button8_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 8;

            button1.Enabled = false;
            button2.Enabled = false;

            button1.BackColor = System.Drawing.Color.White;
            button2.BackColor = System.Drawing.Color.White;
            button6.BackColor = System.Drawing.Color.Tomato;
            button7.BackColor = System.Drawing.Color.Tomato;
            button8.BackColor = System.Drawing.Color.GreenYellow;
            button9.BackColor = System.Drawing.Color.Tomato;
            button10.BackColor = System.Drawing.Color.Tomato;
            button11.BackColor = System.Drawing.Color.Tomato;

            button12.Text = "Submit";
            button13.Text = "Reset";

            label3.Text = "Mfg Name:";
            
            label4.Text = "Model:";
            label5.Text = "Color:";
            label7.Text = "Status:";

            comboBox3.Items.Clear();
            comboBox3.Items.Add("Active");
            comboBox3.Items.Add("Inactive");
            comboBox3.SelectedItem = "Active";
            {
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
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;

                textBox1.Visible = true;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;
                textBox21.Visible = false;
                textBox22.Visible = false;

                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;

                comboBox1.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = true;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                label3.Enabled = true;
                label4.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                label7.Enabled = true;
                label8.Enabled = true;
                label9.Enabled = true;
                label10.Enabled = true;
                label12.Enabled = true;
                label13.Enabled = true;
                label14.Enabled = true;
                label15.Enabled = true;
                label17.Enabled = true;
                label18.Enabled = true;
                label19.Enabled = true;
                label20.Enabled = true;


                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                textBox12.Enabled = true;



                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;


                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;


                label22.Enabled = true;
                label23.Enabled = true;
                label24.Enabled = true;
                label25.Enabled = true;
                label26.Enabled = true;
                label27.Enabled = true;
                label28.Enabled = true;

                textBox19.Enabled = true;
                textBox20.Enabled = true;
                textBox21.Enabled = true;
                textBox22.Enabled = true;


                comboBox12.Enabled = true;
                comboBox13.Enabled = true;

                dateTimePicker3.Enabled = true;
            }

                changeDG();
        }

        private void button9_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 9;

            button1.Enabled = false;
            button2.Enabled = false;

            button1.BackColor = System.Drawing.Color.White;
            button2.BackColor = System.Drawing.Color.White;
            button6.BackColor = System.Drawing.Color.Tomato;
            button7.BackColor = System.Drawing.Color.Tomato;
            button8.BackColor = System.Drawing.Color.Tomato;
            button9.BackColor= System.Drawing.Color.GreenYellow;
            button10.BackColor = System.Drawing.Color.Tomato;
            button11.BackColor = System.Drawing.Color.Tomato;



            label3.Text = "Name:";
            label4.Text = "Address1:";
            label6.Text = "Address2:";
            label7.Text = "City:";
            label18.Text = "State:";
            label19.Text = "Country:";
            label20.Text = "Pincode";
            label9.Text = " Contact Person's Name:";
            label12.Text = "WhatsApp Contact:";
            label17.Text = "SMS Contact:";
            label21.Text = "Telegram Contact:";
            label13.Text = "Email 1:";
            label14.Text = "       Email 2:";
            label22.Text = "Default Inward:";
            label23.Text = "Default Outward:";
            label24.Text = "Status:";
            label25.Text = "Owner Reference Mark:";


            {
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = false;
                label9.Visible = true;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = false;
                label17.Visible = true;

                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                label25.Visible = true;
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;

                textBox1.Visible = true;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = true;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = true;
                textBox15.Visible = true;
                textBox16.Visible = true;
                textBox17.Visible = true;
                textBox18.Visible = true;
                textBox19.Visible = false;
                textBox20.Visible = false;
                textBox21.Visible = false;
                textBox22.Visible = false;

                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;

                comboBox1.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = true;
                comboBox9.Visible = true;
                comboBox10.Visible = true;
                comboBox11.Visible = false;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                label3.Enabled = true;
                label4.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                label7.Enabled = true;
                label8.Enabled = true;
                label9.Enabled = true;
                label10.Enabled = true;
                label12.Enabled = true;
                label13.Enabled = true;
                label14.Enabled = true;
                label15.Enabled = true;
                label17.Enabled = true;
                label18.Enabled = true;
                label19.Enabled = true;
                label20.Enabled = true;


                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                textBox12.Enabled = true;



                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;


                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;


                label22.Enabled = true;
                label23.Enabled = true;
                label24.Enabled = true;
                label25.Enabled = true;
                label26.Enabled = true;
                label27.Enabled = true;
                label28.Enabled = true;

                textBox19.Enabled = true;
                textBox20.Enabled = true;
                textBox21.Enabled = true;
                textBox22.Enabled = true;


                comboBox12.Enabled = true;
                comboBox13.Enabled = true;


                dateTimePicker3.Enabled = true;

            }
            comboBox8.Items.Clear();
            comboBox9.Items.Clear();
            comboBox10.Items.Clear();
            comboBox10.Items.Add("Active");
            comboBox10.Items.Add("Inactive");
            comboBox10.SelectedItem = "Active";

            
            sqlite_cmd.CommandText = "SELECT id,company_name,transport_mode FROM transportation_master ";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            comboBox8.Items.Add("---Select a mode---");
            comboBox9.Items.Add("---Select a mode---");
            while (sqlite_datareader.Read())
            {
                comboBox8.Items.Add(sqlite_datareader["id"]+"."+sqlite_datareader["transport_mode"]+" ("+ sqlite_datareader["company_name"] + ")");
                comboBox9.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["transport_mode"] + " (" + sqlite_datareader["company_name"] + ")");


            }

            sqlite_datareader.Close();



            changeDG();
        }

        private void button10_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 10;

            button1.BackColor = System.Drawing.Color.White;
            button2.BackColor = System.Drawing.Color.White;
            button6.BackColor = System.Drawing.Color.Tomato;
            button7.BackColor = System.Drawing.Color.Tomato;
            button8.BackColor = System.Drawing.Color.Tomato;
            button9.BackColor = System.Drawing.Color.Tomato;
            button10.BackColor = System.Drawing.Color.GreenYellow;
            button11.BackColor = System.Drawing.Color.Tomato;

            button1.Enabled = false;
            button2.Enabled = false;

            comboBox11.Items.Add("Active");
            comboBox11.Items.Add("Inactive");
            comboBox11.SelectedItem = "Active";

            button12.Text = "Submit";
            button13.Text = "Reset";

            label3.Text = "Company Name:";
            label4.Text = "Contact No:";

            label7.Text = "Contact Name:";
            label12.Text = "Fixed Price:";
            label13.Text = "Status";
            label17.Text = "Transport Mode:";



            {
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = true;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = false;
                label15.Visible = false;
                label17.Visible = true;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;


                textBox1.Text = "";
                textBox1.Visible = true;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = true;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = true;
                textBox8.Visible = false;
                textBox9.Visible = true;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = true;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;
                textBox21.Visible = false;
                textBox22.Visible = false;

                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;

                comboBox1.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                comboBox11.Visible = true;
                comboBox12.Visible = false;
                comboBox13.Visible = false;
                label3.Enabled = true;
                label4.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                label7.Enabled = true;
                label8.Enabled = true;
                label9.Enabled = true;
                label10.Enabled = true;
                label12.Enabled = true;
                label13.Enabled = true;
                label14.Enabled = true;
                label15.Enabled = true;
                label17.Enabled = true;
                label18.Enabled = true;
                label19.Enabled = true;
                label20.Enabled = true;


                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                textBox12.Enabled = true;



                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;


                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;


                label22.Enabled = true;
                label23.Enabled = true;
                label24.Enabled = true;
                label25.Enabled = true;
                label26.Enabled = true;
                label27.Enabled = true;
                label28.Enabled = true;

                textBox19.Enabled = true;
                textBox20.Enabled = true;
                textBox21.Enabled = true;
                textBox22.Enabled = true;


                comboBox12.Enabled = true;
                comboBox13.Enabled = true;

                dateTimePicker3.Enabled = true;
            }

                changeDG();
        }

        private void button12_MouseClick(object sender, MouseEventArgs e)
        {

            if (but_stat == 7)
            {
                if (updt == 0)
                {
                    sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "INSERT INTO activity_master (activity, active) VALUES('" + textBox1.Text + "', 1); " : "INSERT INTO activity_master (activity, active) VALUES('" + textBox1.Text + "', 0); ";
                    if (textBox1.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Activity field cannot be empty");
                    }
                    else
                    {
                        try
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1 + "");
                        }
                    }
                   
                }


                else
                {
                    sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "update activity_master set activity = '" + textBox1.Text + "', active = '1', updated=current_timestamp where id = " + id : "update activity_master set activity = '" + textBox1.Text + "', active = '0', updated=current_timestamp where id = " + id;
                    if (textBox1.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Activity field cannot be empty");
                    }
                    else
                    {
                        try
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1 + "");
                        }
                    }
                   
                }
            }
            if (but_stat == 6)
            {
                if (updt == 0)
                {
                    sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "INSERT INTO employee_master (emp_name, active) VALUES('" + textBox1.Text + "', 1); " : "INSERT INTO employee_master (emp_name, active) VALUES('" + textBox1.Text + "', 0); ";
                    if (textBox1.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Emp name cannot be empty");
                    }
                    else
                    {
                        try
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1 + "");
                        }
                    }
                 
                }
                else
                {
                    sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "update employee_master set emp_name = '" + textBox1.Text + "', active = '1', updated=current_timestamp where id = " + id : "update employee_master set emp_name = '" + textBox1.Text + "', active = '0', updated=current_timestamp where id = " + id;
                    if (textBox1.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Emp name cannot be empty");
                    }
                    else
                    {
                        try
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1 + "");
                        }
                    }
                    
                }
            }
            if (but_stat == 8)
            {
                if (updt == 0)
                {
                    sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "INSERT INTO make_master (mfg_name, model,color,active) VALUES('" + textBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "', 1); " : "INSERT INTO make_master (mfg_name, model,color,active) VALUES('" + textBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "', 1); ";
                    if (textBox1.Text.Trim().Equals("") || textBox6.Text.Trim().Equals("" ))
                    {
                        MessageBox.Show("Mfg name or color cannot be empty");
                    }
                    else
                    {
                        try
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1 + "");
                        }
                    }
                   
                }
                else
                {
                    sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "update make_master set mfg_name = '" + textBox1.Text + "',model = '" + textBox5.Text + "',color = '" + textBox6.Text + "', active = '1', updated=current_timestamp where id = " + id : "update make_master set mfg_name = '" + textBox1.Text + "',model = '" + textBox5.Text + "',color = '" + textBox6.Text + "', active = '0', updated=current_timestamp where id = " + id;
                    if (textBox1.Text.Trim().Equals("") || textBox6.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Mfg name or color cannot be empty");
                    }
                    else
                    {
                        try
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1 + "");
                        }
                    }
                    

                }
            }
            if (but_stat == 9)
            {
                if (updt == 0)
                {
                    
                    if (textBox1.Text.Trim().Equals("---Select a mode---") || comboBox9.SelectedItem.Equals("Active") || comboBox8.SelectedItem.Equals("---Select a mode---"))
                    {
                        MessageBox.Show("Name and inward/outward mode cannot be empty");
                    }
                    else
                    {
                        sqlite_cmd.CommandText = (comboBox10.SelectedItem.Equals("Active")) ? "INSERT INTO owner_master (owner_name,address1,address2,city,state,country,pincode,sms_contact,contact_name,whatsapp_contact,telegram_contact,email1,email2,owner_ref,default_inward_mode,default_outward_mode,active) VALUES('" + textBox1.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox4.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + comboBox8.SelectedItem.ToString().Split('.')[0] + "','" + comboBox9.SelectedItem.ToString().Split('.')[0] + "',1); " : "INSERT INTO owner_master (owner_name,address1,address2,city,state,country,pincode,sms_contact,contact_name,whatsapp_contact,telegram_contact,email1,email2,owner_ref,default_inward_mode,default_outward_mode,active) VALUES('" + textBox1.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox4.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + comboBox8.SelectedItem.ToString().Split('.')[0] + "','" + comboBox9.SelectedItem.ToString().Split('.')[0] + "',,0); ";
                        MessageBox.Show(sqlite_cmd.CommandText);
                        try
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1 + "");
                        }
                    }

                }


                else
                {
                    
                    if (textBox1.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Name cannot be empty");
                    }
                    else
                    {
                        sqlite_cmd.CommandText = (comboBox10.SelectedItem.Equals("Active")) ? "update owner_master set owner_name = '" + textBox1.Text + "',address1 = '" + textBox7.Text + "',address2 = '" + textBox8.Text + "',city = '" + textBox9.Text + "',state = '" + textBox10.Text + "',country = '" + textBox11.Text + "',pincode = '" + textBox12.Text + "',sms_contact = '" + textBox4.Text + "',contact_name = '" + textBox13.Text + "',whatsapp_contact = '" + textBox14.Text + "',telegram_contact = '" + textBox15.Text + "',email1 = '" + textBox16.Text + "',email2 = '" + textBox17.Text + "',owner_ref= '" + textBox18.Text + "',default_inward_mode = '" + comboBox8.SelectedItem.ToString().Split('.')[0] + "',default_outward_mode='" + comboBox9.SelectedItem.ToString().Split('.')[0] + "', active = '1', updated=current_timestamp where id = " + id : "update owner_master set owner_name = '" + textBox1.Text + "',address1 = '" + textBox7.Text + "',address2 = '" + textBox8.Text + "',city = '" + textBox9.Text + "',state = '" + textBox10.Text + "',country = '" + textBox11.Text + "',pincode = '" + textBox12.Text + "',sms_contact = '" + textBox4.Text + "',contact_name = '" + textBox13.Text + "',whatsapp_contact = '" + textBox14.Text + "',telegram_contact = '" + textBox15.Text + "',email1 = '" + textBox16.Text + "',email2 = '" + textBox17.Text + "',owner_ref= '" + textBox18.Text + "',default_inward_mode = '" + comboBox8.SelectedItem.ToString().Split('.')[0] + "',default_outward_mode='" + comboBox9.SelectedItem.ToString().Split('.')[0] + "', active = '0', updated=current_timestamp where id = " + id;
                        try
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1 + "");
                        }
                    }

                }
            }
            if (but_stat == 10)
            {
                if (updt == 0)
                {
                    sqlite_cmd.CommandText = (comboBox11.SelectedItem.Equals("Active")) ? "INSERT INTO transportation_master (company_name, contact_num,person_of_contact,transport_mode,fixed_price,active) VALUES('" + textBox1.Text + "','" + textBox7.Text + "','" + textBox9.Text + "', '" + textBox4.Text + "','" + textBox14.Text + "', 1); " : "INSERT INTO transportation_master(company_name, contact_num, person_of_contact, transport_mode, fixed_price, active) VALUES('" + textBox1.Text + "', '" + textBox7.Text + "', '" + textBox9.Text + "', '" + textBox4.Text + "', '" + textBox14.Text + "', 0); " ;
                    if (textBox4.Text.Trim().Equals(""))
                    {
                        MessageBox.Show(" Transport mode cannot be blank");
                    }
                    else
                    {
                        try
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1 + "");
                        }
                    }
                    
                }
                else
                {
                    sqlite_cmd.CommandText = (comboBox11.SelectedItem.Equals("Active")) ? "update transportation_master set company_name = '" + textBox1.Text + "',contact_num = '" + textBox7.Text + "',person_of_contact = '" + textBox9.Text + "', transport_mode = '" + textBox4.Text + "', fixed_price = '" + textBox14.Text + "',active = '1', updated=current_timestamp where id = " + id : "update transportation_master set company_name = '" + textBox1.Text + "',contact_num = '" + textBox7.Text + "',person_of_contact = '" + textBox9.Text + "', transport_mode = '" + textBox4.Text + "', fixed_price = '" + textBox14.Text + "',active = '0', updated=current_timestamp where id = " + id;
                    if (textBox4.Text.Trim().Equals(""))
                    {
                        MessageBox.Show(" Transport mode cannot be blank");
                    }
                    else
                    {
                        try
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1 + "");
                        }
                    }
                 

                }
            }
            changeDG();
        }
        private void changeDG()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            if(but_stat==10)
            {
                button12.Text = "Submit";
                button13.Text = "Reset";
                updt = 0;
                textBox1.Text = "";
                textBox4.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                textBox14.Text = "";
                comboBox8.ResetText();
                comboBox9.ResetText();
                comboBox8.SelectedItem = -1;
                
                comboBox9.SelectedIndex = -1;
                comboBox10.SelectedItem = "Active";

                dataGridView1.ColumnCount = 7;
                dataGridView1.Columns[0].Name = "ID";
                dataGridView1.Columns[1].Name = "Company Name";
                dataGridView1.Columns[2].Name = "Conatact Number";
                dataGridView1.Columns[3].Name = "Person of contact";
                dataGridView1.Columns[4].Name = "Transport Mode";
                dataGridView1.Columns[5].Name = "Fixed Price";
                dataGridView1.Columns[6].Name = "Status";


                sqlite_cmd.CommandText = "SELECT * FROM transportation_master order by datetime(updated) desc";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "", sqlite_datareader["company_name"] + "", sqlite_datareader["contact_num"] + "", sqlite_datareader["person_of_contact"] + "", sqlite_datareader["transport_mode"] + "", "₹ "+sqlite_datareader["fixed_price"] ,(sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive" });

                }

                sqlite_datareader.Close();


            }
            if (but_stat == 9)
            {
                button12.Text = "Submit";
                button13.Text = "Reset";
                updt = 0;
                textBox1.Text = "";
                textBox4.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
                comboBox10.SelectedItem = "Active";
                comboBox8.SelectedItem = "---Select a mode---";
                comboBox9.SelectedItem = "---Select a mode---";

                dataGridView1.ColumnCount = 18;
                dataGridView1.Columns[0].Name = "ID";
                dataGridView1.Columns[1].Name = "Owner Name";
                dataGridView1.Columns[2].Name = "Address 1";
                dataGridView1.Columns[3].Name = "Address 2";
                dataGridView1.Columns[4].Name = "City";
                dataGridView1.Columns[5].Name = "State";
                dataGridView1.Columns[6].Name = "Country";
                dataGridView1.Columns[7].Name = "Pincode";
                dataGridView1.Columns[8].Name = "SMS Contact";
                dataGridView1.Columns[9].Name = "Contact Name";
                dataGridView1.Columns[10].Name = "WhatsApp Contact";
                dataGridView1.Columns[11].Name = "Telegram Contact";
                dataGridView1.Columns[12].Name = "Email 1";
                dataGridView1.Columns[13].Name = "Email 2";
                dataGridView1.Columns[14].Name = "Owner Reference Mark";
                dataGridView1.Columns[15].Name = "Default Inward Mode";
                dataGridView1.Columns[16].Name = "Default Outward Mode";
                dataGridView1.Columns[17].Name = "Active Status";

                SQLiteDataReader dr;
                sqlite_cmd.CommandText = "SELECT * FROM owner_master order by datetime(updated) desc";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    SQLiteCommand sqlite_cmd1 = m_dbConnection.CreateCommand();

                    sqlite_cmd1.CommandText = "SELECT company_name,transport_mode FROM transportation_master where id=" + sqlite_datareader["default_inward_mode"]; 
                   
                    dr = sqlite_cmd1.ExecuteReader();
                    dr.Read();
                    String inc = dr["transport_mode"] +" ( "+dr["company_name"] +" )";
                    dr.Close();
                    sqlite_cmd1.CommandText = "SELECT company_name,transport_mode FROM transportation_master where id=" + sqlite_datareader["default_outward_mode"];
                    dr = sqlite_cmd1.ExecuteReader();
                    dr.Read();
                    String outw = dr["transport_mode"] + " ( " + dr["company_name"] + " )";
                    dr.Close();

                    dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "",
                        sqlite_datareader["owner_name"] + "",
                        sqlite_datareader["address1"] + "",
                        sqlite_datareader["address2"] + "",
                        sqlite_datareader["city"] + "",
                        sqlite_datareader["state"]+"",
                        sqlite_datareader["country"]+"",
                        sqlite_datareader["pincode"]+"",
                        sqlite_datareader["sms_contact"]+"",
                        sqlite_datareader["contact_name"]+"",
                        sqlite_datareader["whatsapp_contact"]+"",
                        sqlite_datareader["telegram_contact"]+"",
                        sqlite_datareader["email1"]+"",
                        sqlite_datareader["email2"]+"",
                        sqlite_datareader["owner_ref"]+"",
                        inc,
                        outw,
                        (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive" });

                }

                sqlite_datareader.Close();


            }
            if (but_stat==8)
            {

                button12.Text = "Submit";
                button13.Text = "Reset";
                updt = 0;
                textBox1.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox3.SelectedItem = "Active";

                dataGridView1.ColumnCount = 5;
                dataGridView1.Columns[0].Name = "ID";
                dataGridView1.Columns[1].Name = "Mfg Name";
                dataGridView1.Columns[2].Name = "model";
                dataGridView1.Columns[3].Name = "color";
                dataGridView1.Columns[4].Name = "Active Status";
                sqlite_cmd.CommandText = "SELECT * FROM make_master order by datetime(updated) desc";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "", sqlite_datareader["mfg_name"] + "", sqlite_datareader["model"] + "", sqlite_datareader["color"] + "",(sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive" });

                }

                sqlite_datareader.Close();

            }
            if (but_stat == 6)
            {
                button12.Text = "Submit";
                button13.Text = "Reset";
                updt = 0;
                textBox1.Text = "";
                comboBox3.SelectedItem = "Active";

                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "ID";
                dataGridView1.Columns[1].Name = "Emp Name";
                dataGridView1.Columns[2].Name = "Active Status";

                sqlite_cmd.CommandText = "SELECT * FROM employee_master order by datetime(updated) desc";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "", sqlite_datareader["emp_name"] + "", (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive" });

                }

                sqlite_datareader.Close();

            }
            if (but_stat==7)
            {
                button12.Text = "Submit";
                button13.Text = "Reset";
                updt = 0;
                textBox1.Text = "";
                comboBox3.SelectedItem = "Active";

                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "ID";
                dataGridView1.Columns[1].Name = "Activity";
                dataGridView1.Columns[2].Name = "Active Status";

                sqlite_cmd.CommandText = "SELECT * FROM activity_master order by datetime(updated) desc";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "",sqlite_datareader["activity"] + "", (sqlite_datareader["active"] + "").Equals("1")?"Active":"Inactive" });
                   
                }

                sqlite_datareader.Close();

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_dbConnection.Close();
        }

        private void button13_MouseClick(object sender, MouseEventArgs e)
        {
            changeDG();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show("Hello");
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id=Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value+"");
            updt = 1;
            button12.Text = "Update";
            button13.Text = "Cancel";
            updtTable();
        }

        private void updtTable()
        {
            if (but_stat == 6)
            {
                sqlite_cmd.CommandText = "SELECT * FROM employee_master where id =" + id;
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                sqlite_datareader.Read();


                textBox1.Text = sqlite_datareader["emp_name"] + "";
                comboBox3.SelectedItem = (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive";
                sqlite_datareader.Close();

            }
            if (but_stat==7)
            {
                sqlite_cmd.CommandText = "SELECT * FROM activity_master where id ="+id;
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                sqlite_datareader.Read();
                

                textBox1.Text = sqlite_datareader["activity"] + "";
                comboBox3.SelectedItem= (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive";
                sqlite_datareader.Close();
            
            }
            if (but_stat == 8)
            {
                sqlite_cmd.CommandText = "SELECT * FROM make_master where id =" + id;
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                sqlite_datareader.Read();


                textBox1.Text = sqlite_datareader["mfg_name"] + "";
                textBox5.Text = sqlite_datareader["model"] + "";
                textBox6.Text = sqlite_datareader["color"] + "";
                comboBox3.SelectedItem = (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive";
                sqlite_datareader.Close();

            }
            if (but_stat == 10)
            {
                sqlite_cmd.CommandText = "SELECT * FROM transportation_master where id =" + id;
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                sqlite_datareader.Read();


                textBox1.Text = sqlite_datareader["company_name"] + "";
                textBox7.Text = sqlite_datareader["contact_num"] + "";
                textBox9.Text = sqlite_datareader["person_of_contact"] + "";
                textBox4.Text = sqlite_datareader["transport_mode"] + "";
                textBox14.Text = sqlite_datareader["fixed_price"] + "";


                comboBox11.SelectedItem = (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive";
                sqlite_datareader.Close();

            }

            if (but_stat == 9)
            {
                sqlite_cmd.CommandText = "SELECT * FROM owner_master where id =" + id;
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                sqlite_datareader.Read();


                textBox1.Text = sqlite_datareader["owner_name"] + "";
                textBox7.Text= sqlite_datareader["address1"] + "";
                textBox8.Text = sqlite_datareader["address2"] + "";
                textBox9.Text = sqlite_datareader["city"] + "";
                textBox10.Text = sqlite_datareader["state"] + "";
                textBox11.Text = sqlite_datareader["country"] + "";
                textBox12.Text = sqlite_datareader["pincode"] + "";
                textBox4.Text = sqlite_datareader["sms_contact"] + "";
                textBox13.Text = sqlite_datareader["contact_name"] + "";
                textBox14.Text = sqlite_datareader["whatsapp_contact"] + "";
                textBox15.Text = sqlite_datareader["telegram_contact"] + "";
                textBox16.Text = sqlite_datareader["email1"] + "";
                textBox17.Text = sqlite_datareader["email2"] + "";
                textBox18.Text = sqlite_datareader["owner_ref"] + "";

                SQLiteDataReader dr;
                SQLiteCommand sqlite_cmd1 = m_dbConnection.CreateCommand();

                sqlite_cmd1.CommandText = "SELECT company_name,transport_mode FROM transportation_master where id=" + sqlite_datareader["default_inward_mode"];
                dr = sqlite_cmd1.ExecuteReader();
                dr.Read();
                
                comboBox8.SelectedItem = sqlite_datareader["default_inward_mode"] + "." + dr["transport_mode"] + " (" + dr["company_name"] + ")"; 
                dr.Close();

                sqlite_cmd1.CommandText = "SELECT company_name,transport_mode FROM transportation_master where id=" + sqlite_datareader["default_outward_mode"];
                dr = sqlite_cmd1.ExecuteReader();
                dr.Read();
                
                comboBox9.SelectedItem = sqlite_datareader["default_outward_mode"] + "." + dr["transport_mode"] + " (" + dr["company_name"] + ")";
                dr.Close();


                
                comboBox10.SelectedItem = (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive";
                sqlite_datareader.Close();

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (but_stat == 6 || but_stat == 7)
            {
                button12.Text = "Submit";
                button13.Text = "Reset";
                updt = 0;
                textBox1.Text = "";
                comboBox3.SelectedItem = "Active";
            }
            if(but_stat==8)
            {
                button12.Text = "Submit";
                button13.Text = "Reset";
                updt = 0;
                textBox1.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox3.SelectedItem = "Active";
            }
            if(but_stat==10)
            {
                button12.Text = "Submit";
                button13.Text = "Reset";
                updt = 0;
                textBox1.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox11.SelectedItem = "Active";

            }
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            inco = 0;

            label3.Enabled = true;
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            label8.Enabled = true;
            label9.Enabled = true;
            label10.Enabled = true;
            label12.Enabled = true;
            label13.Enabled = true;
            label14.Enabled = true;
            label15.Enabled = true;
            label17.Enabled = true;
            label18.Enabled = true;
            label19.Enabled = true;
            label20.Enabled = true;


            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;



            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
            comboBox6.Enabled = true;
            comboBox7.Enabled = true;


            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;


            label22.Enabled = false;
            label23.Enabled = false;
            label24.Enabled = false;
            label25.Enabled = false;
            label26.Enabled = false;
            label27.Enabled = false;
            label28.Enabled = false;

            textBox19.Enabled = false;
            textBox20.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;


            comboBox12.Enabled = false;
            comboBox13.Enabled = false;

            dateTimePicker3.Enabled = false;
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            inco = 1;

            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;
            label8.Enabled = false;
            label9.Enabled = false;
            label10.Enabled = false;
            label12.Enabled = false;
            label13.Enabled = false;
            label14.Enabled = false;
            label15.Enabled = false;
            label17.Enabled = false;
            label18.Enabled = false;
            label19.Enabled = false;
            label20.Enabled = false;


            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;



            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;


            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;


            label22.Enabled = true;
            label23.Enabled = true;
            label24.Enabled = true;
            label25.Enabled = true;
            label26.Enabled = true;
            label27.Enabled = true;
            label28.Enabled = true;

            textBox19.Enabled = true;
            textBox20.Enabled = true;
            textBox21.Enabled = true;
            textBox22.Enabled = true;


            comboBox12.Enabled = true;
            comboBox13.Enabled = true;

            dateTimePicker3.Enabled = true;
        }
    }
}
