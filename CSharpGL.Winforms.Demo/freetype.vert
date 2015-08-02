#version 120

attribute vec4 coord;
varying vec2 texcoord;

void main(void) {
  gl_Position = vec4(coord.xy, 0, 1);
  texcoord = coord.zw;
}