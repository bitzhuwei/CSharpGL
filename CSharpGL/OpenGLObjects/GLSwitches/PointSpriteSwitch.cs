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
            this.SwitchList.Add(new EnableSwitch(GL.GL_POINT_SMOOTH));
            this.SwitchList.Add(new BlendSwitch(
                BlendingSourceFactor.SourceAlpha,
                BlendingDestinationFactor.OneMinusSourceAlpha));
            this.SwitchList.Add(new EnableSwitch(GL.GL_DEPTH_TEST));
        }

        int m_ParticleSize = 30;
        protected override void SwitchOn()
        {
            int count = this.SwitchList.Count;
            for (int i = 0; i < count; i++) { this.SwitchList[i].On(); }

            GL.Enable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
            GL.Enable(GL.GL_POINT_SPRITE_ARB);
            GL.TexEnv(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);
            GL.Hint(GL.GL_POINT_SMOOTH_HINT, GL.GL_NICEST);
            //GL.Enable(GL.GL_BLEND);
            //GL.BlendFunc(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.One);
            //GL.GetDelegateFor<GL.glBlendEquation>()(GL.GL_FUNC_ADD_EXT);
            //GL.GetDelegateFor<GL.glBlendFuncSeparate>()(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, GL.GL_ONE, GL.GL_ONE);
            GL.Disable(GL.GL_DEPTH_TEST);

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
            GL.Enable(GL.GL_DEPTH_TEST);
            //GL.Disable(GL.GL_BLEND);
            GL.Disable(GL.GL_POINT_SPRITE_ARB);
            GL.Disable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);

            int count = this.SwitchList.Count;
            for (int i = count - 1; i >= 0; i--) { this.SwitchList[i].Off(); }
        }

        public List<GLSwitch> SwitchList { get; set; }
    }
}
