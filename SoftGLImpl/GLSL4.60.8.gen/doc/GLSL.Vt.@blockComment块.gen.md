# Vt: 'blockComment'

patterns[0]: `\/\*([^*\u0000]|[*][^/\u0000])*\*\/`

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
eNFA0_16[["εNFA0-16 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_6[["εNFA0-6 regex start"]]
eNFA0_4[["εNFA0-4 scope{1, 1}"]]
eNFA0_8[["εNFA0-8 scope{1, 1}"]]
eNFA0_7[["εNFA0-7 regex end"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_9[["εNFA0-9 scope[1]"]]
eNFA0_12[["εNFA0-12 char{1, 1}"]]
eNFA0_10[["εNFA0-10 scope{1, 1}"]]
eNFA0_13[["εNFA0-13 char[1]"]]
eNFA0_11[["εNFA0-11 scope[1]"]]
eNFA0_14[["εNFA0-14 char{1, 1}"]]
eNFA0_15[["εNFA0-15 char[1]"]]
eNFA0_17[["εNFA0-17 regex end"]]
eNFA0_18[["εNFA0-18 post-regex start"]]
eNFA0_19[\"εNFA0-19 post-regex end"/]
eNFA0_16 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"#92;/"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"#92;#42;"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_6
eNFA0_6 -.->|"ε"|eNFA0_4
eNFA0_6 -.->|"ε"|eNFA0_8
eNFA0_6 -.->|"ε"|eNFA0_7
eNFA0_4 -->|"[^#42;#92;u0000]"|eNFA0_5
eNFA0_8 -->|"[#42;]"|eNFA0_9
eNFA0_7 -.->|"ε"|eNFA0_6
eNFA0_7 -.->|"ε"|eNFA0_12
eNFA0_5 -.->|"ε"|eNFA0_7
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_12 -->|"#92;#42;"|eNFA0_13
eNFA0_10 -->|"[^/#92;u0000]"|eNFA0_11
eNFA0_13 -.->|"ε"|eNFA0_14
eNFA0_11 -.->|"ε"|eNFA0_7
eNFA0_14 -->|"#92;/"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_17
eNFA0_17 -.->|"ε"|eNFA0_18
eNFA0_18 -.->|"ε"|eNFA0_19
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
eNFA0_16[["εNFA0-16 regex start"]]
eNFA0_0[["εNFA0-0 char{1, 1}"]]
eNFA0_1[["εNFA0-1 char[1]"]]
eNFA0_2[["εNFA0-2 char{1, 1}"]]
eNFA0_3[["εNFA0-3 char[1]"]]
eNFA0_6[["εNFA0-6 regex start"]]
eNFA0_4[["εNFA0-4 scope{1, 1}"]]
eNFA0_8[["εNFA0-8 scope{1, 1}"]]
eNFA0_7[["εNFA0-7 regex end"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_9[["εNFA0-9 scope[1]"]]
eNFA0_12[["εNFA0-12 char{1, 1}"]]
eNFA0_13[["εNFA0-13 char[1]"]]
eNFA0_10[["εNFA0-10 scope{1, 1}"]]
eNFA0_11[["εNFA0-11 scope[1]"]]
eNFA0_14[["εNFA0-14 char{1, 1}"]]
eNFA0_15[\"εNFA0-15 char[1]"/]
eNFA0_17[\"εNFA0-17 regex end"/]
eNFA0_18[\"εNFA0-18 post-regex start"/]
eNFA0_19[\"εNFA0-19 post-regex end"/]
eNFA0_16 -.->|"ε"|eNFA0_0
eNFA0_16 -->|"#92;/"|eNFA0_1
eNFA0_0 -->|"#92;/"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_1 -->|"#92;#42;"|eNFA0_3
eNFA0_2 -->|"#92;#42;"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_6
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_3 -.->|"ε"|eNFA0_8
eNFA0_3 -.->|"ε"|eNFA0_7
eNFA0_3 -->|"[^#42;#92;u0000]"|eNFA0_5
eNFA0_3 -->|"[#42;]"|eNFA0_9
eNFA0_3 -.->|"ε"|eNFA0_12
eNFA0_3 -->|"#92;#42;"|eNFA0_13
eNFA0_6 -.->|"ε"|eNFA0_4
eNFA0_6 -.->|"ε"|eNFA0_8
eNFA0_6 -.->|"ε"|eNFA0_7
eNFA0_6 -->|"[^#42;#92;u0000]"|eNFA0_5
eNFA0_6 -->|"[#42;]"|eNFA0_9
eNFA0_6 -.->|"ε"|eNFA0_6
eNFA0_6 -.->|"ε"|eNFA0_12
eNFA0_6 -->|"#92;#42;"|eNFA0_13
eNFA0_4 -->|"[^#42;#92;u0000]"|eNFA0_5
eNFA0_8 -->|"[#42;]"|eNFA0_9
eNFA0_7 -.->|"ε"|eNFA0_6
eNFA0_7 -.->|"ε"|eNFA0_12
eNFA0_7 -.->|"ε"|eNFA0_4
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_7 -.->|"ε"|eNFA0_7
eNFA0_7 -->|"[^#42;#92;u0000]"|eNFA0_5
eNFA0_7 -->|"[#42;]"|eNFA0_9
eNFA0_7 -->|"#92;#42;"|eNFA0_13
eNFA0_5 -.->|"ε"|eNFA0_7
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_5 -.->|"ε"|eNFA0_12
eNFA0_5 -.->|"ε"|eNFA0_4
eNFA0_5 -.->|"ε"|eNFA0_8
eNFA0_5 -->|"[^#42;#92;u0000]"|eNFA0_5
eNFA0_5 -->|"[#42;]"|eNFA0_9
eNFA0_5 -->|"#92;#42;"|eNFA0_13
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_9 -->|"[^/#92;u0000]"|eNFA0_11
eNFA0_12 -->|"#92;#42;"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_14
eNFA0_13 -->|"#92;/"|eNFA0_15
eNFA0_10 -->|"[^/#92;u0000]"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_7
eNFA0_11 -.->|"ε"|eNFA0_6
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_11 -.->|"ε"|eNFA0_4
eNFA0_11 -.->|"ε"|eNFA0_8
eNFA0_11 -->|"[^#42;#92;u0000]"|eNFA0_5
eNFA0_11 -->|"[#42;]"|eNFA0_9
eNFA0_11 -->|"#92;#42;"|eNFA0_13
eNFA0_14 -->|"#92;/"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_17
eNFA0_15 -.->|"ε"|eNFA0_18
eNFA0_15 -.->|"ε"|eNFA0_19
eNFA0_17 -.->|"ε"|eNFA0_18
eNFA0_17 -.->|"ε"|eNFA0_19
eNFA0_18 -.->|"ε"|eNFA0_19
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
NFA0_16("NFA0-16 regex start")
NFA0_1("NFA0-1 char[1]")
NFA0_3("NFA0-3 char[1]")
NFA0_5("NFA0-5 scope[1]")
NFA0_9("NFA0-9 scope[1]")
NFA0_13("NFA0-13 char[1]")
NFA0_11("NFA0-11 scope[1]")
NFA0_15[\"NFA0-15 char[1]"/]
NFA0_16 -->|"#92;/"|NFA0_1
NFA0_1 -->|"#92;#42;"|NFA0_3
NFA0_3 -->|"[^#42;#92;u0000]"|NFA0_5
NFA0_3 -->|"[#42;]"|NFA0_9
NFA0_3 -->|"#92;#42;"|NFA0_13
NFA0_5 -->|"[^#42;#92;u0000]"|NFA0_5
NFA0_5 -->|"[#42;]"|NFA0_9
NFA0_5 -->|"#92;#42;"|NFA0_13
NFA0_9 -->|"[^/#92;u0000]"|NFA0_11
NFA0_13 -->|"#92;/"|NFA0_15
NFA0_11 -->|"[^#42;#92;u0000]"|NFA0_5
NFA0_11 -->|"[#42;]"|NFA0_9
NFA0_11 -->|"#92;#42;"|NFA0_13
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
NFA0_16_0("NFA0-16 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA0_1_1("NFA0-1 char[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA0_3_2("NFA0-3 char[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA0_5_3("NFA0-5 scope[1]")
end
subgraph DFA4["DFA4 2 NFA States"]
NFA0_9_4("NFA0-9 scope[1]")
NFA0_13_5("NFA0-13 char[1]")
end
subgraph DFA5["DFA5 1 NFA States"]
NFA0_15_6[\"NFA0-15 char[1]"/]
end
subgraph DFA6["DFA6 1 NFA States"]
NFA0_11_7("NFA0-11 scope[1]")
end
DFA0 -->|"#92;/"|DFA1
DFA1 -->|"#92;#42;"|DFA2
DFA2 -->|"[^#42;#92;u0000]"|DFA3
DFA2 -->|"[#42;]"|DFA4
DFA3 -->|"[^#42;#92;u0000]"|DFA3
DFA3 -->|"[#42;]"|DFA4
DFA4 -->|"#92;/"|DFA5
DFA4 -->|"[^/#92;u0000]"|DFA6
DFA6 -->|"[^#42;#92;u0000]"|DFA3
DFA6 -->|"[#42;]"|DFA4
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
DFA4{{"DFA4 2 NFA States"}}
DFA5[\"DFA5 1 NFA States"/]
DFA6{{"DFA6 1 NFA States"}}
DFA0 -->|"#92;/"|DFA1
DFA1 -->|"#92;#42;"|DFA2
DFA2 -->|"[^#42;#92;u0000]"|DFA3
DFA2 -->|"[#42;]"|DFA4
DFA3 -->|"[^#42;#92;u0000]"|DFA3
DFA3 -->|"[#42;]"|DFA4
DFA4 -->|"#92;/"|DFA5
DFA4 -->|"[^/#92;u0000]"|DFA6
DFA6 -->|"[^#42;#92;u0000]"|DFA3
DFA6 -->|"[#42;]"|DFA4
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
subgraph miniDFA2["miniDFA2 3 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
DFA3_3{{"DFA3 1 NFA States"}}
DFA6_4{{"DFA6 1 NFA States"}}
end
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA4_5{{"DFA4 2 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA5_6[\"DFA5 1 NFA States"/]
end
miniDFA0 -->|"#92;/"|miniDFA1
miniDFA1 -->|"#92;#42;"|miniDFA2
miniDFA2 -->|"[^#42;#92;u0000]"|miniDFA2
miniDFA2 -->|"[#42;]"|miniDFA3
miniDFA3 -->|"#92;/"|miniDFA4
miniDFA3 -->|"[^/#92;u0000]"|miniDFA2
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
miniDFA2(["miniDFA2 3 DFA States"])
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA0 -->|"#92;/"|miniDFA1
miniDFA1 -->|"#92;#42;"|miniDFA2
miniDFA2 -->|"[^#42;#92;u0000]"|miniDFA2
miniDFA2 -->|"[#42;]"|miniDFA3
miniDFA3 -->|"#92;/"|miniDFA4
miniDFA3 -->|"[^/#92;u0000]"|miniDFA2
```
-------------------------------
pattern: `\/\*([^*\u0000]|[*][^/\u0000])*\*\/`

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
eNFA1_16[["εNFA1-16 regex start"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA1_6[["εNFA1-6 regex start"]]
eNFA1_4[["εNFA1-4 scope{1, 1}"]]
eNFA1_8[["εNFA1-8 scope{1, 1}"]]
eNFA1_7[["εNFA1-7 regex end"]]
eNFA1_5[["εNFA1-5 scope[1]"]]
eNFA1_9[["εNFA1-9 scope[1]"]]
eNFA1_12[["εNFA1-12 char{1, 1}"]]
eNFA1_10[["εNFA1-10 scope{1, 1}"]]
eNFA1_13[["εNFA1-13 char[1]"]]
eNFA1_11[["εNFA1-11 scope[1]"]]
eNFA1_14[["εNFA1-14 char{1, 1}"]]
eNFA1_15[["εNFA1-15 char[1]"]]
eNFA1_17[["εNFA1-17 regex end"]]
eNFA1_18[["εNFA1-18 post-regex start"]]
eNFA1_19[\"εNFA1-19 post-regex end"/]
eNFA1_16 -.->|"ε"|eNFA1_0
eNFA1_0 -->|"#92;/"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_2 -->|"#92;#42;"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_6
eNFA1_6 -.->|"ε"|eNFA1_4
eNFA1_6 -.->|"ε"|eNFA1_8
eNFA1_6 -.->|"ε"|eNFA1_7
eNFA1_4 -->|"[^#42;#92;u0000]"|eNFA1_5
eNFA1_8 -->|"[#42;]"|eNFA1_9
eNFA1_7 -.->|"ε"|eNFA1_6
eNFA1_7 -.->|"ε"|eNFA1_12
eNFA1_5 -.->|"ε"|eNFA1_7
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_12 -->|"#92;#42;"|eNFA1_13
eNFA1_10 -->|"[^/#92;u0000]"|eNFA1_11
eNFA1_13 -.->|"ε"|eNFA1_14
eNFA1_11 -.->|"ε"|eNFA1_7
eNFA1_14 -->|"#92;/"|eNFA1_15
eNFA1_15 -.->|"ε"|eNFA1_17
eNFA1_17 -.->|"ε"|eNFA1_18
eNFA1_18 -.->|"ε"|eNFA1_19
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
eNFA1_16[["εNFA1-16 regex start"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA1_6[["εNFA1-6 regex start"]]
eNFA1_4[["εNFA1-4 scope{1, 1}"]]
eNFA1_8[["εNFA1-8 scope{1, 1}"]]
eNFA1_7[["εNFA1-7 regex end"]]
eNFA1_5[["εNFA1-5 scope[1]"]]
eNFA1_9[["εNFA1-9 scope[1]"]]
eNFA1_12[["εNFA1-12 char{1, 1}"]]
eNFA1_13[["εNFA1-13 char[1]"]]
eNFA1_10[["εNFA1-10 scope{1, 1}"]]
eNFA1_11[["εNFA1-11 scope[1]"]]
eNFA1_14[["εNFA1-14 char{1, 1}"]]
eNFA1_15[\"εNFA1-15 char[1]"/]
eNFA1_17[\"εNFA1-17 regex end"/]
eNFA1_18[\"εNFA1-18 post-regex start"/]
eNFA1_19[\"εNFA1-19 post-regex end"/]
eNFA1_16 -.->|"ε"|eNFA1_0
eNFA1_16 -->|"#92;/"|eNFA1_1
eNFA1_0 -->|"#92;/"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"#92;#42;"|eNFA1_3
eNFA1_2 -->|"#92;#42;"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_6
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -.->|"ε"|eNFA1_8
eNFA1_3 -.->|"ε"|eNFA1_7
eNFA1_3 -->|"[^#42;#92;u0000]"|eNFA1_5
eNFA1_3 -->|"[#42;]"|eNFA1_9
eNFA1_3 -.->|"ε"|eNFA1_12
eNFA1_3 -->|"#92;#42;"|eNFA1_13
eNFA1_6 -.->|"ε"|eNFA1_4
eNFA1_6 -.->|"ε"|eNFA1_8
eNFA1_6 -.->|"ε"|eNFA1_7
eNFA1_6 -->|"[^#42;#92;u0000]"|eNFA1_5
eNFA1_6 -->|"[#42;]"|eNFA1_9
eNFA1_6 -.->|"ε"|eNFA1_6
eNFA1_6 -.->|"ε"|eNFA1_12
eNFA1_6 -->|"#92;#42;"|eNFA1_13
eNFA1_4 -->|"[^#42;#92;u0000]"|eNFA1_5
eNFA1_8 -->|"[#42;]"|eNFA1_9
eNFA1_7 -.->|"ε"|eNFA1_6
eNFA1_7 -.->|"ε"|eNFA1_12
eNFA1_7 -.->|"ε"|eNFA1_4
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_7 -.->|"ε"|eNFA1_7
eNFA1_7 -->|"[^#42;#92;u0000]"|eNFA1_5
eNFA1_7 -->|"[#42;]"|eNFA1_9
eNFA1_7 -->|"#92;#42;"|eNFA1_13
eNFA1_5 -.->|"ε"|eNFA1_7
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -.->|"ε"|eNFA1_12
eNFA1_5 -.->|"ε"|eNFA1_4
eNFA1_5 -.->|"ε"|eNFA1_8
eNFA1_5 -->|"[^#42;#92;u0000]"|eNFA1_5
eNFA1_5 -->|"[#42;]"|eNFA1_9
eNFA1_5 -->|"#92;#42;"|eNFA1_13
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_9 -->|"[^/#92;u0000]"|eNFA1_11
eNFA1_12 -->|"#92;#42;"|eNFA1_13
eNFA1_13 -.->|"ε"|eNFA1_14
eNFA1_13 -->|"#92;/"|eNFA1_15
eNFA1_10 -->|"[^/#92;u0000]"|eNFA1_11
eNFA1_11 -.->|"ε"|eNFA1_7
eNFA1_11 -.->|"ε"|eNFA1_6
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_11 -.->|"ε"|eNFA1_4
eNFA1_11 -.->|"ε"|eNFA1_8
eNFA1_11 -->|"[^#42;#92;u0000]"|eNFA1_5
eNFA1_11 -->|"[#42;]"|eNFA1_9
eNFA1_11 -->|"#92;#42;"|eNFA1_13
eNFA1_14 -->|"#92;/"|eNFA1_15
eNFA1_15 -.->|"ε"|eNFA1_17
eNFA1_15 -.->|"ε"|eNFA1_18
eNFA1_15 -.->|"ε"|eNFA1_19
eNFA1_17 -.->|"ε"|eNFA1_18
eNFA1_17 -.->|"ε"|eNFA1_19
eNFA1_18 -.->|"ε"|eNFA1_19
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
NFA1_16("NFA1-16 regex start")
NFA1_1("NFA1-1 char[1]")
NFA1_3("NFA1-3 char[1]")
NFA1_5("NFA1-5 scope[1]")
NFA1_9("NFA1-9 scope[1]")
NFA1_13("NFA1-13 char[1]")
NFA1_11("NFA1-11 scope[1]")
NFA1_15[\"NFA1-15 char[1]"/]
NFA1_16 -->|"#92;/"|NFA1_1
NFA1_1 -->|"#92;#42;"|NFA1_3
NFA1_3 -->|"[^#42;#92;u0000]"|NFA1_5
NFA1_3 -->|"[#42;]"|NFA1_9
NFA1_3 -->|"#92;#42;"|NFA1_13
NFA1_5 -->|"[^#42;#92;u0000]"|NFA1_5
NFA1_5 -->|"[#42;]"|NFA1_9
NFA1_5 -->|"#92;#42;"|NFA1_13
NFA1_9 -->|"[^/#92;u0000]"|NFA1_11
NFA1_13 -->|"#92;/"|NFA1_15
NFA1_11 -->|"[^#42;#92;u0000]"|NFA1_5
NFA1_11 -->|"[#42;]"|NFA1_9
NFA1_11 -->|"#92;#42;"|NFA1_13
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
NFA1_16_0("NFA1-16 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA1_1_1("NFA1-1 char[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA1_3_2("NFA1-3 char[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA1_5_3("NFA1-5 scope[1]")
end
subgraph DFA4["DFA4 2 NFA States"]
NFA1_9_4("NFA1-9 scope[1]")
NFA1_13_5("NFA1-13 char[1]")
end
subgraph DFA5["DFA5 1 NFA States"]
NFA1_15_6[\"NFA1-15 char[1]"/]
end
subgraph DFA6["DFA6 1 NFA States"]
NFA1_11_7("NFA1-11 scope[1]")
end
DFA0 -->|"#92;/"|DFA1
DFA1 -->|"#92;#42;"|DFA2
DFA2 -->|"[^#42;#92;u0000]"|DFA3
DFA2 -->|"[#42;]"|DFA4
DFA3 -->|"[^#42;#92;u0000]"|DFA3
DFA3 -->|"[#42;]"|DFA4
DFA4 -->|"#92;/"|DFA5
DFA4 -->|"[^/#92;u0000]"|DFA6
DFA6 -->|"[^#42;#92;u0000]"|DFA3
DFA6 -->|"[#42;]"|DFA4
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
DFA4{{"DFA4 2 NFA States"}}
DFA5[\"DFA5 1 NFA States"/]
DFA6{{"DFA6 1 NFA States"}}
DFA0 -->|"#92;/"|DFA1
DFA1 -->|"#92;#42;"|DFA2
DFA2 -->|"[^#42;#92;u0000]"|DFA3
DFA2 -->|"[#42;]"|DFA4
DFA3 -->|"[^#42;#92;u0000]"|DFA3
DFA3 -->|"[#42;]"|DFA4
DFA4 -->|"#92;/"|DFA5
DFA4 -->|"[^/#92;u0000]"|DFA6
DFA6 -->|"[^#42;#92;u0000]"|DFA3
DFA6 -->|"[#42;]"|DFA4
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
subgraph miniDFA2["miniDFA2 3 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
DFA3_3{{"DFA3 1 NFA States"}}
DFA6_4{{"DFA6 1 NFA States"}}
end
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA4_5{{"DFA4 2 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA5_6[\"DFA5 1 NFA States"/]
end
miniDFA0 -->|"#92;/"|miniDFA1
miniDFA1 -->|"#92;#42;"|miniDFA2
miniDFA2 -->|"[^#42;#92;u0000]"|miniDFA2
miniDFA2 -->|"[#42;]"|miniDFA3
miniDFA3 -->|"#92;/"|miniDFA4
miniDFA3 -->|"[^/#92;u0000]"|miniDFA2
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
miniDFA2(["miniDFA2 3 DFA States"])
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA0 -->|"#92;/"|miniDFA1
miniDFA1 -->|"#92;#42;"|miniDFA2
miniDFA2 -->|"[^#42;#92;u0000]"|miniDFA2
miniDFA2 -->|"[#42;]"|miniDFA3
miniDFA3 -->|"#92;/"|miniDFA4
miniDFA3 -->|"[^/#92;u0000]"|miniDFA2
```
-------------------------------
