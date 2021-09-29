using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automad
{
    class CheckConnection
    {
        private Main form;
        public CheckConnection(Main formm)
        {
            form = formm;
        }
        public void Check()
        {
            try
            {
                while (form.testing)
                {
                    if (PingTest())
                    {
                        form.Invoke(form.connected);
                    }
                    else
                    {
                        form.Invoke(form.notconnected);
                    }
                    Thread.Sleep(3000);
                }
            }
            catch { }

        }
        public static bool PingTest()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            try
            {
                System.Net.NetworkInformation.PingReply pingStatus1 =
                    ping.Send("www.google.com", 1000);

                if (pingStatus1.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    return true;
                }
                System.Net.NetworkInformation.PingReply pingStatus2 =
                    ping.Send("www.facebook.com", 1000);
                if (pingStatus2.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    return true;
                }
                System.Net.NetworkInformation.PingReply pingStatus3 =
                ping.Send("www.microsoft.com", 1000);
                if (pingStatus3.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
    }
}
