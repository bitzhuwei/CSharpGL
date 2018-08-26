using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fuluDD01_LayeredEngraving.PNG
{
    public partial class RaycastNode
    {
        private const string raycastingVert = @"#version 150

in vec3 inPosition;
in vec3 inBoundingBox;  

out vec3 passEntryPoint;

uniform mat4 mvpMat;

void main()
{
    gl_Position = mvpMat * vec4(inPosition, 1.0);

    passEntryPoint = inBoundingBox;
}
";
        private const string raycastingFrag = @"#version 150

in vec3 passEntryPoint;

uniform sampler2D texExitPoint;
uniform sampler3D texVolume;

uniform float stepLength = 0.001f;
uniform vec2 canvasSize;
uniform vec4 backgroundColor = vec4(0, 0, 0, 0);// value in glClearColor(value);
uniform int cycle = 1600;

out vec4 outColor;

void main()
{
    vec3 exitPoint = texture(texExitPoint, gl_FragCoord.st / canvasSize).xyz;
    if (passEntryPoint == exitPoint) { discard; }

    vec3 direction = exitPoint - passEntryPoint;
    float directionLength = length(direction);
    vec3 deltaDirection = direction * (stepLength / directionLength);

    vec3 voxelCoord = passEntryPoint;
    vec3 colorAccumulator = vec3(0.0); // The dest color
    float alphaAccumulator = 0.0f;
    float lengthAccumulator = 0.0;
    vec3 intensity;
    vec4 colorSample; // The src color 
 
    for(int i = 0; i < cycle; i++)
    {
        intensity = texture(texVolume, voxelCoord).rgb;
        colorSample = vec4(intensity, 0.05);
        // front-to-back integration.
        if (colorSample.r > 0.0 || colorSample.g > 0.0 || colorSample.b > 0.0) {
            // accomodate for variable sampling rates (base interval defined by mod_compositing.frag)
            colorSample.a = 1.0 - pow(1.0 - colorSample.a, stepLength * 200.0f);
            colorAccumulator += (1.0 - alphaAccumulator) * colorSample.rgb * colorSample.a;
            alphaAccumulator += (1.0 - alphaAccumulator) * colorSample.a;
        }
        voxelCoord += deltaDirection;
        lengthAccumulator += stepLength;
        if (lengthAccumulator >= directionLength)
        {    
            colorAccumulator = colorAccumulator * alphaAccumulator 
                + (1 - alphaAccumulator) * backgroundColor.rgb;
            break;
        }    
        else if (alphaAccumulator > 1.0)
        {
            alphaAccumulator = 1.0;
            break;
        }
    }

    outColor = vec4(colorAccumulator, alphaAccumulator);
}
";
    }
}
