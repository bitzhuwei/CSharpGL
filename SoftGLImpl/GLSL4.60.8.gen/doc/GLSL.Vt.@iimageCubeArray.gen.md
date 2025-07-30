# Vt: 'iimageCubeArray'

patterns[0]: `iimageCubeArray`

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
eNFA0_30[["εNFA0-30 regex start"]]
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
eNFA0_31[["εNFA0-31 regex end"]]
eNFA0_32[["εNFA0-32 post-regex start"]]
eNFA0_33[\"εNFA0-33 post-regex end"/]
eNFA0_30 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"i"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"i"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"m"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"a"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"g"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"e"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_12 -->|"C"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_14
eNFA0_14 -->|"u"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_16 -->|"b"|eNFA0_17
eNFA0_17 -.->|"ε"|eNFA0_18
eNFA0_18 -->|"e"|eNFA0_19
eNFA0_19 -.->|"ε"|eNFA0_20
eNFA0_20 -->|"A"|eNFA0_21
eNFA0_21 -.->|"ε"|eNFA0_22
eNFA0_22 -->|"r"|eNFA0_23
eNFA0_23 -.->|"ε"|eNFA0_24
eNFA0_24 -->|"r"|eNFA0_25
eNFA0_25 -.->|"ε"|eNFA0_26
eNFA0_26 -->|"a"|eNFA0_27
eNFA0_27 -.->|"ε"|eNFA0_28
eNFA0_28 -->|"y"|eNFA0_29
eNFA0_29 -.->|"ε"|eNFA0_31
eNFA0_31 -.->|"ε"|eNFA0_32
eNFA0_32 -.->|"ε"|eNFA0_33
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
eNFA0_30[["εNFA0-30 regex start"]]
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
eNFA0_29[\"εNFA0-29 char[1]"/]
eNFA0_31[\"εNFA0-31 regex end"/]
eNFA0_32[\"εNFA0-32 post-regex start"/]
eNFA0_33[\"εNFA0-33 post-regex end"/]
eNFA0_30 -.->|"ε"|eNFA0_0
eNFA0_30 -->|"i"|eNFA0_1
eNFA0_0 -->|"i"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_1 -->|"i"|eNFA0_3
eNFA0_2 -->|"i"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_3 -->|"m"|eNFA0_5
eNFA0_4 -->|"m"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_5 -->|"a"|eNFA0_7
eNFA0_6 -->|"a"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_7 -->|"g"|eNFA0_9
eNFA0_8 -->|"g"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_9 -->|"e"|eNFA0_11
eNFA0_10 -->|"e"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_11 -->|"C"|eNFA0_13
eNFA0_12 -->|"C"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_14
eNFA0_13 -->|"u"|eNFA0_15
eNFA0_14 -->|"u"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_15 -->|"b"|eNFA0_17
eNFA0_16 -->|"b"|eNFA0_17
eNFA0_17 -.->|"ε"|eNFA0_18
eNFA0_17 -->|"e"|eNFA0_19
eNFA0_18 -->|"e"|eNFA0_19
eNFA0_19 -.->|"ε"|eNFA0_20
eNFA0_19 -->|"A"|eNFA0_21
eNFA0_20 -->|"A"|eNFA0_21
eNFA0_21 -.->|"ε"|eNFA0_22
eNFA0_21 -->|"r"|eNFA0_23
eNFA0_22 -->|"r"|eNFA0_23
eNFA0_23 -.->|"ε"|eNFA0_24
eNFA0_23 -->|"r"|eNFA0_25
eNFA0_24 -->|"r"|eNFA0_25
eNFA0_25 -.->|"ε"|eNFA0_26
eNFA0_25 -->|"a"|eNFA0_27
eNFA0_26 -->|"a"|eNFA0_27
eNFA0_27 -.->|"ε"|eNFA0_28
eNFA0_27 -->|"y"|eNFA0_29
eNFA0_28 -->|"y"|eNFA0_29
eNFA0_29 -.->|"ε"|eNFA0_31
eNFA0_29 -.->|"ε"|eNFA0_32
eNFA0_29 -.->|"ε"|eNFA0_33
eNFA0_31 -.->|"ε"|eNFA0_32
eNFA0_31 -.->|"ε"|eNFA0_33
eNFA0_32 -.->|"ε"|eNFA0_33
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
NFA0_30("NFA0-30 regex start")
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
NFA0_29[\"NFA0-29 char[1]"/]
NFA0_30 -->|"i"|NFA0_1
NFA0_1 -->|"i"|NFA0_3
NFA0_3 -->|"m"|NFA0_5
NFA0_5 -->|"a"|NFA0_7
NFA0_7 -->|"g"|NFA0_9
NFA0_9 -->|"e"|NFA0_11
NFA0_11 -->|"C"|NFA0_13
NFA0_13 -->|"u"|NFA0_15
NFA0_15 -->|"b"|NFA0_17
NFA0_17 -->|"e"|NFA0_19
NFA0_19 -->|"A"|NFA0_21
NFA0_21 -->|"r"|NFA0_23
NFA0_23 -->|"r"|NFA0_25
NFA0_25 -->|"a"|NFA0_27
NFA0_27 -->|"y"|NFA0_29
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
NFA0_30_0("NFA0-30 regex start")
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
NFA0_29_15[\"NFA0-29 char[1]"/]
end
DFA0 -->|"i"|DFA1
DFA1 -->|"i"|DFA2
DFA2 -->|"m"|DFA3
DFA3 -->|"a"|DFA4
DFA4 -->|"g"|DFA5
DFA5 -->|"e"|DFA6
DFA6 -->|"C"|DFA7
DFA7 -->|"u"|DFA8
DFA8 -->|"b"|DFA9
DFA9 -->|"e"|DFA10
DFA10 -->|"A"|DFA11
DFA11 -->|"r"|DFA12
DFA12 -->|"r"|DFA13
DFA13 -->|"a"|DFA14
DFA14 -->|"y"|DFA15
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
DFA15[\"DFA15 1 NFA States"/]
DFA0 -->|"i"|DFA1
DFA1 -->|"i"|DFA2
DFA2 -->|"m"|DFA3
DFA3 -->|"a"|DFA4
DFA4 -->|"g"|DFA5
DFA5 -->|"e"|DFA6
DFA6 -->|"C"|DFA7
DFA7 -->|"u"|DFA8
DFA8 -->|"b"|DFA9
DFA9 -->|"e"|DFA10
DFA10 -->|"A"|DFA11
DFA11 -->|"r"|DFA12
DFA12 -->|"r"|DFA13
DFA13 -->|"a"|DFA14
DFA14 -->|"y"|DFA15
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
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA4_4{{"DFA4 1 NFA States"}}
end
subgraph miniDFA6["miniDFA6 1 DFA States"]
DFA5_5{{"DFA5 1 NFA States"}}
end
subgraph miniDFA8["miniDFA8 1 DFA States"]
DFA6_6{{"DFA6 1 NFA States"}}
end
subgraph miniDFA9["miniDFA9 1 DFA States"]
DFA7_7{{"DFA7 1 NFA States"}}
end
subgraph miniDFA10["miniDFA10 1 DFA States"]
DFA8_8{{"DFA8 1 NFA States"}}
end
subgraph miniDFA7["miniDFA7 1 DFA States"]
DFA9_9{{"DFA9 1 NFA States"}}
end
subgraph miniDFA11["miniDFA11 1 DFA States"]
DFA10_10{{"DFA10 1 NFA States"}}
end
subgraph miniDFA12["miniDFA12 1 DFA States"]
DFA11_11{{"DFA11 1 NFA States"}}
end
subgraph miniDFA13["miniDFA13 1 DFA States"]
DFA12_12{{"DFA12 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA13_13{{"DFA13 1 NFA States"}}
end
subgraph miniDFA14["miniDFA14 1 DFA States"]
DFA14_14{{"DFA14 1 NFA States"}}
end
subgraph miniDFA15["miniDFA15 1 DFA States"]
DFA15_15[\"DFA15 1 NFA States"/]
end
miniDFA0 -->|"i"|miniDFA1
miniDFA1 -->|"i"|miniDFA2
miniDFA2 -->|"m"|miniDFA3
miniDFA3 -->|"a"|miniDFA5
miniDFA5 -->|"g"|miniDFA6
miniDFA6 -->|"e"|miniDFA8
miniDFA8 -->|"C"|miniDFA9
miniDFA9 -->|"u"|miniDFA10
miniDFA10 -->|"b"|miniDFA7
miniDFA7 -->|"e"|miniDFA11
miniDFA11 -->|"A"|miniDFA12
miniDFA12 -->|"r"|miniDFA13
miniDFA13 -->|"r"|miniDFA4
miniDFA4 -->|"a"|miniDFA14
miniDFA14 -->|"y"|miniDFA15
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
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA8(["miniDFA8 1 DFA States"])
miniDFA9(["miniDFA9 1 DFA States"])
miniDFA10(["miniDFA10 1 DFA States"])
miniDFA7(["miniDFA7 1 DFA States"])
miniDFA11(["miniDFA11 1 DFA States"])
miniDFA12(["miniDFA12 1 DFA States"])
miniDFA13(["miniDFA13 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA14(["miniDFA14 1 DFA States"])
miniDFA15(["miniDFA15 1 DFA States"])
miniDFA0 -->|"i"|miniDFA1
miniDFA1 -->|"i"|miniDFA2
miniDFA2 -->|"m"|miniDFA3
miniDFA3 -->|"a"|miniDFA5
miniDFA5 -->|"g"|miniDFA6
miniDFA6 -->|"e"|miniDFA8
miniDFA8 -->|"C"|miniDFA9
miniDFA9 -->|"u"|miniDFA10
miniDFA10 -->|"b"|miniDFA7
miniDFA7 -->|"e"|miniDFA11
miniDFA11 -->|"A"|miniDFA12
miniDFA12 -->|"r"|miniDFA13
miniDFA13 -->|"r"|miniDFA4
miniDFA4 -->|"a"|miniDFA14
miniDFA14 -->|"y"|miniDFA15
```
-------------------------------
pattern: `iimageCubeArray`

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
eNFA1_30[["εNFA1-30 regex start"]]
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
eNFA1_31[["εNFA1-31 regex end"]]
eNFA1_32[["εNFA1-32 post-regex start"]]
eNFA1_33[\"εNFA1-33 post-regex end"/]
eNFA1_30 -.->|"ε"|eNFA1_0
eNFA1_0 -->|"i"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_2 -->|"i"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_4 -->|"m"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_6 -->|"a"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_8 -->|"g"|eNFA1_9
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_10 -->|"e"|eNFA1_11
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_12 -->|"C"|eNFA1_13
eNFA1_13 -.->|"ε"|eNFA1_14
eNFA1_14 -->|"u"|eNFA1_15
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_16 -->|"b"|eNFA1_17
eNFA1_17 -.->|"ε"|eNFA1_18
eNFA1_18 -->|"e"|eNFA1_19
eNFA1_19 -.->|"ε"|eNFA1_20
eNFA1_20 -->|"A"|eNFA1_21
eNFA1_21 -.->|"ε"|eNFA1_22
eNFA1_22 -->|"r"|eNFA1_23
eNFA1_23 -.->|"ε"|eNFA1_24
eNFA1_24 -->|"r"|eNFA1_25
eNFA1_25 -.->|"ε"|eNFA1_26
eNFA1_26 -->|"a"|eNFA1_27
eNFA1_27 -.->|"ε"|eNFA1_28
eNFA1_28 -->|"y"|eNFA1_29
eNFA1_29 -.->|"ε"|eNFA1_31
eNFA1_31 -.->|"ε"|eNFA1_32
eNFA1_32 -.->|"ε"|eNFA1_33
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
eNFA1_30[["εNFA1-30 regex start"]]
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
eNFA1_29[\"εNFA1-29 char[1]"/]
eNFA1_31[\"εNFA1-31 regex end"/]
eNFA1_32[\"εNFA1-32 post-regex start"/]
eNFA1_33[\"εNFA1-33 post-regex end"/]
eNFA1_30 -.->|"ε"|eNFA1_0
eNFA1_30 -->|"i"|eNFA1_1
eNFA1_0 -->|"i"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"i"|eNFA1_3
eNFA1_2 -->|"i"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -->|"m"|eNFA1_5
eNFA1_4 -->|"m"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -->|"a"|eNFA1_7
eNFA1_6 -->|"a"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_7 -->|"g"|eNFA1_9
eNFA1_8 -->|"g"|eNFA1_9
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_9 -->|"e"|eNFA1_11
eNFA1_10 -->|"e"|eNFA1_11
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_11 -->|"C"|eNFA1_13
eNFA1_12 -->|"C"|eNFA1_13
eNFA1_13 -.->|"ε"|eNFA1_14
eNFA1_13 -->|"u"|eNFA1_15
eNFA1_14 -->|"u"|eNFA1_15
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_15 -->|"b"|eNFA1_17
eNFA1_16 -->|"b"|eNFA1_17
eNFA1_17 -.->|"ε"|eNFA1_18
eNFA1_17 -->|"e"|eNFA1_19
eNFA1_18 -->|"e"|eNFA1_19
eNFA1_19 -.->|"ε"|eNFA1_20
eNFA1_19 -->|"A"|eNFA1_21
eNFA1_20 -->|"A"|eNFA1_21
eNFA1_21 -.->|"ε"|eNFA1_22
eNFA1_21 -->|"r"|eNFA1_23
eNFA1_22 -->|"r"|eNFA1_23
eNFA1_23 -.->|"ε"|eNFA1_24
eNFA1_23 -->|"r"|eNFA1_25
eNFA1_24 -->|"r"|eNFA1_25
eNFA1_25 -.->|"ε"|eNFA1_26
eNFA1_25 -->|"a"|eNFA1_27
eNFA1_26 -->|"a"|eNFA1_27
eNFA1_27 -.->|"ε"|eNFA1_28
eNFA1_27 -->|"y"|eNFA1_29
eNFA1_28 -->|"y"|eNFA1_29
eNFA1_29 -.->|"ε"|eNFA1_31
eNFA1_29 -.->|"ε"|eNFA1_32
eNFA1_29 -.->|"ε"|eNFA1_33
eNFA1_31 -.->|"ε"|eNFA1_32
eNFA1_31 -.->|"ε"|eNFA1_33
eNFA1_32 -.->|"ε"|eNFA1_33
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
NFA1_30("NFA1-30 regex start")
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
NFA1_29[\"NFA1-29 char[1]"/]
NFA1_30 -->|"i"|NFA1_1
NFA1_1 -->|"i"|NFA1_3
NFA1_3 -->|"m"|NFA1_5
NFA1_5 -->|"a"|NFA1_7
NFA1_7 -->|"g"|NFA1_9
NFA1_9 -->|"e"|NFA1_11
NFA1_11 -->|"C"|NFA1_13
NFA1_13 -->|"u"|NFA1_15
NFA1_15 -->|"b"|NFA1_17
NFA1_17 -->|"e"|NFA1_19
NFA1_19 -->|"A"|NFA1_21
NFA1_21 -->|"r"|NFA1_23
NFA1_23 -->|"r"|NFA1_25
NFA1_25 -->|"a"|NFA1_27
NFA1_27 -->|"y"|NFA1_29
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
NFA1_30_0("NFA1-30 regex start")
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
NFA1_29_15[\"NFA1-29 char[1]"/]
end
DFA0 -->|"i"|DFA1
DFA1 -->|"i"|DFA2
DFA2 -->|"m"|DFA3
DFA3 -->|"a"|DFA4
DFA4 -->|"g"|DFA5
DFA5 -->|"e"|DFA6
DFA6 -->|"C"|DFA7
DFA7 -->|"u"|DFA8
DFA8 -->|"b"|DFA9
DFA9 -->|"e"|DFA10
DFA10 -->|"A"|DFA11
DFA11 -->|"r"|DFA12
DFA12 -->|"r"|DFA13
DFA13 -->|"a"|DFA14
DFA14 -->|"y"|DFA15
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
DFA15[\"DFA15 1 NFA States"/]
DFA0 -->|"i"|DFA1
DFA1 -->|"i"|DFA2
DFA2 -->|"m"|DFA3
DFA3 -->|"a"|DFA4
DFA4 -->|"g"|DFA5
DFA5 -->|"e"|DFA6
DFA6 -->|"C"|DFA7
DFA7 -->|"u"|DFA8
DFA8 -->|"b"|DFA9
DFA9 -->|"e"|DFA10
DFA10 -->|"A"|DFA11
DFA11 -->|"r"|DFA12
DFA12 -->|"r"|DFA13
DFA13 -->|"a"|DFA14
DFA14 -->|"y"|DFA15
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
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA4_4{{"DFA4 1 NFA States"}}
end
subgraph miniDFA6["miniDFA6 1 DFA States"]
DFA5_5{{"DFA5 1 NFA States"}}
end
subgraph miniDFA8["miniDFA8 1 DFA States"]
DFA6_6{{"DFA6 1 NFA States"}}
end
subgraph miniDFA9["miniDFA9 1 DFA States"]
DFA7_7{{"DFA7 1 NFA States"}}
end
subgraph miniDFA10["miniDFA10 1 DFA States"]
DFA8_8{{"DFA8 1 NFA States"}}
end
subgraph miniDFA7["miniDFA7 1 DFA States"]
DFA9_9{{"DFA9 1 NFA States"}}
end
subgraph miniDFA11["miniDFA11 1 DFA States"]
DFA10_10{{"DFA10 1 NFA States"}}
end
subgraph miniDFA12["miniDFA12 1 DFA States"]
DFA11_11{{"DFA11 1 NFA States"}}
end
subgraph miniDFA13["miniDFA13 1 DFA States"]
DFA12_12{{"DFA12 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 1 DFA States"]
DFA13_13{{"DFA13 1 NFA States"}}
end
subgraph miniDFA14["miniDFA14 1 DFA States"]
DFA14_14{{"DFA14 1 NFA States"}}
end
subgraph miniDFA15["miniDFA15 1 DFA States"]
DFA15_15[\"DFA15 1 NFA States"/]
end
miniDFA0 -->|"i"|miniDFA1
miniDFA1 -->|"i"|miniDFA2
miniDFA2 -->|"m"|miniDFA3
miniDFA3 -->|"a"|miniDFA5
miniDFA5 -->|"g"|miniDFA6
miniDFA6 -->|"e"|miniDFA8
miniDFA8 -->|"C"|miniDFA9
miniDFA9 -->|"u"|miniDFA10
miniDFA10 -->|"b"|miniDFA7
miniDFA7 -->|"e"|miniDFA11
miniDFA11 -->|"A"|miniDFA12
miniDFA12 -->|"r"|miniDFA13
miniDFA13 -->|"r"|miniDFA4
miniDFA4 -->|"a"|miniDFA14
miniDFA14 -->|"y"|miniDFA15
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
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA8(["miniDFA8 1 DFA States"])
miniDFA9(["miniDFA9 1 DFA States"])
miniDFA10(["miniDFA10 1 DFA States"])
miniDFA7(["miniDFA7 1 DFA States"])
miniDFA11(["miniDFA11 1 DFA States"])
miniDFA12(["miniDFA12 1 DFA States"])
miniDFA13(["miniDFA13 1 DFA States"])
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA14(["miniDFA14 1 DFA States"])
miniDFA15(["miniDFA15 1 DFA States"])
miniDFA0 -->|"i"|miniDFA1
miniDFA1 -->|"i"|miniDFA2
miniDFA2 -->|"m"|miniDFA3
miniDFA3 -->|"a"|miniDFA5
miniDFA5 -->|"g"|miniDFA6
miniDFA6 -->|"e"|miniDFA8
miniDFA8 -->|"C"|miniDFA9
miniDFA9 -->|"u"|miniDFA10
miniDFA10 -->|"b"|miniDFA7
miniDFA7 -->|"e"|miniDFA11
miniDFA11 -->|"A"|miniDFA12
miniDFA12 -->|"r"|miniDFA13
miniDFA13 -->|"r"|miniDFA4
miniDFA4 -->|"a"|miniDFA14
miniDFA14 -->|"y"|miniDFA15
```
-------------------------------
