using System;
using System.Diagnostics;
using System.Drawing;
using Essence.ScreenCapture.Data;
using NLog;

namespace Essence.Processors
{
    internal class BitmapProcessor
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static unsafe void ProcessImageForColor(Color color, ref UnsafeMemoryBitmap bmp, ref bool foundColor)
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            int depth = Image.GetPixelFormatSize(bmp.Data.PixelFormat);
            //logger.Info($"W:{bmp.Data.Width}, H:{bmp.Data.Height}, depth: {depth}");

            //Gets the first pixel data pointer(Ptr)
            byte* scan0 = (byte*)bmp.Data.Scan0.ToPointer();
            for (int i = 0; i < bmp.Data.Height; i++)
            {
                for (int j = 0; j < bmp.Data.Width; j++)
                {
                    
                    Pixel pixel = new Pixel();
                    Pixel.Read(bmp.Data, i, j, depth, scan0, ref pixel);

                    if (pixel.IsEmpty) continue;
                    if (pixel.IsColor(color))
                    {
                        foundColor = true;
                        return;
                    }
                    else
                    {
                        pixel.Blank();
                    }
                }
            }
            //logger.Trace($"Bitmap Processing took: {s.ElapsedMilliseconds}ms");
        }
    }
}
