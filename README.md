# CSharpGL
纠集整理SharpGL，GLM，SharpFont等开源库，努力做一个更好用的纯C#版OpenGL。

<p><img src="http://images2015.cnblogs.com/blog/383191/201509/383191-20150908133820794-1595596727.png" alt="" width="64" height="64" /><img src="http://images2015.cnblogs.com/blog/383191/201509/383191-20150908133828090-2134647437.png" alt="" width="272" height="64" /></p>
<p>CSharpGL是我受到<span style="line-height: 1.5;">SharpGL的启发，在整理了SharpGL，GLM，SharpFont等开源库的基础上，做的一个新的</span><span style="color: red;">C#版OpenGL库</span><span style="line-height: 1.5;">，希望它能做到易学易用，简化OpenGL开发，减少低级错误，帮助初学者更快地由入门到精通。</span></p>
<p>CSharpGL已在GitHub开源，欢迎对OpenGL有兴趣的同学加入（<a href="https://github.com/bitzhuwei/CSharpGL" target="_blank">https://github.com/bitzhuwei/CSharpGL</a>）</p>
<p>下面这段话引自（<a href="http://blog.sina.com.cn/s/blog_7cfb366d0101eglm.html" target="_blank">http://blog.sina.com.cn/s/blog_7cfb366d0101eglm.html</a>）</p>
<blockquote>学习OpenGL之所以痛苦，是因为首先只有两本推荐的，一本红宝书《OpenGL编程指南》；一本蓝宝书《OpenGL超级宝典》，初学者看他的东西往往会不知所云。在学习初期，除了少的可怜的书之外，更缺乏调试器。本身物体在三维空间，输错一个正负号就有可能让你找不到你的物体在哪里，没有调试的话你甚至不知道中间过程的时候，物体到底是什么样子。也就是说基本就是一抹黑，你可能既不知道你顶点坐标是否正确，也不知道某些个API是不是调用错误，抑或者是像深度缓冲没开等等，只能靠运气一般的去调去试。我就是这么可怜的度过了那段时间，现在想起来真心感叹，没人带没人教就是这么惨。</blockquote>

<h1>CSharpGL.vsix</h1>
<p>我制作了一个CSharpGL.vsix插件，安装后可以使用模板项目来体会CSharpGL的用法。</p>
<h2>安装CSharpGL.vsix</h2>
<p>原本我想把CSharpGL.vsix上传到visualstudiogallery，结果试了多少次都失败了。</p>
<p>您可以在（<a href="http://files.cnblogs.com/files/bitzhuwei/CSharpGL.vsix.rar">http://files.cnblogs.com/files/bitzhuwei/CSharpGL.vsix.rar</a>）下载之。</p>
<p>解压后安装很简单。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201509/383191-20150908021125856-142020205.png" alt="" /></p>
<p>安装后关闭即可。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201509/383191-20150908021126903-12457472.png" alt="" /></p>
<p>&nbsp;</p>
<h2>使用CSharpGL.vsix</h2>
<p>安装完成后，重启visual studio 2013。</p>
<p>我们来新建一个示例项目。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201509/383191-20150908021127872-1531891577.png" alt="" /></p>
<p>在项目模板中，出现了新增的HelloCSharpGL，我们来创建它。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201509/383191-20150908021129934-786736530.png" alt="" /></p>
<p>点击"确定"，即可自动生成一个完整的项目。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201509/383191-20150908021130997-2102201143.png" alt="" /></p>
<p>现在直接启动，即可看到效果。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201509/383191-20150908021132637-427032682.png" alt="" /></p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201509/383191-20150908021133278-546436100.png" alt="" /></p>
<p>现在你可以在此项目基础上进行各种尝试。</p>
<h1>CSharpGL有什么？</h1>
<p>下面是目前CSharpGL的一部分示例。</p>
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
<h2>&nbsp;Instanced Rendering</h2>
<p>这个Demo演示了用DrawArraysInstanced实现Instanced Rendering的方法。这也是从redbook转换到C#的Demo之一。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201508/383191-20150830222215609-847720238.png" alt="" /></p>
<h2>立方体纹理CubeMap</h2>
<p>这个从redbook中转换来的CubeMap示例，展示了如何加载DDS文件并用作CubeMap。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201508/383191-20150830221841390-1478789274.png" alt="" /></p>

<h2>绘制文字</h2>
<p>CSharpGL提供一个PointSpriteStringElement类型实现绘制所有Unicode范围内文字的功能。你可以加载任何TTF/TTC文件中的字形来绘制文字。如果加载的TTF文件含有中文字形，就可以用来显示中文字符。如果含有任何其他语言文字的字形，都是可以显示的。</p>
<p><img src="http://images0.cnblogs.com/blog/383191/201508/292101026878751.png" alt="" /></p>
<p>CSharpGL提供一个副产品：TTF2Bmps，可以从TTF/TTC字体文件中提取所有的字形，保存为PNG图片。这演示了CSharpGL内部是如何获取字形贴图的。</p>
<p><img src="http://images0.cnblogs.com/blog2015/383191/201508/080314287053831.png" alt="" width="929" height="500" /></p>
<h2>PointSprite示例</h2>
<p>CSharpGL提供了多个使用PointSprite进行绘制的Demo。CSharpGL还提供了很多其他OpenGL功能的用法的示例代码。你可以在CSharpGL.Winforms.Demo项目中找到所有的Demo。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201508/383191-20150829210104922-1016741521.png" alt="" /></p>

<h2>对VBO内的图元的拾取</h2>
<p>CSharpGL提供IColorCodedPicking接口用以实现拾取功能。你可以在下面的Demo程序中了解如何使用IColorCodedPicking及其辅助类型。</p>
<p><img src="http://images0.cnblogs.com/blog/383191/201508/292101082976199.png" alt="" /></p>
<h2>绘制UI控件</h2>
<p>在上面的示例中你看到有的窗口左下角有一个坐标系，这就是一种UI元素。下面是另一个UI元素（色标）。UI元素可以指定其大小、是否绑定到上下左右边框等属性。只需实现IUILayout接口即可自动实现UI布局。你可以从示例代码中看到这一布局机制是如何实现的。这一布局机制对legacy OpenGL和modern OpenGL的效果相同。</p>
<p><img src="http://images0.cnblogs.com/blog/383191/201508/292101101251556.png" alt="" /></p>
<h2>渲染*.3ds文件</h2>
<p>CSharpGL实现了3ds文件的解析器和加载器，可以解析并渲染3ds文件里的模型。例如下面这个盆景就是从（<a href="http://images2015.cnblogs.com/blog/383191/201509/383191-20150912011052731-1205655610.png" target="_blank">http://images2015.cnblogs.com/blog/383191/201509/383191-20150912011052731-1205655610.png</a>）得到的一个3ds文件的渲染结果。</p>
<p>CSharpGL提供的3ds解析器已经能够解析40多种类型的3ds块，涵盖了大多数常用功能，且易于扩展。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201509/383191-20150912011052731-1205655610.png" alt="" width="1272" height="684" /></p>
<p>&nbsp;</p>

<h2>其它</h2>
<p>CSharpGL还提供了很多其他的Demo，如对基础类型UnmanagedArray的使用、Debugging的使用、MapBuffer、Feedback、Instanced Rendering、3D纹理等。我会继续添加新的功能和Demo。你既可以通过CSharpGL来学习OpenGL，也可以用CSharpGL来编写OpenGL程序。</p>
<p>CSharpGL为了降低出错可能，为OpenGL各项功能提供了针对性的枚举类型、重载方法和易于理解的对象。例如等BufferTarget、BufferUsage、GetTarget、PolygonMode、PrimitiveMode、ShadeModel等枚举类型，Camera、ShaderProgram、SceneElementBase、RenderContext、Texture2D等通用的类型，IColorCodedPicking、IUILayout、IMVP、IRenderable等包含着各自的功能机制的接口。</p>
<p>CSharpGL将为每项功能、机制编写文档，讲解其原理和实现，并提供Demo。为了让我能在未来多少年后都能顺利地重拾OpenGL，我一定会尽心地把文档做好。</p>
<p>CSharpGL还拿来了GLM、SharpFont等开源项目，用于计算矩阵、获取字形贴图等操作。</p>

<div>
<h1>CSharpGL与其他C#OpenGL类库的对比</h1>
<h2>SharpGL</h2>
<p>创建OpenGL Render Context的过程只支持Windows平台。</p>
<p>提供OpenGLControl控件供执行OpenGL指令。</p>
<p>提供SceneControl和一系列接口，用于绘制一个树状组织的场景。但树状组织的场景是基于legacy OpenGL的栈结构（glPushMatrix()、glPopMatrix()）设计的，对modern OpenGL并不恰当（但仍可用）。</p>
<p>提供了一些Studio之类的工具，但几乎不能使用。</p>
<p>提供了VSIX插件，可一键创建SharpGL项目。这很适合初学者研究OpenGL入门。</p>
<p>提供数十个Demo项目，分别演示了OpenGL的某些功能（贴图、拾取、光照&hellip;&hellip;）的实现方法。</p>
<p>在渲染文字、拾取等高级内容方面没有针对modern OpenGL的方案。</p>
<p>到今天（2015年8月30日）已有半年多不更新。针对modern OpenGL的内容比较少。</p>
<p>文档基本上没有，不过也不需要太多文档，直接追踪代码就可以了解了。</p>
<h2>OpenTK</h2>
<p>跨平台。为实现跨平台，大量使用了设计模式，代码复杂度飙升，不利于学习掌握。</p>
<p>针对OpenGL、OpenGL ES的各个版本分别编写底层接口，代码量飙升，不利于学习理解。</p>
<p>同时含有OpenCL、OpenAL，功能可谓丰富。</p>
<p>部分功能尚未实现，只列出了代码框架。</p>
<p>由于代码量超大，内存占用稍多，速度稍慢。（待验证）</p>
<p>文档还是有一些的。</p>
<h2>Tao.Framework</h2>
<p>几年前Tao.Framework已被OpenTK取代，我就不再关注了。</p>
<h2>CSharpGL</h2>
<p>创建OpenGL Render Context的过程只支持Windows平台。</p>
<p>提供GLCanvas控件供执行OpenGL指令。</p>
<p>面向modern OpenGL，兼顾legacy OpenGL，为场景元素提供最简设计。并用接口及其辅助机制实现矩阵变换、拾取、UI布局等功能。</p>
<p>提供数十个Demo，分别演示了OpenGL的某些功能（Shader、贴图、拾取、光照、文字、UI&hellip;&hellip;）的实现方法。</p>
<p>将部分《OpenGL Programming Guide(8<sup>th</sup> Edition)》中的代码转换为C#版。</p>
<p>提供TTF2Bmps，可读取TTF/TTC字体文件后输出含有字形的PNG图片及其位置信息（XML）。</p>
<p>CSharpGL刚刚问世，文档将针对各个功能点逐步添加。</p>
<h2>总评</h2>
<p>在跨平台方面，只有OpenTK能做到。跨平台到底有多大的价值，我不敢妄言。但对于水平有限的本人来说，能够简化一切不必要的复杂性，把OpenGL本身学好是第一位的，所以在学习阶段能否跨平台并不重要。</p>
<p>在功能方面，OpenTK也是最丰富的，但学习起来比较费力。SharpGL学起来比较轻松，但其功能在支持modern OpenGL方面比较少。很多很实用的功能又没有很好的实现，导致难以使用。</p>
<p>在性能方面，OpenTK与SharpGL调用底层的OpenGL函数的机制是相同的，所以两者应该没有大的区别。但OpenTK本身的代码量很大，所以可能稍微慢一点点，不过在目前的硬件配置能够承受的情况下，这都不成问题。（若要追求最高速度，直接用C/C++才行。用C#主要是为了提升开发和调试效率，少折腾）</p>
<p>在OpenGL接口方面，OpenTK也是很全面的，SharpGL对modern OpenGL的支持则很少。</p>
<p>CSharpGL的目标是易学易用。为此，CSharpGL除了调用OpenGL指令、执行矩阵变换、创建Render Context等最基础的功能外，都做成了可选的Demo项目。一方面Demo代码可用作学习参考，另一方面可以去掉Demo项目，只用最基础的类库进行开发。CSharpGL的Demo涵盖了OpenGL的各项功能，并对绘制文字、UI、拾取等高级功能也设计了可复用的机制，且全部面向modern OpenGL。</p>
<p>总之，OpenTK是强大而稍复杂，SharpGL是简约而稍老旧，CSharpGL则结合使用简便、功能丰富两方面，用&ldquo;一个Demo演示一项功能&rdquo;的方式学用OpenGL。</p>
</div>
<h1>计划</h1>
<p>首先，我想把redbook里的例子都转换为C#版放到CSharpGL里，作为demo演示OpenGL的各项功能是如何实现的。在这一过程中，必然会涉及补充一些文件格式解析器、枚举类型、类似Texture2D的实用类型等。</p>
<p>然后，我希望把NEHE的例子都集成进来。NEHE是用legacy OpenGL写的，我除了集成legacy OpenGL版外，还要用modernOpenGL写一遍。</p>
<p>还有，我找到一个很好的网站（<a href="http://ogldev.atspace.co.uk/" target="_blank">http://ogldev.atspace.co.uk/</a>），有很多实用强大的例子，我打算把这里的例子也都转换为C#版，放到CSharpGL里。</p>
<p>可以看到，我的计划就是找很多很多的例子，转换成C#版，安排到CSharpGL里，在这过程中丰富CSharpGL的类库。这样，既有大量的例子可以学习模仿，又有强大的可复用类库，CSharpGL就能实现易学易用的目标了。</p>
<p>我计划针对所有实现了的功能、机制逐个写一篇随笔。本篇算是开篇。</p>
<h1>总结</h1>
<p>学OpenGL有2年了，从NEHE到SharpGL，从《3D Math Primer for Graphics and Game Development》到《OpenGL Programming Guide》，算是对OpenGL有了初级的认识。最近我纠集整理了SharpGL，GLM，SharpFont等开源库，想做一个更好用的纯C#版OpenGL。欢迎对OpenGL有兴趣的同学加入（<a href="https://github.com/bitzhuwei/CSharpGL" target="_blank">https://github.com/bitzhuwei/CSharpGL</a>）</p>
