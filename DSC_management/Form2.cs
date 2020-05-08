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
using Excel = Microsoft.Office.Interop.Excel;

namespace DSC_management
{
    public partial class Form2 : Form
    {
       
        SQLiteCommand sqlite_cmd;
        SQLiteConnection m_dbConnection;
        SQLiteDataReader sqlite_datareader;
        Form1 fa1;
        public Form2(SQLiteConnection m_db, Form1 fa)
        {
            fa1 = fa;
            fa1.Enabled = false;
            m_dbConnection = m_db;
            sqlite_cmd = m_db.CreateCommand();

         


            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.ShowDialog();
            { 

               
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");

                }
                else
                {
                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells[1, 1] = "ID";
                    xlWorkSheet.Cells[1, 2] = "Location Ref.";
                    xlWorkSheet.Cells[1, 3] = "Owner Name";
                    xlWorkSheet.Cells[1, 4] = "Transaction Date";
                    xlWorkSheet.Cells[1, 5] = "Inward Date";
                    xlWorkSheet.Cells[1, 6] = "Inward By";
                    xlWorkSheet.Cells[1, 7] = "Receive Mode";
                    xlWorkSheet.Cells[1, 8] = "Activity";
                    xlWorkSheet.Cells[1, 9] = "DSC UID";
                    xlWorkSheet.Cells[1, 10] = "DSC Model";
                    xlWorkSheet.Cells[1, 11] = "DSC Make";
                    xlWorkSheet.Cells[1, 12] = "DSC Color";
                    xlWorkSheet.Cells[1, 13] = "Inward Charge";
                    xlWorkSheet.Cells[1, 14] = "Return Init";
                    xlWorkSheet.Cells[1, 15] = "Autoreturn Date";
                    xlWorkSheet.Cells[1, 16] = "Autoreturn Days";
                    xlWorkSheet.Cells[1, 17] = "Outward Date";
                    xlWorkSheet.Cells[1, 18] = "Outward Mode";
                    xlWorkSheet.Cells[1, 19] = "Outward By";
                    xlWorkSheet.Cells[1, 20] = "Outward Charges";
                    xlWorkSheet.Cells[1, 21] = "Outward Collected By";
                    xlWorkSheet.Cells[1, 22] = "Courier Name";
                    xlWorkSheet.Cells[1, 23] = "Courier Track ID";
                    xlWorkSheet.Cells[1, 24] = "DSC Stayed";
                    xlWorkSheet.Cells[1, 25] = "Record Open";
                    xlWorkSheet.Cells[1, 26] = "Last Modified";
                    xlWorkSheet.Cells[1, 27] = "Wrong Entry";
                    xlWorkSheet.Cells[1, 28] = "Remarks";

                    
                    int i = 1;
                    try
                    {
                        sqlite_cmd.CommandText = "SELECT * FROM transaction_master";

                        sqlite_datareader = sqlite_cmd.ExecuteReader();
                        while (sqlite_datareader.Read()) // Reading Rows
                        {

                            for (int j = 0; j <= sqlite_datareader.FieldCount - 1; j++) // Looping throw colums
                            {
                                if ((j == 2 || j == 5 || j == 6 || j == 7 || j == 10 || j == 17 || j == 18) && !(sqlite_datareader.GetValue(j).ToString().Equals("")))
                                {
                                    // MessageBox.Show(sqlite_datareader.GetValue(j).ToString());

                                    xlWorkSheet.Cells[i + 1, j + 1] = sqlite_datareader.GetValue(j).ToString().Split('.')[1];
                                }
                                else
                                {
                                    xlWorkSheet.Cells[i + 1, j + 1] = sqlite_datareader.GetValue(j).ToString();

                                }
                            }
                            i++;
                        }

                        sqlite_datareader.Close();
                    }
                    catch (Exception e1)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log\\DSC.log", true))
                        {
                            file.WriteLine(DateTime.Now + ":Form2.cs:120:" + e1 + "\n\n");
                        }
                        MessageBox.Show(" " + e1);
                    }


                    try
                    {
                        this.Hide();
                        
                        xlWorkBook.SaveAs("", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(true, misValue, misValue);
                    }
                    catch (Exception e1)
                    {
                        xlWorkBook.Close(true, misValue, misValue);
                    }
                    xlApp.Quit();
                    
                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                  
                    this.Close();
                }
                
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            fa1.Enabled = true;
            fa1.BringToFront();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Comming Soon");
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

    }
}
