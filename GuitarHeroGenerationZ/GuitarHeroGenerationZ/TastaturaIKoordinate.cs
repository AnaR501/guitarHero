using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarHeroGenerationZ
{
    class TastaturaIKoordinate
    {
        public static int[] XKoord = new int[] { 1, 2, 3, 4, 5 };

        public static string poruka = "";

        public static bool smerTastaturePlayer1;

        public static bool smerTastaturePlayer2;

        public static int YKoordOsnovnih;


        public static int[] Tastatura = new int[5];

        public static int[] TastaturaPlayer1 = new int[5];

        public static int[] TastaturaPlayer2 = new int[5];

        public static int[] OkidaciZica = new int[3];

        public static int[] PowerMode = new int[3];

        public static int startWidth = 0; // za MultiPlayer igru, pocetna sirina za crtanje podloge

        public static int startHeight = 0; // za MultiPlayer igru, pocetna visina za crtanje podloge

        public static int Volume;

        public static void PostaviKoord(int x0, int x1, int x2, int x3, int x4, int h)
        {
            XKoord[0] = x0;
            XKoord[1] = x1;
            XKoord[2] = x2;
            XKoord[3] = x3;
            XKoord[4] = x4;
            YKoordOsnovnih = h;
        }

        public static void PostaviTastaturu(int t0, int t1, int t2, int t3, int t4, int ok1, int power1) 
        {
            Tastatura[0] = t0;
            Tastatura[1] = t1;
            Tastatura[2] = t2;
            Tastatura[3] = t3;
            Tastatura[4] = t4;
            OkidaciZica[0] = ok1;
            PowerMode[0] = power1;
        }

        public static void PostaviTastaturuPlayer1(int t0, int t1, int t2, int t3, int t4, int ok1, int power1) 
        {
            TastaturaPlayer1[0] = t0;
            TastaturaPlayer1[1] = t1;
            TastaturaPlayer1[2] = t2;
            TastaturaPlayer1[3] = t3;
            TastaturaPlayer1[4] = t4;
            OkidaciZica[1] = ok1;
            PowerMode[1] = power1;
        }


        public static void PostaviTastaturuPlayer2(int t0, int t1, int t2, int t3, int t4, int ok2, int power2) 
        {
            TastaturaPlayer2[0] = t0;
            TastaturaPlayer2[1] = t1;
            TastaturaPlayer2[2] = t2;
            TastaturaPlayer2[3] = t3;
            TastaturaPlayer2[4] = t4;
            OkidaciZica[2] = ok2;
            PowerMode[2] = power2;
        }


        public static void FlipKeyboard(int i)
        {
            if (i == 1)
                smerTastaturePlayer1 = !smerTastaturePlayer1;
            else if (i == 2)
                smerTastaturePlayer2 = !smerTastaturePlayer2;
        }

        public static void PostaviStartDimenzije(int sw, int sh)
        {
            startWidth = sw;
            startHeight = sh;
        }

        public static int getXKoord(int i, int brTast)
        {
            if(brTast == 1) //Trazi se koordinata prve tastature
            {
                if (smerTastaturePlayer1)
                    return XKoord[i];
                else
                    return XKoord[4 - i];
            }
            else  //Trazi se koordinata druge tastature
            {
                if (smerTastaturePlayer2)
                    return XKoord[i];
                else
                    return XKoord[4 - i];

            }
        }

        public static string getOriginalKey(int key)
        {
            string res = "";

            if (key >= (int)Keys.A && key <= (int)Keys.Z) 
            {
                res = ((char)((int)'A' + key - (int)Keys.A)).ToString();
            }
            else if (key >= (int)Keys.D0 && key <= (int)Keys.D9) //onda je broj sa vrha tastature
            {
                res = ((char)((int)'0' + key - (int)Keys.D0)).ToString(); 
            }
            else if (key >= (int)Keys.NumPad0 && key <= (int)Keys.NumPad9) //onda je sa desnih brojeva (KeyPad)
            {
                res = ("Keypad" + (char)((int)'0' + key - (int)Keys.NumPad0)).ToString(); //format je "Keypad0"
            }
            else if (key >= (int)Keys.F1 && key <= (int)Keys.F12)
            {
                res = ("F" + (char)((int)'1' + key - (int)Keys.F1)).ToString(); 
            }
            else if (key == (int)Keys.Back) //backspace
            {
                res = "Backspace"; 
            }
            else if (key == (int)Keys.Enter)
            {
                res = "Enter";
            }
            else if (key == (int)Keys.Space)
            {
                res = "Space";
            }
            return res;
        }

        public static void ResetujTastature()
        {
            Tastatura[0] = (int)Keys.A;
            Tastatura[1] = (int)Keys.S;
            Tastatura[2] = (int)Keys.D;
            Tastatura[3] = (int)Keys.F;
            Tastatura[4] = (int)Keys.G;
            TastaturaPlayer1[0] = (int)Keys.Q;
            TastaturaPlayer1[1] = (int)Keys.W;
            TastaturaPlayer1[2] = (int)Keys.E;
            TastaturaPlayer1[3] = (int)Keys.R;
            TastaturaPlayer1[4] = (int)Keys.T;
            TastaturaPlayer2[0] = (int)Keys.Y;
            TastaturaPlayer2[1] = (int)Keys.U;
            TastaturaPlayer2[2] = (int)Keys.I;
            TastaturaPlayer2[3] = (int)Keys.O;
            TastaturaPlayer2[4] = (int)Keys.P;
            OkidaciZica[0] = (int)Keys.Space;
            OkidaciZica[1] = (int)Keys.Space;
            OkidaciZica[2] = (int)Keys.Enter;
            PowerMode[0] = (int)Keys.Enter;
            PowerMode[1] = (int)Keys.V;
            PowerMode[2] = (int)Keys.Back;
            smerTastaturePlayer1 = true;
            smerTastaturePlayer2 = true;
        }

        public static void ZameniDugmice(int mod1, int ind1, int mod2, int ind2)
        {
            int vr1=-1, vr2=-1;
            if(mod1 == 0) //ako je iz Tastature Single Player-a
            {
                if (ind1 < 5)
                    vr1 = Tastatura[ind1];
                else if (ind1 == 5)
                    vr1 = PowerMode[0];
                else if (ind1 == 6)
                    vr1 = OkidaciZica[0];
            }
            else if (mod1 == 1)
            {
                if (ind1 < 5)
                    vr1 = TastaturaPlayer1[ind1];
                else if (ind1 == 5)
                    vr1 = PowerMode[1];
                else if (ind1 == 6)
                    vr1 = OkidaciZica[1];
            }
            else if (mod1 == 2)
            {
                if (ind1 < 5)
                    vr1 = TastaturaPlayer2[ind1];
                else if (ind1 == 5)
                    vr1 = PowerMode[2];
                else if (ind1 == 6)
                    vr1 = OkidaciZica[2];
            }
            //postavila sam vrednost vr1, sada trazim vrednost vr2 i postavljam vrednost tog dugmeta na vr1
            if (mod2 == 0) //ako je iz Tastature Single Player-a
            {
                if (ind2 < 5)
                {
                    vr2 = Tastatura[ind2];
                    Tastatura[ind2] = vr1;
                }
                else if (ind2 == 5)
                {
                    vr2 = PowerMode[0];
                    PowerMode[0] = vr1;
                }
                else if (ind2 == 6)
                {
                    vr2 = OkidaciZica[0];
                    OkidaciZica[0] = vr1;
                }
            }
            else if (mod2 == 1)
            {
                if (ind2 < 5)
                {
                    vr2 = TastaturaPlayer1[ind2];
                    TastaturaPlayer1[ind2] = vr1;

                }
                else if (ind2 == 5)
                {
                    vr2 = PowerMode[1];
                    PowerMode[1] = vr1;
                }
                else if (ind2 == 6)
                {
                    vr2 = OkidaciZica[1];
                    OkidaciZica[1] = vr1;
                }
            }
            else if (mod2 == 2)
            {
                if (ind2 < 5)
                {
                    vr1 = TastaturaPlayer2[ind2];
                    TastaturaPlayer2[ind2] = vr1;
                }
                else if (ind2 == 5)
                {
                    vr2 = PowerMode[2];
                    PowerMode[2] = vr1;
                }
                else if (ind2 == 6)
                {
                    vr2 = OkidaciZica[2];
                    OkidaciZica[2] = vr1;
                }
            }
            //postavila sam vrednost v2, sada treba da nadjem dugme kome treba da je dodelim
            if (mod1 == 0) //ako je iz Tastature Single Player-a
            {
                if (ind1 < 5)
                    Tastatura[ind1] = vr2;
                else if (ind1 == 5)
                    PowerMode[0] = vr2;
                else if (ind1 == 6)
                    OkidaciZica[0] = vr2;
            }
            else if (mod1 == 1)
            {
                if (ind1 < 5)
                    TastaturaPlayer1[ind1] = vr2;
                else if (ind1 == 5)
                    PowerMode[1] = vr2;
                else if (ind1 == 6)
                    OkidaciZica[1] = vr2;
            }
            else if (mod1 == 2)
            {
                if (ind1 < 5)
                    TastaturaPlayer2[ind1] = vr2;
                else if (ind1 == 5)
                    PowerMode[2] = vr2;
                else if (ind1 == 6)
                    OkidaciZica[2] = vr2;
            }
        }

    }
}
