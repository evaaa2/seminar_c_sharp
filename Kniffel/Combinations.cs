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
        public Combinations() {}

        public abstract int Points(List<int> thrownNumbers);
        public abstract void Write(List<int> thrownNumbers);
    }
}
