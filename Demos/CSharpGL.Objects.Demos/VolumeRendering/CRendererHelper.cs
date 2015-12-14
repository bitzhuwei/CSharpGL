using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos.VolumeRendering
{
    public class CRendererHelper
    {
        public float alphaThreshold = 0.05f;

        public bool Initialize(CRawDataProcessor pRawDataProc_i, CTranformationMgr pTransformationMgr_i)
        {
            m_pRawDataProc = pRawDataProc_i;
            m_pTransformMgr = pTransformationMgr_i;

            return true;
        }
        public void Resize(int nWidth_i, int nHeight_i)
        {
            //Find the aspect ratio of the window.
            double AspectRatio = (double)(nWidth_i) / (double)(nHeight_i);
            //glViewport( 0, 0, cx , cy );
            GL.Viewport(0, 0, nWidth_i, nHeight_i);
            GL.MatrixMode(GL.GL_PROJECTION);
            GL.LoadIdentity();

            //Set the orthographic projection.
            if (nWidth_i <= nHeight_i)
            {
                GL.Ortho(-dOrthoSize, dOrthoSize, -(dOrthoSize / AspectRatio),
                    dOrthoSize / AspectRatio, 2.0f * -dOrthoSize, 2.0f * dOrthoSize);
            }
            else
            {
                GL.Ortho(-dOrthoSize * AspectRatio, dOrthoSize * AspectRatio,
                    -dOrthoSize, dOrthoSize, 2.0f * -dOrthoSize, 2.0f * dOrthoSize);
            }

            GL.MatrixMode(GL.GL_MODELVIEW);
            GL.LoadIdentity();
        }
        public void Render()
        {
            float fFrameCount = (float)m_pRawDataProc.GetDepth();
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            GL.Enable(GL.GL_ALPHA_TEST);
            GL.AlphaFunc(GL.GL_GREATER, alphaThreshold);

            GL.Enable(GL.GL_BLEND);
            GL.BlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);

            GL.MatrixMode(GL.GL_TEXTURE);
            GL.LoadIdentity();

            // Translate and make 0.5f as the center 
            // (texture co ordinate is from 0 to 1. so center of rotation has to be 0.5f)
            GL.Translatef(0.5f, 0.5f, 0.5f);

            // A scaling applied to normalize the axis 
            // (Usually the number of slices will be less so if this is not - 
            // normalized then the z axis will look bulky)
            // Flipping of the y axis is done by giving a negative value in y axis.
            // This can be achieved either by changing the y co ordinates in -
            // texture mapping or by negative scaling of y axis
            GL.Scaled((float)m_pRawDataProc.GetWidth() / (float)m_pRawDataProc.GetWidth(),
                -1.0f * (float)m_pRawDataProc.GetWidth() / (float)(float)m_pRawDataProc.GetHeight(),
                (float)m_pRawDataProc.GetWidth() / (float)m_pRawDataProc.GetDepth());
            GL.Scalef(wheel, wheel, wheel);

            // Apply the user provided transformations
            GL.MultMatrixd(m_pTransformMgr.GetMatrix());

            GL.Translatef(-0.5f, -0.5f, -0.5f);

            GL.Enable(GL.GL_TEXTURE_3D);
            GL.BindTexture(GL.GL_TEXTURE_3D, m_pRawDataProc.GetTexture3D());
            for (float fIndx = -1.0f; fIndx <= 1.0f; fIndx += 0.01f)
            {
                GL.Begin(GL.GL_QUADS);

                GL.TexCoord3f(0.0f, 0.0f, ((float)fIndx + 1.0f) / 2.0f);
                GL.Vertex3f(-dOrthoSize, -dOrthoSize, fIndx);

                GL.TexCoord3f(1.0f, 0.0f, ((float)fIndx + 1.0f) / 2.0f);
                GL.Vertex3f(dOrthoSize, -dOrthoSize, fIndx);

                GL.TexCoord3f(1.0f, 1.0f, ((float)fIndx + 1.0f) / 2.0f);
                GL.Vertex3f(dOrthoSize, dOrthoSize, fIndx);

                GL.TexCoord3f(0.0f, 1.0f, ((float)fIndx + 1.0f) / 2.0f);
                GL.Vertex3f(-dOrthoSize, dOrthoSize, fIndx);

                GL.End();
            }
        }


        float dOrthoSize = 1.0f;
        private CRawDataProcessor m_pRawDataProc;
        private CTranformationMgr m_pTransformMgr;

        private float wheel = 1.0f;
        public void MouseWheel(int p)
        {
            wheel -= (float)p / 5000.0f;
            if(wheel<=0)
            {
                wheel = 0.001f;
            }
        }
    }
}
