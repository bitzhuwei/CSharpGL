// Vertex Shader
#version 450 core

layout(local_size_x = 256) in;

// 输入的 Sparse 数据
layout(std430, binding = 0) buffer Indices {
    uint indices[];
};

layout(std430, binding = 1) buffer Values {
    float values[];
};

// 默认顶点属性
layout(location = 0) in vec3 inPosition;
layout(location = 1) in vec3 defaultColor;

// 输出到 Fragment Shader
out vec3 fragColor;

void main()
{
    // 查找当前顶点是否有 Sparse 更新
    vec3 finalPos = inPosition;
    
    // 遍历 Sparse 索引（实际需优化为二分查找）
    for (int i = 0; i < indices.length(); i++) {
        if (indices[i] == gl.gl_VertexID) {
            finalPos = vec3(values[i*3], values[i*3+1], values[i*3+2]);
            break;
        }
    }
    
    // 其他顶点处理...
    gl_Position = vec4(finalPos, 1.0);
}