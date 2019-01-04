using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_v4
{
    public class Accident : ILoader
    {
        public int startPointY { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Crash { get; set; }

        public Accident(int x, int y, int startY)
        {
            X = x;
            Y = y;
            startPointY = startY;
        }

        public void Move(int x, int y)
        {
            X += Math.Sign(x - X);
            Y += Math.Sign(y - Y);
        }

    }
}
