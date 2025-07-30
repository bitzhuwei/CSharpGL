
using CSharpGL;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide7code {
    struct jitter_point {
        const int MAX_SAMPLES = 66;
        public GLfloat x;
        public GLfloat y;

        public jitter_point(GLfloat x, GLfloat y) {
            this.x = x; this.y = y;
        }

        /* 2 jitter points */
        public static jitter_point[] j2 = {
    new jitter_point( 0.246490f,  0.249999f),
    new jitter_point(-0.246490f, -0.249999f)
        };


        /* 3 jitter points */
        public static jitter_point[] j3 =
        {
    new jitter_point(-0.373411f, -0.250550f),
    new jitter_point( 0.256263f,  0.368119f),
    new jitter_point( 0.117148f, -0.117570f)
};


        /* 4 jitter points */
        public static jitter_point[] j4 =
        {
    new jitter_point(-0.208147f,  0.353730f),
    new jitter_point( 0.203849f, -0.353780f),
    new jitter_point(-0.292626f, -0.149945f),
    new jitter_point( 0.296924f,  0.149994f)
};


        /* 8 jitter points */
        public static jitter_point[] j8 =
        {
    new jitter_point(-0.334818f,  0.435331f),
    new jitter_point( 0.286438f, -0.393495f),
    new jitter_point( 0.459462f,  0.141540f),
    new jitter_point(-0.414498f, -0.192829f),
    new jitter_point(-0.183790f,  0.082102f),
    new jitter_point(-0.079263f, -0.317383f),
    new jitter_point( 0.102254f,  0.299133f),
    new jitter_point( 0.164216f, -0.054399f)
};


        /* 15 jitter points */
        public static jitter_point[] j15 =
        {
    new jitter_point( 0.285561f,  0.188437f),
    new jitter_point( 0.360176f, -0.065688f),
    new jitter_point(-0.111751f,  0.275019f),
    new jitter_point(-0.055918f, -0.215197f),
    new jitter_point(-0.080231f, -0.470965f),
    new jitter_point( 0.138721f,  0.409168f),
    new jitter_point( 0.384120f,  0.458500f),
    new jitter_point(-0.454968f,  0.134088f),
    new jitter_point( 0.179271f, -0.331196f),
    new jitter_point(-0.307049f, -0.364927f),
    new jitter_point( 0.105354f, -0.010099f),
    new jitter_point(-0.154180f,  0.021794f),
    new jitter_point(-0.370135f, -0.116425f),
    new jitter_point( 0.451636f, -0.300013f),
    new jitter_point(-0.370610f,  0.387504f)
};


        /* 24 jitter points */
        public static jitter_point[] j24 =
        {
    new jitter_point( 0.030245f,  0.136384f),
    new jitter_point( 0.018865f, -0.348867f),
    new jitter_point(-0.350114f, -0.472309f),
    new jitter_point( 0.222181f,  0.149524f),
    new jitter_point(-0.393670f, -0.266873f),
    new jitter_point( 0.404568f,  0.230436f),
    new jitter_point( 0.098381f,  0.465337f),
    new jitter_point( 0.462671f,  0.442116f),
    new jitter_point( 0.400373f, -0.212720f),
    new jitter_point(-0.409988f,  0.263345f),
    new jitter_point(-0.115878f, -0.001981f),
    new jitter_point( 0.348425f, -0.009237f),
    new jitter_point(-0.464016f,  0.066467f),
    new jitter_point(-0.138674f, -0.468006f),
    new jitter_point( 0.144932f, -0.022780f),
    new jitter_point(-0.250195f,  0.150161f),
    new jitter_point(-0.181400f, -0.264219f),
    new jitter_point( 0.196097f, -0.234139f),
    new jitter_point(-0.311082f, -0.078815f),
    new jitter_point( 0.268379f,  0.366778f),
    new jitter_point(-0.040601f,  0.327109f),
    new jitter_point(-0.234392f,  0.354659f),
    new jitter_point(-0.003102f, -0.154402f),
    new jitter_point( 0.297997f, -0.417965f)
};


        /* 66 jitter points */
        public static jitter_point[] j66 =
        {
    new jitter_point( 0.266377f, -0.218171f),
    new jitter_point(-0.170919f, -0.429368f),
    new jitter_point( 0.047356f, -0.387135f),
    new jitter_point(-0.430063f,  0.363413f),
    new jitter_point(-0.221638f, -0.313768f),
    new jitter_point( 0.124758f, -0.197109f),
    new jitter_point(-0.400021f,  0.482195f),
    new jitter_point( 0.247882f,  0.152010f),
    new jitter_point(-0.286709f, -0.470214f),
    new jitter_point(-0.426790f,  0.004977f),
    new jitter_point(-0.361249f, -0.104549f),
    new jitter_point(-0.040643f,  0.123453f),
    new jitter_point(-0.189296f,  0.438963f),
    new jitter_point(-0.453521f, -0.299889f),
    new jitter_point( 0.408216f, -0.457699f),
    new jitter_point( 0.328973f, -0.101914f),
    new jitter_point(-0.055540f, -0.477952f),
    new jitter_point( 0.194421f,  0.453510f),
    new jitter_point( 0.404051f,  0.224974f),
    new jitter_point( 0.310136f,  0.419700f),
    new jitter_point(-0.021743f,  0.403898f),
    new jitter_point(-0.466210f,  0.248839f),
    new jitter_point( 0.341369f,  0.081490f),
    new jitter_point( 0.124156f, -0.016859f),
    new jitter_point(-0.461321f, -0.176661f),
    new jitter_point( 0.013210f,  0.234401f),
    new jitter_point( 0.174258f, -0.311854f),
    new jitter_point( 0.294061f,  0.263364f),
    new jitter_point(-0.114836f,  0.328189f),
    new jitter_point( 0.041206f, -0.106205f),
    new jitter_point( 0.079227f,  0.345021f),
    new jitter_point(-0.109319f, -0.242380f),
    new jitter_point( 0.425005f, -0.332397f),
    new jitter_point( 0.009146f,  0.015098f),
    new jitter_point(-0.339084f, -0.355707f),
    new jitter_point(-0.224596f, -0.189548f),
    new jitter_point( 0.083475f,  0.117028f),
    new jitter_point( 0.295962f, -0.334699f),
    new jitter_point( 0.452998f,  0.025397f),
    new jitter_point( 0.206511f, -0.104668f),
    new jitter_point( 0.447544f, -0.096004f),
    new jitter_point(-0.108006f, -0.002471f),
    new jitter_point(-0.380810f,  0.130036f),
    new jitter_point(-0.242440f,  0.186934f),
    new jitter_point(-0.200363f,  0.070863f),
    new jitter_point(-0.344844f, -0.230814f),
    new jitter_point( 0.408660f,  0.345826f),
    new jitter_point(-0.233016f,  0.305203f),
    new jitter_point( 0.158475f, -0.430762f),
    new jitter_point( 0.486972f,  0.139163f),
    new jitter_point(-0.301610f,  0.009319f),
    new jitter_point( 0.282245f, -0.458671f),
    new jitter_point( 0.482046f,  0.443890f),
    new jitter_point(-0.121527f,  0.210223f),
    new jitter_point(-0.477606f, -0.424878f),
    new jitter_point(-0.083941f, -0.121440f),
    new jitter_point(-0.345773f,  0.253779f),
    new jitter_point( 0.234646f,  0.034549f),
    new jitter_point( 0.394102f, -0.210901f),
    new jitter_point(-0.312571f,  0.397656f),
    new jitter_point( 0.200906f,  0.333293f),
    new jitter_point( 0.018703f, -0.261792f),
    new jitter_point(-0.209349f, -0.065383f),
    new jitter_point( 0.076248f,  0.478538f),
    new jitter_point(-0.073036f, -0.355064f),
    new jitter_point( 0.145087f,  0.221726f)
};
    };

}