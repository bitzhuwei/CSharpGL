# 困境
现在（2016年1月28日）编写GLSL的shader程序时，并没有什么好的开发环境。智能提示、代码补全、自动排版都没有。基本上我是用notepad++之类的编辑器写的。很苦恼，一度导致我对shader有偏见。
# CSSL
CSSL是C-Sharp-Shading-Language的缩写。  
CSSL的目的：使开发者可以直接用C#书写GLSL代码。  
# 如何使用
GLSL是类似C语言的。我发现几乎所有的GLSL里出现的语法形式都可以用C#以相同的方式写出来。那么用C#来写“GLSL代码”，之后再自动地转换为纯粹的GLSL代码，岂非一大快事？！
在open_file_folder:CSSL定义的类型基础上，你就可以直接用C#来写GLSL代码了。（只有很少的几点不同，到时候你会立即明白的。）
# 规定
为了便于使用和懒化开发，我设计了如下几条规定：
GLSL文件名以*.cssl.cs为扩展名。这样方便System.IO.File识别。

# Dilemma
There is no good dev-environment for coding GLSL shader. No IntelliSense, no Code Completion, no Automatic Composing, nothing. I usually write GLSL in notepad++. It's a difficult task which is why I don't like writing GLSL.
# CSSL
CSSL is short for C-Sharp-Shading-Language.
CSSL aims at writing GLSL in C#.
# How
GLSL is similar to C. I find it that almost every grammar format in GLSL appears in C#. So it's possible to write "GLSL" in C#, which can be transfered to GLSL then. That'll be great, isn't it?
You can write GLSL in C# using types provided in :open_file_folder:CSSL. (Only a few differences which are easy to understand.)
# Rules
Some rules are suggested here for future convenience.
* CSSL files uses ".cssl.cs" or ".main.cs" as extension name, which is easy for file filter.
