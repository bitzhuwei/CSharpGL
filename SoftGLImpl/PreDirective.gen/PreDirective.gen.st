// 126 regulations:
PreDirective : 
    MicroDefinition // [0] [0]
  | ConditionalCompilation // [1] [1]
  | ErrorDirective // [2] [2]
  | PragmaDirective // [3] [3]
  | ExtensionDirective // [4] [4]
  | VersionDirective // [5] [5]
  | LineDirective ; // [6] [6]
MicroDefinition : 
    '#define' 'identifier' '(' ParameterList ')' RandomTokens // [0] [7]
  | '#define' 'identifier' '(' ')' RandomTokens // [1] [8]
  | '#define' 'identifier' RandomTokens // [2] [9]
  | '#undef' 'identifier' ; // [3] [10]
ParameterList : 
    'identifier' // [0] [11]
  | ParameterList ',' 'identifier' ; // [1] [12]
RandomTokens : 
    RandomTokens RandomToken // [0] [13]
  | RandomToken // [1] [14]
  | null ; // [2] [15]
RandomToken : 
    'identifier' // [0] [16]
  | 'intConstant' // [1] [17]
  | 'uintConstant' // [2] [18]
  | 'floatConstant' // [3] [19]
  | 'boolConstant' // [4] [20]
  | 'doubleConstant' // [5] [21]
  | ';' // [6] [22]
  | '(' // [7] [23]
  | ')' // [8] [24]
  | '[' // [9] [25]
  | ']' // [10] [26]
  | '.' // [11] [27]
  | '++' // [12] [28]
  | '--' // [13] [29]
  | ',' // [14] [30]
  | '+' // [15] [31]
  | '-' // [16] [32]
  | '!' // [17] [33]
  | '~' // [18] [34]
  | '*' // [19] [35]
  | '/' // [20] [36]
  | '%' // [21] [37]
  | '<<' // [22] [38]
  | '>>' // [23] [39]
  | '<' // [24] [40]
  | '>' // [25] [41]
  | '<=' // [26] [42]
  | '>=' // [27] [43]
  | '==' // [28] [44]
  | '!=' // [29] [45]
  | '&' // [30] [46]
  | '^' // [31] [47]
  | '|' // [32] [48]
  | '&&' // [33] [49]
  | '^^' // [34] [50]
  | '||' // [35] [51]
  | '?' // [36] [52]
  | ':' // [37] [53]
  | '=' // [38] [54]
  | '*=' // [39] [55]
  | '/=' // [40] [56]
  | '%=' // [41] [57]
  | '+=' // [42] [58]
  | '-=' // [43] [59]
  | '<<=' // [44] [60]
  | '>>=' // [45] [61]
  | '&=' // [46] [62]
  | '^=' // [47] [63]
  | '|=' // [48] [64]
  | '{' // [49] [65]
  | '}' // [50] [66]
  | '##' ; // [51] [67]
ConditionalCompilation : 
    IfGroup // [0] [68]
  | ElseGroup // [1] [69]
  | ElifGroup // [2] [70]
  | EndifGroup ; // [3] [71]
IfGroup : 
    '#if' ConstExp // [0] [72]
  | '#ifdef' ConstExp // [1] [73]
  | '#ifndef' ConstExp ; // [2] [74]
ElseGroup : 
    '#else' ; // [0] [75]
ElifGroup : 
    '#elif' ConstExp ; // [0] [76]
EndifGroup : 
    '#endif' ; // [0] [77]
ErrorDirective : 
    '#error' 'literalString' ; // [0] [78]
PragmaDirective : 
    '#pragma' 'identifier' // [0] [79]
  | '#pragma' 'identifier' '(' ParameterList ')' // [1] [80]
  | '#pragma' 'identifier' '(' ')' ; // [2] [81]
ExtensionDirective : 
    '#extension' 'literalString' ':' 'literalString' ; // [0] [82]
VersionDirective : 
    '#version' 'number' // [0] [83]
  | '#version' 'number' 'identifier' ; // [1] [84]
LineDirective : 
    '#line' 'number' // [0] [85]
  | '#line' 'number' 'number' ; // [1] [86]
ConstExp : 
    OrOrExp ; // [0] [87]
OrOrExp : 
    AndAndExp // [0] [88]
  | OrOrExp '||' AndAndExp ; // [1] [89]
AndAndExp : 
    OrExp // [0] [90]
  | AndAndExp '&&' OrExp ; // [1] [91]
OrExp : 
    XorExp // [0] [92]
  | OrExp '|' XorExp ; // [1] [93]
XorExp : 
    AndExp // [0] [94]
  | XorExp '^' AndExp ; // [1] [95]
AndExp : 
    EqualExp // [0] [96]
  | AndExp '&' EqualExp ; // [1] [97]
EqualExp : 
    RelationExp // [0] [98]
  | EqualExp '==' RelationExp // [1] [99]
  | EqualExp '!=' RelationExp ; // [2] [100]
RelationExp : 
    ShiftExp // [0] [101]
  | RelationExp '<' ShiftExp // [1] [102]
  | RelationExp '>' ShiftExp // [2] [103]
  | RelationExp '<=' ShiftExp // [3] [104]
  | RelationExp '>=' ShiftExp ; // [4] [105]
ShiftExp : 
    AddExp // [0] [106]
  | ShiftExp '<<' AddExp // [1] [107]
  | ShiftExp '>>' AddExp ; // [2] [108]
AddExp : 
    MultiExp // [0] [109]
  | AddExp '+' MultiExp // [1] [110]
  | AddExp '-' MultiExp ; // [2] [111]
MultiExp : 
    UnaryExp // [0] [112]
  | MultiExp '*' UnaryExp // [1] [113]
  | MultiExp '/' UnaryExp // [2] [114]
  | MultiExp '%' UnaryExp ; // [3] [115]
UnaryExp : 
    PrimaryExp // [0] [116]
  | UnaryOp UnaryExp ; // [1] [117]
UnaryOp : 
    'defined' // [0] [118]
  | '+' // [1] [119]
  | '-' // [2] [120]
  | '~' // [3] [121]
  | '!' ; // [4] [122]
PrimaryExp : 
    'number' // [0] [123]
  | 'identifier' // [1] [124]
  | '(' ConstExp ')' ; // [2] [125]

// 11 token statements:
%%[a-zA-Z_][a-zA-Z0-9_]*%% 'identifier' // [0]
%%[a-zA-Z_]?"(\\.|[^\\"])*"%% 'literalString' // [1]
%%[0-9]+([.][0-9]+)?%% 'number' // [2]
%%[-+]?[0-9]+%% 'intConstant' // [3]
%%0x[0-9A-Fa-f]+%% 'intConstant' // [4]
%%[-+]?[0-9]+[uU]%% 'uintConstant' // [5]
%%0x[0-9A-Fa-f]+[uU]%% 'uintConstant' // [6]
%%[-+]?[0-9]+([.][0-9]*)?([Ee][-+]?[0-9]+)?[fF]%% 'floatConstant' // [7]
%%true/[^a-zA-Z0-9_]%% 'boolConstant' // [8]
%%false/[^a-zA-Z0-9_]%% 'boolConstant' // [9]
%%[-+]?[0-9]+([.][0-9]*)?([Ee][-+]?[0-9]+)?%% 'doubleConstant' // [10]

// 0 precedences

// options
%grammarName PreDirective
%start PreDirective
%blockComment off
%inlineComment on
%validScopeChars [\u0001-\uFFFF]
%validGlobalChars [\u0001-\uFFFF]

