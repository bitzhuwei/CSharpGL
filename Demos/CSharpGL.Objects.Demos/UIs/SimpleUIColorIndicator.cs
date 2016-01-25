using GLM;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.UIs;

namespace CSharpGL.Objects.Demos.UIs
{
    public class SimpleUIColorIndicator : RendererBase//, IMVP,IUILayout
    {
        private SimpleUIColorIndicatorBar bar;
        private SimpleUIPointSpriteStringElement[] numbers;

        public SimpleUIColorIndicator(IUILayoutParam param, ColorPalette colorPalette, GLColor textColor, float min, float max, float step)
        {
            this.bar = new SimpleUIColorIndicatorBar(param, colorPalette, min, max, step);

            float[] coords = colorPalette.Coords;
            float coordLength = coords[coords.Length - 1] - coords[0];
            this.numbers = new SimpleUIPointSpriteStringElement[coords.Length];
            const float posY = -1.0f;
            this.numbers[0] = new SimpleUIPointSpriteStringElement(
                param, (-100.0f).ToShortString(), new vec3(-0.5f, posY, 0), textColor, 20);
            for (int i = 1; i < coords.Length; i++)
            {
                float x = (coords[i] - coords[0]) / coordLength - 0.5f;
                if (i + 1 == coords.Length)
                {
                    var number = new SimpleUIPointSpriteStringElement(param,
                        (100.0f).ToShortString(), new vec3(x, posY, 0), textColor, 20);
                    this.numbers[i] = number;
                }
                else
                {
                    var number = new SimpleUIPointSpriteStringElement(param,
                        (-100.0f + i * (100 - (-100)) / 5).ToShortString(), new vec3(x, posY, 0), textColor, 20);
                    this.numbers[i] = number;
                }
            }
        }

        protected override void DoInitialize()
        {
            this.bar.Initialize();

            foreach (var item in this.numbers)
            {
                item.Initialize();
            }
        }

        protected override void DoRender(RenderEventArgs e)
        {
            // 去掉Camera，UI就不会旋转。
            RenderEventArgs barArg = new RenderEventArgs(e.RenderMode, null);
            this.bar.Render(barArg);

            foreach (var item in this.numbers)
            {
                item.Render(barArg);
            }
        }

        public IUILayoutParam Param { get; set; }
    }
}
