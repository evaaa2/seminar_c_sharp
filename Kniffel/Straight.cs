using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kniffel 
{
    //class for small and large straight
    internal class Straight : Combinations
    {
        public int positionLeft;
        public int positionTop;
        public bool isActive = true;

        public int points;
        public int number;

        public Straight(int positionLeft, int positionTop, int number)
        {
            this.positionLeft = positionLeft;
            this.positionTop = positionTop;
            this.number = number;

        }
        //count points
        public override int Points(List<int> thrownNumbers)
        {
            List<int> smallStraight = new List<int>(){1, 2, 3, 4};
            List<int> largeStraight = new List<int>(){1, 2, 3, 4, 5};

            bool boolSmallStraight = false;
            bool boolLargeStraight = false;

            
            //small straight
            if (this.number == 1)
            {
                for (int i = 0; i < 3; i++) //for all possible small straights
                {
                    foreach (int a in smallStraight)
                    {
                        if (thrownNumbers.Contains(a + i))
                        {
                            boolSmallStraight = true;
                        }
                        else
                        {
                            boolSmallStraight = false;
                            break;
                        }
                    }
                    if (boolSmallStraight)
                    {
                        points = 30;
                        break;
                    }
                    else points = 0;
                }
                
            }
            //large straight
            if (this.number == 2)
            {
                for (int i = 0; i < 2; i++)// for all possible large straights
                {
                    foreach (int a in largeStraight)
                    {
                        if (thrownNumbers.Contains(a + i))
                        {
                            boolLargeStraight = true;
                        }
                        else 
                        {
                            boolLargeStraight = false;
                            break;
                         }
                    }
                    if (boolLargeStraight)
                    {
                        points = 40;
                        break;
                    }
                    else points = 0;
                }
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

