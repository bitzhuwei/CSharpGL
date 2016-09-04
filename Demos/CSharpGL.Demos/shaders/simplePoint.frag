#version 150 core

out vec4 out_Color;

uniform vec3 pointColor = vec3(1, 1, 1);

void main(){
	//outColor = vec4(pointColor, 1.0f);
	out_Color = vec4(1.0f, 0.0f, 1.0f, 1.0f);
}
