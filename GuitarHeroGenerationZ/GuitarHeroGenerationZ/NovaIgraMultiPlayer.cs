using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GuitarHeroGenerationZ
{
    public class NovaIgraMultiPlayer : NovaIgra
    {
        public string Player2 { get; set; }
        public int indCiljanihElipsiP2 { get; set; }//indeks elementa koji je u listi najduze => najnizi set krugova za koje proveravamo rastojanje kod pogotka

        public List<OsnovnaElipsa> osnovneElipse2;
        public List<List<Elipsa>> padajuceElipse2;

        public string TrazeniAkord2 { get; set; }
        public bool Hold2;
        public KockaPoeniComboMulti poeniCombo2;
        public int PowerMode2;
        public int timer2;
        public static int PowerModeTimer2 = 250;

        public bool BioPogodak2; //potrebno je da bi se adekvatno registrovalo drzanje SPACE-a posle pogotka, da se ne bi racunalo kao greska
        public int brPogodjenihAkorda2;
        public int brAkordaZaJednog;
        public GitaraPodloga podloga2;
        public int ukupanBrAkorda;

        public bool igracNaRedu; //ako je true onda Elipse treba dodati prvom igracu, ako je false onda drugom igracu
        public int ukupnoAkordaP2; //koliko je ukupno akorda izaslo drugom igracu, u zbiru sa ukupnoAkordaP1 daje ukupanBrAkorda


        public NovaIgraMultiPlayer(string ime1, string ime2, int _d1, int _d2, int _h, KockaPoeniComboMulti poeniC1, 
            KockaPoeniComboMulti poeniC2, int startWidth, int ukBrAkorda) : base(ime1, _d1, _d2, _h, poeniC1)
        {
            Player2 = ime2;
            index = 0;
            indCiljanihElipsiP2 = -1;
            TrazeniAkord2 = "";

            Hold2 = false;
            poeniCombo2 = poeniC2;
            BioPogodak2 = false;
            brPogodjenihAkorda2 = 0;
            timer2 = PowerModeTimer2;
            timer1 = PowerModeTimer2;
            igracNaRedu = true;
            brAkordaZaJednog = 15;
            ukupanBrAkorda = ukBrAkorda;
            ukupnoAkordaP2 = 0;
            singleIliMulti = true;

            podloga2 = new GitaraPodloga(startWidth); //argument je kolik udesno treba da se pomeri podloga

            padajuceElipse2 = new List<List<Elipsa>>();
            osnovneElipse2 = new List<OsnovnaElipsa>();
            osnovneElipse2.Add(new OsnovnaElipsa(TastaturaIKoordinate.startWidth + TastaturaIKoordinate.getXKoord(0, 2), TastaturaIKoordinate.YKoordOsnovnih, 1));
            osnovneElipse2.Add(new OsnovnaElipsa(TastaturaIKoordinate.startWidth + TastaturaIKoordinate.getXKoord(1, 2), TastaturaIKoordinate.YKoordOsnovnih, 2));
            osnovneElipse2.Add(new OsnovnaElipsa(TastaturaIKoordinate.startWidth + TastaturaIKoordinate.getXKoord(2, 2), TastaturaIKoordinate.YKoordOsnovnih, 3));
            osnovneElipse2.Add(new OsnovnaElipsa(TastaturaIKoordinate.startWidth + TastaturaIKoordinate.getXKoord(3, 2), TastaturaIKoordinate.YKoordOsnovnih, 4));
            osnovneElipse2.Add(new OsnovnaElipsa(TastaturaIKoordinate.startWidth + TastaturaIKoordinate.getXKoord(4, 2), TastaturaIKoordinate.YKoordOsnovnih, 5));
        }

        public override void Crtaj(Graphics g)
        {
            base.Crtaj(g);
            poeniCombo2.Crtaj(g);
            podloga2.Crtaj(g);
            for (int i = 0; i < osnovneElipse2.Count; i++)
            {
                osnovneElipse2[i].Crtaj(g);
            }
            for (int i = 0; i < padajuceElipse2.Count; i++)
            {
                for (int j = 0; j < padajuceElipse2[i].Count; j++)
                    padajuceElipse2[i][j].Crtaj(g);
            }
        }

        public void ObrisiHoldOsnovnihElipsi2()
        {
            for (int i = 0; i < osnovneElipse2.Count; i++)
            {
                osnovneElipse2[i].ObrisiHold();
            }
        }

        public void PokreniOneButtonP1()
        {
            osnovneElipse[PowerMultiPlayer.rand.Next(0, 5)].ModCrtanja = 3;
            timer1 = PowerModeTimer2;
            PowerMode1 = 2; //oznaka da je u posebnom stanju
        }

        public void PokreniOneButtonP2()
        {
            osnovneElipse2[PowerMultiPlayer.rand.Next(0, 5)].ModCrtanja = 3;
            timer2 = PowerModeTimer2;
            PowerMode2 = 2; //oznaka da je u posebnom stanju
        }

        public void OkreniElipseP1()
        {
            TastaturaIKoordinate.FlipKeyboard(1);
            for (int i = 0; i < padajuceElipse.Count; i++)
            {
                for (int j = 0; j < padajuceElipse[i].Count; j++)
                {
                    padajuceElipse[i][j].resetXKoord(1, 0);
                }
            }
            for (int i = 0; i < osnovneElipse.Count; i++)
            {
                osnovneElipse[i].resetXKoord(1, 0);
            }

        }

        public void OkreniElipseP2()
        {
            TastaturaIKoordinate.FlipKeyboard(2);
            for (int i = 0; i < padajuceElipse2.Count; i++)
            {
                for (int j = 0; j < padajuceElipse2[i].Count; j++)
                {
                    padajuceElipse2[i][j].resetXKoord(2, TastaturaIKoordinate.startWidth);
                }
            }
            for (int i = 0; i < osnovneElipse2.Count; i++)
            {
                osnovneElipse2[i].resetXKoord(2, TastaturaIKoordinate.startWidth);
            }
        }

        public void PokreniLeftyKeyboardP1()
        {
            OkreniElipseP1();
            PowerMode1 = 3;
            timer1 = PowerModeTimer2;
        }

        public void PokreniLeftyKeyboardP2()
        {
            OkreniElipseP2();
            PowerMode2 = 3;
            timer2 = PowerModeTimer2;
        }

        public void PokreniEarthquakeP1()
        {
            for (int i = 0; i < padajuceElipse.Count; i++)
            {
                for (int j = 0; j < padajuceElipse[i].Count; j++)
                {
                    padajuceElipse[i][j].PokreniEarthquake(10, PowerMultiPlayer.rand.Next(0, 10)); 
                }
            }
            PowerMode1 = 4;
            timer1 = PowerModeTimer2;
        }

        public void PokreniEarthquakeP2()
        {
            for (int i = 0; i < padajuceElipse2.Count; i++)
            {
                for (int j = 0; j < padajuceElipse2[i].Count; j++)
                {
                    padajuceElipse2[i][j].PokreniEarthquake(10, PowerMultiPlayer.rand.Next(0, 10)); 
                }
            }
            PowerMode2 = 4;
            timer2 = PowerModeTimer2;
        }

        public override void PokreniPowerMode1()
        {  
            if (poeniCombo2.getMoc() != null)
            {
                int oznaka = poeniCombo2.getMoc().oznaka;
                poeniCombo2.PokreniPowerMode();
                if (oznaka == 1) // u pitanju je OneButtonPower, treba da zabranim koriscenje nekog dugmeta
                {
                    PokreniOneButtonP1();
                }
                else if (oznaka == 2 && PowerMode1 != 3)
                {
                    PokreniLeftyKeyboardP1();
                }
                else if (oznaka == 3)
                {
                    PokreniEarthquakeP1();
                }
                timer1 = PowerModeTimer2;
            }
        }

        public void PokreniPowerMode2()
        {  

            if (poeniCombo1.getMoc() != null)
            {
                int oznaka = poeniCombo1.getMoc().oznaka;
                poeniCombo1.PokreniPowerMode();
                if (oznaka == 1) // u pitanju je OneButtonPower, treba da zabranim koriscenje nekog dugmeta
                {
                    PokreniOneButtonP2();
                }
                else if (oznaka == 2 && PowerMode2 != 3)
                {
                    PokreniLeftyKeyboardP2();
                }
                else if (oznaka == 3)
                {
                    PokreniEarthquakeP2();
                }
            }
        }

        public override void ZavrsiPowerMode1()
        {
            if (PowerMode1 == 2) //ako se zavrsila OneButtonPower
            {
                for (int i = 0; i < osnovneElipse.Count; i++)
                    osnovneElipse[i].ModCrtanja = 1;
            }
            else if (PowerMode1 == 3) //ako se zavrsila LeftyKeyboardPower
            {
                OkreniElipseP1();
            }
            else if (PowerMode1 == 4) //ako se zavrsilaEarthquakePower
            {
                for (int i = 0; i < padajuceElipse.Count; i++)
                {
                    for (int j = 0; j < padajuceElipse[i].Count; j++)
                    {
                        padajuceElipse[i][j].ModCrtanja = 1;
                    }
                }
            }

            PowerMode1 = 0;
        }

        public void ZavrsiPowerMode2()
        {
            if (PowerMode2 == 2) //ako se zavrsila OneButtonPower
            {
                for (int i = 0; i < osnovneElipse2.Count; i++)
                    osnovneElipse2[i].ModCrtanja = 1;
            }
            else if (PowerMode2 == 3) //ako se zavrsila LeftyKeyboardPower
            {
                OkreniElipseP2();
            }
            else if (PowerMode2 == 4) //ako se zavrsilaEarthquakePower
            {
                for (int i = 0; i < padajuceElipse2.Count; i++)
                {
                    for (int j = 0; j < padajuceElipse2[i].Count; j++)
                    {
                        padajuceElipse2[i][j].ModCrtanja = 1;
                    }
                }
            }

            PowerMode2 = 0;
        }

        public int getIndexOfPositionPadajuceElipse2(int row, int poz)
        {
            for (int i = 0; i < padajuceElipse2[row].Count; i++)
                if (padajuceElipse2[row][i].PozicijaElipse == poz)
                    return i;
            return -1;
        }

        public int getIndexOfPositionOsnovneElipse2(int poz)
        {
            for (int i = 0; i < osnovneElipse2.Count; i++)
                if (osnovneElipse2[i].PozicijaElipse == poz)
                    return i;
            return -1;
        }

        public void ObrisiPadajucuElipsuNaMestuIP2(int i)
        {
            if (i >= 0 && i < padajuceElipse2.Count)
            {
                padajuceElipse2[i].Clear();
                padajuceElipse2.RemoveAt(i);
            }

        }

        public void ObradiMoguciPogodakPlayer2(string akord)
        {
            //obradjujemo sta se trazi da se pritisne
            if (!BioPogodak2 && Pogodak2(akord)) //proveravamo da li smo pretisnuli ono sto se trazi
                                                //u MultiPlayer mozda pretisnu u razlicitom trenutku, svakako treba da im se racuna
            {
                //logika pogotka note
                brPogodjenihAkorda2++;
                BioPogodak2 = true;
                poeniCombo2.AzurirajCombo(true);
                poeniCombo2.brPoena += 10 * poeniCombo2.mnoziPoene; // mnozi se sa Combo, puta 2, 3, 4
                for (int i = 0; i < padajuceElipse2[indCiljanihElipsiP2].Count; i++)
                {
                    if (padajuceElipse2[indCiljanihElipsiP2][i].rep != null)
                    {
                        int ind = getIndexOfPositionOsnovneElipse2(padajuceElipse2[indCiljanihElipsiP2][i].PozicijaElipse);
                        osnovneElipse2[ind].rep = padajuceElipse2[indCiljanihElipsiP2][i].rep;
                        padajuceElipse2[indCiljanihElipsiP2][i].rep = null;
                        osnovneElipse2[ind].rep.Pogodjeno = true;
                        osnovneElipse2[ind].rep.linija.B.Y = osnovneElipse2[ind].Y - Elipsa.RY / 2 + 1;
                        Hold2 = true;
                    }
                    if(padajuceElipse2[indCiljanihElipsiP2][i].power != null)
                    {
                        poeniCombo2.DodajPower(padajuceElipse2[indCiljanihElipsiP2][i].power);
                    }
                }
                ObrisiPadajucuElipsuNaMestuIP2(indCiljanihElipsiP2);
            }
            else if (!BioPogodak2)
            {
                poeniCombo2.AzurirajCombo(false);
            }

        }

        public void AzurirajTrazeniAkordP2()
        {
            TrazeniAkord2 = "";
            if (indCiljanihElipsiP2 < padajuceElipse2.Count && indCiljanihElipsiP2 >= 0)
            {
                for (int i = 0; i < padajuceElipse2[indCiljanihElipsiP2].Count; i++)
                {
                    if(padajuceElipse2[indCiljanihElipsiP2][i].Vidljiva)
                        TrazeniAkord2 += padajuceElipse2[indCiljanihElipsiP2][i].PozicijaElipse.ToString();
                }
            }
        }

        public bool Pogodak2(string akord)
        {
            AzurirajTrazeniAkordP2();
            if (akord.Equals(TrazeniAkord2) && akord != "")
            {
                if (indCiljanihElipsiP2 >= 0 && padajuceElipse2[indCiljanihElipsiP2][0].Y < osnovneElipse2[0].Y + Elipsa.RY &&
                    padajuceElipse2[indCiljanihElipsiP2][0].Y > osnovneElipse2[0].Y - Elipsa.RY)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public override void KeyDown(ref byte[] keys) 
        {
            string akord1 = "", akord2 = "";
            bool pretisnutoPogresnoDugme1 = false, pretisnutoPogresnoDugme2 = false;

            //Obrada promene boje pretisnutih dugmica - PLAYER1[]
            if ((keys[TastaturaIKoordinate.TastaturaPlayer1[0]] & 128) == 128)
            {
                if (osnovneElipse[0].RegistrujKeyDown(Hold1))
                    pretisnutoPogresnoDugme1 = true;
                if(osnovneElipse[0].ModCrtanja != 3)
                    akord1 += "1";
            }
            if ((keys[TastaturaIKoordinate.TastaturaPlayer1[1]] & 128) == 128)
            {
                if (osnovneElipse[1].RegistrujKeyDown(Hold1))
                    pretisnutoPogresnoDugme1 = true;
                if (osnovneElipse[1].ModCrtanja != 3)
                    akord1 += "2";
            }
            if ((keys[TastaturaIKoordinate.TastaturaPlayer1[2]] & 128) == 128)
            {
                if (osnovneElipse[2].RegistrujKeyDown(Hold1))
                    pretisnutoPogresnoDugme1 = true;
                if (osnovneElipse[2].ModCrtanja != 3)
                    akord1 += "3";
            }
            if ((keys[TastaturaIKoordinate.TastaturaPlayer1[3]] & 128) == 128)
            {
                if (osnovneElipse[3].RegistrujKeyDown(Hold1))
                    pretisnutoPogresnoDugme1 = true;
                if (osnovneElipse[3].ModCrtanja != 3)
                    akord1 += "4";
            }
            if ((keys[TastaturaIKoordinate.TastaturaPlayer1[4]] & 128) == 128)
            {
                if (osnovneElipse[4].RegistrujKeyDown(Hold1))
                    pretisnutoPogresnoDugme1 = true;
                if (osnovneElipse[4].ModCrtanja != 3)
                    akord1 += "5";
            }
            if ((keys[TastaturaIKoordinate.PowerMode[1]] & 128) == 128 && poeniCombo1.getMoci() > 0)
            {
                PokreniPowerMode2();
            }

            //Obrada moguceg pogotka PLAYER 1
            //if ((keys[TastaturaIKoordinate.OkidaciZica[1]] & 128) == 128 && !Hold1) //space dugme, za okidanje zice
            if ((keys[TastaturaIKoordinate.OkidaciZica[1]] & 128) == 128 && !Hold1) //space dugme, za okidanje zice
            {
                ObradiMoguciPogodakPlayer1(akord1);
            }
            if (Hold1 && pretisnutoPogresnoDugme1)
            {
                Hold1 = false;
                poeniCombo1.AzurirajCombo(false);
                ObrisiHoldOsnovnihElipsi1();
            }

            //Obrada promene boje pretisnutih dugmica - PLAYER2
            if ((keys[TastaturaIKoordinate.TastaturaPlayer2[0]] & 128) == 128)
            {
                if (osnovneElipse2[0].RegistrujKeyDown(Hold2))
                    pretisnutoPogresnoDugme2 = true;
                if (osnovneElipse2[0].ModCrtanja != 3)
                    akord2 += "1";
            }
            if ((keys[TastaturaIKoordinate.TastaturaPlayer2[1]] & 128) == 128)
            {
                if (osnovneElipse2[1].RegistrujKeyDown(Hold2))
                    pretisnutoPogresnoDugme2 = true;
                if (osnovneElipse2[1].ModCrtanja != 3)
                    akord2 += "2";
            }
            if ((keys[TastaturaIKoordinate.TastaturaPlayer2[2]] & 128) == 128)
            {
                if (osnovneElipse2[2].RegistrujKeyDown(Hold2))
                    pretisnutoPogresnoDugme2 = true;
                if (osnovneElipse2[2].ModCrtanja != 3)
                    akord2 += "3";
            }
            if ((keys[TastaturaIKoordinate.TastaturaPlayer2[3]] & 128) == 128)
            {
                if (osnovneElipse2[3].RegistrujKeyDown(Hold2))
                    pretisnutoPogresnoDugme2 = true;
                if (osnovneElipse2[3].ModCrtanja != 3)
                    akord2 += "4";
            }
            if ((keys[TastaturaIKoordinate.TastaturaPlayer2[4]] & 128) == 128)
            {
                if (osnovneElipse2[4].RegistrujKeyDown(Hold2))
                    pretisnutoPogresnoDugme2 = true;
                if (osnovneElipse2[4].ModCrtanja != 3)
                    akord2 += "5";
            }
            if ((keys[TastaturaIKoordinate.PowerMode[2]] & 128) == 128 && poeniCombo2.getMoci() > 0)
            {
                PokreniPowerMode1();
            }


            

            //Obrada moguceg pogotka PLAYER 2
            if ((keys[TastaturaIKoordinate.OkidaciZica[2]] & 128) == 128 && !Hold2) //space dugme, za okidanje zice
            {
                ObradiMoguciPogodakPlayer2(akord2);
            }
            if (Hold2 && pretisnutoPogresnoDugme2)
            {
                Hold2 = false;
                poeniCombo2.AzurirajCombo(false);
                ObrisiHoldOsnovnihElipsi2();
            }
        }

        public void NadjiHoldIObrisiGaP2()
        {
            for (int i = 0; i < osnovneElipse2.Count; i++)
                osnovneElipse2[i].ObrisiHold();
        }

        public override void KeyUp(ref byte[] keys)
        {
            bool promenaHolda1 = false, promenaHolda2 = false; //postace true ako sam negde obrisala Hold (zato sto to dugme vise nije pritisnuto)

            //Obrada KeyUp Player1
            if (!((keys[TastaturaIKoordinate.TastaturaPlayer1[0]] & 128) == 128))
            {
                if (osnovneElipse[0].RegistrujKeyUp(Hold1))
                    promenaHolda1 = true;
            }
            if (!((keys[TastaturaIKoordinate.TastaturaPlayer1[1]] & 128) == 128))
            {
                if (osnovneElipse[1].RegistrujKeyUp(Hold1))
                    promenaHolda1 = true;
            }
            if (!((keys[TastaturaIKoordinate.TastaturaPlayer1[2]] & 128) == 128))
            {
                if (osnovneElipse[2].RegistrujKeyUp(Hold1))
                    promenaHolda1 = true;
            }
            if (!((keys[TastaturaIKoordinate.TastaturaPlayer1[3]] & 128) == 128))
            {
                if (osnovneElipse[3].RegistrujKeyUp(Hold1))
                    promenaHolda1 = true;
            }
            if (!((keys[TastaturaIKoordinate.TastaturaPlayer1[4]] & 128) == 128))
            {
                if (osnovneElipse[4].RegistrujKeyUp(Hold1))
                    promenaHolda1 = true;
            }

            if (Hold1 && promenaHolda1)
            {
                Hold1 = false;
            }

            //Obrada KeyUp Player2
            if (!((keys[TastaturaIKoordinate.TastaturaPlayer2[0]] & 128) == 128))
            {
                if (osnovneElipse2[0].RegistrujKeyUp(Hold2))
                    promenaHolda2 = true;
            }
            if (!((keys[TastaturaIKoordinate.TastaturaPlayer2[1]] & 128) == 128))
            {
                if (osnovneElipse2[1].RegistrujKeyUp(Hold2))
                    promenaHolda2 = true;
            }
            if (!((keys[TastaturaIKoordinate.TastaturaPlayer2[2]] & 128) == 128))
            {
                if (osnovneElipse2[2].RegistrujKeyUp(Hold2))
                    promenaHolda2 = true;
            }
            if (!((keys[TastaturaIKoordinate.TastaturaPlayer2[3]] & 128) == 128))
            {
                if (osnovneElipse2[3].RegistrujKeyUp(Hold2))
                    promenaHolda2 = true;
            }
            if (!((keys[TastaturaIKoordinate.TastaturaPlayer2[4]] & 128) == 128))
            {
                if (osnovneElipse2[4].RegistrujKeyUp(Hold2))
                    promenaHolda2 = true;
            }
            if (!((keys[TastaturaIKoordinate.OkidaciZica[2]] & 128) == 128))
                BioPogodak2 = false;
            if (Hold2 && promenaHolda2)
            {
                Hold2 = false;
            }
        }
        

        public void ObradiPojavljivanjeHoldaP2() //kad pozovem znam da imam karakter H u akordu
        {
            ocitanPocetakHolda = true;
            string tmp = note[index];
            int ind = tmp.IndexOf('H');
            while (ind != -1)
            {

                int i = getIndexOfPositionPadajuceElipse2(padajuceElipse2.Count - 1, tmp[ind - 1] - '0');
                padajuceElipse2[padajuceElipse2.Count - 1][i].DodajNoviHold();

                tmp = tmp.Remove(ind, 1);  //ukloni char pocevsi od indeksa ind duzine 1
                ind = tmp.IndexOf('H');
            }
        }

        public void ObradiKrajHoldaP2()
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
                int i = padajuceElipse2.Count - 1;
                while (i >= 0) //trazi se padajuci krug koji je zapoceo hold, ako ne postoji onda je ili u osnovnom krugu
                               //i pogodjen je ili je promasen pa treba da se ignorise
                {
                    int j = getIndexOfPositionPadajuceElipse2(i, tmp[prethInd] - '0');
                    if (j != -1 && padajuceElipse2[i][j].rep != null) //nadjen je padajuci krug kome hold pripada
                    {
                        padajuceElipse2[i][j].rep.VidljivGornjiKraj = true;
                        nadjen = true;
                        break;
                    }
                    i--;
                }
                if (!nadjen && osnovneElipse2[tmp[prethInd] - '1'].rep != null)
                {
                    osnovneElipse2[tmp[prethInd] - '1'].rep.VidljivGornjiKraj = true;
                    nadjen = true;
                }
                if (!nadjen || zaBrisanje) //to znaci da je Hold obrisan u medjuvremenu i da se vise ne iscrtava, onda treba obrisati
                                           //padajuci krug ciji bi to hold bio ako je samo naznacavao kraj Hold-a
                {
                    int j = getIndexOfPositionPadajuceElipse2(padajuceElipse2.Count - 1, tmp[prethInd] - '0');
                    padajuceElipse2[padajuceElipse2.Count - 1].RemoveAt(j);
                }
                tmp = tmp.Remove(ind, 1);
                ind = tmp.IndexOf('X');
            }
        }


        public void DodajElipsePlayer2()
        {
            if (RegularanAkord(note[index]))
            {
                padajuceElipse2.Add(new List<Elipsa>());

                if (note[index].Contains('1'))
                    padajuceElipse2[padajuceElipse2.Count - 1].Add(new Elipsa(TastaturaIKoordinate.startWidth + TastaturaIKoordinate.getXKoord(0, 2), TastaturaIKoordinate.startHeight, 1));
                if (note[index].Contains('2'))
                    padajuceElipse2[padajuceElipse2.Count - 1].Add(new Elipsa(TastaturaIKoordinate.startWidth + TastaturaIKoordinate.getXKoord(1, 2), TastaturaIKoordinate.startHeight, 2));
                if (note[index].Contains('3'))
                    padajuceElipse2[padajuceElipse2.Count - 1].Add(new Elipsa(TastaturaIKoordinate.startWidth + TastaturaIKoordinate.getXKoord(2, 2), TastaturaIKoordinate.startHeight, 3));
                if (note[index].Contains('4'))
                    padajuceElipse2[padajuceElipse2.Count - 1].Add(new Elipsa(TastaturaIKoordinate.startWidth + TastaturaIKoordinate.getXKoord(3, 2), TastaturaIKoordinate.startHeight, 4));
                if (note[index].Contains('5'))
                    padajuceElipse2[padajuceElipse2.Count - 1].Add(new Elipsa(TastaturaIKoordinate.startWidth + TastaturaIKoordinate.getXKoord(4, 2), TastaturaIKoordinate.startHeight, 5));



                if (note[index].Contains('H')) //za pocetak holda
                    ObradiPojavljivanjeHoldaP2();

                if (note[index].Contains('X')) //za kraj holda
                    ObradiKrajHoldaP2();

                if (padajuceElipse2.Count == 1)
                {
                    indCiljanihElipsiP2 = 0;
                    AzurirajTrazeniAkordP2();
                }
                if (padajuceElipse2[padajuceElipse2.Count - 1].Count > 0)
                {
                    brDodatihAkorda++;
                    ukupnoAkordaP2++;
                    if (ukupnoAkordaP2 % 20 == 0)
                    {
                        int x = padajuceElipse2[padajuceElipse2.Count - 1][0].X, y = padajuceElipse2[padajuceElipse2.Count - 1][0].Y;
                        padajuceElipse2[padajuceElipse2.Count - 1][0].power = PowerMultiPlayer.odrediPower(x, y);
                    }
                    if (PowerMode2 == 4)
                    {
                        for(int i=0; i<padajuceElipse2[padajuceElipse2.Count - 1].Count; i++)
                            padajuceElipse2[padajuceElipse2.Count - 1][i].PokreniEarthquake(10, PowerMultiPlayer.rand.Next(0, 10)); 
                    }
                }
                if (PowerMode2 == 1)
                {
                    for (int i = 0; i < padajuceElipse2[padajuceElipse2.Count - 1].Count; i++)
                    {
                        padajuceElipse2[padajuceElipse2.Count - 1][i].ModCrtanja = 2;
                        if (padajuceElipse2[padajuceElipse2.Count - 1][i].rep != null)
                            padajuceElipse2[padajuceElipse2.Count - 1][i].rep.ModCrtanja = 2;
                    }
                }
                index++;
            }
        }

        public void DodajElipse()
        {
            if (igracNaRedu)
                base.DodajElipsePlayer1();
            else
                DodajElipsePlayer2();
            if (brDodatihAkorda >= brAkordaZaJednog && !ocitanPocetakHolda)
            {
                if (igracNaRedu && ukupanBrAkorda < 30) //ako je prvi na potezu i ostala je jos jedna runda nota koje treba da se podele
                    brAkordaZaJednog = ukupanBrAkorda / 2;
                else if (!igracNaRedu && ukupanBrAkorda <= 15)
                    brAkordaZaJednog = ukupanBrAkorda;
                else
                    brAkordaZaJednog = 15;
                ukupanBrAkorda -= brAkordaZaJednog;
                brDodatihAkorda = 0;
                igracNaRedu = !igracNaRedu;
            }
        }

        public override void PomeriElipse()
        {
            base.PomeriElipse();
            int pomak = 10;
            if (Hold2)
                poeniCombo2.brPoena += poeniCombo2.mnoziPoene;
            for (int i = 0; i < padajuceElipse2.Count; i++)
            {
                for (int j = 0; j < padajuceElipse2[i].Count; j++)
                {
                    padajuceElipse2[i][j].Pomeri(pomak);
                }
            }
            podloga2.Pomeri(pomak);
            for (int i = 0; i < osnovneElipse2.Count; i++)
            {
                if (osnovneElipse2[i].Pomeri(pomak) && Hold2) //ako su se koordinate Hold-a spojile menjamo stanje sistema
                    Hold2 = false;
            }
            if (PowerMode2 > 0)
            {
                timer2--;
                if (timer2 < 0)
                    ZavrsiPowerMode2();
            }
        }

        public void ProveraCiljanogKrugaP2() //vraca true ako je krug ispao iz fokusa, da bi se azurirao Combo
        {
            if (indCiljanihElipsiP2 >= 0 && indCiljanihElipsiP2 < padajuceElipse2.Count && padajuceElipse2[indCiljanihElipsiP2].Count > 0)
            {
                if (padajuceElipse2[indCiljanihElipsiP2][0].Y > osnovneElipse2[0].Y + Elipsa.RY)
                {
                    for (int i = 0; i < padajuceElipse2[indCiljanihElipsiP2].Count; i++)
                        if (padajuceElipse2[indCiljanihElipsiP2][i].rep != null)
                            padajuceElipse2[indCiljanihElipsiP2][i].rep = null;
                    indCiljanihElipsiP2++;
                    if (indCiljanihElipsiP2 < padajuceElipse2.Count)
                        AzurirajTrazeniAkordP2();
                    poeniCombo2.AzurirajCombo(false);
                }
            }
        }

        public void IspaoIzEkranaP2(int height)
        {
            if (padajuceElipse2.Count > 0)
            {
                while (padajuceElipse2.Count > 0 && (padajuceElipse2[0].Count == 0 || padajuceElipse2[0][0].Y - Elipsa.RY / 2 >= height))
                {
                    if (padajuceElipse2[0].Count == 0)
                        ++indCiljanihElipsiP2;
                    padajuceElipse2[0].Clear();
                    ObrisiPadajucuElipsuNaMestuIP2(0);
                    if (--indCiljanihElipsiP2 >= 0)
                        AzurirajTrazeniAkordP2();
                }
            }
        }

        public int getBrPogodjenihAkordaP2()
        {
            return brPogodjenihAkorda2;
        }

        public override void DodajPoprecnuLiniju(int h)
        {
            base.DodajPoprecnuLiniju(h);
            podloga2.DodajPoprecnuliniju();
            podloga2.ObrisiNevidljivePoprecneLinije(h);
        }



    }
}
