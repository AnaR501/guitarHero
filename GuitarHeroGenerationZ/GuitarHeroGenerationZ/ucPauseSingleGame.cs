using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarHeroGenerationZ
{
    public partial class ucPauseSingleGame : UserControl
    {
        public event EventHandler ButtonClickResume;
        public event EventHandler ButtonClickRestart;
        public event EventHandler ButtonClickFlipKeyboard;
        public event EventHandler ButtonClickQuitGame;


        public ucPauseSingleGame()
        {
            InitializeComponent();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickResume != null)
                this.ButtonClickResume(this, e);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickRestart != null)
                this.ButtonClickRestart(this, e);
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickFlipKeyboard != null)
                this.ButtonClickFlipKeyboard(this, e);
        }

        private void btnQuitGame_Click(object sender, EventArgs e)
        {
            if (this.ButtonClickQuitGame != null)
                this.ButtonClickQuitGame(this, e);
        }

        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);

        private void ucPauseSingleGame_KeyDown(object sender, KeyEventArgs e)
        {
            byte[] keys = new byte[256];

            GetKeyboardState(keys);
            if ((keys[(int)Keys.Escape] & 128) == 128)
                btnResume_Click(this, e);
        }
    }
}
