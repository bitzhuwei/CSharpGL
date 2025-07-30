对block的从GLSL到C#转换，从未测试过：转换的C#代码是否正确，是否能正常传递数据。

对于int(3.0f)这样的GLSL代码，不能正确转换为C#代码。因为C#里int是关键字，不能这样写。

private static unsafe void WriteFragments2Framebuffer(RenderContext context, GLFramebuffer framebuffer, ConcurrentBag<FragmentCodeBase[]> primitiveList) {
里的
attachment.Set((int)fsInstance.gl_FragCoord.x, (int)fsInstance.gl_FragCoord.y, pointer, passType);
可能能够通过unmanaged代码或什么方法来提升效率。

DrawArrays() DrawElements()有支持各个变种的潜力。

尚未实现与Texture相关的功能。

尚未实现与Compute Shader相关的功能。
