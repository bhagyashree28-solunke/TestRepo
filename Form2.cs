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

namespace ShopBridgeApplication
{
    public partial class Form2 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-NBDOPGO\SQLEXPRESS;Initial Catalog=ShopBridge;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        SqlDataReader dr;
        public Form2()
        {
            InitializeComponent();
        }
        private void GetProduct()
        {
            cmd = new SqlCommand("Usp_GetProduct", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", cmbProdName.Text);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void cmbProdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProduct();
        }
    }
}
