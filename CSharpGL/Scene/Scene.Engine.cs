using System.Linq;

namespace CSharpGL
{
    public partial class Scene
    {
        private const double interval = 1000 / 25;

        private int currentCycle;

        /// <summary>
        /// how many times should this engine run?
        /// <para>0 means endless.</para>
        /// </summary>
        private int maxCycle = 0;

        private bool running = false;

        private System.Timers.Timer timer;

        /// <summary>
        /// whether this scene's objects are being updated now.
        /// </summary>
        public bool Running
        {
            get { return running; }
            set
            {
                if (value)
                { this.Start(); }
                else
                { this.Stop(); }
            }
        }

        // = new System.Timers.Timer(10000);   //实例化Timer类，设置间隔时间为10000毫秒；

        /// <summary>
        /// start running scripts.
        /// </summary>
        /// <param name="maxCycle">
        /// how many times should this engine run?
        /// <para>0 means endless.</para></param>
        public void Start(int maxCycle = 0)
        {
            if (this.running) { return; }

            if (timer == null)
            {
                timer = new System.Timers.Timer(interval);   //实例化Timer类，设置间隔时间为10000毫秒；
                timer.Elapsed += new System.Timers.ElapsedEventHandler(Tick); //到达时间的时候执行事件；
                timer.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；
            }

            this.currentCycle = 0;
            this.maxCycle = maxCycle;
            Time.Set();
            timer.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；
            this.running = true;
        }

        /// <summary>
        /// stop running scripts.
        /// </summary>
        public void Stop()
        {
            if (!this.running) { return; }

            if (timer != null)
            {
                timer.Enabled = false;     //是否执行System.Timers.Timer.Elapsed事件；
            }

            this.running = false;
        }

        /// <summary>
        /// update once.
        /// </summary>
        public void UpdateOnce()
        {
            this.UpdateObject(this.RootObject);
        }

        private void Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.maxCycle <= 0// endless
                || this.currentCycle < this.maxCycle)// not reached last cycle yet
            {
                this.currentCycle++;
                Time.Update();
                SceneObject obj = this.rootObject;
                UpdateObject(obj);
            }
            else
            {
                this.Stop();
            }
        }

        private void UpdateObject(SceneObject sceneObject)
        {
            if (sceneObject.Enabled)
            {
                sceneObject.Update();
                SceneObject[] array = sceneObject.Children.ToArray();
                foreach (var child in array)
                {
                    UpdateObject(child);
                }
            }
        }
    }
}