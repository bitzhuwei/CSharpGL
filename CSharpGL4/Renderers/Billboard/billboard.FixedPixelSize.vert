#version 120

in vec3 in_Positions;

out vec2 UV;

uniform vec3 billboardCenter_worldspace; // Position of the center of the billboard
uniform ivec2 BillboardSizeInPixelSize; // Size of the billboard, in percentage of screen units (probably meters)
uniform vec2 ScreenSizeinPixelSize;
uniform mat4 projection;
uniform mat4 view;
void main()
{
	gl_Position = projection * view * vec4(billboardCenter_worldspace, 1.0f); // Get the screen-space position of the particle's center
	gl_Position /= gl_Position.w; // Here we have to do the perspective division ourselves.
	gl_Position.xy += in_Positions.xy * BillboardSizeInPixelSize / ScreenSizeinPixelSize * 2; // Move the vertex in directly screen space. No need for CameraUp/Right_worlspace here.

	// UV of the vertex. No special space for this one.
	UV = in_Positions.xy + vec2(0.5, 0.5);
}
