//
// Fragment shader for cartoon-style shading
//
// Author: Philip Rideout
//
// Copyright (c) 2004 3Dlabs Inc. Ltd.
//
// See 3Dlabs-License.txt for license information
//
#version 150 core

uniform vec3 DiffuseColor;
uniform vec3 PhongColor;
uniform float Edge;
uniform float Phong;
in vec3 Normal;

out vec4 outColor;

void main (void)
{
	vec3 color = DiffuseColor;
	float f = dot(vec3(0, 0, 1), Normal);
	if (abs(f) < Edge)
		color = vec3(0);
	if (f > Phong)
		color = PhongColor;

	outColor = vec4(color, 1);	
}
