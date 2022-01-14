using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GuitarHeroGenerationZ
{
    public class TimeLine //Vertikalni timeLine
    {
        public int height;
        public int width;
        public Duz linija;
        public int vreme;
        public int ukupnoVreme;
        public int pomak;

        public TimeLine(int w, int h, int p, int uv)
        {
            height = h;
            width = w;
            vreme = 0;
            ukupnoVreme = uv;
            pomak = p;

            int x = width / 2;
            int y1 = height * 2 / 10;
            int y2 = height * 8 / 10;

            linija = new Duz(new Tacka(pomak + x, TastaturaIKoordinate.startHeight + y2), new Tacka(pomak + x, TastaturaIKoordinate.startHeight+ y1));
        }

        public void Crtaj(Graphics g)
        {
            g.FillEllipse(BojeKrugova.KockaPoeniCetkica1, new Rectangle(linija.A.X - 25, linija.A.Y-2, 50, 50));
            g.FillEllipse(BojeKrugova.KockaPoeniCetkica1, new Rectangle(linija.B.X - 25, linija.B.Y - 50, 50, 50));
            g.DrawLine(BojeKrugova.TimeLineOlovka, linija.A.X, linija.A.Y, linija.B.X, linija.B.Y);
            double duzina = linija.Duzina() - 20;
            int x = linija.A.X;
            int y = (int)(linija.A.Y - 10 - (duzina * (double)vreme/ukupnoVreme));
            g.FillEllipse(BojeKrugova.KockaPoeniCetkica1, new Rectangle(x - 30, y - 10, 60, 20));
        }
    }
}
