using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private Stopwatch _actionTimer = new Stopwatch();

        public string PerformanceStats => _actionTimer.ElapsedMilliseconds.ToString();

        public UnsafeMemoryBitmap CaptureViewPort(int x, int y, int width, int height)
        {
            _actionTimer = new Stopwatch();
            _actionTimer.Start();
            Bitmap bmp = new Bitmap(width, height);
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(x,y,0,0,new Size(width,height));

            }
            UnsafeMemoryBitmap ubmp = new UnsafeMemoryBitmap(bmp);
            _actionTimer.Stop();

            return ubmp;
        }
    }
}
