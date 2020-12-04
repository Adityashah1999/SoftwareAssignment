using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Component_I
{
    /// <summary>
    /// for triangle
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// 
        /// </summary>
        public int val1 , val2, bas, perp, hypt;

        
         /// <summary>
         /// initialized parameters for saved_values
         /// </summary>
         /// <param name="x"></param>
         /// <param name="y"></param>
         /// <param name="z"></param>
         /// <param name="w"></param>
        public void saved_values(int x, int y, int z, int w)
        {
            val1 = x;
            val2 = y;
            bas = z;
            perp = w;
        }
        /// <summary>
        /// overriding draw_shape method
        /// </summary>
        /// <param name="g"></param>
        public override void Draw_shape(Graphics g)
        {
            Pen tri1 = new Pen(Color.Black, 3);
            PointF A = new Point(val1, val2);
            PointF B = new PointF(val1 + perp, val2);
            PointF C = new PointF(B.X, B.Y + perp);
            PointF[] cho = { A, B, C };
            g.DrawPolygon(tri1, cho);

        }
        /// <summary>
        /// draw_shape method for triangle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="colour"></param>
        /// <param name="fill"></param>
        public void Draw_shape(Graphics g, Color colour, bool fill)
        {
            Pen tri1 = new Pen(colour);
            SolidBrush brush = new SolidBrush(colour);
            Pen mew2 = new Pen(colour, 3);
            PointF A = new Point(val1, val2);
            PointF B = new PointF(val1 + perp, val2);
            PointF C = new PointF(B.X, B.Y + perp);
            PointF[] cho = { A, B, C };

            if (fill) { g.FillPolygon(brush, cho); }
            else  { g.DrawPolygon(tri1, cho); }

        }
    }
}