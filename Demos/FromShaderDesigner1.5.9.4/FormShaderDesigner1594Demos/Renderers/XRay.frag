// vertex to fragment shader io
#version 150 core

in vec3 N;
in vec3 I;
in vec3 Cs;

out vec4 color;

// globals
uniform float edgefalloff;

// entry point
void main()
{
    float opac = dot(normalize(-N), normalize(-I));
    opac = abs(opac);
    opac = pow(opac, edgefalloff);
    opac = 1.0 - opac;
    
    //gl_FragColor =  opac * Cs;
    //gl_FragColor.a = opac;
	color = vec4(opac * Cs, opac);
}
