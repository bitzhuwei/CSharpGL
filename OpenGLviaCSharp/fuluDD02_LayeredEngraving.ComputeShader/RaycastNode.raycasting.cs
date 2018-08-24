using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fuluDD02_LayeredEngraving.ComputeShader
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

uniform float     stepLength = 0.001f;
uniform vec2      canvasSize;
uniform vec4      backgroundColor = vec4(0, 0, 0, 0);// value in glClearColor(value);
uniform int       cycle = 1600;

out vec4 FragColor;

void main()
{
    // ExitPointCoord is normalized device coordinate
    vec3 exitPoint = texture(texExitPoint, gl_FragCoord.st / canvasSize).xyz;
    // that will actually give you clip-space coordinates rather than
    // normalised device coordinates, since you're not performing the perspective
    // division which happens during the rasterisation process (between the vertex
    // shader and fragment shader
    // vec2 exitFragCoord = (ExitPointCoord.xy / ExitPointCoord.w + 1.0)/2.0;
    // vec3 exitPoint  = texture(texExitPoint, exitFragCoord).xyz;

    //background need no raycasting
    if (passEntryPoint == exitPoint) { discard; }

    vec3 direction = exitPoint - passEntryPoint;
    float directionLength = length(direction); // the length from front to back is calculated and used to terminate the ray
    vec3 deltaDirection = direction * (stepLength / directionLength);

    vec3 voxelCoord = passEntryPoint;
    vec3 colorAccumulator = vec3(0.0); // The dest color
    float alphaAccumulator = 0.0f;
    float lengthAccumulator = 0.0;
    vec3 intensity;
    vec4 colorSample; // The src color 
 
    for(int i = 0; i < cycle; i++)
    {
        // get scaler value in the volume data
        intensity = texture(texVolume, voxelCoord).rgb;
        // get mapped color from 1-D texture
        colorSample = vec4(intensity, 0.05);
        // modulate the value of colorSample.a
        // front-to-back integration
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
            break;  // terminate if opacity > 1 or the ray is outside the volume
        }    
        else if (alphaAccumulator > 1.0)
        {
            alphaAccumulator = 1.0;
            break;
        }
    }
    FragColor = vec4(colorAccumulator, alphaAccumulator);
    // for test
    // FragColor = vec4(passEntryPoint, 1.0);
    // FragColor = vec4(exitPoint, 1.0);
   
}
";
    }
}
