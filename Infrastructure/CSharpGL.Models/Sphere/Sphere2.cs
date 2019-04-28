using System;
using System.Collections.Generic;
namespace CSharpGL {
    /// <summary>
    /// Sphere from https://github.com/JoeyDeVries/LearnOpenGL/blob/master/src/6.pbr/1.2.lighting_textured/lighting_textured.cpp
    /// <para>Uses <see cref="DrawElementsCmd"/></para>
    /// </summary>
    public class Sphere2 : IBufferSource, IObjFormat {
        private SphereModel2 model;

        /// <summary>
        /// Sphere from https://github.com/JoeyDeVries/LearnOpenGL/blob/master/src/6.pbr/1.2.lighting_textured/lighting_textured.cpp
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="X_SEGMENTS"></param>
        /// <param name="Y_SEGMENTS"></param>
        public Sphere2(float radius = 1.0f, int X_SEGMENTS = 64, int Y_SEGMENTS = 64) {
            this.model = new SphereModel2(radius, X_SEGMENTS, Y_SEGMENTS);
            this.Size = new vec3(radius * 2, radius * 2, radius * 2);
        }

        /// <summary>
        ///
        /// </summary>
        public const string strPosition = "position";

        /// <summary>
        ///
        /// </summary>
        public const string strNormal = "normal";

        /// <summary>
        ///
        /// </summary>
        public const string strTexCoord = "texCoord";

        private VertexBuffer positionBuffer;
        private VertexBuffer texCoordBuffer;
        private VertexBuffer normalBuffer;
        private IDrawCommand drawCmd = null;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (bufferName == strPosition) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = this.model.positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }
                yield return this.positionBuffer;
            }
            else if (bufferName == strTexCoord) {
                if (this.texCoordBuffer == null) {
                    this.texCoordBuffer = model.texCoords.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }
                yield return this.texCoordBuffer;
            }
            else if (bufferName == strNormal) {
                if (this.normalBuffer == null) {
                    this.normalBuffer = this.model.normals.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }
                yield return this.normalBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                int length = model.indexes.Length;
                if (model.positions.Length < byte.MaxValue) {
                    IndexBuffer buffer = GetBufferInBytes(length);
                    this.drawCmd = new DrawElementsCmd(buffer, DrawMode.TriangleStrip, byte.MaxValue);
                }
                else if (model.positions.Length < ushort.MaxValue) {
                    IndexBuffer buffer = GetBufferInUShort(length);
                    this.drawCmd = new DrawElementsCmd(buffer, DrawMode.TriangleStrip, ushort.MaxValue);
                }
                else {
                    IndexBuffer buffer = GetBufferInUInt(length);
                    this.drawCmd = new DrawElementsCmd(buffer, DrawMode.TriangleStrip, uint.MaxValue);
                }
            }

            yield return drawCmd;
        }

        private IndexBuffer GetBufferInUInt(int length) {
            IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UInt, length, BufferUsage.StaticDraw);
            unsafe {
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                var array = (uint*)pointer;
                for (int i = 0; i < model.indexes.Length; i++) {
                    array[i] = model.indexes[i];
                }
                buffer.UnmapBuffer();
            }
            return buffer;
        }

        private IndexBuffer GetBufferInUShort(int length) {
            IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UShort, length, BufferUsage.StaticDraw);
            unsafe {
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                var array = (ushort*)pointer;
                for (int i = 0; i < model.indexes.Length; i++) {
                    if (model.indexes[i] == uint.MaxValue) { array[i] = ushort.MaxValue; }
                    else { array[i] = (ushort)model.indexes[i]; }
                }
                buffer.UnmapBuffer();
            }
            return buffer;
        }

        private IndexBuffer GetBufferInBytes(int length) {
            IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UByte, length, BufferUsage.StaticDraw);
            unsafe {
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                var array = (byte*)pointer;
                for (int i = 0; i < model.indexes.Length; i++) {
                    if (model.indexes[i] == uint.MaxValue) { array[i] = byte.MaxValue; }
                    else { array[i] = (byte)model.indexes[i]; }
                }
                buffer.UnmapBuffer();
            }
            return buffer;
        }

        /// <summary>
        ///
        /// </summary>
        public vec3 Size { get; private set; }

        #region IObjFormat 成员

        public vec3[] GetPositions() {
            return this.model.positions;
        }

        public vec2[] GetTexCoords() {
            return this.model.texCoords;
        }

        public uint[] GetIndexes() {
            bool reverse = false;

            var list = new List<uint>();
            var indexes = this.model.indexes;
            for (int i = 0; i < indexes.Length - 2; i++) {
                var index0 = indexes[i + 0];
                var index1 = indexes[i + 1];
                var index2 = indexes[i + 2];
                if (index0 == uint.MaxValue || index1 == uint.MaxValue || index2 == uint.MaxValue) { continue; }

                if (reverse) {
                    list.Add(index0); list.Add(index2); list.Add(index1);
                }
                else {
                    list.Add(index0); list.Add(index1); list.Add(index2);
                }

                reverse = !reverse;
            }

            return list.ToArray();
        }

        #endregion
    }
}