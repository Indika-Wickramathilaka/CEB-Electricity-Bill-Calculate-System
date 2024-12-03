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
    public partial class frm_New_User_Registration : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\HNDIT\Internship\Project\CEB Electricity Bill Calculat System\CEB_Electricity_Bill.mdb");
        OleDbCommand cmd;
        int cheker;
        public frm_New_User_Registration()
        {
            InitializeComponent();
        }

        void dataViewerInduPurpose()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cu_De_Industrial_Purpose";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                dp.Fill(dt);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        void dataViewerGenPurpose()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cu_De_General_Purpose";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                dp.Fill(dt);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        void dataViewerHotPurpose()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cu_De_Hotel_Purpose";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                dp.Fill(dt);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        void dataViewerDomPurpose()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cu_De_Domestic_Purpose";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                dp.Fill(dt);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        void dataViewerRelPurpose()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cu_De_Religious_Purpose";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                dp.Fill(dt);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

            void dataViewerGovPurpose()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cu_De_Government_Purpose";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                dp.Fill(dt);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }

        }
        private void frm_New_User_Registration_Load(object sender, EventArgs e)
        {
            cboCategory.Items.Add("Industrial Purpose");
            cboCategory.Items.Add("General Purpose");
            cboCategory.Items.Add("Hotel Purpose");
            cboCategory.Items.Add("Government Purpose");
            cboCategory.Items.Add("Domestic Purpose");
            cboCategory.Items.Add("Religious Purpose");

            
        }


        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.Text == "Industrial Purpose")
            {
                dataViewerInduPurpose();
                txtEleAccNo.Select();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAreaOffice.Text = "";
                txtAddress.Text = "";
                txtMonth.Text = "";
            }

            else if (cboCategory.Text == "General Purpose")
            {
                dataViewerGenPurpose();
                txtEleAccNo.Select();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAreaOffice.Text = "";
                txtAddress.Text = "";
                txtMonth.Text = "";
            }

            else if (cboCategory.Text == "Hotel Purpose")
            {
                dataViewerHotPurpose();
                txtEleAccNo.Select();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAreaOffice.Text = "";
                txtAddress.Text = "";
                txtMonth.Text = "";
            }

            else if (cboCategory.Text == "Domestic Purpose")
            {
                dataViewerDomPurpose();
                txtEleAccNo.Select();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAreaOffice.Text = "";
                txtAddress.Text = "";
                txtMonth.Text = "";
            }

            else if (cboCategory.Text == "Religious Purpose")
            {
                dataViewerRelPurpose();
                txtEleAccNo.Select();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAreaOffice.Text = "";
                txtAddress.Text = "";
                txtMonth.Text = "";
            }

            else if (cboCategory.Text == "Government Purpose")
            {
                
                txtEleAccNo.Select();
                dataViewerGovPurpose();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAreaOffice.Text = "";
                txtAddress.Text = "";
                txtMonth.Text = "";
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (cboCategory.Text == "Industrial Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Cu_De_Industrial_Purpose(Ele_Acc_No,Cu_Name,Address,Area_Office,Mon)values('" + txtEleAccNo.Text+ "','" + txtCusName.Text + "','" + txtAddress.Text + "','" + txtAreaOffice.Text + "','" + txtMonth.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Save in Database", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    dataViewerInduPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                    txtAddress.Text = "";

                    txtEleAccNo.Select();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            
            }

            else if (cboCategory.Text == "General Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Cu_De_General_Purpose(Ele_Acc_No,Cu_Name,Address,Area_Office,Mon)values('" + txtEleAccNo.Text + "','" + txtCusName.Text + "','" + txtAddress.Text + "','" + txtAreaOffice.Text + "','" + txtMonth.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Save in Database", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    dataViewerGenPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                    txtAddress.Text = "";

                    txtEleAccNo.Select();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "Hotel Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Cu_De_Hotel_Purpose(Ele_Acc_No,Cu_Name,Address,Area_Office,Mon)values('" + txtEleAccNo.Text + "','" + txtCusName.Text + "','" + txtAddress.Text + "','" + txtAreaOffice.Text + "','" + txtMonth.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Save in Database", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    dataViewerHotPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                    txtAddress.Text = "";

                    txtEleAccNo.Select();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "Domestic Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Cu_De_Domestic_Purpose(Ele_Acc_No,Cu_Name,Address,Area_Office,Mon)values('" + txtEleAccNo.Text + "','" + txtCusName.Text + "','" + txtAddress.Text + "','" + txtAreaOffice.Text + "','" + txtMonth.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Save in Database", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    dataViewerDomPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                    txtAddress.Text = "";

                    txtEleAccNo.Select();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "Religious Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Cu_De_Religious_Purpose(Ele_Acc_No,Cu_Name,Address,Area_Office,Mon)values('" + txtEleAccNo.Text + "','" + txtCusName.Text + "','" + txtAddress.Text + "','" + txtAreaOffice.Text + "','" + txtMonth.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Save in Database", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    dataViewerRelPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                    txtAddress.Text = "";

                    txtEleAccNo.Select();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "Government Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Cu_De_Government_Purpose(Ele_Acc_No,Cu_Name,Address,Area_Office,Mon)values('" + txtEleAccNo.Text + "','" + txtCusName.Text + "','" + txtAddress.Text + "','" + txtAreaOffice.Text + "','" + txtMonth.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Save in Database", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    dataViewerGovPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                    txtAddress.Text = "";

                    txtEleAccNo.Select();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtEleAccNo.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtCusName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtAddress.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtAreaOffice.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtMonth.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboCategory.Text == "Industrial Purpose")
            {
                try
                {
                    string query = "UPDATE Cu_De_Industrial_Purpose SET Cu_Name=@cus_name, Address=@address, Area_Office=@area_office, Mon=@mon WHERE Ele_Acc_No=@ele_acc_no ";

                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cus_name", txtCusName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@area_office", txtAreaOffice.Text);
                    cmd.Parameters.AddWithValue("@mon", txtMonth.Text);
                    cmd.Parameters.AddWithValue("@ele_acc_no", txtEleAccNo.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Updated Successfully");
                    dataViewerInduPurpose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "General Purpose")
            {
                try
                {
                    string query = "UPDATE Cu_De_General_Purpose SET Cu_Name=@cus_name, Address=@address, Area_Office=@area_office, Mon=@mon WHERE Ele_Acc_No=@ele_acc_no ";

                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cus_name", txtCusName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@area_office", txtAreaOffice.Text);
                    cmd.Parameters.AddWithValue("@mon", txtMonth.Text);
                    cmd.Parameters.AddWithValue("@ele_acc_no", txtEleAccNo.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Updated Successfully");
                    dataViewerGenPurpose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            
            }

            else if (cboCategory.Text == "Hotel Purpose")
            {
                try
                {
                    string query = "UPDATE Cu_De_Hotel_Purpose SET Cu_Name=@cus_name, Address=@address, Area_Office=@area_office, Mon=@mon WHERE Ele_Acc_No=@ele_acc_no ";

                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cus_name", txtCusName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@area_office", txtAreaOffice.Text);
                    cmd.Parameters.AddWithValue("@mon", txtMonth.Text);
                    cmd.Parameters.AddWithValue("@ele_acc_no", txtEleAccNo.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Updated Successfully");
                    dataViewerHotPurpose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }

            }

            else if (cboCategory.Text == "Domestic Purpose")
            {
                try
                {
                    string query = "UPDATE Cu_De_Domestic_Purpose SET Cu_Name=@cus_name, Address=@address, Area_Office=@area_office, Mon=@mon WHERE Ele_Acc_No=@ele_acc_no ";

                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cus_name", txtCusName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@area_office", txtAreaOffice.Text);
                    cmd.Parameters.AddWithValue("@mon", txtMonth.Text);
                    cmd.Parameters.AddWithValue("@ele_acc_no", txtEleAccNo.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Updated Successfully");
                    dataViewerDomPurpose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }

            }

            else if (cboCategory.Text == "Religious Purpose")
            {
                try
                {
                    string query = "UPDATE Cu_De_Religious_Purpose SET Cu_Name=@cus_name, Address=@address, Area_Office=@area_office, Mon=@mon WHERE Ele_Acc_No=@ele_acc_no ";

                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cus_name", txtCusName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@area_office", txtAreaOffice.Text);
                    cmd.Parameters.AddWithValue("@mon", txtMonth.Text);
                    cmd.Parameters.AddWithValue("@ele_acc_no", txtEleAccNo.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Updated Successfully");
                    dataViewerRelPurpose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "Government Purpose")
            {
                try
                {
                    string query = "UPDATE Cu_De_Government_Purpose SET Cu_Name=@cus_name, Address=@address, Area_Office=@area_office, Mon=@mon WHERE Ele_Acc_No=@ele_acc_no ";

                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cus_name", txtCusName.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@area_office", txtAreaOffice.Text);
                    cmd.Parameters.AddWithValue("@mon", txtMonth.Text);
                    cmd.Parameters.AddWithValue("@ele_acc_no", txtEleAccNo.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Updated Successfully");
                    dataViewerGovPurpose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboCategory.Text == "Industrial Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete * from Cu_De_Industrial_Purpose where Ele_Acc_No ='" +txtEleAccNo.Text + "' ";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Successfully Delete", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataViewerInduPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAddress.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "General Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete * from Cu_De_General_Purpose where Ele_Acc_No ='" + txtEleAccNo.Text + "' ";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Successfully Delete", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataViewerGenPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAddress.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "Hotel Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete * from Cu_De_Hotel_Purpose where Ele_Acc_No ='" + txtEleAccNo.Text + "' ";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Successfully Delete", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataViewerHotPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAddress.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "Domestic Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete * from Cu_De_Domestic_Purpose where Ele_Acc_No ='" + txtEleAccNo.Text + "' ";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Successfully Delete", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataViewerDomPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAddress.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "Religious Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete * from Cu_De_Religious_Purpose where Ele_Acc_No ='" + txtEleAccNo.Text + "' ";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Successfully Delete", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataViewerRelPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAddress.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "Government Purpose")
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete * from Cu_De_Government_Purpose where Ele_Acc_No ='" + txtEleAccNo.Text + "' ";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Successfully Delete", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataViewerGovPurpose();

                    txtEleAccNo.Text = "";
                    txtCusName.Text = "";
                    txtAddress.Text = "";
                    txtAreaOffice.Text = "";
                    txtMonth.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (cboCategory.Text == "Industrial Purpose")
            {

                cheker = 0;

                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Cu_De_Industrial_Purpose where Ele_Acc_No = '" + txtEleAccNo.Text + "' or Cu_Name = '" + txtCusName.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                    dp.Fill(dt);
                    cheker = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;
                    conn.Close();

                    if (cheker == 0)
                    {
                        MessageBox.Show("Rocord Not Found", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEleAccNo.Clear();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "General Purpose")
            {
                cheker = 0;

                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Cu_De_General_Purpose where Ele_Acc_No = '" + txtEleAccNo.Text + "' or Cu_Name = '" + txtCusName.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                    dp.Fill(dt);
                    cheker = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;
                    conn.Close();

                    if (cheker == 0)
                    {
                        MessageBox.Show("Rocord Not Found", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEleAccNo.Clear();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }

            else if (cboCategory.Text == "Hotel Purpose")
            {
                cheker = 0;

                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Cu_De_Hotel_Purpose where Ele_Acc_No = '" + txtEleAccNo.Text + "' or Cu_Name = '" + txtCusName.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                    dp.Fill(dt);
                    cheker = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;
                    conn.Close();

                    if (cheker == 0)
                    {
                        MessageBox.Show("Rocord Not Found", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEleAccNo.Clear();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }

            }

            else if (cboCategory.Text == "Domestic Purpose")
            {
                cheker = 0;

                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Cu_De_Domestic_Purpose where Ele_Acc_No = '" + txtEleAccNo.Text + "' or Cu_Name = '" + txtCusName.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                    dp.Fill(dt);
                    cheker = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;
                    conn.Close();

                    if (cheker == 0)
                    {
                        MessageBox.Show("Rocord Not Found", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEleAccNo.Clear();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }

            }

            else if (cboCategory.Text == "Religious Purpose")
            {
                cheker = 0;

                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Cu_De_Religious_Purpose where Ele_Acc_No = '" + txtEleAccNo.Text + "' or Cu_Name = '" + txtCusName.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                    dp.Fill(dt);
                    cheker = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;
                    conn.Close();

                    if (cheker == 0)
                    {
                        MessageBox.Show("Rocord Not Found", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEleAccNo.Clear();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }

            }

            else if (cboCategory.Text == "Government Purpose")
            {
                cheker = 0;

                try
                {
                    conn.Open();
                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Cu_De_Government_Purpose where Ele_Acc_No = '" + txtEleAccNo.Text + "' or Cu_Name = '" + txtCusName.Text + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                    dp.Fill(dt);
                    cheker = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;
                    conn.Close();

                    if (cheker == 0)
                    {
                        MessageBox.Show("Rocord Not Found", "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEleAccNo.Clear();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Access connect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }

            }
            
            

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (cboCategory.Text == "Industrial Purpose")
            {
                dataViewerInduPurpose();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAddress.Text = "";
                txtAreaOffice.Text = "";
                txtMonth.Text = "";

                txtEleAccNo.Select();
            }

            else if (cboCategory.Text == "General Purpose")
            {
                dataViewerGenPurpose();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAddress.Text = "";
                txtAreaOffice.Text = "";
                txtMonth.Text = "";

                txtEleAccNo.Select();
            }

            else if (cboCategory.Text == "Hotel Purpose")
            {
                dataViewerHotPurpose();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAddress.Text = "";
                txtAreaOffice.Text = "";
                txtMonth.Text = "";

                txtEleAccNo.Select();
            }

            else if (cboCategory.Text == "Domestic Purpose")
            {
                dataViewerDomPurpose();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAddress.Text = "";
                txtAreaOffice.Text = "";
                txtMonth.Text = "";

                txtEleAccNo.Select();
            }

            else if (cboCategory.Text == "Religious Purpose")
            {
                dataViewerRelPurpose();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAddress.Text = "";
                txtAreaOffice.Text = "";
                txtMonth.Text = "";

                txtEleAccNo.Select();
            }

            else if (cboCategory.Text == "Government Purpose")
            {
                dataViewerGovPurpose();

                txtEleAccNo.Text = "";
                txtCusName.Text = "";
                txtAddress.Text = "";
                txtAreaOffice.Text = "";
                txtMonth.Text = "";

                txtEleAccNo.Select();
            }



        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Confirm if you want to exit", "CEB ElectricityBill Calculator", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (iExit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtEleAccNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCusName.Select();
            }
        }

        private void txtCusName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtAddress.Select();
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtAreaOffice.Select();
            }
        }

        private void txtAreaOffice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtMonth.Select();
            }
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            if (cboCategory.Text == "Industrial Purpose")
            {
                dataViewerInduPurpose();
            }

            else if (cboCategory.Text == "General Purpose")
            {
                dataViewerGenPurpose();
            }

            else if (cboCategory.Text == "Hotel Purpose")
            {
                dataViewerHotPurpose();
            }

            else if (cboCategory.Text == "Government Purpose")
            {
                dataViewerGovPurpose();
            }

            else if (cboCategory.Text == "Domestic Purpose")
            {
                dataViewerDomPurpose();
            }

            else if (cboCategory.Text == "Religious Purpose")
            {
                dataViewerRelPurpose();
            }
        }
    }
}
