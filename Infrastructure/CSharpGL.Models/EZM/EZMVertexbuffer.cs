using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    public class EZMVertexbuffer
    {
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
                string[] parts = xElement.Value.Split(Separator.separators, StringSplitOptions.RemoveEmptyEntries);
                var lineLength = result.Ctypes[0].Length;
                var charCounts = new int[groupSize];
                for (int i = 1; i < groupSize; i++) { charCounts[i] = charCounts[i - 1] + result.Ctypes[i - 1].Length; lineLength += result.Ctypes[i].Length; }
                var buffers = new Passbuffer[groupSize];
                var pointers = new void*[groupSize];
                for (int i = 0; i < groupSize; i++)
                {
                    int index = charCounts[i];
                    buffers[i] = new Passbuffer(result.Ctypes[i], groupCount);
                    pointers[i] = buffers[i].Mapbuffer().ToPointer();
                    switch (buffers[i].type)
                    {
                    case PassType.vec4:
                        for (int t = 0; t < groupCount; t++)
                        {
                            float x = float.Parse(parts[t * lineLength + index + 0]);
                            float y = float.Parse(parts[t * lineLength + index + 1]);
                            float z = float.Parse(parts[t * lineLength + index + 2]);
                            float w = float.Parse(parts[t * lineLength + index + 3]);
                            var array = (vec4*)pointers[i];
                            array[t] = new vec4(x, y, z, w);
                            if (!(0 <= x && x <= 1)) { Console.WriteLine("Error"); }
                            if (!(0 <= y && y <= 1)) { Console.WriteLine("Error"); }
                            if (!(0 <= z && z <= 1)) { Console.WriteLine("Error"); }
                            if (!(0 <= w && w <= 1)) { Console.WriteLine("Error"); }
                        } break;
                    case PassType.vec3:
                        for (int t = 0; t < groupCount; t++)
                        {
                            float x = float.Parse(parts[t * lineLength + index + 0]);
                            float y = float.Parse(parts[t * lineLength + index + 1]);
                            float z = float.Parse(parts[t * lineLength + index + 2]);
                            var array = (vec3*)pointers[i];
                            array[t] = new vec3(x, y, z);
                        } break;
                    case PassType.vec2:
                        var vec2xList = new List<float>();
                        var vec2yList = new List<float>();
                        for (int t = 0; t < groupCount; t++)
                        {
                            float x = float.Parse(parts[t * lineLength + index + 0]);
                            if (x < 0) { x = 0; } if (1 < x) { x = 1; }
                            float y = float.Parse(parts[t * lineLength + index + 1]);
                            if (y < 0) { y = 0; } if (1 < y) { y = 1; }
                            var array = (vec2*)pointers[i];
                            array[t] = new vec2(x, y);
                            if (!(0 <= x && x <= 1)) { vec2xList.Add(x); }
                            if (!(0 <= y && y <= 1)) { vec2yList.Add(y); }
                        }
                        if (vec2xList.Count > 0 || vec2yList.Count > 0) { Console.WriteLine("Error"); }
                        break;
                    case PassType.ivec4:
                        var list = new List<int>();
                        for (int t = 0; t < groupCount; t++)
                        {
                            int x = int.Parse(parts[t * lineLength + index + 0]);
                            int y = int.Parse(parts[t * lineLength + index + 1]);
                            int z = int.Parse(parts[t * lineLength + index + 2]);
                            int w = int.Parse(parts[t * lineLength + index + 3]);
                            var array = (ivec4*)pointers[i];
                            array[t] = new ivec4(x, y, z, w);
                            if (!list.Contains(x)) { list.Add(x); }
                            if (!list.Contains(y)) { list.Add(y); }
                            if (!list.Contains(z)) { list.Add(z); }
                            if (!list.Contains(w)) { list.Add(w); }
                        } break;
                    default:
                        break;
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

        public Passbuffer GetBuffer(string semantics)
        {
            Passbuffer buffer = null;
            for (int i = 0; i < this.Buffers.Length; i++)
            {
                string s = this.Semantics[i];
                if (s == semantics)
                {
                    buffer = this.Buffers[i];
                    break;
                }
            }

            return buffer;
        }

        public override string ToString()
        {
            return string.Format("{0} ctypes {1} semantics {2} buffers", this.Ctypes.Length, this.Semantics.Length, this.Buffers.Length);
        }
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
            this.pin = GCHandle.Alloc(this.array, GCHandleType.Pinned);
            return pin.AddrOfPinnedObject();
        }

        public void Unmapbuffer()
        {
            this.pin.Free();
        }

        public int Length()
        {
            return this.array.Length / ByteSize(this.type);
        }

        static PassType ToPassType(string type)
        {
            PassType passType;
            switch (type)
            {
            case "ffff": passType = PassType.vec4; break;
            case "fff": passType = PassType.vec3; break;
            case "ff": passType = PassType.vec2; break;
            case "hhhh": passType = PassType.ivec4; break;
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
            case PassType.ivec4: result = sizeof(int) * 4; break;
            default: throw new NotDealWithNewEnumItemException(typeof(PassType));
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} bytes", this.type, this.array.Length);
        }
    }

    public enum PassType
    {
        vec4,
        vec3,
        vec2,
        ivec4,
    }
}
