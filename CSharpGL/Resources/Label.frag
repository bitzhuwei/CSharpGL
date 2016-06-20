#version 150 core

in vec2 passUV;

uniform sampler2D fontTexture;

void main(){
    // Output color = color of the texture at the specified UV
    vec4 color = texture(fontTexture, passUV);
    //if (color.r <= 0.1f) discard;
    
    gl_FragColor = color;
}
