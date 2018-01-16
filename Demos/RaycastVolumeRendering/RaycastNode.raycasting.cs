using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaycastVolumeRendering
{
    public partial class RaycastNode
    {
        private const string raycastingVert = @"#version 150

in vec3 position;
// have to use this variable!!!, or it will be very hard to debug for AMD video card
in vec3 boundingBox;  

out vec3 passEntryPoint;

uniform mat4 MVP;

void main()
{
    passEntryPoint = boundingBox;
    gl_Position = MVP * vec4(position, 1.0);
}
";
        private const string raycastingFrag = @"#version 150

in vec3 passEntryPoint;

uniform sampler1D TransferFunc;
uniform sampler2D ExitPoints;
uniform sampler3D VolumeTex;

uniform float     StepSize = 0.001f;
uniform vec2      ScreenSize;
uniform vec4      backgroundColor = vec4(0, 0, 0, 0);// value in glClearColor(value);

out vec4 FragColor;

void main()
{
    // ExitPointCoord is normalized device coordinate
    vec3 exitPoint = texture(ExitPoints, gl_FragCoord.st / ScreenSize).xyz;
    // that will actually give you clip-space coordinates rather than
    // normalised device coordinates, since you're not performing the perspective
    // division which happens during the rasterisation process (between the vertex
    // shader and fragment shader
    // vec2 exitFragCoord = (ExitPointCoord.xy / ExitPointCoord.w + 1.0)/2.0;
    // vec3 exitPoint  = texture(ExitPoints, exitFragCoord).xyz;

    //background need no raycasting
    if (passEntryPoint == exitPoint) { discard; }

    vec3 direction = exitPoint - passEntryPoint;
    float directionLength = length(direction); // the length from front to back is calculated and used to terminate the ray
    vec3 deltaDirection = direction * (StepSize / directionLength);

    vec3 voxelCoord = passEntryPoint;
    vec3 colorAccumulator = vec3(0.0); // The dest color
    float alphaAccumulator = 0.0f;
    float lengthAccumulator = 0.0;
    float intensity;
    vec4 colorSample; // The src color 
 
   // get scaler value in the volume data
        intensity =  texture(VolumeTex, voxelCoord).x;
        // get mapped color from 1-D texture
        colorSample = texture(TransferFunc, intensity);
    if (colorSample.a > 0)
    {
        FragColor = colorSample;
    }
    else
    {
        discard;
    }
}

";
    }
}
