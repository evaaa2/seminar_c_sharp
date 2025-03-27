using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        Pen basicPen = new Pen(Color.Black, 1);
        Graphics g;
        
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            changeWidth.Value = (decimal)basicPen.Width;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drawingActive = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drawingActive = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingActive)
            {
               
                g.DrawLine(basicPen, e.Location, lastPosition);
           
            }

            lastPosition = e.Location;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            basicPen.Width = (float)changeWidth.Value;
            
        }

        
    }
    }

