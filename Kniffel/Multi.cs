using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kniffel
{
    internal class Multi : Combinations
    {
        public int positionLeft;
        public int positionTop;
        public bool isActive = true;

        public static int points = 0;
        public int number;
        public Multi(int positionLeft, int positionTop, int number)
        {
            this.positionLeft = positionLeft;
            this.positionTop = positionTop;
            this.number = number;
        }

        public override int Points(List<int> thrownNumbers)
        {
            foreach (int nmb in thrownNumbers)
            {
                points = 0;
                int one = 0;
                int two = 0;
                int three = 0;
                int four = 0;
                int five = 0;
                int six = 0;

                if (nmb == 1) one++;
                else if (nmb == 2) two++; 
                else if (nmb == 3) three++;
                else if (nmb == 4) four++;
                else if (nmb == 5) five++;
                else if (nmb == 6) six++;

                points += nmb;


                if (one < this.number && two < this.number && three < this.number && four < this.number && five < this.number && six < this.number)
                {
                    points = 0;
                }
               
            }
            return points;
        }

        public override void Write(List<int> thrownNumbers)
        {
            Console.SetCursorPosition(this.positionLeft, this.positionTop);
            Console.Write(Points(thrownNumbers));
            isActive = false;
        }
    }
}
