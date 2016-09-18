namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public class PolygonModeSwitch : GLSwitch
    {
        private int[] originalPolygonMode = new int[2];

        /// <summary>
        ///
        /// </summary>
        public PolygonModeSwitch() : this(PolygonMode.Fill) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        public PolygonModeSwitch(PolygonMode mode)
        {
            this.Mode = mode;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Polygon Mode: {0}", Mode);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void SwitchOn()
        {
            OpenGL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);

            OpenGL.PolygonMode(PolygonModeFaces.FrontAndBack, Mode);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void SwitchOff()
        {
            if (originalPolygonMode[0] == originalPolygonMode[1])
            {
                OpenGL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonMode)(originalPolygonMode[0]));
            }
            else
            {
                //TODO: not tested yet
                OpenGL.PolygonMode(PolygonModeFaces.Front, (PolygonMode)originalPolygonMode[0]);
                OpenGL.PolygonMode(PolygonModeFaces.Back, (PolygonMode)originalPolygonMode[1]);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public PolygonMode Mode { get; set; }
    }
}