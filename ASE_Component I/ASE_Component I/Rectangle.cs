using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Component_I
{
    /// <summary>
    /// initialized rectangle classs
    /// </summary>
    public class Rectangle:Shape  //insert shape class
    {
        /// <summary>
        /// variables for rectangle class
        /// </summary>
        public int s, n, j, y; //defining variables
        /// <summary>
        /// parameters are passed inside saved_values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public void saved_values(int a, int b, int c,int d)
        {
            s = a; //parameters
            n = b;
            j = c;
            y = d;
        }
        /// <summary>
        /// overriding draw shape method
        /// </summary>
        /// <param name="g"></param>
        public override void Draw_shape(Graphics g)
        {
            Pen mew3 = new Pen(Color.Black, 3);
            g.DrawRectangle(mew3, s, n, j, y);
        }

        /// <summary>
        /// draw_shape method for rectangle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="colour"></param>
        /// <param name="fill"></param>
        public void Draw_shape(Graphics g, Color colour, bool fill)
        {
            Pen tri1 = new Pen(colour);
            SolidBrush brush = new SolidBrush(colour);

            if (fill) { g.FillRectangle(brush, s, n, j, y); }
            else { g.DrawRectangle(tri1, s, n, j, y); }

        }
    }
}
