using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarHeroGenerationZ
{
    public class Song
    {

        public String Name { get; private set; }

        public int Duration { get; private set; }

        public int Interval { get; set; }

        public int MaxBrAkorda { get; set; }

        public int BrPreskakanja { get; set; } 


        public Song(String n, int d, int h, int m, int brPresk)
        {
            Name = n;
            Duration = d;
            Interval = h;
            MaxBrAkorda = m;
            BrPreskakanja = brPresk;
        }


    }
}

