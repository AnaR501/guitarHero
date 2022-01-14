using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarHeroGenerationZ
{
    public partial class ucEndSingleGame : UserControl
    {
        public string Poruka;
        public int brPoena;
        public double procenatPogodaka;

        public event EventHandler ButtonClickReply;
        public event EventHandler ButtonClickNewSong;
        public event EventHandler ButtonClickMenu;

        public ucEndSingleGame()
        {
            InitializeComponent();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickReply != null)
                this.ButtonClickReply(this, e);
        }

        private void btnNewSong_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickNewSong != null)
                this.ButtonClickNewSong(this, e);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickMenu != null)
                this.ButtonClickMenu(this, e);
        }

        public void PodesiVrednosti(int brP, double procenatP)
        {
            brPoena = brP;
            procenatPogodaka = procenatP;
            Poruka = "You've got " + brPoena + " points (" + String.Format("{0:0.00}%", procenatPogodaka) + ")!";
            lblPoints.Text = Poruka;
        }
    }
}
