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
    public partial class changeNumberOfColors : Form
    {
        Mastermind game;
        public changeNumberOfColors(Mastermind game)
        {
            InitializeComponent();
            this.game = game;
        }
    }
}
