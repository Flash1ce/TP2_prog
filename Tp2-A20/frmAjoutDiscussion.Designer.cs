namespace Tp2_A20
{
    partial class frmAjoutDiscussion
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
            this.components = new System.ComponentModel.Container();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.txtCatégorie = new System.Windows.Forms.TextBox();
            this.txtContenu = new System.Windows.Forms.TextBox();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblCatégorie = new System.Windows.Forms.Label();
            this.btnSauvegarder = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitre
            // 
            this.txtTitre.Location = new System.Drawing.Point(137, 52);
            this.txtTitre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(220, 27);
            this.txtTitre.TabIndex = 0;
            // 
            // txtCatégorie
            // 
            this.txtCatégorie.Location = new System.Drawing.Point(137, 91);
            this.txtCatégorie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCatégorie.Name = "txtCatégorie";
            this.txtCatégorie.Size = new System.Drawing.Size(220, 27);
            this.txtCatégorie.TabIndex = 1;
            // 
            // txtContenu
            // 
            this.txtContenu.Location = new System.Drawing.Point(14, 129);
            this.txtContenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContenu.Multiline = true;
            this.txtContenu.Name = "txtContenu";
            this.txtContenu.Size = new System.Drawing.Size(750, 517);
            this.txtContenu.TabIndex = 2;
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(89, 56);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(46, 20);
            this.lblTitre.TabIndex = 3;
            this.lblTitre.Text = "Titre :";
            // 
            // lblCatégorie
            // 
            this.lblCatégorie.AutoSize = true;
            this.lblCatégorie.Location = new System.Drawing.Point(57, 95);
            this.lblCatégorie.Name = "lblCatégorie";
            this.lblCatégorie.Size = new System.Drawing.Size(81, 20);
            this.lblCatégorie.TabIndex = 4;
            this.lblCatégorie.Text = "Catégorie :";
            // 
            // btnSauvegarder
            // 
            this.btnSauvegarder.Location = new System.Drawing.Point(571, 671);
            this.btnSauvegarder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSauvegarder.Name = "btnSauvegarder";
            this.btnSauvegarder.Size = new System.Drawing.Size(193, 29);
            this.btnSauvegarder.TabIndex = 5;
            this.btnSauvegarder.Text = "Ajouter la discussion";
            this.btnSauvegarder.UseVisualStyleBackColor = true;
            this.btnSauvegarder.Click += new System.EventHandler(this.btnSauvegarder_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAjoutDiscussion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 745);
            this.Controls.Add(this.btnSauvegarder);
            this.Controls.Add(this.lblCatégorie);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.txtContenu);
            this.Controls.Add(this.txtCatégorie);
            this.Controls.Add(this.txtTitre);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAjoutDiscussion";
            this.Text = "Ajout";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.TextBox txtCatégorie;
        private System.Windows.Forms.TextBox txtContenu;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblCatégorie;
        private System.Windows.Forms.Button btnSauvegarder;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}