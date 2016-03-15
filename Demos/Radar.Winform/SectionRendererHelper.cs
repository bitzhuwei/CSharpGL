using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Winform
{
    public class SectionRendererHelper
    {
        public float alphaThreshold = 0.00f;
        public float negativeZ = -1.0f;
        public float positiveZ = 1.0f;

        public bool Initialize(RawDataProcessor pRawDataProc_i)
        {
            m_pRawDataProc = pRawDataProc_i;

            return true;
        }
        public void Render()
        {
            GL.Enable(GL.GL_ALPHA_TEST);
            GL.AlphaFunc(GL.GL_GREATER, alphaThreshold);

            if (blend) { GL.Enable(GL.GL_BLEND); }
            else { GL.Disable(GL.GL_BLEND); }
            GL.BlendFunc(this.SourceFactor, this.DestFactor);

            //GL.MatrixMode(GL.GL_TEXTURE);
            //GL.Scaled((float)m_pRawDataProc.GetWidth() / (float)m_pRawDataProc.GetWidth(),
            //    (float)m_pRawDataProc.GetWidth() / (float)(float)m_pRawDataProc.GetHeight(),
            //    (float)m_pRawDataProc.GetWidth() / (float)m_pRawDataProc.GetDepth());
            //GL.MatrixMode(GL.GL_MODELVIEW);
            var w = (float)m_pRawDataProc.GetWidth() / (float)m_pRawDataProc.GetWidth();
            var h = (float)m_pRawDataProc.GetWidth() / (float)(float)m_pRawDataProc.GetHeight();
            var d = (float)m_pRawDataProc.GetWidth() / (float)m_pRawDataProc.GetDepth();
            GL.Enable(GL.GL_TEXTURE_3D);
            GL.BindTexture(GL.GL_TEXTURE_3D, m_pRawDataProc.GetTexture3D());
            if (renderZ)
            {
                for (float fIndx = negativeZ; fIndx <= positiveZ; fIndx += 0.01f)
                {
                    GL.Begin(GL.GL_QUADS);

                    GL.TexCoord3f(0.0f, 0.0f, ((float)fIndx + 1.0f) / 2.0f);
                    GL.Vertex3f(-dOrthoSize / w, -dOrthoSize / h, fIndx / d);

                    GL.TexCoord3f(1.0f, 0.0f, ((float)fIndx + 1.0f) / 2.0f);
                    GL.Vertex3f(dOrthoSize / w, -dOrthoSize / h, fIndx / d);

                    GL.TexCoord3f(1.0f, 1.0f, ((float)fIndx + 1.0f) / 2.0f);
                    GL.Vertex3f(dOrthoSize / w, dOrthoSize / h, fIndx / d);

                    GL.TexCoord3f(0.0f, 1.0f, ((float)fIndx + 1.0f) / 2.0f);
                    GL.Vertex3f(-dOrthoSize / w, dOrthoSize / h, fIndx / d);

                    GL.End();
                }
            }
            //
            if (renderY)
            {
                float negtiveY = -1;
                float positiveY = 1;
                for (float fIndx = negtiveY; fIndx <= positiveY; fIndx += 0.01f)
                {
                    GL.Begin(GL.GL_QUADS);

                    GL.TexCoord3f(0.0f, ((float)fIndx + 1.0f) / 2.0f, 0.0f);
                    GL.Vertex3f(-dOrthoSize, fIndx, -dOrthoSize);

                    GL.TexCoord3f(1.0f, ((float)fIndx + 1.0f) / 2.0f, 0.0f);
                    GL.Vertex3f(dOrthoSize, fIndx, -dOrthoSize);

                    GL.TexCoord3f(1.0f, ((float)fIndx + 1.0f) / 2.0f, 1.0f);
                    GL.Vertex3f(dOrthoSize, fIndx, dOrthoSize);

                    GL.TexCoord3f(0.0f, ((float)fIndx + 1.0f) / 2.0f, 1.0f);
                    GL.Vertex3f(-dOrthoSize, fIndx, dOrthoSize);

                    GL.End();
                }
            }
            GL.BindTexture(GL.GL_TEXTURE_3D, 0);
            GL.Disable(GL.GL_TEXTURE_3D);
            GL.Disable(GL.GL_ALPHA_TEST);
            GL.AlphaFunc(GL.GL_GREATER, alphaThreshold);

            GL.Disable(GL.GL_BLEND);

        }

        bool blend = true;
        bool renderZ = true;
        bool renderY = false;

        float dOrthoSize = 1.0f;
        private RawDataProcessor m_pRawDataProc;

        private uint sourceFactor = GL.GL_ONE_MINUS_SRC_COLOR;

        public uint SourceFactor
        {
            get { return sourceFactor; }
            set { sourceFactor = value; }
        }

        private uint destFactor = GL.GL_ONE_MINUS_SRC_COLOR;

        public uint DestFactor
        {
            get { return destFactor; }
            set { destFactor = value; }
        }
    }
}
