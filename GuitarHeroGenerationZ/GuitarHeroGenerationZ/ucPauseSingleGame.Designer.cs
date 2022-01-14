
namespace GuitarHeroGenerationZ
{
    partial class ucPauseSingleGame
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnFlip = new System.Windows.Forms.Button();
            this.btnQuitGame = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnResume, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRestart, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnFlip, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnQuitGame, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(441, 405);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnResume
            // 
            this.btnResume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResume.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.Location = new System.Drawing.Point(91, 43);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(258, 62);
            this.btnResume.TabIndex = 0;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            this.btnResume.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPauseSingleGame_KeyDown);
            // 
            // btnRestart
            // 
            this.btnRestart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRestart.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.Location = new System.Drawing.Point(91, 127);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(258, 62);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            this.btnRestart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPauseSingleGame_KeyDown);
            // 
            // btnFlip
            // 
            this.btnFlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFlip.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlip.Location = new System.Drawing.Point(91, 211);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(258, 62);
            this.btnFlip.TabIndex = 2;
            this.btnFlip.Text = "Flip Keyboard";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.btnFlip_Click);
            this.btnFlip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPauseSingleGame_KeyDown);
            // 
            // btnQuitGame
            // 
            this.btnQuitGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuitGame.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitGame.Location = new System.Drawing.Point(91, 295);
            this.btnQuitGame.Name = "btnQuitGame";
            this.btnQuitGame.Size = new System.Drawing.Size(258, 62);
            this.btnQuitGame.TabIndex = 3;
            this.btnQuitGame.Text = "Quit";
            this.btnQuitGame.UseVisualStyleBackColor = true;
            this.btnQuitGame.Click += new System.EventHandler(this.btnQuitGame_Click);
            this.btnQuitGame.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPauseSingleGame_KeyDown);
            // 
            // ucPauseSingleGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucPauseSingleGame";
            this.Size = new System.Drawing.Size(441, 405);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPauseSingleGame_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnFlip;
        private System.Windows.Forms.Button btnQuitGame;
    }
}
