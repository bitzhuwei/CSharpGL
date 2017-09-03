# glClearBufferSubData

from([http://blog.csdn.net/csxiaoshui/article/details/45894867](http://blog.csdn.net/csxiaoshui/article/details/45894867))

## glCearBufferSubData

用一个固定的值填充缓冲区对象的一部分（或者全部）

<div class="cnblogs_code">
<pre><span style="color: #008080;">1</span> <span style="color: #008000;">//</span><span style="color: #008000;"> OpenGL &gt;= 4.3</span>
<span style="color: #008080;">2</span> <span style="color: #0000ff;">void</span><span style="color: #000000;"> glClearBufferSubData(  
</span><span style="color: #008080;">3</span> <span style="color: #000000;">    GLenum target,
</span><span style="color: #008080;">4</span> <span style="color: #000000;">    GLenum internalformat,
</span><span style="color: #008080;">5</span> <span style="color: #000000;">    GLintptr offset,
</span><span style="color: #008080;">6</span> <span style="color: #000000;">    GLsizeiptr size,
</span><span style="color: #008080;">7</span> <span style="color: #000000;">    GLenum format,
</span><span style="color: #008080;">8</span> <span style="color: #000000;">    GLenum type,
</span><span style="color: #008080;">9</span>     <span style="color: #0000ff;">const</span> <span style="color: #0000ff;">void</span> * data);</pre>
</div>

参数：&nbsp;

target ： 指定缓冲区对象的类型，具体类型参考&nbsp;glBufferData&nbsp;

internalformat : 指定缓冲区对象中的数据的内部存储格式&nbsp;

offset：指定需要替换数据的偏移量（以字节计算）&nbsp;

size：指定需要填充的数据的大小（以字节计算）&nbsp;

format：指定内存中的数据的格式&nbsp;

type：指定类存中数据的类型&nbsp;

data：指定内存中的数据，用来替换掉缓冲区对象中的数据

# 上述参数中有几个概念需要明确：

## &nbsp;1. internalformat

用来表述缓冲区对象中的数据是那种形式的，可选的取值有：

<table style="width: 875px;" border="1" cellspacing="0" cellpadding="0">
<thead>
<tr>
<td valign="top">

**内部格式**

   </td>
<td valign="top">

**数据类型**

   </td>
<td valign="top">

**组成成分**

   </td>
<td valign="top">

**是否单位化**

   </td>
<td valign="top">

**成分（****0,1,2,3****）**

   </td>

  </tr>

 </thead>
<tbody>
<tr>
<td valign="top">

GL_R8

  </td>
<td valign="top">

ubyte

  </td>
<td valign="top">

1

  </td>
<td valign="top">

YES

  </td>
<td valign="top">

R 0 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_R16

  </td>
<td valign="top">

ushort

  </td>
<td valign="top">

1

  </td>
<td valign="top">

YES

  </td>
<td valign="top">

R 0 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_R16F

  </td>
<td valign="top">

half

  </td>
<td valign="top">

1

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R 0 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_R32F

  </td>
<td valign="top">

float

  </td>
<td valign="top">

1

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R 0 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_R8I

  </td>
<td valign="top">

byte

  </td>
<td valign="top">

1

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R 0 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_R16I

  </td>
<td valign="top">

short

  </td>
<td valign="top">

1

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R 0 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_R32I

  </td>
<td valign="top">

int

  </td>
<td valign="top">

1

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R 0 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_R8UI

  </td>
<td valign="top">

ubyte

  </td>
<td valign="top">

1

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R 0 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_R16UI

  </td>
<td valign="top">

ushort

  </td>
<td valign="top">

1

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R 0 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_R32UI

  </td>
<td valign="top">

uint

  </td>
<td valign="top">

1

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R 0 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RG8

  </td>
<td valign="top">

ubyte

  </td>
<td valign="top">

2

  </td>
<td valign="top">

YES

  </td>
<td valign="top">

R G 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RG16

  </td>
<td valign="top">

ushort

  </td>
<td valign="top">

2

  </td>
<td valign="top">

YES

  </td>
<td valign="top">

R G 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RG16F

  </td>
<td valign="top">

half

  </td>
<td valign="top">

2

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RG32F

  </td>
<td valign="top">

float

  </td>
<td valign="top">

2

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RG8I

  </td>
<td valign="top">

byte

  </td>
<td valign="top">

2

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RG16I

  </td>
<td valign="top">

short

  </td>
<td valign="top">

2

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RG32I

  </td>
<td valign="top">

int

  </td>
<td valign="top">

2

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RG8UI

  </td>
<td valign="top">

ubyte

  </td>
<td valign="top">

2

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RG16UI

  </td>
<td valign="top">

ushort

  </td>
<td valign="top">

2

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RG32UI

  </td>
<td valign="top">

uint

  </td>
<td valign="top">

2

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G 0 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGB32F

  </td>
<td valign="top">

float

  </td>
<td valign="top">

3

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G B 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGB32I

  </td>
<td valign="top">

int

  </td>
<td valign="top">

3

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G B 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGB32UI

  </td>
<td valign="top">

uint

  </td>
<td valign="top">

3

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G B 1

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGBA8

  </td>
<td valign="top">

uint

  </td>
<td valign="top">

4

  </td>
<td valign="top">

YES

  </td>
<td valign="top">

R G B A

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGBA16

  </td>
<td valign="top">

short

  </td>
<td valign="top">

4

  </td>
<td valign="top">

YES

  </td>
<td valign="top">

R G B A

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGBA16F

  </td>
<td valign="top">

half

  </td>
<td valign="top">

4

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G B A

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGBA32F

  </td>
<td valign="top">

float

  </td>
<td valign="top">

4

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G B A

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGBA8I

  </td>
<td valign="top">

byte

  </td>
<td valign="top">

4

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G B A

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGBA16I

  </td>
<td valign="top">

short

  </td>
<td valign="top">

4

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G B A

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGBA32I

  </td>
<td valign="top">

int

  </td>
<td valign="top">

4

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G B A

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGBA8UI

  </td>
<td valign="top">

ubyte

  </td>
<td valign="top">

4

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G B A

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGBA16UI

  </td>
<td valign="top">

ushort

  </td>
<td valign="top">

4

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G B A

  </td>

 </tr>
<tr>
<td valign="top">

GL_RGBA32UI

  </td>
<td valign="top">

uint

  </td>
<td valign="top">

4

  </td>
<td valign="top">

NO

  </td>
<td valign="top">

R G B A

  </td>

 </tr>

</tbody>

</table>
<div align="left">

* * *

</div>

format和type指定了data中的格式类型

## format

可以取值&nbsp;_GL_RED, GL_RG, GL_RGB,GL_RGBA 来代表一维、二维、三维或四维的数据_

## type

指定了数据的类型是GL_FLOAT或者GL_INT或者GL_UNSIGNED_BYTE等

## data

指定用来填充的数据，如果是NULL那么该缓冲区由offset和size指定的区域会被0填充

&nbsp;