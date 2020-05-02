using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace DSC_management
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SQLiteConnection m_dbConnection;


            if (File.Exists("dsc_management.sqlite"))
            {
               // MessageBox.Show("Hello");
                m_dbConnection = new SQLiteConnection("Data Source=dsc_management.sqlite;Version=3;");
                m_dbConnection.Open();

            }
            else
            {
                // MessageBox.Show("Hello");   
                SQLiteConnection.CreateFile("dsc_management.sqlite");
                m_dbConnection = new SQLiteConnection("Data Source=dsc_management.sqlite;Version=3;");
                // m_dbConnection.SetPassword("hello123");
                m_dbConnection.Open();
                try
                {
                    string sql = "CREATE TABLE `activity_master` (`id`	INTEGER PRIMARY KEY AUTOINCREMENT,`activity`	varchar ( 20 ),`active`	INTEGER DEFAULT 1,`updated`	INTEGER DEFAULT current_timestamp,`usr_char_1`	varchar ( 10 ),`usr_char_2`	varchar ( 20 ),`usr_char_3`	varchar ( 50 ),`usr_int_1`	INTEGER,`usr_int_2`	INTEGER,`usr_int_3`	INTEGER,`usr_dec_1`	decimal,`usr_dec_2`	decimal,`usr_dec_3`	decimal,`usr_dt_1`	datetime,`usr_dt_2`	datetime,`usr_dt_3`	datetime);";
                    SQLiteCommand command = m_dbConnection.CreateCommand();
                    command.CommandText = sql;
                    command.ExecuteNonQuery();


                    sql = "CREATE TABLE 'employee_master' ( `id` INTEGER PRIMARY KEY AUTOINCREMENT, `emp_name` varchar ( 30 ), `active` INTEGER DEFAULT 1, `Updated` datetime DEFAULT current_timestamp, `usr_char_1` varchar ( 10 ), `usr_char_2` varchar ( 20 ), `usr_char_3` varchar ( 50 ), `usr_int_1` INTEGER, `usr_int_2` INTEGER, `usr_int_3` INTEGER, `usr_dec_1` decimal, `usr_dec_2` decimal, `usr_dec_3` decimal, `usr_dt_1` datetime, `usr_dt_2` datetime, `usr_dt_3` datetime ); ";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE 'make_master' ( `id` INTEGER PRIMARY KEY AUTOINCREMENT, `mfg_name` varchar ( 30 ), `model` varchar ( 30 ), `color` varchar ( 10 ), `active` INTEGER DEFAULT 1, `updated` datetime DEFAULT current_timestamp, `usr_char_1` varchar ( 10 ), `usr_char_2` varchar ( 20 ), `usr_char_3` varchar ( 50 ), `usr_int_1` INTEGER, `usr_int_2` INTEGER, `usr_int_3` INTEGER, `usr_dec_1` decimal, `usr_dec_2` decimal, `usr_dec_3` decimal, `usr_dt_1` datetime, `usr_dt_2` datetime, `usr_dt_3` datetime );";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE 'owner_master' ( `id` INTEGER PRIMARY KEY AUTOINCREMENT, `owner_name` varchar ( 20 ), `address1` varchar ( 30 ), `address2` varchar ( 30 ), `city` varchar ( 30 ), `state` varchar ( 30 ), `country` varchar ( 30 ), `pincode` varchar ( 10 ), `sms_contact` varchar ( 12 ), `contact_name` varhcar ( 30 ), `whatsapp_contact` varchar ( 12 ), `telegram_contact` varchar ( 12 ), `email1` varchar ( 100 ), `email2` varchar ( 100 ), `owner_ref` varchar ( 50 ), `default_inward_mode` INTEGER, `default_outward_mode` INTEGER, `active` INTEGER DEFAULT 1, `updated` datetime DEFAULT current_timestamp, `usr_char_1` varchar ( 10 ), `usr_char_2` varchar ( 20 ), `usr_char_3` varchar ( 50 ), `usr_int_1` INTEGER, `usr_int_2` INTEGER, `usr_int_3` INTEGER, `usr_dec_1` decimal, `usr_dec_2` decimal, `usr_dec_3` decimal, `usr_dt_1` datetime, `usr_dt_2` datetime, `usr_dt_3` datetime );";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE `transaction_master` ( `record_id` INTEGER PRIMARY KEY AUTOINCREMENT, `location_ref` varchar ( 50 ), `trans_date` datetime, `inward_date` datetime, `inward_by` varchar ( 30 ), `receive_mode` varchar ( 30 ), `activity_id` varchar ( 50 ), `dsc_uid` varchar ( 20 ), `dsc_model` varchar ( 30 ), `dsc_make` varchar ( 30 ), `dsc_colour` varchar ( 30 ), `inward_charge` INTEGER, `return_init` Integer ( 1 ), `autoreturn_date` datetime, `autoreturn_days` INTEGER, `outward_date` datetime, `outward_mode` varchar(30), `outward_by` varchar ( 30 ), `outward_charges` INTEGER, `outward_collected_by` INTEGER, `courier_name` varchar ( 30 ), `courier_track_id` INTEGER, `dsc_stayed` INTEGER, `record_open` INTEGER DEFAULT 1, `last_modified` datetime, `wrong_entry` INTEGER DEFAULT 0, `remarks1` varchar ( 100 ), `remarks2` varchar ( 100 ), `usr_char_1` varchar ( 10 ), `usr_char_2` varchar ( 20 ), `usr_char_3` varchar ( 50 ), `usr_int_1` INTEGER, `usr_int_2` INTEGER, `usr_int_3` INTEGER, `usr_dec_1` decimal, `usr_dec_2` decimal, `usr_dec_3` decimal, `usr_dt_1` datetime, `usr_dt_2` datetime, `usr_dt_3` datetime );";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                    sql = "CREATE TABLE 'transportation_master' ( `id` INTEGER PRIMARY KEY AUTOINCREMENT, `company_name` varchar ( 30 ), `contact_num` varchar ( 12 ), `person_of_contact` varchar ( 30 ), `transport_mode` varchar ( 30 ), `fixed_price` INTEGER, `active` INTEGER DEFAULT 1, `updated` datetime DEFAULT current_timestamp, `usr_char_1` varchar ( 10 ), `usr_char_2` varchar ( 20 ), `usr_char_3` varchar ( 50 ), `usr_int_1` INTEGER, `usr_int_2` INTEGER, `usr_int_3` INTEGER, `usr_dec_1` decimal, `usr_dec_2` decimal, `usr_dec_3` decimal, `usr_dt_1` datetime, `usr_dt_2` datetime, `usr_dt_3` datetime );";
                    command.CommandText = sql;
                    command.ExecuteNonQuery();



                }
                catch (Exception e)
                {

                    MessageBox.Show("programlog.txt", "Main form " + e + Environment.NewLine);


                }

              
            }
            Application.Run(new Form1(m_dbConnection));
        }
    }
}