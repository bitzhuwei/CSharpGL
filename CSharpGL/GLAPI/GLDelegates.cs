using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Cached delegates. Used in GL.GetDelegateFor().
    /// </summary>
    public static class GLDelegates
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <returns></returns>
        public delegate bool bool_uint_uint(uint _0, uint _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_bool_uint_uint = typeof(bool_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <returns></returns>
        public delegate bool bool_uint(uint _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_bool_uint = typeof(bool_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <returns></returns>
        public delegate int int_uint_string(uint _0, string _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_int_uint_string = typeof(int_uint_string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <returns></returns>
        public delegate int int_uint_uint_string(uint _0, uint _1, string _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_int_uint_uint_string = typeof(int_uint_uint_string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <returns></returns>
        public delegate IntPtr IntPtr_IntPtr_IntPtr_intN(IntPtr _0, IntPtr _1, int[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_IntPtr_IntPtr_IntPtr_intN = typeof(IntPtr_IntPtr_IntPtr_intN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <returns></returns>
        public delegate bool bool_IntPtr_intN_floatN_uint_intN_uintN(IntPtr _0, int[] _1, float[] _2, uint _3, int[] _4, uint[] _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_bool_IntPtr_intN_floatN_uint_intN_uintN = typeof(bool_IntPtr_intN_floatN_uint_intN_uintN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <returns></returns>
        public delegate IntPtr IntPtr_IntPtr_uint_IntPtr_IntPtr(IntPtr _0, uint _1, IntPtr _2, IntPtr _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_IntPtr_IntPtr_uint_IntPtr_IntPtr = typeof(IntPtr_IntPtr_uint_IntPtr_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <returns></returns>
        public delegate IntPtr IntPtr_uint_int_int_uint(uint _0, int _1, int _2, uint _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_IntPtr_uint_int_int_uint = typeof(IntPtr_uint_int_int_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <returns></returns>
        public delegate IntPtr IntPtr_uint_uint(uint _0, uint _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_IntPtr_uint_uint = typeof(IntPtr_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <returns></returns>
        public delegate string string_IntPtr(IntPtr _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_string_IntPtr = typeof(string_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <returns></returns>
        public delegate string string_uint_uint(uint _0, uint _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_string_uint_uint = typeof(string_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public delegate uint uint_void();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_uint_void = typeof(uint_void);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <returns></returns>
        public delegate uint uint_uint_string(uint _0, string _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_uint_uint_string = typeof(uint_uint_string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <returns></returns>
        public delegate uint uint_uint_uint_string(uint _0, uint _1, string _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_uint_uint_uint_string = typeof(uint_uint_uint_string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <returns></returns>
        public delegate uint uint_uint_uint_uint_uintN(uint _0, uint _1, uint _2, uint[] _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_uint_uint_uint_uint_uintN = typeof(uint_uint_uint_uint_uintN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <returns></returns>
        public delegate uint uint_uint(uint _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_uint_uint = typeof(uint_uint);

        /// <summary>
        /// 
        /// </summary>
        public delegate void void_void();
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_void = typeof(void_void);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_byte_byte_byte(byte _0, byte _1, byte _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_byte_byte_byte = typeof(void_byte_byte_byte);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_byteN(byte[] _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_byteN = typeof(void_byteN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_double_double_double(double _0, double _1, double _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_double_double_double = typeof(void_double_double_double);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_double_double(double _0, double _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_double_double = typeof(void_double_double);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_double(double _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_double = typeof(void_double);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_doubleN(double[] _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_doubleN = typeof(void_doubleN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_float_bool(float _0, bool _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_float_bool = typeof(void_float_bool);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_float_float_float_float(float _0, float _1, float _2, float _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_float_float_float_float = typeof(void_float_float_float_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_float_float_float(float _0, float _1, float _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_float_float_float = typeof(void_float_float_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_float_float(float _0, float _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_float_float = typeof(void_float_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_float(float _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_float = typeof(void_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_floatN(float[] _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_floatN = typeof(void_floatN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_int_float_float_float_float(int _0, float _1, float _2, float _3, float _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_float_float_float_float = typeof(void_int_float_float_float_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_int_float_float_float(int _0, float _1, float _2, float _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_float_float_float = typeof(void_int_float_float_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_int_float_float(int _0, float _1, float _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_float_float = typeof(void_int_float_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_int_float(int _0, float _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_float = typeof(void_int_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_int_int_bool_floatN(int _0, int _1, bool _2, float[] _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_int_bool_floatN = typeof(void_int_int_bool_floatN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_int_int_floatN(int _0, int _1, float[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_int_floatN = typeof(void_int_int_floatN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_int_int_int_int_int(int _0, int _1, int _2, int _3, int _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_int_int_int_int = typeof(void_int_int_int_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_int_int_int_int(int _0, int _1, int _2, int _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_int_int_int = typeof(void_int_int_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_int_int_int(int _0, int _1, int _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_int_int = typeof(void_int_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_int_int_intN(int _0, int _1, int[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_int_intN = typeof(void_int_int_intN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_int_int_IntPtr(int _0, int _1, IntPtr _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_int_IntPtr = typeof(void_int_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_int_int_uintN(int _0, int _1, uint[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_int_uintN = typeof(void_int_int_uintN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_int_int(int _0, int _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_int = typeof(void_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_int_uint_int_IntPtr(int _0, uint _1, int _2, IntPtr _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_uint_int_IntPtr = typeof(void_int_uint_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_int_uint_uint_uint_uint(int _0, uint _1, uint _2, uint _3, uint _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_uint_uint_uint_uint = typeof(void_int_uint_uint_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_int_uint_uint_uint(int _0, uint _1, uint _2, uint _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_uint_uint_uint = typeof(void_int_uint_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_int_uint_uint(int _0, uint _1, uint _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_uint_uint = typeof(void_int_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_int_uint(int _0, uint _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_uint = typeof(void_int_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_int_uintN(int _0, uint[] _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_int_uintN = typeof(void_int_uintN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_intN(int[] _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_intN = typeof(void_intN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_IntPtr(IntPtr _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_IntPtr = typeof(void_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_sbyte_sbyte_sbyte(sbyte _0, sbyte _1, sbyte _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_sbyte_sbyte_sbyte = typeof(void_sbyte_sbyte_sbyte);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_sbyteN(sbyte[] _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_sbyteN = typeof(void_sbyteN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_short_short_short(short _0, short _1, short _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_short_short_short = typeof(void_short_short_short);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_short_short(short _0, short _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_short_short = typeof(void_short_short);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_shortN(short[] _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_shortN = typeof(void_shortN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_bool_bool_bool_bool(uint _0, bool _1, bool _2, bool _3, bool _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_bool_bool_bool_bool = typeof(void_uint_bool_bool_bool_bool);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_bool_uint_uint_IntPtr(uint _0, bool _1, uint _2, uint _3, IntPtr _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_bool_uint_uint_IntPtr = typeof(void_uint_bool_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_byte_byte_byte_byte(uint _0, byte _1, byte _2, byte _3, byte _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_byte_byte_byte_byte = typeof(void_uint_byte_byte_byte_byte);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_byteN(uint _0, byte[] _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_byteN = typeof(void_uint_byteN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_double_double_double_double(uint _0, double _1, double _2, double _3, double _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_double_double_double_double = typeof(void_uint_double_double_double_double);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_double_double_double(uint _0, double _1, double _2, double _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_double_double_double = typeof(void_uint_double_double_double);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_double_double(uint _0, double _1, double _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_double_double = typeof(void_uint_double_double);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_double(uint _0, double _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_double = typeof(void_uint_double);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_doubleN(uint _0, double[] _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_doubleN = typeof(void_uint_doubleN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_float_float_float_float(uint _0, float _1, float _2, float _3, float _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_float_float_float_float = typeof(void_uint_float_float_float_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_float_float_float(uint _0, float _1, float _2, float _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_float_float_float = typeof(void_uint_float_float_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_float_float(uint _0, float _1, float _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_float_float = typeof(void_uint_float_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_float(uint _0, float _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_float = typeof(void_uint_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_floatN(uint _0, float[] _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_floatN = typeof(void_uint_floatN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_float_int(uint _0, int _1, float _2, int _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_float_int = typeof(void_uint_int_float_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_int_floatN(uint _0, int _1, float[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_floatN = typeof(void_uint_int_floatN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        /// <param name="_8"></param>
        public delegate void void_uint_int_int_int_int_int_int_int_int(uint _0, int _1, int _2, int _3, int _4, int _5, int _6, int _7, int _8);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_int_int_int_int_int_int_int = typeof(void_uint_int_int_int_int_int_int_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        /// <param name="_8"></param>
        /// <param name="_9"></param>
        /// <param name="_10"></param>
        public delegate void void_uint_int_int_int_int_int_int_int_uint_int_IntPtr(uint _0, int _1, int _2, int _3, int _4, int _5, int _6, int _7, uint _8, int _9, IntPtr _10);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_int_int_int_int_int_int_uint_int_IntPtr = typeof(void_uint_int_int_int_int_int_int_int_uint_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        /// <param name="_8"></param>
        /// <param name="_9"></param>
        /// <param name="_10"></param>
        public delegate void void_uint_int_int_int_int_int_int_int_uint_uint_IntPtr(uint _0, int _1, int _2, int _3, int _4, int _5, int _6, int _7, uint _8, uint _9, IntPtr _10);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_int_int_int_int_int_int_uint_uint_IntPtr = typeof(void_uint_int_int_int_int_int_int_int_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        /// <param name="_8"></param>
        /// <param name="_9"></param>
        public delegate void void_uint_int_uint_int_int_int_int_uint_uint_IntPtr(uint _0, int _1, uint _2, int _3, int _4, int _5, int _6, uint _7, uint _8, IntPtr _9);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_int_int_int_int_uint_uint_IntPtr = typeof(void_uint_int_uint_int_int_int_int_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        /// <param name="_8"></param>
        public delegate void void_uint_int_int_int_int_int_uint_int_IntPtr(uint _0, int _1, int _2, int _3, int _4, int _5, uint _6, int _7, IntPtr _8);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_int_int_int_int_uint_int_IntPtr = typeof(void_uint_int_int_int_int_int_uint_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        /// <param name="_8"></param>
        public delegate void void_uint_int_int_int_int_int_uint_uint_IntPtr(uint _0, int _1, int _2, int _3, int _4, int _5, uint _6, uint _7, IntPtr _8);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_int_int_int_int_uint_uint_IntPtr = typeof(void_uint_int_int_int_int_int_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_int_int_int_int(uint _0, int _1, int _2, int _3, int _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_int_int_int = typeof(void_uint_int_int_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        public delegate void void_uint_int_int_int_uint_int_IntPtr(uint _0, int _1, int _2, int _3, uint _4, int _5, IntPtr _6);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_int_int_uint_int_IntPtr = typeof(void_uint_int_int_int_uint_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_int_int(uint _0, int _1, int _2, int _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_int_int = typeof(void_uint_int_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_int_IntPtr(uint _0, int _1, int _2, IntPtr _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_int_IntPtr = typeof(void_uint_int_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_int_int_uint_uint_IntPtr(uint _0, int _1, int _2, uint _3, uint _4, IntPtr _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_int_uint_uint_IntPtr = typeof(void_uint_int_int_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_int_int(uint _0, int _1, int _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_int = typeof(void_uint_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_intN_uintN(uint _0, int _1, int[] _2, uint[] _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_intN_uintN = typeof(void_uint_int_intN_uintN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_int_intN(uint _0, int _1, int[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_intN = typeof(void_uint_int_intN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_IntPtr_StringBuilder(uint _0, int _1, IntPtr _2, StringBuilder _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_IntPtr_StringBuilder = typeof(void_uint_int_IntPtr_StringBuilder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_IntPtr_uint(uint _0, int _1, IntPtr _2, uint _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_IntPtr_uint = typeof(void_uint_int_IntPtr_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_int_IntPtr(uint _0, int _1, IntPtr _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_IntPtr = typeof(void_uint_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_refint_refuint(uint _0, int _1, ref int _2, ref uint _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_refint_refuint = typeof(void_uint_int_refint_refuint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_refint_string(uint _0, int _1, ref int _2, string _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_refint_string = typeof(void_uint_int_refint_string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_stringN_intN(uint _0, int _1, string[] _2, int[] _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_stringN_intN = typeof(void_uint_int_stringN_intN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_stringN_refint(uint _0, int _1, string[] _2, ref int _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_stringN_refint = typeof(void_uint_int_stringN_refint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_stringN_uint(uint _0, int _1, string[] _2, uint _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_stringN_uint = typeof(void_uint_int_stringN_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_int_uint_bool_int_IntPtr(uint _0, int _1, uint _2, bool _3, int _4, IntPtr _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_bool_int_IntPtr = typeof(void_uint_int_uint_bool_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_int_uint_bool_uint(uint _0, int _1, uint _2, bool _3, uint _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_bool_uint = typeof(void_uint_int_uint_bool_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_uint_bool(uint _0, int _1, uint _2, bool _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_bool = typeof(void_uint_int_uint_bool);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        /// <param name="_8"></param>
        public delegate void void_uint_int_uint_int_int_int_int_int_IntPtr(uint _0, int _1, uint _2, int _3, int _4, int _5, int _6, int _7, IntPtr _8);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_int_int_int_int_int_IntPtr = typeof(void_uint_int_uint_int_int_int_int_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        public delegate void void_uint_int_uint_int_int_int_int_IntPtr(uint _0, int _1, uint _2, int _3, int _4, int _5, int _6, IntPtr _7);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_int_int_int_int_IntPtr = typeof(void_uint_int_uint_int_int_int_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        public delegate void void_uint_int_uint_int_int_int_IntPtr(uint _0, int _1, uint _2, int _3, int _4, int _5, IntPtr _6);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_int_int_int_IntPtr = typeof(void_uint_int_uint_int_int_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_int_uint_int_int_int(uint _0, int _1, uint _2, int _3, int _4, int _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_int_int_int = typeof(void_uint_int_uint_int_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_int_uint_int_int(uint _0, int _1, uint _2, int _3, int _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_int_int = typeof(void_uint_int_uint_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_int_uint_int_IntPtr(uint _0, int _1, uint _2, int _3, IntPtr _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_int_IntPtr = typeof(void_uint_int_uint_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_uint_int(uint _0, int _1, uint _2, int _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_int = typeof(void_uint_int_uint_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_int_uint_IntPtr_int(uint _0, int _1, uint _2, IntPtr _3, int _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_IntPtr_int = typeof(void_uint_int_uint_IntPtr_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_int_uint_IntPtr_int_int(uint _0, int _1, uint _2, IntPtr _3, int _4, int _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_IntPtr_int_int = typeof(void_uint_int_uint_IntPtr_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_int_uint_uint(uint _0, int _1, uint _2, uint _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uint_uint = typeof(void_uint_int_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_int_uintN(uint _0, int _1, uint[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int_uintN = typeof(void_uint_int_uintN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_int(uint _0, int _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_int = typeof(void_uint_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_intN_intN_int(uint _0, int[] _1, int[] _2, int _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_intN_intN_int = typeof(void_uint_intN_intN_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_intN_uint_IntPtr_int(uint _0, int[] _1, uint _2, IntPtr _3, int _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_intN_uint_IntPtr_int = typeof(void_uint_intN_uint_IntPtr_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_intN_uint_IntPtr_int_intN(uint _0, int[] _1, uint _2, IntPtr _3, int _4, int[] _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_intN_uint_IntPtr_int_intN = typeof(void_uint_intN_uint_IntPtr_int_intN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_intN(uint _0, int[] _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_intN = typeof(void_uint_intN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_IntPtr_IntPtr(uint _0, IntPtr _1, IntPtr _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_IntPtr_IntPtr = typeof(void_uint_IntPtr_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_IntPtr_uint_uint(uint _0, IntPtr _1, uint _2, uint _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_IntPtr_uint_uint = typeof(void_uint_IntPtr_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_sbyteN(uint _0, sbyte[] _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_sbyteN = typeof(void_uint_sbyteN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_short_short_short_short(uint _0, short _1, short _2, short _3, short _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_short_short_short_short = typeof(void_uint_short_short_short_short);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_short_short_short(uint _0, short _1, short _2, short _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_short_short_short = typeof(void_uint_short_short_short);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_short_short(uint _0, short _1, short _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_short_short = typeof(void_uint_short_short);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_short(uint _0, short _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_short = typeof(void_uint_short);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_shortN(uint _0, short[] _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_shortN = typeof(void_uint_shortN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_bool(uint _0, uint _1, bool _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_bool = typeof(void_uint_uint_bool);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_boolN(uint _0, uint _1, bool[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_boolN = typeof(void_uint_uint_boolN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_double_double_double_double(uint _0, uint _1, double _2, double _3, double _4, double _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_double_double_double_double = typeof(void_uint_uint_double_double_double_double);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_doubleN(uint _0, uint _1, double[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_doubleN = typeof(void_uint_uint_doubleN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_float_float_float_float(uint _0, uint _1, float _2, float _3, float _4, float _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_float_float_float_float = typeof(void_uint_uint_float_float_float_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_float(uint _0, uint _1, float _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_float = typeof(void_uint_uint_float);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_floatN(uint _0, uint _1, float[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_floatN = typeof(void_uint_uint_floatN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        public delegate void void_uint_uint_int_bool_int_uint_uint(uint _0, uint _1, int _2, bool _3, int _4, uint _5, uint _6);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_bool_int_uint_uint = typeof(void_uint_uint_int_bool_int_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_int_int_int_int(uint _0, uint _1, int _2, int _3, int _4, int _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_int_int_int = typeof(void_uint_uint_int_int_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_int_int_int(uint _0, uint _1, int _2, int _3, int _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_int_int = typeof(void_uint_uint_int_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        public delegate void void_uint_uint_int_int_uint_uint_IntPtr_IntPtr(uint _0, uint _1, int _2, int _3, uint _4, uint _5, IntPtr _6, IntPtr _7);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_int_uint_uint_IntPtr_IntPtr = typeof(void_uint_uint_int_int_uint_uint_IntPtr_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        public delegate void void_uint_uint_int_int_uint_uint_IntPtr(uint _0, uint _1, int _2, int _3, uint _4, uint _5, IntPtr _6);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_int_uint_uint_IntPtr = typeof(void_uint_uint_int_int_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_int_int_uint(uint _0, uint _1, int _2, int _3, uint _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_int_uint = typeof(void_uint_uint_int_int_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_uint_int_int(uint _0, uint _1, int _2, int _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_int = typeof(void_uint_uint_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        public delegate void void_uint_uint_int_intN_intN_uintN_string(uint _0, uint _1, int _2, int[] _3, int[] _4, uint[] _5, StringBuilder _6);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_intN_intN_uintN_string = typeof(void_uint_uint_int_intN_intN_uintN_string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_uint_int_IntPtr(uint _0, uint _1, int _2, IntPtr _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_IntPtr = typeof(void_uint_uint_int_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        public delegate void void_uint_uint_int_outint_outint_outuint_StringBuilder(uint _0, uint _1, int _2, out int _3, out int _4, out uint _5, StringBuilder _6);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_outint_outint_outuint_StringBuilder = typeof(void_uint_uint_int_outint_outint_outuint_StringBuilder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        public delegate void void_uint_uint_int_refint_refint_refuint_string(uint _0, uint _1, int _2, ref int _3, ref int _4, ref uint _5, string _6);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_refint_refint_refuint_string = typeof(void_uint_uint_int_refint_refint_refuint_string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_int_uint_bool_uint(uint _0, uint _1, int _2, uint _3, bool _4, uint _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_uint_bool_uint = typeof(void_uint_uint_int_uint_bool_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_int_uint_uint_IntPtr(uint _0, uint _1, int _2, uint _3, uint _4, IntPtr _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_uint_uint_IntPtr = typeof(void_uint_uint_int_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_int_uint_uint(uint _0, uint _1, int _2, uint _3, uint _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_uint_uint = typeof(void_uint_uint_int_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_uint_int_uint(uint _0, uint _1, int _2, uint _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int_uint = typeof(void_uint_uint_int_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_int(uint _0, uint _1, int _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_int = typeof(void_uint_uint_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_intN(uint _0, uint _1, int[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_intN = typeof(void_uint_uint_intN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_Int64N(uint _0, uint _1, Int64[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_Int64N = typeof(void_uint_uint_Int64N);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_IntPtr_IntPtr_IntPtr(uint _0, uint _1, IntPtr _2, IntPtr _3, IntPtr _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_IntPtr_IntPtr_IntPtr = typeof(void_uint_uint_IntPtr_IntPtr_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        public delegate void void_uint_uint_IntPtr_uint_uint_uint_IntPtr(uint _0, uint _1, IntPtr _2, uint _3, uint _4, uint _5, IntPtr _6);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_IntPtr_uint_uint_uint_IntPtr = typeof(void_uint_uint_IntPtr_uint_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_IntPtr_uint_uint(uint _0, uint _1, IntPtr _2, uint _3, uint _4);
        /// <summary>
        /// /
        /// </summary>
        public static readonly Type typeof_void_uint_uint_IntPtr_uint_uint = typeof(void_uint_uint_IntPtr_uint_uint);

        /// <summary>
        /// /
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_uint_IntPtr_uint(uint _0, uint _1, IntPtr _2, uint _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_IntPtr_uint = typeof(void_uint_uint_IntPtr_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_IntPtr(uint _0, uint _1, IntPtr _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_IntPtr = typeof(void_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_IntPtrN(uint _0, uint _1, IntPtr[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_IntPtrN = typeof(void_uint_uint_IntPtrN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_string(uint _0, uint _1, string _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_string = typeof(void_uint_uint_string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_uint_int_int(uint _0, uint _1, uint _2, int _3, int _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_int_int = typeof(void_uint_uint_uint_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_uint_int_intN_bool(uint _0, uint _1, uint _2, int _3, int[] _4, bool _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_int_intN_bool = typeof(void_uint_uint_uint_int_intN_bool);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_uint_int_uint_IntPtr(uint _0, uint _1, uint _2, int _3, uint _4, IntPtr _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_int_uint_IntPtr = typeof(void_uint_uint_uint_int_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_uint_uint_int(uint _0, uint _1, uint _2, int _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_int = typeof(void_uint_uint_uint_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_uint_uint_intN(uint _0, uint _1, uint _2, int[] _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_intN = typeof(void_uint_uint_uint_intN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_uint_IntPtr_IntPtr_IntPtr(uint _0, uint _1, uint _2, IntPtr _3, IntPtr _4, IntPtr _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_IntPtr_IntPtr_IntPtr = typeof(void_uint_uint_uint_IntPtr_IntPtr_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_uint_IntPtr_IntPtr(uint _0, uint _1, uint _2, IntPtr _3, IntPtr _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_IntPtr_IntPtr = typeof(void_uint_uint_uint_IntPtr_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_uint_IntPtr_uint(uint _0, uint _1, uint _2, IntPtr _3, uint _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_IntPtr_uint = typeof(void_uint_uint_uint_IntPtr_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_uint_uint_IntPtr(uint _0, uint _1, uint _2, IntPtr _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_IntPtr = typeof(void_uint_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_uint_uint_string(uint _0, uint _1, uint _2, string _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_string = typeof(void_uint_uint_uint_string);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_uint_uint_int_int(uint _0, uint _1, uint _2, uint _3, int _4, int _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_int_int = typeof(void_uint_uint_uint_uint_int_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_uint_uint_int_StringBuilder(uint _0, uint _1, uint _2, uint _3, int _4, StringBuilder _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_int_StringBuilder = typeof(void_uint_uint_uint_uint_int_StringBuilder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_uint_uint_int(uint _0, uint _1, uint _2, uint _3, int _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_int = typeof(void_uint_uint_uint_uint_int);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_uint_uint_intN(uint _0, uint _1, uint _2, uint _3, int[] _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_intN = typeof(void_uint_uint_uint_uint_intN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_uint_uint_Int64N(uint _0, uint _1, uint _2, uint _3, Int64[] _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_Int64N = typeof(void_uint_uint_uint_uint_Int64N);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_uint_uint_IntPtr_IntPtr(uint _0, uint _1, uint _2, uint _3, IntPtr _4, IntPtr _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_IntPtr_IntPtr = typeof(void_uint_uint_uint_uint_IntPtr_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_uint_uint_IntPtr(uint _0, uint _1, uint _2, uint _3, IntPtr _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_IntPtr = typeof(void_uint_uint_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_uint_uint_uint_bool(uint _0, uint _1, uint _2, uint _3, uint _4, bool _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_uint_bool = typeof(void_uint_uint_uint_uint_uint_bool);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_uint_uint_uint_IntPtr(uint _0, uint _1, uint _2, uint _3, uint _4, IntPtr _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_uint_IntPtr = typeof(void_uint_uint_uint_uint_uint_IntPtr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        public delegate void void_uint_uint_uint_uint_uint_uint_bool(uint _0, uint _1, uint _2, uint _3, uint _4, uint _5, bool _6);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_uint_uint_bool = typeof(void_uint_uint_uint_uint_uint_uint_bool);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        public delegate void void_uint_uint_uint_uint_uint_uint_uint_bool(uint _0, uint _1, uint _2, uint _3, uint _4, uint _5, uint _6, bool _7);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_uint_uint_uint_bool = typeof(void_uint_uint_uint_uint_uint_uint_uint_bool);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        public delegate void void_uint_uint_uint_uint_uint_uint_uint_uint(uint _0, uint _1, uint _2, uint _3, uint _4, uint _5, uint _6, uint _7);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_uint_uint_uint_uint = typeof(void_uint_uint_uint_uint_uint_uint_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        public delegate void void_uint_uint_uint_uint_uint(uint _0, uint _1, uint _2, uint _3, uint _4);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_uint = typeof(void_uint_uint_uint_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        public delegate void void_uint_uint_uint_uint_uintN_stringN(uint _0, uint _1, uint _2, uint _3, uint[] _4, string[] _5);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_uintN_stringN = typeof(void_uint_uint_uint_uint_uintN_stringN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        /// <param name="_4"></param>
        /// <param name="_5"></param>
        /// <param name="_6"></param>
        /// <param name="_7"></param>
        public delegate void void_uint_uint_uint_uint_uintN_uint_uintN_intN(uint _0, uint _1, uint _2, uint _3, uint[] _4, uint _5, uint[] _6, int[] _7);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint_uintN_uint_uintN_intN = typeof(void_uint_uint_uint_uint_uintN_uint_uintN_intN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        /// <param name="_3"></param>
        public delegate void void_uint_uint_uint_uint(uint _0, uint _1, uint _2, uint _3);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint_uint = typeof(void_uint_uint_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_uint(uint _0, uint _1, uint _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uint = typeof(void_uint_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_uint_uint_uintN(uint _0, uint _1, uint[] _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint_uintN = typeof(void_uint_uint_uintN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_uint(uint _0, uint _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uint = typeof(void_uint_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_uintN(uint _0, uint[] _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_uintN = typeof(void_uint_uintN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        public delegate void void_uint_ushortN(uint _0, ushort[] _1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint_ushortN = typeof(void_uint_ushortN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_uint(uint _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uint = typeof(void_uint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_uintN(uint[] _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_uintN = typeof(void_uintN);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        /// <param name="_1"></param>
        /// <param name="_2"></param>
        public delegate void void_ushort_ushort_ushort(ushort _0, ushort _1, ushort _2);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_ushort_ushort_ushort = typeof(void_ushort_ushort_ushort);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_0"></param>
        public delegate void void_ushortN(ushort[] _0);
        /// <summary>
        /// 
        /// </summary>
        public static readonly Type typeof_void_ushortN = typeof(void_ushortN);


    }
}
