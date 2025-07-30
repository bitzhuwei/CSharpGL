# Vt: 'literalString'

patterns[0]: `[a-zA-Z_]?"(\\.|[^\\"])*"`

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
eNFA0_16[["εNFA0-16 post-regex start"]]
eNFA0_17[\"εNFA0-17 post-regex end"/]
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
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_16 -.->|"ε"|eNFA0_17
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
eNFA0_13[\"εNFA0-13 char[1]"/]
eNFA0_6[["εNFA0-6 char{1, 1}"]]
eNFA0_7[["εNFA0-7 char[1]"]]
eNFA0_15[\"εNFA0-15 regex end"/]
eNFA0_16[\"εNFA0-16 post-regex start"/]
eNFA0_17[\"εNFA0-17 post-regex end"/]
eNFA0_14 -.->|"ε"|eNFA0_0
eNFA0_14 -->|"[a-zA-Z_]"|eNFA0_1
eNFA0_14 -.->|"ε"|eNFA0_1
eNFA0_14 -.->|"ε"|eNFA0_2
eNFA0_14 -->|"#34;"|eNFA0_3
eNFA0_0 -->|"[a-zA-Z_]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_2
eNFA0_0 -->|"#34;"|eNFA0_3
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_1 -->|"#34;"|eNFA0_3
eNFA0_2 -->|"#34;"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_8
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_3 -.->|"ε"|eNFA0_10
eNFA0_3 -.->|"ε"|eNFA0_9
eNFA0_3 -->|"#92;#92;"|eNFA0_5
eNFA0_3 -->|"[^#92;#92;#34;]"|eNFA0_11
eNFA0_3 -.->|"ε"|eNFA0_12
eNFA0_3 -->|"#34;"|eNFA0_13
eNFA0_8 -.->|"ε"|eNFA0_4
eNFA0_8 -.->|"ε"|eNFA0_10
eNFA0_8 -.->|"ε"|eNFA0_9
eNFA0_8 -->|"#92;#92;"|eNFA0_5
eNFA0_8 -->|"[^#92;#92;#34;]"|eNFA0_11
eNFA0_8 -.->|"ε"|eNFA0_8
eNFA0_8 -.->|"ε"|eNFA0_12
eNFA0_8 -->|"#34;"|eNFA0_13
eNFA0_4 -->|"#92;#92;"|eNFA0_5
eNFA0_10 -->|"[^#92;#92;#34;]"|eNFA0_11
eNFA0_9 -.->|"ε"|eNFA0_8
eNFA0_9 -.->|"ε"|eNFA0_12
eNFA0_9 -.->|"ε"|eNFA0_4
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_9 -.->|"ε"|eNFA0_9
eNFA0_9 -->|"#92;#92;"|eNFA0_5
eNFA0_9 -->|"[^#92;#92;#34;]"|eNFA0_11
eNFA0_9 -->|"#34;"|eNFA0_13
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_5 -->|"[#32;-~]"|eNFA0_7
eNFA0_11 -.->|"ε"|eNFA0_9
eNFA0_11 -.->|"ε"|eNFA0_8
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_11 -.->|"ε"|eNFA0_4
eNFA0_11 -.->|"ε"|eNFA0_10
eNFA0_11 -->|"#92;#92;"|eNFA0_5
eNFA0_11 -->|"[^#92;#92;#34;]"|eNFA0_11
eNFA0_11 -->|"#34;"|eNFA0_13
eNFA0_12 -->|"#34;"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_15
eNFA0_13 -.->|"ε"|eNFA0_16
eNFA0_13 -.->|"ε"|eNFA0_17
eNFA0_6 -->|"[#32;-~]"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_9
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_7 -.->|"ε"|eNFA0_12
eNFA0_7 -.->|"ε"|eNFA0_4
eNFA0_7 -.->|"ε"|eNFA0_10
eNFA0_7 -->|"#92;#92;"|eNFA0_5
eNFA0_7 -->|"[^#92;#92;#34;]"|eNFA0_11
eNFA0_7 -->|"#34;"|eNFA0_13
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_15 -.->|"ε"|eNFA0_17
eNFA0_16 -.->|"ε"|eNFA0_17
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
NFA0_14("NFA0-14 regex start")
NFA0_1("NFA0-1 scope[1]")
NFA0_3("NFA0-3 char[1]")
NFA0_5("NFA0-5 char[1]")
NFA0_11("NFA0-11 scope[1]")
NFA0_13[\"NFA0-13 char[1]"/]
NFA0_7("NFA0-7 char[1]")
NFA0_14 -->|"[a-zA-Z_]"|NFA0_1
NFA0_14 -->|"#34;"|NFA0_3
NFA0_1 -->|"#34;"|NFA0_3
NFA0_3 -->|"#92;#92;"|NFA0_5
NFA0_3 -->|"[^#92;#92;#34;]"|NFA0_11
NFA0_3 -->|"#34;"|NFA0_13
NFA0_5 -->|"[#32;-~]"|NFA0_7
NFA0_11 -->|"#92;#92;"|NFA0_5
NFA0_11 -->|"[^#92;#92;#34;]"|NFA0_11
NFA0_11 -->|"#34;"|NFA0_13
NFA0_7 -->|"#92;#92;"|NFA0_5
NFA0_7 -->|"[^#92;#92;#34;]"|NFA0_11
NFA0_7 -->|"#34;"|NFA0_13
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
NFA0_14_0("NFA0-14 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA0_3_1("NFA0-3 char[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA0_1_2("NFA0-1 scope[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA0_13_3[\"NFA0-13 char[1]"/]
end
subgraph DFA4["DFA4 1 NFA States"]
NFA0_11_4("NFA0-11 scope[1]")
end
subgraph DFA5["DFA5 1 NFA States"]
NFA0_5_5("NFA0-5 char[1]")
end
subgraph DFA6["DFA6 1 NFA States"]
NFA0_7_6("NFA0-7 char[1]")
end
DFA0 -->|"#34;"|DFA1
DFA0 -->|"[a-zA-Z_]"|DFA2
DFA1 -->|"#34;"|DFA3
DFA1 -->|"[^#92;#92;#34;]"|DFA4
DFA1 -->|"#92;#92;"|DFA5
DFA2 -->|"#34;"|DFA1
DFA4 -->|"#34;"|DFA3
DFA4 -->|"[^#92;#92;#34;]"|DFA4
DFA4 -->|"#92;#92;"|DFA5
DFA5 -->|"[#32;-~]"|DFA6
DFA6 -->|"#34;"|DFA3
DFA6 -->|"[^#92;#92;#34;]"|DFA4
DFA6 -->|"#92;#92;"|DFA5
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
DFA4{{"DFA4 1 NFA States"}}
DFA5{{"DFA5 1 NFA States"}}
DFA6{{"DFA6 1 NFA States"}}
DFA0 -->|"#34;"|DFA1
DFA0 -->|"[a-zA-Z_]"|DFA2
DFA1 -->|"#34;"|DFA3
DFA1 -->|"[^#92;#92;#34;]"|DFA4
DFA1 -->|"#92;#92;"|DFA5
DFA2 -->|"#34;"|DFA1
DFA4 -->|"#34;"|DFA3
DFA4 -->|"[^#92;#92;#34;]"|DFA4
DFA4 -->|"#92;#92;"|DFA5
DFA5 -->|"[#32;-~]"|DFA6
DFA6 -->|"#34;"|DFA3
DFA6 -->|"[^#92;#92;#34;]"|DFA4
DFA6 -->|"#92;#92;"|DFA5
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
subgraph miniDFA1["miniDFA1 3 DFA States"]
DFA1_1{{"DFA1 1 NFA States"}}
DFA4_2{{"DFA4 1 NFA States"}}
DFA6_3{{"DFA6 1 NFA States"}}
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA2_4{{"DFA2 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA3_5[\"DFA3 1 NFA States"/]
end
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA5_6{{"DFA5 1 NFA States"}}
end
miniDFA0 -->|"#34;"|miniDFA1
miniDFA0 -->|"[a-zA-Z_]"|miniDFA2
miniDFA1 -->|"#34;"|miniDFA4
miniDFA1 -->|"[^#92;#92;#34;]"|miniDFA1
miniDFA1 -->|"#92;#92;"|miniDFA3
miniDFA2 -->|"#34;"|miniDFA1
miniDFA3 -->|"[#32;-~]"|miniDFA1
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
miniDFA1(["miniDFA1 3 DFA States"])
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA0 -->|"#34;"|miniDFA1
miniDFA0 -->|"[a-zA-Z_]"|miniDFA2
miniDFA1 -->|"#34;"|miniDFA4
miniDFA1 -->|"[^#92;#92;#34;]"|miniDFA1
miniDFA1 -->|"#92;#92;"|miniDFA3
miniDFA2 -->|"#34;"|miniDFA1
miniDFA3 -->|"[#32;-~]"|miniDFA1
```
-------------------------------
pattern: `[a-zA-Z_]?"(\\.|[^\\"])*"`

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
eNFA1_14[["εNFA1-14 regex start"]]
eNFA1_0[["εNFA1-0 scope{0, 1}"]]
eNFA1_1[["εNFA1-1 scope[1]"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA1_8[["εNFA1-8 regex start"]]
eNFA1_4[["εNFA1-4 char{1, 1}"]]
eNFA1_10[["εNFA1-10 scope{1, 1}"]]
eNFA1_9[["εNFA1-9 regex end"]]
eNFA1_5[["εNFA1-5 char[1]"]]
eNFA1_11[["εNFA1-11 scope[1]"]]
eNFA1_12[["εNFA1-12 char{1, 1}"]]
eNFA1_6[["εNFA1-6 char{1, 1}"]]
eNFA1_13[["εNFA1-13 char[1]"]]
eNFA1_7[["εNFA1-7 char[1]"]]
eNFA1_15[["εNFA1-15 regex end"]]
eNFA1_16[["εNFA1-16 post-regex start"]]
eNFA1_17[\"εNFA1-17 post-regex end"/]
eNFA1_14 -.->|"ε"|eNFA1_0
eNFA1_0 -->|"[a-zA-Z_]"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_2 -->|"#34;"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_8
eNFA1_8 -.->|"ε"|eNFA1_4
eNFA1_8 -.->|"ε"|eNFA1_10
eNFA1_8 -.->|"ε"|eNFA1_9
eNFA1_4 -->|"#92;#92;"|eNFA1_5
eNFA1_10 -->|"[^#92;#92;#34;]"|eNFA1_11
eNFA1_9 -.->|"ε"|eNFA1_8
eNFA1_9 -.->|"ε"|eNFA1_12
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_11 -.->|"ε"|eNFA1_9
eNFA1_12 -->|"#34;"|eNFA1_13
eNFA1_6 -->|"[#32;-~]"|eNFA1_7
eNFA1_13 -.->|"ε"|eNFA1_15
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_16 -.->|"ε"|eNFA1_17
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
eNFA1_14[["εNFA1-14 regex start"]]
eNFA1_0[["εNFA1-0 scope{0, 1}"]]
eNFA1_1[["εNFA1-1 scope[1]"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA1_8[["εNFA1-8 regex start"]]
eNFA1_4[["εNFA1-4 char{1, 1}"]]
eNFA1_10[["εNFA1-10 scope{1, 1}"]]
eNFA1_9[["εNFA1-9 regex end"]]
eNFA1_5[["εNFA1-5 char[1]"]]
eNFA1_11[["εNFA1-11 scope[1]"]]
eNFA1_12[["εNFA1-12 char{1, 1}"]]
eNFA1_13[\"εNFA1-13 char[1]"/]
eNFA1_6[["εNFA1-6 char{1, 1}"]]
eNFA1_7[["εNFA1-7 char[1]"]]
eNFA1_15[\"εNFA1-15 regex end"/]
eNFA1_16[\"εNFA1-16 post-regex start"/]
eNFA1_17[\"εNFA1-17 post-regex end"/]
eNFA1_14 -.->|"ε"|eNFA1_0
eNFA1_14 -->|"[a-zA-Z_]"|eNFA1_1
eNFA1_14 -.->|"ε"|eNFA1_1
eNFA1_14 -.->|"ε"|eNFA1_2
eNFA1_14 -->|"#34;"|eNFA1_3
eNFA1_0 -->|"[a-zA-Z_]"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_2
eNFA1_0 -->|"#34;"|eNFA1_3
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"#34;"|eNFA1_3
eNFA1_2 -->|"#34;"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_8
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -.->|"ε"|eNFA1_10
eNFA1_3 -.->|"ε"|eNFA1_9
eNFA1_3 -->|"#92;#92;"|eNFA1_5
eNFA1_3 -->|"[^#92;#92;#34;]"|eNFA1_11
eNFA1_3 -.->|"ε"|eNFA1_12
eNFA1_3 -->|"#34;"|eNFA1_13
eNFA1_8 -.->|"ε"|eNFA1_4
eNFA1_8 -.->|"ε"|eNFA1_10
eNFA1_8 -.->|"ε"|eNFA1_9
eNFA1_8 -->|"#92;#92;"|eNFA1_5
eNFA1_8 -->|"[^#92;#92;#34;]"|eNFA1_11
eNFA1_8 -.->|"ε"|eNFA1_8
eNFA1_8 -.->|"ε"|eNFA1_12
eNFA1_8 -->|"#34;"|eNFA1_13
eNFA1_4 -->|"#92;#92;"|eNFA1_5
eNFA1_10 -->|"[^#92;#92;#34;]"|eNFA1_11
eNFA1_9 -.->|"ε"|eNFA1_8
eNFA1_9 -.->|"ε"|eNFA1_12
eNFA1_9 -.->|"ε"|eNFA1_4
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_9 -.->|"ε"|eNFA1_9
eNFA1_9 -->|"#92;#92;"|eNFA1_5
eNFA1_9 -->|"[^#92;#92;#34;]"|eNFA1_11
eNFA1_9 -->|"#34;"|eNFA1_13
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -->|"[#32;-~]"|eNFA1_7
eNFA1_11 -.->|"ε"|eNFA1_9
eNFA1_11 -.->|"ε"|eNFA1_8
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_11 -.->|"ε"|eNFA1_4
eNFA1_11 -.->|"ε"|eNFA1_10
eNFA1_11 -->|"#92;#92;"|eNFA1_5
eNFA1_11 -->|"[^#92;#92;#34;]"|eNFA1_11
eNFA1_11 -->|"#34;"|eNFA1_13
eNFA1_12 -->|"#34;"|eNFA1_13
eNFA1_13 -.->|"ε"|eNFA1_15
eNFA1_13 -.->|"ε"|eNFA1_16
eNFA1_13 -.->|"ε"|eNFA1_17
eNFA1_6 -->|"[#32;-~]"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_7 -.->|"ε"|eNFA1_12
eNFA1_7 -.->|"ε"|eNFA1_4
eNFA1_7 -.->|"ε"|eNFA1_10
eNFA1_7 -->|"#92;#92;"|eNFA1_5
eNFA1_7 -->|"[^#92;#92;#34;]"|eNFA1_11
eNFA1_7 -->|"#34;"|eNFA1_13
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_15 -.->|"ε"|eNFA1_17
eNFA1_16 -.->|"ε"|eNFA1_17
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
NFA1_14("NFA1-14 regex start")
NFA1_1("NFA1-1 scope[1]")
NFA1_3("NFA1-3 char[1]")
NFA1_5("NFA1-5 char[1]")
NFA1_11("NFA1-11 scope[1]")
NFA1_13[\"NFA1-13 char[1]"/]
NFA1_7("NFA1-7 char[1]")
NFA1_14 -->|"[a-zA-Z_]"|NFA1_1
NFA1_14 -->|"#34;"|NFA1_3
NFA1_1 -->|"#34;"|NFA1_3
NFA1_3 -->|"#92;#92;"|NFA1_5
NFA1_3 -->|"[^#92;#92;#34;]"|NFA1_11
NFA1_3 -->|"#34;"|NFA1_13
NFA1_5 -->|"[#32;-~]"|NFA1_7
NFA1_11 -->|"#92;#92;"|NFA1_5
NFA1_11 -->|"[^#92;#92;#34;]"|NFA1_11
NFA1_11 -->|"#34;"|NFA1_13
NFA1_7 -->|"#92;#92;"|NFA1_5
NFA1_7 -->|"[^#92;#92;#34;]"|NFA1_11
NFA1_7 -->|"#34;"|NFA1_13
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
NFA1_14_0("NFA1-14 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA1_3_1("NFA1-3 char[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA1_1_2("NFA1-1 scope[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA1_13_3[\"NFA1-13 char[1]"/]
end
subgraph DFA4["DFA4 1 NFA States"]
NFA1_11_4("NFA1-11 scope[1]")
end
subgraph DFA5["DFA5 1 NFA States"]
NFA1_5_5("NFA1-5 char[1]")
end
subgraph DFA6["DFA6 1 NFA States"]
NFA1_7_6("NFA1-7 char[1]")
end
DFA0 -->|"#34;"|DFA1
DFA0 -->|"[a-zA-Z_]"|DFA2
DFA1 -->|"#34;"|DFA3
DFA1 -->|"[^#92;#92;#34;]"|DFA4
DFA1 -->|"#92;#92;"|DFA5
DFA2 -->|"#34;"|DFA1
DFA4 -->|"#34;"|DFA3
DFA4 -->|"[^#92;#92;#34;]"|DFA4
DFA4 -->|"#92;#92;"|DFA5
DFA5 -->|"[#32;-~]"|DFA6
DFA6 -->|"#34;"|DFA3
DFA6 -->|"[^#92;#92;#34;]"|DFA4
DFA6 -->|"#92;#92;"|DFA5
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
DFA4{{"DFA4 1 NFA States"}}
DFA5{{"DFA5 1 NFA States"}}
DFA6{{"DFA6 1 NFA States"}}
DFA0 -->|"#34;"|DFA1
DFA0 -->|"[a-zA-Z_]"|DFA2
DFA1 -->|"#34;"|DFA3
DFA1 -->|"[^#92;#92;#34;]"|DFA4
DFA1 -->|"#92;#92;"|DFA5
DFA2 -->|"#34;"|DFA1
DFA4 -->|"#34;"|DFA3
DFA4 -->|"[^#92;#92;#34;]"|DFA4
DFA4 -->|"#92;#92;"|DFA5
DFA5 -->|"[#32;-~]"|DFA6
DFA6 -->|"#34;"|DFA3
DFA6 -->|"[^#92;#92;#34;]"|DFA4
DFA6 -->|"#92;#92;"|DFA5
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
subgraph miniDFA1["miniDFA1 3 DFA States"]
DFA1_1{{"DFA1 1 NFA States"}}
DFA4_2{{"DFA4 1 NFA States"}}
DFA6_3{{"DFA6 1 NFA States"}}
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA2_4{{"DFA2 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA3_5[\"DFA3 1 NFA States"/]
end
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA5_6{{"DFA5 1 NFA States"}}
end
miniDFA0 -->|"#34;"|miniDFA1
miniDFA0 -->|"[a-zA-Z_]"|miniDFA2
miniDFA1 -->|"#34;"|miniDFA4
miniDFA1 -->|"[^#92;#92;#34;]"|miniDFA1
miniDFA1 -->|"#92;#92;"|miniDFA3
miniDFA2 -->|"#34;"|miniDFA1
miniDFA3 -->|"[#32;-~]"|miniDFA1
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
miniDFA1(["miniDFA1 3 DFA States"])
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA0 -->|"#34;"|miniDFA1
miniDFA0 -->|"[a-zA-Z_]"|miniDFA2
miniDFA1 -->|"#34;"|miniDFA4
miniDFA1 -->|"[^#92;#92;#34;]"|miniDFA1
miniDFA1 -->|"#92;#92;"|miniDFA3
miniDFA2 -->|"#34;"|miniDFA1
miniDFA3 -->|"[#32;-~]"|miniDFA1
```
-------------------------------
