using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Laucher_Bibliothek
{
    public partial class Game_Launcher_GUI : Form
    {
        public Game_Launcher_GUI()
        {
            InitializeComponent();
        }

        private void Game_Launcher_GUI_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Paint += new PaintEventHandler(Game_Launcher_GUI_Paint);
        }
        private void Game_Launcher_GUI_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
