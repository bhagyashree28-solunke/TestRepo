using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace ShopBridgeApplication
{
    public partial class Form1 : Form
    {
       SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-NBDOPGO\SQLEXPRESS;Initial Catalog=ShopBridge;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Usp_InsertProd", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName",txtProdName);
            cmd.Parameters.AddWithValue("@ProductDescription", txtDescription);
            cmd.Parameters.AddWithValue("@ProductPrice", txtPrice);
            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record inserted successfully.", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Usp_UpdateProd", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", txtProdName);
            cmd.Parameters.AddWithValue("@ProductDescription", txtDescription);
            cmd.Parameters.AddWithValue("@ProductPrice", txtPrice);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record update successfully.", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Usp_DeleteProd", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", txtProdName);
            cmd.Parameters.AddWithValue("@ProductDescription", txtDescription);
            cmd.Parameters.AddWithValue("@ProductPrice", txtPrice);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Delete successfully.", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
