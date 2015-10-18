using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Marsman.Toolkit
{
    public static class WpfExtensions
    {
        public static void Schedule(this Dispatcher dispatcher, TimeSpan schedule, Action action)
        {
            DispatcherTimer dt = new DispatcherTimer(
                schedule, 
                DispatcherPriority.Normal, 
                new EventHandler((o, e) =>
                {
                    (o as DispatcherTimer).Stop();
                    action.Invoke();
                }),
                dispatcher);
            dt.Start();
        }
    }
}
