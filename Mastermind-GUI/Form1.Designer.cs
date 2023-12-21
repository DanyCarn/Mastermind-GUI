namespace Mastermind_GUI
{
    partial class changeDifficulty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.lblColumns = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.chkRepetition = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.Location = new System.Drawing.Point(156, 36);
            this.numericUpDownColumns.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownColumns.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownColumns.Name = "numericUpDownColumns";
            this.numericUpDownColumns.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownColumns.TabIndex = 0;
            this.numericUpDownColumns.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumns.Location = new System.Drawing.Point(39, 36);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(64, 16);
            this.lblColumns.TabIndex = 1;
            this.lblColumns.Text = "Colonnes";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(189, 152);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 4;
            this.btnValidate.Text = "Confirmer";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(42, 152);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // chkRepetition
            // 
            this.chkRepetition.AutoSize = true;
            this.chkRepetition.Checked = true;
            this.chkRepetition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRepetition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRepetition.Location = new System.Drawing.Point(127, 72);
            this.chkRepetition.Name = "chkRepetition";
            this.chkRepetition.Size = new System.Drawing.Size(149, 19);
            this.chkRepetition.TabIndex = 6;
            this.chkRepetition.Text = "Répétition de couleurs";
            this.chkRepetition.UseVisualStyleBackColor = true;
            this.chkRepetition.CheckedChanged += new System.EventHandler(this.chkRepetition_CheckedChanged);
            // 
            // changeDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(307, 215);
            this.Controls.Add(this.chkRepetition);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.lblColumns);
            this.Controls.Add(this.numericUpDownColumns);
            this.Name = "changeDifficulty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownColumns;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox chkRepetition;
    }
}