using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointLight.NoShadow
{
    partial class PointLightNoShadowNode
    {
        private const string blinnPhongVert = @"// Blinn-Phong-WorldSpace.vert
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
";
        private const string blinnPhongFrag = @"// Blinn-Phong-WorldSpace.frag
#version 150
struct Attenuation {
    float constant;
    float linear;
    float quadratic;
};
struct Light {
    vec3 position;
    vec3 diffuse;
    vec3 specular;
    Attenuation attenuation;
};

struct Material {
    vec3 diffuse;
    vec3 specular;
    float shiness;
};

uniform Light light;

uniform Material material;

uniform vec3 eyePos;

uniform bool blinn = true;

in VS_OUT {
    vec3 position;
	vec3 normal;
} fs_in;

out vec4 fragColor;

void main() {
    vec3 L = light.position - fs_in.position;
    float distance = length(L);
    float attenuation = 1.0 / (light.attenuation.constant + light.attenuation.linear * distance + light.attenuation.quadratic * distance * distance);
	vec3 lightDir = normalize(L);
	vec3 normal = normalize(fs_in.normal);

	// Diffuse color
    float diff = max(dot(lightDir, normal), 0);
	vec3 diffuse = material.diffuse * diff * attenuation;

	// Specular color
	vec3 eyeDir = normalize(eyePos - fs_in.position);
	float spec;
	if (blinn) {
	    vec3 halfwayDir = normalize(lightDir + eyeDir);
		float spec = pow(max(dot(normal, halfwayDir), 0.0), material.shiness);
	}
	else {
	    vec3 reflectDir = reflect(-lightDir, normal);
		float spec = pow(max(dot(eyeDir, reflectDir), 0.0), material.shiness);
	}
    vec3 specular = material.specular * spec * attenuation;
	
	fragColor = vec4(light.diffuse * diffuse + light.specular * specular, 1.0);
}
";

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
    }
}
