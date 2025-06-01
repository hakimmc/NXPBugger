using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NXPBugger
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        DialogResult DR;
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (u.Text == "OttomotiveNXPAC")
            {
                if(p.Text == "Ottomotive22*AC")
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            this.Close();
        }
    }
}
