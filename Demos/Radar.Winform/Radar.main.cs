// 此文件由CSharpGL.CSSLGenerator.exe生成。
// 用法：使用CSSL2GLSL.exe编译此文件，即可获得对应的vertex shader, geometry shader, fragment shader。
// 此文件中的类型不应被直接调用，发布release时可以去掉。
// 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
namespace CSharpShadingLanguage.Radar
{
    using CSharpShadingLanguage;


    /// <summary>
    /// 一个<see cref="RadarVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    public partial class RadarVert : CSharpShadingLanguage.VertexCSShaderCode
    {

        public override void main()
        {
            pass_color = color;
            vec4 pos = mvp * vec4(position, 1.0f);
            gl_Position = pos;
            //gl_PointSize = 40;// (1.0f - pos.z / pos.w) * 20;// 20: size factor
            pass_position = vec2(pos.x / pos.w, pos.y / pos.w);

            gl_PointSize = pointSize; 
        }
    }

    /// <summary>
    /// 一个<see cref="RadarFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    public partial class RadarFrag : CSharpShadingLanguage.FragmentCSShaderCode
    {

        public override void main()
        {
            //output_color = vec4(pass_color, 1);

            //get screen coord from frag coord
            float screenX = (gl_FragCoord.x / canvasWidth - 0.5f) * 2;
            float screenY = (gl_FragCoord.y / canvasHeight - 0.5f) * 2;
            //find the difference between the fragments screen position and the points screen position then simply work out the point coord from the point size
            vec2 pointCoord = vec2(
                ((screenX - pass_position.x) / (pointSize / canvasWidth) + 1) / 2,
                1 - ((screenY - pass_position.y) / (pointSize / canvasHeight) + 1) / 2);
            // remove this discard thing if you want to have a quad instead of a sphere
            if (length(pointCoord - vec2(0.5f, 0.5f)) > 0.3)
            { discard(); }
            else
            {
                if (pointCoord.x < 0) { pointCoord.x = 0; }
                if (pointCoord.x > 1) { pointCoord.x = 1; }
                if (pointCoord.y < 0) { pointCoord.y = 0; }
                if (pointCoord.y > 1) { pointCoord.y = 1; }
                vec4 textureColor = texture(cloudTexture, pointCoord);
                //vec3 rgb = textureColor.rgb * pass_color;// *brightness;
                //vec3 rgb = textureColor.rgb;// *pass_color;// *brightness;
                vec3 rgb = pass_color;
                //float a = textureColor.a;
                float a = (0.5f - length(pointCoord - vec2(0.5f, 0.5f)));// *2;
                //float a = textureColor.a;
                output_color = vec4(rgb, a);
            }
        }
    }
}
