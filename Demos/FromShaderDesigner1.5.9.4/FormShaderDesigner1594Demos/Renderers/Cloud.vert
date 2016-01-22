
//
// Vertex shader for producing clouds (mostly cloudy)
//
// Author: Randi Rost
//
// Copyright (c) 2002-2004 3Dlabs Inc. Ltd.
//
// See 3Dlabs-License.txt for license information
//
#version 150 core

in vec3 in_Position;
in vec3 in_Normal;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

out float LightIntensity;
out vec3  MCposition;

uniform vec3  LightPos;
uniform float Scale;

void main(void)
{
   // gl_TexCoord[0] = gl_MultiTexCoord0;
    gl_Position     = ftransform();
    vec4 ECposition = gl_ModelViewMatrix * gl_Vertex;
    MCposition      = vec3 (gl_Vertex) * Scale;
    vec3 tnorm      = normalize(vec3 (gl_NormalMatrix * gl_Normal));
    LightIntensity  = dot(normalize(LightPos - vec3 (ECposition)), tnorm) * 1.5;

}
