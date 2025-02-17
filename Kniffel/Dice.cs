using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kniffel
{
    internal class Dice
    {
        int positionLeft;
        int positionTop;
        int currentNumber;
        Random rnd = new Random();
        public Dice(int positionLeft, int positionTop) 
        { 
            this.positionLeft = positionLeft;
            this.positionTop = positionTop;
        
        }

        
        public void Throw()
        {
            for (int i = 0; i < 12; i++)
            {
                currentNumber = rnd.Next(1, 6);
                Console.SetCursorPosition(positionLeft, positionTop);
                Console.Write(currentNumber);
                //Console.Beep(440, 100);
                Thread.Sleep(i * i * 4);
            }
        }

        public int ThrownNumber()
        {
            return currentNumber;
        }
    }
}
