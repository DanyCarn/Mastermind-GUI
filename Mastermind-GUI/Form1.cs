using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind_GUI
{
    public partial class Mastermind : Form
    {
        public Mastermind()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            lblInput01.BackColor = button.BackColor;
        } 

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblInput01.BackColor = SystemColors.ControlLight;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
