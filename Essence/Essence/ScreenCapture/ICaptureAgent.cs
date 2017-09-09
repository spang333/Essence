using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Essence.ScreenCapture.Data;

namespace Essence.ScreenCapture
{
    public interface ICaptureAgent
    {
        string Name { get; }
        string PerformanceStats { get; }
        UnsafeMemoryBitmap CaptureViewPort(int x, int y, int width, int height);
    }
}
