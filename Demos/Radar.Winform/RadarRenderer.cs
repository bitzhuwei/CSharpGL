using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Winform
{
    /// <summary>
    /// 切割方向
    /// </summary>
    public enum SliceAxis
    {
        X, Y, Z,
    }

    /// <summary>
    /// 渲染radar模型
    /// </summary>
    public class RadarRenderer
    {
        /// <summary>
        /// 低于指定不透明度的位置不显示
        /// </summary>
        public float alphaThreshold = 0.00f;
        
        /// <summary>
        /// 指定要渲染的中间层
        /// </summary>
        public float sectionCenter = 0.0f;

        /// <summary>
        /// 指定要渲染的层数
        /// </summary>
        public float halfThickness = 2.0f;

        /// <summary>
        /// 指定切割方式
        /// </summary>
        public SliceAxis slice = SliceAxis.Z;

        public bool Initialize(RawDataProcessor dataProcessor)
        {
            this.dataProcessor = dataProcessor;

            return true;
        }
        public void Render()
        {
            GL.Enable(GL.GL_ALPHA_TEST);
            GL.AlphaFunc(GL.GL_GREATER, alphaThreshold);

            // 混合模式：半透明效果
            if (blend) { GL.Enable(GL.GL_BLEND); }
            else { GL.Disable(GL.GL_BLEND); }
            GL.BlendFunc(this.SourceFactor, this.DestFactor);

            // 放大一点
            GL.LoadIdentity();
            GL.Scale(6, 6, 6);

            // x y z方向的比例
            var w = (float)dataProcessor.GetWidth() / (float)dataProcessor.GetWidth();
            var h = (float)dataProcessor.GetWidth() / (float)(float)dataProcessor.GetHeight();
            var d = (float)dataProcessor.GetWidth() / (float)dataProcessor.GetDepth();

            // 启用指定的3D纹理
            GL.Enable(GL.GL_TEXTURE_3D);
            GL.BindTexture(GL.GL_TEXTURE_3D, dataProcessor.GetTexture3D());

            // 按指定切割方式渲染
            switch (this.slice)
            {
                case SliceAxis.X:
                    SliceXRendering(w, h, d);
                    break;
                case SliceAxis.Y:
                    SliceYRendering(w, h, d);
                    break;
                case SliceAxis.Z:
                    SliceZRendering(w, h, d);
                    break;
                default:
                    throw new NotImplementedException();
            }

            // 收工扫尾
            GL.BindTexture(GL.GL_TEXTURE_3D, 0);
            GL.Disable(GL.GL_TEXTURE_3D);
            GL.Disable(GL.GL_ALPHA_TEST);
            GL.Disable(GL.GL_BLEND);
        }

        private void SliceXRendering(float w, float h, float d)
        {
            if (!reverseRender4X)
            {
                for (float fIndx = sectionCenter - halfThickness / 2; fIndx <= sectionCenter + halfThickness / 2; fIndx += 1.0f / 921.0f)
                {
                    GL.Begin(GL.GL_QUADS);

                    GL.TexCoord3f(((float)fIndx + 1.0f) / 2.0f, 0.0f, 0.0f);
                    GL.Vertex3f(fIndx / h, -dOrthoSize / w, -dOrthoSize / d);

                    GL.TexCoord3f(((float)fIndx + 1.0f) / 2.0f, 1.0f, 0.0f);
                    GL.Vertex3f(fIndx / h, dOrthoSize / w, -dOrthoSize / d);

                    GL.TexCoord3f(((float)fIndx + 1.0f) / 2.0f, 1.0f, 1.0f);
                    GL.Vertex3f(fIndx / h, dOrthoSize / w, dOrthoSize / d);

                    GL.TexCoord3f(((float)fIndx + 1.0f) / 2.0f, 0.0f, 1.0f);
                    GL.Vertex3f(fIndx / h, -dOrthoSize / w, dOrthoSize / d);

                    GL.End();
                }
            }
            else
            {
                for (float fIndx = sectionCenter + halfThickness / 2; fIndx >= sectionCenter - halfThickness / 2; fIndx -= 1.0f / 921.0f)
                {
                    GL.Begin(GL.GL_QUADS);

                    GL.TexCoord3f(((float)fIndx + 1.0f) / 2.0f, 0.0f, 0.0f);
                    GL.Vertex3f(fIndx / h, -dOrthoSize / w, -dOrthoSize / d);

                    GL.TexCoord3f(((float)fIndx + 1.0f) / 2.0f, 1.0f, 0.0f);
                    GL.Vertex3f(fIndx / h, dOrthoSize / w, -dOrthoSize / d);

                    GL.TexCoord3f(((float)fIndx + 1.0f) / 2.0f, 1.0f, 1.0f);
                    GL.Vertex3f(fIndx / h, dOrthoSize / w, dOrthoSize / d);

                    GL.TexCoord3f(((float)fIndx + 1.0f) / 2.0f, 0.0f, 1.0f);
                    GL.Vertex3f(fIndx / h, -dOrthoSize / w, dOrthoSize / d);

                    GL.End();
                }
            }
        }
        private void SliceYRendering(float w, float h, float d)
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

        private void SliceZRendering(float w, float h, float d)
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

        bool blend = true;

        float dOrthoSize = 1.0f;
        private RawDataProcessor dataProcessor;

        private uint sourceFactor = GL.GL_ONE_MINUS_SRC_COLOR;

        public uint SourceFactor
        {
            get { return sourceFactor; }
            set { sourceFactor = value; }
        }

        private uint destFactor = GL.GL_ONE_MINUS_SRC_COLOR;
        public bool reverseRender4X = false;
        public bool reverseRender4Y = false;
        public bool reverseRender4Z = false;

        public uint DestFactor
        {
            get { return destFactor; }
            set { destFactor = value; }
        }

    }
}
