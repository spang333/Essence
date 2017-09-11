using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Essence.Actions;
using Essence.Processors;
using Essence.ScreenCapture;
using Essence.ScreenCapture.Data;

namespace Essence.Bots
{
    internal class QueueBot : BotBase
    {
        public override string BotName => "Queue Bot";

        private bool _foundPurple;
        public bool FoundPurple { get => _foundPurple; set => SetPurpleState(value); }

        private Stopwatch TimeInQueue { get; set; }
            
        private readonly Color queuePurple = Color.FromArgb(178, 0, 255);
        public override void Run()
        {
            base.Run();
            ICaptureAgent captureAgent = new SimpleCaptureAgent();

            Rectangle rect = ApplicationWindow.ToRectangle();
            logger.Info($"rect: {rect}");


            //Color queuePurple = Color.FromArgb(193, 75, 249);
            TimeInQueue = new Stopwatch();
            int i = 0;
            while (true)
            {
                UnsafeMemoryBitmap ubmp = captureAgent.CaptureViewPort(rect.X, rect.Y, rect.Width, rect.Height);

                ubmp.Image.Save($"C:\\Temp\\CaptureAgent\\test-{i}.png");
                i++;
                bool imageHasPurple = false;
                BitmapProcessor.ProcessImageForColor(queuePurple, ref ubmp, ref imageHasPurple);
                FoundPurple = imageHasPurple;
                if (FoundPurple)
                {
                    if (!TimeInQueue.IsRunning)
                    {
                        TimeInQueue.Start();
                    }
                    logger.Info($"Found purple! You are in queue for {TimeInQueue.ElapsedMilliseconds}MS");
                }
                ubmp.Dispose();

            }
        }

        private void SetPurpleState(bool value)
        {
            if (_foundPurple == true && value == false)
            {
                logger.Info($"Got in a queue!");
                FoundQueue();
                _foundPurple = false;
            }
            _foundPurple = value;
        }

        private void FoundQueue()
        {
            TimeInQueue.Stop();
            logger.Info($"Total time in queue: {TimeInQueue.ElapsedMilliseconds}ms");
            TimeInQueue.Reset();


            Mouse.Click(Mouse.MouseButton.Right, new Point(1600,60));

            Mouse.Click(Mouse.MouseButton.Left, new Point(1663,95));
        }
    }
}
