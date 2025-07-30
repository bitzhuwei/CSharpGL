using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c07d02_ShadowVolume.StencilTest {
    partial class ShadowVolumeNode {

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
layout (triangle_strip, max_vertices = 18) out; // 4 per quad * 3 triangle vertices + 6 for near/far caps
in vec3 passPosition[]; // an array of 6 vertices (triangle with adjacency)
uniform bool farAway = false; // light's position is infinitly far away.
uniform vec3 lightPosition; // if farAway is true, lightPosition means direction to light source; otherwise, it means light's position.
uniform mat4 vpMat;
uniform mat4 modelMat;
float EPSILON = 0.0001;
out _Vertex {
    vec3 position;
    vec3 normal;
} v;
// Emit a quad using a triangle strip
void EmitQuad(vec3 startPos, vec3 endPos)
{    
    vec3 lightDirection;
    if (farAway) { lightDirection = -lightPosition; }
    else { lightDirection = normalize(startPos - lightPosition); }
    // Vertex #1: the starting vertex (just a tiny bit below the original edge)
    v.position = startPos;
    v.normal = -cross((endPos - startPos), lightDirection);
    gl_Position = vpMat * vec4((startPos + lightDirection * EPSILON), 1.0);
    EmitVertex();
 
    // Vertex #2: the starting vertex projected to infinity
    v.position = startPos;
    v.normal = -cross((endPos - startPos), lightDirection);
    gl_Position = vpMat * vec4(lightDirection, 0.0);
    EmitVertex();
    
    if (farAway) { lightDirection = -lightPosition; }
    else { lightDirection = normalize(endPos - lightPosition); }
    // Vertex #3: the ending vertex (just a tiny bit below the original edge)
    v.position = endPos;
    v.normal = -cross((endPos - startPos), lightDirection);
    gl_Position = vpMat * vec4((endPos + lightDirection * EPSILON), 1.0);
    EmitVertex();
    
    // Vertex #4: the ending vertex projected to infinity
    v.position = endPos;
    v.normal = -cross((endPos - startPos), lightDirection);
    gl_Position = vpMat * vec4(lightDirection , 0.0);
    EmitVertex();
    EndPrimitive();            
}
void main()
{
    vec3 worldSpacePos[6]; 
    worldSpacePos[0] = vec3(modelMat * vec4(passPosition[0], 1.0));
    worldSpacePos[1] = vec3(modelMat * vec4(passPosition[1], 1.0));
    worldSpacePos[2] = vec3(modelMat * vec4(passPosition[2], 1.0));
    worldSpacePos[3] = vec3(modelMat * vec4(passPosition[3], 1.0));
    worldSpacePos[4] = vec3(modelMat * vec4(passPosition[4], 1.0));
    worldSpacePos[5] = vec3(modelMat * vec4(passPosition[5], 1.0));
    vec3 e1 = worldSpacePos[2] - worldSpacePos[0];
    vec3 e2 = worldSpacePos[4] - worldSpacePos[0];
    vec3 e3 = worldSpacePos[1] - worldSpacePos[0];
    vec3 e4 = worldSpacePos[3] - worldSpacePos[2];
    vec3 e5 = worldSpacePos[4] - worldSpacePos[2];
    vec3 e6 = worldSpacePos[5] - worldSpacePos[0];
    vec3 Normal = normalize(cross(e1,e2));
    vec3 lightDirection;
    if (farAway) { lightDirection = lightPosition; }
    else { lightDirection = normalize(lightPosition - worldSpacePos[0]); }
    // Handle only light facing triangles
    if (dot(Normal, lightDirection) > 0) {
        Normal = cross(e3,e1);
        if (dot(Normal, lightDirection) <= 0) {
            vec3 startPos = worldSpacePos[0];
            vec3 endPos = worldSpacePos[2];
            EmitQuad(startPos, endPos);
        }
        Normal = cross(e4,e5);
        if (farAway) { lightDirection = lightPosition; }
        else { lightDirection = normalize(lightPosition - worldSpacePos[2]); }
        if (dot(Normal, lightDirection) <= 0) {
            vec3 startPos = worldSpacePos[2];
            vec3 endPos = worldSpacePos[4];
            EmitQuad(startPos, endPos);
        }
        Normal = cross(e2,e6);
        if (farAway) { lightDirection = lightPosition; }
        else { lightDirection = normalize(lightPosition - worldSpacePos[4]); }
        if (dot(Normal, lightDirection) <= 0) {
            vec3 startPos = worldSpacePos[4];
            vec3 endPos = worldSpacePos[0];
            EmitQuad(startPos, endPos);
        }
        // render the front cap
        if (farAway) { lightDirection = -lightPosition; }
        else { lightDirection = (normalize(worldSpacePos[0] - lightPosition)); }
        gl_Position = vpMat * vec4((worldSpacePos[0] + lightDirection * EPSILON), 1.0);
        EmitVertex();
        if (farAway) { lightDirection = -lightPosition; }
        else { lightDirection = (normalize(worldSpacePos[2] - lightPosition)); }
        gl_Position = vpMat * vec4((worldSpacePos[2] + lightDirection * EPSILON), 1.0);
        EmitVertex();
        if (farAway) { lightDirection = -lightPosition; }
        else { lightDirection = (normalize(worldSpacePos[4] - lightPosition)); }
        gl_Position = vpMat * vec4((worldSpacePos[4] + lightDirection * EPSILON), 1.0);
        EmitVertex();
        EndPrimitive();
 
        // render the back cap
        if (farAway) { lightDirection = -lightPosition; }
        else { lightDirection = worldSpacePos[0] - lightPosition; }
        gl_Position = vpMat * vec4(lightDirection, 0.0);
        EmitVertex();
        if (farAway) { lightDirection = -lightPosition; }
        else { lightDirection = worldSpacePos[4] - lightPosition; }
        gl_Position = vpMat * vec4(lightDirection, 0.0);
        EmitVertex();
        if (farAway) { lightDirection = -lightPosition; }
        else { lightDirection = worldSpacePos[2] - lightPosition; }
        gl_Position = vpMat * vec4(lightDirection, 0.0);
        EmitVertex();
        EndPrimitive();
    }
}
";
        private const string extrudeFrag = @"#version 330
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
    if (diffuse > 0) {
        vec3 halfwayDir = normalize(lightDir + eyeDir);
        specular = pow(max(dot(normal, halfwayDir), 0.0), shiness);
    }
}
void DirectionalLightUp(Light light, out float diffuse, out float specular) {
    vec3 lightDir = normalize(light.direction);
    vec3 normal = normalize(fsVertex.normal); 
    LightUp(lightDir, normal, eyePos, fsVertex.position, material.shiness, diffuse, specular);
}
uniform bool wireframe = false;
out vec4 outColor;
void main() {
    if (int(gl_FragCoord.x - 0.5) % 2 == 1 && int(gl_FragCoord.y - 0.5) % 2 != 1) discard;
    if (int(gl_FragCoord.x - 0.5) % 2 != 1 && int(gl_FragCoord.y - 0.5) % 2 == 1) discard;
    if (wireframe) { outColor = vec4(1, 1, 1, 1); }
    else {
        float diffuse = 0;
        float specular = 0;
        DirectionalLightUp(light, diffuse, specular);
	    outColor = vec4(1, 0, 0, 1.0);
    }
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