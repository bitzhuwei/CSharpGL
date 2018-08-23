using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c07d00_ShadowMapping
{
    partial class ShadowMappingNode
    {
        private const string ambientVert = @"#version 150

in vec3 inPosition;

uniform mat4 mvpMat;

void main() {
    gl_Position = mvpMat * vec4(inPosition, 1.0);
}
";

        private const string ambientFrag = @"#version 150

uniform vec3 ambientColor;

out vec4 fragColor;

void main() {
    fragColor = vec4(ambientColor, 1.0);
}
";

        private const string shadowVert =
    @"#version 150

uniform mat4 mvpMatrix;

in vec3 inPosition;

void main(void)
{
    gl_Position = mvpMatrix * vec4(inPosition, 1.0);
}
";
        // this fragment shader is not needed.
        //        private const string shadowFragmentCode =
        //            @"#version 150
        //
        //out float fragmentdepth;
        //
        //void main(void) {
        //    fragmentdepth = gl_FragCoord.z;
        //
        //}
        //";

        private const string blinnPhongVert = @"// Blinn-Phong-WorldSpace.vert
#version 150

in vec3 inPosition;
in vec3 inNormal;

// Declare an interface block.
out _Vertex {
    vec3 position;
    vec3 normal;
    vec4 shadow_coord;
} v;

uniform mat4 mvpMat;
uniform mat4 modelMat;
uniform mat4 normalMat; // transpose(inverse(modelMat));
uniform mat4 shadowMat;

void main() {
    gl_Position = mvpMat * vec4(inPosition, 1.0);
    vec4 worldSpacePos = modelMat * vec4(inPosition, 1.0);
    v.position = worldSpacePos.xyz;
    v.normal = (normalMat * vec4(inNormal, 0)).xyz;
    v.shadow_coord = shadowMat * worldSpacePos;
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
    float cutOff;    // for spot light, cutOff. for others, meaningless.
};

struct Material {
    vec3 diffuse;
    vec3 specular;
    float shiness;
};

uniform Light light;
// 0: PointLight;  1: DirectionalLight; 
// 2: SpotLight;
// 3: XSpotLight;  4: NXSpotLight;
// 5: XSpotLight;  6: NXSpotLight;
// 7: XSpotLight;  8: NXSpotLight;
uniform int lightUpRoutine;

uniform Material material;

uniform sampler2DShadow depth_texture;

uniform bool useShadow = true;

uniform vec3 eyePos;

uniform bool blinn = true;

in _Vertex {
    vec3 position;
    vec3 normal;
    vec4 shadow_coord;
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

// direction is the direction to lightPos.
bool InsidePyramid(vec3 lightPos, vec3 direction, vec3 vPos, vec3 baseX, vec3 baseY) {
    direction = normalize(direction);
    vec3 t = lightPos - vPos;
    float height = dot(t, direction);
    if (height <= 0) { return false; }
	
    vec3 h = height * direction;
    vec3 p = h - t;
	
    baseX = normalize(baseX);
    if (abs(dot(p, baseX)) > height) { return false; }
	
    baseY = normalize(baseY);
    if (abs(dot(p, baseY)) > height) { return false; }
	
    return true;
}

void TSpotLightUp(Light light, vec3 direction, vec3 baseX, vec3 baseY, out float diffuse, out float specular) {
    if (InsidePyramid(light.position, direction, fsVertex.position, baseX, baseY)) {
	    vec3 Distance = light.position - fsVertex.position;
        vec3 lightDir = normalize(Distance);
        vec3 normal = normalize(fsVertex.normal); 
        float distance = length(Distance);
        float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * distance * distance);

        LightUp(lightDir, normal, eyePos, fsVertex.position, material.shiness, diffuse, specular);
    
        diffuse = diffuse * attenuation;
        specular = specular * attenuation;
    }
    else {
        diffuse = 0; specular = 0;
    }
}


out vec4 fragColor;

// 0: PointLight;  1: DirectionalLight; 
// 2: SpotLight;
// 3: XSpotLight;  4: NXSpotLight;
// 5: YSpotLight;  6: NYSpotLight;
// 7: ZSpotLight;  8: NZSpotLight;
void main() {
    float diffuse = 0;
    float specular = 0;
    if (lightUpRoutine == 0) { PointLightUp(light, diffuse, specular); }
    else if (lightUpRoutine == 1) { DirectionalLightUp(light, diffuse, specular); }
    else if (lightUpRoutine == 2) { SpotLightUp(light, diffuse, specular); }
    else if (lightUpRoutine == 3) { TSpotLightUp(light, vec3(-1, 0, 0), vec3(0, 1, 0), vec3(0, 0, 1), diffuse, specular); } //
    else if (lightUpRoutine == 4) { TSpotLightUp(light, vec3(1, 0, 0), vec3(0, 1, 0), vec3(0, 0, 1), diffuse, specular); } //
    else if (lightUpRoutine == 5) { TSpotLightUp(light, vec3(0, -1, 0), vec3(1, 0, 0), vec3(0, 0, 1), diffuse, specular); } //
    else if (lightUpRoutine == 6) { TSpotLightUp(light, vec3(0, 1, 0), vec3(1, 0, 0), vec3(0, 0, 1), diffuse, specular); } //
    else if (lightUpRoutine == 7) { TSpotLightUp(light, vec3(0, 0, -1), vec3(1, 0, 0), vec3(0, 1, 0), diffuse, specular); }
    else if (lightUpRoutine == 8) { TSpotLightUp(light, vec3(0, 0, 1), vec3(1, 0, 0), vec3(0, 1, 0), diffuse, specular); }
    else { diffuse = 0; specular = 0; }
    
    float f = 1;
    if (useShadow) {
        f = textureProj(depth_texture, fsVertex.shadow_coord);
    }
    
    fragColor = vec4(f * diffuse * light.diffuse * material.diffuse + f * specular * light.specular * material.specular, 1.0);
}
";

    }
}
