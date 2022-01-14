using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarHeroGenerationZ
{
    public partial class ucMultiPlayerGame : UserControl
    {
        public Bitmap bitmap;
        public Graphics g;
        public int d1; //proporcije rastojanja u odnosu na dimenzije PictureBox-a
        public int d2;
        public int h;
        public NovaIgraMultiPlayer igra;       //Single igra, Multi nasledjuje Single


        public int widthDownLeft;
        public int widthDownMiddle;
        public int widthDownRight;
        public int widthUpLeft;
        public int widthUpMiddle;
        public int widthUpRight;
        public int startHeight;
        public int height;

        public String Player1 { get; set; }
        public String Player2 { get; set; }
        public Song mySong { get; set; }
        public string Difficulty { get; set; } 
        public WMPLib.WindowsMediaPlayer wplayer;
        public KockaPoeniComboMulti poeniCombo1;
        public KockaPoeniComboMulti poeniCombo2;
        public TimeLine tline;

        public event EventHandler ButtonClickPause;
        public delegate void PrikaziKrajMultiIgre(string Player1, int brPoena1, double procenatPogodaka1, string Player2, int brPoena2, double procenatPogodaka2);
        public event PrikaziKrajMultiIgre prikaziKrajMultiIgre;

        public int brojac;
        public int hTimer;

        public int brPreskakanja; //zavisi od pesme, da bi se prilagodila vrednost intervala - timera
        public bool daLiSePreskace;
        public int tmp;


        public ucMultiPlayerGame()
        {
            InitializeComponent();

            bitmap = new Bitmap(pbPlatno.Width, pbPlatno.Height);
            g = Graphics.FromImage(bitmap);
            pbPlatno.Image = bitmap;

            widthDownLeft = pbPlatno.Width * 46 / 100;
            widthDownMiddle = pbPlatno.Width * 8 / 100;
            widthDownRight = pbPlatno.Width * 46 / 100;
            startHeight = pbPlatno.Height * 30 / 100;
            height = pbPlatno.Height;
            brojac = 0;
            widthUpLeft = pbPlatno.Width * 35 / 100;
            widthUpMiddle = pbPlatno.Width * 30 / 100;
            widthUpRight = pbPlatno.Width * 35 / 100;


            tmp = 0;



            d1 = widthDownLeft * 17 / 100;
            d2 = (int)(widthDownLeft * 16.5 / 100);
            h = height - ((height - startHeight) / 7);


        }

        private void Crtaj()
        {
            g = Graphics.FromImage(pbPlatno.Image);
            g.Clear(Color.FromArgb(156, 197, 161));
            igra.Crtaj(g);
            if (tline != null)
                tline.Crtaj(g);
            pbPlatno.Image = bitmap;
        }

        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);

        private void ucMultiPlayerGame_KeyDown(object sender, KeyEventArgs e)
        {
            byte[] keys = new byte[256];

            GetKeyboardState(keys);

            if ((keys[(int)Keys.Escape] & 128) == 128) 
                btnPause_Click(sender, e);
            else
                igra.KeyDown(ref keys); 

            Crtaj();
        }


        private void ucMultiPlayerGame_KeyUp(object sender, KeyEventArgs e)
        {
            byte[] keys = new byte[256];
            GetKeyboardState(keys);


            igra.KeyUp(ref keys);

            Crtaj();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Krug se brise kada se pogodi ili kad ispadne iz ekrana
            //Ako se pogodi, indCiljanihKrugova treba da ostane isti jer ce na njegovo mesto u listi da dodje odgovarajuci krug
            //Ako ispadne iz ekrana, indCiljanihKrugova treba da se smanji za 1 da bi pokazivao i dalje na isti krug

            tmp++;
            if (!daLiSePreskace || (daLiSePreskace && tmp % mySong.BrPreskakanja != 0))
            {
                hTimer--;
                brojac++;
                if (hTimer > 0 && !igra.krajIgre)
                {
                    tline.vreme++;
                    if (brojac == 10)
                    {
                        //Dodavanje balona
                        if (igra.index < igra.note.Count)//zavisi od izabrane tezine
                        {
                            brojac -= 10;
                            igra.DodajElipse();
                        }
                        igra.DodajPoprecnuLiniju(height);
                    }
                    //Pomeranje elipsi i poprecnih linija
                    igra.PomeriElipse();
                    //Provera da li se promenio Cijani Akord, tj. da li je set krugova koji ciljamo ispao iz fokusa
                    igra.ProveraCiljanogKrugaP1();
                    igra.ProveraCiljanogKrugaP2();
                    //Kraj igre je kada istekne vreme pesmi
                    igra.IspaoIzEkranaP1(this.pbPlatno.Height);
                    igra.IspaoIzEkranaP2(this.pbPlatno.Height);
                    Crtaj();
                }
                else
                {
                    int maxAkorda = mySong.MaxBrAkorda;
                    double procenatPogodaka1 = (double)igra.getBrPogodjenihAkordaP1() * 100 / igra.ukupnoAkordaP1;
                    double procenatPogodaka2 = (double)igra.getBrPogodjenihAkordaP2() * 100 / igra.ukupnoAkordaP2;
                    wplayer.controls.stop();
                    timer1.Stop();
                    wplayer = null;
                    if (prikaziKrajMultiIgre != null)
                    {
                        if (procenatPogodaka1 > procenatPogodaka2 || (procenatPogodaka1 == procenatPogodaka2 && poeniCombo1.brPoena > poeniCombo2.brPoena))
                            prikaziKrajMultiIgre(Player1, poeniCombo1.brPoena, procenatPogodaka1, Player2, poeniCombo2.brPoena, procenatPogodaka2);
                        else
                            prikaziKrajMultiIgre(Player2, poeniCombo2.brPoena, procenatPogodaka2, Player1, poeniCombo1.brPoena, procenatPogodaka1);
                        Form1.bazaPodataka.DodajMultiGame(Player1, Player2, mySong.Name, poeniCombo1.brPoena, poeniCombo2.brPoena,
                            procenatPogodaka1, procenatPogodaka2, Difficulty);
                    }
                }
            }
        }

        public void PocniIgru()
        {
            if (mySong.BrPreskakanja > 0)
                daLiSePreskace = true;
            else
                daLiSePreskace = false;

            //Dimenzije Elipsi:
            Elipsa.RX = widthDownLeft * 13 / 100;
            Elipsa.RY = widthDownLeft * 8 / 100;
            PowerElipsa.powerRx = widthUpLeft / 5;
            PowerElipsa.powerRy = startHeight / 10;
            TastaturaIKoordinate.PostaviKoord(d1, d1 + d2, d1 + 2 * d2, d1 + 3 * d2, d1 + 4 * d2, h);
            TastaturaIKoordinate.PostaviStartDimenzije(widthDownLeft + widthDownMiddle, startHeight);
            poeniCombo1 = new KockaPoeniComboMulti(startHeight, widthUpLeft, 0, 2);
            poeniCombo2 = new KockaPoeniComboMulti(startHeight, widthUpRight, widthUpLeft + widthUpMiddle, 2);
            igra = new NovaIgraMultiPlayer(Player1, Player2, d1, d2, h, poeniCombo1, poeniCombo2, widthDownLeft + widthDownMiddle, mySong.MaxBrAkorda);
            igra.singleIliMulti = true;
            string putanjaNota = Difficulty;
            putanjaNota = putanjaNota + mySong.Name + ".txt";
            PreuzmiNoteIzFajla(putanjaNota);
            tline = new TimeLine(widthDownMiddle, height - TastaturaIKoordinate.startHeight, widthDownLeft, mySong.Duration);
            hTimer = mySong.Duration;
            this.timer1.Interval = mySong.Interval;
            this.timer1.Start();
            wplayer = new WMPLib.WindowsMediaPlayer();
            brojac = 0;
            wplayer.URL = mySong.Name + ".mp3";
            wplayer.settings.volume = TastaturaIKoordinate.Volume;
            wplayer.controls.play();
        }

        public void PreuzmiNoteIzFajla(string putanjaNota)
        {
            putanjaNota = "..//..//" + putanjaNota;
            StreamReader sr = new StreamReader(putanjaNota);
            string line;
            igra.note.Clear();
            while (!sr.EndOfStream)
                igra.note.Add(line = sr.ReadLine());
            sr.Close();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickPause != null)
                this.ButtonClickPause(this, e);
        }

        public void Pauziraj()
        {
            timer1.Stop();
            wplayer.controls.pause();
        }

        public void NastaviIgru()
        {
            timer1.Start();
            wplayer.controls.play();
        }

        public void RestartujIgru()
        {
            igra = null;
            NovaIgraMultiPlayer igra2 = new NovaIgraMultiPlayer(Player1, Player2, d1, d2, h, poeniCombo1, poeniCombo2, widthDownLeft + widthDownMiddle, mySong.MaxBrAkorda);
            igra = igra2;
            igra.singleIliMulti = true;

            string putanjaNota = Difficulty;
            putanjaNota = putanjaNota + mySong.Name + ".txt";
            PreuzmiNoteIzFajla(putanjaNota);

            tline = null;
            TimeLine tline2 = new TimeLine(widthDownMiddle, height - TastaturaIKoordinate.startHeight, widthDownLeft, mySong.Duration);
            tline = tline2;

            timer1 = null;
            Timer timer2 = new Timer();
            timer2.Interval = mySong.Interval;
            hTimer = mySong.Duration;
            timer2.Tick += new System.EventHandler(this.timer1_Tick);
            timer1 = timer2;
            timer1.Start();

            wplayer = null;
            WMPLib.WindowsMediaPlayer wplayer2 = new WMPLib.WindowsMediaPlayer();
            wplayer = wplayer2;
            wplayer.URL = mySong.Name + ".mp3";
            wplayer.settings.volume = TastaturaIKoordinate.Volume;
            wplayer.controls.play();

            poeniCombo1.Resetuj();
            poeniCombo2.Resetuj();
            brojac = 0;
        }

        public void ZavrsiIgru()
        {
            mySong = null;
            igra.podloga1 = null;
            igra.podloga2 = null;
            igra = null;
            wplayer = null;
            poeniCombo1 = null;
            poeniCombo2 = null;
            tline = null;
        }

    }
}
