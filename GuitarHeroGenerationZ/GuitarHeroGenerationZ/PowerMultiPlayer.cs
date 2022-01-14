using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GuitarHeroGenerationZ.Properties;

namespace GuitarHeroGenerationZ
{

    public class PowerMultiPlayer
    {
        public Image ikonica;
        public int oznaka;
        public int X { get; set; }
        public int Y { get; set; }
        public int imageHeight;
        public int imageWidth;

        public void Crtaj(Graphics g)
        {
            g.DrawImage(ikonica, X - imageWidth / 2, Y - imageHeight / 2, imageWidth, imageHeight);
        }
        public void Pomeri(int pomak)
        {
            Y += pomak;
        }

        public static Random rand = new Random();
        public static PowerMultiPlayer odrediPower(int x, int y)
        {
            int i = rand.Next(0, 3); //nasumicno biramo koji se tip moci javlja
            if (i == 0)
            {
                return new OneButtonPower(x, y);
            }
            else if (i == 1)
            {
                return new LeftyKeyboardPower(x, y);
            }
            else
                return new EarthquakePower(x, y);

        }

        public void resetXKoord(int i, int poz, int startWidth)
        {
            if (i == 1 || i == 2)
            {
                X = startWidth + TastaturaIKoordinate.getXKoord(poz, i);
            }
        }
    }

    public class OneButtonPower : PowerMultiPlayer
    {
        public OneButtonPower(int x, int y)
        {
            ikonica = Resources.OneButtonPowerPicture;
            X = x;
            Y = y;
            oznaka = 1;
            imageWidth = Elipsa.RX;
            imageHeight = Elipsa.RY;
        }

    }


    public class LeftyKeyboardPower : PowerMultiPlayer
    {
        public LeftyKeyboardPower(int x, int y)
        {
            ikonica = Resources.LeftKeyboardPowerPicture;
            X = x;
            Y = y;
            oznaka = 2;
            imageWidth = Elipsa.RX;
            imageHeight = Elipsa.RY;
        }
    }


    public class EarthquakePower : PowerMultiPlayer
    {
        public EarthquakePower(int x, int y)
        {
            ikonica = Resources.EarthquakePowerPicture;
            X = x;
            Y = y;
            oznaka = 3;
            imageWidth = Elipsa.RX;
            imageHeight = Elipsa.RY;
        }
    }
}
