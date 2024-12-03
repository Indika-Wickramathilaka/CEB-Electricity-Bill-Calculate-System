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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void customDesign()
        {
            pnlSubMenu.Visible = false;
            pnl_Dom_Sub.Visible = false;
            pnlSubMenu2.Visible = false;
        
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            customDesign();
        }


        private void hideMenu()
        {
            if (pnlSubMenu.Visible == true)
            {

            pnlSubMenu.Visible = false;
            }
        }

        private void showMenu(Panel showMenu)
        {
            if (showMenu.Visible == false) 
            {
                hideMenu();
                showMenu.Visible = true;
            }
                else
            {
                pnlSubMenu.Visible = false;
            }

           
            
        }


        private void showSubMenu(Panel subMenuShow)
        {
            if (subMenuShow.Visible == false)
            {
                hideSubMenu();
                subMenuShow.Visible = true;
            }

            else
            {
                subMenuShow.Visible = false;
            }

            
        }

        private void hideSubMenu()
        {
            if (pnl_Dom_Sub.Visible == true)
            { 
             pnl_Dom_Sub.Visible = false;

            }
        }

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        { 
        
            if(activeForm!=null)
            {
                activeForm.Close();
            }
            
            activeForm=childForm;
            childForm.TopLevel=false;
            childForm.FormBorderStyle= FormBorderStyle.None;
            childForm.Dock=DockStyle.Fill;
            pnlRight.Controls.Add(childForm);
            pnlRight.Tag=childForm;
            childForm.BringToFront();
            childForm.Show();
            childForm.BackColor = Color.FromArgb(75, 75, 75);
        
        }

       

        private void btnBillCalculator_Click(object sender, EventArgs e)
        {

            showMenu(pnlSubMenu);

        }

        private void btn_Dom_Cat_1_Click(object sender, EventArgs e)
        {
            showSubMenu(pnl_Dom_Sub);

        }

        private void btn_Ind_Cat_i_1_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_Ind_Cat_I1());
        }

        private void btn_General_Cat_Gp_1_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_Gen_Cat_Gp_1());
        }

        private void btn_Hot_Cat_1_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_Hot_Cat_H1());
        }

        private void btn_Gov_Gv_1_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_Gov_Cat_Gv1());
        }

        private void btn_Cal_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_Dom_Cal());
        }

        private void btn_BillRate_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_Dom_Bill_Rate());
        }

        private void btn_Rel_Cat_R_1_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_Rel_Cat_R1());
        }



        private void showSubMenu2(Panel subMenu2)
        {
            //pnlSubMenu2.Visible = true;

            if (subMenu2.Visible == false)
            {
                hideSubMenu2();
                subMenu2.Visible = true;
            }

            else
            {
                subMenu2.Visible = false;
            }
        }

        private void hideSubMenu2()
        {
            if (pnlSubMenu2.Visible == true)
            {
                pnlSubMenu2.Visible = false;
            }

            
        }

        private void btnUserRegistration_Click(object sender, EventArgs e)
        {
            showSubMenu2(pnlSubMenu2);
        }

        private void btn_Ind_User_Reg_Click(object sender, EventArgs e)
        {
            openChildForm(new frm_New_User_Registration());
        }



    }
}
