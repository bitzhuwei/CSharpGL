// Blinn-Phong-EyeSpace.frag
#version 150

uniform sampler2D tex;
uniform vec3 lightPos;
uniform float shiness;
uniform vec3 lightColor;
uniform bool blinn;
const vec3 eyePos = vec3(0, 0, 0);

in VS_OUT {
    vec3 position;
	vec3 normal;
	vec2 texCoord;
} fs_in;

out vec4 fragColor;

void main() {
    vec3 color = texture(tex, fs_in.texCoord).xyz;
	// Diffuse color
	vec3 lightDir = normalize(lightPos - fs_in.position);
	vec3 normal = normalize(fs_in.normal);
	vec3 diffuse = color * max(dot(lightDir, normal), 0.0);
	// Specular color
	vec3 eyeDir = normalize(eyePos - fs_in.position);
	float specular;
	if (blinn) {
	    vec3 halfwayDir = normalize(lightDir + eyeDir);
		specular = pow(max(dot(normal, halfwayDir), 0.0), shiness);
	}
	else {
	    vec3 reflectDir = reflect(-lightDir, normal);
		specular = pow(max(dot(eyeDir, reflectDir), 0.0), shiness);
	}
	
	fragColor = vec4(lightColor * (diffuse + specular), 1.0);
}
