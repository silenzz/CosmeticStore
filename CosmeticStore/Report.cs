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
    public partial class Report : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OUQEPBS\SQLEXPRESS;Initial Catalog=Cosmetic_db;Integrated Security=True");
        public Report()
        {
            InitializeComponent();
            totalIncome();
            getNumOfTransaction();
            getIncomeDate();
            getMaxIncome();
            getMinIncome();
            getBestSeller();
            getBestProduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerForm form = new ManagerForm();
            form.Show();
            this.Hide();
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

        private void button4_Click(object sender, EventArgs e)
        {
            CaterogyForm form = new CaterogyForm();
            form.Show();
            this.Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
            this.Hide();
        }
        private void totalIncome()
        {
            conn.Open();
            string query = "select sum(InAmount) from Income";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            totalIn.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void getNumOfTransaction()
        {
            conn.Open();
            string query = "select count(*) from Income";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            number.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void getIncomeDate()
        {
            conn.Open();
            string query = "select max(InDate) from Income";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            date.Text = dt.Rows[0][0].ToString();
            last.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void getMaxIncome()
        {
            conn.Open();
            string query = "select max(InAmount) from Income";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            max.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void getMinIncome()
        {
            conn.Open();
            string query = "select min(InAmount) from Income";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            min.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void getBestSeller()
        {
            conn.Open();
            string query = "select InSeller, sum(InAmount) as sumSold from Income group by InSeller order by sum(InAmount) DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            seller.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
        private void getBestProduct()
        {
            conn.Open();
            string query = "select Name, sum(Quantity) as sold from Sold group by Name order by sum(Quantity) DESC";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            pro.Text = dt.Rows[0][0].ToString();
            conn.Close();
        }
    }
}
