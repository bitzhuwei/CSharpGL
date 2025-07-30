# Vt: 'else'

patterns[0]: `else`

-------------------------------
# 1/5: extracted ε-NFA
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
eNFA0_10[["εNFA0-10 post-regex start"]]
eNFA0_11[\"εNFA0-11 post-regex end"/]
eNFA0_8 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"e"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"l"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"s"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"e"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -.->|"ε"|eNFA0_11
```
-------------------------------
# 2/5: manifested ε-NFA
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
eNFA0_7[\"εNFA0-7 char[1]"/]
eNFA0_9[\"εNFA0-9 regex end"/]
eNFA0_10[\"εNFA0-10 post-regex start"/]
eNFA0_11[\"εNFA0-11 post-regex end"/]
eNFA0_8 -.->|"ε"|eNFA0_0
eNFA0_8 -->|"e"|eNFA0_1
eNFA0_0 -->|"e"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_1 -->|"l"|eNFA0_3
eNFA0_2 -->|"l"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_3 -->|"s"|eNFA0_5
eNFA0_4 -->|"s"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_5 -->|"e"|eNFA0_7
eNFA0_6 -->|"e"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_9
eNFA0_7 -.->|"ε"|eNFA0_10
eNFA0_7 -.->|"ε"|eNFA0_11
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_9 -.->|"ε"|eNFA0_11
eNFA0_10 -.->|"ε"|eNFA0_11
```
-------------------------------
# 3/5: NFA
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
NFA0_8("NFA0-8 regex start")
NFA0_1("NFA0-1 char[1]")
NFA0_3("NFA0-3 char[1]")
NFA0_5("NFA0-5 char[1]")
NFA0_7[\"NFA0-7 char[1]"/]
NFA0_8 -->|"e"|NFA0_1
NFA0_1 -->|"l"|NFA0_3
NFA0_3 -->|"s"|NFA0_5
NFA0_5 -->|"e"|NFA0_7
```
-------------------------------
# 4/5: DFA
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
subgraph DFA0["DFA0 regex start"]
NFA0_8_0("NFA0-8 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA0_1_1("NFA0-1 char[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA0_3_2("NFA0-3 char[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA0_5_3("NFA0-5 char[1]")
end
subgraph DFA4["DFA4 1 NFA States"]
NFA0_7_4[\"NFA0-7 char[1]"/]
end
DFA0 -->|"e"|DFA1
DFA1 -->|"l"|DFA2
DFA2 -->|"s"|DFA3
DFA3 -->|"e"|DFA4
```
-------------------------------
# 4/5: DFA.simple
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
DFA0{{"DFA0 regex start"}}
DFA1{{"DFA1 1 NFA States"}}
DFA2{{"DFA2 1 NFA States"}}
DFA3{{"DFA3 1 NFA States"}}
DFA4[\"DFA4 1 NFA States"/]
DFA0 -->|"e"|DFA1
DFA1 -->|"l"|DFA2
DFA2 -->|"s"|DFA3
DFA3 -->|"e"|DFA4
```
-------------------------------
# 5/5: miniDFA
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
DFA0_0{{"DFA0 regex start"}}
end
subgraph miniDFA1["miniDFA1 1 DFA States"]
DFA1_1{{"DFA1 1 NFA States"}}
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
end
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA3_3{{"DFA3 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA4_4[\"DFA4 1 NFA States"/]
end
miniDFA0 -->|"e"|miniDFA1
miniDFA1 -->|"l"|miniDFA2
miniDFA2 -->|"s"|miniDFA3
miniDFA3 -->|"e"|miniDFA4
```
-------------------------------
# 5/5: miniDFA.simple
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
miniDFA1(["miniDFA1 1 DFA States"])
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA0 -->|"e"|miniDFA1
miniDFA1 -->|"l"|miniDFA2
miniDFA2 -->|"s"|miniDFA3
miniDFA3 -->|"e"|miniDFA4
```
-------------------------------
pattern: `else`

-------------------------------
# 1/5: extracted ε-NFA
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
eNFA1_8[["εNFA1-8 regex start"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA1_4[["εNFA1-4 char{1, 1}"]]
eNFA1_5[["εNFA1-5 char[1]"]]
eNFA1_6[["εNFA1-6 char{1, 1}"]]
eNFA1_7[["εNFA1-7 char[1]"]]
eNFA1_9[["εNFA1-9 regex end"]]
eNFA1_10[["εNFA1-10 post-regex start"]]
eNFA1_11[\"εNFA1-11 post-regex end"/]
eNFA1_8 -.->|"ε"|eNFA1_0
eNFA1_0 -->|"e"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_2 -->|"l"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_4 -->|"s"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_6 -->|"e"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_10 -.->|"ε"|eNFA1_11
```
-------------------------------
# 2/5: manifested ε-NFA
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
eNFA1_8[["εNFA1-8 regex start"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA1_4[["εNFA1-4 char{1, 1}"]]
eNFA1_5[["εNFA1-5 char[1]"]]
eNFA1_6[["εNFA1-6 char{1, 1}"]]
eNFA1_7[\"εNFA1-7 char[1]"/]
eNFA1_9[\"εNFA1-9 regex end"/]
eNFA1_10[\"εNFA1-10 post-regex start"/]
eNFA1_11[\"εNFA1-11 post-regex end"/]
eNFA1_8 -.->|"ε"|eNFA1_0
eNFA1_8 -->|"e"|eNFA1_1
eNFA1_0 -->|"e"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"l"|eNFA1_3
eNFA1_2 -->|"l"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -->|"s"|eNFA1_5
eNFA1_4 -->|"s"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -->|"e"|eNFA1_7
eNFA1_6 -->|"e"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA1_7 -.->|"ε"|eNFA1_10
eNFA1_7 -.->|"ε"|eNFA1_11
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_9 -.->|"ε"|eNFA1_11
eNFA1_10 -.->|"ε"|eNFA1_11
```
-------------------------------
# 3/5: NFA
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
NFA1_8("NFA1-8 regex start")
NFA1_1("NFA1-1 char[1]")
NFA1_3("NFA1-3 char[1]")
NFA1_5("NFA1-5 char[1]")
NFA1_7[\"NFA1-7 char[1]"/]
NFA1_8 -->|"e"|NFA1_1
NFA1_1 -->|"l"|NFA1_3
NFA1_3 -->|"s"|NFA1_5
NFA1_5 -->|"e"|NFA1_7
```
-------------------------------
# 4/5: DFA
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
subgraph DFA0["DFA0 regex start"]
NFA1_8_0("NFA1-8 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA1_1_1("NFA1-1 char[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA1_3_2("NFA1-3 char[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA1_5_3("NFA1-5 char[1]")
end
subgraph DFA4["DFA4 1 NFA States"]
NFA1_7_4[\"NFA1-7 char[1]"/]
end
DFA0 -->|"e"|DFA1
DFA1 -->|"l"|DFA2
DFA2 -->|"s"|DFA3
DFA3 -->|"e"|DFA4
```
-------------------------------
# 4/5: DFA.simple
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
DFA0{{"DFA0 regex start"}}
DFA1{{"DFA1 1 NFA States"}}
DFA2{{"DFA2 1 NFA States"}}
DFA3{{"DFA3 1 NFA States"}}
DFA4[\"DFA4 1 NFA States"/]
DFA0 -->|"e"|DFA1
DFA1 -->|"l"|DFA2
DFA2 -->|"s"|DFA3
DFA3 -->|"e"|DFA4
```
-------------------------------
# 5/5: miniDFA
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
DFA0_0{{"DFA0 regex start"}}
end
subgraph miniDFA1["miniDFA1 1 DFA States"]
DFA1_1{{"DFA1 1 NFA States"}}
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
end
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA3_3{{"DFA3 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA4_4[\"DFA4 1 NFA States"/]
end
miniDFA0 -->|"e"|miniDFA1
miniDFA1 -->|"l"|miniDFA2
miniDFA2 -->|"s"|miniDFA3
miniDFA3 -->|"e"|miniDFA4
```
-------------------------------
# 5/5: miniDFA.simple
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
miniDFA1(["miniDFA1 1 DFA States"])
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA0 -->|"e"|miniDFA1
miniDFA1 -->|"l"|miniDFA2
miniDFA2 -->|"s"|miniDFA3
miniDFA3 -->|"e"|miniDFA4
```
-------------------------------
