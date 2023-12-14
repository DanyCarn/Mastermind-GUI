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
        #region forms
        changeDifficulty difficulty;
        MastermindMenu menu;
        #endregion

        #region const
        private const int DEFAULT_ROWS = 10;
        private const int DEFAULT_COLUMNS = 4;
        //Taille des boutons et des labels
        private const int SIZE_X = 40;
        private const int SIZE_Y = 40;
        private const int NB_COLORS = 7;
        private const int HINT_SIZE_X = 10;
        private const int HINT_SIZE_Y = 10;
        #endregion

        #region bool
        private bool english = false;
        //permet de savoir si le joueur veut les répétitions de couleurs ou pas
        public bool repetitionColors = true;
        //permet de savoir si un chiffre du code a déja été généré
        private bool alreadyChecked = false;
        #endregion

        #region int
        public int rows = DEFAULT_ROWS;
        public int columns = DEFAULT_COLUMNS;
        private int guessRow = 0;
        private int guessCol = 0;
        private int currentColumn = 0;
        private int currentRow = 0;
        private int hintOk = 0;
        private int badPosition = 0;
        private int finalVerificationOk = 0;
        #endregion

        #region string
        //message de réussite
        private string victoryMessage = "Bravo vous avez trouvé !";
        //message d'échec
        private string loseMessage = "Vous avez perdu ! Dommage...";
        //message qui indique que le nombre max de couleurs a été rentré
        private string maxColorsMessage = "Le nombre de couleurs maximum par essai a été atteint.";
        #endregion

        #region array
        private int[] numberRandom = new int[DEFAULT_COLUMNS];
        private Label[,] labelArray = new Label[DEFAULT_ROWS, DEFAULT_COLUMNS];
        private Label[] labelAnswerArray = new Label[DEFAULT_COLUMNS];
        private Color[] goalColors = new Color[DEFAULT_COLUMNS];
        private Color[] guessColors = new Color[DEFAULT_COLUMNS];
        private Color[] notOk = new Color[DEFAULT_COLUMNS];
        private Label[,] hints = new Label[DEFAULT_ROWS, DEFAULT_COLUMNS];
        private int[] alreadyCheckedColors = new int[DEFAULT_COLUMNS];
        //tableau contenant les couleurs jouables
        private Color[] Colors = new Color[] { Color.Red,Color.Blue,Color.Yellow,Color.Lime,Color.White,Color.Cyan,Color.Magenta };
        #endregion

        public Mastermind()
        {
            InitializeComponent();
            difficulty = new changeDifficulty(this);
            menu = new MastermindMenu();
            DisplayGuessTable(layoutPanelGuess, columns, rows);
            GenerateColor();
            DisplayAnswerTable(layoutPanelAnswer, columns, rows);
            DisplayHintTable(tableLayoutPanelHints, rows, columns);
            DisplayColorButtons();
            ActivateValidateBtn();
        }

        /// <summary>
        /// choisir la couleur à mettre dans l'essai en cours en appuyant sur un bouton de couleur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            if(currentColumn == columns)
            {
                //Si 4 couleurs ont déja été rentrées, en informe le joueur et lui indique les différentes options à sa disposition 
                MessageBox.Show(maxColorsMessage);
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
                labelArray[currentRow, i].BackColor = SystemColors.ActiveCaption;
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
            //affiche le menu
            menu.Show();

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
                    Guess.Size = new Size(SIZE_X,SIZE_Y);
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
                layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100/ rows));
            }

            for(int i = 0; i < columns; i++)
            {
                layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100/columns));
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
                answer.Size = new Size(SIZE_X, SIZE_Y);
                answer.BorderStyle = BorderStyle.FixedSingle;
                answer.Name = "goal" + Convert.ToString(guessRow) + Convert.ToString(guessCol);
                answerPanel.Controls.Add(answer);

                //Place le label dans le tableau
                labelAnswerArray[i] = answer;
            }

            //ajoute les styles pour que le tableau soit bien mis en place
            for (int i = 0; i < rows; i++)
            {
                answerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / rows));
            }

            for (int i = 0; i < columns; i++)
            {
                answerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / columns));
            }
        }


        /// <summary>
        /// Génère le code de couleur aléatoire à trouver
        /// </summary>
        private void GenerateColor()
        {
            //crée un code aléatoire de 4 chiffres puis le traduit en couleurs
            Random randomColor = new Random();
            for(int i = 0; i < columns; i++)
            {
                if(repetitionColors == true)
                {
                    numberRandom[i] = randomColor.Next(NB_COLORS - 1);
                    SwitchGoalColors(numberRandom[i], i);
                }

                //si le nombre a déja été généré, recommence une génlration de chiffre
                else if(repetitionColors == false)
                {
                    do
                    {
                        alreadyChecked = false;
                        numberRandom[i] = randomColor.Next(NB_COLORS - 1);

                        for (int j = 0; j < columns; j++)
                        {
                            if (alreadyCheckedColors[j] == numberRandom[i])
                            {
                                alreadyChecked = true;
                            }
                        }
                    } while (alreadyChecked == true);

                    //insère le chiffre généré dans le tableau des chiffres déja générés
                    alreadyCheckedColors[i] = numberRandom[i];
                    SwitchGoalColors(numberRandom[i], i);

                }
            }
        }


        /// <summary>
        /// Switch permettant de traduire les chiffres générés en couleurs pour le code à trouver
        /// </summary>
        /// <param name="number">nombre généré aléatoirement</param>
        /// <param name="numberPlace">emplacement de la couleur dans le code</param>
        private void SwitchGoalColors(int number, int numberPlace)
        {
            //Désigne la couleur obtenue selon le chiffre généré aléatoirement
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
            hintOk = 0;
        }


        /// <summary>
        /// Désactive le bouton Valider tant que le code ne contient pas 4 couleurs
        /// </summary>
        private void ActivateValidateBtn()
        {
            //active le bouton valider si les quatre couleurs on été rentrées
            if(currentColumn < columns)
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
            hintOk = 0;
            badPosition = 0;
            finalVerificationOk = 0;

            //Réinitialise le tableau contenant les indications des couleurs trouvées ou mal placées
            for (int i = 0; i < columns; i++)
            {
                notOk[i] = Color.Black;
            }

            for (int i = 0; i < columns; i++)
            {
                //si la couleur est juste, augmente le nombre des indices à mettre et le compteur de couleurs trouvées
                if (guessColors[i] == goalColors[i])
                {
                    hintOk++;
                    finalVerificationOk++;
                }

                else
                {

                    //parcours le goal et le compare au guess afin de trouver des couleurs mal placées
                    for (int j = 0; j < columns; j++)
                    {
                        if (goalColors[j] == guessColors[i])
                        {
                            //si un couleur est mal placée et qu'elle n'est pas également placée au bon endroit plus loin dans le guess, change la couleur du notOk pour pouvoir avoir le compte des mal placés
                            if (goalColors[j] != guessColors[j])
                            {
                                notOk[i] = Color.Red;
                            }
                        }
                    }
                }
            }

            //pour chaque couleur rouge dans le tableau notOk,augmente le compteur bad position pour mettre les indices de mal placé
            for (int i = 0; i < columns; i++)
            {
                if (notOk[i] == Color.Red)
                {
                    badPosition++;
                }

            }

            //affiche les indices
            for(int i = 0; i < columns; i++)
            {
                if(badPosition > 0)
                {
                    hints[currentRow, i].BackColor = Color.Black;
                    badPosition--;
                }

                else if(hintOk != 0)
                {
                    hints[currentRow, i].BackColor = Color.White;
                    hintOk--;
                }
            }

            //Si 4 couleurs justes ont été trouvées, fini le jeu
            if (finalVerificationOk == columns)
            {
                //instancie le menu 
                Form MastermindMenu = new MastermindMenu();

                //affiche le message de réussite
                MessageBox.Show(victoryMessage);
            }

            //Si le nombre d'essais maximum a été atteint, informe le joueur qu'il a perdu
            else if (currentRow == rows - 1)
            {
                //Affiche le goal
                for (int i = 0; i < columns; i++)
                {
                    labelAnswerArray[i].BackColor = goalColors[i];
                }
                //Affiche le message si le joueur a perdu et le renvoie sur la page d'accueil
                MessageBox.Show(loseMessage);

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
        /// <param name="panel">panneau dans lequel créer les labels</param>
        /// <param name="rows">nombre de lignes</param>
        /// <param name="columns">nombre de colonnes</param>
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
                    {
                        hint.AutoSize = false;
                        hint.Size = new Size(HINT_SIZE_X, HINT_SIZE_Y);
                        hint.Anchor = AnchorStyles.None;
                        hint.BorderStyle = BorderStyle.FixedSingle;
                        hint.Name = "hint" + Convert.ToString(guessRow) + Convert.ToString(guessCol);
                    }

                    //insère le label d'indice créé dans le tableau d'indices
                    hints[i, j] = hint;
                    panel.Controls.Add(hint);
                }
            }

            //ajoute les styles pour que le tableau soit bien mis en place
            for (int i = 0; i < rows; i++)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / rows));
            }

            for (int i = 0; i < columns; i++)
            {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / columns));
            }
        }


        /// <summary>
        /// permet d'afficher le code lors du déboguage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxDebug_CheckedChanged(object sender, EventArgs e)
        {
            //si la checkbox est cochée, affiche le code secret
            if (checkBoxDebug.Checked)
            {
                for(int i = 0; i < columns; i++)
                {
                    labelAnswerArray[i].BackColor = goalColors[i];
                }
            }
            else
            {
                for(int i = 0; i < columns; i++)
                {
                    labelAnswerArray[i].BackColor = SystemColors.ActiveCaption;
                }
            }
        }


        /// <summary>
        /// Change le booléen de l'anglais lorsque le joueur appuie sur "English"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            english = true;
            ChangeLanguage();
        }


        /// <summary>
        /// Change le booléen de l'anglais lorsque le joueur appuie sur "English"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void françaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            english = false;
            ChangeLanguage();
        }


        /// <summary>
        /// Change la langue du jeu
        /// </summary>
        private void ChangeLanguage()
        {
            if(english == true)
            {
                langueToolStripMenuItemLanguage.Text = "Language";
                btnEnterTry.Text = "Validate";
                btnClear.Text = "Clear";
                btnQuit.Text = "Return to menu";
                loseMessage = "You lost ! Take the L.";
                victoryMessage = "Well done, you won !";
                maxColorsMessage = "Maximum of colors reached.";
                btnRetry.Text = "Retry";
            }
            else
            {
                langueToolStripMenuItemLanguage.Text = "Langue";
                btnEnterTry.Text = "Valider";
                btnClear.Text = "Effacer";
                btnQuit.Text = "Retour au Menu";
                loseMessage = "Vous avez perdu ! Pfff la loose !";
                victoryMessage = "Bravo vous avez trouvé !";
                maxColorsMessage = "Le nombre de couleurs maximum par essai a été atteint.";
                btnRetry.Text = "Recommencer";
            }
        }


        /// <summary>
        /// Réinitialise le tableau de jeu
        /// </summary>
        public void ResetAll()
        {
            //réinitialise tous ce qu'il faut pour recommencer une partie
            layoutPanelGuess.Controls.Clear();
            tableLayoutPanelHints.Controls.Clear();
            layoutPanelAnswer.Controls.Clear();
            guessRow = 0;
            guessCol = 0;
            currentColumn = 0;
            currentRow = 0;
            int[] numberRandom = new int[columns];
            Label[,] labelArray = new Label[rows, columns];
            Label[] labelAnswerArray = new Label[columns];
            Color[] goalColors = new Color[columns];
            Color[] guessColors = new Color[columns];
            Color[] notOk = new Color[columns];
            Label[,] hints = new Label[rows, columns];
            int[] alreadyCheckedColors = new int[columns];
            GenerateColor();
            DisplayGuessTable(layoutPanelGuess, columns, rows);
            DisplayHintTable(tableLayoutPanelHints, rows, columns);
            DisplayAnswerTable(layoutPanelAnswer, columns, rows);
        }


        /// <summary>
        /// Bouton permettant de recommencer une partie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetry_Click(object sender, EventArgs e)
        {
            ResetAll();
        }


        /// <summary>
        /// Affiche les boutons qui servent à choisir les couleurs
        /// </summary>
        private void DisplayColorButtons()
        {
            for(int i = 0; i < NB_COLORS; i++)
            {
                //Instancie le nouveau bouton
                Button button = new Button();

                //les paramètres des boutons
                button.BackColor = Colors[i];
                button.Size = new Size(SIZE_X, SIZE_Y);
                button.Location = new Point(0, (pnlButtons.Height / NB_COLORS)*i);
                button.Click += new EventHandler(btn_Click);

                //Ajoute le bouton au panel des boutons
                pnlButtons.Controls.Add(button);
            }
        }


        /// <summary>
        /// Ouvre la page qui permet de modifier les paramètres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty.Show();
        }
    }
}
