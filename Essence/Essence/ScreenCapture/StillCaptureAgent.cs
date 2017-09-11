using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Essence.ScreenCapture.Data;

namespace Essence.ScreenCapture
{
    class StillCaptureAgent : ICaptureAgent
    {
        public string Name { get; } = "Still capture agent";
        public string PerformanceStats { get; } = "Doesn't have performance stats...";
        public UnsafeMemoryBitmap CaptureViewPort(int x, int y, int width, int height)
        {
            Bitmap bmp = new Bitmap("C:\\Temp\\CaptureAgent\\still.jpg");
            UnsafeMemoryBitmap ubmp = new UnsafeMemoryBitmap(bmp,bmp.PixelFormat,ImageLockMode.ReadWrite,true);
            return ubmp;
        }
    }
}
