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
            this.SuspendLayout();
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Enabled = true;
            this.RefreshTimer.Interval = 10;
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
            // Game_Launcher_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 501);
            this.Controls.Add(this.SpieleListeBox);
            this.Name = "Game_Launcher_GUI";
            this.Text = "Game-Launcher-GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Game_Launcher_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Game_Launcher_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.ListBox SpieleListeBox;
    }
}

