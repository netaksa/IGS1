using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGS1Consol
{

    /// <summary>
    /// Defines a point on a two-dimensional plane.
    /// </summary>
    public class Point
    {
        float x;
        float y;
       

        public Point()

        {
     
        }
        public Point(float x, float y)

        {
            X = x;
            Y = y;
        }

        public bool IsEmpty { get { return X == 0 && Y == 0; } }

        /// <summary>
        /// Gets or sets the X coordinate of this instance.
        /// </summary>
        public float X { get { return x; } set { x = value; } }

        /// <summary>
        /// Gets or sets the Y coordinate of this instance.
        /// </summary>
        public float Y { get { return y; } set { y = value; } }

        /// <summary>
        /// Returns the Point (0, 0).
        /// </summary>
        /// <summary>
        /// Translates the specified Point by the specified Size.
        /// </summary>
        /// <param name="point">
        /// The <see cref="Point"/> instance to translate.
        /// </param>
        /// <param name="size">
        /// The <see cref="Size"/> instance to translate point with.
        /// </param>
        /// <returns>
        /// A new <see cref="Point"/> instance translated by size.
        /// </returns>
        public static Point operator +(Point point, Size size)
        {
            return new Point(point.X + size.Width, point.Y + size.Height);
        }


        public static Point operator -(Point point, Size size)
        {
            return new Point(point.X - size.Width, point.Y - size.Height);
        }

    }

}
