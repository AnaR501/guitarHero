using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace GuitarHeroGenerationZ
{

    public partial class ucSettings : UserControl
    {
        public bool[] chosenButton;
        public bool postaviDugme; //pravi razliku sto ne mozemo da 1. selektujemo vise dugmeta 2. se vratimo na meni
        public event EventHandler ButtonClickBackToMenu;

        public ucSettings()
        {
            InitializeComponent();
            cbPlayerMode.Items.Add("Single Player");
            cbPlayerMode.Items.Add("Multi Player 1");
            cbPlayerMode.Items.Add("Multi Player 2");
            cbPlayerMode.SelectedIndex = 0;
            chosenButton = new bool[] { false, false, false, false, false, false, false};

            postaviDugme = false;
        }

        public void PostaviButtone(int i)
        {
            if(i == 0) //postavljamo vrednosti na prvu tastaturu
            {
                btn0.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.Tastatura[0]);
                btn1.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.Tastatura[1]);
                btn2.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.Tastatura[2]);
                btn3.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.Tastatura[3]);
                btn4.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.Tastatura[4]);
                btn5.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.PowerMode[0]);
                btn6.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.OkidaciZica[0]);
            }
            else if (i == 1)
            {
                btn0.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.TastaturaPlayer1[0]);
                btn1.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.TastaturaPlayer1[1]);
                btn2.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.TastaturaPlayer1[2]);
                btn3.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.TastaturaPlayer1[3]);
                btn4.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.TastaturaPlayer1[4]);
                btn5.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.PowerMode[1]);
                btn6.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.OkidaciZica[1]);
            }
            else if (i == 2)
            {
                btn0.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.TastaturaPlayer2[0]);
                btn1.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.TastaturaPlayer2[1]);
                btn2.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.TastaturaPlayer2[2]);
                btn3.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.TastaturaPlayer2[3]);
                btn4.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.TastaturaPlayer2[4]);
                btn5.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.PowerMode[2]);
                btn6.Text = TastaturaIKoordinate.getOriginalKey(TastaturaIKoordinate.OkidaciZica[2]);
            }
        }
        private void btnResetKeyboard_Click(object sender, EventArgs e)
        {
            //Vracamo vrednosti kontrola na default-ne
            TastaturaIKoordinate.ResetujTastature();

            PostaviButtone(cbPlayerMode.SelectedIndex);
            this.cbFlip1.Checked = false;
            this.cbFlip2.Checked = false;
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            if(!postaviDugme)
            {
                if (this.ButtonClickBackToMenu != null)
                    this.ButtonClickBackToMenu(this, e);
            }
        }

        private void cbPlayerMode_SelectedValueChanged(object sender, EventArgs e)
        {
            PostaviButtone(cbPlayerMode.SelectedIndex);
            postaviDugme = false;
            if(chosenButton != null)
                for(int i=0; i<chosenButton.Count(); i++)
                    chosenButton[i] = false;
        }

        private void btnKeys_Click(object sender, EventArgs e) //ako izaberemo ovo dugme hocemo da promenimo vrednost dugmeta
        {
            Button b = (Button)sender;
            int rBr = (int)((b.Name[b.Name.Length - 1]) - '0'); //imenovani su tako da se zavrsavaju indexom radi raspoznavanja
            if(!postaviDugme && !chosenButton[rBr])
            {
                chosenButton[rBr] = true;
                b.BackColor = Color.LightBlue;
                postaviDugme = true;
            }
            else if (postaviDugme && chosenButton[rBr])
            {
                int mod2 = -1, ind2 = -1;
                if (ZauzetostDugmetaPoModu((int)Keys.Enter, cbPlayerMode.SelectedIndex, rBr, ref mod2, ref ind2)) //prolazi uslov ako treba da zamenim dugmice
                {
                    if (cbPlayerMode.SelectedIndex == mod2)
                    {
                        Button b2 = getButtonByName("btn" + ind2.ToString());
                        string tmp = b.Text;
                        b.Text = b2.Text;
                        b2.Text = tmp;
                    }
                    //zamenim im vrednosti u TastaturaIKoordinate
                    TastaturaIKoordinate.ZameniDugmice(cbPlayerMode.SelectedIndex, rBr, mod2, ind2);
                }
                else
                    PostaviTastaturu(rBr, (int)Keys.Enter);
                chosenButton[rBr] = false;
                b.BackColor = Color.White;
                postaviDugme = false;
            }
        }

        public void PostaviTastaturu(int ind, int KeyValue)
        {
            //ind pokazuje indeks dugmeta koje je postavljeno
            //odredjujem koji je mod selektovan
            int mod = cbPlayerMode.SelectedIndex;
            if (ind >= 0 && ind <= 4)
            {
                if (mod == 0) //menjam u Tastatura
                {
                    TastaturaIKoordinate.Tastatura[ind] = KeyValue;
                }
                else if (mod == 1) //menjam u Tastatura Playe1
                {
                    TastaturaIKoordinate.TastaturaPlayer1[ind] = KeyValue;
                }
                else if (mod == 2) //menjam u Tastatura Player2
                {
                    TastaturaIKoordinate.TastaturaPlayer2[ind] = KeyValue;
                }
            }
            else if(ind == 5) //power 
            {
                TastaturaIKoordinate.PowerMode[mod] = KeyValue;
            }
            else if (ind == 6) //strum
            {
                TastaturaIKoordinate.OkidaciZica[mod] = KeyValue;
            }
            //ako je u pitanju power mode onda mi mod odredjuje indeks, mogu bez ifa
        }

        public bool ProveriKeyboardZaMod(int KeyValue, int mod, int ind, ref int mod2, ref int ind2)
        {
            bool izostavi = (mod == mod2);
            bool uslov1, uslov2;
            if (mod == 0)
            {
                for (int i = 0; i < TastaturaIKoordinate.Tastatura.Count(); i++)
                {
                    uslov1 = izostavi ? i != ind : true;
                    if (uslov1 && KeyValue == TastaturaIKoordinate.Tastatura[i])
                    {
                        mod2 = 0;
                        ind2 = i;
                        return true;
                    }
                }
                uslov1 = izostavi ? ind != 5 : true;
                uslov2 = izostavi ? ind != 6 : true;
                if (uslov1 && KeyValue == TastaturaIKoordinate.PowerMode[0])
                {
                    mod2 = 0;
                    ind2 = 5;
                    return true;

                }
                else if (uslov2 && KeyValue == TastaturaIKoordinate.OkidaciZica[0])
                {
                    mod2 = 0;
                    ind2 = 6;
                    return true;
                }
            }
            else if (mod == 1)
            {
                for (int i = 0; i < TastaturaIKoordinate.TastaturaPlayer1.Count(); i++)
                {
                    uslov1 = izostavi ? i != ind : true;
                    if (uslov1 && KeyValue == TastaturaIKoordinate.TastaturaPlayer1[i])
                    {
                        mod2 = 1;
                        ind2 = i;
                        return true;
                    }
                }
                uslov1 = izostavi ? ind != 5 : true;
                uslov2 = izostavi ? ind != 6 : true;
                if (uslov1 && KeyValue == TastaturaIKoordinate.PowerMode[1])
                {
                    mod2 = 1;
                    ind2 = 5;
                    return true;
                }
                else if (uslov2 && KeyValue == TastaturaIKoordinate.OkidaciZica[1])
                {
                    mod2 = 1;
                    ind2 = 6;
                    return true;
                }
            }
            else if (mod == 2)
            {
                for (int i = 0; i < TastaturaIKoordinate.TastaturaPlayer2.Count(); i++)
                {
                    uslov1 = izostavi ? i != ind : true;
                    if (uslov1 && KeyValue == TastaturaIKoordinate.TastaturaPlayer2[i])
                    {
                        mod2 = 2;
                        ind2 = i;
                        return true;
                    }
                }
                uslov1 = izostavi ? ind != 5 : true;
                uslov2 = izostavi ? ind != 6 : true;
                if (uslov1 && KeyValue == TastaturaIKoordinate.PowerMode[2])
                {
                    mod2 = 2;
                    ind2 = 5;
                    return true;
                }
                else if (uslov2 && KeyValue == TastaturaIKoordinate.OkidaciZica[2])
                {
                    mod2 = 2;
                    ind2 = 6;
                    return true;
                }
            }
            return false;
        }

        public bool ZauzetostDugmetaPoModu(int KeyValue, int mod1, int ind1, ref int mod2, ref int ind2)
        {
            //ako je mod1 == mod2 onda treba da izostavim dugme sa indeksom ind1
            bool res = false;
            if(mod1 == 0) //podesavam za Single Player-a
            {
                res = res || ProveriKeyboardZaMod(KeyValue, mod1, ind1, ref mod2, ref ind2);
            }
            else if (mod1 == 1)
            {
                //prodjem kroz ostale buttone moda
                res = res || ProveriKeyboardZaMod(KeyValue, 1, ind1, ref mod2, ref ind2);
                //prodjem kroz sve button-e Playera2
                res = res || ProveriKeyboardZaMod(KeyValue, 2, ind1, ref mod2, ref ind2);
            }
            else if (mod1 == 2) //Menjam u Multi Game Player2
            {
                //prodjem kroz ostale buttone moda - Multi Player 2
                res = res || ProveriKeyboardZaMod(KeyValue, 2, ind1, ref mod2, ref ind2);
                //prodjem kroz sve button-e Playera2 - Multi Player 1
                res = res || ProveriKeyboardZaMod(KeyValue, 1, ind1, ref mod2, ref ind2);
            }
            return res;
        }


        private void btn0_KeyDown(object sender, KeyEventArgs e) 
        { 
            if(postaviDugme) 
            {
                bool nadjen = true;
                string tekst = "";
                //prepoznajemo koje dugme je izabrano preko chosenbutton postavimo njegov Text i u TastaturaIKoord.
                if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) 
                {
                    tekst = ((char)((int)'A' + e.KeyCode - Keys.A)).ToString();
                }
                else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) //onda je broj sa vrha tastature
                {
                    tekst = ((char)((int)'0' + e.KeyCode - Keys.D0)).ToString(); 
                }
                else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) //onda je sa desnih brojeva (KeyPad)
                {
                    tekst = ("Keypad" + (char)((int)'0' + e.KeyCode - Keys.NumPad0)).ToString(); //format je "Keypad0"
                }
                else if (e.KeyCode >= Keys.F1 && e.KeyCode <= Keys.F12)
                {
                    tekst = ("F" + (char)((int)'1' + e.KeyCode - Keys.F1)).ToString(); 
                }
                else if (e.KeyCode == Keys.Back) //backspace
                {
                    tekst = "Backspace"; 
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    tekst = "Enter";
                }
                else if (e.KeyCode == Keys.Space)
                {
                    tekst = "Space";
                }
                else
                    nadjen = false;
                if(nadjen)
                {
                    //nadjen button koji ocekuje i postavim mu text
                    for(int i=0; i<chosenButton.Count(); i++)
                    {
                        if(chosenButton[i])
                        {
                            string name = "btn" + i.ToString();
                            Button b = getButtonByName(name);
                            int mod2 = -1, ind2 = -1;
                            //proveravam da li je izabrano dugme zauzeto, ako jeste zamenim ih
                            if (ZauzetostDugmetaPoModu(e.KeyValue, cbPlayerMode.SelectedIndex, i, ref mod2, ref ind2)) //prolazi uslov ako treba da zamenim dugmice
                            {
                                TastaturaIKoordinate.ZameniDugmice(cbPlayerMode.SelectedIndex, i, mod2, ind2);
                                if (cbPlayerMode.SelectedIndex == mod2)
                                {
                                    Button b2 = getButtonByName("btn" + ind2.ToString());
                                    string tmp = b.Text;
                                    b.Text = b2.Text;
                                    b2.Text = tmp;
                                    b.BackColor = Color.White;
                                }
                                //zamenim im vrednosti u TastaturaIKoordinate

                            }
                            else if (b != null)
                            {
                                PostaviTastaturu(i, e.KeyValue);
                                b.Text = tekst;
                                b.BackColor = Color.White;
                            }
                            chosenButton[i] = false;
                        }
                    }
                    postaviDugme = false;
                    //postavi u tastaturi to dugme na odgovarajucem mestu: mesto zavisi od izabranog moda, dugmeta koje ocekuje 
                    //da bude dodeljen tj njegovog indeksa i da li je power ili okidac 

                }

            }
            else
            {
                //treba da prepoznam koje dugme je okinulo event i da pozovem njegov klik
                if(e.KeyCode == Keys.Enter)
                    btnKeys_Click(sender, e);
            }
        }

        public Button getButtonByName(string name)
        {
            if (name == btn0.Name)
                return btn0;
            else if (name == btn1.Name)
                return btn1;
            else if (name == btn2.Name)
                return btn2;
            else if (name == btn3.Name)
                return btn3;
            else if (name == btn4.Name)
                return btn4;
            else if (name == btn5.Name)
                return btn5;
            else if (name == btn6.Name)
                return btn6;
            else
                return null;
        }


        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            TastaturaIKoordinate.Volume = tbVolume.Value;
            lblVolume.Text = TastaturaIKoordinate.Volume.ToString();
        }

        public void PostaviFlipKeyboard()
        {
            cbFlip1.Checked = !TastaturaIKoordinate.smerTastaturePlayer1;
            cbFlip2.Checked = !TastaturaIKoordinate.smerTastaturePlayer2;
        }

        public void Prikazi()
        {
            PostaviFlipKeyboard();
            PostaviButtone(0);
            lblVolume.Text = TastaturaIKoordinate.Volume.ToString();
            tbVolume.Value = TastaturaIKoordinate.Volume;

        }

        public void PodesiFlip()
        {
            if ((cbFlip1.Checked && TastaturaIKoordinate.smerTastaturePlayer1) || (!cbFlip1.Checked && !TastaturaIKoordinate.smerTastaturePlayer1)) //ako treba da se promeni vrednosti
                TastaturaIKoordinate.FlipKeyboard(1);
            if ((cbFlip2.Checked && TastaturaIKoordinate.smerTastaturePlayer2) || (!cbFlip2.Checked && !TastaturaIKoordinate.smerTastaturePlayer2))
                TastaturaIKoordinate.FlipKeyboard(2);
        }
    }
}
