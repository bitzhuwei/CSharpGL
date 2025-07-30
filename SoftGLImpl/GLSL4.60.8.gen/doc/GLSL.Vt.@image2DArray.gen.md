# Vt: 'image2DArray'

patterns[0]: `image2DArray`

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
eNFA0_24[["εNFA0-24 regex start"]]
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
eNFA0_25[["εNFA0-25 regex end"]]
eNFA0_26[["εNFA0-26 post-regex start"]]
eNFA0_27[\"εNFA0-27 post-regex end"/]
eNFA0_24 -.->|"ε"|eNFA0_0
eNFA0_0 -->|"i"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_2 -->|"m"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_4 -->|"a"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_6 -->|"g"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"e"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_10 -->|"2"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_12 -->|"D"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_14
eNFA0_14 -->|"A"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_16 -->|"r"|eNFA0_17
eNFA0_17 -.->|"ε"|eNFA0_18
eNFA0_18 -->|"r"|eNFA0_19
eNFA0_19 -.->|"ε"|eNFA0_20
eNFA0_20 -->|"a"|eNFA0_21
eNFA0_21 -.->|"ε"|eNFA0_22
eNFA0_22 -->|"y"|eNFA0_23
eNFA0_23 -.->|"ε"|eNFA0_25
eNFA0_25 -.->|"ε"|eNFA0_26
eNFA0_26 -.->|"ε"|eNFA0_27
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
eNFA0_24[["εNFA0-24 regex start"]]
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
eNFA0_23[\"εNFA0-23 char[1]"/]
eNFA0_25[\"εNFA0-25 regex end"/]
eNFA0_26[\"εNFA0-26 post-regex start"/]
eNFA0_27[\"εNFA0-27 post-regex end"/]
eNFA0_24 -.->|"ε"|eNFA0_0
eNFA0_24 -->|"i"|eNFA0_1
eNFA0_0 -->|"i"|eNFA0_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_1 -->|"m"|eNFA0_3
eNFA0_2 -->|"m"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_3 -->|"a"|eNFA0_5
eNFA0_4 -->|"a"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_5 -->|"g"|eNFA0_7
eNFA0_6 -->|"g"|eNFA0_7
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_7 -->|"e"|eNFA0_9
eNFA0_8 -->|"e"|eNFA0_9
eNFA0_9 -.->|"ε"|eNFA0_10
eNFA0_9 -->|"2"|eNFA0_11
eNFA0_10 -->|"2"|eNFA0_11
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_11 -->|"D"|eNFA0_13
eNFA0_12 -->|"D"|eNFA0_13
eNFA0_13 -.->|"ε"|eNFA0_14
eNFA0_13 -->|"A"|eNFA0_15
eNFA0_14 -->|"A"|eNFA0_15
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_15 -->|"r"|eNFA0_17
eNFA0_16 -->|"r"|eNFA0_17
eNFA0_17 -.->|"ε"|eNFA0_18
eNFA0_17 -->|"r"|eNFA0_19
eNFA0_18 -->|"r"|eNFA0_19
eNFA0_19 -.->|"ε"|eNFA0_20
eNFA0_19 -->|"a"|eNFA0_21
eNFA0_20 -->|"a"|eNFA0_21
eNFA0_21 -.->|"ε"|eNFA0_22
eNFA0_21 -->|"y"|eNFA0_23
eNFA0_22 -->|"y"|eNFA0_23
eNFA0_23 -.->|"ε"|eNFA0_25
eNFA0_23 -.->|"ε"|eNFA0_26
eNFA0_23 -.->|"ε"|eNFA0_27
eNFA0_25 -.->|"ε"|eNFA0_26
eNFA0_25 -.->|"ε"|eNFA0_27
eNFA0_26 -.->|"ε"|eNFA0_27
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
NFA0_24("NFA0-24 regex start")
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
NFA0_23[\"NFA0-23 char[1]"/]
NFA0_24 -->|"i"|NFA0_1
NFA0_1 -->|"m"|NFA0_3
NFA0_3 -->|"a"|NFA0_5
NFA0_5 -->|"g"|NFA0_7
NFA0_7 -->|"e"|NFA0_9
NFA0_9 -->|"2"|NFA0_11
NFA0_11 -->|"D"|NFA0_13
NFA0_13 -->|"A"|NFA0_15
NFA0_15 -->|"r"|NFA0_17
NFA0_17 -->|"r"|NFA0_19
NFA0_19 -->|"a"|NFA0_21
NFA0_21 -->|"y"|NFA0_23
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
NFA0_24_0("NFA0-24 regex start")
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
NFA0_23_12[\"NFA0-23 char[1]"/]
end
DFA0 -->|"i"|DFA1
DFA1 -->|"m"|DFA2
DFA2 -->|"a"|DFA3
DFA3 -->|"g"|DFA4
DFA4 -->|"e"|DFA5
DFA5 -->|"2"|DFA6
DFA6 -->|"D"|DFA7
DFA7 -->|"A"|DFA8
DFA8 -->|"r"|DFA9
DFA9 -->|"r"|DFA10
DFA10 -->|"a"|DFA11
DFA11 -->|"y"|DFA12
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
DFA12[\"DFA12 1 NFA States"/]
DFA0 -->|"i"|DFA1
DFA1 -->|"m"|DFA2
DFA2 -->|"a"|DFA3
DFA3 -->|"g"|DFA4
DFA4 -->|"e"|DFA5
DFA5 -->|"2"|DFA6
DFA6 -->|"D"|DFA7
DFA7 -->|"A"|DFA8
DFA8 -->|"r"|DFA9
DFA9 -->|"r"|DFA10
DFA10 -->|"a"|DFA11
DFA11 -->|"y"|DFA12
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
subgraph miniDFA8["miniDFA8 1 DFA States"]
DFA7_7{{"DFA7 1 NFA States"}}
end
subgraph miniDFA9["miniDFA9 1 DFA States"]
DFA8_8{{"DFA8 1 NFA States"}}
end
subgraph miniDFA10["miniDFA10 1 DFA States"]
DFA9_9{{"DFA9 1 NFA States"}}
end
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA10_10{{"DFA10 1 NFA States"}}
end
subgraph miniDFA11["miniDFA11 1 DFA States"]
DFA11_11{{"DFA11 1 NFA States"}}
end
subgraph miniDFA12["miniDFA12 1 DFA States"]
DFA12_12[\"DFA12 1 NFA States"/]
end
miniDFA0 -->|"i"|miniDFA1
miniDFA1 -->|"m"|miniDFA2
miniDFA2 -->|"a"|miniDFA4
miniDFA4 -->|"g"|miniDFA5
miniDFA5 -->|"e"|miniDFA6
miniDFA6 -->|"2"|miniDFA7
miniDFA7 -->|"D"|miniDFA8
miniDFA8 -->|"A"|miniDFA9
miniDFA9 -->|"r"|miniDFA10
miniDFA10 -->|"r"|miniDFA3
miniDFA3 -->|"a"|miniDFA11
miniDFA11 -->|"y"|miniDFA12
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
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA7(["miniDFA7 1 DFA States"])
miniDFA8(["miniDFA8 1 DFA States"])
miniDFA9(["miniDFA9 1 DFA States"])
miniDFA10(["miniDFA10 1 DFA States"])
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA11(["miniDFA11 1 DFA States"])
miniDFA12(["miniDFA12 1 DFA States"])
miniDFA0 -->|"i"|miniDFA1
miniDFA1 -->|"m"|miniDFA2
miniDFA2 -->|"a"|miniDFA4
miniDFA4 -->|"g"|miniDFA5
miniDFA5 -->|"e"|miniDFA6
miniDFA6 -->|"2"|miniDFA7
miniDFA7 -->|"D"|miniDFA8
miniDFA8 -->|"A"|miniDFA9
miniDFA9 -->|"r"|miniDFA10
miniDFA10 -->|"r"|miniDFA3
miniDFA3 -->|"a"|miniDFA11
miniDFA11 -->|"y"|miniDFA12
```
-------------------------------
pattern: `image2DArray`

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
eNFA1_24[["εNFA1-24 regex start"]]
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
eNFA1_25[["εNFA1-25 regex end"]]
eNFA1_26[["εNFA1-26 post-regex start"]]
eNFA1_27[\"εNFA1-27 post-regex end"/]
eNFA1_24 -.->|"ε"|eNFA1_0
eNFA1_0 -->|"i"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_2 -->|"m"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_4 -->|"a"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_6 -->|"g"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_8 -->|"e"|eNFA1_9
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_10 -->|"2"|eNFA1_11
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_12 -->|"D"|eNFA1_13
eNFA1_13 -.->|"ε"|eNFA1_14
eNFA1_14 -->|"A"|eNFA1_15
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_16 -->|"r"|eNFA1_17
eNFA1_17 -.->|"ε"|eNFA1_18
eNFA1_18 -->|"r"|eNFA1_19
eNFA1_19 -.->|"ε"|eNFA1_20
eNFA1_20 -->|"a"|eNFA1_21
eNFA1_21 -.->|"ε"|eNFA1_22
eNFA1_22 -->|"y"|eNFA1_23
eNFA1_23 -.->|"ε"|eNFA1_25
eNFA1_25 -.->|"ε"|eNFA1_26
eNFA1_26 -.->|"ε"|eNFA1_27
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
eNFA1_24[["εNFA1-24 regex start"]]
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
eNFA1_23[\"εNFA1-23 char[1]"/]
eNFA1_25[\"εNFA1-25 regex end"/]
eNFA1_26[\"εNFA1-26 post-regex start"/]
eNFA1_27[\"εNFA1-27 post-regex end"/]
eNFA1_24 -.->|"ε"|eNFA1_0
eNFA1_24 -->|"i"|eNFA1_1
eNFA1_0 -->|"i"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"m"|eNFA1_3
eNFA1_2 -->|"m"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -->|"a"|eNFA1_5
eNFA1_4 -->|"a"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -->|"g"|eNFA1_7
eNFA1_6 -->|"g"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_7 -->|"e"|eNFA1_9
eNFA1_8 -->|"e"|eNFA1_9
eNFA1_9 -.->|"ε"|eNFA1_10
eNFA1_9 -->|"2"|eNFA1_11
eNFA1_10 -->|"2"|eNFA1_11
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_11 -->|"D"|eNFA1_13
eNFA1_12 -->|"D"|eNFA1_13
eNFA1_13 -.->|"ε"|eNFA1_14
eNFA1_13 -->|"A"|eNFA1_15
eNFA1_14 -->|"A"|eNFA1_15
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_15 -->|"r"|eNFA1_17
eNFA1_16 -->|"r"|eNFA1_17
eNFA1_17 -.->|"ε"|eNFA1_18
eNFA1_17 -->|"r"|eNFA1_19
eNFA1_18 -->|"r"|eNFA1_19
eNFA1_19 -.->|"ε"|eNFA1_20
eNFA1_19 -->|"a"|eNFA1_21
eNFA1_20 -->|"a"|eNFA1_21
eNFA1_21 -.->|"ε"|eNFA1_22
eNFA1_21 -->|"y"|eNFA1_23
eNFA1_22 -->|"y"|eNFA1_23
eNFA1_23 -.->|"ε"|eNFA1_25
eNFA1_23 -.->|"ε"|eNFA1_26
eNFA1_23 -.->|"ε"|eNFA1_27
eNFA1_25 -.->|"ε"|eNFA1_26
eNFA1_25 -.->|"ε"|eNFA1_27
eNFA1_26 -.->|"ε"|eNFA1_27
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
NFA1_24("NFA1-24 regex start")
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
NFA1_23[\"NFA1-23 char[1]"/]
NFA1_24 -->|"i"|NFA1_1
NFA1_1 -->|"m"|NFA1_3
NFA1_3 -->|"a"|NFA1_5
NFA1_5 -->|"g"|NFA1_7
NFA1_7 -->|"e"|NFA1_9
NFA1_9 -->|"2"|NFA1_11
NFA1_11 -->|"D"|NFA1_13
NFA1_13 -->|"A"|NFA1_15
NFA1_15 -->|"r"|NFA1_17
NFA1_17 -->|"r"|NFA1_19
NFA1_19 -->|"a"|NFA1_21
NFA1_21 -->|"y"|NFA1_23
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
NFA1_24_0("NFA1-24 regex start")
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
NFA1_23_12[\"NFA1-23 char[1]"/]
end
DFA0 -->|"i"|DFA1
DFA1 -->|"m"|DFA2
DFA2 -->|"a"|DFA3
DFA3 -->|"g"|DFA4
DFA4 -->|"e"|DFA5
DFA5 -->|"2"|DFA6
DFA6 -->|"D"|DFA7
DFA7 -->|"A"|DFA8
DFA8 -->|"r"|DFA9
DFA9 -->|"r"|DFA10
DFA10 -->|"a"|DFA11
DFA11 -->|"y"|DFA12
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
DFA12[\"DFA12 1 NFA States"/]
DFA0 -->|"i"|DFA1
DFA1 -->|"m"|DFA2
DFA2 -->|"a"|DFA3
DFA3 -->|"g"|DFA4
DFA4 -->|"e"|DFA5
DFA5 -->|"2"|DFA6
DFA6 -->|"D"|DFA7
DFA7 -->|"A"|DFA8
DFA8 -->|"r"|DFA9
DFA9 -->|"r"|DFA10
DFA10 -->|"a"|DFA11
DFA11 -->|"y"|DFA12
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
subgraph miniDFA8["miniDFA8 1 DFA States"]
DFA7_7{{"DFA7 1 NFA States"}}
end
subgraph miniDFA9["miniDFA9 1 DFA States"]
DFA8_8{{"DFA8 1 NFA States"}}
end
subgraph miniDFA10["miniDFA10 1 DFA States"]
DFA9_9{{"DFA9 1 NFA States"}}
end
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA10_10{{"DFA10 1 NFA States"}}
end
subgraph miniDFA11["miniDFA11 1 DFA States"]
DFA11_11{{"DFA11 1 NFA States"}}
end
subgraph miniDFA12["miniDFA12 1 DFA States"]
DFA12_12[\"DFA12 1 NFA States"/]
end
miniDFA0 -->|"i"|miniDFA1
miniDFA1 -->|"m"|miniDFA2
miniDFA2 -->|"a"|miniDFA4
miniDFA4 -->|"g"|miniDFA5
miniDFA5 -->|"e"|miniDFA6
miniDFA6 -->|"2"|miniDFA7
miniDFA7 -->|"D"|miniDFA8
miniDFA8 -->|"A"|miniDFA9
miniDFA9 -->|"r"|miniDFA10
miniDFA10 -->|"r"|miniDFA3
miniDFA3 -->|"a"|miniDFA11
miniDFA11 -->|"y"|miniDFA12
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
miniDFA4(["miniDFA4 1 DFA States"])
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA7(["miniDFA7 1 DFA States"])
miniDFA8(["miniDFA8 1 DFA States"])
miniDFA9(["miniDFA9 1 DFA States"])
miniDFA10(["miniDFA10 1 DFA States"])
miniDFA3(["miniDFA3 1 DFA States"])
miniDFA11(["miniDFA11 1 DFA States"])
miniDFA12(["miniDFA12 1 DFA States"])
miniDFA0 -->|"i"|miniDFA1
miniDFA1 -->|"m"|miniDFA2
miniDFA2 -->|"a"|miniDFA4
miniDFA4 -->|"g"|miniDFA5
miniDFA5 -->|"e"|miniDFA6
miniDFA6 -->|"2"|miniDFA7
miniDFA7 -->|"D"|miniDFA8
miniDFA8 -->|"A"|miniDFA9
miniDFA9 -->|"r"|miniDFA10
miniDFA10 -->|"r"|miniDFA3
miniDFA3 -->|"a"|miniDFA11
miniDFA11 -->|"y"|miniDFA12
```
-------------------------------
