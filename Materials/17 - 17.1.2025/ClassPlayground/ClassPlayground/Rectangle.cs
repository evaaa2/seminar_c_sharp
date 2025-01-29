using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Rectangle : Shape2D
    {
        private float width;
        private float height;
        public float area;
        public float aspectRatio;

        public Rectangle(float widthInput, float heightInput)
        {
            if (widthInput == 0) width = 1;
            else if (width < 0) width = -widthInput;
            else width = widthInput;

            if (heightInput == 0) height = 1;
            else if (height < 0) height = -heightInput;
            else height = heightInput;

        }
        public override float CalculateArea()
        {
            area = width * height;
            return area;
        }
        public override float CalculateAspectRatio()
        {
            aspectRatio = width / height;
            return aspectRatio;
        }
        public override bool ContainsPoint(float x, float y)
        {
            if (x <=0 || y <=0 || x >=width || y >=height) return false;
            else return true;
        }
        
    }
}
