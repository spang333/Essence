using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Essence.Helper;
using NLog;

namespace Essence.Bots
{
    public abstract class BotBase
    {
        public abstract string BotName { get; }
        public bool Active { get; private set; }

        protected Rectangle ApplicationWindow;
        protected static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public virtual void Run()
        {
            //Get the application's position
            Process applicationProcess = Process.GetProcessesByName(Globals.ProcessName).First();
            IntPtr pointer = applicationProcess.MainWindowHandle;
            ApplicationWindow = new Rectangle();
            Helper.Win32.GetWindowRect(pointer, ref ApplicationWindow);
            logger.Info(ApplicationWindow.ToString());
            logger.Info($"Running {BotName}");
            Active = true;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
