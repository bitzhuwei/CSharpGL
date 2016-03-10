using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Objects.ModernRendering
{
    public abstract class GLSwitch
    {

        public abstract void On();

        public abstract void Off();
    }

    public class PointSpriteSwitch : GLSwitch
    {
        int m_ParticleSize = 30;
        public override void On()
        {
            GL.Enable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
            GL.Enable(GL.GL_POINT_SPRITE_ARB);
            GL.TexEnv(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);
            GL.Enable(GL.GL_POINT_SMOOTH);
            GL.Hint(GL.GL_POINT_SMOOTH_HINT, GL.GL_NICEST);
            GL.Enable(GL.GL_BLEND);
            GL.BlendFunc(Enumerations.BlendingSourceFactor.SourceAlpha, Enumerations.BlendingDestinationFactor.One);
            //GL.BlendEquation(GL.GL_FUNC_ADD_EXT);
            //GL.BlendFuncSeparate(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA, GL.GL_ONE, GL.GL_ONE);
            GL.Disable(GL.GL_DEPTH_TEST);

            //float[] quadratic = { 1.0f, 0, 0, 1.0f };
            //GL.PointParameter(GL.GL_POINT_DISTANCE_ATTENUATION_ARB, quadratic);
            //GL.PointParameter(GL.GL_POINT_FADE_THRESHOLD_SIZE_ARB, 10.0f);
            //GL.TexEnvf(GL.GL_POINT_SPRITE_ARB, GL.GL_COORD_REPLACE_ARB, GL.GL_TRUE);

            //GL.PointParameter(GL.GL_POINT_SIZE_MIN_ARB, m_ParticleSize);
            ////GL.TexEnvi(GL.GL_POINT_SPRITE, GL.GL_COORD_REPLACE, GL.GL_TRUE);
            //GL.PointParameter(GL.GL_POINT_SPRITE_COORD_ORIGIN, GL.GL_LOWER_LEFT);

        }

        public override void Off()
        {
            GL.Enable(GL.GL_DEPTH_TEST);
            GL.Disable(GL.GL_BLEND);
            GL.Disable(GL.GL_POINT_SMOOTH);
            GL.Disable(GL.GL_POINT_SPRITE_ARB);
            GL.Disable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
        }
    }
}
