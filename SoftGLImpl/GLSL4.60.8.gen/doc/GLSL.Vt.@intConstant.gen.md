# Vt: 'intConstant'

patterns[0]: `[-+]?[0-9]+`

patterns[1]: `0x[0-9A-Fa-f]+`

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
eNFA0_0[["εNFA0-0 Start of this Vt"]]
eNFA0_4[["εNFA0-4 regex start"]]
eNFA1_6[["εNFA1-6 regex start"]]
eNFA0_0[["εNFA0-0 scope{0, 1}"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA0_2[["εNFA0-2 scope{1, -1}"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 scope[1]"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA0_5[["εNFA0-5 regex end"]]
eNFA1_4[["εNFA1-4 scope{1, -1}"]]
eNFA0_6[["εNFA0-6 post-regex start"]]
eNFA1_5[["εNFA1-5 scope[1]"]]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA1_7[["εNFA1-7 regex end"]]
eNFA0_1[\"εNFA0-1 End of this Vt"/]
eNFA1_8[["εNFA1-8 post-regex start"]]
eNFA1_9[\"εNFA1-9 post-regex end"/]
eNFA0_0 -.->|"ε"|eNFA0_4
eNFA0_0 -.->|"ε"|eNFA1_6
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA1_6 -.->|"ε"|eNFA1_0
eNFA0_0 -->|"[-+]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA1_0 -->|"0"|eNFA1_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA0_2 -->|"[0-9]"|eNFA0_3
eNFA1_2 -->|"x"|eNFA1_3
eNFA0_3 -->|"[0-9]"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA1_4 -->|"[0-9A-Fa-f]"|eNFA1_5
eNFA0_6 -.->|"ε"|eNFA0_7
eNFA1_5 -->|"[0-9A-Fa-f]"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_7
eNFA0_7 -.->|"ε"|eNFA0_1
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_8 -.->|"ε"|eNFA1_9
eNFA1_9 -.->|"ε"|eNFA0_1
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
eNFA0_0[["εNFA0-0 Start of this Vt"]]
eNFA0_4[["εNFA0-4 regex start"]]
eNFA1_6[["εNFA1-6 regex start"]]
eNFA0_0[["εNFA0-0 scope{0, 1}"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA0_2[["εNFA0-2 scope{1, -1}"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA0_3[\"εNFA0-3 scope[1]"/]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA0_5[\"εNFA0-5 regex end"/]
eNFA0_6[\"εNFA0-6 post-regex start"/]
eNFA0_7[\"εNFA0-7 post-regex end"/]
eNFA0_1[\"εNFA0-1 End of this Vt"/]
eNFA1_4[["εNFA1-4 scope{1, -1}"]]
eNFA1_5[\"εNFA1-5 scope[1]"/]
eNFA1_7[\"εNFA1-7 regex end"/]
eNFA1_8[\"εNFA1-8 post-regex start"/]
eNFA1_9[\"εNFA1-9 post-regex end"/]
eNFA0_0 -.->|"ε"|eNFA0_4
eNFA0_0 -.->|"ε"|eNFA1_6
eNFA0_0 -.->|"ε"|eNFA0_0
eNFA0_0 -.->|"ε"|eNFA1_0
eNFA0_0 -->|"[-+]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_2
eNFA0_0 -->|"0"|eNFA1_1
eNFA0_0 -->|"[0-9]"|eNFA0_3
eNFA0_4 -.->|"ε"|eNFA0_0
eNFA0_4 -->|"[-+]"|eNFA0_1
eNFA0_4 -.->|"ε"|eNFA0_1
eNFA0_4 -.->|"ε"|eNFA0_2
eNFA0_4 -->|"[0-9]"|eNFA0_3
eNFA1_6 -.->|"ε"|eNFA1_0
eNFA1_6 -->|"0"|eNFA1_1
eNFA0_0 -->|"[-+]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_2
eNFA0_0 -->|"[0-9]"|eNFA0_3
eNFA1_0 -->|"0"|eNFA1_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_1 -->|"[0-9]"|eNFA0_3
eNFA0_2 -->|"[0-9]"|eNFA0_3
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"x"|eNFA1_3
eNFA0_3 -->|"[0-9]"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_5
eNFA0_3 -.->|"ε"|eNFA0_6
eNFA0_3 -.->|"ε"|eNFA0_7
eNFA0_3 -.->|"ε"|eNFA0_1
eNFA1_2 -->|"x"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -->|"[0-9A-Fa-f]"|eNFA1_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_5 -.->|"ε"|eNFA0_7
eNFA0_5 -.->|"ε"|eNFA0_1
eNFA0_6 -.->|"ε"|eNFA0_7
eNFA0_6 -.->|"ε"|eNFA0_1
eNFA0_7 -.->|"ε"|eNFA0_1
eNFA1_4 -->|"[0-9A-Fa-f]"|eNFA1_5
eNFA1_5 -->|"[0-9A-Fa-f]"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_7
eNFA1_5 -.->|"ε"|eNFA1_8
eNFA1_5 -.->|"ε"|eNFA1_9
eNFA1_5 -.->|"ε"|eNFA0_1
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA1_7 -.->|"ε"|eNFA0_1
eNFA1_8 -.->|"ε"|eNFA1_9
eNFA1_8 -.->|"ε"|eNFA0_1
eNFA1_9 -.->|"ε"|eNFA0_1
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
NFA0_0("NFA0-0 Start of this Vt")
NFA0_1("NFA0-1 scope[1]")
NFA1_1("NFA1-1 char[1]")
NFA0_3[\"NFA0-3 scope[1]"/]
NFA1_3("NFA1-3 char[1]")
NFA1_5[\"NFA1-5 scope[1]"/]
NFA0_0 -->|"[-+]"|NFA0_1
NFA0_0 -->|"0"|NFA1_1
NFA0_0 -->|"[0-9]"|NFA0_3
NFA0_1 -->|"[0-9]"|NFA0_3
NFA1_1 -->|"x"|NFA1_3
NFA0_3 -->|"[0-9]"|NFA0_3
NFA1_3 -->|"[0-9A-Fa-f]"|NFA1_5
NFA1_5 -->|"[0-9A-Fa-f]"|NFA1_5
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
subgraph DFA0["DFA0 Start of this Vt"]
NFA0_0_0("NFA0-0 Start of this Vt")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA0_3_1[\"NFA0-3 scope[1]"/]
end
subgraph DFA2["DFA2 1 NFA States"]
NFA0_1_2("NFA0-1 scope[1]")
end
subgraph DFA3["DFA3 2 NFA States"]
NFA1_1_3("NFA1-1 char[1]")
NFA0_3_4[\"NFA0-3 scope[1]"/]
end
subgraph DFA4["DFA4 1 NFA States"]
NFA1_3_5("NFA1-3 char[1]")
end
subgraph DFA5["DFA5 1 NFA States"]
NFA1_5_6[\"NFA1-5 scope[1]"/]
end
DFA0 -->|"[1-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA0 -->|"0"|DFA3
DFA1 -->|"[0-9]"|DFA1
DFA2 -->|"[0-9]"|DFA1
DFA3 -->|"[0-9]"|DFA1
DFA3 -->|"x"|DFA4
DFA4 -->|"[0-9A-Fa-f]"|DFA5
DFA5 -->|"[0-9A-Fa-f]"|DFA5
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
DFA0{{"DFA0 Start of this Vt"}}
DFA1[\"DFA1 1 NFA States"/]
DFA2{{"DFA2 1 NFA States"}}
DFA3[\"DFA3 2 NFA States"/]
DFA4{{"DFA4 1 NFA States"}}
DFA5[\"DFA5 1 NFA States"/]
DFA0 -->|"[1-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA0 -->|"0"|DFA3
DFA1 -->|"[0-9]"|DFA1
DFA2 -->|"[0-9]"|DFA1
DFA3 -->|"[0-9]"|DFA1
DFA3 -->|"x"|DFA4
DFA4 -->|"[0-9A-Fa-f]"|DFA5
DFA5 -->|"[0-9A-Fa-f]"|DFA5
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
DFA0_0{{"DFA0 Start of this Vt"}}
end
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA1_1[\"DFA1 1 NFA States"/]
end
subgraph miniDFA1["miniDFA1 1 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA3_3[\"DFA3 2 NFA States"/]
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA4_4{{"DFA4 1 NFA States"}}
end
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA5_5[\"DFA5 1 NFA States"/]
end
miniDFA0 -->|"[1-9]"|miniDFA3
miniDFA0 -->|"[-+]"|miniDFA1
miniDFA0 -->|"0"|miniDFA4
miniDFA3 -->|"[0-9]"|miniDFA3
miniDFA1 -->|"[0-9]"|miniDFA3
miniDFA4 -->|"[0-9]"|miniDFA3
miniDFA4 -->|"x"|miniDFA2
miniDFA2 -->|"[0-9A-Fa-f]"|miniDFA5
miniDFA5 -->|"[0-9A-Fa-f]"|miniDFA5
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
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA1(["miniDFA1 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA0 -->|"[1-9]"|miniDFA3
miniDFA0 -->|"[-+]"|miniDFA1
miniDFA0 -->|"0"|miniDFA4
miniDFA3 -->|"[0-9]"|miniDFA3
miniDFA1 -->|"[0-9]"|miniDFA3
miniDFA4 -->|"[0-9]"|miniDFA3
miniDFA4 -->|"x"|miniDFA2
miniDFA2 -->|"[0-9A-Fa-f]"|miniDFA5
miniDFA5 -->|"[0-9A-Fa-f]"|miniDFA5
```
-------------------------------
pattern: `[-+]?[0-9]+`

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
eNFA1_4[["εNFA1-4 regex start"]]
eNFA1_0[["εNFA1-0 scope{0, 1}"]]
eNFA1_1[["εNFA1-1 scope[1]"]]
eNFA1_2[["εNFA1-2 scope{1, -1}"]]
eNFA1_3[["εNFA1-3 scope[1]"]]
eNFA1_5[["εNFA1-5 regex end"]]
eNFA1_6[["εNFA1-6 post-regex start"]]
eNFA1_7[\"εNFA1-7 post-regex end"/]
eNFA1_4 -.->|"ε"|eNFA1_0
eNFA1_0 -->|"[-+]"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_2 -->|"[0-9]"|eNFA1_3
eNFA1_3 -->|"[0-9]"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_6 -.->|"ε"|eNFA1_7
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
eNFA1_4[["εNFA1-4 regex start"]]
eNFA1_0[["εNFA1-0 scope{0, 1}"]]
eNFA1_1[["εNFA1-1 scope[1]"]]
eNFA1_2[["εNFA1-2 scope{1, -1}"]]
eNFA1_3[\"εNFA1-3 scope[1]"/]
eNFA1_5[\"εNFA1-5 regex end"/]
eNFA1_6[\"εNFA1-6 post-regex start"/]
eNFA1_7[\"εNFA1-7 post-regex end"/]
eNFA1_4 -.->|"ε"|eNFA1_0
eNFA1_4 -->|"[-+]"|eNFA1_1
eNFA1_4 -.->|"ε"|eNFA1_1
eNFA1_4 -.->|"ε"|eNFA1_2
eNFA1_4 -->|"[0-9]"|eNFA1_3
eNFA1_0 -->|"[-+]"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_2
eNFA1_0 -->|"[0-9]"|eNFA1_3
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"[0-9]"|eNFA1_3
eNFA1_2 -->|"[0-9]"|eNFA1_3
eNFA1_3 -->|"[0-9]"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_5
eNFA1_3 -.->|"ε"|eNFA1_6
eNFA1_3 -.->|"ε"|eNFA1_7
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -.->|"ε"|eNFA1_7
eNFA1_6 -.->|"ε"|eNFA1_7
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
NFA1_4("NFA1-4 regex start")
NFA1_1("NFA1-1 scope[1]")
NFA1_3[\"NFA1-3 scope[1]"/]
NFA1_4 -->|"[-+]"|NFA1_1
NFA1_4 -->|"[0-9]"|NFA1_3
NFA1_1 -->|"[0-9]"|NFA1_3
NFA1_3 -->|"[0-9]"|NFA1_3
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
NFA1_4_0("NFA1-4 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA1_3_1[\"NFA1-3 scope[1]"/]
end
subgraph DFA2["DFA2 1 NFA States"]
NFA1_1_2("NFA1-1 scope[1]")
end
DFA0 -->|"[0-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA1 -->|"[0-9]"|DFA1
DFA2 -->|"[0-9]"|DFA1
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
DFA1[\"DFA1 1 NFA States"/]
DFA2{{"DFA2 1 NFA States"}}
DFA0 -->|"[0-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA1 -->|"[0-9]"|DFA1
DFA2 -->|"[0-9]"|DFA1
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
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA1_1[\"DFA1 1 NFA States"/]
end
subgraph miniDFA1["miniDFA1 1 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
end
miniDFA0 -->|"[0-9]"|miniDFA2
miniDFA0 -->|"[-+]"|miniDFA1
miniDFA2 -->|"[0-9]"|miniDFA2
miniDFA1 -->|"[0-9]"|miniDFA2
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
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA1(["miniDFA1 1 DFA States"])
miniDFA0 -->|"[0-9]"|miniDFA2
miniDFA0 -->|"[-+]"|miniDFA1
miniDFA2 -->|"[0-9]"|miniDFA2
miniDFA1 -->|"[0-9]"|miniDFA2
```
-------------------------------
pattern: `0x[0-9A-Fa-f]+`

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
eNFA2_6[["εNFA2-6 regex start"]]
eNFA2_0[["εNFA2-0 char{1, 1}"]]
eNFA2_1[["εNFA2-1 char[1]"]]
eNFA2_2[["εNFA2-2 char{1, 1}"]]
eNFA2_3[["εNFA2-3 char[1]"]]
eNFA2_4[["εNFA2-4 scope{1, -1}"]]
eNFA2_5[["εNFA2-5 scope[1]"]]
eNFA2_7[["εNFA2-7 regex end"]]
eNFA2_8[["εNFA2-8 post-regex start"]]
eNFA2_9[\"εNFA2-9 post-regex end"/]
eNFA2_6 -.->|"ε"|eNFA2_0
eNFA2_0 -->|"0"|eNFA2_1
eNFA2_1 -.->|"ε"|eNFA2_2
eNFA2_2 -->|"x"|eNFA2_3
eNFA2_3 -.->|"ε"|eNFA2_4
eNFA2_4 -->|"[0-9A-Fa-f]"|eNFA2_5
eNFA2_5 -->|"[0-9A-Fa-f]"|eNFA2_5
eNFA2_5 -.->|"ε"|eNFA2_7
eNFA2_7 -.->|"ε"|eNFA2_8
eNFA2_8 -.->|"ε"|eNFA2_9
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
eNFA2_6[["εNFA2-6 regex start"]]
eNFA2_0[["εNFA2-0 char{1, 1}"]]
eNFA2_1[["εNFA2-1 char[1]"]]
eNFA2_2[["εNFA2-2 char{1, 1}"]]
eNFA2_3[["εNFA2-3 char[1]"]]
eNFA2_4[["εNFA2-4 scope{1, -1}"]]
eNFA2_5[\"εNFA2-5 scope[1]"/]
eNFA2_7[\"εNFA2-7 regex end"/]
eNFA2_8[\"εNFA2-8 post-regex start"/]
eNFA2_9[\"εNFA2-9 post-regex end"/]
eNFA2_6 -.->|"ε"|eNFA2_0
eNFA2_6 -->|"0"|eNFA2_1
eNFA2_0 -->|"0"|eNFA2_1
eNFA2_1 -.->|"ε"|eNFA2_2
eNFA2_1 -->|"x"|eNFA2_3
eNFA2_2 -->|"x"|eNFA2_3
eNFA2_3 -.->|"ε"|eNFA2_4
eNFA2_3 -->|"[0-9A-Fa-f]"|eNFA2_5
eNFA2_4 -->|"[0-9A-Fa-f]"|eNFA2_5
eNFA2_5 -->|"[0-9A-Fa-f]"|eNFA2_5
eNFA2_5 -.->|"ε"|eNFA2_7
eNFA2_5 -.->|"ε"|eNFA2_8
eNFA2_5 -.->|"ε"|eNFA2_9
eNFA2_7 -.->|"ε"|eNFA2_8
eNFA2_7 -.->|"ε"|eNFA2_9
eNFA2_8 -.->|"ε"|eNFA2_9
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
NFA2_6("NFA2-6 regex start")
NFA2_1("NFA2-1 char[1]")
NFA2_3("NFA2-3 char[1]")
NFA2_5[\"NFA2-5 scope[1]"/]
NFA2_6 -->|"0"|NFA2_1
NFA2_1 -->|"x"|NFA2_3
NFA2_3 -->|"[0-9A-Fa-f]"|NFA2_5
NFA2_5 -->|"[0-9A-Fa-f]"|NFA2_5
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
NFA2_6_0("NFA2-6 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA2_1_1("NFA2-1 char[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA2_3_2("NFA2-3 char[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA2_5_3[\"NFA2-5 scope[1]"/]
end
DFA0 -->|"0"|DFA1
DFA1 -->|"x"|DFA2
DFA2 -->|"[0-9A-Fa-f]"|DFA3
DFA3 -->|"[0-9A-Fa-f]"|DFA3
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
DFA3[\"DFA3 1 NFA States"/]
DFA0 -->|"0"|DFA1
DFA1 -->|"x"|DFA2
DFA2 -->|"[0-9A-Fa-f]"|DFA3
DFA3 -->|"[0-9A-Fa-f]"|DFA3
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
DFA3_3[\"DFA3 1 NFA States"/]
end
miniDFA0 -->|"0"|miniDFA1
miniDFA1 -->|"x"|miniDFA2
miniDFA2 -->|"[0-9A-Fa-f]"|miniDFA3
miniDFA3 -->|"[0-9A-Fa-f]"|miniDFA3
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
miniDFA0 -->|"0"|miniDFA1
miniDFA1 -->|"x"|miniDFA2
miniDFA2 -->|"[0-9A-Fa-f]"|miniDFA3
miniDFA3 -->|"[0-9A-Fa-f]"|miniDFA3
```
-------------------------------
