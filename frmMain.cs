using Healty_Panda.Froms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healty_Panda
{

    public partial class frmMain : Form
    {
        public long userID;
        bool isShoppingCartOpen;
        static string userName = "", userSurname = "", userAuthority = "";
        Form activeForm;
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=dbHealtyPanda;Integrated Security=True");
        SqlDataReader dataReader;
        SqlCommand command;
        public frmMain()
        {
            InitializeComponent();
            this.Text = String.Empty;
            this.ControlBox = false;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            connection.Open();
            command = new SqlCommand("SELECT Name,Surname,Authority FROM Tbl_Users WHERE ID='" + userID + "'", connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                userName = dataReader["Name"].ToString();
                userSurname = dataReader["Surname"].ToString();
                btnUserID.Text = "   " + userName + " " + userSurname;
                userAuthority = dataReader["Authority"].ToString();
            }
            connection.Close();

            if (userAuthority == "Admin")
            {
                btnManagement.Visible = true;
                btnAccounting.Visible = true;
            }
            else if (userAuthority == "Authorized")
            {
                btnAccounting.Visible = true;
            }
            btnHome_Click(sender, e);
        }

        //    [DllImport{"user32.DLL", EntryPoint = "ReleaseCapture"}]
        //    private extern static void ReleaseCapture();

        //[DllImport{"user32.DLL", EntryPoint = "SendMessage"}]
        //    private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void GetForm(Form newForm) //Getting a form into panelForm
        {
            if (activeForm!=null)
            {
                activeForm.Close();
            }
            activeForm = newForm;
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            this.panelForm.Controls.Add(newForm);
            this.panelForm.Tag = newForm;
            newForm.BringToFront();
            newForm.Show();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            GetForm(new frmHome());
            Settings.SetButtonActive(btnHome);
            btnLogout.Visible = false;
        }
        private void btnAppointments_Click(object sender, EventArgs e)
        {
            GetForm(new frmAppointments());
            Settings.SetButtonActive(btnAppointments);
            btnLogout.Visible = false;
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            GetForm(new frmCustomers());
            Settings.SetButtonActive(btnCustomers);
            btnLogout.Visible = false;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            GetForm(new frmProducts());
            Settings.SetButtonActive(btnProducts);
            btnLogout.Visible = false;
        }


        private void btnUserID_Click(object sender, EventArgs e)
        {
            if (!btnLogout.Visible)
            {
                btnLogout.Visible = true;
                btnLogout.BringToFront();
            }
            else
            {
                btnLogout.Visible = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            this.Hide();
            login.Show();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnShoppingCart_Click(object sender, EventArgs e)
        {
            timerShoppingCart.Start();
        }

        private void timerShoppingCart_Tick(object sender, EventArgs e)
        {
            if (isShoppingCartOpen)
            {
                panelShoppingCart.Width -= 25;
                if (panelShoppingCart.Width == panelShoppingCart.MinimumSize.Width)
                {
                    isShoppingCartOpen = false;
                    timerShoppingCart.Stop();
                }
            }
            else
            {
                panelShoppingCart.Width += 25;
                if (panelShoppingCart.Width == panelShoppingCart.MaximumSize.Width)
                {
                    isShoppingCartOpen=true;
                    timerShoppingCart.Stop();
                }
            }

        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            GetForm(new frmManagement());
            Settings.SetButtonActive(btnManagement);
            btnLogout.Visible = false;
        }

        private void btnAccounting_Click(object sender, EventArgs e)
        {
            GetForm(new frmAccounting());
            Settings.SetButtonActive(btnAccounting);
            btnLogout.Visible = false;
        }
    }
}
