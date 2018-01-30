// Blinn-Phong-WorldSpace.vert
#version 150
in vec3 inPosition;
in vec3 inNormal;

// Declare an interface block.
out VS_OUT {
    vec3 position;
	vec3 normal;
} vs_out;

uniform mat4 projectionMat;
uniform mat4 viewMat;
uniform mat4 modelMat;
uniform mat4 normalMat; // transpose(inverse(modelMat));

void main() {
    vec4 worldPos = modelMat * vec4(inPosition, 1.0);
    gl_Position = projectionMat * viewMat * worldPos;
	vs_out.position = worldPos.xyz;
	vs_out.normal = (normalMat * vec4(inNormal, 0)).xyz;
}
