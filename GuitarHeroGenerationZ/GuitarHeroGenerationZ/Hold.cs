using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GuitarHeroGenerationZ
{
    public class Hold
    {
        public Duz linija;
        public bool Pogodjeno { get; set; } //Ako je Pogodjeno = true, to znaci da se kod pomeranja pomera samo 1 kraj duzi

        public bool VidljivGornjiKraj { get; set; } //Ako je vidljiv gornji kraj Holda (pojavio se na ekranu) onda pomeramo
                                                // gornju tacku linije Hold-a

        public int pozicijaHolda; //Isto kao i pozicija kruga, redni broj mesta, odredjuje Boju

        public int ModCrtanja; //ako je 1, crta se normalno u boji, ako je Power mode onda se crta plavo

        //Kada dugme treba da se drzi pretisnuto, crta se kao siroka linija, elipsa ima pokazivac na hold koji je
        //null ako holda nema, ako se akord pogodi onda se referenca prebacuje njemu za iscrtavanje, kada se u fajlu
        //naidje na X onda OD SLEDECEG AKORDA NEMA VISE HOLDA, NX je onda mini hold?

        public Hold(int x, int y, int poz) //Crta se odozgo na dole, tj tacka A je iznad tacke B
        {
            Tacka a = new Tacka(x, y-50), b = new Tacka(x, y); //-50 zato sto se hold zavrsava na pola sledeceg akorda
            linija = new Duz(a, b);
            Pogodjeno = false;
            ModCrtanja = 1;
            VidljivGornjiKraj = false;
            pozicijaHolda = poz;
        }

        public bool pomeri(int pomak) //vraca true ako Hold treba da se brise, tj kada se koordinate izjednace
        {
            if(VidljivGornjiKraj)
            {
                linija.A.Y += pomak;
            }
            if (!Pogodjeno)
            {
                linija.B.Y += pomak;
            }
            if (linija.A.Y >= linija.B.Y)
                return true;
            else
                return false;
        }

        public void Crtaj(Graphics g)
        {
            int ymin;
            if (linija.A.Y < TastaturaIKoordinate.startHeight)
                ymin = TastaturaIKoordinate.startHeight;
            else
                ymin = linija.A.Y;
            if(ModCrtanja == 1) //crtamo u boji osnovnih elipsi
                g.DrawLine(BojeKrugova.Olovke[pozicijaHolda-1], linija.A.X, ymin, linija.B.X, linija.B.Y);
            else if (ModCrtanja == 2) //crtamo Power bojom
                g.DrawLine(BojeKrugova.PowerOlovka, linija.A.X, ymin, linija.B.X, linija.B.Y);
        }

        public void resetXKoord(int i, int poz, int startWidth)
        {
            if (i == 1 || i == 2)
            {
                linija.A.X = startWidth + TastaturaIKoordinate.getXKoord(poz, i);
                linija.B.X = startWidth + TastaturaIKoordinate.getXKoord(poz, i);
            }
        }

    }
}
