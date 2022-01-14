
namespace GuitarHeroGenerationZ
{
    partial class ucSinglePlayerOptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpSPO = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNewPlayer = new System.Windows.Forms.TextBox();
            this.cbPlayers = new System.Windows.Forms.ComboBox();
            this.lblNewPlayerMessage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSongs = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            this.btnPlay = new System.Windows.Forms.Button();
            this.tlpSPO.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSPO
            // 
            this.tlpSPO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(197)))), ((int)(((byte)(161)))));
            this.tlpSPO.ColumnCount = 2;
            this.tlpSPO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSPO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSPO.Controls.Add(this.label1, 0, 0);
            this.tlpSPO.Controls.Add(this.label2, 0, 1);
            this.tlpSPO.Controls.Add(this.tbNewPlayer, 1, 1);
            this.tlpSPO.Controls.Add(this.cbPlayers, 1, 0);
            this.tlpSPO.Controls.Add(this.lblNewPlayerMessage, 1, 2);
            this.tlpSPO.Controls.Add(this.label3, 0, 3);
            this.tlpSPO.Controls.Add(this.cbSongs, 1, 3);
            this.tlpSPO.Controls.Add(this.groupBox1, 0, 4);
            this.tlpSPO.Controls.Add(this.btnPlay, 1, 4);
            this.tlpSPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSPO.Location = new System.Drawing.Point(0, 0);
            this.tlpSPO.Name = "tlpSPO";
            this.tlpSPO.RowCount = 5;
            this.tlpSPO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.85149F));
            this.tlpSPO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.85149F));
            this.tlpSPO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.87129F));
            this.tlpSPO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.84158F));
            this.tlpSPO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.58416F));
            this.tlpSPO.Size = new System.Drawing.Size(500, 400);
            this.tlpSPO.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Add New Player:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbNewPlayer
            // 
            this.tbNewPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbNewPlayer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewPlayer.Location = new System.Drawing.Point(286, 72);
            this.tbNewPlayer.Name = "tbNewPlayer";
            this.tbNewPlayer.Size = new System.Drawing.Size(177, 33);
            this.tbNewPlayer.TabIndex = 3;
            this.tbNewPlayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNewPlayer.TextChanged += new System.EventHandler(this.tbNewPlayer_TextChanged);
            // 
            // cbPlayers
            // 
            this.cbPlayers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbPlayers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlayers.FormattingEnabled = true;
            this.cbPlayers.Location = new System.Drawing.Point(286, 13);
            this.cbPlayers.Name = "cbPlayers";
            this.cbPlayers.Size = new System.Drawing.Size(178, 33);
            this.cbPlayers.Sorted = true;
            this.cbPlayers.TabIndex = 4;
            // 
            // lblNewPlayerMessage
            // 
            this.lblNewPlayerMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNewPlayerMessage.AutoSize = true;
            this.lblNewPlayerMessage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPlayerMessage.Location = new System.Drawing.Point(375, 131);
            this.lblNewPlayerMessage.Name = "lblNewPlayerMessage";
            this.lblNewPlayerMessage.Size = new System.Drawing.Size(0, 25);
            this.lblNewPlayerMessage.TabIndex = 5;
            this.lblNewPlayerMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Song:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSongs
            // 
            this.cbSongs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSongs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSongs.FormattingEnabled = true;
            this.cbSongs.Location = new System.Drawing.Point(253, 186);
            this.cbSongs.Name = "cbSongs";
            this.cbSongs.Size = new System.Drawing.Size(244, 29);
            this.cbSongs.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbHard);
            this.groupBox1.Controls.Add(this.rbEasy);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 242);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(13);
            this.groupBox1.Size = new System.Drawing.Size(230, 148);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Difficulty";
            // 
            // rbHard
            // 
            this.rbHard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbHard.AutoSize = true;
            this.rbHard.Location = new System.Drawing.Point(68, 93);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(71, 29);
            this.rbHard.TabIndex = 2;
            this.rbHard.Text = "Hard";
            this.rbHard.UseVisualStyleBackColor = true;
            // 
            // rbEasy
            // 
            this.rbEasy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbEasy.AutoSize = true;
            this.rbEasy.Checked = true;
            this.rbEasy.Location = new System.Drawing.Point(68, 39);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(67, 29);
            this.rbEasy.TabIndex = 0;
            this.rbEasy.TabStop = true;
            this.rbEasy.Text = "Easy";
            this.rbEasy.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlay.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(316, 281);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(118, 70);
            this.btnPlay.TabIndex = 9;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // ucSinglePlayerOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpSPO);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucSinglePlayerOptions";
            this.Size = new System.Drawing.Size(500, 400);
            this.tlpSPO.ResumeLayout(false);
            this.tlpSPO.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSPO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbNewPlayer;
        private System.Windows.Forms.ComboBox cbPlayers;
        public System.Windows.Forms.Label lblNewPlayerMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbHard;
        private System.Windows.Forms.RadioButton rbEasy;
        private System.Windows.Forms.Button btnPlay;
        public System.Windows.Forms.ComboBox cbSongs;
    }
}
