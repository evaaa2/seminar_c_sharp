﻿using System;
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
        private static Random rnd = new Random();
        public int positionLeft;
        public int positionTop;
        int currentNumber;
        public bool isActive = true;
        
        public Dice(int positionLeft, int positionTop) 
        { 
            this.positionLeft = positionLeft;
            this.positionTop = positionTop;
        
        }

        
        public void Throw()
        {
            currentNumber = rnd.Next(1, 7);
            Console.SetCursorPosition(this.positionLeft, this.positionTop);
            Console.Write(currentNumber);
        }


        public int ThrownNumber()
        {
            return currentNumber;
        }

       
    }
}
