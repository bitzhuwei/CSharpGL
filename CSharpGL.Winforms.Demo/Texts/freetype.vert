#version 120

attribute vec3 in_Position;
attribute vec2 in_TexCoord;
varying vec2 texcoord;
uniform mat4 transformMatrix;

void main(void) {
  gl_Position = transformMatrix * vec4(in_Position, 1);
  texcoord = in_TexCoord;//coord.zw;
}