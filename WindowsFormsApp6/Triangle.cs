using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    internal class Triangle : Polygon
    {
        public PointF[] pointFs;


        public Triangle(int x, int y) : base(x, y)
        {

        }
        public Triangle(PointF[] pointFs) : base(pointFs)
        {
            this.pointFs = pointFs;
        }
    }
    
}
