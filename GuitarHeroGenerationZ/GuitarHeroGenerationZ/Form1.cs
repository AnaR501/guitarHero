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
    public partial class Form1 : Form
    {

        public static BazaPodataka bazaPodataka = new BazaPodataka();

        public Form1()
        {
            InitializeComponent();

            this.ucSinglePlayerGame1.prikaziKrajSingleIgre += UserControl_ShowEndGame;
            this.ucMultiPlayerGame1.prikaziKrajMultiIgre += UserControl_ShowEndMultiGame;

            //izvlacim podatke iz baze i pamtim ih u TastaturaIKoordinate
            bazaPodataka.PokreniApp();
        }

        protected void UserControl_ButtonClickSinglePlayer(object sender, EventArgs e)
        {
            this.ucSinglePlayerOptions1.PostaviVrednosti();
            this.ucSinglePlayerOptions1.Visible = true;
            this.ucMeni1.Visible = false;
        }

        protected void UserControl_ButtonClickSinglePlayerPlay(object sender, EventArgs e)
        {
            if (ucSinglePlayerOptions1.PreuzmiVrednostiKontrola())
            {
                this.ucSinglePlayerOptions1.Visible = false;
                this.ucSinglePlayerGame1.Visible = true;
                PreuzmiVrednostiSinglePlayer();

                this.ucSinglePlayerGame1.Focus();
                this.ucSinglePlayerGame1.PocniIgru();
            }
        }

        private void PreuzmiVrednostiSinglePlayer()
        {
            this.ucSinglePlayerGame1.Player = this.ucSinglePlayerOptions1.Player;
            this.ucSinglePlayerGame1.mySong = this.ucSinglePlayerOptions1.Song;
            this.ucSinglePlayerGame1.Difficulty = this.ucSinglePlayerOptions1.Difficulty;
        }
        private void PreuzmiVrednostiMultiPlayer()
        {
            this.ucMultiPlayerGame1.Player1 = this.ucMultiPlayerOptions1.Player1;
            this.ucMultiPlayerGame1.Player2 = this.ucMultiPlayerOptions1.Player2;
            this.ucMultiPlayerGame1.mySong = this.ucMultiPlayerOptions1.Song;
            this.ucMultiPlayerGame1.Difficulty = this.ucMultiPlayerOptions1.Difficulty;
        }

        protected void UserControl_ButtonClickSinglePlayerPause(object sender, EventArgs e)
        {
            this.ucSinglePlayerGame1.Pauziraj();
            this.ucPauseSingleGame1.Visible = true;
            this.ucSinglePlayerGame1.Visible = false;
        }

        protected void UserControl_ButtonClickSinglePlayerResume(object sender, EventArgs e)
        {
            this.ucSinglePlayerGame1.NastaviIgru();
            this.ucPauseSingleGame1.Visible = false;
            this.ucSinglePlayerGame1.Visible = true;
            this.ucSinglePlayerGame1.Focus();
        }

        protected void UserControl_ButtonClickSinglePlayerRestart(object sender, EventArgs e)
        {
            this.ucSinglePlayerGame1.RestartujIgru();
            this.ucPauseSingleGame1.Visible = false;
            this.ucSinglePlayerGame1.Visible = true;
            this.ucSinglePlayerGame1.Focus();
        }

        protected void UserControl_ButtonClickSinglePlayerFlip(object sender, EventArgs e)
        {
            TastaturaIKoordinate.FlipKeyboard(1);
            UserControl_ButtonClickSinglePlayerRestart(sender, e);
        }

        protected void UserControl_ButtonClickSinglePlayerQuit(object sender, EventArgs e)
        {
            this.ucSinglePlayerGame1.ZavrsiIgru();
            this.ucPauseSingleGame1.Visible = false;
            this.ucMeni1.Visible = true;
            this.ucMeni1.Focus();
        }

        public void UserControl_ShowEndGame(int brPoena, double procenatPogodaka)
        {
            this.ucSinglePlayerGame1.Visible = false;
            this.ucEndSingleGame1.PodesiVrednosti(brPoena, procenatPogodaka);
            this.ucEndSingleGame1.Visible = true;
        }

        protected void UserControl_ButtonClickSinglePlayerReply(object sender, EventArgs e)
        {
            this.ucSinglePlayerGame1.RestartujIgru();
            this.ucEndSingleGame1.Visible = false;
            this.ucSinglePlayerGame1.Visible = true;
            this.ucSinglePlayerGame1.Focus();
        }

        protected void UserControl_ButtonClickSinglePlayerNewSong(object sender, EventArgs e)
        {
            this.ucSinglePlayerGame1.ZavrsiIgru();
            this.ucEndSingleGame1.Visible = false;
            this.ucSinglePlayerOptions1.Visible = true;
        }

        protected void UserControl_ButtonClickSinglePlayerMenu(object sender, EventArgs e)
        {
            this.ucSinglePlayerGame1.ZavrsiIgru();
            this.ucEndSingleGame1.Visible = false;
            this.ucMeni1.Visible = true;
        }

        //MULTI PLAYER

        protected void UserControl_ButtonClickMultiPlayer(object sender, EventArgs e)
        {
            this.ucMultiPlayerOptions1.PostaviVrednosti();
            this.ucMultiPlayerOptions1.Visible = true;
            this.ucMeni1.Visible = false;
        }

        protected void UserControl_ButtonClickMultiPlayerPlay(object sender, EventArgs e)
        {
            if (ucMultiPlayerOptions1.PreuzmiVrednostiKontrola())
            {
                this.ucMeni1.Visible = false;
                this.ucMultiPlayerOptions1.Visible = false;
                this.ucMultiPlayerOptions1.ResetujPoruke();
                this.ucMultiPlayerGame1.Visible = true;
                PreuzmiVrednostiMultiPlayer();

                this.ucMultiPlayerGame1.Focus();
                this.ucMultiPlayerGame1.PocniIgru();
            }
        }

        protected void UserControl_ButtonClickMultiPlayerPause(object sender, EventArgs e)
        {
            this.ucMultiPlayerGame1.Pauziraj();
            this.ucPauseMultiGame1.Visible = true;
            this.ucMultiPlayerGame1.Visible = false;
            this.ucPauseMultiGame1.Focus();
        }


        //MULTIPLAYER pause dugmici

        protected void UserControl_ButtonClickMultiPlayerResume(object sender, EventArgs e)
        {
            this.ucMultiPlayerGame1.NastaviIgru();
            this.ucPauseMultiGame1.Visible = false;
            this.ucMultiPlayerGame1.Visible = true;
            this.ucMultiPlayerGame1.Focus();
        }

        protected void UserControl_ButtonClickMultiPlayerRestart(object sender, EventArgs e)
        {
            this.ucMultiPlayerGame1.RestartujIgru();
            this.ucPauseMultiGame1.Visible = false;
            this.ucMultiPlayerGame1.Visible = true;
            this.ucMultiPlayerGame1.Focus();
        }

        protected void UserControl_ButtonClickMultiPlayerFlip1(object sender, EventArgs e)
        {
            TastaturaIKoordinate.FlipKeyboard(1); //Flip Keyboard ima arg koji pokazuje koja tastatura treba da se flipuje
            UserControl_ButtonClickMultiPlayerRestart(sender, e);
        }

        protected void UserControl_ButtonClickMultiPlayerFlip2(object sender, EventArgs e)
        {
            TastaturaIKoordinate.FlipKeyboard(2); //Flip Keyboard ima arg koji pokazuje koja tastatura treba da se flipuje
            UserControl_ButtonClickMultiPlayerRestart(sender, e);
        }

        protected void UserControl_ButtonClickMultiPlayerQuit(object sender, EventArgs e)
        {
            this.ucMultiPlayerGame1.ZavrsiIgru();
            this.ucPauseMultiGame1.Visible = false;
            this.ucMeni1.Visible = true;
        }

        public void UserControl_ShowEndMultiGame(string Player1, int brPoena1, double procenatPogodaka1, string Player2, int brPoena2, double procenatPogodaka2)
        {
            this.ucMultiPlayerGame1.Visible = false;
            this.ucEndMultiGame1.PodesiVrednosti(Player1, brPoena1, procenatPogodaka1, Player2, brPoena2, procenatPogodaka2);
            this.ucEndMultiGame1.Visible = true;
        }

        protected void UserControl_ButtonClickMultiPlayerReply(object sender, EventArgs e)
        {
            this.ucMultiPlayerGame1.RestartujIgru();
            this.ucEndMultiGame1.Visible = false;
            this.ucMultiPlayerGame1.Visible = true;
            this.ucMultiPlayerGame1.Focus();
        }

        protected void UserControl_ButtonClickMultiPlayerNewSong(object sender, EventArgs e)
        {
            this.ucMultiPlayerGame1.ZavrsiIgru();
            this.ucEndMultiGame1.Visible = false;
            this.ucMultiPlayerOptions1.Visible = true;
        }

        protected void UserControl_ButtonClickMultiPlayerMenu(object sender, EventArgs e)
        {
            this.ucMultiPlayerGame1.ZavrsiIgru();
            this.ucEndMultiGame1.Visible = false;
            this.ucMeni1.Visible = true;
        }

        public void UserControl_ButtonClickQuit(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UserControl_ButtonClickSettings(object sender, EventArgs e)
        {
            this.ucSettings1.Prikazi();
            this.ucMeni1.Visible = false;
            this.ucSettings1.Visible = true;
            this.ucSettings1.Focus();
        }

        public void UserControl_ButtonClickBackToMenu(object sender, EventArgs e) //from Settings
        {
            this.ucSettings1.Visible = false;
            this.ucSettings1.PodesiFlip();
            this.ucMeni1.Visible = true;
            this.ucMeni1.Focus();
        }

        public void UserControl_ButtonClickHighScores(object sender, EventArgs e)
        {
            this.ucMeni1.Visible = false;
            this.ucHighScores1.PostaviHighScores();
            this.ucHighScores1.Visible = true;
            this.ucHighScores1.Focus();
        }

        public void UserControl_ButtonClickBackToMenuFromHighScores(object sender, EventArgs e)
        {
            this.ucHighScores1.Visible = false;
            this.ucMeni1.Visible = true;
            this.ucMeni1.Focus();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bazaPodataka.ZatvoriApp();
        }
    }
}
