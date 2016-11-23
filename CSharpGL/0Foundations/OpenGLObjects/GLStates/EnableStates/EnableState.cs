namespace CSharpGL
{
    /// <summary>
    /// GL.Enable(cap); or GL.Disable(cap);
    /// </summary>
    public abstract class EnableState : GLState
    {
        /// <summary>
        ///
        /// </summary>
        protected bool enableCapacityWhenStateOn;

        /// <summary>
        /// GL.Enable(capacity);
        /// </summary>
        public uint Capacity { get; protected set; }

        /// <summary>
        /// GL.Enable(capacity); or GL.Disable(capacity);
        /// </summary>
        public bool EnableCapacity { get; set; }

        private bool originalEnableCapacity;

        /// <summary>
        /// GL.Enable(capacity);
        /// </summary>
        /// <param name="capacity"></param>
        public EnableState(uint capacity) : this(capacity, true) { }

        /// <summary>
        /// GL.Enable(capacity); or GL.Disable(capacity);
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public EnableState(uint capacity, bool enableCapacity)
        {
            this.Init(capacity, enableCapacity);
        }

        private void Init(uint capacity, bool enableCapacity)
        {
            this.Capacity = capacity; this.EnableCapacity = enableCapacity;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            if (this.EnableCapacity)
            { return string.Format("OpenGL.Enable({0});", Capacity); }
            else
            { return string.Format("OpenGL.Disable({0});", Capacity); }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            this.enableCapacityWhenStateOn = this.EnableCapacity;
            this.originalEnableCapacity = OpenGL.IsEnabled(this.Capacity) != 0;
            if (this.enableCapacityWhenStateOn)
            {
                if (!this.originalEnableCapacity)
                { OpenGL.Enable(Capacity); }
            }
            else
            {
                if (this.originalEnableCapacity)
                { OpenGL.Disable(Capacity); }
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            if (this.enableCapacityWhenStateOn)
            {
                if (!this.originalEnableCapacity)
                { OpenGL.Disable(Capacity); }
            }
            else
            {
                if (this.originalEnableCapacity)
                { OpenGL.Enable(Capacity); }
            }
        }
    }
}