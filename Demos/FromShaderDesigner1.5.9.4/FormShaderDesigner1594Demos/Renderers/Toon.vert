//
// Vertex shader for cartoon-style shading
//
// Author: Philip Rideout
//
// Copyright (c) 2004 3Dlabs Inc. Ltd.
//
// See 3Dlabs-License.txt for license information
//
#version 150 core

in vec3 in_Position;
in vec3 in_Normal;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

out vec3 Normal;

void main(void)
{
	Normal = normalize(vec3(viewMatrix * modelMatrix * vec4(in_Normal, 1.0)));
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);	
}
