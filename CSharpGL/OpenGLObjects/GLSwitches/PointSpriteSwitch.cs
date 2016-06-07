using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class PointSpriteSwitch : GLSwitch
    {
        public PointSpriteSwitch()
        {
            this.SwitchList = new List<GLSwitch>();
            this.SwitchList.Add(new PointSmoothSwitch());
            this.SwitchList.Add(new DepthTestSwitch());
            this.SwitchList.Add(new BlendSwitch(
                BlendingSourceFactor.SourceAlpha,
                BlendingDestinationFactor.OneMinusSourceAlpha));
        }

        int m_ParticleSize = 30;
        protected override void SwitchOn()
        {
            int count = this.SwitchList.Count;
            for (int i = 0; i < count; i++) { this.SwitchList[i].On(); }

            OpenGL.Enable(OpenGL.GL_VERTEX_PROGRAM_POINT_SIZE);
            OpenGL.Enable(OpenGL.GL_POINT_SPRITE_ARB);
            OpenGL.TexEnv(OpenGL.GL_POINT_SPRITE_ARB, OpenGL.GL_COORD_REPLACE_ARB, OpenGL.GL_TRUE);
            OpenGL.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);
            //GL.GetDelegateFor<GL.glBlendEquation>()(GL.GL_FUNC_ADD_EXT);
            //GL.GetDelegateFor<GL.glBlendFuncSeparate>()(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, GL.GL_ONE, GL.GL_ONE);

            //float[] quadratic = { 1.0f, 0, 0, 1.0f };
            //GL.PointParameter(GL.GL_POINT_DISTANCE_ATTENUATION_ARB, quadratic);
            //GL.PointParameter(GL.GL_POINT_FADE_THRESHOLD_SIZE_ARB, 10.0f);
            //GL.TexEnvf(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);

            //GL.PointParameter(GL.GL_POINT_SIZE_MIN_ARB, m_ParticleSize);
            ////GL.TexEnvi(GL.GL_POINT_SPRITE, GL.GL_COORD_REPLACE, GL.GL_TRUE);
            //GL.PointParameter(GL.GL_POINT_SPRITE_COORD_ORIGIN, GL.GL_LOWER_LEFT);
        }

        protected override void SwitchOff()
        {
            OpenGL.Disable(OpenGL.GL_POINT_SPRITE_ARB);
            OpenGL.Disable(OpenGL.GL_VERTEX_PROGRAM_POINT_SIZE);

            int count = this.SwitchList.Count;
            for (int i = count - 1; i >= 0; i--) { this.SwitchList[i].Off(); }
        }

        public List<GLSwitch> SwitchList { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", this.GetType().Name);
        }
    }
}
