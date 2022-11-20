using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Test
{
    public partial class FrmSalesOrder : Form
    {
        public FrmSalesOrder()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=SalesOrder;Integrated Security=True");
        //SqlCommand cmd = new SqlCommand();

        private void FrmSalesOrder_Load(object sender, EventArgs e)
        {
            DataTable customerDataset = new DataTable();
            customerDataset = getCustomers();
            foreach (DataRow row in customerDataset.Rows)
            {
                cmbCustomer customer = new cmbCustomer();
                customer.DCLink = int.Parse(row["DCLink"].ToString());
                customer.Name = row["Name"].ToString();
                customer.Physical1 = row["Physical1"].ToString();
                customer.Physical2 = row["Physical2"].ToString();
                customer.Physical3 = row["Physical3"].ToString();
                customer.Physical4 = row["Physical4"].ToString();
                customer.Post4 = row["Post4"].ToString();
                customer.Post5 = row["Post5"].ToString();
                customer.PhysicalPC = row["PhysicalPC"].ToString();
                cmbCustomers.Items.Add(customer);
            }

            cmbitemcodeLoad();
            cmbitemDescription();
        }
        public DataTable getCustomers()
        {
            DataTable customerDataset = new DataTable();
            string sql= "Select * from Client";
            SqlCommand cmd = new SqlCommand(sql ,con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();    
            customerDataset.Load(reader);
            con.Close();

            return customerDataset;
        }


        private void cmbitemcodeLoad()
        {
            DataTable items = new DataTable();
            string sql = "Select Code from StkItem";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            items.Load(reader);
            con.Close();

            foreach (DataRow row in items.Rows)
            {
                cmbItems cmbitems = new cmbItems();
                cmbitems.Code = row["Code"].ToString();

               ItemCode.Items.Add(cmbitems.ToString());
            }
            //ItemCode.ValueType = typeof(cmbitems);


        }
        private void cmbitemDescription()
        {
            DataTable items = new DataTable();
            string sql = "Select Description_1 from StkItem";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            items.Load(reader);
            con.Close();

            foreach (DataRow row in items.Rows)
            {
                cmbItemDescription cmbitems = new cmbItemDescription();
                cmbitems.Description_1 = row["Description_1"].ToString();

                Description.Items.Add(cmbitems.ToString());
            }


        }

        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable customerDataset = new DataTable();
            customerDataset = getCustomers();
            if (cmbCustomers.SelectedIndex != -1)
            {
               
                if ((cmbCustomers.SelectedItem as cmbCustomer).DCLink != null)
                {
                    txtAddress1.Text = (cmbCustomers.SelectedItem as cmbCustomer).Physical1.ToString();
                    txtAddress2.Text = (cmbCustomers.SelectedItem as cmbCustomer).Physical2.ToString();
                    txtAddress3.Text = (cmbCustomers.SelectedItem as cmbCustomer).Physical3.ToString();
                    txtSuburb.Text = (cmbCustomers.SelectedItem as cmbCustomer).Post4.ToString();
                    txtPostal.Text = (cmbCustomers.SelectedItem as cmbCustomer).PhysicalPC.ToString();
                    txtState.Text = (cmbCustomers.SelectedItem as cmbCustomer).Post5.ToString();

                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlQuery = "INSERT INTO Client () VALUES(" + id + "," + Title + " ," + Artist + "," + Country + "," + Company + "," + Price + ", " + Year + ";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
               
                connection.Open();
                int newId = command.ExecuteNonQuery();
                connection.Close();
                return newId;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
