using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Cell
    {
        public Rectangle Bounds { get; private set; }
        public int Player { get; set; }
        public int AnimationOffsetY { get; set; }

        public int AnimationOffsetX { get; set; }

        public Cell(Rectangle bounds)
        {
            Bounds = bounds;
            Player = 0;
            AnimationOffsetY = 0;
            AnimationOffsetX = 0;
        }
    }
}
