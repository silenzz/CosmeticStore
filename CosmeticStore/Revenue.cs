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

namespace CosmeticStore
{
    public partial class Revenue : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OUQEPBS\SQLEXPRESS;Initial Catalog=Cosmetic_db;Integrated Security=True");
        public Revenue()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaffForm form = new StaffForm();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            form.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DeliveryStaff deliveryStaff = new DeliveryStaff();
            deliveryStaff.Show();
            this.Hide();
        }
        private void Revenue_Load(object sender, EventArgs e)
        {
            populdateBill();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "insert into Income values(" + inID.Text + "," + inAmt.Text + ",'" + inSeller.Text + "','" + inDate.Value.Date + "','" +  inNote.Text + "','" + Form1.staffName +  "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Income added");
                conn.Close();
                inID.Text = "";
                inAmt.Text = "";
                inSeller.Text = "";
                inNote.Text = "";
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void populdateBill()
        {
            conn.Close();
            conn.Open();
            string query = "select * from Bill";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var data = new DataSet();
            adapter.Fill(data);
            billDG.DataSource = data.Tables[0];
            conn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
            this.Hide();
        }
    }
}
