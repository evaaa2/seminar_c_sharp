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
        
        public Dice(int positionLeft, int positionTop) 
        { 
            this.positionLeft = positionLeft;
            this.positionTop = positionTop;
        
        }

        private int RandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }
        
        public void Throw()
        {
                Console.SetCursorPosition(positionLeft, positionTop);
                Console.Write(RandomNumber());
                //Console.Beep(440, 100);
                //Thread.Sleep(i * i * 4);
        }


        public int ThrownNumber()
        {
            return currentNumber;
        }
    }
}
