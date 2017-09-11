using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Essence.Helper
{
    [StructLayout(LayoutKind.Sequential)]
    struct PointSequential
    {
        public int X;
        public int Y;
        public static implicit operator Point(PointSequential point)
        {
            return new Point(point.X, point.Y);
        }
    }
}
