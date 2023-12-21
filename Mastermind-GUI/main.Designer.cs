namespace Mastermind_GUI
{
    partial class Mastermind
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEnterTry = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.layoutPanelGuess = new System.Windows.Forms.TableLayoutPanel();
            this.layoutPanelAnswer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHints = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxDebug = new System.Windows.Forms.CheckBox();
            this.menuStripGame = new System.Windows.Forms.MenuStrip();
            this.langueToolStripMenuItemLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.françaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRetry = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.menuStripGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnterTry
            // 
            this.btnEnterTry.Location = new System.Drawing.Point(16, 419);
            this.btnEnterTry.Name = "btnEnterTry";
            this.btnEnterTry.Size = new System.Drawing.Size(93, 27);
            this.btnEnterTry.TabIndex = 18;
            this.btnEnterTry.Text = "Valider";
            this.btnEnterTry.UseVisualStyleBackColor = true;
            this.btnEnterTry.Click += new System.EventHandler(this.btnEnterTry_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(17, 452);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(92, 27);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Effacer";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(16, 553);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(113, 27);
            this.btnQuit.TabIndex = 21;
            this.btnQuit.Text = "Retour au Menu";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // layoutPanelGuess
            // 
            this.layoutPanelGuess.ColumnCount = 1;
            this.layoutPanelGuess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanelGuess.Location = new System.Drawing.Point(255, 39);
            this.layoutPanelGuess.Name = "layoutPanelGuess";
            this.layoutPanelGuess.RowCount = 1;
            this.layoutPanelGuess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanelGuess.Size = new System.Drawing.Size(286, 440);
            this.layoutPanelGuess.TabIndex = 26;
            // 
            // layoutPanelAnswer
            // 
            this.layoutPanelAnswer.ColumnCount = 1;
            this.layoutPanelAnswer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanelAnswer.Location = new System.Drawing.Point(255, 525);
            this.layoutPanelAnswer.Name = "layoutPanelAnswer";
            this.layoutPanelAnswer.RowCount = 1;
            this.layoutPanelAnswer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanelAnswer.Size = new System.Drawing.Size(286, 66);
            this.layoutPanelAnswer.TabIndex = 27;
            // 
            // tableLayoutPanelHints
            // 
            this.tableLayoutPanelHints.ColumnCount = 1;
            this.tableLayoutPanelHints.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHints.Location = new System.Drawing.Point(128, 39);
            this.tableLayoutPanelHints.Name = "tableLayoutPanelHints";
            this.tableLayoutPanelHints.RowCount = 1;
            this.tableLayoutPanelHints.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelHints.Size = new System.Drawing.Size(121, 440);
            this.tableLayoutPanelHints.TabIndex = 28;
            // 
            // checkBoxDebug
            // 
            this.checkBoxDebug.AutoSize = true;
            this.checkBoxDebug.Location = new System.Drawing.Point(485, 502);
            this.checkBoxDebug.Name = "checkBoxDebug";
            this.checkBoxDebug.Size = new System.Drawing.Size(56, 17);
            this.checkBoxDebug.TabIndex = 29;
            this.checkBoxDebug.Text = "debug";
            this.checkBoxDebug.UseVisualStyleBackColor = true;
            this.checkBoxDebug.CheckedChanged += new System.EventHandler(this.checkBoxDebug_CheckedChanged);
            // 
            // menuStripGame
            // 
            this.menuStripGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.langueToolStripMenuItemLanguage,
            this.difficultéToolStripMenuItem});
            this.menuStripGame.Location = new System.Drawing.Point(0, 0);
            this.menuStripGame.Name = "menuStripGame";
            this.menuStripGame.Size = new System.Drawing.Size(553, 24);
            this.menuStripGame.TabIndex = 30;
            this.menuStripGame.Text = "menuStrip1";
            // 
            // langueToolStripMenuItemLanguage
            // 
            this.langueToolStripMenuItemLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.françaisToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.langueToolStripMenuItemLanguage.Name = "langueToolStripMenuItemLanguage";
            this.langueToolStripMenuItemLanguage.Size = new System.Drawing.Size(58, 20);
            this.langueToolStripMenuItemLanguage.Text = "Langue";
            // 
            // françaisToolStripMenuItem
            // 
            this.françaisToolStripMenuItem.Name = "françaisToolStripMenuItem";
            this.françaisToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.françaisToolStripMenuItem.Text = "Français";
            this.françaisToolStripMenuItem.Click += new System.EventHandler(this.françaisToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // difficultéToolStripMenuItem
            // 
            this.difficultéToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.difficultéToolStripMenuItem.Name = "difficultéToolStripMenuItem";
            this.difficultéToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.difficultéToolStripMenuItem.Text = "Difficulté";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.Location = new System.Drawing.Point(136, 553);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(113, 27);
            this.btnRetry.TabIndex = 31;
            this.btnRetry.Text = "Recommencer";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(42, 39);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(67, 374);
            this.pnlButtons.TabIndex = 32;
            // 
            // Mastermind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(553, 603);
            this.Controls.Add(this.checkBoxDebug);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.tableLayoutPanelHints);
            this.Controls.Add(this.layoutPanelAnswer);
            this.Controls.Add(this.layoutPanelGuess);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnEnterTry);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.menuStripGame);
            this.Name = "Mastermind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mastermind";
            this.menuStripGame.ResumeLayout(false);
            this.menuStripGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEnterTry;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TableLayoutPanel layoutPanelGuess;
        private System.Windows.Forms.TableLayoutPanel layoutPanelAnswer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHints;
        private System.Windows.Forms.CheckBox checkBoxDebug;
        private System.Windows.Forms.MenuStrip menuStripGame;
        private System.Windows.Forms.ToolStripMenuItem langueToolStripMenuItemLanguage;
        private System.Windows.Forms.ToolStripMenuItem françaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficultéToolStripMenuItem;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

