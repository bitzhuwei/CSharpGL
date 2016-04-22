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
<h1>Demo：北斗七星</h1>
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
<p>&nbsp;</p>
<h1>总结</h1>
<p>原CSharpGL的其他功能（UI、3ds解析器、TTF2Bmp、CSSL等），我将逐步加入新CSharpGL。</p>
