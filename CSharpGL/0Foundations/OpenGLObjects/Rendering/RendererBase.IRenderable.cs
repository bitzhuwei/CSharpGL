namespace CSharpGL
{
    public abstract partial class RendererBase
    {
        //private bool initializing = false;

        ///// <summary>
        ///// in initializing process.
        ///// </summary>
        //public bool Initializing
        //{
        //    get { return initializing; }
        //}

        private bool isInitialized = false;

        /// <summary>
        /// Already initialized.
        /// </summary>
        public bool IsInitialized
        {
            get { return isInitialized; }
        }

        /// <summary>
        /// Initialize all stuff related to OpenGL.
        /// </summary>
        public void Initialize()
        {
            if (!isInitialized)
            {
                lock (synObj)
                {
                    if (!isInitialized)
                    {
                        //initializing = true;
                        DoInitialize();
                        //initializing = false;
                        isInitialized = true;
                    }
                }
            }
        }

        /// <summary>
        /// This method should only be invoked once.
        /// </summary>
        protected abstract void DoInitialize();

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        public void Render(RenderEventArgs arg)
        {
            if (this.Enabled)
            {
                if (!isInitialized) { Initialize(); }

                DoRender(arg);
            }
        }

        /// <summary>
        /// Render something.
        /// </summary>
        /// <param name="arg"></param>
        protected abstract void DoRender(RenderEventArgs arg);
    }
}