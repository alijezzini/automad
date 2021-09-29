using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automad
{
    
    class ControllerThread
    {
        Main ott;
        public ControllerThread(Main ott)
        {
            this.ott = ott;
        }
        public void run()
        {
            while (true)
            {

                if (ott.MaxParallelThreads > 0 && ott.ObjectQueue.Count>0 && ott.pause==false && ott.connectionstatus==true)
                {
                    object obj= ott.ObjectQueue.Dequeue();
                    String type = obj.GetType().ToString();
                    Console.WriteLine(type);
                    switch (type)
                    {

                        case "Automad.Google":
                            Google gg = (Google)obj;
                            new Thread(gg.run).Start();
                            break;

                        case "Automad.Microsoft":
                            Microsoft mt = (Microsoft)obj;
                            new Thread(mt.run).Start();
                            break;


                        case "Automad.Transfergo":
                            Transfergo ex = (Transfergo)obj;
                            new Thread(ex.run).Start();
                            break;

                        case "Automad.Instagram":
                            Instagram ins = (Instagram)obj;
                            new Thread(ins.run).Start();
                            break;

                        case "Automad.Lark":
                            Lark lk = (Lark)obj;
                            new Thread(lk.run).Start();
                            break;

                        case "Automad.Naver":
                            Naver nv = (Naver)obj;
                            new Thread(nv.run).Start();
                            break;
                    }
                    ott.MaxParallelThreads--;
                }
            }
        }
    }
}
