
namespace GuitarHeroGenerationZ
{
    partial class ucPauseMultiGame
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
            this.button2 = new System.Windows.Forms.Button();
            this.btnFlip1 = new System.Windows.Forms.Button();
            this.btnFlip2 = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnFlip1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnFlip2, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnQuit, 1, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnResume
            // 
            this.btnResume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResume.Font = new System.Drawing.Font("Stencil", 18F);
            this.btnResume.Location = new System.Drawing.Point(103, 43);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(294, 52);
            this.btnResume.TabIndex = 0;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            this.btnResume.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPauseMultiGame_KeyDown);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Stencil", 18F);
            this.button2.Location = new System.Drawing.Point(103, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(294, 52);
            this.button2.TabIndex = 1;
            this.button2.Text = "Restart";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnRestart_Click);
            this.button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPauseMultiGame_KeyDown);
            // 
            // btnFlip1
            // 
            this.btnFlip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFlip1.Font = new System.Drawing.Font("Stencil", 18F);
            this.btnFlip1.Location = new System.Drawing.Point(103, 195);
            this.btnFlip1.Name = "btnFlip1";
            this.btnFlip1.Size = new System.Drawing.Size(294, 52);
            this.btnFlip1.TabIndex = 2;
            this.btnFlip1.Text = "Flip Keyboard 1";
            this.btnFlip1.UseVisualStyleBackColor = true;
            this.btnFlip1.Click += new System.EventHandler(this.btnFlip1_Click);
            this.btnFlip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPauseMultiGame_KeyDown);
            // 
            // btnFlip2
            // 
            this.btnFlip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFlip2.Font = new System.Drawing.Font("Stencil", 18F);
            this.btnFlip2.Location = new System.Drawing.Point(103, 271);
            this.btnFlip2.Name = "btnFlip2";
            this.btnFlip2.Size = new System.Drawing.Size(294, 52);
            this.btnFlip2.TabIndex = 3;
            this.btnFlip2.Text = "Flip Keyboard 2";
            this.btnFlip2.UseVisualStyleBackColor = true;
            this.btnFlip2.Click += new System.EventHandler(this.btnFlip2_Click);
            this.btnFlip2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPauseMultiGame_KeyDown);
            // 
            // btnQuit
            // 
            this.btnQuit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuit.Font = new System.Drawing.Font("Stencil", 18F);
            this.btnQuit.Location = new System.Drawing.Point(103, 347);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(294, 52);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuitGame_Click);
            this.btnQuit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPauseMultiGame_KeyDown);
            // 
            // ucPauseMultiGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucPauseMultiGame";
            this.Size = new System.Drawing.Size(500, 450);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ucPauseMultiGame_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnFlip1;
        private System.Windows.Forms.Button btnFlip2;
        private System.Windows.Forms.Button btnQuit;
    }
}
