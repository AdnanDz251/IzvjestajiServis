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
                x.Service<Pokretac>(s =>
                {
                    s.ConstructUsing(practise => new Pokretac());
                    s.WhenStarted(practise => practise.Start());
                    s.WhenStopped(practise => practise.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("IzvještajServis");
                x.SetDisplayName("Servis za Izvještaje");
                x.SetDescription("Servis koji periodično šalje izvještaje");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
