using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automad
{
    class DriverCheck
    {
        public void run()
        {
            while (true)
            {
                Thread.Sleep(1 *60 *1000);
                if (Process.GetProcessesByName("chromedriver").Length>20)
                {
                    foreach (var process in Process.GetProcessesByName("chromedriver"))
                    {
                        try
                        {
                            process.Kill();
                        }
                        catch
                        {

                        }
                    }

                    foreach (var process in Process.GetProcessesByName("chrome"))
                    {
                        try
                        {
                            process.Kill();
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
    }
}
