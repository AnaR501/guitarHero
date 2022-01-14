using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarHeroGenerationZ
{
    public class NovaIgra
    {
        public string Player1 { get; set; }
        public int Pesma { get; set; }
        public int indCiljanihElipsiP1 { get; set; }//indeks elementa koji je u listi najduze => najnizi set krugova za koje proveravamo rastojanje kod pogotka

        public List<OsnovnaElipsa> osnovneElipse;
        public List<List<Elipsa>> padajuceElipse;
        public List<string> note;
        public int d1; //proporcije rastojanja u odnosu na dimenzije PictureBox-a
        public int d2;
        public int h;
        public string TrazeniAkord1 { get; set; }
        public int index;
        public bool krajIgre;

        public bool Hold1;
        public KockaPoeniCombo poeniCombo1;
        public int PowerMode1;
        public int timer1;
        public static int PowerModeTimer1 = 70;
        public int brPogodjenihAkorda1;
        public GitaraPodloga podloga1;
        public int brDodatihAkorda;
        public bool ocitanPocetakHolda;
        public int ukupnoAkordaP1; //koliko je ukupno akorda izaslo prvom igracu
        public bool singleIliMulti; //false je da je Single igra, true je da je Multi igra

        public int brojacZaMoci;





        public NovaIgra(string ime, int _d1, int _d2, int _h, KockaPoeniCombo poeniC)
        {
            Player1 = ime;
            Pesma = 0;
            d1 = _d1;
            d2 = _d2;
            h = _h;
            index = 0;
            indCiljanihElipsiP1 = -1;
            TrazeniAkord1 = "";

            Hold1 = false;
            poeniCombo1 = poeniC;
            brPogodjenihAkorda1 = 0;
            krajIgre = false;
            podloga1 = new GitaraPodloga(0);
            brDodatihAkorda = 0;
            ukupnoAkordaP1 = 0;
            singleIliMulti = false;
            brojacZaMoci = 0;

            note = new List<string>();


            padajuceElipse = new List<List<Elipsa>>();
            osnovneElipse = new List<OsnovnaElipsa>();
            osnovneElipse.Add(new OsnovnaElipsa(TastaturaIKoordinate.getXKoord(0, 1), TastaturaIKoordinate.YKoordOsnovnih, 1));
            osnovneElipse.Add(new OsnovnaElipsa(TastaturaIKoordinate.getXKoord(1, 1), TastaturaIKoordinate.YKoordOsnovnih, 2));
            osnovneElipse.Add(new OsnovnaElipsa(TastaturaIKoordinate.getXKoord(2, 1), TastaturaIKoordinate.YKoordOsnovnih, 3));
            osnovneElipse.Add(new OsnovnaElipsa(TastaturaIKoordinate.getXKoord(3, 1), TastaturaIKoordinate.YKoordOsnovnih, 4));
            osnovneElipse.Add(new OsnovnaElipsa(TastaturaIKoordinate.getXKoord(4, 1), TastaturaIKoordinate.YKoordOsnovnih, 5));

        }

        public virtual void Crtaj(Graphics g) 
        {
            poeniCombo1.Crtaj(g);
            podloga1.Crtaj(g);
            for (int i = 0; i < osnovneElipse.Count; i++)
            {
                osnovneElipse[i].Crtaj(g);
            }
            for (int i = 0; i < padajuceElipse.Count; i++)
            {
                for (int j = 0; j < padajuceElipse[i].Count; j++)
                    padajuceElipse[i][j].Crtaj(g);
            }
        }

        public void ObrisiHoldOsnovnihElipsi1()
        {
            for(int i=0; i<osnovneElipse.Count; i++)
            {
                osnovneElipse[i].ObrisiHold();
            }
        }

        public virtual void PokreniPowerMode1()
        {
            PowerMode1 = 1;
            //treba da se promeni boja postojecih elipsi
            for (int i = 0; i < padajuceElipse.Count; i++)
            {
                for (int j = 0; j < padajuceElipse[i].Count; j++)
                {
                    padajuceElipse[i][j].ModCrtanja = 2;
                    if (padajuceElipse[i][j].rep != null)
                        padajuceElipse[i][j].rep.ModCrtanja = 2;
                }
            }
            for(int i=0; i<osnovneElipse.Count; i++)
            {
                if (osnovneElipse[i].rep != null)
                    osnovneElipse[i].rep.ModCrtanja = 2;
            }
            timer1 = PowerModeTimer1 * poeniCombo1.getMoci();
            poeniCombo1.PokreniPowerMode();

        }

        public virtual void ZavrsiPowerMode1()
        {
            PowerMode1 = 0;
            for (int i = 0; i < padajuceElipse.Count; i++)
            {
                for (int j = 0; j < padajuceElipse[i].Count; j++)
                {
                    padajuceElipse[i][j].ModCrtanja = 1;
                    if (padajuceElipse[i][j].rep != null)
                        padajuceElipse[i][j].rep.ModCrtanja = 1;
                }
            }
            for(int i=0; i<osnovneElipse.Count; i++)
            {
                if (osnovneElipse[i].rep != null)
                    osnovneElipse[i].rep.ModCrtanja = 1;
            }
            poeniCombo1.ZavrsiPowerMode();
        }

        public void ObradiMoguciPogodakPlayer1(string akord)
        {
            //obradjujemo sta se trazi da se pritisne
            if (Pogodak1(akord)) //proveravamo da li smo pretisnuli ono sto se trazi
                                                //u MultiPlayer mozda pretisnu u razlicitom trenutku, svakako treba da im se racuna
            {
                //logika pogotka note
                brPogodjenihAkorda1++;
                poeniCombo1.AzurirajCombo(true);
                poeniCombo1.brPoena += 10 * poeniCombo1.mnoziPoene; 
                for (int i = 0; i < padajuceElipse[indCiljanihElipsiP1].Count; i++)
                {
                    if (!singleIliMulti && padajuceElipse[indCiljanihElipsiP1][i].ModCrtanja == 3) //ova elipsa nosi moc sa sobom
                        poeniCombo1.moci++;
                    if (padajuceElipse[indCiljanihElipsiP1][i].rep != null)
                    {
                        int ind = getIndexOfPositionOsnovneElipse1(padajuceElipse[indCiljanihElipsiP1][i].PozicijaElipse);
                        osnovneElipse[ind].rep = padajuceElipse[indCiljanihElipsiP1][i].rep;
                        padajuceElipse[indCiljanihElipsiP1][i].rep = null;
                        osnovneElipse[ind].rep.Pogodjeno = true;
                        osnovneElipse[ind].rep.linija.B.Y = osnovneElipse[ind].Y - Elipsa.RY / 2 + 1;
                        Hold1 = true;
                    }
                    if (padajuceElipse[indCiljanihElipsiP1][i].power != null)
                    {
                        poeniCombo1.DodajPower(padajuceElipse[indCiljanihElipsiP1][i].power);
                    }

                }
                ObrisiPadajucuElipsuNaMestuIP1(indCiljanihElipsiP1);
            }
            else
            {
                poeniCombo1.AzurirajCombo(false);
            }

        }

        public virtual void KeyDown(ref byte[] keys) 
        {
            string akord = "";
            bool pretisnutoPogresnoDugme = false;
            //Obrada promene boje pretisnutih dugmica
            if ((keys[TastaturaIKoordinate.Tastatura[0]] & 128) == 128)
            {
                if (osnovneElipse[0].RegistrujKeyDown(Hold1))
                    pretisnutoPogresnoDugme = true;
                akord += "1";
            }
            if ((keys[TastaturaIKoordinate.Tastatura[1]] & 128) == 128)
            {
                if (osnovneElipse[1].RegistrujKeyDown(Hold1))
                    pretisnutoPogresnoDugme = true;
                akord += "2";
            }
            if ((keys[TastaturaIKoordinate.Tastatura[2]] & 128) == 128)
            {
                if (osnovneElipse[2].RegistrujKeyDown(Hold1))
                    pretisnutoPogresnoDugme = true;
                akord += "3";
            }
            if ((keys[TastaturaIKoordinate.Tastatura[3]] & 128) == 128)
            {
                if (osnovneElipse[3].RegistrujKeyDown(Hold1))
                    pretisnutoPogresnoDugme = true;
                akord += "4";
            }
            if ((keys[TastaturaIKoordinate.Tastatura[4]] & 128) == 128)
            {
                if (osnovneElipse[4].RegistrujKeyDown(Hold1))
                    pretisnutoPogresnoDugme = true;
                akord += "5";
            }
            if ((keys[TastaturaIKoordinate.PowerMode[0]] & 128) == 128 && poeniCombo1.moci >= 3)
            {
                PokreniPowerMode1();
            }

            //Obrada moguceg pogotka
            if ((keys[TastaturaIKoordinate.OkidaciZica[0]] & 128) == 128) //space dugme, za okidanje zice
            {
                if (Hold1)
                {
                    pretisnutoPogresnoDugme = true;
                }
                else
                    ObradiMoguciPogodakPlayer1(akord);
            }
            if(Hold1 && pretisnutoPogresnoDugme)
            {
                Hold1 = false;
                poeniCombo1.AzurirajCombo(false);
                ObrisiHoldOsnovnihElipsi1();
            }
        }
        public bool Pogodak1(string akord)
        {
            AzurirajTrazeniAkordP1();
            if (akord.Equals(TrazeniAkord1) && akord != "")
            {
                if (indCiljanihElipsiP1 >= 0 && padajuceElipse[indCiljanihElipsiP1][0].Y < osnovneElipse[0].Y + Elipsa.RY &&
                    padajuceElipse[indCiljanihElipsiP1][0].Y > osnovneElipse[0].Y - Elipsa.RY)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public virtual void KeyUp(ref byte[] keys)
        {
            bool promenaHolda = false; //postace true ako sam negde obrisala Hold (zato sto to dugme vise nije pritisnuto)
            if (!((keys[TastaturaIKoordinate.Tastatura[0]] & 128) == 128))
            {
                if (osnovneElipse[0].RegistrujKeyUp(Hold1))
                    promenaHolda = true;
            }
            if (!((keys[TastaturaIKoordinate.Tastatura[1]] & 128) == 128))
            {
                if (osnovneElipse[1].RegistrujKeyUp(Hold1))
                    promenaHolda = true;
            }
            if (!((keys[TastaturaIKoordinate.Tastatura[2]] & 128) == 128))
            {
                if (osnovneElipse[2].RegistrujKeyUp(Hold1))
                    promenaHolda = true;
            }
            if (!((keys[TastaturaIKoordinate.Tastatura[3]] & 128) == 128))
            {
                if (osnovneElipse[3].RegistrujKeyUp(Hold1))
                    promenaHolda = true;
            }
            if (!((keys[TastaturaIKoordinate.Tastatura[4]] & 128) == 128))
            {
                if (osnovneElipse[4].RegistrujKeyUp(Hold1))
                    promenaHolda = true;
            }
            if (Hold1 && promenaHolda)
            {
                Hold1 = false;
            }
        }

        public void ObrisiPadajucuElipsuNaMestuIP1(int i)
        {
            if (i >= 0 && i < padajuceElipse.Count)
            {
                padajuceElipse[i].Clear();
                padajuceElipse.RemoveAt(i);
            }

        }

        public void AzurirajTrazeniAkordP1()
        {
            TrazeniAkord1 = "";
            if (indCiljanihElipsiP1 < padajuceElipse.Count && indCiljanihElipsiP1 >= 0)
            {
                for (int i = 0; i < padajuceElipse[indCiljanihElipsiP1].Count; i++)
                {
                    if(padajuceElipse[indCiljanihElipsiP1][i].Vidljiva)
                        TrazeniAkord1 += padajuceElipse[indCiljanihElipsiP1][i].PozicijaElipse.ToString();
                }
            }
        }


        public bool RegularanAkord(string akord)
        {
            bool res = true;
            for (int i = 0; i < akord.Length; i++)
                if (!(akord[i] == '1' || akord[i] == '2' || akord[i] == '3' || akord[i] == '4' || akord[i] == '5' || 
                    akord[i] == 'H' || akord[i] == 'X' || akord[i] == '*'))
                    res = false;
                return res;
        }

        public int getIndexOfPositionPadajuceElipse1(int row, int poz)
        {
            for (int i = 0; i < padajuceElipse[row].Count; i++)
                if (padajuceElipse[row][i].PozicijaElipse == poz)
                    return i;
            return -1;
        }

        public int getIndexOfPositionOsnovneElipse1(int poz)
        {
            for (int i = 0; i < osnovneElipse.Count; i++)
                if (osnovneElipse[i].PozicijaElipse == poz)
                    return i;
            return -1;
        }

        public void ObradiPojavljivanjeHoldaP1() //kad pozovem znam da imam karakter H u akordu
        {
            ocitanPocetakHolda = true;
            string tmp = note[index];
            int ind = tmp.IndexOf('H');
            while(ind != -1)
            {
                int i = getIndexOfPositionPadajuceElipse1(padajuceElipse.Count-1, tmp[ind - 1] - '0');
                padajuceElipse[padajuceElipse.Count - 1][i].DodajNoviHold();
                
                tmp = tmp.Remove(ind, 1);  //ukloni char pocevsi od indeksa ind duzine 1
                ind = tmp.IndexOf('H');
            }
        }

        public void ObradiKrajHoldaP1()
        {
            ocitanPocetakHolda = false;
            string tmp = note[index];
            int ind = tmp.IndexOf('X'), prethInd;
            bool zaBrisanje = true;
            while (ind != -1) //dok ima jos holdova koje treba zavrsiti
            {
                if (tmp[ind - 1] == 'H')
                {
                    prethInd = ind - 2;
                    zaBrisanje = false;
                }
                else
                    prethInd = ind - 1;
                bool nadjen = false;
                int i = padajuceElipse.Count - 1;
                while(i>=0) //trazi se padajuci krug koji je zapoceo hold, ako ne postoji onda je ili u osnovnom krugu
                    //i pogodjen je ili je promasen pa treba da se ignorise
                {
                    int j = getIndexOfPositionPadajuceElipse1(i, tmp[prethInd] - '0');
                    if(j!= -1 && padajuceElipse[i][j].rep != null) //nadjen je padajuci krug kome hold pripada
                    {
                        padajuceElipse[i][j].rep.VidljivGornjiKraj = true;
                        nadjen = true;
                        break;
                    }
                    i--;
                }
                if(!nadjen && osnovneElipse[tmp[prethInd] - '1'].rep != null)
                {
                    osnovneElipse[tmp[prethInd] - '1'].rep.VidljivGornjiKraj = true;
                    nadjen = true;
                }
                if(!nadjen || zaBrisanje) //to znaci da je Hold obrisan u medjuvremenu i da se vise ne iscrtava, onda treba obrisati
                            //padajuci krug ciji bi to hold bio ako je samo naznacavao kraj Hold-a
                {
                    int j = getIndexOfPositionPadajuceElipse1(padajuceElipse.Count-1, tmp[prethInd] - '0');
                    padajuceElipse[padajuceElipse.Count - 1].RemoveAt(j);
                }
                tmp = tmp.Remove(ind, 1);
                ind = tmp.IndexOf('X');
            }
        }

        public bool DaLiJeBroj(char c)
        {
            if (c == '1' || c == '2' || c == '3' || c == '4' || c == '5')
                return true;
            else
                return false;
        }

        public void ObradiPojavljivanjeMociP1()
        {

            padajuceElipse[padajuceElipse.Count - 1][0].ModCrtanja = 3; 

        }

        public void DodajElipsePlayer1()
        {
            if (RegularanAkord(note[index]))
            {
                padajuceElipse.Add(new List<Elipsa>());

                if (note[index].Contains('1'))
                    padajuceElipse[padajuceElipse.Count - 1].Add(new Elipsa(TastaturaIKoordinate.getXKoord(0, 1), TastaturaIKoordinate.startHeight, 1));
                if (note[index].Contains('2'))
                    padajuceElipse[padajuceElipse.Count - 1].Add(new Elipsa(TastaturaIKoordinate.getXKoord(1, 1), TastaturaIKoordinate.startHeight, 2));
                if (note[index].Contains('3'))
                    padajuceElipse[padajuceElipse.Count - 1].Add(new Elipsa(TastaturaIKoordinate.getXKoord(2, 1), TastaturaIKoordinate.startHeight, 3));
                if (note[index].Contains('4'))
                    padajuceElipse[padajuceElipse.Count - 1].Add(new Elipsa(TastaturaIKoordinate.getXKoord(3, 1), TastaturaIKoordinate.startHeight, 4));
                if (note[index].Contains('5'))
                    padajuceElipse[padajuceElipse.Count - 1].Add(new Elipsa(TastaturaIKoordinate.getXKoord(4, 1), TastaturaIKoordinate.startHeight, 5));



                if (note[index].Contains('H')) //za pocetak holda
                    ObradiPojavljivanjeHoldaP1();

                if (note[index].Contains('X')) //za kraj holda
                    ObradiKrajHoldaP1();

                if (padajuceElipse.Count == 1)
                {
                    indCiljanihElipsiP1 = 0;
                    AzurirajTrazeniAkordP1();
                }
                if (padajuceElipse[padajuceElipse.Count - 1].Count > 0)
                {
                    brojacZaMoci++;
                    brDodatihAkorda++;
                    ukupnoAkordaP1++;

                    if (singleIliMulti) //prolazi ako je multi game
                    {
                        if (ukupnoAkordaP1 % 20 == 0)
                        {
                            int x = padajuceElipse[padajuceElipse.Count - 1][0].X, y = padajuceElipse[padajuceElipse.Count - 1][0].Y;
                            padajuceElipse[padajuceElipse.Count - 1][0].power = PowerMultiPlayer.odrediPower(x, y);
                        }
                        if (PowerMode1 == 4)
                        {
                            for (int i = 0; i < padajuceElipse[padajuceElipse.Count - 1].Count; i++)
                                padajuceElipse[padajuceElipse.Count - 1][i].PokreniEarthquake(10, PowerMultiPlayer.rand.Next(0, 10));
                        }
                    }
                    else //prolazi ako je single game
                    {
                        if (brojacZaMoci > 15 && PowerMode1 == 0)
                        {
                            brojacZaMoci = 0;
                            ObradiPojavljivanjeMociP1();
                        }
                    }
                }
                if (PowerMode1 == 1)
                {
                    for (int i = 0; i < padajuceElipse[padajuceElipse.Count - 1].Count; i++)
                    {
                        padajuceElipse[padajuceElipse.Count - 1][i].ModCrtanja = 2;
                        if (padajuceElipse[padajuceElipse.Count - 1][i].rep != null)
                            padajuceElipse[padajuceElipse.Count - 1][i].rep.ModCrtanja = 2;
                    }
                }
                index++;
            }
        }

        public virtual void PomeriElipse()
        {
            int pomak = 10;
            if (Hold1)
                poeniCombo1.brPoena += poeniCombo1.mnoziPoene;
            for (int i = 0; i < padajuceElipse.Count; i++)
            {
                for (int j = 0; j < padajuceElipse[i].Count; j++)
                {
                    padajuceElipse[i][j].Pomeri(pomak);
                }
            }
            podloga1.Pomeri(pomak);
            for(int i=0; i<osnovneElipse.Count; i++)
            {
                if (osnovneElipse[i].Pomeri(pomak) && Hold1) //ako su se koordinate Hold-a spojile menjamo stanje sistema
                    Hold1 = false;
            }
            if (PowerMode1 > 0)
            {
                timer1--;
                if (timer1 < 0)
                    ZavrsiPowerMode1();
            }
        }
        public void ProveraCiljanogKrugaP1() //vraca true ako je krug ispao iz fokusa, da bi se azurirao Combo
        {
            if (indCiljanihElipsiP1 >= 0 && indCiljanihElipsiP1 < padajuceElipse.Count && padajuceElipse[indCiljanihElipsiP1].Count > 0)
            {
                if (padajuceElipse[indCiljanihElipsiP1][0].Y > osnovneElipse[0].Y + Elipsa.RY)
                {
                    for (int i = 0; i < padajuceElipse[indCiljanihElipsiP1].Count; i++)
                        if (padajuceElipse[indCiljanihElipsiP1][i].rep != null)
                            padajuceElipse[indCiljanihElipsiP1][i].rep = null;
                    indCiljanihElipsiP1++;
                    if (indCiljanihElipsiP1 < padajuceElipse.Count)
                        AzurirajTrazeniAkordP1();
                    poeniCombo1.AzurirajCombo(false);
                }
            }
        }

        public void IspaoIzEkranaP1(int height)
        {
            if (padajuceElipse.Count > 0)
            {
                while (padajuceElipse.Count > 0 && (padajuceElipse[0].Count ==0 || padajuceElipse[0][0].Y - Elipsa.RY/2 >= height))
                {
                    if (padajuceElipse[0].Count == 0)
                        ++indCiljanihElipsiP1;
                    padajuceElipse[0].Clear();
                    ObrisiPadajucuElipsuNaMestuIP1(0);
                    if (--indCiljanihElipsiP1 >= 0)
                        AzurirajTrazeniAkordP1();
                }
            }
        }

        public int getBrPogodjenihAkordaP1()
        {
            return brPogodjenihAkorda1;
        }

        public virtual void DodajPoprecnuLiniju(int h)
        {
            podloga1.DodajPoprecnuliniju();
            podloga1.ObrisiNevidljivePoprecneLinije(h);
        }

    }
}