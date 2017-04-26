# `GLScene`命名规则
## `GLAction`子类型的命名规则
以`RenderAction`为例，由自定义名称（Render）、后缀（Action）两部分组成。
## `GLNode`子类型的命名规则
以`GLProgramNode`为例，由前缀（GL）、自定义名称（Program）、后缀（Node）三部分组成。
## `GLSnippet`子类型的命名规则
以`Render_ProgramNode`为例，由前缀（Render）、下划线（_）、后缀（ProgramNode）三部分组成。  
前缀（Render）来自`RenderAction`，把后缀（Action）去掉。  
后缀（ProgramNode）来自`GLProgramNode`，把前缀（GL）、后缀（Node）去掉。  

