using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace IzvještajiServis
{
    public class Practise
    {
        private readonly Timer _timer;

        public Practise()
        {
            _timer = new Timer(3000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] {DateTime.Now.ToString()};
            Console.WriteLine("TestLine");
            File.AppendAllLines(@"C:\Users\adnan.dzindo\Desktop\TimerThingy.txt", lines);
        }

        public void Start() 
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
