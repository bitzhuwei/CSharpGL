<span style="font-size: 18px; font-family: 'Microsoft YaHei';">CSharpGL(36)通用的非托管数组排序方法</span>

&nbsp;

如果OpenGL要渲染半透明物体，一个方法是根据顶点到窗口的距离排序，按照从远到近的顺序依次渲染。所以本篇介绍对&nbsp;<span class="cnblogs_code">UnmanagedArray&lt;T&gt;</span>&nbsp;进行排序的几种方法。

# UnmanagedArray&lt;T&gt;

首先重新介绍一下非托管数组这个东西。一个&nbsp;<span class="cnblogs_code">UnmanagedArray&lt;<span style="color: #0000ff;">float</span>&gt;</span>&nbsp;与一个&nbsp;<span class="cnblogs_code"><span style="color: #0000ff;">float</span>[]</span>&nbsp;是一样的用处，只不过&nbsp;<span class="cnblogs_code">UnmanagedArray&lt;<span style="color: #0000ff;">float</span>&gt;</span>&nbsp;是用&nbsp;<span class="cnblogs_code">Marshal.AllocHGlobal(memSize);</span>&nbsp;在非托管内存上申请的空间。

<div class="cnblogs_code" onclick="cnblogs_code_show('fbc1e778-d9dc-4660-ae15-54fabd2ec8c2')">![](http://images.cnblogs.com/OutliningIndicators/ContractedBlock.gif)![](http://images.cnblogs.com/OutliningIndicators/ExpandedBlockStart.gif)
<div id="cnblogs_code_open_fbc1e778-d9dc-4660-ae15-54fabd2ec8c2" class="cnblogs_code_hide">
<pre><span style="color: #008080;"> 1</span> <span style="color: #0000ff;">namespace</span><span style="color: #000000;"> CSharpGL
</span><span style="color: #008080;"> 2</span> <span style="color: #000000;">{
</span><span style="color: #008080;"> 3</span>     <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;"> 4</span>     <span style="color: #808080;">///</span><span style="color: #008000;"> unmanaged huge array.
</span><span style="color: #008080;"> 5</span>     <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;para&gt;</span><span style="color: #008000;">Check </span><span style="color: #008000; text-decoration: underline;">http://www.cnblogs.com/bitzhuwei/p/huge-unmanged-array-in-csharp.html</span> <span style="color: #808080;">&lt;/para&gt;</span>
<span style="color: #008080;"> 6</span>     <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;"> 7</span>     <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;typeparam name="T"&gt;</span><span style="color: #008000;">sbyte, byte, char, short, ushort, int, uint, long, ulong, float, double, decimal, bool or other struct types. enum not supported.</span><span style="color: #808080;">&lt;/typeparam&gt;</span>
<span style="color: #008080;"> 8</span>     <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">sealed</span> <span style="color: #0000ff;">unsafe</span> <span style="color: #0000ff;">class</span> UnmanagedArray&lt;T&gt; : UnmanagedArrayBase <span style="color: #0000ff;">where</span> T : <span style="color: #0000ff;">struct</span>
<span style="color: #008080;"> 9</span> <span style="color: #000000;">    {
</span><span style="color: #008080;">10</span>         <span style="color: #0000ff;">public</span> UnmanagedArray(<span style="color: #0000ff;">int</span><span style="color: #000000;"> count)
</span><span style="color: #008080;">11</span>             : <span style="color: #0000ff;">base</span>(count, Marshal.SizeOf(<span style="color: #0000ff;">typeof</span><span style="color: #000000;">(T)))
</span><span style="color: #008080;">12</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">13</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">14</span> <span style="color: #000000;">    }
</span><span style="color: #008080;">15</span> 
<span style="color: #008080;">16</span>     <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;">17</span>     <span style="color: #808080;">///</span><span style="color: #008000;"> Base type of unmanaged array.
</span><span style="color: #008080;">18</span>     <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;para&gt;</span><span style="color: #008000;">Similar to array in </span><span style="color: #808080;">&lt;code&gt;</span><span style="color: #008000;">int array[Length];</span><span style="color: #808080;">&lt;/code&gt;&lt;/para&gt;</span>
<span style="color: #008080;">19</span>     <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;">20</span>     <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">abstract</span> <span style="color: #0000ff;">class</span><span style="color: #000000;"> UnmanagedArrayBase : IDisposable
</span><span style="color: #008080;">21</span> <span style="color: #000000;">    {
</span><span style="color: #008080;">22</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;">23</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> 此非托管数组中的数据在内存中的起始地址
</span><span style="color: #008080;">24</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> Start position of array; Head of array; first element's position of array.
</span><span style="color: #008080;">25</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;para&gt;</span><span style="color: #008000;">Similar to </span><span style="color: #808080;">&lt;code&gt;</span><span style="color: #008000;">array</span><span style="color: #808080;">&lt;/code&gt;</span><span style="color: #008000;"> in </span><span style="color: #808080;">&lt;code&gt;</span><span style="color: #008000;">int array[Length];</span><span style="color: #808080;">&lt;/code&gt;&lt;/para&gt;</span>
<span style="color: #008080;">26</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;">27</span>         <span style="color: #0000ff;">public</span> IntPtr Header { <span style="color: #0000ff;">get</span>; <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">set</span><span style="color: #000000;">; }
</span><span style="color: #008080;">28</span> 
<span style="color: #008080;">29</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;">30</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> How many elements?
</span><span style="color: #008080;">31</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;para&gt;</span><span style="color: #008000;">Similar to </span><span style="color: #808080;">&lt;code&gt;</span><span style="color: #008000;">Length</span><span style="color: #808080;">&lt;/code&gt;</span><span style="color: #008000;"> in </span><span style="color: #808080;">&lt;code&gt;</span><span style="color: #008000;">int array[Length];</span><span style="color: #808080;">&lt;/code&gt;&lt;/para&gt;</span>
<span style="color: #008080;">32</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;">33</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">int</span> Length { <span style="color: #0000ff;">get</span>; <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">set</span><span style="color: #000000;">; }
</span><span style="color: #008080;">34</span> 
<span style="color: #008080;">35</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;">36</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> 单个元素的字节数。
</span><span style="color: #008080;">37</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;para&gt;</span><span style="color: #008000;">How manay bytes for one element of array?</span><span style="color: #808080;">&lt;/para&gt;</span>
<span style="color: #008080;">38</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;">39</span>         <span style="color: #0000ff;">protected</span> <span style="color: #0000ff;">int</span><span style="color: #000000;"> elementSize;
</span><span style="color: #008080;">40</span> 
<span style="color: #008080;">41</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;">42</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> 申请到的字节数。（元素的总数 * 单个元素的字节数）。
</span><span style="color: #008080;">43</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;para&gt;</span><span style="color: #008000;">How many bytes for total array?</span><span style="color: #808080;">&lt;/para&gt;</span>
<span style="color: #008080;">44</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;para&gt;</span><span style="color: #008000;">Length * elementSize</span><span style="color: #808080;">&lt;/para&gt;</span>
<span style="color: #008080;">45</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;">46</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">int</span><span style="color: #000000;"> ByteLength
</span><span style="color: #008080;">47</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">48</span>             <span style="color: #0000ff;">get</span> { <span style="color: #0000ff;">return</span> (<span style="color: #0000ff;">this</span>.Length * <span style="color: #0000ff;">this</span><span style="color: #000000;">.elementSize); }
</span><span style="color: #008080;">49</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">50</span> 
<span style="color: #008080;">51</span>         <span style="color: #0000ff;">protected</span> UnmanagedArrayBase(<span style="color: #0000ff;">int</span> elementCount, <span style="color: #0000ff;">int</span><span style="color: #000000;"> elementSize)
</span><span style="color: #008080;">52</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">53</span>             <span style="color: #0000ff;">this</span>.Length =<span style="color: #000000;"> elementCount;
</span><span style="color: #008080;">54</span>             <span style="color: #0000ff;">this</span>.elementSize =<span style="color: #000000;"> elementSize;
</span><span style="color: #008080;">55</span>             <span style="color: #0000ff;">int</span> memSize = <span style="color: #0000ff;">this</span>.Length * <span style="color: #0000ff;">this</span><span style="color: #000000;">.elementSize;
</span><span style="color: #008080;">56</span>             <span style="color: #0000ff;">this</span>.Header =<span style="color: #000000;"> Marshal.AllocHGlobal(memSize);
</span><span style="color: #008080;">57</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">58</span> <span style="color: #000000;">    }
</span><span style="color: #008080;">59</span> }</pre>
</div>
<span class="cnblogs_code_collapse">UnmanagedArray&lt;T&gt;</span>&nbsp;</div>

## UnmanagedArray&lt;float&gt;

下面我们以&nbsp;<span class="cnblogs_code">UnmanagedArray&lt;<span style="color: #0000ff;">float</span>&gt;</span>&nbsp;为例，实现对非托管数组的排序。（下面是快速排序算法）

<div class="cnblogs_code" onclick="cnblogs_code_show('7ecf2047-5cde-44fc-9d1f-833584988439')">![](http://images.cnblogs.com/OutliningIndicators/ContractedBlock.gif)![](http://images.cnblogs.com/OutliningIndicators/ExpandedBlockStart.gif)
<div id="cnblogs_code_open_7ecf2047-5cde-44fc-9d1f-833584988439" class="cnblogs_code_hide">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> Sort(<span style="color: #0000ff;">this</span> UnmanagedArray&lt;<span style="color: #0000ff;">float</span>&gt; array, <span style="color: #0000ff;">bool</span><span style="color: #000000;"> descending)
</span><span style="color: #008080;"> 2</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 3</span>             QuickSort(array, <span style="color: #800080;">0</span>, array.Length - <span style="color: #800080;">1</span><span style="color: #000000;">, descending);
</span><span style="color: #008080;"> 4</span> <span style="color: #000000;">        }
</span><span style="color: #008080;"> 5</span> 
<span style="color: #008080;"> 6</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> Sort(UnmanagedArray&lt;<span style="color: #0000ff;">float</span>&gt; array, <span style="color: #0000ff;">int</span> start, <span style="color: #0000ff;">int</span> length, <span style="color: #0000ff;">bool</span><span style="color: #000000;"> descending)
</span><span style="color: #008080;"> 7</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 8</span>             QuickSort(array, start, start + length - <span style="color: #800080;">1</span><span style="color: #000000;">, descending);
</span><span style="color: #008080;"> 9</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">10</span> 
<span style="color: #008080;">11</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> QuickSort(UnmanagedArray&lt;<span style="color: #0000ff;">float</span>&gt; array, <span style="color: #0000ff;">int</span> start, <span style="color: #0000ff;">int</span> end, <span style="color: #0000ff;">bool</span><span style="color: #000000;"> descending)
</span><span style="color: #008080;">12</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">13</span>             <span style="color: #0000ff;">if</span> (start &gt;= end) { <span style="color: #0000ff;">return</span><span style="color: #000000;">; }
</span><span style="color: #008080;">14</span> 
<span style="color: #008080;">15</span>             Stack&lt;<span style="color: #0000ff;">int</span>&gt; stack = <span style="color: #0000ff;">new</span> Stack&lt;<span style="color: #0000ff;">int</span>&gt;<span style="color: #000000;">();
</span><span style="color: #008080;">16</span> <span style="color: #000000;">            stack.Push(end);
</span><span style="color: #008080;">17</span> <span style="color: #000000;">            stack.Push(start);
</span><span style="color: #008080;">18</span> <span style="color: #000000;">            QuickSort(array, descending, stack);
</span><span style="color: #008080;">19</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">20</span> 
<span style="color: #008080;">21</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> QuickSort(UnmanagedArray&lt;<span style="color: #0000ff;">float</span>&gt; array, <span style="color: #0000ff;">bool</span> descending, Stack&lt;<span style="color: #0000ff;">int</span>&gt;<span style="color: #000000;"> stack)
</span><span style="color: #008080;">22</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">23</span>             <span style="color: #0000ff;">while</span> (stack.Count &gt; <span style="color: #800080;">0</span><span style="color: #000000;">)
</span><span style="color: #008080;">24</span> <span style="color: #000000;">            {
</span><span style="color: #008080;">25</span>                 <span style="color: #0000ff;">int</span> start =<span style="color: #000000;"> stack.Pop();
</span><span style="color: #008080;">26</span>                 <span style="color: #0000ff;">int</span> end =<span style="color: #000000;"> stack.Pop();
</span><span style="color: #008080;">27</span>                 <span style="color: #0000ff;">int</span> index =<span style="color: #000000;"> QuickSortPartion(array, start, end, descending);
</span><span style="color: #008080;">28</span>                 <span style="color: #0000ff;">if</span> (start &lt; index - <span style="color: #800080;">1</span><span style="color: #000000;">)
</span><span style="color: #008080;">29</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">30</span>                     stack.Push(index - <span style="color: #800080;">1</span><span style="color: #000000;">); stack.Push(start);
</span><span style="color: #008080;">31</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">32</span>                 <span style="color: #0000ff;">if</span> (index + <span style="color: #800080;">1</span> &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">33</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">34</span>                     stack.Push(end); stack.Push(index + <span style="color: #800080;">1</span><span style="color: #000000;">);
</span><span style="color: #008080;">35</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">36</span> <span style="color: #000000;">            }
</span><span style="color: #008080;">37</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">38</span> 
<span style="color: #008080;">39</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">unsafe</span> <span style="color: #0000ff;">int</span> QuickSortPartion(UnmanagedArray&lt;<span style="color: #0000ff;">float</span>&gt; array, <span style="color: #0000ff;">int</span> start, <span style="color: #0000ff;">int</span> end, <span style="color: #0000ff;">bool</span><span style="color: #000000;"> descending)
</span><span style="color: #008080;">40</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">41</span>             <span style="color: #0000ff;">float</span>* pointer = (<span style="color: #0000ff;">float</span>*<span style="color: #000000;">)array.Header.ToPointer();
</span><span style="color: #008080;">42</span>             <span style="color: #0000ff;">float</span><span style="color: #000000;"> pivot, startValue, endValue;
</span><span style="color: #008080;">43</span>             pivot =<span style="color: #000000;"> pointer[start];
</span><span style="color: #008080;">44</span>             <span style="color: #0000ff;">while</span> (start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">45</span> <span style="color: #000000;">            {
</span><span style="color: #008080;">46</span>                 startValue =<span style="color: #000000;"> pointer[start];
</span><span style="color: #008080;">47</span>                 <span style="color: #0000ff;">while</span> ((start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">48</span>                     &amp;&amp; ((descending &amp;&amp; (startValue.CompareTo(pivot) &gt; <span style="color: #800080;">0</span><span style="color: #000000;">))
</span><span style="color: #008080;">49</span>                         || (!descending) &amp;&amp; (startValue.CompareTo(pivot) &lt; <span style="color: #800080;">0</span><span style="color: #000000;">)))
</span><span style="color: #008080;">50</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">51</span>                     start++<span style="color: #000000;">;
</span><span style="color: #008080;">52</span>                     startValue =<span style="color: #000000;"> pointer[start];
</span><span style="color: #008080;">53</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">54</span> 
<span style="color: #008080;">55</span>                 endValue =<span style="color: #000000;"> pointer[end];
</span><span style="color: #008080;">56</span>                 <span style="color: #0000ff;">while</span> ((start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">57</span>                     &amp;&amp; ((descending &amp;&amp; (endValue.CompareTo(pivot) &lt; <span style="color: #800080;">0</span><span style="color: #000000;">))
</span><span style="color: #008080;">58</span>                         || (!descending) &amp;&amp; (endValue.CompareTo(pivot) &gt; <span style="color: #800080;">0</span><span style="color: #000000;">)))
</span><span style="color: #008080;">59</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">60</span>                     end--<span style="color: #000000;">;
</span><span style="color: #008080;">61</span>                     endValue =<span style="color: #000000;"> pointer[end];
</span><span style="color: #008080;">62</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">63</span> 
<span style="color: #008080;">64</span>                 <span style="color: #0000ff;">if</span> (start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">65</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">66</span>                     pointer[end] =<span style="color: #000000;"> startValue;
</span><span style="color: #008080;">67</span>                     pointer[start] =<span style="color: #000000;"> endValue;
</span><span style="color: #008080;">68</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">69</span> <span style="color: #000000;">            }
</span><span style="color: #008080;">70</span> 
<span style="color: #008080;">71</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> start;
</span><span style="color: #008080;">72</span>         }</pre>
</div>
<span class="cnblogs_code_collapse">public static void Sort(this UnmanagedArray array, bool descending)</span></div>

原本我以为把这个方法改写一下，用&nbsp;<span class="cnblogs_code">T</span>代替具体的&nbsp;<span class="cnblogs_code"><span style="color: #0000ff;">float</span></span>&nbsp;，就可以实现对任意&nbsp;<span class="cnblogs_code">T <span style="color: #0000ff;">where</span> T : <span style="color: #0000ff;">struct</span>,IComparable&lt;T&gt;</span>&nbsp;的排序，但是VS报了这样的编译错误：**无法获取托管类型(&ldquo;T&rdquo;)的地址和大小，或无法声明指向它的指针**。

&nbsp;![](http://images2015.cnblogs.com/blog/383191/201610/383191-20161023142526654-1479434690.png)

看来C#不允许将泛型T作为unsafe里的数组的类型。那么只能用下面的几种方式变通一下。

## Marshal

&nbsp;<span class="cnblogs_code">Marshal</span>&nbsp;有这样2个方法：

<div class="cnblogs_code">
<pre><span style="color: #008080;">1</span> <span style="color: #008000;">//</span><span style="color: #008000;"> 从非托管数组中读取一个元素</span>
<span style="color: #008080;">2</span> <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">object</span><span style="color: #000000;"> PtrToStructure(IntPtr ptr, Type structureType);
</span><span style="color: #008080;">3</span> <span style="color: #008000;">//</span><span style="color: #008000;"> 向非托管数组写入一个元素</span>
<span style="color: #008080;">4</span> <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> StructureToPtr(<span style="color: #0000ff;">object</span> structure, IntPtr ptr, <span style="color: #0000ff;">bool</span> fDeleteOld);</pre>
</div>

用这2个方法就可以实现对非托管数组的读写操作。于是泛型版本(&nbsp;<span class="cnblogs_code">UnmagedArray&lt;T&gt;</span>&nbsp;)的排序算法就实现了。

<div class="cnblogs_code" onclick="cnblogs_code_show('adc6aa4f-1aaa-46f5-9397-fe02b3385801')">![](http://images.cnblogs.com/OutliningIndicators/ContractedBlock.gif)![](http://images.cnblogs.com/OutliningIndicators/ExpandedBlockStart.gif)
<div id="cnblogs_code_open_adc6aa4f-1aaa-46f5-9397-fe02b3385801" class="cnblogs_code_hide">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> Sort&lt;T&gt;(<span style="color: #0000ff;">this</span> UnmanagedArray&lt;T&gt; array, <span style="color: #0000ff;">bool</span> descending) <span style="color: #0000ff;">where</span> T : <span style="color: #0000ff;">struct</span>, IComparable&lt;T&gt;
<span style="color: #008080;"> 2</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 3</span>             QuickSort(array, <span style="color: #800080;">0</span>, array.Length - <span style="color: #800080;">1</span><span style="color: #000000;">, descending);
</span><span style="color: #008080;"> 4</span> <span style="color: #000000;">        }
</span><span style="color: #008080;"> 5</span> 
<span style="color: #008080;"> 6</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> Sort&lt;T&gt;(<span style="color: #0000ff;">this</span> UnmanagedArray&lt;T&gt; array, <span style="color: #0000ff;">int</span> start, <span style="color: #0000ff;">int</span> length, <span style="color: #0000ff;">bool</span> descending) <span style="color: #0000ff;">where</span> T : <span style="color: #0000ff;">struct</span>, IComparable&lt;T&gt;
<span style="color: #008080;"> 7</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 8</span>             QuickSort(array, start, start + length - <span style="color: #800080;">1</span><span style="color: #000000;">, descending);
</span><span style="color: #008080;"> 9</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">10</span> 
<span style="color: #008080;">11</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> QuickSort&lt;T&gt;(UnmanagedArray&lt;T&gt; array, <span style="color: #0000ff;">int</span> start, <span style="color: #0000ff;">int</span> end, <span style="color: #0000ff;">bool</span> descending) <span style="color: #0000ff;">where</span> T : <span style="color: #0000ff;">struct</span>, IComparable&lt;T&gt;
<span style="color: #008080;">12</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">13</span>             <span style="color: #0000ff;">if</span> (start &gt;= end) { <span style="color: #0000ff;">return</span><span style="color: #000000;">; }
</span><span style="color: #008080;">14</span> 
<span style="color: #008080;">15</span>             <span style="color: #0000ff;">var</span> stack = <span style="color: #0000ff;">new</span> Stack&lt;<span style="color: #0000ff;">int</span>&gt;<span style="color: #000000;">();
</span><span style="color: #008080;">16</span> <span style="color: #000000;">            stack.Push(end);
</span><span style="color: #008080;">17</span> <span style="color: #000000;">            stack.Push(start);
</span><span style="color: #008080;">18</span> <span style="color: #000000;">            QuickSort(array, descending, stack);
</span><span style="color: #008080;">19</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">20</span> 
<span style="color: #008080;">21</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> QuickSort&lt;T&gt;(UnmanagedArray&lt;T&gt; array, <span style="color: #0000ff;">bool</span> descending, Stack&lt;<span style="color: #0000ff;">int</span>&gt; stack) <span style="color: #0000ff;">where</span> T : <span style="color: #0000ff;">struct</span>, IComparable&lt;T&gt;
<span style="color: #008080;">22</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">23</span>             IntPtr pointer =<span style="color: #000000;"> array.Header;
</span><span style="color: #008080;">24</span>             Type type = <span style="color: #0000ff;">typeof</span><span style="color: #000000;">(T);
</span><span style="color: #008080;">25</span>             <span style="color: #0000ff;">int</span> elementSize =<span style="color: #000000;"> Marshal.SizeOf(type);
</span><span style="color: #008080;">26</span> 
<span style="color: #008080;">27</span>             <span style="color: #0000ff;">while</span> (stack.Count &gt; <span style="color: #800080;">0</span><span style="color: #000000;">)
</span><span style="color: #008080;">28</span> <span style="color: #000000;">            {
</span><span style="color: #008080;">29</span>                 <span style="color: #0000ff;">int</span> start =<span style="color: #000000;"> stack.Pop();
</span><span style="color: #008080;">30</span>                 <span style="color: #0000ff;">int</span> end =<span style="color: #000000;"> stack.Pop();
</span><span style="color: #008080;">31</span>                 <span style="color: #0000ff;">int</span> index =<span style="color: #000000;"> QuickSortPartion(array, start, end, descending, type, elementSize);
</span><span style="color: #008080;">32</span>                 <span style="color: #0000ff;">if</span> (start &lt; index - <span style="color: #800080;">1</span><span style="color: #000000;">)
</span><span style="color: #008080;">33</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">34</span>                     stack.Push(index - <span style="color: #800080;">1</span><span style="color: #000000;">); stack.Push(start);
</span><span style="color: #008080;">35</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">36</span>                 <span style="color: #0000ff;">if</span> (index + <span style="color: #800080;">1</span> &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">37</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">38</span>                     stack.Push(end); stack.Push(index + <span style="color: #800080;">1</span><span style="color: #000000;">);
</span><span style="color: #008080;">39</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">40</span> <span style="color: #000000;">            }
</span><span style="color: #008080;">41</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">42</span> 
<span style="color: #008080;">43</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">int</span> QuickSortPartion&lt;T&gt;(UnmanagedArray&lt;T&gt; array, <span style="color: #0000ff;">int</span> start, <span style="color: #0000ff;">int</span> end, <span style="color: #0000ff;">bool</span> descending, Type type, <span style="color: #0000ff;">int</span> elementSize) <span style="color: #0000ff;">where</span> T : <span style="color: #0000ff;">struct</span>, IComparable&lt;T&gt;
<span style="color: #008080;">44</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">45</span>             IntPtr pointer =<span style="color: #000000;"> array.Header;
</span><span style="color: #008080;">46</span> <span style="color: #000000;">            IntPtr pivotIndex, startIndex, endIndex;
</span><span style="color: #008080;">47</span> <span style="color: #000000;">            T pivot, startValue, endValue;
</span><span style="color: #008080;">48</span>             pivotIndex = <span style="color: #0000ff;">new</span> IntPtr((<span style="color: #0000ff;">int</span>)pointer + start *<span style="color: #000000;"> elementSize);
</span><span style="color: #008080;">49</span>             pivot =<span style="color: #000000;"> (T)Marshal.PtrToStructure(pivotIndex, type);
</span><span style="color: #008080;">50</span>             <span style="color: #0000ff;">while</span> (start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">51</span> <span style="color: #000000;">            {
</span><span style="color: #008080;">52</span>                 startIndex = <span style="color: #0000ff;">new</span> IntPtr((<span style="color: #0000ff;">int</span>)pointer + start *<span style="color: #000000;"> elementSize);
</span><span style="color: #008080;">53</span>                 startValue =<span style="color: #000000;"> (T)Marshal.PtrToStructure(startIndex, type);
</span><span style="color: #008080;">54</span>                 <span style="color: #0000ff;">while</span> ((start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">55</span>                     &amp;&amp; ((descending &amp;&amp; (startValue.CompareTo(pivot) &gt; <span style="color: #800080;">0</span><span style="color: #000000;">))
</span><span style="color: #008080;">56</span>                         || ((!descending) &amp;&amp; (startValue.CompareTo(pivot) &lt; <span style="color: #800080;">0</span><span style="color: #000000;">))))
</span><span style="color: #008080;">57</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">58</span>                     start++<span style="color: #000000;">;
</span><span style="color: #008080;">59</span>                     startIndex = <span style="color: #0000ff;">new</span> IntPtr((<span style="color: #0000ff;">int</span>)pointer + start *<span style="color: #000000;"> elementSize);
</span><span style="color: #008080;">60</span>                     startValue =<span style="color: #000000;"> (T)Marshal.PtrToStructure(startIndex, type);
</span><span style="color: #008080;">61</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">62</span> 
<span style="color: #008080;">63</span>                 endIndex = <span style="color: #0000ff;">new</span> IntPtr((<span style="color: #0000ff;">int</span>)pointer + end *<span style="color: #000000;"> elementSize);
</span><span style="color: #008080;">64</span>                 endValue =<span style="color: #000000;"> (T)Marshal.PtrToStructure(endIndex, type);
</span><span style="color: #008080;">65</span>                 <span style="color: #0000ff;">while</span> ((start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">66</span>                  &amp;&amp; ((descending &amp;&amp; (endValue.CompareTo(pivot) &lt; <span style="color: #800080;">0</span><span style="color: #000000;">))
</span><span style="color: #008080;">67</span>                         || ((!descending) &amp;&amp; (endValue.CompareTo(pivot) &gt; <span style="color: #800080;">0</span><span style="color: #000000;">))))
</span><span style="color: #008080;">68</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">69</span>                     end--<span style="color: #000000;">;
</span><span style="color: #008080;">70</span>                     endIndex = <span style="color: #0000ff;">new</span> IntPtr((<span style="color: #0000ff;">int</span>)pointer + end *<span style="color: #000000;"> elementSize);
</span><span style="color: #008080;">71</span>                     endValue =<span style="color: #000000;"> (T)Marshal.PtrToStructure(endIndex, type);
</span><span style="color: #008080;">72</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">73</span> 
<span style="color: #008080;">74</span>                 <span style="color: #0000ff;">if</span> (start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">75</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">76</span>                     Marshal.StructureToPtr(endValue, startIndex, <span style="color: #0000ff;">true</span><span style="color: #000000;">);
</span><span style="color: #008080;">77</span>                     Marshal.StructureToPtr(startValue, endIndex, <span style="color: #0000ff;">true</span><span style="color: #000000;">);
</span><span style="color: #008080;">78</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">79</span> <span style="color: #000000;">            }
</span><span style="color: #008080;">80</span> 
<span style="color: #008080;">81</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> start;
</span><span style="color: #008080;">82</span>         }</pre>
</div>
<span class="cnblogs_code_collapse"> public static void Sort(this UnmanagedArray array, bool descending) where T : struct, IComparable</span></div>

虽然可用，但是用Marshal读写非托管数组效率比较低（使用了装箱拆箱操作）。于是我有了下面这个思路。

# CodeProvider

我们知道C#现有的类库是支持动态生成和调用C#代码的。因此，我可以在调用&nbsp;<span class="cnblogs_code">Sort&lt;T&gt;(<span style="color: #0000ff;">this</span> UnmanagedArray&lt;T&gt; array, <span style="color: #0000ff;">bool</span> descending)</span>&nbsp;时，临时为具体的T生成一个排序方法，然后去调用这个方法。这就不需要使用&nbsp;<span class="cnblogs_code">Marshal</span>&nbsp;了。

具体步骤如下。

### 准备模板

为了便于编码、维护，我们先准备一个排序代码的模板。模板里的_TemplateStructType_纯属一个占位符，在使用的时候我们先用具体的类型把它替换掉，就成了我们需要的源代码。

<div class="cnblogs_code" onclick="cnblogs_code_show('309c68b5-76ad-4113-877d-4a0eb9d59e1b')">![](http://images.cnblogs.com/OutliningIndicators/ContractedBlock.gif)![](http://images.cnblogs.com/OutliningIndicators/ExpandedBlockStart.gif)
<div id="cnblogs_code_open_309c68b5-76ad-4113-877d-4a0eb9d59e1b" class="cnblogs_code_hide">
<pre><span style="color: #008080;"> 1</span> <span style="color: #0000ff;">using</span><span style="color: #000000;"> System;
</span><span style="color: #008080;"> 2</span> <span style="color: #0000ff;">using</span><span style="color: #000000;"> System.Collections.Generic;
</span><span style="color: #008080;"> 3</span> <span style="color: #0000ff;">using</span><span style="color: #000000;"> System.Runtime.InteropServices;
</span><span style="color: #008080;"> 4</span> 
<span style="color: #008080;"> 5</span> <span style="color: #0000ff;">namespace</span><span style="color: #000000;"> CSharpGL
</span><span style="color: #008080;"> 6</span> <span style="color: #000000;">{
</span><span style="color: #008080;"> 7</span>     <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;"> 8</span>     <span style="color: #808080;">///</span><span style="color: #008000;"> Helper class for sorting unmanaged array.
</span><span style="color: #008080;"> 9</span>     <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;">10</span>     <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">partial</span> <span style="color: #0000ff;">class</span><span style="color: #000000;"> SortingHelper
</span><span style="color: #008080;">11</span> <span style="color: #000000;">    {
</span><span style="color: #008080;">12</span>         <span style="color: #808080;">///</span><span style="color: #008000;">// </span><span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;">13</span>         <span style="color: #808080;">///</span><span style="color: #008000;">// Sort unmanaged array specified with </span><span style="color: #808080;">&lt;paramref name="array"/&gt;</span><span style="color: #008000;"> at specified area.
</span><span style="color: #008080;">14</span>         <span style="color: #808080;">///</span><span style="color: #008000;">// </span><span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;">15</span>         <span style="color: #808080;">///</span><span style="color: #008000;">// </span><span style="color: #808080;">&lt;param name="array"&gt;&lt;/param&gt;</span>
<span style="color: #008080;">16</span>         <span style="color: #808080;">///</span><span style="color: #008000;">// </span><span style="color: #808080;">&lt;param name="descending"&gt;</span><span style="color: #008000;">true for descending sort; otherwise false.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">17</span>         <span style="color: #008000;">//</span><span style="color: #008000;">public static void Sort(this UnmanagedArray&lt;TemplateStructType&gt; array, bool descending)
</span><span style="color: #008080;">18</span>         <span style="color: #008000;">//</span><span style="color: #008000;">{
</span><span style="color: #008080;">19</span>         <span style="color: #008000;">//</span><span style="color: #008000;">    QuickSort(array, 0, array.Length - 1, descending);
</span><span style="color: #008080;">20</span>         <span style="color: #008000;">//</span><span style="color: #008000;">}</span>
<span style="color: #008080;">21</span> 
<span style="color: #008080;">22</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;summary&gt;</span>
<span style="color: #008080;">23</span>         <span style="color: #808080;">///</span><span style="color: #008000;"> Sort unmanaged array specified with </span><span style="color: #808080;">&lt;paramref name="array"/&gt;</span><span style="color: #008000;"> at specified area.
</span><span style="color: #008080;">24</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;/summary&gt;</span>
<span style="color: #008080;">25</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="array"&gt;&lt;/param&gt;</span>
<span style="color: #008080;">26</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="start"&gt;</span><span style="color: #008000;">index of first value to be sorted.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">27</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="length"&gt;</span><span style="color: #008000;">length of </span><span style="color: #808080;">&lt;paramref name="array"/&gt;</span><span style="color: #008000;"> to bo sorted.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">28</span>         <span style="color: #808080;">///</span> <span style="color: #808080;">&lt;param name="descending"&gt;</span><span style="color: #008000;">true for descending sort; otherwise false.</span><span style="color: #808080;">&lt;/param&gt;</span>
<span style="color: #008080;">29</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> Sort(UnmanagedArray&lt;TemplateStructType&gt; array, <span style="color: #0000ff;">int</span> start, <span style="color: #0000ff;">int</span> length, <span style="color: #0000ff;">bool</span><span style="color: #000000;"> descending)
</span><span style="color: #008080;">30</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">31</span>             QuickSort(array, start, start + length - <span style="color: #800080;">1</span><span style="color: #000000;">, descending);
</span><span style="color: #008080;">32</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">33</span> 
<span style="color: #008080;">34</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> QuickSort(UnmanagedArray&lt;TemplateStructType&gt; array, <span style="color: #0000ff;">int</span> start, <span style="color: #0000ff;">int</span> end, <span style="color: #0000ff;">bool</span><span style="color: #000000;"> descending)
</span><span style="color: #008080;">35</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">36</span>             <span style="color: #0000ff;">if</span> (start &gt;= end) { <span style="color: #0000ff;">return</span><span style="color: #000000;">; }
</span><span style="color: #008080;">37</span> 
<span style="color: #008080;">38</span>             Stack&lt;<span style="color: #0000ff;">int</span>&gt; stack = <span style="color: #0000ff;">new</span> Stack&lt;<span style="color: #0000ff;">int</span>&gt;<span style="color: #000000;">();
</span><span style="color: #008080;">39</span> <span style="color: #000000;">            stack.Push(end);
</span><span style="color: #008080;">40</span> <span style="color: #000000;">            stack.Push(start);
</span><span style="color: #008080;">41</span> <span style="color: #000000;">            QuickSort(array, descending, stack);
</span><span style="color: #008080;">42</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">43</span> 
<span style="color: #008080;">44</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> QuickSort(UnmanagedArray&lt;TemplateStructType&gt; array, <span style="color: #0000ff;">bool</span> descending, Stack&lt;<span style="color: #0000ff;">int</span>&gt;<span style="color: #000000;"> stack)
</span><span style="color: #008080;">45</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">46</span>             <span style="color: #0000ff;">while</span> (stack.Count &gt; <span style="color: #800080;">0</span><span style="color: #000000;">)
</span><span style="color: #008080;">47</span> <span style="color: #000000;">            {
</span><span style="color: #008080;">48</span>                 <span style="color: #0000ff;">int</span> start =<span style="color: #000000;"> stack.Pop();
</span><span style="color: #008080;">49</span>                 <span style="color: #0000ff;">int</span> end =<span style="color: #000000;"> stack.Pop();
</span><span style="color: #008080;">50</span>                 <span style="color: #0000ff;">int</span> index =<span style="color: #000000;"> QuickSortPartion(array, start, end, descending);
</span><span style="color: #008080;">51</span>                 <span style="color: #0000ff;">if</span> (start &lt; index - <span style="color: #800080;">1</span><span style="color: #000000;">)
</span><span style="color: #008080;">52</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">53</span>                     stack.Push(index - <span style="color: #800080;">1</span><span style="color: #000000;">); stack.Push(start);
</span><span style="color: #008080;">54</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">55</span>                 <span style="color: #0000ff;">if</span> (index + <span style="color: #800080;">1</span> &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">56</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">57</span>                     stack.Push(end); stack.Push(index + <span style="color: #800080;">1</span><span style="color: #000000;">);
</span><span style="color: #008080;">58</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">59</span> <span style="color: #000000;">            }
</span><span style="color: #008080;">60</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">61</span> 
<span style="color: #008080;">62</span>         <span style="color: #0000ff;">private</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">unsafe</span> <span style="color: #0000ff;">int</span> QuickSortPartion(UnmanagedArray&lt;TemplateStructType&gt; array, <span style="color: #0000ff;">int</span> start, <span style="color: #0000ff;">int</span> end, <span style="color: #0000ff;">bool</span><span style="color: #000000;"> descending)
</span><span style="color: #008080;">63</span> <span style="color: #000000;">        {
</span><span style="color: #008080;">64</span>             TemplateStructType* pointer = (TemplateStructType*<span style="color: #000000;">)array.Header.ToPointer();
</span><span style="color: #008080;">65</span> <span style="color: #000000;">            TemplateStructType pivot, startValue, endValue;
</span><span style="color: #008080;">66</span>             pivot =<span style="color: #000000;"> pointer[start];
</span><span style="color: #008080;">67</span>             <span style="color: #0000ff;">while</span> (start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">68</span> <span style="color: #000000;">            {
</span><span style="color: #008080;">69</span>                 startValue =<span style="color: #000000;"> pointer[start];
</span><span style="color: #008080;">70</span>                 <span style="color: #0000ff;">while</span> ((start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">71</span>                     &amp;&amp; ((descending &amp;&amp; (startValue.CompareTo(pivot) &gt; <span style="color: #800080;">0</span><span style="color: #000000;">))
</span><span style="color: #008080;">72</span>                         || (!descending) &amp;&amp; (startValue.CompareTo(pivot) &lt; <span style="color: #800080;">0</span><span style="color: #000000;">)))
</span><span style="color: #008080;">73</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">74</span>                     start++<span style="color: #000000;">;
</span><span style="color: #008080;">75</span>                     startValue =<span style="color: #000000;"> pointer[start];
</span><span style="color: #008080;">76</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">77</span> 
<span style="color: #008080;">78</span>                 endValue =<span style="color: #000000;"> pointer[end];
</span><span style="color: #008080;">79</span>                 <span style="color: #0000ff;">while</span> ((start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">80</span>                     &amp;&amp; ((descending &amp;&amp; (endValue.CompareTo(pivot) &lt; <span style="color: #800080;">0</span><span style="color: #000000;">))
</span><span style="color: #008080;">81</span>                         || (!descending) &amp;&amp; (endValue.CompareTo(pivot) &gt; <span style="color: #800080;">0</span><span style="color: #000000;">)))
</span><span style="color: #008080;">82</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">83</span>                     end--<span style="color: #000000;">;
</span><span style="color: #008080;">84</span>                     endValue =<span style="color: #000000;"> pointer[end];
</span><span style="color: #008080;">85</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">86</span> 
<span style="color: #008080;">87</span>                 <span style="color: #0000ff;">if</span> (start &lt;<span style="color: #000000;"> end)
</span><span style="color: #008080;">88</span> <span style="color: #000000;">                {
</span><span style="color: #008080;">89</span>                     pointer[end] =<span style="color: #000000;"> startValue;
</span><span style="color: #008080;">90</span>                     pointer[start] =<span style="color: #000000;"> endValue;
</span><span style="color: #008080;">91</span> <span style="color: #000000;">                }
</span><span style="color: #008080;">92</span> <span style="color: #000000;">            }
</span><span style="color: #008080;">93</span> 
<span style="color: #008080;">94</span>             <span style="color: #0000ff;">return</span><span style="color: #000000;"> start;
</span><span style="color: #008080;">95</span> <span style="color: #000000;">        }
</span><span style="color: #008080;">96</span> <span style="color: #000000;">    }
</span><span style="color: #008080;">97</span> }</pre>
</div>
<span class="cnblogs_code_collapse">Teamplate method</span></div>

### 嵌入的资源

然后把这个模板文件设置为嵌入的资源，以便于调用。

&nbsp;![](http://images2015.cnblogs.com/blog/383191/201610/383191-20161023142825373-1376071280.png)

### 动态生成和调用代码

利用CSharpCodeProvider来把源代码编译为Assembly并调用。

<div class="cnblogs_code">
<pre><span style="color: #008080;"> 1</span>         <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">void</span> Sort&lt;T&gt;(<span style="color: #0000ff;">this</span> UnmanagedArray&lt;T&gt; array, <span style="color: #0000ff;">bool</span> descending) <span style="color: #0000ff;">where</span> T : <span style="color: #0000ff;">struct</span>, IComparable&lt;T&gt;
<span style="color: #008080;"> 2</span> <span style="color: #000000;">        {
</span><span style="color: #008080;"> 3</span>             Type type = <span style="color: #0000ff;">typeof</span><span style="color: #000000;">(T);
</span><span style="color: #008080;"> 4</span>             <span style="color: #0000ff;">string</span> order = ManifestResourceLoader.LoadTextFile(<span style="color: #800000;">@"</span><span style="color: #800000;">Resources\SortingHelper.Order`1.cs</span><span style="color: #800000;">"</span><span style="color: #000000;">);
</span><span style="color: #008080;"> 5</span>             order = order.Replace(<span style="color: #800000;">"</span><span style="color: #800000;">TemplateStructType</span><span style="color: #800000;">"</span><span style="color: #000000;">, type.FullName);
</span><span style="color: #008080;"> 6</span>             <span style="color: #0000ff;">var</span> codeProvider = <span style="color: #0000ff;">new</span><span style="color: #000000;"> CSharpCodeProvider();
</span><span style="color: #008080;"> 7</span>             <span style="color: #0000ff;">var</span> option = <span style="color: #0000ff;">new</span><span style="color: #000000;"> CompilerParameters();
</span><span style="color: #008080;"> 8</span>             option.GenerateInMemory = <span style="color: #0000ff;">true</span><span style="color: #000000;">;
</span><span style="color: #008080;"> 9</span>             option.CompilerOptions = <span style="color: #800000;">"</span><span style="color: #800000;">/unsafe</span><span style="color: #800000;">"</span><span style="color: #000000;">;
</span><span style="color: #008080;">10</span>             option.ReferencedAssemblies.Add(<span style="color: #800000;">"</span><span style="color: #800000;">System.dll</span><span style="color: #800000;">"</span><span style="color: #000000;">);
</span><span style="color: #008080;">11</span>             option.ReferencedAssemblies.Add(<span style="color: #800000;">"</span><span style="color: #800000;">CSharpGL.dll</span><span style="color: #800000;">"</span><span style="color: #000000;">);
</span><span style="color: #008080;">12</span>             CompilerResults result =<span style="color: #000000;"> codeProvider.CompileAssemblyFromSource(option,
</span><span style="color: #008080;">13</span> <span style="color: #000000;">                order);
</span><span style="color: #008080;">14</span>             Assembly asm =<span style="color: #000000;"> result.CompiledAssembly;
</span><span style="color: #008080;">15</span>             Type sortingHelper = asm.GetType(<span style="color: #800000;">"</span><span style="color: #800000;">CSharpGL.SortingHelper</span><span style="color: #800000;">"</span><span style="color: #000000;">);
</span><span style="color: #008080;">16</span>             Type unmanagedArrayGeneric = <span style="color: #0000ff;">typeof</span>(UnmanagedArray&lt;&gt;<span style="color: #000000;">);
</span><span style="color: #008080;">17</span>             Type unmanagedArray =<span style="color: #000000;"> unmanagedArrayGeneric.MakeGenericType(type);
</span><span style="color: #008080;">18</span>             MethodInfo method = sortingHelper.GetMethod(<span style="color: #800000;">"</span><span style="color: #800000;">Sort</span><span style="color: #800000;">"</span>, <span style="color: #0000ff;">new</span> Type[] { unmanagedArray, <span style="color: #0000ff;">typeof</span>(<span style="color: #0000ff;">int</span>), <span style="color: #0000ff;">typeof</span>(<span style="color: #0000ff;">int</span>), <span style="color: #0000ff;">typeof</span>(<span style="color: #0000ff;">bool</span><span style="color: #000000;">) });
</span><span style="color: #008080;">19</span>             method.Invoke(<span style="color: #0000ff;">null</span>, <span style="color: #0000ff;">new</span> <span style="color: #0000ff;">object</span>[] { array, <span style="color: #800080;">0</span><span style="color: #000000;">, array.Length, descending });
</span><span style="color: #008080;">20</span>         }</pre>
</div>

# 总结

还有一种利用emit的方法，我就暂时不研究了。

&nbsp;