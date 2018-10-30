using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    partial class AnimationNode
    {
        private const string vertexCode = @"#version 150

in vec3 inPosition;
in vec3 inNormal;
in vec2 inTexCoord;
in uvec4 inBoneIDs;
in vec4 inWeights;

uniform mat4 mvpMat;
uniform mat4 normalMat; // transpose(inverse(modelMat))
const int MAX_BONES = 100;
uniform mat4 bones[MAX_BONES];
uniform bool animation = true;

out vec3 passNormal;
out vec2 passTexCoord;

void main()
{
    if (animation) {
        mat4 boneMat = bones[inBoneIDs[0]] * inWeights[0];
        boneMat += bones[inBoneIDs[1]] * inWeights[1];
        boneMat += bones[inBoneIDs[2]] * inWeights[2];
        boneMat += bones[inBoneIDs[3]] * inWeights[3];
        gl_Position = mvpMat * boneMat * vec4(inPosition, 1.0);
    }
    else {
        gl_Position = mvpMat * vec4(inPosition, 1.0);
    }

    passNormal = vec3(normalMat * vec4(inNormal, 0.0));
    passTexCoord = inTexCoord;
}
";

        private const string fragmentCode = @"#version 150

in vec3 passNormal;
in vec2 passTexCoord;

uniform sampler2D textureMap;
uniform vec3 lihtDirection = vec3(1, 1, 1);
uniform vec3 diffuseColor;
uniform bool transparent = false;

out vec4 outColor;

void main()
{
    if (transparent) {
        if (int(gl_FragCoord.x + gl_FragCoord.y) % 2 == 1) discard;
    }

    if (passTexCoord == vec2(-1, -1)) { // when texture coordinate not exists..
        float diffuse = max(dot(normalize(lihtDirection), normalize(passNormal)), 0);
        outColor = vec4(diffuseColor * diffuse, 1.0);
    }
    else {
        outColor = texture(textureMap, passTexCoord);
    }
}
";

    }
}
