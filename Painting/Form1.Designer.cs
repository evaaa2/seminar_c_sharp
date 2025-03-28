namespace Painting
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.changeWidth = new System.Windows.Forms.NumericUpDown();
            this.buttonBlack = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonYellow = new System.Windows.Forms.Button();
            this.buttonOrange = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.buttonLightBlue = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.buttonPink = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paperLime = new System.Windows.Forms.Button();
            this.paperBlack = new System.Windows.Forms.Button();
            this.paperWhite = new System.Windows.Forms.Button();
            this.paperCtvrka1 = new System.Windows.Forms.Button();
            this.paperSquared = new System.Windows.Forms.Button();
            this.paperCtvrtka = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.changeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(12, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 349);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // changeWidth
            // 
            this.changeWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeWidth.Location = new System.Drawing.Point(63, 44);
            this.changeWidth.Name = "changeWidth";
            this.changeWidth.Size = new System.Drawing.Size(53, 29);
            this.changeWidth.TabIndex = 4;
            this.changeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.changeWidth.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonBlack
            // 
            this.buttonBlack.BackColor = System.Drawing.Color.Black;
            this.buttonBlack.Location = new System.Drawing.Point(165, 10);
            this.buttonBlack.Margin = new System.Windows.Forms.Padding(1);
            this.buttonBlack.Name = "buttonBlack";
            this.buttonBlack.Size = new System.Drawing.Size(30, 30);
            this.buttonBlack.TabIndex = 5;
            this.buttonBlack.UseVisualStyleBackColor = false;
            this.buttonBlack.Click += new System.EventHandler(this.buttonBlack_Click);
            // 
            // buttonRed
            // 
            this.buttonRed.BackColor = System.Drawing.Color.Red;
            this.buttonRed.Location = new System.Drawing.Point(195, 10);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(30, 30);
            this.buttonRed.TabIndex = 6;
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonRed_Click);
            // 
            // buttonYellow
            // 
            this.buttonYellow.BackColor = System.Drawing.Color.Yellow;
            this.buttonYellow.Location = new System.Drawing.Point(165, 40);
            this.buttonYellow.Name = "buttonYellow";
            this.buttonYellow.Size = new System.Drawing.Size(30, 30);
            this.buttonYellow.TabIndex = 7;
            this.buttonYellow.UseVisualStyleBackColor = false;
            this.buttonYellow.Click += new System.EventHandler(this.buttonYellow_Click);
            // 
            // buttonOrange
            // 
            this.buttonOrange.BackColor = System.Drawing.Color.Orange;
            this.buttonOrange.Location = new System.Drawing.Point(195, 40);
            this.buttonOrange.Name = "buttonOrange";
            this.buttonOrange.Size = new System.Drawing.Size(30, 30);
            this.buttonOrange.TabIndex = 8;
            this.buttonOrange.UseVisualStyleBackColor = false;
            this.buttonOrange.Click += new System.EventHandler(this.buttonOrange_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.Color.Blue;
            this.buttonBlue.Location = new System.Drawing.Point(225, 10);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(30, 30);
            this.buttonBlue.TabIndex = 9;
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Click += new System.EventHandler(this.buttonBlue_Click);
            // 
            // buttonLightBlue
            // 
            this.buttonLightBlue.BackColor = System.Drawing.Color.LightBlue;
            this.buttonLightBlue.Location = new System.Drawing.Point(225, 40);
            this.buttonLightBlue.Name = "buttonLightBlue";
            this.buttonLightBlue.Size = new System.Drawing.Size(30, 30);
            this.buttonLightBlue.TabIndex = 10;
            this.buttonLightBlue.UseVisualStyleBackColor = false;
            this.buttonLightBlue.Click += new System.EventHandler(this.buttonLightBlue_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.BackColor = System.Drawing.Color.Green;
            this.buttonGreen.Location = new System.Drawing.Point(255, 10);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(30, 30);
            this.buttonGreen.TabIndex = 11;
            this.buttonGreen.UseVisualStyleBackColor = false;
            this.buttonGreen.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonPink
            // 
            this.buttonPink.BackColor = System.Drawing.Color.DeepPink;
            this.buttonPink.Location = new System.Drawing.Point(255, 40);
            this.buttonPink.Name = "buttonPink";
            this.buttonPink.Size = new System.Drawing.Size(30, 30);
            this.buttonPink.TabIndex = 12;
            this.buttonPink.UseVisualStyleBackColor = false;
            this.buttonPink.Click += new System.EventHandler(this.buttonPink_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Paper";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Pen Color";
            // 
            // paperLime
            // 
            this.paperLime.BackColor = System.Drawing.Color.Lime;
            this.paperLime.Location = new System.Drawing.Point(560, 10);
            this.paperLime.Name = "paperLime";
            this.paperLime.Size = new System.Drawing.Size(30, 30);
            this.paperLime.TabIndex = 20;
            this.paperLime.UseVisualStyleBackColor = false;
            this.paperLime.Click += new System.EventHandler(this.paperLime_Click);
            // 
            // paperBlack
            // 
            this.paperBlack.BackColor = System.Drawing.Color.Black;
            this.paperBlack.Location = new System.Drawing.Point(530, 10);
            this.paperBlack.Name = "paperBlack";
            this.paperBlack.Size = new System.Drawing.Size(30, 30);
            this.paperBlack.TabIndex = 18;
            this.paperBlack.UseVisualStyleBackColor = false;
            this.paperBlack.Click += new System.EventHandler(this.paperBlack_Click);
            // 
            // paperWhite
            // 
            this.paperWhite.BackColor = System.Drawing.Color.White;
            this.paperWhite.Location = new System.Drawing.Point(500, 10);
            this.paperWhite.Name = "paperWhite";
            this.paperWhite.Size = new System.Drawing.Size(30, 30);
            this.paperWhite.TabIndex = 16;
            this.paperWhite.UseVisualStyleBackColor = false;
            this.paperWhite.Click += new System.EventHandler(this.button6_Click);
            // 
            // paperCtvrka1
            // 
            this.paperCtvrka1.BackColor = System.Drawing.Color.DeepPink;
            this.paperCtvrka1.BackgroundImage = global::Painting.Properties.Resources.ctvrtka1;
            this.paperCtvrka1.Location = new System.Drawing.Point(560, 40);
            this.paperCtvrka1.Name = "paperCtvrka1";
            this.paperCtvrka1.Size = new System.Drawing.Size(30, 30);
            this.paperCtvrka1.TabIndex = 21;
            this.paperCtvrka1.UseVisualStyleBackColor = false;
            this.paperCtvrka1.Click += new System.EventHandler(this.paperCtvrka1_Click);
            // 
            // paperSquared
            // 
            this.paperSquared.BackColor = System.Drawing.Color.LightBlue;
            this.paperSquared.BackgroundImage = global::Painting.Properties.Resources.squaredPaper;
            this.paperSquared.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paperSquared.Location = new System.Drawing.Point(530, 40);
            this.paperSquared.Name = "paperSquared";
            this.paperSquared.Size = new System.Drawing.Size(30, 30);
            this.paperSquared.TabIndex = 19;
            this.paperSquared.UseVisualStyleBackColor = false;
            this.paperSquared.Click += new System.EventHandler(this.paperSquared_Click);
            // 
            // paperCtvrtka
            // 
            this.paperCtvrtka.BackColor = System.Drawing.Color.Orange;
            this.paperCtvrtka.BackgroundImage = global::Painting.Properties.Resources.ctvrtka;
            this.paperCtvrtka.Location = new System.Drawing.Point(500, 40);
            this.paperCtvrtka.Name = "paperCtvrtka";
            this.paperCtvrtka.Size = new System.Drawing.Size(30, 30);
            this.paperCtvrtka.TabIndex = 17;
            this.paperCtvrtka.UseVisualStyleBackColor = false;
            this.paperCtvrtka.Click += new System.EventHandler(this.paperCtvrtka_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackgroundImage = global::Painting.Properties.Resources.iconmonstr_reload_alt_filled_240;
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshButton.Image = global::Painting.Properties.Resources.iconmonstr_reload_alt_filled_240;
            this.refreshButton.InitialImage = global::Painting.Properties.Resources.iconmonstr_reload_alt_filled_240;
            this.refreshButton.Location = new System.Drawing.Point(12, 28);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(45, 45);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.TabStop = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.paperCtvrka1);
            this.Controls.Add(this.paperLime);
            this.Controls.Add(this.paperSquared);
            this.Controls.Add(this.paperBlack);
            this.Controls.Add(this.paperCtvrtka);
            this.Controls.Add(this.paperWhite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPink);
            this.Controls.Add(this.buttonGreen);
            this.Controls.Add(this.buttonLightBlue);
            this.Controls.Add(this.buttonBlue);
            this.Controls.Add(this.buttonOrange);
            this.Controls.Add(this.buttonYellow);
            this.Controls.Add(this.buttonRed);
            this.Controls.Add(this.buttonBlack);
            this.Controls.Add(this.changeWidth);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.changeWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox refreshButton;
        private System.Windows.Forms.NumericUpDown changeWidth;
        private System.Windows.Forms.Button buttonBlack;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonYellow;
        private System.Windows.Forms.Button buttonOrange;
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.Button buttonLightBlue;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Button buttonPink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button paperCtvrka1;
        private System.Windows.Forms.Button paperLime;
        private System.Windows.Forms.Button paperSquared;
        private System.Windows.Forms.Button paperBlack;
        private System.Windows.Forms.Button paperCtvrtka;
        private System.Windows.Forms.Button paperWhite;
    }
}

