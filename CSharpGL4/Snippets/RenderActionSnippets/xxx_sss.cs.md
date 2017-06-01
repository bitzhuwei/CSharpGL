# `RenderAction`相关的`GLSnippet`子类的命名规则
只有按此股则命名`GLSnipet`的子类，才能够被`RenderAction`搜索到。
以`Render_Program`为例，由前缀（Render）、下划线（_）、后缀（ProgramNode）三部分组成。  
前缀（Render）来自`RenderAction`，把后缀（Action）去掉。  
后缀（Program）来自`GLProgramNode`，把前缀（GL）、后缀（Node）去掉。  
