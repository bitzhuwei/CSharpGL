using System;

namespace CSharpShadingLanguage.ConsoleTest
{
    class DemoFrag : FragmentShaderCode
    {
        [In]
        vec2 pass_UV;
        [Out]
        vec4 out_Color;

        [Uniform]
        sampler2D texture1;
        [Uniform]
        sampler2D texture2;
        [Uniform]
        float percent;

        public override void main()
        {
            vec4 color = texture(texture1, pass_UV) * percent + texture(texture2, pass_UV) * (1.0f - percent);
			if (color.a < 0.1)
			{
				discard();
			}
            out_Color = color;
        }

    }
}
