namespace Game_Launcher_Bibliothek1
{
    partial class Game_Launcher_SpielHinzufügen
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
            this.Titel = new System.Windows.Forms.TextBox();
            this.InstallationsDatum = new System.Windows.Forms.TextBox();
            this.ZuletztGespielt = new System.Windows.Forms.TextBox();
            this.InstallationsPfad = new System.Windows.Forms.TextBox();
            this.Kategorie = new System.Windows.Forms.TextBox();
            this.Publisher = new System.Windows.Forms.TextBox();
            this.USKEinstufung = new System.Windows.Forms.TextBox();
            this.GameLauncherSpielHinzufügenTimer = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // Titel
            // 
            this.Titel.HideSelection = false;
            this.Titel.Location = new System.Drawing.Point(172, 12);
            this.Titel.Name = "Titel";
            this.Titel.Size = new System.Drawing.Size(100, 20);
            this.Titel.TabIndex = 0;
            // 
            // InstallationsDatum
            // 
            this.InstallationsDatum.Location = new System.Drawing.Point(172, 38);
            this.InstallationsDatum.Name = "InstallationsDatum";
            this.InstallationsDatum.Size = new System.Drawing.Size(100, 20);
            this.InstallationsDatum.TabIndex = 1;
            // 
            // ZuletztGespielt
            // 
            this.ZuletztGespielt.Location = new System.Drawing.Point(172, 64);
            this.ZuletztGespielt.Name = "ZuletztGespielt";
            this.ZuletztGespielt.Size = new System.Drawing.Size(100, 20);
            this.ZuletztGespielt.TabIndex = 2;
            // 
            // InstallationsPfad
            // 
            this.InstallationsPfad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InstallationsPfad.HideSelection = false;
            this.InstallationsPfad.Location = new System.Drawing.Point(172, 90);
            this.InstallationsPfad.Name = "InstallationsPfad";
            this.InstallationsPfad.Size = new System.Drawing.Size(100, 20);
            this.InstallationsPfad.TabIndex = 3;
            this.InstallationsPfad.Click += new System.EventHandler(this.InstallationsPfad_Durchsuchen_Click);
            // 
            // Kategorie
            // 
            this.Kategorie.Location = new System.Drawing.Point(172, 116);
            this.Kategorie.Name = "Kategorie";
            this.Kategorie.Size = new System.Drawing.Size(100, 20);
            this.Kategorie.TabIndex = 4;
            // 
            // Publisher
            // 
            this.Publisher.Location = new System.Drawing.Point(172, 142);
            this.Publisher.Name = "Publisher";
            this.Publisher.Size = new System.Drawing.Size(100, 20);
            this.Publisher.TabIndex = 5;
            // 
            // USKEinstufung
            // 
            this.USKEinstufung.Location = new System.Drawing.Point(172, 168);
            this.USKEinstufung.Name = "USKEinstufung";
            this.USKEinstufung.Size = new System.Drawing.Size(100, 20);
            this.USKEinstufung.TabIndex = 6;
            // 
            // GameLauncherSpielHinzufügenTimer
            // 
            this.GameLauncherSpielHinzufügenTimer.Enabled = true;
            this.GameLauncherSpielHinzufügenTimer.Interval = 10;
            this.GameLauncherSpielHinzufügenTimer.Tick += new System.EventHandler(this.GameLauncherSpielHinzufügenTimer_Tick);
            // 
            // folderBrowserDialog1
            // 
            // 
            // Game_Launcher_SpielHinzufügen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Game_Launcher_Bibliothek1.Properties.Resources.Hintergrund;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.USKEinstufung);
            this.Controls.Add(this.Publisher);
            this.Controls.Add(this.Kategorie);
            this.Controls.Add(this.InstallationsPfad);
            this.Controls.Add(this.ZuletztGespielt);
            this.Controls.Add(this.InstallationsDatum);
            this.Controls.Add(this.Titel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Game_Launcher_SpielHinzufügen";
            this.Text = "Game_Launcher_SpielHinzufügen";
            this.Load += new System.EventHandler(this.Game_Launcher_SpielHinzufügen_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_Launcher_SpielHinzufügen_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Game_Launcher_SpielHinzufügen_MoveMouse);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Titel;
        private System.Windows.Forms.TextBox InstallationsDatum;
        private System.Windows.Forms.TextBox ZuletztGespielt;
        private System.Windows.Forms.TextBox InstallationsPfad;
        private System.Windows.Forms.TextBox Kategorie;
        private System.Windows.Forms.TextBox Publisher;
        private System.Windows.Forms.TextBox USKEinstufung;
        private System.Windows.Forms.Timer GameLauncherSpielHinzufügenTimer;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}