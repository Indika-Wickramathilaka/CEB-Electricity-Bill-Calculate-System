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
    public partial class frm_Dom_Bill_Rate : Form
    {
        double charge_0_30_If_Below_60kWh=8.00;
        double chage_31_60_If_Below_60kWh = 10.00;

        double fixed_charge_0_30_If_Below_60kWh = 120.00;
        double fixed_charge_31_60_If_Below_60kWh = 240.00;



        double charge_0_60_If_Above_60kWh = 16.00;
        double fixed_charge_0_60_If_Above_60kWh = 0;

        double charge_61_90_If_Above_60kWh = 16.00;
        double fixed_charge_61_90_If_Above_60kWh = 360.00;

        double charge_91_120_If_Above_60kWh = 50.00;
        double fixed_charge_91_120_If_Above_60kWh = 960.00;

        double charge_121_180_If_Above_60kWh = 50.00;
        double fixed_charge_121_180_If_Above_60kWh = 960.00;

        double charge__Above_180_If_Above_60kWh = 75.00;
        double fixed_charge__Above_180_If_Above_60kWh = 1500.00;



        public frm_Dom_Bill_Rate()
        {
            InitializeComponent();
        }

        private void frm_Dom_Bill_Rate_Load(object sender, EventArgs e)
        {
            lblT1lDomEnergyCharge1.Text = charge_0_30_If_Below_60kWh.ToString();
            lblT1DomEnergyCharge2.Text = chage_31_60_If_Below_60kWh.ToString();

            lblT1DomFixedCharge1.Text = fixed_charge_0_30_If_Below_60kWh.ToString();
            lblT1DomFixedCharge2.Text = fixed_charge_31_60_If_Below_60kWh.ToString();

            lblT2DomEnergyCharge1.Text = charge_0_60_If_Above_60kWh.ToString();
            lblT2DomEnergyCharge2.Text = charge_61_90_If_Above_60kWh.ToString();
            lblT2DomEnergyCharge3.Text = charge_91_120_If_Above_60kWh.ToString();
            lblT2DomEnergyCharge4.Text = charge_121_180_If_Above_60kWh.ToString();
            lblT2DomEnergyCharge5.Text = charge__Above_180_If_Above_60kWh.ToString();


            lblT2DomFixedCharge1.Text = fixed_charge_0_60_If_Above_60kWh.ToString();
            lblT2DomFixedCharge2.Text = fixed_charge_61_90_If_Above_60kWh.ToString();
            lblT2DomFixedCharge3.Text = fixed_charge_91_120_If_Above_60kWh.ToString();
            lblT2DomFixedCharge4.Text = fixed_charge_121_180_If_Above_60kWh.ToString();
            lblT2DomFixedCharge5.Text = fixed_charge__Above_180_If_Above_60kWh.ToString();

        }
    }
}
