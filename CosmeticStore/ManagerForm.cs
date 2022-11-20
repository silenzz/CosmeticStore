using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmeticStore
{
    public partial class ManagerForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OUQEPBS\SQLEXPRESS;Initial Catalog=Cosmetic_db;Integrated Security=True");
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaffForm staff = new StaffForm();
            staff.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CaterogyForm caterogy = new CaterogyForm();
            caterogy.Show();
            this.Hide();
        }
        private void populate()
        {
            conn.Open();
            string query = "select * from Manager";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var data = new DataSet();
            adapter.Fill(data);
            managerGrid.DataSource = data.Tables[0];
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "insert into Manager values(" + mID.Text + ",'" + maID.Text + "','"
                    + maName.Text + "','" + maLogTb.Text + "','" + maPasswordTb.Text + "','"
                    + maEmailTb.Text + "','" + maAddTb.Text + "'," + maPhoneTb.Text + "," + maSex.Text + ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Manager added");
                conn.Close();
                populate();
                mID.Text = "";
                maID.Text = "";
                maName.Text = "";
                maLogTb.Text = "";
                maPasswordTb.Text = "";
                maEmailTb.Text = "";
                maAddTb.Text = "";
                maPhoneTb.Text = "";
                maSex.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void managerGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            mID.Text = managerGrid.SelectedRows[0].Cells[0].Value.ToString();
            maID.Text = managerGrid.SelectedRows[0].Cells[1].Value.ToString();
            maName.Text = managerGrid.SelectedRows[0].Cells[2].Value.ToString();
            maLogTb.Text = managerGrid.SelectedRows[0].Cells[3].Value.ToString();
            maPasswordTb.Text = managerGrid.SelectedRows[0].Cells[4].Value.ToString();
            maEmailTb.Text = managerGrid.SelectedRows[0].Cells[5].Value.ToString();
            maAddTb.Text = managerGrid.SelectedRows[0].Cells[6].Value.ToString();
            maPhoneTb.Text = managerGrid.SelectedRows[0].Cells[7].Value.ToString();
            maSex.Text = managerGrid.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (maID.Text == "")
                {
                    MessageBox.Show("Please fill in the primary information");
                }
                else
                {
                    conn.Open();
                    string query = "delete from Manager where ManagerID = '" + maID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manager deleted");
                    conn.Close();
                    populate();
                    mID.Text = "";
                    maID.Text = "";
                    maName.Text = "";
                    maLogTb.Text = "";
                    maPasswordTb.Text = "";
                    maEmailTb.Text = "";
                    maAddTb.Text = "";
                    maPhoneTb.Text = "";
                    maSex.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (mID.Text == "" || maID.Text == "" || maName.Text == "" || maLogTb.Text == ""
                    || maPasswordTb.Text == "" || maEmailTb.Text == "" || maAddTb.Text == ""
                    || maPhoneTb.Text == "" || maSex.Text == "")
                {
                    MessageBox.Show("Please fill in the primary information");
                }
                else
                {
                    conn.Open();
                    string query = "update Manager set ID = " + mID.Text + ", ManagerName = '"
                        + maName.Text + "', ManagerLoginID = '" + maLogTb.Text + "', ManagerPassword = '" + maPasswordTb.Text + "', ManagerEmail = '"
                        + maEmailTb.Text + "', ManagerAddress = '" + maAddTb.Text + "', ManagerPhone = "
                        + maPhoneTb.Text + ", ManagerGender = " + maSex.Text + " where ManagerID = '" + maID.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manager updated");
                    conn.Close();
                    populate();
                    mID.Text = "";
                    maID.Text = "";
                    maName.Text = "";
                    maLogTb.Text = "";
                    maPasswordTb.Text = "";
                    maEmailTb.Text = "";
                    maAddTb.Text = "";
                    maPhoneTb.Text = "";
                    maSex.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DeliveryStaff delivery = new DeliveryStaff();
            delivery.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
            this.Hide();
        }
    }
}
