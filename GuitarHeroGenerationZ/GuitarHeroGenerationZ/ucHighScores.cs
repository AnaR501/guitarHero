using GuitarHeroGenerationZ.Properties;
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
    public partial class ucHighScores : UserControl
    {
        public Bitmap bitmap;
        public Graphics g;
        public Image trofej;
        public event EventHandler ButtonClickBackToMenu;

        public ucHighScores()
        {
            InitializeComponent();
            trofej = Resources.trophy;
            bitmap = new Bitmap(pbPlatno.Width, pbPlatno.Height);
            g = Graphics.FromImage(bitmap);
            pbPlatno.Image = bitmap;

            ColumnHeader header1 = new ColumnHeader { Text = "Song", TextAlign = HorizontalAlignment.Left, Width = lvSingleGames.Width / 3 - 10 + 30 };
            ColumnHeader header2 = new ColumnHeader { Text = "Points", TextAlign = HorizontalAlignment.Center, Width = lvSingleGames.Width / 3 - 10 -15};
            ColumnHeader header3 = new ColumnHeader { Text = "Hits Percentage", TextAlign = HorizontalAlignment.Right, Width = lvSingleGames.Width / 3 - 10 -15};
            lvSingleGames.Columns.Add(header1);
            lvSingleGames.Columns.Add(header2);
            lvSingleGames.Columns.Add(header3);
            lvSingleGames.View = View.Details;

            ColumnHeader header11 = new ColumnHeader { Text = "Song", TextAlign = HorizontalAlignment.Left, Width = lvMultiGames.Width / 5 - 10 };
            ColumnHeader header22 = new ColumnHeader { Text = "Points P1", TextAlign = HorizontalAlignment.Center, Width = lvMultiGames.Width / 5 - 10 };
            ColumnHeader header33 = new ColumnHeader { Text = "Hits Percentage P1", TextAlign = HorizontalAlignment.Center, Width = lvMultiGames.Width / 5 - 10 };
            ColumnHeader header4 = new ColumnHeader { Text = "Points P2", TextAlign = HorizontalAlignment.Center, Width = lvMultiGames.Width / 5 - 10 };
            ColumnHeader header5 = new ColumnHeader { Text = "Hits Percentage P2", TextAlign = HorizontalAlignment.Right, Width = lvMultiGames.Width / 5 - 10 };
            lvMultiGames.Columns.Add(header11);
            lvMultiGames.Columns.Add(header22);
            lvMultiGames.Columns.Add(header33);
            lvMultiGames.Columns.Add(header4);
            lvMultiGames.Columns.Add(header5);
            lvMultiGames.View = View.Details;

            Crtaj();
        }

        public void AzurirajLBPlayers()
        {
            //u zavisnosti od izabrane opcije cbSongs treba da prikazem sve odigrane Single partije te pesme
            lvPlayers.Items.Clear();
            lvPlayers.Columns.Clear();
            if (cbSongs.Items.Count > 0 && cbDifficulty.Items.Count > 0)
            {
                if (cbSongs.SelectedIndex == -1)
                    cbSongs.SelectedIndex = 0;
                bool all = cbSongs.SelectedIndex == 0 ? true : false;
                List<Player> items = Form1.bazaPodataka.GetAllPlayers(cbDifficulty.SelectedItem.ToString(), cbSongs.SelectedItem.ToString(), all);

                if (cbSongs.SelectedIndex == 0)
                {
                    ColumnHeader header1 = new ColumnHeader { Text = "Player", TextAlign = HorizontalAlignment.Left, Width = lvPlayers.Width/2 -10};
                    ColumnHeader header2 = new ColumnHeader { Text = "Points", TextAlign = HorizontalAlignment.Right, Width = lvPlayers.Width / 2-10}; 
                    lvPlayers.Columns.Add(header1);
                    lvPlayers.Columns.Add(header2);
                    lvPlayers.View = View.Details;
                    for (int i = 0; i < items.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(items[i].Name);
                        item.SubItems.Add(items[i].BrPoena.ToString());
                        lvPlayers.Items.Add(item);
                    }
                }
                else
                {
                    ColumnHeader header1 = new ColumnHeader { Text = "Player", TextAlign = HorizontalAlignment.Left, Width = lvPlayers.Width / 3 -10};
                    ColumnHeader header2 = new ColumnHeader { Text = "Points", TextAlign = HorizontalAlignment.Center, Width = lvPlayers.Width / 3 -10};
                    ColumnHeader header3 = new ColumnHeader { Text = "Hits Percentage", TextAlign = HorizontalAlignment.Right, Width = lvPlayers.Width / 3 -10};
                    lvPlayers.Columns.Add(header1);
                    lvPlayers.Columns.Add(header2);
                    lvPlayers.Columns.Add(header3);
                    lvPlayers.View = View.Details;
                    for (int i = 0; i < items.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(items[i].Name);
                        item.SubItems.Add(items[i].BrPoena.ToString());
                        item.SubItems.Add(items[i].ProcenatPogodaka.ToString() + "%");
                        lvPlayers.Items.Add(item);
                    }
                }
            }
        }

        public void AzurirajLBSingleGames()
        {
            int suma = 0;
            lvSingleGames.Items.Clear();
            if (cbSinglePlayer.Items.Count > 0 && cbDifficulty.Items.Count > 0) //&& 
            {
                if (cbSinglePlayer.SelectedIndex == -1)
                    cbSinglePlayer.SelectedIndex = 0;
                List<SingleGame> items = Form1.bazaPodataka.GetSingleGames(cbDifficulty.SelectedItem.ToString(), cbSinglePlayer.SelectedItem.ToString());

                for (int i = 0; i < items.Count; i++)
                {
                    suma += items[i].brPoena;

                    ListViewItem item = new ListViewItem(items[i].SongName);
                    item.SubItems.Add(items[i].brPoena.ToString());
                    item.SubItems.Add(items[i].procenatPogodaka.ToString() + "%");
                    lvSingleGames.Items.Add(item);
                }
                lblSum.Text = "Points in total: " + suma;
            }
        }

        public void AzurirajLBMultiGames()
        {
            int sum1 = 0, sum2 = 0;
            lvMultiGames.Items.Clear();
            if (cbMultiPlayer1.Items.Count > 0 && cbMultiPlayer2.Items.Count > 0)
            {
                if (cbMultiPlayer1.SelectedIndex == -1)
                    cbMultiPlayer1.SelectedIndex = 0;
                if (cbMultiPlayer2.SelectedIndex == -1)
                    cbMultiPlayer2.SelectedIndex = 0;
                List<MultiGame> items = Form1.bazaPodataka.GetMultiGames(cbDifficulty.SelectedItem.ToString(), cbMultiPlayer1.SelectedItem.ToString(), cbMultiPlayer2.SelectedItem.ToString());

                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].procenatPogodaka1 > items[i].procenatPogodaka2 || (items[i].procenatPogodaka1 == items[i].procenatPogodaka2 && items[i].brPoena1 > items[i].brPoena2))
                        sum1++;
                    else
                        sum2++;

                    ListViewItem item = new ListViewItem(items[i].SongName);
                    item.SubItems.Add(items[i].brPoena1.ToString());
                    item.SubItems.Add(items[i].procenatPogodaka1.ToString() + "%");
                    item.SubItems.Add(items[i].brPoena2.ToString());
                    item.SubItems.Add(items[i].procenatPogodaka2.ToString() + "%");
                    lvMultiGames.Items.Add(item);

                }
                if (sum1 == 0 && sum2 == 0)
                    lblScore.Text = "";
                else
                    lblScore.Text = $"{sum1} : {sum2}";
            }
        }

        public void PostaviHighScores() //postavi konekciju i izvuci iz baze sve sto ti treba
        {
            if (cbSongs.Items.Count == 0)
            {
                List<string> pesme = Form1.bazaPodataka.GetSongNames();
                if (pesme.Count > 0)
                {
                    cbSongs.Items.Add("All songs");
                    cbSongs.SelectedIndex = 0;
                }
                for (int i = 0; i < pesme.Count; i++)
                    cbSongs.Items.Add(pesme[i]);
            }

            if (cbDifficulty.Items.Count == 0)
            {
                cbDifficulty.Items.Add("Easy");
                cbDifficulty.Items.Add("Hard");
                cbDifficulty.SelectedIndex = 0;
            }



            //Izvlacimo iz baze podatke o korisnicima, mozda smo dodali nekog u medjuvremenu od kad smo pokrenuli aplikaciju
            cbSinglePlayer.Items.Clear();
            cbMultiPlayer1.Items.Clear();
            cbMultiPlayer2.Items.Clear();

            List<string> names = Form1.bazaPodataka.GetPlayerNames();
            for (int i = 0; i < names.Count; i++)
            {
                cbSinglePlayer.Items.Add(names[i]);
                cbMultiPlayer1.Items.Add(names[i]);
                cbMultiPlayer2.Items.Add(names[i]);
            }

            if (cbSinglePlayer.Items.Count > 0)
                cbSinglePlayer.SelectedIndex = 0;
            if (cbMultiPlayer1.Items.Count > 0)
                cbMultiPlayer1.SelectedIndex = 0;
            if (cbMultiPlayer2.Items.Count > 1)
                cbMultiPlayer2.SelectedIndex = 1;
            else if (cbMultiPlayer2.Items.Count > 0)
                cbMultiPlayer2.SelectedIndex = 0;


            AzurirajLBPlayers();
            AzurirajLBSingleGames();
            AzurirajLBMultiGames();
        }

        public void Crtaj()
        {
            g = Graphics.FromImage(pbPlatno.Image);
            g.DrawImage(trofej, pbPlatno.Width*2/10, pbPlatno.Height*2/10, pbPlatno.Width/12, pbPlatno.Height*6/10);
            Rectangle rect1 = new Rectangle(pbPlatno.Width*3/10, pbPlatno.Height/10, pbPlatno.Width*4/10, pbPlatno.Height*8/10);
            Font myFont2 = new Font("Stencil", 46);


            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString("High Scores", myFont2, new SolidBrush(Color.Black), rect1, stringFormat);

            g.DrawImage(trofej, pbPlatno.Width * 70 / 100, pbPlatno.Height * 2 / 10, pbPlatno.Width / 12, pbPlatno.Height * 6 / 10);
            pbPlatno.Image = bitmap;
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickBackToMenu != null)
                this.ButtonClickBackToMenu(this, e);
        }

        private void cbDifficulty_SelectedValueChanged(object sender, EventArgs e)
        {
            //azuriram sve
            AzurirajLBPlayers();
            AzurirajLBSingleGames();
            AzurirajLBMultiGames();
        }

        private void cbSongs_SelectedValueChanged(object sender, EventArgs e)
        {
            AzurirajLBPlayers();
        }

        private void cbSinglePlayer_SelectedValueChanged(object sender, EventArgs e)
        {
            AzurirajLBSingleGames();
        }

        private void cbMultiPlayer_SelectedValueChanged(object sender, EventArgs e)
        {
            AzurirajLBMultiGames();
        }
    }
}
