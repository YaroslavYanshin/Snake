using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snake
{
    class Timer
    {
        System.Timers.Timer timer;
        int mseconds;
        public Timer()
        {
            mseconds = 1;
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(timerFunc);
            timer.Interval = 1;            
        }

        public void Start()
        {
            timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Enabled = false;
        }

        public int GetSec()
        {
            return mseconds;
        }

        public void SyncTimer()
        {
            mseconds++;
        }

        void timerFunc(object source, ElapsedEventArgs e)
        {
            mseconds++;
        }

        public void Show(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("Timer: {0:F2}", mseconds/60.0);
        }

    }
}
