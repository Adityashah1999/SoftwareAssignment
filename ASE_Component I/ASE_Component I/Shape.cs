using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Component_I
{
    /// <summary>
    /// abstract class called shape
    /// </summary>
   public abstract class Shape
    {
        /// <summary>
        /// drawshap method for abstract class
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw_shape(Graphics g);
    }
}
