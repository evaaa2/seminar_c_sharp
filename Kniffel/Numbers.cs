using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kniffel
{
    internal class Numbers : Combinations
    {
        public override int Points(List<int> list, int number)
        {
            int numberOfNumbers = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == number) 
                {
                    numberOfNumbers++;
                }
            }
            return numberOfNumbers * number;

        }
    }
}
