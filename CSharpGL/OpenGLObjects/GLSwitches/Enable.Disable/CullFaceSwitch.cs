using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// https://www.khronos.org/opengles/sdk/docs/man/xhtml/glCullFace.xml
    /// </summary>
    public class CullFaceSwitch : EnableSwitch
    {

        public CullFaceSwitch()
            : base(OpenGL.GL_CULL_FACE, true)
        {
            this.Init(CullFaceMode.Back);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public CullFaceSwitch(bool enableCapacity)
            : base(OpenGL.GL_CULL_FACE, enableCapacity)
        {
            this.Init(CullFaceMode.Back);
        }

        public CullFaceSwitch(CullFaceMode mode)
            : base(OpenGL.GL_CULL_FACE, true)
        {
            this.Init(mode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="enableCapacity">Enable() or Disable() this capacity?</param>
        public CullFaceSwitch(CullFaceMode mode, bool enableCapacity)
            : base(OpenGL.GL_CULL_FACE, enableCapacity)
        {
            this.Init(mode);
        }

        private void Init(CullFaceMode mode)
        {
            this.Mode = mode;
        }

        public override string ToString()
        {
            if (this.EnableCapacity)
            {
                return string.Format("Enable glCullFace({0});", this.Mode);
            }
            else
            {
                return string.Format("Disable glCullFace({0});", this.Mode);
            }
        }

        protected override void SwitchOn()
        {
            base.SwitchOn();

            if (this.enableCapacityWhenSwitchOn)
            {
                OpenGL.CullFace(this.mode);
            }
        }

        /// <summary>
        /// Specifies whether front- or back-facing polygons are candidates for culling. Symbolic constants GL_FRONT, GL_BACK, and GL_FRONT_AND_BACK are accepted. The initial value is GL_BACK.
        /// </summary>
        private uint mode = OpenGL.GL_BACK;

        /// <summary>
        /// https://www.khronos.org/opengles/sdk/docs/man/xhtml/glCullFace.xml
        /// </summary>
        public CullFaceMode Mode
        {
            get { return (CullFaceMode)mode; }
            set { mode = (uint)value; }
        }
    }

    public enum CullFaceMode : uint
    {
        Front = OpenGL.GL_FRONT,
        Back = OpenGL.GL_BACK,
        FrontAndBack = OpenGL.GL_FRONT_AND_BACK,
    }
}
