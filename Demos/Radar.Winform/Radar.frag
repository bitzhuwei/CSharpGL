#version 150 core

in vec3 pass_color;
in vec2 pass_position;
uniform float pointSize;
out vec4 output_color;
uniform sampler2D cloudTexture;
uniform float canvasWidth;
uniform float canvasHeight;
uniform float brightness = 1;

void main(void)
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
    { discard; }
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

