using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHeroGenerationZ
{
    class BojeKrugova
    {
        public static Color[] Boje = new Color[] { Color.Green, Color.Red, Color.Yellow, Color.Blue, Color.Orange };

        public static SolidBrush[] Cetkice = new SolidBrush[] {new SolidBrush(Color.Green), new SolidBrush(Color.Red),
            new SolidBrush(Color.Yellow), new SolidBrush(Color.Blue), new SolidBrush(Color.Orange) };

        public static Pen[] Olovke = new Pen[] {new Pen(Color.Green, 10), new Pen(Color.Red, 10), new Pen(Color.Yellow, 10),
            new Pen(Color.Blue, 10), new Pen(Color.Orange, 10)};

        public static Color PowerBoja = Color.Turquoise;

        public static SolidBrush PowerCetkica = new SolidBrush(Color.Turquoise);

        public static Pen PowerOlovka = new Pen(Color.Turquoise, 10);

        public static SolidBrush svetlnoSiva = new SolidBrush(Color.LightGray);
        public static SolidBrush tamnoSiva = new SolidBrush(Color.FromArgb(150, 150, 150));

        public static SolidBrush KockaPoeniCetkica1 = new SolidBrush(Color.FromArgb(31, 36, 33));
        public static SolidBrush KockaPoeniCetkica2 = new SolidBrush(Color.FromArgb(73, 160, 120));
        public static Pen TimeLineOlovka = new Pen(Color.FromArgb(31, 36, 33), 5);

        public static void PostaviBojeKrugova(Color k1, Color k2, Color k3, Color k4, Color k5) //poziva se u Settings
        {
            Boje[0] = k1;
            Boje[1] = k2;
            Boje[2] = k3;
            Boje[3] = k4;
            Boje[4] = k5;

            for(int i=0; i<5; i++)
            {
                Cetkice[i] = new SolidBrush(Boje[i]);
                Olovke[i] = new Pen(Boje[i], 5);
            }

        }

    }
}
