using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Essence.ScreenCapture;
using Essence.ScreenCapture.Data;

namespace Essence.Bots
{
    class TestBot : BotBase
    {
        public override string BotName => "Test Bot";


        public override void Run()
        {
            base.Run();
            logger.Info("Capturing screen");
            ICaptureAgent captureAgent = new SimpleCaptureAgent();
            Rectangle rect = ApplicationWindow.ToRectangle();
            UnsafeMemoryBitmap bmp = captureAgent.CaptureViewPort(rect.X, rect.Y, rect.Width, rect.Height);
            Console.ReadLine();
        }
    }
}
