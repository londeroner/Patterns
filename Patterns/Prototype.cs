using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public interface IFigure
    {
        IFigure Clone();
        float GetArea();
    }

    public class Rectangle : IFigure
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public float GetArea()
        {
            return Width * Height;
        }

        public IFigure Clone()
        {
            return new Rectangle(Width, Height);
            //return this.MemberwiseClone() as IFigure;
        }
    }
}
