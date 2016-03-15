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
        public float sectionCenter = 0.0f;
        public float halfThickness = 2.0f;

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
            GL.LoadIdentity();
            GL.Scale(6, 6, 6);
            var w = (float)m_pRawDataProc.GetWidth() / (float)m_pRawDataProc.GetWidth();
            var h = (float)m_pRawDataProc.GetWidth() / (float)(float)m_pRawDataProc.GetHeight();
            var d = (float)m_pRawDataProc.GetWidth() / (float)m_pRawDataProc.GetDepth();
            GL.Enable(GL.GL_TEXTURE_3D);
            GL.BindTexture(GL.GL_TEXTURE_3D, m_pRawDataProc.GetTexture3D());
            if (renderZ)
            {
                if (!reverseRender4Z)
                {
                    for (float fIndx = sectionCenter - halfThickness / 2; fIndx <= sectionCenter + halfThickness / 2; fIndx += 0.01f)
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
                else
                {
                    for (float fIndx = sectionCenter + halfThickness / 2; fIndx >= sectionCenter - halfThickness / 2; fIndx -= 0.01f)
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
            }
            else
            {
                if (!reverseRender4Y)
                {
                    for (float fIndx = sectionCenter - halfThickness / 2; fIndx <= sectionCenter + halfThickness / 2; fIndx += 1.0f / 921.0f)
                    {
                        GL.Begin(GL.GL_QUADS);

                        GL.TexCoord3f(0.0f, ((float)fIndx + 1.0f) / 2.0f, 0.0f);
                        GL.Vertex3f(-dOrthoSize / w, fIndx / h, -dOrthoSize / d);

                        GL.TexCoord3f(1.0f, ((float)fIndx + 1.0f) / 2.0f, 0.0f);
                        GL.Vertex3f(dOrthoSize / w, fIndx / h, -dOrthoSize / d);

                        GL.TexCoord3f(1.0f, ((float)fIndx + 1.0f) / 2.0f, 1.0f);
                        GL.Vertex3f(dOrthoSize / w, fIndx / h, dOrthoSize / d);

                        GL.TexCoord3f(0.0f, ((float)fIndx + 1.0f) / 2.0f, 1.0f);
                        GL.Vertex3f(-dOrthoSize / w, fIndx / h, dOrthoSize / d);

                        GL.End();
                    }
                }
                else
                {
                    for (float fIndx = sectionCenter + halfThickness / 2; fIndx >= sectionCenter - halfThickness / 2; fIndx -= 1.0f / 921.0f)
                    {
                        GL.Begin(GL.GL_QUADS);

                        GL.TexCoord3f(0.0f, ((float)fIndx + 1.0f) / 2.0f, 0.0f);
                        GL.Vertex3f(-dOrthoSize / w, fIndx / h, -dOrthoSize / d);

                        GL.TexCoord3f(1.0f, ((float)fIndx + 1.0f) / 2.0f, 0.0f);
                        GL.Vertex3f(dOrthoSize / w, fIndx / h, -dOrthoSize / d);

                        GL.TexCoord3f(1.0f, ((float)fIndx + 1.0f) / 2.0f, 1.0f);
                        GL.Vertex3f(dOrthoSize / w, fIndx / h, dOrthoSize / d);

                        GL.TexCoord3f(0.0f, ((float)fIndx + 1.0f) / 2.0f, 1.0f);
                        GL.Vertex3f(-dOrthoSize / w, fIndx / h, dOrthoSize / d);

                        GL.End();
                    }
                }
            }
            GL.BindTexture(GL.GL_TEXTURE_3D, 0);
            GL.Disable(GL.GL_TEXTURE_3D);
            GL.Disable(GL.GL_ALPHA_TEST);
            GL.AlphaFunc(GL.GL_GREATER, alphaThreshold);

            GL.Disable(GL.GL_BLEND);

        }

        bool blend = true;

        float dOrthoSize = 1.0f;
        private RawDataProcessor m_pRawDataProc;

        private uint sourceFactor = GL.GL_ONE_MINUS_SRC_COLOR;

        public uint SourceFactor
        {
            get { return sourceFactor; }
            set { sourceFactor = value; }
        }

        private uint destFactor = GL.GL_ONE_MINUS_SRC_COLOR;
        public bool reverseRender4Z = false;
        public bool reverseRender4Y = false;
        public bool renderZ = true;

        public uint DestFactor
        {
            get { return destFactor; }
            set { destFactor = value; }
        }

    }
}
