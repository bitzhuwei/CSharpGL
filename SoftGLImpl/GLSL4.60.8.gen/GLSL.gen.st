#extractor <GLSL4.60.8.st.ext>

// 347 regulations:
translation_unit : 
    external_declaration // [0] [0]
  | translation_unit external_declaration ; // [1] [1]
external_declaration : 
    function_definition // [0] [2]
  | declaration // [1] [3]
  | ';' ; // [2] [4]
function_definition : 
    function_prototype compound_statement ; // [0] [5]
variable_identifier : 
    'identifier' ; // [0] [6]
primary_expression : 
    variable_identifier // [0] [7]
  | 'intConstant' // [1] [8]
  | 'uintConstant' // [2] [9]
  | 'floatConstant' // [3] [10]
  | 'boolConstant' // [4] [11]
  | 'doubleConstant' // [5] [12]
  | '(' expression ')' ; // [6] [13]
postfix_expression : 
    primary_expression // [0] [14]
  | postfix_expression '[' integer_expression ']' // [1] [15]
  | function_call // [2] [16]
  | postfix_expression '.' 'identifier' // [3] [17]
  | postfix_expression '++' // [4] [18]
  | postfix_expression '--' ; // [5] [19]
integer_expression : 
    expression ; // [0] [20]
function_call : 
    function_call_or_method ; // [0] [21]
function_call_or_method : 
    function_call_generic ; // [0] [22]
function_call_generic : 
    function_call_header_with_parameters ')' // [0] [23]
  | function_call_header_no_parameters ')' ; // [1] [24]
function_call_header_no_parameters : 
    function_call_header 'void' // [0] [25]
  | function_call_header ; // [1] [26]
function_call_header_with_parameters : 
    function_call_header assignment_expression // [0] [27]
  | function_call_header_with_parameters ',' assignment_expression ; // [1] [28]
function_call_header : 
    function_identifier '(' ; // [0] [29]
function_identifier : 
    type_specifier // [0] [30]
  | postfix_expression ; // [1] [31]
unary_expression : 
    postfix_expression // [0] [32]
  | '++' unary_expression // [1] [33]
  | '--' unary_expression // [2] [34]
  | unary_operator unary_expression ; // [3] [35]
unary_operator : 
    '+' // [0] [36]
  | '-' // [1] [37]
  | '!' // [2] [38]
  | '~' ; // [3] [39]
multiplicative_expression : 
    unary_expression // [0] [40]
  | multiplicative_expression '*' unary_expression // [1] [41]
  | multiplicative_expression '/' unary_expression // [2] [42]
  | multiplicative_expression '%' unary_expression ; // [3] [43]
additive_expression : 
    multiplicative_expression // [0] [44]
  | additive_expression '+' multiplicative_expression // [1] [45]
  | additive_expression '-' multiplicative_expression ; // [2] [46]
shift_expression : 
    additive_expression // [0] [47]
  | shift_expression '<<' additive_expression // [1] [48]
  | shift_expression '>>' additive_expression ; // [2] [49]
relational_expression : 
    shift_expression // [0] [50]
  | relational_expression '<' shift_expression // [1] [51]
  | relational_expression '>' shift_expression // [2] [52]
  | relational_expression '<=' shift_expression // [3] [53]
  | relational_expression '>=' shift_expression ; // [4] [54]
equality_expression : 
    relational_expression // [0] [55]
  | equality_expression '==' relational_expression // [1] [56]
  | equality_expression '!=' relational_expression ; // [2] [57]
and_expression : 
    equality_expression // [0] [58]
  | and_expression '&' equality_expression ; // [1] [59]
exclusive_or_expression : 
    and_expression // [0] [60]
  | exclusive_or_expression '^' and_expression ; // [1] [61]
inclusive_or_expression : 
    exclusive_or_expression // [0] [62]
  | inclusive_or_expression '|' exclusive_or_expression ; // [1] [63]
logical_and_expression : 
    inclusive_or_expression // [0] [64]
  | logical_and_expression '&&' inclusive_or_expression ; // [1] [65]
logical_xor_expression : 
    logical_and_expression // [0] [66]
  | logical_xor_expression '^^' logical_and_expression ; // [1] [67]
logical_or_expression : 
    logical_xor_expression // [0] [68]
  | logical_or_expression '||' logical_xor_expression ; // [1] [69]
conditional_expression : 
    logical_or_expression // [0] [70]
  | logical_or_expression '?' expression ':' assignment_expression ; // [1] [71]
assignment_expression : 
    conditional_expression // [0] [72]
  | unary_expression assignment_operator assignment_expression ; // [1] [73]
assignment_operator : 
    '=' // [0] [74]
  | '*=' // [1] [75]
  | '/=' // [2] [76]
  | '%=' // [3] [77]
  | '+=' // [4] [78]
  | '-=' // [5] [79]
  | '<<=' // [6] [80]
  | '>>=' // [7] [81]
  | '&=' // [8] [82]
  | '^=' // [9] [83]
  | '|=' ; // [10] [84]
expression : 
    assignment_expression // [0] [85]
  | expression ',' assignment_expression ; // [1] [86]
constant_expression : 
    conditional_expression ; // [0] [87]
declaration : 
    function_prototype ';' // [0] [88]
  | init_declarator_list ';' // [1] [89]
  | 'precision' precision_qualifier type_specifier ';' // [2] [90]
  | type_qualifier 'identifier' '{' struct_declaration_list '}' ';' // [3] [91]
  | type_qualifier 'identifier' '{' struct_declaration_list '}' 'identifier' ';' // [4] [92]
  | type_qualifier 'identifier' '{' struct_declaration_list '}' 'identifier' array_specifier ';' // [5] [93]
  | type_qualifier ';' // [6] [94]
  | type_qualifier 'identifier' ';' // [7] [95]
  | type_qualifier 'identifier' identifier_list ';' ; // [8] [96]
identifier_list : 
    ',' 'identifier' // [0] [97]
  | identifier_list ',' 'identifier' ; // [1] [98]
function_prototype : 
    function_declarator ')' ; // [0] [99]
function_declarator : 
    function_header // [0] [100]
  | function_header_with_parameters ; // [1] [101]
function_header_with_parameters : 
    function_header parameter_declaration // [0] [102]
  | function_header_with_parameters ',' parameter_declaration ; // [1] [103]
function_header : 
    fully_specified_type 'identifier' '(' ; // [0] [104]
parameter_declarator : 
    type_specifier 'identifier' // [0] [105]
  | type_specifier 'identifier' array_specifier ; // [1] [106]
parameter_declaration : 
    type_qualifier parameter_declarator // [0] [107]
  | parameter_declarator // [1] [108]
  | type_qualifier parameter_type_specifier // [2] [109]
  | parameter_type_specifier ; // [3] [110]
parameter_type_specifier : 
    type_specifier ; // [0] [111]
init_declarator_list : 
    single_declaration // [0] [112]
  | init_declarator_list ',' 'identifier' // [1] [113]
  | init_declarator_list ',' 'identifier' array_specifier // [2] [114]
  | init_declarator_list ',' 'identifier' array_specifier '=' initializer // [3] [115]
  | init_declarator_list ',' 'identifier' '=' initializer ; // [4] [116]
single_declaration : 
    fully_specified_type // [0] [117]
  | fully_specified_type 'identifier' // [1] [118]
  | fully_specified_type 'identifier' array_specifier // [2] [119]
  | fully_specified_type 'identifier' array_specifier '=' initializer // [3] [120]
  | fully_specified_type 'identifier' '=' initializer ; // [4] [121]
fully_specified_type : 
    type_specifier // [0] [122]
  | type_qualifier type_specifier ; // [1] [123]
invariant_qualifier : 
    'invariant' ; // [0] [124]
interpolation_qualifier : 
    'smooth' // [0] [125]
  | 'flat' // [1] [126]
  | 'noperspective' ; // [2] [127]
layout_qualifier : 
    'layout' '(' layout_qualifier_id_list ')' ; // [0] [128]
layout_qualifier_id_list : 
    layout_qualifier_id // [0] [129]
  | layout_qualifier_id_list ',' layout_qualifier_id ; // [1] [130]
layout_qualifier_id : 
    'identifier' // [0] [131]
  | 'identifier' '=' constant_expression // [1] [132]
  | 'shared' ; // [2] [133]
precise_qualifier : 
    'precise' ; // [0] [134]
type_qualifier : 
    single_type_qualifier // [0] [135]
  | type_qualifier single_type_qualifier ; // [1] [136]
single_type_qualifier : 
    storage_qualifier // [0] [137]
  | layout_qualifier // [1] [138]
  | precision_qualifier // [2] [139]
  | interpolation_qualifier // [3] [140]
  | invariant_qualifier // [4] [141]
  | precise_qualifier ; // [5] [142]
storage_qualifier : 
    'const' // [0] [143]
  | 'in' // [1] [144]
  | 'out' // [2] [145]
  | 'inout' // [3] [146]
  | 'centroid' // [4] [147]
  | 'patch' // [5] [148]
  | 'sample' // [6] [149]
  | 'uniform' // [7] [150]
  | 'buffer' // [8] [151]
  | 'shared' // [9] [152]
  | 'coherent' // [10] [153]
  | 'volatile' // [11] [154]
  | 'restrict' // [12] [155]
  | 'readonly' // [13] [156]
  | 'writeonly' // [14] [157]
  | 'subroutine' // [15] [158]
  | 'subroutine' '(' type_name_list ')' ; // [16] [159]
type_name_list : 
    'type_name' // [0] [160]
  | type_name_list ',' 'type_name' ; // [1] [161]
type_specifier : 
    type_specifier_nonarray // [0] [162]
  | type_specifier_nonarray array_specifier ; // [1] [163]
array_specifier : 
    '[' ']' // [0] [164]
  | '[' conditional_expression ']' // [1] [165]
  | array_specifier '[' ']' // [2] [166]
  | array_specifier '[' conditional_expression ']' ; // [3] [167]
type_specifier_nonarray : 
    'void' // [0] [168]
  | 'float' // [1] [169]
  | 'double' // [2] [170]
  | 'int' // [3] [171]
  | 'uint' // [4] [172]
  | 'bool' // [5] [173]
  | 'vec2' // [6] [174]
  | 'vec3' // [7] [175]
  | 'vec4' // [8] [176]
  | 'dvec2' // [9] [177]
  | 'dvec3' // [10] [178]
  | 'dvec4' // [11] [179]
  | 'bvec2' // [12] [180]
  | 'bvec3' // [13] [181]
  | 'bvec4' // [14] [182]
  | 'ivec2' // [15] [183]
  | 'ivec3' // [16] [184]
  | 'ivec4' // [17] [185]
  | 'uvec2' // [18] [186]
  | 'uvec3' // [19] [187]
  | 'uvec4' // [20] [188]
  | 'mat2' // [21] [189]
  | 'mat3' // [22] [190]
  | 'mat4' // [23] [191]
  | 'mat2x2' // [24] [192]
  | 'mat2x3' // [25] [193]
  | 'mat2x4' // [26] [194]
  | 'mat3x2' // [27] [195]
  | 'mat3x3' // [28] [196]
  | 'mat3x4' // [29] [197]
  | 'mat4x2' // [30] [198]
  | 'mat4x3' // [31] [199]
  | 'mat4x4' // [32] [200]
  | 'dmat2' // [33] [201]
  | 'dmat3' // [34] [202]
  | 'dmat4' // [35] [203]
  | 'dmat2x2' // [36] [204]
  | 'dmat2x3' // [37] [205]
  | 'dmat2x4' // [38] [206]
  | 'dmat3x2' // [39] [207]
  | 'dmat3x3' // [40] [208]
  | 'dmat3x4' // [41] [209]
  | 'dmat4x2' // [42] [210]
  | 'dmat4x3' // [43] [211]
  | 'dmat4x4' // [44] [212]
  | 'atomic_uint' // [45] [213]
  | 'sampler2D' // [46] [214]
  | 'sampler3D' // [47] [215]
  | 'samplerCube' // [48] [216]
  | 'sampler2DShadow' // [49] [217]
  | 'samplerCubeShadow' // [50] [218]
  | 'sampler2DArray' // [51] [219]
  | 'sampler2DArrayShadow' // [52] [220]
  | 'samplerCubeArray' // [53] [221]
  | 'samplerCubeArrayShadow' // [54] [222]
  | 'isampler2D' // [55] [223]
  | 'isampler3D' // [56] [224]
  | 'isamplerCube' // [57] [225]
  | 'isampler2DArray' // [58] [226]
  | 'isamplerCubeArray' // [59] [227]
  | 'usampler2D' // [60] [228]
  | 'usampler3D' // [61] [229]
  | 'usamplerCube' // [62] [230]
  | 'usampler2DArray' // [63] [231]
  | 'usamplerCubeArray' // [64] [232]
  | 'sampler1D' // [65] [233]
  | 'sampler1DShadow' // [66] [234]
  | 'sampler1DArray' // [67] [235]
  | 'sampler1DArrayShadow' // [68] [236]
  | 'isampler1D' // [69] [237]
  | 'isampler1DArray' // [70] [238]
  | 'usampler1D' // [71] [239]
  | 'usampler1DArray' // [72] [240]
  | 'sampler2DRect' // [73] [241]
  | 'sampler2DRectShadow' // [74] [242]
  | 'isampler2DRect' // [75] [243]
  | 'usampler2DRect' // [76] [244]
  | 'samplerBuffer' // [77] [245]
  | 'isamplerBuffer' // [78] [246]
  | 'usamplerBuffer' // [79] [247]
  | 'sampler2DMS' // [80] [248]
  | 'isampler2DMS' // [81] [249]
  | 'usampler2DMS' // [82] [250]
  | 'sampler2DMSArray' // [83] [251]
  | 'isampler2DMSArray' // [84] [252]
  | 'usampler2DMSArray' // [85] [253]
  | 'image2D' // [86] [254]
  | 'iimage2D' // [87] [255]
  | 'uimage2D' // [88] [256]
  | 'image3D' // [89] [257]
  | 'iimage3D' // [90] [258]
  | 'uimage3D' // [91] [259]
  | 'imageCube' // [92] [260]
  | 'iimageCube' // [93] [261]
  | 'uimageCube' // [94] [262]
  | 'imageBuffer' // [95] [263]
  | 'iimageBuffer' // [96] [264]
  | 'uimageBuffer' // [97] [265]
  | 'image1D' // [98] [266]
  | 'iimage1D' // [99] [267]
  | 'uimage1D' // [100] [268]
  | 'image1DArray' // [101] [269]
  | 'iimage1DArray' // [102] [270]
  | 'uimage1DArray' // [103] [271]
  | 'image2DRect' // [104] [272]
  | 'iimage2DRect' // [105] [273]
  | 'uimage2DRect' // [106] [274]
  | 'image2DArray' // [107] [275]
  | 'iimage2DArray' // [108] [276]
  | 'uimage2DArray' // [109] [277]
  | 'imageCubeArray' // [110] [278]
  | 'iimageCubeArray' // [111] [279]
  | 'uimageCubeArray' // [112] [280]
  | 'image2DMS' // [113] [281]
  | 'iimage2DMS' // [114] [282]
  | 'uimage2DMS' // [115] [283]
  | 'image2DMSArray' // [116] [284]
  | 'iimage2DMSArray' // [117] [285]
  | 'uimage2DMSArray' // [118] [286]
  | struct_specifier // [119] [287]
  | 'type_name' ; // [120] [288]
precision_qualifier : 
    'highp' // [0] [289]
  | 'mediump' // [1] [290]
  | 'lowp' ; // [2] [291]
struct_specifier : 
    'struct' 'type_name' '{' struct_declaration_list '}' // [0] [292]
  | 'struct' '{' struct_declaration_list '}' ; // [1] [293]
struct_declaration_list : 
    struct_declaration // [0] [294]
  | struct_declaration_list struct_declaration ; // [1] [295]
struct_declaration : 
    type_specifier struct_declarator_list ';' // [0] [296]
  | type_qualifier type_specifier struct_declarator_list ';' ; // [1] [297]
struct_declarator_list : 
    struct_declarator // [0] [298]
  | struct_declarator_list ',' struct_declarator ; // [1] [299]
struct_declarator : 
    'identifier' // [0] [300]
  | 'identifier' array_specifier ; // [1] [301]
initializer : 
    assignment_expression // [0] [302]
  | '{' initializer_list '}' // [1] [303]
  | '{' initializer_list ',' '}' ; // [2] [304]
initializer_list : 
    initializer // [0] [305]
  | initializer_list ',' initializer ; // [1] [306]
declaration_statement : 
    declaration ; // [0] [307]
statement : 
    compound_statement // [0] [308]
  | simple_statement ; // [1] [309]
simple_statement : 
    declaration_statement // [0] [310]
  | expression_statement // [1] [311]
  | selection_statement // [2] [312]
  | switch_statement // [3] [313]
  | case_label // [4] [314]
  | iteration_statement // [5] [315]
  | jump_statement ; // [6] [316]
compound_statement : 
    '{' '}' // [0] [317]
  | '{' statement_list '}' ; // [1] [318]
statement_list : 
    statement // [0] [319]
  | statement_list statement ; // [1] [320]
expression_statement : 
    ';' // [0] [321]
  | expression ';' ; // [1] [322]
selection_statement : 
    'if' '(' expression ')' selection_rest_statement ; // [0] [323]
selection_rest_statement : 
    statement 'else' statement // [0] [324]
  | statement ; // [1] [325]
condition : 
    expression // [0] [326]
  | fully_specified_type 'identifier' '=' initializer ; // [1] [327]
switch_statement : 
    'switch' '(' expression ')' '{' switch_statement_list '}' ; // [0] [328]
switch_statement_list : 
    null // [0] [329]
  | statement_list ; // [1] [330]
case_label : 
    'case' expression ':' // [0] [331]
  | 'default' ':' ; // [1] [332]
iteration_statement : 
    'while' '(' condition ')' statement // [0] [333]
  | 'do' statement 'while' '(' expression ')' ';' // [1] [334]
  | 'for' '(' for_init_statement for_rest_statement ')' statement ; // [2] [335]
for_init_statement : 
    expression_statement // [0] [336]
  | declaration_statement ; // [1] [337]
conditionopt : 
    condition // [0] [338]
  | null ; // [1] [339]
for_rest_statement : 
    conditionopt ';' // [0] [340]
  | conditionopt ';' expression ; // [1] [341]
jump_statement : 
    'continue' ';' // [0] [342]
  | 'break' ';' // [1] [343]
  | 'return' ';' // [2] [344]
  | 'return' expression ';' // [3] [345]
  | 'discard' ';' ; // [4] [346]

// 15 token statements:
%%<'struct'>[a-zA-Z_][a-zA-Z0-9_]*%% 'type_name' // [0]
%%subroutine%% 'subroutine' subroutine0 // [1]
<subroutine0>%%[(]%% '(' subroutine1 // [2]
<subroutine1>%%[a-zA-Z_][a-zA-Z0-9_]*%% 'type_name'  // [3]
<subroutine1>%%[,]%% ','  // [4]
<subroutine1>%%[)]%% ')' default // [5]
%%[-+]?[0-9]+%% 'intConstant' // [6]
%%0x[0-9A-Fa-f]+%% 'intConstant' // [7]
%%[-+]?[0-9]+[uU]%% 'uintConstant' // [8]
%%0x[0-9A-Fa-f]+[uU]%% 'uintConstant' // [9]
%%[-+]?[0-9]+([.][0-9]*)?([Ee][-+]?[0-9]+)?[fF]%% 'floatConstant' // [10]
%%true/[^a-zA-Z0-9_]%% 'boolConstant' // [11]
%%false/[^a-zA-Z0-9_]%% 'boolConstant' // [12]
%%[-+]?[0-9]+([.][0-9]*)?([Ee][-+]?[0-9]+)?%% 'doubleConstant' // [13]
%%[a-zA-Z_][a-zA-Z0-9_]*%% 'identifier' // [14]

// 0 precedences

// options
%grammarName GLSL
%start translation_unit
%blockComment on
%inlineComment on
%validScopeChars [\u0001-\uFFFF]
%validGlobalChars [\u0001-\uFFFF]

