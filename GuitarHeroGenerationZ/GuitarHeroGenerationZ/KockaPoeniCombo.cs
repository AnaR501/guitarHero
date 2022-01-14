using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GuitarHeroGenerationZ
{
    public class KockaPoeniCombo
    {
        public int windowHeight;
        public int windowWidth;

        public int brPoena;
        public int Combo;
        public int mnoziPoene;
        public int moci;
        public bool PowerMode;

        public List<PowerElipsa> elipse;
        public int x1, x2, y1, y2;


        public KockaPoeniCombo(int wH, int wW, int _widthLeft, int oznaka)
        {
            windowHeight = wH;
            windowWidth = wW;
            brPoena = 0;
            Combo = 0;
            mnoziPoene = 1;
            moci = 0;
            PowerMode = false;
            elipse = new List<PowerElipsa>();

            if (oznaka == 1) //Drugacije crtamo kocku u SinglePlayer i MultiPlayer partiji
            {
                x1 = _widthLeft + windowWidth * 20 / 100;
                x2 = _widthLeft + windowWidth;
                y1 = windowHeight * 40 / 100;
                y2 = windowHeight * 85 / 100;
                elipse.Add(new PowerElipsa(x1, y2 - PowerElipsa.powerRy - 5));
                elipse.Add(new PowerElipsa(x1, y2 - PowerElipsa.powerRy * 3 - 5 - 5));
                elipse.Add(new PowerElipsa(x1, y2 - PowerElipsa.powerRy * 5 - 10 - 5));
                elipse.Add(new PowerElipsa(x1, y2 - PowerElipsa.powerRy * 7 - 15 - 5));
                elipse.Add(new PowerElipsa(x1, y2 - PowerElipsa.powerRy * 9 - 20 - 5));
            }
            else if (oznaka == 2) //Ne crtam ih 5 nego 3 i vece su i treba da sadrze moci
            {
                x1 = _widthLeft + windowWidth * 30 / 100;
                x2 = _widthLeft + windowWidth * 70 / 100;
                y1 = windowHeight * 15 / 100;
                y2 = windowHeight * 85 / 100;
                elipse.Add(new PowerElipsa(x1 - PowerElipsa.powerRx/6, y2 - PowerElipsa.powerRy - 5));
                elipse.Add(new PowerElipsa(x1 - PowerElipsa.powerRx/6, y2 - PowerElipsa.powerRy * 3 - 5 - 5));
                elipse.Add(new PowerElipsa(x1 - PowerElipsa.powerRx/6, y2 - PowerElipsa.powerRy * 5 - 10 - 5));
            }

        }

        public virtual void Crtaj(Graphics g)
        {
            //crtanje elipsi
            for (int i = 0; i < elipse.Count; i++)
                elipse[i].Crtaj(g, moci - i);
            //crtanje pravougaonika
            Rectangle rect1 = new Rectangle(x1, y1, x2 - x1, y2 - y1);
            Rectangle rect2 = new Rectangle(x1, y1, (x2 - x1)*8/10, (y2 - y1)/10);
            Rectangle rect3 = new Rectangle(x1 + (x2 - x1)*2 /10, y1 + (y2-y1)*9/10, (x2 - x1)* 8/10+1, (y2 - y1)/10+1);
            g.FillRectangle(BojeKrugova.KockaPoeniCetkica1, rect1);
            g.FillRectangle(BojeKrugova.KockaPoeniCetkica2, rect2);
            g.FillRectangle(BojeKrugova.KockaPoeniCetkica2, rect3);
            Font myFont1 = new Font("Arial", 18);
            Font myFont2 = new Font("Arial", 40);


            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            if (PowerMode)
                g.DrawString("x" + mnoziPoene.ToString(), myFont2, BojeKrugova.PowerCetkica, rect1, stringFormat);
            else
                g.DrawString("x" + mnoziPoene.ToString(), myFont2, Brushes.White, rect1, stringFormat);
            
            g.DrawString(brPoena.ToString(), myFont1, Brushes.White, rect2, stringFormat);
            g.DrawString(Combo.ToString(), myFont1, Brushes.White, rect3, stringFormat);
        }

        public void AzurirajCombo(bool povecaj) //ako je povecaj = true onda povecamo Combo za 1,
                                                //ako je false ostavljamo ga na 0
        {
            if (povecaj)
                Combo++;
            else
                Combo = 0;
            //izracunavanje mnozioca
            mnoziPoene = Combo / 10;
            if (mnoziPoene > 4)
                mnoziPoene = 4;
            else if (mnoziPoene == 0)
                mnoziPoene = 1;
            if (PowerMode)
                mnoziPoene *= 2;
        }

        public virtual void PokreniPowerMode()
        {
            PowerMode = true;
            moci = 0;
            mnoziPoene *= 2;
        }

        public virtual void ZavrsiPowerMode()
        {
            PowerMode = false;
            mnoziPoene /= 2;
        }

        public virtual void Resetuj()
        {
            brPoena = 0;
            Combo = 0;
            mnoziPoene = 1;
            moci = 0;
            PowerMode = false;
        }

        public virtual int getMoci()
        {
            if (moci > 5)
                return 5;
            else
                return moci;
        }

        public virtual void DodajPower(PowerMultiPlayer p)
        {
        }

        public virtual PowerMultiPlayer getMoc()
        {
            return null;
        }

    }

    public class KockaPoeniComboMulti : KockaPoeniCombo
    {
        public List<PowerMultiPlayer> moci;

        public KockaPoeniComboMulti(int wH, int wW, int _widthLeft, int oznaka) : base(wH, wW, _widthLeft, oznaka)
        {
            moci = new List<PowerMultiPlayer>();
        }

        public override void DodajPower(PowerMultiPlayer p)
        {
            if(moci.Count < 3)
            {
                //promeni dimezije moci da stanu u manje krugova kockaPoenaComba
                moci.Add(p);
                p.X = elipse[moci.Count - 1].X - PowerElipsa.powerRx * 1 / 2 + 10;
                p.Y = elipse[moci.Count - 1].Y;
                p.imageHeight = elipse[moci.Count - 1].RY * 2;
                p.imageWidth = elipse[moci.Count - 1].RX * 4 / 3 - 20;
            }
        }

        public override void Crtaj(Graphics g)
        {
            base.Crtaj(g);
            for (int i = 0; i < moci.Count; i++)
                moci[i].Crtaj(g);
        }

        public override void Resetuj()
        {
            base.Resetuj();
            moci.Clear();
        }

        public override PowerMultiPlayer getMoc()
        {
            if (moci.Count > 0)
                return moci[moci.Count - 1];
            else
                return null;
        }

        public override void PokreniPowerMode()
        {
            if(moci.Count > 0)
            {
                moci.RemoveAt(moci.Count - 1);
                //i u igrici prikazujem moc, ali je ne crtam vise
            }
        }

        public override void ZavrsiPowerMode()
        {
            PowerMode = false;
        }

        public override int getMoci()
        {
            return moci.Count;
        }

    }




}
