using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class Scene
    {

        private const double interval = 1000 / 25;
        System.Timers.Timer timer;// = new System.Timers.Timer(10000);   //实例化Timer类，设置间隔时间为10000毫秒；   

        public void Start()
        {
            if (timer == null)
            {
                timer = new System.Timers.Timer(interval);   //实例化Timer类，设置间隔时间为10000毫秒；   
                timer.Elapsed += new System.Timers.ElapsedEventHandler(Tick); //到达时间的时候执行事件；   
                timer.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
            }

            timer.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
        }

        public void Stop()
        {
            if (timer != null)
            {
                timer.Enabled = false;     //是否执行System.Timers.Timer.Elapsed事件；   
            }
        }

        private void Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (var item in this.objectList)
            {
                item.Update(interval);
            }
        }
    }
}
