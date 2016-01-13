using System;
using System.Runtime.CompilerServices;

namespace System.Numerics
{
	internal class ConstantHelper
	{
		[MethodImpl(256)]
		public unsafe static byte GetByteWithAllBitsSet()
		{
			byte result = 0;
			*(&result) = 255;
			return result;
		}

		[MethodImpl(256)]
		public unsafe static sbyte GetSByteWithAllBitsSet()
		{
			sbyte result = 0;
			*(&result) = -1;
			return result;
		}

		[MethodImpl(256)]
		public unsafe static ushort GetUInt16WithAllBitsSet()
		{
			ushort result = 0;
			*(&result) = 65535;
			return result;
		}

		[MethodImpl(256)]
		public unsafe static short GetInt16WithAllBitsSet()
		{
			short result = 0;
			*(&result) = -1;
			return result;
		}

		[MethodImpl(256)]
		public unsafe static uint GetUInt32WithAllBitsSet()
		{
			uint result = 0u;
			*(&result) = 4294967295u;
			return result;
		}

		[MethodImpl(256)]
		public unsafe static int GetInt32WithAllBitsSet()
		{
			int result = 0;
			*(&result) = -1;
			return result;
		}

		[MethodImpl(256)]
		public unsafe static ulong GetUInt64WithAllBitsSet()
		{
			ulong result = 0uL;
			*(&result) = 18446744073709551615uL;
			return result;
		}

		[MethodImpl(256)]
		public unsafe static long GetInt64WithAllBitsSet()
		{
			long result = 0L;
			*(&result) = -1L;
			return result;
		}

		[MethodImpl(256)]
		public unsafe static float GetSingleWithAllBitsSet()
		{
			float result = 0f;
			*(int*)(&result) = -1;
			return result;
		}

		[MethodImpl(256)]
		public unsafe static double GetDoubleWithAllBitsSet()
		{
			double result = 0.0;
			*(long*)(&result) = -1L;
			return result;
		}
	}
}
