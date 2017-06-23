namespace Game_Launcher_Bibliothek1
{
    partial class Game_Launcher_GUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.SpieleListeBox = new System.Windows.Forms.ListBox();
            this.TitelBox = new System.Windows.Forms.TextBox();
            this.InstallationsDatumBox = new System.Windows.Forms.TextBox();
            this.ZuletztGespieltBox = new System.Windows.Forms.TextBox();
            this.InstallPfadBox = new System.Windows.Forms.TextBox();
            this.KategorieBox = new System.Windows.Forms.TextBox();
            this.PublisherBox = new System.Windows.Forms.TextBox();
            this.UskEinstufungBox = new System.Windows.Forms.TextBox();
            this.spieleMethodenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spieleMethodenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Enabled = true;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // SpieleListeBox
            // 
            this.SpieleListeBox.FormattingEnabled = true;
            this.SpieleListeBox.Location = new System.Drawing.Point(12, 12);
            this.SpieleListeBox.Name = "SpieleListeBox";
            this.SpieleListeBox.Size = new System.Drawing.Size(422, 368);
            this.SpieleListeBox.TabIndex = 0;
            this.SpieleListeBox.SelectedIndexChanged += new System.EventHandler(this.SpieleListeBox_SelectedIndexChanged);
            // 
            // TitelBox
            // 
            this.TitelBox.Location = new System.Drawing.Point(567, 104);
            this.TitelBox.Name = "TitelBox";
            this.TitelBox.Size = new System.Drawing.Size(100, 20);
            this.TitelBox.TabIndex = 1;
            // 
            // InstallationsDatumBox
            // 
            this.InstallationsDatumBox.Location = new System.Drawing.Point(567, 130);
            this.InstallationsDatumBox.Name = "InstallationsDatumBox";
            this.InstallationsDatumBox.Size = new System.Drawing.Size(100, 20);
            this.InstallationsDatumBox.TabIndex = 2;
            // 
            // ZuletztGespieltBox
            // 
            this.ZuletztGespieltBox.Location = new System.Drawing.Point(567, 156);
            this.ZuletztGespieltBox.Name = "ZuletztGespieltBox";
            this.ZuletztGespieltBox.Size = new System.Drawing.Size(100, 20);
            this.ZuletztGespieltBox.TabIndex = 3;
            // 
            // InstallPfadBox
            // 
            this.InstallPfadBox.Location = new System.Drawing.Point(567, 182);
            this.InstallPfadBox.Name = "InstallPfadBox";
            this.InstallPfadBox.Size = new System.Drawing.Size(100, 20);
            this.InstallPfadBox.TabIndex = 4;
            // 
            // KategorieBox
            // 
            this.KategorieBox.Location = new System.Drawing.Point(567, 208);
            this.KategorieBox.Name = "KategorieBox";
            this.KategorieBox.Size = new System.Drawing.Size(100, 20);
            this.KategorieBox.TabIndex = 5;
            // 
            // PublisherBox
            // 
            this.PublisherBox.Location = new System.Drawing.Point(567, 234);
            this.PublisherBox.Name = "PublisherBox";
            this.PublisherBox.Size = new System.Drawing.Size(100, 20);
            this.PublisherBox.TabIndex = 6;
            // 
            // UskEinstufungBox
            // 
            this.UskEinstufungBox.Location = new System.Drawing.Point(567, 260);
            this.UskEinstufungBox.Name = "UskEinstufungBox";
            this.UskEinstufungBox.Size = new System.Drawing.Size(100, 20);
            this.UskEinstufungBox.TabIndex = 7;
            // 
            // spieleMethodenBindingSource
            // 
            this.spieleMethodenBindingSource.DataSource = typeof(Game_Launcher_Bibliothek1.SpieleMethoden);
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(Game_Launcher_Bibliothek1.Program);
            // 
            // Game_Launcher_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Game_Launcher_Bibliothek1.Properties.Resources.Hintergrund;
            this.ClientSize = new System.Drawing.Size(735, 501);
            this.Controls.Add(this.UskEinstufungBox);
            this.Controls.Add(this.PublisherBox);
            this.Controls.Add(this.KategorieBox);
            this.Controls.Add(this.InstallPfadBox);
            this.Controls.Add(this.ZuletztGespieltBox);
            this.Controls.Add(this.InstallationsDatumBox);
            this.Controls.Add(this.TitelBox);
            this.Controls.Add(this.SpieleListeBox);
            this.Name = "Game_Launcher_GUI";
            this.Text = "Game-Launcher-GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_Launcher_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Game_Launcher_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.spieleMethodenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.ListBox SpieleListeBox;
        private System.Windows.Forms.BindingSource spieleMethodenBindingSource;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.TextBox TitelBox;
        private System.Windows.Forms.TextBox InstallationsDatumBox;
        private System.Windows.Forms.TextBox ZuletztGespieltBox;
        private System.Windows.Forms.TextBox InstallPfadBox;
        private System.Windows.Forms.TextBox KategorieBox;
        private System.Windows.Forms.TextBox PublisherBox;
        private System.Windows.Forms.TextBox UskEinstufungBox;
    }
}

