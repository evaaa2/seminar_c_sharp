using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Painting
{
    public partial class Form1 : Form
    {
        bool drawingActive = false;
        Point lastPosition;
        Pen basicPen = new Pen(Color.Black, 1)
        {
            LineJoin = LineJoin.Round,
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };
        
        Pen objectsPen = new Pen(Color.Black, 1);
        Graphics g;
        int penActive = 0;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            changeWidth.Value = (decimal)basicPen.Width;
        }

        //painting
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drawingActive = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drawingActive = false;
        }

    /*Legenda pro penActive:
     * 0 ... basicPen
     * 1 ... ellipse
     * 2 ... rectangle
     * 3 ... 
     * 
     * 
     * 
     * 
     */
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingActive)
            {
                if  (penActive == 0)
                {
                    g.DrawLine(basicPen, e.Location, lastPosition);
                }
                else if (penActive == 2)
                {
                    int i = 0;
                    if (i/5 == 0)
                    {

                    }
                    g.FillEllipse(Brushes.Black, lastPosition.X, lastPosition.Y, 20, 20);
                }
                
            }

            lastPosition = e.Location;
        }

        //refresh button
        private void refreshButton_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        //changing pen width
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            basicPen.Width = (float)changeWidth.Value;
            
        }

        //pen color
        private void buttonBlack_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Black;
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Red;
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Blue;
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Green;
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Yellow;
        }

        private void buttonOrange_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Orange;
        }

        private void buttonLightBlue_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.LightBlue;
        }

        private void buttonPink_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.DeepPink;
        }

        //paper color
        private void button6_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
        }

        private void paperBlack_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
        }

        private void paperLime_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Lime;
        }

        

        //shapes
        private void ellipse_Click(object sender, EventArgs e)
        {
            penActive = 1;
        }

        //eraser
        private void Eraser_Click(object sender, EventArgs e)
        {
            basicPen.Color = panel1.BackColor;
        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            penActive = 2;
        }

        private void Pen_Click(object sender, EventArgs e)
        {
            penActive = 0;
        }
    }
    }

