<span style="font-size: 16pt;">**讲讲清楚OpenGL坐标变换**</span>&nbsp;

> 在理解OpenGL的坐标变换问题的路上，有好几个难点和易错点。且OpenGL秉持着程序难以调试、难点互相纠缠的特色，更让人迷惑。本文依序整理出关于OpenGL坐标变换的各个知识点、隐藏规则、诀窍和注意事项。


# Matrix

OpenGL用4x4矩阵进行坐标变换。

OpenGL的4x4矩阵是按<span style="color: red;">列</span>排列的。

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033251573-877467611.png)

忘记glRotatef()，glScalef()，glTranslatef()什么的吧，那都属于legacy opengl，不久会被彻底淘汰。在modern opengl中有其他方式代替他们。



# Model Space

为了描述3D世界，首先要设计一些三维模型出来。

设计三维模型的时候用的坐标系就是Model Coordinate System。

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033254651-184153794.jpg)

## 只有1个模型

此时你所见的这个空间就是Model Space。Model Space里只负责描述一个模型。

有人可能会说，此图只设计了一个茶壶，如果我设计的是一套茶具（茶壶+几个茶杯），那不就是多个模型了吗？答：还真不是，此时应该把这套茶具视作一个整体，视为一个模型。回忆一下中学学的"确定研究对象"、"将XXX视作一个整体"，就是这个意思。

## 围绕原点

在Model Space设计模型的时候，要注意<span style="color: red;">使模型的包围盒的中心位于原点(0, 0, 0)</span>。&nbsp;&nbsp;&nbsp;&nbsp;

包围盒就是能够把模型包围的最小的长方体。

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033255963-727326880.jpg)

为什么要围绕原点？因为这样才能在下文所述的World Space里"正常地"旋转、缩放和平移模型。



# World Space

## 为何围绕原点

继续解释上面的问题。假设我们设计了一个立方体模型，它是关于原点(0, 0, 0)对称的。我们就这样让它降生到世界上。为了叙述方便，我们称其为<span style="background-color: yellow;">_Center_</span>。如下图所示。

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033258463-567348567.jpg)

（再换个角度看）

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033302385-257434701.jpg)

现在，我们再设计一个小一点的立方体模型，但这个立方体模型的中心不在原点(0, 0, 0)。为了叙述方便，我们称其为<span style="background-color: yellow;">_Corner_</span>。我们把这个<span style="background-color: yellow;">_Corner_</span>也放进来。

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033304854-1790789160.jpg)

（再换个角度看）

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033308213-924516486.jpg)

现在，我们分别把<span style="background-color: yellow;">_Center_</span>和<span style="background-color: yellow;">_Corner_</span>缩小为原来的一半。我们希望的情形是这样的：

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033311198-335702961.jpg)

（再换个角度看）

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033314042-661026423.jpg)

为了看得清楚，我们把<span style="background-color: yellow;">_Center_</span>再扩大到原来的大小：

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033316995-837894321.jpg)

（再换个角度看）

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033319932-1613982917.jpg)

可以看到<span style="background-color: yellow;">_Corner_</span>在<span style="color: red;">原来的位置</span>上缩小了一半。这符合我们的预期。

但是，残酷的现实并非如此，当你把<span style="background-color: yellow;">_Center_</span>和<span style="background-color: yellow;">_Corner_</span>同时缩小一半时，你看到的情形会是这样：

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033332010-1959171316.jpg)

（再换个角度看）

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033342463-1726872546.jpg)

也就是说，一个缩放操作不仅改变了<span style="background-color: yellow;">_Corner_</span>的大小，还改变了它的<span style="color: red;">位置</span>。如果你在缩放之前把Camera对准了<span style="background-color: yellow;">_Corner_</span>，那么缩放之后<span style="background-color: yellow;">_Corner_</span>的位置发生了巨变，Camera很可能就看不到<span style="background-color: #ffff00;">_Corner_</span>了。

## 总结提升

如果一个模型的包围盒A在Model Space的中心不是(0, 0, 0)，那么你可以想象有一个<span style="background-color: yellow;">**_虚拟的包围盒B_**</span>，B的中心是(0, 0, 0)，且恰好能包围住A。然后，同时缩放A和B。由于B的中心是(0, 0, 0)，缩放前后不会改变；而A的中心实际上是B内部一侧的一点，它是必然移动了的，即缩放操作改变了A的位置。

上述例子描述的是缩放操作，对于旋转操作，道理相同。

这就是保持模型的包围盒中心在原点(0, 0, 0)的好处。你可以随意旋转(rotate)、缩放(scale)模型，之后再移动(translate)到任意位置（此位置即模型在World Space里的位置）。无论你如何旋转、缩放此模型，它在移动(translate)之后的位置都是一样的。

![](http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_world-space.gif)

如上图所示，一个立方体向右移动4个单位，并进行了旋转和缩放操作。无论旋转角度、缩放比例是多少，其移动距离始终是4个单位。

## Model Matrix

Model Matrix负责将模型从Model Space变换到World Space。

变换操作有三种：旋转(rotation)、缩放(scale)和平移(translate)。可以按字母表的顺序来记（<span style="color: #ff0000;">R</span>otation,&nbsp;<span style="color: #ff0000;">S</span>cale,&nbsp;<span style="color: #ff0000;">T</span>ranslate）。

变换的顺序应当是：1旋转，2缩放，3平移。

设模型在Model Space里的任意一个顶点坐标为(x, y, z)，我们想把模型放到World Space里的(tx, ty, tz)处，且绕y轴旋转r&deg;，缩放为原来的s倍。那么：

平移矩阵为&nbsp;<span class="cnblogs_code">mat4 translate = glm.translate(mat4.identity(), <span style="color: #0000ff;">new</span> vec3(tx, ty, tz));</span>&nbsp;；

缩放矩阵为&nbsp;<span class="cnblogs_code">mat4 scale = glm.scale(mat4.identity(), <span style="color: #0000ff;">new</span> vec3(s, s, s));</span>&nbsp;；

旋转矩阵为&nbsp;<span class="cnblogs_code">mat4 rotation = glm.rotate(mat4.identity(), (<span style="color: #0000ff;">float</span>)(r * Math.PI / <span style="color: #800080;">180.0</span>), <span style="color: #0000ff;">new</span> vec3(<span style="color: #800080;">0</span>, <span style="color: #800080;">1</span>, <span style="color: #800080;">0</span>));</span>&nbsp;；

总的Model Matrix为&nbsp;<span class="cnblogs_code">mat4 modelMatrix = translate * scale * rotation;</span>&nbsp;。

为了获取(x, y, z)变换到World Space上的位置，首先将其扩充为四元向量(x, y, z, 1)。（不用管为什么不是(x, y, z, 0)），然后可得：<span class="cnblogs_code">vec4 worldPos = modelMatrix * <span style="color: #0000ff;">new</span> vec4(x, y, z, <span style="color: #800080;">1</span>);</span>&nbsp;

## 性质

旋转、缩放操作都是关于原点(0, 0, 0)对称的。把模型的包围盒中心置于原点，会有难以言喻的好处。

&nbsp;<span class="cnblogs_code">(worldPos.x, worldPos,y, worldPos.z)</span>&nbsp;就是&nbsp;<span class="cnblogs_code">(x, y, z)</span>&nbsp;变换到World Space之后的位置。



&nbsp;<span class="cnblogs_code">worldPos.w</span>&nbsp;必然是1。

对模型的操作顺序应当为rotation -&gt; scale -&gt; translate。

# View/Eye/Camera Space

这三个名称是指同一个Space。

在World Space，各个模型都摆放好了位置和角度，之后就该从某个位置用Eye/Camera去看这个World。Camera有三个属性：eye/Position描述其位置，center/Target是朝向，Up是头顶。

Camera的Position是World Space里的一个点(Position.x, Position.y, Position.z)，Target和Up是World Space里的2个向量。就是说，<span style="color: red;">Camera.Position/Target/Up都是在World Space里定义的。</span>

## view matrix

Camera的参数(Position, Target, Up)决定了view matrix。模型在World Space里的位置，经过view matrix的变换，就变成了在View Space里的位置。

根据camera的Position, Target, Up求view matrix的过程就是著名的<span style="color: red;">lookAt()</span>函数。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;"> 2</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> Build a look at view matrix.
</span><span style="color: #008080;"> 3</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> transform object's coordinate from world's space to camera's space.
</span><span style="color: #008080;"> 4</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;"> 5</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="eye"&gt;</span><span style="color: #008000;">The eye.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 6</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="center"&gt;</span><span style="color: #008000;">The center.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 7</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="up"&gt;</span><span style="color: #008000;">Up.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 8</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;returns&gt;&lt;/returns&gt;</span>
<span style="color: #008080;"> 9</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span><span style="color: #000000;"> mat4 lookAt(vec3 eye, vec3 center, vec3 upVector)
</span><span style="color: #008080;">10</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">11</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> camera's back in world space coordinate system</span>
<span style="color: #008080;">12</span>             vec3 back = (eye -<span style="color: #000000;"> center).normalize();
</span><span style="color: #008080;">13</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> camera's right in world space coordinate system</span>
<span style="color: #008080;">14</span>             vec3 right =<span style="color: #000000;"> upVector.cross(back).normalize();
</span><span style="color: #008080;">15</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> camera's up in world space coordinate system</span>
<span style="color: #008080;">16</span>             vec3 up =<span style="color: #000000;"> back.cross(right);
</span><span style="color: #008080;">17</span> 
<span style="color: #008080;">18</span>             mat4 viewMatrix = <span style="color: #0000ff;">new</span> mat4(<span style="color: #800080;">1</span><span style="color: #000000;">);
</span><span style="color: #008080;">19</span>             viewMatrix.col0.x =<span style="color: #000000;"> right.x;
</span><span style="color: #008080;">20</span>             viewMatrix.col1.x =<span style="color: #000000;"> right.y;
</span><span style="color: #008080;">21</span>             viewMatrix.col2.x =<span style="color: #000000;"> right.z;
</span><span style="color: #008080;">22</span>             viewMatrix.col0.y =<span style="color: #000000;"> up.x;
</span><span style="color: #008080;">23</span>             viewMatrix.col1.y =<span style="color: #000000;"> up.y;
</span><span style="color: #008080;">24</span>             viewMatrix.col2.y =<span style="color: #000000;"> up.z;
</span><span style="color: #008080;">25</span>             viewMatrix.col0.z =<span style="color: #000000;"> back.x;
</span><span style="color: #008080;">26</span>             viewMatrix.col1.z =<span style="color: #000000;"> back.y;
</span><span style="color: #008080;">27</span>             viewMatrix.col2.z =<span style="color: #000000;"> back.z;
</span><span style="color: #008080;">28</span> 
<span style="color: #008080;">29</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> Translation in world space coordinate system</span>
<span style="color: #008080;">30</span>             viewMatrix.col3.x = -<span style="color: #000000;">eye.dot(right);
</span><span style="color: #008080;">31</span>             viewMatrix.col3.y = -<span style="color: #000000;">eye.dot(up);
</span><span style="color: #008080;">32</span>             viewMatrix.col3.z = -<span style="color: #000000;">eye.dot(back);
</span><span style="color: #008080;">33</span> 
<span style="color: #008080;">34</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> viewMatrix;
</span><span style="color: #008080;">35</span>         }</pre>
</div>
<div>&nbsp;上述函数中的right/up/back指的就是Camera的右侧、上方、后面，如下图所示。right/up/back是三个互相垂直的向量（构成一个右手系），且是在World Space中描述的。</div>

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033402776-305545035.png)

上述函数得到的结果&nbsp;<span class="cnblogs_code">viewMatrix</span>&nbsp;可以用下图描述。<span style="background-color: #ffff99;">[right/up/back]</span>构成了旋转和缩放的部分，<span style="background-color: #ffff99;">-[right/up/back]*eye</span>构成了平移的部分。right/up/back分别描述了Camera坐标系的X/Y/Z轴，且在&nbsp;<span class="cnblogs_code">viewMatrix</span>&nbsp;里也依次位于第0/1/2行。

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033410885-837071372.png)



# Clip Space

Camera摆好之后，要实现透视投影或正交投影。经过投影之后的坐标就是在Clip Space里的坐标。

## 透视投影

透视投影的效果就是近大远小：

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033413854-1288219734.png)

透视矩阵的作用就是设定下图所示的一个<span style="color: red;">棱台</span>范围，将Camera Space里的顶点位置变换一下。变换效果就是远处的点比变换之前更加靠近彼此，越远就靠近的越多。想象一下把这个棱台的Far面缓缓缩小到与Near面相同的大小，这一过程中，越远的顶点，被挤压的程度越大。

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033414651-802292607.png)

根据棱台参数计算透视投影矩阵的函数就是著名的<span style="color: red;">perspective()</span>函数。

<div class="cnblogs_code" onclick="cnblogs_code_show('27cefedd-e897-407b-9d7a-0d6641aceeac')">![](http://images.cnblogs.com/OutliningIndicators/ContractedBlock.gif)![](http://images.cnblogs.com/OutliningIndicators/ExpandedBlockStart.gif)
<div id="cnblogs_code_open_27cefedd-e897-407b-9d7a-0d6641aceeac" class="cnblogs_code_hide">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;"> 2</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> Creates a perspective transformation matrix.
</span><span style="color: #008080;"> 3</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;"> 4</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="fovy"&gt;</span><span style="color: #008000;">The field of view angle, in radians.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 5</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="aspect"&gt;</span><span style="color: #008000;">The aspect ratio.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 6</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="zNear"&gt;</span><span style="color: #008000;">The near depth clipping plane.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 7</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="zFar"&gt;</span><span style="color: #008000;">The far depth clipping plane.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 8</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;returns&gt;</span><span style="color: #008000;">A </span><span style="color: #808080;">&lt;see cref="mat4"/&gt;</span><span style="color: #008000;"> that contains the projection matrix for the perspective transformation.</span><span style="color: #808080;">&lt;/returns&gt;</span>
<span style="color: #008080;"> 9</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> mat4 perspective(<span style="color: #0000ff;">float</span> fovy, <span style="color: #0000ff;">float</span> aspect, <span style="color: #0000ff;">float</span> zNear, <span style="color: #0000ff;">float</span><span style="color: #000000;"> zFar)
</span><span style="color: #008080;">10</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">11</span>             <span style="color: #0000ff;">float</span> tangent = (<span style="color: #0000ff;">float</span>)Math.Tan(fovy / <span style="color: #800080;">2.0f</span><span style="color: #000000;">);
</span><span style="color: #008080;">12</span>             <span style="color: #0000ff;">float</span> height = zNear *<span style="color: #000000;"> tangent;
</span><span style="color: #008080;">13</span>             <span style="color: #0000ff;">float</span> width = height *<span style="color: #000000;"> aspect;
</span><span style="color: #008080;">14</span> 
<span style="color: #008080;">15</span>             <span style="color: #0000ff;">float</span> left = -width, right = width, bottom = -height, top = height, near = zNear, far =<span style="color: #000000;"> zFar;
</span><span style="color: #008080;">16</span> 
<span style="color: #008080;">17</span>             mat4 result =<span style="color: #000000;"> frustum(left, right, bottom, top, near, far);
</span><span style="color: #008080;">18</span> 
<span style="color: #008080;">19</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> result;
</span><span style="color: #008080;">20</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">21</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;">22</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> Creates a frustrum projection matrix.
</span><span style="color: #008080;">23</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;">24</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="left"&gt;</span><span style="color: #008000;">The left.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">25</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="right"&gt;</span><span style="color: #008000;">The right.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">26</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="bottom"&gt;</span><span style="color: #008000;">The bottom.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">27</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="top"&gt;</span><span style="color: #008000;">The top.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">28</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="nearVal"&gt;</span><span style="color: #008000;">The near val.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">29</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="farVal"&gt;</span><span style="color: #008000;">The far val.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">30</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;returns&gt;&lt;/returns&gt;</span>
<span style="color: #008080;">31</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> mat4 frustum(<span style="color: #0000ff;">float</span> left, <span style="color: #0000ff;">float</span> right, <span style="color: #0000ff;">float</span> bottom, <span style="color: #0000ff;">float</span> top, <span style="color: #0000ff;">float</span> nearVal, <span style="color: #0000ff;">float</span><span style="color: #000000;"> farVal)
</span><span style="color: #008080;">32</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">33</span>             <span style="color: #0000ff;">var</span> result =<span style="color: #000000;"> mat4.identity();
</span><span style="color: #008080;">34</span> 
<span style="color: #008080;">35</span>             result[<span style="color: #800080;">0</span>, <span style="color: #800080;">0</span>] = (<span style="color: #800080;">2.0f</span> * nearVal) / (right -<span style="color: #000000;"> left);
</span><span style="color: #008080;">36</span>             result[<span style="color: #800080;">1</span>, <span style="color: #800080;">1</span>] = (<span style="color: #800080;">2.0f</span> * nearVal) / (top -<span style="color: #000000;"> bottom);
</span><span style="color: #008080;">37</span>             result[<span style="color: #800080;">2</span>, <span style="color: #800080;">0</span>] = (right + left) / (right -<span style="color: #000000;"> left);
</span><span style="color: #008080;">38</span>             result[<span style="color: #800080;">2</span>, <span style="color: #800080;">1</span>] = (top + bottom) / (top -<span style="color: #000000;"> bottom);
</span><span style="color: #008080;">39</span>             result[<span style="color: #800080;">2</span>, <span style="color: #800080;">2</span>] = -(farVal + nearVal) / (farVal -<span style="color: #000000;"> nearVal);
</span><span style="color: #008080;">40</span>             result[<span style="color: #800080;">2</span>, <span style="color: #800080;">3</span>] = -<span style="color: #800080;">1.0f</span><span style="color: #000000;">;
</span><span style="color: #008080;">41</span>             result[<span style="color: #800080;">3</span>, <span style="color: #800080;">2</span>] = -(<span style="color: #800080;">2.0f</span> * farVal * nearVal) / (farVal -<span style="color: #000000;"> nearVal);
</span><span style="color: #008080;">42</span>             result[<span style="color: #800080;">3</span>, <span style="color: #800080;">3</span>] = <span style="color: #800080;">0.0f</span><span style="color: #000000;">;
</span><span style="color: #008080;">43</span> 
<span style="color: #008080;">44</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> result;
</span><span style="color: #008080;">45</span>         }</pre>
</div>
<span class="cnblogs_code_collapse">perspective</span></div>

## 正交投影

正交投影就没有近大远小的效果：

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033416917-466400050.png)

正交矩阵的作用也是设置一个范围，将Camera Space里的顶点位置变换一下。

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033417620-1585017675.png)

根据参数计算正交投影矩阵的函数就是著名的<span style="color: red;">ortho()</span>函数。

<div class="cnblogs_code" onclick="cnblogs_code_show('226b5b06-a272-4b9c-b74e-1aa18d322444')">![](http://images.cnblogs.com/OutliningIndicators/ContractedBlock.gif)![](http://images.cnblogs.com/OutliningIndicators/ExpandedBlockStart.gif)
<div id="cnblogs_code_open_226b5b06-a272-4b9c-b74e-1aa18d322444" class="cnblogs_code_hide">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;"> 2</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> Creates a matrix for an orthographic parallel viewing volume.
</span><span style="color: #008080;"> 3</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;"> 4</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="left"&gt;</span><span style="color: #008000;">The left.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 5</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="right"&gt;</span><span style="color: #008000;">The right.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 6</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="bottom"&gt;</span><span style="color: #008000;">The bottom.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 7</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="top"&gt;</span><span style="color: #008000;">The top.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 8</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="zNear"&gt;</span><span style="color: #008000;">The z near.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 9</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="zFar"&gt;</span><span style="color: #008000;">The z far.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">10</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;returns&gt;&lt;/returns&gt;</span>
<span style="color: #008080;">11</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> mat4 ortho(<span style="color: #0000ff;">float</span> left, <span style="color: #0000ff;">float</span> right, <span style="color: #0000ff;">float</span> bottom, <span style="color: #0000ff;">float</span> top, <span style="color: #0000ff;">float</span> zNear, <span style="color: #0000ff;">float</span><span style="color: #000000;"> zFar)
</span><span style="color: #008080;">12</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">13</span>             <span style="color: #0000ff;">var</span> result =<span style="color: #000000;"> mat4.identity();
</span><span style="color: #008080;">14</span>             result[<span style="color: #800080;">0</span>, <span style="color: #800080;">0</span>] = (2f) / (right -<span style="color: #000000;"> left);
</span><span style="color: #008080;">15</span>             result[<span style="color: #800080;">1</span>, <span style="color: #800080;">1</span>] = (2f) / (top -<span style="color: #000000;"> bottom);
</span><span style="color: #008080;">16</span>             result[<span style="color: #800080;">2</span>, <span style="color: #800080;">2</span>] = -(2f) / (zFar -<span style="color: #000000;"> zNear);
</span><span style="color: #008080;">17</span>             result[<span style="color: #800080;">3</span>, <span style="color: #800080;">0</span>] = -(right + left) / (right -<span style="color: #000000;"> left);
</span><span style="color: #008080;">18</span>             result[<span style="color: #800080;">3</span>, <span style="color: #800080;">1</span>] = -(top + bottom) / (top -<span style="color: #000000;"> bottom);
</span><span style="color: #008080;">19</span>             result[<span style="color: #800080;">3</span>, <span style="color: #800080;">2</span>] = -(zFar + zNear) / (zFar -<span style="color: #000000;"> zNear);
</span><span style="color: #008080;">20</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> result;
</span><span style="color: #008080;">21</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">22</span> 
<span style="color: #008080;">23</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;">24</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> Creates a matrix for projecting two-dimensional coordinates onto the screen.
</span><span style="color: #008080;">25</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;para&gt;</span><span style="color: #008000;">this equals ortho(left, right, bottom, top, -1, 1)</span><span style="color: #808080;">&lt;/para&gt;</span>
<span style="color: #008080;">26</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;">27</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="left"&gt;</span><span style="color: #008000;">The left.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">28</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="right"&gt;</span><span style="color: #008000;">The right.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">29</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="bottom"&gt;</span><span style="color: #008000;">The bottom.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">30</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="top"&gt;</span><span style="color: #008000;">The top.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">31</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;returns&gt;&lt;/returns&gt;</span>
<span style="color: #008080;">32</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> mat4 ortho(<span style="color: #0000ff;">float</span> left, <span style="color: #0000ff;">float</span> right, <span style="color: #0000ff;">float</span> bottom, <span style="color: #0000ff;">float</span><span style="color: #000000;"> top)
</span><span style="color: #008080;">33</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">34</span>             <span style="color: #0000ff;">var</span> result =<span style="color: #000000;"> mat4.identity();
</span><span style="color: #008080;">35</span>             result[<span style="color: #800080;">0</span>, <span style="color: #800080;">0</span>] = (2f) / (right -<span style="color: #000000;"> left);
</span><span style="color: #008080;">36</span>             result[<span style="color: #800080;">1</span>, <span style="color: #800080;">1</span>] = (2f) / (top -<span style="color: #000000;"> bottom);
</span><span style="color: #008080;">37</span>             result[<span style="color: #800080;">2</span>, <span style="color: #800080;">2</span>] = -<span style="color: #000000;">(1f);
</span><span style="color: #008080;">38</span>             result[<span style="color: #800080;">3</span>, <span style="color: #800080;">0</span>] = -(right + left) / (right -<span style="color: #000000;"> left);
</span><span style="color: #008080;">39</span>             result[<span style="color: #800080;">3</span>, <span style="color: #800080;">1</span>] = -(top + bottom) / (top -<span style="color: #000000;"> bottom);
</span><span style="color: #008080;">40</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> result;
</span><span style="color: #008080;">41</span>         }</pre>
</div>
<span class="cnblogs_code_collapse">ortho</span></div>

## 性质

无论是透视投影还是正交投影，都有以下性质：

在Clip Space里的顶点位置(x, y, z, w)，&ldquo;x, y, z的绝对值都小于等于|w|&rdquo;<span style="color: #ff0000;">等价于</span>&ldquo;此顶点在可见范围之内&rdquo;。

<span style="line-height: 1.5;">在Clip Space里的顶点位置(x, y, z, w)，就是在vertex shader里赋值给&nbsp;</span><span class="cnblogs_code">gl_Position</span><span style="line-height: 1.5;">&nbsp;的值。</span>



# Normalized Device Space

从Clip Space到Normalized Device Space很简单，只需将(x, y, z, w)全部除以w即可。这被称为视角除法（perspective division）。

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033418057-48259327.png)

上一节说过，在可见范围里的(x, y, z, w)，x, y, z的绝对值都小于等于|w|。因此，经过视角除法后，所有可见的顶点位置都介于(-1, -1, -1)和(1, 1, 1)之间。

视角除法这一过程是由OpenGL渲染管线<span style="color: red;">自动完成</span>的，我们无需也不能参与。



# Screen/Window Space

最后一步，就是把(-1, -1, -1)和(1, 1, 1)之间的顶点位置转换到二维的屏幕窗口上。

假设用于OpenGL渲染的控件宽、高为Width、Height。

&nbsp;<span class="cnblogs_code">glViewport(<span style="color: #0000ff;">int</span> x, <span style="color: #0000ff;">int</span> y, <span style="color: #0000ff;">int</span> width, <span style="color: #0000ff;">int</span> height);</span>&nbsp;用于指定将渲染结果铺到控件的哪一块上。一般我们用&nbsp;<span class="cnblogs_code">glViewport(<span style="color: #800080;">0</span>, <span style="color: #800080;">0</span>, Width, Height);</span>&nbsp;来告诉OpenGL：我们想把结果渲染到整个控件上。当然，如果控件大小发生改变，就需要再次调用&nbsp;<span class="cnblogs_code">glViewport(<span style="color: #800080;">0</span>, <span style="color: #800080;">0</span>, Width, Height)</span>&nbsp;;。

还有一个不常见的&nbsp;<span class="cnblogs_code">glDepthRange(<span style="color: #0000ff;">float</span> near, <span style="color: #0000ff;">float</span> far);</span>&nbsp;用于指定在Screen Space上的Z轴坐标范围（默认范围是&nbsp;<span class="cnblogs_code">glDepthRange(<span style="color: #800080;">0</span>, <span style="color: #800080;">1</span>)</span>&nbsp;）。没错，Screen Space也是有第三个坐标轴Z的，且其方向是从你的计算机窗口指向里面。

顶点在Screen Space里的位置是按下面的公式计算的，当然也是OpenGL<span style="color: red;">自动完成</span>的，我们无需也无法参与。

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033418542-651841472.png)

这个公式很简单，通过NDC(Normalized Dived Coordinate)和Window Coordinate System的线性关系可知：

![](http://images2015.cnblogs.com/blog/383191/201606/383191-20160619033418901-310393627.png)

当我们用&nbsp;<span class="cnblogs_code">glViewport(x, y, Width, Height);</span>&nbsp;的设定时，Screen Space的原点在&nbsp;<span class="cnblogs_code">(x, y)</span>&nbsp;，X轴正方向向右，Y轴正方向向上，Z轴正方向向里。即这是一个左手系。（这个&nbsp;<span class="cnblogs_code">(x, y)</span>&nbsp;是相对控件的左下角而言的，即Screen Space的X轴、Y轴是贴在WinForm控件上的）

## 注意事项

在WinForm系统中，控件本身的&nbsp;<span class="cnblogs_code">(<span style="color: #800080;">0</span>, <span style="color: #800080;">0</span>)</span>&nbsp;位置是控件的<span style="color: red;">左上角</span>。即在mouse_down/mouse_move/mouse_up等事件中的(e.X, e.Y)是以左上角为原点，向右为X轴正方向，向下为Y轴正方向的。所以根据WinForm里的&nbsp;<span class="cnblogs_code">(e.X, e.Y)</span>&nbsp;计算Screen Space里的坐标时要记得用&nbsp;<span class="cnblogs_code">(e.X, Height - <span style="color: #800080;">1</span> - e.Y)</span>转换一下。

如果你用QQ截图或者其他任何方式截图，得到的窗口图片的Width、Height很可能是不等于用glViewport()得到的Width、Height的。截图得到的图片宽高受显示器分辨率的影响，不同的显示器得到的结果不尽相同。而用glViewport()得到的宽高无论在哪个显示器上都是一致的。Screen Space里用的Width、Height就是glViewport()版本的。这里也是个小坑。



# Model Space&lt;--&gt;Screen Space

## project

坐标变换过程很长很复杂？其实就那么回事。下面的函数就实现了从Model Space里的模型坐标到Window Space里的窗口坐标的变换过程。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;"> 2</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> Map the specified object coordinates (obj.x, obj.y, obj.z) into window coordinates.
</span><span style="color: #008080;"> 3</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;"> 4</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="modelPosition"&gt;</span><span style="color: #008000;">The object&rsquo;s vertex position</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 5</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="view"&gt;</span><span style="color: #008000;">The view matrix</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 6</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="proj"&gt;</span><span style="color: #008000;">The projection matrix.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 7</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="viewport"&gt;</span><span style="color: #008000;">The viewport.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 8</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;returns&gt;&lt;/returns&gt;</span>
<span style="color: #008080;"> 9</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span><span style="color: #000000;"> vec3 project(vec3 modelPosition, mat4 view, mat4 proj, vec4 viewport)
</span><span style="color: #008080;">10</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">11</span>             vec4 tmp = <span style="color: #0000ff;">new</span><span style="color: #000000;"> vec4(modelPosition, (1f));
</span><span style="color: #008080;">12</span>             tmp = view *<span style="color: #000000;"> tmp;
</span><span style="color: #008080;">13</span>             tmp = proj * tmp;<span style="color: #008000;">//</span><span style="color: #008000;"> this is gl_Position</span>
<span style="color: #008080;">14</span> 
<span style="color: #008080;">15</span>             tmp /= tmp.w;<span style="color: #008000;">//</span><span style="color: #008000;"> after this, tmp is normalized device coordinate.</span>
<span style="color: #008080;">16</span> 
<span style="color: #008080;">17</span>             tmp = tmp * <span style="color: #800080;">0.5f</span> + <span style="color: #0000ff;">new</span> vec4(<span style="color: #800080;">0.5f</span>, <span style="color: #800080;">0.5f</span>, <span style="color: #800080;">0.5f</span>, <span style="color: #800080;">0.5f</span><span style="color: #000000;">);
</span><span style="color: #008080;">18</span>             tmp[<span style="color: #800080;">0</span>] = tmp[<span style="color: #800080;">0</span>] * viewport[<span style="color: #800080;">2</span>] + viewport[<span style="color: #800080;">0</span><span style="color: #000000;">];
</span><span style="color: #008080;">19</span>             tmp[<span style="color: #800080;">1</span>] = tmp[<span style="color: #800080;">1</span>] * viewport[<span style="color: #800080;">3</span>] + viewport[<span style="color: #800080;">1</span>];<span style="color: #008000;">//</span><span style="color: #008000;"> after this, tmp is window coordinate.</span>
<span style="color: #008080;">20</span> 
<span style="color: #008080;">21</span>             <span style="color: #0000ff;">return</span> <span style="color: #0000ff;">new</span><span style="color: #000000;"> vec3(tmp.x, tmp.y, tmp.z);
</span><span style="color: #008080;">22</span>         }</pre>
</div>

就这么点事。当然这个函数忽略了model matrix和&nbsp;<span class="cnblogs_code">glDepthRange()</span>&nbsp;的作用。不过model matrix可以和view matrix合二为一，&nbsp;<span class="cnblogs_code">glDepthRange()</span>&nbsp;基本上不需要调用。所以无伤大雅。

## unProject

当然也有一个从Screen Space到Model Space的函数。完全是上面的project()的逆过程。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;"> 2</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> Map the specified window coordinates (win.x, win.y, win.z) into object coordinates.
</span><span style="color: #008080;"> 3</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;"> 4</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="windowPos"&gt;</span><span style="color: #008000;">The win.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 5</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="view"&gt;</span><span style="color: #008000;">The view.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 6</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="proj"&gt;</span><span style="color: #008000;">The proj.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 7</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="viewport"&gt;</span><span style="color: #008000;">The viewport.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 8</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;returns&gt;&lt;/returns&gt;</span>
<span style="color: #008080;"> 9</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span><span style="color: #000000;"> vec3 unProject(vec3 windowPos, mat4 view, mat4 proj, vec4 viewport)
</span><span style="color: #008080;">10</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">11</span>             mat4 Inverse = glm.inverse(proj *<span style="color: #000000;"> view);
</span><span style="color: #008080;">12</span> 
<span style="color: #008080;">13</span>             vec4 tmp = <span style="color: #0000ff;">new</span><span style="color: #000000;"> vec4(windowPos, (1f));
</span><span style="color: #008080;">14</span>             tmp.x = (tmp.x - (viewport[<span style="color: #800080;">0</span>])) / (viewport[<span style="color: #800080;">2</span><span style="color: #000000;">]);
</span><span style="color: #008080;">15</span>             tmp.y = (tmp.y - (viewport[<span style="color: #800080;">1</span>])) / (viewport[<span style="color: #800080;">3</span><span style="color: #000000;">]);
</span><span style="color: #008080;">16</span>             tmp = tmp * (2f) - <span style="color: #0000ff;">new</span> vec4(<span style="color: #800080;">1</span>, <span style="color: #800080;">1</span>, <span style="color: #800080;">1</span>, <span style="color: #800080;">1</span>);<span style="color: #008000;">//</span><span style="color: #008000;"> after this, tmp is normalized device coordinate.</span>
<span style="color: #008080;">17</span> 
<span style="color: #008080;">18</span>             vec4 obj = Inverse *<span style="color: #000000;"> tmp;
</span><span style="color: #008080;">19</span>             obj /= obj.w;<span style="color: #008000;">//</span><span style="color: #008000;"> after this, tmp is model coordinate.</span>
<span style="color: #008080;">20</span> 
<span style="color: #008080;">21</span>             <span style="color: #0000ff;">return</span> <span style="color: #0000ff;">new</span><span style="color: #000000;"> vec3(obj);
</span><span style="color: #008080;">22</span>         }</pre>
</div>

&nbsp;

好好体会这2个互逆的过程，就能看透OpenGL坐标变换的全过程。