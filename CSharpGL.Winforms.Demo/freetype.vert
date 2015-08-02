#version 120

attribute vec4 coord;
varying vec2 texcoord;

uniform mat4 transformMatrix;

void main(void) {
  gl_Position = transformMatrix * vec4(coord.xy, 0, 1);
  texcoord = coord.zw;
}