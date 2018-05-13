using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IGS1Consol
{

    public class Rectangle
    {
        public Point ver1;
        public Point ver2;
        public Point ver3;
        public Point ver4;
        public float width;
        public float height;


        public Rectangle(Point first, Point second, Point secondandone, Point andone)

        {
            ver1 = first;
            ver2 = second;
            ver3 = secondandone;
            ver4 = andone;
        }





    }
}


