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
    public partial class Form1 : Form
    {
        public static string staffName = "";
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OUQEPBS\SQLEXPRESS;Initial Catalog=Cosmetic_db;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                if(roleCb.SelectedIndex > -1)
                {
                    if (uNameTb.Text == "" || passTb.Text == "")
                    {
                        MessageBox.Show("Please fill your username or password");
                    }
                    else
                    {
                        if (roleCb.SelectedIndex == 0)
                        {
                            if (ownerAuthenication())
                            {
                                staffName = uNameTb.Text;
                                ProductForm product = new ProductForm();
                                product.Show();
                                this.Hide();
                            }
                            else MessageBox.Show("Wrong username or password");
                        }
                        else if(roleCb.SelectedIndex == 1)
                        {
                            if(managerAuthenication())
                            {
                                staffName = uNameTb.Text;
                                Revenue revenue = new Revenue();
                                revenue.Show();
                                this.Hide();
                            }
                            else MessageBox.Show("Wrong username or password");
                        }
                        else if(roleCb.SelectedIndex == 2)
                        {
                            if(StaffAuthenication())
                            {
                                staffName = uNameTb.Text;
                                SellingForm selling = new SellingForm();
                                selling.Show();
                                this.Hide();
                            }
                            else MessageBox.Show("Wrong username or password");
                        }
                        else if(roleCb.SelectedIndex == 3)
                        {
                            if(DeliveryAuthenication())
                            {
                                MessageBox.Show("Enter delivery section");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a role for login");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            uNameTb.Clear();
            passTb.Clear();
        }
        public Boolean ownerAuthenication()
        {
            Boolean result = false;
            conn.Open();
            String qr = String.Format("Select count(*) from Owner where OwnerLoginID = '" + uNameTb.Text + "' and OwnerPassword = '" + passTb.Text + "'");
            SqlCommand cmd = new SqlCommand(qr, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if (reader[0].ToString() == "1")
                {
                    result = true;
                }
            }
            conn.Close();
            return result;
        }
        public Boolean managerAuthenication()
        {
            Boolean result = false;
            conn.Open();
            String qr = String.Format("Select count(*) from Manager where ManagerLoginID = '" + uNameTb.Text + "' and ManagerPassword = '" + passTb.Text + "'");
            SqlCommand cmd = new SqlCommand(qr, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString() == "1")
                {
                    result = true;
                }
            }
            conn.Close();
            return result;
        }
        public Boolean StaffAuthenication()
        {
            Boolean result = false;
            conn.Open();
            String qr = String.Format("Select count(*) from Staff where StaffLoginID = '" + uNameTb.Text + "' and StaffPassword = '" + passTb.Text + "'");
            SqlCommand cmd = new SqlCommand(qr, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString() == "1")
                {
                    result = true;
                }
            }
            conn.Close();
            return result;
        }
        public Boolean DeliveryAuthenication()
        {
            Boolean result = false;
            conn.Open();
            String qr = String.Format("Select count(*) from DelStaff where DelLoginID = '" + uNameTb.Text + "' and DelPassword = '" + passTb.Text + "'");
            SqlCommand cmd = new SqlCommand(qr, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString() == "1")
                {
                    result = true;
                }
            }
            conn.Close();
            return result;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
