using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Essence.ScreenCapture.Data
{
    public unsafe struct Pixel
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public byte* R, G, B;

        internal static unsafe void Read(BitmapData data, int x, int y, int bitsPerPixel, byte* scan0, ref Pixel pixel)
        {
            if (x >= data.Width || y >= data.Height)
            {
                pixel.Blank();
                return;
            }
            pixel.B = scan0 + x * data.Stride + y * bitsPerPixel / 8;
            pixel.G = scan0 + x * data.Stride + y * bitsPerPixel / 8 + 1;
            pixel.R = scan0 + x * data.Stride + y * bitsPerPixel / 8 + 2;
        }


        public void Blank()
        {
            if (IsEmpty)
                return;

            *R = 255;
            *G = 255;
            *B = 255;
        }


        public bool IsEmpty => (R == null || G == null || B == null);

        public bool IsColor(byte r, byte g, byte b)
        {
            return (*R == r && *G == g && *B == b);
        }


        public bool IsColor(Color color)
        {
            return *R == color.R && *G == color.G && *B == color.B;
        }

        public bool IsInColorRange(byte rMin, byte gMin, byte bMin, byte rMax, byte gMax, byte bMax)
        {
            return (*R >= rMin && *R <= rMax &&
                    *G >= gMin && *G <= gMax &&
                    *B >= bMin && *B <= bMax);
        }

        public bool IsWhite => (*R == 255 && *B == 255 & *G == 255);
    }
}
