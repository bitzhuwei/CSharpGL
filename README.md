# CSharpGL
纠集整理SharpGL，GLM，SharpFont等开源库，努力做一个更好用的纯C#版OpenGL。
<h1>核心N合一</h1>
<p>为了解耦，我把CSharpGL核心拆分为5个DLL。然后发现这只会带来麻烦。用的时候要引用多个DLL，开发的时候也没有益处。于是全部N合一，成为一个CSharpGL.dll。</p>
<p><img src="http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_CSharpGL2016-04-22_02-18-00.png" alt="" width="1731" height="714" /></p>
<p>现在的版本内容如上图所示。</p>
<h1>Demo：GLCanvas</h1>
<p>这个demo每秒随机更换一个背景色。演示了如何使用GLCanvas（drag-drop即可），清晰展示了GLCanvas最基本的渲染功能。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030915695-929033581.png" alt="" /><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030916398-869374143.png" alt="" /></p>
<p>&nbsp;</p>
<h1>Demo：北斗七星(Big Dipper)</h1>
<p>这个demo演示了如何用CSharpGL进行modern rendering。</p>
<p>北斗七星模型的顶点位置如下：</p>
<div>
<div class="cnblogs_code">
<pre><span style="color: #008080;">1</span> [<span style="color: #800080;">0</span>]    {-<span style="color: #800080;">2.5000</span>, +<span style="color: #800080;">1.0000</span>, +<span style="color: #800080;">0.0000</span><span style="color: #000000;">}
</span><span style="color: #008080;">2</span> [<span style="color: #800080;">1</span>]    {-<span style="color: #800080;">1.5000</span>, +<span style="color: #800080;">1.0000</span>, +<span style="color: #800080;">0.0000</span><span style="color: #000000;">}
</span><span style="color: #008080;">3</span> [<span style="color: #800080;">2</span>]    {-<span style="color: #800080;">0.5000</span>, +<span style="color: #800080;">0.5000</span>, +<span style="color: #800080;">0.0000</span><span style="color: #000000;">}
</span><span style="color: #008080;">4</span> [<span style="color: #800080;">3</span>]    {+<span style="color: #800080;">0.5000</span>, +<span style="color: #800080;">0.2500</span>, +<span style="color: #800080;">0.0000</span><span style="color: #000000;">}
</span><span style="color: #008080;">5</span> [<span style="color: #800080;">4</span>]    {+<span style="color: #800080;">1.0000</span>, -<span style="color: #800080;">1.0000</span>, +<span style="color: #800080;">0.0000</span><span style="color: #000000;">}
</span><span style="color: #008080;">6</span> [<span style="color: #800080;">5</span>]    {+<span style="color: #800080;">2.0000</span>, -<span style="color: #800080;">1.0000</span>, +<span style="color: #800080;">0.0000</span><span style="color: #000000;">}
</span><span style="color: #008080;">7</span> [<span style="color: #800080;">6</span>]    {+<span style="color: #800080;">2.5000</span>, +<span style="color: #800080;">0.0000</span>, +<span style="color: #800080;">0.0000</span>}</pre>
</div>
</div>
<p>北斗七星模型的顶点颜色是由红色逐渐过度到紫色。</p>
<h2>旋转、缩放</h2>
<p>通过camera和satelliteRotator实现旋转和缩放模型的功能。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030917445-1183842753.png" alt="" /></p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030918241-740331833.png" alt="" /></p>
<h2>拾取</h2>
<p>鼠标移动到北斗七星模型上，会在BulletinBoard窗口上显示出拾取到的图元。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030919945-1375132311.png" alt="" /></p>
<h2>GLSwitch</h2>
<p>有时候你需要用GL.LineWidth();设置线宽度；有时候需要用GL.PointSize();设置点的大小。CSharpGL提供GLSwitch对象，可以为各个IRenderable对象动态增删这些功能。</p>
<p>北斗七星Demo里，你可以在PropertyGrid窗口动态增删GLSwitch。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030921304-1011157742.png" alt="" /></p>
<h2>UniformVariables</h2>
<p>CSharpGL提供类似GLSwitch的可视化编辑方式，来动态增删改shader中的uniform变量。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030922929-1238191723.png" alt="" /></p>
<h2>DrawMode</h2>
<p>还可以动态修改渲染模式。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030923960-2047015710.png" alt="" /></p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030925116-2131805405.png" alt="" /></p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030926335-1742356378.png" alt="" /></p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030927273-1942741658.png" alt="" /></p>
<p>其他类型就不贴图了。</p>
<p>另外，不同的DrawMode下，拾取到的图元也是不同的。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160422030929851-1647886969.png" alt="" /></p>
<h1>Demo：Geometry Shader(EmitNormalLine)</h1>
<p>用geometry shader自动渲染出模型顶点的法线是目前我找到的geometry Shader的最好的应用。</p>
<p>下图中的白色针状就是各个顶点的法线。</p>
<h2>Teapot</h2>
<p><img src="http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000022.jpg" alt="" width="687" height="574" /></p>
<h2>Sphere</h2>
<p><img src="http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000023.jpg" alt="" width="687" height="574" /></p>
<h2>Cube</h2>
<p><img src="http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000021.jpg" alt="" width="687" height="574" /></p>
<p>&nbsp;</p>
<h1>将OpenGL渲染出来的内容保存到PNG图片</h1>
<p><img src="http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000092.jpg" alt="" width="687" height="574" /></p>
<p><img src="http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_c.png" alt="" width="529" height="394" /></p>
<p>&nbsp;</p>
<h1>拖拽图元</h1>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160427022619548-1430824180.png" alt="" /></p>
<p>例如，你可以把Big Dipper这个模型拽成下面这个样子。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160427022620845-826784277.png" alt="" /></p>
<p>配合旋转，还可以继续拖拽成这样。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160427022622111-180174169.png" alt="" /></p>
<p>当然，能拖拽的不只是线段。还可以拖拽三角形（如下图）、四边形。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160427023855377-1510998196.png" alt="" width="557" height="465" /></p>
<p>另外，还可以单点拖拽。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201604/383191-20160427141620955-245791237.jpg" alt="" width="950" height="404" /></p>
<h1>顺序无关的半透明渲染(Order-Independent-Transparency)</h1>
<p>在&nbsp;<span class="cnblogs_code">GL.Enable(GL_BLEND);</span>&nbsp;后渲染半透明物体时，由于顶点被渲染的顺序固定，渲染出来的结果往往很奇怪。红宝书里提到一个OIT(Order-Independent-Transparency)的渲染方法，很好的解决了这个问题。这个功能太有用了。于是我把这个方法加入CSharpGL中。</p>
<p>如下图所示，左边是常见的blend方法，右边是OIT渲染的结果。可以看到左边的渲染结果有些诡异，右边的就正常了。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201605/383191-20160507222632796-1377372910.jpg" alt="" /></p>
<p>网络允许的话可以看一下视频，更直观。</p>
<p><object width="480" height="400" align="middle" data="http://player.youku.com/player.php/sid/XMTU2MTk0OTE0OA==/v.swf" type="application/x-shockwave-flash"><param name="src" value="http://player.youku.com/player.php/sid/XMTU2MTk0OTE0OA==/v.swf" /><param name="allowfullscreen" value="true" /><param name="quality" value="high" /><param name="allowscriptaccess" value="always" /></object></p>
<p>或者也可以看红宝书里的例子：左边是常见的blend方法，右边是OIT渲染的结果。</p>
<p><img src="http://images2015.cnblogs.com/blog/383191/201605/383191-20160507222640109-1739591473.png" alt="" /></p>
<h1>总结</h1>
<p>原CSharpGL的其他功能，我将逐步加入新CSharpGL。</p>
<p>欢迎对OpenGL有兴趣的同学关注</p>
