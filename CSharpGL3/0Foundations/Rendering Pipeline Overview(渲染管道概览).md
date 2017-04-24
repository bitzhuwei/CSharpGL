**CSharpGL(31)[译]OpenGL渲染管道那些事**

# 开始

自认为对OpenGL的掌握到了一个小瓶颈，现在回头细细地捋一遍OpenGL渲染管道应当是一个不错的突破口。

本文通过阅读、翻译和扩展（[https://www.opengl.org/wiki/Rendering_Pipeline_Overview](https://www.opengl.org/wiki/Rendering_Pipeline_Overview)）的方式，来逐步回顾总结一下OpenGL渲染管道，从而串联起OpenGL的所有知识点，并期望能在更高的层次上有所领悟。

另外，（[https://www.opengl.org/wiki/Rendering_Pipeline_Overview](https://www.opengl.org/wiki/Rendering_Pipeline_Overview)）涉及的链接，我也会视情况翻译一下，琢磨一下。

为了方便对比，这里保留了英文。

下面开始吧。

//////////////////////////////////////////////////////////////////////////////////////////

# Rendering Pipeline Overview(渲染管道概览)

From OpenGL.org

Jump to: [navigation](https://www.opengl.org/wiki/Rendering_Pipeline_Overview#mw-head), [search](https://www.opengl.org/wiki/Rendering_Pipeline_Overview#p-search)





The **Rendering Pipeline** is the sequence of steps that OpenGL takes when rendering objects. This overview will provide a high-level description of the steps in the pipeline.

**渲染管道**是OpenGL在渲染物体时执行的一系列**步骤（阶段）**。本文将从一个较高的层次描述这些步骤（阶段）。

# Pipeline(管道)



Diagram of the Rendering Pipeline. The blue boxes are programmable shader stages.(渲染管道总图。蓝底色的是可编程shader阶段)

The OpenGL rendering pipeline works in the following order: (OpenGL渲染管道的各个阶段按下述顺序依次执行)

1.  [Prepare vertex array data,](https://www.opengl.org/wiki/Vertex_Specification "Vertex Specification") and then [render it](https://www.opengl.org/wiki/Vertex_Rendering "Vertex Rendering")(准备顶点数据，然后渲染之)
2.  [Vertex Processing](https://www.opengl.org/wiki/Vertex_Processing "Vertex Processing"): (对顶点的处理)

1.  Each vertex is acted upon by a [Vertex Shader](https://www.opengl.org/wiki/Vertex_Shader "Vertex Shader"). Each vertex in the stream is processed in turn into an output vertex.(每个顶点都由一个顶点着色器控制。顶点缓存中的各个顶点依次被转换为一个输出顶点，即由`gl_Position = xxx;`设定输出值。)
2.  Optional primitive [tessellation stages](https://www.opengl.org/wiki/Tessellation "Tessellation").(可选的**图元细分**阶段)
3.  Optional [Geometry Shader](https://www.opengl.org/wiki/Geometry_Shader "Geometry Shader") primitive processing. The output is a sequence of primitives.(可选的**几何着色器**处理阶段，其输出为一系列**图元**。)3.  [Vertex Post-Processing](https://www.opengl.org/wiki/Vertex_Post-Processing "Vertex Post-Processing"), the outputs of the last stage are adjusted or shipped to different locations. (顶点后处理，这一步骤的处理结果可能被送到不同的地方去，比如：)

1.  [Transform Feedback](https://www.opengl.org/wiki/Transform_Feedback "Transform Feedback") happens here.(Transform Feedback在此发动。)
2.  Primitive [Clipping](https://www.opengl.org/wiki/Clipping "Clipping"), the [perspective divide](https://www.opengl.org/wiki/Perspective_Divide "Perspective Divide"), and the [viewport transform](https://www.opengl.org/wiki/Viewport_Transform "Viewport Transform") to window space.(图元裁剪，视角除法，还有把**视口**变换到**窗口空间**。)4.  [Primitive Assembly](https://www.opengl.org/wiki/Primitive_Assembly "Primitive Assembly")(图元组装)
5.  [Scan conversion and primitive parameter interpolation](https://www.opengl.org/wiki/Rasterization "Rasterization"), which generates a number of [Fragments](https://www.opengl.org/wiki/Fragment "Fragment").(扫描转换和图元插值)
6.  A [Fragment Shader](https://www.opengl.org/wiki/Fragment_Shader "Fragment Shader") processes each fragment. Each fragment generates a number of outputs.(一个**片段着色器**处理每个**片段**。每个片段都产生若干输出数据。)
7.  [Per-Sample_Processing](https://www.opengl.org/wiki/Per-Sample_Processing "Per-Sample Processing"): (逐采样的处理)

# Vertex
Specification(准备顶点数据)

_Main article: [Vertex Specification](https://www.opengl.org/wiki/Vertex_Specification "Vertex Specification")(__更多资讯，点击__[Vertex Specification](https://www.opengl.org/wiki/Vertex_Specification "Vertex Specification"))_

The process of vertex
specification is where the application sets up an ordered list of vertices to
send to the pipeline. These vertices define the boundaries of a _primitive_.

所谓准备顶点数据，就是应用程序创建一个数组，里面写入各个顶点的信息（位置、颜色、法线等等），然后发送(glBufferData)到OpenGL管道。这些顶点就组成了若干个**_图元_**。

Primitives are basic drawing
shapes, like triangles, lines, and points. Exactly how the list of vertices is
interpreted as primitives is handled via a later stage.

图元是OpenGL能画的最基本的图形，比如三角形、线段和点。后续步骤会解决**如何解释这些顶点**的问题。

This part of the pipeline deals
with a number of objects like [Vertex Array Objects](https://www.opengl.org/wiki/Vertex_Array_Objects "Vertex Array Objects") and [Vertex Buffer Objects](https://www.opengl.org/wiki/Vertex_Buffer_Objects "Vertex Buffer Objects"). Vertex Array Objects
define what data each vertex has, while Vertex Buffer Objects store the actual
vertex data itself.

这部分的管道会和[Vertex Array Objects](https://www.opengl.org/wiki/Vertex_Array_Objects "Vertex Array Objects")、[Vertex Buffer Objects](https://www.opengl.org/wiki/Vertex_Buffer_Objects "Vertex Buffer Objects")打交道。Vertex Array Objects定义了顶点由哪些Vertex Buffer Objects组成,Vertex Buffer Objects则定义了具体的顶点数据。

A vertex's data is a series of [attributes](https://www.opengl.org/wiki/Vertex_Attributes "Vertex Attributes").
Each attribute is a small set of data that the next stage will do computations
on. While a set of attributes do specify a vertex, there is nothing that says
that part of a vertex's attribute set needs to be a position or normal.
Attribute data is entirely arbitrary; the only meaning assigned to any of it
happens in the vertex processing stage.

顶点数据就是若干个**属性**。顶点的位置、颜色、法线都是顶点的属性，你还可以根据需要自定义任何属性。每个属性都是一个数组（或者数组里的一部分），在后续阶段会对之执行计算（用shader程序计算）。也只有在这些计算阶段里，这些属性才有应用层面上的含义。

## Vertex
Rendering(顶点渲染)

_Main article: [Vertex
Rendering](https://www.opengl.org/wiki/Vertex_Rendering "Vertex Rendering")(__更多资讯，点击__[Vertex Rendering](https://www.opengl.org/wiki/Vertex_Rendering "Vertex Rendering"))_

Once the vertex data is properly
specified, it is then rendered as a [Primitive](https://www.opengl.org/wiki/Primitive "Primitive") via
a drawing command.

准备好了顶点数据，就可以通过**_绘制指令_**将其渲染为图元了。

# Vertex
Processing(顶点处理)

Vertices fetched due to the prior
vertex rendering stage begin their processing here. The vertex processing
stages are almost all [programmable operations](https://www.opengl.org/wiki/Shader "Shader"). This allows user code to customize
the way vertices are processed. Each stage represents a different kind of
shader operation.

前面拿到了顶点数据，现在开始处理数据。处理顶点的各个步骤几乎全部是可编程的操作。因此用户（OpenGL程序员）可以自行决定顶点的处理方式。顶点处理的每个步骤都代表着一个shader。

Many of these stages are
optional.

这些步骤中，很多都是可选的。（目测只有1种shader是必选的）

## Vertex
shader(顶点着色器)

_Main article: [Vertex
Shader](https://www.opengl.org/wiki/Vertex_Shader "Vertex Shader")(__更多资讯，点击__[Vertex
Shader](https://www.opengl.org/wiki/Vertex_Shader "Vertex Shader"))_

Vertex shaders perform basic
processing of each individual vertex. Vertex shaders receive the attribute
inputs from the vertex rendering and converts each incoming vertex into a
single outgoing vertex based on an arbitrary, [user-defined program](https://www.opengl.org/wiki/Shader "Shader").

**顶点着色器**针对每个顶点施展相互独立的处理。顶点着色器以顶点的所有**属性**作为输入，输出的是gl_Position和其他可选的数据。输入到输出的程序代码完全是用户（OpenGL程序员）编写的。

Vertex shaders can have
user-defined outputs, but there is also a special output that represents the
final position of the vertex. If there are no subsequent vertex processing
stages, vertex shaders are expected to fill in this position with the
clip-space position of the vertex, for rendering purposes.

刚刚说到顶点着色器可以有若干可选的输出数据，另外还有一个特殊的输出gl_Position（顶点的最终位置）。如果不启用后续的顶点处理步骤，那么顶点处理器就必须写入gl_Position（顶点在**_裁剪空间_**下的位置）。

One limitation on vertex
processing is that each input vertex _must_ map to a specific output
vertex. And because [vertex shader invocations](https://www.opengl.org/wiki/Shader_Invocation "Shader Invocation") cannot share state
between them, the input attributes to output vertex data mapping is 1:1. That
is, if you feed the exact same attributes to the same vertex shader in the same
primitive, you will get the same output vertex data. This gives implementations
the right to optimize vertex processing; if they can detect that they're about
to process a previously processed vertex, they can use the previously processed
data stored in a [post-transform cache](https://www.opengl.org/wiki/Post_Transform_Cache "Post Transform Cache"). Thus they do not have to
run the vertex processing on that data again.

关于顶点处理的一个限制是：输入一个顶点必须对应输出一个顶点。由于顶点着色器针对各个顶点的调用过程都是互相不能共享任何信息、状态的，输入的属性值和输出的顶点数据之间也是一一映射关系。这就是说，如果你给顶点着色器的相同的输入，你会得到完全相同的输出。这就使得**_OpenGL实现_**（显卡或软渲染程序）可以优化顶点处理过程：如果OpenGL检测到它即将处理一个曾经处理过的完全相同的顶点数据，它就可以直接使用缓存在[post-transform cache](https://www.opengl.org/wiki/Post_Transform_Cache "Post Transform Cache")里的结果。因此OpenGL就可以少执行一次顶点着色器程序了。

Vertex shaders are not optional.

顶点着色器是必选的。

## Tessellation(曲面细分)

<table style="width: 352px;" border="1" cellspacing="5" cellpadding="0">
  <tbody>
    <tr>
      <td colspan="3">

        **Tessellation**

      </td>

    </tr>
    <tr>
      <td></td>
      <td></td>
      <td width="16"></td>

    </tr>
    <tr>
      <td colspan="2" valign="top">

        **Core in version**

      </td>
      <td valign="top">

        4.5

      </td>

    </tr>
    <tr>
      <td colspan="2" valign="top">

        **Core since version**

      </td>
      <td valign="top">

        4.0

      </td>

    </tr>
    <tr>
      <td valign="top">

        **Core ARB extension**

      </td>
      <td colspan="2" valign="top">

        [ARB_tessellation_shader](http://www.opengl.org/registry/specs/ARB/tessellation_shader.txt)

      </td>

    </tr>

  </tbody>

</table>

_Main article: [Tessellation Shader](https://www.opengl.org/wiki/Tessellation_Shader "Tessellation Shader")(__更多资讯，点击__[Tessellation Shader](https://www.opengl.org/wiki/Tessellation_Shader "Tessellation Shader"))_

Primitives can be tessellated
using two shader stages and a fixed-function tessellator between them. The [Tessellation Control Shader](https://www.opengl.org/wiki/Tessellation_Control_Shader "Tessellation Control Shader") (TCS) stage
comes first, and it determines the amount of tessellation to apply to a
primitive, as well as ensuring connectivity between adjacent tessellated primitives.
The [Tessellation Evaluation Shader](https://www.opengl.org/wiki/Tessellation_Evaluation_Shader "Tessellation Evaluation Shader") (TES)
stage comes last, and it applies the interpolation or other operations used to
compute user-defined data values for primitives generated by the fixed-function
tessellation process.

顶点可以被细分，靠的是两个shader步骤及其之间的一个固定功能tessellator（原谅我不知道怎么翻译这个词）。首先是[Tessellation Control Shader](https://www.opengl.org/wiki/Tessellation_Control_Shader "Tessellation Control Shader")（TCS），它决定了一个图元被细分成多少块，并且确保互联的图元之间的关联关系（什么意思？）。然后是[Tessellation Evaluation Shader](https://www.opengl.org/wiki/Tessellation_Evaluation_Shader "Tessellation Evaluation Shader")（TES），它执行插值或者其他操作，最终计算出细分的图元数据。

Tessellation as a process is
optional. Tessellation is considered active if a TES is active. The TCS is
optional, but a TCS can only be used alongside a TES.

**曲面细分**是可选的。启用TES就等于启用了曲面细分。TCS是可选的，但TCS只能陪伴着TES出现。

## Geometry
Shader(几何着色器)

_Main article: [Geometry
Shader](https://www.opengl.org/wiki/Geometry_Shader "Geometry Shader")(__更多资讯，点击__[Geometry Shader](https://www.opengl.org/wiki/Geometry_Shader "Geometry Shader"))_

Geometry shaders are user-defined
programs that process each incoming primitive, returning zero or more output
primitives.

**几何着色器**的输入数据是一个**图元**，输出是0~多个图元。

The input primitives for geometry
shaders are the output primitives from a subset of the [Primitive
Assembly](https://www.opengl.org/wiki/Primitive_Assembly "Primitive Assembly") process. So if you send a triangle strip as a single primitive,
what the geometry shader will see is a series of triangles.

几何着色器的输入图元的类型是**图元组装**步骤的一个子集。所以当你将**_三角形带_**作为一个单独的图元输送给几何着色器时，它会将其视作若干个**_三角形_**。

However, there are a number of
input primitive types that are defined specifically for geometry shaders. These
adjacency primitives give GS's a larger view of the primitives; they provide
access to vertices of primitives adjacent to the current one.

不过，有几个图元类型是几何着色器特有的。**_邻接图元_**给了GS更大的选择范围，它们提供了对与当前图元相邻的图元的处理方法。

The output of a GS is zero or
more simple primitives, much like the output of primitive assembly. The GS is
able to remove primitives, or tessellate them by outputting many primitives for
a single input. The GS can also tinker with the vertex values themselves,
either doing some of the work for the vertex shader, or just to interpolate the
values when tessellating them. Geometry shaders can even convert primitives to
different types; input point primitives can become triangles, or lines can
become points.

几何着色器的输出是0~多个图元，这很像图元组装阶段的输出。几何着色器可以去掉原有的图元（其实，原有的图元是一定被去掉了），可以通过输出更多图元的方式来细分之。几何着色器也可以胡乱地修补顶点数据：要么接手顶点着色器的部分任务，要么通过插值的方式细分图元。几何着色器还可以把图元转换为另一种图元：输入点，输出三角形；输入线段，输出点；等等。

Geometry shaders are optional.

几何着色器是可选的。

# Vertex
post-processing(顶点后处理)

_Main article: [Vertex Post-Processing](https://www.opengl.org/wiki/Vertex_Post-Processing "Vertex Post-Processing")(__更多资讯，点击__[Vertex Post-Processing](https://www.opengl.org/wiki/Vertex_Post-Processing "Vertex Post-Processing"))_

After the shader-based vertex
processing, vertices undergo a number of fixed-function processing steps.

在基于shader的顶点处理之后，顶点还要经历一系列的**固定管道**处理阶段。

## Transform
Feedback(这个术语还是不翻译的好)

_Main article: [Transform
Feedback](https://www.opengl.org/wiki/Transform_Feedback "Transform Feedback")(__更多资讯，点击__[Transform Feedback](https://www.opengl.org/wiki/Transform_Feedback "Transform Feedback"))_

The outputs of the geometry
shader or primitive assembly are written to a series of [buffer
objects](https://www.opengl.org/wiki/Buffer_Objects "Buffer Objects") that have been setup for this purpose. This is called transform
feedback mode; it allows the user to do transform data via vertex and geometry
shaders, then hold on to that data for use later.

如果启用Transform Feedback，几何着色器或图元组装阶段的输出会被写入某些**缓存对象**。此时我们称做transform
feedback模式。它允许用户（OpenGL程序员）通过顶点和几何着色器变换数据并保存（以备后续使用）。

The data output into the
transform feedback buffer is the data from each primitive emitted by this step.

写入transform feedback缓存的数据来自这一步计算出的所有图元。

## Clipping(裁剪)

_Main article: [Clipping](https://www.opengl.org/wiki/Clipping "Clipping")(__更多资讯，点击__[Clipping](https://www.opengl.org/wiki/Clipping "Clipping"))_

The primitives are then clipped.
Clipping means that primitives that lie on the boundary between the inside of
the viewing volume and the outside are split into several primitives, such that
the entire primitive lies in the volume. Also, the last [Vertex
Processing](https://www.opengl.org/wiki/Vertex_Processing "Vertex Processing") shader stage can specify user-defined clipping operations, on a
per-vertex basis.

然后图元会被裁剪。裁剪就是说，那种压着视锥体边界（内部也有外部也有）的图元，会被分成若干个图元。这是为了保证所有视锥体内的图元都是完整的。另外，上文的顶点处理阶段的shader可以自定义裁剪操作（逐顶点）。

The vertex positions are
transformed from clip-space to window space via the [Perspective
Divide](https://www.opengl.org/wiki/Perspective_Divide "Perspective Divide") and the [Viewport Transform](https://www.opengl.org/wiki/Viewport_Transform "Viewport Transform").

经过视角除法和视口变换两步，顶点的位置就从**裁剪空间**变换到了**窗口空间**。

# Primitive
assembly(图元组装)

_Main article: [Primitive
Assembly](https://www.opengl.org/wiki/Primitive_Assembly "Primitive Assembly")(__更多资讯，点击__[Primitive Assembly](https://www.opengl.org/wiki/Primitive_Assembly "Primitive Assembly"))_

Primitive assembly is the process
of collecting a run of vertex data output from the prior stages and composing
it into a sequence of primitives. The type of primitive the user rendered with
determines how this process works.

**图元组装**就是把顶点组合为图元的过程。图元的类型是用户（OpenGL程序员）指定的。

The output of this process is an
ordered sequence of simple primitives (lines, points, or triangles). If the
input is a triangle strip primitive containing 12 vertices, for example, the
output of this process will be 10 triangles.

这一步骤的输出结果是一系列有序的简单图元（线段、点或三角形等）。例如，若输入的是由包含12个顶点的**_三角形带_**，那么输出的就是10个**_三角形_**。

If tessellation or geometry
shaders are active, then a limited form of primitive assembly is executed
before these [Vertex Processing](https://www.opengl.org/wiki/Vertex_Processing "Vertex Processing") stages. This is used to feed
those particular shader stages with individual primitives, rather than a
sequence of vertices.

如果启用了细分或几何着色器，那么一个限制级的图元组装过程就会在那些顶点处理阶段之前执行。这是为了提供给它们需要的图元（而不是顶点）作为输入数据。

The rendering pipeline can also
be aborted at this stage. This allows the use of [Transform
Feedback](https://www.opengl.org/wiki/Transform_Feedback "Transform Feedback") operations, without having to actually render something.

渲染管道有可能在此阶段被终止。这就允许了[Transform
Feedback](https://www.opengl.org/wiki/Transform_Feedback "Transform Feedback")操作，同时也不必真的渲染什么。

## Face
culling(面剔除)

_Main article: [Face
Culling](https://www.opengl.org/wiki/Face_Culling "Face Culling")(__更多资讯，点击__[Face
Culling](https://www.opengl.org/wiki/Face_Culling "Face Culling"))_

Triangle primitives can be culled
(ie: discarded without rendering) based on the triangle's facing in window
space. This allows you to avoid rendering triangles facing away from the
viewer. For closed surfaces, such triangles would naturally be covered up by
triangles facing the user, so there is never any need to render them. Face
culling is a way to avoid rendering such primitives.

OpenGL可以根据三角形图元在**窗口空间**的**朝向**来决定是不是要剔除（忽略，不画）它。这可以让你避免渲染那些背向观察者（摄像机）的三角形。对于**闭合的表面**，这种背向观察者的三角形总是会被朝向观察者的三角形覆盖，因此永远都不必渲染他们。面剔除就是避免渲染这种图元的一种方式。

# Rasterization(光栅化)

_Main article: [Rasterization](https://www.opengl.org/wiki/Rasterization "Rasterization")(__更多资讯，点击__[Rasterization](https://www.opengl.org/wiki/Rasterization "Rasterization"))_

Primitives that reach this stage
are then rasterized in the order in which they were given. The result of
rasterizing a primitive is a sequence of _[Fragments](https://www.opengl.org/wiki/Fragment "Fragment")_.

到达这一阶段的图元依次被光栅化，得到的结果就是若干**_片段（片元）_**。

A fragment is a set of state that
is used to compute the final data for a pixel (or sample if [multisampling](https://www.opengl.org/wiki/Multisampling "Multisampling")
is enabled) in the output framebuffer. The state for a fragment includes its
position in screen-space, the sample coverage if multisampling is enabled, and
a list of arbitrary data that was output from the previous vertex or geometry
shader.

一个片段是若干状态的集合，用于计算最终的像素值或采样值（启用[multisampling](https://www.opengl.org/wiki/Multisampling "Multisampling")时）并写入Framebuffer。片段的状态包括：在屏幕空间的位置，采样覆盖范围（启用[multisampling](https://www.opengl.org/wiki/Multisampling "Multisampling")时），其他任何从顶点或几何着色器传送来的数据。

This last set of data is computed
by interpolating between the data values in the vertices for the fragment. The
style of interpolation is defined by the shader that outputed those values.

片段的数据是通过顶点数据插值计算得来的。插值的方式由输出这些数据的着色器定义。（更多资讯，点击[GLSL关键字flat](http://www.cnblogs.com/bitzhuwei/p/modern-opengl-picking-primitive-in-VBO-2.html)）

# Fragment
Processing(片段处理)

_Main article: [Fragment
Shader](https://www.opengl.org/wiki/Fragment_Shader "Fragment Shader")(__更多资讯，点击__[Fragment Shader](https://www.opengl.org/wiki/Fragment_Shader "Fragment Shader"))_

The data for each fragment from
the rasterization stage is processed by a fragment shader. The output from a
fragment shader is a list of colors for each of the color buffers being written
to, a depth value, and a stencil value. Fragment shaders are not able to set
the stencil data for a fragment, but they do have control over the color and
depth values.

片段数据接下来由片段着色器处理。片段着色器的输出结果是**深度值**、**模板值**和即将写入颜色缓存的**颜色值**。片段着色器不能设置片段的模板值，但是确实能够控制片段的颜色值和深度值。

Fragment shaders are optional. If
you render without a fragment shader, the depth (and stencil) values of the
fragment get their usual values. But the value of all of the colors that a
fragment could have are undefined. Rendering without a fragment shader is
useful when rendering only a primitive's default depth information to the depth
buffer, such as when performing [Occlusion
Query](https://www.opengl.org/wiki/Occlusion_Query "Occlusion Query") tests.

片段着色器是可选的。（什么！！！）如果不使用片段着色器，那么深度值和模板值仍旧正常。但是所有片段的颜色值都将是未定义的。当你只需要将图元的深度信息写入深度缓存时（例如在施展**遮挡查询**测试时），不使用片段着色器的渲染过程就很有用。（是因为减少了渲染管道的工作量，提升了效率吧）

# Per-Sample
Operations(逐采样的操作)

_Main article: [Per-Sample_Processing](https://www.opengl.org/wiki/Per-Sample_Processing "Per-Sample Processing")(__更多资讯，点击__[Per-Sample_Processing](https://www.opengl.org/wiki/Per-Sample_Processing "Per-Sample Processing"))_

The fragment data output from the
fragment processor is then passed through a sequence of steps.

片段着色器输出的片段数据要经过一系列后续步骤。

The first step is a sequence of
culling tests; if a test is active and the fragment fails the test, the
underlying pixels/samples are not updated (usually). Many of these tests are
only active if the user activates them. The tests are: (第一步是一系列**剔除测试**。如果某项测试被启用了并且一个片段没有通过测试，那么（一般情况下）这个片段就会被抛弃，即不会影响到将来的像素/采样值。许多测试只有用户（OpenGL程序员）启用他们后才会生效。这些测试是：)

*   Pixel
ownership test: Fails if the fragment's pixel is not "owned" by
OpenGL (if another window is overlapping with the GL window). Always
passes when using a [Framebuffer Object](https://www.opengl.org/wiki/Framebuffer_Object "Framebuffer Object"). Failure means that the
pixel contains undefined values.(像素归属测试：如果片段所在的像素不属于OpenGL（如果另一个窗口覆盖在GL窗口上），那么测试不通过。当使用Framebuffer对象时，测试永远通过。测试不通过意味着像素包含未定义的值。)
*   [Scissor
Test](https://www.opengl.org/wiki/Scissor_Test "Scissor Test"): When enabled, the test fails if the fragment's pixel lies
outside of a specified rectangle of the screen.(剪切测试：启用后，若片段的像素位于指定范围之外则测试不通过。)
*   [Stencil
Test](https://www.opengl.org/wiki/Stencil_Test "Stencil Test"): When enabled, the test fails if the stencil value provided by
the test does not compare as the user specifies against the stencil value
from the underlying sample in the stencil buffer. Note that the stencil
value in the framebuffer can still be modified even if the stencil test
fails (and even if the depth test fails).(模板测试：启用后，若test提供的模板值与模板缓存中的模板值并不具有用户指定的关系，则测试不通过。注意，即使模板测试失败，Framebuffer中的模板值仍旧会被修改。)
*   [Depth
Test](https://www.opengl.org/wiki/Depth_Test "Depth Test"): When enabled, the test fails if the fragment's depth does not
compare as the user specifies against the depth value from the underlying
sample in the depth buffer.(深度测试：启用后，若片段的深度值与深度缓存中的深度值并不符合用户指定的要求，则测试不通过。)

**Note:** Though these are specified to happen
after the [Fragment Shader](https://www.opengl.org/wiki/Fragment_Shader "Fragment Shader"), they can be made to happen [before the fragment shader](https://www.opengl.org/wiki/Early_Fragment_Test "Early Fragment Test") under certain
conditions. If they happen before the FS, then any culling of the fragment will
also prevent the fragment shader from executing, this saving performance.(注意：尽管这些测试名义上是在片段着色器之后发生的，在某些条件下他们其实可以在片段着色器之前发生。如果他们在片段着色器之前发生，那么在任何剔除片段的测试不通过时，接下来的片段着色器都不会执行了。这可以提升性能。)

After this, [color blending](https://www.opengl.org/wiki/Blending "Blending")
happens. For each fragment color value, there is a specific blending operation
between it and the color already in the framebuffer at that location. [Logical
Operations](https://www.opengl.org/wiki/Logical_Operation "Logical Operation") may also take place in lieu of blending, which perform bitwise
operations between the fragment colors and framebuffer colors.

在此之后，就是**颜色混合**阶段。对每个片段颜色值，都会对其与Framebuffer上已有的颜色值进行某种方式的混合。也可以用**逻辑操作**代替混合操作。逻辑操作会在片段颜色值和Framebuffer上已有的颜色值进行**位操作**。

Lastly, the fragment data is
written to the framebuffer. [Masking operations](https://www.opengl.org/wiki/Write_Mask "Write Mask") allow the user to prevent writes to
certain values. Color, depth, and stencil writes can be masked on and off;
individual color channels can be masked as well.

最后，片段数据被写入Framebuffer。**掩码操作**允许用户（OpenGL程序员）指定避免写入某些值。**颜色写入**、**深度写入**、**模板写入**可以被启用或禁用，单独的颜色通道（R、G、B、A）也可以被掩护。（比如禁止写入R，那么红色不会被更改，而其他通道仍旧可以被更改。）

Retrieved from
"[http://www.opengl.org/wiki_132/index.php?title=Rendering_Pipeline_Overview&amp;oldid=12521](http://www.opengl.org/wiki_132/index.php?title=Rendering_Pipeline_Overview&amp;oldid=12521 "Rendering_Pipeline_Overview&amp;oldid=12521")"

[Category](https://www.opengl.org/wiki/Special:Categories "Special:Categories"):

*   [General OpenGL](https://www.opengl.org/wiki/Category:General_OpenGL "Category:General OpenGL")



//////////////////////////////////////////////////////////////////////////////////////////

