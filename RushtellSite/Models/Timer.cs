using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace RushtellSite.Models
{
    public class SiteStartedTimer
    {
        public static int a = 0;

        public SiteStartedTimer()
        {
            Task task = new Task(() =>
            {
                while (true)
                {
                    a++;
                    Thread.Sleep(1000);
                }
            });
            task.Start();
        }
    }
}
