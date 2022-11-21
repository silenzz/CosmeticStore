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
    public partial class ProductForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OUQEPBS\SQLEXPRESS;Initial Catalog=Cosmetic_db;Integrated Security=True");
        public ProductForm()
        {
            InitializeComponent();
        }
        private void fillComboBox()
        {
            conn.Open();
            string query = "select cateName from Caterogy";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("cateName",typeof(string));
            dt.Load(reader);
            typeCb.ValueMember = "cateName";
            typeCb.DataSource = dt;
            typeCb2.ValueMember = "cateName";
            typeCb2.DataSource = dt;
            conn.Close();
            if(typeCb2.Items.Count > 1)
            {
                typeCb2.SelectedIndex = -1;
            }
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            populate();
            fillComboBox();
            if(Form1.staffName != "admin")
            {
                this.button2.Enabled = false;
                this.button4.Enabled = false;
                this.button11.Enabled = false;
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

        private void button4_Click(object sender, EventArgs e)
        {
            CaterogyForm cate = new CaterogyForm();
            cate.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "insert into Product values(" + pIDTb.Text + ",'" + skuTB.Text + "','" + proNameTb.Text + "','" + proComTb.Text + "',"+proPriceTb.Text+",'"+proDateTb.Text+"',"+proQuanTb.Text+",'"+typeCb.SelectedValue.ToString()+"','"+proUnitTb.Text+"')";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product added");
                conn.Close();
                populate();
                pIDTb.Text = "";
                skuTB.Text = "";
                proNameTb.Text = "";
                proComTb.Text = "";
                proPriceTb.Text = "";
                proDateTb.Text = "";
                proQuanTb.Text = "";
                typeCb.SelectedIndex = -1;
                proUnitTb.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void populate()
        {
            conn.Close();
            conn.Open();
            string query = "select * from Product";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var data = new DataSet();
            adapter.Fill(data);
            proGrid.DataSource = data.Tables[0];
            conn.Close();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (skuTB.Text == "")
                {
                    MessageBox.Show("Please fill in the primary information");
                }
                else
                {
                    conn.Open();
                    string query = "delete from Product where cosSKU = '" + skuTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product deleted");
                    conn.Close();
                    populate();
                    pIDTb.Text = "";
                    skuTB.Text = "";
                    proNameTb.Text = "";
                    proComTb.Text = "";
                    proPriceTb.Text = "";
                    proDateTb.Text = "";
                    proQuanTb.Text = "";
                    typeCb.SelectedIndex = -1;
                    proUnitTb.Text = "";
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void proGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pIDTb.Text = proGrid.SelectedRows[0].Cells[0].Value.ToString();
            skuTB.Text = proGrid.SelectedRows[0].Cells[1].Value.ToString();
            proNameTb.Text = proGrid.SelectedRows[0].Cells[2].Value.ToString();
            proComTb.Text = proGrid.SelectedRows[0].Cells[3].Value.ToString();
            proPriceTb.Text = proGrid.SelectedRows[0].Cells[4].Value.ToString();
            proDateTb.Text = proGrid.SelectedRows[0].Cells[5].Value.ToString();
            proQuanTb.Text = proGrid.SelectedRows[0].Cells[6].Value.ToString();
            typeCb.SelectedValue = proGrid.SelectedRows[0].Cells[7].Value.ToString();
            proUnitTb.Text = proGrid.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (pIDTb.Text == "" || skuTB.Text == "" || proNameTb.Text == "" || proComTb.Text == ""
                    || proPriceTb.Text == "" || proDateTb.Text == "" || proQuanTb.Text == ""
                    || typeCb.SelectedValue.ToString() == "" || proUnitTb.Text == "")
                {
                    MessageBox.Show("Please fill in missing information");
                }
                else
                {
                    conn.Open();
                    string query = "update Product set CosID=" + pIDTb.Text + ", CosName='" + proNameTb.Text + "', " +
                        "CosCom='" + proComTb.Text + "', CosPrice = " + proPriceTb.Text + ", CosExpiriedDate = '" + proDateTb.Text + 
                        "', CosQuantity = " + proQuanTb.Text + ", CosType = '" + typeCb.SelectedValue.ToString() + "',"
                        + "CosUnit = '" + proUnitTb.Text + "' where CosSKU = '" + skuTB.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product updated");
                    conn.Close();
                    populate();
                    pIDTb.Text = "";
                    skuTB.Text = "";
                    proNameTb.Text = "";
                    proComTb.Text = "";
                    proPriceTb.Text = "";
                    proDateTb.Text = "";
                    proQuanTb.Text = "";
                    typeCb.SelectedIndex = -1;
                    proUnitTb.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        private void typeCb2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select * from Product where CosType = '" + typeCb.SelectedValue.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            proGrid.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
            this.Hide();
        }
    }
}
