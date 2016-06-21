# CSharpGL
* CSharpGL允许你以面向对象的方式使用OpenGL的功能。  
* 封装了OpenGL的函数，用枚举代替部分uint参数。  
* 提取出OpenGL中隐含的对象，用class描述他们。  
* 提供矩阵、向量相关的数学类。  
* 提供实用的公用class、扩展方法。  
* 用C#编写GLSL代码。  

# CSharpGL
* CSharpGL allows you to use OpenGL functions in the Object-Oriented way.  
* It wraps OpenGL’s functions and use enum type as parameters instead of ‘uint’for some functions.  
* It abstracts objects inside OpenGL and describes them as classes.  
* It provides maths class for matrix and vectors.  
* It provide useful utilities.  
* Write GLSL shade in C#.  

# release notes:
## v1.0.4.8:
1. SceneObject maintains a list of script components.
2. Generic List Editor for different list types.
3. Move item up/down in generic list editor.
4. Display uniform variable's location in property grid.
5. Add ItemAdded/ItemRemoved events.
6. Explicit implement of ITreeNode<SceneObject> for SceneObject.
7. Remove the complex error-prone relative transform properties.

## v1.0.4.7:
1. Enable/Disable SceneObject controls whether it takes part in rendering and updating.
2. SceneObject's transform(position/scale/rotation) is updated according to parent/child relation then to script component.
3. Sphere supports uv mapping attribute.
4. SatelliteManipulater manipulates camera's posiiton, rotation and distance to target. Camera acts like a sateliite moving around its target when manipulated by SatelliteManipulater.
5. Rename vec2/vec3/vec4.Magnitude() -> length().
6. LabelRenderer renders a text label in 3D world space. The text can be updated in runtime.
7. Fix bug: teapot's face property buffer.
8. Fix bug: FontResource should provide seperate default instances for different render contexts.

## v1.0.4.6:
1. FormSelectType loads specified types from all loaded assemblies and cache them.
2. TransformCompoent and ScriptComponent works simiar to those in Unity.

## v1.0.4.5:
1. Scene object and components learnt from Unity.
2. UITypeEditor for Camera, Scene types.
3. OpenGLVersion Only works in design mode.
4. No need check value type for UniformValue in release mode.
5. Add Cube, Sphere and Ground as buil-in Scene-Object.
6. Update color algorithm for cube and sphere.
7. Remove unnecessary versions of GetViewMat4().
8. FirstPerspectiveManipulater allows for move camera by key event and mouse event.

## v1.0.4.2:
1. Stronger Camera class: Get directions.
2. Faster glm.lookAt().
3. CSSL integrates all build-in funcitons from GLSL shader pdf(not into CSharpGL)
4. Easier to use GLControl as root UI renderer.(Auto-bind to canvas' resize event)
5. Clean interface and implementation for FontResource.
6. Update frame buffer constants.
7. Remove unused resources(teapot.obj etc.) to reduce CSharpGL.dll's file size.
8. internal fields of mat2/mat3/mat4 for better performance.

## v1.0.4.1:
1. integrate all uniform variables and array variables inheriting from UniformVariable.

## v1.0.4.0:
1. Renderer supports setup uniform array variable.(uniform vec3 positions[10];)
2. Different kinds of uniform arrays: float[], vec2[], vec3[], vec4[], mat2[], mat3[],mat4[], samplerValue[].

## v1.0.3.0:
1. Get a Font Resource from TTF files.
2. Font Resource supports rendering text.

## v1.0.2.0:
1. GLControls allows for control-style objects.
2. A GLAxis and GLText control.
3. More OpenGL switches and uniforms.

## v1.0.1.0:
1. Only pickable Renderer check if position buffer's DataSize is 3.
2. Adjust camera's default settings.
3. OneIndexBufferPtr can controls the first element to be rendered.

## v1.0.0.9:
1. supports picking of point, line and basic geometry(triangle, quad, polygon) from any kind of OneIndexRenderer or ZeroIndexRenderer.
2. rename *ModernRenderer*.cs to *Renderer*.cs
3. fix bug in QuadStripRecoginzer: reorder its vertexs to form a quad.(0 1 2 3 -> 0 1 3 2)

## v1.0.0.2:
1. add model: BigDipper, Tetrahedron, Cube, Sphere, Teapot.

## v1.0.0.1:
1. Modern rendering(Shader+VBO).
2. Color-coded-picking of primitives in a VBO.
3. Highlight picked primitives.
4. Draw text using glRasterPos() and CallList.
5. PolygonOffsetSwitch.
6. UILayout.

