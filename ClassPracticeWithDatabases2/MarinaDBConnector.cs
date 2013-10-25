using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPracticeWithDatabases2
{
    class MarinaDBConnector
    {
        private SqlConnection dbSqlConnection;
        //private bool dbConnectionIsPersistent = true;
        //public string DbConnectionString { get; set; }

        public MarinaDBConnector(string dbConnectionString)
        {
            //open connection set it to dbSqlConnection
            dbSqlConnection = new SqlConnection(dbConnectionString);
            dbSqlConnection.Open();
        }

        ~MarinaDBConnector()
        {
            //close connection
            dbSqlConnection.Close();
            
        }
        
        /// <summary>
        /// Selects an individual MarinaDBRow from Marina table
        /// </summary>
        /// <param name="id">id of the requested row</param>
        /// <returns>MarinaDBRow object</returns>
        public MarinaDBRow Select(string id)
        {
            MarinaDBRow row = new MarinaDBRow();

            String sqlQueryString = "SELECT marina_num, name, address, city, state, zip FROM marina WHERE marina_num = " + id + ";";
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, dbSqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                row.id = reader[0].ToString().Trim();
                row.name = reader[1].ToString().Trim();
                row.address = reader[2].ToString().Trim();
                row.city = reader[3].ToString().Trim();
                row.state = reader[4].ToString().Trim();
                row.zip = reader[5].ToString().Trim();
            }
            reader.Close();

            return row;
        }

        /// <summary>
        /// Inserts a MarinaDBRow into the Marina table
        /// </summary>
        /// <param name="?">MarinaDBRow to be inserted</param>
        /// <returns>Number of rows affected in the Marina table</returns>
        public int Insert(MarinaDBRow row)
        {
            int returnNum = 0;

            String sqlQueryString = "INSERT INTO marina VALUES ('" + row.id + "','" + row.name + "','" + row.address + "','" + row.city + "','" + row.state + "','" + row.zip + "');";
            SqlCommand command = new SqlCommand(sqlQueryString, dbSqlConnection);

            returnNum = command.ExecuteNonQuery();

            return returnNum;
        }

        /// <summary>
        /// Inserts data into the Marina table
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <returns>Number of rows affected in the Marina table</returns>
        public int Insert(string id, string name, string address, string city, string state, string zip)
        {

            //stub
            return 0;
        }

        /// <summary>
        /// Updates a Marina row
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <returns>Number of rows affected in the Marina table</returns>
        public int Update(string id, string name, string address, string city, string state, string zip)
        {

            //stub
            return 0;
        }

        /// <summary>
        /// Updates a Marina row
        /// </summary>
        /// <param name="oldId">id value to change</param>
        /// <param name="newId">updated id value</param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <returns>Number of rows affected in the Marina table</returns>
        public int Update(string oldId, string newId, string name, string address, string city, string state, string zip)
        {

            //stub
            return 0;
        }

        /// <summary>
        /// Updates a Marina row
        /// </summary>
        /// <param name="id">id value to change</param>
        /// <param name="row"></param>
        /// <returns>Number of rows updated in the Marina table</returns>
        public int Update(string id, MarinaDBRow row)
        {

            //stub
            return 0;
        }
        /// <summary>
        /// Deletes a row in the Marina table
        /// </summary>
        /// <param name="id">id of row to be deleted</param>
        /// <returns>Number of rows affected in the Marina table</returns>
        public int Delete(string id)
        {
            //stub
            return 0;
        }
    }
}
