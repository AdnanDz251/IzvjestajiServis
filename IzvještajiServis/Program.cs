using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace IzvještajiServis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Practise>(s =>
                {
                    s.ConstructUsing(practise => new Practise());
                    s.WhenStarted(practise => practise.Start());
                    s.WhenStopped(practise => practise.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("PractiseService");
                x.SetDisplayName("Sta the Briga");
                x.SetDescription("Just Practising My Services.");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
