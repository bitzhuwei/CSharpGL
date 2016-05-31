#version 400

in vec3 passEntryPoint;

uniform sampler2D ExitPoints;
uniform sampler3D VolumeTex;
uniform sampler1D TransferFunc;  
uniform float     StepSize = 0.001f;
uniform vec2      ScreenSize;
uniform vec4      backgroundColor = vec4(0, 0, 0, 0);// value in glClearColor(value);
layout (location = 0) out vec4 FragColor;

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
 
    for(int i = 0; i < 1600; i++)
    {
        // get scaler value in the volume data
        intensity =  texture(VolumeTex, voxelCoord).x;
        // get mapped color from 1-D texture
        colorSample = texture(TransferFunc, intensity);
        // modulate the value of colorSample.a
        // front-to-back integration
        if (colorSample.a > 0.0) {
            // accomodate for variable sampling rates (base interval defined by mod_compositing.frag)
            colorSample.a = 1.0 - pow(1.0 - colorSample.a, StepSize * 200.0f);
            colorAccumulator += (1.0 - alphaAccumulator) * colorSample.rgb * colorSample.a;
            alphaAccumulator += (1.0 - alphaAccumulator) * colorSample.a;
        }
        voxelCoord += deltaDirection;
        lengthAccumulator += StepSize;
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
