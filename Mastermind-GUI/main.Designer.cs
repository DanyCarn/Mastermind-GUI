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
            this.btnMagenta = new System.Windows.Forms.Button();
            this.btnCyan = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnYellow = new System.Windows.Forms.Button();
            this.btnWhite = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.guessLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.layoutPanelAnswer = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHints = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxDebug = new System.Windows.Forms.CheckBox();
            this.menuStripGame = new System.Windows.Forms.MenuStrip();
            this.langueToolStripMenuItemLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.françaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnterTry
            // 
            this.btnEnterTry.Location = new System.Drawing.Point(17, 369);
            this.btnEnterTry.Name = "btnEnterTry";
            this.btnEnterTry.Size = new System.Drawing.Size(93, 27);
            this.btnEnterTry.TabIndex = 18;
            this.btnEnterTry.Text = "Valider";
            this.btnEnterTry.UseVisualStyleBackColor = true;
            this.btnEnterTry.Click += new System.EventHandler(this.btnEnterTry_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(18, 421);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(92, 27);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Effacer";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnMagenta
            // 
            this.btnMagenta.BackColor = System.Drawing.Color.Magenta;
            this.btnMagenta.Location = new System.Drawing.Point(16, 180);
            this.btnMagenta.Name = "btnMagenta";
            this.btnMagenta.Size = new System.Drawing.Size(43, 43);
            this.btnMagenta.TabIndex = 16;
            this.btnMagenta.UseVisualStyleBackColor = false;
            this.btnMagenta.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCyan
            // 
            this.btnCyan.BackColor = System.Drawing.Color.Cyan;
            this.btnCyan.Location = new System.Drawing.Point(66, 133);
            this.btnCyan.Name = "btnCyan";
            this.btnCyan.Size = new System.Drawing.Size(44, 43);
            this.btnCyan.TabIndex = 15;
            this.btnCyan.UseVisualStyleBackColor = false;
            this.btnCyan.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.Location = new System.Drawing.Point(16, 133);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(45, 43);
            this.btnBlue.TabIndex = 14;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Yellow;
            this.btnYellow.Location = new System.Drawing.Point(66, 86);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(44, 43);
            this.btnYellow.TabIndex = 13;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnWhite
            // 
            this.btnWhite.BackColor = System.Drawing.Color.White;
            this.btnWhite.Location = new System.Drawing.Point(17, 86);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(43, 43);
            this.btnWhite.TabIndex = 12;
            this.btnWhite.UseVisualStyleBackColor = false;
            this.btnWhite.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.Lime;
            this.btnGreen.Location = new System.Drawing.Point(66, 39);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(43, 43);
            this.btnGreen.TabIndex = 11;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.Location = new System.Drawing.Point(17, 39);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(43, 43);
            this.btnRed.TabIndex = 10;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(16, 564);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(113, 27);
            this.btnQuit.TabIndex = 21;
            this.btnQuit.Text = "Retour au Menu";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // guessLayoutPanel
            // 
            this.guessLayoutPanel.ColumnCount = 1;
            this.guessLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.guessLayoutPanel.Location = new System.Drawing.Point(216, 39);
            this.guessLayoutPanel.Name = "guessLayoutPanel";
            this.guessLayoutPanel.RowCount = 1;
            this.guessLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.guessLayoutPanel.Size = new System.Drawing.Size(230, 440);
            this.guessLayoutPanel.TabIndex = 26;
            // 
            // layoutPanelAnswer
            // 
            this.layoutPanelAnswer.ColumnCount = 1;
            this.layoutPanelAnswer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanelAnswer.Location = new System.Drawing.Point(216, 525);
            this.layoutPanelAnswer.Name = "layoutPanelAnswer";
            this.layoutPanelAnswer.RowCount = 1;
            this.layoutPanelAnswer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanelAnswer.Size = new System.Drawing.Size(230, 66);
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
            this.tableLayoutPanelHints.Size = new System.Drawing.Size(82, 440);
            this.tableLayoutPanelHints.TabIndex = 28;
            // 
            // checkBoxDebug
            // 
            this.checkBoxDebug.AutoSize = true;
            this.checkBoxDebug.Location = new System.Drawing.Point(18, 525);
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
            this.langueToolStripMenuItemLanguage});
            this.menuStripGame.Location = new System.Drawing.Point(0, 0);
            this.menuStripGame.Name = "menuStripGame";
            this.menuStripGame.Size = new System.Drawing.Size(467, 24);
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
            this.françaisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.françaisToolStripMenuItem.Text = "Français";
            this.françaisToolStripMenuItem.Click += new System.EventHandler(this.françaisToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // Mastermind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(467, 603);
            this.Controls.Add(this.checkBoxDebug);
            this.Controls.Add(this.tableLayoutPanelHints);
            this.Controls.Add(this.layoutPanelAnswer);
            this.Controls.Add(this.guessLayoutPanel);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnEnterTry);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnMagenta);
            this.Controls.Add(this.btnCyan);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnYellow);
            this.Controls.Add(this.btnWhite);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnRed);
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
        private System.Windows.Forms.Button btnMagenta;
        private System.Windows.Forms.Button btnCyan;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TableLayoutPanel guessLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel layoutPanelAnswer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHints;
        private System.Windows.Forms.CheckBox checkBoxDebug;
        private System.Windows.Forms.MenuStrip menuStripGame;
        private System.Windows.Forms.ToolStripMenuItem langueToolStripMenuItemLanguage;
        private System.Windows.Forms.ToolStripMenuItem françaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
    }
}

