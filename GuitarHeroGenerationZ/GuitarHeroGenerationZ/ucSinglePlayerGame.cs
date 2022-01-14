using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace GuitarHeroGenerationZ
{
    public partial class ucSinglePlayerGame : UserControl
    {
        public Bitmap bitmap;
        public Graphics g;
        public int d1; //proporcije rastojanja u odnosu na dimenzije PictureBox-a
        public int d2;
        public int h;
        public NovaIgra igra;       //Single igra, Multi nasledjuje Single


        public int widthLeft;
        public int widthMiddle;
        public int widthRight;
        public int height;

        public String Player { get; set; }
        public Song mySong { get; set; }
        public string Difficulty { get; set; } 
        public WMPLib.WindowsMediaPlayer wplayer;
        public KockaPoeniCombo poeniCombo;
        public TimeLine tline;

        public event EventHandler ButtonClickPause;
        public delegate void PrikaziKrajSingleIgre(int brPoena, double procenatPogodaka);
        public event PrikaziKrajSingleIgre prikaziKrajSingleIgre;
        public int brojac;
        public int hTimer;

        public int brPreskakanja; //zavisi od pesme, da bi se prilagodila vrednost intervala - timera
        public bool daLiSePreskace;
        public int tmp;



        public ucSinglePlayerGame()
        {
            InitializeComponent();

            bitmap = new Bitmap(pbPlatno.Width, pbPlatno.Height);
            g = Graphics.FromImage(bitmap);
            pbPlatno.Image = bitmap;

            widthLeft = pbPlatno.Width * 27 / 100;
            widthMiddle = pbPlatno.Width * 58 / 100;
            widthRight = pbPlatno.Width * 15 / 100;
            height = pbPlatno.Height;
            brojac = 0;

            tmp = 0;



            d1 = widthMiddle * 17 / 100;
            d2 = (int)(widthMiddle * 16.5 / 100);
            h = (int)(height * 8.5 / 10);


        }

        private void Crtaj()
        {
            g = Graphics.FromImage(pbPlatno.Image);
            g.Clear(Color.FromArgb(156, 197, 161));
            igra.Crtaj(g);
            if(tline!= null)
                tline.Crtaj(g);
            pbPlatno.Image = bitmap;
        }

        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);



        private void ucSinglePlayerGame_KeyDown(object sender, KeyEventArgs e)
        {
            byte[] keys = new byte[256];

            GetKeyboardState(keys);

            if ((keys[(int)Keys.Escape] & 128) == 128 || (keys[(int)Keys.P] & 128) == 128)
                btnPause_Click(sender, e);
            else
                igra.KeyDown(ref keys); //vraca poruku da li treba da se update-uju labele za broj poena i combo

            Crtaj();
        }


        private void ucSinglePlayerGame_KeyUp(object sender, KeyEventArgs e)
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
            if (!daLiSePreskace || (daLiSePreskace &&  tmp % mySong.BrPreskakanja != 0))
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
                            igra.DodajElipsePlayer1();
                        }
                        igra.DodajPoprecnuLiniju(height);
                    }
                    //Pomeranje elipsi i poprecnih linija
                    igra.PomeriElipse();
                    //Provera da li se promenio Cijani Akord, tj. da li je set krugova koji ciljamo ispao iz fokusa
                    igra.ProveraCiljanogKrugaP1();
                    //Kraj igre je kada istekne vreme pesmi
                    igra.IspaoIzEkranaP1(this.pbPlatno.Height);
                    Crtaj();
                }
                else
                {
                    UpisiBrDodatihAkorda();
                    int maxAkorda = mySong.MaxBrAkorda;
                    double procenatPogodaka = (double)igra.getBrPogodjenihAkordaP1() * 100 / igra.ukupnoAkordaP1;
                    wplayer.controls.stop();
                    timer1.Stop();
                    wplayer = null;
                    if (prikaziKrajSingleIgre != null)
                    {
                        prikaziKrajSingleIgre(poeniCombo.brPoena, procenatPogodaka);
                        Form1.bazaPodataka.DodajSingleGame(Player, mySong.Name, poeniCombo.brPoena, procenatPogodaka, Difficulty);
                    }
                }
            }
        }

        public void UpisiBrDodatihAkorda()
        {
            StreamWriter sw = new StreamWriter("..//..//brDodatihAkorda.txt");
            sw.WriteLine(igra.brDodatihAkorda);
            sw.WriteLine(wplayer.settings.volume);
            sw.Close();
        }

        public void PocniIgru()
        {
            if (mySong.BrPreskakanja > 0)
                daLiSePreskace = true;
            else
                daLiSePreskace = false;

            //Dimenzije Elipsi:
            Elipsa.RX = widthMiddle * 12 / 100;
            Elipsa.RY = widthMiddle * 8 / 100;
            PowerElipsa.powerRx = widthLeft / 10;
            PowerElipsa.powerRy = height / 25;
            TastaturaIKoordinate.PostaviKoord(widthLeft + d1, widthLeft + d1 + d2, widthLeft + d1 + 2 * d2, widthLeft + d1 + 3 * d2, widthLeft + d1 + 4 * d2, h);
            TastaturaIKoordinate.PostaviStartDimenzije(0,0);
            poeniCombo = new KockaPoeniCombo(height, widthLeft, 0, 1);
            igra = new NovaIgra(Player, d1, d2, h, poeniCombo);
            string putanjaNota = Difficulty;
            putanjaNota = putanjaNota + mySong.Name + ".txt";
            PreuzmiNoteIzFajla(putanjaNota);
            tline = new TimeLine(widthRight, height, widthLeft + widthMiddle, mySong.Duration);
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
            NovaIgra igra2 = new NovaIgra(Player, d1, d2, h, poeniCombo);
            igra = igra2;
            string putanjaNota = Difficulty;
            putanjaNota = putanjaNota + mySong.Name + ".txt";

            PreuzmiNoteIzFajla(putanjaNota);

            tline = null;
            TimeLine tline2 = new TimeLine(widthRight, height, widthLeft + widthMiddle, mySong.Duration);
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
            poeniCombo.Resetuj();
            brojac = 0;
        }

        public void ZavrsiIgru()
        {
            Player = null;
            mySong = null;
            igra.podloga1 = null;
            igra.poeniCombo1 = null;
            igra = null;
            wplayer = null;
            poeniCombo = null;
            tline = null;
        }
    }
}
