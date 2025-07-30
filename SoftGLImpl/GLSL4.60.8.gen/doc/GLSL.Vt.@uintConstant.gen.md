# Vt: 'uintConstant'

patterns[0]: `[-+]?[0-9]+[uU]`

patterns[1]: `0x[0-9A-Fa-f]+[uU]`

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
eNFA0_6[["εNFA0-6 regex start"]]
eNFA1_8[["εNFA1-8 regex start"]]
eNFA0_0[["εNFA0-0 scope{0, 1}"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA0_2[["εNFA0-2 scope{1, -1}"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 scope[1]"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA0_4[["εNFA0-4 scope{1, 1}"]]
eNFA1_4[["εNFA1-4 scope{1, -1}"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA1_5[["εNFA1-5 scope[1]"]]
eNFA0_7[["εNFA0-7 regex end"]]
eNFA1_6[["εNFA1-6 scope{1, 1}"]]
eNFA0_8[["εNFA0-8 post-regex start"]]
eNFA1_7[["εNFA1-7 scope[1]"]]
eNFA0_9[\"εNFA0-9 post-regex end"/]
eNFA1_9[["εNFA1-9 regex end"]]
eNFA0_1[\"εNFA0-1 End of this Vt"/]
eNFA1_10[["εNFA1-10 post-regex start"]]
eNFA1_11[\"εNFA1-11 post-regex end"/]
eNFA0_0 -.->|"ε"|eNFA0_6
eNFA0_0 -.->|"ε"|eNFA1_8
eNFA0_6 -.->|"ε"|eNFA0_0
eNFA1_8 -.->|"ε"|eNFA1_0
eNFA0_0 -->|"[-+]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA1_0 -->|"0"|eNFA1_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA0_2 -->|"[0-9]"|eNFA0_3
eNFA1_2 -->|"x"|eNFA1_3
eNFA0_3 -->|"[0-9]"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA0_4 -->|"[uU]"|eNFA0_5
eNFA1_4 -->|"[0-9A-Fa-f]"|eNFA1_5
eNFA0_5 -.->|"ε"|eNFA0_7
eNFA1_5 -->|"[0-9A-Fa-f]"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA1_6 -->|"[uU]"|eNFA1_7
eNFA0_8 -.->|"ε"|eNFA0_9
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA0_9 -.->|"ε"|eNFA0_1
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_10 -.->|"ε"|eNFA1_11
eNFA1_11 -.->|"ε"|eNFA0_1
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
eNFA0_6[["εNFA0-6 regex start"]]
eNFA1_8[["εNFA1-8 regex start"]]
eNFA0_0[["εNFA0-0 scope{0, 1}"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA0_2[["εNFA0-2 scope{1, -1}"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA0_3[["εNFA0-3 scope[1]"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA0_4[["εNFA0-4 scope{1, 1}"]]
eNFA0_5[\"εNFA0-5 scope[1]"/]
eNFA1_4[["εNFA1-4 scope{1, -1}"]]
eNFA1_5[["εNFA1-5 scope[1]"]]
eNFA0_7[\"εNFA0-7 regex end"/]
eNFA0_8[\"εNFA0-8 post-regex start"/]
eNFA0_9[\"εNFA0-9 post-regex end"/]
eNFA0_1[\"εNFA0-1 End of this Vt"/]
eNFA1_6[["εNFA1-6 scope{1, 1}"]]
eNFA1_7[\"εNFA1-7 scope[1]"/]
eNFA1_9[\"εNFA1-9 regex end"/]
eNFA1_10[\"εNFA1-10 post-regex start"/]
eNFA1_11[\"εNFA1-11 post-regex end"/]
eNFA0_0 -.->|"ε"|eNFA0_6
eNFA0_0 -.->|"ε"|eNFA1_8
eNFA0_0 -.->|"ε"|eNFA0_0
eNFA0_0 -.->|"ε"|eNFA1_0
eNFA0_0 -->|"[-+]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_2
eNFA0_0 -->|"0"|eNFA1_1
eNFA0_0 -->|"[0-9]"|eNFA0_3
eNFA0_6 -.->|"ε"|eNFA0_0
eNFA0_6 -->|"[-+]"|eNFA0_1
eNFA0_6 -.->|"ε"|eNFA0_1
eNFA0_6 -.->|"ε"|eNFA0_2
eNFA0_6 -->|"[0-9]"|eNFA0_3
eNFA1_8 -.->|"ε"|eNFA1_0
eNFA1_8 -->|"0"|eNFA1_1
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
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_3 -->|"[uU]"|eNFA0_5
eNFA1_2 -->|"x"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -->|"[0-9A-Fa-f]"|eNFA1_5
eNFA0_4 -->|"[uU]"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_7
eNFA0_5 -.->|"ε"|eNFA0_8
eNFA0_5 -.->|"ε"|eNFA0_9
eNFA0_5 -.->|"ε"|eNFA0_1
eNFA1_4 -->|"[0-9A-Fa-f]"|eNFA1_5
eNFA1_5 -->|"[0-9A-Fa-f]"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -->|"[uU]"|eNFA1_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_7 -.->|"ε"|eNFA0_9
eNFA0_7 -.->|"ε"|eNFA0_1
eNFA0_8 -.->|"ε"|eNFA0_9
eNFA0_8 -.->|"ε"|eNFA0_1
eNFA0_9 -.->|"ε"|eNFA0_1
eNFA1_6 -->|"[uU]"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA1_7 -.->|"ε"|eNFA1_10
eNFA1_7 -.->|"ε"|eNFA1_11
eNFA1_7 -.->|"ε"|eNFA0_1
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_9 -.->|"ε"|eNFA1_11
eNFA1_9 -.->|"ε"|eNFA0_1
eNFA1_10 -.->|"ε"|eNFA1_11
eNFA1_10 -.->|"ε"|eNFA0_1
eNFA1_11 -.->|"ε"|eNFA0_1
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
NFA0_3("NFA0-3 scope[1]")
NFA1_3("NFA1-3 char[1]")
NFA0_5[\"NFA0-5 scope[1]"/]
NFA1_5("NFA1-5 scope[1]")
NFA1_7[\"NFA1-7 scope[1]"/]
NFA0_0 -->|"[-+]"|NFA0_1
NFA0_0 -->|"0"|NFA1_1
NFA0_0 -->|"[0-9]"|NFA0_3
NFA0_1 -->|"[0-9]"|NFA0_3
NFA1_1 -->|"x"|NFA1_3
NFA0_3 -->|"[0-9]"|NFA0_3
NFA0_3 -->|"[uU]"|NFA0_5
NFA1_3 -->|"[0-9A-Fa-f]"|NFA1_5
NFA1_5 -->|"[0-9A-Fa-f]"|NFA1_5
NFA1_5 -->|"[uU]"|NFA1_7
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
NFA0_3_1("NFA0-3 scope[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA0_1_2("NFA0-1 scope[1]")
end
subgraph DFA3["DFA3 2 NFA States"]
NFA1_1_3("NFA1-1 char[1]")
NFA0_3_4("NFA0-3 scope[1]")
end
subgraph DFA4["DFA4 1 NFA States"]
NFA0_5_5[\"NFA0-5 scope[1]"/]
end
subgraph DFA5["DFA5 1 NFA States"]
NFA1_3_6("NFA1-3 char[1]")
end
subgraph DFA6["DFA6 1 NFA States"]
NFA1_5_7("NFA1-5 scope[1]")
end
subgraph DFA7["DFA7 1 NFA States"]
NFA1_7_8[\"NFA1-7 scope[1]"/]
end
DFA0 -->|"[1-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA0 -->|"0"|DFA3
DFA1 -->|"[uU]"|DFA4
DFA1 -->|"[0-9]"|DFA1
DFA2 -->|"[0-9]"|DFA1
DFA3 -->|"[uU]"|DFA4
DFA3 -->|"[0-9]"|DFA1
DFA3 -->|"x"|DFA5
DFA5 -->|"[0-9A-Fa-f]"|DFA6
DFA6 -->|"[uU]"|DFA7
DFA6 -->|"[0-9A-Fa-f]"|DFA6
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
DFA1{{"DFA1 1 NFA States"}}
DFA2{{"DFA2 1 NFA States"}}
DFA3{{"DFA3 2 NFA States"}}
DFA4[\"DFA4 1 NFA States"/]
DFA5{{"DFA5 1 NFA States"}}
DFA6{{"DFA6 1 NFA States"}}
DFA7[\"DFA7 1 NFA States"/]
DFA0 -->|"[1-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA0 -->|"0"|DFA3
DFA1 -->|"[uU]"|DFA4
DFA1 -->|"[0-9]"|DFA1
DFA2 -->|"[0-9]"|DFA1
DFA3 -->|"[uU]"|DFA4
DFA3 -->|"[0-9]"|DFA1
DFA3 -->|"x"|DFA5
DFA5 -->|"[0-9A-Fa-f]"|DFA6
DFA6 -->|"[uU]"|DFA7
DFA6 -->|"[0-9A-Fa-f]"|DFA6
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
subgraph miniDFA1["miniDFA1 1 DFA States"]
DFA1_1{{"DFA1 1 NFA States"}}
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
end
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA3_3{{"DFA3 2 NFA States"}}
end
subgraph miniDFA6["miniDFA6 1 DFA States"]
DFA4_4[\"DFA4 1 NFA States"/]
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA5_5{{"DFA5 1 NFA States"}}
end
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA6_6{{"DFA6 1 NFA States"}}
end
subgraph miniDFA7["miniDFA7 1 DFA States"]
DFA7_7[\"DFA7 1 NFA States"/]
end
miniDFA0 -->|"[1-9]"|miniDFA1
miniDFA0 -->|"[-+]"|miniDFA2
miniDFA0 -->|"0"|miniDFA3
miniDFA1 -->|"[uU]"|miniDFA6
miniDFA1 -->|"[0-9]"|miniDFA1
miniDFA2 -->|"[0-9]"|miniDFA1
miniDFA3 -->|"[uU]"|miniDFA6
miniDFA3 -->|"[0-9]"|miniDFA1
miniDFA3 -->|"x"|miniDFA4
miniDFA4 -->|"[0-9A-Fa-f]"|miniDFA5
miniDFA5 -->|"[uU]"|miniDFA7
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
miniDFA1(["miniDFA1 1 DFA States"])
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA7(["miniDFA7 1 DFA States"])
miniDFA0 -->|"[1-9]"|miniDFA1
miniDFA0 -->|"[-+]"|miniDFA2
miniDFA0 -->|"0"|miniDFA3
miniDFA1 -->|"[uU]"|miniDFA6
miniDFA1 -->|"[0-9]"|miniDFA1
miniDFA2 -->|"[0-9]"|miniDFA1
miniDFA3 -->|"[uU]"|miniDFA6
miniDFA3 -->|"[0-9]"|miniDFA1
miniDFA3 -->|"x"|miniDFA4
miniDFA4 -->|"[0-9A-Fa-f]"|miniDFA5
miniDFA5 -->|"[uU]"|miniDFA7
miniDFA5 -->|"[0-9A-Fa-f]"|miniDFA5
```
-------------------------------
pattern: `[-+]?[0-9]+[uU]`

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
eNFA1_6[["εNFA1-6 regex start"]]
eNFA1_0[["εNFA1-0 scope{0, 1}"]]
eNFA1_1[["εNFA1-1 scope[1]"]]
eNFA1_2[["εNFA1-2 scope{1, -1}"]]
eNFA1_3[["εNFA1-3 scope[1]"]]
eNFA1_4[["εNFA1-4 scope{1, 1}"]]
eNFA1_5[["εNFA1-5 scope[1]"]]
eNFA1_7[["εNFA1-7 regex end"]]
eNFA1_8[["εNFA1-8 post-regex start"]]
eNFA1_9[\"εNFA1-9 post-regex end"/]
eNFA1_6 -.->|"ε"|eNFA1_0
eNFA1_0 -->|"[-+]"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_2 -->|"[0-9]"|eNFA1_3
eNFA1_3 -->|"[0-9]"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_4 -->|"[uU]"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_8 -.->|"ε"|eNFA1_9
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
eNFA1_6[["εNFA1-6 regex start"]]
eNFA1_0[["εNFA1-0 scope{0, 1}"]]
eNFA1_1[["εNFA1-1 scope[1]"]]
eNFA1_2[["εNFA1-2 scope{1, -1}"]]
eNFA1_3[["εNFA1-3 scope[1]"]]
eNFA1_4[["εNFA1-4 scope{1, 1}"]]
eNFA1_5[\"εNFA1-5 scope[1]"/]
eNFA1_7[\"εNFA1-7 regex end"/]
eNFA1_8[\"εNFA1-8 post-regex start"/]
eNFA1_9[\"εNFA1-9 post-regex end"/]
eNFA1_6 -.->|"ε"|eNFA1_0
eNFA1_6 -->|"[-+]"|eNFA1_1
eNFA1_6 -.->|"ε"|eNFA1_1
eNFA1_6 -.->|"ε"|eNFA1_2
eNFA1_6 -->|"[0-9]"|eNFA1_3
eNFA1_0 -->|"[-+]"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_2
eNFA1_0 -->|"[0-9]"|eNFA1_3
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"[0-9]"|eNFA1_3
eNFA1_2 -->|"[0-9]"|eNFA1_3
eNFA1_3 -->|"[0-9]"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -->|"[uU]"|eNFA1_5
eNFA1_4 -->|"[uU]"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_7
eNFA1_5 -.->|"ε"|eNFA1_8
eNFA1_5 -.->|"ε"|eNFA1_9
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA1_8 -.->|"ε"|eNFA1_9
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
NFA1_6("NFA1-6 regex start")
NFA1_1("NFA1-1 scope[1]")
NFA1_3("NFA1-3 scope[1]")
NFA1_5[\"NFA1-5 scope[1]"/]
NFA1_6 -->|"[-+]"|NFA1_1
NFA1_6 -->|"[0-9]"|NFA1_3
NFA1_1 -->|"[0-9]"|NFA1_3
NFA1_3 -->|"[0-9]"|NFA1_3
NFA1_3 -->|"[uU]"|NFA1_5
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
NFA1_6_0("NFA1-6 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA1_3_1("NFA1-3 scope[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA1_1_2("NFA1-1 scope[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA1_5_3[\"NFA1-5 scope[1]"/]
end
DFA0 -->|"[0-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA1 -->|"[uU]"|DFA3
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
DFA1{{"DFA1 1 NFA States"}}
DFA2{{"DFA2 1 NFA States"}}
DFA3[\"DFA3 1 NFA States"/]
DFA0 -->|"[0-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA1 -->|"[uU]"|DFA3
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
subgraph miniDFA1["miniDFA1 1 DFA States"]
DFA1_1{{"DFA1 1 NFA States"}}
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
end
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA3_3[\"DFA3 1 NFA States"/]
end
miniDFA0 -->|"[0-9]"|miniDFA1
miniDFA0 -->|"[-+]"|miniDFA2
miniDFA1 -->|"[uU]"|miniDFA3
miniDFA1 -->|"[0-9]"|miniDFA1
miniDFA2 -->|"[0-9]"|miniDFA1
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
miniDFA0 -->|"[0-9]"|miniDFA1
miniDFA0 -->|"[-+]"|miniDFA2
miniDFA1 -->|"[uU]"|miniDFA3
miniDFA1 -->|"[0-9]"|miniDFA1
miniDFA2 -->|"[0-9]"|miniDFA1
```
-------------------------------
pattern: `0x[0-9A-Fa-f]+[uU]`

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
eNFA2_8[["εNFA2-8 regex start"]]
eNFA2_0[["εNFA2-0 char{1, 1}"]]
eNFA2_1[["εNFA2-1 char[1]"]]
eNFA2_2[["εNFA2-2 char{1, 1}"]]
eNFA2_3[["εNFA2-3 char[1]"]]
eNFA2_4[["εNFA2-4 scope{1, -1}"]]
eNFA2_5[["εNFA2-5 scope[1]"]]
eNFA2_6[["εNFA2-6 scope{1, 1}"]]
eNFA2_7[["εNFA2-7 scope[1]"]]
eNFA2_9[["εNFA2-9 regex end"]]
eNFA2_10[["εNFA2-10 post-regex start"]]
eNFA2_11[\"εNFA2-11 post-regex end"/]
eNFA2_8 -.->|"ε"|eNFA2_0
eNFA2_0 -->|"0"|eNFA2_1
eNFA2_1 -.->|"ε"|eNFA2_2
eNFA2_2 -->|"x"|eNFA2_3
eNFA2_3 -.->|"ε"|eNFA2_4
eNFA2_4 -->|"[0-9A-Fa-f]"|eNFA2_5
eNFA2_5 -->|"[0-9A-Fa-f]"|eNFA2_5
eNFA2_5 -.->|"ε"|eNFA2_6
eNFA2_6 -->|"[uU]"|eNFA2_7
eNFA2_7 -.->|"ε"|eNFA2_9
eNFA2_9 -.->|"ε"|eNFA2_10
eNFA2_10 -.->|"ε"|eNFA2_11
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
eNFA2_8[["εNFA2-8 regex start"]]
eNFA2_0[["εNFA2-0 char{1, 1}"]]
eNFA2_1[["εNFA2-1 char[1]"]]
eNFA2_2[["εNFA2-2 char{1, 1}"]]
eNFA2_3[["εNFA2-3 char[1]"]]
eNFA2_4[["εNFA2-4 scope{1, -1}"]]
eNFA2_5[["εNFA2-5 scope[1]"]]
eNFA2_6[["εNFA2-6 scope{1, 1}"]]
eNFA2_7[\"εNFA2-7 scope[1]"/]
eNFA2_9[\"εNFA2-9 regex end"/]
eNFA2_10[\"εNFA2-10 post-regex start"/]
eNFA2_11[\"εNFA2-11 post-regex end"/]
eNFA2_8 -.->|"ε"|eNFA2_0
eNFA2_8 -->|"0"|eNFA2_1
eNFA2_0 -->|"0"|eNFA2_1
eNFA2_1 -.->|"ε"|eNFA2_2
eNFA2_1 -->|"x"|eNFA2_3
eNFA2_2 -->|"x"|eNFA2_3
eNFA2_3 -.->|"ε"|eNFA2_4
eNFA2_3 -->|"[0-9A-Fa-f]"|eNFA2_5
eNFA2_4 -->|"[0-9A-Fa-f]"|eNFA2_5
eNFA2_5 -->|"[0-9A-Fa-f]"|eNFA2_5
eNFA2_5 -.->|"ε"|eNFA2_6
eNFA2_5 -->|"[uU]"|eNFA2_7
eNFA2_6 -->|"[uU]"|eNFA2_7
eNFA2_7 -.->|"ε"|eNFA2_9
eNFA2_7 -.->|"ε"|eNFA2_10
eNFA2_7 -.->|"ε"|eNFA2_11
eNFA2_9 -.->|"ε"|eNFA2_10
eNFA2_9 -.->|"ε"|eNFA2_11
eNFA2_10 -.->|"ε"|eNFA2_11
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
NFA2_8("NFA2-8 regex start")
NFA2_1("NFA2-1 char[1]")
NFA2_3("NFA2-3 char[1]")
NFA2_5("NFA2-5 scope[1]")
NFA2_7[\"NFA2-7 scope[1]"/]
NFA2_8 -->|"0"|NFA2_1
NFA2_1 -->|"x"|NFA2_3
NFA2_3 -->|"[0-9A-Fa-f]"|NFA2_5
NFA2_5 -->|"[0-9A-Fa-f]"|NFA2_5
NFA2_5 -->|"[uU]"|NFA2_7
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
NFA2_8_0("NFA2-8 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA2_1_1("NFA2-1 char[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA2_3_2("NFA2-3 char[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA2_5_3("NFA2-5 scope[1]")
end
subgraph DFA4["DFA4 1 NFA States"]
NFA2_7_4[\"NFA2-7 scope[1]"/]
end
DFA0 -->|"0"|DFA1
DFA1 -->|"x"|DFA2
DFA2 -->|"[0-9A-Fa-f]"|DFA3
DFA3 -->|"[uU]"|DFA4
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
DFA3{{"DFA3 1 NFA States"}}
DFA4[\"DFA4 1 NFA States"/]
DFA0 -->|"0"|DFA1
DFA1 -->|"x"|DFA2
DFA2 -->|"[0-9A-Fa-f]"|DFA3
DFA3 -->|"[uU]"|DFA4
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
DFA3_3{{"DFA3 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA4_4[\"DFA4 1 NFA States"/]
end
miniDFA0 -->|"0"|miniDFA1
miniDFA1 -->|"x"|miniDFA2
miniDFA2 -->|"[0-9A-Fa-f]"|miniDFA3
miniDFA3 -->|"[uU]"|miniDFA4
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
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA0 -->|"0"|miniDFA1
miniDFA1 -->|"x"|miniDFA2
miniDFA2 -->|"[0-9A-Fa-f]"|miniDFA3
miniDFA3 -->|"[uU]"|miniDFA4
miniDFA3 -->|"[0-9A-Fa-f]"|miniDFA3
```
-------------------------------
