using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                g.DrawLine(Pens.Black, e.Location, lastPosition);
            }

            lastPosition = e.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }
    }
}
