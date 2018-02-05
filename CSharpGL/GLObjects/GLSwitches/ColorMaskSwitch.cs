namespace CSharpGL
{
    /// <summary>
    /// Toggle of color mask.
    /// </summary>
    public class ColorMaskSwitch : GLSwitch
    {
        /// <summary>
        ///  mask when this switch is turned on.
        /// </summary>
        public ColorMask Mask { get; set; }

        /// <summary>
        ///  mask when this switch is turned off.
        /// </summary>
        public ColorMask OriginalMask { get; private set; }

        // Activator needs a non-parameter constructor.
        /// <summary>
        /// Toggle of color mask.
        /// </summary>
        public ColorMaskSwitch() : this(ColorMask.GetDefault()) { }
        /// <summary>
        /// Toggle of color mask.
        /// </summary>
        /// <param name="redWritable">red mask when this switch is turned on</param>
        /// <param name="greenWritable">green mask when this switch is turned on</param>
        /// <param name="blueWritable">blue mask when this switch is turned on</param>
        /// <param name="alphaWritable">alpha mask when this switch is turned on</param>

        public ColorMaskSwitch(bool redWritable, bool greenWritable, bool blueWritable, bool alphaWritable)
        {
            this.Mask = new ColorMask(redWritable, greenWritable, blueWritable, alphaWritable);
            this.OriginalMask = ColorMask.GetCurrent();
        }

        /// <summary>
        /// Toggle of color mask.
        /// </summary>
        /// <param name="redWritable">red mask when this switch is turned on.</param>
        /// <param name="greenWritable">green mask when this switch is turned on.</param>
        /// <param name="blueWritable">blue mask when this switch is turned on.</param>
        /// <param name="alphaWritable">alpha mask when this switch is turned on.</param>
        /// <param name="originalAlphaWritable">red mask when this switch is turned off.</param>
        /// <param name="originalBlueWritable">green mask when this switch is turned off.</param>
        /// <param name="originalGreenWritable">blue mask when this switch is turned off.</param>
        /// <param name="originalRedWritable">alpha mask when this switch is turned off.</param>
        public ColorMaskSwitch(bool redWritable, bool greenWritable, bool blueWritable, bool alphaWritable, bool originalRedWritable, bool originalGreenWritable, bool originalBlueWritable, bool originalAlphaWritable)
        {
            this.Mask = new ColorMask(redWritable, greenWritable, blueWritable, alphaWritable);
            this.OriginalMask = new ColorMask(
                originalRedWritable, originalGreenWritable, originalBlueWritable, originalAlphaWritable);
        }

        /// <summary>
        /// Toggle of color mask.
        /// </summary>
        /// <param name="mask">mask when this switch is turned on.</param>
        public ColorMaskSwitch(ColorMask mask)
        {
            this.Mask = mask;
            this.OriginalMask = ColorMask.GetCurrent();
        }

        /// <summary>
        /// Toggle of color mask.
        /// </summary>
        /// <param name="mask">mask when this switch is turned on.</param>
        /// <param name="originalMask">mask when this switch is turned off.</param>
        public ColorMaskSwitch(ColorMask mask, ColorMask originalMask)
        {
            this.Mask = mask;
            this.OriginalMask = originalMask;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("glColorMask({0});", this.Mask);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOn()
        {
            ColorMask mask = this.Mask;
            GL.Instance.ColorMask(mask.redWritable, mask.greenWritable, mask.blueWritable, mask.alphaWritable);
        }

        /// <summary>
        ///
        /// </summary>
        protected override void StateOff()
        {
            ColorMask mask = this.OriginalMask;
            GL.Instance.ColorMask(mask.redWritable, mask.greenWritable, mask.blueWritable, mask.alphaWritable);
        }
    }

    /// <summary>
    ///
    /// </summary>
    public struct ColorMask
    {
        /// <summary>
        ///
        /// </summary>
        public bool redWritable;

        /// <summary>
        ///
        /// </summary>;
        public bool greenWritable;

        /// <summary>
        ///
        /// </summary>
        public bool blueWritable;

        /// <summary>
        ///
        /// </summary>
        public bool alphaWritable;

        /// <summary>
        ///
        /// </summary>
        /// <param name="redWritable"></param>
        /// <param name="greenWritable"></param>
        /// <param name="blueWritable"></param>
        /// <param name="alphaWritable"></param>
        public ColorMask(bool redWritable, bool greenWritable, bool blueWritable, bool alphaWritable)
        {
            this.redWritable = redWritable;
            this.greenWritable = greenWritable;
            this.blueWritable = blueWritable;
            this.alphaWritable = alphaWritable;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("r:{0}, g:{1}, b:{2}, a:{3}",
                redWritable, greenWritable, blueWritable, alphaWritable);
        }

        /// <summary>
        /// Get current color mask.
        /// </summary>
        /// <returns></returns>
        public static ColorMask GetCurrent()
        {
            var result = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.ColorWritemask, result);
            var current = new ColorMask(result[0] != 0, result[1] != 0, result[2] != 0, result[3] != 0);

            return current;
        }

        /// <summary>
        /// Gets default color mask in OpenGL.
        /// </summary>
        public static ColorMask GetDefault()
        {
            var mask = new ColorMask(true, true, true, true);
            return mask;
        }
    }
}