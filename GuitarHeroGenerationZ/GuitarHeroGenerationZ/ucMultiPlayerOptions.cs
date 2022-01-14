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
    public partial class ucMultiPlayerOptions : UserControl
    {
        public List<String> players;
        public List<String> songs;
        public String Player1 { get; set; }
        public String Player2 { get; set; }
        public Song Song { get; set; }
        public string Difficulty { get; set; } 

        public event EventHandler ButtonClickPlay;
        public ucMultiPlayerOptions()
        {
            InitializeComponent();
            players = new List<String>();
            songs = new List<String>();

            players = Form1.bazaPodataka.GetPlayerNames();

            songs.Add("Slow Ride - Foghat");
            songs.Add("Radio Song - Superbus");

            Song = Form1.bazaPodataka.getSong(songs[0], "Easy");
            Player1 = Player2 = "Greska";



            for (int i = 0; i < players.Count; i++)
            {
                cbPlayers1.Items.Add(players[i]);
                cbPlayers2.Items.Add(players[i]);
            }
            for (int i = 0; i < songs.Count; i++)
            {
                cbSongs.Items.Add(songs[i]);
            }
            Difficulty = "Easy";
            if (players.Count > 1)
            {
                cbPlayers1.SelectedIndex = 0;
                cbPlayers2.SelectedIndex = 1;
                Player1 = players[0];
                Player2 = players[1];
            }
            else if (players.Count == 1)
            {
                cbPlayers1.SelectedIndex = 0;
                Player1 = players[0];
            }
            else { }
            if (songs.Count > 0)
                cbSongs.SelectedIndex = 0;
        }

        public void PostaviVrednosti()
        {
            cbPlayers1.Items.Clear();
            cbPlayers2.Items.Clear();
            players.Clear();
            players = Form1.bazaPodataka.GetPlayerNames();
            for (int i = 0; i < players.Count; i++)
            {
                cbPlayers1.Items.Add(players[i]);
                cbPlayers2.Items.Add(players[i]);
            }
            if (players.Count > 1)
            {
                cbPlayers1.SelectedIndex = 0;
                cbPlayers2.SelectedIndex = 1;
            }
            ResetujPoruke();
            tbNewPlayer1.Text = "";
            tbNewPlayer2.Text = "";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickPlay != null)
                this.ButtonClickPlay(this, e);
        }

        public bool PreuzmiIgrace() //vraca true ako: 1. su izabrana 2 razlicita igraca, 2. su uneta dva nova igraca,
                                    //3. jedan igrac koji ne postoji je unet a drugi je odabran
        {
            if (tbNewPlayer1.Text != "" && lblNewPlayer1Message.ForeColor == Color.Green)
            {
                Player1 = tbNewPlayer1.Text;
                if (Form1.bazaPodataka.DodajPlayera(Player1)) //ako taj korisnik vec postoji
                    return false;
                else
                    players.Add(Player1);
            }
            else if (cbPlayers1.SelectedIndex != -1)
                Player1 = cbPlayers1.SelectedItem.ToString();
            else
                return false;

            if (tbNewPlayer2.Text != "" && lblNewPlayer2Message.ForeColor == Color.Green)
            {
                Player2 = tbNewPlayer2.Text;
                if (Form1.bazaPodataka.DodajPlayera(Player2)) //ako taj korisnik vec postoji
                {
                    lblNewPlayer2Message.Text = "You have to choose different name, that one is taken by Player1.";
                    lblNewPlayer2Message.ForeColor = Color.Red;
                    return false;
                }
                else
                    players.Add(Player2);
            }
            else if (cbPlayers2.SelectedIndex != -1)
                Player2 = cbPlayers2.SelectedItem.ToString();
            else
                return false;
            if(Player1 == Player2)
            {
                lblNewPlayer2Message.Text = "You have to choose different player, that one is taken by Player1.";
                lblNewPlayer2Message.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        public bool PreuzmiVrednostiKontrola()
        {
            if (!PreuzmiIgrace())
            {
                return false;
            }
            else
            {

                if (rbEasy.Checked)
                    Difficulty = "Easy";
                else
                    Difficulty = "Hard";
                Song = Form1.bazaPodataka.getSong(songs[cbSongs.SelectedIndex], Difficulty);

                return true;
            }

        }

        private void tbNewPlayer1_TextChanged(object sender, EventArgs e)
        {
            if (tbNewPlayer1.Text != "")
            {
                if (players.Contains(tbNewPlayer1.Text))
                {
                    lblNewPlayer1Message.Text = "That player name is aready taken!";
                    lblNewPlayer1Message.ForeColor = Color.Red;
                }
                else
                {
                    if (tbNewPlayer1.Text.Length > 12)
                    {
                        lblNewPlayer1Message.Text = "Your name is too long.";
                        lblNewPlayer1Message.ForeColor = Color.Red;

                    }
                    else
                    {
                        lblNewPlayer1Message.Text = "Your name is ok, good luck!";
                        lblNewPlayer1Message.ForeColor = Color.Green;
                        Player1 = lblNewPlayer1Message.Text;

                    }
                }
            }
        }

        private void tbNewPlayer2_TextChanged(object sender, EventArgs e)
        {
            if (tbNewPlayer2.Text != "")
            {
                if (players.Contains(tbNewPlayer2.Text))
                {
                    lblNewPlayer2Message.Text = "That player name is aready taken!";
                    lblNewPlayer2Message.ForeColor = Color.Red;
                }
                else
                {
                    if (tbNewPlayer2.Text.Length > 12)
                    {
                        lblNewPlayer2Message.Text = "Your name is too long.";
                        lblNewPlayer2Message.ForeColor = Color.Red;

                    }
                    else
                    {
                        lblNewPlayer2Message.Text = "Your name is ok, good luck!";
                        lblNewPlayer2Message.ForeColor = Color.Green;
                        Player2 = lblNewPlayer2Message.Text;
                    }
                }
            }
        }

        public void ResetujPoruke()
        {
            lblNewPlayer1Message.Text = "";
            lblNewPlayer2Message.Text = "";
            lblNewPlayer1Message.ForeColor = Color.Black;
            lblNewPlayer2Message.ForeColor = Color.Black;
        }


    }
}
