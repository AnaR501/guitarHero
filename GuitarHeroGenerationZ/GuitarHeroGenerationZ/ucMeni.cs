using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuitarHeroGenerationZ.Properties;

namespace GuitarHeroGenerationZ
{
    public partial class ucMeni : UserControl
    {
        public Bitmap bitmap;
        public Graphics g;
        public Image logo;

        public int X1;
        public int X2;
        public int Y1;
        public int Y2;

        public event EventHandler ButtonClickSinglePlayer;
        public event EventHandler ButtonClickMultiPlayer;
        public event EventHandler ButtonClickSettings;
        public event EventHandler ButtonClickQuit;
        public event EventHandler ButtonClickHighScores;

        public ucMeni()
        {
            InitializeComponent();
            bitmap = new Bitmap(pbBestPlayers.Width, pbBestPlayers.Height);
            g = Graphics.FromImage(bitmap);
            pbBestPlayers.Image = bitmap;

            X1 = (int)(pbBestPlayers.Width * 2.1/10);
            X2 = pbBestPlayers.Width * 9/10;
            Y1 = 0;
            Y2 = pbBestPlayers.Height;
            logo = Resources.LogoPicture;
            Crtaj();
        }

        private void Crtaj()
        {
            g = Graphics.FromImage(pbBestPlayers.Image);
            g.DrawImage(logo, X1, Y1, X2-X1, Y2-Y1);
            pbBestPlayers.Image = bitmap;
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickSinglePlayer != null)
                this.ButtonClickSinglePlayer(this, e);
        }
        private void btnMultiPlayer_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickMultiPlayer != null)
                this.ButtonClickMultiPlayer(this, e);
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickSettings != null)
                this.ButtonClickSettings(this, e);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickQuit != null)
                this.ButtonClickQuit(this, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickHighScores != null)
                this.ButtonClickHighScores(this, e);
        }
    }
}
