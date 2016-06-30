# CSharpGL
CSharpGL is a pure C# project that allows for modern OpenGL rendering in an Object-Oriented way. 
It meets common requirements in OpenGL rendering such as: 
* modern rendering using GLSL shaders and vertex buffer objects;
* a winform control that wraps initialization of creating OpenGL context;
* structs support setting values for uniform variables in GLSL shader;
* OpenGL state switch wrappers;
* picking primitives in multiple vertex buffer objects;
* rendering text using build-in GLText object in 3D space world or UI(window space);
* a scene editor;
* different kinds of demonstrations to use CSharpGL.

For more information please check (http://bitzhuwei.github.io/CSharpGL/)

# release notes:
## v1.0.4.10:
1. Simpler Scene: remove useless UIRootRendererComponent; UIRoot rendering ui for Scene.
2. PositionHelper.Move2Center() supports vec2.
3. Retarget CSharpGL's .net version to .net3.5.
4. Fix bug in ILyaout.NonRootNodeLayout().
5. Remove SatelliteRotator.
6. Rename RenderEventArgs to RenderEventArg.
7. mat4Helper converts float array to mat4.
8. Fix bug in get delegate for OpenGL command.(Use proc.ToInt64() instead of proc.ToInt32())
9. Camera manipulaters using mouse/keyboard.
10. Better performance: reading GL_DEPTH_COMPONENT to make sure something is picked.
11. ChildList<T> represents children in ITreeNode<T>.
12. IndexBufferPtrEditor displays controller for update parameters for glDrawArrays() or glDrawElements().
13: Release bind element buffer in OneIndexBufferPtr.
14. Comment debug lines in FontResource.

14. TextModel allows for updating text property.
## v1.0.4.9:
1. 3 PolygonOffsetSwitch types for Fill, Line and Point.
2. remove unnecessary initialization of creating PrimitiveRestartSwitch for OneIndexRenderer.
3. Rename GLRoot/GLAxis/GLText to UIRoot/UIAxis/UIText.
4. UI types manage its uniform variables inside.
5. ILayout derived from ITreeNode<UIRenderer>.
6. UIRoot auto-layout before rendering.
7. UIRendererComponent manages UI objects in the Scene.
8. FormIListEditor supports creating instance with parameters.
9. PositionHelper.Move2Center() operates on input parameters.

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

