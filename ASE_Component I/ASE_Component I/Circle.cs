using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Component_I
{
    /// <summary>
    /// making circle
    /// </summary>
    public class Circle: Shape
    {
        /// <summary>
        /// initialized variables for circle
        /// </summary>
       public int s, n, j;
        /// <summary>
        /// passing parameters inside saved_values
        /// </summary>
        /// <param name="k"></param>
        /// <param name="h"></param>
        /// <param name="u"></param>
        public void saved_values(int k, int h, int u) {
            n = k;
            j = h;
            s = u;
        }
        /// <summary>
        ///passing parameters for draw_shape for circle
        /// </summary>
        /// <param name="g"></param>
        public void Draw_shape(Graphics g, Color colour, bool fill)
        {

            Pen mew2 = new Pen(colour, 3);
            SolidBrush mew3 = new SolidBrush(colour);
            if (fill) { g.FillEllipse(mew3, n, j, s, s); }
            else { g.DrawEllipse(mew2, n, j, s, s); }

        }
        /// <summary>
        /// overiding draw_shape method for circle
        /// </summary>
        /// <param name="g"></param>
        public override void Draw_shape(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
