using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    /// <summary>
    /// 使用Default字体在一块区域渲染文字。
    /// </summary>
    class RaycastVolumeRender : RendererBase
    {

        static ShaderCode[] staticShaderCodes;
        static PropertyNameMap map;
        static RaycastVolumeRender()
        {
            staticShaderCodes = new ShaderCode[2];
            staticShaderCodes[0] = new ShaderCode(File.ReadAllText(@"09DummyTextBoxRenderer\TexBox.vert"), ShaderType.VertexShader);
            staticShaderCodes[1] = new ShaderCode(File.ReadAllText(@"09DummyTextBoxRenderer\TexBox.frag"), ShaderType.FragmentShader);
            map = new PropertyNameMap();
            map.Add("position", "position");
            map.Add("uv", "uv");
        }

        protected override void DoInitialize()
        {

            throw new NotImplementedException();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }

        protected override void DisposeUnmanagedResources()
        {
            throw new NotImplementedException();
        }

        class RaycastModel : IBufferable
        {
            public const string strPosition = "position";
            Dictionary<string, PropertyBufferPtr> propertyBufferPtrDict = new Dictionary<string, PropertyBufferPtr>();
            // draw the six faces of the boundbox by drawwing triangles
            // draw it contra-clockwise
            // front: 1 5 7 3
            // back:  0 2 6 4
            // left： 0 1 3 2
            // right: 7 5 4 6    
            // up:    2 3 7 6
            // down:  1 0 4 5
            static readonly float[] vertices = 
            {
				0.0f, 0.0f, 0.0f,
				0.0f, 0.0f, 1.0f,
				0.0f, 1.0f, 0.0f,
				0.0f, 1.0f, 1.0f,
				1.0f, 0.0f, 0.0f,
				1.0f, 0.0f, 1.0f,
				1.0f, 1.0f, 0.0f,
				1.0f, 1.0f, 1.0f,
            };
            static readonly uint[] indices = 
            {
				1,5,7,
				7,3,1,
				0,2,6,
				6,4,0,
				0,1,3,
				3,2,0,
				7,5,4,
				4,6,7,
				2,3,7,
				7,6,2,
				1,0,4,
				4,5,1,
            };

            public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (!propertyBufferPtrDict.ContainsKey(bufferName))
                    {
                        using (var buffer = new PropertyBuffer<float>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                        {
                            buffer.Alloc(vertices.Length);
                            unsafe
                            {
                                var array = (float*)buffer.FirstElement();
                                for (int i = 0; i < vertices.Length; i++)
                                {
                                    array[i] = vertices[i];
                                }
                            }
                            propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
                        }
                    }
                    return propertyBufferPtrDict[bufferName];
                }
                else
                {
                    return null;
                }
            }

            public IndexBufferPtr GetIndex()
            {
                if (indexBufferPtr == null)
                {
                    using (var buffer = new OneIndexBuffer<uint>(DrawMode.Triangles, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(indices.Length);
                        unsafe
                        {
                            var array = (uint*)buffer.FirstElement();
                            for (int i = 0; i < indices.Length; i++)
                            {
                                array[i] = indices[i];
                            }
                        }

                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }

                return indexBufferPtr;
            }

            IndexBufferPtr indexBufferPtr = null;

        }
    }
}