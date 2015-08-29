# CSharpGL
纠集整理SharpGL，GLM，SharpFont等开源库，努力做一个更好用的纯C#版OpenGL。
<p style="text-align: center;"><span style="font-size: 16pt;"><strong>CSharpGL(0)一个易学易用的C#版OpenGL </strong></span></p>
<p>CSharpGL是我受到<span style="line-height: 1.5;">SharpGL的启发，在整理了SharpGL，GLM，SharpFont等开源库的基础上，做的一个新的</span><span style="color: red;">C#版OpenGL库</span><span style="line-height: 1.5;">，希望它能做到易学易用，简化OpenGL开发，减少低级错误，帮助初学者更快地由入门到精通。</span></p>
<h1>CSharpGL有什么？</h1>
<p>下面是目前CSharpGL的一部分示例。你可以：</p>
<h2>绘制模型</h2>
<p>你可以用legacy opengl(glVertex)或modern opengl(VBO+Shader)绘制模型。当然这是最基本的功能。CSharpGL提供一个<span style="color: red;">GLCanvas控件</span>供你进行绘制。</p>
<p><img src="http://images0.cnblogs.com/blog/383191/201508/292100422507006.png" alt="" /></p>
<h2>使用纹理（贴图）</h2>
<p>你可以用legacy opengl(glVertex)或modern opengl(VBO+Shader)为模型贴上<span style="color: red;">贴图</span>。例如下面是用一个含有ASCII码的贴图贴在一个Quad上实现的。（此例还含有Blend相关的操作）</p>
<p><img src="http://images0.cnblogs.com/blog/383191/201508/292100452039509.png" alt="" /></p>
<h2>用Shader实现光照效果</h2>
<p>CSharpGL集成了一些《OpenGL Programming Guide》的Demo。例如在GLSL中实现光照效果。</p>
<p><img src="http://images0.cnblogs.com/blog/383191/201508/292100469537310.png" alt="" /></p>
<h2>用Shader制作Fur效果</h2>
<p>下图所示的模型数据中只有蓝色的人物，外层的白色毛毛是geometry shader根据模型顶点信息制作出来的。这也是从redbook转换到C#的Demo之一。</p>
<p><img src="http://images0.cnblogs.com/blog/383191/201508/292100496258026.png" alt="" /></p>
<h2>Particle Simulator</h2>
<p>ParticleSimulator用Compute Shader和glMapBufferRange实现了一个简单的例子效果。这也是从redbook转换到C#的Demo之一。</p>
<p><img src="http://images0.cnblogs.com/blog/383191/201508/292101005621136.png" alt="" /></p>
<h2>绘制文字</h2>
<p>CSharpGL提供一个PointSpriteStringElement类型实现绘制文字的功能。你可以加载任何TTF/TTC文件中的字形来绘制文字。</p>
<p><img src="http://images0.cnblogs.com/blog/383191/201508/292101026878751.png" alt="" /></p>
<h2>PointSprite示例</h2>
<p>CSharpGL提供了多个使用PointSprite进行绘制的Demo。CSharpGL还提供了很多其他OpenGL功能的用法的示例代码。你可以在CSharpGL.Winforms.Demo项目中找到所有的Demo。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201508/383191-20150829210104922-1016741521.png" alt="" /></p>
<h2>对VBO内的图元的拾取</h2>
<p>CSharpGL提供IColorCodedPicking接口用以实现拾取功能。你可以在下面的Demo程序中了解如何使用IColorCodedPicking及其辅助类型。</p>
<p><img src="http://images0.cnblogs.com/blog/383191/201508/292101082976199.png" alt="" /></p>
<h2>绘制UI控件</h2>
<p>在上面的示例中你看到有的窗口左下角有一个坐标系，这就是一种UI元素。下面是另一个UI元素（色标）。UI元素可以指定其大小、是否绑定到上下左右边框等属性。只需实现IUILayout接口即可自动实现UI布局。你可以从示例代码中看到这一布局机制是如何实现的。这一布局机制对legacy OpenGL和modern OpenGL的效果相同。</p>
<p><img src="http://images0.cnblogs.com/blog/383191/201508/292101101251556.png" alt="" /></p>
<h2>其它</h2>
<p>CSharpGL还提供了很多其他的Demo，如对基础类型UnmanagedArray的使用、Debugging的使用、MapBuffer、Feedback、Instanced Rendering、3D纹理等。我会继续添加新的功能和Demo。你既可以通过CSharpGL来学习OpenGL，也可以用CSharpGL来编写OpenGL程序。</p>
<p>CSharpGL为了降低出错可能，为OpenGL各项功能提供了针对性的枚举类型、重载方法和易于理解的对象。例如等BufferTarget、BufferUsage、GetTarget、PolygonMode、PrimitiveMode、ShadeModel等枚举类型，Camera、ShaderProgram、SceneElementBase、RenderContext、Texture2D等通用的类型，IColorCodedPicking、IUILayout、IMVP、IRenderable等包含着各自的功能机制的接口。</p>
<p>CSharpGL将为每项功能、机制编写文档，讲解其原理和实现，并提供Demo。为了让我能在未来多少年后都能顺利地重拾OpenGL，我一定会尽心地把文档做好。</p>
<p>CSharpGL还拿来了GLM、SharpFont等开源项目，用于计算矩阵、获取字形贴图等操作。</p>
<h1>计划</h1>
<p>我计划针对所有实现了的功能、机制逐个写一篇随笔。本篇算是开篇。</p>
<h1>总结</h1>
<p>学OpenGL有2年了，从NEHE到SharpGL，从《3D Math Primer for Graphics and Game Development》到《OpenGL Programming Guide》，算是对OpenGL有了初级的认识。最近我纠集整理了SharpGL，GLM，SharpFont等开源库，想做一个更好用的纯C#版OpenGL。欢迎对OpenGL有兴趣的同学加入。</p>
