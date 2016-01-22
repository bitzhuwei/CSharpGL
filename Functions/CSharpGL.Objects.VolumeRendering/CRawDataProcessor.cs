using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VolumeRendering
{
    public class CRawDataProcessor
    {
        int m_uImageCount;
        int m_uImageWidth;
        int m_uImageHeight;
        uint[] m_nTexId = new uint[1];

        // Call this only after the open gl is initialized.
        public bool ReadFile(string lpDataFile_i, int nWidth_i, int nHeight_i, int nSlices_i)
        {
            FileStream file = new FileStream(lpDataFile_i, FileMode.Open, FileAccess.Read);

            // File has only image data. The dimension of the data should be known.
            m_uImageCount = nSlices_i;
            m_uImageWidth = nWidth_i;
            m_uImageHeight = nHeight_i;

            // Holds the luminance buffer
            //byte[] chBuffer = new byte[m_uImageWidth * m_uImageHeight * m_uImageCount];
            //UnmanagedArray<byte> chBuffer = new UnmanagedArray<byte>(m_uImageWidth * m_uImageHeight * m_uImageCount);
            byte[] chBuffer = new byte[m_uImageWidth * m_uImageHeight * m_uImageCount];

            // Holds the RGBA buffer
            UnmanagedArray<byte> pRGBABuffer = new UnmanagedArray<byte>(m_uImageWidth * m_uImageHeight * m_uImageCount * 4);
            file.Read(chBuffer, 0, chBuffer.Length);

            // Convert the data to RGBA data.
            // Here we are simply putting the same value to R, G, B and A channels.
            // Usually for raw data, the alpha value will be constructed by a threshold value given by the user 

            unsafe
            {
                byte* rgbBuffer = (byte*)pRGBABuffer.FirstElement();
                for (int nIndx = 0; nIndx < m_uImageWidth * m_uImageHeight * m_uImageCount; ++nIndx)
                {
                    byte value = chBuffer[nIndx];
                    //if (value < 20)
                    //{ value = 0; }
                    rgbBuffer[nIndx * 4] = value;
                    rgbBuffer[nIndx * 4 + 1] = value;
                    rgbBuffer[nIndx * 4 + 2] = value;
                    rgbBuffer[nIndx * 4 + 3] = value;
                }
            }

            // If this function is getting called again for another data file.
            // Deleting and creating texture is not a good idea, 
            // we can use the glTexSubImage3D for better performance for such scenario.
            // I am not using that now :-)
            if (0 != m_nTexId[0])
            {
                GL.DeleteTextures(1, m_nTexId);
            }
            GL.GenTextures(1, m_nTexId);

            GL.BindTexture(GL.GL_TEXTURE_3D, m_nTexId[0]);
            GL.TexEnvi(GL.GL_TEXTURE_ENV, GL.GL_TEXTURE_ENV_MODE, (int)GL.GL_REPLACE);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_BORDER);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_BORDER);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_R, (int)GL.GL_CLAMP_TO_BORDER);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);

            //uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, IntPtr pixels)

            GL.TexImage3D(GL.GL_TEXTURE_3D, 0, (int)GL.GL_RGBA, m_uImageWidth, m_uImageHeight, m_uImageCount, 0,
                GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, pRGBABuffer.Header);
            GL.BindTexture(GL.GL_TEXTURE_3D, 0);

            return true;
        }
        public uint GetTexture3D()
        {
            return m_nTexId[0];
        }
        public int GetWidth()
        {
            return m_uImageWidth;
        }
        public int GetHeight()
        {
            return m_uImageHeight;
        }
        public int GetDepth()
        {
            return m_uImageCount;
        }

        ~CRawDataProcessor()
        {
            // If not initialized, then this will be zero. So no checking is needed.
            if (0 != m_nTexId[0])
            {
                GL.DeleteTextures(1, m_nTexId);
            }
        }
    }
}
