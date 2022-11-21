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
    public partial class SellingForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OUQEPBS\SQLEXPRESS;Initial Catalog=Cosmetic_db;Integrated Security=True");
        
        public SellingForm()
        {
            InitializeComponent();
        }

        private void SellingForm_Load(object sender, EventArgs e)
        {
            populate();
            populdateBill();
            fillComboBox();
            staffName.Text = Form1.staffName;
        }
        private void populate()
        {
            conn.Close();
            conn.Open();
            string query = "select CosName, CosPrice from Product";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var data = new DataSet();
            adapter.Fill(data);
            proDG.DataSource = data.Tables[0];
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void proDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sellName.Text = proDG.SelectedRows[0].Cells[0].Value.ToString();
            sellPrice.Text = proDG.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            date.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }
        int n = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if(sellQuan.Text == "")
            {
                MessageBox.Show("Please fill your quantities");
            }
            else
            {
                int view_total = 0;

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(orderDG);
                row.Cells[0].Value = n + 1;
                row.Cells[1].Value = sellName.Text;
                row.Cells[2].Value = sellPrice.Text;
                row.Cells[3].Value = sellQuan.Text;
                row.Cells[4].Value = Convert.ToInt32(sellPrice.Text) * Convert.ToInt32(sellQuan.Text);
                orderDG.Rows.Add(row);
                n++;
                for (int i = 0; i < orderDG.Rows.Count; ++i)
                {
                    view_total += Convert.ToInt32(orderDG.Rows[i].Cells[4].Value);
                }
                amount.Text = view_total.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(sellID.Text == "" || cusTB.Text == "")
            {
                MessageBox.Show("Please enter the bill identity");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into Bill values(" + sellID.Text + ",'" + staffName.Text + "','" + cusTB.Text + "','" + date.Text + "'," + amount.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill added");
                    conn.Close();
                    populdateBill();
                    sellID.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void button7_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void billDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sellID.Text = billDG.SelectedRows[0].Cells[0].Value.ToString();
        }
        int sId, sPrice, sQuantity, sTotal, position = 190;
        string sName;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Cosmetic store receipt", new Font("Century Gothic", 36, FontStyle.Bold), Brushes.SteelBlue, new Point(150));
            e.Graphics.DrawString("Bill ID: " + billDG.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Regular), Brushes.SteelBlue, new Point(100, 70));
            e.Graphics.DrawString("Staff name: " + billDG.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Regular), Brushes.SteelBlue, new Point(100, 100));
            e.Graphics.DrawString("" + billDG.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Regular), Brushes.SteelBlue, new Point(100, 130));
            e.Graphics.DrawString("ID", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.SteelBlue, new Point(100, 160));
            e.Graphics.DrawString("Name", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.SteelBlue, new Point(150, 160));
            e.Graphics.DrawString("Price", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.SteelBlue, new Point(400, 160));
            e.Graphics.DrawString("Quantity", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.SteelBlue, new Point(550, 160));
            e.Graphics.DrawString("Total", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.SteelBlue, new Point(700, 160));
            foreach (DataGridViewRow row in orderDG.Rows)
            {
                sId = Convert.ToInt32(row.Cells[0].Value);
                sName = "" + row.Cells[1].Value;
                sPrice = Convert.ToInt32(row.Cells[2].Value);
                sQuantity = Convert.ToInt32(row.Cells[3].Value);
                sTotal = Convert.ToInt32(row.Cells [4].Value);
                e.Graphics.DrawString("" + sId, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(100, position));
                e.Graphics.DrawString("" + sName, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(150, position));
                e.Graphics.DrawString("" + sPrice, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(400, position));
                e.Graphics.DrawString("" + sQuantity, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(550, position));
                e.Graphics.DrawString("" + sTotal, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Black, new Point(700, position));
                position += 30;
            }
            e.Graphics.DrawString("Total pay: " + billDG.SelectedRows[0].Cells[4].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Regular), Brushes.SteelBlue, new Point(100, 280));
            e.Graphics.DrawString("Payment_method: Credit_card/Cash", new Font("Century Gothic", 20, FontStyle.Regular), Brushes.SteelBlue, new Point(100, 310));
            e.Graphics.DrawString("Date: " + billDG.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Regular), Brushes.SteelBlue, new Point(100, 340));
            e.Graphics.DrawString("*********CosmeticQueen*********", new Font("Century Gothic", 25, FontStyle.Italic), Brushes.SteelBlue, new Point(150, 370));
            e.Graphics.DrawString("Thanks for using our services", new Font("Century Gothic", 25, FontStyle.Italic), Brushes.SteelBlue, new Point(200, 400));
            orderDG.Rows.Clear();
            orderDG.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (sellID.Text == "")
                {
                    MessageBox.Show("Please fill in the primary information");
                }
                else
                {
                    conn.Open();
                    string query = "delete from Bill where BillID = " + sellID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill deleted");
                    conn.Close();
                    populdateBill();
                    sellID.Text = "";
                    sellName.Text = "";
                    sellPrice.Text = "";
                    sellQuan.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void typeCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            conn.Open();
            string query = "select CosName, CosPrice from Product where CosType = '" + typeCb.SelectedValue.ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            proDG.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void fillComboBox()
        {
            conn.Open();
            string query = "select cateName from Caterogy";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("cateName", typeof(string));
            dt.Load(reader);
            typeCb.ValueMember = "cateName";
            typeCb.DataSource = dt;
            conn.Close();
            if(typeCb.Items.Count > 1)
            {
                typeCb.SelectedIndex = -1;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void cPass_Click(object sender, EventArgs e)
        {
            ChangePassword cb = new ChangePassword();
            cb.Show();
            this.Hide();
        }
    }
}
