using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class PointSpriteSwitch : GLSwitch
    {
        /// <summary>
        /// 
        /// </summary>
        public PointSpriteSwitch()
        {
            this.SwitchList = new GLSwitchList();
            this.SwitchList.Add(new PointSmoothSwitch());
            this.SwitchList.Add(new DepthTestSwitch());
            this.SwitchList.Add(new BlendSwitch(
                BlendingSourceFactor.SourceAlpha,
                BlendingDestinationFactor.OneMinusSourceAlpha));
        }

        //int m_ParticleSize = 30;
        /// <summary>
        /// 
        /// </summary>
        protected override void SwitchOn()
        {
            int count = this.SwitchList.Count;
            for (int i = 0; i < count; i++) { this.SwitchList[i].On(); }

            OpenGL.Enable(OpenGL.GL_VERTEX_PROGRAM_POINT_SIZE);
            OpenGL.Enable(OpenGL.GL_POINT_SPRITE_ARB);
            OpenGL.TexEnv(OpenGL.GL_POINT_SPRITE_ARB, OpenGL.GL_COORD_REPLACE_ARB, OpenGL.GL_TRUE);
            OpenGL.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);
            //OpenGL.GetDelegateFor<OpenGL.glBlendEquation>()(OpenGL.GL_FUNC_ADD_EXT);
            //OpenGL.GetDelegateFor<OpenGL.glBlendFuncSeparate>()(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA, OpenGL.GL_ONE, OpenGL.GL_ONE);

            //float[] quadratic = { 1.0f, 0, 0, 1.0f };
            //OpenGL.PointParameter(OpenGL.GL_POINT_DISTANCE_ATTENUATION_ARB, quadratic);
            //OpenGL.PointParameter(OpenGL.GL_POINT_FADE_THRESHOLD_SIZE_ARB, 10.0f);
            //OpenGL.TexEnvf(OpenGL.GL_POINT_SPRITE_ARB, OpenGL.GL_COORD_REPLACE_ARB, OpenGL.GL_TRUE);

            //OpenGL.PointParameter(OpenGL.GL_POINT_SIZE_MIN_ARB, m_ParticleSize);
            ////OpenGL.TexEnvi(OpenGL.GL_POINT_SPRITE, OpenGL.GL_COORD_REPLACE, OpenGL.GL_TRUE);
            //OpenGL.PointParameter(OpenGL.GL_POINT_SPRITE_COORD_ORIGIN, OpenGL.GL_LOWER_LEFT);
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void SwitchOff()
        {
            OpenGL.Disable(OpenGL.GL_POINT_SPRITE_ARB);
            OpenGL.Disable(OpenGL.GL_VERTEX_PROGRAM_POINT_SIZE);

            int count = this.SwitchList.Count;
            for (int i = count - 1; i >= 0; i--) { this.SwitchList[i].Off(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public GLSwitchList SwitchList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}", this.GetType().Name);
        }
    }
}
