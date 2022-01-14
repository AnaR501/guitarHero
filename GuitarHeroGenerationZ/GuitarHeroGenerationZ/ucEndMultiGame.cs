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
    public partial class ucEndMultiGame : UserControl
    {
        public string PorukaPobednik;
        public string PorukaPoeni;
        public int brPoena1;
        public int brPoena2;
        public double procenatPogodaka1;
        public double procenatPogodaka2;

        public event EventHandler ButtonClickReply;
        public event EventHandler ButtonClickNewSong;
        public event EventHandler ButtonClickMenu;
        public ucEndMultiGame()
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

        public void PodesiVrednosti(string Player1, int brP1, double procenatP1,string Player2,  int brP2, double procenatP2) //znamo da je Player1 pobednik
        {
            brPoena1 = brP1;
            brPoena2 = brP2;
            procenatPogodaka1 = procenatP1;
            procenatPogodaka2 = procenatP2;

            PorukaPobednik = Player1 + " wins!";
            PorukaPoeni = Player1 + ": " + brPoena1 + " (" + String.Format("{0:0.00}%", procenatPogodaka1) + ")\n" + Player2 + ": " + brPoena2 + " (" + String.Format("{0:0.00}%", procenatPogodaka2) + ")";
            lblWinner.Text = PorukaPobednik;
            lblPoints.Text = PorukaPoeni;
        }
    }
}
