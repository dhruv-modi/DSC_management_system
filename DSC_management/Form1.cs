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
           

            comboBox3.Items.Add("Active");
            comboBox3.Items.Add("Inactive");
            comboBox3.SelectedItem="Active";
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

            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

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
            changeDG();

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
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;

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

            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;

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

            comboBox3.ResetText();
            comboBox3.Items.Clear();



        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 6;

            button1.Enabled = false;
            button2.Enabled = false;

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
            comboBox3.Items.Add("Active");
            comboBox3.Items.Add("Inactive");
            comboBox3.SelectedItem = "Active";
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

            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

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

            changeDG();
        }

        private void button8_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 8;

            button1.Enabled = false;
            button2.Enabled = false;

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
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;

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

            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

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
            changeDG();
        }

        private void button9_MouseClick(object sender, MouseEventArgs e)
        {
            but_stat = 9;

            button1.Enabled = false;
            button2.Enabled = false;

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


            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

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
                    textBox1.Text = "";
                    comboBox3.SelectedItem = "Active";
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
                    button12.Text = "Submit";
                    button13.Text = "Reset";
                    updt = 0;
                    textBox1.Text = "";
                    comboBox3.SelectedItem = "Active";
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
                    textBox1.Text = "";
                    comboBox3.SelectedItem = "Active";
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
                    button12.Text = "Submit";
                    button13.Text = "Reset";
                    updt = 0;
                    textBox1.Text = "";
                    comboBox3.SelectedItem = "Active";
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
                    textBox1.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    comboBox3.SelectedItem = "Active";
                }
                else
                {
                    sqlite_cmd.CommandText = (comboBox3.SelectedItem.Equals("Active")) ? "update make_master set mfg_name = '" + textBox1.Text + "',model = '" + textBox5.Text + "',color = '" + textBox6.Text + "', active = '1', updated=current_timestamp where id = " + id : "update employee_master set mfg_name = '" + textBox1.Text + "',model = '" + textBox5.Text + "',color = '" + textBox6.Text + "', active = '0', updated=current_timestamp where id = " + id;
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
                    button12.Text = "Submit";
                    button13.Text = "Reset";
                    updt = 0;
                    textBox1.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    comboBox3.SelectedItem = "Active";

                }
            }
            changeDG();
        }
        private void changeDG()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            if(but_stat==8)
            {
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
        }
    }
}
