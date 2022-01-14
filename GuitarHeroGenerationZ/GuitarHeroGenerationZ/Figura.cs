using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHeroGenerationZ
{
    public abstract class Figura
    {
        public abstract void Crtaj(Graphics g);


    }

    public class Tacka : Figura
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Tacka(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override void Crtaj(Graphics g)
        {
            SolidBrush myBrush;
            myBrush = new SolidBrush(Color.FromArgb(0, 0, 255));
            g.FillEllipse(myBrush, X - 3, Y - 3, 6, 6);
        }
    }

    public class Elipsa : Figura //Padajuce elipse na ekranu koje predstavljaju akorde koji treba da se pogode
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static int RX { get; set; } //horizontalni precnik elipse
        public static int RY { get; set; } //vertikalni precnik elipse

        public int PozicijaElipse { get; set; } //Uzima vrednosti 1,2,3,4,5. Pozicija odredjuje boju 

        public int ModCrtanja { get; set; } //pokazatelj kako treba crtati elipsu: mod1 (clasic), mod2 (pritisnuto/odabrano), mod3 (power mode)

        public Hold rep; //pokazatelj da li padajuca Elipsa ima Hold, odnosno da li je igrac pogodio Hold (sto se onda pamti i crta preko osnovne ELipse

        public PowerMultiPlayer power;

        public bool Vidljiva;
        public int timerNevidljiv; //vreme dok je vidljiv je duplo duze od vremena kad je nevidljiv
        public int preostaloVreme; //preostalo vreme do promene vidljivosti u Eartquake Modu

        public Elipsa(int x, int y, int poz) //ako je postaviHold = true onda pravimo instancu Hold-a
        {
            X = x;
            Y = y;
            PozicijaElipse = poz;
            ModCrtanja = 1;
            rep = null;
            power = null;
            Vidljiva = true;
        }

        public override void Crtaj(Graphics g)
        {
            if(rep != null && Vidljiva)
                rep.Crtaj(g);
            if (ModCrtanja == 1 || (Vidljiva && ModCrtanja == 4)) //Obican mod, samo nacrtamo elipsu na odgovarajuce mestu i u odgovarajujcoj boji
            {
                g.FillEllipse(BojeKrugova.Cetkice[PozicijaElipse-1], X - RX / 2, Y - RY / 2, RX, RY);
            }
            else if (ModCrtanja == 2) //POWER mode, elipse postanu plave
            {
                g.FillEllipse(BojeKrugova.PowerCetkica, X - RX / 2, Y - RY / 2, RX, RY);
            }
            else if (ModCrtanja == 3) //Oznacava da ova elipsa nosi moc na sebi
            {
                g.FillEllipse(BojeKrugova.Cetkice[PozicijaElipse - 1], X - RX / 2, Y - RY / 2, RX, RY);
                g.FillEllipse(BojeKrugova.PowerCetkica, X - RX / 4, Y - RY / 4, RX/2, RY/2);
            }
            if (power != null)
                power.Crtaj(g);
        }

        public void DodajNoviHold()
        {
            rep = new Hold(X, Y, PozicijaElipse);
        }

        public virtual bool Pomeri(int pomak) //vraca true ako su se koordinate repa spojile, to moze da se desi samo u Osnovnom krugu
        {
            Y += pomak;
            if (rep != null)
                if (rep.pomeri(pomak)) //ako su se koordinate spojile
                    rep = null;
            if (power != null)
                power.Pomeri(pomak);
            if(ModCrtanja == 4) //ako je pokrenut EarthQuake vodimo racuna o tajmeru
            {
                preostaloVreme--;
                if (preostaloVreme <= 0)
                {
                    Vidljiva = !Vidljiva;
                    if (Vidljiva)
                        preostaloVreme = timerNevidljiv;
                    else
                        preostaloVreme = timerNevidljiv * 7/12;
                }
            }
            return false;
        }

        public void PokreniEarthquake(int t, int k)
        {
            timerNevidljiv = t;
            preostaloVreme = k;
            ModCrtanja = 4;
        }

        public void resetXKoord(int i, int startWidth)
        {
            X = startWidth + TastaturaIKoordinate.getXKoord(PozicijaElipse-1, i);
            if (rep != null)
                rep.resetXKoord(i, PozicijaElipse-1, startWidth);
            if (power != null)
                power.resetXKoord(i, PozicijaElipse - 1, startWidth);
        }

    }

    public class OsnovnaElipsa : Elipsa
    {

        public OsnovnaElipsa(int x, int y, int pozicija) : base(x, y, pozicija)
        {
        }

        public override void Crtaj(Graphics g)
        {
            if(rep != null)
                rep.Crtaj(g);

            g.FillEllipse(BojeKrugova.Cetkice[PozicijaElipse-1], X - RX / 2, Y - RY / 2, RX, RY);
            if (ModCrtanja == 1) //Obican mod, nacrtamo elipsu na odgovarajucem mestu sa svetlo sivim krugom u sredini
            {
                g.FillEllipse(BojeKrugova.svetlnoSiva, X - RX / 4, Y - RY / 4, RX / 2, RY / 2);
            }
            else if (ModCrtanja == 2) //Pretisnut mod, nacrtamo elipsu na odgovarajucem mestu sa tamno sivim krugom u sredini
            {
                g.FillEllipse(BojeKrugova.tamnoSiva, X - RX / 4, Y - RY / 4, RX / 2, RY / 2);
            }
            else if (ModCrtanja == 3) //dugme je zabranjeno
            {
                g.FillEllipse(new SolidBrush(Color.Black), X - RX / 2, Y - RY / 2, RX, RY);
            }
        }

        public void PostaviHold(Hold h)
        {
            rep = h;
        }

        public void ObrisiHold()
        {
            if (rep != null)
                rep = null;
        }

        public bool RegistrujKeyUp(bool hold) //ako je bio Hold, brise rep
        {
            if (ModCrtanja != 3)
            {
                ModCrtanja = 1;
                if (hold)
                {
                    if (rep != null)
                    {
                        rep = null;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool RegistrujKeyDown(bool hold)
        {
            if (ModCrtanja != 3)
            {
                ModCrtanja = 2; //ModCrtanja je 2 kada je dugme pretisnuto
                if (hold)
                {
                    if (rep == null) //ako smo pretisli nesto sto ne treba, onda vracamo true
                                     //kao poruku da treba da obrisemo sve repove osnovninh krugova
                        return true;
                }
            }
            return false;
        }

        public override bool Pomeri(int pomak)
        {
            if (rep != null)
            {
                if (rep.pomeri(pomak)) //ako su se koordinate spojile
                {
                    rep = null;
                    return true;
                }
            }
            return false;
        }
    }
    public class PowerElipsa 
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static int powerRx;
        public static int powerRy;

        public int RX;
        public int RY;

        public PowerElipsa(int x, int y) 
        {
            X = x;
            Y = y;
            RX = powerRx;
            RY = powerRy;
        }

        public void Crtaj(Graphics g, int i)
        {
            if (i <= 0) //crta se providna elipsa - energija nije napunjena
            {
                g.DrawEllipse(BojeKrugova.PowerOlovka, new Rectangle(X - RX, Y - RY, 2 * RX, 2 * RY));
            }
            else //crta se obojena elipsa - energija je napunjena
            {
                g.FillEllipse(BojeKrugova.PowerCetkica, new Rectangle(X - RX, Y - RY, 2 * RX, 2 * RY));
            }
        }
    }


    public class Duz : Figura
    {
        public Tacka A { get; set; }
        public Tacka B { get; set; }

        public Duz(Tacka a, Tacka b)
        {
            A = a;
            B = b;
        }

        public override void Crtaj(Graphics g)
        {
            SolidBrush myBrush;
            myBrush = new SolidBrush(Color.FromArgb(31, 36, 33));
            Pen pen = new Pen(myBrush, 2);
            g.DrawLine(pen, A.X, A.Y, B.X, B.Y);
        }
        public void pomeri(int y)
        {
            A.Y += y;
            B.Y += y;
        }

        public bool Nevidljiva(int height)
        {
            if (A.Y >= height)
                return true;
            else
                return false;
        }

        public double Duzina()
        {
            return (double)Math.Sqrt((B.X - A.X) * (B.X - A.X) + (B.Y - A.Y) * (B.Y - A.Y));
        }
    }

}
