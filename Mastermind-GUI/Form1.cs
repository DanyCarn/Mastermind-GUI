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
/// Date : 14.12.2023
/// Description : Page des options du mastermind permettant de choisir le mode facile ou le mode normal
namespace Mastermind_GUI
{
    public partial class changeDifficulty : Form
    {
        #region Forms
        //le form du jeu
        Mastermind game;
        #endregion

        public changeDifficulty(Mastermind game)
        {
            InitializeComponent();
            this.game = game;

            //insère les valeurs de colonnes et lignes actuelles
            numericUpDownColumns.Value = game.columns;
        }

        /// <summary>
        /// Valide les options choisies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValidate_Click(object sender, EventArgs e)
        {
            //affecte le nombre choisi par l'utilisateur aux colonnes et lignes du jeu
            game.columns = Convert.ToInt32(numericUpDownColumns.Value);

            //reset la partie pour pouvoir mettre à jour
            game.ResetAll();
            this.Hide();
        }

        /// <summary>
        /// permet de choisir si on souhaite la répétition des couleurs dans le code aléatoire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkRepetition_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRepetition.Checked)
            {
                game.repetitionColors = true;
            }
            else
            {
                game.repetitionColors = false;
            }
        }

        /// <summary>
        /// n'enregistre aucune modification et ferme la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
