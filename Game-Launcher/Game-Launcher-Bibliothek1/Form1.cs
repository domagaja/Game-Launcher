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
using System.Diagnostics;


namespace Game_Launcher_Bibliothek1
{
    public partial class Game_Launcher_GUI : Form
    {

#if Scale
        int _cursX = 0;
        int _cursY = 0;
#endif
        BindingSource bs = new BindingSource();
        public Game_Launcher_GUI()
        {
            InitializeComponent();
            ListeAktualisieren();
        }
        public void ListeAktualisieren()
        {
            SpieleMethoden spiel = new SpieleMethoden();
            bs.ResetBindings(false);
            spiel.SpielLaden(spiel.ParameterDesSpielsListe);
            bs.DataSource = spiel.ParameterDesSpielsListe;
            SpieleListeBox.DisplayMember = "TitelDesSpiels";
            SpieleListeBox.DataSource = bs;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Paint += new PaintEventHandler(Form1_Paint); 
            
        }
        /// <summary>
        /// Meine GDI+ Oberfläche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //BackgroundImage = Properties.Resources.Hintergrund;// Listbox items werden verdeckt durch den Hintergrund
            e.Graphics.DrawImage(Properties.Resources.buttonbetter, 10, 457);
            e.Graphics.DrawImage(Properties.Resources.buttonbetter, 110, 457);
            e.Graphics.DrawImage(Properties.Resources.buttonbetter, 210, 457);
            e.Graphics.DrawImage(Properties.Resources.buttonbetter, 575, 457);
            e.Graphics.DrawString("Hinzufügen", this.Font, Brushes.Black, 21, 467);
            e.Graphics.DrawString("Löschen", this.Font, Brushes.Black, 129, 467);
            e.Graphics.DrawString("Aktualisieren", this.Font, Brushes.Black, 217, 467);
            e.Graphics.DrawString("Spiel Starten", this.Font, Brushes.Black, 584, 467);
            e.Graphics.DrawLine(Pens.Black, 0, 445, 741, 445);
            e.Graphics.DrawLine(Pens.Black, 500, 0, 500, 500);
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
        /// <summary>
        /// Refresht in einem bestimmten Zeitabstand die Oberfläche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
            SpieleListeBox.Refresh();

        }
        /// <summary>
        /// MouseMove Methode wird zur Mauspositionsabfrage benutzt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_Launcher_MouseMove(object sender, MouseEventArgs e)
        {
#if Scale
            
            _cursX = e.X;
            _cursY = e.Y;
#endif

        }
        
        /// <summary>
        /// Die ButtonAbfrage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Game_Launcher_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 10 && e.X < 92 && e.Y > 457 && e.Y < 492)
            {
                Game_Launcher_SpielHinzufügen form2 = new Game_Launcher_SpielHinzufügen();
                form2.Show();
            }
            else if (e.X > 110 && e.X < 192 && e.Y > 457 && e.Y < 492)
            {
                SpieleMethoden spiel = new SpieleMethoden();
                spiel.SpielLaden(spiel.ParameterDesSpielsListe);
                spiel.SpielLöschen(SpieleListeBox.SelectedIndex);
                spiel.SpielSpeichern(spiel.ParameterDesSpielsListe);
                ListeAktualisieren();
            }
            else if (e.X > 210 && e.X < 292 && e.Y > 457 && e.Y < 492)
            {
                ListeAktualisieren();
            }
            else if (e.X > 574 && e.X < 658 && e.Y > 457 && e.Y < 492)
            {
                SpieleMethoden spiel = new SpieleMethoden();
                spiel.SpielLaden(spiel.ParameterDesSpielsListe);
                spiel.SpielStarten(InstallPfadBox.Text);

            }
        }
        /// <summary>
        /// Hinzufügen der Elemente in die Boxen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpieleListeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpieleMethoden spiel = new SpieleMethoden();
            spiel.SpielLaden(spiel.ParameterDesSpielsListe);
            TitelBox.Clear();
            InstallationsDatumBox.Clear();
            ZuletztGespieltBox.Clear();
            InstallPfadBox.Clear();
            PublisherBox.Clear();
            UskEinstufungBox.Clear();
            KategorieBox.Clear();
            if (SpieleListeBox.SelectedIndex >= 0)
            {
                TitelBox.Text = spiel.ParameterDesSpielsListe[SpieleListeBox.SelectedIndex].TitelDesSpiels.Replace("_", " ");
                InstallationsDatumBox.Text = spiel.ParameterDesSpielsListe[SpieleListeBox.SelectedIndex].InstallationsDatum.Replace("_", " ");
                ZuletztGespieltBox.Text = spiel.ParameterDesSpielsListe[SpieleListeBox.SelectedIndex].ZuletztGespielt.Replace("_", " ");
                InstallPfadBox.Text = spiel.ParameterDesSpielsListe[SpieleListeBox.SelectedIndex].InstallationsPfad.Replace("_", " ");
                PublisherBox.Text = spiel.ParameterDesSpielsListe[SpieleListeBox.SelectedIndex].Publisher.Replace("_", " ");
                KategorieBox.Text = spiel.ParameterDesSpielsListe[SpieleListeBox.SelectedIndex].Kategorie.Replace("_", " ");
                UskEinstufungBox.Text = Convert.ToString(spiel.ParameterDesSpielsListe[SpieleListeBox.SelectedIndex].UskEinstufung).Replace("_", " ");
            }
        }
    }
}
