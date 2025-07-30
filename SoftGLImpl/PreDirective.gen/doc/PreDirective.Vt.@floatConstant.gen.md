# Vt: 'floatConstant'

patterns[0]: `[-+]?[0-9]+([.][0-9]*)?([Ee][-+]?[0-9]+)?[fF]`

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
eNFA0_21[["εNFA0-21 post-regex start"]]
eNFA0_6[["εNFA0-6 scope{0, -1}"]]
eNFA0_14[["εNFA0-14 scope[1]"]]
eNFA0_22[\"εNFA0-22 post-regex end"/]
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
eNFA0_20 -.->|"ε"|eNFA0_21
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_13 -->|"[0-9]"|eNFA0_14
eNFA0_21 -.->|"ε"|eNFA0_22
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
eNFA0_9[["εNFA0-9 scope{1, 1}"]]
eNFA0_16[["εNFA0-16 regex end"]]
eNFA0_10[["εNFA0-10 scope[1]"]]
eNFA0_17[["εNFA0-17 scope{1, 1}"]]
eNFA0_18[\"εNFA0-18 scope[1]"/]
eNFA0_6[["εNFA0-6 scope{0, -1}"]]
eNFA0_8[["εNFA0-8 regex end"]]
eNFA0_7[["εNFA0-7 regex start"]]
eNFA0_4[["εNFA0-4 scope{1, 1}"]]
eNFA0_5[["εNFA0-5 scope[1]"]]
eNFA0_11[["εNFA0-11 scope{0, 1}"]]
eNFA0_12[["εNFA0-12 scope[1]"]]
eNFA0_13[["εNFA0-13 scope{1, -1}"]]
eNFA0_14[["εNFA0-14 scope[1]"]]
eNFA0_20[\"εNFA0-20 regex end"/]
eNFA0_21[\"εNFA0-21 post-regex start"/]
eNFA0_22[\"εNFA0-22 post-regex end"/]
eNFA0_6[["εNFA0-6 scope{0, -1}"]]
eNFA0_16[["εNFA0-16 regex end"]]
eNFA0_15[["εNFA0-15 regex start"]]
eNFA0_9[["εNFA0-9 scope{1, 1}"]]
eNFA0_10[["εNFA0-10 scope[1]"]]
eNFA0_11[["εNFA0-11 scope{0, 1}"]]
eNFA0_12[["εNFA0-12 scope[1]"]]
eNFA0_13[["εNFA0-13 scope{1, -1}"]]
eNFA0_14[["εNFA0-14 scope[1]"]]
eNFA0_19 -.->|"ε"|eNFA0_0
eNFA0_19 -->|"[-+]"|eNFA0_1
eNFA0_19 -.->|"ε"|eNFA0_1
eNFA0_19 -.->|"ε"|eNFA0_2
eNFA0_19 -->|"[0-9]"|eNFA0_3
eNFA0_0 -->|"[-+]"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_1
eNFA0_0 -.->|"ε"|eNFA0_2
eNFA0_0 -->|"[0-9]"|eNFA0_3
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_1 -->|"[0-9]"|eNFA0_3
eNFA0_2 -->|"[0-9]"|eNFA0_3
eNFA0_3 -->|"[0-9]"|eNFA0_3
eNFA0_3 -.->|"ε"|eNFA0_7
eNFA0_3 -.->|"ε"|eNFA0_4
eNFA0_3 -.->|"ε"|eNFA0_8
eNFA0_3 -->|"[.]"|eNFA0_5
eNFA0_3 -.->|"ε"|eNFA0_15
eNFA0_3 -.->|"ε"|eNFA0_9
eNFA0_3 -.->|"ε"|eNFA0_16
eNFA0_3 -->|"[Ee]"|eNFA0_10
eNFA0_3 -.->|"ε"|eNFA0_17
eNFA0_3 -->|"[fF]"|eNFA0_18
eNFA0_7 -.->|"ε"|eNFA0_4
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_7 -->|"[.]"|eNFA0_5
eNFA0_7 -.->|"ε"|eNFA0_15
eNFA0_7 -.->|"ε"|eNFA0_9
eNFA0_7 -.->|"ε"|eNFA0_16
eNFA0_7 -->|"[Ee]"|eNFA0_10
eNFA0_7 -.->|"ε"|eNFA0_17
eNFA0_7 -->|"[fF]"|eNFA0_18
eNFA0_4 -->|"[.]"|eNFA0_5
eNFA0_8 -.->|"ε"|eNFA0_15
eNFA0_8 -.->|"ε"|eNFA0_9
eNFA0_8 -.->|"ε"|eNFA0_16
eNFA0_8 -->|"[Ee]"|eNFA0_10
eNFA0_8 -.->|"ε"|eNFA0_17
eNFA0_8 -->|"[fF]"|eNFA0_18
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_5 -->|"[0-9]"|eNFA0_6
eNFA0_5 -.->|"ε"|eNFA0_8
eNFA0_5 -.->|"ε"|eNFA0_7
eNFA0_5 -.->|"ε"|eNFA0_4
eNFA0_5 -.->|"ε"|eNFA0_8
eNFA0_5 -->|"[.]"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_15
eNFA0_5 -.->|"ε"|eNFA0_9
eNFA0_5 -.->|"ε"|eNFA0_16
eNFA0_5 -->|"[Ee]"|eNFA0_10
eNFA0_5 -.->|"ε"|eNFA0_17
eNFA0_5 -->|"[fF]"|eNFA0_18
eNFA0_15 -.->|"ε"|eNFA0_9
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_15 -->|"[Ee]"|eNFA0_10
eNFA0_15 -.->|"ε"|eNFA0_17
eNFA0_15 -->|"[fF]"|eNFA0_18
eNFA0_9 -->|"[Ee]"|eNFA0_10
eNFA0_16 -.->|"ε"|eNFA0_17
eNFA0_16 -->|"[fF]"|eNFA0_18
eNFA0_10 -.->|"ε"|eNFA0_11
eNFA0_10 -->|"[-+]"|eNFA0_12
eNFA0_10 -.->|"ε"|eNFA0_12
eNFA0_10 -.->|"ε"|eNFA0_13
eNFA0_10 -->|"[0-9]"|eNFA0_14
eNFA0_17 -->|"[fF]"|eNFA0_18
eNFA0_18 -.->|"ε"|eNFA0_20
eNFA0_18 -.->|"ε"|eNFA0_21
eNFA0_18 -.->|"ε"|eNFA0_22
eNFA0_6 -->|"[0-9]"|eNFA0_6
eNFA0_6 -.->|"ε"|eNFA0_8
eNFA0_6 -.->|"ε"|eNFA0_7
eNFA0_6 -.->|"ε"|eNFA0_4
eNFA0_6 -.->|"ε"|eNFA0_8
eNFA0_6 -->|"[.]"|eNFA0_5
eNFA0_6 -.->|"ε"|eNFA0_15
eNFA0_6 -.->|"ε"|eNFA0_9
eNFA0_6 -.->|"ε"|eNFA0_16
eNFA0_6 -->|"[Ee]"|eNFA0_10
eNFA0_6 -.->|"ε"|eNFA0_17
eNFA0_6 -->|"[fF]"|eNFA0_18
eNFA0_8 -.->|"ε"|eNFA0_7
eNFA0_8 -.->|"ε"|eNFA0_4
eNFA0_8 -.->|"ε"|eNFA0_8
eNFA0_8 -->|"[.]"|eNFA0_5
eNFA0_8 -.->|"ε"|eNFA0_15
eNFA0_8 -.->|"ε"|eNFA0_9
eNFA0_8 -.->|"ε"|eNFA0_16
eNFA0_8 -->|"[Ee]"|eNFA0_10
eNFA0_8 -.->|"ε"|eNFA0_17
eNFA0_8 -->|"[fF]"|eNFA0_18
eNFA0_7 -.->|"ε"|eNFA0_4
eNFA0_7 -.->|"ε"|eNFA0_8
eNFA0_7 -->|"[.]"|eNFA0_5
eNFA0_7 -.->|"ε"|eNFA0_15
eNFA0_7 -.->|"ε"|eNFA0_9
eNFA0_7 -.->|"ε"|eNFA0_16
eNFA0_7 -->|"[Ee]"|eNFA0_10
eNFA0_7 -.->|"ε"|eNFA0_17
eNFA0_7 -->|"[fF]"|eNFA0_18
eNFA0_4 -->|"[.]"|eNFA0_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_5 -->|"[0-9]"|eNFA0_6
eNFA0_5 -.->|"ε"|eNFA0_8
eNFA0_5 -.->|"ε"|eNFA0_15
eNFA0_5 -.->|"ε"|eNFA0_9
eNFA0_5 -.->|"ε"|eNFA0_16
eNFA0_5 -->|"[Ee]"|eNFA0_10
eNFA0_5 -.->|"ε"|eNFA0_17
eNFA0_5 -->|"[fF]"|eNFA0_18
eNFA0_11 -->|"[-+]"|eNFA0_12
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_11 -.->|"ε"|eNFA0_13
eNFA0_11 -->|"[0-9]"|eNFA0_14
eNFA0_12 -.->|"ε"|eNFA0_13
eNFA0_12 -->|"[0-9]"|eNFA0_14
eNFA0_13 -->|"[0-9]"|eNFA0_14
eNFA0_14 -->|"[0-9]"|eNFA0_14
eNFA0_14 -.->|"ε"|eNFA0_16
eNFA0_14 -.->|"ε"|eNFA0_15
eNFA0_14 -.->|"ε"|eNFA0_9
eNFA0_14 -.->|"ε"|eNFA0_16
eNFA0_14 -->|"[Ee]"|eNFA0_10
eNFA0_14 -.->|"ε"|eNFA0_17
eNFA0_14 -->|"[fF]"|eNFA0_18
eNFA0_20 -.->|"ε"|eNFA0_21
eNFA0_20 -.->|"ε"|eNFA0_22
eNFA0_21 -.->|"ε"|eNFA0_22
eNFA0_6 -->|"[0-9]"|eNFA0_6
eNFA0_6 -.->|"ε"|eNFA0_8
eNFA0_6 -.->|"ε"|eNFA0_15
eNFA0_6 -.->|"ε"|eNFA0_9
eNFA0_6 -.->|"ε"|eNFA0_16
eNFA0_6 -->|"[Ee]"|eNFA0_10
eNFA0_6 -.->|"ε"|eNFA0_17
eNFA0_6 -->|"[fF]"|eNFA0_18
eNFA0_16 -.->|"ε"|eNFA0_15
eNFA0_16 -.->|"ε"|eNFA0_9
eNFA0_16 -.->|"ε"|eNFA0_16
eNFA0_16 -->|"[Ee]"|eNFA0_10
eNFA0_16 -.->|"ε"|eNFA0_17
eNFA0_16 -->|"[fF]"|eNFA0_18
eNFA0_15 -.->|"ε"|eNFA0_9
eNFA0_15 -.->|"ε"|eNFA0_16
eNFA0_15 -->|"[Ee]"|eNFA0_10
eNFA0_15 -.->|"ε"|eNFA0_17
eNFA0_15 -->|"[fF]"|eNFA0_18
eNFA0_9 -->|"[Ee]"|eNFA0_10
eNFA0_10 -.->|"ε"|eNFA0_11
eNFA0_10 -->|"[-+]"|eNFA0_12
eNFA0_10 -.->|"ε"|eNFA0_12
eNFA0_10 -.->|"ε"|eNFA0_13
eNFA0_10 -->|"[0-9]"|eNFA0_14
eNFA0_11 -->|"[-+]"|eNFA0_12
eNFA0_11 -.->|"ε"|eNFA0_12
eNFA0_11 -.->|"ε"|eNFA0_13
eNFA0_11 -->|"[0-9]"|eNFA0_14
eNFA0_12 -.->|"ε"|eNFA0_13
eNFA0_12 -->|"[0-9]"|eNFA0_14
eNFA0_13 -->|"[0-9]"|eNFA0_14
eNFA0_14 -->|"[0-9]"|eNFA0_14
eNFA0_14 -.->|"ε"|eNFA0_16
eNFA0_14 -.->|"ε"|eNFA0_17
eNFA0_14 -->|"[fF]"|eNFA0_18
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
NFA0_19("NFA0-19 regex start")
NFA0_1("NFA0-1 scope[1]")
NFA0_3("NFA0-3 scope[1]")
NFA0_5("NFA0-5 scope[1]")
NFA0_10("NFA0-10 scope[1]")
NFA0_18[\"NFA0-18 scope[1]"/]
NFA0_6("NFA0-6 scope{0, -1}")
NFA0_5("NFA0-5 scope[1]")
NFA0_12("NFA0-12 scope[1]")
NFA0_14("NFA0-14 scope[1]")
NFA0_6("NFA0-6 scope{0, -1}")
NFA0_10("NFA0-10 scope[1]")
NFA0_12("NFA0-12 scope[1]")
NFA0_14("NFA0-14 scope[1]")
NFA0_19 -->|"[-+]"|NFA0_1
NFA0_19 -->|"[0-9]"|NFA0_3
NFA0_1 -->|"[0-9]"|NFA0_3
NFA0_3 -->|"[0-9]"|NFA0_3
NFA0_3 -->|"[.]"|NFA0_5
NFA0_3 -->|"[Ee]"|NFA0_10
NFA0_3 -->|"[fF]"|NFA0_18
NFA0_5 -->|"[0-9]"|NFA0_6
NFA0_5 -->|"[.]"|NFA0_5
NFA0_5 -->|"[Ee]"|NFA0_10
NFA0_5 -->|"[fF]"|NFA0_18
NFA0_10 -->|"[-+]"|NFA0_12
NFA0_10 -->|"[0-9]"|NFA0_14
NFA0_6 -->|"[0-9]"|NFA0_6
NFA0_6 -->|"[.]"|NFA0_5
NFA0_6 -->|"[Ee]"|NFA0_10
NFA0_6 -->|"[fF]"|NFA0_18
NFA0_5 -->|"[0-9]"|NFA0_6
NFA0_5 -->|"[Ee]"|NFA0_10
NFA0_5 -->|"[fF]"|NFA0_18
NFA0_12 -->|"[0-9]"|NFA0_14
NFA0_14 -->|"[0-9]"|NFA0_14
NFA0_14 -->|"[Ee]"|NFA0_10
NFA0_14 -->|"[fF]"|NFA0_18
NFA0_6 -->|"[0-9]"|NFA0_6
NFA0_6 -->|"[Ee]"|NFA0_10
NFA0_6 -->|"[fF]"|NFA0_18
NFA0_10 -->|"[-+]"|NFA0_12
NFA0_10 -->|"[0-9]"|NFA0_14
NFA0_12 -->|"[0-9]"|NFA0_14
NFA0_14 -->|"[0-9]"|NFA0_14
NFA0_14 -->|"[fF]"|NFA0_18
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
NFA0_19_0("NFA0-19 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA0_3_1("NFA0-3 scope[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA0_1_2("NFA0-1 scope[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA0_18_3[\"NFA0-18 scope[1]"/]
end
subgraph DFA4["DFA4 1 NFA States"]
NFA0_10_4("NFA0-10 scope[1]")
end
subgraph DFA5["DFA5 1 NFA States"]
NFA0_5_5("NFA0-5 scope[1]")
end
subgraph DFA6["DFA6 1 NFA States"]
NFA0_14_6("NFA0-14 scope[1]")
end
subgraph DFA7["DFA7 1 NFA States"]
NFA0_12_7("NFA0-12 scope[1]")
end
subgraph DFA8["DFA8 1 NFA States"]
NFA0_5_8("NFA0-5 scope[1]")
end
subgraph DFA9["DFA9 1 NFA States"]
NFA0_6_9("NFA0-6 scope{0, -1}")
end
subgraph DFA10["DFA10 1 NFA States"]
NFA0_10_10("NFA0-10 scope[1]")
end
subgraph DFA11["DFA11 1 NFA States"]
NFA0_6_11("NFA0-6 scope{0, -1}")
end
subgraph DFA12["DFA12 1 NFA States"]
NFA0_14_12("NFA0-14 scope[1]")
end
subgraph DFA13["DFA13 1 NFA States"]
NFA0_12_13("NFA0-12 scope[1]")
end
DFA0 -->|"[0-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA1 -->|"[fF]"|DFA3
DFA1 -->|"[Ee]"|DFA4
DFA1 -->|"[.]"|DFA5
DFA1 -->|"[0-9]"|DFA1
DFA2 -->|"[0-9]"|DFA1
DFA4 -->|"[0-9]"|DFA6
DFA4 -->|"[-+]"|DFA7
DFA5 -->|"[fF]"|DFA3
DFA5 -->|"[Ee]"|DFA4
DFA5 -->|"[.]"|DFA8
DFA5 -->|"[0-9]"|DFA9
DFA6 -->|"[fF]"|DFA3
DFA6 -->|"[Ee]"|DFA10
DFA6 -->|"[0-9]"|DFA6
DFA7 -->|"[0-9]"|DFA6
DFA8 -->|"[fF]"|DFA3
DFA8 -->|"[Ee]"|DFA4
DFA8 -->|"[0-9]"|DFA11
DFA9 -->|"[fF]"|DFA3
DFA9 -->|"[Ee]"|DFA4
DFA9 -->|"[.]"|DFA8
DFA9 -->|"[0-9]"|DFA9
DFA10 -->|"[0-9]"|DFA12
DFA10 -->|"[-+]"|DFA13
DFA11 -->|"[fF]"|DFA3
DFA11 -->|"[Ee]"|DFA4
DFA11 -->|"[0-9]"|DFA11
DFA12 -->|"[fF]"|DFA3
DFA12 -->|"[0-9]"|DFA12
DFA13 -->|"[0-9]"|DFA12
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
DFA7{{"DFA7 1 NFA States"}}
DFA8{{"DFA8 1 NFA States"}}
DFA9{{"DFA9 1 NFA States"}}
DFA10{{"DFA10 1 NFA States"}}
DFA11{{"DFA11 1 NFA States"}}
DFA12{{"DFA12 1 NFA States"}}
DFA13{{"DFA13 1 NFA States"}}
DFA0 -->|"[0-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA1 -->|"[fF]"|DFA3
DFA1 -->|"[Ee]"|DFA4
DFA1 -->|"[.]"|DFA5
DFA1 -->|"[0-9]"|DFA1
DFA2 -->|"[0-9]"|DFA1
DFA4 -->|"[0-9]"|DFA6
DFA4 -->|"[-+]"|DFA7
DFA5 -->|"[fF]"|DFA3
DFA5 -->|"[Ee]"|DFA4
DFA5 -->|"[.]"|DFA8
DFA5 -->|"[0-9]"|DFA9
DFA6 -->|"[fF]"|DFA3
DFA6 -->|"[Ee]"|DFA10
DFA6 -->|"[0-9]"|DFA6
DFA7 -->|"[0-9]"|DFA6
DFA8 -->|"[fF]"|DFA3
DFA8 -->|"[Ee]"|DFA4
DFA8 -->|"[0-9]"|DFA11
DFA9 -->|"[fF]"|DFA3
DFA9 -->|"[Ee]"|DFA4
DFA9 -->|"[.]"|DFA8
DFA9 -->|"[0-9]"|DFA9
DFA10 -->|"[0-9]"|DFA12
DFA10 -->|"[-+]"|DFA13
DFA11 -->|"[fF]"|DFA3
DFA11 -->|"[Ee]"|DFA4
DFA11 -->|"[0-9]"|DFA11
DFA12 -->|"[fF]"|DFA3
DFA12 -->|"[0-9]"|DFA12
DFA13 -->|"[0-9]"|DFA12
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
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA1_1{{"DFA1 1 NFA States"}}
end
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
end
subgraph miniDFA11["miniDFA11 1 DFA States"]
DFA3_3[\"DFA3 1 NFA States"/]
end
subgraph miniDFA1["miniDFA1 1 DFA States"]
DFA4_4{{"DFA4 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 2 DFA States"]
DFA5_5{{"DFA5 1 NFA States"}}
DFA9_6{{"DFA9 1 NFA States"}}
end
subgraph miniDFA8["miniDFA8 1 DFA States"]
DFA6_7{{"DFA6 1 NFA States"}}
end
subgraph miniDFA6["miniDFA6 1 DFA States"]
DFA7_8{{"DFA7 1 NFA States"}}
end
subgraph miniDFA9["miniDFA9 2 DFA States"]
DFA8_9{{"DFA8 1 NFA States"}}
DFA11_10{{"DFA11 1 NFA States"}}
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA10_11{{"DFA10 1 NFA States"}}
end
subgraph miniDFA10["miniDFA10 1 DFA States"]
DFA12_12{{"DFA12 1 NFA States"}}
end
subgraph miniDFA7["miniDFA7 1 DFA States"]
DFA13_13{{"DFA13 1 NFA States"}}
end
miniDFA0 -->|"[0-9]"|miniDFA3
miniDFA0 -->|"[-+]"|miniDFA5
miniDFA3 -->|"[fF]"|miniDFA11
miniDFA3 -->|"[Ee]"|miniDFA1
miniDFA3 -->|"[.]"|miniDFA4
miniDFA3 -->|"[0-9]"|miniDFA3
miniDFA5 -->|"[0-9]"|miniDFA3
miniDFA1 -->|"[0-9]"|miniDFA8
miniDFA1 -->|"[-+]"|miniDFA6
miniDFA4 -->|"[fF]"|miniDFA11
miniDFA4 -->|"[Ee]"|miniDFA1
miniDFA4 -->|"[.]"|miniDFA9
miniDFA4 -->|"[0-9]"|miniDFA4
miniDFA8 -->|"[fF]"|miniDFA11
miniDFA8 -->|"[Ee]"|miniDFA2
miniDFA8 -->|"[0-9]"|miniDFA8
miniDFA6 -->|"[0-9]"|miniDFA8
miniDFA9 -->|"[fF]"|miniDFA11
miniDFA9 -->|"[Ee]"|miniDFA1
miniDFA9 -->|"[0-9]"|miniDFA9
miniDFA2 -->|"[0-9]"|miniDFA10
miniDFA2 -->|"[-+]"|miniDFA7
miniDFA10 -->|"[fF]"|miniDFA11
miniDFA10 -->|"[0-9]"|miniDFA10
miniDFA7 -->|"[0-9]"|miniDFA10
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
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA11(["miniDFA11 1 DFA States"])
miniDFA1(["miniDFA1 1 DFA States"])
miniDFA4(["miniDFA4 2 DFA States"])
miniDFA8(["miniDFA8 1 DFA States"])
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA9(["miniDFA9 2 DFA States"])
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA10(["miniDFA10 1 DFA States"])
miniDFA7(["miniDFA7 1 DFA States"])
miniDFA0 -->|"[0-9]"|miniDFA3
miniDFA0 -->|"[-+]"|miniDFA5
miniDFA3 -->|"[fF]"|miniDFA11
miniDFA3 -->|"[Ee]"|miniDFA1
miniDFA3 -->|"[.]"|miniDFA4
miniDFA3 -->|"[0-9]"|miniDFA3
miniDFA5 -->|"[0-9]"|miniDFA3
miniDFA1 -->|"[0-9]"|miniDFA8
miniDFA1 -->|"[-+]"|miniDFA6
miniDFA4 -->|"[fF]"|miniDFA11
miniDFA4 -->|"[Ee]"|miniDFA1
miniDFA4 -->|"[.]"|miniDFA9
miniDFA4 -->|"[0-9]"|miniDFA4
miniDFA8 -->|"[fF]"|miniDFA11
miniDFA8 -->|"[Ee]"|miniDFA2
miniDFA8 -->|"[0-9]"|miniDFA8
miniDFA6 -->|"[0-9]"|miniDFA8
miniDFA9 -->|"[fF]"|miniDFA11
miniDFA9 -->|"[Ee]"|miniDFA1
miniDFA9 -->|"[0-9]"|miniDFA9
miniDFA2 -->|"[0-9]"|miniDFA10
miniDFA2 -->|"[-+]"|miniDFA7
miniDFA10 -->|"[fF]"|miniDFA11
miniDFA10 -->|"[0-9]"|miniDFA10
miniDFA7 -->|"[0-9]"|miniDFA10
```
-------------------------------
pattern: `[-+]?[0-9]+([.][0-9]*)?([Ee][-+]?[0-9]+)?[fF]`

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
eNFA1_19[["εNFA1-19 regex start"]]
eNFA1_0[["εNFA1-0 scope{0, 1}"]]
eNFA1_1[["εNFA1-1 scope[1]"]]
eNFA1_2[["εNFA1-2 scope{1, -1}"]]
eNFA1_3[["εNFA1-3 scope[1]"]]
eNFA1_7[["εNFA1-7 regex start"]]
eNFA1_4[["εNFA1-4 scope{1, 1}"]]
eNFA1_8[["εNFA1-8 regex end"]]
eNFA1_5[["εNFA1-5 scope[1]"]]
eNFA1_15[["εNFA1-15 regex start"]]
eNFA1_6[["εNFA1-6 scope{0, -1}"]]
eNFA1_9[["εNFA1-9 scope{1, 1}"]]
eNFA1_16[["εNFA1-16 regex end"]]
eNFA1_8[["εNFA1-8 regex end"]]
eNFA1_10[["εNFA1-10 scope[1]"]]
eNFA1_17[["εNFA1-17 scope{1, 1}"]]
eNFA1_7[["εNFA1-7 regex start"]]
eNFA1_11[["εNFA1-11 scope{0, 1}"]]
eNFA1_18[["εNFA1-18 scope[1]"]]
eNFA1_4[["εNFA1-4 scope{1, 1}"]]
eNFA1_12[["εNFA1-12 scope[1]"]]
eNFA1_20[["εNFA1-20 regex end"]]
eNFA1_5[["εNFA1-5 scope[1]"]]
eNFA1_13[["εNFA1-13 scope{1, -1}"]]
eNFA1_21[["εNFA1-21 post-regex start"]]
eNFA1_6[["εNFA1-6 scope{0, -1}"]]
eNFA1_14[["εNFA1-14 scope[1]"]]
eNFA1_22[\"εNFA1-22 post-regex end"/]
eNFA1_16[["εNFA1-16 regex end"]]
eNFA1_15[["εNFA1-15 regex start"]]
eNFA1_9[["εNFA1-9 scope{1, 1}"]]
eNFA1_10[["εNFA1-10 scope[1]"]]
eNFA1_11[["εNFA1-11 scope{0, 1}"]]
eNFA1_12[["εNFA1-12 scope[1]"]]
eNFA1_13[["εNFA1-13 scope{1, -1}"]]
eNFA1_14[["εNFA1-14 scope[1]"]]
eNFA1_19 -.->|"ε"|eNFA1_0
eNFA1_0 -->|"[-+]"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_2 -->|"[0-9]"|eNFA1_3
eNFA1_3 -->|"[0-9]"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_7
eNFA1_7 -.->|"ε"|eNFA1_4
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_4 -->|"[.]"|eNFA1_5
eNFA1_8 -.->|"ε"|eNFA1_15
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_15 -.->|"ε"|eNFA1_9
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_6 -->|"[0-9]"|eNFA1_6
eNFA1_6 -.->|"ε"|eNFA1_8
eNFA1_9 -->|"[Ee]"|eNFA1_10
eNFA1_16 -.->|"ε"|eNFA1_17
eNFA1_8 -.->|"ε"|eNFA1_7
eNFA1_10 -.->|"ε"|eNFA1_11
eNFA1_17 -->|"[fF]"|eNFA1_18
eNFA1_7 -.->|"ε"|eNFA1_4
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_11 -->|"[-+]"|eNFA1_12
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_18 -.->|"ε"|eNFA1_20
eNFA1_4 -->|"[.]"|eNFA1_5
eNFA1_12 -.->|"ε"|eNFA1_13
eNFA1_20 -.->|"ε"|eNFA1_21
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_13 -->|"[0-9]"|eNFA1_14
eNFA1_21 -.->|"ε"|eNFA1_22
eNFA1_6 -->|"[0-9]"|eNFA1_6
eNFA1_6 -.->|"ε"|eNFA1_8
eNFA1_14 -->|"[0-9]"|eNFA1_14
eNFA1_14 -.->|"ε"|eNFA1_16
eNFA1_16 -.->|"ε"|eNFA1_15
eNFA1_15 -.->|"ε"|eNFA1_9
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_9 -->|"[Ee]"|eNFA1_10
eNFA1_10 -.->|"ε"|eNFA1_11
eNFA1_11 -->|"[-+]"|eNFA1_12
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_12 -.->|"ε"|eNFA1_13
eNFA1_13 -->|"[0-9]"|eNFA1_14
eNFA1_14 -->|"[0-9]"|eNFA1_14
eNFA1_14 -.->|"ε"|eNFA1_16
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
eNFA1_19[["εNFA1-19 regex start"]]
eNFA1_0[["εNFA1-0 scope{0, 1}"]]
eNFA1_1[["εNFA1-1 scope[1]"]]
eNFA1_2[["εNFA1-2 scope{1, -1}"]]
eNFA1_3[["εNFA1-3 scope[1]"]]
eNFA1_7[["εNFA1-7 regex start"]]
eNFA1_4[["εNFA1-4 scope{1, 1}"]]
eNFA1_8[["εNFA1-8 regex end"]]
eNFA1_5[["εNFA1-5 scope[1]"]]
eNFA1_15[["εNFA1-15 regex start"]]
eNFA1_9[["εNFA1-9 scope{1, 1}"]]
eNFA1_16[["εNFA1-16 regex end"]]
eNFA1_10[["εNFA1-10 scope[1]"]]
eNFA1_17[["εNFA1-17 scope{1, 1}"]]
eNFA1_18[\"εNFA1-18 scope[1]"/]
eNFA1_6[["εNFA1-6 scope{0, -1}"]]
eNFA1_8[["εNFA1-8 regex end"]]
eNFA1_7[["εNFA1-7 regex start"]]
eNFA1_4[["εNFA1-4 scope{1, 1}"]]
eNFA1_5[["εNFA1-5 scope[1]"]]
eNFA1_11[["εNFA1-11 scope{0, 1}"]]
eNFA1_12[["εNFA1-12 scope[1]"]]
eNFA1_13[["εNFA1-13 scope{1, -1}"]]
eNFA1_14[["εNFA1-14 scope[1]"]]
eNFA1_20[\"εNFA1-20 regex end"/]
eNFA1_21[\"εNFA1-21 post-regex start"/]
eNFA1_22[\"εNFA1-22 post-regex end"/]
eNFA1_6[["εNFA1-6 scope{0, -1}"]]
eNFA1_16[["εNFA1-16 regex end"]]
eNFA1_15[["εNFA1-15 regex start"]]
eNFA1_9[["εNFA1-9 scope{1, 1}"]]
eNFA1_10[["εNFA1-10 scope[1]"]]
eNFA1_11[["εNFA1-11 scope{0, 1}"]]
eNFA1_12[["εNFA1-12 scope[1]"]]
eNFA1_13[["εNFA1-13 scope{1, -1}"]]
eNFA1_14[["εNFA1-14 scope[1]"]]
eNFA1_19 -.->|"ε"|eNFA1_0
eNFA1_19 -->|"[-+]"|eNFA1_1
eNFA1_19 -.->|"ε"|eNFA1_1
eNFA1_19 -.->|"ε"|eNFA1_2
eNFA1_19 -->|"[0-9]"|eNFA1_3
eNFA1_0 -->|"[-+]"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_1
eNFA1_0 -.->|"ε"|eNFA1_2
eNFA1_0 -->|"[0-9]"|eNFA1_3
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"[0-9]"|eNFA1_3
eNFA1_2 -->|"[0-9]"|eNFA1_3
eNFA1_3 -->|"[0-9]"|eNFA1_3
eNFA1_3 -.->|"ε"|eNFA1_7
eNFA1_3 -.->|"ε"|eNFA1_4
eNFA1_3 -.->|"ε"|eNFA1_8
eNFA1_3 -->|"[.]"|eNFA1_5
eNFA1_3 -.->|"ε"|eNFA1_15
eNFA1_3 -.->|"ε"|eNFA1_9
eNFA1_3 -.->|"ε"|eNFA1_16
eNFA1_3 -->|"[Ee]"|eNFA1_10
eNFA1_3 -.->|"ε"|eNFA1_17
eNFA1_3 -->|"[fF]"|eNFA1_18
eNFA1_7 -.->|"ε"|eNFA1_4
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_7 -->|"[.]"|eNFA1_5
eNFA1_7 -.->|"ε"|eNFA1_15
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA1_7 -.->|"ε"|eNFA1_16
eNFA1_7 -->|"[Ee]"|eNFA1_10
eNFA1_7 -.->|"ε"|eNFA1_17
eNFA1_7 -->|"[fF]"|eNFA1_18
eNFA1_4 -->|"[.]"|eNFA1_5
eNFA1_8 -.->|"ε"|eNFA1_15
eNFA1_8 -.->|"ε"|eNFA1_9
eNFA1_8 -.->|"ε"|eNFA1_16
eNFA1_8 -->|"[Ee]"|eNFA1_10
eNFA1_8 -.->|"ε"|eNFA1_17
eNFA1_8 -->|"[fF]"|eNFA1_18
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -->|"[0-9]"|eNFA1_6
eNFA1_5 -.->|"ε"|eNFA1_8
eNFA1_5 -.->|"ε"|eNFA1_7
eNFA1_5 -.->|"ε"|eNFA1_4
eNFA1_5 -.->|"ε"|eNFA1_8
eNFA1_5 -->|"[.]"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_15
eNFA1_5 -.->|"ε"|eNFA1_9
eNFA1_5 -.->|"ε"|eNFA1_16
eNFA1_5 -->|"[Ee]"|eNFA1_10
eNFA1_5 -.->|"ε"|eNFA1_17
eNFA1_5 -->|"[fF]"|eNFA1_18
eNFA1_15 -.->|"ε"|eNFA1_9
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_15 -->|"[Ee]"|eNFA1_10
eNFA1_15 -.->|"ε"|eNFA1_17
eNFA1_15 -->|"[fF]"|eNFA1_18
eNFA1_9 -->|"[Ee]"|eNFA1_10
eNFA1_16 -.->|"ε"|eNFA1_17
eNFA1_16 -->|"[fF]"|eNFA1_18
eNFA1_10 -.->|"ε"|eNFA1_11
eNFA1_10 -->|"[-+]"|eNFA1_12
eNFA1_10 -.->|"ε"|eNFA1_12
eNFA1_10 -.->|"ε"|eNFA1_13
eNFA1_10 -->|"[0-9]"|eNFA1_14
eNFA1_17 -->|"[fF]"|eNFA1_18
eNFA1_18 -.->|"ε"|eNFA1_20
eNFA1_18 -.->|"ε"|eNFA1_21
eNFA1_18 -.->|"ε"|eNFA1_22
eNFA1_6 -->|"[0-9]"|eNFA1_6
eNFA1_6 -.->|"ε"|eNFA1_8
eNFA1_6 -.->|"ε"|eNFA1_7
eNFA1_6 -.->|"ε"|eNFA1_4
eNFA1_6 -.->|"ε"|eNFA1_8
eNFA1_6 -->|"[.]"|eNFA1_5
eNFA1_6 -.->|"ε"|eNFA1_15
eNFA1_6 -.->|"ε"|eNFA1_9
eNFA1_6 -.->|"ε"|eNFA1_16
eNFA1_6 -->|"[Ee]"|eNFA1_10
eNFA1_6 -.->|"ε"|eNFA1_17
eNFA1_6 -->|"[fF]"|eNFA1_18
eNFA1_8 -.->|"ε"|eNFA1_7
eNFA1_8 -.->|"ε"|eNFA1_4
eNFA1_8 -.->|"ε"|eNFA1_8
eNFA1_8 -->|"[.]"|eNFA1_5
eNFA1_8 -.->|"ε"|eNFA1_15
eNFA1_8 -.->|"ε"|eNFA1_9
eNFA1_8 -.->|"ε"|eNFA1_16
eNFA1_8 -->|"[Ee]"|eNFA1_10
eNFA1_8 -.->|"ε"|eNFA1_17
eNFA1_8 -->|"[fF]"|eNFA1_18
eNFA1_7 -.->|"ε"|eNFA1_4
eNFA1_7 -.->|"ε"|eNFA1_8
eNFA1_7 -->|"[.]"|eNFA1_5
eNFA1_7 -.->|"ε"|eNFA1_15
eNFA1_7 -.->|"ε"|eNFA1_9
eNFA1_7 -.->|"ε"|eNFA1_16
eNFA1_7 -->|"[Ee]"|eNFA1_10
eNFA1_7 -.->|"ε"|eNFA1_17
eNFA1_7 -->|"[fF]"|eNFA1_18
eNFA1_4 -->|"[.]"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -->|"[0-9]"|eNFA1_6
eNFA1_5 -.->|"ε"|eNFA1_8
eNFA1_5 -.->|"ε"|eNFA1_15
eNFA1_5 -.->|"ε"|eNFA1_9
eNFA1_5 -.->|"ε"|eNFA1_16
eNFA1_5 -->|"[Ee]"|eNFA1_10
eNFA1_5 -.->|"ε"|eNFA1_17
eNFA1_5 -->|"[fF]"|eNFA1_18
eNFA1_11 -->|"[-+]"|eNFA1_12
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_11 -.->|"ε"|eNFA1_13
eNFA1_11 -->|"[0-9]"|eNFA1_14
eNFA1_12 -.->|"ε"|eNFA1_13
eNFA1_12 -->|"[0-9]"|eNFA1_14
eNFA1_13 -->|"[0-9]"|eNFA1_14
eNFA1_14 -->|"[0-9]"|eNFA1_14
eNFA1_14 -.->|"ε"|eNFA1_16
eNFA1_14 -.->|"ε"|eNFA1_15
eNFA1_14 -.->|"ε"|eNFA1_9
eNFA1_14 -.->|"ε"|eNFA1_16
eNFA1_14 -->|"[Ee]"|eNFA1_10
eNFA1_14 -.->|"ε"|eNFA1_17
eNFA1_14 -->|"[fF]"|eNFA1_18
eNFA1_20 -.->|"ε"|eNFA1_21
eNFA1_20 -.->|"ε"|eNFA1_22
eNFA1_21 -.->|"ε"|eNFA1_22
eNFA1_6 -->|"[0-9]"|eNFA1_6
eNFA1_6 -.->|"ε"|eNFA1_8
eNFA1_6 -.->|"ε"|eNFA1_15
eNFA1_6 -.->|"ε"|eNFA1_9
eNFA1_6 -.->|"ε"|eNFA1_16
eNFA1_6 -->|"[Ee]"|eNFA1_10
eNFA1_6 -.->|"ε"|eNFA1_17
eNFA1_6 -->|"[fF]"|eNFA1_18
eNFA1_16 -.->|"ε"|eNFA1_15
eNFA1_16 -.->|"ε"|eNFA1_9
eNFA1_16 -.->|"ε"|eNFA1_16
eNFA1_16 -->|"[Ee]"|eNFA1_10
eNFA1_16 -.->|"ε"|eNFA1_17
eNFA1_16 -->|"[fF]"|eNFA1_18
eNFA1_15 -.->|"ε"|eNFA1_9
eNFA1_15 -.->|"ε"|eNFA1_16
eNFA1_15 -->|"[Ee]"|eNFA1_10
eNFA1_15 -.->|"ε"|eNFA1_17
eNFA1_15 -->|"[fF]"|eNFA1_18
eNFA1_9 -->|"[Ee]"|eNFA1_10
eNFA1_10 -.->|"ε"|eNFA1_11
eNFA1_10 -->|"[-+]"|eNFA1_12
eNFA1_10 -.->|"ε"|eNFA1_12
eNFA1_10 -.->|"ε"|eNFA1_13
eNFA1_10 -->|"[0-9]"|eNFA1_14
eNFA1_11 -->|"[-+]"|eNFA1_12
eNFA1_11 -.->|"ε"|eNFA1_12
eNFA1_11 -.->|"ε"|eNFA1_13
eNFA1_11 -->|"[0-9]"|eNFA1_14
eNFA1_12 -.->|"ε"|eNFA1_13
eNFA1_12 -->|"[0-9]"|eNFA1_14
eNFA1_13 -->|"[0-9]"|eNFA1_14
eNFA1_14 -->|"[0-9]"|eNFA1_14
eNFA1_14 -.->|"ε"|eNFA1_16
eNFA1_14 -.->|"ε"|eNFA1_17
eNFA1_14 -->|"[fF]"|eNFA1_18
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
NFA1_19("NFA1-19 regex start")
NFA1_1("NFA1-1 scope[1]")
NFA1_3("NFA1-3 scope[1]")
NFA1_5("NFA1-5 scope[1]")
NFA1_10("NFA1-10 scope[1]")
NFA1_18[\"NFA1-18 scope[1]"/]
NFA1_6("NFA1-6 scope{0, -1}")
NFA1_5("NFA1-5 scope[1]")
NFA1_12("NFA1-12 scope[1]")
NFA1_14("NFA1-14 scope[1]")
NFA1_6("NFA1-6 scope{0, -1}")
NFA1_10("NFA1-10 scope[1]")
NFA1_12("NFA1-12 scope[1]")
NFA1_14("NFA1-14 scope[1]")
NFA1_19 -->|"[-+]"|NFA1_1
NFA1_19 -->|"[0-9]"|NFA1_3
NFA1_1 -->|"[0-9]"|NFA1_3
NFA1_3 -->|"[0-9]"|NFA1_3
NFA1_3 -->|"[.]"|NFA1_5
NFA1_3 -->|"[Ee]"|NFA1_10
NFA1_3 -->|"[fF]"|NFA1_18
NFA1_5 -->|"[0-9]"|NFA1_6
NFA1_5 -->|"[.]"|NFA1_5
NFA1_5 -->|"[Ee]"|NFA1_10
NFA1_5 -->|"[fF]"|NFA1_18
NFA1_10 -->|"[-+]"|NFA1_12
NFA1_10 -->|"[0-9]"|NFA1_14
NFA1_6 -->|"[0-9]"|NFA1_6
NFA1_6 -->|"[.]"|NFA1_5
NFA1_6 -->|"[Ee]"|NFA1_10
NFA1_6 -->|"[fF]"|NFA1_18
NFA1_5 -->|"[0-9]"|NFA1_6
NFA1_5 -->|"[Ee]"|NFA1_10
NFA1_5 -->|"[fF]"|NFA1_18
NFA1_12 -->|"[0-9]"|NFA1_14
NFA1_14 -->|"[0-9]"|NFA1_14
NFA1_14 -->|"[Ee]"|NFA1_10
NFA1_14 -->|"[fF]"|NFA1_18
NFA1_6 -->|"[0-9]"|NFA1_6
NFA1_6 -->|"[Ee]"|NFA1_10
NFA1_6 -->|"[fF]"|NFA1_18
NFA1_10 -->|"[-+]"|NFA1_12
NFA1_10 -->|"[0-9]"|NFA1_14
NFA1_12 -->|"[0-9]"|NFA1_14
NFA1_14 -->|"[0-9]"|NFA1_14
NFA1_14 -->|"[fF]"|NFA1_18
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
NFA1_19_0("NFA1-19 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA1_3_1("NFA1-3 scope[1]")
end
subgraph DFA2["DFA2 1 NFA States"]
NFA1_1_2("NFA1-1 scope[1]")
end
subgraph DFA3["DFA3 1 NFA States"]
NFA1_18_3[\"NFA1-18 scope[1]"/]
end
subgraph DFA4["DFA4 1 NFA States"]
NFA1_10_4("NFA1-10 scope[1]")
end
subgraph DFA5["DFA5 1 NFA States"]
NFA1_5_5("NFA1-5 scope[1]")
end
subgraph DFA6["DFA6 1 NFA States"]
NFA1_14_6("NFA1-14 scope[1]")
end
subgraph DFA7["DFA7 1 NFA States"]
NFA1_12_7("NFA1-12 scope[1]")
end
subgraph DFA8["DFA8 1 NFA States"]
NFA1_5_8("NFA1-5 scope[1]")
end
subgraph DFA9["DFA9 1 NFA States"]
NFA1_6_9("NFA1-6 scope{0, -1}")
end
subgraph DFA10["DFA10 1 NFA States"]
NFA1_10_10("NFA1-10 scope[1]")
end
subgraph DFA11["DFA11 1 NFA States"]
NFA1_6_11("NFA1-6 scope{0, -1}")
end
subgraph DFA12["DFA12 1 NFA States"]
NFA1_14_12("NFA1-14 scope[1]")
end
subgraph DFA13["DFA13 1 NFA States"]
NFA1_12_13("NFA1-12 scope[1]")
end
DFA0 -->|"[0-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA1 -->|"[fF]"|DFA3
DFA1 -->|"[Ee]"|DFA4
DFA1 -->|"[.]"|DFA5
DFA1 -->|"[0-9]"|DFA1
DFA2 -->|"[0-9]"|DFA1
DFA4 -->|"[0-9]"|DFA6
DFA4 -->|"[-+]"|DFA7
DFA5 -->|"[fF]"|DFA3
DFA5 -->|"[Ee]"|DFA4
DFA5 -->|"[.]"|DFA8
DFA5 -->|"[0-9]"|DFA9
DFA6 -->|"[fF]"|DFA3
DFA6 -->|"[Ee]"|DFA10
DFA6 -->|"[0-9]"|DFA6
DFA7 -->|"[0-9]"|DFA6
DFA8 -->|"[fF]"|DFA3
DFA8 -->|"[Ee]"|DFA4
DFA8 -->|"[0-9]"|DFA11
DFA9 -->|"[fF]"|DFA3
DFA9 -->|"[Ee]"|DFA4
DFA9 -->|"[.]"|DFA8
DFA9 -->|"[0-9]"|DFA9
DFA10 -->|"[0-9]"|DFA12
DFA10 -->|"[-+]"|DFA13
DFA11 -->|"[fF]"|DFA3
DFA11 -->|"[Ee]"|DFA4
DFA11 -->|"[0-9]"|DFA11
DFA12 -->|"[fF]"|DFA3
DFA12 -->|"[0-9]"|DFA12
DFA13 -->|"[0-9]"|DFA12
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
DFA7{{"DFA7 1 NFA States"}}
DFA8{{"DFA8 1 NFA States"}}
DFA9{{"DFA9 1 NFA States"}}
DFA10{{"DFA10 1 NFA States"}}
DFA11{{"DFA11 1 NFA States"}}
DFA12{{"DFA12 1 NFA States"}}
DFA13{{"DFA13 1 NFA States"}}
DFA0 -->|"[0-9]"|DFA1
DFA0 -->|"[-+]"|DFA2
DFA1 -->|"[fF]"|DFA3
DFA1 -->|"[Ee]"|DFA4
DFA1 -->|"[.]"|DFA5
DFA1 -->|"[0-9]"|DFA1
DFA2 -->|"[0-9]"|DFA1
DFA4 -->|"[0-9]"|DFA6
DFA4 -->|"[-+]"|DFA7
DFA5 -->|"[fF]"|DFA3
DFA5 -->|"[Ee]"|DFA4
DFA5 -->|"[.]"|DFA8
DFA5 -->|"[0-9]"|DFA9
DFA6 -->|"[fF]"|DFA3
DFA6 -->|"[Ee]"|DFA10
DFA6 -->|"[0-9]"|DFA6
DFA7 -->|"[0-9]"|DFA6
DFA8 -->|"[fF]"|DFA3
DFA8 -->|"[Ee]"|DFA4
DFA8 -->|"[0-9]"|DFA11
DFA9 -->|"[fF]"|DFA3
DFA9 -->|"[Ee]"|DFA4
DFA9 -->|"[.]"|DFA8
DFA9 -->|"[0-9]"|DFA9
DFA10 -->|"[0-9]"|DFA12
DFA10 -->|"[-+]"|DFA13
DFA11 -->|"[fF]"|DFA3
DFA11 -->|"[Ee]"|DFA4
DFA11 -->|"[0-9]"|DFA11
DFA12 -->|"[fF]"|DFA3
DFA12 -->|"[0-9]"|DFA12
DFA13 -->|"[0-9]"|DFA12
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
subgraph miniDFA3["miniDFA3 1 DFA States"]
DFA1_1{{"DFA1 1 NFA States"}}
end
subgraph miniDFA5["miniDFA5 1 DFA States"]
DFA2_2{{"DFA2 1 NFA States"}}
end
subgraph miniDFA11["miniDFA11 1 DFA States"]
DFA3_3[\"DFA3 1 NFA States"/]
end
subgraph miniDFA1["miniDFA1 1 DFA States"]
DFA4_4{{"DFA4 1 NFA States"}}
end
subgraph miniDFA4["miniDFA4 2 DFA States"]
DFA5_5{{"DFA5 1 NFA States"}}
DFA9_6{{"DFA9 1 NFA States"}}
end
subgraph miniDFA8["miniDFA8 1 DFA States"]
DFA6_7{{"DFA6 1 NFA States"}}
end
subgraph miniDFA6["miniDFA6 1 DFA States"]
DFA7_8{{"DFA7 1 NFA States"}}
end
subgraph miniDFA9["miniDFA9 2 DFA States"]
DFA8_9{{"DFA8 1 NFA States"}}
DFA11_10{{"DFA11 1 NFA States"}}
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA10_11{{"DFA10 1 NFA States"}}
end
subgraph miniDFA10["miniDFA10 1 DFA States"]
DFA12_12{{"DFA12 1 NFA States"}}
end
subgraph miniDFA7["miniDFA7 1 DFA States"]
DFA13_13{{"DFA13 1 NFA States"}}
end
miniDFA0 -->|"[0-9]"|miniDFA3
miniDFA0 -->|"[-+]"|miniDFA5
miniDFA3 -->|"[fF]"|miniDFA11
miniDFA3 -->|"[Ee]"|miniDFA1
miniDFA3 -->|"[.]"|miniDFA4
miniDFA3 -->|"[0-9]"|miniDFA3
miniDFA5 -->|"[0-9]"|miniDFA3
miniDFA1 -->|"[0-9]"|miniDFA8
miniDFA1 -->|"[-+]"|miniDFA6
miniDFA4 -->|"[fF]"|miniDFA11
miniDFA4 -->|"[Ee]"|miniDFA1
miniDFA4 -->|"[.]"|miniDFA9
miniDFA4 -->|"[0-9]"|miniDFA4
miniDFA8 -->|"[fF]"|miniDFA11
miniDFA8 -->|"[Ee]"|miniDFA2
miniDFA8 -->|"[0-9]"|miniDFA8
miniDFA6 -->|"[0-9]"|miniDFA8
miniDFA9 -->|"[fF]"|miniDFA11
miniDFA9 -->|"[Ee]"|miniDFA1
miniDFA9 -->|"[0-9]"|miniDFA9
miniDFA2 -->|"[0-9]"|miniDFA10
miniDFA2 -->|"[-+]"|miniDFA7
miniDFA10 -->|"[fF]"|miniDFA11
miniDFA10 -->|"[0-9]"|miniDFA10
miniDFA7 -->|"[0-9]"|miniDFA10
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
miniDFA5(["miniDFA5 1 DFA States"])
miniDFA11(["miniDFA11 1 DFA States"])
miniDFA1(["miniDFA1 1 DFA States"])
miniDFA4(["miniDFA4 2 DFA States"])
miniDFA8(["miniDFA8 1 DFA States"])
miniDFA6(["miniDFA6 1 DFA States"])
miniDFA9(["miniDFA9 2 DFA States"])
miniDFA2(["miniDFA2 1 DFA States"])
miniDFA10(["miniDFA10 1 DFA States"])
miniDFA7(["miniDFA7 1 DFA States"])
miniDFA0 -->|"[0-9]"|miniDFA3
miniDFA0 -->|"[-+]"|miniDFA5
miniDFA3 -->|"[fF]"|miniDFA11
miniDFA3 -->|"[Ee]"|miniDFA1
miniDFA3 -->|"[.]"|miniDFA4
miniDFA3 -->|"[0-9]"|miniDFA3
miniDFA5 -->|"[0-9]"|miniDFA3
miniDFA1 -->|"[0-9]"|miniDFA8
miniDFA1 -->|"[-+]"|miniDFA6
miniDFA4 -->|"[fF]"|miniDFA11
miniDFA4 -->|"[Ee]"|miniDFA1
miniDFA4 -->|"[.]"|miniDFA9
miniDFA4 -->|"[0-9]"|miniDFA4
miniDFA8 -->|"[fF]"|miniDFA11
miniDFA8 -->|"[Ee]"|miniDFA2
miniDFA8 -->|"[0-9]"|miniDFA8
miniDFA6 -->|"[0-9]"|miniDFA8
miniDFA9 -->|"[fF]"|miniDFA11
miniDFA9 -->|"[Ee]"|miniDFA1
miniDFA9 -->|"[0-9]"|miniDFA9
miniDFA2 -->|"[0-9]"|miniDFA10
miniDFA2 -->|"[-+]"|miniDFA7
miniDFA10 -->|"[fF]"|miniDFA11
miniDFA10 -->|"[0-9]"|miniDFA10
miniDFA7 -->|"[0-9]"|miniDFA10
```
-------------------------------
