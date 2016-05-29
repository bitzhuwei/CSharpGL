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
            staticShaderCodes[0] = new ShaderCode(File.ReadAllText(@"Form09DummyTextBoxRenderer\TexBox.vert"), ShaderType.VertexShader);
            staticShaderCodes[1] = new ShaderCode(File.ReadAllText(@"Form09DummyTextBoxRenderer\TexBox.frag"), ShaderType.FragmentShader);
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
    }
}