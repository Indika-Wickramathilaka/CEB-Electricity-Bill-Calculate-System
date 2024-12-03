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
    public partial class frm_Gov_Cat_Gv1 : Form
    {
        double chargeBefore180 = 25.00;
        double chargeAfter180 = 32.00;
        double fixedCharge_1 = 360.00;
        double fixedCharge_2 = 1500.00;
        double before_180;
        double after_180;
        double maxDemonCharge = 0;
        double totCharge;

        public frm_Gov_Cat_Gv1()
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

                if ((unitConsumed <= 180) && (unitConsumed >= 0))
                {

                    pnl_Result.Visible = true;
                    before_180 = unitConsumed * chargeBefore180;
                    lblChargeBefore180.Text = before_180.ToString("c");
                    after_180 = 0;
                    lblChargeAfter180.Text = after_180.ToString("c");
                    lblFixedChargeResult.Text = fixedCharge_1.ToString("c");
                    totCharge = before_180 + after_180 + fixedCharge_1;
                    lblTotCharge.Text = totCharge.ToString("c");


                    txtUnit.Focus();
                }

                else if (unitConsumed > 180)
                {
                    pnl_Result.Visible = true;

                    after_180 = unitConsumed  * chargeAfter180;

                    lblChargeBefore180.Text ="RS.00.00";
                    lblChargeAfter180.Text = after_180.ToString("c");

                    lblFixedChargeResult.Text = fixedCharge_2.ToString("c");
                    totCharge =  after_180 + fixedCharge_2;
                    lblTotCharge.Text = totCharge.ToString("c");


                    txtUnit.Focus();
                }

                else
                {
                    MessageBox.Show("Please Enter Possitive Number!", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnit.Clear();
                    txtUnit.Select();
                }

            }
            else
            {
                MessageBox.Show("Please Enter a valid number", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnit.Clear();
                txtUnit.Select();

            }

            txtEle_Acc_No_Search.Select();

        }

        private void frm_Gov_Cat_Gv1_Load(object sender, EventArgs e)
        {
            lblFixedChargeLessThan180.Text = chargeBefore180.ToString();
            lblFixedChargeGreaterThan180.Text = chargeAfter180.ToString();

            lblFixedChargeLessThan180.Text = fixedCharge_1.ToString();
            lblFixedChargeGreaterThan180.Text = fixedCharge_2.ToString();

            lblMaxDemonCharge.Text = maxDemonCharge.ToString();

           // pnl_Result.Visible = false;
            txtUnit.Focus();
            txtEle_Acc_No_Search.Select();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OleDbConnection conn1 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Indika Wickramathilaka\HNDIT\Internship\Project\CEB Electricity Bill Calculat System\CEB_Electricity_Bill.mdb");

            conn1.Open();
            OleDbCommand cmd1 = new OleDbCommand("select Ele_Acc_No,Cu_Name,Address,Area_Office,Mon from Cu_De_Government_Purpose where  Ele_Acc_No=@para1", conn1);
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

                lblChargeBefore180.Text = "";
                lblChargeAfter180.Text = "";
                lblFixedChargeResult.Text = "";
                lblTotCharge.Text = "";
                txtUnit.Clear();

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

                lblChargeBefore180.Text = "";
                lblChargeAfter180.Text = "";
                lblFixedChargeResult.Text = "";
                lblTotCharge.Text = "";

            }

            conn1.Close();
        }

        private void txtEle_Acc_No_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection conn1 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Indika Wickramathilaka\HNDIT\Internship\Project\CEB Electricity Bill Calculat System\CEB_Electricity_Bill.mdb");

                conn1.Open();
                OleDbCommand cmd1 = new OleDbCommand("select Ele_Acc_No,Cu_Name,Address,Area_Office,Mon from Cu_De_Government_Purpose where  Ele_Acc_No=@para1", conn1);
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

                    lblChargeBefore180.Text = "";
                    lblChargeAfter180.Text = "";
                    lblFixedChargeResult.Text = "";
                    lblTotCharge.Text = "";
                    txtUnit.Clear();

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

                    lblChargeBefore180.Text = "";
                    lblChargeAfter180.Text = "";
                    lblFixedChargeResult.Text = "";
                    lblTotCharge.Text = "";

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

                    if ((unitConsumed <= 180) && (unitConsumed >= 0))
                    {

                        pnl_Result.Visible = true;
                        before_180 = unitConsumed * chargeBefore180;
                        lblChargeBefore180.Text = before_180.ToString("c");
                        after_180 = 0;
                        lblChargeAfter180.Text = after_180.ToString("c");
                        lblFixedChargeResult.Text = fixedCharge_1.ToString("c");
                        totCharge = before_180 + after_180 + fixedCharge_1;
                        lblTotCharge.Text = totCharge.ToString("c");


                        txtUnit.Focus();
                    }

                    else if (unitConsumed > 180)
                    {
                        pnl_Result.Visible = true;

                        after_180 = unitConsumed * chargeAfter180;

                        lblChargeBefore180.Text = "RS.00.00";
                        lblChargeAfter180.Text = after_180.ToString("c");

                        lblFixedChargeResult.Text = fixedCharge_2.ToString("c");
                        totCharge = after_180 + fixedCharge_2;
                        lblTotCharge.Text = totCharge.ToString("c");


                        txtUnit.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Please Enter Possitive Number!", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUnit.Clear();
                        txtUnit.Select();
                    }

                }
                else
                {
                    MessageBox.Show("Please Enter a valid number", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnit.Clear();
                    txtUnit.Select();

                }

                txtEle_Acc_No_Search.Select();
            }
        }
    }
}
