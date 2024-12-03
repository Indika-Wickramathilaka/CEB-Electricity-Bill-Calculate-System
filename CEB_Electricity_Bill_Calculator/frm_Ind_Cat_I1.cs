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
    public partial class frm_Ind_Cat_I1 : Form
    {
        double chargeBefore300 =20.00;
        double chargeAfter300 = 20.00;
        double fixedCharge_1 = 960.00;
        double fixedCharge_2 = 1500.00;
        double before_300;
        double after_300;
        double maxDemonCharge = 0;
        double totCharge;

        public frm_Ind_Cat_I1()
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
                if ((unitConsumed <= 300) && (unitConsumed >= 0))
                {
                    before_300 = unitConsumed * chargeBefore300;
                    lblChargeFirst300Units.Text = before_300.ToString("c");
                    after_300 = 0;
                    lblChargeAfter300Units.Text = after_300.ToString("c");
                    lblFixedChargeResult.Text = fixedCharge_1.ToString("c");
                    totCharge = before_300 + after_300 + fixedCharge_1 + after_300;
                    lblTotCharge.Text = totCharge.ToString("C");

                    //pnl_Result.Visible = true;
                    txtUnit.Focus();
                }
                else if (unitConsumed > 300)
                {
                    after_300 = unitConsumed * chargeAfter300;


                   // before_300 = 300 * chargeBefore300;
                   // after_300 = ((unitConsumed - 300) * chargeAfter300);

                    lblChargeFirst300Units.Text ="Rs.00.00";
                    lblChargeAfter300Units.Text = after_300.ToString("c");
                    lblFixedChargeResult.Text = fixedCharge_2.ToString("c");
                    totCharge =  after_300 + fixedCharge_2;
                    lblTotCharge.Text = totCharge.ToString("c");

                   pnl_Result.Visible = true;
                    txtUnit.Focus();
                }

                else
                {
                    MessageBox.Show("Please Enter Possitive Number!", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnit.Clear();
                    txtUnit.Select();

                }

                txtEle_Acc_No_Search.Focus();
            }
               


            else
            {
                MessageBox.Show("Please Enter a valid number", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnit.Clear();
                txtUnit.Select();  
            }



        }

        private void frm_Ind_Cat_I1_Load(object sender, EventArgs e)
        {
            txtEle_Acc_No_Search.Focus();
            
       

            lblEnergyChargeLessThan300.Text = chargeBefore300.ToString();
            lblEnergyGreaterThan300.Text = chargeAfter300.ToString();
           

            lblFixedCharge1.Text = fixedCharge_1.ToString();
            lblFixedCharge2.Text = fixedCharge_2.ToString();
            lblMaxDemonCharge.Text = maxDemonCharge.ToString();

           // pnl_Result.Visible = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {


            OleDbConnection conn1 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\HNDIT\Internship\Project\CEB Electricity Bill Calculat System\CEB_Electricity_Bill.mdb");

            conn1.Open();
            OleDbCommand cmd1 = new OleDbCommand("select Ele_Acc_No,Cu_Name,Address,Area_Office,Mon from Cu_De_Industrial_Purpose where  Ele_Acc_No=@para1", conn1);
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

                txtEle_Acc_No_Search.Select();
                //txtUnit.Focus();

                lblChargeAfter300Units.Text = "";
                lblChargeFirst300Units.Text = "";
                lblFixedChargeResult.Text = "";
                lblTotCharge.Text = "";

                txtUnit.Text = "0";

                txtUnit.Select();
            }

            else
            {
                MessageBox.Show("No Data Found");
                txtEle_Acc_No_Search.Text = "";
                txtEle_Acc_No_Search.Select();

                txtEle_Acc_No.Clear();
                txtCus_Name.Clear();
                txtAddress.Clear();
                txtMonth.Clear();
                txtArea_Office.Clear();

                lblChargeAfter300Units.Text = "";
                lblChargeFirst300Units.Text = "";
                lblFixedChargeResult.Text = "";
                lblTotCharge.Text = "";

                txtUnit.Text = "0";
            }

            conn1.Close();

           
        }

        private void txtEle_Acc_No_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection conn1 = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\HNDIT\Internship\Project\CEB Electricity Bill Calculat System\CEB_Electricity_Bill.mdb");

                conn1.Open();
                OleDbCommand cmd1 = new OleDbCommand("select Ele_Acc_No,Cu_Name,Address,Area_Office,Mon from Cu_De_Industrial_Purpose where  Ele_Acc_No=@para1", conn1);
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

                    txtEle_Acc_No_Search.Select();
                    //txtUnit.Focus();

                    lblChargeAfter300Units.Text = "";
                    lblChargeFirst300Units.Text = "";
                    lblFixedChargeResult.Text = "";
                    lblTotCharge.Text = "";

                    txtUnit.Text = "0";

                    txtUnit.Select();

                }

                else
                {
                    MessageBox.Show("No Data Found");
                    txtEle_Acc_No_Search.Text = "";
                    txtEle_Acc_No_Search.Select();

                    txtEle_Acc_No.Clear();
                    txtCus_Name.Clear();
                    txtAddress.Clear();
                    txtArea_Office.Clear();
                    txtMonth.Clear();

                    lblChargeAfter300Units.Text = "";
                    lblChargeFirst300Units.Text = "";
                    lblFixedChargeResult.Text = "";
                    lblTotCharge.Text = "";

                    txtUnit.Text = "0";
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
                if ((unitConsumed <= 300) && (unitConsumed >= 0))
                {
                    before_300 = unitConsumed * chargeBefore300;
                    lblChargeFirst300Units.Text = before_300.ToString("c");
                    after_300 = 0;
                    lblChargeAfter300Units.Text = after_300.ToString("c");
                    lblFixedChargeResult.Text = fixedCharge_1.ToString("c");
                    totCharge = before_300 + after_300 + fixedCharge_1 + after_300;
                    lblTotCharge.Text = totCharge.ToString("C");

                    //pnl_Result.Visible = true;
                    txtUnit.Focus();
                }
                else if (unitConsumed > 300)
                {
                    after_300 = unitConsumed * chargeAfter300;


                   // before_300 = 300 * chargeBefore300;
                   // after_300 = ((unitConsumed - 300) * chargeAfter300);

                    lblChargeFirst300Units.Text ="Rs.00.00";
                    lblChargeAfter300Units.Text = after_300.ToString("c");
                    lblFixedChargeResult.Text = fixedCharge_2.ToString("c");
                    totCharge =  after_300 + fixedCharge_2;
                    lblTotCharge.Text = totCharge.ToString("c");

                   pnl_Result.Visible = true;
                    txtUnit.Focus();
                }

                else
                {
                    MessageBox.Show("Please Enter Possitive Number!", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnit.Clear();
                    txtUnit.Select();

                }

                txtEle_Acc_No_Search.Focus();
            }
               


            else
            {
                MessageBox.Show("Please Enter a valid number", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnit.Clear();
                txtUnit.Select();  
            }



        }
            

        }
    }
}
