using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web;

namespace CosmeticStore
{
    public partial class CaterogyForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OUQEPBS\SQLEXPRESS;Initial Catalog=Cosmetic_db;Integrated Security=True");
        public CaterogyForm()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "insert into Caterogy values("+cIDTb.Text+",'"+cateIDTb.Text+"','"+cateNameTb.Text+"','"+cateDesTb.Text+"')";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Caterogy added");
                conn.Close();
                populate();
                cIDTb.Text = "";
                cateIDTb.Text = "";
                cateNameTb.Text = "";
                cateDesTb.Text = "";
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            conn.Open();
            string query = "select * from Caterogy";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var data = new DataSet();
            adapter.Fill(data);
            cateGrid.DataSource = data.Tables[0];
            conn.Close();
        }
        private void CaterogyForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void cateGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cIDTb.Text = cateGrid.SelectedRows[0].Cells[0].Value.ToString();
            cateIDTb.Text = cateGrid.SelectedRows[0].Cells[1].Value.ToString();
            cateNameTb.Text = cateGrid.SelectedRows[0].Cells[2].Value.ToString();
            cateDesTb.Text = cateGrid.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if(cateIDTb.Text == "")
                {
                    MessageBox.Show("Please fill in the primary information");
                }
                else
                {
                    conn.Open();
                    string query = "delete from Caterogy where cateID = '" + cateIDTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Caterogy deleted");
                    conn.Close();
                    populate();
                    cIDTb.Text = "";
                    cateIDTb.Text = "";
                    cateNameTb.Text = "";
                    cateDesTb.Text = "";
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if(cIDTb.Text == "" || cateIDTb.Text == "" || cateNameTb.Text == "" || cateDesTb.Text == "")
                {
                    MessageBox.Show("Please fill in missing information");
                }
                else
                {
                    conn.Open();
                    string query = "update Caterogy set ID=" + cIDTb.Text + ", cateName='" + cateNameTb.Text + "', description='" + cateDesTb.Text + "' where cateID = '" + cateIDTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Caterogy updated");
                    conn.Close();
                    populate();
                    cIDTb.Text = "";
                    cateIDTb.Text = "";
                    cateNameTb.Text = "";
                    cateDesTb.Text = "";
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductForm pro = new ProductForm();
            pro.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaffForm staff = new StaffForm();
            staff.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerForm manager = new ManagerForm();
            manager.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DeliveryStaff delivery = new DeliveryStaff();
            delivery.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
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
