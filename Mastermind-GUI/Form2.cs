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
    public partial class MastermindMenu : Form
    {
        public MastermindMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Affiche le message de bienvenur dans le menu du mastermind
        /// </summary>
        private void DisplayWelcome()
        {
            lblWelcome.Text = "Bienvenue au Mastermind \n" +
                "Dans ce jeu, vous devez trouver le code caché de quatre couleurs.\n \n" +
                "Choisissez le mode de jeu : ";
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
        }
    }
}
