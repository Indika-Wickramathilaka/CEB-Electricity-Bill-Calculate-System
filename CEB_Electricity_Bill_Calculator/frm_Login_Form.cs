using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEB_Electricity_Bill_Calculator
{
    public partial class frm_Login_Form : Form
    {
        public frm_Login_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "CEB ElectricityBill Calculator", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (iExit == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin" && txtPassword.Text == "123456")
            {
                Dashboard hp = new Dashboard();
                hp.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Incorrect User Name or Passwword", "CEB Electricity Bill App", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtUserName.Select();

            }
        }

        private void frm_Login_Form_Load(object sender, EventArgs e)
        {
            txtUserName.Select();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Select();
            }

        }
    }
}
