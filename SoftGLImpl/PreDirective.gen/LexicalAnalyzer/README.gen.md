# 注意

在DFA和miniDFA文件夹中选择一个使用。

# `PreDirective`的词法分析器（Analyzer）

词法分析的原理是状态机（State Machine）。词法分析的过程就是：看第一个`char`是什么，就能判定它和它后面若干个`char`可能组成哪一类或哪几类的`Token`；然后一个`char`一个`char`地拼接出这个`Token`来。这时候指针（`Cursor`）就指到了下一个`Token`的第一个`char`，重复上述过程。

词法分析的作用可以和计算机网络7层协议里的数据链路层的作用类比。数据链路层把可能出错的物理层的数据打包成一个个不会有错的`数据报`，供上层协议继续分析。词法分析器将纯字符串的源代码变成一个个具有顺序、类型和内容的`Token`，减轻了语法分析的复杂性。

下面各图是状态机的各个部分。它们合在一起就是Analyzer的核心——总状态机（156个DFAState，154个miniDFAState）。

## Vt: '#define'
VtInfo.patterns[1/1]:#define
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_14[["εNFA0-14 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_10[["εNFA0-10 char{1, 1}"]]
eNFA0_11[["εNFA0-11 char[1]"]]
eNFA0_12[["εNFA0-12 char{1, 1}"]]
eNFA0_13[["εNFA0-13 char[1]"]]
eNFA0_15[["εNFA0-15 regex end"]]
eNFA0_14 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"d"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"e"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"f"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"i"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"n"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_12 -->|"e"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_15
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_16[["εNFA0-16 post-regex start"]]
eNFA0_17[\"εNFA0-17 post-regex end"/]
eNFA0_16 -.->|"ε"|eNFA0_17
```


## Vt: '('
VtInfo.patterns[1/1]:\(
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;("|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: ')'
VtInfo.patterns[1/1]:\)
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;)"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '#undef'
VtInfo.patterns[1/1]:#undef
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_12[["εNFA0-12 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_10[["εNFA0-10 char{1, 1}"]]
eNFA0_11[["εNFA0-11 char[1]"]]
eNFA0_13[["εNFA0-13 regex end"]]
eNFA0_12 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"u"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"n"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"d"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"e"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"f"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_13
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_14[["εNFA0-14 post-regex start"]]
eNFA0_15[\"εNFA0-15 post-regex end"/]
eNFA0_14 -.->|"ε"|eNFA0_15
```


## Vt: ','
VtInfo.patterns[1/1]:,
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|","|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: ';'
VtInfo.patterns[1/1]:;
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|";"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '['
VtInfo.patterns[1/1]:\[
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;["|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: ']'
VtInfo.patterns[1/1]:]
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"]"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '.'
VtInfo.patterns[1/1]:\.
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;."|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '++'
VtInfo.patterns[1/1]:\+\+
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;+"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"#92;+"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '--'
VtInfo.patterns[1/1]:--
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"-"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"-"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '+'
VtInfo.patterns[1/1]:\+
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;+"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '-'
VtInfo.patterns[1/1]:-
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"-"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '!'
VtInfo.patterns[1/1]:!
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"!"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '~'
VtInfo.patterns[1/1]:~
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"~"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '*'
VtInfo.patterns[1/1]:\*
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;#42;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '/'
VtInfo.patterns[1/1]:\/
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;/"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '%'
VtInfo.patterns[1/1]:%
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"%"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '<<'
VtInfo.patterns[1/1]:\<\<
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;<"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"#92;<"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '>>'
VtInfo.patterns[1/1]:>>
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|">"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|">"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '<'
VtInfo.patterns[1/1]:\<
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;<"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '>'
VtInfo.patterns[1/1]:>
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|">"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '<='
VtInfo.patterns[1/1]:\<=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;<"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '>='
VtInfo.patterns[1/1]:>=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|">"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '=='
VtInfo.patterns[1/1]:==
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"="|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '!='
VtInfo.patterns[1/1]:!=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"!"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '&'
VtInfo.patterns[1/1]:&
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"&"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '^'
VtInfo.patterns[1/1]:^
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"^"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '|'
VtInfo.patterns[1/1]:\|
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;|"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '&&'
VtInfo.patterns[1/1]:&&
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"&"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"&"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '^^'
VtInfo.patterns[1/1]:^^
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"^"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"^"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '||'
VtInfo.patterns[1/1]:\|\|
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;|"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"#92;|"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '?'
VtInfo.patterns[1/1]:\?
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;?"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: ':'
VtInfo.patterns[1/1]::
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|":"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '='
VtInfo.patterns[1/1]:=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"="|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '*='
VtInfo.patterns[1/1]:\*=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;#42;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '/='
VtInfo.patterns[1/1]:\/=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;/"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '%='
VtInfo.patterns[1/1]:%=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"%"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '+='
VtInfo.patterns[1/1]:\+=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;+"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '-='
VtInfo.patterns[1/1]:-=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"-"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '<<='
VtInfo.patterns[1/1]:\<\<=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_7[["εNFA0-7 regex end"]]
eNFA0_6 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;<"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"#92;<"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"="|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_7
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_8[["εNFA0-8 post-regex start"]]
eNFA0_9[\"εNFA0-9 post-regex end"/]
eNFA0_8 -.->|"ε"|eNFA0_9
```


## Vt: '>>='
VtInfo.patterns[1/1]:>>=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_7[["εNFA0-7 regex end"]]
eNFA0_6 -.->|"ε"|eNFA0_0
eNFA0_0 -->|">"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|">"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"="|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_7
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_8[["εNFA0-8 post-regex start"]]
eNFA0_9[\"εNFA0-9 post-regex end"/]
eNFA0_8 -.->|"ε"|eNFA0_9
```


## Vt: '&='
VtInfo.patterns[1/1]:&=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"&"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '^='
VtInfo.patterns[1/1]:^=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"^"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '|='
VtInfo.patterns[1/1]:\|=
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;|"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"="|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '{'
VtInfo.patterns[1/1]:\{
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;{"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '}'
VtInfo.patterns[1/1]:}
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_2[["εNFA0-2 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_3[["εNFA0-3 regex end"]]
eNFA0_2 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"}"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_3
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 post-regex start"]]
eNFA0_5[\"εNFA0-5 post-regex end"/]
eNFA0_4 -.->|"ε"|eNFA0_5
```


## Vt: '##'
VtInfo.patterns[1/1]:##
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"#35;"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


## Vt: '#if'
VtInfo.patterns[1/1]:#if
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_7[["εNFA0-7 regex end"]]
eNFA0_6 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"i"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"f"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_7
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_8[["εNFA0-8 post-regex start"]]
eNFA0_9[\"εNFA0-9 post-regex end"/]
eNFA0_8 -.->|"ε"|eNFA0_9
```


## Vt: '#ifdef'
VtInfo.patterns[1/1]:#ifdef
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_12[["εNFA0-12 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_10[["εNFA0-10 char{1, 1}"]]
eNFA0_11[["εNFA0-11 char[1]"]]
eNFA0_13[["εNFA0-13 regex end"]]
eNFA0_12 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"i"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"f"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"d"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"e"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"f"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_13
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_14[["εNFA0-14 post-regex start"]]
eNFA0_15[\"εNFA0-15 post-regex end"/]
eNFA0_14 -.->|"ε"|eNFA0_15
```


## Vt: '#ifndef'
VtInfo.patterns[1/1]:#ifndef
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_14[["εNFA0-14 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_10[["εNFA0-10 char{1, 1}"]]
eNFA0_11[["εNFA0-11 char[1]"]]
eNFA0_12[["εNFA0-12 char{1, 1}"]]
eNFA0_13[["εNFA0-13 char[1]"]]
eNFA0_15[["εNFA0-15 regex end"]]
eNFA0_14 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"i"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"f"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"n"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"d"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"e"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_12 -->|"f"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_15
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_16[["εNFA0-16 post-regex start"]]
eNFA0_17[\"εNFA0-17 post-regex end"/]
eNFA0_16 -.->|"ε"|eNFA0_17
```


## Vt: '#else'
VtInfo.patterns[1/1]:#else
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_10[["εNFA0-10 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_11[["εNFA0-11 regex end"]]
eNFA0_10 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"e"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"l"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"s"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"e"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_11
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_12[["εNFA0-12 post-regex start"]]
eNFA0_13[\"εNFA0-13 post-regex end"/]
eNFA0_12 -.->|"ε"|eNFA0_13
```


## Vt: '#elif'
VtInfo.patterns[1/1]:#elif
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_10[["εNFA0-10 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_11[["εNFA0-11 regex end"]]
eNFA0_10 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"e"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"l"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"i"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"f"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_11
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_12[["εNFA0-12 post-regex start"]]
eNFA0_13[\"εNFA0-13 post-regex end"/]
eNFA0_12 -.->|"ε"|eNFA0_13
```


## Vt: '#endif'
VtInfo.patterns[1/1]:#endif
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_12[["εNFA0-12 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_10[["εNFA0-10 char{1, 1}"]]
eNFA0_11[["εNFA0-11 char[1]"]]
eNFA0_13[["εNFA0-13 regex end"]]
eNFA0_12 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"e"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"n"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"d"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"i"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"f"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_13
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_14[["εNFA0-14 post-regex start"]]
eNFA0_15[\"εNFA0-15 post-regex end"/]
eNFA0_14 -.->|"ε"|eNFA0_15
```


## Vt: '#error'
VtInfo.patterns[1/1]:#error
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_12[["εNFA0-12 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_10[["εNFA0-10 char{1, 1}"]]
eNFA0_11[["εNFA0-11 char[1]"]]
eNFA0_13[["εNFA0-13 regex end"]]
eNFA0_12 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"e"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"r"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"r"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"o"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"r"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_13
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_14[["εNFA0-14 post-regex start"]]
eNFA0_15[\"εNFA0-15 post-regex end"/]
eNFA0_14 -.->|"ε"|eNFA0_15
```


## Vt: '#pragma'
VtInfo.patterns[1/1]:#pragma
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_14[["εNFA0-14 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_10[["εNFA0-10 char{1, 1}"]]
eNFA0_11[["εNFA0-11 char[1]"]]
eNFA0_12[["εNFA0-12 char{1, 1}"]]
eNFA0_13[["εNFA0-13 char[1]"]]
eNFA0_15[["εNFA0-15 regex end"]]
eNFA0_14 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"p"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"r"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"a"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"g"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"m"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_12 -->|"a"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_15
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_16[["εNFA0-16 post-regex start"]]
eNFA0_17[\"εNFA0-17 post-regex end"/]
eNFA0_16 -.->|"ε"|eNFA0_17
```


## Vt: '#extension'
VtInfo.patterns[1/1]:#extension
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_20[["εNFA0-20 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_10[["εNFA0-10 char{1, 1}"]]
eNFA0_11[["εNFA0-11 char[1]"]]
eNFA0_12[["εNFA0-12 char{1, 1}"]]
eNFA0_13[["εNFA0-13 char[1]"]]
eNFA0_14[["εNFA0-14 char{1, 1}"]]
eNFA0_15[["εNFA0-15 char[1]"]]
eNFA0_16[["εNFA0-16 char{1, 1}"]]
eNFA0_17[["εNFA0-17 char[1]"]]
eNFA0_18[["εNFA0-18 char{1, 1}"]]
eNFA0_19[["εNFA0-19 char[1]"]]
eNFA0_21[["εNFA0-21 regex end"]]
eNFA0_20 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"e"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"x"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"t"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"e"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"n"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_12 -->|"s"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_14
eNFA0_14 -->|"i"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_16 -->|"o"|eNFA0_17
eNFA0_17 -.->|"ε"|eNFA0_18
eNFA0_18 -->|"n"|eNFA0_19
eNFA0_19 -.->|"ε"|eNFA0_21
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_22[["εNFA0-22 post-regex start"]]
eNFA0_23[\"εNFA0-23 post-regex end"/]
eNFA0_22 -.->|"ε"|eNFA0_23
```


## Vt: '#version'
VtInfo.patterns[1/1]:#version
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_16[["εNFA0-16 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_10[["εNFA0-10 char{1, 1}"]]
eNFA0_11[["εNFA0-11 char[1]"]]
eNFA0_12[["εNFA0-12 char{1, 1}"]]
eNFA0_13[["εNFA0-13 char[1]"]]
eNFA0_14[["εNFA0-14 char{1, 1}"]]
eNFA0_15[["εNFA0-15 char[1]"]]
eNFA0_17[["εNFA0-17 regex end"]]
eNFA0_16 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"v"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"e"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"r"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"s"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"i"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_12 -->|"o"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_14
eNFA0_14 -->|"n"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_17
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_18[["εNFA0-18 post-regex start"]]
eNFA0_19[\"εNFA0-19 post-regex end"/]
eNFA0_18 -.->|"ε"|eNFA0_19
```


## Vt: '#line'
VtInfo.patterns[1/1]:#line
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_10[["εNFA0-10 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_11[["εNFA0-11 regex end"]]
eNFA0_10 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#35;"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"l"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"i"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"n"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"e"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_11
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_12[["εNFA0-12 post-regex start"]]
eNFA0_13[\"εNFA0-13 post-regex end"/]
eNFA0_12 -.->|"ε"|eNFA0_13
```


## Vt: 'defined'
VtInfo.patterns[1/1]:defined
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_14[["εNFA0-14 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_10[["εNFA0-10 char{1, 1}"]]
eNFA0_11[["εNFA0-11 char[1]"]]
eNFA0_12[["εNFA0-12 char{1, 1}"]]
eNFA0_13[["εNFA0-13 char[1]"]]
eNFA0_15[["εNFA0-15 regex end"]]
eNFA0_14 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"d"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"e"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"f"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"i"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"n"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"e"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_12 -->|"d"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_15
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_16[["εNFA0-16 post-regex start"]]
eNFA0_17[\"εNFA0-17 post-regex end"/]
eNFA0_16 -.->|"ε"|eNFA0_17
```


## Vt: 'identifier'
VtInfo.patterns[1/1]:[a-zA-Z_][a-zA-Z0-9_]*
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_3[["εNFA0-3 regex start"]]
eNFA0_0[["εNFA0-0 scope{1, 1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA0_2[["εNFA0-2 scope{0, -1}"]]
eNFA0_4[["εNFA0-4 regex end"]]
eNFA0_3 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"[a-zA-Z_]"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"[a-zA-Z0-9_]"|eNFA0_2
eNFA0_2 -.->|"ε"|eNFA0_4
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_5[["εNFA0-5 post-regex start"]]
eNFA0_6[\"εNFA0-6 post-regex end"/]
eNFA0_5 -.->|"ε"|eNFA0_6
```


## Vt: 'literalString'
VtInfo.patterns[1/1]:[a-zA-Z_]?"(\\.|[^\\"])*"
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_14[["εNFA0-14 regex start"]]
eNFA0_0[["εNFA0-0 scope{0, 1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_8[["εNFA0-8 regex start"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_10[["εNFA0-10 scope{1, 1}"]]
eNFA0_9[["εNFA0-9 regex end"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_11[["εNFA0-11 scope[1]"]]
eNFA0_12[["εNFA0-12 char{1, 1}"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_13[["εNFA0-13 char[1]"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_15[["εNFA0-15 regex end"]]
eNFA0_14 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"[a-zA-Z_]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"#34;"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_8
eNFA0_8 -.->|"ε"|eNFA0_4
eNFA0_8 -.->|"ε"|eNFA0_10
eNFA0_8 -.->|"ε"|eNFA0_9
eNFA0_4 -->|"#92;#92;"|eNFA0_5
eNFA0_10 -->|"[^#92;#92;#34;]"|eNFA0_11
eNFA0_9 -.->|"ε"|eNFA0_8
eNFA0_9 -.->|"ε"|eNFA0_12
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_11 -.->|"ε"|eNFA0_9
eNFA0_12 -->|"#34;"|eNFA0_13
eNFA0_6 -->|"[#32;-~]"|eNFA0_7
eNFA0_13 -.->|"ε"|eNFA0_15
eNFA0_7 -.->|"ε"|eNFA0_9
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_16[["εNFA0-16 post-regex start"]]
eNFA0_17[\"εNFA0-17 post-regex end"/]
eNFA0_16 -.->|"ε"|eNFA0_17
```


## Vt: 'number'
VtInfo.patterns[1/1]:[0-9]+([.][0-9]+)?
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_8[["εNFA0-8 regex start"]]
eNFA0_0[["εNFA0-0 scope{1, -1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA0_6[["εNFA0-6 regex start"]]
eNFA0_2[["εNFA0-2 scope{1, 1}"]]
eNFA0_7[["εNFA0-7 regex end"]]
eNFA0_3[["εNFA0-3 scope[1]"]]
eNFA0_9[["εNFA0-9 regex end"]]
eNFA0_4[["εNFA0-4 scope{1, -1}"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_7[["εNFA0-7 regex end"]]
eNFA0_6[["εNFA0-6 regex start"]]
eNFA0_2[["εNFA0-2 scope{1, 1}"]]
eNFA0_3[["εNFA0-3 scope[1]"]]
eNFA0_4[["εNFA0-4 scope{1, -1}"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_8 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"[0-9]"|eNFA0_1
eNFA0_1 -->|"[0-9]"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_6
eNFA0_6 -.->|"ε"|eNFA0_2
eNFA0_6 -.->|"ε"|eNFA0_7
eNFA0_2 -->|"[.]"|eNFA0_3
eNFA0_7 -.->|"ε"|eNFA0_9
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"[0-9]"|eNFA0_5
eNFA0_5 -->|"[0-9]"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_6
eNFA0_6 -.->|"ε"|eNFA0_2
eNFA0_6 -.->|"ε"|eNFA0_7
eNFA0_2 -->|"[.]"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"[0-9]"|eNFA0_5
eNFA0_5 -->|"[0-9]"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_7
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_10[["εNFA0-10 post-regex start"]]
eNFA0_11[\"εNFA0-11 post-regex end"/]
eNFA0_10 -.->|"ε"|eNFA0_11
```


## Vt: 'intConstant'
VtInfo.patterns[1/2]:[-+]?[0-9]+
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_4[["εNFA0-4 regex start"]]
eNFA0_0[["εNFA0-0 scope{0, 1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA0_2[["εNFA0-2 scope{1, -1}"]]
eNFA0_3[["εNFA0-3 scope[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"[-+]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"[0-9]"|eNFA0_3
eNFA0_3 -->|"[0-9]"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_6 -.->|"ε"|eNFA0_7
```


VtInfo.patterns[1/2]:0x[0-9A-Fa-f]+
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 scope{1, -1}"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_7[["εNFA0-7 regex end"]]
eNFA0_6 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"0"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"x"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"[0-9A-Fa-f]"|eNFA0_5
eNFA0_5 -->|"[0-9A-Fa-f]"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_7
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_8[["εNFA0-8 post-regex start"]]
eNFA0_9[\"εNFA0-9 post-regex end"/]
eNFA0_8 -.->|"ε"|eNFA0_9
```


## Vt: 'uintConstant'
VtInfo.patterns[1/2]:[-+]?[0-9]+[uU]
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_6[["εNFA0-6 regex start"]]
eNFA0_0[["εNFA0-0 scope{0, 1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA0_2[["εNFA0-2 scope{1, -1}"]]
eNFA0_3[["εNFA0-3 scope[1]"]]
eNFA0_4[["εNFA0-4 scope{1, 1}"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_7[["εNFA0-7 regex end"]]
eNFA0_6 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"[-+]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"[0-9]"|eNFA0_3
eNFA0_3 -->|"[0-9]"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"[uU]"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_7
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_8[["εNFA0-8 post-regex start"]]
eNFA0_9[\"εNFA0-9 post-regex end"/]
eNFA0_8 -.->|"ε"|eNFA0_9
```


VtInfo.patterns[1/2]:0x[0-9A-Fa-f]+[uU]
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_8[["εNFA0-8 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 scope{1, -1}"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_6[["εNFA0-6 scope{1, 1}"]]
eNFA0_7[["εNFA0-7 scope[1]"]]
eNFA0_9[["εNFA0-9 regex end"]]
eNFA0_8 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"0"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"x"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"[0-9A-Fa-f]"|eNFA0_5
eNFA0_5 -->|"[0-9A-Fa-f]"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"[uU]"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_9
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_10[["εNFA0-10 post-regex start"]]
eNFA0_11[\"εNFA0-11 post-regex end"/]
eNFA0_10 -.->|"ε"|eNFA0_11
```


## Vt: 'floatConstant'
VtInfo.patterns[1/1]:[-+]?[0-9]+([.][0-9]*)?([Ee][-+]?[0-9]+)?[fF]
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_19[["εNFA0-19 regex start"]]
eNFA0_0[["εNFA0-0 scope{0, 1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA0_2[["εNFA0-2 scope{1, -1}"]]
eNFA0_3[["εNFA0-3 scope[1]"]]
eNFA0_7[["εNFA0-7 regex start"]]
eNFA0_4[["εNFA0-4 scope{1, 1}"]]
eNFA0_8[["εNFA0-8 regex end"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_15[["εNFA0-15 regex start"]]
eNFA0_6[["εNFA0-6 scope{0, -1}"]]
eNFA0_9[["εNFA0-9 scope{1, 1}"]]
eNFA0_16[["εNFA0-16 regex end"]]
eNFA0_8[["εNFA0-8 regex end"]]
eNFA0_10[["εNFA0-10 scope[1]"]]
eNFA0_17[["εNFA0-17 scope{1, 1}"]]
eNFA0_7[["εNFA0-7 regex start"]]
eNFA0_11[["εNFA0-11 scope{0, 1}"]]
eNFA0_18[["εNFA0-18 scope[1]"]]
eNFA0_4[["εNFA0-4 scope{1, 1}"]]
eNFA0_12[["εNFA0-12 scope[1]"]]
eNFA0_20[["εNFA0-20 regex end"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_13[["εNFA0-13 scope{1, -1}"]]
eNFA0_6[["εNFA0-6 scope{0, -1}"]]
eNFA0_14[["εNFA0-14 scope[1]"]]
eNFA0_16[["εNFA0-16 regex end"]]
eNFA0_15[["εNFA0-15 regex start"]]
eNFA0_9[["εNFA0-9 scope{1, 1}"]]
eNFA0_10[["εNFA0-10 scope[1]"]]
eNFA0_11[["εNFA0-11 scope{0, 1}"]]
eNFA0_12[["εNFA0-12 scope[1]"]]
eNFA0_13[["εNFA0-13 scope{1, -1}"]]
eNFA0_14[["εNFA0-14 scope[1]"]]
eNFA0_19 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"[-+]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"[0-9]"|eNFA0_3
eNFA0_3 -->|"[0-9]"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_4
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_4 -->|"[.]"|eNFA0_5
eNFA0_8 -.->|"ε"|eNFA0_15
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_15 -.->|"ε"|eNFA0_9
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_6 -->|"[0-9]"|eNFA0_6
eNFA0_6 -.->|"ε"|eNFA0_8
eNFA0_9 -->|"[Ee]"|eNFA0_10
eNFA0_16 -.->|"ε"|eNFA0_17
eNFA0_8 -.->|"ε"|eNFA0_7
eNFA0_10 -.->|"ε"|eNFA0_11
eNFA0_17 -->|"[fF]"|eNFA0_18
eNFA0_7 -.->|"ε"|eNFA0_4
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_11 -->|"[-+]"|eNFA0_12
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_18 -.->|"ε"|eNFA0_20
eNFA0_4 -->|"[.]"|eNFA0_5
eNFA0_12 -.->|"ε"|eNFA0_13
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_13 -->|"[0-9]"|eNFA0_14
eNFA0_6 -->|"[0-9]"|eNFA0_6
eNFA0_6 -.->|"ε"|eNFA0_8
eNFA0_14 -->|"[0-9]"|eNFA0_14
eNFA0_14 -.->|"ε"|eNFA0_16
eNFA0_16 -.->|"ε"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_9
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_9 -->|"[Ee]"|eNFA0_10
eNFA0_10 -.->|"ε"|eNFA0_11
eNFA0_11 -->|"[-+]"|eNFA0_12
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_12 -.->|"ε"|eNFA0_13
eNFA0_13 -->|"[0-9]"|eNFA0_14
eNFA0_14 -->|"[0-9]"|eNFA0_14
eNFA0_14 -.->|"ε"|eNFA0_16
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_21[["εNFA0-21 post-regex start"]]
eNFA0_22[\"εNFA0-22 post-regex end"/]
eNFA0_21 -.->|"ε"|eNFA0_22
```


## Vt: 'boolConstant'
VtInfo.patterns[1/2]:true/[^a-zA-Z0-9_]
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_8[["εNFA0-8 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_9[["εNFA0-9 regex end"]]
eNFA0_8 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"t"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"r"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"u"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"e"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_9
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_12[["εNFA0-12 regex start"]]
eNFA0_10[["εNFA0-10 scope{1, 1}"]]
eNFA0_11[["εNFA0-11 scope[1]"]]
eNFA0_13[\"εNFA0-13 regex end"/]
eNFA0_12 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"[^a-zA-Z0-9_]"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_13
```


VtInfo.patterns[1/2]:false/[^a-zA-Z0-9_]
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_10[["εNFA0-10 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_8[["εNFA0-8 char{1, 1}"]]
eNFA0_9[["εNFA0-9 char[1]"]]
eNFA0_11[["εNFA0-11 regex end"]]
eNFA0_10 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"f"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"a"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"l"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"s"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"e"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_11
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_14[["εNFA0-14 regex start"]]
eNFA0_12[["εNFA0-12 scope{1, 1}"]]
eNFA0_13[["εNFA0-13 scope[1]"]]
eNFA0_15[\"εNFA0-15 regex end"/]
eNFA0_14 -.->|"ε"|eNFA0_12
eNFA0_12 -->|"[^a-zA-Z0-9_]"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_15
```


## Vt: 'doubleConstant'
VtInfo.patterns[1/1]:[-+]?[0-9]+([.][0-9]*)?([Ee][-+]?[0-9]+)?
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_17[["εNFA0-17 regex start"]]
eNFA0_0[["εNFA0-0 scope{0, 1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA0_2[["εNFA0-2 scope{1, -1}"]]
eNFA0_3[["εNFA0-3 scope[1]"]]
eNFA0_7[["εNFA0-7 regex start"]]
eNFA0_4[["εNFA0-4 scope{1, 1}"]]
eNFA0_8[["εNFA0-8 regex end"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_15[["εNFA0-15 regex start"]]
eNFA0_6[["εNFA0-6 scope{0, -1}"]]
eNFA0_9[["εNFA0-9 scope{1, 1}"]]
eNFA0_16[["εNFA0-16 regex end"]]
eNFA0_8[["εNFA0-8 regex end"]]
eNFA0_10[["εNFA0-10 scope[1]"]]
eNFA0_18[["εNFA0-18 regex end"]]
eNFA0_7[["εNFA0-7 regex start"]]
eNFA0_11[["εNFA0-11 scope{0, 1}"]]
eNFA0_4[["εNFA0-4 scope{1, 1}"]]
eNFA0_12[["εNFA0-12 scope[1]"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_13[["εNFA0-13 scope{1, -1}"]]
eNFA0_6[["εNFA0-6 scope{0, -1}"]]
eNFA0_14[["εNFA0-14 scope[1]"]]
eNFA0_16[["εNFA0-16 regex end"]]
eNFA0_15[["εNFA0-15 regex start"]]
eNFA0_9[["εNFA0-9 scope{1, 1}"]]
eNFA0_10[["εNFA0-10 scope[1]"]]
eNFA0_11[["εNFA0-11 scope{0, 1}"]]
eNFA0_12[["εNFA0-12 scope[1]"]]
eNFA0_13[["εNFA0-13 scope{1, -1}"]]
eNFA0_14[["εNFA0-14 scope[1]"]]
eNFA0_17 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"[-+]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"[0-9]"|eNFA0_3
eNFA0_3 -->|"[0-9]"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_4
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_4 -->|"[.]"|eNFA0_5
eNFA0_8 -.->|"ε"|eNFA0_15
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_15 -.->|"ε"|eNFA0_9
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_6 -->|"[0-9]"|eNFA0_6
eNFA0_6 -.->|"ε"|eNFA0_8
eNFA0_9 -->|"[Ee]"|eNFA0_10
eNFA0_16 -.->|"ε"|eNFA0_18
eNFA0_8 -.->|"ε"|eNFA0_7
eNFA0_10 -.->|"ε"|eNFA0_11
eNFA0_7 -.->|"ε"|eNFA0_4
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_11 -->|"[-+]"|eNFA0_12
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_4 -->|"[.]"|eNFA0_5
eNFA0_12 -.->|"ε"|eNFA0_13
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_13 -->|"[0-9]"|eNFA0_14
eNFA0_6 -->|"[0-9]"|eNFA0_6
eNFA0_6 -.->|"ε"|eNFA0_8
eNFA0_14 -->|"[0-9]"|eNFA0_14
eNFA0_14 -.->|"ε"|eNFA0_16
eNFA0_16 -.->|"ε"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_9
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_9 -->|"[Ee]"|eNFA0_10
eNFA0_10 -.->|"ε"|eNFA0_11
eNFA0_11 -->|"[-+]"|eNFA0_12
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_12 -.->|"ε"|eNFA0_13
eNFA0_13 -->|"[0-9]"|eNFA0_14
eNFA0_14 -->|"[0-9]"|eNFA0_14
eNFA0_14 -.->|"ε"|eNFA0_16
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_19[["εNFA0-19 post-regex start"]]
eNFA0_20[\"εNFA0-20 post-regex end"/]
eNFA0_19 -.->|"ε"|eNFA0_20
```


## Vt: 'inlineComment'
VtInfo.patterns[1/1]:\/\/[^\n\r\u0000]*
1/3: pre-regex `'¥'`

2/3: regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_5[["εNFA0-5 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_4[["εNFA0-4 scope{0, -1}"]]
eNFA0_6[["εNFA0-6 regex end"]]
eNFA0_5 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;/"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"#92;/"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"[^#92;n#92;r#92;u0000]"|eNFA0_4
eNFA0_4 -.->|"ε"|eNFA0_6
```

3/3: post-regex
```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_7[["εNFA0-7 post-regex start"]]
eNFA0_8[\"εNFA0-8 post-regex end"/]
eNFA0_7 -.->|"ε"|eNFA0_8
```




# 总状态机

## 1/5: extracted ε-NFA

```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_0[["εNFA0-0 wholeStart"]]
eNFA1_14[["εNFA1-14 regex start"]]
class eNFA1_14 c1000;
eNFA2_2[["εNFA2-2 regex start"]]
class eNFA2_2 c1000;
eNFA3_2[["εNFA3-2 regex start"]]
class eNFA3_2 c1000;
eNFA4_12[["εNFA4-12 regex start"]]
class eNFA4_12 c1000;
eNFA5_2[["εNFA5-2 regex start"]]
class eNFA5_2 c1000;
eNFA6_2[["εNFA6-2 regex start"]]
class eNFA6_2 c1000;
eNFA7_2[["εNFA7-2 regex start"]]
class eNFA7_2 c1000;
eNFA8_2[["εNFA8-2 regex start"]]
class eNFA8_2 c1000;
eNFA9_2[["εNFA9-2 regex start"]]
class eNFA9_2 c1000;
eNFA10_4[["εNFA10-4 regex start"]]
class eNFA10_4 c1000;
eNFA11_4[["εNFA11-4 regex start"]]
class eNFA11_4 c1000;
eNFA12_2[["εNFA12-2 regex start"]]
class eNFA12_2 c1000;
eNFA13_2[["εNFA13-2 regex start"]]
class eNFA13_2 c1000;
eNFA14_2[["εNFA14-2 regex start"]]
class eNFA14_2 c1000;
eNFA15_2[["εNFA15-2 regex start"]]
class eNFA15_2 c1000;
eNFA16_2[["εNFA16-2 regex start"]]
class eNFA16_2 c1000;
eNFA17_2[["εNFA17-2 regex start"]]
class eNFA17_2 c1000;
eNFA18_2[["εNFA18-2 regex start"]]
class eNFA18_2 c1000;
eNFA19_4[["εNFA19-4 regex start"]]
class eNFA19_4 c1000;
eNFA20_4[["εNFA20-4 regex start"]]
class eNFA20_4 c1000;
eNFA21_2[["εNFA21-2 regex start"]]
class eNFA21_2 c1000;
eNFA22_2[["εNFA22-2 regex start"]]
class eNFA22_2 c1000;
eNFA23_4[["εNFA23-4 regex start"]]
class eNFA23_4 c1000;
eNFA24_4[["εNFA24-4 regex start"]]
class eNFA24_4 c1000;
eNFA25_4[["εNFA25-4 regex start"]]
class eNFA25_4 c1000;
eNFA26_4[["εNFA26-4 regex start"]]
class eNFA26_4 c1000;
eNFA27_2[["εNFA27-2 regex start"]]
class eNFA27_2 c1000;
eNFA28_2[["εNFA28-2 regex start"]]
class eNFA28_2 c1000;
eNFA29_2[["εNFA29-2 regex start"]]
class eNFA29_2 c1000;
eNFA30_4[["εNFA30-4 regex start"]]
class eNFA30_4 c1000;
eNFA31_4[["εNFA31-4 regex start"]]
class eNFA31_4 c1000;
eNFA32_4[["εNFA32-4 regex start"]]
class eNFA32_4 c1000;
eNFA33_2[["εNFA33-2 regex start"]]
class eNFA33_2 c1000;
eNFA34_2[["εNFA34-2 regex start"]]
class eNFA34_2 c1000;
eNFA35_2[["εNFA35-2 regex start"]]
class eNFA35_2 c1000;
eNFA36_4[["εNFA36-4 regex start"]]
class eNFA36_4 c1000;
eNFA37_4[["εNFA37-4 regex start"]]
class eNFA37_4 c1000;
eNFA38_4[["εNFA38-4 regex start"]]
class eNFA38_4 c1000;
eNFA39_4[["εNFA39-4 regex start"]]
class eNFA39_4 c1000;
eNFA40_4[["εNFA40-4 regex start"]]
class eNFA40_4 c1000;
eNFA41_6[["εNFA41-6 regex start"]]
class eNFA41_6 c1000;
eNFA42_6[["εNFA42-6 regex start"]]
class eNFA42_6 c1000;
eNFA43_4[["εNFA43-4 regex start"]]
class eNFA43_4 c1000;
eNFA44_4[["εNFA44-4 regex start"]]
class eNFA44_4 c1000;
eNFA45_4[["εNFA45-4 regex start"]]
class eNFA45_4 c1000;
eNFA46_2[["εNFA46-2 regex start"]]
class eNFA46_2 c1000;
eNFA47_2[["εNFA47-2 regex start"]]
class eNFA47_2 c1000;
eNFA48_4[["εNFA48-4 regex start"]]
class eNFA48_4 c1000;
eNFA49_6[["εNFA49-6 regex start"]]
class eNFA49_6 c1000;
eNFA50_12[["εNFA50-12 regex start"]]
class eNFA50_12 c1000;
eNFA51_14[["εNFA51-14 regex start"]]
class eNFA51_14 c1000;
eNFA52_10[["εNFA52-10 regex start"]]
class eNFA52_10 c1000;
eNFA53_10[["εNFA53-10 regex start"]]
class eNFA53_10 c1000;
eNFA54_12[["εNFA54-12 regex start"]]
class eNFA54_12 c1000;
eNFA55_12[["εNFA55-12 regex start"]]
class eNFA55_12 c1000;
eNFA56_14[["εNFA56-14 regex start"]]
class eNFA56_14 c1000;
eNFA57_20[["εNFA57-20 regex start"]]
class eNFA57_20 c1000;
eNFA58_16[["εNFA58-16 regex start"]]
class eNFA58_16 c1000;
eNFA59_10[["εNFA59-10 regex start"]]
class eNFA59_10 c1000;
eNFA60_14[["εNFA60-14 regex start"]]
class eNFA60_14 c1000;
eNFA61_3[["εNFA61-3 regex start"]]
class eNFA61_3 c1000;
eNFA62_14[["εNFA62-14 regex start"]]
class eNFA62_14 c1000;
eNFA63_8[["εNFA63-8 regex start"]]
class eNFA63_8 c1000;
eNFA64_4[["εNFA64-4 regex start"]]
class eNFA64_4 c1000;
eNFA65_6[["εNFA65-6 regex start"]]
class eNFA65_6 c1000;
eNFA66_6[["εNFA66-6 regex start"]]
class eNFA66_6 c1000;
eNFA67_8[["εNFA67-8 regex start"]]
class eNFA67_8 c1000;
eNFA68_19[["εNFA68-19 regex start"]]
class eNFA68_19 c1000;
eNFA69_8[["εNFA69-8 regex start"]]
class eNFA69_8 c1000;
eNFA70_10[["εNFA70-10 regex start"]]
class eNFA70_10 c1000;
eNFA71_17[["εNFA71-17 regex start"]]
class eNFA71_17 c1000;
eNFA72_5[["εNFA72-5 regex start"]]
class eNFA72_5 c1000;
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA2_0[["εNFA2-0 char{1, 1}"]]
eNFA3_0[["εNFA3-0 char{1, 1}"]]
eNFA4_0[["εNFA4-0 char{1, 1}"]]
eNFA5_0[["εNFA5-0 char{1, 1}"]]
eNFA6_0[["εNFA6-0 char{1, 1}"]]
eNFA7_0[["εNFA7-0 char{1, 1}"]]
eNFA8_0[["εNFA8-0 char{1, 1}"]]
eNFA9_0[["εNFA9-0 char{1, 1}"]]
eNFA10_0[["εNFA10-0 char{1, 1}"]]
eNFA11_0[["εNFA11-0 char{1, 1}"]]
eNFA12_0[["εNFA12-0 char{1, 1}"]]
eNFA13_0[["εNFA13-0 char{1, 1}"]]
eNFA14_0[["εNFA14-0 char{1, 1}"]]
eNFA15_0[["εNFA15-0 char{1, 1}"]]
eNFA16_0[["εNFA16-0 char{1, 1}"]]
eNFA17_0[["εNFA17-0 char{1, 1}"]]
eNFA18_0[["εNFA18-0 char{1, 1}"]]
eNFA19_0[["εNFA19-0 char{1, 1}"]]
eNFA20_0[["εNFA20-0 char{1, 1}"]]
eNFA21_0[["εNFA21-0 char{1, 1}"]]
eNFA22_0[["εNFA22-0 char{1, 1}"]]
eNFA23_0[["εNFA23-0 char{1, 1}"]]
eNFA24_0[["εNFA24-0 char{1, 1}"]]
eNFA25_0[["εNFA25-0 char{1, 1}"]]
eNFA26_0[["εNFA26-0 char{1, 1}"]]
eNFA27_0[["εNFA27-0 char{1, 1}"]]
eNFA28_0[["εNFA28-0 char{1, 1}"]]
eNFA29_0[["εNFA29-0 char{1, 1}"]]
eNFA30_0[["εNFA30-0 char{1, 1}"]]
eNFA31_0[["εNFA31-0 char{1, 1}"]]
eNFA32_0[["εNFA32-0 char{1, 1}"]]
eNFA33_0[["εNFA33-0 char{1, 1}"]]
eNFA34_0[["εNFA34-0 char{1, 1}"]]
eNFA35_0[["εNFA35-0 char{1, 1}"]]
eNFA36_0[["εNFA36-0 char{1, 1}"]]
eNFA37_0[["εNFA37-0 char{1, 1}"]]
eNFA38_0[["εNFA38-0 char{1, 1}"]]
eNFA39_0[["εNFA39-0 char{1, 1}"]]
eNFA40_0[["εNFA40-0 char{1, 1}"]]
eNFA41_0[["εNFA41-0 char{1, 1}"]]
eNFA42_0[["εNFA42-0 char{1, 1}"]]
eNFA43_0[["εNFA43-0 char{1, 1}"]]
eNFA44_0[["εNFA44-0 char{1, 1}"]]
eNFA45_0[["εNFA45-0 char{1, 1}"]]
eNFA46_0[["εNFA46-0 char{1, 1}"]]
eNFA47_0[["εNFA47-0 char{1, 1}"]]
eNFA48_0[["εNFA48-0 char{1, 1}"]]
eNFA49_0[["εNFA49-0 char{1, 1}"]]
eNFA50_0[["εNFA50-0 char{1, 1}"]]
eNFA51_0[["εNFA51-0 char{1, 1}"]]
eNFA52_0[["εNFA52-0 char{1, 1}"]]
eNFA53_0[["εNFA53-0 char{1, 1}"]]
eNFA54_0[["εNFA54-0 char{1, 1}"]]
eNFA55_0[["εNFA55-0 char{1, 1}"]]
eNFA56_0[["εNFA56-0 char{1, 1}"]]
eNFA57_0[["εNFA57-0 char{1, 1}"]]
eNFA58_0[["εNFA58-0 char{1, 1}"]]
eNFA59_0[["εNFA59-0 char{1, 1}"]]
eNFA60_0[["εNFA60-0 char{1, 1}"]]
eNFA61_0[["εNFA61-0 scope{1, 1}"]]
eNFA62_0[["εNFA62-0 scope{0, 1}"]]
eNFA63_0[["εNFA63-0 scope{1, -1}"]]
eNFA64_0[["εNFA64-0 scope{0, 1}"]]
eNFA65_0[["εNFA65-0 char{1, 1}"]]
eNFA66_0[["εNFA66-0 scope{0, 1}"]]
eNFA67_0[["εNFA67-0 char{1, 1}"]]
eNFA68_0[["εNFA68-0 scope{0, 1}"]]
eNFA69_0[["εNFA69-0 char{1, 1}"]]
eNFA70_0[["εNFA70-0 char{1, 1}"]]
eNFA71_0[["εNFA71-0 scope{0, 1}"]]
eNFA72_0[["εNFA72-0 char{1, 1}"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA2_1[["εNFA2-1 char[1]"]]
eNFA3_1[["εNFA3-1 char[1]"]]
eNFA4_1[["εNFA4-1 char[1]"]]
eNFA5_1[["εNFA5-1 char[1]"]]
eNFA6_1[["εNFA6-1 char[1]"]]
eNFA7_1[["εNFA7-1 char[1]"]]
eNFA8_1[["εNFA8-1 char[1]"]]
eNFA9_1[["εNFA9-1 char[1]"]]
eNFA10_1[["εNFA10-1 char[1]"]]
eNFA11_1[["εNFA11-1 char[1]"]]
eNFA12_1[["εNFA12-1 char[1]"]]
eNFA13_1[["εNFA13-1 char[1]"]]
eNFA14_1[["εNFA14-1 char[1]"]]
eNFA15_1[["εNFA15-1 char[1]"]]
eNFA16_1[["εNFA16-1 char[1]"]]
eNFA17_1[["εNFA17-1 char[1]"]]
eNFA18_1[["εNFA18-1 char[1]"]]
eNFA19_1[["εNFA19-1 char[1]"]]
eNFA20_1[["εNFA20-1 char[1]"]]
eNFA21_1[["εNFA21-1 char[1]"]]
eNFA22_1[["εNFA22-1 char[1]"]]
eNFA23_1[["εNFA23-1 char[1]"]]
eNFA24_1[["εNFA24-1 char[1]"]]
eNFA25_1[["εNFA25-1 char[1]"]]
eNFA26_1[["εNFA26-1 char[1]"]]
eNFA27_1[["εNFA27-1 char[1]"]]
eNFA28_1[["εNFA28-1 char[1]"]]
eNFA29_1[["εNFA29-1 char[1]"]]
eNFA30_1[["εNFA30-1 char[1]"]]
eNFA31_1[["εNFA31-1 char[1]"]]
eNFA32_1[["εNFA32-1 char[1]"]]
eNFA33_1[["εNFA33-1 char[1]"]]
eNFA34_1[["εNFA34-1 char[1]"]]
eNFA35_1[["εNFA35-1 char[1]"]]
eNFA36_1[["εNFA36-1 char[1]"]]
eNFA37_1[["εNFA37-1 char[1]"]]
eNFA38_1[["εNFA38-1 char[1]"]]
eNFA39_1[["εNFA39-1 char[1]"]]
eNFA40_1[["εNFA40-1 char[1]"]]
eNFA41_1[["εNFA41-1 char[1]"]]
eNFA42_1[["εNFA42-1 char[1]"]]
eNFA43_1[["εNFA43-1 char[1]"]]
eNFA44_1[["εNFA44-1 char[1]"]]
eNFA45_1[["εNFA45-1 char[1]"]]
eNFA46_1[["εNFA46-1 char[1]"]]
eNFA47_1[["εNFA47-1 char[1]"]]
eNFA48_1[["εNFA48-1 char[1]"]]
eNFA49_1[["εNFA49-1 char[1]"]]
eNFA50_1[["εNFA50-1 char[1]"]]
eNFA51_1[["εNFA51-1 char[1]"]]
eNFA52_1[["εNFA52-1 char[1]"]]
eNFA53_1[["εNFA53-1 char[1]"]]
eNFA54_1[["εNFA54-1 char[1]"]]
eNFA55_1[["εNFA55-1 char[1]"]]
eNFA56_1[["εNFA56-1 char[1]"]]
eNFA57_1[["εNFA57-1 char[1]"]]
eNFA58_1[["εNFA58-1 char[1]"]]
eNFA59_1[["εNFA59-1 char[1]"]]
eNFA60_1[["εNFA60-1 char[1]"]]
eNFA61_1[["εNFA61-1 scope[1]"]]
eNFA62_1[["εNFA62-1 scope[1]"]]
eNFA63_1[["εNFA63-1 scope[1]"]]
eNFA64_1[["εNFA64-1 scope[1]"]]
eNFA65_1[["εNFA65-1 char[1]"]]
eNFA66_1[["εNFA66-1 scope[1]"]]
eNFA67_1[["εNFA67-1 char[1]"]]
eNFA68_1[["εNFA68-1 scope[1]"]]
eNFA69_1[["εNFA69-1 char[1]"]]
eNFA70_1[["εNFA70-1 char[1]"]]
eNFA71_1[["εNFA71-1 scope[1]"]]
eNFA72_1[["εNFA72-1 char[1]"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA2_3[["εNFA2-3 regex end"]]
eNFA3_3[["εNFA3-3 regex end"]]
eNFA4_2[["εNFA4-2 char{1, 1}"]]
eNFA5_3[["εNFA5-3 regex end"]]
eNFA6_3[["εNFA6-3 regex end"]]
eNFA7_3[["εNFA7-3 regex end"]]
eNFA8_3[["εNFA8-3 regex end"]]
eNFA9_3[["εNFA9-3 regex end"]]
eNFA10_2[["εNFA10-2 char{1, 1}"]]
eNFA11_2[["εNFA11-2 char{1, 1}"]]
eNFA12_3[["εNFA12-3 regex end"]]
eNFA13_3[["εNFA13-3 regex end"]]
eNFA14_3[["εNFA14-3 regex end"]]
eNFA15_3[["εNFA15-3 regex end"]]
eNFA16_3[["εNFA16-3 regex end"]]
eNFA17_3[["εNFA17-3 regex end"]]
eNFA18_3[["εNFA18-3 regex end"]]
eNFA19_2[["εNFA19-2 char{1, 1}"]]
eNFA20_2[["εNFA20-2 char{1, 1}"]]
eNFA21_3[["εNFA21-3 regex end"]]
eNFA22_3[["εNFA22-3 regex end"]]
eNFA23_2[["εNFA23-2 char{1, 1}"]]
eNFA24_2[["εNFA24-2 char{1, 1}"]]
eNFA25_2[["εNFA25-2 char{1, 1}"]]
eNFA26_2[["εNFA26-2 char{1, 1}"]]
eNFA27_3[["εNFA27-3 regex end"]]
eNFA28_3[["εNFA28-3 regex end"]]
eNFA29_3[["εNFA29-3 regex end"]]
eNFA30_2[["εNFA30-2 char{1, 1}"]]
eNFA31_2[["εNFA31-2 char{1, 1}"]]
eNFA32_2[["εNFA32-2 char{1, 1}"]]
eNFA33_3[["εNFA33-3 regex end"]]
eNFA34_3[["εNFA34-3 regex end"]]
eNFA35_3[["εNFA35-3 regex end"]]
eNFA36_2[["εNFA36-2 char{1, 1}"]]
eNFA37_2[["εNFA37-2 char{1, 1}"]]
eNFA38_2[["εNFA38-2 char{1, 1}"]]
eNFA39_2[["εNFA39-2 char{1, 1}"]]
eNFA40_2[["εNFA40-2 char{1, 1}"]]
eNFA41_2[["εNFA41-2 char{1, 1}"]]
eNFA42_2[["εNFA42-2 char{1, 1}"]]
eNFA43_2[["εNFA43-2 char{1, 1}"]]
eNFA44_2[["εNFA44-2 char{1, 1}"]]
eNFA45_2[["εNFA45-2 char{1, 1}"]]
eNFA46_3[["εNFA46-3 regex end"]]
eNFA47_3[["εNFA47-3 regex end"]]
eNFA48_2[["εNFA48-2 char{1, 1}"]]
eNFA49_2[["εNFA49-2 char{1, 1}"]]
eNFA50_2[["εNFA50-2 char{1, 1}"]]
eNFA51_2[["εNFA51-2 char{1, 1}"]]
eNFA52_2[["εNFA52-2 char{1, 1}"]]
eNFA53_2[["εNFA53-2 char{1, 1}"]]
eNFA54_2[["εNFA54-2 char{1, 1}"]]
eNFA55_2[["εNFA55-2 char{1, 1}"]]
eNFA56_2[["εNFA56-2 char{1, 1}"]]
eNFA57_2[["εNFA57-2 char{1, 1}"]]
eNFA58_2[["εNFA58-2 char{1, 1}"]]
eNFA59_2[["εNFA59-2 char{1, 1}"]]
eNFA60_2[["εNFA60-2 char{1, 1}"]]
eNFA61_2[["εNFA61-2 scope{0, -1}"]]
eNFA62_2[["εNFA62-2 char{1, 1}"]]
eNFA63_6[["εNFA63-6 regex start"]]
eNFA64_2[["εNFA64-2 scope{1, -1}"]]
eNFA65_2[["εNFA65-2 char{1, 1}"]]
eNFA66_2[["εNFA66-2 scope{1, -1}"]]
eNFA67_2[["εNFA67-2 char{1, 1}"]]
eNFA68_2[["εNFA68-2 scope{1, -1}"]]
eNFA69_2[["εNFA69-2 char{1, 1}"]]
eNFA70_2[["εNFA70-2 char{1, 1}"]]
eNFA71_2[["εNFA71-2 scope{1, -1}"]]
eNFA72_2[["εNFA72-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA2_4[["εNFA2-4 post-regex start"]]
eNFA3_4[["εNFA3-4 post-regex start"]]
eNFA4_3[["εNFA4-3 char[1]"]]
eNFA5_4[["εNFA5-4 post-regex start"]]
eNFA6_4[["εNFA6-4 post-regex start"]]
eNFA7_4[["εNFA7-4 post-regex start"]]
eNFA8_4[["εNFA8-4 post-regex start"]]
eNFA9_4[["εNFA9-4 post-regex start"]]
eNFA10_3[["εNFA10-3 char[1]"]]
eNFA11_3[["εNFA11-3 char[1]"]]
eNFA12_4[["εNFA12-4 post-regex start"]]
eNFA13_4[["εNFA13-4 post-regex start"]]
eNFA14_4[["εNFA14-4 post-regex start"]]
eNFA15_4[["εNFA15-4 post-regex start"]]
eNFA16_4[["εNFA16-4 post-regex start"]]
eNFA17_4[["εNFA17-4 post-regex start"]]
eNFA18_4[["εNFA18-4 post-regex start"]]
eNFA19_3[["εNFA19-3 char[1]"]]
eNFA20_3[["εNFA20-3 char[1]"]]
eNFA21_4[["εNFA21-4 post-regex start"]]
eNFA22_4[["εNFA22-4 post-regex start"]]
eNFA23_3[["εNFA23-3 char[1]"]]
eNFA24_3[["εNFA24-3 char[1]"]]
eNFA25_3[["εNFA25-3 char[1]"]]
eNFA26_3[["εNFA26-3 char[1]"]]
eNFA27_4[["εNFA27-4 post-regex start"]]
eNFA28_4[["εNFA28-4 post-regex start"]]
eNFA29_4[["εNFA29-4 post-regex start"]]
eNFA30_3[["εNFA30-3 char[1]"]]
eNFA31_3[["εNFA31-3 char[1]"]]
eNFA32_3[["εNFA32-3 char[1]"]]
eNFA33_4[["εNFA33-4 post-regex start"]]
eNFA34_4[["εNFA34-4 post-regex start"]]
eNFA35_4[["εNFA35-4 post-regex start"]]
eNFA36_3[["εNFA36-3 char[1]"]]
eNFA37_3[["εNFA37-3 char[1]"]]
eNFA38_3[["εNFA38-3 char[1]"]]
eNFA39_3[["εNFA39-3 char[1]"]]
eNFA40_3[["εNFA40-3 char[1]"]]
eNFA41_3[["εNFA41-3 char[1]"]]
eNFA42_3[["εNFA42-3 char[1]"]]
eNFA43_3[["εNFA43-3 char[1]"]]
eNFA44_3[["εNFA44-3 char[1]"]]
eNFA45_3[["εNFA45-3 char[1]"]]
eNFA46_4[["εNFA46-4 post-regex start"]]
eNFA47_4[["εNFA47-4 post-regex start"]]
eNFA48_3[["εNFA48-3 char[1]"]]
eNFA49_3[["εNFA49-3 char[1]"]]
eNFA50_3[["εNFA50-3 char[1]"]]
eNFA51_3[["εNFA51-3 char[1]"]]
eNFA52_3[["εNFA52-3 char[1]"]]
eNFA53_3[["εNFA53-3 char[1]"]]
eNFA54_3[["εNFA54-3 char[1]"]]
eNFA55_3[["εNFA55-3 char[1]"]]
eNFA56_3[["εNFA56-3 char[1]"]]
eNFA57_3[["εNFA57-3 char[1]"]]
eNFA58_3[["εNFA58-3 char[1]"]]
eNFA59_3[["εNFA59-3 char[1]"]]
eNFA60_3[["εNFA60-3 char[1]"]]
eNFA61_4[["εNFA61-4 regex end"]]
eNFA62_3[["εNFA62-3 char[1]"]]
eNFA63_2[["εNFA63-2 scope{1, 1}"]]
eNFA63_7[["εNFA63-7 regex end"]]
eNFA64_3[["εNFA64-3 scope[1]"]]
eNFA65_3[["εNFA65-3 char[1]"]]
eNFA66_3[["εNFA66-3 scope[1]"]]
eNFA67_3[["εNFA67-3 char[1]"]]
eNFA68_3[["εNFA68-3 scope[1]"]]
eNFA69_3[["εNFA69-3 char[1]"]]
eNFA70_3[["εNFA70-3 char[1]"]]
eNFA71_3[["εNFA71-3 scope[1]"]]
eNFA72_3[["εNFA72-3 char[1]"]]
eNFA1_4[["εNFA1-4 char{1, 1}"]]
eNFA2_5[\"εNFA2-5 post-regex end"/]
class eNFA2_5 c0001;
eNFA3_5[\"εNFA3-5 post-regex end"/]
class eNFA3_5 c0001;
eNFA4_4[["εNFA4-4 char{1, 1}"]]
eNFA5_5[\"εNFA5-5 post-regex end"/]
class eNFA5_5 c0001;
eNFA6_5[\"εNFA6-5 post-regex end"/]
class eNFA6_5 c0001;
eNFA7_5[\"εNFA7-5 post-regex end"/]
class eNFA7_5 c0001;
eNFA8_5[\"εNFA8-5 post-regex end"/]
class eNFA8_5 c0001;
eNFA9_5[\"εNFA9-5 post-regex end"/]
class eNFA9_5 c0001;
eNFA10_5[["εNFA10-5 regex end"]]
eNFA11_5[["εNFA11-5 regex end"]]
eNFA12_5[\"εNFA12-5 post-regex end"/]
class eNFA12_5 c0001;
eNFA13_5[\"εNFA13-5 post-regex end"/]
class eNFA13_5 c0001;
eNFA14_5[\"εNFA14-5 post-regex end"/]
class eNFA14_5 c0001;
eNFA15_5[\"εNFA15-5 post-regex end"/]
class eNFA15_5 c0001;
eNFA16_5[\"εNFA16-5 post-regex end"/]
class eNFA16_5 c0001;
eNFA17_5[\"εNFA17-5 post-regex end"/]
class eNFA17_5 c0001;
eNFA18_5[\"εNFA18-5 post-regex end"/]
class eNFA18_5 c0001;
eNFA19_5[["εNFA19-5 regex end"]]
eNFA20_5[["εNFA20-5 regex end"]]
eNFA21_5[\"εNFA21-5 post-regex end"/]
class eNFA21_5 c0001;
eNFA22_5[\"εNFA22-5 post-regex end"/]
class eNFA22_5 c0001;
eNFA23_5[["εNFA23-5 regex end"]]
eNFA24_5[["εNFA24-5 regex end"]]
eNFA25_5[["εNFA25-5 regex end"]]
eNFA26_5[["εNFA26-5 regex end"]]
eNFA27_5[\"εNFA27-5 post-regex end"/]
class eNFA27_5 c0001;
eNFA28_5[\"εNFA28-5 post-regex end"/]
class eNFA28_5 c0001;
eNFA29_5[\"εNFA29-5 post-regex end"/]
class eNFA29_5 c0001;
eNFA30_5[["εNFA30-5 regex end"]]
eNFA31_5[["εNFA31-5 regex end"]]
eNFA32_5[["εNFA32-5 regex end"]]
eNFA33_5[\"εNFA33-5 post-regex end"/]
class eNFA33_5 c0001;
eNFA34_5[\"εNFA34-5 post-regex end"/]
class eNFA34_5 c0001;
eNFA35_5[\"εNFA35-5 post-regex end"/]
class eNFA35_5 c0001;
eNFA36_5[["εNFA36-5 regex end"]]
eNFA37_5[["εNFA37-5 regex end"]]
eNFA38_5[["εNFA38-5 regex end"]]
eNFA39_5[["εNFA39-5 regex end"]]
eNFA40_5[["εNFA40-5 regex end"]]
eNFA41_4[["εNFA41-4 char{1, 1}"]]
eNFA42_4[["εNFA42-4 char{1, 1}"]]
eNFA43_5[["εNFA43-5 regex end"]]
eNFA44_5[["εNFA44-5 regex end"]]
eNFA45_5[["εNFA45-5 regex end"]]
eNFA46_5[\"εNFA46-5 post-regex end"/]
class eNFA46_5 c0001;
eNFA47_5[\"εNFA47-5 post-regex end"/]
class eNFA47_5 c0001;
eNFA48_5[["εNFA48-5 regex end"]]
eNFA49_4[["εNFA49-4 char{1, 1}"]]
eNFA50_4[["εNFA50-4 char{1, 1}"]]
eNFA51_4[["εNFA51-4 char{1, 1}"]]
eNFA52_4[["εNFA52-4 char{1, 1}"]]
eNFA53_4[["εNFA53-4 char{1, 1}"]]
eNFA54_4[["εNFA54-4 char{1, 1}"]]
eNFA55_4[["εNFA55-4 char{1, 1}"]]
eNFA56_4[["εNFA56-4 char{1, 1}"]]
eNFA57_4[["εNFA57-4 char{1, 1}"]]
eNFA58_4[["εNFA58-4 char{1, 1}"]]
eNFA59_4[["εNFA59-4 char{1, 1}"]]
eNFA60_4[["εNFA60-4 char{1, 1}"]]
eNFA61_5[["εNFA61-5 post-regex start"]]
eNFA62_8[["εNFA62-8 regex start"]]
eNFA63_3[["εNFA63-3 scope[1]"]]
eNFA63_9[["εNFA63-9 regex end"]]
eNFA64_5[["εNFA64-5 regex end"]]
eNFA65_4[["εNFA65-4 scope{1, -1}"]]
eNFA66_4[["εNFA66-4 scope{1, 1}"]]
eNFA67_4[["εNFA67-4 scope{1, -1}"]]
eNFA68_7[["εNFA68-7 regex start"]]
eNFA69_4[["εNFA69-4 char{1, 1}"]]
eNFA70_4[["εNFA70-4 char{1, 1}"]]
eNFA71_7[["εNFA71-7 regex start"]]
eNFA72_4[["εNFA72-4 scope{0, -1}"]]
eNFA1_5[["εNFA1-5 char[1]"]]
eNFA0_1[\"εNFA0-1 wholeEnd"/]
eNFA4_5[["εNFA4-5 char[1]"]]
eNFA10_6[["εNFA10-6 post-regex start"]]
eNFA11_6[["εNFA11-6 post-regex start"]]
eNFA19_6[["εNFA19-6 post-regex start"]]
eNFA20_6[["εNFA20-6 post-regex start"]]
eNFA23_6[["εNFA23-6 post-regex start"]]
eNFA24_6[["εNFA24-6 post-regex start"]]
eNFA25_6[["εNFA25-6 post-regex start"]]
eNFA26_6[["εNFA26-6 post-regex start"]]
eNFA30_6[["εNFA30-6 post-regex start"]]
eNFA31_6[["εNFA31-6 post-regex start"]]
eNFA32_6[["εNFA32-6 post-regex start"]]
eNFA36_6[["εNFA36-6 post-regex start"]]
eNFA37_6[["εNFA37-6 post-regex start"]]
eNFA38_6[["εNFA38-6 post-regex start"]]
eNFA39_6[["εNFA39-6 post-regex start"]]
eNFA40_6[["εNFA40-6 post-regex start"]]
eNFA41_5[["εNFA41-5 char[1]"]]
eNFA42_5[["εNFA42-5 char[1]"]]
eNFA43_6[["εNFA43-6 post-regex start"]]
eNFA44_6[["εNFA44-6 post-regex start"]]
eNFA45_6[["εNFA45-6 post-regex start"]]
eNFA48_6[["εNFA48-6 post-regex start"]]
eNFA49_5[["εNFA49-5 char[1]"]]
eNFA50_5[["εNFA50-5 char[1]"]]
eNFA51_5[["εNFA51-5 char[1]"]]
eNFA52_5[["εNFA52-5 char[1]"]]
eNFA53_5[["εNFA53-5 char[1]"]]
eNFA54_5[["εNFA54-5 char[1]"]]
eNFA55_5[["εNFA55-5 char[1]"]]
eNFA56_5[["εNFA56-5 char[1]"]]
eNFA57_5[["εNFA57-5 char[1]"]]
eNFA58_5[["εNFA58-5 char[1]"]]
eNFA59_5[["εNFA59-5 char[1]"]]
eNFA60_5[["εNFA60-5 char[1]"]]
eNFA61_6[\"εNFA61-6 post-regex end"/]
class eNFA61_6 c0001;
eNFA62_4[["εNFA62-4 char{1, 1}"]]
eNFA62_10[["εNFA62-10 scope{1, 1}"]]
eNFA62_9[["εNFA62-9 regex end"]]
eNFA63_4[["εNFA63-4 scope{1, -1}"]]
eNFA63_10[["εNFA63-10 post-regex start"]]
eNFA64_6[["εNFA64-6 post-regex start"]]
eNFA65_5[["εNFA65-5 scope[1]"]]
eNFA66_5[["εNFA66-5 scope[1]"]]
eNFA67_5[["εNFA67-5 scope[1]"]]
eNFA68_4[["εNFA68-4 scope{1, 1}"]]
eNFA68_8[["εNFA68-8 regex end"]]
eNFA69_5[["εNFA69-5 char[1]"]]
eNFA70_5[["εNFA70-5 char[1]"]]
eNFA71_4[["εNFA71-4 scope{1, 1}"]]
eNFA71_8[["εNFA71-8 regex end"]]
eNFA72_6[["εNFA72-6 regex end"]]
eNFA1_6[["εNFA1-6 char{1, 1}"]]
eNFA4_6[["εNFA4-6 char{1, 1}"]]
eNFA10_7[\"εNFA10-7 post-regex end"/]
class eNFA10_7 c0001;
eNFA11_7[\"εNFA11-7 post-regex end"/]
class eNFA11_7 c0001;
eNFA19_7[\"εNFA19-7 post-regex end"/]
class eNFA19_7 c0001;
eNFA20_7[\"εNFA20-7 post-regex end"/]
class eNFA20_7 c0001;
eNFA23_7[\"εNFA23-7 post-regex end"/]
class eNFA23_7 c0001;
eNFA24_7[\"εNFA24-7 post-regex end"/]
class eNFA24_7 c0001;
eNFA25_7[\"εNFA25-7 post-regex end"/]
class eNFA25_7 c0001;
eNFA26_7[\"εNFA26-7 post-regex end"/]
class eNFA26_7 c0001;
eNFA30_7[\"εNFA30-7 post-regex end"/]
class eNFA30_7 c0001;
eNFA31_7[\"εNFA31-7 post-regex end"/]
class eNFA31_7 c0001;
eNFA32_7[\"εNFA32-7 post-regex end"/]
class eNFA32_7 c0001;
eNFA36_7[\"εNFA36-7 post-regex end"/]
class eNFA36_7 c0001;
eNFA37_7[\"εNFA37-7 post-regex end"/]
class eNFA37_7 c0001;
eNFA38_7[\"εNFA38-7 post-regex end"/]
class eNFA38_7 c0001;
eNFA39_7[\"εNFA39-7 post-regex end"/]
class eNFA39_7 c0001;
eNFA40_7[\"εNFA40-7 post-regex end"/]
class eNFA40_7 c0001;
eNFA41_7[["εNFA41-7 regex end"]]
eNFA42_7[["εNFA42-7 regex end"]]
eNFA43_7[\"εNFA43-7 post-regex end"/]
class eNFA43_7 c0001;
eNFA44_7[\"εNFA44-7 post-regex end"/]
class eNFA44_7 c0001;
eNFA45_7[\"εNFA45-7 post-regex end"/]
class eNFA45_7 c0001;
eNFA48_7[\"εNFA48-7 post-regex end"/]
class eNFA48_7 c0001;
eNFA49_7[["εNFA49-7 regex end"]]
eNFA50_6[["εNFA50-6 char{1, 1}"]]
eNFA51_6[["εNFA51-6 char{1, 1}"]]
eNFA52_6[["εNFA52-6 char{1, 1}"]]
eNFA53_6[["εNFA53-6 char{1, 1}"]]
eNFA54_6[["εNFA54-6 char{1, 1}"]]
eNFA55_6[["εNFA55-6 char{1, 1}"]]
eNFA56_6[["εNFA56-6 char{1, 1}"]]
eNFA57_6[["εNFA57-6 char{1, 1}"]]
eNFA58_6[["εNFA58-6 char{1, 1}"]]
eNFA59_6[["εNFA59-6 char{1, 1}"]]
eNFA60_6[["εNFA60-6 char{1, 1}"]]
eNFA62_5[["εNFA62-5 char[1]"]]
eNFA62_11[["εNFA62-11 scope[1]"]]
eNFA62_12[["εNFA62-12 char{1, 1}"]]
eNFA63_5[["εNFA63-5 scope[1]"]]
eNFA63_11[\"εNFA63-11 post-regex end"/]
class eNFA63_11 c0001;
eNFA64_7[\"εNFA64-7 post-regex end"/]
class eNFA64_7 c0001;
eNFA65_7[["εNFA65-7 regex end"]]
eNFA66_7[["εNFA66-7 regex end"]]
eNFA67_6[["εNFA67-6 scope{1, 1}"]]
eNFA68_5[["εNFA68-5 scope[1]"]]
eNFA68_15[["εNFA68-15 regex start"]]
eNFA69_6[["εNFA69-6 char{1, 1}"]]
eNFA70_6[["εNFA70-6 char{1, 1}"]]
eNFA71_5[["εNFA71-5 scope[1]"]]
eNFA71_15[["εNFA71-15 regex start"]]
eNFA72_7[["εNFA72-7 post-regex start"]]
eNFA1_7[["εNFA1-7 char[1]"]]
eNFA4_7[["εNFA4-7 char[1]"]]
eNFA41_8[["εNFA41-8 post-regex start"]]
eNFA42_8[["εNFA42-8 post-regex start"]]
eNFA49_8[["εNFA49-8 post-regex start"]]
eNFA50_7[["εNFA50-7 char[1]"]]
eNFA51_7[["εNFA51-7 char[1]"]]
eNFA52_7[["εNFA52-7 char[1]"]]
eNFA53_7[["εNFA53-7 char[1]"]]
eNFA54_7[["εNFA54-7 char[1]"]]
eNFA55_7[["εNFA55-7 char[1]"]]
eNFA56_7[["εNFA56-7 char[1]"]]
eNFA57_7[["εNFA57-7 char[1]"]]
eNFA58_7[["εNFA58-7 char[1]"]]
eNFA59_7[["εNFA59-7 char[1]"]]
eNFA60_7[["εNFA60-7 char[1]"]]
eNFA62_6[["εNFA62-6 char{1, 1}"]]
eNFA62_13[["εNFA62-13 char[1]"]]
eNFA63_7[["εNFA63-7 regex end"]]
eNFA65_8[["εNFA65-8 post-regex start"]]
eNFA66_8[["εNFA66-8 post-regex start"]]
eNFA67_7[["εNFA67-7 scope[1]"]]
eNFA68_6[["εNFA68-6 scope{0, -1}"]]
eNFA68_9[["εNFA68-9 scope{1, 1}"]]
eNFA68_16[["εNFA68-16 regex end"]]
eNFA69_7[["εNFA69-7 char[1]"]]
eNFA70_7[["εNFA70-7 char[1]"]]
eNFA71_6[["εNFA71-6 scope{0, -1}"]]
eNFA71_9[["εNFA71-9 scope{1, 1}"]]
eNFA71_16[["εNFA71-16 regex end"]]
eNFA72_8[\"εNFA72-8 post-regex end"/]
class eNFA72_8 c0001;
eNFA1_8[["εNFA1-8 char{1, 1}"]]
eNFA4_8[["εNFA4-8 char{1, 1}"]]
eNFA41_9[\"εNFA41-9 post-regex end"/]
class eNFA41_9 c0001;
eNFA42_9[\"εNFA42-9 post-regex end"/]
class eNFA42_9 c0001;
eNFA49_9[\"εNFA49-9 post-regex end"/]
class eNFA49_9 c0001;
eNFA50_8[["εNFA50-8 char{1, 1}"]]
eNFA51_8[["εNFA51-8 char{1, 1}"]]
eNFA52_8[["εNFA52-8 char{1, 1}"]]
eNFA53_8[["εNFA53-8 char{1, 1}"]]
eNFA54_8[["εNFA54-8 char{1, 1}"]]
eNFA55_8[["εNFA55-8 char{1, 1}"]]
eNFA56_8[["εNFA56-8 char{1, 1}"]]
eNFA57_8[["εNFA57-8 char{1, 1}"]]
eNFA58_8[["εNFA58-8 char{1, 1}"]]
eNFA59_8[["εNFA59-8 char{1, 1}"]]
eNFA60_8[["εNFA60-8 char{1, 1}"]]
eNFA62_7[["εNFA62-7 char[1]"]]
eNFA62_15[["εNFA62-15 regex end"]]
eNFA63_6[["εNFA63-6 regex start"]]
eNFA65_9[\"εNFA65-9 post-regex end"/]
class eNFA65_9 c0001;
eNFA66_9[\"εNFA66-9 post-regex end"/]
class eNFA66_9 c0001;
eNFA67_9[["εNFA67-9 regex end"]]
eNFA68_8[["εNFA68-8 regex end"]]
eNFA68_10[["εNFA68-10 scope[1]"]]
eNFA68_17[["εNFA68-17 scope{1, 1}"]]
eNFA69_9[["εNFA69-9 regex end"]]
eNFA70_8[["εNFA70-8 char{1, 1}"]]
eNFA71_8[["εNFA71-8 regex end"]]
eNFA71_10[["εNFA71-10 scope[1]"]]
eNFA71_18[["εNFA71-18 regex end"]]
eNFA1_9[["εNFA1-9 char[1]"]]
eNFA4_9[["εNFA4-9 char[1]"]]
eNFA50_9[["εNFA50-9 char[1]"]]
eNFA51_9[["εNFA51-9 char[1]"]]
eNFA52_9[["εNFA52-9 char[1]"]]
eNFA53_9[["εNFA53-9 char[1]"]]
eNFA54_9[["εNFA54-9 char[1]"]]
eNFA55_9[["εNFA55-9 char[1]"]]
eNFA56_9[["εNFA56-9 char[1]"]]
eNFA57_9[["εNFA57-9 char[1]"]]
eNFA58_9[["εNFA58-9 char[1]"]]
eNFA59_9[["εNFA59-9 char[1]"]]
eNFA60_9[["εNFA60-9 char[1]"]]
eNFA62_16[["εNFA62-16 post-regex start"]]
eNFA63_2[["εNFA63-2 scope{1, 1}"]]
eNFA67_10[["εNFA67-10 post-regex start"]]
eNFA68_7[["εNFA68-7 regex start"]]
eNFA68_11[["εNFA68-11 scope{0, 1}"]]
eNFA68_18[["εNFA68-18 scope[1]"]]
eNFA69_12[["εNFA69-12 regex start"]]
eNFA70_9[["εNFA70-9 char[1]"]]
eNFA71_7[["εNFA71-7 regex start"]]
eNFA71_11[["εNFA71-11 scope{0, 1}"]]
eNFA71_19[["εNFA71-19 post-regex start"]]
eNFA1_10[["εNFA1-10 char{1, 1}"]]
eNFA4_10[["εNFA4-10 char{1, 1}"]]
eNFA50_10[["εNFA50-10 char{1, 1}"]]
eNFA51_10[["εNFA51-10 char{1, 1}"]]
eNFA52_11[["εNFA52-11 regex end"]]
eNFA53_11[["εNFA53-11 regex end"]]
eNFA54_10[["εNFA54-10 char{1, 1}"]]
eNFA55_10[["εNFA55-10 char{1, 1}"]]
eNFA56_10[["εNFA56-10 char{1, 1}"]]
eNFA57_10[["εNFA57-10 char{1, 1}"]]
eNFA58_10[["εNFA58-10 char{1, 1}"]]
eNFA59_11[["εNFA59-11 regex end"]]
eNFA60_10[["εNFA60-10 char{1, 1}"]]
eNFA62_17[\"εNFA62-17 post-regex end"/]
class eNFA62_17 c0001;
eNFA63_3[["εNFA63-3 scope[1]"]]
eNFA67_11[\"εNFA67-11 post-regex end"/]
class eNFA67_11 c0001;
eNFA68_4[["εNFA68-4 scope{1, 1}"]]
eNFA68_12[["εNFA68-12 scope[1]"]]
eNFA68_20[["εNFA68-20 regex end"]]
eNFA69_10[["εNFA69-10 scope{1, 1}"]]
eNFA70_11[["εNFA70-11 regex end"]]
eNFA71_4[["εNFA71-4 scope{1, 1}"]]
eNFA71_12[["εNFA71-12 scope[1]"]]
eNFA71_20[\"εNFA71-20 post-regex end"/]
class eNFA71_20 c0001;
eNFA1_11[["εNFA1-11 char[1]"]]
eNFA4_11[["εNFA4-11 char[1]"]]
eNFA50_11[["εNFA50-11 char[1]"]]
eNFA51_11[["εNFA51-11 char[1]"]]
eNFA52_12[["εNFA52-12 post-regex start"]]
eNFA53_12[["εNFA53-12 post-regex start"]]
eNFA54_11[["εNFA54-11 char[1]"]]
eNFA55_11[["εNFA55-11 char[1]"]]
eNFA56_11[["εNFA56-11 char[1]"]]
eNFA57_11[["εNFA57-11 char[1]"]]
eNFA58_11[["εNFA58-11 char[1]"]]
eNFA59_12[["εNFA59-12 post-regex start"]]
eNFA60_11[["εNFA60-11 char[1]"]]
eNFA63_4[["εNFA63-4 scope{1, -1}"]]
eNFA68_5[["εNFA68-5 scope[1]"]]
eNFA68_13[["εNFA68-13 scope{1, -1}"]]
eNFA68_21[["εNFA68-21 post-regex start"]]
eNFA69_11[["εNFA69-11 scope[1]"]]
eNFA70_14[["εNFA70-14 regex start"]]
eNFA71_5[["εNFA71-5 scope[1]"]]
eNFA71_13[["εNFA71-13 scope{1, -1}"]]
eNFA1_12[["εNFA1-12 char{1, 1}"]]
eNFA4_13[["εNFA4-13 regex end"]]
eNFA50_13[["εNFA50-13 regex end"]]
eNFA51_12[["εNFA51-12 char{1, 1}"]]
eNFA52_13[\"εNFA52-13 post-regex end"/]
class eNFA52_13 c0001;
eNFA53_13[\"εNFA53-13 post-regex end"/]
class eNFA53_13 c0001;
eNFA54_13[["εNFA54-13 regex end"]]
eNFA55_13[["εNFA55-13 regex end"]]
eNFA56_12[["εNFA56-12 char{1, 1}"]]
eNFA57_12[["εNFA57-12 char{1, 1}"]]
eNFA58_12[["εNFA58-12 char{1, 1}"]]
eNFA59_13[\"εNFA59-13 post-regex end"/]
class eNFA59_13 c0001;
eNFA60_12[["εNFA60-12 char{1, 1}"]]
eNFA63_5[["εNFA63-5 scope[1]"]]
eNFA68_6[["εNFA68-6 scope{0, -1}"]]
eNFA68_14[["εNFA68-14 scope[1]"]]
eNFA68_22[\"εNFA68-22 post-regex end"/]
class eNFA68_22 c0001;
eNFA69_13[\"εNFA69-13 regex end"/]
class eNFA69_13 c0001;
eNFA70_12[["εNFA70-12 scope{1, 1}"]]
eNFA71_6[["εNFA71-6 scope{0, -1}"]]
eNFA71_14[["εNFA71-14 scope[1]"]]
eNFA1_13[["εNFA1-13 char[1]"]]
eNFA4_14[["εNFA4-14 post-regex start"]]
eNFA50_14[["εNFA50-14 post-regex start"]]
eNFA51_13[["εNFA51-13 char[1]"]]
eNFA54_14[["εNFA54-14 post-regex start"]]
eNFA55_14[["εNFA55-14 post-regex start"]]
eNFA56_13[["εNFA56-13 char[1]"]]
eNFA57_13[["εNFA57-13 char[1]"]]
eNFA58_13[["εNFA58-13 char[1]"]]
eNFA60_13[["εNFA60-13 char[1]"]]
eNFA68_16[["εNFA68-16 regex end"]]
eNFA70_13[["εNFA70-13 scope[1]"]]
eNFA71_16[["εNFA71-16 regex end"]]
eNFA1_15[["εNFA1-15 regex end"]]
eNFA4_15[\"εNFA4-15 post-regex end"/]
class eNFA4_15 c0001;
eNFA50_15[\"εNFA50-15 post-regex end"/]
class eNFA50_15 c0001;
eNFA51_15[["εNFA51-15 regex end"]]
eNFA54_15[\"εNFA54-15 post-regex end"/]
class eNFA54_15 c0001;
eNFA55_15[\"εNFA55-15 post-regex end"/]
class eNFA55_15 c0001;
eNFA56_15[["εNFA56-15 regex end"]]
eNFA57_14[["εNFA57-14 char{1, 1}"]]
eNFA58_14[["εNFA58-14 char{1, 1}"]]
eNFA60_15[["εNFA60-15 regex end"]]
eNFA68_15[["εNFA68-15 regex start"]]
eNFA70_15[\"εNFA70-15 regex end"/]
class eNFA70_15 c0001;
eNFA71_15[["εNFA71-15 regex start"]]
eNFA1_16[["εNFA1-16 post-regex start"]]
eNFA51_16[["εNFA51-16 post-regex start"]]
eNFA56_16[["εNFA56-16 post-regex start"]]
eNFA57_15[["εNFA57-15 char[1]"]]
eNFA58_15[["εNFA58-15 char[1]"]]
eNFA60_16[["εNFA60-16 post-regex start"]]
eNFA68_9[["εNFA68-9 scope{1, 1}"]]
eNFA71_9[["εNFA71-9 scope{1, 1}"]]
eNFA1_17[\"εNFA1-17 post-regex end"/]
class eNFA1_17 c0001;
eNFA51_17[\"εNFA51-17 post-regex end"/]
class eNFA51_17 c0001;
eNFA56_17[\"εNFA56-17 post-regex end"/]
class eNFA56_17 c0001;
eNFA57_16[["εNFA57-16 char{1, 1}"]]
eNFA58_17[["εNFA58-17 regex end"]]
eNFA60_17[\"εNFA60-17 post-regex end"/]
class eNFA60_17 c0001;
eNFA68_10[["εNFA68-10 scope[1]"]]
eNFA71_10[["εNFA71-10 scope[1]"]]
eNFA57_17[["εNFA57-17 char[1]"]]
eNFA58_18[["εNFA58-18 post-regex start"]]
eNFA68_11[["εNFA68-11 scope{0, 1}"]]
eNFA71_11[["εNFA71-11 scope{0, 1}"]]
eNFA57_18[["εNFA57-18 char{1, 1}"]]
eNFA58_19[\"εNFA58-19 post-regex end"/]
class eNFA58_19 c0001;
eNFA68_12[["εNFA68-12 scope[1]"]]
eNFA71_12[["εNFA71-12 scope[1]"]]
eNFA57_19[["εNFA57-19 char[1]"]]
eNFA68_13[["εNFA68-13 scope{1, -1}"]]
eNFA71_13[["εNFA71-13 scope{1, -1}"]]
eNFA57_21[["εNFA57-21 regex end"]]
eNFA68_14[["εNFA68-14 scope[1]"]]
eNFA71_14[["εNFA71-14 scope[1]"]]
eNFA57_22[["εNFA57-22 post-regex start"]]
eNFA57_23[\"εNFA57-23 post-regex end"/]
class eNFA57_23 c0001;
eNFA0_0 -.->|"ε"|eNFA1_14
eNFA0_0 -.->|"ε"|eNFA2_2
eNFA0_0 -.->|"ε"|eNFA3_2
eNFA0_0 -.->|"ε"|eNFA4_12
eNFA0_0 -.->|"ε"|eNFA5_2
eNFA0_0 -.->|"ε"|eNFA6_2
eNFA0_0 -.->|"ε"|eNFA7_2
eNFA0_0 -.->|"ε"|eNFA8_2
eNFA0_0 -.->|"ε"|eNFA9_2
eNFA0_0 -.->|"ε"|eNFA10_4
eNFA0_0 -.->|"ε"|eNFA11_4
eNFA0_0 -.->|"ε"|eNFA12_2
eNFA0_0 -.->|"ε"|eNFA13_2
eNFA0_0 -.->|"ε"|eNFA14_2
eNFA0_0 -.->|"ε"|eNFA15_2
eNFA0_0 -.->|"ε"|eNFA16_2
eNFA0_0 -.->|"ε"|eNFA17_2
eNFA0_0 -.->|"ε"|eNFA18_2
eNFA0_0 -.->|"ε"|eNFA19_4
eNFA0_0 -.->|"ε"|eNFA20_4
eNFA0_0 -.->|"ε"|eNFA21_2
eNFA0_0 -.->|"ε"|eNFA22_2
eNFA0_0 -.->|"ε"|eNFA23_4
eNFA0_0 -.->|"ε"|eNFA24_4
eNFA0_0 -.->|"ε"|eNFA25_4
eNFA0_0 -.->|"ε"|eNFA26_4
eNFA0_0 -.->|"ε"|eNFA27_2
eNFA0_0 -.->|"ε"|eNFA28_2
eNFA0_0 -.->|"ε"|eNFA29_2
eNFA0_0 -.->|"ε"|eNFA30_4
eNFA0_0 -.->|"ε"|eNFA31_4
eNFA0_0 -.->|"ε"|eNFA32_4
eNFA0_0 -.->|"ε"|eNFA33_2
eNFA0_0 -.->|"ε"|eNFA34_2
eNFA0_0 -.->|"ε"|eNFA35_2
eNFA0_0 -.->|"ε"|eNFA36_4
eNFA0_0 -.->|"ε"|eNFA37_4
eNFA0_0 -.->|"ε"|eNFA38_4
eNFA0_0 -.->|"ε"|eNFA39_4
eNFA0_0 -.->|"ε"|eNFA40_4
eNFA0_0 -.->|"ε"|eNFA41_6
eNFA0_0 -.->|"ε"|eNFA42_6
eNFA0_0 -.->|"ε"|eNFA43_4
eNFA0_0 -.->|"ε"|eNFA44_4
eNFA0_0 -.->|"ε"|eNFA45_4
eNFA0_0 -.->|"ε"|eNFA46_2
eNFA0_0 -.->|"ε"|eNFA47_2
eNFA0_0 -.->|"ε"|eNFA48_4
eNFA0_0 -.->|"ε"|eNFA49_6
eNFA0_0 -.->|"ε"|eNFA50_12
eNFA0_0 -.->|"ε"|eNFA51_14
eNFA0_0 -.->|"ε"|eNFA52_10
eNFA0_0 -.->|"ε"|eNFA53_10
eNFA0_0 -.->|"ε"|eNFA54_12
eNFA0_0 -.->|"ε"|eNFA55_12
eNFA0_0 -.->|"ε"|eNFA56_14
eNFA0_0 -.->|"ε"|eNFA57_20
eNFA0_0 -.->|"ε"|eNFA58_16
eNFA0_0 -.->|"ε"|eNFA59_10
eNFA0_0 -.->|"ε"|eNFA60_14
eNFA0_0 -.->|"ε"|eNFA61_3
eNFA0_0 -.->|"ε"|eNFA62_14
eNFA0_0 -.->|"ε"|eNFA63_8
eNFA0_0 -.->|"ε"|eNFA64_4
eNFA0_0 -.->|"ε"|eNFA65_6
eNFA0_0 -.->|"ε"|eNFA66_6
eNFA0_0 -.->|"ε"|eNFA67_8
eNFA0_0 -.->|"ε"|eNFA68_19
eNFA0_0 -.->|"ε"|eNFA69_8
eNFA0_0 -.->|"ε"|eNFA70_10
eNFA0_0 -.->|"ε"|eNFA71_17
eNFA0_0 -.->|"ε"|eNFA72_5
eNFA1_14 -.->|"ε
BeginToken '#35;define'"|eNFA1_0
eNFA2_2 -.->|"ε
BeginToken '('"|eNFA2_0
eNFA3_2 -.->|"ε
BeginToken ')'"|eNFA3_0
eNFA4_12 -.->|"ε
BeginToken '#35;undef'"|eNFA4_0
eNFA5_2 -.->|"ε
BeginToken ','"|eNFA5_0
eNFA6_2 -.->|"ε
BeginToken ';'"|eNFA6_0
eNFA7_2 -.->|"ε
BeginToken '['"|eNFA7_0
eNFA8_2 -.->|"ε
BeginToken ']'"|eNFA8_0
eNFA9_2 -.->|"ε
BeginToken '.'"|eNFA9_0
eNFA10_4 -.->|"ε
BeginToken '++'"|eNFA10_0
eNFA11_4 -.->|"ε
BeginToken '--'"|eNFA11_0
eNFA12_2 -.->|"ε
BeginToken '+'"|eNFA12_0
eNFA13_2 -.->|"ε
BeginToken '-'"|eNFA13_0
eNFA14_2 -.->|"ε
BeginToken '!'"|eNFA14_0
eNFA15_2 -.->|"ε
BeginToken '~'"|eNFA15_0
eNFA16_2 -.->|"ε
BeginToken '#42;'"|eNFA16_0
eNFA17_2 -.->|"ε
BeginToken '/'"|eNFA17_0
eNFA18_2 -.->|"ε
BeginToken '%'"|eNFA18_0
eNFA19_4 -.->|"ε
BeginToken '<<'"|eNFA19_0
eNFA20_4 -.->|"ε
BeginToken '>>'"|eNFA20_0
eNFA21_2 -.->|"ε
BeginToken '<'"|eNFA21_0
eNFA22_2 -.->|"ε
BeginToken '>'"|eNFA22_0
eNFA23_4 -.->|"ε
BeginToken '<='"|eNFA23_0
eNFA24_4 -.->|"ε
BeginToken '>='"|eNFA24_0
eNFA25_4 -.->|"ε
BeginToken '=='"|eNFA25_0
eNFA26_4 -.->|"ε
BeginToken '!='"|eNFA26_0
eNFA27_2 -.->|"ε
BeginToken '&'"|eNFA27_0
eNFA28_2 -.->|"ε
BeginToken '^'"|eNFA28_0
eNFA29_2 -.->|"ε
BeginToken '|'"|eNFA29_0
eNFA30_4 -.->|"ε
BeginToken '&&'"|eNFA30_0
eNFA31_4 -.->|"ε
BeginToken '^^'"|eNFA31_0
eNFA32_4 -.->|"ε
BeginToken '||'"|eNFA32_0
eNFA33_2 -.->|"ε
BeginToken '?'"|eNFA33_0
eNFA34_2 -.->|"ε
BeginToken ':'"|eNFA34_0
eNFA35_2 -.->|"ε
BeginToken '='"|eNFA35_0
eNFA36_4 -.->|"ε
BeginToken '#42;='"|eNFA36_0
eNFA37_4 -.->|"ε
BeginToken '/='"|eNFA37_0
eNFA38_4 -.->|"ε
BeginToken '%='"|eNFA38_0
eNFA39_4 -.->|"ε
BeginToken '+='"|eNFA39_0
eNFA40_4 -.->|"ε
BeginToken '-='"|eNFA40_0
eNFA41_6 -.->|"ε
BeginToken '<<='"|eNFA41_0
eNFA42_6 -.->|"ε
BeginToken '>>='"|eNFA42_0
eNFA43_4 -.->|"ε
BeginToken '&='"|eNFA43_0
eNFA44_4 -.->|"ε
BeginToken '^='"|eNFA44_0
eNFA45_4 -.->|"ε
BeginToken '|='"|eNFA45_0
eNFA46_2 -.->|"ε
BeginToken '{'"|eNFA46_0
eNFA47_2 -.->|"ε
BeginToken '}'"|eNFA47_0
eNFA48_4 -.->|"ε
BeginToken '#35;#35;'"|eNFA48_0
eNFA49_6 -.->|"ε
BeginToken '#35;if'"|eNFA49_0
eNFA50_12 -.->|"ε
BeginToken '#35;ifdef'"|eNFA50_0
eNFA51_14 -.->|"ε
BeginToken '#35;ifndef'"|eNFA51_0
eNFA52_10 -.->|"ε
BeginToken '#35;else'"|eNFA52_0
eNFA53_10 -.->|"ε
BeginToken '#35;elif'"|eNFA53_0
eNFA54_12 -.->|"ε
BeginToken '#35;endif'"|eNFA54_0
eNFA55_12 -.->|"ε
BeginToken '#35;error'"|eNFA55_0
eNFA56_14 -.->|"ε
BeginToken '#35;pragma'"|eNFA56_0
eNFA57_20 -.->|"ε
BeginToken '#35;extension'"|eNFA57_0
eNFA58_16 -.->|"ε
BeginToken '#35;version'"|eNFA58_0
eNFA59_10 -.->|"ε
BeginToken '#35;line'"|eNFA59_0
eNFA60_14 -.->|"ε
BeginToken 'defined'"|eNFA60_0
eNFA61_3 -.->|"ε
BeginToken 'identifier'"|eNFA61_0
eNFA62_14 -.->|"ε
BeginToken 'literalString'"|eNFA62_0
eNFA63_8 -.->|"ε
BeginToken 'number'"|eNFA63_0
eNFA64_4 -.->|"ε
BeginToken 'intConstant'"|eNFA64_0
eNFA65_6 -.->|"ε
BeginToken 'intConstant'"|eNFA65_0
eNFA66_6 -.->|"ε
BeginToken 'uintConstant'"|eNFA66_0
eNFA67_8 -.->|"ε
BeginToken 'uintConstant'"|eNFA67_0
eNFA68_19 -.->|"ε
BeginToken 'floatConstant'"|eNFA68_0
eNFA69_8 -.->|"ε
BeginToken 'boolConstant'"|eNFA69_0
eNFA70_10 -.->|"ε
BeginToken 'boolConstant'"|eNFA70_0
eNFA71_17 -.->|"ε
BeginToken 'doubleConstant'"|eNFA71_0
eNFA72_5 -.->|"ε
BeginToken 'inlineComment'"|eNFA72_0
eNFA1_0 -->|"#35;"|eNFA1_1
eNFA2_0 -->|"#92;("|eNFA2_1
eNFA3_0 -->|"#92;)"|eNFA3_1
eNFA4_0 -->|"#35;"|eNFA4_1
eNFA5_0 -->|","|eNFA5_1
eNFA6_0 -->|";"|eNFA6_1
eNFA7_0 -->|"#92;["|eNFA7_1
eNFA8_0 -->|"]"|eNFA8_1
eNFA9_0 -->|"#92;."|eNFA9_1
eNFA10_0 -->|"#92;+"|eNFA10_1
eNFA11_0 -->|"-"|eNFA11_1
eNFA12_0 -->|"#92;+"|eNFA12_1
eNFA13_0 -->|"-"|eNFA13_1
eNFA14_0 -->|"!"|eNFA14_1
eNFA15_0 -->|"~"|eNFA15_1
eNFA16_0 -->|"#92;#42;"|eNFA16_1
eNFA17_0 -->|"#92;/"|eNFA17_1
eNFA18_0 -->|"%"|eNFA18_1
eNFA19_0 -->|"#92;<"|eNFA19_1
eNFA20_0 -->|">"|eNFA20_1
eNFA21_0 -->|"#92;<"|eNFA21_1
eNFA22_0 -->|">"|eNFA22_1
eNFA23_0 -->|"#92;<"|eNFA23_1
eNFA24_0 -->|">"|eNFA24_1
eNFA25_0 -->|"="|eNFA25_1
eNFA26_0 -->|"!"|eNFA26_1
eNFA27_0 -->|"&"|eNFA27_1
eNFA28_0 -->|"^"|eNFA28_1
eNFA29_0 -->|"#92;|"|eNFA29_1
eNFA30_0 -->|"&"|eNFA30_1
eNFA31_0 -->|"^"|eNFA31_1
eNFA32_0 -->|"#92;|"|eNFA32_1
eNFA33_0 -->|"#92;?"|eNFA33_1
eNFA34_0 -->|":"|eNFA34_1
eNFA35_0 -->|"="|eNFA35_1
eNFA36_0 -->|"#92;#42;"|eNFA36_1
eNFA37_0 -->|"#92;/"|eNFA37_1
eNFA38_0 -->|"%"|eNFA38_1
eNFA39_0 -->|"#92;+"|eNFA39_1
eNFA40_0 -->|"-"|eNFA40_1
eNFA41_0 -->|"#92;<"|eNFA41_1
eNFA42_0 -->|">"|eNFA42_1
eNFA43_0 -->|"&"|eNFA43_1
eNFA44_0 -->|"^"|eNFA44_1
eNFA45_0 -->|"#92;|"|eNFA45_1
eNFA46_0 -->|"#92;{"|eNFA46_1
eNFA47_0 -->|"}"|eNFA47_1
eNFA48_0 -->|"#35;"|eNFA48_1
eNFA49_0 -->|"#35;"|eNFA49_1
eNFA50_0 -->|"#35;"|eNFA50_1
eNFA51_0 -->|"#35;"|eNFA51_1
eNFA52_0 -->|"#35;"|eNFA52_1
eNFA53_0 -->|"#35;"|eNFA53_1
eNFA54_0 -->|"#35;"|eNFA54_1
eNFA55_0 -->|"#35;"|eNFA55_1
eNFA56_0 -->|"#35;"|eNFA56_1
eNFA57_0 -->|"#35;"|eNFA57_1
eNFA58_0 -->|"#35;"|eNFA58_1
eNFA59_0 -->|"#35;"|eNFA59_1
eNFA60_0 -->|"d"|eNFA60_1
eNFA61_0 -->|"[a-zA-Z_]"|eNFA61_1
eNFA62_0 -->|"[a-zA-Z_]"|eNFA62_1
eNFA62_0 -.->|"ε"|eNFA62_1
eNFA63_0 -->|"[0-9]"|eNFA63_1
eNFA64_0 -->|"[-+]"|eNFA64_1
eNFA64_0 -.->|"ε"|eNFA64_1
eNFA65_0 -->|"0"|eNFA65_1
eNFA66_0 -->|"[-+]"|eNFA66_1
eNFA66_0 -.->|"ε"|eNFA66_1
eNFA67_0 -->|"0"|eNFA67_1
eNFA68_0 -->|"[-+]"|eNFA68_1
eNFA68_0 -.->|"ε"|eNFA68_1
eNFA69_0 -->|"t"|eNFA69_1
eNFA70_0 -->|"f"|eNFA70_1
eNFA71_0 -->|"[-+]"|eNFA71_1
eNFA71_0 -.->|"ε"|eNFA71_1
eNFA72_0 -->|"#92;/"|eNFA72_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA2_1 -.->|"ε
ExtendToken '('"|eNFA2_3
eNFA3_1 -.->|"ε
ExtendToken ')'"|eNFA3_3
eNFA4_1 -.->|"ε"|eNFA4_2
eNFA5_1 -.->|"ε
ExtendToken ','"|eNFA5_3
eNFA6_1 -.->|"ε
ExtendToken ';'"|eNFA6_3
eNFA7_1 -.->|"ε
ExtendToken '['"|eNFA7_3
eNFA8_1 -.->|"ε
ExtendToken ']'"|eNFA8_3
eNFA9_1 -.->|"ε
ExtendToken '.'"|eNFA9_3
eNFA10_1 -.->|"ε"|eNFA10_2
eNFA11_1 -.->|"ε"|eNFA11_2
eNFA12_1 -.->|"ε
ExtendToken '+'"|eNFA12_3
eNFA13_1 -.->|"ε
ExtendToken '-'"|eNFA13_3
eNFA14_1 -.->|"ε
ExtendToken '!'"|eNFA14_3
eNFA15_1 -.->|"ε
ExtendToken '~'"|eNFA15_3
eNFA16_1 -.->|"ε
ExtendToken '#42;'"|eNFA16_3
eNFA17_1 -.->|"ε
ExtendToken '/'"|eNFA17_3
eNFA18_1 -.->|"ε
ExtendToken '%'"|eNFA18_3
eNFA19_1 -.->|"ε"|eNFA19_2
eNFA20_1 -.->|"ε"|eNFA20_2
eNFA21_1 -.->|"ε
ExtendToken '<'"|eNFA21_3
eNFA22_1 -.->|"ε
ExtendToken '>'"|eNFA22_3
eNFA23_1 -.->|"ε"|eNFA23_2
eNFA24_1 -.->|"ε"|eNFA24_2
eNFA25_1 -.->|"ε"|eNFA25_2
eNFA26_1 -.->|"ε"|eNFA26_2
eNFA27_1 -.->|"ε
ExtendToken '&'"|eNFA27_3
eNFA28_1 -.->|"ε
ExtendToken '^'"|eNFA28_3
eNFA29_1 -.->|"ε
ExtendToken '|'"|eNFA29_3
eNFA30_1 -.->|"ε"|eNFA30_2
eNFA31_1 -.->|"ε"|eNFA31_2
eNFA32_1 -.->|"ε"|eNFA32_2
eNFA33_1 -.->|"ε
ExtendToken '?'"|eNFA33_3
eNFA34_1 -.->|"ε
ExtendToken ':'"|eNFA34_3
eNFA35_1 -.->|"ε
ExtendToken '='"|eNFA35_3
eNFA36_1 -.->|"ε"|eNFA36_2
eNFA37_1 -.->|"ε"|eNFA37_2
eNFA38_1 -.->|"ε"|eNFA38_2
eNFA39_1 -.->|"ε"|eNFA39_2
eNFA40_1 -.->|"ε"|eNFA40_2
eNFA41_1 -.->|"ε"|eNFA41_2
eNFA42_1 -.->|"ε"|eNFA42_2
eNFA43_1 -.->|"ε"|eNFA43_2
eNFA44_1 -.->|"ε"|eNFA44_2
eNFA45_1 -.->|"ε"|eNFA45_2
eNFA46_1 -.->|"ε
ExtendToken '{'"|eNFA46_3
eNFA47_1 -.->|"ε
ExtendToken '}'"|eNFA47_3
eNFA48_1 -.->|"ε"|eNFA48_2
eNFA49_1 -.->|"ε"|eNFA49_2
eNFA50_1 -.->|"ε"|eNFA50_2
eNFA51_1 -.->|"ε"|eNFA51_2
eNFA52_1 -.->|"ε"|eNFA52_2
eNFA53_1 -.->|"ε"|eNFA53_2
eNFA54_1 -.->|"ε"|eNFA54_2
eNFA55_1 -.->|"ε"|eNFA55_2
eNFA56_1 -.->|"ε"|eNFA56_2
eNFA57_1 -.->|"ε"|eNFA57_2
eNFA58_1 -.->|"ε"|eNFA58_2
eNFA59_1 -.->|"ε"|eNFA59_2
eNFA60_1 -.->|"ε"|eNFA60_2
eNFA61_1 -.->|"ε"|eNFA61_2
eNFA62_1 -.->|"ε"|eNFA62_2
eNFA63_1 -->|"[0-9]"|eNFA63_1
eNFA63_1 -.->|"ε"|eNFA63_6
eNFA64_1 -.->|"ε"|eNFA64_2
eNFA65_1 -.->|"ε"|eNFA65_2
eNFA66_1 -.->|"ε"|eNFA66_2
eNFA67_1 -.->|"ε"|eNFA67_2
eNFA68_1 -.->|"ε"|eNFA68_2
eNFA69_1 -.->|"ε"|eNFA69_2
eNFA70_1 -.->|"ε"|eNFA70_2
eNFA71_1 -.->|"ε"|eNFA71_2
eNFA72_1 -.->|"ε"|eNFA72_2
eNFA1_2 -->|"d"|eNFA1_3
eNFA2_3 -.->|"ε"|eNFA2_4
eNFA3_3 -.->|"ε"|eNFA3_4
eNFA4_2 -->|"u"|eNFA4_3
eNFA5_3 -.->|"ε"|eNFA5_4
eNFA6_3 -.->|"ε"|eNFA6_4
eNFA7_3 -.->|"ε"|eNFA7_4
eNFA8_3 -.->|"ε"|eNFA8_4
eNFA9_3 -.->|"ε"|eNFA9_4
eNFA10_2 -->|"#92;+"|eNFA10_3
eNFA11_2 -->|"-"|eNFA11_3
eNFA12_3 -.->|"ε"|eNFA12_4
eNFA13_3 -.->|"ε"|eNFA13_4
eNFA14_3 -.->|"ε"|eNFA14_4
eNFA15_3 -.->|"ε"|eNFA15_4
eNFA16_3 -.->|"ε"|eNFA16_4
eNFA17_3 -.->|"ε"|eNFA17_4
eNFA18_3 -.->|"ε"|eNFA18_4
eNFA19_2 -->|"#92;<"|eNFA19_3
eNFA20_2 -->|">"|eNFA20_3
eNFA21_3 -.->|"ε"|eNFA21_4
eNFA22_3 -.->|"ε"|eNFA22_4
eNFA23_2 -->|"="|eNFA23_3
eNFA24_2 -->|"="|eNFA24_3
eNFA25_2 -->|"="|eNFA25_3
eNFA26_2 -->|"="|eNFA26_3
eNFA27_3 -.->|"ε"|eNFA27_4
eNFA28_3 -.->|"ε"|eNFA28_4
eNFA29_3 -.->|"ε"|eNFA29_4
eNFA30_2 -->|"&"|eNFA30_3
eNFA31_2 -->|"^"|eNFA31_3
eNFA32_2 -->|"#92;|"|eNFA32_3
eNFA33_3 -.->|"ε"|eNFA33_4
eNFA34_3 -.->|"ε"|eNFA34_4
eNFA35_3 -.->|"ε"|eNFA35_4
eNFA36_2 -->|"="|eNFA36_3
eNFA37_2 -->|"="|eNFA37_3
eNFA38_2 -->|"="|eNFA38_3
eNFA39_2 -->|"="|eNFA39_3
eNFA40_2 -->|"="|eNFA40_3
eNFA41_2 -->|"#92;<"|eNFA41_3
eNFA42_2 -->|">"|eNFA42_3
eNFA43_2 -->|"="|eNFA43_3
eNFA44_2 -->|"="|eNFA44_3
eNFA45_2 -->|"="|eNFA45_3
eNFA46_3 -.->|"ε"|eNFA46_4
eNFA47_3 -.->|"ε"|eNFA47_4
eNFA48_2 -->|"#35;"|eNFA48_3
eNFA49_2 -->|"i"|eNFA49_3
eNFA50_2 -->|"i"|eNFA50_3
eNFA51_2 -->|"i"|eNFA51_3
eNFA52_2 -->|"e"|eNFA52_3
eNFA53_2 -->|"e"|eNFA53_3
eNFA54_2 -->|"e"|eNFA54_3
eNFA55_2 -->|"e"|eNFA55_3
eNFA56_2 -->|"p"|eNFA56_3
eNFA57_2 -->|"e"|eNFA57_3
eNFA58_2 -->|"v"|eNFA58_3
eNFA59_2 -->|"l"|eNFA59_3
eNFA60_2 -->|"e"|eNFA60_3
eNFA61_2 -->|"[a-zA-Z0-9_]"|eNFA61_2
eNFA61_2 -.->|"ε
ExtendToken 'identifier'"|eNFA61_4
eNFA62_2 -->|"#34;"|eNFA62_3
eNFA63_6 -.->|"ε"|eNFA63_2
eNFA63_6 -.->|"ε"|eNFA63_7
eNFA64_2 -->|"[0-9]"|eNFA64_3
eNFA65_2 -->|"x"|eNFA65_3
eNFA66_2 -->|"[0-9]"|eNFA66_3
eNFA67_2 -->|"x"|eNFA67_3
eNFA68_2 -->|"[0-9]"|eNFA68_3
eNFA69_2 -->|"r"|eNFA69_3
eNFA70_2 -->|"a"|eNFA70_3
eNFA71_2 -->|"[0-9]"|eNFA71_3
eNFA72_2 -->|"#92;/"|eNFA72_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA2_4 -.->|"ε
AcceptToken '('"|eNFA2_5
eNFA3_4 -.->|"ε
AcceptToken ')'"|eNFA3_5
eNFA4_3 -.->|"ε"|eNFA4_4
eNFA5_4 -.->|"ε
AcceptToken ','"|eNFA5_5
eNFA6_4 -.->|"ε
AcceptToken ';'"|eNFA6_5
eNFA7_4 -.->|"ε
AcceptToken '['"|eNFA7_5
eNFA8_4 -.->|"ε
AcceptToken ']'"|eNFA8_5
eNFA9_4 -.->|"ε
AcceptToken '.'"|eNFA9_5
eNFA10_3 -.->|"ε
ExtendToken '++'"|eNFA10_5
eNFA11_3 -.->|"ε
ExtendToken '--'"|eNFA11_5
eNFA12_4 -.->|"ε
AcceptToken '+'"|eNFA12_5
eNFA13_4 -.->|"ε
AcceptToken '-'"|eNFA13_5
eNFA14_4 -.->|"ε
AcceptToken '!'"|eNFA14_5
eNFA15_4 -.->|"ε
AcceptToken '~'"|eNFA15_5
eNFA16_4 -.->|"ε
AcceptToken '#42;'"|eNFA16_5
eNFA17_4 -.->|"ε
AcceptToken '/'"|eNFA17_5
eNFA18_4 -.->|"ε
AcceptToken '%'"|eNFA18_5
eNFA19_3 -.->|"ε
ExtendToken '<<'"|eNFA19_5
eNFA20_3 -.->|"ε
ExtendToken '>>'"|eNFA20_5
eNFA21_4 -.->|"ε
AcceptToken '<'"|eNFA21_5
eNFA22_4 -.->|"ε
AcceptToken '>'"|eNFA22_5
eNFA23_3 -.->|"ε
ExtendToken '<='"|eNFA23_5
eNFA24_3 -.->|"ε
ExtendToken '>='"|eNFA24_5
eNFA25_3 -.->|"ε
ExtendToken '=='"|eNFA25_5
eNFA26_3 -.->|"ε
ExtendToken '!='"|eNFA26_5
eNFA27_4 -.->|"ε
AcceptToken '&'"|eNFA27_5
eNFA28_4 -.->|"ε
AcceptToken '^'"|eNFA28_5
eNFA29_4 -.->|"ε
AcceptToken '|'"|eNFA29_5
eNFA30_3 -.->|"ε
ExtendToken '&&'"|eNFA30_5
eNFA31_3 -.->|"ε
ExtendToken '^^'"|eNFA31_5
eNFA32_3 -.->|"ε
ExtendToken '||'"|eNFA32_5
eNFA33_4 -.->|"ε
AcceptToken '?'"|eNFA33_5
eNFA34_4 -.->|"ε
AcceptToken ':'"|eNFA34_5
eNFA35_4 -.->|"ε
AcceptToken '='"|eNFA35_5
eNFA36_3 -.->|"ε
ExtendToken '#42;='"|eNFA36_5
eNFA37_3 -.->|"ε
ExtendToken '/='"|eNFA37_5
eNFA38_3 -.->|"ε
ExtendToken '%='"|eNFA38_5
eNFA39_3 -.->|"ε
ExtendToken '+='"|eNFA39_5
eNFA40_3 -.->|"ε
ExtendToken '-='"|eNFA40_5
eNFA41_3 -.->|"ε"|eNFA41_4
eNFA42_3 -.->|"ε"|eNFA42_4
eNFA43_3 -.->|"ε
ExtendToken '&='"|eNFA43_5
eNFA44_3 -.->|"ε
ExtendToken '^='"|eNFA44_5
eNFA45_3 -.->|"ε
ExtendToken '|='"|eNFA45_5
eNFA46_4 -.->|"ε
AcceptToken '{'"|eNFA46_5
eNFA47_4 -.->|"ε
AcceptToken '}'"|eNFA47_5
eNFA48_3 -.->|"ε
ExtendToken '#35;#35;'"|eNFA48_5
eNFA49_3 -.->|"ε"|eNFA49_4
eNFA50_3 -.->|"ε"|eNFA50_4
eNFA51_3 -.->|"ε"|eNFA51_4
eNFA52_3 -.->|"ε"|eNFA52_4
eNFA53_3 -.->|"ε"|eNFA53_4
eNFA54_3 -.->|"ε"|eNFA54_4
eNFA55_3 -.->|"ε"|eNFA55_4
eNFA56_3 -.->|"ε"|eNFA56_4
eNFA57_3 -.->|"ε"|eNFA57_4
eNFA58_3 -.->|"ε"|eNFA58_4
eNFA59_3 -.->|"ε"|eNFA59_4
eNFA60_3 -.->|"ε"|eNFA60_4
eNFA61_4 -.->|"ε"|eNFA61_5
eNFA62_3 -.->|"ε"|eNFA62_8
eNFA63_2 -->|"[.]"|eNFA63_3
eNFA63_7 -.->|"ε
ExtendToken 'number'"|eNFA63_9
eNFA64_3 -->|"[0-9]"|eNFA64_3
eNFA64_3 -.->|"ε
ExtendToken 'intConstant'"|eNFA64_5
eNFA65_3 -.->|"ε"|eNFA65_4
eNFA66_3 -->|"[0-9]"|eNFA66_3
eNFA66_3 -.->|"ε"|eNFA66_4
eNFA67_3 -.->|"ε"|eNFA67_4
eNFA68_3 -->|"[0-9]"|eNFA68_3
eNFA68_3 -.->|"ε"|eNFA68_7
eNFA69_3 -.->|"ε"|eNFA69_4
eNFA70_3 -.->|"ε"|eNFA70_4
eNFA71_3 -->|"[0-9]"|eNFA71_3
eNFA71_3 -.->|"ε"|eNFA71_7
eNFA72_3 -.->|"ε"|eNFA72_4
eNFA1_4 -->|"e"|eNFA1_5
eNFA2_5 -.->|"ε"|eNFA0_1
eNFA3_5 -.->|"ε"|eNFA0_1
eNFA4_4 -->|"n"|eNFA4_5
eNFA5_5 -.->|"ε"|eNFA0_1
eNFA6_5 -.->|"ε"|eNFA0_1
eNFA7_5 -.->|"ε"|eNFA0_1
eNFA8_5 -.->|"ε"|eNFA0_1
eNFA9_5 -.->|"ε"|eNFA0_1
eNFA10_5 -.->|"ε"|eNFA10_6
eNFA11_5 -.->|"ε"|eNFA11_6
eNFA12_5 -.->|"ε"|eNFA0_1
eNFA13_5 -.->|"ε"|eNFA0_1
eNFA14_5 -.->|"ε"|eNFA0_1
eNFA15_5 -.->|"ε"|eNFA0_1
eNFA16_5 -.->|"ε"|eNFA0_1
eNFA17_5 -.->|"ε"|eNFA0_1
eNFA18_5 -.->|"ε"|eNFA0_1
eNFA19_5 -.->|"ε"|eNFA19_6
eNFA20_5 -.->|"ε"|eNFA20_6
eNFA21_5 -.->|"ε"|eNFA0_1
eNFA22_5 -.->|"ε"|eNFA0_1
eNFA23_5 -.->|"ε"|eNFA23_6
eNFA24_5 -.->|"ε"|eNFA24_6
eNFA25_5 -.->|"ε"|eNFA25_6
eNFA26_5 -.->|"ε"|eNFA26_6
eNFA27_5 -.->|"ε"|eNFA0_1
eNFA28_5 -.->|"ε"|eNFA0_1
eNFA29_5 -.->|"ε"|eNFA0_1
eNFA30_5 -.->|"ε"|eNFA30_6
eNFA31_5 -.->|"ε"|eNFA31_6
eNFA32_5 -.->|"ε"|eNFA32_6
eNFA33_5 -.->|"ε"|eNFA0_1
eNFA34_5 -.->|"ε"|eNFA0_1
eNFA35_5 -.->|"ε"|eNFA0_1
eNFA36_5 -.->|"ε"|eNFA36_6
eNFA37_5 -.->|"ε"|eNFA37_6
eNFA38_5 -.->|"ε"|eNFA38_6
eNFA39_5 -.->|"ε"|eNFA39_6
eNFA40_5 -.->|"ε"|eNFA40_6
eNFA41_4 -->|"="|eNFA41_5
eNFA42_4 -->|"="|eNFA42_5
eNFA43_5 -.->|"ε"|eNFA43_6
eNFA44_5 -.->|"ε"|eNFA44_6
eNFA45_5 -.->|"ε"|eNFA45_6
eNFA46_5 -.->|"ε"|eNFA0_1
eNFA47_5 -.->|"ε"|eNFA0_1
eNFA48_5 -.->|"ε"|eNFA48_6
eNFA49_4 -->|"f"|eNFA49_5
eNFA50_4 -->|"f"|eNFA50_5
eNFA51_4 -->|"f"|eNFA51_5
eNFA52_4 -->|"l"|eNFA52_5
eNFA53_4 -->|"l"|eNFA53_5
eNFA54_4 -->|"n"|eNFA54_5
eNFA55_4 -->|"r"|eNFA55_5
eNFA56_4 -->|"r"|eNFA56_5
eNFA57_4 -->|"x"|eNFA57_5
eNFA58_4 -->|"e"|eNFA58_5
eNFA59_4 -->|"i"|eNFA59_5
eNFA60_4 -->|"f"|eNFA60_5
eNFA61_5 -.->|"ε
AcceptToken 'identifier'"|eNFA61_6
eNFA62_8 -.->|"ε"|eNFA62_4
eNFA62_8 -.->|"ε"|eNFA62_10
eNFA62_8 -.->|"ε"|eNFA62_9
eNFA63_3 -.->|"ε"|eNFA63_4
eNFA63_9 -.->|"ε"|eNFA63_10
eNFA64_5 -.->|"ε"|eNFA64_6
eNFA65_4 -->|"[0-9A-Fa-f]"|eNFA65_5
eNFA66_4 -->|"[uU]"|eNFA66_5
eNFA67_4 -->|"[0-9A-Fa-f]"|eNFA67_5
eNFA68_7 -.->|"ε"|eNFA68_4
eNFA68_7 -.->|"ε"|eNFA68_8
eNFA69_4 -->|"u"|eNFA69_5
eNFA70_4 -->|"l"|eNFA70_5
eNFA71_7 -.->|"ε"|eNFA71_4
eNFA71_7 -.->|"ε"|eNFA71_8
eNFA72_4 -->|"[^#92;n#92;r#92;u0000]"|eNFA72_4
eNFA72_4 -.->|"ε
ExtendToken 'inlineComment'"|eNFA72_6
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA4_5 -.->|"ε"|eNFA4_6
eNFA10_6 -.->|"ε
AcceptToken '++'"|eNFA10_7
eNFA11_6 -.->|"ε
AcceptToken '--'"|eNFA11_7
eNFA19_6 -.->|"ε
AcceptToken '<<'"|eNFA19_7
eNFA20_6 -.->|"ε
AcceptToken '>>'"|eNFA20_7
eNFA23_6 -.->|"ε
AcceptToken '<='"|eNFA23_7
eNFA24_6 -.->|"ε
AcceptToken '>='"|eNFA24_7
eNFA25_6 -.->|"ε
AcceptToken '=='"|eNFA25_7
eNFA26_6 -.->|"ε
AcceptToken '!='"|eNFA26_7
eNFA30_6 -.->|"ε
AcceptToken '&&'"|eNFA30_7
eNFA31_6 -.->|"ε
AcceptToken '^^'"|eNFA31_7
eNFA32_6 -.->|"ε
AcceptToken '||'"|eNFA32_7
eNFA36_6 -.->|"ε
AcceptToken '#42;='"|eNFA36_7
eNFA37_6 -.->|"ε
AcceptToken '/='"|eNFA37_7
eNFA38_6 -.->|"ε
AcceptToken '%='"|eNFA38_7
eNFA39_6 -.->|"ε
AcceptToken '+='"|eNFA39_7
eNFA40_6 -.->|"ε
AcceptToken '-='"|eNFA40_7
eNFA41_5 -.->|"ε
ExtendToken '<<='"|eNFA41_7
eNFA42_5 -.->|"ε
ExtendToken '>>='"|eNFA42_7
eNFA43_6 -.->|"ε
AcceptToken '&='"|eNFA43_7
eNFA44_6 -.->|"ε
AcceptToken '^='"|eNFA44_7
eNFA45_6 -.->|"ε
AcceptToken '|='"|eNFA45_7
eNFA48_6 -.->|"ε
AcceptToken '#35;#35;'"|eNFA48_7
eNFA49_5 -.->|"ε
ExtendToken '#35;if'"|eNFA49_7
eNFA50_5 -.->|"ε"|eNFA50_6
eNFA51_5 -.->|"ε"|eNFA51_6
eNFA52_5 -.->|"ε"|eNFA52_6
eNFA53_5 -.->|"ε"|eNFA53_6
eNFA54_5 -.->|"ε"|eNFA54_6
eNFA55_5 -.->|"ε"|eNFA55_6
eNFA56_5 -.->|"ε"|eNFA56_6
eNFA57_5 -.->|"ε"|eNFA57_6
eNFA58_5 -.->|"ε"|eNFA58_6
eNFA59_5 -.->|"ε"|eNFA59_6
eNFA60_5 -.->|"ε"|eNFA60_6
eNFA61_6 -.->|"ε"|eNFA0_1
eNFA62_4 -->|"#92;#92;"|eNFA62_5
eNFA62_10 -->|"[^#92;#92;#34;]"|eNFA62_11
eNFA62_9 -.->|"ε"|eNFA62_8
eNFA62_9 -.->|"ε"|eNFA62_12
eNFA63_4 -->|"[0-9]"|eNFA63_5
eNFA63_10 -.->|"ε
AcceptToken 'number'"|eNFA63_11
eNFA64_6 -.->|"ε
AcceptToken 'intConstant'"|eNFA64_7
eNFA65_5 -->|"[0-9A-Fa-f]"|eNFA65_5
eNFA65_5 -.->|"ε
ExtendToken 'intConstant'"|eNFA65_7
eNFA66_5 -.->|"ε
ExtendToken 'uintConstant'"|eNFA66_7
eNFA67_5 -->|"[0-9A-Fa-f]"|eNFA67_5
eNFA67_5 -.->|"ε"|eNFA67_6
eNFA68_4 -->|"[.]"|eNFA68_5
eNFA68_8 -.->|"ε"|eNFA68_15
eNFA69_5 -.->|"ε"|eNFA69_6
eNFA70_5 -.->|"ε"|eNFA70_6
eNFA71_4 -->|"[.]"|eNFA71_5
eNFA71_8 -.->|"ε"|eNFA71_15
eNFA72_6 -.->|"ε"|eNFA72_7
eNFA1_6 -->|"f"|eNFA1_7
eNFA4_6 -->|"d"|eNFA4_7
eNFA10_7 -.->|"ε"|eNFA0_1
eNFA11_7 -.->|"ε"|eNFA0_1
eNFA19_7 -.->|"ε"|eNFA0_1
eNFA20_7 -.->|"ε"|eNFA0_1
eNFA23_7 -.->|"ε"|eNFA0_1
eNFA24_7 -.->|"ε"|eNFA0_1
eNFA25_7 -.->|"ε"|eNFA0_1
eNFA26_7 -.->|"ε"|eNFA0_1
eNFA30_7 -.->|"ε"|eNFA0_1
eNFA31_7 -.->|"ε"|eNFA0_1
eNFA32_7 -.->|"ε"|eNFA0_1
eNFA36_7 -.->|"ε"|eNFA0_1
eNFA37_7 -.->|"ε"|eNFA0_1
eNFA38_7 -.->|"ε"|eNFA0_1
eNFA39_7 -.->|"ε"|eNFA0_1
eNFA40_7 -.->|"ε"|eNFA0_1
eNFA41_7 -.->|"ε"|eNFA41_8
eNFA42_7 -.->|"ε"|eNFA42_8
eNFA43_7 -.->|"ε"|eNFA0_1
eNFA44_7 -.->|"ε"|eNFA0_1
eNFA45_7 -.->|"ε"|eNFA0_1
eNFA48_7 -.->|"ε"|eNFA0_1
eNFA49_7 -.->|"ε"|eNFA49_8
eNFA50_6 -->|"d"|eNFA50_7
eNFA51_6 -->|"n"|eNFA51_7
eNFA52_6 -->|"s"|eNFA52_7
eNFA53_6 -->|"i"|eNFA53_7
eNFA54_6 -->|"d"|eNFA54_7
eNFA55_6 -->|"r"|eNFA55_7
eNFA56_6 -->|"a"|eNFA56_7
eNFA57_6 -->|"t"|eNFA57_7
eNFA58_6 -->|"r"|eNFA58_7
eNFA59_6 -->|"n"|eNFA59_7
eNFA60_6 -->|"i"|eNFA60_7
eNFA62_5 -.->|"ε"|eNFA62_6
eNFA62_11 -.->|"ε"|eNFA62_9
eNFA62_12 -->|"#34;"|eNFA62_13
eNFA63_5 -->|"[0-9]"|eNFA63_5
eNFA63_5 -.->|"ε"|eNFA63_7
eNFA63_11 -.->|"ε"|eNFA0_1
eNFA64_7 -.->|"ε"|eNFA0_1
eNFA65_7 -.->|"ε"|eNFA65_8
eNFA66_7 -.->|"ε"|eNFA66_8
eNFA67_6 -->|"[uU]"|eNFA67_7
eNFA68_5 -.->|"ε"|eNFA68_6
eNFA68_15 -.->|"ε"|eNFA68_9
eNFA68_15 -.->|"ε"|eNFA68_16
eNFA69_6 -->|"e"|eNFA69_7
eNFA70_6 -->|"s"|eNFA70_7
eNFA71_5 -.->|"ε"|eNFA71_6
eNFA71_15 -.->|"ε"|eNFA71_9
eNFA71_15 -.->|"ε"|eNFA71_16
eNFA72_7 -.->|"ε
AcceptToken 'inlineComment'"|eNFA72_8
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA4_7 -.->|"ε"|eNFA4_8
eNFA41_8 -.->|"ε
AcceptToken '<<='"|eNFA41_9
eNFA42_8 -.->|"ε
AcceptToken '>>='"|eNFA42_9
eNFA49_8 -.->|"ε
AcceptToken '#35;if'"|eNFA49_9
eNFA50_7 -.->|"ε"|eNFA50_8
eNFA51_7 -.->|"ε"|eNFA51_8
eNFA52_7 -.->|"ε"|eNFA52_8
eNFA53_7 -.->|"ε"|eNFA53_8
eNFA54_7 -.->|"ε"|eNFA54_8
eNFA55_7 -.->|"ε"|eNFA55_8
eNFA56_7 -.->|"ε"|eNFA56_8
eNFA57_7 -.->|"ε"|eNFA57_8
eNFA58_7 -.->|"ε"|eNFA58_8
eNFA59_7 -.->|"ε"|eNFA59_8
eNFA60_7 -.->|"ε"|eNFA60_8
eNFA62_6 -->|"[#32;-~]"|eNFA62_7
eNFA62_13 -.->|"ε
ExtendToken 'literalString'"|eNFA62_15
eNFA63_7 -.->|"ε"|eNFA63_6
eNFA65_8 -.->|"ε
AcceptToken 'intConstant'"|eNFA65_9
eNFA66_8 -.->|"ε
AcceptToken 'uintConstant'"|eNFA66_9
eNFA67_7 -.->|"ε
ExtendToken 'uintConstant'"|eNFA67_9
eNFA68_6 -->|"[0-9]"|eNFA68_6
eNFA68_6 -.->|"ε"|eNFA68_8
eNFA68_9 -->|"[Ee]"|eNFA68_10
eNFA68_16 -.->|"ε"|eNFA68_17
eNFA69_7 -.->|"ε
ExtendToken 'boolConstant'"|eNFA69_9
eNFA70_7 -.->|"ε"|eNFA70_8
eNFA71_6 -->|"[0-9]"|eNFA71_6
eNFA71_6 -.->|"ε"|eNFA71_8
eNFA71_9 -->|"[Ee]"|eNFA71_10
eNFA71_16 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA72_8 -.->|"ε"|eNFA0_1
eNFA1_8 -->|"i"|eNFA1_9
eNFA4_8 -->|"e"|eNFA4_9
eNFA41_9 -.->|"ε"|eNFA0_1
eNFA42_9 -.->|"ε"|eNFA0_1
eNFA49_9 -.->|"ε"|eNFA0_1
eNFA50_8 -->|"e"|eNFA50_9
eNFA51_8 -->|"d"|eNFA51_9
eNFA52_8 -->|"e"|eNFA52_9
eNFA53_8 -->|"f"|eNFA53_9
eNFA54_8 -->|"i"|eNFA54_9
eNFA55_8 -->|"o"|eNFA55_9
eNFA56_8 -->|"g"|eNFA56_9
eNFA57_8 -->|"e"|eNFA57_9
eNFA58_8 -->|"s"|eNFA58_9
eNFA59_8 -->|"e"|eNFA59_9
eNFA60_8 -->|"n"|eNFA60_9
eNFA62_7 -.->|"ε"|eNFA62_9
eNFA62_15 -.->|"ε"|eNFA62_16
eNFA63_6 -.->|"ε"|eNFA63_2
eNFA63_6 -.->|"ε"|eNFA63_7
eNFA65_9 -.->|"ε"|eNFA0_1
eNFA66_9 -.->|"ε"|eNFA0_1
eNFA67_9 -.->|"ε"|eNFA67_10
eNFA68_8 -.->|"ε"|eNFA68_7
eNFA68_10 -.->|"ε"|eNFA68_11
eNFA68_17 -->|"[fF]"|eNFA68_18
eNFA69_9 -.->|"ε"|eNFA69_12
eNFA70_8 -->|"e"|eNFA70_9
eNFA71_8 -.->|"ε"|eNFA71_7
eNFA71_10 -.->|"ε"|eNFA71_11
eNFA71_18 -.->|"ε"|eNFA71_19
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA4_9 -.->|"ε"|eNFA4_10
eNFA50_9 -.->|"ε"|eNFA50_10
eNFA51_9 -.->|"ε"|eNFA51_10
eNFA52_9 -.->|"ε
ExtendToken '#35;else'"|eNFA52_11
eNFA53_9 -.->|"ε
ExtendToken '#35;elif'"|eNFA53_11
eNFA54_9 -.->|"ε"|eNFA54_10
eNFA55_9 -.->|"ε"|eNFA55_10
eNFA56_9 -.->|"ε"|eNFA56_10
eNFA57_9 -.->|"ε"|eNFA57_10
eNFA58_9 -.->|"ε"|eNFA58_10
eNFA59_9 -.->|"ε
ExtendToken '#35;line'"|eNFA59_11
eNFA60_9 -.->|"ε"|eNFA60_10
eNFA62_16 -.->|"ε
AcceptToken 'literalString'"|eNFA62_17
eNFA63_2 -->|"[.]"|eNFA63_3
eNFA67_10 -.->|"ε
AcceptToken 'uintConstant'"|eNFA67_11
eNFA68_7 -.->|"ε"|eNFA68_4
eNFA68_7 -.->|"ε"|eNFA68_8
eNFA68_11 -->|"[-+]"|eNFA68_12
eNFA68_11 -.->|"ε"|eNFA68_12
eNFA68_18 -.->|"ε
ExtendToken 'floatConstant'"|eNFA68_20
eNFA69_12 -.->|"ε"|eNFA69_10
eNFA70_9 -.->|"ε
ExtendToken 'boolConstant'"|eNFA70_11
eNFA71_7 -.->|"ε"|eNFA71_4
eNFA71_7 -.->|"ε"|eNFA71_8
eNFA71_11 -->|"[-+]"|eNFA71_12
eNFA71_11 -.->|"ε"|eNFA71_12
eNFA71_19 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA1_10 -->|"n"|eNFA1_11
eNFA4_10 -->|"f"|eNFA4_11
eNFA50_10 -->|"f"|eNFA50_11
eNFA51_10 -->|"e"|eNFA51_11
eNFA52_11 -.->|"ε"|eNFA52_12
eNFA53_11 -.->|"ε"|eNFA53_12
eNFA54_10 -->|"f"|eNFA54_11
eNFA55_10 -->|"r"|eNFA55_11
eNFA56_10 -->|"m"|eNFA56_11
eNFA57_10 -->|"n"|eNFA57_11
eNFA58_10 -->|"i"|eNFA58_11
eNFA59_11 -.->|"ε"|eNFA59_12
eNFA60_10 -->|"e"|eNFA60_11
eNFA62_17 -.->|"ε"|eNFA0_1
eNFA63_3 -.->|"ε"|eNFA63_4
eNFA67_11 -.->|"ε"|eNFA0_1
eNFA68_4 -->|"[.]"|eNFA68_5
eNFA68_12 -.->|"ε"|eNFA68_13
eNFA68_20 -.->|"ε"|eNFA68_21
eNFA69_10 -->|"[^a-zA-Z0-9_]"|eNFA69_11
eNFA70_11 -.->|"ε"|eNFA70_14
eNFA71_4 -->|"[.]"|eNFA71_5
eNFA71_12 -.->|"ε"|eNFA71_13
eNFA71_20 -.->|"ε"|eNFA0_1
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA4_11 -.->|"ε
ExtendToken '#35;undef'"|eNFA4_13
eNFA50_11 -.->|"ε
ExtendToken '#35;ifdef'"|eNFA50_13
eNFA51_11 -.->|"ε"|eNFA51_12
eNFA52_12 -.->|"ε
AcceptToken '#35;else'"|eNFA52_13
eNFA53_12 -.->|"ε
AcceptToken '#35;elif'"|eNFA53_13
eNFA54_11 -.->|"ε
ExtendToken '#35;endif'"|eNFA54_13
eNFA55_11 -.->|"ε
ExtendToken '#35;error'"|eNFA55_13
eNFA56_11 -.->|"ε"|eNFA56_12
eNFA57_11 -.->|"ε"|eNFA57_12
eNFA58_11 -.->|"ε"|eNFA58_12
eNFA59_12 -.->|"ε
AcceptToken '#35;line'"|eNFA59_13
eNFA60_11 -.->|"ε"|eNFA60_12
eNFA63_4 -->|"[0-9]"|eNFA63_5
eNFA68_5 -.->|"ε"|eNFA68_6
eNFA68_13 -->|"[0-9]"|eNFA68_14
eNFA68_21 -.->|"ε
AcceptToken 'floatConstant'"|eNFA68_22
eNFA69_11 -.->|"ε
AcceptToken 'boolConstant'"|eNFA69_13
eNFA70_14 -.->|"ε"|eNFA70_12
eNFA71_5 -.->|"ε"|eNFA71_6
eNFA71_13 -->|"[0-9]"|eNFA71_14
eNFA1_12 -->|"e"|eNFA1_13
eNFA4_13 -.->|"ε"|eNFA4_14
eNFA50_13 -.->|"ε"|eNFA50_14
eNFA51_12 -->|"f"|eNFA51_13
eNFA52_13 -.->|"ε"|eNFA0_1
eNFA53_13 -.->|"ε"|eNFA0_1
eNFA54_13 -.->|"ε"|eNFA54_14
eNFA55_13 -.->|"ε"|eNFA55_14
eNFA56_12 -->|"a"|eNFA56_13
eNFA57_12 -->|"s"|eNFA57_13
eNFA58_12 -->|"o"|eNFA58_13
eNFA59_13 -.->|"ε"|eNFA0_1
eNFA60_12 -->|"d"|eNFA60_13
eNFA63_5 -->|"[0-9]"|eNFA63_5
eNFA63_5 -.->|"ε"|eNFA63_7
eNFA68_6 -->|"[0-9]"|eNFA68_6
eNFA68_6 -.->|"ε"|eNFA68_8
eNFA68_14 -->|"[0-9]"|eNFA68_14
eNFA68_14 -.->|"ε"|eNFA68_16
eNFA68_22 -.->|"ε"|eNFA0_1
eNFA69_13 -.->|"ε"|eNFA0_1
eNFA70_12 -->|"[^a-zA-Z0-9_]"|eNFA70_13
eNFA71_6 -->|"[0-9]"|eNFA71_6
eNFA71_6 -.->|"ε"|eNFA71_8
eNFA71_14 -->|"[0-9]"|eNFA71_14
eNFA71_14 -.->|"ε"|eNFA71_16
eNFA1_13 -.->|"ε
ExtendToken '#35;define'"|eNFA1_15
eNFA4_14 -.->|"ε
AcceptToken '#35;undef'"|eNFA4_15
eNFA50_14 -.->|"ε
AcceptToken '#35;ifdef'"|eNFA50_15
eNFA51_13 -.->|"ε
ExtendToken '#35;ifndef'"|eNFA51_15
eNFA54_14 -.->|"ε
AcceptToken '#35;endif'"|eNFA54_15
eNFA55_14 -.->|"ε
AcceptToken '#35;error'"|eNFA55_15
eNFA56_13 -.->|"ε
ExtendToken '#35;pragma'"|eNFA56_15
eNFA57_13 -.->|"ε"|eNFA57_14
eNFA58_13 -.->|"ε"|eNFA58_14
eNFA60_13 -.->|"ε
ExtendToken 'defined'"|eNFA60_15
eNFA68_16 -.->|"ε"|eNFA68_15
eNFA70_13 -.->|"ε
AcceptToken 'boolConstant'"|eNFA70_15
eNFA71_16 -.->|"ε"|eNFA71_15
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA4_15 -.->|"ε"|eNFA0_1
eNFA50_15 -.->|"ε"|eNFA0_1
eNFA51_15 -.->|"ε"|eNFA51_16
eNFA54_15 -.->|"ε"|eNFA0_1
eNFA55_15 -.->|"ε"|eNFA0_1
eNFA56_15 -.->|"ε"|eNFA56_16
eNFA57_14 -->|"i"|eNFA57_15
eNFA58_14 -->|"n"|eNFA58_15
eNFA60_15 -.->|"ε"|eNFA60_16
eNFA68_15 -.->|"ε"|eNFA68_9
eNFA68_15 -.->|"ε"|eNFA68_16
eNFA70_15 -.->|"ε"|eNFA0_1
eNFA71_15 -.->|"ε"|eNFA71_9
eNFA71_15 -.->|"ε"|eNFA71_16
eNFA1_16 -.->|"ε
AcceptToken '#35;define'"|eNFA1_17
eNFA51_16 -.->|"ε
AcceptToken '#35;ifndef'"|eNFA51_17
eNFA56_16 -.->|"ε
AcceptToken '#35;pragma'"|eNFA56_17
eNFA57_15 -.->|"ε"|eNFA57_16
eNFA58_15 -.->|"ε
ExtendToken '#35;version'"|eNFA58_17
eNFA60_16 -.->|"ε
AcceptToken 'defined'"|eNFA60_17
eNFA68_9 -->|"[Ee]"|eNFA68_10
eNFA71_9 -->|"[Ee]"|eNFA71_10
eNFA1_17 -.->|"ε"|eNFA0_1
eNFA51_17 -.->|"ε"|eNFA0_1
eNFA56_17 -.->|"ε"|eNFA0_1
eNFA57_16 -->|"o"|eNFA57_17
eNFA58_17 -.->|"ε"|eNFA58_18
eNFA60_17 -.->|"ε"|eNFA0_1
eNFA68_10 -.->|"ε"|eNFA68_11
eNFA71_10 -.->|"ε"|eNFA71_11
eNFA57_17 -.->|"ε"|eNFA57_18
eNFA58_18 -.->|"ε
AcceptToken '#35;version'"|eNFA58_19
eNFA68_11 -->|"[-+]"|eNFA68_12
eNFA68_11 -.->|"ε"|eNFA68_12
eNFA71_11 -->|"[-+]"|eNFA71_12
eNFA71_11 -.->|"ε"|eNFA71_12
eNFA57_18 -->|"n"|eNFA57_19
eNFA58_19 -.->|"ε"|eNFA0_1
eNFA68_12 -.->|"ε"|eNFA68_13
eNFA71_12 -.->|"ε"|eNFA71_13
eNFA57_19 -.->|"ε
ExtendToken '#35;extension'"|eNFA57_21
eNFA68_13 -->|"[0-9]"|eNFA68_14
eNFA71_13 -->|"[0-9]"|eNFA71_14
eNFA57_21 -.->|"ε"|eNFA57_22
eNFA68_14 -->|"[0-9]"|eNFA68_14
eNFA68_14 -.->|"ε"|eNFA68_16
eNFA71_14 -->|"[0-9]"|eNFA71_14
eNFA71_14 -.->|"ε"|eNFA71_16
eNFA57_22 -.->|"ε
AcceptToken '#35;extension'"|eNFA57_23
eNFA57_23 -.->|"ε"|eNFA0_1

```

## 2/5: completed ε-NFA

```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
eNFA0_0[["εNFA0-0 wholeStart"]]
class eNFA0_0 c1000;
eNFA1_14[["εNFA1-14 regex start"]]
class eNFA1_14 c1000;
eNFA2_2[["εNFA2-2 regex start"]]
class eNFA2_2 c1000;
eNFA3_2[["εNFA3-2 regex start"]]
class eNFA3_2 c1000;
eNFA4_12[["εNFA4-12 regex start"]]
class eNFA4_12 c1000;
eNFA5_2[["εNFA5-2 regex start"]]
class eNFA5_2 c1000;
eNFA6_2[["εNFA6-2 regex start"]]
class eNFA6_2 c1000;
eNFA7_2[["εNFA7-2 regex start"]]
class eNFA7_2 c1000;
eNFA8_2[["εNFA8-2 regex start"]]
class eNFA8_2 c1000;
eNFA9_2[["εNFA9-2 regex start"]]
class eNFA9_2 c1000;
eNFA10_4[["εNFA10-4 regex start"]]
class eNFA10_4 c1000;
eNFA11_4[["εNFA11-4 regex start"]]
class eNFA11_4 c1000;
eNFA12_2[["εNFA12-2 regex start"]]
class eNFA12_2 c1000;
eNFA13_2[["εNFA13-2 regex start"]]
class eNFA13_2 c1000;
eNFA14_2[["εNFA14-2 regex start"]]
class eNFA14_2 c1000;
eNFA15_2[["εNFA15-2 regex start"]]
class eNFA15_2 c1000;
eNFA16_2[["εNFA16-2 regex start"]]
class eNFA16_2 c1000;
eNFA17_2[["εNFA17-2 regex start"]]
class eNFA17_2 c1000;
eNFA18_2[["εNFA18-2 regex start"]]
class eNFA18_2 c1000;
eNFA19_4[["εNFA19-4 regex start"]]
class eNFA19_4 c1000;
eNFA20_4[["εNFA20-4 regex start"]]
class eNFA20_4 c1000;
eNFA21_2[["εNFA21-2 regex start"]]
class eNFA21_2 c1000;
eNFA22_2[["εNFA22-2 regex start"]]
class eNFA22_2 c1000;
eNFA23_4[["εNFA23-4 regex start"]]
class eNFA23_4 c1000;
eNFA24_4[["εNFA24-4 regex start"]]
class eNFA24_4 c1000;
eNFA25_4[["εNFA25-4 regex start"]]
class eNFA25_4 c1000;
eNFA26_4[["εNFA26-4 regex start"]]
class eNFA26_4 c1000;
eNFA27_2[["εNFA27-2 regex start"]]
class eNFA27_2 c1000;
eNFA28_2[["εNFA28-2 regex start"]]
class eNFA28_2 c1000;
eNFA29_2[["εNFA29-2 regex start"]]
class eNFA29_2 c1000;
eNFA30_4[["εNFA30-4 regex start"]]
class eNFA30_4 c1000;
eNFA31_4[["εNFA31-4 regex start"]]
class eNFA31_4 c1000;
eNFA32_4[["εNFA32-4 regex start"]]
class eNFA32_4 c1000;
eNFA33_2[["εNFA33-2 regex start"]]
class eNFA33_2 c1000;
eNFA34_2[["εNFA34-2 regex start"]]
class eNFA34_2 c1000;
eNFA35_2[["εNFA35-2 regex start"]]
class eNFA35_2 c1000;
eNFA36_4[["εNFA36-4 regex start"]]
class eNFA36_4 c1000;
eNFA37_4[["εNFA37-4 regex start"]]
class eNFA37_4 c1000;
eNFA38_4[["εNFA38-4 regex start"]]
class eNFA38_4 c1000;
eNFA39_4[["εNFA39-4 regex start"]]
class eNFA39_4 c1000;
eNFA40_4[["εNFA40-4 regex start"]]
class eNFA40_4 c1000;
eNFA41_6[["εNFA41-6 regex start"]]
class eNFA41_6 c1000;
eNFA42_6[["εNFA42-6 regex start"]]
class eNFA42_6 c1000;
eNFA43_4[["εNFA43-4 regex start"]]
class eNFA43_4 c1000;
eNFA44_4[["εNFA44-4 regex start"]]
class eNFA44_4 c1000;
eNFA45_4[["εNFA45-4 regex start"]]
class eNFA45_4 c1000;
eNFA46_2[["εNFA46-2 regex start"]]
class eNFA46_2 c1000;
eNFA47_2[["εNFA47-2 regex start"]]
class eNFA47_2 c1000;
eNFA48_4[["εNFA48-4 regex start"]]
class eNFA48_4 c1000;
eNFA49_6[["εNFA49-6 regex start"]]
class eNFA49_6 c1000;
eNFA50_12[["εNFA50-12 regex start"]]
class eNFA50_12 c1000;
eNFA51_14[["εNFA51-14 regex start"]]
class eNFA51_14 c1000;
eNFA52_10[["εNFA52-10 regex start"]]
class eNFA52_10 c1000;
eNFA53_10[["εNFA53-10 regex start"]]
class eNFA53_10 c1000;
eNFA54_12[["εNFA54-12 regex start"]]
class eNFA54_12 c1000;
eNFA55_12[["εNFA55-12 regex start"]]
class eNFA55_12 c1000;
eNFA56_14[["εNFA56-14 regex start"]]
class eNFA56_14 c1000;
eNFA57_20[["εNFA57-20 regex start"]]
class eNFA57_20 c1000;
eNFA58_16[["εNFA58-16 regex start"]]
class eNFA58_16 c1000;
eNFA59_10[["εNFA59-10 regex start"]]
class eNFA59_10 c1000;
eNFA60_14[["εNFA60-14 regex start"]]
class eNFA60_14 c1000;
eNFA61_3[["εNFA61-3 regex start"]]
class eNFA61_3 c1000;
eNFA62_14[["εNFA62-14 regex start"]]
class eNFA62_14 c1000;
eNFA63_8[["εNFA63-8 regex start"]]
class eNFA63_8 c1000;
eNFA64_4[["εNFA64-4 regex start"]]
class eNFA64_4 c1000;
eNFA65_6[["εNFA65-6 regex start"]]
class eNFA65_6 c1000;
eNFA66_6[["εNFA66-6 regex start"]]
class eNFA66_6 c1000;
eNFA67_8[["εNFA67-8 regex start"]]
class eNFA67_8 c1000;
eNFA68_19[["εNFA68-19 regex start"]]
class eNFA68_19 c1000;
eNFA69_8[["εNFA69-8 regex start"]]
class eNFA69_8 c1000;
eNFA70_10[["εNFA70-10 regex start"]]
class eNFA70_10 c1000;
eNFA71_17[["εNFA71-17 regex start"]]
class eNFA71_17 c1000;
eNFA72_5[["εNFA72-5 regex start"]]
class eNFA72_5 c1000;
eNFA1_0[["εNFA1-0 char{1, 1}"]]
class eNFA1_0 c1000;
eNFA2_0[["εNFA2-0 char{1, 1}"]]
class eNFA2_0 c1000;
eNFA3_0[["εNFA3-0 char{1, 1}"]]
class eNFA3_0 c1000;
eNFA4_0[["εNFA4-0 char{1, 1}"]]
class eNFA4_0 c1000;
eNFA5_0[["εNFA5-0 char{1, 1}"]]
class eNFA5_0 c1000;
eNFA6_0[["εNFA6-0 char{1, 1}"]]
class eNFA6_0 c1000;
eNFA7_0[["εNFA7-0 char{1, 1}"]]
class eNFA7_0 c1000;
eNFA8_0[["εNFA8-0 char{1, 1}"]]
class eNFA8_0 c1000;
eNFA9_0[["εNFA9-0 char{1, 1}"]]
class eNFA9_0 c1000;
eNFA10_0[["εNFA10-0 char{1, 1}"]]
class eNFA10_0 c1000;
eNFA11_0[["εNFA11-0 char{1, 1}"]]
class eNFA11_0 c1000;
eNFA12_0[["εNFA12-0 char{1, 1}"]]
class eNFA12_0 c1000;
eNFA13_0[["εNFA13-0 char{1, 1}"]]
class eNFA13_0 c1000;
eNFA14_0[["εNFA14-0 char{1, 1}"]]
class eNFA14_0 c1000;
eNFA15_0[["εNFA15-0 char{1, 1}"]]
class eNFA15_0 c1000;
eNFA16_0[["εNFA16-0 char{1, 1}"]]
class eNFA16_0 c1000;
eNFA17_0[["εNFA17-0 char{1, 1}"]]
class eNFA17_0 c1000;
eNFA18_0[["εNFA18-0 char{1, 1}"]]
class eNFA18_0 c1000;
eNFA19_0[["εNFA19-0 char{1, 1}"]]
class eNFA19_0 c1000;
eNFA20_0[["εNFA20-0 char{1, 1}"]]
class eNFA20_0 c1000;
eNFA21_0[["εNFA21-0 char{1, 1}"]]
class eNFA21_0 c1000;
eNFA22_0[["εNFA22-0 char{1, 1}"]]
class eNFA22_0 c1000;
eNFA23_0[["εNFA23-0 char{1, 1}"]]
class eNFA23_0 c1000;
eNFA24_0[["εNFA24-0 char{1, 1}"]]
class eNFA24_0 c1000;
eNFA25_0[["εNFA25-0 char{1, 1}"]]
class eNFA25_0 c1000;
eNFA26_0[["εNFA26-0 char{1, 1}"]]
class eNFA26_0 c1000;
eNFA27_0[["εNFA27-0 char{1, 1}"]]
class eNFA27_0 c1000;
eNFA28_0[["εNFA28-0 char{1, 1}"]]
class eNFA28_0 c1000;
eNFA29_0[["εNFA29-0 char{1, 1}"]]
class eNFA29_0 c1000;
eNFA30_0[["εNFA30-0 char{1, 1}"]]
class eNFA30_0 c1000;
eNFA31_0[["εNFA31-0 char{1, 1}"]]
class eNFA31_0 c1000;
eNFA32_0[["εNFA32-0 char{1, 1}"]]
class eNFA32_0 c1000;
eNFA33_0[["εNFA33-0 char{1, 1}"]]
class eNFA33_0 c1000;
eNFA34_0[["εNFA34-0 char{1, 1}"]]
class eNFA34_0 c1000;
eNFA35_0[["εNFA35-0 char{1, 1}"]]
class eNFA35_0 c1000;
eNFA36_0[["εNFA36-0 char{1, 1}"]]
class eNFA36_0 c1000;
eNFA37_0[["εNFA37-0 char{1, 1}"]]
class eNFA37_0 c1000;
eNFA38_0[["εNFA38-0 char{1, 1}"]]
class eNFA38_0 c1000;
eNFA39_0[["εNFA39-0 char{1, 1}"]]
class eNFA39_0 c1000;
eNFA40_0[["εNFA40-0 char{1, 1}"]]
class eNFA40_0 c1000;
eNFA41_0[["εNFA41-0 char{1, 1}"]]
class eNFA41_0 c1000;
eNFA42_0[["εNFA42-0 char{1, 1}"]]
class eNFA42_0 c1000;
eNFA43_0[["εNFA43-0 char{1, 1}"]]
class eNFA43_0 c1000;
eNFA44_0[["εNFA44-0 char{1, 1}"]]
class eNFA44_0 c1000;
eNFA45_0[["εNFA45-0 char{1, 1}"]]
class eNFA45_0 c1000;
eNFA46_0[["εNFA46-0 char{1, 1}"]]
class eNFA46_0 c1000;
eNFA47_0[["εNFA47-0 char{1, 1}"]]
class eNFA47_0 c1000;
eNFA48_0[["εNFA48-0 char{1, 1}"]]
class eNFA48_0 c1000;
eNFA49_0[["εNFA49-0 char{1, 1}"]]
class eNFA49_0 c1000;
eNFA50_0[["εNFA50-0 char{1, 1}"]]
class eNFA50_0 c1000;
eNFA51_0[["εNFA51-0 char{1, 1}"]]
class eNFA51_0 c1000;
eNFA52_0[["εNFA52-0 char{1, 1}"]]
class eNFA52_0 c1000;
eNFA53_0[["εNFA53-0 char{1, 1}"]]
class eNFA53_0 c1000;
eNFA54_0[["εNFA54-0 char{1, 1}"]]
class eNFA54_0 c1000;
eNFA55_0[["εNFA55-0 char{1, 1}"]]
class eNFA55_0 c1000;
eNFA56_0[["εNFA56-0 char{1, 1}"]]
class eNFA56_0 c1000;
eNFA57_0[["εNFA57-0 char{1, 1}"]]
class eNFA57_0 c1000;
eNFA58_0[["εNFA58-0 char{1, 1}"]]
class eNFA58_0 c1000;
eNFA59_0[["εNFA59-0 char{1, 1}"]]
class eNFA59_0 c1000;
eNFA60_0[["εNFA60-0 char{1, 1}"]]
class eNFA60_0 c1000;
eNFA61_0[["εNFA61-0 scope{1, 1}"]]
class eNFA61_0 c1000;
eNFA62_0[["εNFA62-0 scope{0, 1}"]]
class eNFA62_0 c1000;
eNFA63_0[["εNFA63-0 scope{1, -1}"]]
class eNFA63_0 c1000;
eNFA64_0[["εNFA64-0 scope{0, 1}"]]
class eNFA64_0 c1000;
eNFA65_0[["εNFA65-0 char{1, 1}"]]
class eNFA65_0 c1000;
eNFA66_0[["εNFA66-0 scope{0, 1}"]]
class eNFA66_0 c1000;
eNFA67_0[["εNFA67-0 char{1, 1}"]]
class eNFA67_0 c1000;
eNFA68_0[["εNFA68-0 scope{0, 1}"]]
class eNFA68_0 c1000;
eNFA69_0[["εNFA69-0 char{1, 1}"]]
class eNFA69_0 c1000;
eNFA70_0[["εNFA70-0 char{1, 1}"]]
class eNFA70_0 c1000;
eNFA71_0[["εNFA71-0 scope{0, 1}"]]
class eNFA71_0 c1000;
eNFA72_0[["εNFA72-0 char{1, 1}"]]
class eNFA72_0 c1000;
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA2_1[\"εNFA2-1 char[1]
AcceptToken '('"/]
class eNFA2_1 c0001;
eNFA3_1[\"εNFA3-1 char[1]
AcceptToken ')'"/]
class eNFA3_1 c0001;
eNFA4_1[["εNFA4-1 char[1]"]]
eNFA5_1[\"εNFA5-1 char[1]
AcceptToken ','"/]
class eNFA5_1 c0001;
eNFA6_1[\"εNFA6-1 char[1]
AcceptToken ';'"/]
class eNFA6_1 c0001;
eNFA7_1[\"εNFA7-1 char[1]
AcceptToken '['"/]
class eNFA7_1 c0001;
eNFA8_1[\"εNFA8-1 char[1]
AcceptToken ']'"/]
class eNFA8_1 c0001;
eNFA9_1[\"εNFA9-1 char[1]
AcceptToken '.'"/]
class eNFA9_1 c0001;
eNFA10_1[["εNFA10-1 char[1]"]]
eNFA11_1[["εNFA11-1 char[1]"]]
eNFA12_1[\"εNFA12-1 char[1]
AcceptToken '+'"/]
class eNFA12_1 c0001;
eNFA13_1[\"εNFA13-1 char[1]
AcceptToken '-'"/]
class eNFA13_1 c0001;
eNFA14_1[\"εNFA14-1 char[1]
AcceptToken '!'"/]
class eNFA14_1 c0001;
eNFA15_1[\"εNFA15-1 char[1]
AcceptToken '~'"/]
class eNFA15_1 c0001;
eNFA16_1[\"εNFA16-1 char[1]
AcceptToken '*'"/]
class eNFA16_1 c0001;
eNFA17_1[\"εNFA17-1 char[1]
AcceptToken '/'"/]
class eNFA17_1 c0001;
eNFA18_1[\"εNFA18-1 char[1]
AcceptToken '%'"/]
class eNFA18_1 c0001;
eNFA19_1[["εNFA19-1 char[1]"]]
eNFA20_1[["εNFA20-1 char[1]"]]
eNFA21_1[\"εNFA21-1 char[1]
AcceptToken '<'"/]
class eNFA21_1 c0001;
eNFA22_1[\"εNFA22-1 char[1]
AcceptToken '>'"/]
class eNFA22_1 c0001;
eNFA23_1[["εNFA23-1 char[1]"]]
eNFA24_1[["εNFA24-1 char[1]"]]
eNFA25_1[["εNFA25-1 char[1]"]]
eNFA26_1[["εNFA26-1 char[1]"]]
eNFA27_1[\"εNFA27-1 char[1]
AcceptToken '&'"/]
class eNFA27_1 c0001;
eNFA28_1[\"εNFA28-1 char[1]
AcceptToken '^'"/]
class eNFA28_1 c0001;
eNFA29_1[\"εNFA29-1 char[1]
AcceptToken '|'"/]
class eNFA29_1 c0001;
eNFA30_1[["εNFA30-1 char[1]"]]
eNFA31_1[["εNFA31-1 char[1]"]]
eNFA32_1[["εNFA32-1 char[1]"]]
eNFA33_1[\"εNFA33-1 char[1]
AcceptToken '?'"/]
class eNFA33_1 c0001;
eNFA34_1[\"εNFA34-1 char[1]
AcceptToken ':'"/]
class eNFA34_1 c0001;
eNFA35_1[\"εNFA35-1 char[1]
AcceptToken '='"/]
class eNFA35_1 c0001;
eNFA36_1[["εNFA36-1 char[1]"]]
eNFA37_1[["εNFA37-1 char[1]"]]
eNFA38_1[["εNFA38-1 char[1]"]]
eNFA39_1[["εNFA39-1 char[1]"]]
eNFA40_1[["εNFA40-1 char[1]"]]
eNFA41_1[["εNFA41-1 char[1]"]]
eNFA42_1[["εNFA42-1 char[1]"]]
eNFA43_1[["εNFA43-1 char[1]"]]
eNFA44_1[["εNFA44-1 char[1]"]]
eNFA45_1[["εNFA45-1 char[1]"]]
eNFA46_1[\"εNFA46-1 char[1]
AcceptToken '{'"/]
class eNFA46_1 c0001;
eNFA47_1[\"εNFA47-1 char[1]
AcceptToken '}'"/]
class eNFA47_1 c0001;
eNFA48_1[["εNFA48-1 char[1]"]]
eNFA49_1[["εNFA49-1 char[1]"]]
eNFA50_1[["εNFA50-1 char[1]"]]
eNFA51_1[["εNFA51-1 char[1]"]]
eNFA52_1[["εNFA52-1 char[1]"]]
eNFA53_1[["εNFA53-1 char[1]"]]
eNFA54_1[["εNFA54-1 char[1]"]]
eNFA55_1[["εNFA55-1 char[1]"]]
eNFA56_1[["εNFA56-1 char[1]"]]
eNFA57_1[["εNFA57-1 char[1]"]]
eNFA58_1[["εNFA58-1 char[1]"]]
eNFA59_1[["εNFA59-1 char[1]"]]
eNFA60_1[["εNFA60-1 char[1]"]]
eNFA61_1[\"εNFA61-1 scope[1]
AcceptToken 'identifier'"/]
class eNFA61_1 c0001;
eNFA62_1[["εNFA62-1 scope[1]"]]
class eNFA62_1 c1000;
eNFA62_2[["εNFA62-2 char{1, 1}"]]
class eNFA62_2 c1000;
eNFA63_1[\"εNFA63-1 scope[1]
AcceptToken 'number'"/]
class eNFA63_1 c0001;
eNFA64_1[["εNFA64-1 scope[1]"]]
class eNFA64_1 c1000;
eNFA64_2[["εNFA64-2 scope{1, -1}"]]
class eNFA64_2 c1000;
eNFA65_1[["εNFA65-1 char[1]"]]
eNFA66_1[["εNFA66-1 scope[1]"]]
class eNFA66_1 c1000;
eNFA66_2[["εNFA66-2 scope{1, -1}"]]
class eNFA66_2 c1000;
eNFA67_1[["εNFA67-1 char[1]"]]
eNFA68_1[["εNFA68-1 scope[1]"]]
class eNFA68_1 c1000;
eNFA68_2[["εNFA68-2 scope{1, -1}"]]
class eNFA68_2 c1000;
eNFA69_1[["εNFA69-1 char[1]"]]
eNFA70_1[["εNFA70-1 char[1]"]]
eNFA71_1[["εNFA71-1 scope[1]"]]
class eNFA71_1 c1000;
eNFA71_2[["εNFA71-2 scope{1, -1}"]]
class eNFA71_2 c1000;
eNFA72_1[["εNFA72-1 char[1]"]]
eNFA62_3[["εNFA62-3 char[1]"]]
eNFA64_3[\"εNFA64-3 scope[1]
AcceptToken 'intConstant'"/]
class eNFA64_3 c0001;
eNFA66_3[["εNFA66-3 scope[1]"]]
eNFA68_3[["εNFA68-3 scope[1]"]]
eNFA71_3[\"εNFA71-3 scope[1]
AcceptToken 'doubleConstant'"/]
class eNFA71_3 c0001;
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA2_3[\"εNFA2-3 regex end
AcceptToken '('"/]
class eNFA2_3 c0001;
eNFA2_4[\"εNFA2-4 post-regex start
AcceptToken '('"/]
class eNFA2_4 c0001;
eNFA2_5[\"εNFA2-5 post-regex end"/]
class eNFA2_5 c0001;
eNFA0_1[\"εNFA0-1 wholeEnd"/]
eNFA3_3[\"εNFA3-3 regex end
AcceptToken ')'"/]
class eNFA3_3 c0001;
eNFA3_4[\"εNFA3-4 post-regex start
AcceptToken ')'"/]
class eNFA3_4 c0001;
eNFA3_5[\"εNFA3-5 post-regex end"/]
class eNFA3_5 c0001;
eNFA4_2[["εNFA4-2 char{1, 1}"]]
eNFA4_3[["εNFA4-3 char[1]"]]
eNFA5_3[\"εNFA5-3 regex end
AcceptToken ','"/]
class eNFA5_3 c0001;
eNFA5_4[\"εNFA5-4 post-regex start
AcceptToken ','"/]
class eNFA5_4 c0001;
eNFA5_5[\"εNFA5-5 post-regex end"/]
class eNFA5_5 c0001;
eNFA6_3[\"εNFA6-3 regex end
AcceptToken ';'"/]
class eNFA6_3 c0001;
eNFA6_4[\"εNFA6-4 post-regex start
AcceptToken ';'"/]
class eNFA6_4 c0001;
eNFA6_5[\"εNFA6-5 post-regex end"/]
class eNFA6_5 c0001;
eNFA7_3[\"εNFA7-3 regex end
AcceptToken '['"/]
class eNFA7_3 c0001;
eNFA7_4[\"εNFA7-4 post-regex start
AcceptToken '['"/]
class eNFA7_4 c0001;
eNFA7_5[\"εNFA7-5 post-regex end"/]
class eNFA7_5 c0001;
eNFA8_3[\"εNFA8-3 regex end
AcceptToken ']'"/]
class eNFA8_3 c0001;
eNFA8_4[\"εNFA8-4 post-regex start
AcceptToken ']'"/]
class eNFA8_4 c0001;
eNFA8_5[\"εNFA8-5 post-regex end"/]
class eNFA8_5 c0001;
eNFA9_3[\"εNFA9-3 regex end
AcceptToken '.'"/]
class eNFA9_3 c0001;
eNFA9_4[\"εNFA9-4 post-regex start
AcceptToken '.'"/]
class eNFA9_4 c0001;
eNFA9_5[\"εNFA9-5 post-regex end"/]
class eNFA9_5 c0001;
eNFA10_2[["εNFA10-2 char{1, 1}"]]
eNFA10_3[\"εNFA10-3 char[1]
AcceptToken '++'"/]
class eNFA10_3 c0001;
eNFA11_2[["εNFA11-2 char{1, 1}"]]
eNFA11_3[\"εNFA11-3 char[1]
AcceptToken '--'"/]
class eNFA11_3 c0001;
eNFA12_3[\"εNFA12-3 regex end
AcceptToken '+'"/]
class eNFA12_3 c0001;
eNFA12_4[\"εNFA12-4 post-regex start
AcceptToken '+'"/]
class eNFA12_4 c0001;
eNFA12_5[\"εNFA12-5 post-regex end"/]
class eNFA12_5 c0001;
eNFA13_3[\"εNFA13-3 regex end
AcceptToken '-'"/]
class eNFA13_3 c0001;
eNFA13_4[\"εNFA13-4 post-regex start
AcceptToken '-'"/]
class eNFA13_4 c0001;
eNFA13_5[\"εNFA13-5 post-regex end"/]
class eNFA13_5 c0001;
eNFA14_3[\"εNFA14-3 regex end
AcceptToken '!'"/]
class eNFA14_3 c0001;
eNFA14_4[\"εNFA14-4 post-regex start
AcceptToken '!'"/]
class eNFA14_4 c0001;
eNFA14_5[\"εNFA14-5 post-regex end"/]
class eNFA14_5 c0001;
eNFA15_3[\"εNFA15-3 regex end
AcceptToken '~'"/]
class eNFA15_3 c0001;
eNFA15_4[\"εNFA15-4 post-regex start
AcceptToken '~'"/]
class eNFA15_4 c0001;
eNFA15_5[\"εNFA15-5 post-regex end"/]
class eNFA15_5 c0001;
eNFA16_3[\"εNFA16-3 regex end
AcceptToken '*'"/]
class eNFA16_3 c0001;
eNFA16_4[\"εNFA16-4 post-regex start
AcceptToken '*'"/]
class eNFA16_4 c0001;
eNFA16_5[\"εNFA16-5 post-regex end"/]
class eNFA16_5 c0001;
eNFA17_3[\"εNFA17-3 regex end
AcceptToken '/'"/]
class eNFA17_3 c0001;
eNFA17_4[\"εNFA17-4 post-regex start
AcceptToken '/'"/]
class eNFA17_4 c0001;
eNFA17_5[\"εNFA17-5 post-regex end"/]
class eNFA17_5 c0001;
eNFA18_3[\"εNFA18-3 regex end
AcceptToken '%'"/]
class eNFA18_3 c0001;
eNFA18_4[\"εNFA18-4 post-regex start
AcceptToken '%'"/]
class eNFA18_4 c0001;
eNFA18_5[\"εNFA18-5 post-regex end"/]
class eNFA18_5 c0001;
eNFA19_2[["εNFA19-2 char{1, 1}"]]
eNFA19_3[\"εNFA19-3 char[1]
AcceptToken '<<'"/]
class eNFA19_3 c0001;
eNFA20_2[["εNFA20-2 char{1, 1}"]]
eNFA20_3[\"εNFA20-3 char[1]
AcceptToken '>>'"/]
class eNFA20_3 c0001;
eNFA21_3[\"εNFA21-3 regex end
AcceptToken '<'"/]
class eNFA21_3 c0001;
eNFA21_4[\"εNFA21-4 post-regex start
AcceptToken '<'"/]
class eNFA21_4 c0001;
eNFA21_5[\"εNFA21-5 post-regex end"/]
class eNFA21_5 c0001;
eNFA22_3[\"εNFA22-3 regex end
AcceptToken '>'"/]
class eNFA22_3 c0001;
eNFA22_4[\"εNFA22-4 post-regex start
AcceptToken '>'"/]
class eNFA22_4 c0001;
eNFA22_5[\"εNFA22-5 post-regex end"/]
class eNFA22_5 c0001;
eNFA23_2[["εNFA23-2 char{1, 1}"]]
eNFA23_3[\"εNFA23-3 char[1]
AcceptToken '<='"/]
class eNFA23_3 c0001;
eNFA24_2[["εNFA24-2 char{1, 1}"]]
eNFA24_3[\"εNFA24-3 char[1]
AcceptToken '>='"/]
class eNFA24_3 c0001;
eNFA25_2[["εNFA25-2 char{1, 1}"]]
eNFA25_3[\"εNFA25-3 char[1]
AcceptToken '=='"/]
class eNFA25_3 c0001;
eNFA26_2[["εNFA26-2 char{1, 1}"]]
eNFA26_3[\"εNFA26-3 char[1]
AcceptToken '!='"/]
class eNFA26_3 c0001;
eNFA27_3[\"εNFA27-3 regex end
AcceptToken '&'"/]
class eNFA27_3 c0001;
eNFA27_4[\"εNFA27-4 post-regex start
AcceptToken '&'"/]
class eNFA27_4 c0001;
eNFA27_5[\"εNFA27-5 post-regex end"/]
class eNFA27_5 c0001;
eNFA28_3[\"εNFA28-3 regex end
AcceptToken '^'"/]
class eNFA28_3 c0001;
eNFA28_4[\"εNFA28-4 post-regex start
AcceptToken '^'"/]
class eNFA28_4 c0001;
eNFA28_5[\"εNFA28-5 post-regex end"/]
class eNFA28_5 c0001;
eNFA29_3[\"εNFA29-3 regex end
AcceptToken '|'"/]
class eNFA29_3 c0001;
eNFA29_4[\"εNFA29-4 post-regex start
AcceptToken '|'"/]
class eNFA29_4 c0001;
eNFA29_5[\"εNFA29-5 post-regex end"/]
class eNFA29_5 c0001;
eNFA30_2[["εNFA30-2 char{1, 1}"]]
eNFA30_3[\"εNFA30-3 char[1]
AcceptToken '&&'"/]
class eNFA30_3 c0001;
eNFA31_2[["εNFA31-2 char{1, 1}"]]
eNFA31_3[\"εNFA31-3 char[1]
AcceptToken '^^'"/]
class eNFA31_3 c0001;
eNFA32_2[["εNFA32-2 char{1, 1}"]]
eNFA32_3[\"εNFA32-3 char[1]
AcceptToken '||'"/]
class eNFA32_3 c0001;
eNFA33_3[\"εNFA33-3 regex end
AcceptToken '?'"/]
class eNFA33_3 c0001;
eNFA33_4[\"εNFA33-4 post-regex start
AcceptToken '?'"/]
class eNFA33_4 c0001;
eNFA33_5[\"εNFA33-5 post-regex end"/]
class eNFA33_5 c0001;
eNFA34_3[\"εNFA34-3 regex end
AcceptToken ':'"/]
class eNFA34_3 c0001;
eNFA34_4[\"εNFA34-4 post-regex start
AcceptToken ':'"/]
class eNFA34_4 c0001;
eNFA34_5[\"εNFA34-5 post-regex end"/]
class eNFA34_5 c0001;
eNFA35_3[\"εNFA35-3 regex end
AcceptToken '='"/]
class eNFA35_3 c0001;
eNFA35_4[\"εNFA35-4 post-regex start
AcceptToken '='"/]
class eNFA35_4 c0001;
eNFA35_5[\"εNFA35-5 post-regex end"/]
class eNFA35_5 c0001;
eNFA36_2[["εNFA36-2 char{1, 1}"]]
eNFA36_3[\"εNFA36-3 char[1]
AcceptToken '*='"/]
class eNFA36_3 c0001;
eNFA37_2[["εNFA37-2 char{1, 1}"]]
eNFA37_3[\"εNFA37-3 char[1]
AcceptToken '/='"/]
class eNFA37_3 c0001;
eNFA38_2[["εNFA38-2 char{1, 1}"]]
eNFA38_3[\"εNFA38-3 char[1]
AcceptToken '%='"/]
class eNFA38_3 c0001;
eNFA39_2[["εNFA39-2 char{1, 1}"]]
eNFA39_3[\"εNFA39-3 char[1]
AcceptToken '+='"/]
class eNFA39_3 c0001;
eNFA40_2[["εNFA40-2 char{1, 1}"]]
eNFA40_3[\"εNFA40-3 char[1]
AcceptToken '-='"/]
class eNFA40_3 c0001;
eNFA41_2[["εNFA41-2 char{1, 1}"]]
eNFA41_3[["εNFA41-3 char[1]"]]
eNFA42_2[["εNFA42-2 char{1, 1}"]]
eNFA42_3[["εNFA42-3 char[1]"]]
eNFA43_2[["εNFA43-2 char{1, 1}"]]
eNFA43_3[\"εNFA43-3 char[1]
AcceptToken '&='"/]
class eNFA43_3 c0001;
eNFA44_2[["εNFA44-2 char{1, 1}"]]
eNFA44_3[\"εNFA44-3 char[1]
AcceptToken '^='"/]
class eNFA44_3 c0001;
eNFA45_2[["εNFA45-2 char{1, 1}"]]
eNFA45_3[\"εNFA45-3 char[1]
AcceptToken '|='"/]
class eNFA45_3 c0001;
eNFA46_3[\"εNFA46-3 regex end
AcceptToken '{'"/]
class eNFA46_3 c0001;
eNFA46_4[\"εNFA46-4 post-regex start
AcceptToken '{'"/]
class eNFA46_4 c0001;
eNFA46_5[\"εNFA46-5 post-regex end"/]
class eNFA46_5 c0001;
eNFA47_3[\"εNFA47-3 regex end
AcceptToken '}'"/]
class eNFA47_3 c0001;
eNFA47_4[\"εNFA47-4 post-regex start
AcceptToken '}'"/]
class eNFA47_4 c0001;
eNFA47_5[\"εNFA47-5 post-regex end"/]
class eNFA47_5 c0001;
eNFA48_2[["εNFA48-2 char{1, 1}"]]
eNFA48_3[\"εNFA48-3 char[1]
AcceptToken '##'"/]
class eNFA48_3 c0001;
eNFA49_2[["εNFA49-2 char{1, 1}"]]
eNFA49_3[["εNFA49-3 char[1]"]]
eNFA50_2[["εNFA50-2 char{1, 1}"]]
eNFA50_3[["εNFA50-3 char[1]"]]
eNFA51_2[["εNFA51-2 char{1, 1}"]]
eNFA51_3[["εNFA51-3 char[1]"]]
eNFA52_2[["εNFA52-2 char{1, 1}"]]
eNFA52_3[["εNFA52-3 char[1]"]]
eNFA53_2[["εNFA53-2 char{1, 1}"]]
eNFA53_3[["εNFA53-3 char[1]"]]
eNFA54_2[["εNFA54-2 char{1, 1}"]]
eNFA54_3[["εNFA54-3 char[1]"]]
eNFA55_2[["εNFA55-2 char{1, 1}"]]
eNFA55_3[["εNFA55-3 char[1]"]]
eNFA56_2[["εNFA56-2 char{1, 1}"]]
eNFA56_3[["εNFA56-3 char[1]"]]
eNFA57_2[["εNFA57-2 char{1, 1}"]]
eNFA57_3[["εNFA57-3 char[1]"]]
eNFA58_2[["εNFA58-2 char{1, 1}"]]
eNFA58_3[["εNFA58-3 char[1]"]]
eNFA59_2[["εNFA59-2 char{1, 1}"]]
eNFA59_3[["εNFA59-3 char[1]"]]
eNFA60_2[["εNFA60-2 char{1, 1}"]]
eNFA60_3[["εNFA60-3 char[1]"]]
eNFA61_2[\"εNFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class eNFA61_2 c0001;
eNFA61_4[\"εNFA61-4 regex end
AcceptToken 'identifier'"/]
class eNFA61_4 c0001;
eNFA61_5[\"εNFA61-5 post-regex start
AcceptToken 'identifier'"/]
class eNFA61_5 c0001;
eNFA61_6[\"εNFA61-6 post-regex end"/]
class eNFA61_6 c0001;
eNFA63_6[\"εNFA63-6 regex start
AcceptToken 'number'"/]
class eNFA63_6 c0001;
eNFA63_2[\"εNFA63-2 scope{1, 1}"/]
eNFA63_7[\"εNFA63-7 regex end
AcceptToken 'number'"/]
class eNFA63_7 c0001;
eNFA63_3[["εNFA63-3 scope[1]"]]
eNFA63_9[\"εNFA63-9 regex end
AcceptToken 'number'"/]
class eNFA63_9 c0001;
eNFA63_10[\"εNFA63-10 post-regex start
AcceptToken 'number'"/]
class eNFA63_10 c0001;
eNFA63_11[\"εNFA63-11 post-regex end"/]
class eNFA63_11 c0001;
eNFA65_2[["εNFA65-2 char{1, 1}"]]
eNFA65_3[["εNFA65-3 char[1]"]]
eNFA67_2[["εNFA67-2 char{1, 1}"]]
eNFA67_3[["εNFA67-3 char[1]"]]
eNFA69_2[["εNFA69-2 char{1, 1}"]]
eNFA69_3[["εNFA69-3 char[1]"]]
eNFA70_2[["εNFA70-2 char{1, 1}"]]
eNFA70_3[["εNFA70-3 char[1]"]]
eNFA72_2[["εNFA72-2 char{1, 1}"]]
eNFA72_3[\"εNFA72-3 char[1]
AcceptToken 'inlineComment'"/]
class eNFA72_3 c0001;
eNFA62_8[["εNFA62-8 regex start"]]
eNFA62_4[["εNFA62-4 char{1, 1}"]]
eNFA62_10[["εNFA62-10 scope{1, 1}"]]
eNFA62_9[["εNFA62-9 regex end"]]
eNFA62_5[["εNFA62-5 char[1]"]]
eNFA62_11[["εNFA62-11 scope[1]"]]
eNFA62_12[["εNFA62-12 char{1, 1}"]]
eNFA62_13[\"εNFA62-13 char[1]
AcceptToken 'literalString'"/]
class eNFA62_13 c0001;
eNFA64_5[\"εNFA64-5 regex end
AcceptToken 'intConstant'"/]
class eNFA64_5 c0001;
eNFA64_6[\"εNFA64-6 post-regex start
AcceptToken 'intConstant'"/]
class eNFA64_6 c0001;
eNFA64_7[\"εNFA64-7 post-regex end"/]
class eNFA64_7 c0001;
eNFA66_4[["εNFA66-4 scope{1, 1}"]]
eNFA66_5[\"εNFA66-5 scope[1]
AcceptToken 'uintConstant'"/]
class eNFA66_5 c0001;
eNFA68_7[["εNFA68-7 regex start"]]
eNFA68_4[["εNFA68-4 scope{1, 1}"]]
eNFA68_8[["εNFA68-8 regex end"]]
eNFA68_5[["εNFA68-5 scope[1]"]]
eNFA68_15[["εNFA68-15 regex start"]]
eNFA68_9[["εNFA68-9 scope{1, 1}"]]
eNFA68_16[["εNFA68-16 regex end"]]
eNFA68_10[["εNFA68-10 scope[1]"]]
eNFA68_17[["εNFA68-17 scope{1, 1}"]]
eNFA68_18[\"εNFA68-18 scope[1]
AcceptToken 'floatConstant'"/]
class eNFA68_18 c0001;
eNFA71_7[\"εNFA71-7 regex start
AcceptToken 'doubleConstant'"/]
class eNFA71_7 c0001;
eNFA71_4[\"εNFA71-4 scope{1, 1}"/]
eNFA71_8[\"εNFA71-8 regex end
AcceptToken 'doubleConstant'"/]
class eNFA71_8 c0001;
eNFA71_5[\"εNFA71-5 scope[1]
AcceptToken 'doubleConstant'"/]
class eNFA71_5 c0001;
eNFA71_15[\"εNFA71-15 regex start
AcceptToken 'doubleConstant'"/]
class eNFA71_15 c0001;
eNFA71_9[\"εNFA71-9 scope{1, 1}"/]
eNFA71_16[\"εNFA71-16 regex end
AcceptToken 'doubleConstant'"/]
class eNFA71_16 c0001;
eNFA71_10[["εNFA71-10 scope[1]"]]
eNFA71_18[\"εNFA71-18 regex end
AcceptToken 'doubleConstant'"/]
class eNFA71_18 c0001;
eNFA71_19[\"εNFA71-19 post-regex start
AcceptToken 'doubleConstant'"/]
class eNFA71_19 c0001;
eNFA71_20[\"εNFA71-20 post-regex end"/]
class eNFA71_20 c0001;
eNFA1_4[["εNFA1-4 char{1, 1}"]]
eNFA1_5[["εNFA1-5 char[1]"]]
eNFA4_4[["εNFA4-4 char{1, 1}"]]
eNFA4_5[["εNFA4-5 char[1]"]]
eNFA10_5[\"εNFA10-5 regex end
AcceptToken '++'"/]
class eNFA10_5 c0001;
eNFA10_6[\"εNFA10-6 post-regex start
AcceptToken '++'"/]
class eNFA10_6 c0001;
eNFA10_7[\"εNFA10-7 post-regex end"/]
class eNFA10_7 c0001;
eNFA11_5[\"εNFA11-5 regex end
AcceptToken '--'"/]
class eNFA11_5 c0001;
eNFA11_6[\"εNFA11-6 post-regex start
AcceptToken '--'"/]
class eNFA11_6 c0001;
eNFA11_7[\"εNFA11-7 post-regex end"/]
class eNFA11_7 c0001;
eNFA19_5[\"εNFA19-5 regex end
AcceptToken '<<'"/]
class eNFA19_5 c0001;
eNFA19_6[\"εNFA19-6 post-regex start
AcceptToken '<<'"/]
class eNFA19_6 c0001;
eNFA19_7[\"εNFA19-7 post-regex end"/]
class eNFA19_7 c0001;
eNFA20_5[\"εNFA20-5 regex end
AcceptToken '>>'"/]
class eNFA20_5 c0001;
eNFA20_6[\"εNFA20-6 post-regex start
AcceptToken '>>'"/]
class eNFA20_6 c0001;
eNFA20_7[\"εNFA20-7 post-regex end"/]
class eNFA20_7 c0001;
eNFA23_5[\"εNFA23-5 regex end
AcceptToken '<='"/]
class eNFA23_5 c0001;
eNFA23_6[\"εNFA23-6 post-regex start
AcceptToken '<='"/]
class eNFA23_6 c0001;
eNFA23_7[\"εNFA23-7 post-regex end"/]
class eNFA23_7 c0001;
eNFA24_5[\"εNFA24-5 regex end
AcceptToken '>='"/]
class eNFA24_5 c0001;
eNFA24_6[\"εNFA24-6 post-regex start
AcceptToken '>='"/]
class eNFA24_6 c0001;
eNFA24_7[\"εNFA24-7 post-regex end"/]
class eNFA24_7 c0001;
eNFA25_5[\"εNFA25-5 regex end
AcceptToken '=='"/]
class eNFA25_5 c0001;
eNFA25_6[\"εNFA25-6 post-regex start
AcceptToken '=='"/]
class eNFA25_6 c0001;
eNFA25_7[\"εNFA25-7 post-regex end"/]
class eNFA25_7 c0001;
eNFA26_5[\"εNFA26-5 regex end
AcceptToken '!='"/]
class eNFA26_5 c0001;
eNFA26_6[\"εNFA26-6 post-regex start
AcceptToken '!='"/]
class eNFA26_6 c0001;
eNFA26_7[\"εNFA26-7 post-regex end"/]
class eNFA26_7 c0001;
eNFA30_5[\"εNFA30-5 regex end
AcceptToken '&&'"/]
class eNFA30_5 c0001;
eNFA30_6[\"εNFA30-6 post-regex start
AcceptToken '&&'"/]
class eNFA30_6 c0001;
eNFA30_7[\"εNFA30-7 post-regex end"/]
class eNFA30_7 c0001;
eNFA31_5[\"εNFA31-5 regex end
AcceptToken '^^'"/]
class eNFA31_5 c0001;
eNFA31_6[\"εNFA31-6 post-regex start
AcceptToken '^^'"/]
class eNFA31_6 c0001;
eNFA31_7[\"εNFA31-7 post-regex end"/]
class eNFA31_7 c0001;
eNFA32_5[\"εNFA32-5 regex end
AcceptToken '||'"/]
class eNFA32_5 c0001;
eNFA32_6[\"εNFA32-6 post-regex start
AcceptToken '||'"/]
class eNFA32_6 c0001;
eNFA32_7[\"εNFA32-7 post-regex end"/]
class eNFA32_7 c0001;
eNFA36_5[\"εNFA36-5 regex end
AcceptToken '*='"/]
class eNFA36_5 c0001;
eNFA36_6[\"εNFA36-6 post-regex start
AcceptToken '*='"/]
class eNFA36_6 c0001;
eNFA36_7[\"εNFA36-7 post-regex end"/]
class eNFA36_7 c0001;
eNFA37_5[\"εNFA37-5 regex end
AcceptToken '/='"/]
class eNFA37_5 c0001;
eNFA37_6[\"εNFA37-6 post-regex start
AcceptToken '/='"/]
class eNFA37_6 c0001;
eNFA37_7[\"εNFA37-7 post-regex end"/]
class eNFA37_7 c0001;
eNFA38_5[\"εNFA38-5 regex end
AcceptToken '%='"/]
class eNFA38_5 c0001;
eNFA38_6[\"εNFA38-6 post-regex start
AcceptToken '%='"/]
class eNFA38_6 c0001;
eNFA38_7[\"εNFA38-7 post-regex end"/]
class eNFA38_7 c0001;
eNFA39_5[\"εNFA39-5 regex end
AcceptToken '+='"/]
class eNFA39_5 c0001;
eNFA39_6[\"εNFA39-6 post-regex start
AcceptToken '+='"/]
class eNFA39_6 c0001;
eNFA39_7[\"εNFA39-7 post-regex end"/]
class eNFA39_7 c0001;
eNFA40_5[\"εNFA40-5 regex end
AcceptToken '-='"/]
class eNFA40_5 c0001;
eNFA40_6[\"εNFA40-6 post-regex start
AcceptToken '-='"/]
class eNFA40_6 c0001;
eNFA40_7[\"εNFA40-7 post-regex end"/]
class eNFA40_7 c0001;
eNFA41_4[["εNFA41-4 char{1, 1}"]]
eNFA41_5[\"εNFA41-5 char[1]
AcceptToken '<<='"/]
class eNFA41_5 c0001;
eNFA42_4[["εNFA42-4 char{1, 1}"]]
eNFA42_5[\"εNFA42-5 char[1]
AcceptToken '>>='"/]
class eNFA42_5 c0001;
eNFA43_5[\"εNFA43-5 regex end
AcceptToken '&='"/]
class eNFA43_5 c0001;
eNFA43_6[\"εNFA43-6 post-regex start
AcceptToken '&='"/]
class eNFA43_6 c0001;
eNFA43_7[\"εNFA43-7 post-regex end"/]
class eNFA43_7 c0001;
eNFA44_5[\"εNFA44-5 regex end
AcceptToken '^='"/]
class eNFA44_5 c0001;
eNFA44_6[\"εNFA44-6 post-regex start
AcceptToken '^='"/]
class eNFA44_6 c0001;
eNFA44_7[\"εNFA44-7 post-regex end"/]
class eNFA44_7 c0001;
eNFA45_5[\"εNFA45-5 regex end
AcceptToken '|='"/]
class eNFA45_5 c0001;
eNFA45_6[\"εNFA45-6 post-regex start
AcceptToken '|='"/]
class eNFA45_6 c0001;
eNFA45_7[\"εNFA45-7 post-regex end"/]
class eNFA45_7 c0001;
eNFA48_5[\"εNFA48-5 regex end
AcceptToken '##'"/]
class eNFA48_5 c0001;
eNFA48_6[\"εNFA48-6 post-regex start
AcceptToken '##'"/]
class eNFA48_6 c0001;
eNFA48_7[\"εNFA48-7 post-regex end"/]
class eNFA48_7 c0001;
eNFA49_4[["εNFA49-4 char{1, 1}"]]
eNFA49_5[\"εNFA49-5 char[1]
AcceptToken '#if'"/]
class eNFA49_5 c0001;
eNFA50_4[["εNFA50-4 char{1, 1}"]]
eNFA50_5[["εNFA50-5 char[1]"]]
eNFA51_4[["εNFA51-4 char{1, 1}"]]
eNFA51_5[["εNFA51-5 char[1]"]]
eNFA52_4[["εNFA52-4 char{1, 1}"]]
eNFA52_5[["εNFA52-5 char[1]"]]
eNFA53_4[["εNFA53-4 char{1, 1}"]]
eNFA53_5[["εNFA53-5 char[1]"]]
eNFA54_4[["εNFA54-4 char{1, 1}"]]
eNFA54_5[["εNFA54-5 char[1]"]]
eNFA55_4[["εNFA55-4 char{1, 1}"]]
eNFA55_5[["εNFA55-5 char[1]"]]
eNFA56_4[["εNFA56-4 char{1, 1}"]]
eNFA56_5[["εNFA56-5 char[1]"]]
eNFA57_4[["εNFA57-4 char{1, 1}"]]
eNFA57_5[["εNFA57-5 char[1]"]]
eNFA58_4[["εNFA58-4 char{1, 1}"]]
eNFA58_5[["εNFA58-5 char[1]"]]
eNFA59_4[["εNFA59-4 char{1, 1}"]]
eNFA59_5[["εNFA59-5 char[1]"]]
eNFA60_4[["εNFA60-4 char{1, 1}"]]
eNFA60_5[["εNFA60-5 char[1]"]]
eNFA63_4[["εNFA63-4 scope{1, -1}"]]
eNFA63_5[\"εNFA63-5 scope[1]
AcceptToken 'number'"/]
class eNFA63_5 c0001;
eNFA65_4[["εNFA65-4 scope{1, -1}"]]
eNFA65_5[\"εNFA65-5 scope[1]
AcceptToken 'intConstant'"/]
class eNFA65_5 c0001;
eNFA67_4[["εNFA67-4 scope{1, -1}"]]
eNFA67_5[["εNFA67-5 scope[1]"]]
eNFA69_4[["εNFA69-4 char{1, 1}"]]
eNFA69_5[["εNFA69-5 char[1]"]]
eNFA70_4[["εNFA70-4 char{1, 1}"]]
eNFA70_5[["εNFA70-5 char[1]"]]
eNFA72_4[\"εNFA72-4 scope{0, -1}
AcceptToken 'inlineComment'"/]
class eNFA72_4 c0001;
eNFA72_6[\"εNFA72-6 regex end
AcceptToken 'inlineComment'"/]
class eNFA72_6 c0001;
eNFA72_7[\"εNFA72-7 post-regex start
AcceptToken 'inlineComment'"/]
class eNFA72_7 c0001;
eNFA72_8[\"εNFA72-8 post-regex end"/]
class eNFA72_8 c0001;
eNFA62_6[["εNFA62-6 char{1, 1}"]]
eNFA62_7[["εNFA62-7 char[1]"]]
eNFA62_15[\"εNFA62-15 regex end
AcceptToken 'literalString'"/]
class eNFA62_15 c0001;
eNFA62_16[\"εNFA62-16 post-regex start
AcceptToken 'literalString'"/]
class eNFA62_16 c0001;
eNFA62_17[\"εNFA62-17 post-regex end"/]
class eNFA62_17 c0001;
eNFA66_7[\"εNFA66-7 regex end
AcceptToken 'uintConstant'"/]
class eNFA66_7 c0001;
eNFA66_8[\"εNFA66-8 post-regex start
AcceptToken 'uintConstant'"/]
class eNFA66_8 c0001;
eNFA66_9[\"εNFA66-9 post-regex end"/]
class eNFA66_9 c0001;
eNFA68_6[["εNFA68-6 scope{0, -1}"]]
eNFA68_8[["εNFA68-8 regex end"]]
eNFA68_7[["εNFA68-7 regex start"]]
eNFA68_4[["εNFA68-4 scope{1, 1}"]]
eNFA68_5[["εNFA68-5 scope[1]"]]
eNFA68_11[["εNFA68-11 scope{0, 1}"]]
eNFA68_12[["εNFA68-12 scope[1]"]]
eNFA68_13[["εNFA68-13 scope{1, -1}"]]
eNFA68_14[["εNFA68-14 scope[1]"]]
eNFA68_20[\"εNFA68-20 regex end
AcceptToken 'floatConstant'"/]
class eNFA68_20 c0001;
eNFA68_21[\"εNFA68-21 post-regex start
AcceptToken 'floatConstant'"/]
class eNFA68_21 c0001;
eNFA68_22[\"εNFA68-22 post-regex end"/]
class eNFA68_22 c0001;
eNFA71_6[\"εNFA71-6 scope{0, -1}
AcceptToken 'doubleConstant'"/]
class eNFA71_6 c0001;
eNFA71_8[\"εNFA71-8 regex end
AcceptToken 'doubleConstant'"/]
class eNFA71_8 c0001;
eNFA71_7[\"εNFA71-7 regex start
AcceptToken 'doubleConstant'"/]
class eNFA71_7 c0001;
eNFA71_4[\"εNFA71-4 scope{1, 1}"/]
eNFA71_5[\"εNFA71-5 scope[1]
AcceptToken 'doubleConstant'"/]
class eNFA71_5 c0001;
eNFA71_11[["εNFA71-11 scope{0, 1}"]]
eNFA71_12[["εNFA71-12 scope[1]"]]
eNFA71_13[["εNFA71-13 scope{1, -1}"]]
eNFA71_14[\"εNFA71-14 scope[1]
AcceptToken 'doubleConstant'"/]
class eNFA71_14 c0001;
eNFA1_6[["εNFA1-6 char{1, 1}"]]
eNFA1_7[["εNFA1-7 char[1]"]]
eNFA4_6[["εNFA4-6 char{1, 1}"]]
eNFA4_7[["εNFA4-7 char[1]"]]
eNFA41_7[\"εNFA41-7 regex end
AcceptToken '<<='"/]
class eNFA41_7 c0001;
eNFA41_8[\"εNFA41-8 post-regex start
AcceptToken '<<='"/]
class eNFA41_8 c0001;
eNFA41_9[\"εNFA41-9 post-regex end"/]
class eNFA41_9 c0001;
eNFA42_7[\"εNFA42-7 regex end
AcceptToken '>>='"/]
class eNFA42_7 c0001;
eNFA42_8[\"εNFA42-8 post-regex start
AcceptToken '>>='"/]
class eNFA42_8 c0001;
eNFA42_9[\"εNFA42-9 post-regex end"/]
class eNFA42_9 c0001;
eNFA49_7[\"εNFA49-7 regex end
AcceptToken '#if'"/]
class eNFA49_7 c0001;
eNFA49_8[\"εNFA49-8 post-regex start
AcceptToken '#if'"/]
class eNFA49_8 c0001;
eNFA49_9[\"εNFA49-9 post-regex end"/]
class eNFA49_9 c0001;
eNFA50_6[["εNFA50-6 char{1, 1}"]]
eNFA50_7[["εNFA50-7 char[1]"]]
eNFA51_6[["εNFA51-6 char{1, 1}"]]
eNFA51_7[["εNFA51-7 char[1]"]]
eNFA52_6[["εNFA52-6 char{1, 1}"]]
eNFA52_7[["εNFA52-7 char[1]"]]
eNFA53_6[["εNFA53-6 char{1, 1}"]]
eNFA53_7[["εNFA53-7 char[1]"]]
eNFA54_6[["εNFA54-6 char{1, 1}"]]
eNFA54_7[["εNFA54-7 char[1]"]]
eNFA55_6[["εNFA55-6 char{1, 1}"]]
eNFA55_7[["εNFA55-7 char[1]"]]
eNFA56_6[["εNFA56-6 char{1, 1}"]]
eNFA56_7[["εNFA56-7 char[1]"]]
eNFA57_6[["εNFA57-6 char{1, 1}"]]
eNFA57_7[["εNFA57-7 char[1]"]]
eNFA58_6[["εNFA58-6 char{1, 1}"]]
eNFA58_7[["εNFA58-7 char[1]"]]
eNFA59_6[["εNFA59-6 char{1, 1}"]]
eNFA59_7[["εNFA59-7 char[1]"]]
eNFA60_6[["εNFA60-6 char{1, 1}"]]
eNFA60_7[["εNFA60-7 char[1]"]]
eNFA63_7[\"εNFA63-7 regex end
AcceptToken 'number'"/]
class eNFA63_7 c0001;
eNFA63_6[\"εNFA63-6 regex start
AcceptToken 'number'"/]
class eNFA63_6 c0001;
eNFA63_2[\"εNFA63-2 scope{1, 1}"/]
eNFA63_3[["εNFA63-3 scope[1]"]]
eNFA65_7[\"εNFA65-7 regex end
AcceptToken 'intConstant'"/]
class eNFA65_7 c0001;
eNFA65_8[\"εNFA65-8 post-regex start
AcceptToken 'intConstant'"/]
class eNFA65_8 c0001;
eNFA65_9[\"εNFA65-9 post-regex end"/]
class eNFA65_9 c0001;
eNFA67_6[["εNFA67-6 scope{1, 1}"]]
eNFA67_7[\"εNFA67-7 scope[1]
AcceptToken 'uintConstant'"/]
class eNFA67_7 c0001;
eNFA69_6[["εNFA69-6 char{1, 1}"]]
eNFA69_7[["εNFA69-7 char[1]"]]
eNFA70_6[["εNFA70-6 char{1, 1}"]]
eNFA70_7[["εNFA70-7 char[1]"]]
eNFA68_6[["εNFA68-6 scope{0, -1}"]]
eNFA68_16[["εNFA68-16 regex end"]]
eNFA68_15[["εNFA68-15 regex start"]]
eNFA68_9[["εNFA68-9 scope{1, 1}"]]
eNFA68_10[["εNFA68-10 scope[1]"]]
eNFA71_6[\"εNFA71-6 scope{0, -1}
AcceptToken 'doubleConstant'"/]
class eNFA71_6 c0001;
eNFA71_16[\"εNFA71-16 regex end
AcceptToken 'doubleConstant'"/]
class eNFA71_16 c0001;
eNFA71_15[\"εNFA71-15 regex start
AcceptToken 'doubleConstant'"/]
class eNFA71_15 c0001;
eNFA71_9[\"εNFA71-9 scope{1, 1}"/]
eNFA71_10[["εNFA71-10 scope[1]"]]
eNFA1_8[["εNFA1-8 char{1, 1}"]]
eNFA1_9[["εNFA1-9 char[1]"]]
eNFA4_8[["εNFA4-8 char{1, 1}"]]
eNFA4_9[["εNFA4-9 char[1]"]]
eNFA50_8[["εNFA50-8 char{1, 1}"]]
eNFA50_9[["εNFA50-9 char[1]"]]
eNFA51_8[["εNFA51-8 char{1, 1}"]]
eNFA51_9[["εNFA51-9 char[1]"]]
eNFA52_8[["εNFA52-8 char{1, 1}"]]
eNFA52_9[\"εNFA52-9 char[1]
AcceptToken '#else'"/]
class eNFA52_9 c0001;
eNFA53_8[["εNFA53-8 char{1, 1}"]]
eNFA53_9[\"εNFA53-9 char[1]
AcceptToken '#elif'"/]
class eNFA53_9 c0001;
eNFA54_8[["εNFA54-8 char{1, 1}"]]
eNFA54_9[["εNFA54-9 char[1]"]]
eNFA55_8[["εNFA55-8 char{1, 1}"]]
eNFA55_9[["εNFA55-9 char[1]"]]
eNFA56_8[["εNFA56-8 char{1, 1}"]]
eNFA56_9[["εNFA56-9 char[1]"]]
eNFA57_8[["εNFA57-8 char{1, 1}"]]
eNFA57_9[["εNFA57-9 char[1]"]]
eNFA58_8[["εNFA58-8 char{1, 1}"]]
eNFA58_9[["εNFA58-9 char[1]"]]
eNFA59_8[["εNFA59-8 char{1, 1}"]]
eNFA59_9[\"εNFA59-9 char[1]
AcceptToken '#line'"/]
class eNFA59_9 c0001;
eNFA60_8[["εNFA60-8 char{1, 1}"]]
eNFA60_9[["εNFA60-9 char[1]"]]
eNFA63_4[["εNFA63-4 scope{1, -1}"]]
eNFA63_5[\"εNFA63-5 scope[1]
AcceptToken 'number'"/]
class eNFA63_5 c0001;
eNFA67_9[\"εNFA67-9 regex end
AcceptToken 'uintConstant'"/]
class eNFA67_9 c0001;
eNFA67_10[\"εNFA67-10 post-regex start
AcceptToken 'uintConstant'"/]
class eNFA67_10 c0001;
eNFA67_11[\"εNFA67-11 post-regex end"/]
class eNFA67_11 c0001;
eNFA69_9[["εNFA69-9 regex end"]]
eNFA69_12[["εNFA69-12 regex start"]]
eNFA69_10[["εNFA69-10 scope{1, 1}"]]
eNFA69_11[\"εNFA69-11 scope[1]
AcceptToken 'boolConstant'"/]
class eNFA69_11 c0001;
eNFA70_8[["εNFA70-8 char{1, 1}"]]
eNFA70_9[["εNFA70-9 char[1]"]]
eNFA68_11[["εNFA68-11 scope{0, 1}"]]
eNFA68_12[["εNFA68-12 scope[1]"]]
eNFA68_13[["εNFA68-13 scope{1, -1}"]]
eNFA68_14[["εNFA68-14 scope[1]"]]
eNFA71_11[["εNFA71-11 scope{0, 1}"]]
eNFA71_12[["εNFA71-12 scope[1]"]]
eNFA71_13[["εNFA71-13 scope{1, -1}"]]
eNFA71_14[\"εNFA71-14 scope[1]
AcceptToken 'doubleConstant'"/]
class eNFA71_14 c0001;
eNFA1_10[["εNFA1-10 char{1, 1}"]]
eNFA1_11[["εNFA1-11 char[1]"]]
eNFA4_10[["εNFA4-10 char{1, 1}"]]
eNFA4_11[\"εNFA4-11 char[1]
AcceptToken '#undef'"/]
class eNFA4_11 c0001;
eNFA50_10[["εNFA50-10 char{1, 1}"]]
eNFA50_11[\"εNFA50-11 char[1]
AcceptToken '#ifdef'"/]
class eNFA50_11 c0001;
eNFA51_10[["εNFA51-10 char{1, 1}"]]
eNFA51_11[["εNFA51-11 char[1]"]]
eNFA52_11[\"εNFA52-11 regex end
AcceptToken '#else'"/]
class eNFA52_11 c0001;
eNFA52_12[\"εNFA52-12 post-regex start
AcceptToken '#else'"/]
class eNFA52_12 c0001;
eNFA52_13[\"εNFA52-13 post-regex end"/]
class eNFA52_13 c0001;
eNFA53_11[\"εNFA53-11 regex end
AcceptToken '#elif'"/]
class eNFA53_11 c0001;
eNFA53_12[\"εNFA53-12 post-regex start
AcceptToken '#elif'"/]
class eNFA53_12 c0001;
eNFA53_13[\"εNFA53-13 post-regex end"/]
class eNFA53_13 c0001;
eNFA54_10[["εNFA54-10 char{1, 1}"]]
eNFA54_11[\"εNFA54-11 char[1]
AcceptToken '#endif'"/]
class eNFA54_11 c0001;
eNFA55_10[["εNFA55-10 char{1, 1}"]]
eNFA55_11[\"εNFA55-11 char[1]
AcceptToken '#error'"/]
class eNFA55_11 c0001;
eNFA56_10[["εNFA56-10 char{1, 1}"]]
eNFA56_11[["εNFA56-11 char[1]"]]
eNFA57_10[["εNFA57-10 char{1, 1}"]]
eNFA57_11[["εNFA57-11 char[1]"]]
eNFA58_10[["εNFA58-10 char{1, 1}"]]
eNFA58_11[["εNFA58-11 char[1]"]]
eNFA59_11[\"εNFA59-11 regex end
AcceptToken '#line'"/]
class eNFA59_11 c0001;
eNFA59_12[\"εNFA59-12 post-regex start
AcceptToken '#line'"/]
class eNFA59_12 c0001;
eNFA59_13[\"εNFA59-13 post-regex end"/]
class eNFA59_13 c0001;
eNFA60_10[["εNFA60-10 char{1, 1}"]]
eNFA60_11[["εNFA60-11 char[1]"]]
eNFA69_13[\"εNFA69-13 regex end"/]
class eNFA69_13 c0001;
eNFA70_11[["εNFA70-11 regex end"]]
eNFA70_14[["εNFA70-14 regex start"]]
eNFA70_12[["εNFA70-12 scope{1, 1}"]]
eNFA70_13[\"εNFA70-13 scope[1]
AcceptToken 'boolConstant'"/]
class eNFA70_13 c0001;
eNFA1_12[["εNFA1-12 char{1, 1}"]]
eNFA1_13[\"εNFA1-13 char[1]
AcceptToken '#define'"/]
class eNFA1_13 c0001;
eNFA4_13[\"εNFA4-13 regex end
AcceptToken '#undef'"/]
class eNFA4_13 c0001;
eNFA4_14[\"εNFA4-14 post-regex start
AcceptToken '#undef'"/]
class eNFA4_14 c0001;
eNFA4_15[\"εNFA4-15 post-regex end"/]
class eNFA4_15 c0001;
eNFA50_13[\"εNFA50-13 regex end
AcceptToken '#ifdef'"/]
class eNFA50_13 c0001;
eNFA50_14[\"εNFA50-14 post-regex start
AcceptToken '#ifdef'"/]
class eNFA50_14 c0001;
eNFA50_15[\"εNFA50-15 post-regex end"/]
class eNFA50_15 c0001;
eNFA51_12[["εNFA51-12 char{1, 1}"]]
eNFA51_13[\"εNFA51-13 char[1]
AcceptToken '#ifndef'"/]
class eNFA51_13 c0001;
eNFA54_13[\"εNFA54-13 regex end
AcceptToken '#endif'"/]
class eNFA54_13 c0001;
eNFA54_14[\"εNFA54-14 post-regex start
AcceptToken '#endif'"/]
class eNFA54_14 c0001;
eNFA54_15[\"εNFA54-15 post-regex end"/]
class eNFA54_15 c0001;
eNFA55_13[\"εNFA55-13 regex end
AcceptToken '#error'"/]
class eNFA55_13 c0001;
eNFA55_14[\"εNFA55-14 post-regex start
AcceptToken '#error'"/]
class eNFA55_14 c0001;
eNFA55_15[\"εNFA55-15 post-regex end"/]
class eNFA55_15 c0001;
eNFA56_12[["εNFA56-12 char{1, 1}"]]
eNFA56_13[\"εNFA56-13 char[1]
AcceptToken '#pragma'"/]
class eNFA56_13 c0001;
eNFA57_12[["εNFA57-12 char{1, 1}"]]
eNFA57_13[["εNFA57-13 char[1]"]]
eNFA58_12[["εNFA58-12 char{1, 1}"]]
eNFA58_13[["εNFA58-13 char[1]"]]
eNFA60_12[["εNFA60-12 char{1, 1}"]]
eNFA60_13[\"εNFA60-13 char[1]
AcceptToken 'defined'"/]
class eNFA60_13 c0001;
eNFA70_15[\"εNFA70-15 regex end"/]
class eNFA70_15 c0001;
eNFA1_15[\"εNFA1-15 regex end
AcceptToken '#define'"/]
class eNFA1_15 c0001;
eNFA1_16[\"εNFA1-16 post-regex start
AcceptToken '#define'"/]
class eNFA1_16 c0001;
eNFA1_17[\"εNFA1-17 post-regex end"/]
class eNFA1_17 c0001;
eNFA51_15[\"εNFA51-15 regex end
AcceptToken '#ifndef'"/]
class eNFA51_15 c0001;
eNFA51_16[\"εNFA51-16 post-regex start
AcceptToken '#ifndef'"/]
class eNFA51_16 c0001;
eNFA51_17[\"εNFA51-17 post-regex end"/]
class eNFA51_17 c0001;
eNFA56_15[\"εNFA56-15 regex end
AcceptToken '#pragma'"/]
class eNFA56_15 c0001;
eNFA56_16[\"εNFA56-16 post-regex start
AcceptToken '#pragma'"/]
class eNFA56_16 c0001;
eNFA56_17[\"εNFA56-17 post-regex end"/]
class eNFA56_17 c0001;
eNFA57_14[["εNFA57-14 char{1, 1}"]]
eNFA57_15[["εNFA57-15 char[1]"]]
eNFA58_14[["εNFA58-14 char{1, 1}"]]
eNFA58_15[\"εNFA58-15 char[1]
AcceptToken '#version'"/]
class eNFA58_15 c0001;
eNFA60_15[\"εNFA60-15 regex end
AcceptToken 'defined'"/]
class eNFA60_15 c0001;
eNFA60_16[\"εNFA60-16 post-regex start
AcceptToken 'defined'"/]
class eNFA60_16 c0001;
eNFA60_17[\"εNFA60-17 post-regex end"/]
class eNFA60_17 c0001;
eNFA57_16[["εNFA57-16 char{1, 1}"]]
eNFA57_17[["εNFA57-17 char[1]"]]
eNFA58_17[\"εNFA58-17 regex end
AcceptToken '#version'"/]
class eNFA58_17 c0001;
eNFA58_18[\"εNFA58-18 post-regex start
AcceptToken '#version'"/]
class eNFA58_18 c0001;
eNFA58_19[\"εNFA58-19 post-regex end"/]
class eNFA58_19 c0001;
eNFA57_18[["εNFA57-18 char{1, 1}"]]
eNFA57_19[\"εNFA57-19 char[1]
AcceptToken '#extension'"/]
class eNFA57_19 c0001;
eNFA57_21[\"εNFA57-21 regex end
AcceptToken '#extension'"/]
class eNFA57_21 c0001;
eNFA57_22[\"εNFA57-22 post-regex start
AcceptToken '#extension'"/]
class eNFA57_22 c0001;
eNFA57_23[\"εNFA57-23 post-regex end"/]
class eNFA57_23 c0001;
eNFA0_0 -.->|"ε"|eNFA1_14
eNFA0_0 -.->|"ε"|eNFA2_2
eNFA0_0 -.->|"ε"|eNFA3_2
eNFA0_0 -.->|"ε"|eNFA4_12
eNFA0_0 -.->|"ε"|eNFA5_2
eNFA0_0 -.->|"ε"|eNFA6_2
eNFA0_0 -.->|"ε"|eNFA7_2
eNFA0_0 -.->|"ε"|eNFA8_2
eNFA0_0 -.->|"ε"|eNFA9_2
eNFA0_0 -.->|"ε"|eNFA10_4
eNFA0_0 -.->|"ε"|eNFA11_4
eNFA0_0 -.->|"ε"|eNFA12_2
eNFA0_0 -.->|"ε"|eNFA13_2
eNFA0_0 -.->|"ε"|eNFA14_2
eNFA0_0 -.->|"ε"|eNFA15_2
eNFA0_0 -.->|"ε"|eNFA16_2
eNFA0_0 -.->|"ε"|eNFA17_2
eNFA0_0 -.->|"ε"|eNFA18_2
eNFA0_0 -.->|"ε"|eNFA19_4
eNFA0_0 -.->|"ε"|eNFA20_4
eNFA0_0 -.->|"ε"|eNFA21_2
eNFA0_0 -.->|"ε"|eNFA22_2
eNFA0_0 -.->|"ε"|eNFA23_4
eNFA0_0 -.->|"ε"|eNFA24_4
eNFA0_0 -.->|"ε"|eNFA25_4
eNFA0_0 -.->|"ε"|eNFA26_4
eNFA0_0 -.->|"ε"|eNFA27_2
eNFA0_0 -.->|"ε"|eNFA28_2
eNFA0_0 -.->|"ε"|eNFA29_2
eNFA0_0 -.->|"ε"|eNFA30_4
eNFA0_0 -.->|"ε"|eNFA31_4
eNFA0_0 -.->|"ε"|eNFA32_4
eNFA0_0 -.->|"ε"|eNFA33_2
eNFA0_0 -.->|"ε"|eNFA34_2
eNFA0_0 -.->|"ε"|eNFA35_2
eNFA0_0 -.->|"ε"|eNFA36_4
eNFA0_0 -.->|"ε"|eNFA37_4
eNFA0_0 -.->|"ε"|eNFA38_4
eNFA0_0 -.->|"ε"|eNFA39_4
eNFA0_0 -.->|"ε"|eNFA40_4
eNFA0_0 -.->|"ε"|eNFA41_6
eNFA0_0 -.->|"ε"|eNFA42_6
eNFA0_0 -.->|"ε"|eNFA43_4
eNFA0_0 -.->|"ε"|eNFA44_4
eNFA0_0 -.->|"ε"|eNFA45_4
eNFA0_0 -.->|"ε"|eNFA46_2
eNFA0_0 -.->|"ε"|eNFA47_2
eNFA0_0 -.->|"ε"|eNFA48_4
eNFA0_0 -.->|"ε"|eNFA49_6
eNFA0_0 -.->|"ε"|eNFA50_12
eNFA0_0 -.->|"ε"|eNFA51_14
eNFA0_0 -.->|"ε"|eNFA52_10
eNFA0_0 -.->|"ε"|eNFA53_10
eNFA0_0 -.->|"ε"|eNFA54_12
eNFA0_0 -.->|"ε"|eNFA55_12
eNFA0_0 -.->|"ε"|eNFA56_14
eNFA0_0 -.->|"ε"|eNFA57_20
eNFA0_0 -.->|"ε"|eNFA58_16
eNFA0_0 -.->|"ε"|eNFA59_10
eNFA0_0 -.->|"ε"|eNFA60_14
eNFA0_0 -.->|"ε"|eNFA61_3
eNFA0_0 -.->|"ε"|eNFA62_14
eNFA0_0 -.->|"ε"|eNFA63_8
eNFA0_0 -.->|"ε"|eNFA64_4
eNFA0_0 -.->|"ε"|eNFA65_6
eNFA0_0 -.->|"ε"|eNFA66_6
eNFA0_0 -.->|"ε"|eNFA67_8
eNFA0_0 -.->|"ε"|eNFA68_19
eNFA0_0 -.->|"ε"|eNFA69_8
eNFA0_0 -.->|"ε"|eNFA70_10
eNFA0_0 -.->|"ε"|eNFA71_17
eNFA0_0 -.->|"ε"|eNFA72_5
eNFA0_0 -.->|"ε
BeginToken '#35;define'"|eNFA1_0
eNFA0_0 -.->|"ε
BeginToken '('"|eNFA2_0
eNFA0_0 -.->|"ε
BeginToken ')'"|eNFA3_0
eNFA0_0 -.->|"ε
BeginToken '#35;undef'"|eNFA4_0
eNFA0_0 -.->|"ε
BeginToken ','"|eNFA5_0
eNFA0_0 -.->|"ε
BeginToken ';'"|eNFA6_0
eNFA0_0 -.->|"ε
BeginToken '['"|eNFA7_0
eNFA0_0 -.->|"ε
BeginToken ']'"|eNFA8_0
eNFA0_0 -.->|"ε
BeginToken '.'"|eNFA9_0
eNFA0_0 -.->|"ε
BeginToken '++'"|eNFA10_0
eNFA0_0 -.->|"ε
BeginToken '--'"|eNFA11_0
eNFA0_0 -.->|"ε
BeginToken '+'"|eNFA12_0
eNFA0_0 -.->|"ε
BeginToken '-'"|eNFA13_0
eNFA0_0 -.->|"ε
BeginToken '!'"|eNFA14_0
eNFA0_0 -.->|"ε
BeginToken '~'"|eNFA15_0
eNFA0_0 -.->|"ε
BeginToken '#42;'"|eNFA16_0
eNFA0_0 -.->|"ε
BeginToken '/'"|eNFA17_0
eNFA0_0 -.->|"ε
BeginToken '%'"|eNFA18_0
eNFA0_0 -.->|"ε
BeginToken '<<'"|eNFA19_0
eNFA0_0 -.->|"ε
BeginToken '>>'"|eNFA20_0
eNFA0_0 -.->|"ε
BeginToken '<'"|eNFA21_0
eNFA0_0 -.->|"ε
BeginToken '>'"|eNFA22_0
eNFA0_0 -.->|"ε
BeginToken '<='"|eNFA23_0
eNFA0_0 -.->|"ε
BeginToken '>='"|eNFA24_0
eNFA0_0 -.->|"ε
BeginToken '=='"|eNFA25_0
eNFA0_0 -.->|"ε
BeginToken '!='"|eNFA26_0
eNFA0_0 -.->|"ε
BeginToken '&'"|eNFA27_0
eNFA0_0 -.->|"ε
BeginToken '^'"|eNFA28_0
eNFA0_0 -.->|"ε
BeginToken '|'"|eNFA29_0
eNFA0_0 -.->|"ε
BeginToken '&&'"|eNFA30_0
eNFA0_0 -.->|"ε
BeginToken '^^'"|eNFA31_0
eNFA0_0 -.->|"ε
BeginToken '||'"|eNFA32_0
eNFA0_0 -.->|"ε
BeginToken '?'"|eNFA33_0
eNFA0_0 -.->|"ε
BeginToken ':'"|eNFA34_0
eNFA0_0 -.->|"ε
BeginToken '='"|eNFA35_0
eNFA0_0 -.->|"ε
BeginToken '#42;='"|eNFA36_0
eNFA0_0 -.->|"ε
BeginToken '/='"|eNFA37_0
eNFA0_0 -.->|"ε
BeginToken '%='"|eNFA38_0
eNFA0_0 -.->|"ε
BeginToken '+='"|eNFA39_0
eNFA0_0 -.->|"ε
BeginToken '-='"|eNFA40_0
eNFA0_0 -.->|"ε
BeginToken '<<='"|eNFA41_0
eNFA0_0 -.->|"ε
BeginToken '>>='"|eNFA42_0
eNFA0_0 -.->|"ε
BeginToken '&='"|eNFA43_0
eNFA0_0 -.->|"ε
BeginToken '^='"|eNFA44_0
eNFA0_0 -.->|"ε
BeginToken '|='"|eNFA45_0
eNFA0_0 -.->|"ε
BeginToken '{'"|eNFA46_0
eNFA0_0 -.->|"ε
BeginToken '}'"|eNFA47_0
eNFA0_0 -.->|"ε
BeginToken '#35;#35;'"|eNFA48_0
eNFA0_0 -.->|"ε
BeginToken '#35;if'"|eNFA49_0
eNFA0_0 -.->|"ε
BeginToken '#35;ifdef'"|eNFA50_0
eNFA0_0 -.->|"ε
BeginToken '#35;ifndef'"|eNFA51_0
eNFA0_0 -.->|"ε
BeginToken '#35;else'"|eNFA52_0
eNFA0_0 -.->|"ε
BeginToken '#35;elif'"|eNFA53_0
eNFA0_0 -.->|"ε
BeginToken '#35;endif'"|eNFA54_0
eNFA0_0 -.->|"ε
BeginToken '#35;error'"|eNFA55_0
eNFA0_0 -.->|"ε
BeginToken '#35;pragma'"|eNFA56_0
eNFA0_0 -.->|"ε
BeginToken '#35;extension'"|eNFA57_0
eNFA0_0 -.->|"ε
BeginToken '#35;version'"|eNFA58_0
eNFA0_0 -.->|"ε
BeginToken '#35;line'"|eNFA59_0
eNFA0_0 -.->|"ε
BeginToken 'defined'"|eNFA60_0
eNFA0_0 -.->|"ε
BeginToken 'identifier'"|eNFA61_0
eNFA0_0 -.->|"ε
BeginToken 'literalString'"|eNFA62_0
eNFA0_0 -.->|"ε
BeginToken 'number'"|eNFA63_0
eNFA0_0 -.->|"ε
BeginToken 'intConstant'"|eNFA64_0
eNFA0_0 -.->|"ε
BeginToken 'intConstant'"|eNFA65_0
eNFA0_0 -.->|"ε
BeginToken 'uintConstant'"|eNFA66_0
eNFA0_0 -.->|"ε
BeginToken 'uintConstant'"|eNFA67_0
eNFA0_0 -.->|"ε
BeginToken 'floatConstant'"|eNFA68_0
eNFA0_0 -.->|"ε
BeginToken 'boolConstant'"|eNFA69_0
eNFA0_0 -.->|"ε
BeginToken 'boolConstant'"|eNFA70_0
eNFA0_0 -.->|"ε
BeginToken 'doubleConstant'"|eNFA71_0
eNFA0_0 -.->|"ε
BeginToken 'inlineComment'"|eNFA72_0
eNFA0_0 -->|"#35;
BeginToken '#35;define'"|eNFA1_1
eNFA0_0 -->|"#92;(
BeginToken '('
ExtendToken '('"|eNFA2_1
eNFA0_0 -->|"#92;)
BeginToken ')'
ExtendToken ')'"|eNFA3_1
eNFA0_0 -->|"#35;
BeginToken '#35;undef'"|eNFA4_1
eNFA0_0 -->|",
BeginToken ','
ExtendToken ','"|eNFA5_1
eNFA0_0 -->|";
BeginToken ';'
ExtendToken ';'"|eNFA6_1
eNFA0_0 -->|"#92;[
BeginToken '['
ExtendToken '['"|eNFA7_1
eNFA0_0 -->|"]
BeginToken ']'
ExtendToken ']'"|eNFA8_1
eNFA0_0 -->|"#92;.
BeginToken '.'
ExtendToken '.'"|eNFA9_1
eNFA0_0 -->|"#92;+
BeginToken '++'"|eNFA10_1
eNFA0_0 -->|"-
BeginToken '--'"|eNFA11_1
eNFA0_0 -->|"#92;+
BeginToken '+'
ExtendToken '+'"|eNFA12_1
eNFA0_0 -->|"-
BeginToken '-'
ExtendToken '-'"|eNFA13_1
eNFA0_0 -->|"!
BeginToken '!'
ExtendToken '!'"|eNFA14_1
eNFA0_0 -->|"~
BeginToken '~'
ExtendToken '~'"|eNFA15_1
eNFA0_0 -->|"#92;#42;
BeginToken '#42;'
ExtendToken '#42;'"|eNFA16_1
eNFA0_0 -->|"#92;/
BeginToken '/'
ExtendToken '/'"|eNFA17_1
eNFA0_0 -->|"%
BeginToken '%'
ExtendToken '%'"|eNFA18_1
eNFA0_0 -->|"#92;<
BeginToken '<<'"|eNFA19_1
eNFA0_0 -->|">
BeginToken '>>'"|eNFA20_1
eNFA0_0 -->|"#92;<
BeginToken '<'
ExtendToken '<'"|eNFA21_1
eNFA0_0 -->|">
BeginToken '>'
ExtendToken '>'"|eNFA22_1
eNFA0_0 -->|"#92;<
BeginToken '<='"|eNFA23_1
eNFA0_0 -->|">
BeginToken '>='"|eNFA24_1
eNFA0_0 -->|"=
BeginToken '=='"|eNFA25_1
eNFA0_0 -->|"!
BeginToken '!='"|eNFA26_1
eNFA0_0 -->|"&
BeginToken '&'
ExtendToken '&'"|eNFA27_1
eNFA0_0 -->|"^
BeginToken '^'
ExtendToken '^'"|eNFA28_1
eNFA0_0 -->|"#92;|
BeginToken '|'
ExtendToken '|'"|eNFA29_1
eNFA0_0 -->|"&
BeginToken '&&'"|eNFA30_1
eNFA0_0 -->|"^
BeginToken '^^'"|eNFA31_1
eNFA0_0 -->|"#92;|
BeginToken '||'"|eNFA32_1
eNFA0_0 -->|"#92;?
BeginToken '?'
ExtendToken '?'"|eNFA33_1
eNFA0_0 -->|":
BeginToken ':'
ExtendToken ':'"|eNFA34_1
eNFA0_0 -->|"=
BeginToken '='
ExtendToken '='"|eNFA35_1
eNFA0_0 -->|"#92;#42;
BeginToken '#42;='"|eNFA36_1
eNFA0_0 -->|"#92;/
BeginToken '/='"|eNFA37_1
eNFA0_0 -->|"%
BeginToken '%='"|eNFA38_1
eNFA0_0 -->|"#92;+
BeginToken '+='"|eNFA39_1
eNFA0_0 -->|"-
BeginToken '-='"|eNFA40_1
eNFA0_0 -->|"#92;<
BeginToken '<<='"|eNFA41_1
eNFA0_0 -->|">
BeginToken '>>='"|eNFA42_1
eNFA0_0 -->|"&
BeginToken '&='"|eNFA43_1
eNFA0_0 -->|"^
BeginToken '^='"|eNFA44_1
eNFA0_0 -->|"#92;|
BeginToken '|='"|eNFA45_1
eNFA0_0 -->|"#92;{
BeginToken '{'
ExtendToken '{'"|eNFA46_1
eNFA0_0 -->|"}
BeginToken '}'
ExtendToken '}'"|eNFA47_1
eNFA0_0 -->|"#35;
BeginToken '#35;#35;'"|eNFA48_1
eNFA0_0 -->|"#35;
BeginToken '#35;if'"|eNFA49_1
eNFA0_0 -->|"#35;
BeginToken '#35;ifdef'"|eNFA50_1
eNFA0_0 -->|"#35;
BeginToken '#35;ifndef'"|eNFA51_1
eNFA0_0 -->|"#35;
BeginToken '#35;else'"|eNFA52_1
eNFA0_0 -->|"#35;
BeginToken '#35;elif'"|eNFA53_1
eNFA0_0 -->|"#35;
BeginToken '#35;endif'"|eNFA54_1
eNFA0_0 -->|"#35;
BeginToken '#35;error'"|eNFA55_1
eNFA0_0 -->|"#35;
BeginToken '#35;pragma'"|eNFA56_1
eNFA0_0 -->|"#35;
BeginToken '#35;extension'"|eNFA57_1
eNFA0_0 -->|"#35;
BeginToken '#35;version'"|eNFA58_1
eNFA0_0 -->|"#35;
BeginToken '#35;line'"|eNFA59_1
eNFA0_0 -->|"d
BeginToken 'defined'"|eNFA60_1
eNFA0_0 -->|"[a-zA-Z_]
BeginToken 'identifier'
ExtendToken 'identifier'"|eNFA61_1
eNFA0_0 -->|"[a-zA-Z_]
BeginToken 'literalString'"|eNFA62_1
eNFA0_0 -.->|"ε
BeginToken 'literalString'"|eNFA62_1
eNFA0_0 -.->|"ε
BeginToken 'literalString'"|eNFA62_2
eNFA0_0 -->|"[0-9]
BeginToken 'number'
ExtendToken 'number'"|eNFA63_1
eNFA0_0 -->|"[-+]
BeginToken 'intConstant'"|eNFA64_1
eNFA0_0 -.->|"ε
BeginToken 'intConstant'"|eNFA64_1
eNFA0_0 -.->|"ε
BeginToken 'intConstant'"|eNFA64_2
eNFA0_0 -->|"0
BeginToken 'intConstant'"|eNFA65_1
eNFA0_0 -->|"[-+]
BeginToken 'uintConstant'"|eNFA66_1
eNFA0_0 -.->|"ε
BeginToken 'uintConstant'"|eNFA66_1
eNFA0_0 -.->|"ε
BeginToken 'uintConstant'"|eNFA66_2
eNFA0_0 -->|"0
BeginToken 'uintConstant'"|eNFA67_1
eNFA0_0 -->|"[-+]
BeginToken 'floatConstant'"|eNFA68_1
eNFA0_0 -.->|"ε
BeginToken 'floatConstant'"|eNFA68_1
eNFA0_0 -.->|"ε
BeginToken 'floatConstant'"|eNFA68_2
eNFA0_0 -->|"t
BeginToken 'boolConstant'"|eNFA69_1
eNFA0_0 -->|"f
BeginToken 'boolConstant'"|eNFA70_1
eNFA0_0 -->|"[-+]
BeginToken 'doubleConstant'"|eNFA71_1
eNFA0_0 -.->|"ε
BeginToken 'doubleConstant'"|eNFA71_1
eNFA0_0 -.->|"ε
BeginToken 'doubleConstant'"|eNFA71_2
eNFA0_0 -->|"#92;/
BeginToken 'inlineComment'"|eNFA72_1
eNFA0_0 -->|"#34;
BeginToken 'literalString'"|eNFA62_3
eNFA0_0 -->|"[0-9]
BeginToken 'intConstant'
ExtendToken 'intConstant'"|eNFA64_3
eNFA0_0 -->|"[0-9]
BeginToken 'uintConstant'"|eNFA66_3
eNFA0_0 -->|"[0-9]
BeginToken 'floatConstant'"|eNFA68_3
eNFA0_0 -->|"[0-9]
BeginToken 'doubleConstant'
ExtendToken 'doubleConstant'"|eNFA71_3
eNFA1_14 -.->|"ε
BeginToken '#35;define'"|eNFA1_0
eNFA1_14 -->|"#35;
BeginToken '#35;define'"|eNFA1_1
eNFA2_2 -.->|"ε
BeginToken '('"|eNFA2_0
eNFA2_2 -->|"#92;(
BeginToken '('
ExtendToken '('"|eNFA2_1
eNFA3_2 -.->|"ε
BeginToken ')'"|eNFA3_0
eNFA3_2 -->|"#92;)
BeginToken ')'
ExtendToken ')'"|eNFA3_1
eNFA4_12 -.->|"ε
BeginToken '#35;undef'"|eNFA4_0
eNFA4_12 -->|"#35;
BeginToken '#35;undef'"|eNFA4_1
eNFA5_2 -.->|"ε
BeginToken ','"|eNFA5_0
eNFA5_2 -->|",
BeginToken ','
ExtendToken ','"|eNFA5_1
eNFA6_2 -.->|"ε
BeginToken ';'"|eNFA6_0
eNFA6_2 -->|";
BeginToken ';'
ExtendToken ';'"|eNFA6_1
eNFA7_2 -.->|"ε
BeginToken '['"|eNFA7_0
eNFA7_2 -->|"#92;[
BeginToken '['
ExtendToken '['"|eNFA7_1
eNFA8_2 -.->|"ε
BeginToken ']'"|eNFA8_0
eNFA8_2 -->|"]
BeginToken ']'
ExtendToken ']'"|eNFA8_1
eNFA9_2 -.->|"ε
BeginToken '.'"|eNFA9_0
eNFA9_2 -->|"#92;.
BeginToken '.'
ExtendToken '.'"|eNFA9_1
eNFA10_4 -.->|"ε
BeginToken '++'"|eNFA10_0
eNFA10_4 -->|"#92;+
BeginToken '++'"|eNFA10_1
eNFA11_4 -.->|"ε
BeginToken '--'"|eNFA11_0
eNFA11_4 -->|"-
BeginToken '--'"|eNFA11_1
eNFA12_2 -.->|"ε
BeginToken '+'"|eNFA12_0
eNFA12_2 -->|"#92;+
BeginToken '+'
ExtendToken '+'"|eNFA12_1
eNFA13_2 -.->|"ε
BeginToken '-'"|eNFA13_0
eNFA13_2 -->|"-
BeginToken '-'
ExtendToken '-'"|eNFA13_1
eNFA14_2 -.->|"ε
BeginToken '!'"|eNFA14_0
eNFA14_2 -->|"!
BeginToken '!'
ExtendToken '!'"|eNFA14_1
eNFA15_2 -.->|"ε
BeginToken '~'"|eNFA15_0
eNFA15_2 -->|"~
BeginToken '~'
ExtendToken '~'"|eNFA15_1
eNFA16_2 -.->|"ε
BeginToken '#42;'"|eNFA16_0
eNFA16_2 -->|"#92;#42;
BeginToken '#42;'
ExtendToken '#42;'"|eNFA16_1
eNFA17_2 -.->|"ε
BeginToken '/'"|eNFA17_0
eNFA17_2 -->|"#92;/
BeginToken '/'
ExtendToken '/'"|eNFA17_1
eNFA18_2 -.->|"ε
BeginToken '%'"|eNFA18_0
eNFA18_2 -->|"%
BeginToken '%'
ExtendToken '%'"|eNFA18_1
eNFA19_4 -.->|"ε
BeginToken '<<'"|eNFA19_0
eNFA19_4 -->|"#92;<
BeginToken '<<'"|eNFA19_1
eNFA20_4 -.->|"ε
BeginToken '>>'"|eNFA20_0
eNFA20_4 -->|">
BeginToken '>>'"|eNFA20_1
eNFA21_2 -.->|"ε
BeginToken '<'"|eNFA21_0
eNFA21_2 -->|"#92;<
BeginToken '<'
ExtendToken '<'"|eNFA21_1
eNFA22_2 -.->|"ε
BeginToken '>'"|eNFA22_0
eNFA22_2 -->|">
BeginToken '>'
ExtendToken '>'"|eNFA22_1
eNFA23_4 -.->|"ε
BeginToken '<='"|eNFA23_0
eNFA23_4 -->|"#92;<
BeginToken '<='"|eNFA23_1
eNFA24_4 -.->|"ε
BeginToken '>='"|eNFA24_0
eNFA24_4 -->|">
BeginToken '>='"|eNFA24_1
eNFA25_4 -.->|"ε
BeginToken '=='"|eNFA25_0
eNFA25_4 -->|"=
BeginToken '=='"|eNFA25_1
eNFA26_4 -.->|"ε
BeginToken '!='"|eNFA26_0
eNFA26_4 -->|"!
BeginToken '!='"|eNFA26_1
eNFA27_2 -.->|"ε
BeginToken '&'"|eNFA27_0
eNFA27_2 -->|"&
BeginToken '&'
ExtendToken '&'"|eNFA27_1
eNFA28_2 -.->|"ε
BeginToken '^'"|eNFA28_0
eNFA28_2 -->|"^
BeginToken '^'
ExtendToken '^'"|eNFA28_1
eNFA29_2 -.->|"ε
BeginToken '|'"|eNFA29_0
eNFA29_2 -->|"#92;|
BeginToken '|'
ExtendToken '|'"|eNFA29_1
eNFA30_4 -.->|"ε
BeginToken '&&'"|eNFA30_0
eNFA30_4 -->|"&
BeginToken '&&'"|eNFA30_1
eNFA31_4 -.->|"ε
BeginToken '^^'"|eNFA31_0
eNFA31_4 -->|"^
BeginToken '^^'"|eNFA31_1
eNFA32_4 -.->|"ε
BeginToken '||'"|eNFA32_0
eNFA32_4 -->|"#92;|
BeginToken '||'"|eNFA32_1
eNFA33_2 -.->|"ε
BeginToken '?'"|eNFA33_0
eNFA33_2 -->|"#92;?
BeginToken '?'
ExtendToken '?'"|eNFA33_1
eNFA34_2 -.->|"ε
BeginToken ':'"|eNFA34_0
eNFA34_2 -->|":
BeginToken ':'
ExtendToken ':'"|eNFA34_1
eNFA35_2 -.->|"ε
BeginToken '='"|eNFA35_0
eNFA35_2 -->|"=
BeginToken '='
ExtendToken '='"|eNFA35_1
eNFA36_4 -.->|"ε
BeginToken '#42;='"|eNFA36_0
eNFA36_4 -->|"#92;#42;
BeginToken '#42;='"|eNFA36_1
eNFA37_4 -.->|"ε
BeginToken '/='"|eNFA37_0
eNFA37_4 -->|"#92;/
BeginToken '/='"|eNFA37_1
eNFA38_4 -.->|"ε
BeginToken '%='"|eNFA38_0
eNFA38_4 -->|"%
BeginToken '%='"|eNFA38_1
eNFA39_4 -.->|"ε
BeginToken '+='"|eNFA39_0
eNFA39_4 -->|"#92;+
BeginToken '+='"|eNFA39_1
eNFA40_4 -.->|"ε
BeginToken '-='"|eNFA40_0
eNFA40_4 -->|"-
BeginToken '-='"|eNFA40_1
eNFA41_6 -.->|"ε
BeginToken '<<='"|eNFA41_0
eNFA41_6 -->|"#92;<
BeginToken '<<='"|eNFA41_1
eNFA42_6 -.->|"ε
BeginToken '>>='"|eNFA42_0
eNFA42_6 -->|">
BeginToken '>>='"|eNFA42_1
eNFA43_4 -.->|"ε
BeginToken '&='"|eNFA43_0
eNFA43_4 -->|"&
BeginToken '&='"|eNFA43_1
eNFA44_4 -.->|"ε
BeginToken '^='"|eNFA44_0
eNFA44_4 -->|"^
BeginToken '^='"|eNFA44_1
eNFA45_4 -.->|"ε
BeginToken '|='"|eNFA45_0
eNFA45_4 -->|"#92;|
BeginToken '|='"|eNFA45_1
eNFA46_2 -.->|"ε
BeginToken '{'"|eNFA46_0
eNFA46_2 -->|"#92;{
BeginToken '{'
ExtendToken '{'"|eNFA46_1
eNFA47_2 -.->|"ε
BeginToken '}'"|eNFA47_0
eNFA47_2 -->|"}
BeginToken '}'
ExtendToken '}'"|eNFA47_1
eNFA48_4 -.->|"ε
BeginToken '#35;#35;'"|eNFA48_0
eNFA48_4 -->|"#35;
BeginToken '#35;#35;'"|eNFA48_1
eNFA49_6 -.->|"ε
BeginToken '#35;if'"|eNFA49_0
eNFA49_6 -->|"#35;
BeginToken '#35;if'"|eNFA49_1
eNFA50_12 -.->|"ε
BeginToken '#35;ifdef'"|eNFA50_0
eNFA50_12 -->|"#35;
BeginToken '#35;ifdef'"|eNFA50_1
eNFA51_14 -.->|"ε
BeginToken '#35;ifndef'"|eNFA51_0
eNFA51_14 -->|"#35;
BeginToken '#35;ifndef'"|eNFA51_1
eNFA52_10 -.->|"ε
BeginToken '#35;else'"|eNFA52_0
eNFA52_10 -->|"#35;
BeginToken '#35;else'"|eNFA52_1
eNFA53_10 -.->|"ε
BeginToken '#35;elif'"|eNFA53_0
eNFA53_10 -->|"#35;
BeginToken '#35;elif'"|eNFA53_1
eNFA54_12 -.->|"ε
BeginToken '#35;endif'"|eNFA54_0
eNFA54_12 -->|"#35;
BeginToken '#35;endif'"|eNFA54_1
eNFA55_12 -.->|"ε
BeginToken '#35;error'"|eNFA55_0
eNFA55_12 -->|"#35;
BeginToken '#35;error'"|eNFA55_1
eNFA56_14 -.->|"ε
BeginToken '#35;pragma'"|eNFA56_0
eNFA56_14 -->|"#35;
BeginToken '#35;pragma'"|eNFA56_1
eNFA57_20 -.->|"ε
BeginToken '#35;extension'"|eNFA57_0
eNFA57_20 -->|"#35;
BeginToken '#35;extension'"|eNFA57_1
eNFA58_16 -.->|"ε
BeginToken '#35;version'"|eNFA58_0
eNFA58_16 -->|"#35;
BeginToken '#35;version'"|eNFA58_1
eNFA59_10 -.->|"ε
BeginToken '#35;line'"|eNFA59_0
eNFA59_10 -->|"#35;
BeginToken '#35;line'"|eNFA59_1
eNFA60_14 -.->|"ε
BeginToken 'defined'"|eNFA60_0
eNFA60_14 -->|"d
BeginToken 'defined'"|eNFA60_1
eNFA61_3 -.->|"ε
BeginToken 'identifier'"|eNFA61_0
eNFA61_3 -->|"[a-zA-Z_]
BeginToken 'identifier'
ExtendToken 'identifier'"|eNFA61_1
eNFA62_14 -.->|"ε
BeginToken 'literalString'"|eNFA62_0
eNFA62_14 -->|"[a-zA-Z_]
BeginToken 'literalString'"|eNFA62_1
eNFA62_14 -.->|"ε
BeginToken 'literalString'"|eNFA62_1
eNFA62_14 -.->|"ε
BeginToken 'literalString'"|eNFA62_2
eNFA62_14 -->|"#34;
BeginToken 'literalString'"|eNFA62_3
eNFA63_8 -.->|"ε
BeginToken 'number'"|eNFA63_0
eNFA63_8 -->|"[0-9]
BeginToken 'number'
ExtendToken 'number'"|eNFA63_1
eNFA64_4 -.->|"ε
BeginToken 'intConstant'"|eNFA64_0
eNFA64_4 -->|"[-+]
BeginToken 'intConstant'"|eNFA64_1
eNFA64_4 -.->|"ε
BeginToken 'intConstant'"|eNFA64_1
eNFA64_4 -.->|"ε
BeginToken 'intConstant'"|eNFA64_2
eNFA64_4 -->|"[0-9]
BeginToken 'intConstant'
ExtendToken 'intConstant'"|eNFA64_3
eNFA65_6 -.->|"ε
BeginToken 'intConstant'"|eNFA65_0
eNFA65_6 -->|"0
BeginToken 'intConstant'"|eNFA65_1
eNFA66_6 -.->|"ε
BeginToken 'uintConstant'"|eNFA66_0
eNFA66_6 -->|"[-+]
BeginToken 'uintConstant'"|eNFA66_1
eNFA66_6 -.->|"ε
BeginToken 'uintConstant'"|eNFA66_1
eNFA66_6 -.->|"ε
BeginToken 'uintConstant'"|eNFA66_2
eNFA66_6 -->|"[0-9]
BeginToken 'uintConstant'"|eNFA66_3
eNFA67_8 -.->|"ε
BeginToken 'uintConstant'"|eNFA67_0
eNFA67_8 -->|"0
BeginToken 'uintConstant'"|eNFA67_1
eNFA68_19 -.->|"ε
BeginToken 'floatConstant'"|eNFA68_0
eNFA68_19 -->|"[-+]
BeginToken 'floatConstant'"|eNFA68_1
eNFA68_19 -.->|"ε
BeginToken 'floatConstant'"|eNFA68_1
eNFA68_19 -.->|"ε
BeginToken 'floatConstant'"|eNFA68_2
eNFA68_19 -->|"[0-9]
BeginToken 'floatConstant'"|eNFA68_3
eNFA69_8 -.->|"ε
BeginToken 'boolConstant'"|eNFA69_0
eNFA69_8 -->|"t
BeginToken 'boolConstant'"|eNFA69_1
eNFA70_10 -.->|"ε
BeginToken 'boolConstant'"|eNFA70_0
eNFA70_10 -->|"f
BeginToken 'boolConstant'"|eNFA70_1
eNFA71_17 -.->|"ε
BeginToken 'doubleConstant'"|eNFA71_0
eNFA71_17 -->|"[-+]
BeginToken 'doubleConstant'"|eNFA71_1
eNFA71_17 -.->|"ε
BeginToken 'doubleConstant'"|eNFA71_1
eNFA71_17 -.->|"ε
BeginToken 'doubleConstant'"|eNFA71_2
eNFA71_17 -->|"[0-9]
BeginToken 'doubleConstant'
ExtendToken 'doubleConstant'"|eNFA71_3
eNFA72_5 -.->|"ε
BeginToken 'inlineComment'"|eNFA72_0
eNFA72_5 -->|"#92;/
BeginToken 'inlineComment'"|eNFA72_1
eNFA1_0 -->|"#35;
BeginToken '#35;define'"|eNFA1_1
eNFA2_0 -->|"#92;(
BeginToken '('
ExtendToken '('"|eNFA2_1
eNFA3_0 -->|"#92;)
BeginToken ')'
ExtendToken ')'"|eNFA3_1
eNFA4_0 -->|"#35;
BeginToken '#35;undef'"|eNFA4_1
eNFA5_0 -->|",
BeginToken ','
ExtendToken ','"|eNFA5_1
eNFA6_0 -->|";
BeginToken ';'
ExtendToken ';'"|eNFA6_1
eNFA7_0 -->|"#92;[
BeginToken '['
ExtendToken '['"|eNFA7_1
eNFA8_0 -->|"]
BeginToken ']'
ExtendToken ']'"|eNFA8_1
eNFA9_0 -->|"#92;.
BeginToken '.'
ExtendToken '.'"|eNFA9_1
eNFA10_0 -->|"#92;+
BeginToken '++'"|eNFA10_1
eNFA11_0 -->|"-
BeginToken '--'"|eNFA11_1
eNFA12_0 -->|"#92;+
BeginToken '+'
ExtendToken '+'"|eNFA12_1
eNFA13_0 -->|"-
BeginToken '-'
ExtendToken '-'"|eNFA13_1
eNFA14_0 -->|"!
BeginToken '!'
ExtendToken '!'"|eNFA14_1
eNFA15_0 -->|"~
BeginToken '~'
ExtendToken '~'"|eNFA15_1
eNFA16_0 -->|"#92;#42;
BeginToken '#42;'
ExtendToken '#42;'"|eNFA16_1
eNFA17_0 -->|"#92;/
BeginToken '/'
ExtendToken '/'"|eNFA17_1
eNFA18_0 -->|"%
BeginToken '%'
ExtendToken '%'"|eNFA18_1
eNFA19_0 -->|"#92;<
BeginToken '<<'"|eNFA19_1
eNFA20_0 -->|">
BeginToken '>>'"|eNFA20_1
eNFA21_0 -->|"#92;<
BeginToken '<'
ExtendToken '<'"|eNFA21_1
eNFA22_0 -->|">
BeginToken '>'
ExtendToken '>'"|eNFA22_1
eNFA23_0 -->|"#92;<
BeginToken '<='"|eNFA23_1
eNFA24_0 -->|">
BeginToken '>='"|eNFA24_1
eNFA25_0 -->|"=
BeginToken '=='"|eNFA25_1
eNFA26_0 -->|"!
BeginToken '!='"|eNFA26_1
eNFA27_0 -->|"&
BeginToken '&'
ExtendToken '&'"|eNFA27_1
eNFA28_0 -->|"^
BeginToken '^'
ExtendToken '^'"|eNFA28_1
eNFA29_0 -->|"#92;|
BeginToken '|'
ExtendToken '|'"|eNFA29_1
eNFA30_0 -->|"&
BeginToken '&&'"|eNFA30_1
eNFA31_0 -->|"^
BeginToken '^^'"|eNFA31_1
eNFA32_0 -->|"#92;|
BeginToken '||'"|eNFA32_1
eNFA33_0 -->|"#92;?
BeginToken '?'
ExtendToken '?'"|eNFA33_1
eNFA34_0 -->|":
BeginToken ':'
ExtendToken ':'"|eNFA34_1
eNFA35_0 -->|"=
BeginToken '='
ExtendToken '='"|eNFA35_1
eNFA36_0 -->|"#92;#42;
BeginToken '#42;='"|eNFA36_1
eNFA37_0 -->|"#92;/
BeginToken '/='"|eNFA37_1
eNFA38_0 -->|"%
BeginToken '%='"|eNFA38_1
eNFA39_0 -->|"#92;+
BeginToken '+='"|eNFA39_1
eNFA40_0 -->|"-
BeginToken '-='"|eNFA40_1
eNFA41_0 -->|"#92;<
BeginToken '<<='"|eNFA41_1
eNFA42_0 -->|">
BeginToken '>>='"|eNFA42_1
eNFA43_0 -->|"&
BeginToken '&='"|eNFA43_1
eNFA44_0 -->|"^
BeginToken '^='"|eNFA44_1
eNFA45_0 -->|"#92;|
BeginToken '|='"|eNFA45_1
eNFA46_0 -->|"#92;{
BeginToken '{'
ExtendToken '{'"|eNFA46_1
eNFA47_0 -->|"}
BeginToken '}'
ExtendToken '}'"|eNFA47_1
eNFA48_0 -->|"#35;
BeginToken '#35;#35;'"|eNFA48_1
eNFA49_0 -->|"#35;
BeginToken '#35;if'"|eNFA49_1
eNFA50_0 -->|"#35;
BeginToken '#35;ifdef'"|eNFA50_1
eNFA51_0 -->|"#35;
BeginToken '#35;ifndef'"|eNFA51_1
eNFA52_0 -->|"#35;
BeginToken '#35;else'"|eNFA52_1
eNFA53_0 -->|"#35;
BeginToken '#35;elif'"|eNFA53_1
eNFA54_0 -->|"#35;
BeginToken '#35;endif'"|eNFA54_1
eNFA55_0 -->|"#35;
BeginToken '#35;error'"|eNFA55_1
eNFA56_0 -->|"#35;
BeginToken '#35;pragma'"|eNFA56_1
eNFA57_0 -->|"#35;
BeginToken '#35;extension'"|eNFA57_1
eNFA58_0 -->|"#35;
BeginToken '#35;version'"|eNFA58_1
eNFA59_0 -->|"#35;
BeginToken '#35;line'"|eNFA59_1
eNFA60_0 -->|"d
BeginToken 'defined'"|eNFA60_1
eNFA61_0 -->|"[a-zA-Z_]
BeginToken 'identifier'
ExtendToken 'identifier'"|eNFA61_1
eNFA62_0 -->|"[a-zA-Z_]
BeginToken 'literalString'"|eNFA62_1
eNFA62_0 -.->|"ε
BeginToken 'literalString'"|eNFA62_1
eNFA62_0 -.->|"ε
BeginToken 'literalString'"|eNFA62_2
eNFA62_0 -->|"#34;
BeginToken 'literalString'"|eNFA62_3
eNFA63_0 -->|"[0-9]
BeginToken 'number'
ExtendToken 'number'"|eNFA63_1
eNFA64_0 -->|"[-+]
BeginToken 'intConstant'"|eNFA64_1
eNFA64_0 -.->|"ε
BeginToken 'intConstant'"|eNFA64_1
eNFA64_0 -.->|"ε
BeginToken 'intConstant'"|eNFA64_2
eNFA64_0 -->|"[0-9]
BeginToken 'intConstant'
ExtendToken 'intConstant'"|eNFA64_3
eNFA65_0 -->|"0
BeginToken 'intConstant'"|eNFA65_1
eNFA66_0 -->|"[-+]
BeginToken 'uintConstant'"|eNFA66_1
eNFA66_0 -.->|"ε
BeginToken 'uintConstant'"|eNFA66_1
eNFA66_0 -.->|"ε
BeginToken 'uintConstant'"|eNFA66_2
eNFA66_0 -->|"[0-9]
BeginToken 'uintConstant'"|eNFA66_3
eNFA67_0 -->|"0
BeginToken 'uintConstant'"|eNFA67_1
eNFA68_0 -->|"[-+]
BeginToken 'floatConstant'"|eNFA68_1
eNFA68_0 -.->|"ε
BeginToken 'floatConstant'"|eNFA68_1
eNFA68_0 -.->|"ε
BeginToken 'floatConstant'"|eNFA68_2
eNFA68_0 -->|"[0-9]
BeginToken 'floatConstant'"|eNFA68_3
eNFA69_0 -->|"t
BeginToken 'boolConstant'"|eNFA69_1
eNFA70_0 -->|"f
BeginToken 'boolConstant'"|eNFA70_1
eNFA71_0 -->|"[-+]
BeginToken 'doubleConstant'"|eNFA71_1
eNFA71_0 -.->|"ε
BeginToken 'doubleConstant'"|eNFA71_1
eNFA71_0 -.->|"ε
BeginToken 'doubleConstant'"|eNFA71_2
eNFA71_0 -->|"[0-9]
BeginToken 'doubleConstant'
ExtendToken 'doubleConstant'"|eNFA71_3
eNFA72_0 -->|"#92;/
BeginToken 'inlineComment'"|eNFA72_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"d"|eNFA1_3
eNFA2_1 -.->|"ε
ExtendToken '('"|eNFA2_3
eNFA2_1 -.->|"ε"|eNFA2_4
eNFA2_1 -.->|"ε
AcceptToken '('"|eNFA2_5
eNFA2_1 -.->|"ε"|eNFA0_1
eNFA3_1 -.->|"ε
ExtendToken ')'"|eNFA3_3
eNFA3_1 -.->|"ε"|eNFA3_4
eNFA3_1 -.->|"ε
AcceptToken ')'"|eNFA3_5
eNFA3_1 -.->|"ε"|eNFA0_1
eNFA4_1 -.->|"ε"|eNFA4_2
eNFA4_1 -->|"u"|eNFA4_3
eNFA5_1 -.->|"ε
ExtendToken ','"|eNFA5_3
eNFA5_1 -.->|"ε"|eNFA5_4
eNFA5_1 -.->|"ε
AcceptToken ','"|eNFA5_5
eNFA5_1 -.->|"ε"|eNFA0_1
eNFA6_1 -.->|"ε
ExtendToken ';'"|eNFA6_3
eNFA6_1 -.->|"ε"|eNFA6_4
eNFA6_1 -.->|"ε
AcceptToken ';'"|eNFA6_5
eNFA6_1 -.->|"ε"|eNFA0_1
eNFA7_1 -.->|"ε
ExtendToken '['"|eNFA7_3
eNFA7_1 -.->|"ε"|eNFA7_4
eNFA7_1 -.->|"ε
AcceptToken '['"|eNFA7_5
eNFA7_1 -.->|"ε"|eNFA0_1
eNFA8_1 -.->|"ε
ExtendToken ']'"|eNFA8_3
eNFA8_1 -.->|"ε"|eNFA8_4
eNFA8_1 -.->|"ε
AcceptToken ']'"|eNFA8_5
eNFA8_1 -.->|"ε"|eNFA0_1
eNFA9_1 -.->|"ε
ExtendToken '.'"|eNFA9_3
eNFA9_1 -.->|"ε"|eNFA9_4
eNFA9_1 -.->|"ε
AcceptToken '.'"|eNFA9_5
eNFA9_1 -.->|"ε"|eNFA0_1
eNFA10_1 -.->|"ε"|eNFA10_2
eNFA10_1 -->|"#92;+
ExtendToken '++'"|eNFA10_3
eNFA11_1 -.->|"ε"|eNFA11_2
eNFA11_1 -->|"-
ExtendToken '--'"|eNFA11_3
eNFA12_1 -.->|"ε
ExtendToken '+'"|eNFA12_3
eNFA12_1 -.->|"ε"|eNFA12_4
eNFA12_1 -.->|"ε
AcceptToken '+'"|eNFA12_5
eNFA12_1 -.->|"ε"|eNFA0_1
eNFA13_1 -.->|"ε
ExtendToken '-'"|eNFA13_3
eNFA13_1 -.->|"ε"|eNFA13_4
eNFA13_1 -.->|"ε
AcceptToken '-'"|eNFA13_5
eNFA13_1 -.->|"ε"|eNFA0_1
eNFA14_1 -.->|"ε
ExtendToken '!'"|eNFA14_3
eNFA14_1 -.->|"ε"|eNFA14_4
eNFA14_1 -.->|"ε
AcceptToken '!'"|eNFA14_5
eNFA14_1 -.->|"ε"|eNFA0_1
eNFA15_1 -.->|"ε
ExtendToken '~'"|eNFA15_3
eNFA15_1 -.->|"ε"|eNFA15_4
eNFA15_1 -.->|"ε
AcceptToken '~'"|eNFA15_5
eNFA15_1 -.->|"ε"|eNFA0_1
eNFA16_1 -.->|"ε
ExtendToken '#42;'"|eNFA16_3
eNFA16_1 -.->|"ε"|eNFA16_4
eNFA16_1 -.->|"ε
AcceptToken '#42;'"|eNFA16_5
eNFA16_1 -.->|"ε"|eNFA0_1
eNFA17_1 -.->|"ε
ExtendToken '/'"|eNFA17_3
eNFA17_1 -.->|"ε"|eNFA17_4
eNFA17_1 -.->|"ε
AcceptToken '/'"|eNFA17_5
eNFA17_1 -.->|"ε"|eNFA0_1
eNFA18_1 -.->|"ε
ExtendToken '%'"|eNFA18_3
eNFA18_1 -.->|"ε"|eNFA18_4
eNFA18_1 -.->|"ε
AcceptToken '%'"|eNFA18_5
eNFA18_1 -.->|"ε"|eNFA0_1
eNFA19_1 -.->|"ε"|eNFA19_2
eNFA19_1 -->|"#92;<
ExtendToken '<<'"|eNFA19_3
eNFA20_1 -.->|"ε"|eNFA20_2
eNFA20_1 -->|">
ExtendToken '>>'"|eNFA20_3
eNFA21_1 -.->|"ε
ExtendToken '<'"|eNFA21_3
eNFA21_1 -.->|"ε"|eNFA21_4
eNFA21_1 -.->|"ε
AcceptToken '<'"|eNFA21_5
eNFA21_1 -.->|"ε"|eNFA0_1
eNFA22_1 -.->|"ε
ExtendToken '>'"|eNFA22_3
eNFA22_1 -.->|"ε"|eNFA22_4
eNFA22_1 -.->|"ε
AcceptToken '>'"|eNFA22_5
eNFA22_1 -.->|"ε"|eNFA0_1
eNFA23_1 -.->|"ε"|eNFA23_2
eNFA23_1 -->|"=
ExtendToken '<='"|eNFA23_3
eNFA24_1 -.->|"ε"|eNFA24_2
eNFA24_1 -->|"=
ExtendToken '>='"|eNFA24_3
eNFA25_1 -.->|"ε"|eNFA25_2
eNFA25_1 -->|"=
ExtendToken '=='"|eNFA25_3
eNFA26_1 -.->|"ε"|eNFA26_2
eNFA26_1 -->|"=
ExtendToken '!='"|eNFA26_3
eNFA27_1 -.->|"ε
ExtendToken '&'"|eNFA27_3
eNFA27_1 -.->|"ε"|eNFA27_4
eNFA27_1 -.->|"ε
AcceptToken '&'"|eNFA27_5
eNFA27_1 -.->|"ε"|eNFA0_1
eNFA28_1 -.->|"ε
ExtendToken '^'"|eNFA28_3
eNFA28_1 -.->|"ε"|eNFA28_4
eNFA28_1 -.->|"ε
AcceptToken '^'"|eNFA28_5
eNFA28_1 -.->|"ε"|eNFA0_1
eNFA29_1 -.->|"ε
ExtendToken '|'"|eNFA29_3
eNFA29_1 -.->|"ε"|eNFA29_4
eNFA29_1 -.->|"ε
AcceptToken '|'"|eNFA29_5
eNFA29_1 -.->|"ε"|eNFA0_1
eNFA30_1 -.->|"ε"|eNFA30_2
eNFA30_1 -->|"&
ExtendToken '&&'"|eNFA30_3
eNFA31_1 -.->|"ε"|eNFA31_2
eNFA31_1 -->|"^
ExtendToken '^^'"|eNFA31_3
eNFA32_1 -.->|"ε"|eNFA32_2
eNFA32_1 -->|"#92;|
ExtendToken '||'"|eNFA32_3
eNFA33_1 -.->|"ε
ExtendToken '?'"|eNFA33_3
eNFA33_1 -.->|"ε"|eNFA33_4
eNFA33_1 -.->|"ε
AcceptToken '?'"|eNFA33_5
eNFA33_1 -.->|"ε"|eNFA0_1
eNFA34_1 -.->|"ε
ExtendToken ':'"|eNFA34_3
eNFA34_1 -.->|"ε"|eNFA34_4
eNFA34_1 -.->|"ε
AcceptToken ':'"|eNFA34_5
eNFA34_1 -.->|"ε"|eNFA0_1
eNFA35_1 -.->|"ε
ExtendToken '='"|eNFA35_3
eNFA35_1 -.->|"ε"|eNFA35_4
eNFA35_1 -.->|"ε
AcceptToken '='"|eNFA35_5
eNFA35_1 -.->|"ε"|eNFA0_1
eNFA36_1 -.->|"ε"|eNFA36_2
eNFA36_1 -->|"=
ExtendToken '#42;='"|eNFA36_3
eNFA37_1 -.->|"ε"|eNFA37_2
eNFA37_1 -->|"=
ExtendToken '/='"|eNFA37_3
eNFA38_1 -.->|"ε"|eNFA38_2
eNFA38_1 -->|"=
ExtendToken '%='"|eNFA38_3
eNFA39_1 -.->|"ε"|eNFA39_2
eNFA39_1 -->|"=
ExtendToken '+='"|eNFA39_3
eNFA40_1 -.->|"ε"|eNFA40_2
eNFA40_1 -->|"=
ExtendToken '-='"|eNFA40_3
eNFA41_1 -.->|"ε"|eNFA41_2
eNFA41_1 -->|"#92;<"|eNFA41_3
eNFA42_1 -.->|"ε"|eNFA42_2
eNFA42_1 -->|">"|eNFA42_3
eNFA43_1 -.->|"ε"|eNFA43_2
eNFA43_1 -->|"=
ExtendToken '&='"|eNFA43_3
eNFA44_1 -.->|"ε"|eNFA44_2
eNFA44_1 -->|"=
ExtendToken '^='"|eNFA44_3
eNFA45_1 -.->|"ε"|eNFA45_2
eNFA45_1 -->|"=
ExtendToken '|='"|eNFA45_3
eNFA46_1 -.->|"ε
ExtendToken '{'"|eNFA46_3
eNFA46_1 -.->|"ε"|eNFA46_4
eNFA46_1 -.->|"ε
AcceptToken '{'"|eNFA46_5
eNFA46_1 -.->|"ε"|eNFA0_1
eNFA47_1 -.->|"ε
ExtendToken '}'"|eNFA47_3
eNFA47_1 -.->|"ε"|eNFA47_4
eNFA47_1 -.->|"ε
AcceptToken '}'"|eNFA47_5
eNFA47_1 -.->|"ε"|eNFA0_1
eNFA48_1 -.->|"ε"|eNFA48_2
eNFA48_1 -->|"#35;
ExtendToken '#35;#35;'"|eNFA48_3
eNFA49_1 -.->|"ε"|eNFA49_2
eNFA49_1 -->|"i"|eNFA49_3
eNFA50_1 -.->|"ε"|eNFA50_2
eNFA50_1 -->|"i"|eNFA50_3
eNFA51_1 -.->|"ε"|eNFA51_2
eNFA51_1 -->|"i"|eNFA51_3
eNFA52_1 -.->|"ε"|eNFA52_2
eNFA52_1 -->|"e"|eNFA52_3
eNFA53_1 -.->|"ε"|eNFA53_2
eNFA53_1 -->|"e"|eNFA53_3
eNFA54_1 -.->|"ε"|eNFA54_2
eNFA54_1 -->|"e"|eNFA54_3
eNFA55_1 -.->|"ε"|eNFA55_2
eNFA55_1 -->|"e"|eNFA55_3
eNFA56_1 -.->|"ε"|eNFA56_2
eNFA56_1 -->|"p"|eNFA56_3
eNFA57_1 -.->|"ε"|eNFA57_2
eNFA57_1 -->|"e"|eNFA57_3
eNFA58_1 -.->|"ε"|eNFA58_2
eNFA58_1 -->|"v"|eNFA58_3
eNFA59_1 -.->|"ε"|eNFA59_2
eNFA59_1 -->|"l"|eNFA59_3
eNFA60_1 -.->|"ε"|eNFA60_2
eNFA60_1 -->|"e"|eNFA60_3
eNFA61_1 -.->|"ε
ExtendToken 'identifier'"|eNFA61_2
eNFA61_1 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier'"|eNFA61_2
eNFA61_1 -.->|"ε
ExtendToken 'identifier'"|eNFA61_4
eNFA61_1 -.->|"ε"|eNFA61_5
eNFA61_1 -.->|"ε
AcceptToken 'identifier'"|eNFA61_6
eNFA61_1 -.->|"ε"|eNFA0_1
eNFA62_1 -.->|"ε
BeginToken 'literalString'"|eNFA62_2
eNFA62_1 -->|"#34;
BeginToken 'literalString'"|eNFA62_3
eNFA62_2 -->|"#34;
BeginToken 'literalString'"|eNFA62_3
eNFA63_1 -->|"[0-9]
ExtendToken 'number'"|eNFA63_1
eNFA63_1 -.->|"ε
ExtendToken 'number'"|eNFA63_6
eNFA63_1 -.->|"ε"|eNFA63_2
eNFA63_1 -.->|"ε
ExtendToken 'number'"|eNFA63_7
eNFA63_1 -->|"[.]"|eNFA63_3
eNFA63_1 -.->|"ε
ExtendToken 'number'"|eNFA63_9
eNFA63_1 -.->|"ε"|eNFA63_10
eNFA63_1 -.->|"ε
AcceptToken 'number'"|eNFA63_11
eNFA63_1 -.->|"ε"|eNFA0_1
eNFA64_1 -.->|"ε
BeginToken 'intConstant'"|eNFA64_2
eNFA64_1 -->|"[0-9]
BeginToken 'intConstant'
ExtendToken 'intConstant'"|eNFA64_3
eNFA64_2 -->|"[0-9]
BeginToken 'intConstant'
ExtendToken 'intConstant'"|eNFA64_3
eNFA65_1 -.->|"ε"|eNFA65_2
eNFA65_1 -->|"x"|eNFA65_3
eNFA66_1 -.->|"ε
BeginToken 'uintConstant'"|eNFA66_2
eNFA66_1 -->|"[0-9]
BeginToken 'uintConstant'"|eNFA66_3
eNFA66_2 -->|"[0-9]
BeginToken 'uintConstant'"|eNFA66_3
eNFA67_1 -.->|"ε"|eNFA67_2
eNFA67_1 -->|"x"|eNFA67_3
eNFA68_1 -.->|"ε
BeginToken 'floatConstant'"|eNFA68_2
eNFA68_1 -->|"[0-9]
BeginToken 'floatConstant'"|eNFA68_3
eNFA68_2 -->|"[0-9]
BeginToken 'floatConstant'"|eNFA68_3
eNFA69_1 -.->|"ε"|eNFA69_2
eNFA69_1 -->|"r"|eNFA69_3
eNFA70_1 -.->|"ε"|eNFA70_2
eNFA70_1 -->|"a"|eNFA70_3
eNFA71_1 -.->|"ε
BeginToken 'doubleConstant'"|eNFA71_2
eNFA71_1 -->|"[0-9]
BeginToken 'doubleConstant'
ExtendToken 'doubleConstant'"|eNFA71_3
eNFA71_2 -->|"[0-9]
BeginToken 'doubleConstant'
ExtendToken 'doubleConstant'"|eNFA71_3
eNFA72_1 -.->|"ε"|eNFA72_2
eNFA72_1 -->|"#92;/
ExtendToken 'inlineComment'"|eNFA72_3
eNFA62_3 -.->|"ε"|eNFA62_8
eNFA62_3 -.->|"ε"|eNFA62_4
eNFA62_3 -.->|"ε"|eNFA62_10
eNFA62_3 -.->|"ε"|eNFA62_9
eNFA62_3 -->|"#92;#92;"|eNFA62_5
eNFA62_3 -->|"[^#92;#92;#34;]"|eNFA62_11
eNFA62_3 -.->|"ε"|eNFA62_12
eNFA62_3 -->|"#34;
ExtendToken 'literalString'"|eNFA62_13
eNFA64_3 -->|"[0-9]
ExtendToken 'intConstant'"|eNFA64_3
eNFA64_3 -.->|"ε
ExtendToken 'intConstant'"|eNFA64_5
eNFA64_3 -.->|"ε"|eNFA64_6
eNFA64_3 -.->|"ε
AcceptToken 'intConstant'"|eNFA64_7
eNFA64_3 -.->|"ε"|eNFA0_1
eNFA66_3 -->|"[0-9]"|eNFA66_3
eNFA66_3 -.->|"ε"|eNFA66_4
eNFA66_3 -->|"[uU]
ExtendToken 'uintConstant'"|eNFA66_5
eNFA68_3 -->|"[0-9]"|eNFA68_3
eNFA68_3 -.->|"ε"|eNFA68_7
eNFA68_3 -.->|"ε"|eNFA68_4
eNFA68_3 -.->|"ε"|eNFA68_8
eNFA68_3 -->|"[.]"|eNFA68_5
eNFA68_3 -.->|"ε"|eNFA68_15
eNFA68_3 -.->|"ε"|eNFA68_9
eNFA68_3 -.->|"ε"|eNFA68_16
eNFA68_3 -->|"[Ee]"|eNFA68_10
eNFA68_3 -.->|"ε"|eNFA68_17
eNFA68_3 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA71_3 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_3
eNFA71_3 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_7
eNFA71_3 -.->|"ε"|eNFA71_4
eNFA71_3 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_8
eNFA71_3 -->|"[.]
ExtendToken 'doubleConstant'"|eNFA71_5
eNFA71_3 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_15
eNFA71_3 -.->|"ε"|eNFA71_9
eNFA71_3 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_3 -->|"[Ee]"|eNFA71_10
eNFA71_3 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_3 -.->|"ε"|eNFA71_19
eNFA71_3 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_3 -.->|"ε"|eNFA0_1
eNFA1_2 -->|"d"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -->|"e"|eNFA1_5
eNFA2_3 -.->|"ε"|eNFA2_4
eNFA2_3 -.->|"ε
AcceptToken '('"|eNFA2_5
eNFA2_3 -.->|"ε"|eNFA0_1
eNFA2_4 -.->|"ε
AcceptToken '('"|eNFA2_5
eNFA2_4 -.->|"ε"|eNFA0_1
eNFA2_5 -.->|"ε"|eNFA0_1
eNFA3_3 -.->|"ε"|eNFA3_4
eNFA3_3 -.->|"ε
AcceptToken ')'"|eNFA3_5
eNFA3_3 -.->|"ε"|eNFA0_1
eNFA3_4 -.->|"ε
AcceptToken ')'"|eNFA3_5
eNFA3_4 -.->|"ε"|eNFA0_1
eNFA3_5 -.->|"ε"|eNFA0_1
eNFA4_2 -->|"u"|eNFA4_3
eNFA4_3 -.->|"ε"|eNFA4_4
eNFA4_3 -->|"n"|eNFA4_5
eNFA5_3 -.->|"ε"|eNFA5_4
eNFA5_3 -.->|"ε
AcceptToken ','"|eNFA5_5
eNFA5_3 -.->|"ε"|eNFA0_1
eNFA5_4 -.->|"ε
AcceptToken ','"|eNFA5_5
eNFA5_4 -.->|"ε"|eNFA0_1
eNFA5_5 -.->|"ε"|eNFA0_1
eNFA6_3 -.->|"ε"|eNFA6_4
eNFA6_3 -.->|"ε
AcceptToken ';'"|eNFA6_5
eNFA6_3 -.->|"ε"|eNFA0_1
eNFA6_4 -.->|"ε
AcceptToken ';'"|eNFA6_5
eNFA6_4 -.->|"ε"|eNFA0_1
eNFA6_5 -.->|"ε"|eNFA0_1
eNFA7_3 -.->|"ε"|eNFA7_4
eNFA7_3 -.->|"ε
AcceptToken '['"|eNFA7_5
eNFA7_3 -.->|"ε"|eNFA0_1
eNFA7_4 -.->|"ε
AcceptToken '['"|eNFA7_5
eNFA7_4 -.->|"ε"|eNFA0_1
eNFA7_5 -.->|"ε"|eNFA0_1
eNFA8_3 -.->|"ε"|eNFA8_4
eNFA8_3 -.->|"ε
AcceptToken ']'"|eNFA8_5
eNFA8_3 -.->|"ε"|eNFA0_1
eNFA8_4 -.->|"ε
AcceptToken ']'"|eNFA8_5
eNFA8_4 -.->|"ε"|eNFA0_1
eNFA8_5 -.->|"ε"|eNFA0_1
eNFA9_3 -.->|"ε"|eNFA9_4
eNFA9_3 -.->|"ε
AcceptToken '.'"|eNFA9_5
eNFA9_3 -.->|"ε"|eNFA0_1
eNFA9_4 -.->|"ε
AcceptToken '.'"|eNFA9_5
eNFA9_4 -.->|"ε"|eNFA0_1
eNFA9_5 -.->|"ε"|eNFA0_1
eNFA10_2 -->|"#92;+
ExtendToken '++'"|eNFA10_3
eNFA10_3 -.->|"ε
ExtendToken '++'"|eNFA10_5
eNFA10_3 -.->|"ε"|eNFA10_6
eNFA10_3 -.->|"ε
AcceptToken '++'"|eNFA10_7
eNFA10_3 -.->|"ε"|eNFA0_1
eNFA11_2 -->|"-
ExtendToken '--'"|eNFA11_3
eNFA11_3 -.->|"ε
ExtendToken '--'"|eNFA11_5
eNFA11_3 -.->|"ε"|eNFA11_6
eNFA11_3 -.->|"ε
AcceptToken '--'"|eNFA11_7
eNFA11_3 -.->|"ε"|eNFA0_1
eNFA12_3 -.->|"ε"|eNFA12_4
eNFA12_3 -.->|"ε
AcceptToken '+'"|eNFA12_5
eNFA12_3 -.->|"ε"|eNFA0_1
eNFA12_4 -.->|"ε
AcceptToken '+'"|eNFA12_5
eNFA12_4 -.->|"ε"|eNFA0_1
eNFA12_5 -.->|"ε"|eNFA0_1
eNFA13_3 -.->|"ε"|eNFA13_4
eNFA13_3 -.->|"ε
AcceptToken '-'"|eNFA13_5
eNFA13_3 -.->|"ε"|eNFA0_1
eNFA13_4 -.->|"ε
AcceptToken '-'"|eNFA13_5
eNFA13_4 -.->|"ε"|eNFA0_1
eNFA13_5 -.->|"ε"|eNFA0_1
eNFA14_3 -.->|"ε"|eNFA14_4
eNFA14_3 -.->|"ε
AcceptToken '!'"|eNFA14_5
eNFA14_3 -.->|"ε"|eNFA0_1
eNFA14_4 -.->|"ε
AcceptToken '!'"|eNFA14_5
eNFA14_4 -.->|"ε"|eNFA0_1
eNFA14_5 -.->|"ε"|eNFA0_1
eNFA15_3 -.->|"ε"|eNFA15_4
eNFA15_3 -.->|"ε
AcceptToken '~'"|eNFA15_5
eNFA15_3 -.->|"ε"|eNFA0_1
eNFA15_4 -.->|"ε
AcceptToken '~'"|eNFA15_5
eNFA15_4 -.->|"ε"|eNFA0_1
eNFA15_5 -.->|"ε"|eNFA0_1
eNFA16_3 -.->|"ε"|eNFA16_4
eNFA16_3 -.->|"ε
AcceptToken '#42;'"|eNFA16_5
eNFA16_3 -.->|"ε"|eNFA0_1
eNFA16_4 -.->|"ε
AcceptToken '#42;'"|eNFA16_5
eNFA16_4 -.->|"ε"|eNFA0_1
eNFA16_5 -.->|"ε"|eNFA0_1
eNFA17_3 -.->|"ε"|eNFA17_4
eNFA17_3 -.->|"ε
AcceptToken '/'"|eNFA17_5
eNFA17_3 -.->|"ε"|eNFA0_1
eNFA17_4 -.->|"ε
AcceptToken '/'"|eNFA17_5
eNFA17_4 -.->|"ε"|eNFA0_1
eNFA17_5 -.->|"ε"|eNFA0_1
eNFA18_3 -.->|"ε"|eNFA18_4
eNFA18_3 -.->|"ε
AcceptToken '%'"|eNFA18_5
eNFA18_3 -.->|"ε"|eNFA0_1
eNFA18_4 -.->|"ε
AcceptToken '%'"|eNFA18_5
eNFA18_4 -.->|"ε"|eNFA0_1
eNFA18_5 -.->|"ε"|eNFA0_1
eNFA19_2 -->|"#92;<
ExtendToken '<<'"|eNFA19_3
eNFA19_3 -.->|"ε
ExtendToken '<<'"|eNFA19_5
eNFA19_3 -.->|"ε"|eNFA19_6
eNFA19_3 -.->|"ε
AcceptToken '<<'"|eNFA19_7
eNFA19_3 -.->|"ε"|eNFA0_1
eNFA20_2 -->|">
ExtendToken '>>'"|eNFA20_3
eNFA20_3 -.->|"ε
ExtendToken '>>'"|eNFA20_5
eNFA20_3 -.->|"ε"|eNFA20_6
eNFA20_3 -.->|"ε
AcceptToken '>>'"|eNFA20_7
eNFA20_3 -.->|"ε"|eNFA0_1
eNFA21_3 -.->|"ε"|eNFA21_4
eNFA21_3 -.->|"ε
AcceptToken '<'"|eNFA21_5
eNFA21_3 -.->|"ε"|eNFA0_1
eNFA21_4 -.->|"ε
AcceptToken '<'"|eNFA21_5
eNFA21_4 -.->|"ε"|eNFA0_1
eNFA21_5 -.->|"ε"|eNFA0_1
eNFA22_3 -.->|"ε"|eNFA22_4
eNFA22_3 -.->|"ε
AcceptToken '>'"|eNFA22_5
eNFA22_3 -.->|"ε"|eNFA0_1
eNFA22_4 -.->|"ε
AcceptToken '>'"|eNFA22_5
eNFA22_4 -.->|"ε"|eNFA0_1
eNFA22_5 -.->|"ε"|eNFA0_1
eNFA23_2 -->|"=
ExtendToken '<='"|eNFA23_3
eNFA23_3 -.->|"ε
ExtendToken '<='"|eNFA23_5
eNFA23_3 -.->|"ε"|eNFA23_6
eNFA23_3 -.->|"ε
AcceptToken '<='"|eNFA23_7
eNFA23_3 -.->|"ε"|eNFA0_1
eNFA24_2 -->|"=
ExtendToken '>='"|eNFA24_3
eNFA24_3 -.->|"ε
ExtendToken '>='"|eNFA24_5
eNFA24_3 -.->|"ε"|eNFA24_6
eNFA24_3 -.->|"ε
AcceptToken '>='"|eNFA24_7
eNFA24_3 -.->|"ε"|eNFA0_1
eNFA25_2 -->|"=
ExtendToken '=='"|eNFA25_3
eNFA25_3 -.->|"ε
ExtendToken '=='"|eNFA25_5
eNFA25_3 -.->|"ε"|eNFA25_6
eNFA25_3 -.->|"ε
AcceptToken '=='"|eNFA25_7
eNFA25_3 -.->|"ε"|eNFA0_1
eNFA26_2 -->|"=
ExtendToken '!='"|eNFA26_3
eNFA26_3 -.->|"ε
ExtendToken '!='"|eNFA26_5
eNFA26_3 -.->|"ε"|eNFA26_6
eNFA26_3 -.->|"ε
AcceptToken '!='"|eNFA26_7
eNFA26_3 -.->|"ε"|eNFA0_1
eNFA27_3 -.->|"ε"|eNFA27_4
eNFA27_3 -.->|"ε
AcceptToken '&'"|eNFA27_5
eNFA27_3 -.->|"ε"|eNFA0_1
eNFA27_4 -.->|"ε
AcceptToken '&'"|eNFA27_5
eNFA27_4 -.->|"ε"|eNFA0_1
eNFA27_5 -.->|"ε"|eNFA0_1
eNFA28_3 -.->|"ε"|eNFA28_4
eNFA28_3 -.->|"ε
AcceptToken '^'"|eNFA28_5
eNFA28_3 -.->|"ε"|eNFA0_1
eNFA28_4 -.->|"ε
AcceptToken '^'"|eNFA28_5
eNFA28_4 -.->|"ε"|eNFA0_1
eNFA28_5 -.->|"ε"|eNFA0_1
eNFA29_3 -.->|"ε"|eNFA29_4
eNFA29_3 -.->|"ε
AcceptToken '|'"|eNFA29_5
eNFA29_3 -.->|"ε"|eNFA0_1
eNFA29_4 -.->|"ε
AcceptToken '|'"|eNFA29_5
eNFA29_4 -.->|"ε"|eNFA0_1
eNFA29_5 -.->|"ε"|eNFA0_1
eNFA30_2 -->|"&
ExtendToken '&&'"|eNFA30_3
eNFA30_3 -.->|"ε
ExtendToken '&&'"|eNFA30_5
eNFA30_3 -.->|"ε"|eNFA30_6
eNFA30_3 -.->|"ε
AcceptToken '&&'"|eNFA30_7
eNFA30_3 -.->|"ε"|eNFA0_1
eNFA31_2 -->|"^
ExtendToken '^^'"|eNFA31_3
eNFA31_3 -.->|"ε
ExtendToken '^^'"|eNFA31_5
eNFA31_3 -.->|"ε"|eNFA31_6
eNFA31_3 -.->|"ε
AcceptToken '^^'"|eNFA31_7
eNFA31_3 -.->|"ε"|eNFA0_1
eNFA32_2 -->|"#92;|
ExtendToken '||'"|eNFA32_3
eNFA32_3 -.->|"ε
ExtendToken '||'"|eNFA32_5
eNFA32_3 -.->|"ε"|eNFA32_6
eNFA32_3 -.->|"ε
AcceptToken '||'"|eNFA32_7
eNFA32_3 -.->|"ε"|eNFA0_1
eNFA33_3 -.->|"ε"|eNFA33_4
eNFA33_3 -.->|"ε
AcceptToken '?'"|eNFA33_5
eNFA33_3 -.->|"ε"|eNFA0_1
eNFA33_4 -.->|"ε
AcceptToken '?'"|eNFA33_5
eNFA33_4 -.->|"ε"|eNFA0_1
eNFA33_5 -.->|"ε"|eNFA0_1
eNFA34_3 -.->|"ε"|eNFA34_4
eNFA34_3 -.->|"ε
AcceptToken ':'"|eNFA34_5
eNFA34_3 -.->|"ε"|eNFA0_1
eNFA34_4 -.->|"ε
AcceptToken ':'"|eNFA34_5
eNFA34_4 -.->|"ε"|eNFA0_1
eNFA34_5 -.->|"ε"|eNFA0_1
eNFA35_3 -.->|"ε"|eNFA35_4
eNFA35_3 -.->|"ε
AcceptToken '='"|eNFA35_5
eNFA35_3 -.->|"ε"|eNFA0_1
eNFA35_4 -.->|"ε
AcceptToken '='"|eNFA35_5
eNFA35_4 -.->|"ε"|eNFA0_1
eNFA35_5 -.->|"ε"|eNFA0_1
eNFA36_2 -->|"=
ExtendToken '#42;='"|eNFA36_3
eNFA36_3 -.->|"ε
ExtendToken '#42;='"|eNFA36_5
eNFA36_3 -.->|"ε"|eNFA36_6
eNFA36_3 -.->|"ε
AcceptToken '#42;='"|eNFA36_7
eNFA36_3 -.->|"ε"|eNFA0_1
eNFA37_2 -->|"=
ExtendToken '/='"|eNFA37_3
eNFA37_3 -.->|"ε
ExtendToken '/='"|eNFA37_5
eNFA37_3 -.->|"ε"|eNFA37_6
eNFA37_3 -.->|"ε
AcceptToken '/='"|eNFA37_7
eNFA37_3 -.->|"ε"|eNFA0_1
eNFA38_2 -->|"=
ExtendToken '%='"|eNFA38_3
eNFA38_3 -.->|"ε
ExtendToken '%='"|eNFA38_5
eNFA38_3 -.->|"ε"|eNFA38_6
eNFA38_3 -.->|"ε
AcceptToken '%='"|eNFA38_7
eNFA38_3 -.->|"ε"|eNFA0_1
eNFA39_2 -->|"=
ExtendToken '+='"|eNFA39_3
eNFA39_3 -.->|"ε
ExtendToken '+='"|eNFA39_5
eNFA39_3 -.->|"ε"|eNFA39_6
eNFA39_3 -.->|"ε
AcceptToken '+='"|eNFA39_7
eNFA39_3 -.->|"ε"|eNFA0_1
eNFA40_2 -->|"=
ExtendToken '-='"|eNFA40_3
eNFA40_3 -.->|"ε
ExtendToken '-='"|eNFA40_5
eNFA40_3 -.->|"ε"|eNFA40_6
eNFA40_3 -.->|"ε
AcceptToken '-='"|eNFA40_7
eNFA40_3 -.->|"ε"|eNFA0_1
eNFA41_2 -->|"#92;<"|eNFA41_3
eNFA41_3 -.->|"ε"|eNFA41_4
eNFA41_3 -->|"=
ExtendToken '<<='"|eNFA41_5
eNFA42_2 -->|">"|eNFA42_3
eNFA42_3 -.->|"ε"|eNFA42_4
eNFA42_3 -->|"=
ExtendToken '>>='"|eNFA42_5
eNFA43_2 -->|"=
ExtendToken '&='"|eNFA43_3
eNFA43_3 -.->|"ε
ExtendToken '&='"|eNFA43_5
eNFA43_3 -.->|"ε"|eNFA43_6
eNFA43_3 -.->|"ε
AcceptToken '&='"|eNFA43_7
eNFA43_3 -.->|"ε"|eNFA0_1
eNFA44_2 -->|"=
ExtendToken '^='"|eNFA44_3
eNFA44_3 -.->|"ε
ExtendToken '^='"|eNFA44_5
eNFA44_3 -.->|"ε"|eNFA44_6
eNFA44_3 -.->|"ε
AcceptToken '^='"|eNFA44_7
eNFA44_3 -.->|"ε"|eNFA0_1
eNFA45_2 -->|"=
ExtendToken '|='"|eNFA45_3
eNFA45_3 -.->|"ε
ExtendToken '|='"|eNFA45_5
eNFA45_3 -.->|"ε"|eNFA45_6
eNFA45_3 -.->|"ε
AcceptToken '|='"|eNFA45_7
eNFA45_3 -.->|"ε"|eNFA0_1
eNFA46_3 -.->|"ε"|eNFA46_4
eNFA46_3 -.->|"ε
AcceptToken '{'"|eNFA46_5
eNFA46_3 -.->|"ε"|eNFA0_1
eNFA46_4 -.->|"ε
AcceptToken '{'"|eNFA46_5
eNFA46_4 -.->|"ε"|eNFA0_1
eNFA46_5 -.->|"ε"|eNFA0_1
eNFA47_3 -.->|"ε"|eNFA47_4
eNFA47_3 -.->|"ε
AcceptToken '}'"|eNFA47_5
eNFA47_3 -.->|"ε"|eNFA0_1
eNFA47_4 -.->|"ε
AcceptToken '}'"|eNFA47_5
eNFA47_4 -.->|"ε"|eNFA0_1
eNFA47_5 -.->|"ε"|eNFA0_1
eNFA48_2 -->|"#35;
ExtendToken '#35;#35;'"|eNFA48_3
eNFA48_3 -.->|"ε
ExtendToken '#35;#35;'"|eNFA48_5
eNFA48_3 -.->|"ε"|eNFA48_6
eNFA48_3 -.->|"ε
AcceptToken '#35;#35;'"|eNFA48_7
eNFA48_3 -.->|"ε"|eNFA0_1
eNFA49_2 -->|"i"|eNFA49_3
eNFA49_3 -.->|"ε"|eNFA49_4
eNFA49_3 -->|"f
ExtendToken '#35;if'"|eNFA49_5
eNFA50_2 -->|"i"|eNFA50_3
eNFA50_3 -.->|"ε"|eNFA50_4
eNFA50_3 -->|"f"|eNFA50_5
eNFA51_2 -->|"i"|eNFA51_3
eNFA51_3 -.->|"ε"|eNFA51_4
eNFA51_3 -->|"f"|eNFA51_5
eNFA52_2 -->|"e"|eNFA52_3
eNFA52_3 -.->|"ε"|eNFA52_4
eNFA52_3 -->|"l"|eNFA52_5
eNFA53_2 -->|"e"|eNFA53_3
eNFA53_3 -.->|"ε"|eNFA53_4
eNFA53_3 -->|"l"|eNFA53_5
eNFA54_2 -->|"e"|eNFA54_3
eNFA54_3 -.->|"ε"|eNFA54_4
eNFA54_3 -->|"n"|eNFA54_5
eNFA55_2 -->|"e"|eNFA55_3
eNFA55_3 -.->|"ε"|eNFA55_4
eNFA55_3 -->|"r"|eNFA55_5
eNFA56_2 -->|"p"|eNFA56_3
eNFA56_3 -.->|"ε"|eNFA56_4
eNFA56_3 -->|"r"|eNFA56_5
eNFA57_2 -->|"e"|eNFA57_3
eNFA57_3 -.->|"ε"|eNFA57_4
eNFA57_3 -->|"x"|eNFA57_5
eNFA58_2 -->|"v"|eNFA58_3
eNFA58_3 -.->|"ε"|eNFA58_4
eNFA58_3 -->|"e"|eNFA58_5
eNFA59_2 -->|"l"|eNFA59_3
eNFA59_3 -.->|"ε"|eNFA59_4
eNFA59_3 -->|"i"|eNFA59_5
eNFA60_2 -->|"e"|eNFA60_3
eNFA60_3 -.->|"ε"|eNFA60_4
eNFA60_3 -->|"f"|eNFA60_5
eNFA61_2 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier'"|eNFA61_2
eNFA61_2 -.->|"ε
ExtendToken 'identifier'"|eNFA61_4
eNFA61_2 -.->|"ε"|eNFA61_5
eNFA61_2 -.->|"ε
AcceptToken 'identifier'"|eNFA61_6
eNFA61_2 -.->|"ε"|eNFA0_1
eNFA61_4 -.->|"ε"|eNFA61_5
eNFA61_4 -.->|"ε
AcceptToken 'identifier'"|eNFA61_6
eNFA61_4 -.->|"ε"|eNFA0_1
eNFA61_5 -.->|"ε
AcceptToken 'identifier'"|eNFA61_6
eNFA61_5 -.->|"ε"|eNFA0_1
eNFA61_6 -.->|"ε"|eNFA0_1
eNFA63_6 -.->|"ε"|eNFA63_2
eNFA63_6 -.->|"ε
ExtendToken 'number'"|eNFA63_7
eNFA63_6 -->|"[.]"|eNFA63_3
eNFA63_6 -.->|"ε
ExtendToken 'number'"|eNFA63_9
eNFA63_6 -.->|"ε"|eNFA63_10
eNFA63_6 -.->|"ε
AcceptToken 'number'"|eNFA63_11
eNFA63_6 -.->|"ε"|eNFA0_1
eNFA63_2 -->|"[.]"|eNFA63_3
eNFA63_7 -.->|"ε
ExtendToken 'number'"|eNFA63_9
eNFA63_7 -.->|"ε"|eNFA63_10
eNFA63_7 -.->|"ε
AcceptToken 'number'"|eNFA63_11
eNFA63_7 -.->|"ε"|eNFA0_1
eNFA63_3 -.->|"ε"|eNFA63_4
eNFA63_3 -->|"[0-9]
ExtendToken 'number'"|eNFA63_5
eNFA63_9 -.->|"ε"|eNFA63_10
eNFA63_9 -.->|"ε
AcceptToken 'number'"|eNFA63_11
eNFA63_9 -.->|"ε"|eNFA0_1
eNFA63_10 -.->|"ε
AcceptToken 'number'"|eNFA63_11
eNFA63_10 -.->|"ε"|eNFA0_1
eNFA63_11 -.->|"ε"|eNFA0_1
eNFA65_2 -->|"x"|eNFA65_3
eNFA65_3 -.->|"ε"|eNFA65_4
eNFA65_3 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant'"|eNFA65_5
eNFA67_2 -->|"x"|eNFA67_3
eNFA67_3 -.->|"ε"|eNFA67_4
eNFA67_3 -->|"[0-9A-Fa-f]"|eNFA67_5
eNFA69_2 -->|"r"|eNFA69_3
eNFA69_3 -.->|"ε"|eNFA69_4
eNFA69_3 -->|"u"|eNFA69_5
eNFA70_2 -->|"a"|eNFA70_3
eNFA70_3 -.->|"ε"|eNFA70_4
eNFA70_3 -->|"l"|eNFA70_5
eNFA72_2 -->|"#92;/
ExtendToken 'inlineComment'"|eNFA72_3
eNFA72_3 -.->|"ε
ExtendToken 'inlineComment'"|eNFA72_4
eNFA72_3 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment'"|eNFA72_4
eNFA72_3 -.->|"ε
ExtendToken 'inlineComment'"|eNFA72_6
eNFA72_3 -.->|"ε"|eNFA72_7
eNFA72_3 -.->|"ε
AcceptToken 'inlineComment'"|eNFA72_8
eNFA72_3 -.->|"ε"|eNFA0_1
eNFA62_8 -.->|"ε"|eNFA62_4
eNFA62_8 -.->|"ε"|eNFA62_10
eNFA62_8 -.->|"ε"|eNFA62_9
eNFA62_8 -->|"#92;#92;"|eNFA62_5
eNFA62_8 -->|"[^#92;#92;#34;]"|eNFA62_11
eNFA62_8 -.->|"ε"|eNFA62_8
eNFA62_8 -.->|"ε"|eNFA62_12
eNFA62_8 -->|"#34;
ExtendToken 'literalString'"|eNFA62_13
eNFA62_4 -->|"#92;#92;"|eNFA62_5
eNFA62_10 -->|"[^#92;#92;#34;]"|eNFA62_11
eNFA62_9 -.->|"ε"|eNFA62_8
eNFA62_9 -.->|"ε"|eNFA62_12
eNFA62_9 -.->|"ε"|eNFA62_4
eNFA62_9 -.->|"ε"|eNFA62_10
eNFA62_9 -.->|"ε"|eNFA62_9
eNFA62_9 -->|"#92;#92;"|eNFA62_5
eNFA62_9 -->|"[^#92;#92;#34;]"|eNFA62_11
eNFA62_9 -->|"#34;
ExtendToken 'literalString'"|eNFA62_13
eNFA62_5 -.->|"ε"|eNFA62_6
eNFA62_5 -->|"[#32;-~]"|eNFA62_7
eNFA62_11 -.->|"ε"|eNFA62_9
eNFA62_11 -.->|"ε"|eNFA62_8
eNFA62_11 -.->|"ε"|eNFA62_12
eNFA62_11 -.->|"ε"|eNFA62_4
eNFA62_11 -.->|"ε"|eNFA62_10
eNFA62_11 -->|"#92;#92;"|eNFA62_5
eNFA62_11 -->|"[^#92;#92;#34;]"|eNFA62_11
eNFA62_11 -->|"#34;
ExtendToken 'literalString'"|eNFA62_13
eNFA62_12 -->|"#34;
ExtendToken 'literalString'"|eNFA62_13
eNFA62_13 -.->|"ε
ExtendToken 'literalString'"|eNFA62_15
eNFA62_13 -.->|"ε"|eNFA62_16
eNFA62_13 -.->|"ε
AcceptToken 'literalString'"|eNFA62_17
eNFA62_13 -.->|"ε"|eNFA0_1
eNFA64_5 -.->|"ε"|eNFA64_6
eNFA64_5 -.->|"ε
AcceptToken 'intConstant'"|eNFA64_7
eNFA64_5 -.->|"ε"|eNFA0_1
eNFA64_6 -.->|"ε
AcceptToken 'intConstant'"|eNFA64_7
eNFA64_6 -.->|"ε"|eNFA0_1
eNFA64_7 -.->|"ε"|eNFA0_1
eNFA66_4 -->|"[uU]
ExtendToken 'uintConstant'"|eNFA66_5
eNFA66_5 -.->|"ε
ExtendToken 'uintConstant'"|eNFA66_7
eNFA66_5 -.->|"ε"|eNFA66_8
eNFA66_5 -.->|"ε
AcceptToken 'uintConstant'"|eNFA66_9
eNFA66_5 -.->|"ε"|eNFA0_1
eNFA68_7 -.->|"ε"|eNFA68_4
eNFA68_7 -.->|"ε"|eNFA68_8
eNFA68_7 -->|"[.]"|eNFA68_5
eNFA68_7 -.->|"ε"|eNFA68_15
eNFA68_7 -.->|"ε"|eNFA68_9
eNFA68_7 -.->|"ε"|eNFA68_16
eNFA68_7 -->|"[Ee]"|eNFA68_10
eNFA68_7 -.->|"ε"|eNFA68_17
eNFA68_7 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_4 -->|"[.]"|eNFA68_5
eNFA68_8 -.->|"ε"|eNFA68_15
eNFA68_8 -.->|"ε"|eNFA68_9
eNFA68_8 -.->|"ε"|eNFA68_16
eNFA68_8 -->|"[Ee]"|eNFA68_10
eNFA68_8 -.->|"ε"|eNFA68_17
eNFA68_8 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_5 -.->|"ε"|eNFA68_6
eNFA68_5 -->|"[0-9]"|eNFA68_6
eNFA68_5 -.->|"ε"|eNFA68_8
eNFA68_5 -.->|"ε"|eNFA68_7
eNFA68_5 -.->|"ε"|eNFA68_4
eNFA68_5 -.->|"ε"|eNFA68_8
eNFA68_5 -->|"[.]"|eNFA68_5
eNFA68_5 -.->|"ε"|eNFA68_15
eNFA68_5 -.->|"ε"|eNFA68_9
eNFA68_5 -.->|"ε"|eNFA68_16
eNFA68_5 -->|"[Ee]"|eNFA68_10
eNFA68_5 -.->|"ε"|eNFA68_17
eNFA68_5 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_15 -.->|"ε"|eNFA68_9
eNFA68_15 -.->|"ε"|eNFA68_16
eNFA68_15 -->|"[Ee]"|eNFA68_10
eNFA68_15 -.->|"ε"|eNFA68_17
eNFA68_15 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_9 -->|"[Ee]"|eNFA68_10
eNFA68_16 -.->|"ε"|eNFA68_17
eNFA68_16 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_10 -.->|"ε"|eNFA68_11
eNFA68_10 -->|"[-+]"|eNFA68_12
eNFA68_10 -.->|"ε"|eNFA68_12
eNFA68_10 -.->|"ε"|eNFA68_13
eNFA68_10 -->|"[0-9]"|eNFA68_14
eNFA68_17 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_18 -.->|"ε
ExtendToken 'floatConstant'"|eNFA68_20
eNFA68_18 -.->|"ε"|eNFA68_21
eNFA68_18 -.->|"ε
AcceptToken 'floatConstant'"|eNFA68_22
eNFA68_18 -.->|"ε"|eNFA0_1
eNFA71_7 -.->|"ε"|eNFA71_4
eNFA71_7 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_8
eNFA71_7 -->|"[.]
ExtendToken 'doubleConstant'"|eNFA71_5
eNFA71_7 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_15
eNFA71_7 -.->|"ε"|eNFA71_9
eNFA71_7 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_7 -->|"[Ee]"|eNFA71_10
eNFA71_7 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_7 -.->|"ε"|eNFA71_19
eNFA71_7 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_7 -.->|"ε"|eNFA0_1
eNFA71_4 -->|"[.]
ExtendToken 'doubleConstant'"|eNFA71_5
eNFA71_8 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_15
eNFA71_8 -.->|"ε"|eNFA71_9
eNFA71_8 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_8 -->|"[Ee]"|eNFA71_10
eNFA71_8 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_8 -.->|"ε"|eNFA71_19
eNFA71_8 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_8 -.->|"ε"|eNFA0_1
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_6
eNFA71_5 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_6
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_8
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_7
eNFA71_5 -.->|"ε"|eNFA71_4
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_8
eNFA71_5 -->|"[.]
ExtendToken 'doubleConstant'"|eNFA71_5
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_15
eNFA71_5 -.->|"ε"|eNFA71_9
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_5 -->|"[Ee]"|eNFA71_10
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_5 -.->|"ε"|eNFA71_19
eNFA71_5 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_5 -.->|"ε"|eNFA0_1
eNFA71_15 -.->|"ε"|eNFA71_9
eNFA71_15 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_15 -->|"[Ee]"|eNFA71_10
eNFA71_15 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_15 -.->|"ε"|eNFA71_19
eNFA71_15 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_15 -.->|"ε"|eNFA0_1
eNFA71_9 -->|"[Ee]"|eNFA71_10
eNFA71_16 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_16 -.->|"ε"|eNFA71_19
eNFA71_16 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_16 -.->|"ε"|eNFA0_1
eNFA71_10 -.->|"ε"|eNFA71_11
eNFA71_10 -->|"[-+]"|eNFA71_12
eNFA71_10 -.->|"ε"|eNFA71_12
eNFA71_10 -.->|"ε"|eNFA71_13
eNFA71_10 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_14
eNFA71_18 -.->|"ε"|eNFA71_19
eNFA71_18 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_18 -.->|"ε"|eNFA0_1
eNFA71_19 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_19 -.->|"ε"|eNFA0_1
eNFA71_20 -.->|"ε"|eNFA0_1
eNFA1_4 -->|"e"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -->|"f"|eNFA1_7
eNFA4_4 -->|"n"|eNFA4_5
eNFA4_5 -.->|"ε"|eNFA4_6
eNFA4_5 -->|"d"|eNFA4_7
eNFA10_5 -.->|"ε"|eNFA10_6
eNFA10_5 -.->|"ε
AcceptToken '++'"|eNFA10_7
eNFA10_5 -.->|"ε"|eNFA0_1
eNFA10_6 -.->|"ε
AcceptToken '++'"|eNFA10_7
eNFA10_6 -.->|"ε"|eNFA0_1
eNFA10_7 -.->|"ε"|eNFA0_1
eNFA11_5 -.->|"ε"|eNFA11_6
eNFA11_5 -.->|"ε
AcceptToken '--'"|eNFA11_7
eNFA11_5 -.->|"ε"|eNFA0_1
eNFA11_6 -.->|"ε
AcceptToken '--'"|eNFA11_7
eNFA11_6 -.->|"ε"|eNFA0_1
eNFA11_7 -.->|"ε"|eNFA0_1
eNFA19_5 -.->|"ε"|eNFA19_6
eNFA19_5 -.->|"ε
AcceptToken '<<'"|eNFA19_7
eNFA19_5 -.->|"ε"|eNFA0_1
eNFA19_6 -.->|"ε
AcceptToken '<<'"|eNFA19_7
eNFA19_6 -.->|"ε"|eNFA0_1
eNFA19_7 -.->|"ε"|eNFA0_1
eNFA20_5 -.->|"ε"|eNFA20_6
eNFA20_5 -.->|"ε
AcceptToken '>>'"|eNFA20_7
eNFA20_5 -.->|"ε"|eNFA0_1
eNFA20_6 -.->|"ε
AcceptToken '>>'"|eNFA20_7
eNFA20_6 -.->|"ε"|eNFA0_1
eNFA20_7 -.->|"ε"|eNFA0_1
eNFA23_5 -.->|"ε"|eNFA23_6
eNFA23_5 -.->|"ε
AcceptToken '<='"|eNFA23_7
eNFA23_5 -.->|"ε"|eNFA0_1
eNFA23_6 -.->|"ε
AcceptToken '<='"|eNFA23_7
eNFA23_6 -.->|"ε"|eNFA0_1
eNFA23_7 -.->|"ε"|eNFA0_1
eNFA24_5 -.->|"ε"|eNFA24_6
eNFA24_5 -.->|"ε
AcceptToken '>='"|eNFA24_7
eNFA24_5 -.->|"ε"|eNFA0_1
eNFA24_6 -.->|"ε
AcceptToken '>='"|eNFA24_7
eNFA24_6 -.->|"ε"|eNFA0_1
eNFA24_7 -.->|"ε"|eNFA0_1
eNFA25_5 -.->|"ε"|eNFA25_6
eNFA25_5 -.->|"ε
AcceptToken '=='"|eNFA25_7
eNFA25_5 -.->|"ε"|eNFA0_1
eNFA25_6 -.->|"ε
AcceptToken '=='"|eNFA25_7
eNFA25_6 -.->|"ε"|eNFA0_1
eNFA25_7 -.->|"ε"|eNFA0_1
eNFA26_5 -.->|"ε"|eNFA26_6
eNFA26_5 -.->|"ε
AcceptToken '!='"|eNFA26_7
eNFA26_5 -.->|"ε"|eNFA0_1
eNFA26_6 -.->|"ε
AcceptToken '!='"|eNFA26_7
eNFA26_6 -.->|"ε"|eNFA0_1
eNFA26_7 -.->|"ε"|eNFA0_1
eNFA30_5 -.->|"ε"|eNFA30_6
eNFA30_5 -.->|"ε
AcceptToken '&&'"|eNFA30_7
eNFA30_5 -.->|"ε"|eNFA0_1
eNFA30_6 -.->|"ε
AcceptToken '&&'"|eNFA30_7
eNFA30_6 -.->|"ε"|eNFA0_1
eNFA30_7 -.->|"ε"|eNFA0_1
eNFA31_5 -.->|"ε"|eNFA31_6
eNFA31_5 -.->|"ε
AcceptToken '^^'"|eNFA31_7
eNFA31_5 -.->|"ε"|eNFA0_1
eNFA31_6 -.->|"ε
AcceptToken '^^'"|eNFA31_7
eNFA31_6 -.->|"ε"|eNFA0_1
eNFA31_7 -.->|"ε"|eNFA0_1
eNFA32_5 -.->|"ε"|eNFA32_6
eNFA32_5 -.->|"ε
AcceptToken '||'"|eNFA32_7
eNFA32_5 -.->|"ε"|eNFA0_1
eNFA32_6 -.->|"ε
AcceptToken '||'"|eNFA32_7
eNFA32_6 -.->|"ε"|eNFA0_1
eNFA32_7 -.->|"ε"|eNFA0_1
eNFA36_5 -.->|"ε"|eNFA36_6
eNFA36_5 -.->|"ε
AcceptToken '#42;='"|eNFA36_7
eNFA36_5 -.->|"ε"|eNFA0_1
eNFA36_6 -.->|"ε
AcceptToken '#42;='"|eNFA36_7
eNFA36_6 -.->|"ε"|eNFA0_1
eNFA36_7 -.->|"ε"|eNFA0_1
eNFA37_5 -.->|"ε"|eNFA37_6
eNFA37_5 -.->|"ε
AcceptToken '/='"|eNFA37_7
eNFA37_5 -.->|"ε"|eNFA0_1
eNFA37_6 -.->|"ε
AcceptToken '/='"|eNFA37_7
eNFA37_6 -.->|"ε"|eNFA0_1
eNFA37_7 -.->|"ε"|eNFA0_1
eNFA38_5 -.->|"ε"|eNFA38_6
eNFA38_5 -.->|"ε
AcceptToken '%='"|eNFA38_7
eNFA38_5 -.->|"ε"|eNFA0_1
eNFA38_6 -.->|"ε
AcceptToken '%='"|eNFA38_7
eNFA38_6 -.->|"ε"|eNFA0_1
eNFA38_7 -.->|"ε"|eNFA0_1
eNFA39_5 -.->|"ε"|eNFA39_6
eNFA39_5 -.->|"ε
AcceptToken '+='"|eNFA39_7
eNFA39_5 -.->|"ε"|eNFA0_1
eNFA39_6 -.->|"ε
AcceptToken '+='"|eNFA39_7
eNFA39_6 -.->|"ε"|eNFA0_1
eNFA39_7 -.->|"ε"|eNFA0_1
eNFA40_5 -.->|"ε"|eNFA40_6
eNFA40_5 -.->|"ε
AcceptToken '-='"|eNFA40_7
eNFA40_5 -.->|"ε"|eNFA0_1
eNFA40_6 -.->|"ε
AcceptToken '-='"|eNFA40_7
eNFA40_6 -.->|"ε"|eNFA0_1
eNFA40_7 -.->|"ε"|eNFA0_1
eNFA41_4 -->|"=
ExtendToken '<<='"|eNFA41_5
eNFA41_5 -.->|"ε
ExtendToken '<<='"|eNFA41_7
eNFA41_5 -.->|"ε"|eNFA41_8
eNFA41_5 -.->|"ε
AcceptToken '<<='"|eNFA41_9
eNFA41_5 -.->|"ε"|eNFA0_1
eNFA42_4 -->|"=
ExtendToken '>>='"|eNFA42_5
eNFA42_5 -.->|"ε
ExtendToken '>>='"|eNFA42_7
eNFA42_5 -.->|"ε"|eNFA42_8
eNFA42_5 -.->|"ε
AcceptToken '>>='"|eNFA42_9
eNFA42_5 -.->|"ε"|eNFA0_1
eNFA43_5 -.->|"ε"|eNFA43_6
eNFA43_5 -.->|"ε
AcceptToken '&='"|eNFA43_7
eNFA43_5 -.->|"ε"|eNFA0_1
eNFA43_6 -.->|"ε
AcceptToken '&='"|eNFA43_7
eNFA43_6 -.->|"ε"|eNFA0_1
eNFA43_7 -.->|"ε"|eNFA0_1
eNFA44_5 -.->|"ε"|eNFA44_6
eNFA44_5 -.->|"ε
AcceptToken '^='"|eNFA44_7
eNFA44_5 -.->|"ε"|eNFA0_1
eNFA44_6 -.->|"ε
AcceptToken '^='"|eNFA44_7
eNFA44_6 -.->|"ε"|eNFA0_1
eNFA44_7 -.->|"ε"|eNFA0_1
eNFA45_5 -.->|"ε"|eNFA45_6
eNFA45_5 -.->|"ε
AcceptToken '|='"|eNFA45_7
eNFA45_5 -.->|"ε"|eNFA0_1
eNFA45_6 -.->|"ε
AcceptToken '|='"|eNFA45_7
eNFA45_6 -.->|"ε"|eNFA0_1
eNFA45_7 -.->|"ε"|eNFA0_1
eNFA48_5 -.->|"ε"|eNFA48_6
eNFA48_5 -.->|"ε
AcceptToken '#35;#35;'"|eNFA48_7
eNFA48_5 -.->|"ε"|eNFA0_1
eNFA48_6 -.->|"ε
AcceptToken '#35;#35;'"|eNFA48_7
eNFA48_6 -.->|"ε"|eNFA0_1
eNFA48_7 -.->|"ε"|eNFA0_1
eNFA49_4 -->|"f
ExtendToken '#35;if'"|eNFA49_5
eNFA49_5 -.->|"ε
ExtendToken '#35;if'"|eNFA49_7
eNFA49_5 -.->|"ε"|eNFA49_8
eNFA49_5 -.->|"ε
AcceptToken '#35;if'"|eNFA49_9
eNFA49_5 -.->|"ε"|eNFA0_1
eNFA50_4 -->|"f"|eNFA50_5
eNFA50_5 -.->|"ε"|eNFA50_6
eNFA50_5 -->|"d"|eNFA50_7
eNFA51_4 -->|"f"|eNFA51_5
eNFA51_5 -.->|"ε"|eNFA51_6
eNFA51_5 -->|"n"|eNFA51_7
eNFA52_4 -->|"l"|eNFA52_5
eNFA52_5 -.->|"ε"|eNFA52_6
eNFA52_5 -->|"s"|eNFA52_7
eNFA53_4 -->|"l"|eNFA53_5
eNFA53_5 -.->|"ε"|eNFA53_6
eNFA53_5 -->|"i"|eNFA53_7
eNFA54_4 -->|"n"|eNFA54_5
eNFA54_5 -.->|"ε"|eNFA54_6
eNFA54_5 -->|"d"|eNFA54_7
eNFA55_4 -->|"r"|eNFA55_5
eNFA55_5 -.->|"ε"|eNFA55_6
eNFA55_5 -->|"r"|eNFA55_7
eNFA56_4 -->|"r"|eNFA56_5
eNFA56_5 -.->|"ε"|eNFA56_6
eNFA56_5 -->|"a"|eNFA56_7
eNFA57_4 -->|"x"|eNFA57_5
eNFA57_5 -.->|"ε"|eNFA57_6
eNFA57_5 -->|"t"|eNFA57_7
eNFA58_4 -->|"e"|eNFA58_5
eNFA58_5 -.->|"ε"|eNFA58_6
eNFA58_5 -->|"r"|eNFA58_7
eNFA59_4 -->|"i"|eNFA59_5
eNFA59_5 -.->|"ε"|eNFA59_6
eNFA59_5 -->|"n"|eNFA59_7
eNFA60_4 -->|"f"|eNFA60_5
eNFA60_5 -.->|"ε"|eNFA60_6
eNFA60_5 -->|"i"|eNFA60_7
eNFA63_4 -->|"[0-9]
ExtendToken 'number'"|eNFA63_5
eNFA63_5 -->|"[0-9]
ExtendToken 'number'"|eNFA63_5
eNFA63_5 -.->|"ε
ExtendToken 'number'"|eNFA63_7
eNFA63_5 -.->|"ε
ExtendToken 'number'"|eNFA63_6
eNFA63_5 -.->|"ε"|eNFA63_2
eNFA63_5 -.->|"ε
ExtendToken 'number'"|eNFA63_7
eNFA63_5 -->|"[.]"|eNFA63_3
eNFA63_5 -.->|"ε
ExtendToken 'number'"|eNFA63_9
eNFA63_5 -.->|"ε"|eNFA63_10
eNFA63_5 -.->|"ε
AcceptToken 'number'"|eNFA63_11
eNFA63_5 -.->|"ε"|eNFA0_1
eNFA65_4 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant'"|eNFA65_5
eNFA65_5 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant'"|eNFA65_5
eNFA65_5 -.->|"ε
ExtendToken 'intConstant'"|eNFA65_7
eNFA65_5 -.->|"ε"|eNFA65_8
eNFA65_5 -.->|"ε
AcceptToken 'intConstant'"|eNFA65_9
eNFA65_5 -.->|"ε"|eNFA0_1
eNFA67_4 -->|"[0-9A-Fa-f]"|eNFA67_5
eNFA67_5 -->|"[0-9A-Fa-f]"|eNFA67_5
eNFA67_5 -.->|"ε"|eNFA67_6
eNFA67_5 -->|"[uU]
ExtendToken 'uintConstant'"|eNFA67_7
eNFA69_4 -->|"u"|eNFA69_5
eNFA69_5 -.->|"ε"|eNFA69_6
eNFA69_5 -->|"e
ExtendToken 'boolConstant'"|eNFA69_7
eNFA70_4 -->|"l"|eNFA70_5
eNFA70_5 -.->|"ε"|eNFA70_6
eNFA70_5 -->|"s"|eNFA70_7
eNFA72_4 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment'"|eNFA72_4
eNFA72_4 -.->|"ε
ExtendToken 'inlineComment'"|eNFA72_6
eNFA72_4 -.->|"ε"|eNFA72_7
eNFA72_4 -.->|"ε
AcceptToken 'inlineComment'"|eNFA72_8
eNFA72_4 -.->|"ε"|eNFA0_1
eNFA72_6 -.->|"ε"|eNFA72_7
eNFA72_6 -.->|"ε
AcceptToken 'inlineComment'"|eNFA72_8
eNFA72_6 -.->|"ε"|eNFA0_1
eNFA72_7 -.->|"ε
AcceptToken 'inlineComment'"|eNFA72_8
eNFA72_7 -.->|"ε"|eNFA0_1
eNFA72_8 -.->|"ε"|eNFA0_1
eNFA62_6 -->|"[#32;-~]"|eNFA62_7
eNFA62_7 -.->|"ε"|eNFA62_9
eNFA62_7 -.->|"ε"|eNFA62_8
eNFA62_7 -.->|"ε"|eNFA62_12
eNFA62_7 -.->|"ε"|eNFA62_4
eNFA62_7 -.->|"ε"|eNFA62_10
eNFA62_7 -->|"#92;#92;"|eNFA62_5
eNFA62_7 -->|"[^#92;#92;#34;]"|eNFA62_11
eNFA62_7 -->|"#34;
ExtendToken 'literalString'"|eNFA62_13
eNFA62_15 -.->|"ε"|eNFA62_16
eNFA62_15 -.->|"ε
AcceptToken 'literalString'"|eNFA62_17
eNFA62_15 -.->|"ε"|eNFA0_1
eNFA62_16 -.->|"ε
AcceptToken 'literalString'"|eNFA62_17
eNFA62_16 -.->|"ε"|eNFA0_1
eNFA62_17 -.->|"ε"|eNFA0_1
eNFA66_7 -.->|"ε"|eNFA66_8
eNFA66_7 -.->|"ε
AcceptToken 'uintConstant'"|eNFA66_9
eNFA66_7 -.->|"ε"|eNFA0_1
eNFA66_8 -.->|"ε
AcceptToken 'uintConstant'"|eNFA66_9
eNFA66_8 -.->|"ε"|eNFA0_1
eNFA66_9 -.->|"ε"|eNFA0_1
eNFA68_6 -->|"[0-9]"|eNFA68_6
eNFA68_6 -.->|"ε"|eNFA68_8
eNFA68_6 -.->|"ε"|eNFA68_7
eNFA68_6 -.->|"ε"|eNFA68_4
eNFA68_6 -.->|"ε"|eNFA68_8
eNFA68_6 -->|"[.]"|eNFA68_5
eNFA68_6 -.->|"ε"|eNFA68_15
eNFA68_6 -.->|"ε"|eNFA68_9
eNFA68_6 -.->|"ε"|eNFA68_16
eNFA68_6 -->|"[Ee]"|eNFA68_10
eNFA68_6 -.->|"ε"|eNFA68_17
eNFA68_6 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_8 -.->|"ε"|eNFA68_7
eNFA68_8 -.->|"ε"|eNFA68_4
eNFA68_8 -.->|"ε"|eNFA68_8
eNFA68_8 -->|"[.]"|eNFA68_5
eNFA68_8 -.->|"ε"|eNFA68_15
eNFA68_8 -.->|"ε"|eNFA68_9
eNFA68_8 -.->|"ε"|eNFA68_16
eNFA68_8 -->|"[Ee]"|eNFA68_10
eNFA68_8 -.->|"ε"|eNFA68_17
eNFA68_8 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_7 -.->|"ε"|eNFA68_4
eNFA68_7 -.->|"ε"|eNFA68_8
eNFA68_7 -->|"[.]"|eNFA68_5
eNFA68_7 -.->|"ε"|eNFA68_15
eNFA68_7 -.->|"ε"|eNFA68_9
eNFA68_7 -.->|"ε"|eNFA68_16
eNFA68_7 -->|"[Ee]"|eNFA68_10
eNFA68_7 -.->|"ε"|eNFA68_17
eNFA68_7 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_4 -->|"[.]"|eNFA68_5
eNFA68_5 -.->|"ε"|eNFA68_6
eNFA68_5 -->|"[0-9]"|eNFA68_6
eNFA68_5 -.->|"ε"|eNFA68_8
eNFA68_5 -.->|"ε"|eNFA68_15
eNFA68_5 -.->|"ε"|eNFA68_9
eNFA68_5 -.->|"ε"|eNFA68_16
eNFA68_5 -->|"[Ee]"|eNFA68_10
eNFA68_5 -.->|"ε"|eNFA68_17
eNFA68_5 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_11 -->|"[-+]"|eNFA68_12
eNFA68_11 -.->|"ε"|eNFA68_12
eNFA68_11 -.->|"ε"|eNFA68_13
eNFA68_11 -->|"[0-9]"|eNFA68_14
eNFA68_12 -.->|"ε"|eNFA68_13
eNFA68_12 -->|"[0-9]"|eNFA68_14
eNFA68_13 -->|"[0-9]"|eNFA68_14
eNFA68_14 -->|"[0-9]"|eNFA68_14
eNFA68_14 -.->|"ε"|eNFA68_16
eNFA68_14 -.->|"ε"|eNFA68_15
eNFA68_14 -.->|"ε"|eNFA68_9
eNFA68_14 -.->|"ε"|eNFA68_16
eNFA68_14 -->|"[Ee]"|eNFA68_10
eNFA68_14 -.->|"ε"|eNFA68_17
eNFA68_14 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_20 -.->|"ε"|eNFA68_21
eNFA68_20 -.->|"ε
AcceptToken 'floatConstant'"|eNFA68_22
eNFA68_20 -.->|"ε"|eNFA0_1
eNFA68_21 -.->|"ε
AcceptToken 'floatConstant'"|eNFA68_22
eNFA68_21 -.->|"ε"|eNFA0_1
eNFA68_22 -.->|"ε"|eNFA0_1
eNFA71_6 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_6
eNFA71_6 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_8
eNFA71_6 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_7
eNFA71_6 -.->|"ε"|eNFA71_4
eNFA71_6 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_8
eNFA71_6 -->|"[.]
ExtendToken 'doubleConstant'"|eNFA71_5
eNFA71_6 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_15
eNFA71_6 -.->|"ε"|eNFA71_9
eNFA71_6 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_6 -->|"[Ee]"|eNFA71_10
eNFA71_6 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_6 -.->|"ε"|eNFA71_19
eNFA71_6 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_6 -.->|"ε"|eNFA0_1
eNFA71_8 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_7
eNFA71_8 -.->|"ε"|eNFA71_4
eNFA71_8 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_8
eNFA71_8 -->|"[.]
ExtendToken 'doubleConstant'"|eNFA71_5
eNFA71_8 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_15
eNFA71_8 -.->|"ε"|eNFA71_9
eNFA71_8 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_8 -->|"[Ee]"|eNFA71_10
eNFA71_8 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_8 -.->|"ε"|eNFA71_19
eNFA71_8 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_8 -.->|"ε"|eNFA0_1
eNFA71_7 -.->|"ε"|eNFA71_4
eNFA71_7 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_8
eNFA71_7 -->|"[.]
ExtendToken 'doubleConstant'"|eNFA71_5
eNFA71_7 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_15
eNFA71_7 -.->|"ε"|eNFA71_9
eNFA71_7 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_7 -->|"[Ee]"|eNFA71_10
eNFA71_7 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_7 -.->|"ε"|eNFA71_19
eNFA71_7 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_7 -.->|"ε"|eNFA0_1
eNFA71_4 -->|"[.]
ExtendToken 'doubleConstant'"|eNFA71_5
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_6
eNFA71_5 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_6
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_8
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_15
eNFA71_5 -.->|"ε"|eNFA71_9
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_5 -->|"[Ee]"|eNFA71_10
eNFA71_5 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_5 -.->|"ε"|eNFA71_19
eNFA71_5 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_5 -.->|"ε"|eNFA0_1
eNFA71_11 -->|"[-+]"|eNFA71_12
eNFA71_11 -.->|"ε"|eNFA71_12
eNFA71_11 -.->|"ε"|eNFA71_13
eNFA71_11 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_14
eNFA71_12 -.->|"ε"|eNFA71_13
eNFA71_12 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_14
eNFA71_13 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_14
eNFA71_14 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_14
eNFA71_14 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_14 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_15
eNFA71_14 -.->|"ε"|eNFA71_9
eNFA71_14 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_14 -->|"[Ee]"|eNFA71_10
eNFA71_14 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_14 -.->|"ε"|eNFA71_19
eNFA71_14 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_14 -.->|"ε"|eNFA0_1
eNFA1_6 -->|"f"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_7 -->|"i"|eNFA1_9
eNFA4_6 -->|"d"|eNFA4_7
eNFA4_7 -.->|"ε"|eNFA4_8
eNFA4_7 -->|"e"|eNFA4_9
eNFA41_7 -.->|"ε"|eNFA41_8
eNFA41_7 -.->|"ε
AcceptToken '<<='"|eNFA41_9
eNFA41_7 -.->|"ε"|eNFA0_1
eNFA41_8 -.->|"ε
AcceptToken '<<='"|eNFA41_9
eNFA41_8 -.->|"ε"|eNFA0_1
eNFA41_9 -.->|"ε"|eNFA0_1
eNFA42_7 -.->|"ε"|eNFA42_8
eNFA42_7 -.->|"ε
AcceptToken '>>='"|eNFA42_9
eNFA42_7 -.->|"ε"|eNFA0_1
eNFA42_8 -.->|"ε
AcceptToken '>>='"|eNFA42_9
eNFA42_8 -.->|"ε"|eNFA0_1
eNFA42_9 -.->|"ε"|eNFA0_1
eNFA49_7 -.->|"ε"|eNFA49_8
eNFA49_7 -.->|"ε
AcceptToken '#35;if'"|eNFA49_9
eNFA49_7 -.->|"ε"|eNFA0_1
eNFA49_8 -.->|"ε
AcceptToken '#35;if'"|eNFA49_9
eNFA49_8 -.->|"ε"|eNFA0_1
eNFA49_9 -.->|"ε"|eNFA0_1
eNFA50_6 -->|"d"|eNFA50_7
eNFA50_7 -.->|"ε"|eNFA50_8
eNFA50_7 -->|"e"|eNFA50_9
eNFA51_6 -->|"n"|eNFA51_7
eNFA51_7 -.->|"ε"|eNFA51_8
eNFA51_7 -->|"d"|eNFA51_9
eNFA52_6 -->|"s"|eNFA52_7
eNFA52_7 -.->|"ε"|eNFA52_8
eNFA52_7 -->|"e
ExtendToken '#35;else'"|eNFA52_9
eNFA53_6 -->|"i"|eNFA53_7
eNFA53_7 -.->|"ε"|eNFA53_8
eNFA53_7 -->|"f
ExtendToken '#35;elif'"|eNFA53_9
eNFA54_6 -->|"d"|eNFA54_7
eNFA54_7 -.->|"ε"|eNFA54_8
eNFA54_7 -->|"i"|eNFA54_9
eNFA55_6 -->|"r"|eNFA55_7
eNFA55_7 -.->|"ε"|eNFA55_8
eNFA55_7 -->|"o"|eNFA55_9
eNFA56_6 -->|"a"|eNFA56_7
eNFA56_7 -.->|"ε"|eNFA56_8
eNFA56_7 -->|"g"|eNFA56_9
eNFA57_6 -->|"t"|eNFA57_7
eNFA57_7 -.->|"ε"|eNFA57_8
eNFA57_7 -->|"e"|eNFA57_9
eNFA58_6 -->|"r"|eNFA58_7
eNFA58_7 -.->|"ε"|eNFA58_8
eNFA58_7 -->|"s"|eNFA58_9
eNFA59_6 -->|"n"|eNFA59_7
eNFA59_7 -.->|"ε"|eNFA59_8
eNFA59_7 -->|"e
ExtendToken '#35;line'"|eNFA59_9
eNFA60_6 -->|"i"|eNFA60_7
eNFA60_7 -.->|"ε"|eNFA60_8
eNFA60_7 -->|"n"|eNFA60_9
eNFA63_7 -.->|"ε
ExtendToken 'number'"|eNFA63_6
eNFA63_7 -.->|"ε"|eNFA63_2
eNFA63_7 -.->|"ε
ExtendToken 'number'"|eNFA63_7
eNFA63_7 -->|"[.]"|eNFA63_3
eNFA63_7 -.->|"ε
ExtendToken 'number'"|eNFA63_9
eNFA63_7 -.->|"ε"|eNFA63_10
eNFA63_7 -.->|"ε
AcceptToken 'number'"|eNFA63_11
eNFA63_7 -.->|"ε"|eNFA0_1
eNFA63_6 -.->|"ε"|eNFA63_2
eNFA63_6 -.->|"ε
ExtendToken 'number'"|eNFA63_7
eNFA63_6 -->|"[.]"|eNFA63_3
eNFA63_6 -.->|"ε
ExtendToken 'number'"|eNFA63_9
eNFA63_6 -.->|"ε"|eNFA63_10
eNFA63_6 -.->|"ε
AcceptToken 'number'"|eNFA63_11
eNFA63_6 -.->|"ε"|eNFA0_1
eNFA63_2 -->|"[.]"|eNFA63_3
eNFA63_3 -.->|"ε"|eNFA63_4
eNFA63_3 -->|"[0-9]
ExtendToken 'number'"|eNFA63_5
eNFA65_7 -.->|"ε"|eNFA65_8
eNFA65_7 -.->|"ε
AcceptToken 'intConstant'"|eNFA65_9
eNFA65_7 -.->|"ε"|eNFA0_1
eNFA65_8 -.->|"ε
AcceptToken 'intConstant'"|eNFA65_9
eNFA65_8 -.->|"ε"|eNFA0_1
eNFA65_9 -.->|"ε"|eNFA0_1
eNFA67_6 -->|"[uU]
ExtendToken 'uintConstant'"|eNFA67_7
eNFA67_7 -.->|"ε
ExtendToken 'uintConstant'"|eNFA67_9
eNFA67_7 -.->|"ε"|eNFA67_10
eNFA67_7 -.->|"ε
AcceptToken 'uintConstant'"|eNFA67_11
eNFA67_7 -.->|"ε"|eNFA0_1
eNFA69_6 -->|"e
ExtendToken 'boolConstant'"|eNFA69_7
eNFA69_7 -.->|"ε
ExtendToken 'boolConstant'"|eNFA69_9
eNFA69_7 -.->|"ε"|eNFA69_12
eNFA69_7 -.->|"ε"|eNFA69_10
eNFA69_7 -->|"[^a-zA-Z0-9_]"|eNFA69_11
eNFA70_6 -->|"s"|eNFA70_7
eNFA70_7 -.->|"ε"|eNFA70_8
eNFA70_7 -->|"e
ExtendToken 'boolConstant'"|eNFA70_9
eNFA68_6 -->|"[0-9]"|eNFA68_6
eNFA68_6 -.->|"ε"|eNFA68_8
eNFA68_6 -.->|"ε"|eNFA68_15
eNFA68_6 -.->|"ε"|eNFA68_9
eNFA68_6 -.->|"ε"|eNFA68_16
eNFA68_6 -->|"[Ee]"|eNFA68_10
eNFA68_6 -.->|"ε"|eNFA68_17
eNFA68_6 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_16 -.->|"ε"|eNFA68_15
eNFA68_16 -.->|"ε"|eNFA68_9
eNFA68_16 -.->|"ε"|eNFA68_16
eNFA68_16 -->|"[Ee]"|eNFA68_10
eNFA68_16 -.->|"ε"|eNFA68_17
eNFA68_16 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_15 -.->|"ε"|eNFA68_9
eNFA68_15 -.->|"ε"|eNFA68_16
eNFA68_15 -->|"[Ee]"|eNFA68_10
eNFA68_15 -.->|"ε"|eNFA68_17
eNFA68_15 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA68_9 -->|"[Ee]"|eNFA68_10
eNFA68_10 -.->|"ε"|eNFA68_11
eNFA68_10 -->|"[-+]"|eNFA68_12
eNFA68_10 -.->|"ε"|eNFA68_12
eNFA68_10 -.->|"ε"|eNFA68_13
eNFA68_10 -->|"[0-9]"|eNFA68_14
eNFA71_6 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_6
eNFA71_6 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_8
eNFA71_6 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_15
eNFA71_6 -.->|"ε"|eNFA71_9
eNFA71_6 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_6 -->|"[Ee]"|eNFA71_10
eNFA71_6 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_6 -.->|"ε"|eNFA71_19
eNFA71_6 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_6 -.->|"ε"|eNFA0_1
eNFA71_16 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_15
eNFA71_16 -.->|"ε"|eNFA71_9
eNFA71_16 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_16 -->|"[Ee]"|eNFA71_10
eNFA71_16 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_16 -.->|"ε"|eNFA71_19
eNFA71_16 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_16 -.->|"ε"|eNFA0_1
eNFA71_15 -.->|"ε"|eNFA71_9
eNFA71_15 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_15 -->|"[Ee]"|eNFA71_10
eNFA71_15 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_15 -.->|"ε"|eNFA71_19
eNFA71_15 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_15 -.->|"ε"|eNFA0_1
eNFA71_9 -->|"[Ee]"|eNFA71_10
eNFA71_10 -.->|"ε"|eNFA71_11
eNFA71_10 -->|"[-+]"|eNFA71_12
eNFA71_10 -.->|"ε"|eNFA71_12
eNFA71_10 -.->|"ε"|eNFA71_13
eNFA71_10 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_14
eNFA1_8 -->|"i"|eNFA1_9
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_9 -->|"n"|eNFA1_11
eNFA4_8 -->|"e"|eNFA4_9
eNFA4_9 -.->|"ε"|eNFA4_10
eNFA4_9 -->|"f
ExtendToken '#35;undef'"|eNFA4_11
eNFA50_8 -->|"e"|eNFA50_9
eNFA50_9 -.->|"ε"|eNFA50_10
eNFA50_9 -->|"f
ExtendToken '#35;ifdef'"|eNFA50_11
eNFA51_8 -->|"d"|eNFA51_9
eNFA51_9 -.->|"ε"|eNFA51_10
eNFA51_9 -->|"e"|eNFA51_11
eNFA52_8 -->|"e
ExtendToken '#35;else'"|eNFA52_9
eNFA52_9 -.->|"ε
ExtendToken '#35;else'"|eNFA52_11
eNFA52_9 -.->|"ε"|eNFA52_12
eNFA52_9 -.->|"ε
AcceptToken '#35;else'"|eNFA52_13
eNFA52_9 -.->|"ε"|eNFA0_1
eNFA53_8 -->|"f
ExtendToken '#35;elif'"|eNFA53_9
eNFA53_9 -.->|"ε
ExtendToken '#35;elif'"|eNFA53_11
eNFA53_9 -.->|"ε"|eNFA53_12
eNFA53_9 -.->|"ε
AcceptToken '#35;elif'"|eNFA53_13
eNFA53_9 -.->|"ε"|eNFA0_1
eNFA54_8 -->|"i"|eNFA54_9
eNFA54_9 -.->|"ε"|eNFA54_10
eNFA54_9 -->|"f
ExtendToken '#35;endif'"|eNFA54_11
eNFA55_8 -->|"o"|eNFA55_9
eNFA55_9 -.->|"ε"|eNFA55_10
eNFA55_9 -->|"r
ExtendToken '#35;error'"|eNFA55_11
eNFA56_8 -->|"g"|eNFA56_9
eNFA56_9 -.->|"ε"|eNFA56_10
eNFA56_9 -->|"m"|eNFA56_11
eNFA57_8 -->|"e"|eNFA57_9
eNFA57_9 -.->|"ε"|eNFA57_10
eNFA57_9 -->|"n"|eNFA57_11
eNFA58_8 -->|"s"|eNFA58_9
eNFA58_9 -.->|"ε"|eNFA58_10
eNFA58_9 -->|"i"|eNFA58_11
eNFA59_8 -->|"e
ExtendToken '#35;line'"|eNFA59_9
eNFA59_9 -.->|"ε
ExtendToken '#35;line'"|eNFA59_11
eNFA59_9 -.->|"ε"|eNFA59_12
eNFA59_9 -.->|"ε
AcceptToken '#35;line'"|eNFA59_13
eNFA59_9 -.->|"ε"|eNFA0_1
eNFA60_8 -->|"n"|eNFA60_9
eNFA60_9 -.->|"ε"|eNFA60_10
eNFA60_9 -->|"e"|eNFA60_11
eNFA63_4 -->|"[0-9]
ExtendToken 'number'"|eNFA63_5
eNFA63_5 -->|"[0-9]
ExtendToken 'number'"|eNFA63_5
eNFA63_5 -.->|"ε
ExtendToken 'number'"|eNFA63_7
eNFA63_5 -.->|"ε
ExtendToken 'number'"|eNFA63_9
eNFA63_5 -.->|"ε"|eNFA63_10
eNFA63_5 -.->|"ε
AcceptToken 'number'"|eNFA63_11
eNFA63_5 -.->|"ε"|eNFA0_1
eNFA67_9 -.->|"ε"|eNFA67_10
eNFA67_9 -.->|"ε
AcceptToken 'uintConstant'"|eNFA67_11
eNFA67_9 -.->|"ε"|eNFA0_1
eNFA67_10 -.->|"ε
AcceptToken 'uintConstant'"|eNFA67_11
eNFA67_10 -.->|"ε"|eNFA0_1
eNFA67_11 -.->|"ε"|eNFA0_1
eNFA69_9 -.->|"ε"|eNFA69_12
eNFA69_9 -.->|"ε"|eNFA69_10
eNFA69_9 -->|"[^a-zA-Z0-9_]"|eNFA69_11
eNFA69_12 -.->|"ε"|eNFA69_10
eNFA69_12 -->|"[^a-zA-Z0-9_]"|eNFA69_11
eNFA69_10 -->|"[^a-zA-Z0-9_]"|eNFA69_11
eNFA69_11 -.->|"ε
AcceptToken 'boolConstant'"|eNFA69_13
eNFA69_11 -.->|"ε"|eNFA0_1
eNFA70_8 -->|"e
ExtendToken 'boolConstant'"|eNFA70_9
eNFA70_9 -.->|"ε
ExtendToken 'boolConstant'"|eNFA70_11
eNFA70_9 -.->|"ε"|eNFA70_14
eNFA70_9 -.->|"ε"|eNFA70_12
eNFA70_9 -->|"[^a-zA-Z0-9_]"|eNFA70_13
eNFA68_11 -->|"[-+]"|eNFA68_12
eNFA68_11 -.->|"ε"|eNFA68_12
eNFA68_11 -.->|"ε"|eNFA68_13
eNFA68_11 -->|"[0-9]"|eNFA68_14
eNFA68_12 -.->|"ε"|eNFA68_13
eNFA68_12 -->|"[0-9]"|eNFA68_14
eNFA68_13 -->|"[0-9]"|eNFA68_14
eNFA68_14 -->|"[0-9]"|eNFA68_14
eNFA68_14 -.->|"ε"|eNFA68_16
eNFA68_14 -.->|"ε"|eNFA68_17
eNFA68_14 -->|"[fF]
ExtendToken 'floatConstant'"|eNFA68_18
eNFA71_11 -->|"[-+]"|eNFA71_12
eNFA71_11 -.->|"ε"|eNFA71_12
eNFA71_11 -.->|"ε"|eNFA71_13
eNFA71_11 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_14
eNFA71_12 -.->|"ε"|eNFA71_13
eNFA71_12 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_14
eNFA71_13 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_14
eNFA71_14 -->|"[0-9]
ExtendToken 'doubleConstant'"|eNFA71_14
eNFA71_14 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_16
eNFA71_14 -.->|"ε
ExtendToken 'doubleConstant'"|eNFA71_18
eNFA71_14 -.->|"ε"|eNFA71_19
eNFA71_14 -.->|"ε
AcceptToken 'doubleConstant'"|eNFA71_20
eNFA71_14 -.->|"ε"|eNFA0_1
eNFA1_10 -->|"n"|eNFA1_11
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_11 -->|"e
ExtendToken '#35;define'"|eNFA1_13
eNFA4_10 -->|"f
ExtendToken '#35;undef'"|eNFA4_11
eNFA4_11 -.->|"ε
ExtendToken '#35;undef'"|eNFA4_13
eNFA4_11 -.->|"ε"|eNFA4_14
eNFA4_11 -.->|"ε
AcceptToken '#35;undef'"|eNFA4_15
eNFA4_11 -.->|"ε"|eNFA0_1
eNFA50_10 -->|"f
ExtendToken '#35;ifdef'"|eNFA50_11
eNFA50_11 -.->|"ε
ExtendToken '#35;ifdef'"|eNFA50_13
eNFA50_11 -.->|"ε"|eNFA50_14
eNFA50_11 -.->|"ε
AcceptToken '#35;ifdef'"|eNFA50_15
eNFA50_11 -.->|"ε"|eNFA0_1
eNFA51_10 -->|"e"|eNFA51_11
eNFA51_11 -.->|"ε"|eNFA51_12
eNFA51_11 -->|"f
ExtendToken '#35;ifndef'"|eNFA51_13
eNFA52_11 -.->|"ε"|eNFA52_12
eNFA52_11 -.->|"ε
AcceptToken '#35;else'"|eNFA52_13
eNFA52_11 -.->|"ε"|eNFA0_1
eNFA52_12 -.->|"ε
AcceptToken '#35;else'"|eNFA52_13
eNFA52_12 -.->|"ε"|eNFA0_1
eNFA52_13 -.->|"ε"|eNFA0_1
eNFA53_11 -.->|"ε"|eNFA53_12
eNFA53_11 -.->|"ε
AcceptToken '#35;elif'"|eNFA53_13
eNFA53_11 -.->|"ε"|eNFA0_1
eNFA53_12 -.->|"ε
AcceptToken '#35;elif'"|eNFA53_13
eNFA53_12 -.->|"ε"|eNFA0_1
eNFA53_13 -.->|"ε"|eNFA0_1
eNFA54_10 -->|"f
ExtendToken '#35;endif'"|eNFA54_11
eNFA54_11 -.->|"ε
ExtendToken '#35;endif'"|eNFA54_13
eNFA54_11 -.->|"ε"|eNFA54_14
eNFA54_11 -.->|"ε
AcceptToken '#35;endif'"|eNFA54_15
eNFA54_11 -.->|"ε"|eNFA0_1
eNFA55_10 -->|"r
ExtendToken '#35;error'"|eNFA55_11
eNFA55_11 -.->|"ε
ExtendToken '#35;error'"|eNFA55_13
eNFA55_11 -.->|"ε"|eNFA55_14
eNFA55_11 -.->|"ε
AcceptToken '#35;error'"|eNFA55_15
eNFA55_11 -.->|"ε"|eNFA0_1
eNFA56_10 -->|"m"|eNFA56_11
eNFA56_11 -.->|"ε"|eNFA56_12
eNFA56_11 -->|"a
ExtendToken '#35;pragma'"|eNFA56_13
eNFA57_10 -->|"n"|eNFA57_11
eNFA57_11 -.->|"ε"|eNFA57_12
eNFA57_11 -->|"s"|eNFA57_13
eNFA58_10 -->|"i"|eNFA58_11
eNFA58_11 -.->|"ε"|eNFA58_12
eNFA58_11 -->|"o"|eNFA58_13
eNFA59_11 -.->|"ε"|eNFA59_12
eNFA59_11 -.->|"ε
AcceptToken '#35;line'"|eNFA59_13
eNFA59_11 -.->|"ε"|eNFA0_1
eNFA59_12 -.->|"ε
AcceptToken '#35;line'"|eNFA59_13
eNFA59_12 -.->|"ε"|eNFA0_1
eNFA59_13 -.->|"ε"|eNFA0_1
eNFA60_10 -->|"e"|eNFA60_11
eNFA60_11 -.->|"ε"|eNFA60_12
eNFA60_11 -->|"d
ExtendToken 'defined'"|eNFA60_13
eNFA69_13 -.->|"ε"|eNFA0_1
eNFA70_11 -.->|"ε"|eNFA70_14
eNFA70_11 -.->|"ε"|eNFA70_12
eNFA70_11 -->|"[^a-zA-Z0-9_]"|eNFA70_13
eNFA70_14 -.->|"ε"|eNFA70_12
eNFA70_14 -->|"[^a-zA-Z0-9_]"|eNFA70_13
eNFA70_12 -->|"[^a-zA-Z0-9_]"|eNFA70_13
eNFA70_13 -.->|"ε
AcceptToken 'boolConstant'"|eNFA70_15
eNFA70_13 -.->|"ε"|eNFA0_1
eNFA1_12 -->|"e
ExtendToken '#35;define'"|eNFA1_13
eNFA1_13 -.->|"ε
ExtendToken '#35;define'"|eNFA1_15
eNFA1_13 -.->|"ε"|eNFA1_16
eNFA1_13 -.->|"ε
AcceptToken '#35;define'"|eNFA1_17
eNFA1_13 -.->|"ε"|eNFA0_1
eNFA4_13 -.->|"ε"|eNFA4_14
eNFA4_13 -.->|"ε
AcceptToken '#35;undef'"|eNFA4_15
eNFA4_13 -.->|"ε"|eNFA0_1
eNFA4_14 -.->|"ε
AcceptToken '#35;undef'"|eNFA4_15
eNFA4_14 -.->|"ε"|eNFA0_1
eNFA4_15 -.->|"ε"|eNFA0_1
eNFA50_13 -.->|"ε"|eNFA50_14
eNFA50_13 -.->|"ε
AcceptToken '#35;ifdef'"|eNFA50_15
eNFA50_13 -.->|"ε"|eNFA0_1
eNFA50_14 -.->|"ε
AcceptToken '#35;ifdef'"|eNFA50_15
eNFA50_14 -.->|"ε"|eNFA0_1
eNFA50_15 -.->|"ε"|eNFA0_1
eNFA51_12 -->|"f
ExtendToken '#35;ifndef'"|eNFA51_13
eNFA51_13 -.->|"ε
ExtendToken '#35;ifndef'"|eNFA51_15
eNFA51_13 -.->|"ε"|eNFA51_16
eNFA51_13 -.->|"ε
AcceptToken '#35;ifndef'"|eNFA51_17
eNFA51_13 -.->|"ε"|eNFA0_1
eNFA54_13 -.->|"ε"|eNFA54_14
eNFA54_13 -.->|"ε
AcceptToken '#35;endif'"|eNFA54_15
eNFA54_13 -.->|"ε"|eNFA0_1
eNFA54_14 -.->|"ε
AcceptToken '#35;endif'"|eNFA54_15
eNFA54_14 -.->|"ε"|eNFA0_1
eNFA54_15 -.->|"ε"|eNFA0_1
eNFA55_13 -.->|"ε"|eNFA55_14
eNFA55_13 -.->|"ε
AcceptToken '#35;error'"|eNFA55_15
eNFA55_13 -.->|"ε"|eNFA0_1
eNFA55_14 -.->|"ε
AcceptToken '#35;error'"|eNFA55_15
eNFA55_14 -.->|"ε"|eNFA0_1
eNFA55_15 -.->|"ε"|eNFA0_1
eNFA56_12 -->|"a
ExtendToken '#35;pragma'"|eNFA56_13
eNFA56_13 -.->|"ε
ExtendToken '#35;pragma'"|eNFA56_15
eNFA56_13 -.->|"ε"|eNFA56_16
eNFA56_13 -.->|"ε
AcceptToken '#35;pragma'"|eNFA56_17
eNFA56_13 -.->|"ε"|eNFA0_1
eNFA57_12 -->|"s"|eNFA57_13
eNFA57_13 -.->|"ε"|eNFA57_14
eNFA57_13 -->|"i"|eNFA57_15
eNFA58_12 -->|"o"|eNFA58_13
eNFA58_13 -.->|"ε"|eNFA58_14
eNFA58_13 -->|"n
ExtendToken '#35;version'"|eNFA58_15
eNFA60_12 -->|"d
ExtendToken 'defined'"|eNFA60_13
eNFA60_13 -.->|"ε
ExtendToken 'defined'"|eNFA60_15
eNFA60_13 -.->|"ε"|eNFA60_16
eNFA60_13 -.->|"ε
AcceptToken 'defined'"|eNFA60_17
eNFA60_13 -.->|"ε"|eNFA0_1
eNFA70_15 -.->|"ε"|eNFA0_1
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_15 -.->|"ε
AcceptToken '#35;define'"|eNFA1_17
eNFA1_15 -.->|"ε"|eNFA0_1
eNFA1_16 -.->|"ε
AcceptToken '#35;define'"|eNFA1_17
eNFA1_16 -.->|"ε"|eNFA0_1
eNFA1_17 -.->|"ε"|eNFA0_1
eNFA51_15 -.->|"ε"|eNFA51_16
eNFA51_15 -.->|"ε
AcceptToken '#35;ifndef'"|eNFA51_17
eNFA51_15 -.->|"ε"|eNFA0_1
eNFA51_16 -.->|"ε
AcceptToken '#35;ifndef'"|eNFA51_17
eNFA51_16 -.->|"ε"|eNFA0_1
eNFA51_17 -.->|"ε"|eNFA0_1
eNFA56_15 -.->|"ε"|eNFA56_16
eNFA56_15 -.->|"ε
AcceptToken '#35;pragma'"|eNFA56_17
eNFA56_15 -.->|"ε"|eNFA0_1
eNFA56_16 -.->|"ε
AcceptToken '#35;pragma'"|eNFA56_17
eNFA56_16 -.->|"ε"|eNFA0_1
eNFA56_17 -.->|"ε"|eNFA0_1
eNFA57_14 -->|"i"|eNFA57_15
eNFA57_15 -.->|"ε"|eNFA57_16
eNFA57_15 -->|"o"|eNFA57_17
eNFA58_14 -->|"n
ExtendToken '#35;version'"|eNFA58_15
eNFA58_15 -.->|"ε
ExtendToken '#35;version'"|eNFA58_17
eNFA58_15 -.->|"ε"|eNFA58_18
eNFA58_15 -.->|"ε
AcceptToken '#35;version'"|eNFA58_19
eNFA58_15 -.->|"ε"|eNFA0_1
eNFA60_15 -.->|"ε"|eNFA60_16
eNFA60_15 -.->|"ε
AcceptToken 'defined'"|eNFA60_17
eNFA60_15 -.->|"ε"|eNFA0_1
eNFA60_16 -.->|"ε
AcceptToken 'defined'"|eNFA60_17
eNFA60_16 -.->|"ε"|eNFA0_1
eNFA60_17 -.->|"ε"|eNFA0_1
eNFA57_16 -->|"o"|eNFA57_17
eNFA57_17 -.->|"ε"|eNFA57_18
eNFA57_17 -->|"n
ExtendToken '#35;extension'"|eNFA57_19
eNFA58_17 -.->|"ε"|eNFA58_18
eNFA58_17 -.->|"ε
AcceptToken '#35;version'"|eNFA58_19
eNFA58_17 -.->|"ε"|eNFA0_1
eNFA58_18 -.->|"ε
AcceptToken '#35;version'"|eNFA58_19
eNFA58_18 -.->|"ε"|eNFA0_1
eNFA58_19 -.->|"ε"|eNFA0_1
eNFA57_18 -->|"n
ExtendToken '#35;extension'"|eNFA57_19
eNFA57_19 -.->|"ε
ExtendToken '#35;extension'"|eNFA57_21
eNFA57_19 -.->|"ε"|eNFA57_22
eNFA57_19 -.->|"ε
AcceptToken '#35;extension'"|eNFA57_23
eNFA57_19 -.->|"ε"|eNFA0_1
eNFA57_21 -.->|"ε"|eNFA57_22
eNFA57_21 -.->|"ε
AcceptToken '#35;extension'"|eNFA57_23
eNFA57_21 -.->|"ε"|eNFA0_1
eNFA57_22 -.->|"ε
AcceptToken '#35;extension'"|eNFA57_23
eNFA57_22 -.->|"ε"|eNFA0_1
eNFA57_23 -.->|"ε"|eNFA0_1

```

## 3/5: NFA

```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
NFA0_0("NFA0-0 wholeStart")
class NFA0_0 c1000;
NFA1_1("NFA1-1 char[1]")
NFA2_1[\"NFA2-1 char[1]
AcceptToken '('"/]
class NFA2_1 c0001;
NFA3_1[\"NFA3-1 char[1]
AcceptToken ')'"/]
class NFA3_1 c0001;
NFA4_1("NFA4-1 char[1]")
NFA5_1[\"NFA5-1 char[1]
AcceptToken ','"/]
class NFA5_1 c0001;
NFA6_1[\"NFA6-1 char[1]
AcceptToken ';'"/]
class NFA6_1 c0001;
NFA7_1[\"NFA7-1 char[1]
AcceptToken '['"/]
class NFA7_1 c0001;
NFA8_1[\"NFA8-1 char[1]
AcceptToken ']'"/]
class NFA8_1 c0001;
NFA9_1[\"NFA9-1 char[1]
AcceptToken '.'"/]
class NFA9_1 c0001;
NFA10_1("NFA10-1 char[1]")
NFA11_1("NFA11-1 char[1]")
NFA12_1[\"NFA12-1 char[1]
AcceptToken '+'"/]
class NFA12_1 c0001;
NFA13_1[\"NFA13-1 char[1]
AcceptToken '-'"/]
class NFA13_1 c0001;
NFA14_1[\"NFA14-1 char[1]
AcceptToken '!'"/]
class NFA14_1 c0001;
NFA15_1[\"NFA15-1 char[1]
AcceptToken '~'"/]
class NFA15_1 c0001;
NFA16_1[\"NFA16-1 char[1]
AcceptToken '*'"/]
class NFA16_1 c0001;
NFA17_1[\"NFA17-1 char[1]
AcceptToken '/'"/]
class NFA17_1 c0001;
NFA18_1[\"NFA18-1 char[1]
AcceptToken '%'"/]
class NFA18_1 c0001;
NFA19_1("NFA19-1 char[1]")
NFA20_1("NFA20-1 char[1]")
NFA21_1[\"NFA21-1 char[1]
AcceptToken '<'"/]
class NFA21_1 c0001;
NFA22_1[\"NFA22-1 char[1]
AcceptToken '>'"/]
class NFA22_1 c0001;
NFA23_1("NFA23-1 char[1]")
NFA24_1("NFA24-1 char[1]")
NFA25_1("NFA25-1 char[1]")
NFA26_1("NFA26-1 char[1]")
NFA27_1[\"NFA27-1 char[1]
AcceptToken '&'"/]
class NFA27_1 c0001;
NFA28_1[\"NFA28-1 char[1]
AcceptToken '^'"/]
class NFA28_1 c0001;
NFA29_1[\"NFA29-1 char[1]
AcceptToken '|'"/]
class NFA29_1 c0001;
NFA30_1("NFA30-1 char[1]")
NFA31_1("NFA31-1 char[1]")
NFA32_1("NFA32-1 char[1]")
NFA33_1[\"NFA33-1 char[1]
AcceptToken '?'"/]
class NFA33_1 c0001;
NFA34_1[\"NFA34-1 char[1]
AcceptToken ':'"/]
class NFA34_1 c0001;
NFA35_1[\"NFA35-1 char[1]
AcceptToken '='"/]
class NFA35_1 c0001;
NFA36_1("NFA36-1 char[1]")
NFA37_1("NFA37-1 char[1]")
NFA38_1("NFA38-1 char[1]")
NFA39_1("NFA39-1 char[1]")
NFA40_1("NFA40-1 char[1]")
NFA41_1("NFA41-1 char[1]")
NFA42_1("NFA42-1 char[1]")
NFA43_1("NFA43-1 char[1]")
NFA44_1("NFA44-1 char[1]")
NFA45_1("NFA45-1 char[1]")
NFA46_1[\"NFA46-1 char[1]
AcceptToken '{'"/]
class NFA46_1 c0001;
NFA47_1[\"NFA47-1 char[1]
AcceptToken '}'"/]
class NFA47_1 c0001;
NFA48_1("NFA48-1 char[1]")
NFA49_1("NFA49-1 char[1]")
NFA50_1("NFA50-1 char[1]")
NFA51_1("NFA51-1 char[1]")
NFA52_1("NFA52-1 char[1]")
NFA53_1("NFA53-1 char[1]")
NFA54_1("NFA54-1 char[1]")
NFA55_1("NFA55-1 char[1]")
NFA56_1("NFA56-1 char[1]")
NFA57_1("NFA57-1 char[1]")
NFA58_1("NFA58-1 char[1]")
NFA59_1("NFA59-1 char[1]")
NFA60_1("NFA60-1 char[1]")
NFA61_1[\"NFA61-1 scope[1]
AcceptToken 'identifier'"/]
class NFA61_1 c0001;
NFA62_1("NFA62-1 scope[1]")
class NFA62_1 c1000;
NFA63_1[\"NFA63-1 scope[1]
AcceptToken 'number'"/]
class NFA63_1 c0001;
NFA64_1("NFA64-1 scope[1]")
class NFA64_1 c1000;
NFA65_1("NFA65-1 char[1]")
NFA66_1("NFA66-1 scope[1]")
class NFA66_1 c1000;
NFA67_1("NFA67-1 char[1]")
NFA68_1("NFA68-1 scope[1]")
class NFA68_1 c1000;
NFA69_1("NFA69-1 char[1]")
NFA70_1("NFA70-1 char[1]")
NFA71_1("NFA71-1 scope[1]")
class NFA71_1 c1000;
NFA72_1("NFA72-1 char[1]")
NFA62_3("NFA62-3 char[1]")
NFA64_3[\"NFA64-3 scope[1]
AcceptToken 'intConstant'"/]
class NFA64_3 c0001;
NFA66_3("NFA66-3 scope[1]")
NFA68_3("NFA68-3 scope[1]")
NFA71_3[\"NFA71-3 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_3 c0001;
NFA1_3("NFA1-3 char[1]")
NFA4_3("NFA4-3 char[1]")
NFA10_3[\"NFA10-3 char[1]
AcceptToken '++'"/]
class NFA10_3 c0001;
NFA11_3[\"NFA11-3 char[1]
AcceptToken '--'"/]
class NFA11_3 c0001;
NFA19_3[\"NFA19-3 char[1]
AcceptToken '<<'"/]
class NFA19_3 c0001;
NFA20_3[\"NFA20-3 char[1]
AcceptToken '>>'"/]
class NFA20_3 c0001;
NFA23_3[\"NFA23-3 char[1]
AcceptToken '<='"/]
class NFA23_3 c0001;
NFA24_3[\"NFA24-3 char[1]
AcceptToken '>='"/]
class NFA24_3 c0001;
NFA25_3[\"NFA25-3 char[1]
AcceptToken '=='"/]
class NFA25_3 c0001;
NFA26_3[\"NFA26-3 char[1]
AcceptToken '!='"/]
class NFA26_3 c0001;
NFA30_3[\"NFA30-3 char[1]
AcceptToken '&&'"/]
class NFA30_3 c0001;
NFA31_3[\"NFA31-3 char[1]
AcceptToken '^^'"/]
class NFA31_3 c0001;
NFA32_3[\"NFA32-3 char[1]
AcceptToken '||'"/]
class NFA32_3 c0001;
NFA36_3[\"NFA36-3 char[1]
AcceptToken '*='"/]
class NFA36_3 c0001;
NFA37_3[\"NFA37-3 char[1]
AcceptToken '/='"/]
class NFA37_3 c0001;
NFA38_3[\"NFA38-3 char[1]
AcceptToken '%='"/]
class NFA38_3 c0001;
NFA39_3[\"NFA39-3 char[1]
AcceptToken '+='"/]
class NFA39_3 c0001;
NFA40_3[\"NFA40-3 char[1]
AcceptToken '-='"/]
class NFA40_3 c0001;
NFA41_3("NFA41-3 char[1]")
NFA42_3("NFA42-3 char[1]")
NFA43_3[\"NFA43-3 char[1]
AcceptToken '&='"/]
class NFA43_3 c0001;
NFA44_3[\"NFA44-3 char[1]
AcceptToken '^='"/]
class NFA44_3 c0001;
NFA45_3[\"NFA45-3 char[1]
AcceptToken '|='"/]
class NFA45_3 c0001;
NFA48_3[\"NFA48-3 char[1]
AcceptToken '##'"/]
class NFA48_3 c0001;
NFA49_3("NFA49-3 char[1]")
NFA50_3("NFA50-3 char[1]")
NFA51_3("NFA51-3 char[1]")
NFA52_3("NFA52-3 char[1]")
NFA53_3("NFA53-3 char[1]")
NFA54_3("NFA54-3 char[1]")
NFA55_3("NFA55-3 char[1]")
NFA56_3("NFA56-3 char[1]")
NFA57_3("NFA57-3 char[1]")
NFA58_3("NFA58-3 char[1]")
NFA59_3("NFA59-3 char[1]")
NFA60_3("NFA60-3 char[1]")
NFA61_2[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2 c0001;
NFA63_3("NFA63-3 scope[1]")
NFA65_3("NFA65-3 char[1]")
NFA67_3("NFA67-3 char[1]")
NFA69_3("NFA69-3 char[1]")
NFA70_3("NFA70-3 char[1]")
NFA72_3[\"NFA72-3 char[1]
AcceptToken 'inlineComment'"/]
class NFA72_3 c0001;
NFA62_5("NFA62-5 char[1]")
NFA62_11("NFA62-11 scope[1]")
NFA62_13[\"NFA62-13 char[1]
AcceptToken 'literalString'"/]
class NFA62_13 c0001;
NFA66_5[\"NFA66-5 scope[1]
AcceptToken 'uintConstant'"/]
class NFA66_5 c0001;
NFA68_5("NFA68-5 scope[1]")
NFA68_10("NFA68-10 scope[1]")
NFA68_18[\"NFA68-18 scope[1]
AcceptToken 'floatConstant'"/]
class NFA68_18 c0001;
NFA71_5[\"NFA71-5 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_5 c0001;
NFA71_10("NFA71-10 scope[1]")
NFA1_5("NFA1-5 char[1]")
NFA4_5("NFA4-5 char[1]")
NFA41_5[\"NFA41-5 char[1]
AcceptToken '<<='"/]
class NFA41_5 c0001;
NFA42_5[\"NFA42-5 char[1]
AcceptToken '>>='"/]
class NFA42_5 c0001;
NFA49_5[\"NFA49-5 char[1]
AcceptToken '#if'"/]
class NFA49_5 c0001;
NFA50_5("NFA50-5 char[1]")
NFA51_5("NFA51-5 char[1]")
NFA52_5("NFA52-5 char[1]")
NFA53_5("NFA53-5 char[1]")
NFA54_5("NFA54-5 char[1]")
NFA55_5("NFA55-5 char[1]")
NFA56_5("NFA56-5 char[1]")
NFA57_5("NFA57-5 char[1]")
NFA58_5("NFA58-5 char[1]")
NFA59_5("NFA59-5 char[1]")
NFA60_5("NFA60-5 char[1]")
NFA63_5[\"NFA63-5 scope[1]
AcceptToken 'number'"/]
class NFA63_5 c0001;
NFA65_5[\"NFA65-5 scope[1]
AcceptToken 'intConstant'"/]
class NFA65_5 c0001;
NFA67_5("NFA67-5 scope[1]")
NFA69_5("NFA69-5 char[1]")
NFA70_5("NFA70-5 char[1]")
NFA72_4[\"NFA72-4 scope{0, -1}
AcceptToken 'inlineComment'"/]
class NFA72_4 c0001;
NFA62_7("NFA62-7 char[1]")
NFA68_6("NFA68-6 scope{0, -1}")
NFA68_5("NFA68-5 scope[1]")
NFA68_12("NFA68-12 scope[1]")
NFA68_14("NFA68-14 scope[1]")
NFA71_6[\"NFA71-6 scope{0, -1}
AcceptToken 'doubleConstant'"/]
class NFA71_6 c0001;
NFA71_5[\"NFA71-5 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_5 c0001;
NFA71_12("NFA71-12 scope[1]")
NFA71_14[\"NFA71-14 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_14 c0001;
NFA1_7("NFA1-7 char[1]")
NFA4_7("NFA4-7 char[1]")
NFA50_7("NFA50-7 char[1]")
NFA51_7("NFA51-7 char[1]")
NFA52_7("NFA52-7 char[1]")
NFA53_7("NFA53-7 char[1]")
NFA54_7("NFA54-7 char[1]")
NFA55_7("NFA55-7 char[1]")
NFA56_7("NFA56-7 char[1]")
NFA57_7("NFA57-7 char[1]")
NFA58_7("NFA58-7 char[1]")
NFA59_7("NFA59-7 char[1]")
NFA60_7("NFA60-7 char[1]")
NFA63_3("NFA63-3 scope[1]")
NFA67_7[\"NFA67-7 scope[1]
AcceptToken 'uintConstant'"/]
class NFA67_7 c0001;
NFA69_7("NFA69-7 char[1]")
NFA70_7("NFA70-7 char[1]")
NFA68_6("NFA68-6 scope{0, -1}")
NFA68_10("NFA68-10 scope[1]")
NFA71_6[\"NFA71-6 scope{0, -1}
AcceptToken 'doubleConstant'"/]
class NFA71_6 c0001;
NFA71_10("NFA71-10 scope[1]")
NFA1_9("NFA1-9 char[1]")
NFA4_9("NFA4-9 char[1]")
NFA50_9("NFA50-9 char[1]")
NFA51_9("NFA51-9 char[1]")
NFA52_9[\"NFA52-9 char[1]
AcceptToken '#else'"/]
class NFA52_9 c0001;
NFA53_9[\"NFA53-9 char[1]
AcceptToken '#elif'"/]
class NFA53_9 c0001;
NFA54_9("NFA54-9 char[1]")
NFA55_9("NFA55-9 char[1]")
NFA56_9("NFA56-9 char[1]")
NFA57_9("NFA57-9 char[1]")
NFA58_9("NFA58-9 char[1]")
NFA59_9[\"NFA59-9 char[1]
AcceptToken '#line'"/]
class NFA59_9 c0001;
NFA60_9("NFA60-9 char[1]")
NFA63_5[\"NFA63-5 scope[1]
AcceptToken 'number'"/]
class NFA63_5 c0001;
NFA69_11[\"NFA69-11 scope[1]
AcceptToken 'boolConstant'"/]
class NFA69_11 c0001;
NFA70_9("NFA70-9 char[1]")
NFA68_12("NFA68-12 scope[1]")
NFA68_14("NFA68-14 scope[1]")
NFA71_12("NFA71-12 scope[1]")
NFA71_14[\"NFA71-14 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_14 c0001;
NFA1_11("NFA1-11 char[1]")
NFA4_11[\"NFA4-11 char[1]
AcceptToken '#undef'"/]
class NFA4_11 c0001;
NFA50_11[\"NFA50-11 char[1]
AcceptToken '#ifdef'"/]
class NFA50_11 c0001;
NFA51_11("NFA51-11 char[1]")
NFA54_11[\"NFA54-11 char[1]
AcceptToken '#endif'"/]
class NFA54_11 c0001;
NFA55_11[\"NFA55-11 char[1]
AcceptToken '#error'"/]
class NFA55_11 c0001;
NFA56_11("NFA56-11 char[1]")
NFA57_11("NFA57-11 char[1]")
NFA58_11("NFA58-11 char[1]")
NFA60_11("NFA60-11 char[1]")
NFA70_13[\"NFA70-13 scope[1]
AcceptToken 'boolConstant'"/]
class NFA70_13 c0001;
NFA1_13[\"NFA1-13 char[1]
AcceptToken '#define'"/]
class NFA1_13 c0001;
NFA51_13[\"NFA51-13 char[1]
AcceptToken '#ifndef'"/]
class NFA51_13 c0001;
NFA56_13[\"NFA56-13 char[1]
AcceptToken '#pragma'"/]
class NFA56_13 c0001;
NFA57_13("NFA57-13 char[1]")
NFA58_13("NFA58-13 char[1]")
NFA60_13[\"NFA60-13 char[1]
AcceptToken 'defined'"/]
class NFA60_13 c0001;
NFA57_15("NFA57-15 char[1]")
NFA58_15[\"NFA58-15 char[1]
AcceptToken '#version'"/]
class NFA58_15 c0001;
NFA57_17("NFA57-17 char[1]")
NFA57_19[\"NFA57-19 char[1]
AcceptToken '#extension'"/]
class NFA57_19 c0001;
NFA0_0 -->|"#35;
BeginToken '#35;define'"|NFA1_1
NFA0_0 -->|"#92;(
BeginToken '('
ExtendToken '('"|NFA2_1
NFA0_0 -->|"#92;)
BeginToken ')'
ExtendToken ')'"|NFA3_1
NFA0_0 -->|"#35;
BeginToken '#35;undef'"|NFA4_1
NFA0_0 -->|",
BeginToken ','
ExtendToken ','"|NFA5_1
NFA0_0 -->|";
BeginToken ';'
ExtendToken ';'"|NFA6_1
NFA0_0 -->|"#92;[
BeginToken '['
ExtendToken '['"|NFA7_1
NFA0_0 -->|"]
BeginToken ']'
ExtendToken ']'"|NFA8_1
NFA0_0 -->|"#92;.
BeginToken '.'
ExtendToken '.'"|NFA9_1
NFA0_0 -->|"#92;+
BeginToken '++'"|NFA10_1
NFA0_0 -->|"-
BeginToken '--'"|NFA11_1
NFA0_0 -->|"#92;+
BeginToken '+'
ExtendToken '+'"|NFA12_1
NFA0_0 -->|"-
BeginToken '-'
ExtendToken '-'"|NFA13_1
NFA0_0 -->|"!
BeginToken '!'
ExtendToken '!'"|NFA14_1
NFA0_0 -->|"~
BeginToken '~'
ExtendToken '~'"|NFA15_1
NFA0_0 -->|"#92;#42;
BeginToken '#42;'
ExtendToken '#42;'"|NFA16_1
NFA0_0 -->|"#92;/
BeginToken '/'
ExtendToken '/'"|NFA17_1
NFA0_0 -->|"%
BeginToken '%'
ExtendToken '%'"|NFA18_1
NFA0_0 -->|"#92;<
BeginToken '<<'"|NFA19_1
NFA0_0 -->|">
BeginToken '>>'"|NFA20_1
NFA0_0 -->|"#92;<
BeginToken '<'
ExtendToken '<'"|NFA21_1
NFA0_0 -->|">
BeginToken '>'
ExtendToken '>'"|NFA22_1
NFA0_0 -->|"#92;<
BeginToken '<='"|NFA23_1
NFA0_0 -->|">
BeginToken '>='"|NFA24_1
NFA0_0 -->|"=
BeginToken '=='"|NFA25_1
NFA0_0 -->|"!
BeginToken '!='"|NFA26_1
NFA0_0 -->|"&
BeginToken '&'
ExtendToken '&'"|NFA27_1
NFA0_0 -->|"^
BeginToken '^'
ExtendToken '^'"|NFA28_1
NFA0_0 -->|"#92;|
BeginToken '|'
ExtendToken '|'"|NFA29_1
NFA0_0 -->|"&
BeginToken '&&'"|NFA30_1
NFA0_0 -->|"^
BeginToken '^^'"|NFA31_1
NFA0_0 -->|"#92;|
BeginToken '||'"|NFA32_1
NFA0_0 -->|"#92;?
BeginToken '?'
ExtendToken '?'"|NFA33_1
NFA0_0 -->|":
BeginToken ':'
ExtendToken ':'"|NFA34_1
NFA0_0 -->|"=
BeginToken '='
ExtendToken '='"|NFA35_1
NFA0_0 -->|"#92;#42;
BeginToken '#42;='"|NFA36_1
NFA0_0 -->|"#92;/
BeginToken '/='"|NFA37_1
NFA0_0 -->|"%
BeginToken '%='"|NFA38_1
NFA0_0 -->|"#92;+
BeginToken '+='"|NFA39_1
NFA0_0 -->|"-
BeginToken '-='"|NFA40_1
NFA0_0 -->|"#92;<
BeginToken '<<='"|NFA41_1
NFA0_0 -->|">
BeginToken '>>='"|NFA42_1
NFA0_0 -->|"&
BeginToken '&='"|NFA43_1
NFA0_0 -->|"^
BeginToken '^='"|NFA44_1
NFA0_0 -->|"#92;|
BeginToken '|='"|NFA45_1
NFA0_0 -->|"#92;{
BeginToken '{'
ExtendToken '{'"|NFA46_1
NFA0_0 -->|"}
BeginToken '}'
ExtendToken '}'"|NFA47_1
NFA0_0 -->|"#35;
BeginToken '#35;#35;'"|NFA48_1
NFA0_0 -->|"#35;
BeginToken '#35;if'"|NFA49_1
NFA0_0 -->|"#35;
BeginToken '#35;ifdef'"|NFA50_1
NFA0_0 -->|"#35;
BeginToken '#35;ifndef'"|NFA51_1
NFA0_0 -->|"#35;
BeginToken '#35;else'"|NFA52_1
NFA0_0 -->|"#35;
BeginToken '#35;elif'"|NFA53_1
NFA0_0 -->|"#35;
BeginToken '#35;endif'"|NFA54_1
NFA0_0 -->|"#35;
BeginToken '#35;error'"|NFA55_1
NFA0_0 -->|"#35;
BeginToken '#35;pragma'"|NFA56_1
NFA0_0 -->|"#35;
BeginToken '#35;extension'"|NFA57_1
NFA0_0 -->|"#35;
BeginToken '#35;version'"|NFA58_1
NFA0_0 -->|"#35;
BeginToken '#35;line'"|NFA59_1
NFA0_0 -->|"d
BeginToken 'defined'"|NFA60_1
NFA0_0 -->|"[a-zA-Z_]
BeginToken 'identifier'
ExtendToken 'identifier'"|NFA61_1
NFA0_0 -->|"[a-zA-Z_]
BeginToken 'literalString'"|NFA62_1
NFA0_0 -->|"[0-9]
BeginToken 'number'
ExtendToken 'number'"|NFA63_1
NFA0_0 -->|"[-+]
BeginToken 'intConstant'"|NFA64_1
NFA0_0 -->|"0
BeginToken 'intConstant'"|NFA65_1
NFA0_0 -->|"[-+]
BeginToken 'uintConstant'"|NFA66_1
NFA0_0 -->|"0
BeginToken 'uintConstant'"|NFA67_1
NFA0_0 -->|"[-+]
BeginToken 'floatConstant'"|NFA68_1
NFA0_0 -->|"t
BeginToken 'boolConstant'"|NFA69_1
NFA0_0 -->|"f
BeginToken 'boolConstant'"|NFA70_1
NFA0_0 -->|"[-+]
BeginToken 'doubleConstant'"|NFA71_1
NFA0_0 -->|"#92;/
BeginToken 'inlineComment'"|NFA72_1
NFA0_0 -->|"#34;
BeginToken 'literalString'"|NFA62_3
NFA0_0 -->|"[0-9]
BeginToken 'intConstant'
ExtendToken 'intConstant'"|NFA64_3
NFA0_0 -->|"[0-9]
BeginToken 'uintConstant'"|NFA66_3
NFA0_0 -->|"[0-9]
BeginToken 'floatConstant'"|NFA68_3
NFA0_0 -->|"[0-9]
BeginToken 'doubleConstant'
ExtendToken 'doubleConstant'"|NFA71_3
NFA1_1 -->|"d"|NFA1_3
NFA4_1 -->|"u"|NFA4_3
NFA10_1 -->|"#92;+
ExtendToken '++'"|NFA10_3
NFA11_1 -->|"-
ExtendToken '--'"|NFA11_3
NFA19_1 -->|"#92;<
ExtendToken '<<'"|NFA19_3
NFA20_1 -->|">
ExtendToken '>>'"|NFA20_3
NFA23_1 -->|"=
ExtendToken '<='"|NFA23_3
NFA24_1 -->|"=
ExtendToken '>='"|NFA24_3
NFA25_1 -->|"=
ExtendToken '=='"|NFA25_3
NFA26_1 -->|"=
ExtendToken '!='"|NFA26_3
NFA30_1 -->|"&
ExtendToken '&&'"|NFA30_3
NFA31_1 -->|"^
ExtendToken '^^'"|NFA31_3
NFA32_1 -->|"#92;|
ExtendToken '||'"|NFA32_3
NFA36_1 -->|"=
ExtendToken '#42;='"|NFA36_3
NFA37_1 -->|"=
ExtendToken '/='"|NFA37_3
NFA38_1 -->|"=
ExtendToken '%='"|NFA38_3
NFA39_1 -->|"=
ExtendToken '+='"|NFA39_3
NFA40_1 -->|"=
ExtendToken '-='"|NFA40_3
NFA41_1 -->|"#92;<"|NFA41_3
NFA42_1 -->|">"|NFA42_3
NFA43_1 -->|"=
ExtendToken '&='"|NFA43_3
NFA44_1 -->|"=
ExtendToken '^='"|NFA44_3
NFA45_1 -->|"=
ExtendToken '|='"|NFA45_3
NFA48_1 -->|"#35;
ExtendToken '#35;#35;'"|NFA48_3
NFA49_1 -->|"i"|NFA49_3
NFA50_1 -->|"i"|NFA50_3
NFA51_1 -->|"i"|NFA51_3
NFA52_1 -->|"e"|NFA52_3
NFA53_1 -->|"e"|NFA53_3
NFA54_1 -->|"e"|NFA54_3
NFA55_1 -->|"e"|NFA55_3
NFA56_1 -->|"p"|NFA56_3
NFA57_1 -->|"e"|NFA57_3
NFA58_1 -->|"v"|NFA58_3
NFA59_1 -->|"l"|NFA59_3
NFA60_1 -->|"e"|NFA60_3
NFA61_1 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier'"|NFA61_2
NFA62_1 -->|"#34;
BeginToken 'literalString'"|NFA62_3
NFA63_1 -->|"[0-9]
ExtendToken 'number'"|NFA63_1
NFA63_1 -->|"[.]"|NFA63_3
NFA64_1 -->|"[0-9]
BeginToken 'intConstant'
ExtendToken 'intConstant'"|NFA64_3
NFA65_1 -->|"x"|NFA65_3
NFA66_1 -->|"[0-9]
BeginToken 'uintConstant'"|NFA66_3
NFA67_1 -->|"x"|NFA67_3
NFA68_1 -->|"[0-9]
BeginToken 'floatConstant'"|NFA68_3
NFA69_1 -->|"r"|NFA69_3
NFA70_1 -->|"a"|NFA70_3
NFA71_1 -->|"[0-9]
BeginToken 'doubleConstant'
ExtendToken 'doubleConstant'"|NFA71_3
NFA72_1 -->|"#92;/
ExtendToken 'inlineComment'"|NFA72_3
NFA62_3 -->|"#92;#92;"|NFA62_5
NFA62_3 -->|"[^#92;#92;#34;]"|NFA62_11
NFA62_3 -->|"#34;
ExtendToken 'literalString'"|NFA62_13
NFA64_3 -->|"[0-9]
ExtendToken 'intConstant'"|NFA64_3
NFA66_3 -->|"[0-9]"|NFA66_3
NFA66_3 -->|"[uU]
ExtendToken 'uintConstant'"|NFA66_5
NFA68_3 -->|"[0-9]"|NFA68_3
NFA68_3 -->|"[.]"|NFA68_5
NFA68_3 -->|"[Ee]"|NFA68_10
NFA68_3 -->|"[fF]
ExtendToken 'floatConstant'"|NFA68_18
NFA71_3 -->|"[0-9]
ExtendToken 'doubleConstant'"|NFA71_3
NFA71_3 -->|"[.]
ExtendToken 'doubleConstant'"|NFA71_5
NFA71_3 -->|"[Ee]"|NFA71_10
NFA1_3 -->|"e"|NFA1_5
NFA4_3 -->|"n"|NFA4_5
NFA41_3 -->|"=
ExtendToken '<<='"|NFA41_5
NFA42_3 -->|"=
ExtendToken '>>='"|NFA42_5
NFA49_3 -->|"f
ExtendToken '#35;if'"|NFA49_5
NFA50_3 -->|"f"|NFA50_5
NFA51_3 -->|"f"|NFA51_5
NFA52_3 -->|"l"|NFA52_5
NFA53_3 -->|"l"|NFA53_5
NFA54_3 -->|"n"|NFA54_5
NFA55_3 -->|"r"|NFA55_5
NFA56_3 -->|"r"|NFA56_5
NFA57_3 -->|"x"|NFA57_5
NFA58_3 -->|"e"|NFA58_5
NFA59_3 -->|"i"|NFA59_5
NFA60_3 -->|"f"|NFA60_5
NFA61_2 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier'"|NFA61_2
NFA63_3 -->|"[0-9]
ExtendToken 'number'"|NFA63_5
NFA65_3 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant'"|NFA65_5
NFA67_3 -->|"[0-9A-Fa-f]"|NFA67_5
NFA69_3 -->|"u"|NFA69_5
NFA70_3 -->|"l"|NFA70_5
NFA72_3 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment'"|NFA72_4
NFA62_5 -->|"[#32;-~]"|NFA62_7
NFA62_11 -->|"#92;#92;"|NFA62_5
NFA62_11 -->|"[^#92;#92;#34;]"|NFA62_11
NFA62_11 -->|"#34;
ExtendToken 'literalString'"|NFA62_13
NFA68_5 -->|"[0-9]"|NFA68_6
NFA68_5 -->|"[.]"|NFA68_5
NFA68_5 -->|"[Ee]"|NFA68_10
NFA68_5 -->|"[fF]
ExtendToken 'floatConstant'"|NFA68_18
NFA68_10 -->|"[-+]"|NFA68_12
NFA68_10 -->|"[0-9]"|NFA68_14
NFA71_5 -->|"[0-9]
ExtendToken 'doubleConstant'"|NFA71_6
NFA71_5 -->|"[.]
ExtendToken 'doubleConstant'"|NFA71_5
NFA71_5 -->|"[Ee]"|NFA71_10
NFA71_10 -->|"[-+]"|NFA71_12
NFA71_10 -->|"[0-9]
ExtendToken 'doubleConstant'"|NFA71_14
NFA1_5 -->|"f"|NFA1_7
NFA4_5 -->|"d"|NFA4_7
NFA50_5 -->|"d"|NFA50_7
NFA51_5 -->|"n"|NFA51_7
NFA52_5 -->|"s"|NFA52_7
NFA53_5 -->|"i"|NFA53_7
NFA54_5 -->|"d"|NFA54_7
NFA55_5 -->|"r"|NFA55_7
NFA56_5 -->|"a"|NFA56_7
NFA57_5 -->|"t"|NFA57_7
NFA58_5 -->|"r"|NFA58_7
NFA59_5 -->|"n"|NFA59_7
NFA60_5 -->|"i"|NFA60_7
NFA63_5 -->|"[0-9]
ExtendToken 'number'"|NFA63_5
NFA63_5 -->|"[.]"|NFA63_3
NFA65_5 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant'"|NFA65_5
NFA67_5 -->|"[0-9A-Fa-f]"|NFA67_5
NFA67_5 -->|"[uU]
ExtendToken 'uintConstant'"|NFA67_7
NFA69_5 -->|"e
ExtendToken 'boolConstant'"|NFA69_7
NFA70_5 -->|"s"|NFA70_7
NFA72_4 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment'"|NFA72_4
NFA62_7 -->|"#92;#92;"|NFA62_5
NFA62_7 -->|"[^#92;#92;#34;]"|NFA62_11
NFA62_7 -->|"#34;
ExtendToken 'literalString'"|NFA62_13
NFA68_6 -->|"[0-9]"|NFA68_6
NFA68_6 -->|"[.]"|NFA68_5
NFA68_6 -->|"[Ee]"|NFA68_10
NFA68_6 -->|"[fF]
ExtendToken 'floatConstant'"|NFA68_18
NFA68_5 -->|"[0-9]"|NFA68_6
NFA68_5 -->|"[Ee]"|NFA68_10
NFA68_5 -->|"[fF]
ExtendToken 'floatConstant'"|NFA68_18
NFA68_12 -->|"[0-9]"|NFA68_14
NFA68_14 -->|"[0-9]"|NFA68_14
NFA68_14 -->|"[Ee]"|NFA68_10
NFA68_14 -->|"[fF]
ExtendToken 'floatConstant'"|NFA68_18
NFA71_6 -->|"[0-9]
ExtendToken 'doubleConstant'"|NFA71_6
NFA71_6 -->|"[.]
ExtendToken 'doubleConstant'"|NFA71_5
NFA71_6 -->|"[Ee]"|NFA71_10
NFA71_5 -->|"[0-9]
ExtendToken 'doubleConstant'"|NFA71_6
NFA71_5 -->|"[Ee]"|NFA71_10
NFA71_12 -->|"[0-9]
ExtendToken 'doubleConstant'"|NFA71_14
NFA71_14 -->|"[0-9]
ExtendToken 'doubleConstant'"|NFA71_14
NFA71_14 -->|"[Ee]"|NFA71_10
NFA1_7 -->|"i"|NFA1_9
NFA4_7 -->|"e"|NFA4_9
NFA50_7 -->|"e"|NFA50_9
NFA51_7 -->|"d"|NFA51_9
NFA52_7 -->|"e
ExtendToken '#35;else'"|NFA52_9
NFA53_7 -->|"f
ExtendToken '#35;elif'"|NFA53_9
NFA54_7 -->|"i"|NFA54_9
NFA55_7 -->|"o"|NFA55_9
NFA56_7 -->|"g"|NFA56_9
NFA57_7 -->|"e"|NFA57_9
NFA58_7 -->|"s"|NFA58_9
NFA59_7 -->|"e
ExtendToken '#35;line'"|NFA59_9
NFA60_7 -->|"n"|NFA60_9
NFA63_3 -->|"[0-9]
ExtendToken 'number'"|NFA63_5
NFA69_7 -->|"[^a-zA-Z0-9_]"|NFA69_11
NFA70_7 -->|"e
ExtendToken 'boolConstant'"|NFA70_9
NFA68_6 -->|"[0-9]"|NFA68_6
NFA68_6 -->|"[Ee]"|NFA68_10
NFA68_6 -->|"[fF]
ExtendToken 'floatConstant'"|NFA68_18
NFA68_10 -->|"[-+]"|NFA68_12
NFA68_10 -->|"[0-9]"|NFA68_14
NFA71_6 -->|"[0-9]
ExtendToken 'doubleConstant'"|NFA71_6
NFA71_6 -->|"[Ee]"|NFA71_10
NFA71_10 -->|"[-+]"|NFA71_12
NFA71_10 -->|"[0-9]
ExtendToken 'doubleConstant'"|NFA71_14
NFA1_9 -->|"n"|NFA1_11
NFA4_9 -->|"f
ExtendToken '#35;undef'"|NFA4_11
NFA50_9 -->|"f
ExtendToken '#35;ifdef'"|NFA50_11
NFA51_9 -->|"e"|NFA51_11
NFA54_9 -->|"f
ExtendToken '#35;endif'"|NFA54_11
NFA55_9 -->|"r
ExtendToken '#35;error'"|NFA55_11
NFA56_9 -->|"m"|NFA56_11
NFA57_9 -->|"n"|NFA57_11
NFA58_9 -->|"i"|NFA58_11
NFA60_9 -->|"e"|NFA60_11
NFA63_5 -->|"[0-9]
ExtendToken 'number'"|NFA63_5
NFA70_9 -->|"[^a-zA-Z0-9_]"|NFA70_13
NFA68_12 -->|"[0-9]"|NFA68_14
NFA68_14 -->|"[0-9]"|NFA68_14
NFA68_14 -->|"[fF]
ExtendToken 'floatConstant'"|NFA68_18
NFA71_12 -->|"[0-9]
ExtendToken 'doubleConstant'"|NFA71_14
NFA71_14 -->|"[0-9]
ExtendToken 'doubleConstant'"|NFA71_14
NFA1_11 -->|"e
ExtendToken '#35;define'"|NFA1_13
NFA51_11 -->|"f
ExtendToken '#35;ifndef'"|NFA51_13
NFA56_11 -->|"a
ExtendToken '#35;pragma'"|NFA56_13
NFA57_11 -->|"s"|NFA57_13
NFA58_11 -->|"o"|NFA58_13
NFA60_11 -->|"d
ExtendToken 'defined'"|NFA60_13
NFA57_13 -->|"i"|NFA57_15
NFA58_13 -->|"n
ExtendToken '#35;version'"|NFA58_15
NFA57_15 -->|"o"|NFA57_17
NFA57_17 -->|"n
ExtendToken '#35;extension'"|NFA57_19

```

## 4/5: DFA

```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
subgraph DFA0["DFA0 wholeStart"]
NFA0_0_0("NFA0-0 wholeStart")
class NFA0_0_0 c1000;
end
class DFA0 c1000;
subgraph DFA1["DFA1 1 NFA States"]
NFA62_3_1("NFA62-3 char[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA47_1_2[\"NFA47-1 char[1]
AcceptToken '}'"/]
class NFA47_1_2 c0001;
end
class DFA2 c0001;
subgraph DFA3["DFA3 1 NFA States"]
NFA46_1_3[\"NFA46-1 char[1]
AcceptToken '{'"/]
class NFA46_1_3 c0001;
end
class DFA3 c0001;
subgraph DFA4["DFA4 1 NFA States"]
NFA34_1_4[\"NFA34-1 char[1]
AcceptToken ':'"/]
class NFA34_1_4 c0001;
end
class DFA4 c0001;
subgraph DFA5["DFA5 1 NFA States"]
NFA33_1_5[\"NFA33-1 char[1]
AcceptToken '?'"/]
class NFA33_1_5 c0001;
end
class DFA5 c0001;
subgraph DFA6["DFA6 1 NFA States"]
NFA15_1_6[\"NFA15-1 char[1]
AcceptToken '~'"/]
class NFA15_1_6 c0001;
end
class DFA6 c0001;
subgraph DFA7["DFA7 1 NFA States"]
NFA9_1_7[\"NFA9-1 char[1]
AcceptToken '.'"/]
class NFA9_1_7 c0001;
end
class DFA7 c0001;
subgraph DFA8["DFA8 1 NFA States"]
NFA8_1_8[\"NFA8-1 char[1]
AcceptToken ']'"/]
class NFA8_1_8 c0001;
end
class DFA8 c0001;
subgraph DFA9["DFA9 1 NFA States"]
NFA7_1_9[\"NFA7-1 char[1]
AcceptToken '['"/]
class NFA7_1_9 c0001;
end
class DFA9 c0001;
subgraph DFA10["DFA10 1 NFA States"]
NFA6_1_10[\"NFA6-1 char[1]
AcceptToken ';'"/]
class NFA6_1_10 c0001;
end
class DFA10 c0001;
subgraph DFA11["DFA11 1 NFA States"]
NFA5_1_11[\"NFA5-1 char[1]
AcceptToken ','"/]
class NFA5_1_11 c0001;
end
class DFA11 c0001;
subgraph DFA12["DFA12 1 NFA States"]
NFA3_1_12[\"NFA3-1 char[1]
AcceptToken ')'"/]
class NFA3_1_12 c0001;
end
class DFA12 c0001;
subgraph DFA13["DFA13 1 NFA States"]
NFA2_1_13[\"NFA2-1 char[1]
AcceptToken '('"/]
class NFA2_1_13 c0001;
end
class DFA13 c0001;
subgraph DFA14["DFA14 2 NFA States"]
NFA61_1_14[\"NFA61-1 scope[1]
AcceptToken 'identifier'"/]
class NFA61_1_14 c0001;
NFA62_1_15("NFA62-1 scope[1]")
class NFA62_1_15 c1000;
end
class DFA14 c1001;
subgraph DFA15["DFA15 2 NFA States"]
NFA25_1_16("NFA25-1 char[1]")
NFA35_1_17[\"NFA35-1 char[1]
AcceptToken '='"/]
class NFA35_1_17 c0001;
end
class DFA15 c0001;
subgraph DFA16["DFA16 2 NFA States"]
NFA18_1_18[\"NFA18-1 char[1]
AcceptToken '%'"/]
class NFA18_1_18 c0001;
NFA38_1_19("NFA38-1 char[1]")
end
class DFA16 c0001;
subgraph DFA17["DFA17 2 NFA States"]
NFA16_1_20[\"NFA16-1 char[1]
AcceptToken '*'"/]
class NFA16_1_20 c0001;
NFA36_1_21("NFA36-1 char[1]")
end
class DFA17 c0001;
subgraph DFA18["DFA18 2 NFA States"]
NFA14_1_22[\"NFA14-1 char[1]
AcceptToken '!'"/]
class NFA14_1_22 c0001;
NFA26_1_23("NFA26-1 char[1]")
end
class DFA18 c0001;
subgraph DFA19["DFA19 3 NFA States"]
NFA61_1_24[\"NFA61-1 scope[1]
AcceptToken 'identifier'"/]
class NFA61_1_24 c0001;
NFA62_1_25("NFA62-1 scope[1]")
class NFA62_1_25 c1000;
NFA70_1_26("NFA70-1 char[1]")
end
class DFA19 c1001;
subgraph DFA20["DFA20 3 NFA States"]
NFA61_1_27[\"NFA61-1 scope[1]
AcceptToken 'identifier'"/]
class NFA61_1_27 c0001;
NFA62_1_28("NFA62-1 scope[1]")
class NFA62_1_28 c1000;
NFA69_1_29("NFA69-1 char[1]")
end
class DFA20 c1001;
subgraph DFA21["DFA21 3 NFA States"]
NFA60_1_30("NFA60-1 char[1]")
NFA61_1_31[\"NFA61-1 scope[1]
AcceptToken 'identifier'"/]
class NFA61_1_31 c0001;
NFA62_1_32("NFA62-1 scope[1]")
class NFA62_1_32 c1000;
end
class DFA21 c1001;
subgraph DFA22["DFA22 3 NFA States"]
NFA29_1_33[\"NFA29-1 char[1]
AcceptToken '|'"/]
class NFA29_1_33 c0001;
NFA32_1_34("NFA32-1 char[1]")
NFA45_1_35("NFA45-1 char[1]")
end
class DFA22 c0001;
subgraph DFA23["DFA23 3 NFA States"]
NFA28_1_36[\"NFA28-1 char[1]
AcceptToken '^'"/]
class NFA28_1_36 c0001;
NFA31_1_37("NFA31-1 char[1]")
NFA44_1_38("NFA44-1 char[1]")
end
class DFA23 c0001;
subgraph DFA24["DFA24 3 NFA States"]
NFA27_1_39[\"NFA27-1 char[1]
AcceptToken '&'"/]
class NFA27_1_39 c0001;
NFA30_1_40("NFA30-1 char[1]")
NFA43_1_41("NFA43-1 char[1]")
end
class DFA24 c0001;
subgraph DFA25["DFA25 4 NFA States"]
NFA20_1_42("NFA20-1 char[1]")
NFA22_1_43[\"NFA22-1 char[1]
AcceptToken '>'"/]
class NFA22_1_43 c0001;
NFA24_1_44("NFA24-1 char[1]")
NFA42_1_45("NFA42-1 char[1]")
end
class DFA25 c0001;
subgraph DFA26["DFA26 4 NFA States"]
NFA19_1_46("NFA19-1 char[1]")
NFA21_1_47[\"NFA21-1 char[1]
AcceptToken '<'"/]
class NFA21_1_47 c0001;
NFA23_1_48("NFA23-1 char[1]")
NFA41_1_49("NFA41-1 char[1]")
end
class DFA26 c0001;
subgraph DFA27["DFA27 3 NFA States"]
NFA17_1_50[\"NFA17-1 char[1]
AcceptToken '/'"/]
class NFA17_1_50 c0001;
NFA37_1_51("NFA37-1 char[1]")
NFA72_1_52("NFA72-1 char[1]")
end
class DFA27 c0001;
subgraph DFA28["DFA28 5 NFA States"]
NFA63_1_53[\"NFA63-1 scope[1]
AcceptToken 'number'"/]
class NFA63_1_53 c0001;
NFA64_3_54[\"NFA64-3 scope[1]
AcceptToken 'intConstant'"/]
class NFA64_3_54 c0001;
NFA66_3_55("NFA66-3 scope[1]")
NFA68_3_56("NFA68-3 scope[1]")
NFA71_3_57[\"NFA71-3 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_3_57 c0001;
end
class DFA28 c0001;
subgraph DFA29["DFA29 7 NFA States"]
NFA63_1_58[\"NFA63-1 scope[1]
AcceptToken 'number'"/]
class NFA63_1_58 c0001;
NFA65_1_59("NFA65-1 char[1]")
NFA67_1_60("NFA67-1 char[1]")
NFA64_3_61[\"NFA64-3 scope[1]
AcceptToken 'intConstant'"/]
class NFA64_3_61 c0001;
NFA66_3_62("NFA66-3 scope[1]")
NFA68_3_63("NFA68-3 scope[1]")
NFA71_3_64[\"NFA71-3 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_3_64 c0001;
end
class DFA29 c0001;
subgraph DFA30["DFA30 7 NFA States"]
NFA11_1_65("NFA11-1 char[1]")
NFA13_1_66[\"NFA13-1 char[1]
AcceptToken '-'"/]
class NFA13_1_66 c0001;
NFA40_1_67("NFA40-1 char[1]")
NFA64_1_68("NFA64-1 scope[1]")
class NFA64_1_68 c1000;
NFA66_1_69("NFA66-1 scope[1]")
class NFA66_1_69 c1000;
NFA68_1_70("NFA68-1 scope[1]")
class NFA68_1_70 c1000;
NFA71_1_71("NFA71-1 scope[1]")
class NFA71_1_71 c1000;
end
class DFA30 c1001;
subgraph DFA31["DFA31 7 NFA States"]
NFA10_1_72("NFA10-1 char[1]")
NFA12_1_73[\"NFA12-1 char[1]
AcceptToken '+'"/]
class NFA12_1_73 c0001;
NFA39_1_74("NFA39-1 char[1]")
NFA64_1_75("NFA64-1 scope[1]")
class NFA64_1_75 c1000;
NFA66_1_76("NFA66-1 scope[1]")
class NFA66_1_76 c1000;
NFA68_1_77("NFA68-1 scope[1]")
class NFA68_1_77 c1000;
NFA71_1_78("NFA71-1 scope[1]")
class NFA71_1_78 c1000;
end
class DFA31 c1001;
subgraph DFA32["DFA32 14 NFA States"]
NFA1_1_79("NFA1-1 char[1]")
NFA4_1_80("NFA4-1 char[1]")
NFA48_1_81("NFA48-1 char[1]")
NFA49_1_82("NFA49-1 char[1]")
NFA50_1_83("NFA50-1 char[1]")
NFA51_1_84("NFA51-1 char[1]")
NFA52_1_85("NFA52-1 char[1]")
NFA53_1_86("NFA53-1 char[1]")
NFA54_1_87("NFA54-1 char[1]")
NFA55_1_88("NFA55-1 char[1]")
NFA56_1_89("NFA56-1 char[1]")
NFA57_1_90("NFA57-1 char[1]")
NFA58_1_91("NFA58-1 char[1]")
NFA59_1_92("NFA59-1 char[1]")
end
subgraph DFA33["DFA33 1 NFA States"]
NFA62_13_93[\"NFA62-13 char[1]
AcceptToken 'literalString'"/]
class NFA62_13_93 c0001;
end
class DFA33 c0001;
subgraph DFA34["DFA34 1 NFA States"]
NFA62_11_94("NFA62-11 scope[1]")
end
subgraph DFA35["DFA35 1 NFA States"]
NFA62_5_95("NFA62-5 char[1]")
end
subgraph DFA36["DFA36 1 NFA States"]
NFA61_2_96[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_96 c0001;
end
class DFA36 c0001;
subgraph DFA37["DFA37 1 NFA States"]
NFA25_3_97[\"NFA25-3 char[1]
AcceptToken '=='"/]
class NFA25_3_97 c0001;
end
class DFA37 c0001;
subgraph DFA38["DFA38 1 NFA States"]
NFA38_3_98[\"NFA38-3 char[1]
AcceptToken '%='"/]
class NFA38_3_98 c0001;
end
class DFA38 c0001;
subgraph DFA39["DFA39 1 NFA States"]
NFA36_3_99[\"NFA36-3 char[1]
AcceptToken '*='"/]
class NFA36_3_99 c0001;
end
class DFA39 c0001;
subgraph DFA40["DFA40 1 NFA States"]
NFA26_3_100[\"NFA26-3 char[1]
AcceptToken '!='"/]
class NFA26_3_100 c0001;
end
class DFA40 c0001;
subgraph DFA41["DFA41 2 NFA States"]
NFA61_2_101[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_101 c0001;
NFA70_3_102("NFA70-3 char[1]")
end
class DFA41 c0001;
subgraph DFA42["DFA42 2 NFA States"]
NFA61_2_103[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_103 c0001;
NFA69_3_104("NFA69-3 char[1]")
end
class DFA42 c0001;
subgraph DFA43["DFA43 2 NFA States"]
NFA60_3_105("NFA60-3 char[1]")
NFA61_2_106[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_106 c0001;
end
class DFA43 c0001;
subgraph DFA44["DFA44 1 NFA States"]
NFA45_3_107[\"NFA45-3 char[1]
AcceptToken '|='"/]
class NFA45_3_107 c0001;
end
class DFA44 c0001;
subgraph DFA45["DFA45 1 NFA States"]
NFA32_3_108[\"NFA32-3 char[1]
AcceptToken '||'"/]
class NFA32_3_108 c0001;
end
class DFA45 c0001;
subgraph DFA46["DFA46 1 NFA States"]
NFA44_3_109[\"NFA44-3 char[1]
AcceptToken '^='"/]
class NFA44_3_109 c0001;
end
class DFA46 c0001;
subgraph DFA47["DFA47 1 NFA States"]
NFA31_3_110[\"NFA31-3 char[1]
AcceptToken '^^'"/]
class NFA31_3_110 c0001;
end
class DFA47 c0001;
subgraph DFA48["DFA48 1 NFA States"]
NFA43_3_111[\"NFA43-3 char[1]
AcceptToken '&='"/]
class NFA43_3_111 c0001;
end
class DFA48 c0001;
subgraph DFA49["DFA49 1 NFA States"]
NFA30_3_112[\"NFA30-3 char[1]
AcceptToken '&&'"/]
class NFA30_3_112 c0001;
end
class DFA49 c0001;
subgraph DFA50["DFA50 1 NFA States"]
NFA24_3_113[\"NFA24-3 char[1]
AcceptToken '>='"/]
class NFA24_3_113 c0001;
end
class DFA50 c0001;
subgraph DFA51["DFA51 2 NFA States"]
NFA20_3_114[\"NFA20-3 char[1]
AcceptToken '>>'"/]
class NFA20_3_114 c0001;
NFA42_3_115("NFA42-3 char[1]")
end
class DFA51 c0001;
subgraph DFA52["DFA52 1 NFA States"]
NFA23_3_116[\"NFA23-3 char[1]
AcceptToken '<='"/]
class NFA23_3_116 c0001;
end
class DFA52 c0001;
subgraph DFA53["DFA53 2 NFA States"]
NFA19_3_117[\"NFA19-3 char[1]
AcceptToken '<<'"/]
class NFA19_3_117 c0001;
NFA41_3_118("NFA41-3 char[1]")
end
class DFA53 c0001;
subgraph DFA54["DFA54 1 NFA States"]
NFA72_3_119[\"NFA72-3 char[1]
AcceptToken 'inlineComment'"/]
class NFA72_3_119 c0001;
end
class DFA54 c0001;
subgraph DFA55["DFA55 1 NFA States"]
NFA37_3_120[\"NFA37-3 char[1]
AcceptToken '/='"/]
class NFA37_3_120 c0001;
end
class DFA55 c0001;
subgraph DFA56["DFA56 1 NFA States"]
NFA68_18_121[\"NFA68-18 scope[1]
AcceptToken 'floatConstant'"/]
class NFA68_18_121 c0001;
end
class DFA56 c0001;
subgraph DFA57["DFA57 1 NFA States"]
NFA66_5_122[\"NFA66-5 scope[1]
AcceptToken 'uintConstant'"/]
class NFA66_5_122 c0001;
end
class DFA57 c0001;
subgraph DFA58["DFA58 2 NFA States"]
NFA68_10_123("NFA68-10 scope[1]")
NFA71_10_124("NFA71-10 scope[1]")
end
subgraph DFA59["DFA59 3 NFA States"]
NFA63_3_125("NFA63-3 scope[1]")
NFA68_5_126("NFA68-5 scope[1]")
NFA71_5_127[\"NFA71-5 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_5_127 c0001;
end
class DFA59 c0001;
subgraph DFA60["DFA60 2 NFA States"]
NFA65_3_128("NFA65-3 char[1]")
NFA67_3_129("NFA67-3 char[1]")
end
subgraph DFA61["DFA61 1 NFA States"]
NFA40_3_130[\"NFA40-3 char[1]
AcceptToken '-='"/]
class NFA40_3_130 c0001;
end
class DFA61 c0001;
subgraph DFA62["DFA62 1 NFA States"]
NFA11_3_131[\"NFA11-3 char[1]
AcceptToken '--'"/]
class NFA11_3_131 c0001;
end
class DFA62 c0001;
subgraph DFA63["DFA63 4 NFA States"]
NFA64_3_132[\"NFA64-3 scope[1]
AcceptToken 'intConstant'"/]
class NFA64_3_132 c0001;
NFA66_3_133("NFA66-3 scope[1]")
NFA68_3_134("NFA68-3 scope[1]")
NFA71_3_135[\"NFA71-3 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_3_135 c0001;
end
class DFA63 c0001;
subgraph DFA64["DFA64 1 NFA States"]
NFA39_3_136[\"NFA39-3 char[1]
AcceptToken '+='"/]
class NFA39_3_136 c0001;
end
class DFA64 c0001;
subgraph DFA65["DFA65 1 NFA States"]
NFA10_3_137[\"NFA10-3 char[1]
AcceptToken '++'"/]
class NFA10_3_137 c0001;
end
class DFA65 c0001;
subgraph DFA66["DFA66 1 NFA States"]
NFA59_3_138("NFA59-3 char[1]")
end
subgraph DFA67["DFA67 1 NFA States"]
NFA58_3_139("NFA58-3 char[1]")
end
subgraph DFA68["DFA68 1 NFA States"]
NFA56_3_140("NFA56-3 char[1]")
end
subgraph DFA69["DFA69 1 NFA States"]
NFA48_3_141[\"NFA48-3 char[1]
AcceptToken '##'"/]
class NFA48_3_141 c0001;
end
class DFA69 c0001;
subgraph DFA70["DFA70 1 NFA States"]
NFA4_3_142("NFA4-3 char[1]")
end
subgraph DFA71["DFA71 1 NFA States"]
NFA1_3_143("NFA1-3 char[1]")
end
subgraph DFA72["DFA72 3 NFA States"]
NFA49_3_144("NFA49-3 char[1]")
NFA50_3_145("NFA50-3 char[1]")
NFA51_3_146("NFA51-3 char[1]")
end
subgraph DFA73["DFA73 5 NFA States"]
NFA52_3_147("NFA52-3 char[1]")
NFA53_3_148("NFA53-3 char[1]")
NFA54_3_149("NFA54-3 char[1]")
NFA55_3_150("NFA55-3 char[1]")
NFA57_3_151("NFA57-3 char[1]")
end
subgraph DFA74["DFA74 1 NFA States"]
NFA62_7_152("NFA62-7 char[1]")
end
subgraph DFA75["DFA75 2 NFA States"]
NFA61_2_153[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_153 c0001;
NFA70_5_154("NFA70-5 char[1]")
end
class DFA75 c0001;
subgraph DFA76["DFA76 2 NFA States"]
NFA61_2_155[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_155 c0001;
NFA69_5_156("NFA69-5 char[1]")
end
class DFA76 c0001;
subgraph DFA77["DFA77 2 NFA States"]
NFA60_5_157("NFA60-5 char[1]")
NFA61_2_158[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_158 c0001;
end
class DFA77 c0001;
subgraph DFA78["DFA78 1 NFA States"]
NFA42_5_159[\"NFA42-5 char[1]
AcceptToken '>>='"/]
class NFA42_5_159 c0001;
end
class DFA78 c0001;
subgraph DFA79["DFA79 1 NFA States"]
NFA41_5_160[\"NFA41-5 char[1]
AcceptToken '<<='"/]
class NFA41_5_160 c0001;
end
class DFA79 c0001;
subgraph DFA80["DFA80 1 NFA States"]
NFA72_4_161[\"NFA72-4 scope{0, -1}
AcceptToken 'inlineComment'"/]
class NFA72_4_161 c0001;
end
class DFA80 c0001;
subgraph DFA81["DFA81 2 NFA States"]
NFA68_14_162("NFA68-14 scope[1]")
NFA71_14_163[\"NFA71-14 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_14_163 c0001;
end
class DFA81 c0001;
subgraph DFA82["DFA82 2 NFA States"]
NFA68_12_164("NFA68-12 scope[1]")
NFA71_12_165("NFA71-12 scope[1]")
end
subgraph DFA83["DFA83 2 NFA States"]
NFA68_5_166("NFA68-5 scope[1]")
NFA71_5_167[\"NFA71-5 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_5_167 c0001;
end
class DFA83 c0001;
subgraph DFA84["DFA84 3 NFA States"]
NFA63_5_168[\"NFA63-5 scope[1]
AcceptToken 'number'"/]
class NFA63_5_168 c0001;
NFA68_6_169("NFA68-6 scope{0, -1}")
NFA71_6_170[\"NFA71-6 scope{0, -1}
AcceptToken 'doubleConstant'"/]
class NFA71_6_170 c0001;
end
class DFA84 c0001;
subgraph DFA85["DFA85 2 NFA States"]
NFA65_5_171[\"NFA65-5 scope[1]
AcceptToken 'intConstant'"/]
class NFA65_5_171 c0001;
NFA67_5_172("NFA67-5 scope[1]")
end
class DFA85 c0001;
subgraph DFA86["DFA86 2 NFA States"]
NFA68_5_173("NFA68-5 scope[1]")
NFA71_5_174[\"NFA71-5 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_5_174 c0001;
end
class DFA86 c0001;
subgraph DFA87["DFA87 1 NFA States"]
NFA59_5_175("NFA59-5 char[1]")
end
subgraph DFA88["DFA88 1 NFA States"]
NFA58_5_176("NFA58-5 char[1]")
end
subgraph DFA89["DFA89 1 NFA States"]
NFA56_5_177("NFA56-5 char[1]")
end
subgraph DFA90["DFA90 1 NFA States"]
NFA4_5_178("NFA4-5 char[1]")
end
subgraph DFA91["DFA91 1 NFA States"]
NFA1_5_179("NFA1-5 char[1]")
end
subgraph DFA92["DFA92 3 NFA States"]
NFA49_5_180[\"NFA49-5 char[1]
AcceptToken '#if'"/]
class NFA49_5_180 c0001;
NFA50_5_181("NFA50-5 char[1]")
NFA51_5_182("NFA51-5 char[1]")
end
class DFA92 c0001;
subgraph DFA93["DFA93 1 NFA States"]
NFA57_5_183("NFA57-5 char[1]")
end
subgraph DFA94["DFA94 1 NFA States"]
NFA55_5_184("NFA55-5 char[1]")
end
subgraph DFA95["DFA95 1 NFA States"]
NFA54_5_185("NFA54-5 char[1]")
end
subgraph DFA96["DFA96 2 NFA States"]
NFA52_5_186("NFA52-5 char[1]")
NFA53_5_187("NFA53-5 char[1]")
end
subgraph DFA97["DFA97 2 NFA States"]
NFA61_2_188[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_188 c0001;
NFA70_7_189("NFA70-7 char[1]")
end
class DFA97 c0001;
subgraph DFA98["DFA98 2 NFA States"]
NFA61_2_190[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_190 c0001;
NFA69_7_191("NFA69-7 char[1]")
end
class DFA98 c0001;
subgraph DFA99["DFA99 2 NFA States"]
NFA60_7_192("NFA60-7 char[1]")
NFA61_2_193[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_193 c0001;
end
class DFA99 c0001;
subgraph DFA100["DFA100 2 NFA States"]
NFA68_10_194("NFA68-10 scope[1]")
NFA71_10_195("NFA71-10 scope[1]")
end
subgraph DFA101["DFA101 2 NFA States"]
NFA68_6_196("NFA68-6 scope{0, -1}")
NFA71_6_197[\"NFA71-6 scope{0, -1}
AcceptToken 'doubleConstant'"/]
class NFA71_6_197 c0001;
end
class DFA101 c0001;
subgraph DFA102["DFA102 3 NFA States"]
NFA63_3_198("NFA63-3 scope[1]")
NFA68_5_199("NFA68-5 scope[1]")
NFA71_5_200[\"NFA71-5 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_5_200 c0001;
end
class DFA102 c0001;
subgraph DFA103["DFA103 1 NFA States"]
NFA67_7_201[\"NFA67-7 scope[1]
AcceptToken 'uintConstant'"/]
class NFA67_7_201 c0001;
end
class DFA103 c0001;
subgraph DFA104["DFA104 2 NFA States"]
NFA68_6_202("NFA68-6 scope{0, -1}")
NFA71_6_203[\"NFA71-6 scope{0, -1}
AcceptToken 'doubleConstant'"/]
class NFA71_6_203 c0001;
end
class DFA104 c0001;
subgraph DFA105["DFA105 1 NFA States"]
NFA59_7_204("NFA59-7 char[1]")
end
subgraph DFA106["DFA106 1 NFA States"]
NFA58_7_205("NFA58-7 char[1]")
end
subgraph DFA107["DFA107 1 NFA States"]
NFA56_7_206("NFA56-7 char[1]")
end
subgraph DFA108["DFA108 1 NFA States"]
NFA4_7_207("NFA4-7 char[1]")
end
subgraph DFA109["DFA109 1 NFA States"]
NFA1_7_208("NFA1-7 char[1]")
end
subgraph DFA110["DFA110 1 NFA States"]
NFA51_7_209("NFA51-7 char[1]")
end
subgraph DFA111["DFA111 1 NFA States"]
NFA50_7_210("NFA50-7 char[1]")
end
subgraph DFA112["DFA112 1 NFA States"]
NFA57_7_211("NFA57-7 char[1]")
end
subgraph DFA113["DFA113 1 NFA States"]
NFA55_7_212("NFA55-7 char[1]")
end
subgraph DFA114["DFA114 1 NFA States"]
NFA54_7_213("NFA54-7 char[1]")
end
subgraph DFA115["DFA115 1 NFA States"]
NFA53_7_214("NFA53-7 char[1]")
end
subgraph DFA116["DFA116 1 NFA States"]
NFA52_7_215("NFA52-7 char[1]")
end
subgraph DFA117["DFA117 2 NFA States"]
NFA61_2_216[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_216 c0001;
NFA70_9_217("NFA70-9 char[1]")
end
class DFA117 c0001;
subgraph DFA118["DFA118 1 NFA States"]
NFA69_11_218[\"NFA69-11 scope[1]
AcceptToken 'boolConstant'"/]
class NFA69_11_218 c0001;
end
class DFA118 c0001;
subgraph DFA119["DFA119 2 NFA States"]
NFA60_9_219("NFA60-9 char[1]")
NFA61_2_220[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_220 c0001;
end
class DFA119 c0001;
subgraph DFA120["DFA120 2 NFA States"]
NFA68_14_221("NFA68-14 scope[1]")
NFA71_14_222[\"NFA71-14 scope[1]
AcceptToken 'doubleConstant'"/]
class NFA71_14_222 c0001;
end
class DFA120 c0001;
subgraph DFA121["DFA121 2 NFA States"]
NFA68_12_223("NFA68-12 scope[1]")
NFA71_12_224("NFA71-12 scope[1]")
end
subgraph DFA122["DFA122 3 NFA States"]
NFA63_5_225[\"NFA63-5 scope[1]
AcceptToken 'number'"/]
class NFA63_5_225 c0001;
NFA68_6_226("NFA68-6 scope{0, -1}")
NFA71_6_227[\"NFA71-6 scope{0, -1}
AcceptToken 'doubleConstant'"/]
class NFA71_6_227 c0001;
end
class DFA122 c0001;
subgraph DFA123["DFA123 1 NFA States"]
NFA59_9_228[\"NFA59-9 char[1]
AcceptToken '#line'"/]
class NFA59_9_228 c0001;
end
class DFA123 c0001;
subgraph DFA124["DFA124 1 NFA States"]
NFA58_9_229("NFA58-9 char[1]")
end
subgraph DFA125["DFA125 1 NFA States"]
NFA56_9_230("NFA56-9 char[1]")
end
subgraph DFA126["DFA126 1 NFA States"]
NFA4_9_231("NFA4-9 char[1]")
end
subgraph DFA127["DFA127 1 NFA States"]
NFA1_9_232("NFA1-9 char[1]")
end
subgraph DFA128["DFA128 1 NFA States"]
NFA51_9_233("NFA51-9 char[1]")
end
subgraph DFA129["DFA129 1 NFA States"]
NFA50_9_234("NFA50-9 char[1]")
end
subgraph DFA130["DFA130 1 NFA States"]
NFA57_9_235("NFA57-9 char[1]")
end
subgraph DFA131["DFA131 1 NFA States"]
NFA55_9_236("NFA55-9 char[1]")
end
subgraph DFA132["DFA132 1 NFA States"]
NFA54_9_237("NFA54-9 char[1]")
end
subgraph DFA133["DFA133 1 NFA States"]
NFA53_9_238[\"NFA53-9 char[1]
AcceptToken '#elif'"/]
class NFA53_9_238 c0001;
end
class DFA133 c0001;
subgraph DFA134["DFA134 1 NFA States"]
NFA52_9_239[\"NFA52-9 char[1]
AcceptToken '#else'"/]
class NFA52_9_239 c0001;
end
class DFA134 c0001;
subgraph DFA135["DFA135 1 NFA States"]
NFA70_13_240[\"NFA70-13 scope[1]
AcceptToken 'boolConstant'"/]
class NFA70_13_240 c0001;
end
class DFA135 c0001;
subgraph DFA136["DFA136 2 NFA States"]
NFA60_11_241("NFA60-11 char[1]")
NFA61_2_242[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_242 c0001;
end
class DFA136 c0001;
subgraph DFA137["DFA137 1 NFA States"]
NFA58_11_243("NFA58-11 char[1]")
end
subgraph DFA138["DFA138 1 NFA States"]
NFA56_11_244("NFA56-11 char[1]")
end
subgraph DFA139["DFA139 1 NFA States"]
NFA4_11_245[\"NFA4-11 char[1]
AcceptToken '#undef'"/]
class NFA4_11_245 c0001;
end
class DFA139 c0001;
subgraph DFA140["DFA140 1 NFA States"]
NFA1_11_246("NFA1-11 char[1]")
end
subgraph DFA141["DFA141 1 NFA States"]
NFA51_11_247("NFA51-11 char[1]")
end
subgraph DFA142["DFA142 1 NFA States"]
NFA50_11_248[\"NFA50-11 char[1]
AcceptToken '#ifdef'"/]
class NFA50_11_248 c0001;
end
class DFA142 c0001;
subgraph DFA143["DFA143 1 NFA States"]
NFA57_11_249("NFA57-11 char[1]")
end
subgraph DFA144["DFA144 1 NFA States"]
NFA55_11_250[\"NFA55-11 char[1]
AcceptToken '#error'"/]
class NFA55_11_250 c0001;
end
class DFA144 c0001;
subgraph DFA145["DFA145 1 NFA States"]
NFA54_11_251[\"NFA54-11 char[1]
AcceptToken '#endif'"/]
class NFA54_11_251 c0001;
end
class DFA145 c0001;
subgraph DFA146["DFA146 2 NFA States"]
NFA60_13_252[\"NFA60-13 char[1]
AcceptToken 'defined'"/]
class NFA60_13_252 c0001;
NFA61_2_253[\"NFA61-2 scope{0, -1}
AcceptToken 'identifier'"/]
class NFA61_2_253 c0001;
end
class DFA146 c0001;
subgraph DFA147["DFA147 1 NFA States"]
NFA58_13_254("NFA58-13 char[1]")
end
subgraph DFA148["DFA148 1 NFA States"]
NFA56_13_255[\"NFA56-13 char[1]
AcceptToken '#pragma'"/]
class NFA56_13_255 c0001;
end
class DFA148 c0001;
subgraph DFA149["DFA149 1 NFA States"]
NFA1_13_256[\"NFA1-13 char[1]
AcceptToken '#define'"/]
class NFA1_13_256 c0001;
end
class DFA149 c0001;
subgraph DFA150["DFA150 1 NFA States"]
NFA51_13_257[\"NFA51-13 char[1]
AcceptToken '#ifndef'"/]
class NFA51_13_257 c0001;
end
class DFA150 c0001;
subgraph DFA151["DFA151 1 NFA States"]
NFA57_13_258("NFA57-13 char[1]")
end
subgraph DFA152["DFA152 1 NFA States"]
NFA58_15_259[\"NFA58-15 char[1]
AcceptToken '#version'"/]
class NFA58_15_259 c0001;
end
class DFA152 c0001;
subgraph DFA153["DFA153 1 NFA States"]
NFA57_15_260("NFA57-15 char[1]")
end
subgraph DFA154["DFA154 1 NFA States"]
NFA57_17_261("NFA57-17 char[1]")
end
subgraph DFA155["DFA155 1 NFA States"]
NFA57_19_262[\"NFA57-19 char[1]
AcceptToken '#extension'"/]
class NFA57_19_262 c0001;
end
class DFA155 c0001;
DFA0 -->|"#34;
BeginToken 'literalString' "|DFA1
DFA0 -->|"}
BeginToken '}' 
ExtendToken '}' "|DFA2
DFA0 -->|"#92;{
BeginToken '{' 
ExtendToken '{' "|DFA3
DFA0 -->|":
BeginToken ':' 
ExtendToken ':' "|DFA4
DFA0 -->|"#92;?
BeginToken '?' 
ExtendToken '?' "|DFA5
DFA0 -->|"~
BeginToken '~' 
ExtendToken '~' "|DFA6
DFA0 -->|"#92;.
BeginToken '.' 
ExtendToken '.' "|DFA7
DFA0 -->|"]
BeginToken ']' 
ExtendToken ']' "|DFA8
DFA0 -->|"#92;[
BeginToken '[' 
ExtendToken '[' "|DFA9
DFA0 -->|";
BeginToken ';' 
ExtendToken ';' "|DFA10
DFA0 -->|",
BeginToken ',' 
ExtendToken ',' "|DFA11
DFA0 -->|"#92;)
BeginToken ')' 
ExtendToken ')' "|DFA12
DFA0 -->|"#92;(
BeginToken '(' 
ExtendToken '(' "|DFA13
DFA0 -->|"[A-Z]_[a-c]e[g-s][u-z]
BeginToken 'identifier' 'literalString' 
ExtendToken 'identifier' "|DFA14
DFA0 -->|"=
BeginToken '==' '=' 
ExtendToken '=' "|DFA15
DFA0 -->|"%
BeginToken '%' '%=' 
ExtendToken '%' "|DFA16
DFA0 -->|"#92;#42;
BeginToken '#42;' '#42;=' 
ExtendToken '#42;' "|DFA17
DFA0 -->|"!
BeginToken '!' '!=' 
ExtendToken '!' "|DFA18
DFA0 -->|"f
BeginToken 'identifier' 'literalString' 'boolConstant' 
ExtendToken 'identifier' "|DFA19
DFA0 -->|"t
BeginToken 'identifier' 'literalString' 'boolConstant' 
ExtendToken 'identifier' "|DFA20
DFA0 -->|"d
BeginToken 'defined' 'identifier' 'literalString' 
ExtendToken 'identifier' "|DFA21
DFA0 -->|"#92;|
BeginToken '|' '||' '|=' 
ExtendToken '|' "|DFA22
DFA0 -->|"^
BeginToken '^' '^^' '^=' 
ExtendToken '^' "|DFA23
DFA0 -->|"&
BeginToken '&' '&&' '&=' 
ExtendToken '&' "|DFA24
DFA0 -->|">
BeginToken '>>' '>' '>=' '>>=' 
ExtendToken '>' "|DFA25
DFA0 -->|"#92;<
BeginToken '<<' '<' '<=' '<<=' 
ExtendToken '<' "|DFA26
DFA0 -->|"#92;/
BeginToken '/' '/=' 'inlineComment' 
ExtendToken '/' "|DFA27
DFA0 -->|"[1-9]
BeginToken 'number' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'number' 'intConstant' 'doubleConstant' "|DFA28
DFA0 -->|"0
BeginToken 'number' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'number' 'intConstant' 'doubleConstant' "|DFA29
DFA0 -->|"-
BeginToken '--' '-' '-=' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken '-' "|DFA30
DFA0 -->|"#92;+
BeginToken '++' '+' '+=' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken '+' "|DFA31
DFA0 -->|"#35;
BeginToken '#35;define' '#35;undef' '#35;#35;' '#35;if' '#35;ifdef' '#35;ifndef' '#35;else' '#35;elif' '#35;endif' '#35;error' '#35;pragma' '#35;extension' '#35;version' '#35;line' "|DFA32
DFA1 -->|"#34;
ExtendToken 'literalString' "|DFA33
DFA1 -->|"[^#92;#92;#34;]"|DFA34
DFA1 -->|"#92;#92;"|DFA35
DFA14 -->|"#34;
BeginToken 'literalString' "|DFA1
DFA14 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|DFA36
DFA15 -->|"=
ExtendToken '==' "|DFA37
DFA16 -->|"=
ExtendToken '%=' "|DFA38
DFA17 -->|"=
ExtendToken '#42;=' "|DFA39
DFA18 -->|"=
ExtendToken '!=' "|DFA40
DFA19 -->|"#34;
BeginToken 'literalString' "|DFA1
DFA19 -->|"[0-9][A-Z]_[b-z]
ExtendToken 'identifier' "|DFA36
DFA19 -->|"a
ExtendToken 'identifier' "|DFA41
DFA20 -->|"#34;
BeginToken 'literalString' "|DFA1
DFA20 -->|"[0-9][A-Z]_[a-q][s-z]
ExtendToken 'identifier' "|DFA36
DFA20 -->|"r
ExtendToken 'identifier' "|DFA42
DFA21 -->|"#34;
BeginToken 'literalString' "|DFA1
DFA21 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|DFA36
DFA21 -->|"e
ExtendToken 'identifier' "|DFA43
DFA22 -->|"=
ExtendToken '|=' "|DFA44
DFA22 -->|"#92;|
ExtendToken '||' "|DFA45
DFA23 -->|"=
ExtendToken '^=' "|DFA46
DFA23 -->|"^
ExtendToken '^^' "|DFA47
DFA24 -->|"=
ExtendToken '&=' "|DFA48
DFA24 -->|"&
ExtendToken '&&' "|DFA49
DFA25 -->|"=
ExtendToken '>=' "|DFA50
DFA25 -->|">
ExtendToken '>>' "|DFA51
DFA26 -->|"=
ExtendToken '<=' "|DFA52
DFA26 -->|"#92;<
ExtendToken '<<' "|DFA53
DFA27 -->|"#92;/
ExtendToken 'inlineComment' "|DFA54
DFA27 -->|"=
ExtendToken '/=' "|DFA55
DFA28 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA28 -->|"[uU]
ExtendToken 'uintConstant' "|DFA57
DFA28 -->|"[Ee]"|DFA58
DFA28 -->|"[.]
ExtendToken 'doubleConstant' "|DFA59
DFA28 -->|"[0-9]
ExtendToken 'number' 'intConstant' 'doubleConstant' "|DFA28
DFA29 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA29 -->|"[uU]
ExtendToken 'uintConstant' "|DFA57
DFA29 -->|"[Ee]"|DFA58
DFA29 -->|"x"|DFA60
DFA29 -->|"[.]
ExtendToken 'doubleConstant' "|DFA59
DFA29 -->|"[0-9]
ExtendToken 'number' 'intConstant' 'doubleConstant' "|DFA28
DFA30 -->|"=
ExtendToken '-=' "|DFA61
DFA30 -->|"-
ExtendToken '--' "|DFA62
DFA30 -->|"[0-9]
BeginToken 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'intConstant' 'doubleConstant' "|DFA63
DFA31 -->|"=
ExtendToken '+=' "|DFA64
DFA31 -->|"#92;+
ExtendToken '++' "|DFA65
DFA31 -->|"[0-9]
BeginToken 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'intConstant' 'doubleConstant' "|DFA63
DFA32 -->|"l"|DFA66
DFA32 -->|"v"|DFA67
DFA32 -->|"p"|DFA68
DFA32 -->|"#35;
ExtendToken '#35;#35;' "|DFA69
DFA32 -->|"u"|DFA70
DFA32 -->|"d"|DFA71
DFA32 -->|"i"|DFA72
DFA32 -->|"e"|DFA73
DFA34 -->|"#34;
ExtendToken 'literalString' "|DFA33
DFA34 -->|"[^#92;#92;#34;]"|DFA34
DFA34 -->|"#92;#92;"|DFA35
DFA35 -->|"[#32;-~]"|DFA74
DFA36 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|DFA36
DFA41 -->|"[0-9][A-Z]_[a-k][m-z]
ExtendToken 'identifier' "|DFA36
DFA41 -->|"l
ExtendToken 'identifier' "|DFA75
DFA42 -->|"[0-9][A-Z]_[a-t][v-z]
ExtendToken 'identifier' "|DFA36
DFA42 -->|"u
ExtendToken 'identifier' "|DFA76
DFA43 -->|"[0-9][A-Z]_[a-e][g-z]
ExtendToken 'identifier' "|DFA36
DFA43 -->|"f
ExtendToken 'identifier' "|DFA77
DFA51 -->|"=
ExtendToken '>>=' "|DFA78
DFA53 -->|"=
ExtendToken '<<=' "|DFA79
DFA54 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment' "|DFA80
DFA58 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA81
DFA58 -->|"[-+]"|DFA82
DFA59 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA59 -->|"[Ee]"|DFA58
DFA59 -->|"[.]
ExtendToken 'doubleConstant' "|DFA83
DFA59 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|DFA84
DFA60 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant' "|DFA85
DFA63 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA63 -->|"[uU]
ExtendToken 'uintConstant' "|DFA57
DFA63 -->|"[Ee]"|DFA58
DFA63 -->|"[.]
ExtendToken 'doubleConstant' "|DFA86
DFA63 -->|"[0-9]
ExtendToken 'intConstant' 'doubleConstant' "|DFA63
DFA66 -->|"i"|DFA87
DFA67 -->|"e"|DFA88
DFA68 -->|"r"|DFA89
DFA70 -->|"n"|DFA90
DFA71 -->|"e"|DFA91
DFA72 -->|"f
ExtendToken '#35;if' "|DFA92
DFA73 -->|"x"|DFA93
DFA73 -->|"r"|DFA94
DFA73 -->|"n"|DFA95
DFA73 -->|"l"|DFA96
DFA74 -->|"#34;
ExtendToken 'literalString' "|DFA33
DFA74 -->|"[^#92;#92;#34;]"|DFA34
DFA74 -->|"#92;#92;"|DFA35
DFA75 -->|"[0-9][A-Z]_[a-r][t-z]
ExtendToken 'identifier' "|DFA36
DFA75 -->|"s
ExtendToken 'identifier' "|DFA97
DFA76 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|DFA36
DFA76 -->|"e
ExtendToken 'identifier' 'boolConstant' "|DFA98
DFA77 -->|"[0-9][A-Z]_[a-h][j-z]
ExtendToken 'identifier' "|DFA36
DFA77 -->|"i
ExtendToken 'identifier' "|DFA99
DFA80 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment' "|DFA80
DFA81 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA81 -->|"[Ee]"|DFA100
DFA81 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA81
DFA82 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA81
DFA83 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA83 -->|"[Ee]"|DFA58
DFA83 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA101
DFA84 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA84 -->|"[Ee]"|DFA58
DFA84 -->|"[.]
ExtendToken 'doubleConstant' "|DFA102
DFA84 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|DFA84
DFA85 -->|"[uU]
ExtendToken 'uintConstant' "|DFA103
DFA85 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant' "|DFA85
DFA86 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA86 -->|"[Ee]"|DFA58
DFA86 -->|"[.]
ExtendToken 'doubleConstant' "|DFA83
DFA86 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA104
DFA87 -->|"n"|DFA105
DFA88 -->|"r"|DFA106
DFA89 -->|"a"|DFA107
DFA90 -->|"d"|DFA108
DFA91 -->|"f"|DFA109
DFA92 -->|"n"|DFA110
DFA92 -->|"d"|DFA111
DFA93 -->|"t"|DFA112
DFA94 -->|"r"|DFA113
DFA95 -->|"d"|DFA114
DFA96 -->|"i"|DFA115
DFA96 -->|"s"|DFA116
DFA97 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|DFA36
DFA97 -->|"e
ExtendToken 'identifier' 'boolConstant' "|DFA117
DFA98 -->|"[^a-zA-Z0-9_]"|DFA118
DFA98 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|DFA36
DFA99 -->|"[0-9][A-Z]_[a-m][o-z]
ExtendToken 'identifier' "|DFA36
DFA99 -->|"n
ExtendToken 'identifier' "|DFA119
DFA100 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA120
DFA100 -->|"[-+]"|DFA121
DFA101 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA101 -->|"[Ee]"|DFA58
DFA101 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA101
DFA102 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA102 -->|"[Ee]"|DFA58
DFA102 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|DFA122
DFA104 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA104 -->|"[Ee]"|DFA58
DFA104 -->|"[.]
ExtendToken 'doubleConstant' "|DFA83
DFA104 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA104
DFA105 -->|"e
ExtendToken '#35;line' "|DFA123
DFA106 -->|"s"|DFA124
DFA107 -->|"g"|DFA125
DFA108 -->|"e"|DFA126
DFA109 -->|"i"|DFA127
DFA110 -->|"d"|DFA128
DFA111 -->|"e"|DFA129
DFA112 -->|"e"|DFA130
DFA113 -->|"o"|DFA131
DFA114 -->|"i"|DFA132
DFA115 -->|"f
ExtendToken '#35;elif' "|DFA133
DFA116 -->|"e
ExtendToken '#35;else' "|DFA134
DFA117 -->|"[^a-zA-Z0-9_]"|DFA135
DFA117 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|DFA36
DFA119 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|DFA36
DFA119 -->|"e
ExtendToken 'identifier' "|DFA136
DFA120 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA120 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA120
DFA121 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA120
DFA122 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA122 -->|"[Ee]"|DFA58
DFA122 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|DFA122
DFA124 -->|"i"|DFA137
DFA125 -->|"m"|DFA138
DFA126 -->|"f
ExtendToken '#35;undef' "|DFA139
DFA127 -->|"n"|DFA140
DFA128 -->|"e"|DFA141
DFA129 -->|"f
ExtendToken '#35;ifdef' "|DFA142
DFA130 -->|"n"|DFA143
DFA131 -->|"r
ExtendToken '#35;error' "|DFA144
DFA132 -->|"f
ExtendToken '#35;endif' "|DFA145
DFA136 -->|"[0-9][A-Z]_[a-c][e-z]
ExtendToken 'identifier' "|DFA36
DFA136 -->|"d
ExtendToken 'defined' 'identifier' "|DFA146
DFA137 -->|"o"|DFA147
DFA138 -->|"a
ExtendToken '#35;pragma' "|DFA148
DFA140 -->|"e
ExtendToken '#35;define' "|DFA149
DFA141 -->|"f
ExtendToken '#35;ifndef' "|DFA150
DFA143 -->|"s"|DFA151
DFA146 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|DFA36
DFA147 -->|"n
ExtendToken '#35;version' "|DFA152
DFA151 -->|"i"|DFA153
DFA153 -->|"o"|DFA154
DFA154 -->|"n
ExtendToken '#35;extension' "|DFA155

```

## 4/5: DFA.simple

```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
DFA0{{"DFA0 wholeStart"}}
class DFA0 c1000;
DFA1{{"DFA1 1 NFA States"}}
DFA2[\"DFA2 1 NFA States
AcceptToken '}'"/]
class DFA2 c0001;
DFA3[\"DFA3 1 NFA States
AcceptToken '{'"/]
class DFA3 c0001;
DFA4[\"DFA4 1 NFA States
AcceptToken ':'"/]
class DFA4 c0001;
DFA5[\"DFA5 1 NFA States
AcceptToken '?'"/]
class DFA5 c0001;
DFA6[\"DFA6 1 NFA States
AcceptToken '~'"/]
class DFA6 c0001;
DFA7[\"DFA7 1 NFA States
AcceptToken '.'"/]
class DFA7 c0001;
DFA8[\"DFA8 1 NFA States
AcceptToken ']'"/]
class DFA8 c0001;
DFA9[\"DFA9 1 NFA States
AcceptToken '['"/]
class DFA9 c0001;
DFA10[\"DFA10 1 NFA States
AcceptToken ';'"/]
class DFA10 c0001;
DFA11[\"DFA11 1 NFA States
AcceptToken ','"/]
class DFA11 c0001;
DFA12[\"DFA12 1 NFA States
AcceptToken ')'"/]
class DFA12 c0001;
DFA13[\"DFA13 1 NFA States
AcceptToken '('"/]
class DFA13 c0001;
DFA14[\"DFA14 2 NFA States
AcceptToken 'identifier'"/]
class DFA14 c1001;
DFA15[\"DFA15 2 NFA States
AcceptToken '='"/]
class DFA15 c0001;
DFA16[\"DFA16 2 NFA States
AcceptToken '%'"/]
class DFA16 c0001;
DFA17[\"DFA17 2 NFA States
AcceptToken '*'"/]
class DFA17 c0001;
DFA18[\"DFA18 2 NFA States
AcceptToken '!'"/]
class DFA18 c0001;
DFA19[\"DFA19 3 NFA States
AcceptToken 'identifier'"/]
class DFA19 c1001;
DFA20[\"DFA20 3 NFA States
AcceptToken 'identifier'"/]
class DFA20 c1001;
DFA21[\"DFA21 3 NFA States
AcceptToken 'identifier'"/]
class DFA21 c1001;
DFA22[\"DFA22 3 NFA States
AcceptToken '|'"/]
class DFA22 c0001;
DFA23[\"DFA23 3 NFA States
AcceptToken '^'"/]
class DFA23 c0001;
DFA24[\"DFA24 3 NFA States
AcceptToken '&'"/]
class DFA24 c0001;
DFA25[\"DFA25 4 NFA States
AcceptToken '>'"/]
class DFA25 c0001;
DFA26[\"DFA26 4 NFA States
AcceptToken '<'"/]
class DFA26 c0001;
DFA27[\"DFA27 3 NFA States
AcceptToken '/'"/]
class DFA27 c0001;
DFA28[\"DFA28 5 NFA States
AcceptToken 'number'
AcceptToken 'intConstant'
AcceptToken 'doubleConstant'"/]
class DFA28 c0001;
DFA29[\"DFA29 7 NFA States
AcceptToken 'number'
AcceptToken 'intConstant'
AcceptToken 'doubleConstant'"/]
class DFA29 c0001;
DFA30[\"DFA30 7 NFA States
AcceptToken '-'"/]
class DFA30 c1001;
DFA31[\"DFA31 7 NFA States
AcceptToken '+'"/]
class DFA31 c1001;
DFA32{{"DFA32 14 NFA States"}}
DFA33[\"DFA33 1 NFA States
AcceptToken 'literalString'"/]
class DFA33 c0001;
DFA34{{"DFA34 1 NFA States"}}
DFA35{{"DFA35 1 NFA States"}}
DFA36[\"DFA36 1 NFA States
AcceptToken 'identifier'"/]
class DFA36 c0001;
DFA37[\"DFA37 1 NFA States
AcceptToken '=='"/]
class DFA37 c0001;
DFA38[\"DFA38 1 NFA States
AcceptToken '%='"/]
class DFA38 c0001;
DFA39[\"DFA39 1 NFA States
AcceptToken '*='"/]
class DFA39 c0001;
DFA40[\"DFA40 1 NFA States
AcceptToken '!='"/]
class DFA40 c0001;
DFA41[\"DFA41 2 NFA States
AcceptToken 'identifier'"/]
class DFA41 c0001;
DFA42[\"DFA42 2 NFA States
AcceptToken 'identifier'"/]
class DFA42 c0001;
DFA43[\"DFA43 2 NFA States
AcceptToken 'identifier'"/]
class DFA43 c0001;
DFA44[\"DFA44 1 NFA States
AcceptToken '|='"/]
class DFA44 c0001;
DFA45[\"DFA45 1 NFA States
AcceptToken '||'"/]
class DFA45 c0001;
DFA46[\"DFA46 1 NFA States
AcceptToken '^='"/]
class DFA46 c0001;
DFA47[\"DFA47 1 NFA States
AcceptToken '^^'"/]
class DFA47 c0001;
DFA48[\"DFA48 1 NFA States
AcceptToken '&='"/]
class DFA48 c0001;
DFA49[\"DFA49 1 NFA States
AcceptToken '&&'"/]
class DFA49 c0001;
DFA50[\"DFA50 1 NFA States
AcceptToken '>='"/]
class DFA50 c0001;
DFA51[\"DFA51 2 NFA States
AcceptToken '>>'"/]
class DFA51 c0001;
DFA52[\"DFA52 1 NFA States
AcceptToken '<='"/]
class DFA52 c0001;
DFA53[\"DFA53 2 NFA States
AcceptToken '<<'"/]
class DFA53 c0001;
DFA54[\"DFA54 1 NFA States
AcceptToken 'inlineComment'"/]
class DFA54 c0001;
DFA55[\"DFA55 1 NFA States
AcceptToken '/='"/]
class DFA55 c0001;
DFA56[\"DFA56 1 NFA States
AcceptToken 'floatConstant'"/]
class DFA56 c0001;
DFA57[\"DFA57 1 NFA States
AcceptToken 'uintConstant'"/]
class DFA57 c0001;
DFA58{{"DFA58 2 NFA States"}}
DFA59[\"DFA59 3 NFA States
AcceptToken 'doubleConstant'"/]
class DFA59 c0001;
DFA60{{"DFA60 2 NFA States"}}
DFA61[\"DFA61 1 NFA States
AcceptToken '-='"/]
class DFA61 c0001;
DFA62[\"DFA62 1 NFA States
AcceptToken '--'"/]
class DFA62 c0001;
DFA63[\"DFA63 4 NFA States
AcceptToken 'intConstant'
AcceptToken 'doubleConstant'"/]
class DFA63 c0001;
DFA64[\"DFA64 1 NFA States
AcceptToken '+='"/]
class DFA64 c0001;
DFA65[\"DFA65 1 NFA States
AcceptToken '++'"/]
class DFA65 c0001;
DFA66{{"DFA66 1 NFA States"}}
DFA67{{"DFA67 1 NFA States"}}
DFA68{{"DFA68 1 NFA States"}}
DFA69[\"DFA69 1 NFA States
AcceptToken '##'"/]
class DFA69 c0001;
DFA70{{"DFA70 1 NFA States"}}
DFA71{{"DFA71 1 NFA States"}}
DFA72{{"DFA72 3 NFA States"}}
DFA73{{"DFA73 5 NFA States"}}
DFA74{{"DFA74 1 NFA States"}}
DFA75[\"DFA75 2 NFA States
AcceptToken 'identifier'"/]
class DFA75 c0001;
DFA76[\"DFA76 2 NFA States
AcceptToken 'identifier'"/]
class DFA76 c0001;
DFA77[\"DFA77 2 NFA States
AcceptToken 'identifier'"/]
class DFA77 c0001;
DFA78[\"DFA78 1 NFA States
AcceptToken '>>='"/]
class DFA78 c0001;
DFA79[\"DFA79 1 NFA States
AcceptToken '<<='"/]
class DFA79 c0001;
DFA80[\"DFA80 1 NFA States
AcceptToken 'inlineComment'"/]
class DFA80 c0001;
DFA81[\"DFA81 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA81 c0001;
DFA82{{"DFA82 2 NFA States"}}
DFA83[\"DFA83 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA83 c0001;
DFA84[\"DFA84 3 NFA States
AcceptToken 'number'
AcceptToken 'doubleConstant'"/]
class DFA84 c0001;
DFA85[\"DFA85 2 NFA States
AcceptToken 'intConstant'"/]
class DFA85 c0001;
DFA86[\"DFA86 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA86 c0001;
DFA87{{"DFA87 1 NFA States"}}
DFA88{{"DFA88 1 NFA States"}}
DFA89{{"DFA89 1 NFA States"}}
DFA90{{"DFA90 1 NFA States"}}
DFA91{{"DFA91 1 NFA States"}}
DFA92[\"DFA92 3 NFA States
AcceptToken '#if'"/]
class DFA92 c0001;
DFA93{{"DFA93 1 NFA States"}}
DFA94{{"DFA94 1 NFA States"}}
DFA95{{"DFA95 1 NFA States"}}
DFA96{{"DFA96 2 NFA States"}}
DFA97[\"DFA97 2 NFA States
AcceptToken 'identifier'"/]
class DFA97 c0001;
DFA98[\"DFA98 2 NFA States
AcceptToken 'identifier'"/]
class DFA98 c0001;
DFA99[\"DFA99 2 NFA States
AcceptToken 'identifier'"/]
class DFA99 c0001;
DFA100{{"DFA100 2 NFA States"}}
DFA101[\"DFA101 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA101 c0001;
DFA102[\"DFA102 3 NFA States
AcceptToken 'doubleConstant'"/]
class DFA102 c0001;
DFA103[\"DFA103 1 NFA States
AcceptToken 'uintConstant'"/]
class DFA103 c0001;
DFA104[\"DFA104 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA104 c0001;
DFA105{{"DFA105 1 NFA States"}}
DFA106{{"DFA106 1 NFA States"}}
DFA107{{"DFA107 1 NFA States"}}
DFA108{{"DFA108 1 NFA States"}}
DFA109{{"DFA109 1 NFA States"}}
DFA110{{"DFA110 1 NFA States"}}
DFA111{{"DFA111 1 NFA States"}}
DFA112{{"DFA112 1 NFA States"}}
DFA113{{"DFA113 1 NFA States"}}
DFA114{{"DFA114 1 NFA States"}}
DFA115{{"DFA115 1 NFA States"}}
DFA116{{"DFA116 1 NFA States"}}
DFA117[\"DFA117 2 NFA States
AcceptToken 'identifier'"/]
class DFA117 c0001;
DFA118[\"DFA118 1 NFA States
AcceptToken 'boolConstant'"/]
class DFA118 c0001;
DFA119[\"DFA119 2 NFA States
AcceptToken 'identifier'"/]
class DFA119 c0001;
DFA120[\"DFA120 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA120 c0001;
DFA121{{"DFA121 2 NFA States"}}
DFA122[\"DFA122 3 NFA States
AcceptToken 'number'
AcceptToken 'doubleConstant'"/]
class DFA122 c0001;
DFA123[\"DFA123 1 NFA States
AcceptToken '#line'"/]
class DFA123 c0001;
DFA124{{"DFA124 1 NFA States"}}
DFA125{{"DFA125 1 NFA States"}}
DFA126{{"DFA126 1 NFA States"}}
DFA127{{"DFA127 1 NFA States"}}
DFA128{{"DFA128 1 NFA States"}}
DFA129{{"DFA129 1 NFA States"}}
DFA130{{"DFA130 1 NFA States"}}
DFA131{{"DFA131 1 NFA States"}}
DFA132{{"DFA132 1 NFA States"}}
DFA133[\"DFA133 1 NFA States
AcceptToken '#elif'"/]
class DFA133 c0001;
DFA134[\"DFA134 1 NFA States
AcceptToken '#else'"/]
class DFA134 c0001;
DFA135[\"DFA135 1 NFA States
AcceptToken 'boolConstant'"/]
class DFA135 c0001;
DFA136[\"DFA136 2 NFA States
AcceptToken 'identifier'"/]
class DFA136 c0001;
DFA137{{"DFA137 1 NFA States"}}
DFA138{{"DFA138 1 NFA States"}}
DFA139[\"DFA139 1 NFA States
AcceptToken '#undef'"/]
class DFA139 c0001;
DFA140{{"DFA140 1 NFA States"}}
DFA141{{"DFA141 1 NFA States"}}
DFA142[\"DFA142 1 NFA States
AcceptToken '#ifdef'"/]
class DFA142 c0001;
DFA143{{"DFA143 1 NFA States"}}
DFA144[\"DFA144 1 NFA States
AcceptToken '#error'"/]
class DFA144 c0001;
DFA145[\"DFA145 1 NFA States
AcceptToken '#endif'"/]
class DFA145 c0001;
DFA146[\"DFA146 2 NFA States
AcceptToken 'defined'
AcceptToken 'identifier'"/]
class DFA146 c0001;
DFA147{{"DFA147 1 NFA States"}}
DFA148[\"DFA148 1 NFA States
AcceptToken '#pragma'"/]
class DFA148 c0001;
DFA149[\"DFA149 1 NFA States
AcceptToken '#define'"/]
class DFA149 c0001;
DFA150[\"DFA150 1 NFA States
AcceptToken '#ifndef'"/]
class DFA150 c0001;
DFA151{{"DFA151 1 NFA States"}}
DFA152[\"DFA152 1 NFA States
AcceptToken '#version'"/]
class DFA152 c0001;
DFA153{{"DFA153 1 NFA States"}}
DFA154{{"DFA154 1 NFA States"}}
DFA155[\"DFA155 1 NFA States
AcceptToken '#extension'"/]
class DFA155 c0001;
DFA0 -->|"#34;
BeginToken 'literalString' "|DFA1
DFA0 -->|"}
BeginToken '}' 
ExtendToken '}' "|DFA2
DFA0 -->|"#92;{
BeginToken '{' 
ExtendToken '{' "|DFA3
DFA0 -->|":
BeginToken ':' 
ExtendToken ':' "|DFA4
DFA0 -->|"#92;?
BeginToken '?' 
ExtendToken '?' "|DFA5
DFA0 -->|"~
BeginToken '~' 
ExtendToken '~' "|DFA6
DFA0 -->|"#92;.
BeginToken '.' 
ExtendToken '.' "|DFA7
DFA0 -->|"]
BeginToken ']' 
ExtendToken ']' "|DFA8
DFA0 -->|"#92;[
BeginToken '[' 
ExtendToken '[' "|DFA9
DFA0 -->|";
BeginToken ';' 
ExtendToken ';' "|DFA10
DFA0 -->|",
BeginToken ',' 
ExtendToken ',' "|DFA11
DFA0 -->|"#92;)
BeginToken ')' 
ExtendToken ')' "|DFA12
DFA0 -->|"#92;(
BeginToken '(' 
ExtendToken '(' "|DFA13
DFA0 -->|"[A-Z]_[a-c]e[g-s][u-z]
BeginToken 'identifier' 'literalString' 
ExtendToken 'identifier' "|DFA14
DFA0 -->|"=
BeginToken '==' '=' 
ExtendToken '=' "|DFA15
DFA0 -->|"%
BeginToken '%' '%=' 
ExtendToken '%' "|DFA16
DFA0 -->|"#92;#42;
BeginToken '#42;' '#42;=' 
ExtendToken '#42;' "|DFA17
DFA0 -->|"!
BeginToken '!' '!=' 
ExtendToken '!' "|DFA18
DFA0 -->|"f
BeginToken 'identifier' 'literalString' 'boolConstant' 
ExtendToken 'identifier' "|DFA19
DFA0 -->|"t
BeginToken 'identifier' 'literalString' 'boolConstant' 
ExtendToken 'identifier' "|DFA20
DFA0 -->|"d
BeginToken 'defined' 'identifier' 'literalString' 
ExtendToken 'identifier' "|DFA21
DFA0 -->|"#92;|
BeginToken '|' '||' '|=' 
ExtendToken '|' "|DFA22
DFA0 -->|"^
BeginToken '^' '^^' '^=' 
ExtendToken '^' "|DFA23
DFA0 -->|"&
BeginToken '&' '&&' '&=' 
ExtendToken '&' "|DFA24
DFA0 -->|">
BeginToken '>>' '>' '>=' '>>=' 
ExtendToken '>' "|DFA25
DFA0 -->|"#92;<
BeginToken '<<' '<' '<=' '<<=' 
ExtendToken '<' "|DFA26
DFA0 -->|"#92;/
BeginToken '/' '/=' 'inlineComment' 
ExtendToken '/' "|DFA27
DFA0 -->|"[1-9]
BeginToken 'number' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'number' 'intConstant' 'doubleConstant' "|DFA28
DFA0 -->|"0
BeginToken 'number' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'number' 'intConstant' 'doubleConstant' "|DFA29
DFA0 -->|"-
BeginToken '--' '-' '-=' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken '-' "|DFA30
DFA0 -->|"#92;+
BeginToken '++' '+' '+=' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken '+' "|DFA31
DFA0 -->|"#35;
BeginToken '#35;define' '#35;undef' '#35;#35;' '#35;if' '#35;ifdef' '#35;ifndef' '#35;else' '#35;elif' '#35;endif' '#35;error' '#35;pragma' '#35;extension' '#35;version' '#35;line' "|DFA32
DFA1 -->|"#34;
ExtendToken 'literalString' "|DFA33
DFA1 -->|"[^#92;#92;#34;]"|DFA34
DFA1 -->|"#92;#92;"|DFA35
DFA14 -->|"#34;
BeginToken 'literalString' "|DFA1
DFA14 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|DFA36
DFA15 -->|"=
ExtendToken '==' "|DFA37
DFA16 -->|"=
ExtendToken '%=' "|DFA38
DFA17 -->|"=
ExtendToken '#42;=' "|DFA39
DFA18 -->|"=
ExtendToken '!=' "|DFA40
DFA19 -->|"#34;
BeginToken 'literalString' "|DFA1
DFA19 -->|"[0-9][A-Z]_[b-z]
ExtendToken 'identifier' "|DFA36
DFA19 -->|"a
ExtendToken 'identifier' "|DFA41
DFA20 -->|"#34;
BeginToken 'literalString' "|DFA1
DFA20 -->|"[0-9][A-Z]_[a-q][s-z]
ExtendToken 'identifier' "|DFA36
DFA20 -->|"r
ExtendToken 'identifier' "|DFA42
DFA21 -->|"#34;
BeginToken 'literalString' "|DFA1
DFA21 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|DFA36
DFA21 -->|"e
ExtendToken 'identifier' "|DFA43
DFA22 -->|"=
ExtendToken '|=' "|DFA44
DFA22 -->|"#92;|
ExtendToken '||' "|DFA45
DFA23 -->|"=
ExtendToken '^=' "|DFA46
DFA23 -->|"^
ExtendToken '^^' "|DFA47
DFA24 -->|"=
ExtendToken '&=' "|DFA48
DFA24 -->|"&
ExtendToken '&&' "|DFA49
DFA25 -->|"=
ExtendToken '>=' "|DFA50
DFA25 -->|">
ExtendToken '>>' "|DFA51
DFA26 -->|"=
ExtendToken '<=' "|DFA52
DFA26 -->|"#92;<
ExtendToken '<<' "|DFA53
DFA27 -->|"#92;/
ExtendToken 'inlineComment' "|DFA54
DFA27 -->|"=
ExtendToken '/=' "|DFA55
DFA28 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA28 -->|"[uU]
ExtendToken 'uintConstant' "|DFA57
DFA28 -->|"[Ee]"|DFA58
DFA28 -->|"[.]
ExtendToken 'doubleConstant' "|DFA59
DFA28 -->|"[0-9]
ExtendToken 'number' 'intConstant' 'doubleConstant' "|DFA28
DFA29 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA29 -->|"[uU]
ExtendToken 'uintConstant' "|DFA57
DFA29 -->|"[Ee]"|DFA58
DFA29 -->|"x"|DFA60
DFA29 -->|"[.]
ExtendToken 'doubleConstant' "|DFA59
DFA29 -->|"[0-9]
ExtendToken 'number' 'intConstant' 'doubleConstant' "|DFA28
DFA30 -->|"=
ExtendToken '-=' "|DFA61
DFA30 -->|"-
ExtendToken '--' "|DFA62
DFA30 -->|"[0-9]
BeginToken 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'intConstant' 'doubleConstant' "|DFA63
DFA31 -->|"=
ExtendToken '+=' "|DFA64
DFA31 -->|"#92;+
ExtendToken '++' "|DFA65
DFA31 -->|"[0-9]
BeginToken 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'intConstant' 'doubleConstant' "|DFA63
DFA32 -->|"l"|DFA66
DFA32 -->|"v"|DFA67
DFA32 -->|"p"|DFA68
DFA32 -->|"#35;
ExtendToken '#35;#35;' "|DFA69
DFA32 -->|"u"|DFA70
DFA32 -->|"d"|DFA71
DFA32 -->|"i"|DFA72
DFA32 -->|"e"|DFA73
DFA34 -->|"#34;
ExtendToken 'literalString' "|DFA33
DFA34 -->|"[^#92;#92;#34;]"|DFA34
DFA34 -->|"#92;#92;"|DFA35
DFA35 -->|"[#32;-~]"|DFA74
DFA36 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|DFA36
DFA41 -->|"[0-9][A-Z]_[a-k][m-z]
ExtendToken 'identifier' "|DFA36
DFA41 -->|"l
ExtendToken 'identifier' "|DFA75
DFA42 -->|"[0-9][A-Z]_[a-t][v-z]
ExtendToken 'identifier' "|DFA36
DFA42 -->|"u
ExtendToken 'identifier' "|DFA76
DFA43 -->|"[0-9][A-Z]_[a-e][g-z]
ExtendToken 'identifier' "|DFA36
DFA43 -->|"f
ExtendToken 'identifier' "|DFA77
DFA51 -->|"=
ExtendToken '>>=' "|DFA78
DFA53 -->|"=
ExtendToken '<<=' "|DFA79
DFA54 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment' "|DFA80
DFA58 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA81
DFA58 -->|"[-+]"|DFA82
DFA59 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA59 -->|"[Ee]"|DFA58
DFA59 -->|"[.]
ExtendToken 'doubleConstant' "|DFA83
DFA59 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|DFA84
DFA60 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant' "|DFA85
DFA63 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA63 -->|"[uU]
ExtendToken 'uintConstant' "|DFA57
DFA63 -->|"[Ee]"|DFA58
DFA63 -->|"[.]
ExtendToken 'doubleConstant' "|DFA86
DFA63 -->|"[0-9]
ExtendToken 'intConstant' 'doubleConstant' "|DFA63
DFA66 -->|"i"|DFA87
DFA67 -->|"e"|DFA88
DFA68 -->|"r"|DFA89
DFA70 -->|"n"|DFA90
DFA71 -->|"e"|DFA91
DFA72 -->|"f
ExtendToken '#35;if' "|DFA92
DFA73 -->|"x"|DFA93
DFA73 -->|"r"|DFA94
DFA73 -->|"n"|DFA95
DFA73 -->|"l"|DFA96
DFA74 -->|"#34;
ExtendToken 'literalString' "|DFA33
DFA74 -->|"[^#92;#92;#34;]"|DFA34
DFA74 -->|"#92;#92;"|DFA35
DFA75 -->|"[0-9][A-Z]_[a-r][t-z]
ExtendToken 'identifier' "|DFA36
DFA75 -->|"s
ExtendToken 'identifier' "|DFA97
DFA76 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|DFA36
DFA76 -->|"e
ExtendToken 'identifier' 'boolConstant' "|DFA98
DFA77 -->|"[0-9][A-Z]_[a-h][j-z]
ExtendToken 'identifier' "|DFA36
DFA77 -->|"i
ExtendToken 'identifier' "|DFA99
DFA80 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment' "|DFA80
DFA81 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA81 -->|"[Ee]"|DFA100
DFA81 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA81
DFA82 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA81
DFA83 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA83 -->|"[Ee]"|DFA58
DFA83 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA101
DFA84 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA84 -->|"[Ee]"|DFA58
DFA84 -->|"[.]
ExtendToken 'doubleConstant' "|DFA102
DFA84 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|DFA84
DFA85 -->|"[uU]
ExtendToken 'uintConstant' "|DFA103
DFA85 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant' "|DFA85
DFA86 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA86 -->|"[Ee]"|DFA58
DFA86 -->|"[.]
ExtendToken 'doubleConstant' "|DFA83
DFA86 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA104
DFA87 -->|"n"|DFA105
DFA88 -->|"r"|DFA106
DFA89 -->|"a"|DFA107
DFA90 -->|"d"|DFA108
DFA91 -->|"f"|DFA109
DFA92 -->|"n"|DFA110
DFA92 -->|"d"|DFA111
DFA93 -->|"t"|DFA112
DFA94 -->|"r"|DFA113
DFA95 -->|"d"|DFA114
DFA96 -->|"i"|DFA115
DFA96 -->|"s"|DFA116
DFA97 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|DFA36
DFA97 -->|"e
ExtendToken 'identifier' 'boolConstant' "|DFA117
DFA98 -->|"[^a-zA-Z0-9_]"|DFA118
DFA98 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|DFA36
DFA99 -->|"[0-9][A-Z]_[a-m][o-z]
ExtendToken 'identifier' "|DFA36
DFA99 -->|"n
ExtendToken 'identifier' "|DFA119
DFA100 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA120
DFA100 -->|"[-+]"|DFA121
DFA101 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA101 -->|"[Ee]"|DFA58
DFA101 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA101
DFA102 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA102 -->|"[Ee]"|DFA58
DFA102 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|DFA122
DFA104 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA104 -->|"[Ee]"|DFA58
DFA104 -->|"[.]
ExtendToken 'doubleConstant' "|DFA83
DFA104 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA104
DFA105 -->|"e
ExtendToken '#35;line' "|DFA123
DFA106 -->|"s"|DFA124
DFA107 -->|"g"|DFA125
DFA108 -->|"e"|DFA126
DFA109 -->|"i"|DFA127
DFA110 -->|"d"|DFA128
DFA111 -->|"e"|DFA129
DFA112 -->|"e"|DFA130
DFA113 -->|"o"|DFA131
DFA114 -->|"i"|DFA132
DFA115 -->|"f
ExtendToken '#35;elif' "|DFA133
DFA116 -->|"e
ExtendToken '#35;else' "|DFA134
DFA117 -->|"[^a-zA-Z0-9_]"|DFA135
DFA117 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|DFA36
DFA119 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|DFA36
DFA119 -->|"e
ExtendToken 'identifier' "|DFA136
DFA120 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA120 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA120
DFA121 -->|"[0-9]
ExtendToken 'doubleConstant' "|DFA120
DFA122 -->|"[fF]
ExtendToken 'floatConstant' "|DFA56
DFA122 -->|"[Ee]"|DFA58
DFA122 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|DFA122
DFA124 -->|"i"|DFA137
DFA125 -->|"m"|DFA138
DFA126 -->|"f
ExtendToken '#35;undef' "|DFA139
DFA127 -->|"n"|DFA140
DFA128 -->|"e"|DFA141
DFA129 -->|"f
ExtendToken '#35;ifdef' "|DFA142
DFA130 -->|"n"|DFA143
DFA131 -->|"r
ExtendToken '#35;error' "|DFA144
DFA132 -->|"f
ExtendToken '#35;endif' "|DFA145
DFA136 -->|"[0-9][A-Z]_[a-c][e-z]
ExtendToken 'identifier' "|DFA36
DFA136 -->|"d
ExtendToken 'defined' 'identifier' "|DFA146
DFA137 -->|"o"|DFA147
DFA138 -->|"a
ExtendToken '#35;pragma' "|DFA148
DFA140 -->|"e
ExtendToken '#35;define' "|DFA149
DFA141 -->|"f
ExtendToken '#35;ifndef' "|DFA150
DFA143 -->|"s"|DFA151
DFA146 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|DFA36
DFA147 -->|"n
ExtendToken '#35;version' "|DFA152
DFA151 -->|"i"|DFA153
DFA153 -->|"o"|DFA154
DFA154 -->|"n
ExtendToken '#35;extension' "|DFA155

```

## 5/5: miniDFA

```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
subgraph miniDFA0["miniDFA0 1 DFA States"]
DFA0_0{{"DFA0 wholeStart"}}
class DFA0_0 c1000;
end
class miniDFA0 c1000;
subgraph miniDFA1["miniDFA1 3 DFA States"]
DFA1_1{{"DFA1 1 NFA States"}}
DFA34_2{{"DFA34 1 NFA States"}}
DFA74_3{{"DFA74 1 NFA States"}}
end
subgraph miniDFA55["miniDFA55 1 DFA States"]
DFA2_4[\"DFA2 1 NFA States
AcceptToken '}'"/]
class DFA2_4 c0001;
end
class miniDFA55 c0001;
subgraph miniDFA56["miniDFA56 1 DFA States"]
DFA3_5[\"DFA3 1 NFA States
AcceptToken '{'"/]
class DFA3_5 c0001;
end
class miniDFA56 c0001;
subgraph miniDFA57["miniDFA57 1 DFA States"]
DFA4_6[\"DFA4 1 NFA States
AcceptToken ':'"/]
class DFA4_6 c0001;
end
class miniDFA57 c0001;
subgraph miniDFA58["miniDFA58 1 DFA States"]
DFA5_7[\"DFA5 1 NFA States
AcceptToken '?'"/]
class DFA5_7 c0001;
end
class miniDFA58 c0001;
subgraph miniDFA59["miniDFA59 1 DFA States"]
DFA6_8[\"DFA6 1 NFA States
AcceptToken '~'"/]
class DFA6_8 c0001;
end
class miniDFA59 c0001;
subgraph miniDFA60["miniDFA60 1 DFA States"]
DFA7_9[\"DFA7 1 NFA States
AcceptToken '.'"/]
class DFA7_9 c0001;
end
class miniDFA60 c0001;
subgraph miniDFA61["miniDFA61 1 DFA States"]
DFA8_10[\"DFA8 1 NFA States
AcceptToken ']'"/]
class DFA8_10 c0001;
end
class miniDFA61 c0001;
subgraph miniDFA62["miniDFA62 1 DFA States"]
DFA9_11[\"DFA9 1 NFA States
AcceptToken '['"/]
class DFA9_11 c0001;
end
class miniDFA62 c0001;
subgraph miniDFA63["miniDFA63 1 DFA States"]
DFA10_12[\"DFA10 1 NFA States
AcceptToken ';'"/]
class DFA10_12 c0001;
end
class miniDFA63 c0001;
subgraph miniDFA64["miniDFA64 1 DFA States"]
DFA11_13[\"DFA11 1 NFA States
AcceptToken ','"/]
class DFA11_13 c0001;
end
class miniDFA64 c0001;
subgraph miniDFA65["miniDFA65 1 DFA States"]
DFA12_14[\"DFA12 1 NFA States
AcceptToken ')'"/]
class DFA12_14 c0001;
end
class miniDFA65 c0001;
subgraph miniDFA66["miniDFA66 1 DFA States"]
DFA13_15[\"DFA13 1 NFA States
AcceptToken '('"/]
class DFA13_15 c0001;
end
class miniDFA66 c0001;
subgraph miniDFA67["miniDFA67 1 DFA States"]
DFA14_16[\"DFA14 2 NFA States
AcceptToken 'identifier'"/]
class DFA14_16 c1001;
end
class miniDFA67 c1001;
subgraph miniDFA68["miniDFA68 1 DFA States"]
DFA15_17[\"DFA15 2 NFA States
AcceptToken '='"/]
class DFA15_17 c0001;
end
class miniDFA68 c0001;
subgraph miniDFA69["miniDFA69 1 DFA States"]
DFA16_18[\"DFA16 2 NFA States
AcceptToken '%'"/]
class DFA16_18 c0001;
end
class miniDFA69 c0001;
subgraph miniDFA70["miniDFA70 1 DFA States"]
DFA17_19[\"DFA17 2 NFA States
AcceptToken '*'"/]
class DFA17_19 c0001;
end
class miniDFA70 c0001;
subgraph miniDFA71["miniDFA71 1 DFA States"]
DFA18_20[\"DFA18 2 NFA States
AcceptToken '!'"/]
class DFA18_20 c0001;
end
class miniDFA71 c0001;
subgraph miniDFA72["miniDFA72 1 DFA States"]
DFA19_21[\"DFA19 3 NFA States
AcceptToken 'identifier'"/]
class DFA19_21 c1001;
end
class miniDFA72 c1001;
subgraph miniDFA73["miniDFA73 1 DFA States"]
DFA20_22[\"DFA20 3 NFA States
AcceptToken 'identifier'"/]
class DFA20_22 c1001;
end
class miniDFA73 c1001;
subgraph miniDFA74["miniDFA74 1 DFA States"]
DFA21_23[\"DFA21 3 NFA States
AcceptToken 'identifier'"/]
class DFA21_23 c1001;
end
class miniDFA74 c1001;
subgraph miniDFA75["miniDFA75 1 DFA States"]
DFA22_24[\"DFA22 3 NFA States
AcceptToken '|'"/]
class DFA22_24 c0001;
end
class miniDFA75 c0001;
subgraph miniDFA76["miniDFA76 1 DFA States"]
DFA23_25[\"DFA23 3 NFA States
AcceptToken '^'"/]
class DFA23_25 c0001;
end
class miniDFA76 c0001;
subgraph miniDFA77["miniDFA77 1 DFA States"]
DFA24_26[\"DFA24 3 NFA States
AcceptToken '&'"/]
class DFA24_26 c0001;
end
class miniDFA77 c0001;
subgraph miniDFA78["miniDFA78 1 DFA States"]
DFA25_27[\"DFA25 4 NFA States
AcceptToken '>'"/]
class DFA25_27 c0001;
end
class miniDFA78 c0001;
subgraph miniDFA79["miniDFA79 1 DFA States"]
DFA26_28[\"DFA26 4 NFA States
AcceptToken '<'"/]
class DFA26_28 c0001;
end
class miniDFA79 c0001;
subgraph miniDFA80["miniDFA80 1 DFA States"]
DFA27_29[\"DFA27 3 NFA States
AcceptToken '/'"/]
class DFA27_29 c0001;
end
class miniDFA80 c0001;
subgraph miniDFA81["miniDFA81 1 DFA States"]
DFA28_30[\"DFA28 5 NFA States
AcceptToken 'number'
AcceptToken 'intConstant'
AcceptToken 'doubleConstant'"/]
class DFA28_30 c0001;
end
class miniDFA81 c0001;
subgraph miniDFA82["miniDFA82 1 DFA States"]
DFA29_31[\"DFA29 7 NFA States
AcceptToken 'number'
AcceptToken 'intConstant'
AcceptToken 'doubleConstant'"/]
class DFA29_31 c0001;
end
class miniDFA82 c0001;
subgraph miniDFA83["miniDFA83 1 DFA States"]
DFA30_32[\"DFA30 7 NFA States
AcceptToken '-'"/]
class DFA30_32 c1001;
end
class miniDFA83 c1001;
subgraph miniDFA84["miniDFA84 1 DFA States"]
DFA31_33[\"DFA31 7 NFA States
AcceptToken '+'"/]
class DFA31_33 c1001;
end
class miniDFA84 c1001;
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA32_34{{"DFA32 14 NFA States"}}
end
subgraph miniDFA85["miniDFA85 1 DFA States"]
DFA33_35[\"DFA33 1 NFA States
AcceptToken 'literalString'"/]
class DFA33_35 c0001;
end
class miniDFA85 c0001;
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA35_36{{"DFA35 1 NFA States"}}
end
subgraph miniDFA86["miniDFA86 1 DFA States"]
DFA36_37[\"DFA36 1 NFA States
AcceptToken 'identifier'"/]
class DFA36_37 c0001;
end
class miniDFA86 c0001;
subgraph miniDFA87["miniDFA87 1 DFA States"]
DFA37_38[\"DFA37 1 NFA States
AcceptToken '=='"/]
class DFA37_38 c0001;
end
class miniDFA87 c0001;
subgraph miniDFA88["miniDFA88 1 DFA States"]
DFA38_39[\"DFA38 1 NFA States
AcceptToken '%='"/]
class DFA38_39 c0001;
end
class miniDFA88 c0001;
subgraph miniDFA89["miniDFA89 1 DFA States"]
DFA39_40[\"DFA39 1 NFA States
AcceptToken '*='"/]
class DFA39_40 c0001;
end
class miniDFA89 c0001;
subgraph miniDFA90["miniDFA90 1 DFA States"]
DFA40_41[\"DFA40 1 NFA States
AcceptToken '!='"/]
class DFA40_41 c0001;
end
class miniDFA90 c0001;
subgraph miniDFA91["miniDFA91 1 DFA States"]
DFA41_42[\"DFA41 2 NFA States
AcceptToken 'identifier'"/]
class DFA41_42 c0001;
end
class miniDFA91 c0001;
subgraph miniDFA92["miniDFA92 1 DFA States"]
DFA42_43[\"DFA42 2 NFA States
AcceptToken 'identifier'"/]
class DFA42_43 c0001;
end
class miniDFA92 c0001;
subgraph miniDFA93["miniDFA93 1 DFA States"]
DFA43_44[\"DFA43 2 NFA States
AcceptToken 'identifier'"/]
class DFA43_44 c0001;
end
class miniDFA93 c0001;
subgraph miniDFA94["miniDFA94 1 DFA States"]
DFA44_45[\"DFA44 1 NFA States
AcceptToken '|='"/]
class DFA44_45 c0001;
end
class miniDFA94 c0001;
subgraph miniDFA95["miniDFA95 1 DFA States"]
DFA45_46[\"DFA45 1 NFA States
AcceptToken '||'"/]
class DFA45_46 c0001;
end
class miniDFA95 c0001;
subgraph miniDFA96["miniDFA96 1 DFA States"]
DFA46_47[\"DFA46 1 NFA States
AcceptToken '^='"/]
class DFA46_47 c0001;
end
class miniDFA96 c0001;
subgraph miniDFA97["miniDFA97 1 DFA States"]
DFA47_48[\"DFA47 1 NFA States
AcceptToken '^^'"/]
class DFA47_48 c0001;
end
class miniDFA97 c0001;
subgraph miniDFA98["miniDFA98 1 DFA States"]
DFA48_49[\"DFA48 1 NFA States
AcceptToken '&='"/]
class DFA48_49 c0001;
end
class miniDFA98 c0001;
subgraph miniDFA99["miniDFA99 1 DFA States"]
DFA49_50[\"DFA49 1 NFA States
AcceptToken '&&'"/]
class DFA49_50 c0001;
end
class miniDFA99 c0001;
subgraph miniDFA100["miniDFA100 1 DFA States"]
DFA50_51[\"DFA50 1 NFA States
AcceptToken '>='"/]
class DFA50_51 c0001;
end
class miniDFA100 c0001;
subgraph miniDFA101["miniDFA101 1 DFA States"]
DFA51_52[\"DFA51 2 NFA States
AcceptToken '>>'"/]
class DFA51_52 c0001;
end
class miniDFA101 c0001;
subgraph miniDFA102["miniDFA102 1 DFA States"]
DFA52_53[\"DFA52 1 NFA States
AcceptToken '<='"/]
class DFA52_53 c0001;
end
class miniDFA102 c0001;
subgraph miniDFA103["miniDFA103 1 DFA States"]
DFA53_54[\"DFA53 2 NFA States
AcceptToken '<<'"/]
class DFA53_54 c0001;
end
class miniDFA103 c0001;
subgraph miniDFA104["miniDFA104 1 DFA States"]
DFA54_55[\"DFA54 1 NFA States
AcceptToken 'inlineComment'"/]
class DFA54_55 c0001;
end
class miniDFA104 c0001;
subgraph miniDFA105["miniDFA105 1 DFA States"]
DFA55_56[\"DFA55 1 NFA States
AcceptToken '/='"/]
class DFA55_56 c0001;
end
class miniDFA105 c0001;
subgraph miniDFA106["miniDFA106 1 DFA States"]
DFA56_57[\"DFA56 1 NFA States
AcceptToken 'floatConstant'"/]
class DFA56_57 c0001;
end
class miniDFA106 c0001;
subgraph miniDFA107["miniDFA107 1 DFA States"]
DFA57_58[\"DFA57 1 NFA States
AcceptToken 'uintConstant'"/]
class DFA57_58 c0001;
end
class miniDFA107 c0001;
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA58_59{{"DFA58 2 NFA States"}}
end
subgraph miniDFA108["miniDFA108 1 DFA States"]
DFA59_60[\"DFA59 3 NFA States
AcceptToken 'doubleConstant'"/]
class DFA59_60 c0001;
end
class miniDFA108 c0001;
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA60_61{{"DFA60 2 NFA States"}}
end
subgraph miniDFA109["miniDFA109 1 DFA States"]
DFA61_62[\"DFA61 1 NFA States
AcceptToken '-='"/]
class DFA61_62 c0001;
end
class miniDFA109 c0001;
subgraph miniDFA110["miniDFA110 1 DFA States"]
DFA62_63[\"DFA62 1 NFA States
AcceptToken '--'"/]
class DFA62_63 c0001;
end
class miniDFA110 c0001;
subgraph miniDFA111["miniDFA111 1 DFA States"]
DFA63_64[\"DFA63 4 NFA States
AcceptToken 'intConstant'
AcceptToken 'doubleConstant'"/]
class DFA63_64 c0001;
end
class miniDFA111 c0001;
subgraph miniDFA112["miniDFA112 1 DFA States"]
DFA64_65[\"DFA64 1 NFA States
AcceptToken '+='"/]
class DFA64_65 c0001;
end
class miniDFA112 c0001;
subgraph miniDFA113["miniDFA113 1 DFA States"]
DFA65_66[\"DFA65 1 NFA States
AcceptToken '++'"/]
class DFA65_66 c0001;
end
class miniDFA113 c0001;
subgraph miniDFA6["miniDFA6 1 DFA States"]
DFA66_67{{"DFA66 1 NFA States"}}
end
subgraph miniDFA11["miniDFA11 1 DFA States"]
DFA67_68{{"DFA67 1 NFA States"}}
end
subgraph miniDFA17["miniDFA17 1 DFA States"]
DFA68_69{{"DFA68 1 NFA States"}}
end
subgraph miniDFA114["miniDFA114 1 DFA States"]
DFA69_70[\"DFA69 1 NFA States
AcceptToken '##'"/]
class DFA69_70 c0001;
end
class miniDFA114 c0001;
subgraph miniDFA20["miniDFA20 1 DFA States"]
DFA70_71{{"DFA70 1 NFA States"}}
end
subgraph miniDFA12["miniDFA12 1 DFA States"]
DFA71_72{{"DFA71 1 NFA States"}}
end
subgraph miniDFA24["miniDFA24 1 DFA States"]
DFA72_73{{"DFA72 3 NFA States"}}
end
subgraph miniDFA25["miniDFA25 1 DFA States"]
DFA73_74{{"DFA73 5 NFA States"}}
end
subgraph miniDFA115["miniDFA115 1 DFA States"]
DFA75_75[\"DFA75 2 NFA States
AcceptToken 'identifier'"/]
class DFA75_75 c0001;
end
class miniDFA115 c0001;
subgraph miniDFA116["miniDFA116 1 DFA States"]
DFA76_76[\"DFA76 2 NFA States
AcceptToken 'identifier'"/]
class DFA76_76 c0001;
end
class miniDFA116 c0001;
subgraph miniDFA117["miniDFA117 1 DFA States"]
DFA77_77[\"DFA77 2 NFA States
AcceptToken 'identifier'"/]
class DFA77_77 c0001;
end
class miniDFA117 c0001;
subgraph miniDFA118["miniDFA118 1 DFA States"]
DFA78_78[\"DFA78 1 NFA States
AcceptToken '>>='"/]
class DFA78_78 c0001;
end
class miniDFA118 c0001;
subgraph miniDFA119["miniDFA119 1 DFA States"]
DFA79_79[\"DFA79 1 NFA States
AcceptToken '<<='"/]
class DFA79_79 c0001;
end
class miniDFA119 c0001;
subgraph miniDFA120["miniDFA120 1 DFA States"]
DFA80_80[\"DFA80 1 NFA States
AcceptToken 'inlineComment'"/]
class DFA80_80 c0001;
end
class miniDFA120 c0001;
subgraph miniDFA121["miniDFA121 1 DFA States"]
DFA81_81[\"DFA81 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA81_81 c0001;
end
class miniDFA121 c0001;
subgraph miniDFA26["miniDFA26 1 DFA States"]
DFA82_82{{"DFA82 2 NFA States"}}
end
subgraph miniDFA122["miniDFA122 1 DFA States"]
DFA83_83[\"DFA83 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA83_83 c0001;
end
class miniDFA122 c0001;
subgraph miniDFA123["miniDFA123 1 DFA States"]
DFA84_84[\"DFA84 3 NFA States
AcceptToken 'number'
AcceptToken 'doubleConstant'"/]
class DFA84_84 c0001;
end
class miniDFA123 c0001;
subgraph miniDFA124["miniDFA124 1 DFA States"]
DFA85_85[\"DFA85 2 NFA States
AcceptToken 'intConstant'"/]
class DFA85_85 c0001;
end
class miniDFA124 c0001;
subgraph miniDFA125["miniDFA125 1 DFA States"]
DFA86_86[\"DFA86 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA86_86 c0001;
end
class miniDFA125 c0001;
subgraph miniDFA21["miniDFA21 1 DFA States"]
DFA87_87{{"DFA87 1 NFA States"}}
end
subgraph miniDFA18["miniDFA18 1 DFA States"]
DFA88_88{{"DFA88 1 NFA States"}}
end
subgraph miniDFA27["miniDFA27 1 DFA States"]
DFA89_89{{"DFA89 1 NFA States"}}
end
subgraph miniDFA28["miniDFA28 1 DFA States"]
DFA90_90{{"DFA90 1 NFA States"}}
end
subgraph miniDFA31["miniDFA31 1 DFA States"]
DFA91_91{{"DFA91 1 NFA States"}}
end
subgraph miniDFA126["miniDFA126 1 DFA States"]
DFA92_92[\"DFA92 3 NFA States
AcceptToken '#if'"/]
class DFA92_92 c0001;
end
class miniDFA126 c0001;
subgraph miniDFA32["miniDFA32 1 DFA States"]
DFA93_93{{"DFA93 1 NFA States"}}
end
subgraph miniDFA19["miniDFA19 1 DFA States"]
DFA94_94{{"DFA94 1 NFA States"}}
end
subgraph miniDFA30["miniDFA30 1 DFA States"]
DFA95_95{{"DFA95 1 NFA States"}}
end
subgraph miniDFA33["miniDFA33 1 DFA States"]
DFA96_96{{"DFA96 2 NFA States"}}
end
subgraph miniDFA127["miniDFA127 1 DFA States"]
DFA97_97[\"DFA97 2 NFA States
AcceptToken 'identifier'"/]
class DFA97_97 c0001;
end
class miniDFA127 c0001;
subgraph miniDFA128["miniDFA128 1 DFA States"]
DFA98_98[\"DFA98 2 NFA States
AcceptToken 'identifier'"/]
class DFA98_98 c0001;
end
class miniDFA128 c0001;
subgraph miniDFA129["miniDFA129 1 DFA States"]
DFA99_99[\"DFA99 2 NFA States
AcceptToken 'identifier'"/]
class DFA99_99 c0001;
end
class miniDFA129 c0001;
subgraph miniDFA34["miniDFA34 1 DFA States"]
DFA100_100{{"DFA100 2 NFA States"}}
end
subgraph miniDFA130["miniDFA130 1 DFA States"]
DFA101_101[\"DFA101 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA101_101 c0001;
end
class miniDFA130 c0001;
subgraph miniDFA131["miniDFA131 1 DFA States"]
DFA102_102[\"DFA102 3 NFA States
AcceptToken 'doubleConstant'"/]
class DFA102_102 c0001;
end
class miniDFA131 c0001;
subgraph miniDFA132["miniDFA132 1 DFA States"]
DFA103_103[\"DFA103 1 NFA States
AcceptToken 'uintConstant'"/]
class DFA103_103 c0001;
end
class miniDFA132 c0001;
subgraph miniDFA133["miniDFA133 1 DFA States"]
DFA104_104[\"DFA104 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA104_104 c0001;
end
class miniDFA133 c0001;
subgraph miniDFA35["miniDFA35 1 DFA States"]
DFA105_105{{"DFA105 1 NFA States"}}
end
subgraph miniDFA36["miniDFA36 1 DFA States"]
DFA106_106{{"DFA106 1 NFA States"}}
end
subgraph miniDFA38["miniDFA38 1 DFA States"]
DFA107_107{{"DFA107 1 NFA States"}}
end
subgraph miniDFA13["miniDFA13 1 DFA States"]
DFA108_108{{"DFA108 1 NFA States"}}
end
subgraph miniDFA7["miniDFA7 1 DFA States"]
DFA109_109{{"DFA109 1 NFA States"}}
end
subgraph miniDFA29["miniDFA29 1 DFA States"]
DFA110_110{{"DFA110 1 NFA States"}}
end
subgraph miniDFA14["miniDFA14 1 DFA States"]
DFA111_111{{"DFA111 1 NFA States"}}
end
subgraph miniDFA15["miniDFA15 1 DFA States"]
DFA112_112{{"DFA112 1 NFA States"}}
end
subgraph miniDFA39["miniDFA39 1 DFA States"]
DFA113_113{{"DFA113 1 NFA States"}}
end
subgraph miniDFA8["miniDFA8 1 DFA States"]
DFA114_114{{"DFA114 1 NFA States"}}
end
subgraph miniDFA42["miniDFA42 1 DFA States"]
DFA115_115{{"DFA115 1 NFA States"}}
end
subgraph miniDFA43["miniDFA43 1 DFA States"]
DFA116_116{{"DFA116 1 NFA States"}}
end
subgraph miniDFA134["miniDFA134 1 DFA States"]
DFA117_117[\"DFA117 2 NFA States
AcceptToken 'identifier'"/]
class DFA117_117 c0001;
end
class miniDFA134 c0001;
subgraph miniDFA135["miniDFA135 1 DFA States"]
DFA118_118[\"DFA118 1 NFA States
AcceptToken 'boolConstant'"/]
class DFA118_118 c0001;
end
class miniDFA135 c0001;
subgraph miniDFA136["miniDFA136 1 DFA States"]
DFA119_119[\"DFA119 2 NFA States
AcceptToken 'identifier'"/]
class DFA119_119 c0001;
end
class miniDFA136 c0001;
subgraph miniDFA137["miniDFA137 1 DFA States"]
DFA120_120[\"DFA120 2 NFA States
AcceptToken 'doubleConstant'"/]
class DFA120_120 c0001;
end
class miniDFA137 c0001;
subgraph miniDFA44["miniDFA44 1 DFA States"]
DFA121_121{{"DFA121 2 NFA States"}}
end
subgraph miniDFA138["miniDFA138 1 DFA States"]
DFA122_122[\"DFA122 3 NFA States
AcceptToken 'number'
AcceptToken 'doubleConstant'"/]
class DFA122_122 c0001;
end
class miniDFA138 c0001;
subgraph miniDFA139["miniDFA139 1 DFA States"]
DFA123_123[\"DFA123 1 NFA States
AcceptToken '#line'"/]
class DFA123_123 c0001;
end
class miniDFA139 c0001;
subgraph miniDFA9["miniDFA9 1 DFA States"]
DFA124_124{{"DFA124 1 NFA States"}}
end
subgraph miniDFA45["miniDFA45 1 DFA States"]
DFA125_125{{"DFA125 1 NFA States"}}
end
subgraph miniDFA46["miniDFA46 1 DFA States"]
DFA126_126{{"DFA126 1 NFA States"}}
end
subgraph miniDFA22["miniDFA22 1 DFA States"]
DFA127_127{{"DFA127 1 NFA States"}}
end
subgraph miniDFA16["miniDFA16 1 DFA States"]
DFA128_128{{"DFA128 1 NFA States"}}
end
subgraph miniDFA47["miniDFA47 1 DFA States"]
DFA129_129{{"DFA129 1 NFA States"}}
end
subgraph miniDFA23["miniDFA23 1 DFA States"]
DFA130_130{{"DFA130 1 NFA States"}}
end
subgraph miniDFA48["miniDFA48 1 DFA States"]
DFA131_131{{"DFA131 1 NFA States"}}
end
subgraph miniDFA49["miniDFA49 1 DFA States"]
DFA132_132{{"DFA132 1 NFA States"}}
end
subgraph miniDFA140["miniDFA140 1 DFA States"]
DFA133_133[\"DFA133 1 NFA States
AcceptToken '#elif'"/]
class DFA133_133 c0001;
end
class miniDFA140 c0001;
subgraph miniDFA141["miniDFA141 1 DFA States"]
DFA134_134[\"DFA134 1 NFA States
AcceptToken '#else'"/]
class DFA134_134 c0001;
end
class miniDFA141 c0001;
subgraph miniDFA142["miniDFA142 1 DFA States"]
DFA135_135[\"DFA135 1 NFA States
AcceptToken 'boolConstant'"/]
class DFA135_135 c0001;
end
class miniDFA142 c0001;
subgraph miniDFA143["miniDFA143 1 DFA States"]
DFA136_136[\"DFA136 2 NFA States
AcceptToken 'identifier'"/]
class DFA136_136 c0001;
end
class miniDFA143 c0001;
subgraph miniDFA40["miniDFA40 1 DFA States"]
DFA137_137{{"DFA137 1 NFA States"}}
end
subgraph miniDFA50["miniDFA50 1 DFA States"]
DFA138_138{{"DFA138 1 NFA States"}}
end
subgraph miniDFA144["miniDFA144 1 DFA States"]
DFA139_139[\"DFA139 1 NFA States
AcceptToken '#undef'"/]
class DFA139_139 c0001;
end
class miniDFA144 c0001;
subgraph miniDFA51["miniDFA51 1 DFA States"]
DFA140_140{{"DFA140 1 NFA States"}}
end
subgraph miniDFA52["miniDFA52 1 DFA States"]
DFA141_141{{"DFA141 1 NFA States"}}
end
subgraph miniDFA145["miniDFA145 1 DFA States"]
DFA142_142[\"DFA142 1 NFA States
AcceptToken '#ifdef'"/]
class DFA142_142 c0001;
end
class miniDFA145 c0001;
subgraph miniDFA37["miniDFA37 1 DFA States"]
DFA143_143{{"DFA143 1 NFA States"}}
end
subgraph miniDFA146["miniDFA146 1 DFA States"]
DFA144_144[\"DFA144 1 NFA States
AcceptToken '#error'"/]
class DFA144_144 c0001;
end
class miniDFA146 c0001;
subgraph miniDFA147["miniDFA147 1 DFA States"]
DFA145_145[\"DFA145 1 NFA States
AcceptToken '#endif'"/]
class DFA145_145 c0001;
end
class miniDFA147 c0001;
subgraph miniDFA148["miniDFA148 1 DFA States"]
DFA146_146[\"DFA146 2 NFA States
AcceptToken 'defined'
AcceptToken 'identifier'"/]
class DFA146_146 c0001;
end
class miniDFA148 c0001;
subgraph miniDFA53["miniDFA53 1 DFA States"]
DFA147_147{{"DFA147 1 NFA States"}}
end
subgraph miniDFA149["miniDFA149 1 DFA States"]
DFA148_148[\"DFA148 1 NFA States
AcceptToken '#pragma'"/]
class DFA148_148 c0001;
end
class miniDFA149 c0001;
subgraph miniDFA150["miniDFA150 1 DFA States"]
DFA149_149[\"DFA149 1 NFA States
AcceptToken '#define'"/]
class DFA149_149 c0001;
end
class miniDFA150 c0001;
subgraph miniDFA151["miniDFA151 1 DFA States"]
DFA150_150[\"DFA150 1 NFA States
AcceptToken '#ifndef'"/]
class DFA150_150 c0001;
end
class miniDFA151 c0001;
subgraph miniDFA10["miniDFA10 1 DFA States"]
DFA151_151{{"DFA151 1 NFA States"}}
end
subgraph miniDFA152["miniDFA152 1 DFA States"]
DFA152_152[\"DFA152 1 NFA States
AcceptToken '#version'"/]
class DFA152_152 c0001;
end
class miniDFA152 c0001;
subgraph miniDFA41["miniDFA41 1 DFA States"]
DFA153_153{{"DFA153 1 NFA States"}}
end
subgraph miniDFA54["miniDFA54 1 DFA States"]
DFA154_154{{"DFA154 1 NFA States"}}
end
subgraph miniDFA153["miniDFA153 1 DFA States"]
DFA155_155[\"DFA155 1 NFA States
AcceptToken '#extension'"/]
class DFA155_155 c0001;
end
class miniDFA153 c0001;
miniDFA0 -->|"#34;
BeginToken 'literalString' "|miniDFA1
miniDFA0 -->|"}
BeginToken '}' 
ExtendToken '}' "|miniDFA55
miniDFA0 -->|"#92;{
BeginToken '{' 
ExtendToken '{' "|miniDFA56
miniDFA0 -->|":
BeginToken ':' 
ExtendToken ':' "|miniDFA57
miniDFA0 -->|"#92;?
BeginToken '?' 
ExtendToken '?' "|miniDFA58
miniDFA0 -->|"~
BeginToken '~' 
ExtendToken '~' "|miniDFA59
miniDFA0 -->|"#92;.
BeginToken '.' 
ExtendToken '.' "|miniDFA60
miniDFA0 -->|"]
BeginToken ']' 
ExtendToken ']' "|miniDFA61
miniDFA0 -->|"#92;[
BeginToken '[' 
ExtendToken '[' "|miniDFA62
miniDFA0 -->|";
BeginToken ';' 
ExtendToken ';' "|miniDFA63
miniDFA0 -->|",
BeginToken ',' 
ExtendToken ',' "|miniDFA64
miniDFA0 -->|"#92;)
BeginToken ')' 
ExtendToken ')' "|miniDFA65
miniDFA0 -->|"#92;(
BeginToken '(' 
ExtendToken '(' "|miniDFA66
miniDFA0 -->|"[A-Z]_[a-c]e[g-s][u-z]
BeginToken 'identifier' 'literalString' 
ExtendToken 'identifier' "|miniDFA67
miniDFA0 -->|"=
BeginToken '==' '=' 
ExtendToken '=' "|miniDFA68
miniDFA0 -->|"%
BeginToken '%' '%=' 
ExtendToken '%' "|miniDFA69
miniDFA0 -->|"#92;#42;
BeginToken '#42;' '#42;=' 
ExtendToken '#42;' "|miniDFA70
miniDFA0 -->|"!
BeginToken '!' '!=' 
ExtendToken '!' "|miniDFA71
miniDFA0 -->|"f
BeginToken 'identifier' 'literalString' 'boolConstant' 
ExtendToken 'identifier' "|miniDFA72
miniDFA0 -->|"t
BeginToken 'identifier' 'literalString' 'boolConstant' 
ExtendToken 'identifier' "|miniDFA73
miniDFA0 -->|"d
BeginToken 'defined' 'identifier' 'literalString' 
ExtendToken 'identifier' "|miniDFA74
miniDFA0 -->|"#92;|
BeginToken '|' '||' '|=' 
ExtendToken '|' "|miniDFA75
miniDFA0 -->|"^
BeginToken '^' '^^' '^=' 
ExtendToken '^' "|miniDFA76
miniDFA0 -->|"&
BeginToken '&' '&&' '&=' 
ExtendToken '&' "|miniDFA77
miniDFA0 -->|">
BeginToken '>>' '>' '>=' '>>=' 
ExtendToken '>' "|miniDFA78
miniDFA0 -->|"#92;<
BeginToken '<<' '<' '<=' '<<=' 
ExtendToken '<' "|miniDFA79
miniDFA0 -->|"#92;/
BeginToken '/' '/=' 'inlineComment' 
ExtendToken '/' "|miniDFA80
miniDFA0 -->|"[1-9]
BeginToken 'number' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'number' 'intConstant' 'doubleConstant' "|miniDFA81
miniDFA0 -->|"0
BeginToken 'number' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'number' 'intConstant' 'doubleConstant' "|miniDFA82
miniDFA0 -->|"-
BeginToken '--' '-' '-=' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken '-' "|miniDFA83
miniDFA0 -->|"#92;+
BeginToken '++' '+' '+=' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken '+' "|miniDFA84
miniDFA0 -->|"#35;
BeginToken '#35;define' '#35;undef' '#35;#35;' '#35;if' '#35;ifdef' '#35;ifndef' '#35;else' '#35;elif' '#35;endif' '#35;error' '#35;pragma' '#35;extension' '#35;version' '#35;line' "|miniDFA2
miniDFA1 -->|"#34;
ExtendToken 'literalString' "|miniDFA85
miniDFA1 -->|"[^#92;#92;#34;]"|miniDFA1
miniDFA1 -->|"#92;#92;"|miniDFA3
miniDFA67 -->|"#34;
BeginToken 'literalString' "|miniDFA1
miniDFA67 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|miniDFA86
miniDFA68 -->|"=
ExtendToken '==' "|miniDFA87
miniDFA69 -->|"=
ExtendToken '%=' "|miniDFA88
miniDFA70 -->|"=
ExtendToken '#42;=' "|miniDFA89
miniDFA71 -->|"=
ExtendToken '!=' "|miniDFA90
miniDFA72 -->|"#34;
BeginToken 'literalString' "|miniDFA1
miniDFA72 -->|"[0-9][A-Z]_[b-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA72 -->|"a
ExtendToken 'identifier' "|miniDFA91
miniDFA73 -->|"#34;
BeginToken 'literalString' "|miniDFA1
miniDFA73 -->|"[0-9][A-Z]_[a-q][s-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA73 -->|"r
ExtendToken 'identifier' "|miniDFA92
miniDFA74 -->|"#34;
BeginToken 'literalString' "|miniDFA1
miniDFA74 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA74 -->|"e
ExtendToken 'identifier' "|miniDFA93
miniDFA75 -->|"=
ExtendToken '|=' "|miniDFA94
miniDFA75 -->|"#92;|
ExtendToken '||' "|miniDFA95
miniDFA76 -->|"=
ExtendToken '^=' "|miniDFA96
miniDFA76 -->|"^
ExtendToken '^^' "|miniDFA97
miniDFA77 -->|"=
ExtendToken '&=' "|miniDFA98
miniDFA77 -->|"&
ExtendToken '&&' "|miniDFA99
miniDFA78 -->|"=
ExtendToken '>=' "|miniDFA100
miniDFA78 -->|">
ExtendToken '>>' "|miniDFA101
miniDFA79 -->|"=
ExtendToken '<=' "|miniDFA102
miniDFA79 -->|"#92;<
ExtendToken '<<' "|miniDFA103
miniDFA80 -->|"#92;/
ExtendToken 'inlineComment' "|miniDFA104
miniDFA80 -->|"=
ExtendToken '/=' "|miniDFA105
miniDFA81 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA81 -->|"[uU]
ExtendToken 'uintConstant' "|miniDFA107
miniDFA81 -->|"[Ee]"|miniDFA4
miniDFA81 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA108
miniDFA81 -->|"[0-9]
ExtendToken 'number' 'intConstant' 'doubleConstant' "|miniDFA81
miniDFA82 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA82 -->|"[uU]
ExtendToken 'uintConstant' "|miniDFA107
miniDFA82 -->|"[Ee]"|miniDFA4
miniDFA82 -->|"x"|miniDFA5
miniDFA82 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA108
miniDFA82 -->|"[0-9]
ExtendToken 'number' 'intConstant' 'doubleConstant' "|miniDFA81
miniDFA83 -->|"=
ExtendToken '-=' "|miniDFA109
miniDFA83 -->|"-
ExtendToken '--' "|miniDFA110
miniDFA83 -->|"[0-9]
BeginToken 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'intConstant' 'doubleConstant' "|miniDFA111
miniDFA84 -->|"=
ExtendToken '+=' "|miniDFA112
miniDFA84 -->|"#92;+
ExtendToken '++' "|miniDFA113
miniDFA84 -->|"[0-9]
BeginToken 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'intConstant' 'doubleConstant' "|miniDFA111
miniDFA2 -->|"l"|miniDFA6
miniDFA2 -->|"v"|miniDFA11
miniDFA2 -->|"p"|miniDFA17
miniDFA2 -->|"#35;
ExtendToken '#35;#35;' "|miniDFA114
miniDFA2 -->|"u"|miniDFA20
miniDFA2 -->|"d"|miniDFA12
miniDFA2 -->|"i"|miniDFA24
miniDFA2 -->|"e"|miniDFA25
miniDFA3 -->|"[#32;-~]"|miniDFA1
miniDFA86 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|miniDFA86
miniDFA91 -->|"[0-9][A-Z]_[a-k][m-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA91 -->|"l
ExtendToken 'identifier' "|miniDFA115
miniDFA92 -->|"[0-9][A-Z]_[a-t][v-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA92 -->|"u
ExtendToken 'identifier' "|miniDFA116
miniDFA93 -->|"[0-9][A-Z]_[a-e][g-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA93 -->|"f
ExtendToken 'identifier' "|miniDFA117
miniDFA101 -->|"=
ExtendToken '>>=' "|miniDFA118
miniDFA103 -->|"=
ExtendToken '<<=' "|miniDFA119
miniDFA104 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment' "|miniDFA120
miniDFA4 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA121
miniDFA4 -->|"[-+]"|miniDFA26
miniDFA108 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA108 -->|"[Ee]"|miniDFA4
miniDFA108 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA122
miniDFA108 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|miniDFA123
miniDFA5 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant' "|miniDFA124
miniDFA111 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA111 -->|"[uU]
ExtendToken 'uintConstant' "|miniDFA107
miniDFA111 -->|"[Ee]"|miniDFA4
miniDFA111 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA125
miniDFA111 -->|"[0-9]
ExtendToken 'intConstant' 'doubleConstant' "|miniDFA111
miniDFA6 -->|"i"|miniDFA21
miniDFA11 -->|"e"|miniDFA18
miniDFA17 -->|"r"|miniDFA27
miniDFA20 -->|"n"|miniDFA28
miniDFA12 -->|"e"|miniDFA31
miniDFA24 -->|"f
ExtendToken '#35;if' "|miniDFA126
miniDFA25 -->|"x"|miniDFA32
miniDFA25 -->|"r"|miniDFA19
miniDFA25 -->|"n"|miniDFA30
miniDFA25 -->|"l"|miniDFA33
miniDFA115 -->|"[0-9][A-Z]_[a-r][t-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA115 -->|"s
ExtendToken 'identifier' "|miniDFA127
miniDFA116 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA116 -->|"e
ExtendToken 'identifier' 'boolConstant' "|miniDFA128
miniDFA117 -->|"[0-9][A-Z]_[a-h][j-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA117 -->|"i
ExtendToken 'identifier' "|miniDFA129
miniDFA120 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment' "|miniDFA120
miniDFA121 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA121 -->|"[Ee]"|miniDFA34
miniDFA121 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA121
miniDFA26 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA121
miniDFA122 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA122 -->|"[Ee]"|miniDFA4
miniDFA122 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA130
miniDFA123 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA123 -->|"[Ee]"|miniDFA4
miniDFA123 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA131
miniDFA123 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|miniDFA123
miniDFA124 -->|"[uU]
ExtendToken 'uintConstant' "|miniDFA132
miniDFA124 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant' "|miniDFA124
miniDFA125 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA125 -->|"[Ee]"|miniDFA4
miniDFA125 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA122
miniDFA125 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA133
miniDFA21 -->|"n"|miniDFA35
miniDFA18 -->|"r"|miniDFA36
miniDFA27 -->|"a"|miniDFA38
miniDFA28 -->|"d"|miniDFA13
miniDFA31 -->|"f"|miniDFA7
miniDFA126 -->|"n"|miniDFA29
miniDFA126 -->|"d"|miniDFA14
miniDFA32 -->|"t"|miniDFA15
miniDFA19 -->|"r"|miniDFA39
miniDFA30 -->|"d"|miniDFA8
miniDFA33 -->|"i"|miniDFA42
miniDFA33 -->|"s"|miniDFA43
miniDFA127 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA127 -->|"e
ExtendToken 'identifier' 'boolConstant' "|miniDFA134
miniDFA128 -->|"[^a-zA-Z0-9_]"|miniDFA135
miniDFA128 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|miniDFA86
miniDFA129 -->|"[0-9][A-Z]_[a-m][o-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA129 -->|"n
ExtendToken 'identifier' "|miniDFA136
miniDFA34 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA137
miniDFA34 -->|"[-+]"|miniDFA44
miniDFA130 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA130 -->|"[Ee]"|miniDFA4
miniDFA130 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA130
miniDFA131 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA131 -->|"[Ee]"|miniDFA4
miniDFA131 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|miniDFA138
miniDFA133 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA133 -->|"[Ee]"|miniDFA4
miniDFA133 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA122
miniDFA133 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA133
miniDFA35 -->|"e
ExtendToken '#35;line' "|miniDFA139
miniDFA36 -->|"s"|miniDFA9
miniDFA38 -->|"g"|miniDFA45
miniDFA13 -->|"e"|miniDFA46
miniDFA7 -->|"i"|miniDFA22
miniDFA29 -->|"d"|miniDFA16
miniDFA14 -->|"e"|miniDFA47
miniDFA15 -->|"e"|miniDFA23
miniDFA39 -->|"o"|miniDFA48
miniDFA8 -->|"i"|miniDFA49
miniDFA42 -->|"f
ExtendToken '#35;elif' "|miniDFA140
miniDFA43 -->|"e
ExtendToken '#35;else' "|miniDFA141
miniDFA134 -->|"[^a-zA-Z0-9_]"|miniDFA142
miniDFA134 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|miniDFA86
miniDFA136 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA136 -->|"e
ExtendToken 'identifier' "|miniDFA143
miniDFA137 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA137 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA137
miniDFA44 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA137
miniDFA138 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA138 -->|"[Ee]"|miniDFA4
miniDFA138 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|miniDFA138
miniDFA9 -->|"i"|miniDFA40
miniDFA45 -->|"m"|miniDFA50
miniDFA46 -->|"f
ExtendToken '#35;undef' "|miniDFA144
miniDFA22 -->|"n"|miniDFA51
miniDFA16 -->|"e"|miniDFA52
miniDFA47 -->|"f
ExtendToken '#35;ifdef' "|miniDFA145
miniDFA23 -->|"n"|miniDFA37
miniDFA48 -->|"r
ExtendToken '#35;error' "|miniDFA146
miniDFA49 -->|"f
ExtendToken '#35;endif' "|miniDFA147
miniDFA143 -->|"[0-9][A-Z]_[a-c][e-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA143 -->|"d
ExtendToken 'defined' 'identifier' "|miniDFA148
miniDFA40 -->|"o"|miniDFA53
miniDFA50 -->|"a
ExtendToken '#35;pragma' "|miniDFA149
miniDFA51 -->|"e
ExtendToken '#35;define' "|miniDFA150
miniDFA52 -->|"f
ExtendToken '#35;ifndef' "|miniDFA151
miniDFA37 -->|"s"|miniDFA10
miniDFA148 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|miniDFA86
miniDFA53 -->|"n
ExtendToken '#35;version' "|miniDFA152
miniDFA10 -->|"i"|miniDFA41
miniDFA41 -->|"o"|miniDFA54
miniDFA54 -->|"n
ExtendToken '#35;extension' "|miniDFA153

```
## 5/5: miniDFA.simple

```Mermaid
flowchart
classDef c0001 color:#FF0000;
classDef c0010 stroke-dasharray: 10 10;
classDef c0011 stroke-dasharray: 10 10,color:#FF0000;
classDef c0100 fill:#BB66EE;
classDef c0101 fill:#BB66EE,color:#FF0000;
classDef c0110 fill:#BB66EE,stroke-dasharray: 10 10;
classDef c0111 fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
classDef c1000 stroke:#333,stroke-width:4px;
classDef c1001 stroke:#333,stroke-width:4px,color:#FF0000;
classDef c1010 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10;
classDef c1011 stroke:#333,stroke-width:4px,stroke-dasharray: 10 10,color:#FF0000;
classDef c1100 stroke:#333,stroke-width:4px,fill:#BB66EE;
classDef c1101 stroke:#333,stroke-width:4px,fill:#BB66EE,color:#FF0000;
classDef c1110 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10;
classDef c1111 stroke:#333,stroke-width:4px,fill:#BB66EE,stroke-dasharray: 10 10,color:#FF0000;
miniDFA0(["miniDFA0 1 DFA States"])
class miniDFA0 c1000;
miniDFA1(["miniDFA1 3 DFA States"])
miniDFA55(["miniDFA55 1 DFA States
AcceptToken '}'"])
class miniDFA55 c0001;
miniDFA56(["miniDFA56 1 DFA States
AcceptToken '{'"])
class miniDFA56 c0001;
miniDFA57(["miniDFA57 1 DFA States
AcceptToken ':'"])
class miniDFA57 c0001;
miniDFA58(["miniDFA58 1 DFA States
AcceptToken '?'"])
class miniDFA58 c0001;
miniDFA59(["miniDFA59 1 DFA States
AcceptToken '~'"])
class miniDFA59 c0001;
miniDFA60(["miniDFA60 1 DFA States
AcceptToken '.'"])
class miniDFA60 c0001;
miniDFA61(["miniDFA61 1 DFA States
AcceptToken ']'"])
class miniDFA61 c0001;
miniDFA62(["miniDFA62 1 DFA States
AcceptToken '['"])
class miniDFA62 c0001;
miniDFA63(["miniDFA63 1 DFA States
AcceptToken ';'"])
class miniDFA63 c0001;
miniDFA64(["miniDFA64 1 DFA States
AcceptToken ','"])
class miniDFA64 c0001;
miniDFA65(["miniDFA65 1 DFA States
AcceptToken ')'"])
class miniDFA65 c0001;
miniDFA66(["miniDFA66 1 DFA States
AcceptToken '('"])
class miniDFA66 c0001;
miniDFA67(["miniDFA67 1 DFA States
AcceptToken 'identifier'"])
class miniDFA67 c1001;
miniDFA68(["miniDFA68 1 DFA States
AcceptToken '='"])
class miniDFA68 c0001;
miniDFA69(["miniDFA69 1 DFA States
AcceptToken '%'"])
class miniDFA69 c0001;
miniDFA70(["miniDFA70 1 DFA States
AcceptToken '*'"])
class miniDFA70 c0001;
miniDFA71(["miniDFA71 1 DFA States
AcceptToken '!'"])
class miniDFA71 c0001;
miniDFA72(["miniDFA72 1 DFA States
AcceptToken 'identifier'"])
class miniDFA72 c1001;
miniDFA73(["miniDFA73 1 DFA States
AcceptToken 'identifier'"])
class miniDFA73 c1001;
miniDFA74(["miniDFA74 1 DFA States
AcceptToken 'identifier'"])
class miniDFA74 c1001;
miniDFA75(["miniDFA75 1 DFA States
AcceptToken '|'"])
class miniDFA75 c0001;
miniDFA76(["miniDFA76 1 DFA States
AcceptToken '^'"])
class miniDFA76 c0001;
miniDFA77(["miniDFA77 1 DFA States
AcceptToken '&'"])
class miniDFA77 c0001;
miniDFA78(["miniDFA78 1 DFA States
AcceptToken '>'"])
class miniDFA78 c0001;
miniDFA79(["miniDFA79 1 DFA States
AcceptToken '<'"])
class miniDFA79 c0001;
miniDFA80(["miniDFA80 1 DFA States
AcceptToken '/'"])
class miniDFA80 c0001;
miniDFA81(["miniDFA81 1 DFA States
AcceptToken 'number'
AcceptToken 'intConstant'
AcceptToken 'doubleConstant'"])
class miniDFA81 c0001;
miniDFA82(["miniDFA82 1 DFA States
AcceptToken 'number'
AcceptToken 'intConstant'
AcceptToken 'doubleConstant'"])
class miniDFA82 c0001;
miniDFA83(["miniDFA83 1 DFA States
AcceptToken '-'"])
class miniDFA83 c1001;
miniDFA84(["miniDFA84 1 DFA States
AcceptToken '+'"])
class miniDFA84 c1001;
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA85(["miniDFA85 1 DFA States
AcceptToken 'literalString'"])
class miniDFA85 c0001;
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA86(["miniDFA86 1 DFA States
AcceptToken 'identifier'"])
class miniDFA86 c0001;
miniDFA87(["miniDFA87 1 DFA States
AcceptToken '=='"])
class miniDFA87 c0001;
miniDFA88(["miniDFA88 1 DFA States
AcceptToken '%='"])
class miniDFA88 c0001;
miniDFA89(["miniDFA89 1 DFA States
AcceptToken '*='"])
class miniDFA89 c0001;
miniDFA90(["miniDFA90 1 DFA States
AcceptToken '!='"])
class miniDFA90 c0001;
miniDFA91(["miniDFA91 1 DFA States
AcceptToken 'identifier'"])
class miniDFA91 c0001;
miniDFA92(["miniDFA92 1 DFA States
AcceptToken 'identifier'"])
class miniDFA92 c0001;
miniDFA93(["miniDFA93 1 DFA States
AcceptToken 'identifier'"])
class miniDFA93 c0001;
miniDFA94(["miniDFA94 1 DFA States
AcceptToken '|='"])
class miniDFA94 c0001;
miniDFA95(["miniDFA95 1 DFA States
AcceptToken '||'"])
class miniDFA95 c0001;
miniDFA96(["miniDFA96 1 DFA States
AcceptToken '^='"])
class miniDFA96 c0001;
miniDFA97(["miniDFA97 1 DFA States
AcceptToken '^^'"])
class miniDFA97 c0001;
miniDFA98(["miniDFA98 1 DFA States
AcceptToken '&='"])
class miniDFA98 c0001;
miniDFA99(["miniDFA99 1 DFA States
AcceptToken '&&'"])
class miniDFA99 c0001;
miniDFA100(["miniDFA100 1 DFA States
AcceptToken '>='"])
class miniDFA100 c0001;
miniDFA101(["miniDFA101 1 DFA States
AcceptToken '>>'"])
class miniDFA101 c0001;
miniDFA102(["miniDFA102 1 DFA States
AcceptToken '<='"])
class miniDFA102 c0001;
miniDFA103(["miniDFA103 1 DFA States
AcceptToken '<<'"])
class miniDFA103 c0001;
miniDFA104(["miniDFA104 1 DFA States
AcceptToken 'inlineComment'"])
class miniDFA104 c0001;
miniDFA105(["miniDFA105 1 DFA States
AcceptToken '/='"])
class miniDFA105 c0001;
miniDFA106(["miniDFA106 1 DFA States
AcceptToken 'floatConstant'"])
class miniDFA106 c0001;
miniDFA107(["miniDFA107 1 DFA States
AcceptToken 'uintConstant'"])
class miniDFA107 c0001;
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA108(["miniDFA108 1 DFA States
AcceptToken 'doubleConstant'"])
class miniDFA108 c0001;
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA109(["miniDFA109 1 DFA States
AcceptToken '-='"])
class miniDFA109 c0001;
miniDFA110(["miniDFA110 1 DFA States
AcceptToken '--'"])
class miniDFA110 c0001;
miniDFA111(["miniDFA111 1 DFA States
AcceptToken 'intConstant'
AcceptToken 'doubleConstant'"])
class miniDFA111 c0001;
miniDFA112(["miniDFA112 1 DFA States
AcceptToken '+='"])
class miniDFA112 c0001;
miniDFA113(["miniDFA113 1 DFA States
AcceptToken '++'"])
class miniDFA113 c0001;
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA11(["miniDFA11 1 DFA States"])
miniDFA17(["miniDFA17 1 DFA States"])
miniDFA114(["miniDFA114 1 DFA States
AcceptToken '##'"])
class miniDFA114 c0001;
miniDFA20(["miniDFA20 1 DFA States"])
miniDFA12(["miniDFA12 1 DFA States"])
miniDFA24(["miniDFA24 1 DFA States"])
miniDFA25(["miniDFA25 1 DFA States"])
miniDFA115(["miniDFA115 1 DFA States
AcceptToken 'identifier'"])
class miniDFA115 c0001;
miniDFA116(["miniDFA116 1 DFA States
AcceptToken 'identifier'"])
class miniDFA116 c0001;
miniDFA117(["miniDFA117 1 DFA States
AcceptToken 'identifier'"])
class miniDFA117 c0001;
miniDFA118(["miniDFA118 1 DFA States
AcceptToken '>>='"])
class miniDFA118 c0001;
miniDFA119(["miniDFA119 1 DFA States
AcceptToken '<<='"])
class miniDFA119 c0001;
miniDFA120(["miniDFA120 1 DFA States
AcceptToken 'inlineComment'"])
class miniDFA120 c0001;
miniDFA121(["miniDFA121 1 DFA States
AcceptToken 'doubleConstant'"])
class miniDFA121 c0001;
miniDFA26(["miniDFA26 1 DFA States"])
miniDFA122(["miniDFA122 1 DFA States
AcceptToken 'doubleConstant'"])
class miniDFA122 c0001;
miniDFA123(["miniDFA123 1 DFA States
AcceptToken 'number'
AcceptToken 'doubleConstant'"])
class miniDFA123 c0001;
miniDFA124(["miniDFA124 1 DFA States
AcceptToken 'intConstant'"])
class miniDFA124 c0001;
miniDFA125(["miniDFA125 1 DFA States
AcceptToken 'doubleConstant'"])
class miniDFA125 c0001;
miniDFA21(["miniDFA21 1 DFA States"])
miniDFA18(["miniDFA18 1 DFA States"])
miniDFA27(["miniDFA27 1 DFA States"])
miniDFA28(["miniDFA28 1 DFA States"])
miniDFA31(["miniDFA31 1 DFA States"])
miniDFA126(["miniDFA126 1 DFA States
AcceptToken '#if'"])
class miniDFA126 c0001;
miniDFA32(["miniDFA32 1 DFA States"])
miniDFA19(["miniDFA19 1 DFA States"])
miniDFA30(["miniDFA30 1 DFA States"])
miniDFA33(["miniDFA33 1 DFA States"])
miniDFA127(["miniDFA127 1 DFA States
AcceptToken 'identifier'"])
class miniDFA127 c0001;
miniDFA128(["miniDFA128 1 DFA States
AcceptToken 'identifier'"])
class miniDFA128 c0001;
miniDFA129(["miniDFA129 1 DFA States
AcceptToken 'identifier'"])
class miniDFA129 c0001;
miniDFA34(["miniDFA34 1 DFA States"])
miniDFA130(["miniDFA130 1 DFA States
AcceptToken 'doubleConstant'"])
class miniDFA130 c0001;
miniDFA131(["miniDFA131 1 DFA States
AcceptToken 'doubleConstant'"])
class miniDFA131 c0001;
miniDFA132(["miniDFA132 1 DFA States
AcceptToken 'uintConstant'"])
class miniDFA132 c0001;
miniDFA133(["miniDFA133 1 DFA States
AcceptToken 'doubleConstant'"])
class miniDFA133 c0001;
miniDFA35(["miniDFA35 1 DFA States"])
miniDFA36(["miniDFA36 1 DFA States"])
miniDFA38(["miniDFA38 1 DFA States"])
miniDFA13(["miniDFA13 1 DFA States"])
miniDFA7(["miniDFA7 1 DFA States"])
miniDFA29(["miniDFA29 1 DFA States"])
miniDFA14(["miniDFA14 1 DFA States"])
miniDFA15(["miniDFA15 1 DFA States"])
miniDFA39(["miniDFA39 1 DFA States"])
miniDFA8(["miniDFA8 1 DFA States"])
miniDFA42(["miniDFA42 1 DFA States"])
miniDFA43(["miniDFA43 1 DFA States"])
miniDFA134(["miniDFA134 1 DFA States
AcceptToken 'identifier'"])
class miniDFA134 c0001;
miniDFA135(["miniDFA135 1 DFA States
AcceptToken 'boolConstant'"])
class miniDFA135 c0001;
miniDFA136(["miniDFA136 1 DFA States
AcceptToken 'identifier'"])
class miniDFA136 c0001;
miniDFA137(["miniDFA137 1 DFA States
AcceptToken 'doubleConstant'"])
class miniDFA137 c0001;
miniDFA44(["miniDFA44 1 DFA States"])
miniDFA138(["miniDFA138 1 DFA States
AcceptToken 'number'
AcceptToken 'doubleConstant'"])
class miniDFA138 c0001;
miniDFA139(["miniDFA139 1 DFA States
AcceptToken '#line'"])
class miniDFA139 c0001;
miniDFA9(["miniDFA9 1 DFA States"])
miniDFA45(["miniDFA45 1 DFA States"])
miniDFA46(["miniDFA46 1 DFA States"])
miniDFA22(["miniDFA22 1 DFA States"])
miniDFA16(["miniDFA16 1 DFA States"])
miniDFA47(["miniDFA47 1 DFA States"])
miniDFA23(["miniDFA23 1 DFA States"])
miniDFA48(["miniDFA48 1 DFA States"])
miniDFA49(["miniDFA49 1 DFA States"])
miniDFA140(["miniDFA140 1 DFA States
AcceptToken '#elif'"])
class miniDFA140 c0001;
miniDFA141(["miniDFA141 1 DFA States
AcceptToken '#else'"])
class miniDFA141 c0001;
miniDFA142(["miniDFA142 1 DFA States
AcceptToken 'boolConstant'"])
class miniDFA142 c0001;
miniDFA143(["miniDFA143 1 DFA States
AcceptToken 'identifier'"])
class miniDFA143 c0001;
miniDFA40(["miniDFA40 1 DFA States"])
miniDFA50(["miniDFA50 1 DFA States"])
miniDFA144(["miniDFA144 1 DFA States
AcceptToken '#undef'"])
class miniDFA144 c0001;
miniDFA51(["miniDFA51 1 DFA States"])
miniDFA52(["miniDFA52 1 DFA States"])
miniDFA145(["miniDFA145 1 DFA States
AcceptToken '#ifdef'"])
class miniDFA145 c0001;
miniDFA37(["miniDFA37 1 DFA States"])
miniDFA146(["miniDFA146 1 DFA States
AcceptToken '#error'"])
class miniDFA146 c0001;
miniDFA147(["miniDFA147 1 DFA States
AcceptToken '#endif'"])
class miniDFA147 c0001;
miniDFA148(["miniDFA148 1 DFA States
AcceptToken 'defined'
AcceptToken 'identifier'"])
class miniDFA148 c0001;
miniDFA53(["miniDFA53 1 DFA States"])
miniDFA149(["miniDFA149 1 DFA States
AcceptToken '#pragma'"])
class miniDFA149 c0001;
miniDFA150(["miniDFA150 1 DFA States
AcceptToken '#define'"])
class miniDFA150 c0001;
miniDFA151(["miniDFA151 1 DFA States
AcceptToken '#ifndef'"])
class miniDFA151 c0001;
miniDFA10(["miniDFA10 1 DFA States"])
miniDFA152(["miniDFA152 1 DFA States
AcceptToken '#version'"])
class miniDFA152 c0001;
miniDFA41(["miniDFA41 1 DFA States"])
miniDFA54(["miniDFA54 1 DFA States"])
miniDFA153(["miniDFA153 1 DFA States
AcceptToken '#extension'"])
class miniDFA153 c0001;
miniDFA0 -->|"#34;
BeginToken 'literalString' "|miniDFA1
miniDFA0 -->|"}
BeginToken '}' 
ExtendToken '}' "|miniDFA55
miniDFA0 -->|"#92;{
BeginToken '{' 
ExtendToken '{' "|miniDFA56
miniDFA0 -->|":
BeginToken ':' 
ExtendToken ':' "|miniDFA57
miniDFA0 -->|"#92;?
BeginToken '?' 
ExtendToken '?' "|miniDFA58
miniDFA0 -->|"~
BeginToken '~' 
ExtendToken '~' "|miniDFA59
miniDFA0 -->|"#92;.
BeginToken '.' 
ExtendToken '.' "|miniDFA60
miniDFA0 -->|"]
BeginToken ']' 
ExtendToken ']' "|miniDFA61
miniDFA0 -->|"#92;[
BeginToken '[' 
ExtendToken '[' "|miniDFA62
miniDFA0 -->|";
BeginToken ';' 
ExtendToken ';' "|miniDFA63
miniDFA0 -->|",
BeginToken ',' 
ExtendToken ',' "|miniDFA64
miniDFA0 -->|"#92;)
BeginToken ')' 
ExtendToken ')' "|miniDFA65
miniDFA0 -->|"#92;(
BeginToken '(' 
ExtendToken '(' "|miniDFA66
miniDFA0 -->|"[A-Z]_[a-c]e[g-s][u-z]
BeginToken 'identifier' 'literalString' 
ExtendToken 'identifier' "|miniDFA67
miniDFA0 -->|"=
BeginToken '==' '=' 
ExtendToken '=' "|miniDFA68
miniDFA0 -->|"%
BeginToken '%' '%=' 
ExtendToken '%' "|miniDFA69
miniDFA0 -->|"#92;#42;
BeginToken '#42;' '#42;=' 
ExtendToken '#42;' "|miniDFA70
miniDFA0 -->|"!
BeginToken '!' '!=' 
ExtendToken '!' "|miniDFA71
miniDFA0 -->|"f
BeginToken 'identifier' 'literalString' 'boolConstant' 
ExtendToken 'identifier' "|miniDFA72
miniDFA0 -->|"t
BeginToken 'identifier' 'literalString' 'boolConstant' 
ExtendToken 'identifier' "|miniDFA73
miniDFA0 -->|"d
BeginToken 'defined' 'identifier' 'literalString' 
ExtendToken 'identifier' "|miniDFA74
miniDFA0 -->|"#92;|
BeginToken '|' '||' '|=' 
ExtendToken '|' "|miniDFA75
miniDFA0 -->|"^
BeginToken '^' '^^' '^=' 
ExtendToken '^' "|miniDFA76
miniDFA0 -->|"&
BeginToken '&' '&&' '&=' 
ExtendToken '&' "|miniDFA77
miniDFA0 -->|">
BeginToken '>>' '>' '>=' '>>=' 
ExtendToken '>' "|miniDFA78
miniDFA0 -->|"#92;<
BeginToken '<<' '<' '<=' '<<=' 
ExtendToken '<' "|miniDFA79
miniDFA0 -->|"#92;/
BeginToken '/' '/=' 'inlineComment' 
ExtendToken '/' "|miniDFA80
miniDFA0 -->|"[1-9]
BeginToken 'number' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'number' 'intConstant' 'doubleConstant' "|miniDFA81
miniDFA0 -->|"0
BeginToken 'number' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'number' 'intConstant' 'doubleConstant' "|miniDFA82
miniDFA0 -->|"-
BeginToken '--' '-' '-=' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken '-' "|miniDFA83
miniDFA0 -->|"#92;+
BeginToken '++' '+' '+=' 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken '+' "|miniDFA84
miniDFA0 -->|"#35;
BeginToken '#35;define' '#35;undef' '#35;#35;' '#35;if' '#35;ifdef' '#35;ifndef' '#35;else' '#35;elif' '#35;endif' '#35;error' '#35;pragma' '#35;extension' '#35;version' '#35;line' "|miniDFA2
miniDFA1 -->|"#34;
ExtendToken 'literalString' "|miniDFA85
miniDFA1 -->|"[^#92;#92;#34;]"|miniDFA1
miniDFA1 -->|"#92;#92;"|miniDFA3
miniDFA67 -->|"#34;
BeginToken 'literalString' "|miniDFA1
miniDFA67 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|miniDFA86
miniDFA68 -->|"=
ExtendToken '==' "|miniDFA87
miniDFA69 -->|"=
ExtendToken '%=' "|miniDFA88
miniDFA70 -->|"=
ExtendToken '#42;=' "|miniDFA89
miniDFA71 -->|"=
ExtendToken '!=' "|miniDFA90
miniDFA72 -->|"#34;
BeginToken 'literalString' "|miniDFA1
miniDFA72 -->|"[0-9][A-Z]_[b-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA72 -->|"a
ExtendToken 'identifier' "|miniDFA91
miniDFA73 -->|"#34;
BeginToken 'literalString' "|miniDFA1
miniDFA73 -->|"[0-9][A-Z]_[a-q][s-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA73 -->|"r
ExtendToken 'identifier' "|miniDFA92
miniDFA74 -->|"#34;
BeginToken 'literalString' "|miniDFA1
miniDFA74 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA74 -->|"e
ExtendToken 'identifier' "|miniDFA93
miniDFA75 -->|"=
ExtendToken '|=' "|miniDFA94
miniDFA75 -->|"#92;|
ExtendToken '||' "|miniDFA95
miniDFA76 -->|"=
ExtendToken '^=' "|miniDFA96
miniDFA76 -->|"^
ExtendToken '^^' "|miniDFA97
miniDFA77 -->|"=
ExtendToken '&=' "|miniDFA98
miniDFA77 -->|"&
ExtendToken '&&' "|miniDFA99
miniDFA78 -->|"=
ExtendToken '>=' "|miniDFA100
miniDFA78 -->|">
ExtendToken '>>' "|miniDFA101
miniDFA79 -->|"=
ExtendToken '<=' "|miniDFA102
miniDFA79 -->|"#92;<
ExtendToken '<<' "|miniDFA103
miniDFA80 -->|"#92;/
ExtendToken 'inlineComment' "|miniDFA104
miniDFA80 -->|"=
ExtendToken '/=' "|miniDFA105
miniDFA81 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA81 -->|"[uU]
ExtendToken 'uintConstant' "|miniDFA107
miniDFA81 -->|"[Ee]"|miniDFA4
miniDFA81 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA108
miniDFA81 -->|"[0-9]
ExtendToken 'number' 'intConstant' 'doubleConstant' "|miniDFA81
miniDFA82 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA82 -->|"[uU]
ExtendToken 'uintConstant' "|miniDFA107
miniDFA82 -->|"[Ee]"|miniDFA4
miniDFA82 -->|"x"|miniDFA5
miniDFA82 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA108
miniDFA82 -->|"[0-9]
ExtendToken 'number' 'intConstant' 'doubleConstant' "|miniDFA81
miniDFA83 -->|"=
ExtendToken '-=' "|miniDFA109
miniDFA83 -->|"-
ExtendToken '--' "|miniDFA110
miniDFA83 -->|"[0-9]
BeginToken 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'intConstant' 'doubleConstant' "|miniDFA111
miniDFA84 -->|"=
ExtendToken '+=' "|miniDFA112
miniDFA84 -->|"#92;+
ExtendToken '++' "|miniDFA113
miniDFA84 -->|"[0-9]
BeginToken 'intConstant' 'uintConstant' 'floatConstant' 'doubleConstant' 
ExtendToken 'intConstant' 'doubleConstant' "|miniDFA111
miniDFA2 -->|"l"|miniDFA6
miniDFA2 -->|"v"|miniDFA11
miniDFA2 -->|"p"|miniDFA17
miniDFA2 -->|"#35;
ExtendToken '#35;#35;' "|miniDFA114
miniDFA2 -->|"u"|miniDFA20
miniDFA2 -->|"d"|miniDFA12
miniDFA2 -->|"i"|miniDFA24
miniDFA2 -->|"e"|miniDFA25
miniDFA3 -->|"[#32;-~]"|miniDFA1
miniDFA86 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|miniDFA86
miniDFA91 -->|"[0-9][A-Z]_[a-k][m-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA91 -->|"l
ExtendToken 'identifier' "|miniDFA115
miniDFA92 -->|"[0-9][A-Z]_[a-t][v-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA92 -->|"u
ExtendToken 'identifier' "|miniDFA116
miniDFA93 -->|"[0-9][A-Z]_[a-e][g-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA93 -->|"f
ExtendToken 'identifier' "|miniDFA117
miniDFA101 -->|"=
ExtendToken '>>=' "|miniDFA118
miniDFA103 -->|"=
ExtendToken '<<=' "|miniDFA119
miniDFA104 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment' "|miniDFA120
miniDFA4 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA121
miniDFA4 -->|"[-+]"|miniDFA26
miniDFA108 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA108 -->|"[Ee]"|miniDFA4
miniDFA108 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA122
miniDFA108 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|miniDFA123
miniDFA5 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant' "|miniDFA124
miniDFA111 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA111 -->|"[uU]
ExtendToken 'uintConstant' "|miniDFA107
miniDFA111 -->|"[Ee]"|miniDFA4
miniDFA111 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA125
miniDFA111 -->|"[0-9]
ExtendToken 'intConstant' 'doubleConstant' "|miniDFA111
miniDFA6 -->|"i"|miniDFA21
miniDFA11 -->|"e"|miniDFA18
miniDFA17 -->|"r"|miniDFA27
miniDFA20 -->|"n"|miniDFA28
miniDFA12 -->|"e"|miniDFA31
miniDFA24 -->|"f
ExtendToken '#35;if' "|miniDFA126
miniDFA25 -->|"x"|miniDFA32
miniDFA25 -->|"r"|miniDFA19
miniDFA25 -->|"n"|miniDFA30
miniDFA25 -->|"l"|miniDFA33
miniDFA115 -->|"[0-9][A-Z]_[a-r][t-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA115 -->|"s
ExtendToken 'identifier' "|miniDFA127
miniDFA116 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA116 -->|"e
ExtendToken 'identifier' 'boolConstant' "|miniDFA128
miniDFA117 -->|"[0-9][A-Z]_[a-h][j-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA117 -->|"i
ExtendToken 'identifier' "|miniDFA129
miniDFA120 -->|"[^#92;n#92;r#92;u0000]
ExtendToken 'inlineComment' "|miniDFA120
miniDFA121 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA121 -->|"[Ee]"|miniDFA34
miniDFA121 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA121
miniDFA26 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA121
miniDFA122 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA122 -->|"[Ee]"|miniDFA4
miniDFA122 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA130
miniDFA123 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA123 -->|"[Ee]"|miniDFA4
miniDFA123 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA131
miniDFA123 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|miniDFA123
miniDFA124 -->|"[uU]
ExtendToken 'uintConstant' "|miniDFA132
miniDFA124 -->|"[0-9A-Fa-f]
ExtendToken 'intConstant' "|miniDFA124
miniDFA125 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA125 -->|"[Ee]"|miniDFA4
miniDFA125 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA122
miniDFA125 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA133
miniDFA21 -->|"n"|miniDFA35
miniDFA18 -->|"r"|miniDFA36
miniDFA27 -->|"a"|miniDFA38
miniDFA28 -->|"d"|miniDFA13
miniDFA31 -->|"f"|miniDFA7
miniDFA126 -->|"n"|miniDFA29
miniDFA126 -->|"d"|miniDFA14
miniDFA32 -->|"t"|miniDFA15
miniDFA19 -->|"r"|miniDFA39
miniDFA30 -->|"d"|miniDFA8
miniDFA33 -->|"i"|miniDFA42
miniDFA33 -->|"s"|miniDFA43
miniDFA127 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA127 -->|"e
ExtendToken 'identifier' 'boolConstant' "|miniDFA134
miniDFA128 -->|"[^a-zA-Z0-9_]"|miniDFA135
miniDFA128 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|miniDFA86
miniDFA129 -->|"[0-9][A-Z]_[a-m][o-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA129 -->|"n
ExtendToken 'identifier' "|miniDFA136
miniDFA34 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA137
miniDFA34 -->|"[-+]"|miniDFA44
miniDFA130 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA130 -->|"[Ee]"|miniDFA4
miniDFA130 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA130
miniDFA131 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA131 -->|"[Ee]"|miniDFA4
miniDFA131 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|miniDFA138
miniDFA133 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA133 -->|"[Ee]"|miniDFA4
miniDFA133 -->|"[.]
ExtendToken 'doubleConstant' "|miniDFA122
miniDFA133 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA133
miniDFA35 -->|"e
ExtendToken '#35;line' "|miniDFA139
miniDFA36 -->|"s"|miniDFA9
miniDFA38 -->|"g"|miniDFA45
miniDFA13 -->|"e"|miniDFA46
miniDFA7 -->|"i"|miniDFA22
miniDFA29 -->|"d"|miniDFA16
miniDFA14 -->|"e"|miniDFA47
miniDFA15 -->|"e"|miniDFA23
miniDFA39 -->|"o"|miniDFA48
miniDFA8 -->|"i"|miniDFA49
miniDFA42 -->|"f
ExtendToken '#35;elif' "|miniDFA140
miniDFA43 -->|"e
ExtendToken '#35;else' "|miniDFA141
miniDFA134 -->|"[^a-zA-Z0-9_]"|miniDFA142
miniDFA134 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|miniDFA86
miniDFA136 -->|"[0-9][A-Z]_[a-d][f-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA136 -->|"e
ExtendToken 'identifier' "|miniDFA143
miniDFA137 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA137 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA137
miniDFA44 -->|"[0-9]
ExtendToken 'doubleConstant' "|miniDFA137
miniDFA138 -->|"[fF]
ExtendToken 'floatConstant' "|miniDFA106
miniDFA138 -->|"[Ee]"|miniDFA4
miniDFA138 -->|"[0-9]
ExtendToken 'number' 'doubleConstant' "|miniDFA138
miniDFA9 -->|"i"|miniDFA40
miniDFA45 -->|"m"|miniDFA50
miniDFA46 -->|"f
ExtendToken '#35;undef' "|miniDFA144
miniDFA22 -->|"n"|miniDFA51
miniDFA16 -->|"e"|miniDFA52
miniDFA47 -->|"f
ExtendToken '#35;ifdef' "|miniDFA145
miniDFA23 -->|"n"|miniDFA37
miniDFA48 -->|"r
ExtendToken '#35;error' "|miniDFA146
miniDFA49 -->|"f
ExtendToken '#35;endif' "|miniDFA147
miniDFA143 -->|"[0-9][A-Z]_[a-c][e-z]
ExtendToken 'identifier' "|miniDFA86
miniDFA143 -->|"d
ExtendToken 'defined' 'identifier' "|miniDFA148
miniDFA40 -->|"o"|miniDFA53
miniDFA50 -->|"a
ExtendToken '#35;pragma' "|miniDFA149
miniDFA51 -->|"e
ExtendToken '#35;define' "|miniDFA150
miniDFA52 -->|"f
ExtendToken '#35;ifndef' "|miniDFA151
miniDFA37 -->|"s"|miniDFA10
miniDFA148 -->|"[a-zA-Z0-9_]
ExtendToken 'identifier' "|miniDFA86
miniDFA53 -->|"n
ExtendToken '#35;version' "|miniDFA152
miniDFA10 -->|"i"|miniDFA41
miniDFA41 -->|"o"|miniDFA54
miniDFA54 -->|"n
ExtendToken '#35;extension' "|miniDFA153

```

# 总结

无。

