#define Scale
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
    public partial class Game_Launcher_GUI : Form
    {
        
#if Scale
        int _cursX = 0;
        int _cursY = 0;
#endif
        SpieleMethoden spiel = new SpieleMethoden();
        public Game_Launcher_GUI()
        {
            InitializeComponent();
            
            
        }

        public void ListeAktualisieren()
        {
            spiel.ParameterDesSpielsListe.Clear();
            spiel.ListeSollLeerSein = true;
            spiel.SpielLaden(spiel.ParameterDesSpielsListe);
            SpieleListeBox.DataSource = spiel.ParameterDesSpielsListe;
            SpieleListeBox.DisplayMember = "TitelDesSpiels";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Paint += new PaintEventHandler(Form1_Paint);
            ListeAktualisieren();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //BackgroundImage = Properties.Resources.Hintergrund;
            e.Graphics.DrawImage(Properties.Resources.buttonbetter, 10, 457);
            e.Graphics.DrawImage(Properties.Resources.buttonbetter, 110, 457);
            e.Graphics.DrawImage(Properties.Resources.buttonbetter, 210, 457);
            e.Graphics.DrawImage(Properties.Resources.buttonbetter, 575, 457);
            e.Graphics.DrawString("Hinzufügen", this.Font, Brushes.Black, 21, 467);
            e.Graphics.DrawString("Löschen", this.Font, Brushes.Black, 129, 467);
            e.Graphics.DrawString("Schließen", this.Font, Brushes.Black, 225, 467);
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
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Game_Launcher_MouseMove(object sender, MouseEventArgs e)
        {
#if Scale
            _cursX = e.X;
            _cursY = e.Y;
#endif
            
        }
        

        private void Game_Launcher_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 10 && e.X < 92 && e.Y > 457 && e.Y < 492)
            {
                Game_Launcher_SpielHinzufügen form2 = new Game_Launcher_SpielHinzufügen();
                form2.Show();
            }
            else if (e.X > 110 && e.X < 192 && e.Y > 457 && e.Y < 492)
            {
                MessageBox.Show("gelöscht");
            }
            else if (e.X > 210 && e.X < 292 && e.Y > 457 && e.Y < 492)
            {
                Close();
            }
            else if (e.X > 574 && e.X < 658 && e.Y > 457 && e.Y < 492)
            {
                MessageBox.Show("Spiel Starten");
            }
        }
    }
}
