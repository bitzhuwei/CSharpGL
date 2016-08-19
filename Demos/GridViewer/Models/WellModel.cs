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
    public partial class WellModel : IBufferable, IModelSize, IModelTransform
    {

        public const string strPosition = "position";
        //public const string strColor = "color";
        //public const string strprojectionMatrix = "projectionMatrix";
        //public const string strviewMatrix = "viewMatrix";
        //public const string strmodelMatrix = "modelMatrix";
        private PropertyBufferPtr positionBufferPtr = null;
        //private PropertyBufferPtr colorBufferPtr = null;
        private IndexBufferPtr indexBufferPtr = null;

        private List<vec3> pipeline;
        private float radius;
        private int faceCount;

        /// <summary>
        /// WellPipeline
        /// 蛇形管道（井）
        /// </summary>
        /// <param name="pipeline"></param>
        /// <param name="radius"></param>
        /// <param name="color"></param>
        /// <param name="faceCount"></param>
        public WellModel(List<vec3> pipeline, float radius, int faceCount = 18)
        {
            if (pipeline == null || pipeline.Count < 2 || radius <= 0.0f)
            { throw new ArgumentException(); }

            this.pipeline = pipeline; this.radius = radius;
            this.faceCount = faceCount;
            this.ModelMatrix = mat4.identity();
        }

        public unsafe PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr != null) { return positionBufferPtr; }

                using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                {
                    List<vec3> pipeline = this.pipeline.ToList();
                    BoundingBox box = pipeline.Move2Center();
                    this.ModelMatrix = glm.translate(mat4.identity(), 0.5f * box.MaxPosition + 0.5f * box.MinPosition);
                    this.lengths = box.MaxPosition - box.MinPosition;
                    int vertexCount = (faceCount * 2 + 2) * (pipeline.Count - 1);
                    buffer.Create(vertexCount);
                    var array = (vec3*)buffer.Header.ToPointer();
                    int index = 0;
                    for (int i = 1; i < pipeline.Count; i++)
                    {
                        vec3 p1 = pipeline[i - 1];
                        vec3 p2 = pipeline[i];
                        vec3 vector = p2 - p1;// 从p1到p2的向量
                        // 找到互相垂直的三个向量：vector, orthogontalVector1和orthogontalVector2
                        vec3 orthogontalVector1 = new vec3(vector.y - vector.z, vector.z - vector.x, vector.x - vector.y);
                        vec3 orthogontalVector2 = vector.cross(orthogontalVector1);
                        orthogontalVector1 = orthogontalVector1.normalize() * (float)Math.Sqrt(this.radius);
                        orthogontalVector2 = orthogontalVector2.normalize() * (float)Math.Sqrt(this.radius);
                        for (int faceIndex = 0; faceIndex < faceCount + 1; faceIndex++)
                        {
                            double angle = (Math.PI * 2 * faceIndex) / faceCount;
                            vec3 delta = orthogontalVector1 * (float)Math.Cos(angle) + orthogontalVector2 * (float)Math.Sin(angle);
                            vec3 tmp1 = p1 + delta, tmp2 = p2 + delta;
                            array[index++] = tmp1;
                            array[index++] = tmp2;
                        }
                    }

                    positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                }

                return positionBufferPtr;
            }
            //else if (bufferName == strColor)
            //{
            //    if (colorBufferPtr != null) { return colorBufferPtr; }

            //    using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
            //    {
            //        int vertexCount = (faceCount * 2 + 2) * (this.pipeline.Count - 1);
            //        buffer.Create(vertexCount);
            //        var array = (vec3*)buffer.Header.ToPointer();
            //        vec3 vColor = this.color.ToVec3();
            //        for (int i = 0; i < buffer.Length; i++)
            //        {
            //            array[i] = vColor;
            //        }

            //        colorBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
            //    }

            //    return colorBufferPtr;
            //}
            else
            {
                throw new ArgumentException();
            }
        }

        public unsafe IndexBufferPtr GetIndex()
        {
            if (this.indexBufferPtr != null) { return this.indexBufferPtr; }

            int vertexCount = (faceCount * 2 + 2) * (this.pipeline.Count - 1);
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.QuadStrip, BufferUsage.StaticDraw))
            {
                buffer.Create(vertexCount + (this.pipeline.Count - 1));
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

                this.indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
            }

            return this.indexBufferPtr;
        }

        internal vec3 lengths;
        public float XLength { get { return lengths.x; } }

        public float YLength { get { return lengths.y; } }

        public float ZLength { get { return lengths.z; } }

        public mat4 ModelMatrix { get; set; }
    }
}
