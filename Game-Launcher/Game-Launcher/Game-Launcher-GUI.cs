using System;
using System.Resources;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Configuration;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Game_Launcher_Bibliothek
{
    public partial class Game_Launcher_GUI : Form
    {
        Image image = 
        
        public Game_Launcher_GUI()
        {
            InitializeComponent();
            
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Paint += new PaintEventHandler(Form1_Paint);
            
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            // e.Graphics.DrawRectangle(Pens.Gray, 0, 0, 300, 300);
            e.Graphics.DrawImage(Properties.);
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
