using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL.EZM
{
    public class EZMVertexbuffer
    {
        private static readonly char[] separators = new char[] { ' ', ',' };
        // <vertexbuffer count="13114" ctype="fff fff ff ff ff ffff hhhh" semantic="position normal texcoord1 texcoord2 texcoord3 blendweights blendindices">
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static unsafe EZMVertexbuffer Parse(System.Xml.Linq.XElement xElement)
        {
            EZMVertexbuffer result = null;
            if (xElement.Name == "vertexbuffer")
            {
                result = new EZMVertexbuffer();
                int groupCount = int.Parse(xElement.Attribute("count").Value);
                result.Ctypes = xElement.Attribute("ctype").Value.Split(' ');
                result.Semantics = xElement.Attribute("semantic").Value.Split(' ');
                if (result.Ctypes.Length != result.Semantics.Length) { throw new Exception("EZMVertexbuffer.Ctypes.Length != EZMVertexbuffer.Semantics.Length"); }
                int groupSize = result.Ctypes.Length; // how many elements in a group.
                string[] parts = xElement.Value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                var charCounts = new int[groupSize];
                for (int i = 1; i < groupSize; i++) { charCounts[i] = charCounts[i - 1] + result.Ctypes[i - 1].Length; }
                var buffers = new Passbuffer[groupSize];
                var pointers = new void*[groupSize];
                for (int i = 0; i < groupSize; i++)
                {
                    int index = charCounts[i];
                    buffers[i] = new Passbuffer(result.Ctypes[i], groupCount);
                    pointers[i] = buffers[i].Mapbuffer().ToPointer();
                    for (int t = 0; t < groupCount; t++)
                    {
                        switch (buffers[i].type)
                        {
                        case PassType.vec4:
                            {
                                float x = float.Parse(parts[t * groupSize + index + 0]);
                                float y = float.Parse(parts[t * groupSize + index + 1]);
                                float z = float.Parse(parts[t * groupSize + index + 2]);
                                float w = float.Parse(parts[t * groupSize + index + 3]);
                                var array = (vec4*)pointers[i];
                                array[t] = new vec4(x, y, z, w);
                            } break;
                        case PassType.vec3:
                            {
                                float x = float.Parse(parts[t * groupSize + index + 0]);
                                float y = float.Parse(parts[t * groupSize + index + 1]);
                                float z = float.Parse(parts[t * groupSize + index + 2]);
                                var array = (vec3*)pointers[i];
                                array[t] = new vec3(x, y, z);
                            } break;
                        case PassType.vec2:
                            {
                                float x = float.Parse(parts[t * groupSize + index + 0]);
                                float y = float.Parse(parts[t * groupSize + index + 1]);
                                var array = (vec2*)pointers[i];
                                array[t] = new vec2(x, y);
                            } break;
                        case PassType.uvec4:
                            {
                                uint x = uint.Parse(parts[t * groupSize + index + 0]);
                                uint y = uint.Parse(parts[t * groupSize + index + 1]);
                                uint z = uint.Parse(parts[t * groupSize + index + 2]);
                                uint w = uint.Parse(parts[t * groupSize + index + 3]);
                                var array = (uvec4*)pointers[i];
                                array[t] = new uvec4(x, y, z, w);
                            } break;
                        default:
                            break;
                        }
                    }
                    buffers[i].Unmapbuffer();
                }

                result.Buffers = buffers;
            }

            return result;
        }

        public string[] Ctypes { get; private set; }

        public string[] Semantics { get; private set; }

        public Passbuffer[] Buffers { get; private set; }
    }

    public class Passbuffer
    {
        public readonly PassType type;

        public readonly byte[] array;

        internal Passbuffer(string strType, int length)
            : this(ToPassType(strType), length)
        { }

        public Passbuffer(PassType type, int length)
        {
            int s = ByteSize(type);
            this.type = type;
            this.array = new byte[s * length];
        }

        GCHandle pin;

        public IntPtr Mapbuffer()
        {
            this.pin = GCHandle.Alloc(this.array);
            return pin.AddrOfPinnedObject();
        }

        public void Unmapbuffer()
        {
            this.pin.Free();
        }

        static PassType ToPassType(string type)
        {
            PassType passType;
            switch (type)
            {
            case "ffff": passType = PassType.vec4; break;
            case "fff": passType = PassType.vec3; break;
            case "ff": passType = PassType.vec2; break;
            case "hhhh": passType = PassType.uvec4; break;
            default: throw new NotImplementedException();
            }

            return passType;
        }

        static int ByteSize(PassType type)
        {
            int result = 0;
            switch (type)
            {
            case PassType.vec4: result = sizeof(float) * 4; break;
            case PassType.vec3: result = sizeof(float) * 3; break;
            case PassType.vec2: result = sizeof(float) * 2; break;
            case PassType.uvec4: result = sizeof(uint) * 4; break;
            default: throw new NotDealWithNewEnumItemException(typeof(PassType));
            }

            return result;
        }
    }

    public enum PassType
    {
        vec4,
        vec3,
        vec2,
        uvec4,
    }
}
