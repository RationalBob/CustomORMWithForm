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
    public partial class Form1 : Form
    {
        private MarinaDBConnector connector = new MarinaDBConnector("Data Source=(local);Initial Catalog=ALEXAMARA;User Id=sa;Password=abc123;Integrated Security=false");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnGo_Click(object sender, EventArgs e)
        {
            string recordNum = txtGo.Text;
            MarinaDBRow row;

            row = connector.Select(recordNum);

            txtNum.Text = row.id;
            txtName.Text = row.name;
            txtAddress.Text = row.address;
            txtCity.Text = row.city;
            txtState.Text = row.state;
            txtZip.Text = row.zip;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string recordNum = txtUpdate.Text;
            String connectionString = "Data Source=(local);Initial Catalog=ALEXAMARA;User Id=sa;Password=abc123;Integrated Security=false";
            String sqlQueryString = "UPDATE marina SET marina_num='" + txtNum.Text + "', name='" + txtName.Text + "', address='" + txtAddress.Text + "', city='" + txtCity.Text +"', state='" + txtState.Text + "', zip='" + txtZip.Text + "' WHERE marina_num='" + recordNum + "';";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, sqlConnection);

            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("Record updated");

            sqlConnection.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string recordNum = txtUpdate.Text;
            String connectionString = "Data Source=(local);Initial Catalog=ALEXAMARA;User Id=sa;Password=abc123;Integrated Security=false";
            String sqlQueryString = "DELETE FROM marina WHERE marina_num=" + recordNum + ";";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQueryString, sqlConnection);

            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            txtNum.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtGo.Text = "";
            txtUpdate.Text = "";
            txtDelete.Text = "";

            MessageBox.Show("Record deleted");

            sqlConnection.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            MarinaDBRow row = new MarinaDBRow();

            row.id = txtNum.Text;
            row.name = txtName.Text;
            row.address = txtAddress.Text;
            row.city = txtCity.Text;
            row.state = txtState.Text;
            row.zip = txtZip.Text;

            int numRowsInserted = connector.Insert(row);

            MessageBox.Show(numRowsInserted + "row(s) inserted!");


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNum.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtGo.Text = "";
            txtUpdate.Text = "";
            txtDelete.Text = "";
        }
    }
}
