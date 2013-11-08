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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Marina m1 = Marina.GetMarinaById(txtGo.Text);
            
            txtNum.Text = m1.id;
            txtName.Text = m1.name;
            txtAddress.Text = m1.address;
            txtCity.Text = m1.city;
            txtState.Text = m1.state;
            txtZip.Text = m1.zip;

            txtUpdate.Text = txtGo.Text;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idNum = Convert.ToInt32(txtUpdate.Text);
            int numRowsAffected;
            Marina m1 = new Marina();
            m1.id = txtNum.Text;
            m1.name = txtName.Text;
            m1.address = txtAddress.Text;
            m1.city = txtCity.Text;
            m1.state = txtState.Text;
            m1.zip = txtZip.Text;
            numRowsAffected = Marina.Update(m1, idNum);

            MessageBox.Show(numRowsAffected + " record(s) affected");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int numRowsAffected;
            numRowsAffected = Marina.Delete(txtDelete.Text);
            MessageBox.Show(numRowsAffected + " record(s) affected");

            txtNum.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtGo.Text = "";
            txtUpdate.Text = "";
            txtDelete.Text = "";
            txtNum.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Marina m1 = new Marina();
            int numRowsAffected;
            m1.id = txtNum.Text;
            m1.name = txtName.Text;
            m1.address = txtAddress.Text;
            m1.city = txtCity.Text;
            m1.state = txtState.Text;
            m1.zip = txtZip.Text;
            numRowsAffected = Marina.InsertMarina(m1);

            MessageBox.Show(numRowsAffected + " record(s) affected");
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            List<Marina> marinaList = Marina.GetAllMarinas();
            foreach (Marina marina in marinaList)
            {
                MessageBox.Show(marina.id + " " + marina.name + " " + marina.address + " " + marina.city + " " + marina.state + " " + marina.zip);
            }
        }
    }
}
