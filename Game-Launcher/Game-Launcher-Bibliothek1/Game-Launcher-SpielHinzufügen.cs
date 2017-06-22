//#define Scale
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Launcher_Bibliothek1
{
    public partial class Game_Launcher_SpielHinzufügen : Form
    {
        SpieleMethoden spiel = new SpieleMethoden();
#if Scale
        int _cursX = 0;
        int _cursY = 0;
#endif
        public Game_Launcher_SpielHinzufügen()
        {
            InitializeComponent();
        }

        private void Game_Launcher_SpielHinzufügen_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Paint += new PaintEventHandler(Form1_Paint);
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
#if Scale
            Graphics dc = e.Graphics;
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(dc, "X=" + _cursX.ToString() + ":" + "Y=" + _cursY.ToString(), _font, new Rectangle(0, 0, 120, 20), SystemColors.ControlText, flags);
#endif
            base.OnPaint(e);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           // BackgroundImage = Properties.Resources.Hintergrund; Curcor ist nicht zu sehen
            e.Graphics.DrawImage(Properties.Resources.buttonbetter, 10, 218);
            e.Graphics.DrawImage(Properties.Resources.buttonbetter, 190, 218);
            e.Graphics.DrawString("Hinzufügen", this.Font, Brushes.Black, 20, 228);
            e.Graphics.DrawString("Schließen", this.Font, Brushes.Black, 205, 228);
            e.Graphics.DrawString("Titel des Spiels", this.Font, Brushes.Black, 13, 15);
            e.Graphics.DrawString("Installations Datum", this.Font, Brushes.Black, 13, 40);
            e.Graphics.DrawString("Zuletzt Gespielt", this.Font, Brushes.Black, 13, 67);
            e.Graphics.DrawString("Installations Pfad", this.Font, Brushes.Black, 13, 94);
            e.Graphics.DrawString("Kategorie", this.Font, Brushes.Black, 13, 120);
            e.Graphics.DrawString("Publisher", this.Font, Brushes.Black, 13, 145);
            e.Graphics.DrawString("USK Einstufung", this.Font, Brushes.Black, 13, 170);
        }

        private void Game_Launcher_SpielHinzufügen_MoveMouse(object sender, MouseEventArgs e)
        {
#if Scale
            _cursX = e.X;
            _cursY = e.Y;
#endif
            
        }

        private void Game_Launcher_SpielHinzufügen_Click(object sender, MouseEventArgs e)
        {
            if (e.X > 10 && e.X < 92 && e.Y > 217 && e.Y < 251)
            {
                spiel.SpielHinzufügen(Titel.Text,InstallationsDatum.Text,ZuletztGespielt.Text,InstallationsPfad.Text,Kategorie.Text,Publisher.Text,Convert.ToInt32(USKEinstufung.Text));
            }
            else if (e.X > 193 && e.X < 273 && e.Y > 217 && e.Y < 251)
            {
                spiel.SpielSpeichern(spiel.ParameterDesSpielsListe);
                Game_Launcher_GUI form1 = new Game_Launcher_GUI();
                form1.ListeAktualisieren();
                Close();
            }
        }

        private void GameLauncherSpielHinzufügenTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void InstallationsPfad_Durchsuchen_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InstallationsPfad.Text = FD.FileName;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void Game_Launcher_SpielHinzufügen_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void InstallationsPfad_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
