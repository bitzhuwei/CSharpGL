using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SoftGLImpl {
    class GLVertexArrayObject {
        public uint Id { get; private set; }

        internal bool deleteFlag = false;

        public GLVertexArrayObject(uint id) { this.Id = id; }

        private Dictionary<uint, VertexAttribDesc> loc2VertexAttrib = new Dictionary<uint, VertexAttribDesc>();
        /// <summary>
        /// (location = ..) in vec3 inPosition -> glVertexAttrib(I|L)Pointer(..).
        /// </summary>
        public Dictionary<uint, VertexAttribDesc> LocVertexAttribDict { get { return loc2VertexAttrib; } }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("Vertex Array Object: Id:{0}", this.Id);
        }
    }

    /// <summary>
    /// glVertexAttrib(I|L)Pointer.
    /// </summary>
    class VertexAttribDesc {
        public uint inLocation;
        public GLBuffer vbo;
        public enum Kind { Default, I, L };
        public Kind kind;
        public int dataSize;
        public uint dataType;
        /// <summary>
        /// only valid for glVertexAttribPointer(..).
        /// </summary>
        public bool normalize;
        /// <summary>
        /// pointer.
        /// </summary>
        public uint startPos;
        /// <summary>
        /// interval.
        /// </summary>
        public uint stride;
        public bool enabled;

        public VertexAttribDesc(GLBuffer buffer, Kind kind) {
            this.vbo = buffer;
            this.kind = kind;
        }

        private uint GetByteLength() {
            uint elementBytes = 0;
            switch (this.kind) {
            case Kind.Default: {
                var type = (VertexAttribType)this.dataType;
                Debug.Assert(Enum.IsDefined(typeof(VertexAttribType), type));
                elementBytes = GetByteLength(type); // byte length of specified type.
            }
            break;
            case Kind.I: {
                var type = (VertexAttribIType)this.dataType;
                Debug.Assert(Enum.IsDefined(typeof(VertexAttribIType), type));
                elementBytes = GetByteLength(type); // byte length of specified type.
            }
            break;
            case Kind.L: {
                var type = (VertexAttribLType)this.dataType;
                Debug.Assert(Enum.IsDefined(typeof(VertexAttribLType), type));
                elementBytes = GetByteLength(type); // byte length of specified type.
            }
            break;
            default: throw new NotImplementedException();
            }
            return elementBytes;
        }
        public int GetVertexCount() {
            Debug.Assert(this.vbo != null);
            uint elementBytes = this.GetByteLength();
            int byteLength = this.vbo.Size;
            uint elementCount = (uint)(this.dataSize == GL.GL_BGRA ? 4 : this.dataSize); // how many elements of specified type in one vertex?
            uint vertexLength = elementBytes * elementCount + this.stride; // byte length of a single vertex.
            if ((byteLength % vertexLength) != 0) {
                throw new Exception(
                $"GetVertexCount() error! [{byteLength} % {vertexLength}, t:{this.dataType}, s:{elementCount}]");
            }
            var result = (int)(byteLength / vertexLength); // how many vertex?

            return result;
        }

        public virtual int GetDataIndex(uint indexID) {
            Debug.Assert(this.vbo != null);
            uint elementBytes = this.GetByteLength();
            int byteLength = this.vbo.Size;
            uint elementCount = (uint)(this.dataSize == GL.GL_BGRA ? 4 : this.dataSize); // how many elements of specified type in one vertex? (1, 2, 3 or 4)
            uint vertexLength = elementBytes * elementCount + stride; // byte length of a single vertex.
            var result = (int)(vertexLength * indexID + this.startPos);

            return result;
        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //internal static Type GetManagedType(VertexAttribType type) {
        //    Type result;
        //    switch (type) {
        //    case VertexAttribType.Byte: result = typeof(byte); break;
        //    case VertexAttribType.UnsignedByte: result = typeof(byte); break;
        //    case VertexAttribType.Short: result = typeof(short); break;
        //    case VertexAttribType.UnsignedShort: result = typeof(ushort); break;
        //    case VertexAttribType.Int: result = typeof(int); break;
        //    case VertexAttribType.UnsignedInt: result = typeof(uint); break;
        //    case VertexAttribType.HalfFloat: result = typeof(ushort); break;
        //    case VertexAttribType.Float: result = typeof(float); break;
        //    case VertexAttribType.Double: result = typeof(double); break;
        //    case VertexAttribType.Fixed: result = typeof(int); break;
        //    case VertexAttribType.Int2101010Rev: result = typeof(int); break;
        //    case VertexAttribType.UnsignedInt2101010Rev: result = typeof(uint); break;
        //    case VertexAttribType.UnsignedInt10f11f11fRev: result = typeof(uint); break;
        //    default:
        //    throw new NotDealWithNewEnumItemException(typeof(VertexAttribType));
        //    }

        //    return result;
        //}

        internal static uint GetByteLength(VertexAttribType type) {
            uint result = 0;
            switch (type) {
            case VertexAttribType.Byte: result = sizeof(byte); break;
            case VertexAttribType.UnsignedByte: result = sizeof(byte); break;
            case VertexAttribType.Short: result = sizeof(short); break;
            case VertexAttribType.UnsignedShort: result = sizeof(ushort); break;
            case VertexAttribType.Int: result = sizeof(int); break;
            case VertexAttribType.UnsignedInt: result = sizeof(uint); break;
            case VertexAttribType.HalfFloat: result = sizeof(float) / 2; break;
            case VertexAttribType.Float: result = sizeof(float); break;
            case VertexAttribType.Double: result = sizeof(double); break;
            case VertexAttribType.Fixed: result = sizeof(int); break;
            case VertexAttribType.Int2101010Rev: result = sizeof(int); break;
            case VertexAttribType.UnsignedInt2101010Rev: result = sizeof(uint); break;
            case VertexAttribType.UnsignedInt10f11f11fRev: result = sizeof(uint); break;
            default:
            throw new NotDealWithNewEnumItemException(typeof(VertexAttribType));
            }

            return result;
        }
        internal static uint GetByteLength(VertexAttribIType type) {
            uint result = 0;
            switch (type) {
            case VertexAttribIType.Byte: result = sizeof(byte); break;
            case VertexAttribIType.UnsignedByte: result = sizeof(byte); break;
            case VertexAttribIType.Short: result = sizeof(short); break;
            case VertexAttribIType.UnsignedShort: result = sizeof(ushort); break;
            case VertexAttribIType.Int: result = sizeof(int); break;
            case VertexAttribIType.UnsignedInt: result = sizeof(uint); break;
            default:
            throw new NotDealWithNewEnumItemException(typeof(VertexAttribIType));
            }

            return result;
        }
        internal static uint GetByteLength(VertexAttribLType type) {
            uint result = 0;
            switch (type) {
            case VertexAttribLType.Double: result = sizeof(double); break;
            default:
            throw new NotDealWithNewEnumItemException(typeof(VertexAttribLType));
            }

            return result;
        }
    }
}
