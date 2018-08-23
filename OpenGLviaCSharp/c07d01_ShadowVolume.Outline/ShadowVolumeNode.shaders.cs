using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lighting.ShadowVolume
{
    partial class ShadowVolumeNode
    {

        private const string ambientVert = @"#version 330

in vec3 inPosition;

uniform mat4 mvpMat;

void main(void) {
	gl_Position = mvpMat * vec4(inPosition, 1.0);
}
";
        private const string ambientFrag = @"#version 330

uniform vec3 ambientColor;

out vec4 outColor;

void main(void) {
	outColor = vec4(ambientColor, 0.1);
}
";

        private const string extrudeVert = @"#version 330

in vec3 inPosition;                                             

out vec3 passPosition;
                                                                                    
void main()                                                                         
{                                                                                   
    passPosition = inPosition;
}
";

        private const string extrudeGeom = @"#version 330

layout (triangles_adjacency) in;    // six vertices in
layout (line_strip, max_vertices = 6) out; // 4 per quad * 3 triangle vertices + 6 for near/far caps

in vec3 passPosition[]; // an array of 6 vertices (triangle with adjacency)

uniform bool farAway = false; // light's position is infinitly far away.
uniform vec3 lightPosition; // if farAway is true, lightPosition means direction to light source; otherwise, it means light's position.
uniform mat4 vpMat;
uniform mat4 gWorld;

float EPSILON = 0.0001;

// Emit a line using a triangle strip
void EmitOutline(vec3 StartVertex, vec3 EndVertex)
{    
    gl_Position = vpMat * vec4(StartVertex, 1.0);
    EmitVertex();
 
    gl_Position = vpMat * vec4(EndVertex, 1.0);
    EmitVertex();
    
    EndPrimitive();            
}


void main()
{
    vec3 worldSpacePos[6]; 
	worldSpacePos[0] = vec3(gWorld * vec4(passPosition[0], 1.0));
    worldSpacePos[1] = vec3(gWorld * vec4(passPosition[1], 1.0));
    worldSpacePos[2] = vec3(gWorld * vec4(passPosition[2], 1.0));
    worldSpacePos[3] = vec3(gWorld * vec4(passPosition[3], 1.0));
    worldSpacePos[4] = vec3(gWorld * vec4(passPosition[4], 1.0));
    worldSpacePos[5] = vec3(gWorld * vec4(passPosition[5], 1.0));
    vec3 e1 = worldSpacePos[2] - worldSpacePos[0];
    vec3 e2 = worldSpacePos[4] - worldSpacePos[0];
    vec3 e3 = worldSpacePos[1] - worldSpacePos[0];
    vec3 e4 = worldSpacePos[3] - worldSpacePos[2];
    vec3 e5 = worldSpacePos[4] - worldSpacePos[2];
    vec3 e6 = worldSpacePos[5] - worldSpacePos[0];

    vec3 Normal = normalize(cross(e1,e2));
    vec3 LightDir;
    if (farAway) { LightDir = lightPosition; }
    else { LightDir = normalize(lightPosition - worldSpacePos[0]); }

    // Handle only light facing triangles
    if (dot(Normal, LightDir) > 0) {

        Normal = cross(e3,e1);

        if (dot(Normal, LightDir) <= 0) {
            vec3 StartVertex = worldSpacePos[0];
            vec3 EndVertex = worldSpacePos[2];
            EmitOutline(StartVertex, EndVertex);
        }

        Normal = cross(e4,e5);
        if (farAway) { LightDir = lightPosition; }
        else { LightDir = normalize(lightPosition - worldSpacePos[2]); }

        if (dot(Normal, LightDir) <= 0) {
            vec3 StartVertex = worldSpacePos[2];
            vec3 EndVertex = worldSpacePos[4];
            EmitOutline(StartVertex, EndVertex);
        }

        Normal = cross(e2,e6);
        if (farAway) { LightDir = lightPosition; }
        else { LightDir = normalize(lightPosition - worldSpacePos[4]); }

        if (dot(Normal, LightDir) <= 0) {
            vec3 StartVertex = worldSpacePos[4];
            vec3 EndVertex = worldSpacePos[0];
            EmitOutline(StartVertex, EndVertex);
        }
    }
}
";
        private const string extrudeFrag = @"#version 330

out vec4 outColor;

void main()
{
    outColor = vec4(1);
}
";

        private const string blinnPhongVert = @"// Blinn-Phong-WorldSpace.vert
#version 150

in vec3 inPosition;
in vec3 inNormal;

// Declare an interface block.
out _Vertex {
    vec3 position;
	vec3 normal;
} v;

uniform mat4 mvpMat;
uniform mat4 modelMat;
uniform mat4 normalMat; // transpose(inverse(modelMat));

void main() {
    gl_Position = mvpMat * vec4(inPosition, 1.0);
    vec4 worldSpacePos = modelMat * vec4(inPosition, 1.0);
	v.position = worldSpacePos.xyz;
	v.normal = (normalMat * vec4(inNormal, 0)).xyz;
}
";
        private const string blinnPhongFrag = @"// Blinn-Phong-WorldSpace.frag
#version 150

struct Light {
    vec3 position;   // for directional light, meaningless.
    vec3 diffuse;
    vec3 specular;
    float constant;  // Attenuation.constant.
    float linear;    // Attenuation.linear.
    float quadratic; // Attenuation.quadratic.
	// direction from outer space to light source.
	vec3 direction;  // for point light, meaningless.
	// Note: We assume that spot light's angle ranges from 0 to 180 degrees.
    // cutOff = Cos(angle). angle ranges in [0, 90].
	float cutOff;    // for spot light, cutOff. for others, meaningless.
};

struct Material {
    vec3 diffuse;
    vec3 specular;
    float shiness;
};

uniform Light light;
uniform int lightUpRoutine; // 0: point light; 1: directional light; 2: spot light.

uniform Material material;

uniform vec3 eyePos;

uniform bool blinn = true;

in _Vertex {
    vec3 position;
	vec3 normal;
} fsVertex;

void LightUp(vec3 lightDir, vec3 normal, vec3 ePos, vec3 vPos, float shiness, out float diffuse, out float specular) {
    // Diffuse factor
    diffuse = max(dot(lightDir, normal), 0);

    // Specular factor
    vec3 eyeDir = normalize(ePos - vPos);
    specular = 0;
    if (blinn) {
        if (diffuse > 0) {
            vec3 halfwayDir = normalize(lightDir + eyeDir);
            specular = pow(max(dot(normal, halfwayDir), 0.0), shiness);
        }
    }
    else {
        if (diffuse > 0) {
            vec3 reflectDir = reflect(-lightDir, normal);
            specular = pow(max(dot(eyeDir, reflectDir), 0.0), shiness);
        }
    }
}

void PointLightUp(Light light, out float diffuse, out float specular) {
    vec3 Distance = light.position - fsVertex.position;
    vec3 lightDir = normalize(Distance);
    vec3 normal = normalize(fsVertex.normal); 
    float distance = length(Distance);
    float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * distance * distance);
    
    LightUp(lightDir, normal, eyePos, fsVertex.position, material.shiness, diffuse, specular);
    
    diffuse = diffuse * attenuation;
    specular = specular * attenuation;
}

void DirectionalLightUp(Light light, out float diffuse, out float specular) {
    vec3 lightDir = normalize(light.direction);
    vec3 normal = normalize(fsVertex.normal); 
    LightUp(lightDir, normal, eyePos, fsVertex.position, material.shiness, diffuse, specular);
}

// Note: We assume that spot light's angle ranges from 0 to 180 degrees.
void SpotLightUp(Light light, out float diffuse, out float specular) {
    vec3 Distance = light.position - fsVertex.position;
    vec3 lightDir = normalize(Distance);
    vec3 centerDir = normalize(light.direction);
    float c = dot(lightDir, centerDir);// cut off at this point.
    if (c < light.cutOff) { // current point is outside of the cut off edge. 
        diffuse = 0; specular = 0;
    }
    else {
        vec3 normal = normalize(fsVertex.normal); 
        float distance = length(Distance);
        float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * distance * distance);

        LightUp(lightDir, normal, eyePos, fsVertex.position, material.shiness, diffuse, specular);
    
        diffuse = diffuse * attenuation;
        specular = specular * attenuation;
    }
}

out vec4 outColor;

void main() {
    float diffuse = 0;
    float specular = 0;
	if (lightUpRoutine == 0) { PointLightUp(light, diffuse, specular); }
	else if (lightUpRoutine == 1) { DirectionalLightUp(light, diffuse, specular); }
	else if (lightUpRoutine == 2) { SpotLightUp(light, diffuse, specular); }
    else { diffuse = 0; specular = 0; }

	outColor = vec4(diffuse * light.diffuse * material.diffuse + specular * light.specular * material.specular, 1.0);
}
";
    }

}
