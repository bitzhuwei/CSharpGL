# :art:Welcome to CSharpGL
[CSharpGL](https://github.com/bitzhuwei/CSharpGL) is a pure C# project that allows for modern OpenGL rendering in a Object-Oriented way. It meets common requirements in OpenGL rendering such as:
## :rocket:Modern Rendering
Objected-Oriented modern rendering using GLSL shaders and vertex buffer objects.
![modern-rendering](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/modern-rendering.jpg?raw=true)
## :stars:GLCanvas
A winform control that supports drag-drop and wraps initialization of creating OpenGL context.
![raycast-volume-rendering](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/GLCanvas.gif?raw=true)
## :car:Uniform Variables
structs support setting values for uniform variables in GLSL shader.
![edit-uniform-value](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/edit-uniform-value.jpg?raw=true)
## :cancer:GLSwitch
Wraps OpenGL commands like 
```
glEnable(GL_BLEND);
glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_DST_ALPHA);
...
glDisable(GL_BLEND);
```
or
``glLineWidth(2.0f);``
![GLSwitch](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/GLSwitch.jpg?raw=true)
## :movie_camera:Camera and Rotator
Get projection and view matrix by moving or rotating camera.
## :pushpin:Color-Coded Picking
PickableRenderer supports picking primitives in multiple vertex buffer objects using Mouse.  
![pick and move primitive](http://images2015.cnblogs.com/blog/383191/201605/383191-20160503191610388-117673971.gif)
## :slot_machine:GLControl
Rendering 'Control' at fixed position with fixed size. For example, GLAxis renders an axis at left bottom corner.
'Control' binding to specified border just like winform-control.
## :abcd::curly_loop::ideograph_advantage:Text
Rendering text using ``glRasterPos()`` and ``CallList()``.
Rendering text using GLText(a special GLControl).
Load True Type Font File(*.ttf or *.otf) to build a texture filled with glyphs, which then could be used to render text.
The project CSharpGL.Font2Picture in :open_file_folder:`Infrastructure` is a quick tool converting TTF files to pictures along with a xml config file.
![export-glyph-texture-from-TTF](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/glyph-texture.png?raw=true)
## :tea:Some Models
A Cube, Sphere, Teapot and some other models.
![cube](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/cube.png?raw=true)
![sphere](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/sphere.png?raw=true)
![teapot](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/teapot.png?raw=true)
![axis](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/axis.png?raw=true)
# :gem:Some Cool Demos
## Image processing using compute shader.
![compute-shader-image-processing](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/compute-shader-edge-detection.gif?raw=true)
## Raycast volume rendering.
![raycast-volume-rendering](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/raycast-volume-render.gif?raw=true)
## Particle simulator using compute shader.
![compute-shader-particles](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/compute-shader-particles.gif?raw=true)
## Order-independent transparency VS Order-denpendent transparency.
![order-independent-transparency](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/order-independent-transparency.jpg?raw=true)
## Point sprite.
10000 particles with a sphere insied a cube.
![point-sprite](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/point-sprite.jpg?raw=true)
## earth.
An earth model that singly rotate same as real earth. It's composed of 65341 positions, normals and uvs and 130140 indexes and a 10800x5400 texture.
![earth](https://github.com/bitzhuwei/CSharpGL/blob/gh-pages/images/CSharpGL/earth.gif?raw=true)
# :question:Support or Contact
Check my blog [here](http://www.cnblogs.com/bitzhuwei/) if you are familiar with Chinese.
