# Vt: 'sampler2DMSArray'

patterns[0]: `sampler2DMSArray`

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
eNFA0_32[["εNFA0-32 regex start"]]
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
eNFA0_20[["εNFA0-20 char{1, 1}"]]
eNFA0_21[["εNFA0-21 char[1]"]]
eNFA0_22[["εNFA0-22 char{1, 1}"]]
eNFA0_23[["εNFA0-23 char[1]"]]
eNFA0_24[["εNFA0-24 char{1, 1}"]]
eNFA0_25[["εNFA0-25 char[1]"]]
eNFA0_26[["εNFA0-26 char{1, 1}"]]
eNFA0_27[["εNFA0-27 char[1]"]]
eNFA0_28[["εNFA0-28 char{1, 1}"]]
eNFA0_29[["εNFA0-29 char[1]"]]
eNFA0_30[["εNFA0-30 char{1, 1}"]]
eNFA0_31[["εNFA0-31 char[1]"]]
eNFA0_33[["εNFA0-33 regex end"]]
eNFA0_34[["εNFA0-34 post-regex start"]]
eNFA0_35[\"εNFA0-35 post-regex end"/]
eNFA0_32 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"s"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"a"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"m"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"p"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"l"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"e"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_12 -->|"r"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_14
eNFA0_14 -->|"2"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_16 -->|"D"|eNFA0_17
eNFA0_17 -.->|"ε"|eNFA0_18
eNFA0_18 -->|"M"|eNFA0_19
eNFA0_19 -.->|"ε"|eNFA0_20
eNFA0_20 -->|"S"|eNFA0_21
eNFA0_21 -.->|"ε"|eNFA0_22
eNFA0_22 -->|"A"|eNFA0_23
eNFA0_23 -.->|"ε"|eNFA0_24
eNFA0_24 -->|"r"|eNFA0_25
eNFA0_25 -.->|"ε"|eNFA0_26
eNFA0_26 -->|"r"|eNFA0_27
eNFA0_27 -.->|"ε"|eNFA0_28
eNFA0_28 -->|"a"|eNFA0_29
eNFA0_29 -.->|"ε"|eNFA0_30
eNFA0_30 -->|"y"|eNFA0_31
eNFA0_31 -.->|"ε"|eNFA0_33
eNFA0_33 -.->|"ε"|eNFA0_34
eNFA0_34 -.->|"ε"|eNFA0_35
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
eNFA0_32[["εNFA0-32 regex start"]]
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
eNFA0_20[["εNFA0-20 char{1, 1}"]]
eNFA0_21[["εNFA0-21 char[1]"]]
eNFA0_22[["εNFA0-22 char{1, 1}"]]
eNFA0_23[["εNFA0-23 char[1]"]]
eNFA0_24[["εNFA0-24 char{1, 1}"]]
eNFA0_25[["εNFA0-25 char[1]"]]
eNFA0_26[["εNFA0-26 char{1, 1}"]]
eNFA0_27[["εNFA0-27 char[1]"]]
eNFA0_28[["εNFA0-28 char{1, 1}"]]
eNFA0_29[["εNFA0-29 char[1]"]]
eNFA0_30[["εNFA0-30 char{1, 1}"]]
eNFA0_31[\"εNFA0-31 char[1]"/]
eNFA0_33[\"εNFA0-33 regex end"/]
eNFA0_34[\"εNFA0-34 post-regex start"/]
eNFA0_35[\"εNFA0-35 post-regex end"/]
eNFA0_32 -.->|"ε"|eNFA0_0
eNFA0_32 -->|"s"|eNFA0_1
eNFA0_0 -->|"s"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_1 -->|"a"|eNFA0_3
eNFA0_2 -->|"a"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_3 -->|"m"|eNFA0_5
eNFA0_4 -->|"m"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_5 -->|"p"|eNFA0_7
eNFA0_6 -->|"p"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_7 -->|"l"|eNFA0_9
eNFA0_8 -->|"l"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_9 -->|"e"|eNFA0_11
eNFA0_10 -->|"e"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_11 -->|"r"|eNFA0_13
eNFA0_12 -->|"r"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_14
eNFA0_13 -->|"2"|eNFA0_15
eNFA0_14 -->|"2"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_15 -->|"D"|eNFA0_17
eNFA0_16 -->|"D"|eNFA0_17
eNFA0_17 -.->|"ε"|eNFA0_18
eNFA0_17 -->|"M"|eNFA0_19
eNFA0_18 -->|"M"|eNFA0_19
eNFA0_19 -.->|"ε"|eNFA0_20
eNFA0_19 -->|"S"|eNFA0_21
eNFA0_20 -->|"S"|eNFA0_21
eNFA0_21 -.->|"ε"|eNFA0_22
eNFA0_21 -->|"A"|eNFA0_23
eNFA0_22 -->|"A"|eNFA0_23
eNFA0_23 -.->|"ε"|eNFA0_24
eNFA0_23 -->|"r"|eNFA0_25
eNFA0_24 -->|"r"|eNFA0_25
eNFA0_25 -.->|"ε"|eNFA0_26
eNFA0_25 -->|"r"|eNFA0_27
eNFA0_26 -->|"r"|eNFA0_27
eNFA0_27 -.->|"ε"|eNFA0_28
eNFA0_27 -->|"a"|eNFA0_29
eNFA0_28 -->|"a"|eNFA0_29
eNFA0_29 -.->|"ε"|eNFA0_30
eNFA0_29 -->|"y"|eNFA0_31
eNFA0_30 -->|"y"|eNFA0_31
eNFA0_31 -.->|"ε"|eNFA0_33
eNFA0_31 -.->|"ε"|eNFA0_34
eNFA0_31 -.->|"ε"|eNFA0_35
eNFA0_33 -.->|"ε"|eNFA0_34
eNFA0_33 -.->|"ε"|eNFA0_35
eNFA0_34 -.->|"ε"|eNFA0_35
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
NFA0_32("NFA0-32 regex start")
NFA0_1("NFA0-1 char[1]")
NFA0_3("NFA0-3 char[1]")
NFA0_5("NFA0-5 char[1]")
NFA0_7("NFA0-7 char[1]")
NFA0_9("NFA0-9 char[1]")
NFA0_11("NFA0-11 char[1]")
NFA0_13("NFA0-13 char[1]")
NFA0_15("NFA0-15 char[1]")
NFA0_17("NFA0-17 char[1]")
NFA0_19("NFA0-19 char[1]")
NFA0_21("NFA0-21 char[1]")
NFA0_23("NFA0-23 char[1]")
NFA0_25("NFA0-25 char[1]")
NFA0_27("NFA0-27 char[1]")
NFA0_29("NFA0-29 char[1]")
NFA0_31[\"NFA0-31 char[1]"/]
NFA0_32 -->|"s"|NFA0_1
NFA0_1 -->|"a"|NFA0_3
NFA0_3 -->|"m"|NFA0_5
NFA0_5 -->|"p"|NFA0_7
NFA0_7 -->|"l"|NFA0_9
NFA0_9 -->|"e"|NFA0_11
NFA0_11 -->|"r"|NFA0_13
NFA0_13 -->|"2"|NFA0_15
NFA0_15 -->|"D"|NFA0_17
NFA0_17 -->|"M"|NFA0_19
NFA0_19 -->|"S"|NFA0_21
NFA0_21 -->|"A"|NFA0_23
NFA0_23 -->|"r"|NFA0_25
NFA0_25 -->|"r"|NFA0_27
NFA0_27 -->|"a"|NFA0_29
NFA0_29 -->|"y"|NFA0_31
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
NFA0_32_0("NFA0-32 regex start")
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
NFA0_7_4("NFA0-7 char[1]")
end
subgraph DFA5["DFA5 1 NFA States"]
NFA0_9_5("NFA0-9 char[1]")
end
subgraph DFA6["DFA6 1 NFA States"]
NFA0_11_6("NFA0-11 char[1]")
end
subgraph DFA7["DFA7 1 NFA States"]
NFA0_13_7("NFA0-13 char[1]")
end
subgraph DFA8["DFA8 1 NFA States"]
NFA0_15_8("NFA0-15 char[1]")
end
subgraph DFA9["DFA9 1 NFA States"]
NFA0_17_9("NFA0-17 char[1]")
end
subgraph DFA10["DFA10 1 NFA States"]
NFA0_19_10("NFA0-19 char[1]")
end
subgraph DFA11["DFA11 1 NFA States"]
NFA0_21_11("NFA0-21 char[1]")
end
subgraph DFA12["DFA12 1 NFA States"]
NFA0_23_12("NFA0-23 char[1]")
end
subgraph DFA13["DFA13 1 NFA States"]
NFA0_25_13("NFA0-25 char[1]")
end
subgraph DFA14["DFA14 1 NFA States"]
NFA0_27_14("NFA0-27 char[1]")
end
subgraph DFA15["DFA15 1 NFA States"]
NFA0_29_15("NFA0-29 char[1]")
end
subgraph DFA16["DFA16 1 NFA States"]
NFA0_31_16[\"NFA0-31 char[1]"/]
end
DFA0 -->|"s"|DFA1
DFA1 -->|"a"|DFA2
DFA2 -->|"m"|DFA3
DFA3 -->|"p"|DFA4
DFA4 -->|"l"|DFA5
DFA5 -->|"e"|DFA6
DFA6 -->|"r"|DFA7
DFA7 -->|"2"|DFA8
DFA8 -->|"D"|DFA9
DFA9 -->|"M"|DFA10
DFA10 -->|"S"|DFA11
DFA11 -->|"A"|DFA12
DFA12 -->|"r"|DFA13
DFA13 -->|"r"|DFA14
DFA14 -->|"a"|DFA15
DFA15 -->|"y"|DFA16
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
DFA6{{"DFA6 1 NFA States"}}
DFA7{{"DFA7 1 NFA States"}}
DFA8{{"DFA8 1 NFA States"}}
DFA9{{"DFA9 1 NFA States"}}
DFA10{{"DFA10 1 NFA States"}}
DFA11{{"DFA11 1 NFA States"}}
DFA12{{"DFA12 1 NFA States"}}
DFA13{{"DFA13 1 NFA States"}}
DFA14{{"DFA14 1 NFA States"}}
DFA15{{"DFA15 1 NFA States"}}
DFA16[\"DFA16 1 NFA States"/]
DFA0 -->|"s"|DFA1
DFA1 -->|"a"|DFA2
DFA2 -->|"m"|DFA3
DFA3 -->|"p"|DFA4
DFA4 -->|"l"|DFA5
DFA5 -->|"e"|DFA6
DFA6 -->|"r"|DFA7
DFA7 -->|"2"|DFA8
DFA8 -->|"D"|DFA9
DFA9 -->|"M"|DFA10
DFA10 -->|"S"|DFA11
DFA11 -->|"A"|DFA12
DFA12 -->|"r"|DFA13
DFA13 -->|"r"|DFA14
DFA14 -->|"a"|DFA15
DFA15 -->|"y"|DFA16
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
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA3_3{{"DFA3 1 NFA States"}}
end
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA4_4{{"DFA4 1 NFA States"}}
end
subgraph miniDFA6["miniDFA6 1 DFA States"]
DFA5_5{{"DFA5 1 NFA States"}}
end
subgraph miniDFA7["miniDFA7 1 DFA States"]
DFA6_6{{"DFA6 1 NFA States"}}
end
subgraph miniDFA10["miniDFA10 1 DFA States"]
DFA7_7{{"DFA7 1 NFA States"}}
end
subgraph miniDFA11["miniDFA11 1 DFA States"]
DFA8_8{{"DFA8 1 NFA States"}}
end
subgraph miniDFA12["miniDFA12 1 DFA States"]
DFA9_9{{"DFA9 1 NFA States"}}
end
subgraph miniDFA13["miniDFA13 1 DFA States"]
DFA10_10{{"DFA10 1 NFA States"}}
end
subgraph miniDFA14["miniDFA14 1 DFA States"]
DFA11_11{{"DFA11 1 NFA States"}}
end
subgraph miniDFA8["miniDFA8 1 DFA States"]
DFA12_12{{"DFA12 1 NFA States"}}
end
subgraph miniDFA9["miniDFA9 1 DFA States"]
DFA13_13{{"DFA13 1 NFA States"}}
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA14_14{{"DFA14 1 NFA States"}}
end
subgraph miniDFA15["miniDFA15 1 DFA States"]
DFA15_15{{"DFA15 1 NFA States"}}
end
subgraph miniDFA16["miniDFA16 1 DFA States"]
DFA16_16[\"DFA16 1 NFA States"/]
end
miniDFA0 -->|"s"|miniDFA1
miniDFA1 -->|"a"|miniDFA3
miniDFA3 -->|"m"|miniDFA4
miniDFA4 -->|"p"|miniDFA5
miniDFA5 -->|"l"|miniDFA6
miniDFA6 -->|"e"|miniDFA7
miniDFA7 -->|"r"|miniDFA10
miniDFA10 -->|"2"|miniDFA11
miniDFA11 -->|"D"|miniDFA12
miniDFA12 -->|"M"|miniDFA13
miniDFA13 -->|"S"|miniDFA14
miniDFA14 -->|"A"|miniDFA8
miniDFA8 -->|"r"|miniDFA9
miniDFA9 -->|"r"|miniDFA2
miniDFA2 -->|"a"|miniDFA15
miniDFA15 -->|"y"|miniDFA16
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
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA7(["miniDFA7 1 DFA States"])
miniDFA10(["miniDFA10 1 DFA States"])
miniDFA11(["miniDFA11 1 DFA States"])
miniDFA12(["miniDFA12 1 DFA States"])
miniDFA13(["miniDFA13 1 DFA States"])
miniDFA14(["miniDFA14 1 DFA States"])
miniDFA8(["miniDFA8 1 DFA States"])
miniDFA9(["miniDFA9 1 DFA States"])
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA15(["miniDFA15 1 DFA States"])
miniDFA16(["miniDFA16 1 DFA States"])
miniDFA0 -->|"s"|miniDFA1
miniDFA1 -->|"a"|miniDFA3
miniDFA3 -->|"m"|miniDFA4
miniDFA4 -->|"p"|miniDFA5
miniDFA5 -->|"l"|miniDFA6
miniDFA6 -->|"e"|miniDFA7
miniDFA7 -->|"r"|miniDFA10
miniDFA10 -->|"2"|miniDFA11
miniDFA11 -->|"D"|miniDFA12
miniDFA12 -->|"M"|miniDFA13
miniDFA13 -->|"S"|miniDFA14
miniDFA14 -->|"A"|miniDFA8
miniDFA8 -->|"r"|miniDFA9
miniDFA9 -->|"r"|miniDFA2
miniDFA2 -->|"a"|miniDFA15
miniDFA15 -->|"y"|miniDFA16
```
-------------------------------
pattern: `sampler2DMSArray`

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
eNFA1_32[["εNFA1-32 regex start"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA1_4[["εNFA1-4 char{1, 1}"]]
eNFA1_5[["εNFA1-5 char[1]"]]
eNFA1_6[["εNFA1-6 char{1, 1}"]]
eNFA1_7[["εNFA1-7 char[1]"]]
eNFA1_8[["εNFA1-8 char{1, 1}"]]
eNFA1_9[["εNFA1-9 char[1]"]]
eNFA1_10[["εNFA1-10 char{1, 1}"]]
eNFA1_11[["εNFA1-11 char[1]"]]
eNFA1_12[["εNFA1-12 char{1, 1}"]]
eNFA1_13[["εNFA1-13 char[1]"]]
eNFA1_14[["εNFA1-14 char{1, 1}"]]
eNFA1_15[["εNFA1-15 char[1]"]]
eNFA1_16[["εNFA1-16 char{1, 1}"]]
eNFA1_17[["εNFA1-17 char[1]"]]
eNFA1_18[["εNFA1-18 char{1, 1}"]]
eNFA1_19[["εNFA1-19 char[1]"]]
eNFA1_20[["εNFA1-20 char{1, 1}"]]
eNFA1_21[["εNFA1-21 char[1]"]]
eNFA1_22[["εNFA1-22 char{1, 1}"]]
eNFA1_23[["εNFA1-23 char[1]"]]
eNFA1_24[["εNFA1-24 char{1, 1}"]]
eNFA1_25[["εNFA1-25 char[1]"]]
eNFA1_26[["εNFA1-26 char{1, 1}"]]
eNFA1_27[["εNFA1-27 char[1]"]]
eNFA1_28[["εNFA1-28 char{1, 1}"]]
eNFA1_29[["εNFA1-29 char[1]"]]
eNFA1_30[["εNFA1-30 char{1, 1}"]]
eNFA1_31[["εNFA1-31 char[1]"]]
eNFA1_33[["εNFA1-33 regex end"]]
eNFA1_34[["εNFA1-34 post-regex start"]]
eNFA1_35[\"εNFA1-35 post-regex end"/]
eNFA1_32 -.->|"ε"|eNFA1_0
eNFA1_0 -->|"s"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_2 -->|"a"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_4 -->|"m"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_6 -->|"p"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_8 -->|"l"|eNFA1_9
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_10 -->|"e"|eNFA1_11
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_12 -->|"r"|eNFA1_13
eNFA1_13 -.->|"ε"|eNFA1_14
eNFA1_14 -->|"2"|eNFA1_15
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_16 -->|"D"|eNFA1_17
eNFA1_17 -.->|"ε"|eNFA1_18
eNFA1_18 -->|"M"|eNFA1_19
eNFA1_19 -.->|"ε"|eNFA1_20
eNFA1_20 -->|"S"|eNFA1_21
eNFA1_21 -.->|"ε"|eNFA1_22
eNFA1_22 -->|"A"|eNFA1_23
eNFA1_23 -.->|"ε"|eNFA1_24
eNFA1_24 -->|"r"|eNFA1_25
eNFA1_25 -.->|"ε"|eNFA1_26
eNFA1_26 -->|"r"|eNFA1_27
eNFA1_27 -.->|"ε"|eNFA1_28
eNFA1_28 -->|"a"|eNFA1_29
eNFA1_29 -.->|"ε"|eNFA1_30
eNFA1_30 -->|"y"|eNFA1_31
eNFA1_31 -.->|"ε"|eNFA1_33
eNFA1_33 -.->|"ε"|eNFA1_34
eNFA1_34 -.->|"ε"|eNFA1_35
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
eNFA1_32[["εNFA1-32 regex start"]]
eNFA1_0[["εNFA1-0 char{1, 1}"]]
eNFA1_1[["εNFA1-1 char[1]"]]
eNFA1_2[["εNFA1-2 char{1, 1}"]]
eNFA1_3[["εNFA1-3 char[1]"]]
eNFA1_4[["εNFA1-4 char{1, 1}"]]
eNFA1_5[["εNFA1-5 char[1]"]]
eNFA1_6[["εNFA1-6 char{1, 1}"]]
eNFA1_7[["εNFA1-7 char[1]"]]
eNFA1_8[["εNFA1-8 char{1, 1}"]]
eNFA1_9[["εNFA1-9 char[1]"]]
eNFA1_10[["εNFA1-10 char{1, 1}"]]
eNFA1_11[["εNFA1-11 char[1]"]]
eNFA1_12[["εNFA1-12 char{1, 1}"]]
eNFA1_13[["εNFA1-13 char[1]"]]
eNFA1_14[["εNFA1-14 char{1, 1}"]]
eNFA1_15[["εNFA1-15 char[1]"]]
eNFA1_16[["εNFA1-16 char{1, 1}"]]
eNFA1_17[["εNFA1-17 char[1]"]]
eNFA1_18[["εNFA1-18 char{1, 1}"]]
eNFA1_19[["εNFA1-19 char[1]"]]
eNFA1_20[["εNFA1-20 char{1, 1}"]]
eNFA1_21[["εNFA1-21 char[1]"]]
eNFA1_22[["εNFA1-22 char{1, 1}"]]
eNFA1_23[["εNFA1-23 char[1]"]]
eNFA1_24[["εNFA1-24 char{1, 1}"]]
eNFA1_25[["εNFA1-25 char[1]"]]
eNFA1_26[["εNFA1-26 char{1, 1}"]]
eNFA1_27[["εNFA1-27 char[1]"]]
eNFA1_28[["εNFA1-28 char{1, 1}"]]
eNFA1_29[["εNFA1-29 char[1]"]]
eNFA1_30[["εNFA1-30 char{1, 1}"]]
eNFA1_31[\"εNFA1-31 char[1]"/]
eNFA1_33[\"εNFA1-33 regex end"/]
eNFA1_34[\"εNFA1-34 post-regex start"/]
eNFA1_35[\"εNFA1-35 post-regex end"/]
eNFA1_32 -.->|"ε"|eNFA1_0
eNFA1_32 -->|"s"|eNFA1_1
eNFA1_0 -->|"s"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"a"|eNFA1_3
eNFA1_2 -->|"a"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -->|"m"|eNFA1_5
eNFA1_4 -->|"m"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -->|"p"|eNFA1_7
eNFA1_6 -->|"p"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_7 -->|"l"|eNFA1_9
eNFA1_8 -->|"l"|eNFA1_9
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_9 -->|"e"|eNFA1_11
eNFA1_10 -->|"e"|eNFA1_11
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_11 -->|"r"|eNFA1_13
eNFA1_12 -->|"r"|eNFA1_13
eNFA1_13 -.->|"ε"|eNFA1_14
eNFA1_13 -->|"2"|eNFA1_15
eNFA1_14 -->|"2"|eNFA1_15
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_15 -->|"D"|eNFA1_17
eNFA1_16 -->|"D"|eNFA1_17
eNFA1_17 -.->|"ε"|eNFA1_18
eNFA1_17 -->|"M"|eNFA1_19
eNFA1_18 -->|"M"|eNFA1_19
eNFA1_19 -.->|"ε"|eNFA1_20
eNFA1_19 -->|"S"|eNFA1_21
eNFA1_20 -->|"S"|eNFA1_21
eNFA1_21 -.->|"ε"|eNFA1_22
eNFA1_21 -->|"A"|eNFA1_23
eNFA1_22 -->|"A"|eNFA1_23
eNFA1_23 -.->|"ε"|eNFA1_24
eNFA1_23 -->|"r"|eNFA1_25
eNFA1_24 -->|"r"|eNFA1_25
eNFA1_25 -.->|"ε"|eNFA1_26
eNFA1_25 -->|"r"|eNFA1_27
eNFA1_26 -->|"r"|eNFA1_27
eNFA1_27 -.->|"ε"|eNFA1_28
eNFA1_27 -->|"a"|eNFA1_29
eNFA1_28 -->|"a"|eNFA1_29
eNFA1_29 -.->|"ε"|eNFA1_30
eNFA1_29 -->|"y"|eNFA1_31
eNFA1_30 -->|"y"|eNFA1_31
eNFA1_31 -.->|"ε"|eNFA1_33
eNFA1_31 -.->|"ε"|eNFA1_34
eNFA1_31 -.->|"ε"|eNFA1_35
eNFA1_33 -.->|"ε"|eNFA1_34
eNFA1_33 -.->|"ε"|eNFA1_35
eNFA1_34 -.->|"ε"|eNFA1_35
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
NFA1_32("NFA1-32 regex start")
NFA1_1("NFA1-1 char[1]")
NFA1_3("NFA1-3 char[1]")
NFA1_5("NFA1-5 char[1]")
NFA1_7("NFA1-7 char[1]")
NFA1_9("NFA1-9 char[1]")
NFA1_11("NFA1-11 char[1]")
NFA1_13("NFA1-13 char[1]")
NFA1_15("NFA1-15 char[1]")
NFA1_17("NFA1-17 char[1]")
NFA1_19("NFA1-19 char[1]")
NFA1_21("NFA1-21 char[1]")
NFA1_23("NFA1-23 char[1]")
NFA1_25("NFA1-25 char[1]")
NFA1_27("NFA1-27 char[1]")
NFA1_29("NFA1-29 char[1]")
NFA1_31[\"NFA1-31 char[1]"/]
NFA1_32 -->|"s"|NFA1_1
NFA1_1 -->|"a"|NFA1_3
NFA1_3 -->|"m"|NFA1_5
NFA1_5 -->|"p"|NFA1_7
NFA1_7 -->|"l"|NFA1_9
NFA1_9 -->|"e"|NFA1_11
NFA1_11 -->|"r"|NFA1_13
NFA1_13 -->|"2"|NFA1_15
NFA1_15 -->|"D"|NFA1_17
NFA1_17 -->|"M"|NFA1_19
NFA1_19 -->|"S"|NFA1_21
NFA1_21 -->|"A"|NFA1_23
NFA1_23 -->|"r"|NFA1_25
NFA1_25 -->|"r"|NFA1_27
NFA1_27 -->|"a"|NFA1_29
NFA1_29 -->|"y"|NFA1_31
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
NFA1_32_0("NFA1-32 regex start")
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
NFA1_9_5("NFA1-9 char[1]")
end
subgraph DFA6["DFA6 1 NFA States"]
NFA1_11_6("NFA1-11 char[1]")
end
subgraph DFA7["DFA7 1 NFA States"]
NFA1_13_7("NFA1-13 char[1]")
end
subgraph DFA8["DFA8 1 NFA States"]
NFA1_15_8("NFA1-15 char[1]")
end
subgraph DFA9["DFA9 1 NFA States"]
NFA1_17_9("NFA1-17 char[1]")
end
subgraph DFA10["DFA10 1 NFA States"]
NFA1_19_10("NFA1-19 char[1]")
end
subgraph DFA11["DFA11 1 NFA States"]
NFA1_21_11("NFA1-21 char[1]")
end
subgraph DFA12["DFA12 1 NFA States"]
NFA1_23_12("NFA1-23 char[1]")
end
subgraph DFA13["DFA13 1 NFA States"]
NFA1_25_13("NFA1-25 char[1]")
end
subgraph DFA14["DFA14 1 NFA States"]
NFA1_27_14("NFA1-27 char[1]")
end
subgraph DFA15["DFA15 1 NFA States"]
NFA1_29_15("NFA1-29 char[1]")
end
subgraph DFA16["DFA16 1 NFA States"]
NFA1_31_16[\"NFA1-31 char[1]"/]
end
DFA0 -->|"s"|DFA1
DFA1 -->|"a"|DFA2
DFA2 -->|"m"|DFA3
DFA3 -->|"p"|DFA4
DFA4 -->|"l"|DFA5
DFA5 -->|"e"|DFA6
DFA6 -->|"r"|DFA7
DFA7 -->|"2"|DFA8
DFA8 -->|"D"|DFA9
DFA9 -->|"M"|DFA10
DFA10 -->|"S"|DFA11
DFA11 -->|"A"|DFA12
DFA12 -->|"r"|DFA13
DFA13 -->|"r"|DFA14
DFA14 -->|"a"|DFA15
DFA15 -->|"y"|DFA16
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
DFA6{{"DFA6 1 NFA States"}}
DFA7{{"DFA7 1 NFA States"}}
DFA8{{"DFA8 1 NFA States"}}
DFA9{{"DFA9 1 NFA States"}}
DFA10{{"DFA10 1 NFA States"}}
DFA11{{"DFA11 1 NFA States"}}
DFA12{{"DFA12 1 NFA States"}}
DFA13{{"DFA13 1 NFA States"}}
DFA14{{"DFA14 1 NFA States"}}
DFA15{{"DFA15 1 NFA States"}}
DFA16[\"DFA16 1 NFA States"/]
DFA0 -->|"s"|DFA1
DFA1 -->|"a"|DFA2
DFA2 -->|"m"|DFA3
DFA3 -->|"p"|DFA4
DFA4 -->|"l"|DFA5
DFA5 -->|"e"|DFA6
DFA6 -->|"r"|DFA7
DFA7 -->|"2"|DFA8
DFA8 -->|"D"|DFA9
DFA9 -->|"M"|DFA10
DFA10 -->|"S"|DFA11
DFA11 -->|"A"|DFA12
DFA12 -->|"r"|DFA13
DFA13 -->|"r"|DFA14
DFA14 -->|"a"|DFA15
DFA15 -->|"y"|DFA16
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
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA3_3{{"DFA3 1 NFA States"}}
end
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA4_4{{"DFA4 1 NFA States"}}
end
subgraph miniDFA6["miniDFA6 1 DFA States"]
DFA5_5{{"DFA5 1 NFA States"}}
end
subgraph miniDFA7["miniDFA7 1 DFA States"]
DFA6_6{{"DFA6 1 NFA States"}}
end
subgraph miniDFA10["miniDFA10 1 DFA States"]
DFA7_7{{"DFA7 1 NFA States"}}
end
subgraph miniDFA11["miniDFA11 1 DFA States"]
DFA8_8{{"DFA8 1 NFA States"}}
end
subgraph miniDFA12["miniDFA12 1 DFA States"]
DFA9_9{{"DFA9 1 NFA States"}}
end
subgraph miniDFA13["miniDFA13 1 DFA States"]
DFA10_10{{"DFA10 1 NFA States"}}
end
subgraph miniDFA14["miniDFA14 1 DFA States"]
DFA11_11{{"DFA11 1 NFA States"}}
end
subgraph miniDFA8["miniDFA8 1 DFA States"]
DFA12_12{{"DFA12 1 NFA States"}}
end
subgraph miniDFA9["miniDFA9 1 DFA States"]
DFA13_13{{"DFA13 1 NFA States"}}
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA14_14{{"DFA14 1 NFA States"}}
end
subgraph miniDFA15["miniDFA15 1 DFA States"]
DFA15_15{{"DFA15 1 NFA States"}}
end
subgraph miniDFA16["miniDFA16 1 DFA States"]
DFA16_16[\"DFA16 1 NFA States"/]
end
miniDFA0 -->|"s"|miniDFA1
miniDFA1 -->|"a"|miniDFA3
miniDFA3 -->|"m"|miniDFA4
miniDFA4 -->|"p"|miniDFA5
miniDFA5 -->|"l"|miniDFA6
miniDFA6 -->|"e"|miniDFA7
miniDFA7 -->|"r"|miniDFA10
miniDFA10 -->|"2"|miniDFA11
miniDFA11 -->|"D"|miniDFA12
miniDFA12 -->|"M"|miniDFA13
miniDFA13 -->|"S"|miniDFA14
miniDFA14 -->|"A"|miniDFA8
miniDFA8 -->|"r"|miniDFA9
miniDFA9 -->|"r"|miniDFA2
miniDFA2 -->|"a"|miniDFA15
miniDFA15 -->|"y"|miniDFA16
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
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA7(["miniDFA7 1 DFA States"])
miniDFA10(["miniDFA10 1 DFA States"])
miniDFA11(["miniDFA11 1 DFA States"])
miniDFA12(["miniDFA12 1 DFA States"])
miniDFA13(["miniDFA13 1 DFA States"])
miniDFA14(["miniDFA14 1 DFA States"])
miniDFA8(["miniDFA8 1 DFA States"])
miniDFA9(["miniDFA9 1 DFA States"])
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA15(["miniDFA15 1 DFA States"])
miniDFA16(["miniDFA16 1 DFA States"])
miniDFA0 -->|"s"|miniDFA1
miniDFA1 -->|"a"|miniDFA3
miniDFA3 -->|"m"|miniDFA4
miniDFA4 -->|"p"|miniDFA5
miniDFA5 -->|"l"|miniDFA6
miniDFA6 -->|"e"|miniDFA7
miniDFA7 -->|"r"|miniDFA10
miniDFA10 -->|"2"|miniDFA11
miniDFA11 -->|"D"|miniDFA12
miniDFA12 -->|"M"|miniDFA13
miniDFA13 -->|"S"|miniDFA14
miniDFA14 -->|"A"|miniDFA8
miniDFA8 -->|"r"|miniDFA9
miniDFA9 -->|"r"|miniDFA2
miniDFA2 -->|"a"|miniDFA15
miniDFA15 -->|"y"|miniDFA16
```
-------------------------------
