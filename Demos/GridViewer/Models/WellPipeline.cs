using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace GridViewer
{
    /// <summary>
    /// WellPipeline
    /// 蛇形管道（井）
    /// </summary>
    public partial class WellPipeline : IBufferable
    {

        public const string strPosition = "position";
        public const string strColor = "color";
        //public const string strprojectionMatrix = "projectionMatrix";
        //public const string strviewMatrix = "viewMatrix";
        //public const string strmodelMatrix = "modelMatrix";
        private PropertyBufferPtr positionBufferPtr = null;
        private PropertyBufferPtr colorBufferPtr = null;
        private IndexBufferPtr indexBufferPtr = null;

        private List<vec3> pipeline;
        private float radius;
        private Color color;
        private int faceCount;

        /// <summary>
        /// WellPipeline
        /// 蛇形管道（井）
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="radius"></param>
        /// <param name="color"></param>
        /// <param name="faceCount"></param>
        public WellPipeline(List<vec3> pipeline, float radius, Color color, int faceCount = 18)
        {
            if (pipeline == null || pipeline.Count < 2 || radius <= 0.0f)
            { throw new ArgumentException(); }

            this.pipeline = pipeline; this.radius = radius; this.color = color;
            this.faceCount = faceCount;
        }

        public unsafe PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr != null) { return positionBufferPtr; }

                using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                {
                    int vertexCount = (faceCount * 2 + 2) * (this.pipeline.Count - 1);
                    buffer.Alloc(vertexCount);
                    var array = (vec3*)buffer.Header.ToPointer();
                    int index = 0;
                    for (int i = 1; i < this.pipeline.Count; i++)
                    {
                        vec3 p1 = this.pipeline[i - 1];
                        vec3 p2 = this.pipeline[i];
                        vec3 vector = p2 - p1;// 从p1到p2的向量
                        // 找到互相垂直的三个向量：vector, orthogontalVector1和orthogontalVector2
                        vec3 orthogontalVector1 = new vec3(vector.y - vector.z, vector.z - vector.x, vector.x - vector.y);
                        vec3 orthogontalVector2 = vector.cross(orthogontalVector1);
                        orthogontalVector1 = orthogontalVector1.normalize() * (float)Math.Sqrt(this.radius);
                        orthogontalVector2 = orthogontalVector2.normalize() * (float)Math.Sqrt(this.radius);
                        for (int faceIndex = 0; faceIndex < faceCount + 1; faceIndex++)
                        {
                            double angle = (Math.PI * 2 * faceIndex) / faceCount;
                            vec3 point = orthogontalVector1 * (float)Math.Cos(angle) + orthogontalVector2 * (float)Math.Sin(angle);
                            array[index++] = p2 + point;
                            array[index++] = p1 + point;
                        }
                    }

                    positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                }

                return positionBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (colorBufferPtr != null) { return colorBufferPtr; }

                using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                {
                    int vertexCount = (faceCount * 2 + 2) * (this.pipeline.Count - 1);
                    buffer.Alloc(vertexCount);
                    var array = (vec3*)buffer.Header.ToPointer();
                    vec3 vColor = this.color.ToVec3();
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        array[i] = vColor;
                    }

                    colorBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                }

                return colorBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public unsafe IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr != null) { return indexBufferPtr; }

            int vertexCount = (faceCount * 2 + 2) * (this.pipeline.Count - 1);
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.QuadStrip, BufferUsage.StaticDraw))
            {
                buffer.Alloc(vertexCount + (this.pipeline.Count - 1));
                var array = (uint*)buffer.Header.ToPointer();
                uint positionIndex = 0;
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (i % (faceCount * 2 + 2 + 1) == (faceCount * 2 + 2))
                    {
                        array[i] = uint.MaxValue;//分割各个圆柱体
                    }
                    else
                    {
                        array[i] = positionIndex++;
                    }
                }
            }

            return indexBufferPtr;
        }

    }
}
