using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Shape2D
    {
        public virtual float CalculateArea()
        {
            Console.WriteLine("Does not make sense");
            return 0;
        }
        public virtual float CalculateAspectRatio()
        {
            Console.WriteLine("Does not make sense");
            return 0;
        }
        public virtual bool ContainsPoint(float x, float y)
        {
            Console.WriteLine("Does not make sense");
            return false;
        }
    }
}
