# Answer to these questions
1. how to create render context on Windows with opengl32.dll ?

2. how to get openGL function pointers on Windows with opengl32.dll ?

# 我要怼人了

为什么要写这种代码？
```csharp
if (Platform.IsWindows) { lib = "opengl32.dll"; }
else if (Platform.IsLinux) { lib = "libGL.so.1"; }
else if (Platform.IsIOS) { lib = "/System/Library/Frameworks/OpenGL.framework/OpenGL"; }
else { throw new NotSupportedPlatformException(); }
```
难道程序员会不知道自己写的程序将要用在哪个操作系统上吗？

何必在1个DLL里判断自己所在的操作系统。

想在Windows上用，就加载`CsharpGL.Windows`，想在Linux上用，就加载`CsharpGL.Linux`。有什么好判断的。

就那么想把同一个DLL文件放到不同的操作系统上吗？何必呢，平白增大文件体积，增多代码复杂性。

你说什么？为了避免代码重复？啊呸，你就不会把与平台无关的代码放到一个单独的DLL里去吗？这点设计头脑都没有嘛！

- 想在Windows上用，就加载`CsharpGL`和`CsharpGL.Windows`。

- 想在Linux上用，就加载`CsharpGL`和`CsharpGL.Linux`。

把与平台无关的代码放到`CSharpGL`里不就行了。

有什么好判断的。

