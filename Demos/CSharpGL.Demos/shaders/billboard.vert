#version 120

in vec3 in_Positions;

out vec2 UV;

uniform vec3 billboardCenter_worldspace; // Position of the center of the billboard
uniform vec3 CameraRight_worldspace;
uniform vec3 CameraUp_worldspace;
uniform vec2 BillboardSize; // Size of the billboard, in world units (probably meters)
uniform vec2 BillboardSizeInPercentage; // Size of the billboard, in percentage of screen units (probably meters)
uniform vec2 BillboardSizeInPixelSize; // Size of the billboard, in percentage of screen units (probably meters)
uniform vec2 ScreenSizeinPixelSize;
uniform mat4 projection;
uniform mat4 view;
uniform float billboardType = 0.0f;
void main()
{
	if (billboardType == 0.0f)// fixed pixel size
	{
		// Or, if BillboardSize is in pixels :
		//Same thing, just use (ScreenSizeInPixels / BillboardSizeInPixels) instead of BillboardSizeInScreenPercentage.
		gl_Position = projection * view * vec4(billboardCenter_worldspace, 1.0f); // Get the screen-space position of the particle's center
		gl_Position /= gl_Position.w; // Here we have to do the perspective division ourselves.
		gl_Position.xy += in_Positions.xy * BillboardSizeInPixelSize / ScreenSizeinPixelSize * 2; // Move the vertex in directly screen space. No need for CameraUp/Right_worlspace here.

	}
    else if (billboardType == 1.0f)// fixed physical size
	{
		vec3 vertexPosition_worldspace =
			billboardCenter_worldspace
			+ CameraRight_worldspace * in_Positions.x * BillboardSize.x
			+ CameraUp_worldspace * in_Positions.y * BillboardSize.y;

		gl_Position = projection * view * vec4(vertexPosition_worldspace, 1.0f);
	}
	else// if (billboardType == 2.0f)// percentage size of screen
	{
		// Or, if BillboardSize is in percentage of the screen size (vec2(1, 1) for fullscreen) :
		gl_Position = projection * view * vec4(billboardCenter_worldspace, 1.0f); // Get the screen-space position of the particle's center
		gl_Position /= gl_Position.w; // Here we have to do the perspective division ourselves.
		gl_Position.xy += in_Positions.xy * BillboardSizeInPercentage * 2; // Move the vertex in directly screen space. No need for CameraUp/Right_worlspace here.
	}


	// UV of the vertex. No special space for this one.
	UV = in_Positions.xy + vec2(0.5, 0.5);
}
