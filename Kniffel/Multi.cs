using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kniffel
{
    internal class Multi : Combinations
        // class for triple, quadruple, Yatzy and chance
    {
        public int positionLeft;
        public int positionTop;
        public bool isActive = true;

        public int points = 0;
        public int number;
        public Multi(int positionLeft, int positionTop, int number)
        {
            this.positionLeft = positionLeft;
            this.positionTop = positionTop;
            this.number = number;
        }

        //count points
        public override int Points(List<int> thrownNumbers)
        {
            points = 0;
            int one = 0;
            int two = 0;
            int three = 0;
            int four = 0;
            int five = 0;
            int six = 0;

            //counting how many times was each number thrown
            foreach (int nmb in thrownNumbers)
            {
                if (nmb == 1) one++;
                else if (nmb == 2) two++; 
                else if (nmb == 3) three++;
                else if (nmb == 4) four++;
                else if (nmb == 5) five++;
                else if (nmb == 6) six++;

                points += nmb;//for tree and four of a kind
            }

            //for kniffel
            if(this.number == 5 && (one == 5 || two == 5 || three == 5 || three == 5 || four == 5 || five == 5 ))
            {
                points = 50;
            }

            //for fullhouse
            // a quintuple is not considered a fullhouse
            else if (this.number == 6 && (one == 2 || two == 2 || three == 2 || four == 2 || five == 2 || six == 2) && (one == 3 || two == 3 || three == 3 || four == 3 || five == 3 || six == 3))
            {
                points = 25;
            }

            //in case of not fulfilling the criteria for a combination
            else if (one < this.number && two < this.number && three < this.number && four < this.number && five < this.number && six < this.number)
            {
                points = 0;
            }
            return points;
        }
        //write points in console
        public override void Write(List<int> thrownNumbers)
        {
            Console.SetCursorPosition(this.positionLeft, this.positionTop);
            Console.Write(Points(thrownNumbers));
            isActive = false;
        }
    }
}
