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

namespace CosmeticStore
{
    public partial class StaffForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OUQEPBS\SQLEXPRESS;Initial Catalog=Cosmetic_db;Integrated Security=True");
        public StaffForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductForm product = new ProductForm();
            product.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CaterogyForm caterogyForm = new CaterogyForm();
            caterogyForm.Show();
            this.Hide();
        }
        private void populate()
        {
            conn.Close();
            conn.Open();
            string query = "select * from Staff";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var data = new DataSet();
            adapter.Fill(data);
            staffGrid.DataSource = data.Tables[0];
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (sIDTb.Text == "" || staffIDTb.Text == "" || staffNameTb.Text == "" || staffLogTb.Text == ""
                    || staffPasswordTb.Text == "" || staffEmailTb.Text == "" || staffAddTb.Text == ""
                    || staffPhoneTb.Text == "" || staffSex.Text == "")
                {
                    MessageBox.Show("Please fill in the primary information");
                }
                else
                {
                    conn.Open();
                    string query = "insert into Staff values(" + sIDTb.Text + ",'" + staffIDTb.Text + "','"
                        + staffNameTb.Text + "','" + staffLogTb.Text + "','" + staffPasswordTb.Text + "','"
                        + staffEmailTb.Text + "','" + staffAddTb.Text + "'," + staffPhoneTb.Text + "," + staffSex.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff added");
                    conn.Close();
                    populate();
                    sIDTb.Text = "";
                    staffIDTb.Text = "";
                    staffNameTb.Text = "";
                    staffLogTb.Text = "";
                    staffPasswordTb.Text = "";
                    staffEmailTb.Text = "";
                    staffAddTb.Text = "";
                    staffPhoneTb.Text = "";
                    staffSex.Text = "";
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void StaffForm_Load(object sender, EventArgs e)
        {
            populate();
            if(Form1.staffName != "admin")
            {
                this.button2.Enabled = false;
                this.button4.Enabled = false;
                this.button10.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            populate();
        }

        private void staffGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sIDTb.Text = staffGrid.SelectedRows[0].Cells[0].Value.ToString();
            staffIDTb.Text = staffGrid.SelectedRows[0].Cells[1].Value.ToString();
            staffNameTb.Text = staffGrid.SelectedRows[0].Cells[2].Value.ToString();
            staffLogTb.Text = staffGrid.SelectedRows[0].Cells[3].Value.ToString();
            staffPasswordTb.Text = staffGrid.SelectedRows[0].Cells[4].Value.ToString();
            staffEmailTb.Text = staffGrid.SelectedRows[0].Cells[5].Value.ToString();
            staffAddTb.Text = staffGrid.SelectedRows[0].Cells[6].Value.ToString();
            staffPhoneTb.Text = staffGrid.SelectedRows[0].Cells[7].Value.ToString();
            staffSex.Text = staffGrid.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDTb.Text == "")
                {
                    MessageBox.Show("Please fill in the primary information");
                }
                else
                {
                    conn.Open();
                    string query = "delete from Staff where StaffID = '" + staffIDTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff deleted");
                    conn.Close();
                    populate();
                    sIDTb.Text = "";
                    staffIDTb.Text = "";
                    staffNameTb.Text = "";
                    staffLogTb.Text = "";
                    staffPasswordTb.Text = "";
                    staffEmailTb.Text = "";
                    staffAddTb.Text = "";
                    staffPhoneTb.Text = "";
                    staffSex.Text = "";
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
                if(sIDTb.Text == "" || staffIDTb.Text == "" || staffNameTb.Text == "" || staffLogTb.Text == ""
                    || staffPasswordTb.Text == "" || staffEmailTb.Text == "" || staffAddTb.Text == ""
                    || staffPhoneTb.Text == "" || staffSex.Text == "")
                {
                    MessageBox.Show("Please fill in the primary information");
                }
                else
                {
                    conn.Open();
                    string query = "update Staff set ID = " + sIDTb.Text + ", StaffName = '"
                        + staffNameTb.Text + "', StaffLoginID = '" + staffLogTb.Text + "', StaffPassword = '" + staffPasswordTb.Text + "', StaffEmail = '"
                        + staffEmailTb.Text + "', StaffAddress = '" + staffAddTb.Text + "', StaffPhone = "
                        + staffPhoneTb.Text + ", StaffGender = " + staffSex.Text + " where StaffID = '" + staffIDTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff updated");
                    conn.Close();
                    populate();
                    sIDTb.Text = "";
                    staffIDTb.Text = "";
                    staffNameTb.Text = "";
                    staffLogTb.Text = "";
                    staffPasswordTb.Text = "";
                    staffEmailTb.Text = "";
                    staffAddTb.Text = "";
                    staffPhoneTb.Text = "";
                    staffSex.Text = "";
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerForm form = new ManagerForm();
            form.Show();
            this.Hide();
        }
        private void label11_Click(object sender, EventArgs e)
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
