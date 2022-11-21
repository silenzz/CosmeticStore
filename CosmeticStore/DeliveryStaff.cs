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
    public partial class DeliveryStaff : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OUQEPBS\SQLEXPRESS;Initial Catalog=Cosmetic_db;Integrated Security=True");
        public DeliveryStaff()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerForm manager = new ManagerForm();
            manager.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Form1.staffName != "admin")
            {
                Revenue revenue = new Revenue();
                revenue.Show();
                this.Hide();
            }
            else Application.Exit();
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
            conn.Close();
            conn.Open();
            string query = "select * from DelStaff";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var data = new DataSet();
            adapter.Fill(data);
            delGrid.DataSource = data.Tables[0];
            conn.Close();
        }

        private void delGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dID.Text = delGrid.SelectedRows[0].Cells[0].Value.ToString();
            delIDTb.Text = delGrid.SelectedRows[0].Cells[1].Value.ToString();
            delNameTb.Text = delGrid.SelectedRows[0].Cells[2].Value.ToString();
            delLogTb.Text = delGrid.SelectedRows[0].Cells[3].Value.ToString();
            delPasswordTb.Text = delGrid.SelectedRows[0].Cells[4].Value.ToString();
            delEmailTb.Text = delGrid.SelectedRows[0].Cells[5].Value.ToString();
            delAddTb.Text = delGrid.SelectedRows[0].Cells[6].Value.ToString();
            delPhoneTb.Text = delGrid.SelectedRows[0].Cells[7].Value.ToString();
            delSex.Text = delGrid.SelectedRows[0].Cells[8].Value.ToString();
            delVehicle.Text = delGrid.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "insert into DelStaff values(" + dID.Text + ",'" + delIDTb.Text + "','"
                    + delNameTb.Text + "','" + delLogTb.Text + "','" + delPasswordTb.Text + "','"
                    + delEmailTb.Text + "','" + delAddTb.Text + "'," + delPhoneTb.Text + "," + delSex.Text + "," + delVehicle.Text + ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delivery staff added");
                conn.Close();
                populate();
                dID.Text = "";
                delIDTb.Text = "";
                delNameTb.Text = "";
                delLogTb.Text = "";
                delPasswordTb.Text = "";
                delEmailTb.Text = "";
                delAddTb.Text = "";
                delPhoneTb.Text = "";
                delSex.Text = "";
                delVehicle.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeliveryStaff_Load(object sender, EventArgs e)
        {
            populate();
            if(Form1.staffName != "admin")
            {
                this.button2.Enabled = false;
                this.button4.Enabled = false;
                this.button10.Enabled = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (delIDTb.Text == "")
                {
                    MessageBox.Show("Please fill in the primary information");
                }
                else
                {
                    conn.Open();
                    string query = "delete from DelStaff where DelID = '" + delIDTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delivery staff deleted");
                    conn.Close();
                    populate();
                    dID.Text = "";
                    delIDTb.Text = "";
                    delNameTb.Text = "";
                    delLogTb.Text = "";
                    delPasswordTb.Text = "";
                    delEmailTb.Text = "";
                    delAddTb.Text = "";
                    delPhoneTb.Text = "";
                    delSex.Text = "";
                    delVehicle.Text = "";
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
                if (dID.Text == "" || delIDTb.Text == "" || delNameTb.Text == "" || delLogTb.Text == ""
                    || delPasswordTb.Text == "" || delEmailTb.Text == "" || delAddTb.Text == ""
                    || delPhoneTb.Text == "" || delSex.Text == "" || delVehicle.Text == "")
                {
                    MessageBox.Show("Please fill in the primary information");
                }
                else
                {
                    conn.Open();
                    string query = "update DelStaff set ID = " + dID.Text + ", DelName = '"
                        + delNameTb.Text + "', DelLoginID = '" + delLogTb.Text + "', DelPassword = '" + delPasswordTb.Text + "', DelEmail = '"
                        + delEmailTb.Text + "', DelAddress = '" + delAddTb.Text + "', DelPhone = "
                        + delPhoneTb.Text + ", DelGender = " + delSex.Text + ", VehicleNo = " + delVehicle.Text + "where DelID = '" + delIDTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delivery staff updated");
                    conn.Close();
                    populate();
                    dID.Text = "";
                    delIDTb.Text = "";
                    delNameTb.Text = "";
                    delLogTb.Text = "";
                    delPasswordTb.Text = "";
                    delEmailTb.Text = "";
                    delAddTb.Text = "";
                    delPhoneTb.Text = "";
                    delSex.Text = "";
                    delVehicle.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
