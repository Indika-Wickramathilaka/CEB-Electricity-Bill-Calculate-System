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
    public partial class frm_CEB_Bill_Calculator : Form
    {
        public frm_CEB_Bill_Calculator()
        {
            InitializeComponent();
        }
        int startPoint = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 1;
            MyProgress.ForeColor = Color.White;
            MyProgress.Value = startPoint;
            
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();

                frm_Login_Form log = new frm_Login_Form();
                this.Hide();
                log.Show();
            }
        }

        private void frm_CEB_Bill_Calculator_Load(object sender, EventArgs e)
        {
            timer1.Start();
           
        }
    }
}
