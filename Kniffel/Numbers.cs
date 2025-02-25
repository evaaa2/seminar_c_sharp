using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kniffel
{
    internal class Numbers : Combinations
    {
        public int positionLeft;
        public int positionTop;
        public bool isActive = true;

        public int points;
        public int number;

        public Numbers(int positionLeft, int positionTop, int number)
        {
            this.positionLeft = positionLeft;
            this.positionTop = positionTop;
            this.number = number;
        }
        public override int Points(List<int> thrownNumbers)
        {
            int numberOfNumbers = 0;
            for (int i = 0; i < thrownNumbers.Count; i++)
            {
                if (thrownNumbers[i] == number) 
                {
                    numberOfNumbers++;
                }
            }
            points = numberOfNumbers * number;
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
