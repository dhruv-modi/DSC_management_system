using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace DSC_management
{
    public partial class Form1 : Form
    {
        int inco = 0;
        int pendaler = 0;
        int id = 0;
        int updt = 0;
        Regex regex1 = new Regex("^[a-zA-Z]+[a-zA-Z0-9]+[[a-zA-Z0-9-_.!#$%'*+/=?^]{1,20}@[a-zA-Z0-9]{1,20}.[a-zA-Z]{2,3}$");
      

        Form3 f3;
        SQLiteCommand sqlite_cmd;
        SQLiteConnection m_dbConnection;
        SQLiteDataReader sqlite_datareader;
        int but_stat = 0;
        public Form1(SQLiteConnection m_db)
        {

            f3 = new Form3();
            f3.Show();
            Thread.Sleep(3000);
            f3.Close();
            m_dbConnection = m_db;
            sqlite_cmd = m_db.CreateCommand();
            
            but_stat = 11;




            InitializeComponent();
            timer1_Tick(null, null);
            

            pending();
            alert();
            {
                button11.TabIndex = 0;
                button6.TabIndex = 1;
                button7.TabIndex = 2;
                button8.TabIndex = 3;
                button9.TabIndex = 4;
                button10.TabIndex = 5;
                textBox1.TabIndex = 6;
                comboBox14.TabIndex = 7;
                dateTimePicker1.TabIndex = 8;
                textBox7.TabIndex = 9;
                comboBox1.TabIndex = 10;
                comboBox2.TabIndex = 11;
                textBox8.TabIndex = 12;
                textBox2.TabIndex = 13;
                comboBox3.TabIndex = 14;
                textBox9.TabIndex = 15;
                textBox10.TabIndex = 16;
                textBox11.TabIndex = 17;
                textBox12.TabIndex = 18;
                textBox4.TabIndex = 19;
                textBox14.TabIndex = 19;
                comboBox5.TabIndex = 20;
                textBox13.TabIndex = 21;
                comboBox4.TabIndex = 22;
                comboBox6.TabIndex = 23;
                comboBox7.TabIndex = 24;
                textBox14.TabIndex = 25;
                textBox15.TabIndex = 26;
                dateTimePicker2.TabIndex = 27;
                textBox16.TabIndex = 28;
                textBox3.TabIndex = 29;
                textBox17.TabIndex = 30;
                dateTimePicker3.TabIndex = 31;
                textBox18.TabIndex = 32;
                comboBox12.TabIndex = 33;
                comboBox13.TabIndex = 34;
                textBox19.TabIndex = 35;
                comboBox8.TabIndex = 36;
                textBox20.TabIndex = 37;
                comboBox9.TabIndex = 38;
                textBox21.TabIndex = 39;
                comboBox10.TabIndex = 40;
                textBox22.TabIndex = 41;
                comboBox15.TabIndex = 42;
                textBox23.TabIndex = 43;
                button1.TabIndex = 44;
                button2.TabIndex = 45;
                button4.TabIndex = 46;
                button14.TabIndex = 47;
                button15.TabIndex = 48;
                button3.TabIndex = 49;
                button5.TabIndex = 50;
                button13.TabIndex = 51;
                button12.TabIndex = 52;










            }
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker3.Value = DateTime.Today;
            {
                comboBox14.Items.Clear();
                comboBox14.Items.Add("-Select-");

                comboBox14.SelectedItem = "-Select-";
                sqlite_cmd.CommandText = "SELECT id,owner_name FROM owner_master where active=1 order by owner_name asc";

                try
                {
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        comboBox14.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["owner_name"] + "");

                    }
                    sqlite_datareader.Close();
                }catch(Exception e)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:139:" + e + "\n\n");
                    }
                    MessageBox.Show(" " + e);
                }
            }//owner
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("-Select-");
                comboBox1.SelectedItem = "-Select-";
                comboBox13.Items.Clear();
                comboBox13.Items.Add("-Select-");
                comboBox13.SelectedItem = "-Select-";
                try
                {
                    sqlite_cmd.CommandText = "SELECT id,emp_name FROM employee_master where active=1  order by emp_name asc";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        comboBox1.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["emp_name"]);
                        comboBox13.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["emp_name"]);
                    }
                    sqlite_datareader.Close();
                }catch(Exception e)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:164:" + e + "\n\n");
                    }
                    MessageBox.Show(" " + e );
                }
            }//employee
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("-Select-");

                comboBox2.SelectedItem = "-Select-";
                comboBox12.Items.Clear();
                comboBox12.Items.Add("-Select-");

                comboBox12.SelectedItem = "-Select-";
                try
                {
                    sqlite_cmd.CommandText = "SELECT id,company_name,transport_mode FROM transportation_master where active=1 order by transport_mode asc";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        comboBox2.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["transport_mode"] + " (" + sqlite_datareader["company_name"] + ")");
                        comboBox12.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["transport_mode"] + " (" + sqlite_datareader["company_name"] + ")");

                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:193:" + e + "\n\n");
                    }
                    MessageBox.Show(" " + e);
                }
            }//transport
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("-Select-");

                comboBox3.SelectedItem = "-Select-";
                try
                {
                    sqlite_cmd.CommandText = "SELECT id,activity FROM activity_master where active=1 order by activity asc ";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        comboBox3.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["activity"]);

                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:217:" + e + "\n\n");
                    }
                    MessageBox.Show(" " + e);
                }
            }//activty
            {
                comboBox7.Items.Clear();
                comboBox7.Items.Add("Yes");
                comboBox7.Items.Add("No");
                comboBox7.SelectedItem = "Yes";
            }//return
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("-Select-");

                comboBox5.SelectedItem = "-Select-";
                try
                {
                    sqlite_cmd.CommandText = "SELECT id,mfg_name FROM make_master where active=1 order by mfg_name asc ";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        comboBox5.Items.Add("" + sqlite_datareader["id"] + "." + sqlite_datareader["mfg_name"]);

                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:247:" + e + "\n\n");
                    }
                    MessageBox.Show(" " + e);
                }
            }//make
            {
                comboBox4.Items.Add("");
                comboBox4.SelectedItem = "";

                comboBox6.Items.Add("");
                comboBox6.SelectedItem = "";


            }
            
          
            changeDG();
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
            textBox1.MaxLength = 30;
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
                label29.Visible = false;
                label30.Visible = false;
                label31.Visible = false;

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
                textBox23.Visible = false;


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
                comboBox14.Visible = false;
                comboBox15.Visible = false;
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
            pendaler = 0;
            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.MaxLength = 50;
            textBox4.MaxLength = 20;
            textBox20.MaxLength = 30;
            textBox21.MaxLength = 30;
            textBox22.MaxLength = 30;
            textBox23.MaxLength = 100;

            button1.BackColor = System.Drawing.Color.GreenYellow;
            button2.BackColor = System.Drawing.Color.Tomato;
            button6.BackColor = System.Drawing.Color.Tomato;
            button7.BackColor = System.Drawing.Color.Tomato;
            button8.BackColor = System.Drawing.Color.Tomato;
            button9.BackColor = System.Drawing.Color.Tomato;
            button10.BackColor = System.Drawing.Color.Tomato;
            button11.BackColor = System.Drawing.Color.GreenYellow;

            {
                comboBox14.Items.Clear();
                comboBox14.Items.Add("-Select-");

                comboBox14.SelectedItem = "-Select-";
                try
                {
                    sqlite_cmd.CommandText = "SELECT id,owner_name FROM owner_master where active=1 order by owner_name asc";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        comboBox14.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["owner_name"] + "");

                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:477:" + e1+"\n\n" );
                    }
                    MessageBox.Show(" " + e1);
                }
            }//owner
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("-Select-");
                comboBox1.SelectedItem = "-Select-";
                try
                {
                    sqlite_cmd.CommandText = "SELECT id,emp_name FROM employee_master where active=1  order by emp_name asc";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        comboBox1.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["emp_name"]);

                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:504:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }
            }//employee
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("-Select-");

                comboBox2.SelectedItem = "-Select-";
                try
                {
                    sqlite_cmd.CommandText = "SELECT id,company_name,transport_mode FROM transportation_master where active=1 order by transport_mode asc";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        comboBox2.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["transport_mode"] + " (" + sqlite_datareader["company_name"] + ")");

                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:528:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }

            }//transport
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add("-Select-");
                
                comboBox3.SelectedItem = "-Select-";
                try
                {
                    sqlite_cmd.CommandText = "SELECT id,activity FROM activity_master where active=1 order by activity asc ";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        comboBox3.Items.Add("" + sqlite_datareader["id"] + "." + sqlite_datareader["activity"]);

                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:553:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }
            }//activty
            {
                comboBox7.Items.Clear();
                comboBox7.Items.Add("Yes");
                comboBox7.Items.Add("No");
                comboBox7.SelectedItem = "Yes";
            }//return
            {
                comboBox4.Items.Add("");
                comboBox4.SelectedItem = "";

                comboBox6.Items.Add("");
                comboBox6.SelectedItem = "";


            }
            {
                comboBox5.Items.Clear();
                comboBox5.Items.Add("-Select-");

                comboBox5.SelectedItem = "-Select-";
                try
                {
                    sqlite_cmd.CommandText = "SELECT id,mfg_name FROM make_master where active=1 order by mfg_name asc ";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        comboBox5.Items.Add("" + sqlite_datareader["id"] + "." + sqlite_datareader["mfg_name"]);

                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:596:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }
            }//make


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
            label10.Visible = false;
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
            label29.Visible = true;
            label30.Visible = true;
                label31.Visible = true;


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
                textBox23.Visible = true;


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
            comboBox14.Visible = true;
            comboBox15.Visible = true;
                
           

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
            label8.Enabled = false;
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
            comboBox4.Enabled = false;
            comboBox5.Enabled = true;
            comboBox6.Enabled = false;
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
                label30.Enabled = false;

            textBox19.Enabled = false;
            textBox20.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;


            comboBox12.Enabled = false;
            comboBox13.Enabled = false;

                comboBox15.Enabled = false;

            dateTimePicker3.Enabled = false;
        }


            changeDG();
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 6;
            textBox1.MaxLength = 30;
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
                label29.Visible = false;
                label30.Visible = false;
                label31.Visible = false;

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
                textBox23.Visible = false;

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
                comboBox14.Visible = false;
                comboBox15.Visible = false;
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
            textBox1.MaxLength = 30;
            textBox7.MaxLength = 30;
            textBox6.MaxLength = 20;
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
                label29.Visible = false;
                label30.Visible = false;
                label31.Visible = false;

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
                textBox23.Visible = false;

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
                comboBox14.Visible = false;
                comboBox15.Visible = false;
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
            textBox1.MaxLength = 30;
            textBox7.MaxLength = 30;
            textBox8.MaxLength = 30;
            textBox9.MaxLength = 30;
            textBox10.MaxLength = 30;
            textBox11.MaxLength = 30;
            textBox12.MaxLength = 10;
            textBox4.MaxLength = 12;
            textBox13.MaxLength = 30;
            textBox14.MaxLength = 12;
            textBox15.MaxLength = 12;
            textBox16.MaxLength = 100;
            textBox17.MaxLength = 100;
            textBox18.MaxLength = 50;

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
                label29.Visible = false;
                label30.Visible = false;
                label31.Visible = false;

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
                textBox23.Visible = false;

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
                comboBox14.Visible = false;
                comboBox15.Visible = false;
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

            try
            {
                sqlite_cmd.CommandText = "SELECT id,company_name,transport_mode FROM transportation_master where active=1 order by transport_mode asc";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                comboBox8.Items.Add("---Select a mode---");
                comboBox9.Items.Add("---Select a mode---");
                while (sqlite_datareader.Read())
                {
                    comboBox8.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["transport_mode"] + " (" + sqlite_datareader["company_name"] + ")");
                    comboBox9.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["transport_mode"] + " (" + sqlite_datareader["company_name"] + ")");


                }

                sqlite_datareader.Close();
            }
            catch (Exception e1)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                {
                    file.WriteLine(DateTime.Now + ":Form1.cs:1313:" + e1 + "\n\n");
                }
                MessageBox.Show(" " + e1);
            }


            changeDG();
        }

        private void button10_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 10;
            textBox1.MaxLength = 30;
            textBox7.MaxLength = 12;
            textBox9.MaxLength = 30;
            textBox4.MaxLength = 30;

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

            comboBox11.Items.Clear();
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
                label29.Visible = false;
                label30.Visible = false;
                label31.Visible = false;


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
                textBox23.Visible = false;

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
                comboBox14.Visible = false;
                comboBox15.Visible = false;
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
            int stat = 0;
            if (but_stat == 7)
            {
                if (updt == 0)
                {
                    try
                    {
                        sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "INSERT INTO activity_master (activity, active) VALUES('" + textBox1.Text + "', 1); " : "INSERT INTO activity_master (activity, active) VALUES('" + textBox1.Text + "', 0); ";
                        if (textBox1.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Activity field cannot be empty");
                            stat = 1;
                        }
                        else
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();


                        }
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:1520:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }

                }


                else
                {
                    try
                    {
                        sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "update activity_master set activity = '" + textBox1.Text + "', active = '1', updated=current_timestamp where id = " + id : "update activity_master set activity = '" + textBox1.Text + "', active = '0', updated=current_timestamp where id = " + id;
                        if (textBox1.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Activity field cannot be empty");
                            stat = 1;
                        }
                        else
                        {
                                int it = sqlite_cmd.ExecuteNonQuery();
                           
                        }
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:1548:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }

                }
            }
            if (but_stat == 6)
            {
                if (updt == 0)
                {
                    try
                    {
                        sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "INSERT INTO employee_master (emp_name, active) VALUES('" + textBox1.Text + "', 1); " : "INSERT INTO employee_master (emp_name, active) VALUES('" + textBox1.Text + "', 0); ";
                        if (textBox1.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Emp name cannot be empty");
                            stat = 1;
                        }
                        else
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();

                        }
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:1578:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }

                }
                else
                {
                    try
                    {
                        sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "update employee_master set emp_name = '" + textBox1.Text + "', active = '1', updated=current_timestamp where id = " + id : "update employee_master set emp_name = '" + textBox1.Text + "', active = '0', updated=current_timestamp where id = " + id;
                        if (textBox1.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Emp name cannot be empty");
                            stat = 1;
                        }
                        else
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();

                        }
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:1605:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }

                }
            }
            if (but_stat == 8)
            {
                if (updt == 0)
                {
                    try
                    {
                        sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "INSERT INTO make_master (mfg_name, model,color,active) VALUES('" + textBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "', 1); " : "INSERT INTO make_master (mfg_name, model,color,active) VALUES('" + textBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "', 1); ";
                        if (textBox1.Text.Trim().Equals("") || textBox6.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Mfg name or color cannot be empty");
                            stat = 1;
                        }
                        else
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();

                        }
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:1635:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }
                }
                else
                {
                    try
                    {
                        sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "update make_master set mfg_name = '" + textBox1.Text + "',model = '" + textBox5.Text + "',color = '" + textBox6.Text + "', active = '1', updated=current_timestamp where id = " + id : "update make_master set mfg_name = '" + textBox1.Text + "',model = '" + textBox5.Text + "',color = '" + textBox6.Text + "', active = '0', updated=current_timestamp where id = " + id;
                        if (textBox1.Text.Trim().Equals("") || textBox6.Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Mfg name or color cannot be empty");
                            stat = 1;
                        }
                        else
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();

                        }
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:1661:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }


                }
            }
            if (but_stat == 9)
            {
                if (updt == 0)
                {
                    try
                    {
                        if (textBox1.Text.Trim().Equals("---Select a mode---") || comboBox9.SelectedItem.Equals("Active") || comboBox8.SelectedItem.Equals("---Select a mode---"))
                        {
                            MessageBox.Show("Name and inward/outward mode cannot be empty");
                            stat = 1;
                        }
                        else if (!textBox4.Text.Equals("") && textBox4.Text.Length < 10)
                        {
                            MessageBox.Show(" Contact Number is less than 10 digits");
                            stat = 1;
                        }
                        else if (!textBox14.Text.Equals("") && textBox14.Text.Length < 10)
                        {
                            MessageBox.Show(" Contact Number is less than 10 digits");
                            stat = 1;
                        }
                        else if (!textBox15.Text.Equals("") && textBox15.Text.Length < 10)
                        {
                            MessageBox.Show(" Contact Number is less than 10 digits");
                            stat = 1;
                        }
                         else if (!textBox17.Text.Equals("") && !regex1.IsMatch(textBox17.Text))
                        {
                            MessageBox.Show(" Email address format for email 2 is not correct");
                            stat = 1;
                        }
                        else if (!textBox16.Text.Equals("") && !regex1.IsMatch(textBox16.Text))
                        {
                            MessageBox.Show(" Email address format for email 1 is not correct");
                            stat = 1;
                        }
                        else
                        {
                            sqlite_cmd.CommandText = (comboBox10.SelectedItem.Equals("Active")) ? "INSERT INTO owner_master (owner_name,address1,address2,city,state,country,pincode,sms_contact,contact_name,whatsapp_contact,telegram_contact,email1,email2,owner_ref,default_inward_mode,default_outward_mode,active) VALUES('" + textBox1.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox4.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + comboBox8.SelectedItem.ToString().Split('.')[0] + "','" + comboBox9.SelectedItem.ToString().Split('.')[0] + "',1); " : "INSERT INTO owner_master (owner_name,address1,address2,city,state,country,pincode,sms_contact,contact_name,whatsapp_contact,telegram_contact,email1,email2,owner_ref,default_inward_mode,default_outward_mode,active) VALUES('" + textBox1.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox4.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + comboBox8.SelectedItem.ToString().Split('.')[0] + "','" + comboBox9.SelectedItem.ToString().Split('.')[0] + "',,0); ";
                            //MessageBox.Show(sqlite_cmd.CommandText);

                            int it = sqlite_cmd.ExecuteNonQuery();

                        }
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:1693:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }
                }


                else
                {
                    
                    if (textBox1.Text.Trim().Equals("---Select a mode---") || comboBox9.SelectedItem.Equals("Active") || comboBox8.SelectedItem.Equals("---Select a mode---"))
                    {
                        MessageBox.Show("Name cannot be empty");
                        stat = 1;
                    }
                    else
                    {
                        try { 
                        sqlite_cmd.CommandText = (comboBox10.SelectedItem.Equals("Active")) ? "update owner_master set owner_name = '" + textBox1.Text + "',address1 = '" + textBox7.Text + "',address2 = '" + textBox8.Text + "',city = '" + textBox9.Text + "',state = '" + textBox10.Text + "',country = '" + textBox11.Text + "',pincode = '" + textBox12.Text + "',sms_contact = '" + textBox4.Text + "',contact_name = '" + textBox13.Text + "',whatsapp_contact = '" + textBox14.Text + "',telegram_contact = '" + textBox15.Text + "',email1 = '" + textBox16.Text + "',email2 = '" + textBox17.Text + "',owner_ref= '" + textBox18.Text + "',default_inward_mode = '" + comboBox8.SelectedItem.ToString().Split('.')[0] + "',default_outward_mode='" + comboBox9.SelectedItem.ToString().Split('.')[0] + "', active = '1', updated=current_timestamp where id = " + id : "update owner_master set owner_name = '" + textBox1.Text + "',address1 = '" + textBox7.Text + "',address2 = '" + textBox8.Text + "',city = '" + textBox9.Text + "',state = '" + textBox10.Text + "',country = '" + textBox11.Text + "',pincode = '" + textBox12.Text + "',sms_contact = '" + textBox4.Text + "',contact_name = '" + textBox13.Text + "',whatsapp_contact = '" + textBox14.Text + "',telegram_contact = '" + textBox15.Text + "',email1 = '" + textBox16.Text + "',email2 = '" + textBox17.Text + "',owner_ref= '" + textBox18.Text + "',default_inward_mode = '" + comboBox8.SelectedItem.ToString().Split('.')[0] + "',default_outward_mode='" + comboBox9.SelectedItem.ToString().Split('.')[0] + "', active = '0', updated=current_timestamp where id = " + id;
                        
                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                            {
                                file.WriteLine(DateTime.Now + ":Form1.cs:1719:" + e1 + "\n\n");
                            }
                            MessageBox.Show(" " + e1);
                        }
                    }

                }
            }
            if (but_stat == 10)
            {
                if (updt == 0)
                {
                    try
                    {
                        sqlite_cmd.CommandText = (comboBox11.SelectedItem.Equals("Active")) ? "INSERT INTO transportation_master (company_name, contact_num,person_of_contact,transport_mode,fixed_price,active) VALUES('" + textBox1.Text + "','" + textBox7.Text + "','" + textBox9.Text + "', '" + textBox4.Text + "','" + textBox14.Text + "', 1); " : "INSERT INTO transportation_master(company_name, contact_num, person_of_contact, transport_mode, fixed_price, active) VALUES('" + textBox1.Text + "', '" + textBox7.Text + "', '" + textBox9.Text + "', '" + textBox4.Text + "', '" + textBox14.Text + "', 0); ";
                        if (textBox4.Text.Trim().Equals("") || textBox1.Text.Trim().Equals(""))
                        {
                            MessageBox.Show(" Transport mode or Company Name cannot be blank");
                            stat = 1;
                        }
                        else if(!textBox7.Text.Equals("") &&  textBox7.Text.Length<10)
                        {
                            MessageBox.Show(" Contact Number is less than 10 digits");
                            stat = 1;
                        }
                        else
                        {
                            
                                int it = sqlite_cmd.ExecuteNonQuery();
                           
                        }
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:1756:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }

                }
                else
                {
                    try
                    {
                        sqlite_cmd.CommandText = (comboBox11.SelectedItem.Equals("Active")) ? "update transportation_master set company_name = '" + textBox1.Text + "',contact_num = '" + textBox7.Text + "',person_of_contact = '" + textBox9.Text + "', transport_mode = '" + textBox4.Text + "', fixed_price = '" + textBox14.Text + "',active = '1', updated=current_timestamp where id = " + id : "update transportation_master set company_name = '" + textBox1.Text + "',contact_num = '" + textBox7.Text + "',person_of_contact = '" + textBox9.Text + "', transport_mode = '" + textBox4.Text + "', fixed_price = '" + textBox14.Text + "',active = '0', updated=current_timestamp where id = " + id;
                        if (textBox4.Text.Trim().Equals("") || textBox1.Text.Trim().Equals(""))
                        {
                            MessageBox.Show(" Transport mode or Company Name cannot be blank");
                            stat = 1;
                        }
                        else
                        {

                            int it = sqlite_cmd.ExecuteNonQuery();

                        }
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:1777:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }


                }
            }

            if(but_stat==11 && inco==0)
            {

                
                {
                   
                    if (textBox1.Text.Trim().Equals(""))
                    {
                       
                        MessageBox.Show("Location cannot be empty");
                        stat = 1;
                    }
                    else if(comboBox14.SelectedItem.Equals("-Select-"))
                    {
                        MessageBox.Show("Please select an owner");
                        stat = 1;

                    }
                    else if(comboBox1.SelectedItem.Equals("-Select-"))
                    {
                        MessageBox.Show("Please select a name in inward by");
                        stat = 1;
                    }
                    else if (comboBox2.SelectedItem.Equals("-Select-"))
                    {
                        MessageBox.Show("Please select an inward mode");
                        stat = 1;
                    }
                    else if (comboBox3.SelectedItem.Equals("-Select-"))
                    {
                        MessageBox.Show("Please select the activity to be performed");
                        stat = 1;
                    }
                    else if (comboBox5.SelectedItem.Equals("-Select-"))
                    {
                        MessageBox.Show("Please select dsc make");
                        stat = 1;
                    }
                    else if ((dateTimePicker2.Value - dateTimePicker1.Value).Days < 0 && textBox3.Text=="")
                    {
                        MessageBox.Show("Please select a valid return date");
                        stat = 1;
                    }
                    
                    else
                    {
                        //MessageBox.Show((textBox3.Text.Equals("") ? dateTimePicker2.Value.ToString("yyyy-MM-dd") : DateTime.Today.AddDays(Convert.ToDouble(textBox3.Text)).ToString("yyyy-MM-dd")));
                        try { 
                        sqlite_cmd.CommandText = "INSERT INTO transaction_master (location_ref,owner_name, inward_date,inward_by,receive_mode,activity,dsc_uid,dsc_model,dsc_make,dsc_color,inward_charge,return_init,autoreturn_date," +
                            "autoreturn_days,remarks1) VALUES('" + textBox1.Text + "','" + comboBox14.SelectedItem.ToString() + "',date('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')," +
                            "'" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + textBox4.Text + "','" + comboBox4.SelectedItem.ToString() + "'," +
                            "'" + comboBox5.SelectedItem.ToString() + "','" + comboBox6.SelectedItem.ToString() + "','" + textBox2.Text + "','" + (comboBox7.SelectedItem.ToString().Equals("Yes") ? "1" : "0") + "'" +
                            ",date('" + (textBox3.Text.Equals("") ? dateTimePicker2.Value.ToString("yyyy-MM-dd") : DateTime.Today.AddDays(Convert.ToDouble(textBox3.Text)).ToString("yyyy-MM-dd")) + "'),'" + textBox3.Text + "','" + textBox23.Text + "'); ";

                    
                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                            {
                                file.WriteLine(DateTime.Now + ":Form1.cs:1847:" + e1 + "\n\n");
                            }
                            MessageBox.Show(" " + e1);
                        }
                    }
                    pending();

                }

            }

            if (but_stat == 11 && inco == 1)
            {
                if (comboBox14.SelectedItem.Equals("-Select-"))
                {
                    MessageBox.Show("Please select an owner");
                }
                else
                {
                    if (comboBox15.SelectedItem.Equals("True"))
                    {
                        if ((MessageBox.Show("Do you want to make this transaction invalid ?", "Confirmation Needed", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString()).Equals("Yes"))
                        {
                            try
                            {
                                sqlite_cmd.CommandText = "update transaction_master set wrong_entry ='1', record_open='0' where id='" + id + "';";


                                int it = sqlite_cmd.ExecuteNonQuery();
                            }
                            catch (Exception e1)
                            {
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                                {
                                    file.WriteLine(DateTime.Now + ":Form1.cs:1874:" + e1 + "\n\n");
                                }
                                MessageBox.Show(" " + e1);
                            }
                        }


                    }
                    else if (comboBox12.SelectedItem.Equals("-Select-"))
                    {
                        MessageBox.Show("Please select an outward mode");
                        stat = 1;

                    }
                    else if (comboBox13.SelectedItem.Equals("-Select-"))
                    {
                        MessageBox.Show("Please select a valid value in outward by");
                        stat = 1;

                    }
                    else if ((dateTimePicker3.Value - dateTimePicker1.Value).Days < 0)
                    {
                        MessageBox.Show("Outward Date should not be before Inward Date");
                        stat = 1;
                    }
                    else if (textBox20.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Please a name of person who collected");
                        stat = 1;
                    }
                    else
                    {

                        try
                        {
                            sqlite_cmd.CommandText = "update transaction_master set outward_date=date('" + dateTimePicker3.Value.ToString("yyyy-MM-dd") + "'),outward_mode='" + comboBox12.SelectedItem.ToString() + "',outward_by='" + comboBox13.SelectedItem.ToString() + "',outward_charges='" + textBox19.Text + "',outward_collected_by='" + textBox20.Text + "',courier_name='" + textBox21.Text + "',courier_track_id='" + textBox22.Text + "',dsc_stayed='" + (dateTimePicker3.Value - dateTimePicker1.Value).Days + "',record_open='0',remarks1='" + textBox23.Text + "' where id='" + id + "';";



                            int it = sqlite_cmd.ExecuteNonQuery();
                        }
                        catch (Exception e1)
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                            {
                                file.WriteLine(DateTime.Now + ":Form1.cs:1918:" + e1 + "\n\n");
                            }
                            MessageBox.Show(" " + e1);
                        }


                    }
                    pending();
                    alert();
                    pendaler = 0;
                }




            }




            if (stat == 1)
            {

            }
            else
            {
                if (but_stat == 11 && inco == 0)
                {
                    button1_MouseClick(sender, e);
                   
                }
                if (but_stat == 11 && inco == 1)
                {
                    button2_MouseClick(sender, e);
                    
                }
                else
                {
                    changeDG();
                }
            }
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

                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM transportation_master order by datetime(updated) desc";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "", sqlite_datareader["company_name"] + "", sqlite_datareader["contact_num"] + "", sqlite_datareader["person_of_contact"] + "", sqlite_datareader["transport_mode"] + "", "₹ " + sqlite_datareader["fixed_price"], (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive" });

                    }

                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2007:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }

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

                try
                {
                    SQLiteDataReader dr;
                    sqlite_cmd.CommandText = "SELECT * FROM owner_master order by datetime(updated) desc";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        SQLiteCommand sqlite_cmd1 = m_dbConnection.CreateCommand();

                        sqlite_cmd1.CommandText = "SELECT company_name,transport_mode FROM transportation_master where id=" + sqlite_datareader["default_inward_mode"];

                        dr = sqlite_cmd1.ExecuteReader();
                        dr.Read();
                        String inc = dr["transport_mode"] + " ( " + dr["company_name"] + " )";
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
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2104:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }

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
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM make_master order by datetime(updated) desc";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "", sqlite_datareader["mfg_name"] + "", sqlite_datareader["model"] + "", sqlite_datareader["color"] + "", (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive" });

                    }

                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2143:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }

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
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM employee_master order by datetime(updated) desc";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "", sqlite_datareader["emp_name"] + "", (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive" });

                    }

                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2177:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }

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
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM activity_master order by datetime(updated) desc";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "", sqlite_datareader["activity"] + "", (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive" });

                    }

                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2211:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }
            }

            if (but_stat == 11)
            {
                button12.Text = "Submit";
                button13.Text = "Reset";
                updt = 0;
                
                dataGridView1.ColumnCount = 25      ;
                dataGridView1.Columns[0].Name = "ID";
                dataGridView1.Columns[1].Name = "Location Reference";
                dataGridView1.Columns[2].Name = "Owner Name";
                dataGridView1.Columns[3].Name = "Transaction Date";
                dataGridView1.Columns[4].Name = "Inward Date";
                dataGridView1.Columns[5].Name = "Inward By";
                dataGridView1.Columns[6].Name = "Receive Mode";
                dataGridView1.Columns[7].Name = "Activity";
                dataGridView1.Columns[8].Name = "DSC UID";
                dataGridView1.Columns[9].Name = "DSC Model";//
                dataGridView1.Columns[10].Name = "DSC Make";
                dataGridView1.Columns[11].Name = "DSC Color";
                dataGridView1.Columns[12].Name = "Inward Charge";
                dataGridView1.Columns[13].Name = "Return Initialization";
                dataGridView1.Columns[14].Name = "Autoreturn Date";
               
                dataGridView1.Columns[15].Name = "Autoreturn days";
                dataGridView1.Columns[16].Name = "Outward Date";
                dataGridView1.Columns[17].Name = "Outward Mode";
                dataGridView1.Columns[18].Name = "Outward By";
                dataGridView1.Columns[19].Name = "Outward Charge";
                dataGridView1.Columns[20].Name = "Outward Collected By";
                dataGridView1.Columns[21].Name = "Courier Name";
                dataGridView1.Columns[22].Name = "Courier Track ID";
                dataGridView1.Columns[23].Name = "Last Modified";
                dataGridView1.Columns[24].Name = "Remarks";
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM transaction_master where wrong_entry=0 and record_open='1' order by datetime(last_modified) desc";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {



                        dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "",
                            sqlite_datareader["location_ref"] + "",
                            sqlite_datareader["owner_name"] + "",
                            sqlite_datareader["trans_date"] + "",
                            sqlite_datareader["inward_date"] + "",
                            sqlite_datareader["inward_by"]+"",
                            sqlite_datareader["receive_mode"]+"",
                            sqlite_datareader["activity"]+"",
                            sqlite_datareader["dsc_uid"]+"",
                            sqlite_datareader["dsc_model"]+"",
                            sqlite_datareader["dsc_make"]+"",
                            sqlite_datareader["dsc_color"]+"",
                            sqlite_datareader["inward_charge"]+"",
                            (sqlite_datareader["return_init"]+"").Equals("0")?"False":"True",
                            sqlite_datareader["autoreturn_date"]+"",
                            sqlite_datareader["autoreturn_days"]+"",
                            sqlite_datareader["outward_date"]+"",
                            sqlite_datareader["outward_mode"]+"",
                            sqlite_datareader["outward_by"]+"",
                            sqlite_datareader["outward_charges"]+"",
                            sqlite_datareader["outward_collected_by"]+"",
                            sqlite_datareader["courier_name"]+"",
                            sqlite_datareader["courier_track_id"]+"",
                            sqlite_datareader["last_modified"]+"",
                            sqlite_datareader["remarks1"]+"",

                             });

                    }

                    sqlite_datareader.Close();

                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2296:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {

                m_dbConnection.Close();
            }
        }

        private void button13_MouseClick(object sender, MouseEventArgs e)
        {
            if (but_stat == 11 && inco == 0)
            {
                button1_MouseClick(sender, e);

                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                changeDG();
            }
            if (but_stat == 11 && inco == 1)
            {
                button2_MouseClick(sender, e);
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                
            }
            else
            changeDG();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show("Hello");
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (but_stat == 11 && inco == 0)
            { }
            else
            {//MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value + "");
                id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value + "");
                updt = 1;
                button12.Text = "Update";
                button13.Text = "Cancel";
                updtTable();
            }
        }

        private void updtTable()
        {

            if (but_stat == 11 && inco == 1)
            {
                try
                {
                    SQLiteCommand sqlite_cmd1;
                    SQLiteDataReader sqlite_datareader1;
                    SQLiteCommand sqlite_cmd2;
                    SQLiteDataReader dd1;
                    sqlite_cmd1 = m_dbConnection.CreateCommand();
                    sqlite_cmd2 = m_dbConnection.CreateCommand();


                    sqlite_cmd1.CommandText = "SELECT * FROM transaction_master where id =" + id;
                    sqlite_datareader1 = sqlite_cmd1.ExecuteReader();
                    sqlite_datareader1.Read();
                    //comboBox4.SelectedItem= sqlite_datareader["owner_name"] + "";

                    textBox1.Text = sqlite_datareader1["location_ref"] + "";
                    dateTimePicker1.Value = Convert.ToDateTime(sqlite_datareader1["inward_date"] + "");
                    comboBox14.SelectedItem = sqlite_datareader1["owner_name"] + "";

                    sqlite_cmd2.CommandText = "select default_outward_mode from owner_master where id='" + sqlite_datareader1["owner_name"].ToString().Split('.')[0] + "'";
                    dd1 = sqlite_cmd2.ExecuteReader();
                    dd1.Read();
                    String ss = dd1["default_outward_mode"]+"";
                    dd1.Close();
                    
                    sqlite_cmd2.CommandText = "SELECT id, company_name, transport_mode FROM transportation_master where id = " + ss;
                    dd1 = sqlite_cmd2.ExecuteReader();
                    dd1.Read();
                    comboBox12.SelectedItem = dd1["id"] + "." + dd1["transport_mode"] + " (" + dd1["company_name"] + ")";




                    comboBox1.SelectedItem = sqlite_datareader1["inward_by"] + "";
                    comboBox2.SelectedItem = sqlite_datareader1["receive_mode"] + "";
                    comboBox3.SelectedItem = sqlite_datareader1["activity"] + "";
                    textBox4.Text = sqlite_datareader1["dsc_uid"] + "";
                    comboBox4.SelectedItem = sqlite_datareader1["dsc_model"] + "";
                    comboBox5.SelectedItem = sqlite_datareader1["dsc_make"] + "";
                    comboBox6.SelectedItem = sqlite_datareader1["dsc_color"] + "";
                    textBox2.Text = sqlite_datareader1["inward_charge"] + "";
                    comboBox7.SelectedItem = (sqlite_datareader1["return_init"] + "").Equals("1") ? "Yes" : "No";
                    textBox3.Text = sqlite_datareader1["autoreturn_days"] + "";
                    //   MessageBox.Show(sqlite_datareader1["autoreturn_date"] + "");
                    //dateTimePicker2.Value= Convert.ToDateTime(sqlite_datareader1["autoreturn_date"] + "");
                    textBox23.Text = sqlite_datareader1["remarks1"] + "";

                    //comboBox3.SelectedItem = (sqlite_datareader1["active"] + "").Equals("1") ? "Active" : "Inactive";
                    sqlite_datareader1.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2393:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }
                label11.Enabled = false;
                label8.Enabled = false;
                label10.Enabled = false;
                comboBox4.Enabled = false;
                comboBox6.Enabled = false;
                button12.Enabled = true;
                button13.Enabled = true;
                comboBox15.Items.Clear();
                comboBox15.Items.Add("True");
                comboBox15.Items.Add("False");
                comboBox15.SelectedItem = "False";
                comboBox15.BackColor = System.Drawing.Color.GreenYellow;
              
            }

            else if (but_stat == 6)
            {
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM employee_master where id =" + id;
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        textBox1.Text = sqlite_datareader["emp_name"] + "";

                        comboBox3.SelectedItem = (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive";
                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2429:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }
            }
            else if (but_stat==7)
            {
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM activity_master where id =" + id;
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {


                        textBox1.Text = sqlite_datareader["activity"] + "";
                        comboBox3.SelectedItem = (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive";
                    }

                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2434:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }
            }
            else if (but_stat == 8)
            {
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM make_master where id =" + id;
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {


                        textBox1.Text = sqlite_datareader["mfg_name"] + "";
                        textBox5.Text = sqlite_datareader["model"] + "";
                        textBox6.Text = sqlite_datareader["color"] + "";
                        comboBox3.SelectedItem = (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive";
                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2480:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }

            }
            else if (but_stat == 10)
            {
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM transportation_master where id =" + id;
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {


                        textBox1.Text = sqlite_datareader["company_name"] + "";
                        textBox7.Text = sqlite_datareader["contact_num"] + "";
                        textBox9.Text = sqlite_datareader["person_of_contact"] + "";
                        textBox4.Text = sqlite_datareader["transport_mode"] + "";
                        textBox14.Text = sqlite_datareader["fixed_price"] + "";


                        comboBox11.SelectedItem = (sqlite_datareader["active"] + "").Equals("1") ? "Active" : "Inactive";
                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2511:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }

            }
            else if (but_stat == 9)
            {
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM owner_master where id =" + id;
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {

                        textBox1.Text = sqlite_datareader["owner_name"] + "";
                        textBox7.Text = sqlite_datareader["address1"] + "";
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
                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:2568:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            updt = 0;
            pendaler = 0;
            button12.Text = "Submit";
            button13.Text = "Reset";

            if (but_stat == 6 || but_stat == 7)
            {
                
                textBox1.Text = "";
                comboBox3.SelectedItem = "Active";
            }
            if(but_stat==8)
            {
                
                textBox1.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox3.SelectedItem = "Active";
            }
            if(but_stat==10)
            {
                
                textBox1.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                comboBox11.SelectedItem = "Active";

            }
            if(but_stat==11 && inco==1)
            {
                button12.Enabled = false;
                button13.Enabled = false;
            }
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            
            button1.BackColor= System.Drawing.Color.GreenYellow;
            button2.BackColor= System.Drawing.Color.Tomato;
            inco = 0;
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
                textBox21.Text = "";
                textBox22.Text = "";
                textBox23.Text = "";
                label11.Enabled = true;
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today;
                dateTimePicker3.Value = DateTime.Today;
                comboBox14.SelectedItem = "-Select-";
                comboBox1.SelectedItem = "-Select-";
                comboBox2.SelectedItem = "-Select-";
                comboBox3.SelectedItem = "-Select-";
                comboBox5.SelectedItem = "-Select-";
                comboBox4.SelectedItem = "";
                comboBox6.SelectedItem = "";
                comboBox7.SelectedItem = "Yes";
                comboBox12.SelectedItem = "-Select-";
                comboBox13.SelectedItem = "-Select-";
                comboBox15.SelectedItem = "No";

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
            label30.Enabled = false;

            textBox19.Enabled = false;
            textBox20.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;


            comboBox12.Enabled = false;
            comboBox13.Enabled = false;
            comboBox15.Enabled = false;

            dateTimePicker3.Enabled = false;
        }
            {
                but_stat = 11;
                button12.Enabled = true;
                button13.Enabled = true;
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

                {
                    comboBox14.Items.Clear();
                    comboBox14.Items.Add("-Select-");

                    comboBox14.SelectedItem = "-Select-";
                    try
                    {
                        sqlite_cmd.CommandText = "SELECT id,owner_name FROM owner_master where active=1 order by owner_name asc";
                        sqlite_datareader = sqlite_cmd.ExecuteReader();
                        while (sqlite_datareader.Read())
                        {
                            comboBox14.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["owner_name"] + "");

                        }
                        sqlite_datareader.Close();
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:2747:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }
                }//owner
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("-Select-");
                    comboBox1.SelectedItem = "-Select-";
                    comboBox13.Items.Clear();
                    comboBox13.Items.Add("-Select-");
                    comboBox13.SelectedItem = "-Select-";
                    try
                    {
                        sqlite_cmd.CommandText = "SELECT id,emp_name FROM employee_master where active=1  order by emp_name asc";
                        sqlite_datareader = sqlite_cmd.ExecuteReader();
                        while (sqlite_datareader.Read())
                        {
                            comboBox1.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["emp_name"]);
                            comboBox13.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["emp_name"]);
                        }
                        sqlite_datareader.Close();
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:2774:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }
                }//employee
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("-Select-");

                    comboBox2.SelectedItem = "-Select-";
                    comboBox12.Items.Clear();
                    comboBox12.Items.Add("-Select-");

                    comboBox12.SelectedItem = "-Select-";
                    try
                    {
                        sqlite_cmd.CommandText = "SELECT id,company_name,transport_mode FROM transportation_master where active=1 order by transport_mode asc";
                        sqlite_datareader = sqlite_cmd.ExecuteReader();
                        while (sqlite_datareader.Read())
                        {
                            comboBox2.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["transport_mode"] + " (" + sqlite_datareader["company_name"] + ")");
                            comboBox12.Items.Add(sqlite_datareader["id"] + "." + sqlite_datareader["transport_mode"] + " (" + sqlite_datareader["company_name"] + ")");

                        }
                        sqlite_datareader.Close();
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:2804:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }
                }//transport
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("-Select-");

                    comboBox3.SelectedItem = "-Select-";
                    try
                    {
                        sqlite_cmd.CommandText = "SELECT id,activity FROM activity_master where active=1 order by activity asc ";
                        sqlite_datareader = sqlite_cmd.ExecuteReader();
                        while (sqlite_datareader.Read())
                        {
                            comboBox3.Items.Add("" + sqlite_datareader["id"] + "." + sqlite_datareader["activity"]);

                        }
                        sqlite_datareader.Close();
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:2829:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }
                }//activty
                {
                    comboBox7.Items.Clear();
                    comboBox7.Items.Add("Yes");
                    comboBox7.Items.Add("No");
                    comboBox7.SelectedItem = "Yes";
                }//return
                {
                    comboBox5.Items.Clear();
                    comboBox5.Items.Add("-Select-");

                    comboBox5.SelectedItem = "-Select-";
                    try
                    {
                        sqlite_cmd.CommandText = "SELECT id,mfg_name FROM make_master where active=1 order by mfg_name asc ";
                        sqlite_datareader = sqlite_cmd.ExecuteReader();
                        while (sqlite_datareader.Read())
                        {
                            comboBox5.Items.Add("" + sqlite_datareader["id"] + "." + sqlite_datareader["mfg_name"]);

                        }
                        sqlite_datareader.Close();
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:2860:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }
                }//make


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

                {
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
                    label29.Visible = true;
                    label30.Visible = true;

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
                    comboBox14.Visible = true;
                    comboBox15.Visible = true;



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
                    label8.Enabled = false;
                    label9.Enabled = true;
                    label10.Enabled = false;
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
                    comboBox4.Enabled = false;
                    comboBox5.Enabled = true;
                    comboBox6.Enabled = false;
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
                    label30.Enabled = false;

                    textBox19.Enabled = false;
                    textBox20.Enabled = false;
                    textBox21.Enabled = false;
                    textBox22.Enabled = false;


                    comboBox12.Enabled = false;
                    comboBox13.Enabled = false;

                    comboBox15.Enabled = false;

                    dateTimePicker3.Enabled = false;
                }
            }//code from transc button
            changeDG();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            inco = 1;
            pendaler = 0;
            button1.BackColor = System.Drawing.Color.Tomato;
            button2.BackColor = System.Drawing.Color.GreenYellow;

            {

                comboBox15.Items.Clear();
                comboBox15.ResetText();
                comboBox15.BackColor = System.Drawing.Color.White;
                button12.Enabled = false;
                button13.Enabled = false;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                label11.Enabled = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox19.Text = "";
                textBox20.Text = "";
                textBox21.Text = "";
                textBox22.Text = "";
                textBox23.Text = "";

                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today;
                dateTimePicker3.Value = DateTime.Today;
                comboBox14.SelectedItem = "-Select-";
                comboBox1.SelectedItem = "-Select-";
                comboBox2.SelectedItem = "-Select-";
                comboBox3.SelectedItem = "-Select-";
                comboBox5.SelectedItem = "-Select-";
                comboBox4.SelectedItem = "";
                comboBox6.SelectedItem = "";
                comboBox7.SelectedItem = "Yes";
                comboBox12.SelectedItem = "-Select-";
                comboBox13.SelectedItem = "-Select-";
                comboBox15.SelectedItem = "No";


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
                label30.Enabled = true;

                textBox19.Enabled = true;
                textBox20.Enabled = true;
                textBox21.Enabled = true;
                textBox22.Enabled = true;


                comboBox12.Enabled = true;
                comboBox13.Enabled = true;
                comboBox15.Enabled = true;

                dateTimePicker3.Enabled = true;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if(!comboBox5.SelectedItem.Equals("-Select-"))
            {
                comboBox4.Enabled = true;
                comboBox6.Enabled = true;
                label8.Enabled = true;
                label10.Enabled = true;

                comboBox4.Items.Clear();
                comboBox4.Items.Add("");

                comboBox6.Items.Clear();
                comboBox6.Items.Add("");

                comboBox4.SelectedItem = "";
                comboBox6.SelectedItem = "";
                try
                {
                    sqlite_cmd.CommandText = "SELECT model,color FROM make_master where id=" + comboBox5.Text.Split('.')[0] + " ";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        comboBox4.Items.Add("" + sqlite_datareader["model"]);
                        comboBox6.Items.Add("" + sqlite_datareader["color"]);


                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:3190:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }
            }
            else
            {
                comboBox4.Enabled = false;
                comboBox6.Enabled = false;
                label8.Enabled = false;
                label10.Enabled = false;

            }

        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        { if (but_stat == 11 && inco == 0)
            {
                if (!comboBox14.SelectedItem.Equals("-Select-"))
                {
                    try
                    {
                        sqlite_cmd.CommandText = "SELECT default_inward_mode FROM owner_master where id=" + comboBox14.Text.Split('.')[0] + " ";
                        sqlite_datareader = sqlite_cmd.ExecuteReader();

                        while (sqlite_datareader.Read())
                        {
                            SQLiteCommand cmd = m_dbConnection.CreateCommand();
                            cmd.CommandText = "SELECT id, company_name, transport_mode FROM transportation_master where id = " + sqlite_datareader["default_inward_mode"];
                            SQLiteDataReader dd = cmd.ExecuteReader();
                            dd.Read();
                            // MessageBox.Show(dd["id"] + "." + sqlite_datareader["default_inward_mode"]);
                            comboBox2.SelectedItem = dd["id"] + "." + dd["transport_mode"] + " (" + dd["company_name"] + ")";


                        }
                        sqlite_datareader.Close();
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form1.cs:3233:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }

                }
            }
            else if(but_stat == 11 && inco == 1 && !comboBox14.SelectedItem.Equals("-Select-") && pendaler==0) 
            {


                try
                {
                    sqlite_cmd.CommandText = "SELECT default_outward_mode FROM owner_master where id=" + comboBox14.Text.Split('.')[0] + " ";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    while (sqlite_datareader.Read())
                    {
                        SQLiteCommand cmd = m_dbConnection.CreateCommand();
                        cmd.CommandText = "SELECT id, company_name, transport_mode FROM transportation_master where id = " + sqlite_datareader["default_outward_mode"];
                        SQLiteDataReader dd = cmd.ExecuteReader();
                        dd.Read();
                        // MessageBox.Show(dd["id"] + "." + sqlite_datareader["default_inward_mode"]);
                        comboBox12.SelectedItem = dd["id"] + "." + dd["transport_mode"] + " (" + dd["company_name"] + ")";


                    }
                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:3266:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }
                button12.Text = "Submit";
                button13.Text = "Reset";
                

                dataGridView1.ColumnCount = 10;
                dataGridView1.Columns[0].Name = "ID";
                dataGridView1.Columns[1].Name = "Location Reference";
                
                dataGridView1.Columns[2].Name = "Activity";
                dataGridView1.Columns[3].Name = "DSC UID";
                dataGridView1.Columns[4].Name = "DSC Model";
                dataGridView1.Columns[5].Name = "DSC Make";
                dataGridView1.Columns[6].Name = "DSC Color";
                dataGridView1.Columns[7].Name = "Inward Date";
                dataGridView1.Columns[8].Name = "Inward By";
                dataGridView1.Columns[9].Name = "Remarks";
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM transaction_master where record_open='1' and wrong_entry='0' and owner_name='" + comboBox14.SelectedItem + "' order  by datetime(last_modified) desc";

                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {



                        dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "",
                            sqlite_datareader["location_ref"] + "",
                            sqlite_datareader["activity"] + "",
                              sqlite_datareader["dsc_uid"]+"",
                            sqlite_datareader["dsc_model"]+"",
                            sqlite_datareader["dsc_make"]+"",
                            sqlite_datareader["dsc_color"]+"",
                            sqlite_datareader["inward_date"] + "",
                            sqlite_datareader["inward_by"]+"",
                            sqlite_datareader["remarks1"]+"",

                             });

                    }

                    sqlite_datareader.Close();

                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form1.cs:3318:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }



            } 
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if ((dateTimePicker2.Value - dateTimePicker1.Value).Days < 0)
            {
                MessageBox.Show("Please select a valid date");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(but_stat==9)
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (but_stat == 9 || but_stat==10)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (but_stat == 10)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox15.SelectedItem.Equals("True"))
            {
                comboBox15.BackColor = System.Drawing.Color.Red;

            }
            else
            {
                comboBox15.BackColor = System.Drawing.Color.GreenYellow;
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

            if ((dateTimePicker3.Value - dateTimePicker1.Value).Days < 0)
            {
                MessageBox.Show("Outward Date should not be before Inward Date");
            }
        }

        private void label33_DoubleClick(object sender, EventArgs e)
        {
              
            pending();
            pendingdg();
        }
        private void pending()
        {
            button11_MouseClick(null, null);
            try
            {
                sqlite_cmd.CommandText = "SELECT count(*) FROM transaction_master where record_open='1' and wrong_entry='0'  order  by datetime(last_modified) desc";

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                sqlite_datareader.Read();
                label33.Text = sqlite_datareader["count(*)"] + "";
                sqlite_datareader.Close();
            }
            catch (Exception e1)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                {
                    file.WriteLine(DateTime.Now + ":Form1.cs:3428:" + e1 + "\n\n");
                }
                MessageBox.Show(" " + e1);
            }
        }
        private void alert()
        {
            try
            {
                sqlite_cmd.CommandText = "select count(*) from transaction_master where (julianday(autoreturn_date) - julianday('now')) < 1 and record_open = 1 and wrong_entry = 0;";
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                sqlite_datareader.Read();
                if (Int32.Parse(sqlite_datareader["count(*)"] + "") > 0)
                {
                    label37.Visible = true;
                }
                else
                {
                    label37.Visible = false;
                }
                sqlite_datareader.Close();
            }
            catch (Exception e1)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                {
                    file.WriteLine(DateTime.Now + ":Form1.cs:3454:" + e1 + "\n\n");
                }
                MessageBox.Show(" " + e1);
            }
        }
        private void pendingdg()
        {
            but_stat = 11;
            inco = 1;
            pendaler = 1;

            {
                inco = 1;
                button1.BackColor = System.Drawing.Color.Tomato;
                button2.BackColor = System.Drawing.Color.GreenYellow;

                {

                    comboBox15.Items.Clear();
                    comboBox15.ResetText();
                    comboBox15.BackColor = System.Drawing.Color.White;
                    button12.Enabled = false;
                    button13.Enabled = false;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    label11.Enabled = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox19.Text = "";
                    textBox20.Text = "";
                    textBox21.Text = "";
                    textBox22.Text = "";
                    textBox23.Text = "";

                    dateTimePicker1.Value = DateTime.Today;
                    dateTimePicker2.Value = DateTime.Today;
                    dateTimePicker3.Value = DateTime.Today;
                    comboBox14.SelectedItem = "-Select-";
                    comboBox1.SelectedItem = "-Select-";
                    comboBox2.SelectedItem = "-Select-";
                    comboBox3.SelectedItem = "-Select-";
                    comboBox5.SelectedItem = "-Select-";
                    comboBox4.SelectedItem = "";
                    comboBox6.SelectedItem = "";
                    comboBox7.SelectedItem = "Yes";
                    comboBox12.SelectedItem = "-Select-";
                    comboBox13.SelectedItem = "-Select-";
                    comboBox15.SelectedItem = "No";


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
                    label30.Enabled = true;

                    textBox19.Enabled = true;
                    textBox20.Enabled = true;
                    textBox21.Enabled = true;
                    textBox22.Enabled = true;


                    comboBox12.Enabled = true;
                    comboBox13.Enabled = true;
                    comboBox15.Enabled = true;

                    dateTimePicker3.Enabled = true;
                }
            }

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 11;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Location Reference";
            dataGridView1.Columns[2].Name = "Owner";
            dataGridView1.Columns[3].Name = "Activity";
            dataGridView1.Columns[4].Name = "DSC UID";
            dataGridView1.Columns[5].Name = "DSC Model";
            dataGridView1.Columns[6].Name = "DSC Make";
            dataGridView1.Columns[7].Name = "DSC Color";
            dataGridView1.Columns[8].Name = "Inward Date";
            dataGridView1.Columns[9].Name = "Inward By";
            dataGridView1.Columns[10].Name = "Remarks";
            try
            {
                sqlite_cmd.CommandText = "SELECT * FROM transaction_master where record_open='1' and wrong_entry='0'  order  by datetime(last_modified) desc";

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {



                    dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "",
                            sqlite_datareader["location_ref"] + "",
                            sqlite_datareader["owner_name"] + "",
                            sqlite_datareader["activity"] + "",
                              sqlite_datareader["dsc_uid"]+"",
                            sqlite_datareader["dsc_model"]+"",
                            sqlite_datareader["dsc_make"]+"",
                            sqlite_datareader["dsc_color"]+"",
                            sqlite_datareader["inward_date"] + "",
                            sqlite_datareader["inward_by"]+"",
                            sqlite_datareader["remarks1"]+"",

                             });

                }

                sqlite_datareader.Close();
            }
            catch (Exception e1)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                {
                    file.WriteLine(DateTime.Now + ":Form1.cs:3616:" + e1 + "\n\n");
                }
                MessageBox.Show(" " + e1);
            }



        }

        private void label32_DoubleClick(object sender, EventArgs e)
        {
            pending();
            pendingdg();
        }

        private void button14_MouseClick(object sender, MouseEventArgs e)
        {
            Form2 f2 = new Form2(m_dbConnection,this);
            f2.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f2 = new Form4( this);
            f2.Show();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            File.Copy("dsc_management.sqlite", Path.Combine(@".\\backup\", "bkp_" + DateTime.Now.ToString("ddMMMMyyyy_HH_mm_ss") + ".bkp"), true);
            MessageBox.Show("Backup was created successfully");
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            label34.Text = DateTime.Now.ToString("HH:mm");
            label35.Text = DateTime.Now.ToString("dd MMM yyyy");
        }

        private void label37_DoubleClick(object sender, EventArgs e)
        {
            button11_MouseClick(null, null);
            pendaler = 1;
            but_stat = 11;
            inco = 1;


            {
               
                button1.BackColor = System.Drawing.Color.Tomato;
                button2.BackColor = System.Drawing.Color.GreenYellow;

                {

                    comboBox15.Items.Clear();
                    comboBox15.ResetText();
                    comboBox15.BackColor = System.Drawing.Color.White;
                    button12.Enabled = false;
                    button13.Enabled = false;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    label11.Enabled = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox19.Text = "";
                    textBox20.Text = "";
                    textBox21.Text = "";
                    textBox22.Text = "";
                    textBox23.Text = "";

                    dateTimePicker1.Value = DateTime.Today;
                    dateTimePicker2.Value = DateTime.Today;
                    dateTimePicker3.Value = DateTime.Today;
                    comboBox14.SelectedItem = "-Select-";
                    comboBox1.SelectedItem = "-Select-";
                    comboBox2.SelectedItem = "-Select-";
                    comboBox3.SelectedItem = "-Select-";
                    comboBox5.SelectedItem = "-Select-";
                    comboBox4.SelectedItem = "";
                    comboBox6.SelectedItem = "";
                    comboBox7.SelectedItem = "Yes";
                    comboBox12.SelectedItem = "-Select-";
                    comboBox13.SelectedItem = "-Select-";
                    comboBox15.SelectedItem = "No";


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
                    label30.Enabled = true;

                    textBox19.Enabled = true;
                    textBox20.Enabled = true;
                    textBox21.Enabled = true;
                    textBox22.Enabled = true;


                    comboBox12.Enabled = true;
                    comboBox13.Enabled = true;
                    comboBox15.Enabled = true;

                    dateTimePicker3.Enabled = true;
                }
            }

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.ColumnCount = 12;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Location Reference";
            dataGridView1.Columns[2].Name = "Owner";
            dataGridView1.Columns[3].Name = "Activity";
            dataGridView1.Columns[4].Name = "DSC UID";
            dataGridView1.Columns[5].Name = "DSC Model";
            dataGridView1.Columns[6].Name = "DSC Make";
            dataGridView1.Columns[7].Name = "DSC Color";
            dataGridView1.Columns[8].Name = "Inward Date";
            dataGridView1.Columns[9].Name = "Inward By";
            dataGridView1.Columns[10].Name = "Return Date";
            dataGridView1.Columns[11].Name = "Remarks";
            try
            {
                sqlite_cmd.CommandText = "select * from transaction_master where (julianday(autoreturn_date)-julianday('now'))<1 and record_open=1 and wrong_entry=0;  order  by datetime(last_modified) desc";

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {



                    dataGridView1.Rows.Add(new string[] { sqlite_datareader["id"] + "",
                            sqlite_datareader["location_ref"] + "",
                            sqlite_datareader["owner_name"] + "",
                            sqlite_datareader["activity"] + "",
                              sqlite_datareader["dsc_uid"]+"",
                            sqlite_datareader["dsc_model"]+"",
                            sqlite_datareader["dsc_make"]+"",
                            sqlite_datareader["dsc_color"]+"",
                            sqlite_datareader["inward_date"] + "",
                            sqlite_datareader["inward_by"]+"",
                            sqlite_datareader["autoreturn_date"]+"",
                            sqlite_datareader["remarks1"]+"",

                             });

                }

                sqlite_datareader.Close();
            }
            catch (Exception e1)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                {
                    file.WriteLine(DateTime.Now + ":Form1.cs:3827:" + e1 + "\n\n");
                }
                MessageBox.Show(" " + e1);
            }

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F10))
            {
                button12_MouseClick(null, null);
                return true;
            }
          
            if (keyData == (Keys.F2))
            {
                button11_MouseClick(null, null);
                return true;
            }
            if (keyData == (Keys.F3))
            {
                button6_MouseClick(null, null);
                return true;
            }
            if (keyData == (Keys.F4))
            {
                button7_MouseClick(null, null);
                return true;
            }
            if (keyData == (Keys.F5))
            {
                button8_MouseClick(null, null);
                return true;
            }
            if (keyData == (Keys.F6))
            {
                button9_MouseClick(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.P))
            {
                button4_Click(null, null);
                return true;
            }
            
            if (keyData == (Keys.F7))
            {
                button10_MouseClick(null, null);
                return true;
            }
          
            
            if (keyData == (Keys.F11))
            {
                label37_DoubleClick(null, null);
                return true;
            }
            if (keyData == (Keys.F12))
            {
                label32_DoubleClick(null, null);
                return true;
            }

            if (keyData == (Keys.F1))
            {
                button16_Click(null, null);
                return true;
            }
            if (but_stat==11)
            {
                if (keyData == (Keys.F8))
                {
                    button1_MouseClick(null, null);
                    return true;
                }
                if (keyData == (Keys.F9))
                {
                    button2_MouseClick(null, null);
                    return true;
                }
            }
            if (keyData == (Keys.Alt | Keys.X))
            {
                this.Close();
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f2 = new Form5(this,m_dbConnection);
            f2.Show();

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!textBox3.Text.Equals(""))
            {
                if (Int32.Parse(textBox3.Text) > 60)
                {
                    MessageBox.Show("This is an alert message as you have entered days value greater than 60");
                }
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (!textBox7.Text.Equals(""))
            {
                if (but_stat == 10)
                {
                    if (textBox7.Text.Length < 10)
                    {
                        MessageBox.Show("Contact Number is less than 10 digits");
                    }
                }
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (!textBox14.Text.Equals(""))
            {
                if (but_stat == 10)
                {
                    if (Int32.Parse(textBox14.Text) > 10000)
                    {
                        MessageBox.Show("The price value has exceeded 10,000");
                    }

                }

                if (but_stat == 9)
                {
                    if (textBox14.Text.Length < 10)
                    {
                        MessageBox.Show("Contact Number is less than 10 digits");
                    }
                }
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (!textBox4.Text.Equals(""))
            {
                if (but_stat == 9)
                {
                    if (textBox4.Text.Length < 10)
                    {
                        MessageBox.Show("Contact Number is less than 10 digits");
                    }
                }
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (!textBox15.Text.Equals(""))
            {
                if (but_stat == 9)
                {
                    if (textBox15.Text.Length < 10)
                    {
                        MessageBox.Show("Contact Number is less than 10 digits");
                    }
                }
            }
        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            if (!textBox16.Text.Equals(""))
            {
                if (!regex1.IsMatch(textBox16.Text))
                {

                    MessageBox.Show("Your email address format is not correct!");

                }
            }
        }

        private void textBox17_Leave(object sender, EventArgs e)
        {
            if (!textBox17.Text.Equals(""))
            {
                if (!regex1.IsMatch(textBox17.Text))
                {

                    MessageBox.Show("Your email address format is not correct!");

                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if(!textBox2.Text.Equals("") && Int32.Parse(textBox2.Text)>10000)
            {
                MessageBox.Show("The amount is greater than 10,000");
            }
            
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            if (!textBox19.Text.Equals("") && Int32.Parse(textBox19.Text) > 10000)
            {
                MessageBox.Show("The amount is greater than 10,000");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form6 f2 = new Form6(this);
            f2.Show();
        }
    }
}
