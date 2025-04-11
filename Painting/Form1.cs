using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Painting
{
    public partial class Form1 : Form
    {
        //defining
        bool drawingActive = false;
        Point lastPosition;
        static Color highlighterColor = Color.FromArgb(70, Color.Black);
        Random rnd = new Random();
        Bitmap panelBefore;
        bool filled;
        //defining basic pen
        Pen basicPen = new Pen(Color.Black, 5)
        {
            LineJoin = LineJoin.Round,
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };
        //defining highlighter pen + brush
        Pen highlighterPen = new Pen(highlighterColor, 15)
        {
            LineJoin = LineJoin.Round,
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        };

        SolidBrush highlighterBrush = new SolidBrush(highlighterColor);

        Brush basicBrush = new SolidBrush(Color.Black);

        Pen deleteObjectsPen = new Pen(Color.White, width: 3);

        //more defining
        Graphics g;
        Graphics invisible;
        int penActive = 0;
        Point start;
        Point end;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.CompositingMode = CompositingMode.SourceOver;

            invisible = invisiblePanel.CreateGraphics();
            basicPen.Width = 30;
            highlighterPen.Width = 30;

            changeWidth.Value = (decimal)basicPen.Width;

            ChangeHighlighterColor(basicPen.Color);

        }

        //painting
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drawingActive = true;
            start = e.Location;
            panelBefore = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(panelBefore, new Rectangle(0, 0, panel1.Width, panel1.Height));
            //panel1.DrawToBitmap(panelBefore, new Rectangle(0, 0, panel1.Width, panel1.Height));

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            drawingActive = false;
            end = e.Location;
            Point rectangleStart = start;
            panel1.BackgroundImage = null;



            //adapting to the orientation
            if (start.X > end.X) rectangleStart.X = end.X;
            if (start.Y > end.Y) rectangleStart.Y = end.Y;


            if (penActive == 1)//ellipse
            {
                if (filled)
                {
                    g.FillEllipse(basicBrush, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                }
                else
                {
                    g.DrawEllipse(basicPen, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                }

            }
            if (penActive == 4)//rectangle
            {
                if (filled)
                {
                    g.FillRectangle(basicBrush, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                }
                else
                {
                    g.DrawRectangle(basicPen, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                }


            }
            if (penActive == 5)//line
            {
                g.DrawLine(basicPen, start, end);
            }
            if (penActive == 7)//random image
            {
                int imgNmb = rnd.Next(1, 7);
                if (imgNmb == 1)
                {
                    g.DrawImage(Properties.Resources.iconmonstr_reload_alt_filled_240, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                }
                else if (imgNmb == 2)
                {
                    g.DrawImage(Properties.Resources.cat, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                }
                else if (imgNmb == 3)
                {
                    g.DrawImage(Properties.Resources.dog, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                }
                else if (imgNmb == 4)
                {
                    g.DrawImage(Properties.Resources.hedgehog, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                }
                else if (imgNmb == 5)
                {
                    g.DrawImage(Properties.Resources.dog_2, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                }
                else
                {
                    g.DrawImage(Properties.Resources.apple, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                }

            }

        }

        /*Legenda pro penActive:
         * 0 ... basicPen
         * 1 ... ellipse
         * 2 ... highlighter
         * 3 ... dropper
         * 4 ... rectangle
         * 5 ... line
         * 6 ... voskovka
         * 7 ... random image
         * 
         * 
         * 
         * 
         * 
         * 
         */
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (basicBrush != null)
                basicBrush.Dispose();
            basicBrush = new SolidBrush(basicPen.Color);

            if (drawingActive)
            {

                deleteObjectsPen.Color = panel1.BackColor;
                if (penActive == 0)//basic drawing
                {
                    g.DrawLine(basicPen, e.Location, lastPosition);
                }
                else if (penActive == 3)//highlighter
                {
                    DrawSmoothHighlighter(g, highlighterPen.Width, lastPosition, e.Location);
                }
                else if (penActive == 2)//dropper
                {
                    g.FillEllipse(basicBrush, lastPosition.X, lastPosition.Y, basicPen.Width, basicPen.Width);
                    Thread.Sleep(200);
                }
                else if (penActive == 6)//crayon
                {
                    int randomAmount = rnd.Next(7, 20);
                    for (int i = 0; i < randomAmount; i++)
                    {
                        int radius = Math.Max(2, (int)basicPen.Width / 2);
                        int rectSize = Math.Max(2, radius/2);
                        int randomX = rnd.Next(-radius, radius);
                        int randomY = rnd.Next(-radius, radius);
                        int randomTransparency = rnd.Next(80, 100);
                        basicBrush = new SolidBrush(Color.FromArgb(randomTransparency, basicPen.Color));
                        g.FillRectangle(basicBrush, lastPosition.X + randomX, lastPosition.Y + randomY, rectSize, rectSize);
                    }
                }


                end = e.Location;
                Point rectangleStart = start;
                invisiblePanel.Refresh();
                //adapting to the orientation
                if (start.X > end.X) rectangleStart.X = end.X;
                if (start.Y > end.Y) rectangleStart.Y = end.Y;

                /*
                if (penActive == 1)//for showing the ellipse continuously while stretching
                {
                    panel1.BackgroundImage = panelBefore;
                    g.DrawEllipse(basicPen, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                }
                if (penActive == 4)//for showing the rectangle continuously while stretching
                {
                    panel1.BackgroundImage = panelBefore;
                    g.DrawRectangle(basicPen, rectangleStart.X, rectangleStart.Y, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                   
                }
                if (penActive == 5)//line
                {
                    panel1.BackgroundImage = panelBefore;
                    g.DrawLine(basicPen, start, end);
                }
                */
                /*
                if (panelBefore != null || (penActive == 1 && penActive == 4 || penActive == 5))
                {

                    panel1.BackgroundImage = new Bitmap(panelBefore);

                    using (Graphics gPreview = Graphics.FromImage(panel1.BackgroundImage))
                    {
                        if (penActive == 1) // Ellipse
                        {
                            gPreview.DrawEllipse(basicPen, rectangleStart.X, rectangleStart.Y,
                                Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                        }
                        else if (penActive == 4) // Rectangle
                        {
                            gPreview.DrawRectangle(basicPen, rectangleStart.X, rectangleStart.Y,
                                Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                        }
                        else if (penActive == 5) // Line
                        {
                            gPreview.DrawLine(basicPen, start, end);
                        }
                    }

                    panel1.Invalidate(); // force redraw
                }
                */





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
            highlighterPen.Width = (float)changeWidth.Value;

        }

        //pen colors
        private void buttonBlack_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Black;
            ChangeHighlighterColor(Color.Black);
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Red;
            ChangeHighlighterColor(Color.Red);
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Blue;
            ChangeHighlighterColor(Color.Blue);
        }

        private void buttonGreen_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Green;
            ChangeHighlighterColor(Color.Green);

        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Yellow;
            ChangeHighlighterColor(Color.Yellow);
        }

        private void buttonOrange_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.Orange;
            ChangeHighlighterColor(Color.Orange);
        }

        private void buttonLightBlue_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.LightBlue;
            highlighterColor = Color.FromArgb(70, Color.LightBlue);
        }

        private void buttonPink_Click(object sender, EventArgs e)
        {
            basicPen.Color = Color.DeepPink;
            ChangeHighlighterColor(Color.DeepPink);
        }

        //background color
        private void paperWhite_Click(object sender, EventArgs e)
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


        private void line_Click(object sender, EventArgs e)
        {
            penActive = 5;
        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            penActive = 4;
        }

        //eraser
        private void Eraser_Click(object sender, EventArgs e)
        {
            basicPen.Color = panel1.BackColor;
            penActive = 0;
        }


        //pens
        private void Pen_Click(object sender, EventArgs e)
        {
            penActive = 0;
        }

        private void dropper_Click(object sender, EventArgs e)
        {
            penActive = 2;
        }

        private void marker_Click(object sender, EventArgs e)
        {
            penActive = 3;
        }

        private void Crayon_Click(object sender, EventArgs e)
        {
            penActive = 6;
        }

        private void ChangeHighlighterColor(Color color)
        {
            highlighterColor = Color.FromArgb(10, color);
            highlighterPen.Color = highlighterColor;

            if (highlighterBrush != null)highlighterBrush.Dispose();
            highlighterBrush = new SolidBrush(highlighterColor);
        }
        private void DrawSmoothHighlighter(Graphics g, float width, Point p1, Point p2)//from ChatGPT
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            int distance = Math.Max(Math.Abs(dx), Math.Abs(dy));

            for (int i = 0; i <= distance; i++)
            {
                float t = (float)i / distance;
                int x = (int)(p1.X + t * dx);
                int y = (int)(p1.Y + t * dy);
                g.FillEllipse(highlighterBrush, x - width / 2, y - width / 2, width, width);
            }
        }



        private void image_Click(object sender, EventArgs e)
        {
            penActive = 7;
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (filled == true)
            {
                filled = false;
            }
            else
            {
                filled = true;
            }
        }
    }
}


