using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using CSharpGL.Texts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.UIs
{
    /// <summary>
    /// 用shader+VAO+组装的texture显示一个指定的字符串
    /// <para>代表一个三维空间内的内容不可变的字符串</para>
    /// </summary>
    public class SimpleUIPointSpriteStringElement : SceneElementBase, IMVP, IUILayout
    {
        PointSpriteStringElement element;

        public SimpleUIPointSpriteStringElement(IUILayoutParam param,
            string content, vec3 position, 
            GLColor color = null, int fontSize = 32, int maxRowWidth = 256, FontResource fontResource = null)
        {
            IUILayout layout = this;
            layout.Param = param;
            this.element = new PointSpriteStringElement(content, position, color, fontSize, maxRowWidth, fontResource);
        }
        protected override void DoInitialize()
        {
            this.element.Initialize();

            this.BeforeRendering += this.GetSimpleUI_BeforeRendering();
            this.AfterRendering += this.GetSimpleUI_AfterRendering();
        }

        protected override void DoRender(RenderEventArgs e)
        {
            this.element.Render(e);
        }

        ~SimpleUIPointSpriteStringElement()
        {
            this.Dispose();
        }

        protected override void CleanManagedRes()
        {
            this.element.Dispose();

            base.CleanManagedRes();
        }

        void IMVP.SetShaderProgram(mat4 mvp)
        {
            IMVP element = this.element as IMVP;
            element.SetShaderProgram(mvp);
        }

        void IMVP.ResetShaderProgram()
        {
            IMVP element = this.element as IMVP;
            element.ResetShaderProgram();
        }

        ShaderProgram IMVP.GetShaderProgram()
        {
            return ((IMVP)this.element).GetShaderProgram();
        }

        IUILayoutParam IUILayout.Param { get; set; }
    }
}
