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

namespace MarketTIcketingSystem.User_Interface
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public void validation()
        {
            if (!(textBoxUsername.Text == string.Empty))
            {
                if (!(textBoxPassword.Text == string.Empty))
                {
                    using (SqlConnection connection = new SqlConnection(Helper.Helper.ConnectionString))
                    {
                        const string query = "Select * from HrEmployee where UserName =@username And Password =@password";
                        using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar));
                            sqlCommand.Parameters["@username"].Value = textBoxUsername.Text;
                            sqlCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar));
                            sqlCommand.Parameters["@password"].Value = textBoxPassword.Text;
                            try
                            {
                                connection.Open();
                                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                                {
                                    int count = 0;
                                    while (dataReader.Read())
                                    {
                                        count = count + 1;
                                    }
                                    if (count == 1)
                                    {
                                        MessageBox.Show("Login Successful !");
                                        DashBoard dashBoard = new DashBoard();
                                        dashBoard.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Username or Password Incorrect !");
                                    }
                                    dataReader.Close();
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password Empty !");
                }
            }
            else
            {
                MessageBox.Show("Username Empty");
            }

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            validation();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
