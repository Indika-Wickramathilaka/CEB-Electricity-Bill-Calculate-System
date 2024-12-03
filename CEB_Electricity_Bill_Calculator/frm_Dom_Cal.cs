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
    public partial class frm_Dom_Cal : Form
    {
        double charge_0_30_If_Below_60kWh = 8.00;
        double charge_31_60_If_Below_60kWh = 10.00;

        double charge_0_60_If_Above_60kWh = 16.00;
        double charge_61_90_If_Above_60kWh = 16.00;
        double charge_91_120_If_Above_60kWh = 50.00;
        double charge_121_180_If_Above_60kWh = 50.00;
        double charge__Above_180_If_Above_60kWh = 75.00;

        double fixed_charge_0_30_If_Below_60kWh = 120.00;
        double fixed_charge_31_60_If_Below_60kWh = 240.00;

        double fixed_charge_0_60_If_Above_60kWh = 0;
        double fixed_charge_61_90_If_Above_60kWh = 360.00;
        double fixed_charge_91_120_If_Above_60kWh = 960.00;
        double fixed_charge_121_180_If_Above_60kWh = 960.00;
        double fixed_charge__Above_180_If_Above_60kWh = 1500.00;

        double charge_0_30;
        double charge_31_60;

        double charge_0_60;
        double charge_61_90;
        double charge_91_120;
        double charge_121_180;
        double above_180;

        double tot_Charge;
       
        public frm_Dom_Cal()
        {
            InitializeComponent();
        }

        private void frm_Dom_Cal_Load(object sender, EventArgs e)
        {
           // pnl_Result.Visible = false;
            txtEle_Acc_No_Search.Select();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
             string temp = txtUnit.Text;
             int value;

             if (int.TryParse(temp, out value))
             {
                 int unitConsumed = int.Parse(txtUnit.Text);
                 if ((unitConsumed <= 60) && (unitConsumed >= 0))
                 {

                     if ((unitConsumed <= 30) && (unitConsumed >= 0))
                     {

                         charge_0_30 = unitConsumed * charge_0_30_If_Below_60kWh;
                         tot_Charge = charge_0_30 + fixed_charge_0_30_If_Below_60kWh;

                         lbl_1.Text = charge_0_30.ToString("c");

                         lbl_1.Text = charge_0_30.ToString("c");
                         lbl_2.Text = "Rs.0.00";
                         lbl_3.Text = "Rs.0.00";
                         lbl_4.Text = "Rs.0.00";
                         lbl_5.Text = "Rs.0.00";
                         lbl_6.Text = "Rs.0.00";
                         lbl_7.Text = fixed_charge_0_30_If_Below_60kWh.ToString("c");
                         lbl_8.Text = (charge_0_30 + fixed_charge_0_30_If_Below_60kWh).ToString("c");

                         pnl_Result.Visible = true;

                     }

                     else
                     {
                         charge_0_30 = 30 * charge_0_30_If_Below_60kWh;
                         charge_31_60 = (unitConsumed - 30) * charge_31_60_If_Below_60kWh;
                         tot_Charge = charge_0_30 + fixed_charge_0_30_If_Below_60kWh;

                         lbl_1.Text = charge_0_30.ToString("c");
                         lbl_2.Text = charge_31_60.ToString("c");
                         lbl_3.Text = "Rs.0.00";
                         lbl_4.Text = "Rs.0.00";
                         lbl_5.Text = "Rs.0.00";
                         lbl_6.Text = "Rs.0.00";
                         lbl_7.Text = fixed_charge_31_60_If_Below_60kWh.ToString("c");
                         lbl_8.Text = (charge_0_30 + fixed_charge_31_60_If_Below_60kWh + charge_31_60).ToString("c");

                         pnl_Result.Visible = true;
                     }


                 }

                 else if (unitConsumed >= 61 && unitConsumed <= 90)
                 {

                     charge_0_60 = 60 * charge_0_60_If_Above_60kWh;
                     charge_61_90 = (unitConsumed - 60) * charge_61_90_If_Above_60kWh;

                     tot_Charge = (charge_0_60 + charge_61_90) + fixed_charge_61_90_If_Above_60kWh;

                     lbl_1.Text = charge_0_60.ToString("c");
                     lbl_2.Text = charge_0_60.ToString("c");

                     lbl_3.Text = charge_61_90.ToString("c");
                     lbl_4.Text = "Rs.0.00";
                     lbl_5.Text = "Rs.0.00";
                     lbl_6.Text = "Rs.0.00";
                     lbl_7.Text = fixed_charge_61_90_If_Above_60kWh.ToString("c");
                     lbl_8.Text = ((charge_0_60 + charge_61_90) + fixed_charge_61_90_If_Above_60kWh).ToString("c");
                     pnl_Result.Visible = true;
                 }

                 else if (unitConsumed >= 91 && unitConsumed <= 120)
                 {
                     charge_0_60 = 60 * charge_0_60_If_Above_60kWh;
                     charge_61_90 = 30 * charge_61_90_If_Above_60kWh;

                     charge_91_120 = (unitConsumed - 90) * charge_91_120_If_Above_60kWh;

                     lbl_1.Text = charge_0_60.ToString("c");
                     lbl_2.Text = charge_0_60.ToString("c");
                     lbl_3.Text = charge_61_90.ToString("c");
                     lbl_4.Text = charge_91_120.ToString("c");
                     lbl_5.Text = "Rs.0.00";
                     lbl_6.Text = "Rs.0.00";
                     lbl_7.Text = fixed_charge_91_120_If_Above_60kWh.ToString("c");
                     lbl_8.Text = (((charge_0_60 + charge_61_90) + charge_91_120) + fixed_charge_91_120_If_Above_60kWh).ToString("c");
                     pnl_Result.Visible = true;
                 }

                 else if (unitConsumed >= 121 && unitConsumed <= 180)
                 {
                     charge_0_60 = 60 * charge_0_60_If_Above_60kWh;
                     charge_61_90 = 30 * charge_61_90_If_Above_60kWh;
                     charge_91_120 = 30 * charge_91_120_If_Above_60kWh;

                     charge_121_180 = (unitConsumed - 120) * charge_121_180_If_Above_60kWh;

                     lbl_1.Text = charge_0_60.ToString("c");
                     lbl_2.Text = charge_0_60.ToString("c");
                     lbl_3.Text = charge_61_90.ToString("c");
                     lbl_4.Text = charge_91_120.ToString("c");
                     lbl_5.Text = charge_121_180.ToString("c");
                     lbl_6.Text = "Rs.0.00";
                     lbl_7.Text = fixed_charge_121_180_If_Above_60kWh.ToString("c");
                     lbl_8.Text = ((((charge_0_60 + charge_61_90) + charge_91_120) + charge_121_180) + fixed_charge_121_180_If_Above_60kWh).ToString("c");
                     pnl_Result.Visible = true;
                 }

                 else if (unitConsumed > 180)
                 {
                     charge_0_60 = 60 * charge_0_60_If_Above_60kWh;
                     charge_61_90 = 30 * charge_61_90_If_Above_60kWh;
                     charge_91_120 = 30 * charge_91_120_If_Above_60kWh;
                     charge_121_180 = 60 * charge_121_180_If_Above_60kWh;

                     above_180 = (unitConsumed - 180) * charge__Above_180_If_Above_60kWh;

                     lbl_1.Text = charge_0_60.ToString("c");
                     lbl_2.Text = charge_0_60.ToString("c");
                     lbl_3.Text = charge_61_90.ToString("c");
                     lbl_4.Text = charge_91_120.ToString("c");
                     lbl_5.Text = charge_121_180.ToString("c");
                     lbl_6.Text = above_180.ToString("c");
                     lbl_7.Text = fixed_charge__Above_180_If_Above_60kWh.ToString("c");
                     lbl_8.Text = (((((charge_0_60 + charge_61_90) + charge_91_120) + charge_121_180) + above_180) + fixed_charge__Above_180_If_Above_60kWh).ToString("c");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OleDbConnection conn1 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\HNDIT\Internship\Project\CEB Electricity Bill Calculat System\CEB_Electricity_Bill.mdb");

            conn1.Open();
            OleDbCommand cmd1 = new OleDbCommand("select Ele_Acc_No,Cu_Name,Address,Area_Office,Mon from Cu_De_Domestic_Purpose where  Ele_Acc_No=@para1", conn1);
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
                lbl_8.Text = "";
                

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
                lbl_8.Text = "";

            }

            conn1.Close();
        }

        private void txtEle_Acc_No_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection conn1 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\HNDIT\Internship\Project\CEB Electricity Bill Calculat System\CEB_Electricity_Bill.mdb");

                conn1.Open();
                OleDbCommand cmd1 = new OleDbCommand("select Ele_Acc_No,Cu_Name,Address,Area_Office,Mon from Cu_De_Domestic_Purpose where  Ele_Acc_No=@para1", conn1);
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
                    lbl_8.Text = "";


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
                    lbl_8.Text = "";

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
                    if ((unitConsumed <= 60) && (unitConsumed >= 0))
                    {

                        if ((unitConsumed <= 30) && (unitConsumed >= 0))
                        {

                            charge_0_30 = unitConsumed * charge_0_30_If_Below_60kWh;
                            tot_Charge = charge_0_30 + fixed_charge_0_30_If_Below_60kWh;

                            lbl_1.Text = charge_0_30.ToString("c");

                            lbl_1.Text = charge_0_30.ToString("c");
                            lbl_2.Text = "Rs.0.00";
                            lbl_3.Text = "Rs.0.00";
                            lbl_4.Text = "Rs.0.00";
                            lbl_5.Text = "Rs.0.00";
                            lbl_6.Text = "Rs.0.00";
                            lbl_7.Text = fixed_charge_0_30_If_Below_60kWh.ToString("c");
                            lbl_8.Text = (charge_0_30 + fixed_charge_0_30_If_Below_60kWh).ToString("c");

                            pnl_Result.Visible = true;

                        }

                        else
                        {
                            charge_0_30 = 30 * charge_0_30_If_Below_60kWh;
                            charge_31_60 = (unitConsumed - 30) * charge_31_60_If_Below_60kWh;
                            tot_Charge = charge_0_30 + fixed_charge_0_30_If_Below_60kWh;

                            lbl_1.Text = charge_0_30.ToString("c");
                            lbl_2.Text = charge_31_60.ToString("c");
                            lbl_3.Text = "Rs.0.00";
                            lbl_4.Text = "Rs.0.00";
                            lbl_5.Text = "Rs.0.00";
                            lbl_6.Text = "Rs.0.00";
                            lbl_7.Text = fixed_charge_31_60_If_Below_60kWh.ToString("c");
                            lbl_8.Text = (charge_0_30 + fixed_charge_31_60_If_Below_60kWh + charge_31_60).ToString("c");

                            pnl_Result.Visible = true;
                        }


                    }

                    else if (unitConsumed >= 61 && unitConsumed <= 90)
                    {

                        charge_0_60 = 60 * charge_0_60_If_Above_60kWh;
                        charge_61_90 = (unitConsumed - 60) * charge_61_90_If_Above_60kWh;

                        tot_Charge = (charge_0_60 + charge_61_90) + fixed_charge_61_90_If_Above_60kWh;

                        lbl_1.Text = charge_0_60.ToString("c");
                        lbl_2.Text = charge_0_60.ToString("c");

                        lbl_3.Text = charge_61_90.ToString("c");
                        lbl_4.Text = "Rs.0.00";
                        lbl_5.Text = "Rs.0.00";
                        lbl_6.Text = "Rs.0.00";
                        lbl_7.Text = fixed_charge_61_90_If_Above_60kWh.ToString("c");
                        lbl_8.Text = ((charge_0_60 + charge_61_90) + fixed_charge_61_90_If_Above_60kWh).ToString("c");
                        pnl_Result.Visible = true;
                    }

                    else if (unitConsumed >= 91 && unitConsumed <= 120)
                    {
                        charge_0_60 = 60 * charge_0_60_If_Above_60kWh;
                        charge_61_90 = 30 * charge_61_90_If_Above_60kWh;

                        charge_91_120 = (unitConsumed - 90) * charge_91_120_If_Above_60kWh;

                        lbl_1.Text = charge_0_60.ToString("c");
                        lbl_2.Text = charge_0_60.ToString("c");
                        lbl_3.Text = charge_61_90.ToString("c");
                        lbl_4.Text = charge_91_120.ToString("c");
                        lbl_5.Text = "Rs.0.00";
                        lbl_6.Text = "Rs.0.00";
                        lbl_7.Text = fixed_charge_91_120_If_Above_60kWh.ToString("c");
                        lbl_8.Text = (((charge_0_60 + charge_61_90) + charge_91_120) + fixed_charge_91_120_If_Above_60kWh).ToString("c");
                        pnl_Result.Visible = true;
                    }

                    else if (unitConsumed >= 121 && unitConsumed <= 180)
                    {
                        charge_0_60 = 60 * charge_0_60_If_Above_60kWh;
                        charge_61_90 = 30 * charge_61_90_If_Above_60kWh;
                        charge_91_120 = 30 * charge_91_120_If_Above_60kWh;

                        charge_121_180 = (unitConsumed - 120) * charge_121_180_If_Above_60kWh;

                        lbl_1.Text = charge_0_60.ToString("c");
                        lbl_2.Text = charge_0_60.ToString("c");
                        lbl_3.Text = charge_61_90.ToString("c");
                        lbl_4.Text = charge_91_120.ToString("c");
                        lbl_5.Text = charge_121_180.ToString("c");
                        lbl_6.Text = "Rs.0.00";
                        lbl_7.Text = fixed_charge_121_180_If_Above_60kWh.ToString("c");
                        lbl_8.Text = ((((charge_0_60 + charge_61_90) + charge_91_120) + charge_121_180) + fixed_charge_121_180_If_Above_60kWh).ToString("c");
                        pnl_Result.Visible = true;
                    }

                    else if (unitConsumed > 180)
                    {
                        charge_0_60 = 60 * charge_0_60_If_Above_60kWh;
                        charge_61_90 = 30 * charge_61_90_If_Above_60kWh;
                        charge_91_120 = 30 * charge_91_120_If_Above_60kWh;
                        charge_121_180 = 60 * charge_121_180_If_Above_60kWh;

                        above_180 = (unitConsumed - 180) * charge__Above_180_If_Above_60kWh;

                        lbl_1.Text = charge_0_60.ToString("c");
                        lbl_2.Text = charge_0_60.ToString("c");
                        lbl_3.Text = charge_61_90.ToString("c");
                        lbl_4.Text = charge_91_120.ToString("c");
                        lbl_5.Text = charge_121_180.ToString("c");
                        lbl_6.Text = above_180.ToString("c");
                        lbl_7.Text = fixed_charge__Above_180_If_Above_60kWh.ToString("c");
                        lbl_8.Text = (((((charge_0_60 + charge_61_90) + charge_91_120) + charge_121_180) + above_180) + fixed_charge__Above_180_If_Above_60kWh).ToString("c");
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
