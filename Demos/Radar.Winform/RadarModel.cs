using CSharpGL;
using CSharpGL.Objects.ModernRendering;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Winform
{
    class RadarModel : IConvert2BufferPointer
    {
        List<vec3> positionList = new List<vec3>();
        List<vec3> colorList = new List<vec3>();

        public RadarModel(List<vec3> positionList,List<vec3> colorList)
        {
            this.positionList = positionList;
            this.colorList = colorList;
        }

        const string strposition = "position";
        const string strcolor = "color";

        CSharpGL.Objects.VertexBuffers.BufferPointer IConvert2BufferPointer.GetBufferRenderer(string bufferName, string varNameInShader)
        {
            if (bufferName == strposition)
            {
                using (var buffer = new PositionBuffer(bufferName))
                {
                    buffer.Alloc(this.positionList.Count);
                    unsafe
                    {
                        var array = (vec3*)buffer.FirstElement();
                        for (int i = 0; i < this.positionList.Count; i++)
                        {
                            array[i] = this.positionList[i];
                        }
                    }

                    return buffer.GetRenderer();
                }
            }
            else if (bufferName == strcolor)
            {
                using (var buffer = new ColorBuffer(bufferName))
                {
                    buffer.Alloc(this.colorList.Count);
                    unsafe
                    {
                        var array = (vec3*)buffer.FirstElement();
                        for (int i = 0; i < this.colorList.Count; i++)
                        {
                            array[i] = this.colorList[i];
                        }
                    }

                    return buffer.GetRenderer();
                }
            }

            throw new NotImplementedException();
        }

        CSharpGL.Objects.VertexBuffers.IndexBufferPointerBase IConvert2BufferPointer.GetIndexBufferRenderer()
        {
            using (var buffer = new ZeroIndexBuffer(DrawMode.Points, 0, this.positionList.Count))
            {
                return buffer.GetRenderer() as CSharpGL.Objects.VertexBuffers.IndexBufferPointerBase;
            }
        }

        class PositionBuffer : PropertyBuffer<vec3>
        {
            public PositionBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            { }
        }

        class ColorBuffer : PropertyBuffer<vec3>
        {
            public ColorBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            { }
        }


    }
}
