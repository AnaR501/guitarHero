using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GuitarHeroGenerationZ
{
    public class GitaraPodloga
    {
        public List<Figura> figure;
        public List<Duz> poprecneLinije;
        public int pomak;

        public GitaraPodloga(int p)
        {
            pomak = p;
            poprecneLinije = new List<Duz>();
            figure = new List<Figura>();

            figure.Add(new Duz(new Tacka(pomak + TastaturaIKoordinate.XKoord[0], TastaturaIKoordinate.startHeight), new Tacka(p + TastaturaIKoordinate.XKoord[0], TastaturaIKoordinate.YKoordOsnovnih + 170)));
            figure.Add(new Duz(new Tacka(pomak + TastaturaIKoordinate.XKoord[1], TastaturaIKoordinate.startHeight), new Tacka(p + TastaturaIKoordinate.XKoord[1], TastaturaIKoordinate.YKoordOsnovnih + 150)));
            figure.Add(new Duz(new Tacka(pomak + TastaturaIKoordinate.XKoord[2], TastaturaIKoordinate.startHeight), new Tacka(p + TastaturaIKoordinate.XKoord[2], TastaturaIKoordinate.YKoordOsnovnih + 150)));
            figure.Add(new Duz(new Tacka(pomak + TastaturaIKoordinate.XKoord[3], TastaturaIKoordinate.startHeight), new Tacka(p + TastaturaIKoordinate.XKoord[3], TastaturaIKoordinate.YKoordOsnovnih + 150)));
            figure.Add(new Duz(new Tacka(pomak + TastaturaIKoordinate.XKoord[4], TastaturaIKoordinate.startHeight), new Tacka(p + TastaturaIKoordinate.XKoord[4], TastaturaIKoordinate.YKoordOsnovnih + 150)));
        }

        public void Crtaj(Graphics g)
        {
            for (int i = 0; i < figure.Count; i++)
            {
                figure[i].Crtaj(g);
            }
            for (int i = 0; i < poprecneLinije.Count; i++)
            {
                poprecneLinije[i].Crtaj(g);
            }
        }

        public void DodajPoprecnuliniju()
        {
            poprecneLinije.Add(new Duz(new Tacka(pomak + TastaturaIKoordinate.XKoord[0], TastaturaIKoordinate.startHeight), new Tacka(pomak + TastaturaIKoordinate.XKoord[4], TastaturaIKoordinate.startHeight)));
        }

        public void Pomeri(int pomak)
        {
            for (int i = 0; i < poprecneLinije.Count; i++)
                poprecneLinije[i].pomeri(pomak);
        }

        public void ObrisiNevidljivePoprecneLinije(int height)
        {
            for (int i = poprecneLinije.Count - 1; i >= 0; i--)
            {
                if (poprecneLinije[i].Nevidljiva(height))
                    poprecneLinije.RemoveAt(i);
            }
        }


    }
}
