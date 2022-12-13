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
    public partial class ChangePassword : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OUQEPBS\SQLEXPRESS;Initial Catalog=Cosmetic_db;Integrated Security=True");
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (newTb.Text == confirmTb.Text && (recentTb.Text != "" || newTb.Text != "" || confirmTb.Text != ""))
                {
                    if(checkPassword())
                    {
                        conn.Open();
                        string query = "update Staff set StaffPassword = '" + confirmTb.Text + "' where StaffPassword = '" + recentTb.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password has been changed");
                        conn.Close();
                        recentTb.Text = "";
                        newTb.Text = "";
                        confirmTb.Text = "";
                        Form1 form = new Form1();
                        form.Show();
                        this.Hide();
                    }
                }
                else MessageBox.Show("Please fill up the information");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private Boolean checkPassword()
        {
            Boolean result = false;
            conn.Open();
            String query = String.Format("Select count(*) from Staff where StaffPassword = '" + recentTb.Text + "'");
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if (reader[0].ToString().Equals("1"))
                {
                    result = true;
                }
            }
            conn.Close();
            return result;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SellingForm form = new SellingForm();
            form.Show();
            this.Hide();
        }
    }
}
