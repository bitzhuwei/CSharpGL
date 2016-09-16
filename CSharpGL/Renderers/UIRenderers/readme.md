在窗口上渲染UI样式的东西。坐标系，文字等。
RULE: 用于渲染UI元素的模型，其范围最好是在(-0.5, -0.5, -0.5)到(-0.5, -0.5, -0.5)之间，即保持其边长为1，且位于坐标系中心。这样，就可以用mat4 model = glm.scale(mat4.identity(), new vec3(this.Size.Width, this.Size.Height, 1));来设定其缩放比例了。简单方便。
