using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Essence.Helper;
using Essence.ScreenCapture.Data;
using NLog;

namespace Essence.ScreenCapture
{
    class SimpleCaptureAgent : ICaptureAgent
    {
        public string Name => "Simple Capture Agent";
        public string PerformanceStats { get; }

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public UnsafeMemoryBitmap CaptureViewPort(int x, int y, int width, int height)
        {

            logger.Info($"Setting up dimensions...");
            logger.Info($"{x},{y},{width},{height}");

            Bitmap bmp = new Bitmap(width, height);
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(x,y,0,0,new Size(width,height));
            }
            UnsafeMemoryBitmap ubmp = new UnsafeMemoryBitmap(bmp, bmp.PixelFormat);
            return ubmp;
        }
    }
}
