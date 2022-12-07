using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Data.SqlClient;

//Deneme
namespace Healty_Panda
{
    public partial class frmLogin : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=dbHealtyPanda;Integrated Security=True");
      
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void txtUserPassword_Enter(object sender, EventArgs e)
        {
            Settings.LoginWritingActive(txtUserPassword, panelUserPassword, true);
            Settings.LoginWritingActive(txtUserID, panelUserID, false);
        }

        private void txtUserID_Enter(object sender, EventArgs e)
        {
            Settings.LoginWritingActive(txtUserID, panelUserID, true);
            Settings.LoginWritingActive(txtUserPassword, panelUserPassword, false);
        }

        private void btnLogin_Enter(object sender, EventArgs e)
        {
            Settings.LoginWritingActive(txtUserPassword, panelUserPassword, false);
            Settings.LoginWritingActive(txtUserID, panelUserID, false);
        }

        private void picPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtUserPassword.UseSystemPasswordChar = false;
        }

        private void picPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtUserPassword.UseSystemPasswordChar = true;
        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact your supervisor, for now!","Password Reset");
        }

        private void picMail_MouseEnter(object sender, EventArgs e)
        {
            picMail.BackColor = Color.White;
        }

        private void picMail_MouseLeave(object sender, EventArgs e)
        {
            picMail.BackColor = Color.Gainsboro;
        }

        private void picTwitter_MouseEnter(object sender, EventArgs e)
        {
            picTwitter.BackColor = Color.White;
        }

        private void picTwitter_MouseLeave(object sender, EventArgs e)
        {
            picTwitter.BackColor = Color.Gainsboro;
        }

        private void picGithub_MouseEnter(object sender, EventArgs e)
        {
            picGithub.BackColor = Color.White;
        }

        private void picGithub_MouseLeave(object sender, EventArgs e)
        {
            picGithub.BackColor = Color.Gainsboro;
        }

        private void picLinkedin_MouseEnter(object sender, EventArgs e)
        {
            picLinkedin.BackColor = Color.White;
        }

        private void picLinkedin_MouseLeave(object sender, EventArgs e)
        {
            picLinkedin.BackColor = Color.Gainsboro;
        }

        private void picLinkedin_Click(object sender, EventArgs e)
        {
            
        }

        private void picGithub_Click(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            if (txtUserID.Text.Trim()==String.Empty || txtUserPassword.Text.Trim() == String.Empty)
            {
                lblWarning.Text = "*User account information cannot be empty!";
            }           
            else
            {
                try
                {
                    SqlCommand command = new SqlCommand("Select *From Users where ID=@userID AND Password=@userPassword", connection);
                    command.Parameters.AddWithValue("@userID", txtUserID.Text);
                    command.Parameters.AddWithValue("@userPassword", txtUserPassword.Text);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        frmMain frm = new frmMain();
                        frm.userID = Int64.Parse(txtUserID.Text);
                        this.Hide();
                        frm.ShowDialog();
                        
                    }
                    else
                    {
                        lblWarning.Text = "*Login failed! Please check your information.";
                    }                   
                }
                catch (Exception)
                {
                    lblWarning.Text = "*Please enter a valid ID!";
                }                
            }
            connection.Close();
        }
    }
}
