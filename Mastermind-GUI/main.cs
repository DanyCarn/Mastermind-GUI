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
        private const int ROWS = 10;
        private const int COLUMNS = 4;
        private const int GUESS_SIZE_X = 40;
        private const int GUESS_SIZE_Y = 40;
        private const int NB_COLORS = 7;
        private const int HINT_SIZE_X = 10;
        private const int HINT_SIZE_Y = 10;

        private int guessRow = 0;
        private int guessCol = 0;
        private int currentColumn = 0;
        private int currentRow = 0;
        private int guessOk = 0;
        private int badPosition = 0;
        private int finalVerificationOk = 0;

        private int[] numberRandom = new int[COLUMNS];
        private Label[,] labelArray = new Label[ROWS, COLUMNS];
        private Label[] labelAnswerArray = new Label[COLUMNS];
        private Color[] goalColors = new Color[COLUMNS];
        private Color[] guessColors = new Color[COLUMNS];
        private Color[] notOk = new Color[COLUMNS];
        private Label[,] hints = new Label[ROWS, COLUMNS];

        public Mastermind()
        {
            InitializeComponent();
            CreateLabelTable(guessLayoutPanel, COLUMNS, ROWS, labelArray);
            DisplayGuessTable(guessLayoutPanel, COLUMNS, ROWS);
            GenerateColor();
            DisplayAnswerTable(layoutPanelAnswer, COLUMNS, ROWS);
            DisplayHintTable(tableLayoutPanelHints, ROWS, COLUMNS);
            ActivateValidateBtn();
        }

        /// <summary>
        /// choisir la couleur à mettre dans l'essai en cours en appuyant sur un bouton de couleur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            if(currentColumn == COLUMNS)
            {
                //Si 4 couleurs ont déja été rentrées, en informe le joueur et lui indique les différentes options à sa disposition 
                MessageBox.Show("Le nombre de couleurs maximum par essai a été atteint.");
            }
            else
            {
                //Change la couleur, dans le tableau affiché, du label suivant qui n'as pas encore de couleur
                Button button = (Button)sender;
                labelArray[currentRow, currentColumn].BackColor = button.BackColor;
                guessColors[currentColumn] = labelArray[currentRow, currentColumn].BackColor;
                currentColumn++;
            }

            //Si le code contient 4 couleurs, active le bouton valider
            ActivateValidateBtn();
        } 

        /// <summary>
        /// Nettoie l'essai de toutes les couleurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            //lorsque le bouton Effacer est cliqué, efface toutes les couleurs du tableau affiché
            for(int i = 0; i < currentColumn; i++)
            {
                labelArray[currentRow, i].BackColor = SystemColors.AppWorkspace;
            }
            currentColumn = 0;
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

        /// <summary>
        /// Génère la tableau qui affiche les essais
        /// </summary>
        private void DisplayGuessTable(TableLayoutPanel layoutPanel, int columns, int rows)
        {
            //crée le tableau affiché au joueur
            layoutPanel.ColumnCount = columns;
            layoutPanel.RowCount = rows;
            layoutPanel.AutoSize = true;
            layoutPanel.RowStyles.Clear();
            layoutPanel.ColumnStyles.Clear();

            //met les labels dans le tableau affiché
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    //crée chaque label
                    Label Guess = new Label();
                    Guess.AutoSize = false;
                    Guess.Size = new Size(GUESS_SIZE_X,GUESS_SIZE_Y);
                    Guess.BorderStyle = BorderStyle.FixedSingle;
                    Guess.Name = "guess" + Convert.ToString(guessRow) + Convert.ToString(guessCol);
                    layoutPanel.Controls.Add(Guess);

                    //place le label dans le tableau de labels
                    labelArray[i, j] = Guess;
                }
            }

            //ajoute les styles pour que le tableau soit bien mis en place
            for(int i = 0; i < rows; i++)
            {
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100/ROWS));
            }

            for(int i = 0; i < columns; i++)
            {
                layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100/COLUMNS));
            }
        }

        /// <summary>
        /// Initialise le tableau qui montrera la réponse à la fin de la partie
        /// </summary>
        /// <param name="answerPanel"></param>
        /// <param name="columns"></param>
        /// <param name="rows"></param>
        private void DisplayAnswerTable(TableLayoutPanel answerPanel,int columns, int rows)
        {
            //crée le tableau affiché qui montrera la réponse
            answerPanel.ColumnCount = columns;
            answerPanel.RowCount = rows;
            answerPanel.AutoSize = true;
            answerPanel.RowStyles.Clear();
            answerPanel.ColumnStyles.Clear();

            for (int i = 0; i < columns; i++)
            {
                //crée chaque label
                Label answer = new Label();
                answer.AutoSize = false;
                answer.Size = new Size(GUESS_SIZE_X, GUESS_SIZE_Y);
                answer.BorderStyle = BorderStyle.FixedSingle;
                answer.Name = "goal" + Convert.ToString(guessRow) + Convert.ToString(guessCol);
                answerPanel.Controls.Add(answer);

                //Place le label dans le tableau
                labelAnswerArray[i] = answer;
            }

            //ajoute les styles pour que le tableau soit bien mis en place
            for (int i = 0; i < rows; i++)
            {
                answerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / ROWS));
            }

            for (int i = 0; i < columns; i++)
            {
                answerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / COLUMNS));
            }
        }

        /// <summary>
        /// Génère le code de couleur aléatoire à trouver
        /// </summary>
        private void GenerateColor()
        {
            //crée un code aléatoire de 4 chiffres puis le traduit en couleurs
            Random randomColor = new Random();
            for(int i = 0; i < COLUMNS; i++)
            {
                numberRandom[i] = randomColor.Next(NB_COLORS - 1);
                SwitchGoalColors(numberRandom[i], i);
            }
        }

        /// <summary>
        /// Switch permettant de traduire les chiffres générés en couleurs pour le code à trouver
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numberPlace"></param>
        private void SwitchGoalColors(int number, int numberPlace)
        {
            for (int i = 0; i < 4; i++)
                switch (number)
                {
                    case 0:
                        goalColors[numberPlace] = Color.Red;
                        break;
                    case 1:
                        goalColors[numberPlace] = Color.Lime;
                        break;
                    case 2:
                        goalColors[numberPlace] = Color.White;
                        break;
                    case 3:
                        goalColors[numberPlace] = Color.Yellow;
                        break;
                    case 4:
                        goalColors[numberPlace] = Color.Blue;
                        break;
                    case 5:
                        goalColors[numberPlace] = Color.Cyan;
                        break;
                    case 6:
                        goalColors[numberPlace] = Color.Magenta;
                        break;
                }

        }

        /// <summary>
        /// Permet de valider l'essai actuel et de passer au prochain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnterTry_Click(object sender, EventArgs e)
        {
            //Compare l'essai du joueur par rapport au code à trouver
            CompareGoalGuess();

            //désactive le bouton Valider après avoir cliqué dessus
            ActivateValidateBtn();

            //Réinitialise le nombre de couleurs trouvées pour le prochain essai
            guessOk = 0;
        }

        /// <summary>
        /// Désactive le bouton Valider tant que le code ne contient pas 4 couleurs
        /// </summary>
        private void ActivateValidateBtn()
        {
            if(currentColumn < 4)
            {
                btnEnterTry.Enabled = false;
            }
            else
            {
                btnEnterTry.Enabled = true;
            }
        }

        /// <summary>
        /// Compare l'essai du joueur au code à trouver
        /// </summary>
        private void CompareGoalGuess()
        {
            //réinitialise les variables qui permettent la vérification
            guessOk = 0;
            badPosition = 0;
            finalVerificationOk = 0;

            //Réinitialise le tableau contenant les indications des couleurs trouvées ou mal placées
            for (int i = 0; i < COLUMNS; i++)
            {
                notOk[i] = Color.Black;
            }

            for (int i = 0; i < COLUMNS; i++)
            {
                if (guessColors[i] == goalColors[i])
                {
                    guessOk++;
                    finalVerificationOk++;
                }

                else
                {
                    for (int j = 0; j < COLUMNS; j++)
                    {
                        if (goalColors[j] == guessColors[i])
                        {
                            if (goalColors[j] != guessColors[j])
                            {
                                notOk[i] = guessColors[i];
                            }
                            else
                            {
                                notOk[i] = Color.Black;
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < COLUMNS; i++)
            {
                if (notOk[i] != Color.Black)
                {
                    badPosition++;
                }

            }

            //affiche les indices
            for(int i = 0; i < COLUMNS; i++)
            {
                if(badPosition != 0)
                {
                    hints[currentRow, i].BackColor = Color.Black;
                    badPosition--;
                }

                else if(guessOk != 0)
                {
                    hints[currentRow, i].BackColor = Color.White;
                    guessOk--;
                }
            }

            //Si 4 couleurs justes ont été trouvées, fini le jeu
            if (finalVerificationOk == 4)
            {
                Form MastermindMenu = new MastermindMenu();
                MessageBox.Show("Bravo vous avez trouvé !");

                //Affiche le menu du jeu 
                MastermindMenu.Show();

                //Ferme la fenêtre de jeu
                this.Hide();
            }

            //Si le nombre d'essais maximum a été atteint, informe le joueur qu'il a perdu
            else if (currentRow == ROWS - 1)
            {
                //Affiche le goal
                for (int i = 0; i < COLUMNS; i++)
                {
                    labelAnswerArray[i].BackColor = goalColors[i];
                }
                //Affiche le message si le joueur a perdu et le renvoie sur la page d'accueil
                MessageBox.Show("Vous avez perdu ! Dommage.");

                Form MastermindMenu = new MastermindMenu();

                //Affiche le menu du jeu 
                MastermindMenu.Show();

                //Ferme la fenêtre de jeu
                this.Hide();

            }

            //réinitialise la couleur actuelle de l'essai et passe à l'essai suivant
            else
            {
                currentRow++;
                currentColumn = 0;
            }           
        }

        /// <summary>
        /// Affiche le tableau qui indiquera les indices 
        /// </summary>
        private void DisplayHintTable(TableLayoutPanel panel, int rows, int columns)
        {
            //crée le tableau affiché qui montrera les indices
            panel.ColumnCount = columns;
            panel.RowCount = rows;
            panel.AutoSize = true;
            panel.RowStyles.Clear();
            panel.ColumnStyles.Clear();

            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    //crée chaque label
                    Label hint = new Label();
                    hint.AutoSize = false;
                    hint.Size = new Size(HINT_SIZE_X, HINT_SIZE_Y);
                    hint.Anchor = AnchorStyles.None;
                    hint.BorderStyle = BorderStyle.FixedSingle;
                    hint.Name = "hint" + Convert.ToString(guessRow) + Convert.ToString(guessCol);

                    //insère le label d'indice créé dans le tableau d'indices
                    hints[i, j] = hint;
                    panel.Controls.Add(hint);
                }
            }

            //ajoute les styles pour que le tableau soit bien mis en place
            for (int i = 0; i < rows; i++)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / ROWS));
            }

            for (int i = 0; i < columns; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / COLUMNS));
            }
        }


        /// <summary>
        /// permet d'afficher le code lors du déboguage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDebug.Checked)
            {
                for(int i = 0; i < COLUMNS; i++)
                {
                    labelAnswerArray[i].BackColor = goalColors[i];
                }
            }
        }

        private void CreateLabelTable(TableLayoutPanel panel, int columns, int rows, Label[,] array)
        {
            //crée le tableau affiché qui montrera la réponse
            panel.ColumnCount = columns;
            panel.RowCount = rows;
            panel.AutoSize = true;
            panel.RowStyles.Clear();
            panel.ColumnStyles.Clear();

            for (int i = 0; i < columns; i++)
            {
                //crée chaque label
                Label label = new Label();
                label.AutoSize = false;
                label.Size = new Size(GUESS_SIZE_X, GUESS_SIZE_Y);
                label.BorderStyle = BorderStyle.FixedSingle;
                label.Name = "goal" + Convert.ToString(guessRow) + Convert.ToString(guessCol);
                label.Controls.Add(label);

                //Place le label dans le tableau
                array[i] = label;
            }

            //ajoute les styles pour que le tableau soit bien mis en place
            for (int i = 0; i < rows; i++)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / ROWS));
            }

            for (int i = 0; i < columns; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / COLUMNS));
            }
        }
    }
}
