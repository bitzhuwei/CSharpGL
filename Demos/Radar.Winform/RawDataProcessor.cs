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
    /// <summary>
    /// 解析数据文件，得到3D纹理
    /// </summary>
    public class RawDataProcessor
    {
        int slices;
        int width;
        int height;
        uint[] textureId = new uint[1];

        /// <summary>
        /// 读取数据文件，获取3D纹理
        /// </summary>
        /// <param name="dataFiles"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="slices"></param>
        /// <returns></returns>
        public bool ReadFile(string[] dataFiles, int width, int height, int slices)
        {
            this.slices = slices;
            this.width = width;
            this.height = height;

            float[] chBuffer = new float[width * height * slices];
            float min = 0, max = 0;

            // 找到数据中的最大、最小值，为配色做准备
            {
                int index = 0;
                bool minSet = false, maxSet = false;
                char[] separator = new char[] { ' ', '\t', '\r', '\n' };
                for (int i = 0; i < dataFiles.Length; i++)
                {
                    string filename = dataFiles[i];
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

            // 用非托管数组存储顶点颜色，为创建3D纹理做准备
            UnmanagedArray<byte> pRGBABuffer = new UnmanagedArray<byte>(width * height * slices * 4);
            unsafe
            {
                byte* rgbBuffer = (byte*)pRGBABuffer.FirstElement();
                for (int nIndx = 0; nIndx < width * height * slices; ++nIndx)
                {
                    float value = chBuffer[nIndx];
                    ColorBar bar = ColorBar.GetDefault();// 默认配色方案
                    vec3 color = bar.GetColor(min, max, value);// 有数值得到对应的颜色
                    rgbBuffer[nIndx * 4] = (byte)(color.x * 255);
                    rgbBuffer[nIndx * 4 + 1] = (byte)(color.y * 255);
                    rgbBuffer[nIndx * 4 + 2] = (byte)(color.z * 255);
                    // 适当降低不透明度（此处用 / 10）
                    rgbBuffer[nIndx * 4 + 3] = (byte)((value - min) / (max - min) * 255.0f / 10);
                }
            }

            // 创建3D贴图，为渲染做准备
            if (0 != textureId[0])
            {
                GL.DeleteTextures(1, textureId);
            }
            GL.GenTextures(1, textureId);
            GL.BindTexture(GL.GL_TEXTURE_3D, textureId[0]);
            GL.TexEnvi(GL.GL_TEXTURE_ENV, GL.GL_TEXTURE_ENV_MODE, (int)GL.GL_REPLACE);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_BORDER);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_BORDER);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_WRAP_R, (int)GL.GL_CLAMP_TO_BORDER);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_3D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
            GL.TexImage3D(GL.GL_TEXTURE_3D, 0, (int)GL.GL_RGBA, width, height, slices, 0,
                GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, pRGBABuffer.Header);
            GL.BindTexture(GL.GL_TEXTURE_3D, 0);

            // 非托管数组要手动释放
            pRGBABuffer.Dispose();

            return true;
        }
        public uint GetTexture3D()
        {
            return textureId[0];
        }
        public int GetWidth()
        {
            return width;
        }
        public int GetHeight()
        {
            return height;
        }
        public int GetDepth()
        {
            return slices;
        }

        ~RawDataProcessor()
        {
            // 删除3D纹理
            if (0 != textureId[0])
            {
                GL.DeleteTextures(1, textureId);
            }
        }
    }
}
