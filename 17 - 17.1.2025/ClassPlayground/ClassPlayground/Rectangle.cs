using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Rectangle
    {
        private float width;
        private float height;
        public float area;
        public float aspectRatio;

        public Rectangle(float widthInput, float heightInput)
        {
            
            width = widthInput;
            height = heightInput;
        }
        public float CalculateArea()
        {
            area = width * height;
            return area;
        }
        public float CalculateAspectRatio()
        {
            aspectRatio = width / height;
            return aspectRatio;
        }
        public bool ContainsPoint(float x, float y)
        {
            if (x <=0 || y <=0 || x >=width || y >=height) return false;
            else return true;
        }
        
    }
}
