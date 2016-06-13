#version 120

in vec3 in_Positions;

out vec2 UV;

uniform vec3 billboardCenter_worldspace; // Position of the center of the billboard
uniform vec3 CameraRight_worldspace;
uniform vec3 CameraUp_worldspace;
uniform vec2 BillboardSize; // Size of the billboard, in world units (probably meters)
uniform mat4 projection;
uniform mat4 view;

void main()
{
	vec3 vertexPosition_worldspace =
		billboardCenter_worldspace
		+ CameraRight_worldspace * in_Positions.x * BillboardSize.x
		+ CameraUp_worldspace * in_Positions.y * BillboardSize.y;

	gl_Position = projection * view * vec4(vertexPosition_worldspace, 1.0f);

	// Or, if BillboardSize is in percentage of the screen size (vec2(1, 1) for fullscreen) :
	//vertexPosition_worldspace = billboardCenter_worldspace;
	//gl_Position = VP * vec4(vertexPosition_worldspace, 1.0f); // Get the screen-space position of the particle's center
	//gl_Position /= gl_Position.w; // Here we have to do the perspective division ourselves.
	//gl_Position.xy += in_Positions.xy * vec2(0.2, 0.05); // Move the vertex in directly screen space. No need for CameraUp/Right_worlspace here.

	// Or, if BillboardSize is in pixels :
	// Same thing, just use (ScreenSizeInPixels / BillboardSizeInPixels) instead of BillboardSizeInScreenPercentage.


	// UV of the vertex. No special space for this one.
	UV = in_Positions.xy + vec2(0.5, 0.5);
}
