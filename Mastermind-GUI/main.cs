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
/// Date 16.11.2023
/// Description : Page de jeu du mastermind où l'utilisateur va jouer

namespace Mastermind_GUI
{
    public partial class Mastermind : Form
    {
        public Mastermind()
        {
            InitializeComponent();
        }

        /// <summary>
        /// choisir la couleur à mettre dans le premier carré en appuyant sur un bouton de couleur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            lblInput01.BackColor = button.BackColor;
        } 

        /// <summary>
        /// Nettoie l'essai de toutes les couleurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblInput01.BackColor = SystemColors.ControlLight;
        }
        /// <summary>
        /// Quitte le jeu et revient au menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            //crée l'instance pour le menu du mastermind
            Form MastermindMenu = new MastermindMenu();

            //affiche le menu
            MastermindMenu.Show();

            //cache cette page
            this.Close();

        }

    }
}
