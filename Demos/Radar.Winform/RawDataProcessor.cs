using CSharpGL;
using GLM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Winform
{
    public class RawDataProcessor
    {
        int m_uImageCount;
        int m_uImageWidth;
        int m_uImageHeight;
        uint[] m_nTexId = new uint[1];

        // Call this only after the open gl is initialized.
        public bool ReadFile(string[] lpDataFile_i, int nWidth_i, int nHeight_i, int nSlices_i)
        {
            // File has only image data. The dimension of the data should be known.
            m_uImageCount = nSlices_i;
            m_uImageWidth = nWidth_i;
            m_uImageHeight = nHeight_i;

            // Holds the luminance buffer
            //byte[] chBuffer = new byte[m_uImageWidth * m_uImageHeight * m_uImageCount];
            //UnmanagedArray<byte> chBuffer = new UnmanagedArray<byte>(m_uImageWidth * m_uImageHeight * m_uImageCount);
            float[] chBuffer = new float[m_uImageWidth * m_uImageHeight * m_uImageCount];
            float min = 0, max = 0;

            {
                int index = 0;
                bool minSet = false, maxSet = false;
                char[] separator = new char[] { ' ', '\t', '\r', '\n' };
                for (int i = 0; i < lpDataFile_i.Length; i++)
                {
                    string filename = lpDataFile_i[i];
                    using (var sr = new StreamReader(filename))
                    {
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            var parts = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var part in parts)
                            {
                                float value;
                                if (float.TryParse(part, out value))
                                {
                                    if (!minSet) { min = value; minSet = true; }
                                    if (!maxSet) { max = value; maxSet = true; }

                                    if (value < min) { min = value; }
                                    if (max < value) { max = value; }

                                    chBuffer[index++] = value;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                        }
                    }
                }
            }

            // Convert the data to RGBA data.
            // Here we are simply putting the same value to R, G, B and A channels.
            // Usually for raw data, the alpha value will be constructed by a threshold value given by the user 

            // Holds the RGBA buffer
            UnmanagedArray<byte> pRGBABuffer = new UnmanagedArray<byte>(m_uImageWidth * m_uImageHeight * m_uImageCount * 4);
            unsafe
            {
                byte* rgbBuffer = (byte*)pRGBABuffer.FirstElement();
                for (int nIndx = 0; nIndx < m_uImageWidth * m_uImageHeight * m_uImageCount; ++nIndx)
                {
                    float value = chBuffer[nIndx];
                    //if (value < 20) { value = 0; }
                    ColorBar bar = ColorBar.GetDefault();
                    vec3 color = bar.GetColor(min, max, value);
                    rgbBuffer[nIndx * 4] = (byte)(color.x * 255);
                    rgbBuffer[nIndx * 4 + 1] = (byte)(color.y * 255);
                    rgbBuffer[nIndx * 4 + 2] = (byte)(color.z * 255);
                    rgbBuffer[nIndx * 4 + 3] = (byte)((value - min) / (max - min) * 255.0f / 10);
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

        ~RawDataProcessor()
        {
            // If not initialized, then this will be zero. So no checking is needed.
            if (0 != m_nTexId[0])
            {
                GL.DeleteTextures(1, m_nTexId);
            }
        }
    }
}
