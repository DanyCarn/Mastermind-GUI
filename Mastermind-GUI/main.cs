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
        //page de choix des options pour changer la difficulté
        changeDifficulty _difficulty;
        //page de menu
        MastermindMenu _menu;
        #endregion

        #region const
        //valeur par défaut des lignes et colonnes
        private const int DEFAULT_ROWS = 10;
        private const int DEFAULT_COLUMNS = 4;
        //Taille des boutons et des labels
        private const int SIZE_X = 40;
        private const int SIZE_Y = 40;
        //nombre de couleurs
        private const int NB_COLORS = 7;
        //taille des indices
        private const int HINT_SIZE_X = 10;
        private const int HINT_SIZE_Y = 10;
        #endregion

        #region bool
        //permet de savoir si l'on souhaite la langue en anglais ou en français
        private bool _english = false;
        //permet de savoir si le joueur veut les répétitions de couleurs ou pas
        public bool repetitionColors = true;
        //permet de savoir si un chiffre du code a déja été généré
        private bool _alreadyChecked = false;
        #endregion

        #region int
        //nombre d'essais
        private int _rows = DEFAULT_ROWS;
        //longueur du code
        public int columns = DEFAULT_COLUMNS;
        //la colonne où le joueur choisis la couleur
        private int _currentColumn = 0;
        //l'essai actuel
        private int _currentRow = 0;
        //nombre de couleurs trouvées. Sert à afficher les indices
        private int _hintOk = 0;
        //nombre de couleurs mal placées. Sert à afficher les indices
        private int _badPosition = 0;
        //nre de couleurs trouvées. Sert à savoir si le joueur a gagné
        private int _finalVerificationOk = 0;
        #endregion

        #region string
        //message de réussite
        private string _victoryMessage = "Bravo vous avez trouvé !";
        //message d'échec
        private string _loseMessage = "Vous avez perdu ! Dommage...";
        //message qui indique que le nombre max de couleurs a été rentré
        private string _maxColorsMessage = "Le nombre de couleurs maximum par essai a été atteint.";
        #endregion

        #region array
        //les nombres générés aléatoirement pour avoir les couleurs à trouver
        private int[] _numberRandom = new int[DEFAULT_COLUMNS];
        //labels qui affichent les essais des joueurs
        private Label[,] _labelArray = new Label[DEFAULT_ROWS, DEFAULT_COLUMNS];
        //labels qui affichent la réponse
        private Label[] _labelAnswerArray = new Label[DEFAULT_COLUMNS];
        //Les couleurs du code à trouver
        private Color[] _goalColors = new Color[DEFAULT_COLUMNS];
        //les couleurs de l'essai du joueur
        private Color[] _guessColors = new Color[DEFAULT_COLUMNS];
        //les couleurs qui servent à la vérification du joueur pour savoir si des couleurs sont mal placées
        private Color[] _notOk = new Color[DEFAULT_COLUMNS];
        //labels des indices 
        private Label[,] _hints = new Label[DEFAULT_ROWS, DEFAULT_COLUMNS];
        //les nombres déjà générés lors de la création du code. Permet d'empêcher les répétitions de couleurs
        private int[] _alreadyCheckedColors = new int[DEFAULT_COLUMNS];
        //tableau contenant les couleurs jouables
        private Color[] _Colors = new Color[] { Color.Red,Color.Blue,Color.Yellow,Color.Lime,Color.White,Color.Cyan,Color.Magenta };
        #endregion

        public Mastermind()
        {
            InitializeComponent();
            _difficulty = new changeDifficulty(this);
            _menu = new MastermindMenu();
            DisplayGuessTable(layoutPanelGuess, columns, _rows);
            GenerateColor();
            DisplayAnswerTable(layoutPanelAnswer, columns, _rows);
            DisplayHintTable(tableLayoutPanelHints, _rows, columns);
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
            if(_currentColumn == columns)
            {
                //Si 4 couleurs ont déja été rentrées, en informe le joueur et lui indique les différentes options à sa disposition 
                MessageBox.Show(_maxColorsMessage);
            }
            else
            {
                //Change la couleur, dans le tableau affiché, du label suivant qui n'as pas encore de couleur
                Button button = (Button)sender;
                _labelArray[_currentRow, _currentColumn].BackColor = button.BackColor;
                _guessColors[_currentColumn] = _labelArray[_currentRow, _currentColumn].BackColor;
                _currentColumn++;
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
            for(int i = 0; i < _currentColumn; i++)
            {
                _labelArray[_currentRow, i].BackColor = SystemColors.AppWorkspace;
            }
            _currentColumn = 0;
        }


        /// <summary>
        /// Quitte le jeu et revient au menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            //affiche le menu
            _menu.Show();

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
                    layoutPanel.Controls.Add(Guess);

                    //place le label dans le tableau de labels
                    _labelArray[i, j] = Guess;
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
        private void DisplayAnswerTable(TableLayoutPanel answerPanel, int columns, int rows)
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
                answerPanel.Controls.Add(answer);

                //Place le label dans le tableau
                _labelAnswerArray[i] = answer;
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
                    _numberRandom[i] = randomColor.Next(NB_COLORS - 1);
                    SwitchGoalColors(_numberRandom[i], i);
                }

                //si le nombre a déja été généré, recommence une génlration de chiffre
                else if(repetitionColors == false)
                {
                    do
                    {
                        _alreadyChecked = false;
                        _numberRandom[i] = randomColor.Next(NB_COLORS - 1);

                        for (int j = 0; j < columns; j++)
                        {
                            if (_alreadyCheckedColors[j] == _numberRandom[i])
                            {
                                _alreadyChecked = true;
                            }
                        }
                    } while (_alreadyChecked == true);

                    //insère le chiffre généré dans le tableau des chiffres déja générés
                    _alreadyCheckedColors[i] = _numberRandom[i];
                    SwitchGoalColors(_numberRandom[i], i);

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
            //Désigne la couleur obtenue en fonction du chiffre généré aléatoirement
            switch (number)
            {
                case 0:
                    _goalColors[numberPlace] = Color.Red;
                    break;
                case 1:
                    _goalColors[numberPlace] = Color.Lime;
                    break;
                case 2:
                    _goalColors[numberPlace] = Color.White;
                    break;
                case 3:
                    _goalColors[numberPlace] = Color.Yellow;
                    break;
                case 4:
                    _goalColors[numberPlace] = Color.Blue;
                    break;
                case 5:
                    _goalColors[numberPlace] = Color.Cyan;
                    break;
                case 6:
                    _goalColors[numberPlace] = Color.Magenta;
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
            _hintOk = 0;
        }


        /// <summary>
        /// Désactive le bouton Valider tant que le code ne contient pas 4 couleurs
        /// </summary>
        private void ActivateValidateBtn()
        {
            //active le bouton valider si les quatre couleurs on été rentrées
            if(_currentColumn < columns)
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
            _hintOk = 0;
            _badPosition = 0;
            _finalVerificationOk = 0;

            //Réinitialise le tableau contenant les indications des couleurs trouvées ou mal placées
            for (int i = 0; i < columns; i++)
            {
                _notOk[i] = Color.Black;
            }

            for (int i = 0; i < columns; i++)
            {
                //si la couleur est juste, augmente le nombre des indices à mettre et le compteur de couleurs trouvées
                if (_guessColors[i] == _goalColors[i])
                {
                    _hintOk++;
                    _finalVerificationOk++;
                }

                else
                {

                    //parcours le goal et le compare au guess afin de trouver des couleurs mal placées
                    for (int j = 0; j < columns; j++)
                    {
                        if (_goalColors[j] == _guessColors[i])
                        {
                            //si un couleur est mal placée et qu'elle n'est pas également placée au bon endroit plus loin dans le guess, change la couleur du notOk pour pouvoir avoir le compte des mal placés
                            if (_goalColors[j] != _guessColors[j])
                            {
                                _notOk[i] = Color.Red;
                            }
                        }
                    }
                }
            }

            //pour chaque couleur rouge dans le tableau notOk,augmente le compteur bad position pour mettre les indices de mal placé
            for (int i = 0; i < columns; i++)
            {
                if (_notOk[i] == Color.Red)
                {
                    _badPosition++;
                }

            }

            //affiche les indices
            for(int i = 0; i < columns; i++)
            {
                if(_badPosition > 0)
                {
                    _hints[_currentRow, i].BackColor = Color.Black;
                    _badPosition--;
                }

                else if(_hintOk != 0)
                {
                    _hints[_currentRow, i].BackColor = Color.White;
                    _hintOk--;
                }
            }

            //Si 4 couleurs justes ont été trouvées, fini le jeu
            if (_finalVerificationOk == columns)
            {
                //instancie le menu 
                Form MastermindMenu = new MastermindMenu();

                //affiche le message de réussite
                MessageBox.Show(_victoryMessage);
            }

            //Si le nombre d'essais maximum a été atteint, informe le joueur qu'il a perdu
            else if (_currentRow == _rows - 1)
            {
                //Affiche le goal
                for (int i = 0; i < columns; i++)
                {
                    _labelAnswerArray[i].BackColor = _goalColors[i];
                }
                //Affiche le message si le joueur a perdu et le renvoie sur la page d'accueil
                MessageBox.Show(_loseMessage);

            }

            //réinitialise la couleur actuelle de l'essai et passe à l'essai suivant
            else
            {
                _currentRow++;
                _currentColumn = 0;
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
                    //crée chaque label avec ses paramètres
                    Label hint = new Label();
                    {
                        hint.AutoSize = false;
                        hint.Size = new Size(HINT_SIZE_X, HINT_SIZE_Y);
                        hint.Anchor = AnchorStyles.None;
                        hint.BorderStyle = BorderStyle.FixedSingle;
                    }

                    //insère le label d'indice créé dans le tableau d'indices
                    _hints[i, j] = hint;
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
                    _labelAnswerArray[i].BackColor = _goalColors[i];
                }
            }
            else
            {
                for(int i = 0; i < columns; i++)
                {
                    _labelAnswerArray[i].BackColor = SystemColors.ActiveCaption;
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
            _english = true;
            ChangeLanguage();
        }


        /// <summary>
        /// Change le booléen de l'anglais lorsque le joueur appuie sur "English"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void françaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _english = false;
            ChangeLanguage();
        }


        /// <summary>
        /// Change la langue du jeu
        /// </summary>
        private void ChangeLanguage()
        {
            if(_english)
            {
                langueToolStripMenuItemLanguage.Text = "Language";
                btnEnterTry.Text = "Validate";
                btnClear.Text = "Clear";
                btnQuit.Text = "Return to menu";
                _loseMessage = "You lost ! Take the L.";
                _victoryMessage = "Well done, you won !";
                _maxColorsMessage = "Maximum of colors reached.";
                btnRetry.Text = "Retry";
            }
            else
            {
                langueToolStripMenuItemLanguage.Text = "Langue";
                btnEnterTry.Text = "Valider";
                btnClear.Text = "Effacer";
                btnQuit.Text = "Retour au Menu";
                _loseMessage = "Vous avez perdu ! Pfff la loose !";
                _victoryMessage = "Bravo vous avez trouvé !";
                _maxColorsMessage = "Le nombre de couleurs maximum par essai a été atteint.";
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
            _currentColumn = 0;
            _currentRow = 0;
            _numberRandom = new int[columns];
            _labelArray = new Label[_rows, columns];
            _labelAnswerArray = new Label[columns];
            _goalColors = new Color[columns];
            _guessColors = new Color[columns];
            _notOk = new Color[columns];
            _hints = new Label[_rows, columns];
            _alreadyCheckedColors = new int[columns];

            //appelle les fonctions pour réafficher les labels
            GenerateColor();
            DisplayGuessTable(layoutPanelGuess, columns, _rows);
            DisplayHintTable(tableLayoutPanelHints, _rows, columns);
            DisplayAnswerTable(layoutPanelAnswer, columns, _rows);
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
                button.BackColor = _Colors[i];
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
            _difficulty.Show();
        }
    }
}
