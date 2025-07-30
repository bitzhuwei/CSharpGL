DummyScene与原有Scenery的区别：
用SSBO保存每个Node的model matrix，用另一个SSBO保存场景里的Camera的projection matrix和view matrix。
简化IBufferSource（即模型），不再用IEnumerable<VertexBuffer>描述一个顶点属性了，只用1个VertexBuffer足矣。


DummyRenderer是用来加载和渲染GLTF2文件的，但是没实现。

暂决定将Assimp的数据结构移植进CSharpGL里，取代现有的Scene和Node。

总之，重整Scene，重写Text、Picking、GUI，尝试用Shader实现碰撞检测：朝着图形引擎、物理引擎、游戏引擎的方向前进！

接下来，第一步要做的是：将Assimp整理为C#版。


```csharp
texture.textureUnitIndex = 0;//TODO: use some manager to manage this unit index thing.
```

