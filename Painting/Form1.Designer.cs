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
            this.Eraser = new System.Windows.Forms.Button();
            this.ellipse = new System.Windows.Forms.Button();
            this.dropper = new System.Windows.Forms.Button();
            this.Pen = new System.Windows.Forms.Button();
            this.rectangle = new System.Windows.Forms.Button();
            this.marker = new System.Windows.Forms.Button();
            this.line = new System.Windows.Forms.Button();
            this.Crayon = new System.Windows.Forms.Button();
            this.invisiblePanel = new System.Windows.Forms.Panel();
            this.image = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.PictureBox();
            this.filledObject = new System.Windows.Forms.CheckBox();
            this.graphicPen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.changeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(20, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 500);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // changeWidth
            // 
            this.changeWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeWidth.Location = new System.Drawing.Point(75, 41);
            this.changeWidth.Name = "changeWidth";
            this.changeWidth.Size = new System.Drawing.Size(53, 29);
            this.changeWidth.TabIndex = 4;
            this.changeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.changeWidth.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonBlack
            // 
            this.buttonBlack.BackColor = System.Drawing.Color.Black;
            this.buttonBlack.Location = new System.Drawing.Point(554, 19);
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
            this.buttonRed.Location = new System.Drawing.Point(584, 19);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(30, 30);
            this.buttonRed.TabIndex = 6;
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonRed_Click);
            // 
            // buttonYellow
            // 
            this.buttonYellow.BackColor = System.Drawing.Color.Yellow;
            this.buttonYellow.Location = new System.Drawing.Point(554, 49);
            this.buttonYellow.Name = "buttonYellow";
            this.buttonYellow.Size = new System.Drawing.Size(30, 30);
            this.buttonYellow.TabIndex = 7;
            this.buttonYellow.UseVisualStyleBackColor = false;
            this.buttonYellow.Click += new System.EventHandler(this.buttonYellow_Click);
            // 
            // buttonOrange
            // 
            this.buttonOrange.BackColor = System.Drawing.Color.Orange;
            this.buttonOrange.Location = new System.Drawing.Point(584, 49);
            this.buttonOrange.Name = "buttonOrange";
            this.buttonOrange.Size = new System.Drawing.Size(30, 30);
            this.buttonOrange.TabIndex = 8;
            this.buttonOrange.UseVisualStyleBackColor = false;
            this.buttonOrange.Click += new System.EventHandler(this.buttonOrange_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.Color.Blue;
            this.buttonBlue.Location = new System.Drawing.Point(614, 19);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(30, 30);
            this.buttonBlue.TabIndex = 9;
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Click += new System.EventHandler(this.buttonBlue_Click);
            // 
            // buttonLightBlue
            // 
            this.buttonLightBlue.BackColor = System.Drawing.Color.LightBlue;
            this.buttonLightBlue.Location = new System.Drawing.Point(614, 49);
            this.buttonLightBlue.Name = "buttonLightBlue";
            this.buttonLightBlue.Size = new System.Drawing.Size(30, 30);
            this.buttonLightBlue.TabIndex = 10;
            this.buttonLightBlue.UseVisualStyleBackColor = false;
            this.buttonLightBlue.Click += new System.EventHandler(this.buttonLightBlue_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.BackColor = System.Drawing.Color.Green;
            this.buttonGreen.Location = new System.Drawing.Point(644, 19);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(30, 30);
            this.buttonGreen.TabIndex = 11;
            this.buttonGreen.UseVisualStyleBackColor = false;
            this.buttonGreen.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonPink
            // 
            this.buttonPink.BackColor = System.Drawing.Color.DeepPink;
            this.buttonPink.Location = new System.Drawing.Point(644, 49);
            this.buttonPink.Name = "buttonPink";
            this.buttonPink.Size = new System.Drawing.Size(30, 30);
            this.buttonPink.TabIndex = 12;
            this.buttonPink.UseVisualStyleBackColor = false;
            this.buttonPink.Click += new System.EventHandler(this.buttonPink_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(867, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Paper Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Pen Color";
            // 
            // paperLime
            // 
            this.paperLime.BackColor = System.Drawing.Color.Lime;
            this.paperLime.Location = new System.Drawing.Point(995, 36);
            this.paperLime.Name = "paperLime";
            this.paperLime.Size = new System.Drawing.Size(32, 30);
            this.paperLime.TabIndex = 20;
            this.paperLime.UseVisualStyleBackColor = false;
            this.paperLime.Click += new System.EventHandler(this.paperLime_Click);
            // 
            // paperBlack
            // 
            this.paperBlack.BackColor = System.Drawing.Color.Black;
            this.paperBlack.Location = new System.Drawing.Point(965, 36);
            this.paperBlack.Name = "paperBlack";
            this.paperBlack.Size = new System.Drawing.Size(32, 30);
            this.paperBlack.TabIndex = 18;
            this.paperBlack.UseVisualStyleBackColor = false;
            this.paperBlack.Click += new System.EventHandler(this.paperBlack_Click);
            // 
            // paperWhite
            // 
            this.paperWhite.BackColor = System.Drawing.Color.White;
            this.paperWhite.Location = new System.Drawing.Point(935, 36);
            this.paperWhite.Name = "paperWhite";
            this.paperWhite.Size = new System.Drawing.Size(32, 30);
            this.paperWhite.TabIndex = 16;
            this.paperWhite.UseVisualStyleBackColor = false;
            this.paperWhite.Click += new System.EventHandler(this.paperWhite_Click);
            // 
            // Eraser
            // 
            this.Eraser.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.Eraser.Location = new System.Drawing.Point(144, 43);
            this.Eraser.Name = "Eraser";
            this.Eraser.Size = new System.Drawing.Size(75, 23);
            this.Eraser.TabIndex = 23;
            this.Eraser.Text = "eraser";
            this.Eraser.UseVisualStyleBackColor = true;
            this.Eraser.Click += new System.EventHandler(this.Eraser_Click);
            // 
            // ellipse
            // 
            this.ellipse.Location = new System.Drawing.Point(704, 53);
            this.ellipse.Name = "ellipse";
            this.ellipse.Size = new System.Drawing.Size(80, 25);
            this.ellipse.TabIndex = 22;
            this.ellipse.Text = "ellipse";
            this.ellipse.UseVisualStyleBackColor = true;
            this.ellipse.Click += new System.EventHandler(this.ellipse_Click);
            // 
            // dropper
            // 
            this.dropper.Location = new System.Drawing.Point(238, 75);
            this.dropper.Name = "dropper";
            this.dropper.Size = new System.Drawing.Size(80, 25);
            this.dropper.TabIndex = 24;
            this.dropper.Text = "dropper";
            this.dropper.UseVisualStyleBackColor = true;
            this.dropper.Click += new System.EventHandler(this.dropper_Click);
            // 
            // Pen
            // 
            this.Pen.Location = new System.Drawing.Point(238, 13);
            this.Pen.Name = "Pen";
            this.Pen.Size = new System.Drawing.Size(80, 25);
            this.Pen.TabIndex = 25;
            this.Pen.Text = "pen";
            this.Pen.UseVisualStyleBackColor = true;
            this.Pen.Click += new System.EventHandler(this.Pen_Click);
            // 
            // rectangle
            // 
            this.rectangle.Location = new System.Drawing.Point(704, 84);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(80, 25);
            this.rectangle.TabIndex = 26;
            this.rectangle.Text = "rectangle";
            this.rectangle.UseVisualStyleBackColor = true;
            this.rectangle.Click += new System.EventHandler(this.rectangle_Click);
            // 
            // marker
            // 
            this.marker.Location = new System.Drawing.Point(238, 44);
            this.marker.Name = "marker";
            this.marker.Size = new System.Drawing.Size(80, 25);
            this.marker.TabIndex = 27;
            this.marker.Text = "highlighter";
            this.marker.UseVisualStyleBackColor = true;
            this.marker.Click += new System.EventHandler(this.marker_Click);
            // 
            // line
            // 
            this.line.Location = new System.Drawing.Point(704, 22);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(80, 25);
            this.line.TabIndex = 28;
            this.line.Text = "line";
            this.line.UseVisualStyleBackColor = true;
            this.line.Click += new System.EventHandler(this.line_Click);
            // 
            // Crayon
            // 
            this.Crayon.Location = new System.Drawing.Point(324, 13);
            this.Crayon.Name = "Crayon";
            this.Crayon.Size = new System.Drawing.Size(80, 25);
            this.Crayon.TabIndex = 29;
            this.Crayon.Text = "crayon";
            this.Crayon.UseVisualStyleBackColor = true;
            this.Crayon.Click += new System.EventHandler(this.Crayon_Click);
            // 
            // invisiblePanel
            // 
            this.invisiblePanel.BackColor = System.Drawing.Color.Transparent;
            this.invisiblePanel.Location = new System.Drawing.Point(20, 150);
            this.invisiblePanel.Name = "invisiblePanel";
            this.invisiblePanel.Size = new System.Drawing.Size(1000, 500);
            this.invisiblePanel.TabIndex = 0;
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(444, 98);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(139, 27);
            this.image.TabIndex = 30;
            this.image.Text = "random image";
            this.image.UseVisualStyleBackColor = true;
            this.image.Click += new System.EventHandler(this.image_Click);
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
            // filledObject
            // 
            this.filledObject.AutoSize = true;
            this.filledObject.Location = new System.Drawing.Point(790, 75);
            this.filledObject.Name = "filledObject";
            this.filledObject.Size = new System.Drawing.Size(53, 17);
            this.filledObject.TabIndex = 31;
            this.filledObject.Text = "filled?";
            this.filledObject.UseVisualStyleBackColor = true;
            this.filledObject.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // graphicPen
            // 
            this.graphicPen.Location = new System.Drawing.Point(324, 45);
            this.graphicPen.Name = "graphicPen";
            this.graphicPen.Size = new System.Drawing.Size(80, 25);
            this.graphicPen.TabIndex = 32;
            this.graphicPen.Text = "graphic pen";
            this.graphicPen.UseVisualStyleBackColor = true;
            this.graphicPen.Click += new System.EventHandler(this.graphicPen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1044, 737);
            this.Controls.Add(this.graphicPen);
            this.Controls.Add(this.filledObject);
            this.Controls.Add(this.image);
            this.Controls.Add(this.Crayon);
            this.Controls.Add(this.line);
            this.Controls.Add(this.dropper);
            this.Controls.Add(this.marker);
            this.Controls.Add(this.rectangle);
            this.Controls.Add(this.Pen);
            this.Controls.Add(this.Eraser);
            this.Controls.Add(this.ellipse);
            this.Controls.Add(this.paperLime);
            this.Controls.Add(this.paperBlack);
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
            this.Controls.Add(this.invisiblePanel);
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
        private System.Windows.Forms.Button paperLime;
        private System.Windows.Forms.Button paperBlack;
        private System.Windows.Forms.Button paperWhite;
        private System.Windows.Forms.Button Eraser;
        private System.Windows.Forms.Button ellipse;
        private System.Windows.Forms.Button dropper;
        private System.Windows.Forms.Button Pen;
        private System.Windows.Forms.Button rectangle;
        private System.Windows.Forms.Button marker;
        private System.Windows.Forms.Button line;
        private System.Windows.Forms.Button Crayon;
        private System.Windows.Forms.Panel invisiblePanel;
        private System.Windows.Forms.Button image;
        private System.Windows.Forms.CheckBox filledObject;
        private System.Windows.Forms.Button graphicPen;
    }
}

