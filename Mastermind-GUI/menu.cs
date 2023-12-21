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
        #region Forms
        //le form du jeu
        Mastermind game;
        #endregion

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
            //Message de bienvenue au jeu qui explique les règles
            lblWelcome.Text = "Bienvenue au Mastermind \n" +
                "Dans ce jeu, vous devez trouver le code caché de quatre couleurs en moins de 10 essais.\n" +
                "Bonne Chance ! \n";
        }


        /// <summary>
        /// quitte le jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitGamebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Affiche la fenêtre de jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            game = new Mastermind();
            //affiche l'autre page
            game.Show();

            //Cache le menu
            this.Hide();

        }
    }
}
