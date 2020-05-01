using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Numerics;
using System.Security.Cryptography;

namespace SoulMemory_Calc
{
	public class JunkCode
	{
        public static IntPtr BaseA = new IntPtr(0x7FF75228B8D0);

		public JunkCode()
		{
		}



		public static int getSoulMemory()
		{
			IntPtr smPointer = BuildPointer(BaseA, new List<int> { 0xD0, 0x490, 0xF4 });
			int soulmemory = Memoryold.ReadInt32(smPointer);
			return soulmemory;
		}
		public static IntPtr BuildPointer(IntPtr baseAddress, List<int> offsets)
		{
			var pointer = baseAddress;
			foreach (var offset in offsets)
			{
				pointer = (IntPtr)Memoryold.ReadInt64(pointer);
				pointer += offset;
			}
			return pointer;
		}

       
			
		public static byte ConvertToByte(BitArray bits)
		{
			if (bits.Count != 8)
			{
				throw new ArgumentException("bits");
			}
			byte[] bytes = new byte[1];
			bits.CopyTo(bytes, 0);
			return bytes[0];
		}
		
    }

}