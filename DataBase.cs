using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barmaster
{
    internal static  class DataBase
    {
        //פונקצית חיבור למסד הנתונים 
        public static SqlConnection GetOpenConnection()
        {
            string connectionString = "Server=MAYAZARIA\\SQLEXPRESS;Database=Bar Master;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }


        //פונקציה שמקבלת שאילתת 
        //sql
        //ושולחת אותה לבתור פקודה למסד הנתונים
        public static void send(string sql)
        {
            //pass
            using (SqlConnection connection = GetOpenConnection())
            {
                try
                {
                    SqlCommand createDatabaseCommand = new SqlCommand(sql, connection);
                    createDatabaseCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

        }

        // פונקציית SELECT להוצאת ושליה מידע ממסד הנתונים 
        public static DataTable select(string sql)
        {
            //pass
            using (SqlConnection connection = GetOpenConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // הרצת השאילתא והחזרת התוצאה כ-DataReader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // יצירת DataTable לאחסון הנתונים שהתקבלו
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            return dataTable;

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    return null;
                }
            }

        }
    }
}
