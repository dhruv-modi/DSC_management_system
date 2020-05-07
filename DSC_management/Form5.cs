using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace DSC_management
{
    public partial class Form5 : Form
    {
        SQLiteCommand sqlite_cmd, sqlite_cmd1;
        SQLiteConnection m_dbConnection;
        SQLiteDataReader sqlite_datareader;
        Form1 f1;
        public Form5(Form1 fa1, SQLiteConnection m_db)
        {
            m_dbConnection = m_db;
            sqlite_cmd = m_db.CreateCommand();
            sqlite_cmd1 = m_db.CreateCommand();
            f1 =fa1;
            f1.Enabled = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals(""))
            {
                MessageBox.Show("Please enter an ID");
            }
            else
            {
                try
                {
                    sqlite_cmd.CommandText = "SELECT count(*),strftime('%d-%m-%Y', inward_date) as inw,strftime('%d-%m-%Y', outward_date) as outw,* FROM transaction_master where record_open='0' and wrong_entry='0' and id= '" + textBox1.Text + "';";

                    sqlite_datareader = sqlite_cmd.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        if (Int32.Parse(sqlite_datareader["count(*)"] + "") == 1)
                        {



                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(".\\report.html", false))
                            {
                                file.WriteLine("<!DOCTYPE html><html><head><style>th, td {border: 1px solid black;border-collapse: collapse;}</style></head><body><h1 style=\"text - align:center\">DSC MANAGEMENT</h1><table style=\"width: 100 %; border: 1px solid black; margin - left:auto; margin - right:auto; \" ><tr style=\"text - align:center\"><td>ID:</td><td>" +
                                    "" + sqlite_datareader["id"] + "</td></tr><tr style=\"text - align:center\"><td>Owner Name:</td><td>" + sqlite_datareader["owner_name"].ToString().Split('.')[1] +
                                   "</td></tr><tr style=\"text - align:center\"><td>Purpose:</td><td>" + sqlite_datareader["activity"].ToString().Split('.')[1] +
                                   "</td></tr><tr style=\"text - align:center\"><td>Inward Date:</td><td>" + sqlite_datareader["inw"] +
                                   "</td></tr><tr style=\"text - align:center\"><td>Inward Mode:</td><td>" + sqlite_datareader["receive_mode"].ToString().Split('.')[1] +
                                   "</td></tr><tr style=\"text - align:center\"><td>Inward By:</td><td>" + sqlite_datareader["inward_by"].ToString().Split('.')[1] +
                                   "</td></tr><tr style=\"text - align:center\"><td>Outward Date:</td><td>" + sqlite_datareader["outw"] +
                                   "</td></tr><tr style=\"text - align:center\"><td>Outward Mode:</td><td>" + sqlite_datareader["outward_mode"].ToString().Split('.')[1] +
                                   "</td></tr><tr style=\"text - align:center\"><td>Outward By:</td><td>" + sqlite_datareader["outward_by"].ToString().Split('.')[1] +
                                   "</td></tr></table><br/><h3>Remarks: " + sqlite_datareader["remarks1"] +
                                   "</h3><br/><h3>Generated On: " + DateTime.Today.ToString("dd/MM/yyyy") +
                                   "</h3><h3>Signature: </h3></body></html>");

                            }

                            String ss = sqlite_datareader["id"] + "_" + sqlite_datareader["report_count"] + ".pdf";
                            System.Diagnostics.Process process = System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + "\\html2pdf.exe", System.IO.Directory.GetCurrentDirectory() + "\\report.html " + System.IO.Directory.GetCurrentDirectory() + "\\reports\\" + ss);
                            while (!process.HasExited)
                            {

                            }
                            System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + "\\reports\\" + ss);

                            if (MessageBox.Show("Report looks fine?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                sqlite_cmd1.CommandText = "update transaction_master set report_count=report_count+1,report_date=current_time,report_name='" + ss + "' where id=" + sqlite_datareader["id"];
                                sqlite_cmd1.ExecuteNonQuery();
                            }
                            File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\report.html");





                        }
                        else
                        {
                            MessageBox.Show("ID not valid\n (if the id exist and you are still seeing this message then it could be because the transaction is still not completed or the transaction has been marked invalid)");
                        }




                    }

                    sqlite_datareader.Close();
                }
                catch (Exception e1)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                    {
                        file.WriteLine(DateTime.Now + ":Form5.cs:104:" + e1 + "\n\n");
                    }
                    MessageBox.Show(" " + e1);
                }




            }


        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Enabled = true;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Enter))
            {
                button1_Click(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.Back))
            {
                textBox1.Text = "";
                return true;
            }
          
            if (keyData == (Keys.Control | Keys.C))
            {
                this.Close();
                return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
