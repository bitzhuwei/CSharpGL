using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class ClearColorSwitch : GLSwitch
    {

        vec4 clearColor = new vec4();

        static ClearColorSwitch() { }

        /// <summary>
        /// 
        /// </summary>
        public Color ClearColor
        {
            get
            {
                return Color.FromArgb(
                    (int)(clearColor.w * 255),
                    (int)(clearColor.x * 255),
                    (int)(clearColor.y * 255),
                    (int)(clearColor.z * 255));
            }
            set
            {
                this.clearColor.x = value.R / 255.0f;
                this.clearColor.y = value.G / 255.0f;
                this.clearColor.z = value.B / 255.0f;
                this.clearColor.w = value.A / 255.0f;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ClearColorSwitch() : this(Color.Black) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clearColor"></param>
        public ClearColorSwitch(Color clearColor)
        {
            this.ClearColor = clearColor;
        }

        float[] original = new float[4];

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return string.Format("glClearColor({0}, {1}, {2}, {3});",
                clearColor.x, clearColor.y, clearColor.z, clearColor.w);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void SwitchOn()
        {
            OpenGL.GetFloat(GetTarget.ColorClearValue, original);

            OpenGL.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void SwitchOff()
        {
            OpenGL.ClearColor(original[0], original[1], original[2], original[3]);
        }
    }
}
