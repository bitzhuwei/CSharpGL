# Vt: 'type_name'

patterns[0]: `<'struct'>[a-zA-Z_][a-zA-Z0-9_]*`

patterns[1]: `[a-zA-Z_][a-zA-Z0-9_]*`

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
eNFA0_3[["εNFA0-3 regex start"]]
eNFA1_3[["εNFA1-3 regex start"]]
eNFA0_0[["εNFA0-0 scope{1, 1}"]]
eNFA1_0[["εNFA1-0 scope{1, 1}"]]
eNFA0_1[["εNFA0-1 scope[1]"]]
eNFA1_1[["εNFA1-1 scope[1]"]]
eNFA0_2[["εNFA0-2 scope{0, -1}"]]
eNFA1_2[["εNFA1-2 scope{0, -1}"]]
eNFA0_4[["εNFA0-4 regex end"]]
eNFA1_4[["εNFA1-4 regex end"]]
eNFA0_5[["εNFA0-5 post-regex start"]]
eNFA1_5[["εNFA1-5 post-regex start"]]
eNFA0_6[\"εNFA0-6 post-regex end"/]
eNFA1_6[\"εNFA1-6 post-regex end"/]
eNFA0_1[\"εNFA0-1 End of this Vt"/]
eNFA0_0 -.->|"ε"|eNFA0_3
eNFA0_0 -.->|"ε"|eNFA1_3
eNFA0_3 -.->|"ε"|eNFA0_0
eNFA1_3 -.->|"ε"|eNFA1_0
eNFA0_0 -->|"[a-zA-Z_]"|eNFA0_1
eNFA1_0 -->|"[a-zA-Z_]"|eNFA1_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA0_2 -->|"[a-zA-Z0-9_]"|eNFA0_2
eNFA0_2 -.->|"ε"|eNFA0_4
eNFA1_2 -->|"[a-zA-Z0-9_]"|eNFA1_2
eNFA1_2 -.->|"ε"|eNFA1_4
eNFA0_4 -.->|"ε"|eNFA0_5
eNFA1_4 -.->|"ε"|eNFA1_5
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA0_6 -.->|"ε"|eNFA0_1
eNFA1_6 -.->|"ε"|eNFA0_1
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
eNFA0_3[["εNFA0-3 regex start"]]
eNFA1_3[["εNFA1-3 regex start"]]
eNFA0_0[["εNFA0-0 scope{1, 1}"]]
eNFA1_0[["εNFA1-0 scope{1, 1}"]]
eNFA0_1[\"εNFA0-1 scope[1]"/]
eNFA1_1[\"εNFA1-1 scope[1]"/]
eNFA0_2[\"εNFA0-2 scope{0, -1}"/]
eNFA0_4[\"εNFA0-4 regex end"/]
eNFA0_5[\"εNFA0-5 post-regex start"/]
eNFA0_6[\"εNFA0-6 post-regex end"/]
eNFA0_1[\"εNFA0-1 End of this Vt"/]
eNFA1_2[\"εNFA1-2 scope{0, -1}"/]
eNFA1_4[\"εNFA1-4 regex end"/]
eNFA1_5[\"εNFA1-5 post-regex start"/]
eNFA1_6[\"εNFA1-6 post-regex end"/]
eNFA0_0 -.->|"ε"|eNFA0_3
eNFA0_0 -.->|"ε"|eNFA1_3
eNFA0_0 -.->|"ε"|eNFA0_0
eNFA0_0 -.->|"ε"|eNFA1_0
eNFA0_0 -->|"[a-zA-Z_]"|eNFA0_1
eNFA0_0 -->|"[a-zA-Z_]"|eNFA1_1
eNFA0_3 -.->|"ε"|eNFA0_0
eNFA0_3 -->|"[a-zA-Z_]"|eNFA0_1
eNFA1_3 -.->|"ε"|eNFA1_0
eNFA1_3 -->|"[a-zA-Z_]"|eNFA1_1
eNFA0_0 -->|"[a-zA-Z_]"|eNFA0_1
eNFA1_0 -->|"[a-zA-Z_]"|eNFA1_1
eNFA0_1 -.->|"ε"|eNFA0_2
eNFA0_1 -->|"[a-zA-Z0-9_]"|eNFA0_2
eNFA0_1 -.->|"ε"|eNFA0_4
eNFA0_1 -.->|"ε"|eNFA0_5
eNFA0_1 -.->|"ε"|eNFA0_6
eNFA0_1 -.->|"ε"|eNFA0_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"[a-zA-Z0-9_]"|eNFA1_2
eNFA1_1 -.->|"ε"|eNFA1_4
eNFA1_1 -.->|"ε"|eNFA1_5
eNFA1_1 -.->|"ε"|eNFA1_6
eNFA1_1 -.->|"ε"|eNFA0_1
eNFA0_2 -->|"[a-zA-Z0-9_]"|eNFA0_2
eNFA0_2 -.->|"ε"|eNFA0_4
eNFA0_2 -.->|"ε"|eNFA0_5
eNFA0_2 -.->|"ε"|eNFA0_6
eNFA0_2 -.->|"ε"|eNFA0_1
eNFA0_4 -.->|"ε"|eNFA0_5
eNFA0_4 -.->|"ε"|eNFA0_6
eNFA0_4 -.->|"ε"|eNFA0_1
eNFA0_5 -.->|"ε"|eNFA0_6
eNFA0_5 -.->|"ε"|eNFA0_1
eNFA0_6 -.->|"ε"|eNFA0_1
eNFA1_2 -->|"[a-zA-Z0-9_]"|eNFA1_2
eNFA1_2 -.->|"ε"|eNFA1_4
eNFA1_2 -.->|"ε"|eNFA1_5
eNFA1_2 -.->|"ε"|eNFA1_6
eNFA1_2 -.->|"ε"|eNFA0_1
eNFA1_4 -.->|"ε"|eNFA1_5
eNFA1_4 -.->|"ε"|eNFA1_6
eNFA1_4 -.->|"ε"|eNFA0_1
eNFA1_5 -.->|"ε"|eNFA1_6
eNFA1_5 -.->|"ε"|eNFA0_1
eNFA1_6 -.->|"ε"|eNFA0_1
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
NFA0_1[\"NFA0-1 scope[1]"/]
NFA1_1[\"NFA1-1 scope[1]"/]
NFA0_2[\"NFA0-2 scope{0, -1}"/]
NFA1_2[\"NFA1-2 scope{0, -1}"/]
NFA0_0 -->|"[a-zA-Z_]"|NFA0_1
NFA0_0 -->|"[a-zA-Z_]"|NFA1_1
NFA0_1 -->|"[a-zA-Z0-9_]"|NFA0_2
NFA1_1 -->|"[a-zA-Z0-9_]"|NFA1_2
NFA0_2 -->|"[a-zA-Z0-9_]"|NFA0_2
NFA1_2 -->|"[a-zA-Z0-9_]"|NFA1_2
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
subgraph DFA1["DFA1 2 NFA States"]
NFA0_1_1[\"NFA0-1 scope[1]"/]
NFA1_1_2[\"NFA1-1 scope[1]"/]
end
subgraph DFA2["DFA2 2 NFA States"]
NFA0_2_3[\"NFA0-2 scope{0, -1}"/]
NFA1_2_4[\"NFA1-2 scope{0, -1}"/]
end
DFA0 -->|"[a-zA-Z_]"|DFA1
DFA1 -->|"[a-zA-Z0-9_]"|DFA2
DFA2 -->|"[a-zA-Z0-9_]"|DFA2
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
DFA1[\"DFA1 2 NFA States"/]
DFA2[\"DFA2 2 NFA States"/]
DFA0 -->|"[a-zA-Z_]"|DFA1
DFA1 -->|"[a-zA-Z0-9_]"|DFA2
DFA2 -->|"[a-zA-Z0-9_]"|DFA2
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
DFA1_1[\"DFA1 2 NFA States"/]
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA2_2[\"DFA2 2 NFA States"/]
end
miniDFA0 -->|"[a-zA-Z_]"|miniDFA1
miniDFA1 -->|"[a-zA-Z0-9_]"|miniDFA2
miniDFA2 -->|"[a-zA-Z0-9_]"|miniDFA2
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
miniDFA0 -->|"[a-zA-Z_]"|miniDFA1
miniDFA1 -->|"[a-zA-Z0-9_]"|miniDFA2
miniDFA2 -->|"[a-zA-Z0-9_]"|miniDFA2
```
-------------------------------
pattern: `<'struct'>[a-zA-Z_][a-zA-Z0-9_]*`

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
eNFA1_3[["εNFA1-3 regex start"]]
eNFA1_0[["εNFA1-0 scope{1, 1}"]]
eNFA1_1[["εNFA1-1 scope[1]"]]
eNFA1_2[["εNFA1-2 scope{0, -1}"]]
eNFA1_4[["εNFA1-4 regex end"]]
eNFA1_5[["εNFA1-5 post-regex start"]]
eNFA1_6[\"εNFA1-6 post-regex end"/]
eNFA1_3 -.->|"ε"|eNFA1_0
eNFA1_0 -->|"[a-zA-Z_]"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_2 -->|"[a-zA-Z0-9_]"|eNFA1_2
eNFA1_2 -.->|"ε"|eNFA1_4
eNFA1_4 -.->|"ε"|eNFA1_5
eNFA1_5 -.->|"ε"|eNFA1_6
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
eNFA1_3[["εNFA1-3 regex start"]]
eNFA1_0[["εNFA1-0 scope{1, 1}"]]
eNFA1_1[\"εNFA1-1 scope[1]"/]
eNFA1_2[\"εNFA1-2 scope{0, -1}"/]
eNFA1_4[\"εNFA1-4 regex end"/]
eNFA1_5[\"εNFA1-5 post-regex start"/]
eNFA1_6[\"εNFA1-6 post-regex end"/]
eNFA1_3 -.->|"ε"|eNFA1_0
eNFA1_3 -->|"[a-zA-Z_]"|eNFA1_1
eNFA1_0 -->|"[a-zA-Z_]"|eNFA1_1
eNFA1_1 -.->|"ε"|eNFA1_2
eNFA1_1 -->|"[a-zA-Z0-9_]"|eNFA1_2
eNFA1_1 -.->|"ε"|eNFA1_4
eNFA1_1 -.->|"ε"|eNFA1_5
eNFA1_1 -.->|"ε"|eNFA1_6
eNFA1_2 -->|"[a-zA-Z0-9_]"|eNFA1_2
eNFA1_2 -.->|"ε"|eNFA1_4
eNFA1_2 -.->|"ε"|eNFA1_5
eNFA1_2 -.->|"ε"|eNFA1_6
eNFA1_4 -.->|"ε"|eNFA1_5
eNFA1_4 -.->|"ε"|eNFA1_6
eNFA1_5 -.->|"ε"|eNFA1_6
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
NFA1_3("NFA1-3 regex start")
NFA1_1[\"NFA1-1 scope[1]"/]
NFA1_2[\"NFA1-2 scope{0, -1}"/]
NFA1_3 -->|"[a-zA-Z_]"|NFA1_1
NFA1_1 -->|"[a-zA-Z0-9_]"|NFA1_2
NFA1_2 -->|"[a-zA-Z0-9_]"|NFA1_2
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
NFA1_3_0("NFA1-3 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA1_1_1[\"NFA1-1 scope[1]"/]
end
subgraph DFA2["DFA2 1 NFA States"]
NFA1_2_2[\"NFA1-2 scope{0, -1}"/]
end
DFA0 -->|"[a-zA-Z_]"|DFA1
DFA1 -->|"[a-zA-Z0-9_]"|DFA2
DFA2 -->|"[a-zA-Z0-9_]"|DFA2
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
DFA2[\"DFA2 1 NFA States"/]
DFA0 -->|"[a-zA-Z_]"|DFA1
DFA1 -->|"[a-zA-Z0-9_]"|DFA2
DFA2 -->|"[a-zA-Z0-9_]"|DFA2
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
DFA1_1[\"DFA1 1 NFA States"/]
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA2_2[\"DFA2 1 NFA States"/]
end
miniDFA0 -->|"[a-zA-Z_]"|miniDFA1
miniDFA1 -->|"[a-zA-Z0-9_]"|miniDFA2
miniDFA2 -->|"[a-zA-Z0-9_]"|miniDFA2
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
miniDFA0 -->|"[a-zA-Z_]"|miniDFA1
miniDFA1 -->|"[a-zA-Z0-9_]"|miniDFA2
miniDFA2 -->|"[a-zA-Z0-9_]"|miniDFA2
```
-------------------------------
pattern: `[a-zA-Z_][a-zA-Z0-9_]*`

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
eNFA2_3[["εNFA2-3 regex start"]]
eNFA2_0[["εNFA2-0 scope{1, 1}"]]
eNFA2_1[["εNFA2-1 scope[1]"]]
eNFA2_2[["εNFA2-2 scope{0, -1}"]]
eNFA2_4[["εNFA2-4 regex end"]]
eNFA2_5[["εNFA2-5 post-regex start"]]
eNFA2_6[\"εNFA2-6 post-regex end"/]
eNFA2_3 -.->|"ε"|eNFA2_0
eNFA2_0 -->|"[a-zA-Z_]"|eNFA2_1
eNFA2_1 -.->|"ε"|eNFA2_2
eNFA2_2 -->|"[a-zA-Z0-9_]"|eNFA2_2
eNFA2_2 -.->|"ε"|eNFA2_4
eNFA2_4 -.->|"ε"|eNFA2_5
eNFA2_5 -.->|"ε"|eNFA2_6
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
eNFA2_3[["εNFA2-3 regex start"]]
eNFA2_0[["εNFA2-0 scope{1, 1}"]]
eNFA2_1[\"εNFA2-1 scope[1]"/]
eNFA2_2[\"εNFA2-2 scope{0, -1}"/]
eNFA2_4[\"εNFA2-4 regex end"/]
eNFA2_5[\"εNFA2-5 post-regex start"/]
eNFA2_6[\"εNFA2-6 post-regex end"/]
eNFA2_3 -.->|"ε"|eNFA2_0
eNFA2_3 -->|"[a-zA-Z_]"|eNFA2_1
eNFA2_0 -->|"[a-zA-Z_]"|eNFA2_1
eNFA2_1 -.->|"ε"|eNFA2_2
eNFA2_1 -->|"[a-zA-Z0-9_]"|eNFA2_2
eNFA2_1 -.->|"ε"|eNFA2_4
eNFA2_1 -.->|"ε"|eNFA2_5
eNFA2_1 -.->|"ε"|eNFA2_6
eNFA2_2 -->|"[a-zA-Z0-9_]"|eNFA2_2
eNFA2_2 -.->|"ε"|eNFA2_4
eNFA2_2 -.->|"ε"|eNFA2_5
eNFA2_2 -.->|"ε"|eNFA2_6
eNFA2_4 -.->|"ε"|eNFA2_5
eNFA2_4 -.->|"ε"|eNFA2_6
eNFA2_5 -.->|"ε"|eNFA2_6
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
NFA2_3("NFA2-3 regex start")
NFA2_1[\"NFA2-1 scope[1]"/]
NFA2_2[\"NFA2-2 scope{0, -1}"/]
NFA2_3 -->|"[a-zA-Z_]"|NFA2_1
NFA2_1 -->|"[a-zA-Z0-9_]"|NFA2_2
NFA2_2 -->|"[a-zA-Z0-9_]"|NFA2_2
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
NFA2_3_0("NFA2-3 regex start")
end
subgraph DFA1["DFA1 1 NFA States"]
NFA2_1_1[\"NFA2-1 scope[1]"/]
end
subgraph DFA2["DFA2 1 NFA States"]
NFA2_2_2[\"NFA2-2 scope{0, -1}"/]
end
DFA0 -->|"[a-zA-Z_]"|DFA1
DFA1 -->|"[a-zA-Z0-9_]"|DFA2
DFA2 -->|"[a-zA-Z0-9_]"|DFA2
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
DFA2[\"DFA2 1 NFA States"/]
DFA0 -->|"[a-zA-Z_]"|DFA1
DFA1 -->|"[a-zA-Z0-9_]"|DFA2
DFA2 -->|"[a-zA-Z0-9_]"|DFA2
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
DFA1_1[\"DFA1 1 NFA States"/]
end
subgraph miniDFA2["miniDFA2 1 DFA States"]
DFA2_2[\"DFA2 1 NFA States"/]
end
miniDFA0 -->|"[a-zA-Z_]"|miniDFA1
miniDFA1 -->|"[a-zA-Z0-9_]"|miniDFA2
miniDFA2 -->|"[a-zA-Z0-9_]"|miniDFA2
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
miniDFA0 -->|"[a-zA-Z_]"|miniDFA1
miniDFA1 -->|"[a-zA-Z0-9_]"|miniDFA2
miniDFA2 -->|"[a-zA-Z0-9_]"|miniDFA2
```
-------------------------------
