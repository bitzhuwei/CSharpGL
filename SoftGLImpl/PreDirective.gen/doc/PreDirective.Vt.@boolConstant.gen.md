# Vt: 'boolConstant'

patterns[0]: `true/[^a-zA-Z0-9_]`

patterns[1]: `false/[^a-zA-Z0-9_]`

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
eNFA0_8[["εNFA0-8 regex start"]]
eNFA1_10[["εNFA1-10 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA1_4[["εNFA1-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA1_5[["εNFA1-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA1_6[["εNFA1-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA1_7[["εNFA1-7 char[1]"]]
eNFA0_9[["εNFA0-9 regex end"]]
eNFA1_8[["εNFA1-8 char{1, 1}"]]
eNFA0_12[["εNFA0-12 regex start"]]
eNFA1_9[["εNFA1-9 char[1]"]]
eNFA0_10[["εNFA0-10 scope{1, 1}"]]
eNFA1_11[["εNFA1-11 regex end"]]
eNFA0_11[["εNFA0-11 scope[1]"]]
eNFA1_14[["εNFA1-14 regex start"]]
eNFA0_13[\"εNFA0-13 regex end"/]
eNFA1_12[["εNFA1-12 scope{1, 1}"]]
eNFA0_1[\"εNFA0-1 End of this Vt"/]
eNFA1_13[["εNFA1-13 scope[1]"]]
eNFA1_15[\"εNFA1-15 regex end"/]
eNFA0_0 -.->|"ε"|eNFA0_8
eNFA0_0 -.->|"ε"|eNFA1_10
eNFA0_8 -.->|"ε"|eNFA0_0
eNFA1_10 -.->|"ε"|eNFA1_0
eNFA0_0 -->|"t"|eNFA0_1
eNFA1_0 -->|"f"|eNFA1_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA0_2 -->|"r"|eNFA0_3
eNFA1_2 -->|"a"|eNFA1_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA0_4 -->|"u"|eNFA0_5
eNFA1_4 -->|"l"|eNFA1_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA0_6 -->|"e"|eNFA0_7
eNFA1_6 -->|"s"|eNFA1_7
eNFA0_7 -.->|"ε"|eNFA0_9
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA0_9 -.->|"ε"|eNFA0_12
eNFA1_8 -->|"e"|eNFA1_9
eNFA0_12 -.->|"ε"|eNFA0_10
eNFA1_9 -.->|"ε"|eNFA1_11
eNFA0_10 -->|"[^a-zA-Z0-9_]"|eNFA0_11
eNFA1_11 -.->|"ε"|eNFA1_14
eNFA0_11 -.->|"ε"|eNFA0_13
eNFA1_14 -.->|"ε"|eNFA1_12
eNFA0_13 -.->|"ε"|eNFA0_1
eNFA1_12 -->|"[^a-zA-Z0-9_]"|eNFA1_13
eNFA1_13 -.->|"ε"|eNFA1_15
eNFA1_15 -.->|"ε"|eNFA0_1
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
eNFA0_8[["εNFA0-8 regex start"]]
eNFA1_10[["εNFA1-10 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA0_4[["εNFA0-4 char{1, 1}"]]
eNFA0_5[["εNFA0-5 char[1]"]]
eNFA1_4[["εNFA1-4 char{1, 1}"]]
eNFA1_5[["εNFA1-5 char[1]"]]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA1_6[["εNFA1-6 char{1, 1}"]]
eNFA1_7[["εNFA1-7 char[1]"]]
eNFA0_9[["εNFA0-9 regex end"]]
eNFA0_12[["εNFA0-12 regex start"]]
eNFA0_10[["εNFA0-10 scope{1, 1}"]]
eNFA0_11[\"εNFA0-11 scope[1]"/]
eNFA1_8[["εNFA1-8 char{1, 1}"]]
eNFA1_9[["εNFA1-9 char[1]"]]
eNFA0_13[\"εNFA0-13 regex end"/]
eNFA0_1[\"εNFA0-1 End of this Vt"/]
eNFA1_11[["εNFA1-11 regex end"]]
eNFA1_14[["εNFA1-14 regex start"]]
eNFA1_12[["εNFA1-12 scope{1, 1}"]]
eNFA1_13[\"εNFA1-13 scope[1]"/]
eNFA1_15[\"εNFA1-15 regex end"/]
eNFA0_0 -.->|"ε"|eNFA0_8
eNFA0_0 -.->|"ε"|eNFA1_10
eNFA0_0 -.->|"ε"|eNFA0_0
eNFA0_0 -.->|"ε"|eNFA1_0
eNFA0_0 -->|"t"|eNFA0_1
eNFA0_0 -->|"f"|eNFA1_1
eNFA0_8 -.->|"ε"|eNFA0_0
eNFA0_8 -->|"t"|eNFA0_1
eNFA1_10 -.->|"ε"|eNFA1_0
eNFA1_10 -->|"f"|eNFA1_1
eNFA0_0 -->|"t"|eNFA0_1
eNFA1_0 -->|"f"|eNFA1_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_1 -->|"r"|eNFA0_3
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"a"|eNFA1_3
eNFA0_2 -->|"r"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_3 -->|"u"|eNFA0_5
eNFA1_2 -->|"a"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -->|"l"|eNFA1_5
eNFA0_4 -->|"u"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_5 -->|"e"|eNFA0_7
eNFA1_4 -->|"l"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -->|"s"|eNFA1_7
eNFA0_6 -->|"e"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_9
eNFA0_7 -.->|"ε"|eNFA0_12
eNFA0_7 -.->|"ε"|eNFA0_10
eNFA0_7 -->|"[^a-zA-Z0-9_]"|eNFA0_11
eNFA1_6 -->|"s"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_7 -->|"e"|eNFA1_9
eNFA0_9 -.->|"ε"|eNFA0_12
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_9 -->|"[^a-zA-Z0-9_]"|eNFA0_11
eNFA0_12 -.->|"ε"|eNFA0_10
eNFA0_12 -->|"[^a-zA-Z0-9_]"|eNFA0_11
eNFA0_10 -->|"[^a-zA-Z0-9_]"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_13
eNFA0_11 -.->|"ε"|eNFA0_1
eNFA1_8 -->|"e"|eNFA1_9
eNFA1_9 -.->|"ε"|eNFA1_11
eNFA1_9 -.->|"ε"|eNFA1_14
eNFA1_9 -.->|"ε"|eNFA1_12
eNFA1_9 -->|"[^a-zA-Z0-9_]"|eNFA1_13
eNFA0_13 -.->|"ε"|eNFA0_1
eNFA1_11 -.->|"ε"|eNFA1_14
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_11 -->|"[^a-zA-Z0-9_]"|eNFA1_13
eNFA1_14 -.->|"ε"|eNFA1_12
eNFA1_14 -->|"[^a-zA-Z0-9_]"|eNFA1_13
eNFA1_12 -->|"[^a-zA-Z0-9_]"|eNFA1_13
eNFA1_13 -.->|"ε"|eNFA1_15
eNFA1_13 -.->|"ε"|eNFA0_1
eNFA1_15 -.->|"ε"|eNFA0_1
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
NFA0_1("NFA0-1 char[1]")
NFA1_1("NFA1-1 char[1]")
NFA0_3("NFA0-3 char[1]")
NFA1_3("NFA1-3 char[1]")
NFA0_5("NFA0-5 char[1]")
NFA1_5("NFA1-5 char[1]")
NFA0_7("NFA0-7 char[1]")
NFA1_7("NFA1-7 char[1]")
NFA0_11[\"NFA0-11 scope[1]"/]
NFA1_9("NFA1-9 char[1]")
NFA1_13[\"NFA1-13 scope[1]"/]
NFA0_0 -->|"t"|NFA0_1
NFA0_0 -->|"f"|NFA1_1
NFA0_1 -->|"r"|NFA0_3
NFA1_1 -->|"a"|NFA1_3
NFA0_3 -->|"u"|NFA0_5
NFA1_3 -->|"l"|NFA1_5
NFA0_5 -->|"e"|NFA0_7
NFA1_5 -->|"s"|NFA1_7
NFA0_7 -->|"[^a-zA-Z0-9_]"|NFA0_11
NFA1_7 -->|"e"|NFA1_9
NFA1_9 -->|"[^a-zA-Z0-9_]"|NFA1_13
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
NFA1_1_1("NFA1-1 char[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA0_1_2("NFA0-1 char[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA1_3_3("NFA1-3 char[1]")
end
subgraph DFA4["DFA4 1 NFA States"]
NFA0_3_4("NFA0-3 char[1]")
end
subgraph DFA5["DFA5 1 NFA States"]
NFA1_5_5("NFA1-5 char[1]")
end
subgraph DFA6["DFA6 1 NFA States"]
NFA0_5_6("NFA0-5 char[1]")
end
subgraph DFA7["DFA7 1 NFA States"]
NFA1_7_7("NFA1-7 char[1]")
end
subgraph DFA8["DFA8 1 NFA States"]
NFA0_7_8("NFA0-7 char[1]")
end
subgraph DFA9["DFA9 1 NFA States"]
NFA1_9_9("NFA1-9 char[1]")
end
subgraph DFA10["DFA10 1 NFA States"]
NFA0_11_10[\"NFA0-11 scope[1]"/]
end
subgraph DFA11["DFA11 1 NFA States"]
NFA1_13_11[\"NFA1-13 scope[1]"/]
end
DFA0 -->|"f"|DFA1
DFA0 -->|"t"|DFA2
DFA1 -->|"a"|DFA3
DFA2 -->|"r"|DFA4
DFA3 -->|"l"|DFA5
DFA4 -->|"u"|DFA6
DFA5 -->|"s"|DFA7
DFA6 -->|"e"|DFA8
DFA7 -->|"e"|DFA9
DFA8 -->|"[^a-zA-Z0-9_]"|DFA10
DFA9 -->|"[^a-zA-Z0-9_]"|DFA11
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
DFA3{{"DFA3 1 NFA States"}}
DFA4{{"DFA4 1 NFA States"}}
DFA5{{"DFA5 1 NFA States"}}
DFA6{{"DFA6 1 NFA States"}}
DFA7{{"DFA7 1 NFA States"}}
DFA8{{"DFA8 1 NFA States"}}
DFA9{{"DFA9 1 NFA States"}}
DFA10[\"DFA10 1 NFA States"/]
DFA11[\"DFA11 1 NFA States"/]
DFA0 -->|"f"|DFA1
DFA0 -->|"t"|DFA2
DFA1 -->|"a"|DFA3
DFA2 -->|"r"|DFA4
DFA3 -->|"l"|DFA5
DFA4 -->|"u"|DFA6
DFA5 -->|"s"|DFA7
DFA6 -->|"e"|DFA8
DFA7 -->|"e"|DFA9
DFA8 -->|"[^a-zA-Z0-9_]"|DFA10
DFA9 -->|"[^a-zA-Z0-9_]"|DFA11
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
DFA3_3{{"DFA3 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA4_4{{"DFA4 1 NFA States"}}
end
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA5_5{{"DFA5 1 NFA States"}}
end
subgraph miniDFA6["miniDFA6 1 DFA States"]
DFA6_6{{"DFA6 1 NFA States"}}
end
subgraph miniDFA7["miniDFA7 1 DFA States"]
DFA7_7{{"DFA7 1 NFA States"}}
end
subgraph miniDFA8["miniDFA8 1 DFA States"]
DFA8_8{{"DFA8 1 NFA States"}}
end
subgraph miniDFA9["miniDFA9 1 DFA States"]
DFA9_9{{"DFA9 1 NFA States"}}
end
subgraph miniDFA10["miniDFA10 1 DFA States"]
DFA10_10[\"DFA10 1 NFA States"/]
end
subgraph miniDFA11["miniDFA11 1 DFA States"]
DFA11_11[\"DFA11 1 NFA States"/]
end
miniDFA0 -->|"f"|miniDFA1
miniDFA0 -->|"t"|miniDFA2
miniDFA1 -->|"a"|miniDFA3
miniDFA2 -->|"r"|miniDFA4
miniDFA3 -->|"l"|miniDFA5
miniDFA4 -->|"u"|miniDFA6
miniDFA5 -->|"s"|miniDFA7
miniDFA6 -->|"e"|miniDFA8
miniDFA7 -->|"e"|miniDFA9
miniDFA8 -->|"[^a-zA-Z0-9_]"|miniDFA10
miniDFA9 -->|"[^a-zA-Z0-9_]"|miniDFA11
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
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA7(["miniDFA7 1 DFA States"])
miniDFA8(["miniDFA8 1 DFA States"])
miniDFA9(["miniDFA9 1 DFA States"])
miniDFA10(["miniDFA10 1 DFA States"])
miniDFA11(["miniDFA11 1 DFA States"])
miniDFA0 -->|"f"|miniDFA1
miniDFA0 -->|"t"|miniDFA2
miniDFA1 -->|"a"|miniDFA3
miniDFA2 -->|"r"|miniDFA4
miniDFA3 -->|"l"|miniDFA5
miniDFA4 -->|"u"|miniDFA6
miniDFA5 -->|"s"|miniDFA7
miniDFA6 -->|"e"|miniDFA8
miniDFA7 -->|"e"|miniDFA9
miniDFA8 -->|"[^a-zA-Z0-9_]"|miniDFA10
miniDFA9 -->|"[^a-zA-Z0-9_]"|miniDFA11
```
-------------------------------
pattern: `true/[^a-zA-Z0-9_]`

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
eNFA1_12[["εNFA1-12 regex start"]]
eNFA1_10[["εNFA1-10 scope{1, 1}"]]
eNFA1_11[["εNFA1-11 scope[1]"]]
eNFA1_13[\"εNFA1-13 regex end"/]
eNFA1_8 -.->|"ε"|eNFA1_0
eNFA1_0 -->|"t"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_2 -->|"r"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_4 -->|"u"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_6 -->|"e"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA1_9 -.->|"ε"|eNFA1_12
eNFA1_12 -.->|"ε"|eNFA1_10
eNFA1_10 -->|"[^a-zA-Z0-9_]"|eNFA1_11
eNFA1_11 -.->|"ε"|eNFA1_13
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
eNFA1_7[["εNFA1-7 char[1]"]]
eNFA1_9[["εNFA1-9 regex end"]]
eNFA1_12[["εNFA1-12 regex start"]]
eNFA1_10[["εNFA1-10 scope{1, 1}"]]
eNFA1_11[\"εNFA1-11 scope[1]"/]
eNFA1_13[\"εNFA1-13 regex end"/]
eNFA1_8 -.->|"ε"|eNFA1_0
eNFA1_8 -->|"t"|eNFA1_1
eNFA1_0 -->|"t"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"r"|eNFA1_3
eNFA1_2 -->|"r"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -->|"u"|eNFA1_5
eNFA1_4 -->|"u"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -->|"e"|eNFA1_7
eNFA1_6 -->|"e"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA1_7 -.->|"ε"|eNFA1_12
eNFA1_7 -.->|"ε"|eNFA1_10
eNFA1_7 -->|"[^a-zA-Z0-9_]"|eNFA1_11
eNFA1_9 -.->|"ε"|eNFA1_12
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_9 -->|"[^a-zA-Z0-9_]"|eNFA1_11
eNFA1_12 -.->|"ε"|eNFA1_10
eNFA1_12 -->|"[^a-zA-Z0-9_]"|eNFA1_11
eNFA1_10 -->|"[^a-zA-Z0-9_]"|eNFA1_11
eNFA1_11 -.->|"ε"|eNFA1_13
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
NFA1_7("NFA1-7 char[1]")
NFA1_11[\"NFA1-11 scope[1]"/]
NFA1_8 -->|"t"|NFA1_1
NFA1_1 -->|"r"|NFA1_3
NFA1_3 -->|"u"|NFA1_5
NFA1_5 -->|"e"|NFA1_7
NFA1_7 -->|"[^a-zA-Z0-9_]"|NFA1_11
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
NFA1_7_4("NFA1-7 char[1]")
end
subgraph DFA5["DFA5 1 NFA States"]
NFA1_11_5[\"NFA1-11 scope[1]"/]
end
DFA0 -->|"t"|DFA1
DFA1 -->|"r"|DFA2
DFA2 -->|"u"|DFA3
DFA3 -->|"e"|DFA4
DFA4 -->|"[^a-zA-Z0-9_]"|DFA5
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
DFA4{{"DFA4 1 NFA States"}}
DFA5[\"DFA5 1 NFA States"/]
DFA0 -->|"t"|DFA1
DFA1 -->|"r"|DFA2
DFA2 -->|"u"|DFA3
DFA3 -->|"e"|DFA4
DFA4 -->|"[^a-zA-Z0-9_]"|DFA5
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
DFA4_4{{"DFA4 1 NFA States"}}
end
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA5_5[\"DFA5 1 NFA States"/]
end
miniDFA0 -->|"t"|miniDFA1
miniDFA1 -->|"r"|miniDFA2
miniDFA2 -->|"u"|miniDFA3
miniDFA3 -->|"e"|miniDFA4
miniDFA4 -->|"[^a-zA-Z0-9_]"|miniDFA5
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
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA0 -->|"t"|miniDFA1
miniDFA1 -->|"r"|miniDFA2
miniDFA2 -->|"u"|miniDFA3
miniDFA3 -->|"e"|miniDFA4
miniDFA4 -->|"[^a-zA-Z0-9_]"|miniDFA5
```
-------------------------------
pattern: `false/[^a-zA-Z0-9_]`

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
eNFA2_10[["εNFA2-10 regex start"]]
eNFA2_0[["εNFA2-0 char{1, 1}"]]
eNFA2_1[["εNFA2-1 char[1]"]]
eNFA2_2[["εNFA2-2 char{1, 1}"]]
eNFA2_3[["εNFA2-3 char[1]"]]
eNFA2_4[["εNFA2-4 char{1, 1}"]]
eNFA2_5[["εNFA2-5 char[1]"]]
eNFA2_6[["εNFA2-6 char{1, 1}"]]
eNFA2_7[["εNFA2-7 char[1]"]]
eNFA2_8[["εNFA2-8 char{1, 1}"]]
eNFA2_9[["εNFA2-9 char[1]"]]
eNFA2_11[["εNFA2-11 regex end"]]
eNFA2_14[["εNFA2-14 regex start"]]
eNFA2_12[["εNFA2-12 scope{1, 1}"]]
eNFA2_13[["εNFA2-13 scope[1]"]]
eNFA2_15[\"εNFA2-15 regex end"/]
eNFA2_10 -.->|"ε"|eNFA2_0
eNFA2_0 -->|"f"|eNFA2_1
eNFA2_1 -.->|"ε"|eNFA2_2
eNFA2_2 -->|"a"|eNFA2_3
eNFA2_3 -.->|"ε"|eNFA2_4
eNFA2_4 -->|"l"|eNFA2_5
eNFA2_5 -.->|"ε"|eNFA2_6
eNFA2_6 -->|"s"|eNFA2_7
eNFA2_7 -.->|"ε"|eNFA2_8
eNFA2_8 -->|"e"|eNFA2_9
eNFA2_9 -.->|"ε"|eNFA2_11
eNFA2_11 -.->|"ε"|eNFA2_14
eNFA2_14 -.->|"ε"|eNFA2_12
eNFA2_12 -->|"[^a-zA-Z0-9_]"|eNFA2_13
eNFA2_13 -.->|"ε"|eNFA2_15
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
eNFA2_10[["εNFA2-10 regex start"]]
eNFA2_0[["εNFA2-0 char{1, 1}"]]
eNFA2_1[["εNFA2-1 char[1]"]]
eNFA2_2[["εNFA2-2 char{1, 1}"]]
eNFA2_3[["εNFA2-3 char[1]"]]
eNFA2_4[["εNFA2-4 char{1, 1}"]]
eNFA2_5[["εNFA2-5 char[1]"]]
eNFA2_6[["εNFA2-6 char{1, 1}"]]
eNFA2_7[["εNFA2-7 char[1]"]]
eNFA2_8[["εNFA2-8 char{1, 1}"]]
eNFA2_9[["εNFA2-9 char[1]"]]
eNFA2_11[["εNFA2-11 regex end"]]
eNFA2_14[["εNFA2-14 regex start"]]
eNFA2_12[["εNFA2-12 scope{1, 1}"]]
eNFA2_13[\"εNFA2-13 scope[1]"/]
eNFA2_15[\"εNFA2-15 regex end"/]
eNFA2_10 -.->|"ε"|eNFA2_0
eNFA2_10 -->|"f"|eNFA2_1
eNFA2_0 -->|"f"|eNFA2_1
eNFA2_1 -.->|"ε"|eNFA2_2
eNFA2_1 -->|"a"|eNFA2_3
eNFA2_2 -->|"a"|eNFA2_3
eNFA2_3 -.->|"ε"|eNFA2_4
eNFA2_3 -->|"l"|eNFA2_5
eNFA2_4 -->|"l"|eNFA2_5
eNFA2_5 -.->|"ε"|eNFA2_6
eNFA2_5 -->|"s"|eNFA2_7
eNFA2_6 -->|"s"|eNFA2_7
eNFA2_7 -.->|"ε"|eNFA2_8
eNFA2_7 -->|"e"|eNFA2_9
eNFA2_8 -->|"e"|eNFA2_9
eNFA2_9 -.->|"ε"|eNFA2_11
eNFA2_9 -.->|"ε"|eNFA2_14
eNFA2_9 -.->|"ε"|eNFA2_12
eNFA2_9 -->|"[^a-zA-Z0-9_]"|eNFA2_13
eNFA2_11 -.->|"ε"|eNFA2_14
eNFA2_11 -.->|"ε"|eNFA2_12
eNFA2_11 -->|"[^a-zA-Z0-9_]"|eNFA2_13
eNFA2_14 -.->|"ε"|eNFA2_12
eNFA2_14 -->|"[^a-zA-Z0-9_]"|eNFA2_13
eNFA2_12 -->|"[^a-zA-Z0-9_]"|eNFA2_13
eNFA2_13 -.->|"ε"|eNFA2_15
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
NFA2_10("NFA2-10 regex start")
NFA2_1("NFA2-1 char[1]")
NFA2_3("NFA2-3 char[1]")
NFA2_5("NFA2-5 char[1]")
NFA2_7("NFA2-7 char[1]")
NFA2_9("NFA2-9 char[1]")
NFA2_13[\"NFA2-13 scope[1]"/]
NFA2_10 -->|"f"|NFA2_1
NFA2_1 -->|"a"|NFA2_3
NFA2_3 -->|"l"|NFA2_5
NFA2_5 -->|"s"|NFA2_7
NFA2_7 -->|"e"|NFA2_9
NFA2_9 -->|"[^a-zA-Z0-9_]"|NFA2_13
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
NFA2_10_0("NFA2-10 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA2_1_1("NFA2-1 char[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA2_3_2("NFA2-3 char[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA2_5_3("NFA2-5 char[1]")
end
subgraph DFA4["DFA4 1 NFA States"]
NFA2_7_4("NFA2-7 char[1]")
end
subgraph DFA5["DFA5 1 NFA States"]
NFA2_9_5("NFA2-9 char[1]")
end
subgraph DFA6["DFA6 1 NFA States"]
NFA2_13_6[\"NFA2-13 scope[1]"/]
end
DFA0 -->|"f"|DFA1
DFA1 -->|"a"|DFA2
DFA2 -->|"l"|DFA3
DFA3 -->|"s"|DFA4
DFA4 -->|"e"|DFA5
DFA5 -->|"[^a-zA-Z0-9_]"|DFA6
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
DFA4{{"DFA4 1 NFA States"}}
DFA5{{"DFA5 1 NFA States"}}
DFA6[\"DFA6 1 NFA States"/]
DFA0 -->|"f"|DFA1
DFA1 -->|"a"|DFA2
DFA2 -->|"l"|DFA3
DFA3 -->|"s"|DFA4
DFA4 -->|"e"|DFA5
DFA5 -->|"[^a-zA-Z0-9_]"|DFA6
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
DFA4_4{{"DFA4 1 NFA States"}}
end
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA5_5{{"DFA5 1 NFA States"}}
end
subgraph miniDFA6["miniDFA6 1 DFA States"]
DFA6_6[\"DFA6 1 NFA States"/]
end
miniDFA0 -->|"f"|miniDFA1
miniDFA1 -->|"a"|miniDFA2
miniDFA2 -->|"l"|miniDFA3
miniDFA3 -->|"s"|miniDFA4
miniDFA4 -->|"e"|miniDFA5
miniDFA5 -->|"[^a-zA-Z0-9_]"|miniDFA6
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
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA0 -->|"f"|miniDFA1
miniDFA1 -->|"a"|miniDFA2
miniDFA2 -->|"l"|miniDFA3
miniDFA3 -->|"s"|miniDFA4
miniDFA4 -->|"e"|miniDFA5
miniDFA5 -->|"[^a-zA-Z0-9_]"|miniDFA6
```
-------------------------------
