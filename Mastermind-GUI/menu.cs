using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// ETML
/// Auteur : Dany Carneiro Jeremias
/// Date : 16.11.2023
/// Description : Page du menu du mastermind permettant de choisir le mode facile ou le mode normal

namespace Mastermind_GUI
{
    public partial class MastermindMenu : Form
    {
        public MastermindMenu()
        {
            InitializeComponent();
            DisplayWelcome();
        }
        /// <summary>
        /// Affiche le message de bienvenue dans le menu du mastermind
        /// </summary>
        private void DisplayWelcome()
        {
            //Message de bienvenue au jeu
            lblWelcome.Text = "Bienvenue au Mastermind \n" +
                "Dans ce jeu, vous devez trouver le code caché de quatre couleurs.\n \n";
        }
        private void btnNormal_Click(object sender, EventArgs e)
        {
            //crée une instance pour appeller le mode normal du jeu
            Form Mastermind = new Mastermind();

            //affiche l'autre page
            Mastermind.Show();

            //Cache le menu
            this.Hide();
            
        }

        private void QuitGamebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
