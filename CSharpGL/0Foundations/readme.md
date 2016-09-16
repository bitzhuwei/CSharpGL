# 基础
这个文件夹里写的都是OpenGL的概念。CSharpGL所涉及的所有OpenGL知识点，都被封装为enum, struct, interface, class代码。这些知识点包含在类型的名字上；包含在方法的名字上；包含在类型的继承关系上；包含在所有的注释上。
# OpenGL 对象
## Shader
一个Shader就是在GPU上运行的一小段（也许并不小）类C代码。  
现代OpenGL的渲染是建立在GLSL的shader基础上的。Shader工作在OpenGL渲染管线的各自的阶段上。这些阶段如何是施展全看你的shader怎么写。
## Buffers
`Buffer` and `BufferPtr` 是对OpenGL的Buffer对象的封装。一个Buffer对象本质上是从CPU内存上传到GPU内存的一个数组。
OpenGL中执行渲染的指令是`glDrawArrays()`和`glDrawElemtns()`以及他们的高级变种版本。如果你想从零开始学OpenGL，也许可以首先围绕这两个指令开始。
## 摄像机
摄像机是在世界坐标系下的一个特殊的物体。  
摄像机把模型的坐标从世界坐标系转换到camera/view/eye坐标系。
## uniform变量
`UniformVariable`封装了shader里的uniform变量（例如`uniform vec3 vPosition;`）。`UniformVariable`在`Renderer`里用于为uniform变量指定值。
# OpenGL开关
OpenGL是个状态机。`GLSwitch`就是控制其状态的。  
例如`LineWidthSwitch`控制线的宽度。在渲染前将线宽设置为指定的宽度，在渲染后恢复到原来的宽度。  
这可以避免忘记恢复原有状态的bug。
## Rendering
`Renderer`用Modern OpenGL(VBO+Shader)进行渲染。以`IBufferable`为模型数据，以`ShaderCode`为shader数据，以`PropertyNameMap`为两者之间的关联关系。可自定义开关（`GLSwtich`）。可自定义uniform变量。
## 其他
纹理、甄嬛穿、查询对象等等，在你学会上述内容之后就仅仅是一些很简单的概念而已。

# Foundations
OpenGL concepts lays in this folder. All basic OpenGL knowledge included in CSharpGL are wrapped into types(enum, interface, struct, class). It exists in type's names, method's names, inheritance relationships, and all comments.
# OpenGL Objects
## Shader
A shader is a small(maybe not that small) piece of C-like code that executes on GPU.  
Moddern OpenGL rendering is built on GLSL shader. Shaders works on their own stage in OpenGL rendering pipeline. It's all up to you how that stage works.
## Buffers
`Buffer` and `BufferPtr` wraps buffer object in OpenGL. A buffer object is essentially an array uploaded to GPU memory from CPU memory.  
The actual rendering command in OpenGL is `glDrawArrays()` and `glDrawElemtns()` and their advanced versions. If you want to learn OpenGL from Scratch, maybe your first choise is to focus on these two commands.  
## Camera
Camera is a special object in world space.  
Camera transforms object's world coordinate to camera/view/eye coordiate.
## Uniform Variable
`UniformVariable` wraps uniform variables in shader like `uniform vec3 vPosition;`. `UniformVariable` is used in `Renderer` to setup uniform variables.
# OpenGL switch
OpenGL works as a state machine. `GLSwitch` controls one of states in OpenGL.  
For example, `LineWidthSwitch` controls line's width. It sets line's width to specified value before rendering, and reset it to original value after rendering.  
This could prevent future bugs about forgetting to reset to original state.
## Rendering
`Renderer` renders a model with VBO and shaders. `IBufferable` provides model's data. `ShaderCode' provides shader code. `PropertyNameMap` provides mapping relations between model data and shader's variables. Differen kinds of `GLSwitch` and uniform variables are supported.
## Other stuff
Texture, framebuffer, query object are simple concepts after you've learnt everything metioned above.
