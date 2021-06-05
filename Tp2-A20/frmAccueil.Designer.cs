namespace Tp2_A20
{
    partial class frmAccueil
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvPublications = new System.Windows.Forms.TreeView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtContenu = new System.Windows.Forms.TextBox();
            this.gbAuthentifie = new System.Windows.Forms.GroupBox();
            this.lstFiltre = new System.Windows.Forms.ListBox();
            this.txtFiltre = new System.Windows.Forms.TextBox();
            this.lblFiltre = new System.Windows.Forms.Label();
            this.btnFiltrerParCategories = new System.Windows.Forms.Button();
            this.btnFilterParUtilisateur = new System.Windows.Forms.Button();
            this.btnPouceEnHaut = new System.Windows.Forms.Button();
            this.btnAjoutCommentaire = new System.Windows.Forms.Button();
            this.btnDeconnection = new System.Windows.Forms.Button();
            this.btnPouceEnBas = new System.Windows.Forms.Button();
            this.btnDiscussion = new System.Windows.Forms.Button();
            this.gbAuthentification = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCreeCompte = new System.Windows.Forms.Button();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.txtUtilisateur = new System.Windows.Forms.TextBox();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.lblUtilisateur = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbAuthentifie.SuspendLayout();
            this.gbAuthentification.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvPublications
            // 
            this.tvPublications.Location = new System.Drawing.Point(362, 16);
            this.tvPublications.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tvPublications.Name = "tvPublications";
            this.tvPublications.Size = new System.Drawing.Size(670, 887);
            this.tvPublications.TabIndex = 0;
            this.tvPublications.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPublications_AfterSelect);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // txtContenu
            // 
            this.txtContenu.Location = new System.Drawing.Point(1040, 16);
            this.txtContenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContenu.Multiline = true;
            this.txtContenu.Name = "txtContenu";
            this.txtContenu.Size = new System.Drawing.Size(569, 887);
            this.txtContenu.TabIndex = 3;
            // 
            // gbAuthentifie
            // 
            this.gbAuthentifie.Controls.Add(this.lstFiltre);
            this.gbAuthentifie.Controls.Add(this.txtFiltre);
            this.gbAuthentifie.Controls.Add(this.lblFiltre);
            this.gbAuthentifie.Controls.Add(this.btnFiltrerParCategories);
            this.gbAuthentifie.Controls.Add(this.btnFilterParUtilisateur);
            this.gbAuthentifie.Controls.Add(this.btnPouceEnHaut);
            this.gbAuthentifie.Controls.Add(this.btnAjoutCommentaire);
            this.gbAuthentifie.Controls.Add(this.btnDeconnection);
            this.gbAuthentifie.Controls.Add(this.btnPouceEnBas);
            this.gbAuthentifie.Controls.Add(this.btnDiscussion);
            this.gbAuthentifie.Location = new System.Drawing.Point(12, 13);
            this.gbAuthentifie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbAuthentifie.Name = "gbAuthentifie";
            this.gbAuthentifie.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbAuthentifie.Size = new System.Drawing.Size(342, 888);
            this.gbAuthentifie.TabIndex = 2;
            this.gbAuthentifie.TabStop = false;
            this.gbAuthentifie.Text = "groupBox1";
            // 
            // lstFiltre
            // 
            this.lstFiltre.FormattingEnabled = true;
            this.lstFiltre.ItemHeight = 20;
            this.lstFiltre.Location = new System.Drawing.Point(19, 442);
            this.lstFiltre.Name = "lstFiltre";
            this.lstFiltre.Size = new System.Drawing.Size(307, 384);
            this.lstFiltre.TabIndex = 5;
            this.lstFiltre.SelectedIndexChanged += new System.EventHandler(this.lstFiltre_SelectedIndexChanged);
            // 
            // txtFiltre
            // 
            this.txtFiltre.Location = new System.Drawing.Point(62, 290);
            this.txtFiltre.Name = "txtFiltre";
            this.txtFiltre.Size = new System.Drawing.Size(252, 27);
            this.txtFiltre.TabIndex = 4;
            // 
            // lblFiltre
            // 
            this.lblFiltre.AutoSize = true;
            this.lblFiltre.Location = new System.Drawing.Point(7, 290);
            this.lblFiltre.Name = "lblFiltre";
            this.lblFiltre.Size = new System.Drawing.Size(49, 20);
            this.lblFiltre.TabIndex = 3;
            this.lblFiltre.Text = "Filtre :";
            // 
            // btnFiltrerParCategories
            // 
            this.btnFiltrerParCategories.Location = new System.Drawing.Point(19, 376);
            this.btnFiltrerParCategories.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFiltrerParCategories.Name = "btnFiltrerParCategories";
            this.btnFiltrerParCategories.Size = new System.Drawing.Size(307, 31);
            this.btnFiltrerParCategories.TabIndex = 2;
            this.btnFiltrerParCategories.Text = "Filtrer par les catégories";
            this.btnFiltrerParCategories.UseVisualStyleBackColor = true;
            this.btnFiltrerParCategories.Click += new System.EventHandler(this.btnFiltrerParCategories_Click);
            // 
            // btnFilterParUtilisateur
            // 
            this.btnFilterParUtilisateur.Location = new System.Drawing.Point(19, 337);
            this.btnFilterParUtilisateur.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFilterParUtilisateur.Name = "btnFilterParUtilisateur";
            this.btnFilterParUtilisateur.Size = new System.Drawing.Size(307, 31);
            this.btnFilterParUtilisateur.TabIndex = 2;
            this.btnFilterParUtilisateur.Text = "Filtrer par les utilisateurs";
            this.btnFilterParUtilisateur.UseVisualStyleBackColor = true;
            this.btnFilterParUtilisateur.Click += new System.EventHandler(this.btnFilterParUtilisateur_Click);
            // 
            // btnPouceEnHaut
            // 
            this.btnPouceEnHaut.Location = new System.Drawing.Point(19, 33);
            this.btnPouceEnHaut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPouceEnHaut.Name = "btnPouceEnHaut";
            this.btnPouceEnHaut.Size = new System.Drawing.Size(307, 31);
            this.btnPouceEnHaut.TabIndex = 2;
            this.btnPouceEnHaut.Text = "Pouce en haut";
            this.btnPouceEnHaut.UseVisualStyleBackColor = true;
            this.btnPouceEnHaut.Click += new System.EventHandler(this.btnPouceEnHaut_Click);
            // 
            // btnAjoutCommentaire
            // 
            this.btnAjoutCommentaire.Location = new System.Drawing.Point(19, 122);
            this.btnAjoutCommentaire.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAjoutCommentaire.Name = "btnAjoutCommentaire";
            this.btnAjoutCommentaire.Size = new System.Drawing.Size(307, 31);
            this.btnAjoutCommentaire.TabIndex = 2;
            this.btnAjoutCommentaire.Text = "Ajouter un commentaire";
            this.btnAjoutCommentaire.UseVisualStyleBackColor = true;
            this.btnAjoutCommentaire.Click += new System.EventHandler(this.btnAjoutCommentaire_Click);
            // 
            // btnDeconnection
            // 
            this.btnDeconnection.Location = new System.Drawing.Point(161, 843);
            this.btnDeconnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeconnection.Name = "btnDeconnection";
            this.btnDeconnection.Size = new System.Drawing.Size(165, 31);
            this.btnDeconnection.TabIndex = 1;
            this.btnDeconnection.Text = "se déconnecter";
            this.btnDeconnection.UseVisualStyleBackColor = true;
            this.btnDeconnection.Click += new System.EventHandler(this.btnDeconnection_Click);
            // 
            // btnPouceEnBas
            // 
            this.btnPouceEnBas.Location = new System.Drawing.Point(19, 72);
            this.btnPouceEnBas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPouceEnBas.Name = "btnPouceEnBas";
            this.btnPouceEnBas.Size = new System.Drawing.Size(307, 31);
            this.btnPouceEnBas.TabIndex = 1;
            this.btnPouceEnBas.Text = "Pouce en bas";
            this.btnPouceEnBas.UseVisualStyleBackColor = true;
            this.btnPouceEnBas.Click += new System.EventHandler(this.btnPouceEnBas_Click);
            // 
            // btnDiscussion
            // 
            this.btnDiscussion.Location = new System.Drawing.Point(19, 161);
            this.btnDiscussion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDiscussion.Name = "btnDiscussion";
            this.btnDiscussion.Size = new System.Drawing.Size(307, 31);
            this.btnDiscussion.TabIndex = 1;
            this.btnDiscussion.Text = "Ajouter une discussion";
            this.btnDiscussion.UseVisualStyleBackColor = true;
            this.btnDiscussion.Click += new System.EventHandler(this.btnDiscussion_Click);
            // 
            // gbAuthentification
            // 
            this.gbAuthentification.Controls.Add(this.btnLogin);
            this.gbAuthentification.Controls.Add(this.btnCreeCompte);
            this.gbAuthentification.Controls.Add(this.txtMotDePasse);
            this.gbAuthentification.Controls.Add(this.txtUtilisateur);
            this.gbAuthentification.Controls.Add(this.lblMotDePasse);
            this.gbAuthentification.Controls.Add(this.lblUtilisateur);
            this.gbAuthentification.Location = new System.Drawing.Point(18, 13);
            this.gbAuthentification.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbAuthentification.Name = "gbAuthentification";
            this.gbAuthentification.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbAuthentification.Size = new System.Drawing.Size(338, 880);
            this.gbAuthentification.TabIndex = 2;
            this.gbAuthentification.TabStop = false;
            this.gbAuthentification.Text = " Authentification";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(182, 132);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(148, 29);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "S\'authentifier";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCreeCompte
            // 
            this.btnCreeCompte.Location = new System.Drawing.Point(14, 132);
            this.btnCreeCompte.Name = "btnCreeCompte";
            this.btnCreeCompte.Size = new System.Drawing.Size(148, 29);
            this.btnCreeCompte.TabIndex = 4;
            this.btnCreeCompte.Text = "Créé un compte";
            this.btnCreeCompte.UseVisualStyleBackColor = true;
            this.btnCreeCompte.Click += new System.EventHandler(this.btnCreeCompte_Click);
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(122, 58);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.PasswordChar = '*';
            this.txtMotDePasse.Size = new System.Drawing.Size(199, 27);
            this.txtMotDePasse.TabIndex = 3;
            // 
            // txtUtilisateur
            // 
            this.txtUtilisateur.Location = new System.Drawing.Point(122, 21);
            this.txtUtilisateur.Name = "txtUtilisateur";
            this.txtUtilisateur.Size = new System.Drawing.Size(199, 27);
            this.txtUtilisateur.TabIndex = 2;
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Location = new System.Drawing.Point(7, 65);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(109, 20);
            this.lblMotDePasse.TabIndex = 1;
            this.lblMotDePasse.Text = "Mot de passe : ";
            // 
            // lblUtilisateur
            // 
            this.lblUtilisateur.AutoSize = true;
            this.lblUtilisateur.Location = new System.Drawing.Point(29, 28);
            this.lblUtilisateur.Name = "lblUtilisateur";
            this.lblUtilisateur.Size = new System.Drawing.Size(87, 20);
            this.lblUtilisateur.TabIndex = 0;
            this.lblUtilisateur.Text = "Utilisateur : ";
            // 
            // frmAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1648, 931);
            this.Controls.Add(this.txtContenu);
            this.Controls.Add(this.gbAuthentification);
            this.Controls.Add(this.gbAuthentifie);
            this.Controls.Add(this.tvPublications);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAccueil";
            this.Text = "Accueil";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccueil_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbAuthentifie.ResumeLayout(false);
            this.gbAuthentifie.PerformLayout();
            this.gbAuthentification.ResumeLayout(false);
            this.gbAuthentification.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvPublications;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtContenu;
        private System.Windows.Forms.GroupBox gbAuthentifie;
        private System.Windows.Forms.Button btnDiscussion;
        private System.Windows.Forms.GroupBox gbAuthentification;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCreeCompte;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.TextBox txtUtilisateur;
        private System.Windows.Forms.Label lblMotDePasse;
        private System.Windows.Forms.Label lblUtilisateur;
        private System.Windows.Forms.Button btnAjoutCommentaire;
        private System.Windows.Forms.TextBox txtFiltre;
        private System.Windows.Forms.Label lblFiltre;
        private System.Windows.Forms.Button btnFiltrerParCategories;
        private System.Windows.Forms.Button btnFilterParUtilisateur;
        private System.Windows.Forms.Button btnPouceEnHaut;
        private System.Windows.Forms.Button btnDeconnection;
        private System.Windows.Forms.Button btnPouceEnBas;
        private System.Windows.Forms.ListBox lstFiltre;
    }
}

