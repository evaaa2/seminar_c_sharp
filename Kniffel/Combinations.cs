using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kniffel
{
    internal abstract class Combinations
    {
        public Combinations() { }

        public abstract int Points(List<int> list, int number);
    }
}
