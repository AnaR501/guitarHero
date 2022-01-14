
using System;
using System.Drawing;

namespace GuitarHeroGenerationZ
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucEndMultiGame1 = new GuitarHeroGenerationZ.ucEndMultiGame();
            this.ucPauseMultiGame1 = new GuitarHeroGenerationZ.ucPauseMultiGame();
            this.ucMultiPlayerGame1 = new GuitarHeroGenerationZ.ucMultiPlayerGame();
            this.ucMultiPlayerOptions1 = new GuitarHeroGenerationZ.ucMultiPlayerOptions();
            this.ucEndSingleGame1 = new GuitarHeroGenerationZ.ucEndSingleGame();
            this.ucPauseSingleGame1 = new GuitarHeroGenerationZ.ucPauseSingleGame();
            this.ucSinglePlayerGame1 = new GuitarHeroGenerationZ.ucSinglePlayerGame();
            this.ucSinglePlayerOptions1 = new GuitarHeroGenerationZ.ucSinglePlayerOptions();
            this.ucMeni1 = new GuitarHeroGenerationZ.ucMeni();
            this.ucSettings1 = new GuitarHeroGenerationZ.ucSettings();
            this.ucHighScores1 = new GuitarHeroGenerationZ.ucHighScores();
            this.SuspendLayout();
            // 
            // ucEndMultiGame1
            // 
            this.ucEndMultiGame1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucEndMultiGame1.Location = new System.Drawing.Point(118, 109);
            this.ucEndMultiGame1.Name = "ucEndMultiGame1";
            this.ucEndMultiGame1.Size = new System.Drawing.Size(941, 643);
            this.ucEndMultiGame1.TabIndex = 8;
            this.ucEndMultiGame1.Visible = false;
            this.ucEndMultiGame1.ButtonClickReply += new System.EventHandler(this.UserControl_ButtonClickMultiPlayerReply);
            this.ucEndMultiGame1.ButtonClickNewSong += new System.EventHandler(this.UserControl_ButtonClickMultiPlayerNewSong);
            this.ucEndMultiGame1.ButtonClickMenu += new System.EventHandler(this.UserControl_ButtonClickMultiPlayerMenu);
            // 
            // ucPauseMultiGame1
            // 
            this.ucPauseMultiGame1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucPauseMultiGame1.Location = new System.Drawing.Point(313, 211);
            this.ucPauseMultiGame1.Name = "ucPauseMultiGame1";
            this.ucPauseMultiGame1.Size = new System.Drawing.Size(541, 425);
            this.ucPauseMultiGame1.TabIndex = 7;
            this.ucPauseMultiGame1.Visible = false;
            this.ucPauseMultiGame1.ButtonClickResume += new System.EventHandler(this.UserControl_ButtonClickMultiPlayerResume);
            this.ucPauseMultiGame1.ButtonClickRestart += new System.EventHandler(this.UserControl_ButtonClickMultiPlayerRestart);
            this.ucPauseMultiGame1.ButtonClickFlipKeyboard1 += new System.EventHandler(this.UserControl_ButtonClickMultiPlayerFlip1);
            this.ucPauseMultiGame1.ButtonClickFlipKeyboard2 += new System.EventHandler(this.UserControl_ButtonClickMultiPlayerFlip2);
            this.ucPauseMultiGame1.ButtonClickQuitGame += new System.EventHandler(this.UserControl_ButtonClickMultiPlayerQuit);
            // 
            // ucMultiPlayerGame1
            // 
            this.ucMultiPlayerGame1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucMultiPlayerGame1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(197)))), ((int)(((byte)(161)))));
            this.ucMultiPlayerGame1.Difficulty = "Easy";
            this.ucMultiPlayerGame1.Location = new System.Drawing.Point(0, 0);
            this.ucMultiPlayerGame1.mySong = null;
            this.ucMultiPlayerGame1.Name = "ucMultiPlayerGame1";
            this.ucMultiPlayerGame1.Player1 = null;
            this.ucMultiPlayerGame1.Player2 = null;
            this.ucMultiPlayerGame1.Size = new System.Drawing.Size(1184, 868);
            this.ucMultiPlayerGame1.TabIndex = 6;
            this.ucMultiPlayerGame1.Visible = false;
            this.ucMultiPlayerGame1.ButtonClickPause += new System.EventHandler(this.UserControl_ButtonClickMultiPlayerPause);
            // 
            // ucMultiPlayerOptions1
            // 
            this.ucMultiPlayerOptions1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucMultiPlayerOptions1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.ucMultiPlayerOptions1.Difficulty = "Easy";
            this.ucMultiPlayerOptions1.Location = new System.Drawing.Point(224, 166);
            this.ucMultiPlayerOptions1.Name = "ucMultiPlayerOptions1";
            this.ucMultiPlayerOptions1.Player1 = "Player1";
            this.ucMultiPlayerOptions1.Player2 = "Player2";
            this.ucMultiPlayerOptions1.Size = new System.Drawing.Size(746, 516);
            this.ucMultiPlayerOptions1.TabIndex = 5;
            this.ucMultiPlayerOptions1.Visible = false;
            this.ucMultiPlayerOptions1.ButtonClickPlay += new System.EventHandler(this.UserControl_ButtonClickMultiPlayerPlay);
            // 
            // ucEndSingleGame1
            // 
            this.ucEndSingleGame1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucEndSingleGame1.Location = new System.Drawing.Point(200, 59);
            this.ucEndSingleGame1.Name = "ucEndSingleGame1";
            this.ucEndSingleGame1.Size = new System.Drawing.Size(754, 693);
            this.ucEndSingleGame1.TabIndex = 4;
            this.ucEndSingleGame1.Visible = false;
            this.ucEndSingleGame1.ButtonClickReply += new System.EventHandler(this.UserControl_ButtonClickSinglePlayerReply);
            this.ucEndSingleGame1.ButtonClickNewSong += new System.EventHandler(this.UserControl_ButtonClickSinglePlayerNewSong);
            this.ucEndSingleGame1.ButtonClickMenu += new System.EventHandler(this.UserControl_ButtonClickSinglePlayerMenu);
            // 
            // ucPauseSingleGame1
            // 
            this.ucPauseSingleGame1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucPauseSingleGame1.Location = new System.Drawing.Point(400, 280);
            this.ucPauseSingleGame1.Name = "ucPauseSingleGame1";
            this.ucPauseSingleGame1.Size = new System.Drawing.Size(383, 339);
            this.ucPauseSingleGame1.TabIndex = 3;
            this.ucPauseSingleGame1.Visible = false;
            this.ucPauseSingleGame1.ButtonClickResume += new System.EventHandler(this.UserControl_ButtonClickSinglePlayerResume);
            this.ucPauseSingleGame1.ButtonClickRestart += new System.EventHandler(this.UserControl_ButtonClickSinglePlayerRestart);
            this.ucPauseSingleGame1.ButtonClickFlipKeyboard += new System.EventHandler(this.UserControl_ButtonClickSinglePlayerFlip);
            this.ucPauseSingleGame1.ButtonClickQuitGame += new System.EventHandler(this.UserControl_ButtonClickSinglePlayerQuit);
            // 
            // ucSinglePlayerGame1
            // 
            this.ucSinglePlayerGame1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ucSinglePlayerGame1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.ucSinglePlayerGame1.Difficulty = "Easy";
            this.ucSinglePlayerGame1.Location = new System.Drawing.Point(0, 0);
            this.ucSinglePlayerGame1.mySong = null;
            this.ucSinglePlayerGame1.Name = "ucSinglePlayerGame1";
            this.ucSinglePlayerGame1.Player = null;
            this.ucSinglePlayerGame1.Size = new System.Drawing.Size(1184, 868);
            this.ucSinglePlayerGame1.TabIndex = 2;
            this.ucSinglePlayerGame1.Visible = false;
            this.ucSinglePlayerGame1.ButtonClickPause += new System.EventHandler(this.UserControl_ButtonClickSinglePlayerPause);
            // 
            // ucSinglePlayerOptions1
            // 
            this.ucSinglePlayerOptions1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ucSinglePlayerOptions1.Difficulty = "Easy";
            this.ucSinglePlayerOptions1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSinglePlayerOptions1.Location = new System.Drawing.Point(271, 166);
            this.ucSinglePlayerOptions1.Name = "ucSinglePlayerOptions1";
            this.ucSinglePlayerOptions1.Player = null;
            this.ucSinglePlayerOptions1.Size = new System.Drawing.Size(636, 487);
            this.ucSinglePlayerOptions1.Song = null;
            this.ucSinglePlayerOptions1.TabIndex = 1;
            this.ucSinglePlayerOptions1.Visible = false;
            this.ucSinglePlayerOptions1.ButtonClickPlay += new System.EventHandler(this.UserControl_ButtonClickSinglePlayerPlay);
            // 
            // ucMeni1
            // 
            this.ucMeni1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMeni1.Location = new System.Drawing.Point(0, 0);
            this.ucMeni1.Name = "ucMeni1";
            this.ucMeni1.Size = new System.Drawing.Size(1184, 861);
            this.ucMeni1.TabIndex = 0;
            this.ucMeni1.ButtonClickSinglePlayer += new System.EventHandler(this.UserControl_ButtonClickSinglePlayer);
            this.ucMeni1.ButtonClickMultiPlayer += new System.EventHandler(this.UserControl_ButtonClickMultiPlayer);
            this.ucMeni1.ButtonClickSettings += new System.EventHandler(this.UserControl_ButtonClickSettings);
            this.ucMeni1.ButtonClickQuit += new System.EventHandler(this.UserControl_ButtonClickQuit);
            this.ucMeni1.ButtonClickHighScores += new System.EventHandler(this.UserControl_ButtonClickHighScores);
            // 
            // ucSettings1
            // 
            this.ucSettings1.Location = new System.Drawing.Point(84, 71);
            this.ucSettings1.Name = "ucSettings1";
            this.ucSettings1.Size = new System.Drawing.Size(1000, 700);
            this.ucSettings1.TabIndex = 9;
            this.ucSettings1.Visible = false;
            this.ucSettings1.ButtonClickBackToMenu += new System.EventHandler(this.UserControl_ButtonClickBackToMenu);
            // 
            // ucHighScores1
            // 
            this.ucHighScores1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(197)))), ((int)(((byte)(161)))));
            this.ucHighScores1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucHighScores1.Location = new System.Drawing.Point(0, 0);
            this.ucHighScores1.Name = "ucHighScores1";
            this.ucHighScores1.Size = new System.Drawing.Size(1184, 861);
            this.ucHighScores1.TabIndex = 10;
            this.ucHighScores1.Visible = false;
            this.ucHighScores1.ButtonClickBackToMenu += new System.EventHandler(this.UserControl_ButtonClickBackToMenuFromHighScores);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(160)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.Controls.Add(this.ucHighScores1);
            this.Controls.Add(this.ucSettings1);
            this.Controls.Add(this.ucEndMultiGame1);
            this.Controls.Add(this.ucPauseMultiGame1);
            this.Controls.Add(this.ucMultiPlayerGame1);
            this.Controls.Add(this.ucMultiPlayerOptions1);
            this.Controls.Add(this.ucEndSingleGame1);
            this.Controls.Add(this.ucPauseSingleGame1);
            this.Controls.Add(this.ucSinglePlayerGame1);
            this.Controls.Add(this.ucSinglePlayerOptions1);
            this.Controls.Add(this.ucMeni1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ucMeni ucMeni1;
        private ucSinglePlayerOptions ucSinglePlayerOptions1;
        private ucSinglePlayerGame ucSinglePlayerGame1;
        private ucPauseSingleGame ucPauseSingleGame1;
        private ucEndSingleGame ucEndSingleGame1;
        private ucMultiPlayerOptions ucMultiPlayerOptions1;
        private ucMultiPlayerGame ucMultiPlayerGame1;
        private ucPauseMultiGame ucPauseMultiGame1;
        private ucEndMultiGame ucEndMultiGame1;
        private ucSettings ucSettings1;
        private ucHighScores ucHighScores1;
    }
}

