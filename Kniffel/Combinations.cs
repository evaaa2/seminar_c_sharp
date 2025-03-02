using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kniffel
{
    internal abstract class Combinations
    {
        public int positionLeft;
        public int positionTop;
        public bool isActive;
        public int points;
        public Combinations() {}

        //count points
        public abstract int Points(List<int> thrownNumbers);

        //write points in console
        public abstract void Write(List<int> thrownNumbers);
    }
}
