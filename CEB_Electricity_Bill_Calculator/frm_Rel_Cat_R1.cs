using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CEB_Electricity_Bill_Calculator
{
    public partial class frm_Rel_Cat_R1 : Form
    {
        double charge_Energy_0_30 = 8.00;
        double charge_Energy_31_90 = 15.00;
        double charge_Energy_91_120 = 20.00;
        double charge_Energy_121_180 = 30.00;
        double above_Energy_180 = 65.00;

        double fixed_Charge_0_30 = 90.00;
        double fixed_Charge_31_90 = 120.00;
        double fixed_Charge_91_120 = 120.00;
        double fixed_Charge_121_180 = 450.00;
        double fixed_Charge_Above_180 = 1500.00;

        double charge_0_30;
        double charge_31_90;
        double charge_91_120;
        double charge_121_180;
        double above_180;


        public frm_Rel_Cat_R1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string temp = txtUnit.Text;
            int value;

            if (int.TryParse(temp, out value))
            {

                int unitConsumed = int.Parse(txtUnit.Text);

                if (unitConsumed >= 0 && unitConsumed <= 30)
                {
                    charge_0_30 = unitConsumed * charge_Energy_0_30;

                    lbl_1.Text = charge_0_30.ToString("c");
                    lbl_2.Text = "Rs.0.00";
                    lbl_3.Text = "Rs.0.00";
                    lbl_4.Text = "Rs.0.00";
                    lbl_5.Text = "Rs.0.00";
                    lbl_6.Text = fixed_Charge_0_30.ToString("c");
                    lbl_7.Text = (charge_0_30 + fixed_Charge_0_30).ToString("c");

                    pnl_Result.Visible = true;
                }

                else if (unitConsumed >= 31 && unitConsumed <= 90)
                {

                    charge_0_30 = 30 * charge_Energy_0_30;
                    charge_31_90 = (unitConsumed - 30) * charge_Energy_31_90;

                    lbl_1.Text = charge_0_30.ToString("c");
                    lbl_2.Text = charge_31_90.ToString("c");
                    lbl_3.Text = "Rs.0.00";
                    lbl_4.Text = "Rs.0.00";
                    lbl_5.Text = "Rs.0.00";
                    lbl_6.Text = fixed_Charge_31_90.ToString("c");
                    lbl_7.Text = ((charge_0_30 + charge_31_90) + fixed_Charge_31_90).ToString("c");

                    pnl_Result.Visible = true;
                }


                else if (unitConsumed >= 91 && unitConsumed <= 120)
                {

                    charge_0_30 = 30 * charge_Energy_0_30;
                    charge_31_90 = 60 * charge_Energy_31_90;
                    charge_91_120 = (unitConsumed - 90) * charge_Energy_91_120;

                    lbl_1.Text = charge_0_30.ToString("c");
                    lbl_2.Text = charge_31_90.ToString("c");
                    lbl_3.Text = charge_91_120.ToString("c");
                    lbl_4.Text = "Rs.0.00";
                    lbl_5.Text = "Rs.0.00";
                    lbl_6.Text = fixed_Charge_91_120.ToString("c");
                    lbl_7.Text = (((charge_0_30 + charge_31_90) + charge_91_120) + fixed_Charge_91_120).ToString("c");

                    pnl_Result.Visible = true;
                }

                else if (unitConsumed >= 121 && unitConsumed <= 180)
                {
                    
                    charge_0_30 = 30 * charge_Energy_0_30;
                    charge_31_90 = 60 * charge_Energy_31_90;
                    charge_91_120 = 30 * charge_Energy_91_120;
                    charge_121_180 = (unitConsumed - 120) * charge_Energy_121_180;

                    lbl_1.Text = charge_0_30.ToString("c");
                    lbl_2.Text = charge_31_90.ToString("c");
                    lbl_3.Text = charge_91_120.ToString("c");
                    lbl_4.Text = charge_121_180.ToString("c");
                    lbl_5.Text = "Rs.0.00";
                    lbl_6.Text = fixed_Charge_121_180.ToString("c");
                    lbl_7.Text = ((((charge_0_30 + charge_31_90) + charge_91_120) + charge_121_180) + fixed_Charge_121_180).ToString("c");

                    pnl_Result.Visible = true;
                }

                else if (unitConsumed > 180)
                {
                    charge_0_30 = 30 * charge_Energy_0_30;
                    charge_31_90 = 60 * charge_Energy_31_90;
                    charge_91_120 = 30 * charge_Energy_91_120;
                    charge_121_180 = 60 * charge_Energy_121_180;
                    above_180 = (unitConsumed - 180) * above_Energy_180;

                    lbl_1.Text = charge_0_30.ToString("c");
                    lbl_2.Text = charge_31_90.ToString("c");
                    lbl_3.Text = charge_91_120.ToString("c");
                    lbl_4.Text = charge_121_180.ToString("c");
                    lbl_5.Text = above_180.ToString("c");
                    lbl_6.Text = fixed_Charge_Above_180.ToString("c");
                    lbl_7.Text = (((((charge_0_30 + charge_31_90) + charge_91_120) + charge_121_180) + above_180) + fixed_Charge_Above_180).ToString("c");

                    pnl_Result.Visible = true;
                }

            }
            else
            {
                MessageBox.Show("Please Enter Possitive Number!", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnit.Clear();
                txtUnit.Select();
            }

            txtEle_Acc_No_Search.Select();
            
        }
        private void frm_Rel_Cat_R1_Load(object sender, EventArgs e)
        {
            //pnl_Result.Visible = false;
            txtEle_Acc_No_Search.Select();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OleDbConnection conn1 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\HNDIT\Internship\Project\CEB Electricity Bill Calculat System\CEB_Electricity_Bill.mdb");

            conn1.Open();
            OleDbCommand cmd1 = new OleDbCommand("select Ele_Acc_No,Cu_Name,Address,Area_Office,Mon from Cu_De_Religious_Purpose where  Ele_Acc_No=@para1", conn1);
            cmd1.Parameters.AddWithValue("@para1", txtEle_Acc_No_Search.Text);
            OleDbDataReader reader1;
            reader1 = cmd1.ExecuteReader();

            if (reader1.Read())
            {
                txtEle_Acc_No.Text = reader1["Ele_Acc_No"].ToString();
                txtCus_Name.Text = reader1["Cu_Name"].ToString();
                txtAddress.Text = reader1["Address"].ToString();
                txtArea_Office.Text = reader1["Area_Office"].ToString();
                txtMonth.Text = reader1["Mon"].ToString();

                txtUnit.Select();
                txtUnit.Text = "0";

                lbl_1.Text = "";
                lbl_2.Text = "";
                lbl_3.Text = "";
                lbl_4.Text = "";
                lbl_5.Text = "";
                lbl_6.Text = "";
                lbl_7.Text = "";
                
            }

            else
            {
                MessageBox.Show("No Data Found");
                txtEle_Acc_No_Search.Text = "";
                txtEle_Acc_No_Search.Select();

                txtUnit.Text = "0";

                txtEle_Acc_No.Clear();
                txtCus_Name.Clear();
                txtAddress.Clear();
                txtArea_Office.Clear();
                txtMonth.Clear();

                lbl_1.Text = "";
                lbl_2.Text = "";
                lbl_3.Text = "";
                lbl_4.Text = "";
                lbl_5.Text = "";
                lbl_6.Text = "";
                lbl_7.Text = "";

            }

            conn1.Close();
        }

        private void txtEle_Acc_No_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection conn1 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\HNDIT\Internship\Project\CEB Electricity Bill Calculat System\CEB_Electricity_Bill.mdb");

                conn1.Open();
                OleDbCommand cmd1 = new OleDbCommand("select Ele_Acc_No,Cu_Name,Address,Area_Office,Mon from Cu_De_Religious_Purpose where  Ele_Acc_No=@para1", conn1);
                cmd1.Parameters.AddWithValue("@para1", txtEle_Acc_No_Search.Text);
                OleDbDataReader reader1;
                reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    txtEle_Acc_No.Text = reader1["Ele_Acc_No"].ToString();
                    txtCus_Name.Text = reader1["Cu_Name"].ToString();
                    txtAddress.Text = reader1["Address"].ToString();
                    txtArea_Office.Text = reader1["Area_Office"].ToString();
                    txtMonth.Text = reader1["Mon"].ToString();

                    txtUnit.Select();
                    txtUnit.Text = "0";

                    lbl_1.Text = "";
                    lbl_2.Text = "";
                    lbl_3.Text = "";
                    lbl_4.Text = "";
                    lbl_5.Text = "";
                    lbl_6.Text = "";
                    lbl_7.Text = "";

                }

                else
                {
                    MessageBox.Show("No Data Found");
                    txtEle_Acc_No_Search.Text = "";
                    txtEle_Acc_No_Search.Select();

                    txtUnit.Text = "0";

                    txtEle_Acc_No.Clear();
                    txtCus_Name.Clear();
                    txtAddress.Clear();
                    txtArea_Office.Clear();
                    txtMonth.Clear();

                    lbl_1.Text = "";
                    lbl_2.Text = "";
                    lbl_3.Text = "";
                    lbl_4.Text = "";
                    lbl_5.Text = "";
                    lbl_6.Text = "";
                    lbl_7.Text = "";

                }

                conn1.Close();
            }
        }

        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string temp = txtUnit.Text;
                int value;

                if (int.TryParse(temp, out value))
                {

                    int unitConsumed = int.Parse(txtUnit.Text);

                    if (unitConsumed >= 0 && unitConsumed <= 30)
                    {
                        charge_0_30 = unitConsumed * charge_Energy_0_30;

                        lbl_1.Text = charge_0_30.ToString("c");
                        lbl_2.Text = "Rs.0.00";
                        lbl_3.Text = "Rs.0.00";
                        lbl_4.Text = "Rs.0.00";
                        lbl_5.Text = "Rs.0.00";
                        lbl_6.Text = fixed_Charge_0_30.ToString("c");
                        lbl_7.Text = (charge_0_30 + fixed_Charge_0_30).ToString("c");

                        pnl_Result.Visible = true;
                    }

                    else if (unitConsumed >= 31 && unitConsumed <= 90)
                    {

                        charge_0_30 = 30 * charge_Energy_0_30;
                        charge_31_90 = (unitConsumed - 30) * charge_Energy_31_90;

                        lbl_1.Text = charge_0_30.ToString("c");
                        lbl_2.Text = charge_31_90.ToString("c");
                        lbl_3.Text = "Rs.0.00";
                        lbl_4.Text = "Rs.0.00";
                        lbl_5.Text = "Rs.0.00";
                        lbl_6.Text = fixed_Charge_31_90.ToString("c");
                        lbl_7.Text = ((charge_0_30 + charge_31_90) + fixed_Charge_31_90).ToString("c");

                        pnl_Result.Visible = true;
                    }


                    else if (unitConsumed >= 91 && unitConsumed <= 120)
                    {

                        charge_0_30 = 30 * charge_Energy_0_30;
                        charge_31_90 = 60 * charge_Energy_31_90;
                        charge_91_120 = (unitConsumed - 90) * charge_Energy_91_120;

                        lbl_1.Text = charge_0_30.ToString("c");
                        lbl_2.Text = charge_31_90.ToString("c");
                        lbl_3.Text = charge_91_120.ToString("c");
                        lbl_4.Text = "Rs.0.00";
                        lbl_5.Text = "Rs.0.00";
                        lbl_6.Text = fixed_Charge_91_120.ToString("c");
                        lbl_7.Text = (((charge_0_30 + charge_31_90) + charge_91_120) + fixed_Charge_91_120).ToString("c");

                        pnl_Result.Visible = true;
                    }

                    else if (unitConsumed >= 121 && unitConsumed <= 180)
                    {

                        charge_0_30 = 30 * charge_Energy_0_30;
                        charge_31_90 = 60 * charge_Energy_31_90;
                        charge_91_120 = 30 * charge_Energy_91_120;
                        charge_121_180 = (unitConsumed - 120) * charge_Energy_121_180;

                        lbl_1.Text = charge_0_30.ToString("c");
                        lbl_2.Text = charge_31_90.ToString("c");
                        lbl_3.Text = charge_91_120.ToString("c");
                        lbl_4.Text = charge_121_180.ToString("c");
                        lbl_5.Text = "Rs.0.00";
                        lbl_6.Text = fixed_Charge_121_180.ToString("c");
                        lbl_7.Text = ((((charge_0_30 + charge_31_90) + charge_91_120) + charge_121_180) + fixed_Charge_121_180).ToString("c");

                        pnl_Result.Visible = true;
                    }

                    else if (unitConsumed > 180)
                    {
                        charge_0_30 = 30 * charge_Energy_0_30;
                        charge_31_90 = 60 * charge_Energy_31_90;
                        charge_91_120 = 30 * charge_Energy_91_120;
                        charge_121_180 = 60 * charge_Energy_121_180;
                        above_180 = (unitConsumed - 180) * above_Energy_180;

                        lbl_1.Text = charge_0_30.ToString("c");
                        lbl_2.Text = charge_31_90.ToString("c");
                        lbl_3.Text = charge_91_120.ToString("c");
                        lbl_4.Text = charge_121_180.ToString("c");
                        lbl_5.Text = above_180.ToString("c");
                        lbl_6.Text = fixed_Charge_Above_180.ToString("c");
                        lbl_7.Text = (((((charge_0_30 + charge_31_90) + charge_91_120) + charge_121_180) + above_180) + fixed_Charge_Above_180).ToString("c");

                        pnl_Result.Visible = true;
                    }

                }
                else
                {
                    MessageBox.Show("Please Enter Possitive Number!", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnit.Clear();
                    txtUnit.Select();
                }

                txtEle_Acc_No_Search.Select();
            }
        }
    }
}
