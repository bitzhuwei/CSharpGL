#version 120

// Input vertex data, different for all executions of this shader.
in vec3 in_Positions;

// Output data ; will be interpolated for each fragment.
varying vec2 UV;

// Values that stay constant for the whole mesh.
uniform vec3 CameraRight_worldspace;
uniform vec3 CameraUp_worldspace;
uniform mat4 projection;
uniform mat4 view;
uniform vec3 particleCenter_wordspace; // Position of the center of the billboard
uniform vec2 BillboardSize; // Size of the billboard, in world units (probably meters)

void main()
{
	vec3 vertexPosition_worldspace =
		particleCenter_wordspace
		+ CameraRight_worldspace * in_Positions.x * BillboardSize.x
		+ CameraUp_worldspace * in_Positions.y * BillboardSize.y;


	// Output position of the vertex
	gl_Position = projection * view * vec4(vertexPosition_worldspace, 1.0f);



	// Or, if BillboardSize is in percentage of the screen size (1,1 for fullscreen) :
	//vertexPosition_worldspace = particleCenter_wordspace;
	//gl_Position = VP * vec4(vertexPosition_worldspace, 1.0f); // Get the screen-space position of the particle's center
	//gl_Position /= gl_Position.w; // Here we have to do the perspective division ourselves.
	//gl_Position.xy += in_Positions.xy * vec2(0.2, 0.05); // Move the vertex in directly screen space. No need for CameraUp/Right_worlspace here.

	// Or, if BillboardSize is in pixels :
	// Same thing, just use (ScreenSizeInPixels / BillboardSizeInPixels) instead of BillboardSizeInScreenPercentage.


	// UV of the vertex. No special space for this one.
	UV = in_Positions.xy + vec2(0.5, 0.5);
}
