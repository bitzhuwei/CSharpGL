using System.ComponentModel;
using System.Drawing;

namespace CSharpGL
{
    public partial class UIText
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            // RULE: 用于渲染UI元素的模型，其范围最好是在(-0.5, -0.5, -0.5)到(-0.5, -0.5, -0.5)之间，即保持其边长为1，且位于坐标系中心。这样，就可以用mat4 model = glm.scale(mat4.identity(), new vec3(this.Size.Width, this.Size.Height, 1));来设定其缩放比例了。简单方便。
            mat4 projection = this.GetOrthoProjection();
            //vec3 position = (this.camera.Position - this.camera.Target).normalize();
            mat4 view = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
            //float length = Math.Max(glText.Size.Width, glText.Size.Height) / 2;
            float length = this.Size.Height;// / 2;
            mat4 model = glm.scale(mat4.identity(), new vec3(length, length, length));
            //model = mat4.identity();
            var renderer = this.Renderer as Renderer;
            renderer.SetUniform("mvp", projection * view * model);
            if (this.textColorRecord.IsMarked())
            {
                renderer.SetUniform("textColor", this.textColor);
                this.textColorRecord.CancelMark();
            }
            if (this.textRecord.IsMarked())
            {
                TextModel textModel = this.textModel;
                if (textModel != null)
                {
                    textModel.SetText(this.text, this.fontTexture);
                    this.textRecord.CancelMark();
                }
            }

            blendSwitch.On();

            base.DoRender(arg);

            blendSwitch.Off();
        }
    }
}