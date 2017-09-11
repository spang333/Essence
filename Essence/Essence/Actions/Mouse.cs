using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Essence.Helper;
namespace Essence.Actions
{
    internal static class Mouse
    {
        internal enum MouseButton
        {
            Left,
            Right
        }

        #region constants
        internal struct MouseEvents
        {
            public const int MOUSEEVENTF_LEFTDOWN = 0x02;
            public const int MOUSEEVENTF_LEFTUP = 0x04;
            public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
            public const int MOUSEEVENTF_RIGHTUP = 0x10;
        }
        #endregion
        public static void Click(MouseButton button, Point clickPosition)
        {
            SetCursor(clickPosition);

            //TODO: Remove this ugly sleeper
            Thread.Sleep(10);
            if (button == MouseButton.Left)
                Win32.mouse_event(MouseEvents.MOUSEEVENTF_LEFTDOWN | MouseEvents.MOUSEEVENTF_LEFTUP, (uint)clickPosition.X, (uint)clickPosition.Y, 0, 0);
            else
                Win32.mouse_event(MouseEvents.MOUSEEVENTF_RIGHTDOWN | MouseEvents.MOUSEEVENTF_RIGHTUP, (uint)clickPosition.X, (uint)clickPosition.Y, 0, 0);
            Thread.Sleep(10);
        }

        public static void SetCursor(Point position)
        {
            Win32.SetCursorPos(position.X, position.Y);
        }

        public static Point CursorPosition()
        {
            Win32.GetCursorPos(out var cursorPos);
            return cursorPos;
        }
    }
}
