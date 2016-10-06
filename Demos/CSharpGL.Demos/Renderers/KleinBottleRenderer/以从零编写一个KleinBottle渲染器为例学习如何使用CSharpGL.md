# 开始

本文用step by step的方式，讲述如何使用[CSharpGL](https://github.com/bitzhuwei/CSharpGL)渲染一个Klein Bottle，从而得到下图所示的图形。你会看到这并不困难。

&nbsp;![](http://images2015.cnblogs.com/blog/383191/201609/383191-20160930122733641-1543126378.png)

&nbsp;

# 用Modern OpenGL渲染

在Modern OpenGL中，shader是在GPU上执行的程序，用于计算图形最终的样子；模型则提供顶点数据给shader。也就是说，shader是算法，模型是数据结构。渲染器(Renderer)就是将两者联合起来，实现渲染的那么一个干活的工人。

比喻来说，模型是白菜豆腐牛羊猪肉这些食材，shader是煎炒烹炸川鲁粤苏这些做法，渲染器(Renderer)就是厨师。

我们要用Modern OpenGL渲染一个Klein Bottle，就得完成shader、模型、渲染器这三项。为了避免可有可无的细节干扰，本文都采用最简单的方式。

# Shader

我认为从shader开始是一个好习惯，因为shader里除了算法本身，也定义了数据结构（最底层的形式），在shader、模型、渲染器三者中算得上是最为完整的了。

## Vertex shader

下面这个vertex shader已经十分简单了。它的功能就是将Klein Bottle模型的一个顶点[从模型空间(Model Space)坐标系变换到裁剪空间(Clip Space)坐标系](http://www.cnblogs.com/bitzhuwei/p/CSharpGL-27-make-it-clear-about-coordinate-transforms.html#_label1)。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span> #version <span style="color: #800080;">150</span><span style="color: #000000;"> core
</span><span style="color: #008080;"> 2</span> 
<span style="color: #008080;"> 3</span> <span style="color: #0000ff;">in</span> vec3 in_Position;<span style="color: #008000;">//</span><span style="color: #008000;"> 一个顶点</span>
<span style="color: #008080;"> 4</span> uniform mat4 projectionMatrix;<span style="color: #008000;">//</span><span style="color: #008000;"> 投影矩阵</span>
<span style="color: #008080;"> 5</span> uniform mat4 viewMatrix;<span style="color: #008000;">//</span><span style="color: #008000;"> 视图矩阵</span>
<span style="color: #008080;"> 6</span> uniform mat4 modelMatrix;<span style="color: #008000;">//</span><span style="color: #008000;"> 模型矩阵</span>
<span style="color: #008080;"> 7</span> 
<span style="color: #008080;"> 8</span> <span style="color: #0000ff;">void</span> main(<span style="color: #0000ff;">void</span><span style="color: #000000;">) {
</span><span style="color: #008080;"> 9</span>     <span style="color: #008000;">//</span><span style="color: #008000;"> 计算顶点位置</span>
<span style="color: #008080;">10</span>     gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, <span style="color: #800080;">1.0</span><span style="color: #000000;">);
</span><span style="color: #008080;">11</span> }</pre>
</div>

&nbsp;

简单来说，vertex shader程序会对KleinBottle模型上的每个顶点都执行一次。因此在输入数据上写的是`in vec3 in_Position`，而不是`in vec3 in_Positions[]`。由于各个顶点之间互不影响，所以GPU就可以通过并行计算的方式大幅度提高渲染效率。即使有上百万个顶点，GPU也可以同时计算，这等于用一次执行的时间代替了CPU上的一个大型循环的时间。

而`uniform`修饰的变量则是对每次执行的vertex shader都相同的（即全局变量）。

## Fragment shader

下面这个fragment shader也是十分简单的。它的功能就是计算每个顶点的颜色。简单来说，这个fragment shader程序也会对KleinBottle模型上的每个顶点都执行一次。（这是最简单的情况，为了不分散精力，现在这样认为即可）

Fragment shader里的`out_Color`你可以改成其他你喜欢的名字，其效果是一样的。

<div class="cnblogs_code">
<pre><span style="color: #008080;">1</span> #version <span style="color: #800080;">150</span><span style="color: #000000;"> core
</span><span style="color: #008080;">2</span> 
<span style="color: #008080;">3</span> <span style="color: #0000ff;">out</span> vec4 out_Color;<span style="color: #008000;">//</span><span style="color: #008000;"> 输出到屏幕</span>
<span style="color: #008080;">4</span> 
<span style="color: #008080;">5</span> uniform vec3 uniformColor = vec3(<span style="color: #800080;">1</span>, <span style="color: #800080;">1</span>, <span style="color: #800080;">1</span>);<span style="color: #008000;">//</span><span style="color: #008000;"> 颜色为白色</span>
<span style="color: #008080;">6</span> 
<span style="color: #008080;">7</span> <span style="color: #0000ff;">void</span> main(<span style="color: #0000ff;">void</span><span style="color: #000000;">) {
</span><span style="color: #008080;">8</span>     out_Color = vec4(uniformColor, <span style="color: #800080;">1.0f</span>);<span style="color: #008000;">//</span><span style="color: #008000;"> 输出指定的颜色</span>
<span style="color: #008080;">9</span> }</pre>
</div>

# Klein Bottle模型

菜系已然确定，下面就该准备食材（模型数据）了。

下面我们就新建一个KleinBottleModel类。为了融入CSharpGL，让它实现`IBufferable`接口。这个接口的作用是把各式各样的模型数据转化为shader能接受的顶点属性缓存(Vertex Buffer Object)和索引缓存(Index Buffer Object)。（顺带处理一点其他的小事）

<div class="cnblogs_code">
<pre><span style="color: #008080;">1</span>     <span style="color: #0000ff;">class</span><span style="color: #000000;"> KleinBottleModel : IBufferable
</span><span style="color: #008080;">2</span> <span style="color: #000000;">    {
</span><span style="color: #008080;">3</span>     }</pre>
</div>

&nbsp;

下面我们来逐步完成这个Model类。

## 公式

Klein Bottle是个著名的三维模型，可以用一个公式来计算它的每个顶点。

&nbsp;![](http://images2015.cnblogs.com/blog/383191/201609/383191-20160930122756656-1885252765.png)

（0 &le; u &lt; &pi; and 0 &le; v &lt; 2&pi;）

这个公式输入变量是u和v，输出是(x, y, z)。我们先用程序来描述一下这个公式：

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #0000ff;">private</span> vec3 GetPosition(<span style="color: #0000ff;">double</span> u, <span style="color: #0000ff;">double</span><span style="color: #000000;"> v)
</span><span style="color: #008080;"> 2</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 3</span>             <span style="color: #0000ff;">double</span> sinU = Math.Sin(u), cosU =<span style="color: #000000;"> Math.Cos(u);
</span><span style="color: #008080;"> 4</span>             <span style="color: #0000ff;">double</span> sinV = Math.Sin(v), cosV =<span style="color: #000000;"> Math.Cos(v);
</span><span style="color: #008080;"> 5</span>             <span style="color: #0000ff;">double</span> x = -<span style="color: #800080;">2.0</span> * cosU * (<span style="color: #800080;">3</span> * cosV - <span style="color: #800080;">30</span> * sinU + <span style="color: #800080;">90</span> * Math.Pow(cosU, <span style="color: #800080;">4</span>) * sinU - <span style="color: #800080;">60</span> * Math.Pow(cosU, <span style="color: #800080;">6</span>) * sinU + <span style="color: #800080;">5</span> * cosU * cosV *<span style="color: #000000;"> sinU);
</span><span style="color: #008080;"> 6</span>             <span style="color: #0000ff;">double</span> y = -<span style="color: #800080;">1.0</span> * sinU * (<span style="color: #800080;">3</span> * cosV - <span style="color: #800080;">3</span> * Math.Pow(cosU, <span style="color: #800080;">2</span>) * cosV - <span style="color: #800080;">48</span> * Math.Pow(cosU, <span style="color: #800080;">4</span>) * cosV + <span style="color: #800080;">48</span> * Math.Pow(cosU, <span style="color: #800080;">6</span>) * cosV - <span style="color: #800080;">60</span> * sinU + <span style="color: #800080;">5</span> * cosU * cosV * sinU - <span style="color: #800080;">5</span> * Math.Pow(cosU, <span style="color: #800080;">3</span>) * cosV * sinU - <span style="color: #800080;">80</span> * Math.Pow(cosU, <span style="color: #800080;">5</span>) * cosV * sinU + <span style="color: #800080;">80</span> * Math.Pow(cosU, <span style="color: #800080;">7</span>) * cosV *<span style="color: #000000;"> sinU);
</span><span style="color: #008080;"> 7</span>             <span style="color: #0000ff;">double</span> z = <span style="color: #800080;">2.0</span> * (<span style="color: #800080;">3.0</span> + <span style="color: #800080;">5</span> * cosU * sinU) *<span style="color: #000000;"> sinV;
</span><span style="color: #008080;"> 8</span> 
<span style="color: #008080;"> 9</span>             <span style="color: #0000ff;">return</span> <span style="color: #0000ff;">new</span> vec3((<span style="color: #0000ff;">float</span>)x, (<span style="color: #0000ff;">float</span>)y, (<span style="color: #0000ff;">float</span><span style="color: #000000;">)z);
</span><span style="color: #008080;">10</span>         }</pre>
</div>

在u、v各自的范围内，各自采样的点越多，模型就越细致，那么到底要采样多少呢？我们就用一个`double interval`来控制。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">double</span><span style="color: #000000;"> interval;
</span><span style="color: #008080;"> 2</span> 
<span style="color: #008080;"> 3</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">int</span> GetUCount(<span style="color: #0000ff;">double</span><span style="color: #000000;"> interval)
</span><span style="color: #008080;"> 4</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 5</span>             <span style="color: #0000ff;">int</span> uCount = (<span style="color: #0000ff;">int</span>)(Math.PI /<span style="color: #000000;"> interval);
</span><span style="color: #008080;"> 6</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> uCount;
</span><span style="color: #008080;"> 7</span> <span style="color: #000000;">        }
</span><span style="color: #008080;"> 8</span> 
<span style="color: #008080;"> 9</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">int</span> GetVCount(<span style="color: #0000ff;">double</span><span style="color: #000000;"> interval)
</span><span style="color: #008080;">10</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">11</span>             <span style="color: #0000ff;">int</span> vCount = (<span style="color: #0000ff;">int</span>)(Math.PI * <span style="color: #800080;">2</span> / interval / <span style="color: #800080;">10.0</span><span style="color: #000000;">);
</span><span style="color: #008080;">12</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> vCount;
</span><span style="color: #008080;">13</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">14</span> 
<span style="color: #008080;">15</span>         <span style="color: #0000ff;">public</span> KleinBottleModel(<span style="color: #0000ff;">double</span> interval = <span style="color: #800080;">0.02</span><span style="color: #000000;">)
</span><span style="color: #008080;">16</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">17</span>             <span style="color: #0000ff;">this</span>.interval =<span style="color: #000000;"> interval;
</span><span style="color: #008080;">18</span>         }</pre>
</div>

&nbsp;

## 实现IBufferable

下面来实现`IBufferable`接口。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">const</span> <span style="color: #0000ff;">string</span> strPosition = <span style="color: #800000;">"</span><span style="color: #800000;">position</span><span style="color: #800000;">"</span>;<span style="color: #008000;">//</span><span style="color: #008000;"> buffer name.</span>
<span style="color: #008080;"> 2</span>         <span style="color: #0000ff;">private</span> VertexAttributeBufferPtr positionBufferPtr = <span style="color: #0000ff;">null</span><span style="color: #000000;">;
</span><span style="color: #008080;"> 3</span> 
<span style="color: #008080;"> 4</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;"> 5</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> 获取指定的顶点属性缓存。
</span><span style="color: #008080;"> 6</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;para&gt;</span><span style="color: #008000;">Gets specified vertex buffer object.</span><span style="color: #808080;">&lt;/para&gt;</span>
<span style="color: #008080;"> 7</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;"> 8</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="bufferName"&gt;</span><span style="color: #008000;">buffer name(Gets this name from 'strPosition' etc.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;"> 9</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="varNameInShader"&gt;</span><span style="color: #008000;">name in vertex shader like `in vec3 in_Position;`.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">10</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;returns&gt;</span><span style="color: #008000;">Vertex Buffer Object.</span><span style="color: #808080;">&lt;/returns&gt;</span>
<span style="color: #008080;">11</span>         VertexAttributeBufferPtr IBufferable.GetVertexAttributeBufferPtr(<span style="color: #0000ff;">string</span> bufferName, <span style="color: #0000ff;">string</span><span style="color: #000000;"> varNameInShader)
</span><span style="color: #008080;">12</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">13</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> &hellip;</span>
<span style="color: #008080;">14</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">15</span> 
<span style="color: #008080;">16</span>         <span style="color: #0000ff;">private</span> IndexBufferPtr indexBufferPtr = <span style="color: #0000ff;">null</span><span style="color: #000000;">;
</span><span style="color: #008080;">17</span> 
<span style="color: #008080;">18</span> 
<span style="color: #008080;">19</span> <span style="color: #000000;">        IndexBufferPtr IBufferable.GetIndexBufferPtr()
</span><span style="color: #008080;">20</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">21</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> &hellip;</span>
<span style="color: #008080;">22</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">23</span> 
<span style="color: #008080;">24</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;">25</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> Uses </span><span style="color: #808080;">&lt;see cref="ZeroIndexBuffer"/&gt;</span><span style="color: #008000;"> or </span><span style="color: #808080;">&lt;see cref="OneIndexBuffer"/&gt;</span><span style="color: #008000;">.
</span><span style="color: #008080;">26</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;">27</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;returns&gt;&lt;/returns&gt;</span>
<span style="color: #008080;">28</span>         <span style="color: #0000ff;">bool</span> IBufferable.UsesZeroIndexBuffer() { <span style="color: #0000ff;">return</span> <span style="color: #0000ff;">true</span>; }</pre>
</div>

&nbsp;

### 顶点属性缓存&mdash;&mdash;位置(Vertex Attribute Buffer &ndash; Position)

为了简单，本例中的Klein Bottle，我们只给它一条顶点属性，即必不可少的位置。等学会了这个，今后再加其他的属性（颜色、法线等等）就可以触类旁通了。

提供顶点属性缓存的是`IBufferable.GetVertexAttributeBufferPtr (string bufferName, string varNameInShader string bufferName, string varNameInShader);`这个方法。根据`bufferName`，这个方法提供用户需要的缓存对象。下面就是实现这个方法的框架结构。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #0000ff;">public</span> VertexAttributeBufferPtr GetVertexAttributeBufferPtr(<span style="color: #0000ff;">string</span> bufferName, <span style="color: #0000ff;">string</span><span style="color: #000000;"> varNameInShader)
</span><span style="color: #008080;"> 2</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 3</span>             <span style="color: #0000ff;">if</span> (bufferName ==<span style="color: #000000;"> KleinBottleModel.strPosition)
</span><span style="color: #008080;"> 4</span> <span style="color: #000000;">            {
</span><span style="color: #008080;"> 5</span>                 <span style="color: #0000ff;">if</span> (<span style="color: #0000ff;">this</span>.positionBufferPtr == <span style="color: #0000ff;">null</span><span style="color: #000000;">)
</span><span style="color: #008080;"> 6</span> <span style="color: #000000;">                {
</span><span style="color: #008080;"> 7</span>                     <span style="color: #0000ff;">this</span>.positionBufferPtr =<span style="color: #000000;"> GetPositionBufferPtr(varNameInShader);
</span><span style="color: #008080;"> 8</span> <span style="color: #000000;">                }
</span><span style="color: #008080;"> 9</span>                 <span style="color: #0000ff;">return</span> <span style="color: #0000ff;">this</span><span style="color: #000000;">.positionBufferPtr;
</span><span style="color: #008080;">10</span> <span style="color: #000000;">            }
</span><span style="color: #008080;">11</span>             <span style="color: #0000ff;">else</span>
<span style="color: #008080;">12</span> <span style="color: #000000;">            {
</span><span style="color: #008080;">13</span>                 <span style="color: #0000ff;">throw</span> <span style="color: #0000ff;">new</span><span style="color: #000000;"> ArgumentException();
</span><span style="color: #008080;">14</span> <span style="color: #000000;">            }
</span><span style="color: #008080;">15</span>         }</pre>
</div>

&nbsp;

具体创建位置缓存的方法如下。

<div class="cnblogs_code" onclick="cnblogs_code_show('dec3a89c-81f9-466c-9f71-ef3c4a7f69e6')">![](http://images.cnblogs.com/OutliningIndicators/ContractedBlock.gif)![](http://images.cnblogs.com/OutliningIndicators/ExpandedBlockStart.gif)
<div id="cnblogs_code_open_dec3a89c-81f9-466c-9f71-ef3c4a7f69e6" class="cnblogs_code_hide">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #0000ff;">private</span> VertexAttributeBufferPtr GetPositionBufferPtr(<span style="color: #0000ff;">string</span><span style="color: #000000;"> varNameInShader)
</span><span style="color: #008080;"> 2</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 3</span> VertexAttributeBufferPtr positionBufferPtr = <span style="color: #0000ff;">null</span><span style="color: #000000;">;
</span><span style="color: #008080;"> 4</span> <span style="color: #008000;">//</span><span style="color: #008000;"> 在CPU端创建缓存buffer，buffer实际上是一个数组，数组元素的类型为vec3。</span>
<span style="color: #008080;"> 5</span>             <span style="color: #0000ff;">using</span> (<span style="color: #0000ff;">var</span> buffer = <span style="color: #0000ff;">new</span> VertexAttributeBuffer&lt;vec3&gt;<span style="color: #000000;">(
</span><span style="color: #008080;"> 6</span> <span style="color: #000000;">                varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
</span><span style="color: #008080;"> 7</span> <span style="color: #000000;">            { 
</span><span style="color: #008080;"> 8</span>                 <span style="color: #0000ff;">int</span> uCount = GetUCount(<span style="color: #0000ff;">this</span><span style="color: #000000;">.interval);
</span><span style="color: #008080;"> 9</span>                 <span style="color: #0000ff;">int</span> vCount = GetVCount(<span style="color: #0000ff;">this</span><span style="color: #000000;">.interval);             
</span><span style="color: #008080;">10</span>                 <span style="color: #008000;">//</span><span style="color: #008000;"> 申请非托管数组（长度为uCount * vCount * sizeof(vec3)个字节）。到此才真正得到了一个可能很大的空间。</span>
<span style="color: #008080;">11</span>   buffer.Create(uCount *<span style="color: #000000;"> vCount);
</span><span style="color: #008080;">12</span>                 <span style="color: #0000ff;">unsafe</span>
<span style="color: #008080;">13</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">14</span>                     <span style="color: #0000ff;">int</span> index = <span style="color: #800080;">0</span><span style="color: #000000;">;
</span><span style="color: #008080;">15</span>                     <span style="color: #008000;">//</span><span style="color: #008000;"> 用unsafe方式设置数组元素的值。</span>
<span style="color: #008080;">16</span>                     <span style="color: #0000ff;">var</span> array = (vec3*<span style="color: #000000;">)buffer.Header.ToPointer();
</span><span style="color: #008080;">17</span>                     <span style="color: #0000ff;">for</span> (<span style="color: #0000ff;">int</span> uIndex = <span style="color: #800080;">0</span>; uIndex &lt; uCount; uIndex++<span style="color: #000000;">)
</span><span style="color: #008080;">18</span> <span style="color: #000000;">                    {
</span><span style="color: #008080;">19</span>                         <span style="color: #0000ff;">for</span> (<span style="color: #0000ff;">int</span> vIndex = <span style="color: #800080;">0</span>; vIndex &lt; vCount; vIndex++<span style="color: #000000;">)
</span><span style="color: #008080;">20</span> <span style="color: #000000;">                        {
</span><span style="color: #008080;">21</span>                             <span style="color: #0000ff;">double</span> u = Math.PI * uIndex /<span style="color: #000000;"> uCount;
</span><span style="color: #008080;">22</span>                             <span style="color: #0000ff;">double</span> v = Math.PI * <span style="color: #800080;">2</span> * vIndex /<span style="color: #000000;"> vCount;
</span><span style="color: #008080;">23</span>                             vec3 position =<span style="color: #000000;"> GetPosition(u, v);
</span><span style="color: #008080;">24</span>                             array[index++] =<span style="color: #000000;"> position;
</span><span style="color: #008080;">25</span> <span style="color: #000000;">                        }
</span><span style="color: #008080;">26</span> <span style="color: #000000;">                    }
</span><span style="color: #008080;">27</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">28</span> 
<span style="color: #008080;">29</span>                 <span style="color: #008000;">//</span><span style="color: #008000;"> GetBufferPtr()将CPU端的数组上传到GPU端，GPU返回此buffer的指针，将此指针及其相关数据封装起来，就成为了我们需要的位置缓存对象。</span>
<span style="color: #008080;">30</span>                 positionBufferPtr =<span style="color: #000000;"> buffer.GetBufferPtr();
</span><span style="color: #008080;">31</span>             }<span style="color: #008000;">//</span><span style="color: #008000;"> using(){} 结束，CPU端的非托管数组空间被释放。即CPU端不再需要保持buffer了。</span>
<span style="color: #008080;">32</span> 
<span style="color: #008080;">33</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> positionBufferPtr;
</span><span style="color: #008080;">34</span>         }</pre>
</div>
<span class="cnblogs_code_collapse">VertexAttributeBufferPtr GetPositionBufferPtr(string varNameInShader)</span></div>

&nbsp;

### 索引属性缓存

每个渲染器(Renderer)都需要一个索引缓存。索引缓存告诉GPU，顶点属性缓存里的数据是按怎样的顺序依次渲染的。本例用最简单的索引缓存`ZeroIndexBuffer`。`ZeroIndexBuffer`用`glDrawArrays()`这个OpenGL指令来渲染。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #0000ff;">private</span> IndexBufferPtr indexBufferPtr = <span style="color: #0000ff;">null</span><span style="color: #000000;">;
</span><span style="color: #008080;"> 2</span> 
<span style="color: #008080;"> 3</span>         <span style="color: #0000ff;">public</span><span style="color: #000000;"> IndexBufferPtr GetIndexBufferPtr()
</span><span style="color: #008080;"> 4</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 5</span>             <span style="color: #0000ff;">if</span> (indexBufferPtr == <span style="color: #0000ff;">null</span><span style="color: #000000;">)
</span><span style="color: #008080;"> 6</span> <span style="color: #000000;">            {
</span><span style="color: #008080;"> 7</span>                 <span style="color: #0000ff;">int</span> uCount =<span style="color: #000000;"> GetUCount(interval);
</span><span style="color: #008080;"> 8</span>                 <span style="color: #0000ff;">int</span> vCount =<span style="color: #000000;"> GetVCount(interval);
</span><span style="color: #008080;"> 9</span>                 <span style="color: #0000ff;">using</span> (<span style="color: #0000ff;">var</span> buffer = <span style="color: #0000ff;">new</span> ZeroIndexBuffer(DrawMode.Points, <span style="color: #800080;">0</span>, uCount *<span style="color: #000000;"> vCount))
</span><span style="color: #008080;">10</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">11</span>                     indexBufferPtr =<span style="color: #000000;"> buffer.GetBufferPtr();
</span><span style="color: #008080;">12</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">13</span> <span style="color: #000000;">            }
</span><span style="color: #008080;">14</span> 
<span style="color: #008080;">15</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> indexBufferPtr;
</span><span style="color: #008080;">16</span>         }</pre>
</div>

# 渲染器(Renderer)

渲染器要做的已经被`Renderer`类型封装好，只需继承之就可以。

## KleinBottleRenderer

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>     <span style="color: #0000ff;">class</span><span style="color: #000000;"> KleinBottleRenderer : Renderer
</span><span style="color: #008080;"> 2</span> <span style="color: #000000;">    {
</span><span style="color: #008080;"> 3</span>         <span style="color: #0000ff;">private</span><span style="color: #000000;"> KleinBottleRenderer(IBufferable model, ShaderCode[] shaderCodes,
</span><span style="color: #008080;"> 4</span>             AttributeNameMap attributeNameMap, <span style="color: #0000ff;">params</span><span style="color: #000000;"> GLSwitch[] switches)
</span><span style="color: #008080;"> 5</span>             : <span style="color: #0000ff;">base</span><span style="color: #000000;">(model, shaderCodes, attributeNameMap, switches)
</span><span style="color: #008080;"> 6</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 7</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 设定点的大小。</span>
<span style="color: #008080;"> 8</span>             <span style="color: #0000ff;">this</span>.switchList.Add(<span style="color: #0000ff;">new</span> PointSizeSwitch(<span style="color: #800080;">3</span><span style="color: #000000;">));
</span><span style="color: #008080;"> 9</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">10</span>     }</pre>
</div>

&nbsp;

你注意到这个`KleinBottleRenderer`的构造函数被标记为`private`。这是因为我们不想每次都让用户去指定那些参数（又麻烦又困难），我们用一个`static`方法来创建` KleinBottleRenderer `。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>     <span style="color: #0000ff;">class</span><span style="color: #000000;"> KleinBottleRenderer : Renderer
</span><span style="color: #008080;"> 2</span> <span style="color: #000000;">    {
</span><span style="color: #008080;"> 3</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span><span style="color: #000000;"> KleinBottleRenderer Create(KleinBottleModel model)
</span><span style="color: #008080;"> 4</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 5</span>             <span style="color: #0000ff;">var</span> shaderCodes = <span style="color: #0000ff;">new</span> ShaderCode[<span style="color: #800080;">2</span><span style="color: #000000;">];
</span><span style="color: #008080;"> 6</span>             shaderCodes[<span style="color: #800080;">0</span>] = <span style="color: #0000ff;">new</span> ShaderCode(File.ReadAllText(<span style="color: #800000;">@"</span><span style="color: #800000;">shaders\KleinBottle.vert</span><span style="color: #800000;">"</span><span style="color: #000000;">), ShaderType.VertexShader);
</span><span style="color: #008080;"> 7</span>             shaderCodes[<span style="color: #800080;">1</span>] = <span style="color: #0000ff;">new</span> ShaderCode(File.ReadAllText(<span style="color: #800000;">@"</span><span style="color: #800000;">shaders\KleinBottle.frag</span><span style="color: #800000;">"</span><span style="color: #000000;">), ShaderType.FragmentShader);
</span><span style="color: #008080;"> 8</span>             <span style="color: #0000ff;">var</span> map = <span style="color: #0000ff;">new</span><span style="color: #000000;"> AttributeNameMap();
</span><span style="color: #008080;"> 9</span>             map.Add(<span style="color: #800000;">"</span><span style="color: #800000;">in_Position</span><span style="color: #800000;">"</span>, <span style="color: #008000;">//</span><span style="color: #008000;"> variable name in vertex shader.</span>
<span style="color: #008080;">10</span> KleinBottleModel.strPosition <span style="color: #008000;">//</span><span style="color: #008000;"> buffer name in model.</span>
<span style="color: #008080;">11</span> <span style="color: #000000;">);
</span><span style="color: #008080;">12</span>             <span style="color: #0000ff;">var</span> renderer = <span style="color: #0000ff;">new</span><span style="color: #000000;"> KleinBottleRenderer(model, shaderCodes, map);
</span><span style="color: #008080;">13</span> 
<span style="color: #008080;">14</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> renderer;
</span><span style="color: #008080;">15</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">16</span>     }</pre>
</div>

&nbsp;
 你注意到这里有个`AttributeNameMap`对象，它指定了shader中的in属性与`IBufferable`模型中的顶点属性的对应关系。有了这个map，`Renderer`才能把shader和模型关联起来。
## Override渲染功能

对于每个具体的Renderer，或多或少都有各自的特殊设定。因此需要override DoRender();方法。此方法完成了真正执行渲染的功能。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>     <span style="color: #0000ff;">class</span><span style="color: #000000;"> KleinBottleRenderer : Renderer
</span><span style="color: #008080;"> 2</span> <span style="color: #000000;">    {
</span><span style="color: #008080;"> 3</span>         <span style="color: #0000ff;">public</span> vec3 UniformColor { <span style="color: #0000ff;">get</span>; <span style="color: #0000ff;">set</span><span style="color: #000000;">; }
</span><span style="color: #008080;"> 4</span>         
<span style="color: #008080;"> 5</span>         <span style="color: #0000ff;">protected</span> <span style="color: #0000ff;">override</span> <span style="color: #0000ff;">void</span><span style="color: #000000;"> DoRender(RenderEventArgs arg)
</span><span style="color: #008080;"> 6</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 7</span>             mat4 projection =<span style="color: #000000;"> arg.Camera.GetProjectionMatrix();
</span><span style="color: #008080;"> 8</span>             mat4 view =<span style="color: #000000;"> arg.Camera.GetViewMatrix();
</span><span style="color: #008080;"> 9</span>             mat4 model = <span style="color: #0000ff;">this</span><span style="color: #000000;">.GetModelMatrix();
</span><span style="color: #008080;">10</span>             <span style="color: #0000ff;">this</span>.SetUniform(<span style="color: #800000;">"</span><span style="color: #800000;">projectionMatrix</span><span style="color: #800000;">"</span>, <span style="color: #008000;">//</span><span style="color: #008000;"> variable name in shader.</span>
<span style="color: #008080;">11</span> <span style="color: #000000;">projection);
</span><span style="color: #008080;">12</span>             <span style="color: #0000ff;">this</span>.SetUniform(<span style="color: #800000;">"</span><span style="color: #800000;">viewMatrix</span><span style="color: #800000;">"</span>, <span style="color: #008000;">//</span><span style="color: #008000;"> variable name in shader.</span>
<span style="color: #008080;">13</span> <span style="color: #000000;">view);
</span><span style="color: #008080;">14</span>             <span style="color: #0000ff;">this</span>.SetUniform(<span style="color: #800000;">"</span><span style="color: #800000;">modelMatrix</span><span style="color: #800000;">"</span>, <span style="color: #008000;">//</span><span style="color: #008000;"> variable name in shader.</span>
<span style="color: #008080;">15</span> <span style="color: #000000;">model);
</span><span style="color: #008080;">16</span>             <span style="color: #0000ff;">this</span>.SetUniform(<span style="color: #800000;">"</span><span style="color: #800000;">uniformColor</span><span style="color: #800000;">"</span>, <span style="color: #008000;">//</span><span style="color: #008000;"> variable name in shader.</span>
<span style="color: #008080;">17</span> <span style="color: #0000ff;">this</span><span style="color: #000000;">.uniformColor);
</span><span style="color: #008080;">18</span> 
<span style="color: #008080;">19</span>             <span style="color: #0000ff;">base</span><span style="color: #000000;">.DoRender(arg);
</span><span style="color: #008080;">20</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">21</span>     }</pre>
</div>

&nbsp;

可见一般都是设定一些uniform变量。

## Override 初始化功能

对于每个具体的Renderer，或多或少都有各自的特殊项目需要初始化。因此需要override DoInitialize();方法。不过本例实际上并不需要。

<div class="cnblogs_code">
<pre><span style="color: #008080;">1</span>     <span style="color: #0000ff;">class</span><span style="color: #000000;"> KleinBottleRenderer : Renderer
</span><span style="color: #008080;">2</span> <span style="color: #000000;">    {
</span><span style="color: #008080;">3</span>         <span style="color: #0000ff;">protected</span> <span style="color: #0000ff;">override</span> <span style="color: #0000ff;">void</span><span style="color: #000000;"> DoInitialize()
</span><span style="color: #008080;">4</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">5</span>             <span style="color: #0000ff;">base</span><span style="color: #000000;">.DoInitialize();
</span><span style="color: #008080;">6</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">7</span>     }</pre>
</div>

现在渲染功能准备完毕，我们把它放到窗口上，真正画出来。

# GLCanvas

## 拽控件

首先我们在项目中添加一个窗口。

&nbsp;![](http://images2015.cnblogs.com/blog/383191/201609/383191-20160930122847328-1784351930.png)

&nbsp;![](http://images2015.cnblogs.com/blog/383191/201609/383191-20160930122855610-1009011390.png)

然后拽一个GLCanvas控件进来。

&nbsp;![](http://images2015.cnblogs.com/blog/383191/201609/383191-20160930122903813-853468803.png)

稍微布局一下，好看点。

&nbsp;![](http://images2015.cnblogs.com/blog/383191/201609/383191-20160930122911000-255746332.png)

关闭这个窗口，然后重新打开，你应该能看到下面的景象。立方体不停地旋转，钟表则一直显示当前时间，左下角写着控件全名，左上角是FPS。这表明GLCanvas运转良好。

&nbsp;![](http://images2015.cnblogs.com/blog/383191/201609/383191-20160930122918078-1957302808.png)

## 场景

控件就准备好了。下面就把一个 KlienBottleRenderer加入此控件。

首先来准备好场景`Scene`，有了场景，就可以添加、管理多个Renderer。当然，本例只需要1个。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #0000ff;">private</span><span style="color: #000000;"> Scene scene;
</span><span style="color: #008080;"> 2</span> 
<span style="color: #008080;"> 3</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">void</span> Form_Load(<span style="color: #0000ff;">object</span><span style="color: #000000;"> sender, EventArgs e)
</span><span style="color: #008080;"> 4</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 5</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> step 1.
</span><span style="color: #008080;"> 6</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 创建摄像机。</span>
<span style="color: #008080;"> 7</span>             <span style="color: #0000ff;">var</span> camera = <span style="color: #0000ff;">new</span><span style="color: #000000;"> Camera(
</span><span style="color: #008080;"> 8</span>                 <span style="color: #0000ff;">new</span> vec3(<span style="color: #800080;">3</span>, <span style="color: #800080;">4</span>, <span style="color: #800080;">5</span>) * <span style="color: #800080;">4</span>, <span style="color: #0000ff;">new</span> vec3(<span style="color: #800080;">0</span>, <span style="color: #800080;">0</span>, <span style="color: #800080;">0</span>), <span style="color: #0000ff;">new</span> vec3(<span style="color: #800080;">0</span>, <span style="color: #800080;">1</span>, <span style="color: #800080;">0</span><span style="color: #000000;">),
</span><span style="color: #008080;"> 9</span>                 CameraType.Perspecitive, <span style="color: #0000ff;">this</span>.glCanvas1.Width, <span style="color: #0000ff;">this</span><span style="color: #000000;">.glCanvas1.Height);
</span><span style="color: #008080;">10</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 指定移动摄像机的方式（让摄像机像卫星一样围绕目标旋转）。</span>
<span style="color: #008080;">11</span>             <span style="color: #0000ff;">var</span> rotator = <span style="color: #0000ff;">new</span><span style="color: #000000;"> SatelliteManipulater();
</span><span style="color: #008080;">12</span>             rotator.Bind(camera, <span style="color: #0000ff;">this</span><span style="color: #000000;">.glCanvas1);
</span><span style="color: #008080;">13</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 创建场景。</span>
<span style="color: #008080;">14</span>             <span style="color: #0000ff;">var</span> scene = <span style="color: #0000ff;">new</span> Scene(camera, <span style="color: #0000ff;">this</span><span style="color: #000000;">.glCanvas1);
</span><span style="color: #008080;">15</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 指定背景色。</span>
<span style="color: #008080;">16</span>             scene.ClearColor =<span style="color: #000000;"> Color.SkyBlue;
</span><span style="color: #008080;">17</span>             <span style="color: #0000ff;">this</span>.scene =<span style="color: #000000;"> scene;
</span><span style="color: #008080;">18</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 指定Resize如何处理。</span>
<span style="color: #008080;">19</span>             <span style="color: #0000ff;">this</span>.glCanvas1.Resize += <span style="color: #0000ff;">this</span><span style="color: #000000;">.scene.Resize;
</span><span style="color: #008080;">20</span> 
<span style="color: #008080;">21</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> step 2.
</span><span style="color: #008080;">22</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> &hellip;</span>
<span style="color: #008080;">23</span>         }</pre>
</div>

&nbsp;

## 场景对象

有场景了，该往里面加一些能渲染的对象了。本例就加入一个` KleinBottleRenderer`。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span> <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">void</span> Form_Load(<span style="color: #0000ff;">object</span><span style="color: #000000;"> sender, EventArgs e)
</span><span style="color: #008080;"> 2</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 3</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> step 1.
</span><span style="color: #008080;"> 4</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> &hellip;
</span><span style="color: #008080;"> 5</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> step 2.
</span><span style="color: #008080;"> 6</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 创建Renderer。</span>
<span style="color: #008080;"> 7</span>             KleinBottleRenderer renderer = KleinBottleRenderer.Create(<span style="color: #0000ff;">new</span> KleinBottleModel(interval: <span style="color: #800080;">0.2</span><span style="color: #000000;">));
</span><span style="color: #008080;"> 8</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 把renderer封装为SceneObject。</span>
<span style="color: #008080;"> 9</span>             SceneObject obj = renderer.WrapToSceneObject(generateBoundingBox: <span style="color: #0000ff;">true</span><span style="color: #000000;">);
</span><span style="color: #008080;">10</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 把SceneObject加入场景的对象列表（其实是个树结构）。</span>
<span style="color: #008080;">11</span>             <span style="color: #0000ff;">this</span><span style="color: #000000;">.scene.RootObject.Children.Add(obj);
</span><span style="color: #008080;">12</span>         }</pre>
</div>

## UI

其实这样就可以了。不过为了更多地展示Scene的能力，我们再添加一个UI对象&mdash;&mdash;坐标轴到窗口的左下角。

<div class="cnblogs_code">
<pre><span style="color: #008080;">1</span> <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">void</span> Form_Load(<span style="color: #0000ff;">object</span><span style="color: #000000;"> sender, EventArgs e)
</span><span style="color: #008080;">2</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">3</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> step 3.
</span><span style="color: #008080;">4</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 创建一个坐标轴对象。</span>
<span style="color: #008080;">5</span>             <span style="color: #0000ff;">var</span> uiAxis = <span style="color: #0000ff;">new</span> UIAxis(AnchorStyles.Left |<span style="color: #000000;"> AnchorStyles.Bottom,
</span><span style="color: #008080;">6</span>                 <span style="color: #0000ff;">new</span> Padding(<span style="color: #800080;">3</span>, <span style="color: #800080;">3</span>, <span style="color: #800080;">3</span>, <span style="color: #800080;">3</span>), <span style="color: #0000ff;">new</span> Size(<span style="color: #800080;">128</span>, <span style="color: #800080;">128</span><span style="color: #000000;">));
</span><span style="color: #008080;">7</span>             <span style="color: #008000;">//</span><span style="color: #008000;"> 坐标轴对象加入到场景里的UI列表（其实是个树结构）。</span>
<span style="color: #008080;">8</span>             <span style="color: #0000ff;">this</span><span style="color: #000000;">.scene.UIRoot.Children.Add(uiAxis);
</span><span style="color: #008080;">9</span>         }</pre>
</div>

# 其他

至此你就可以看到本文开始处渲染出的效果了。

使用CSharpGL，你可以获得如下好处：

★不必担心使用OpenGL指令时不小心用错了各种各样的target、param等标记。这种易错又难易排查的问题往往会让初学者想去自杀。

★CSharpGL会自动释放那些不需要的CPU端Buffer占用的内存。CSharpGL通过封装好的Buffer对象的使用方式，保证了不需要的大量空间会被及时释放。

★CSharpGL封装了拾取、拖拽模型、UI、文字、场景等常用的功能，你只需继承这些类型即可使用。CSharpGL对每项功能都提供了Demo，运行这些demo，就可以得知如何使用这些功能。

★可以用PropertyGrid来实时控制渲染效果，这是十分便利的工具。例如本例中，你可以用PointSizeSwitch来控制渲染的顶点的大小。

&nbsp;![](http://images2015.cnblogs.com/blog/383191/201609/383191-20160930122945688-1860094329.png)

&nbsp;![](http://images2015.cnblogs.com/blog/383191/201609/383191-20160930122953641-1583508158.png)

★我将持续更新CSharpGL。虽然不能保证最后能做到多好多强大。。。。。。

&nbsp;

# 总结

欢迎提问。

&nbsp;