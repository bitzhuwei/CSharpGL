using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Objects.VolumeRendering
{
    public class CTranformationMgr
    {
        public CTranformationMgr()
        {
            mdRotation[0] = mdRotation[5] = mdRotation[10] = mdRotation[15] = 1.0f;
            mdRotation[1] = mdRotation[2] = mdRotation[3] = mdRotation[4] = 0.0f;
            mdRotation[6] = mdRotation[7] = mdRotation[8] = mdRotation[9] = 0.0f;
            mdRotation[11] = mdRotation[12] = mdRotation[13] = mdRotation[14] = 0.0f;

            mfRot[0] = mfRot[1] = mfRot[2] = 0.0f;
        }
        public double[] GetMatrix()
        {
            return mdRotation;
        }
        // Call this only after the open gl is initialized.
        public void Rotate(float fx_i, float fy_i, float fz_i)
        {
            mfRot[0] = fx_i;
            mfRot[1] = fy_i;
            mfRot[2] = fz_i;

            GL.MatrixMode(GL.GL_MODELVIEW);
            GL.LoadMatrixd(mdRotation);
            GL.Rotated(mfRot[0], 1.0f, 0, 0);
            GL.Rotated(mfRot[1], 0, 1.0f, 0);
            GL.Rotated(mfRot[2], 0, 0, 1.0f);

            GL.GetDoublev(GL.GL_MODELVIEW_MATRIX, mdRotation);
            GL.LoadIdentity();
        }

        public void ResetRotation()
        {
            mdRotation[0] = mdRotation[5] = mdRotation[10] = mdRotation[15] = 1.0f;
            mdRotation[1] = mdRotation[2] = mdRotation[3] = mdRotation[4] = 0.0f;
            mdRotation[6] = mdRotation[7] = mdRotation[8] = mdRotation[9] = 0.0f;
            mdRotation[11] = mdRotation[12] = mdRotation[13] = mdRotation[14] = 0.0f;
        }


        private float[] mfRot = new float[3];
        private double[] mdRotation = new double[16];
    }
}
