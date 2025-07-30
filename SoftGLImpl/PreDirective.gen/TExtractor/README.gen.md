# `PreDirective`的内容提取器（`Extractor`）

得到单词流`TokenList`和语法树`Node`后，就可以得到`PreDirective`的实际内容`PreDirective`了。

实现`PreDirectiveExtractor`的要点，简述如下：

1. 用后序遍历算法（Post-Order Traversing），遍历`Node`的每个结点。由于`Node`结构可能很大，所以用递归形式的算法会发生堆栈溢出异常`StackOverflowException`，所以必须用非递归形式的算法。

2. 根据词法分析和语法分析的过程可知，每个终结点`'a'`，都对应一个`Token`。我们将此`Token`的内容入栈（即`Stack.Push(token.value)`）。
3. 根据词法分析和语法分析的过程可知，每个非终结点`A`，都对应一个规约规则，也就是一条文法规则`Regulation`（例如`A : X Y 'z' ;`）。因为我们采用了**后序遍历**，所以`A`的各个子结点的内容都已经入栈（这是关键！）了。此时,我们可以根据`A`对应的`Regulation`，知道栈里都有哪些内容、其排列顺序如何（例如从栈顶到栈底依次为`;` `'z'` `Y` `X`）。那么，我们就可以将这些内容依次出栈（即`object obj = Stack.Pop();`），用以构造`A`对应的内容，而后将此内容入栈。

4. 在不断经历上述2.和3.的过程中，`Node`中的信息会被不断提取到更高层的结点，最终提取到根结点，就形成了`PreDirective`。

得到了`PreDirective`，首先就可以格式化`PreDirective`的源文件了。这也可以验证前面的词法分析、语法分析、提取过程的正确性。

然后，程序员就可以自由地对此`PreDirective`对象进行任何操作了。

