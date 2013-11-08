using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassPracticeWithDatabases2
{
    class Marina
    {
        public string id;
        public string name;
        public string address;
        public string city;
        public string state;
        public string zip;

        public static int Update(Marina updateMarina, int idNum)
        {
            SqlConnection dbSqlConnection = new SqlConnection(ClassPracticeWithDatabases2.Properties.Resources.DBConnectionString);
            dbSqlConnection.Open();

            string sqlQueryString = "UPDATE marina SET marina_num='" + updateMarina.id + "', name='" + updateMarina.name + "', address='" + updateMarina.address + "', city='" + updateMarina.city + "', state='" + updateMarina.state + "', zip='" + updateMarina.zip + "' WHERE marina_num='" + idNum +"';";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            int numRowsAffected = sqlCommand.ExecuteNonQuery();

            dbSqlConnection.Close();

            return numRowsAffected;
        }

        public static int Delete(string id)
        {
            SqlConnection dbSqlConnection = new SqlConnection(ClassPracticeWithDatabases2.Properties.Resources.DBConnectionString);
            dbSqlConnection.Open();
            
            string sqlQueryString = "DELETE FROM marina WHERE marina_num = '" + id + "';";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            int numRowsAffected = sqlCommand.ExecuteNonQuery();
            
            dbSqlConnection.Close();

            return numRowsAffected;
        }
        
        public static Marina GetMarinaById(string id)
        {
            Marina tempMarina = new Marina();

            SqlConnection dbSqlConnection = new SqlConnection(ClassPracticeWithDatabases2.Properties.Resources.DBConnectionString);
            dbSqlConnection.Open();

            string sqlQueryString = "SELECT marina_num, name, address, city, state, zip FROM marina WHERE marina_num = '" + id + "';";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);

            SqlDataReader newReader = sqlCommand.ExecuteReader();
            while (newReader.Read())
            {
                tempMarina.id = newReader[0].ToString().Trim();
                tempMarina.name = newReader[1].ToString().Trim();
                tempMarina.address = newReader[2].ToString().Trim();
                tempMarina.city = newReader[3].ToString().Trim();
                tempMarina.state = newReader[4].ToString().Trim();
                tempMarina.zip = newReader[5].ToString().Trim();
            }
            newReader.Close();

            return tempMarina;
        }

        public static int InsertMarina(Marina tempMarina)
        {            
            int numRowsAffected;

            SqlConnection dbSqlConnection = new SqlConnection(ClassPracticeWithDatabases2.Properties.Resources.DBConnectionString);
            dbSqlConnection.Open();

            string sqlQueryString = "INSERT INTO marina VALUES ('" + tempMarina.id + "', '" + tempMarina.name + "', '" + tempMarina.address + "', '" + tempMarina.city + "', '" + tempMarina.state + "', '" + tempMarina.zip + "');";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);
            numRowsAffected = sqlCommand.ExecuteNonQuery();

            dbSqlConnection.Close();

            return numRowsAffected;
        }

        public static List<Marina> GetAllMarinas()
        {
            List<Marina> marinaList = new List<Marina>();
            
            SqlConnection dbSqlConnection = new SqlConnection(ClassPracticeWithDatabases2.Properties.Resources.DBConnectionString);
            dbSqlConnection.Open();

            string sqlQueryString = "SELECT marina_num, name, address, city, state, zip FROM marina;";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Marina tempMarina = new Marina();

                tempMarina.id = reader[0].ToString().Trim();
                tempMarina.name = reader[1].ToString().Trim();
                tempMarina.address = reader[2].ToString().Trim();
                tempMarina.city = reader[3].ToString().Trim();
                tempMarina.state = reader[4].ToString().Trim();
                tempMarina.zip = reader[5].ToString().Trim();

                marinaList.Add(tempMarina);
            }

            reader.Close();


            return marinaList;
        }

        public Marina()
        {

        }
    }
}
