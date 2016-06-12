#version 150 core

uniform vec2 iResolution = vec2(800, 600);
uniform float iGlobalTime;


out vec4 out_Color;

// Fork of the main sequence star by flight404: https://www.shadertoy.com/view/4dXGR4
// Without the music of course.
// based on https://www.shadertoy.com/view/lsf3RH by
// trisomie21 (THANKS!)
// My apologies for the ugly code.

float snoise(vec3 uv, float res)	// by trisomie21
{
	const vec3 s = vec3(1e0, 1e2, 1e4);
	
	uv *= res;
	
	vec3 uv0 = floor(mod(uv, res))*s;
	vec3 uv1 = floor(mod(uv+vec3(1.), res))*s;
	
	vec3 f = fract(uv); f = f*f*(3.0-2.0*f);
	
	vec4 v = vec4(uv0.x+uv0.y+uv0.z, uv1.x+uv0.y+uv0.z,
		      	  uv0.x+uv1.y+uv0.z, uv1.x+uv1.y+uv0.z);
	
	vec4 r = fract(sin(v*1e-3)*1e5);
	float r0 = mix(mix(r.x, r.y, f.x), mix(r.z, r.w, f.x), f.y);
	
	r = fract(sin((v + uv1.z - uv0.z)*1e-3)*1e5);
	float r1 = mix(mix(r.x, r.y, f.x), mix(r.z, r.w, f.x), f.y);
	
	return mix(r0, r1, f.z)*2.-1.;
}


void mainImage( out vec4 fragColor, in vec2 fragCoord )
{
	float brightness = 0.0;
	float radius = 0.24 + brightness * 0.2;
	float invRadius = 1.0 / radius;

	vec3 orange = vec3(0.8, 0.65, 0.3);
	vec3 orangeRed = vec3(0.8, 0.35, 0.1);
	float time = iGlobalTime * 0.1;
	float aspect = iResolution.x / iResolution.y;
	vec2 uv = fragCoord.xy / iResolution.xy;
	vec2 p = -0.5 + uv;
	p.x *= aspect;

	float fade = pow(length(2.0 * p), 0.5);
	float fVal1 = 1.0 - fade;
	float fVal2 = 1.0 - fade;

	float angle = atan(p.x, p.y) / 6.2832;
	float dist = length(p);
	vec3 coord = vec3(angle, dist, time * 0.1);

	float newTime1 = abs(snoise(coord + vec3(0.0, -time * (0.35 + brightness * 0.001), time * 0.015), 15.0));
	float newTime2 = abs(snoise(coord + vec3(0.0, -time * (0.15 + brightness * 0.001), time * 0.015), 45.0));
	for (int i = 1; i <= 7; i++)
	{
		float power = pow(2.0, float(i + 1));
		fVal1 += (0.5 / power) * snoise(coord + vec3(0.0, -time, time * 0.2), (power * (10.0) * (newTime1 + 1.0)));
		fVal2 += (0.5 / power) * snoise(coord + vec3(0.0, -time, time * 0.2), (power * (25.0) * (newTime2 + 1.0)));
	}

	float corona = pow(fVal1 * max(1.1 - fade, 0.0), 2.0) * 50.0;
	corona += pow(fVal2 * max(1.1 - fade, 0.0), 2.0) * 50.0;
	corona *= 1.2 - newTime1;

	if (dist < radius)
	{
		corona *= pow(dist * invRadius, 24.0);
	}

	fragColor.rgb = corona * orange;
	fragColor.a = 1.0;
}

void main(void)
{
    mainImage(out_Color, gl_FragCoord.xy);
}
