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
    public partial class ucSinglePlayerOptions : UserControl
    {
        public List<String> players;
        public List<String> songs; 
        public String Player { get; set; }
        public Song Song { get; set; }
        public string Difficulty { get; set; } 

        public event EventHandler ButtonClickPlay;


        public ucSinglePlayerOptions()
        {
            InitializeComponent();
            players = new List<String>();
            songs = new List<String>();

            players = Form1.bazaPodataka.GetPlayerNames();

            songs.Add("Slow Ride - Foghat");
            songs.Add("Radio Song - Superbus");

            rbEasy.Checked = true;
            rbHard.Checked = false;
            Song = Form1.bazaPodataka.getSong(songs[0], "Easy");
            if(players.Count > 0)
                Player = players[0];



            for (int i = 0; i < players.Count; i++)
            {
                cbPlayers.Items.Add(players[i]);
            }
            for (int i = 0; i < songs.Count; i++)
            {
                cbSongs.Items.Add(songs[i]);
            }
            Difficulty = "Easy";
            if (players.Count > 0)
                cbPlayers.SelectedIndex = 0;
            if (songs.Count > 0)
                cbSongs.SelectedIndex = 0;
        }

        public void PostaviVrednosti()
        {
            cbPlayers.Items.Clear();
            players.Clear();
            players = Form1.bazaPodataka.GetPlayerNames();
            for (int i = 0; i < players.Count; i++)
            {
                cbPlayers.Items.Add(players[i]);
            }
            if (players.Count > 0)
                cbPlayers.SelectedIndex = 0;
            ResetujPoruke();
            tbNewPlayer.Text = "";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickPlay != null)
                this.ButtonClickPlay(this, e);
        }

        public bool PreuzmiVrednostiKontrola()
        {
            if ((lblNewPlayerMessage.ForeColor == Color.Red))
            {
                return false;
            }
            else
            {
                if (lblNewPlayerMessage.ForeColor == Color.Green)
                {
                    Player = tbNewPlayer.Text;
                    //provera da li vec postoji u bazi
                    if (Form1.bazaPodataka.DodajPlayera(Player)) //vraca true ako korisnik vec postoji
                        return false;
                }
                else if (cbPlayers.Items.Count > 0)
                    Player = cbPlayers.SelectedItem.ToString();
                else
                {
                    lblNewPlayerMessage.Text = "You have to make new player!";
                    lblNewPlayerMessage.ForeColor = Color.Red;
                    return false;
                }


                if (rbEasy.Checked)
                    Difficulty = "Easy";
                else
                    Difficulty = "Hard";

                Song = Form1.bazaPodataka.getSong(songs[cbSongs.SelectedIndex], Difficulty);

                return true;
            }

        }

        private void tbNewPlayer_TextChanged(object sender, EventArgs e)
        {
            if (tbNewPlayer.Text != "")
            {
                if (players.Contains(tbNewPlayer.Text))
                {
                    lblNewPlayerMessage.Text = "That player name is aready taken!";
                    lblNewPlayerMessage.ForeColor = Color.Red;
                }
                else
                {
                    if (tbNewPlayer.Text.Length > 12)
                    {
                        lblNewPlayerMessage.Text = "Your name is too long.";
                        lblNewPlayerMessage.ForeColor = Color.Red;

                    }
                    else
                    {
                        lblNewPlayerMessage.Text = "Your name is ok, good luck!";
                        lblNewPlayerMessage.ForeColor = Color.Green;
                        Player = lblNewPlayerMessage.Text;

                    }
                }
            }
        }


        public void ResetujPoruke()
        {
            lblNewPlayerMessage.Text = "";
            lblNewPlayerMessage.ForeColor = Color.Black;
        }
    }
}