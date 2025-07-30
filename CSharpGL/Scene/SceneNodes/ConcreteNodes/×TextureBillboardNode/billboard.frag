#version 120

// Interpolated values from the vertex shaders
in vec2 UV;

uniform sampler2D myTextureSampler;

uniform float LifeLevel;

void main(){
	// Output color = color of the texture at the specified UV
	vec4 color = texture2D( myTextureSampler, UV );
	if (color.r <= 0.1f) discard;
	
	// Hardcoded life level, should be in a separate texture.
	if (UV.x < LifeLevel && UV.y > 0.2 && UV.y < 0.8 && UV.x > 0.04 )
	{ 
		gl_FragColor = vec4(0.2, 0.8, 0.2, 1.0); // Opaque green
	}
	else
	{
		gl_FragColor = color;
	}
}
