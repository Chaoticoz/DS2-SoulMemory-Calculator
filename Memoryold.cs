using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace SoulMemory_Calc
{
	public class Memoryold
	{
		const int PROCESS_ALL_ACCESS = 0x1F0FFF;
		public static IntPtr BaseAddress
		{
			get;
			set;
		}	

		public static bool Is64Bit
		{
			get
			{
				return IntPtr.Size == 8;
			}
		}

		public static IntPtr ProcessHandle
		{
			get;
			set;
		}

		public static bool isRunning
		{
			get
			{
				Process[] processesByName = Process.GetProcessesByName("DarkSoulsII");
				if (processesByName.Length == 0)
				{
					return false;
				}
				return true;
			}
		}

		public Memoryold()
		{
		}

		public static IntPtr AttachProc(string procName)
		{
			IntPtr processHandle;
			IntPtr intPtr = new IntPtr(0);
			Process[] processesByName = Process.GetProcessesByName(procName);
			if (processesByName.Length == 0)
			{
				processHandle = IntPtr.Zero;
			}
			else
			{
				Process process = processesByName[0];
				Memoryold.BaseAddress = process.MainModule.BaseAddress;
				try
				{
					Memoryold.ProcessHandle = Kernel32.OpenProcess(PROCESS_ALL_ACCESS, false, process.Id);
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message);
				}
				processHandle = Memoryold.ProcessHandle;
			}

			return processHandle;
			
		}

		public static void ExecuteBufferFunction(byte[] array, byte[] argument)
		{
			uint num;
			int num1 = 256;
			int num2 = 256;
			IntPtr intPtr = Kernel32.VirtualAllocEx(Memoryold.ProcessHandle, IntPtr.Zero, num1, 12288, 64);
			IntPtr intPtr1 = Kernel32.VirtualAllocEx(Memoryold.ProcessHandle, IntPtr.Zero, num2, 12288, 64);
			int num3 = 2;
			byte[] bytes = new byte[7];
			Memoryold.WriteBytes(intPtr1, argument);
			bytes = BitConverter.GetBytes((long)intPtr1);
			Array.Copy(bytes, 0, array, num3, (int)bytes.Length);
			if (intPtr != IntPtr.Zero)
			{
				if (Memoryold.WriteBytes(intPtr, array))
				{
					IntPtr intPtr2 = Kernel32.CreateRemoteThread(Memoryold.ProcessHandle, IntPtr.Zero, 0, intPtr, IntPtr.Zero, 0, out num);
					if (intPtr2 != IntPtr.Zero)
					{
						Kernel32.WaitForSingleObject(intPtr2, 30000);
					}
				}
				Kernel32.VirtualFreeEx(Memoryold.ProcessHandle, intPtr, num1, 2);
				Kernel32.VirtualFreeEx(Memoryold.ProcessHandle, intPtr1, num2, 2);
			}
		}

		public static void ExecuteFunction(byte[] array)
		{
			uint num;
			int num1 = 256;
			IntPtr intPtr = Kernel32.VirtualAllocEx(Memoryold.ProcessHandle, IntPtr.Zero, num1, 12288, 64);
			if (intPtr != IntPtr.Zero)
			{
				if (Memoryold.WriteBytes(intPtr, array))
				{
					IntPtr intPtr1 = Kernel32.CreateRemoteThread(Memoryold.ProcessHandle, IntPtr.Zero, 0, intPtr, IntPtr.Zero, 0, out num);
					if (intPtr1 != IntPtr.Zero)
					{
						Kernel32.WaitForSingleObject(intPtr1, 30000);
					}
				}
				Kernel32.VirtualFreeEx(Memoryold.ProcessHandle, intPtr, num1, 2);
			}
		}

		public static bool ReadBoolean(IntPtr address)
		{
			byte[] numArray = new byte[1];
			Kernel32.ReadProcessMemory(Memoryold.ProcessHandle, address, numArray, (UIntPtr)((long)1), UIntPtr.Zero);
			return Convert.ToBoolean(numArray[0]);
		}

		public static double ReadDouble(IntPtr address)
		{
			byte[] numArray = new byte[8];
			Kernel32.ReadProcessMemory(Memoryold.ProcessHandle, address, numArray, (UIntPtr)((long)((int)numArray.Length)), UIntPtr.Zero);
			return BitConverter.ToDouble(numArray, 0);
		}

		public static float ReadFloat(IntPtr address)
		{
			byte[] numArray = new byte[4];
			Kernel32.ReadProcessMemory(Memoryold.ProcessHandle, address, numArray, (UIntPtr)((long)((int)numArray.Length)), UIntPtr.Zero);
			return BitConverter.ToSingle(numArray, 0);
		}

		public static short ReadInt16(IntPtr address)
		{
			byte[] numArray = new byte[2];
			Kernel32.ReadProcessMemory(Memoryold.ProcessHandle, address, numArray, (UIntPtr)((long)2), UIntPtr.Zero);
			return BitConverter.ToInt16(numArray, 0);
		}

		public static int ReadInt32(IntPtr address)
		{
			byte[] numArray = new byte[4];
			Kernel32.ReadProcessMemory(Memoryold.ProcessHandle, address, numArray, (UIntPtr)((long)((int)numArray.Length)), UIntPtr.Zero);
			return BitConverter.ToInt32(numArray, 0);
		}

		public static long ReadInt64(IntPtr address)
		{
			byte[] numArray = new byte[8];
			Kernel32.ReadProcessMemory(Memoryold.ProcessHandle, address, numArray, (UIntPtr)((long)((int)numArray.Length)), UIntPtr.Zero);
			return BitConverter.ToInt64(numArray, 0);
		}

		public static byte ReadByte(IntPtr address)
		{
			byte[] Byte = new byte[1];
			Kernel32.ReadProcessMemory(Memoryold.ProcessHandle, address, Byte, (UIntPtr)((long)1), UIntPtr.Zero);
			return Byte[0];
		}
		public static void WriteByte(IntPtr address, byte[] Byte)
		{
			Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, Byte, (UIntPtr)1, UIntPtr.Zero);
		}
			public static byte ReadInt8(IntPtr address)
		{
			byte[] numArray = new byte[1];
			Kernel32.ReadProcessMemory(Memoryold.ProcessHandle, address, numArray, (UIntPtr)((long)1), UIntPtr.Zero);
			return numArray[0];
		}

		public static string ReadString(IntPtr address, int length, string encodingName)
		{
			byte[] numArray = new byte[length];
			Kernel32.ReadProcessMemory(Memoryold.ProcessHandle, address, numArray, (UIntPtr)((long)((int)numArray.Length)), UIntPtr.Zero);
			Encoding encoding = Encoding.GetEncoding(encodingName);
			return encoding.GetString(numArray, 0, (int)numArray.Length);
		}

		public static string ReadUnicodeString(IntPtr address, int length)
		{
			byte[] numArray = new byte[length];
			Kernel32.ReadProcessMemory(Memoryold.ProcessHandle, address, numArray, (UIntPtr)((long)((int)numArray.Length)), UIntPtr.Zero);
			int num = 0;
			while (num < (int)numArray.Length)
			{
				if ((numArray[num] != 0 ? true : numArray[num + 1] != 0))
				{
					num++;
				}
				else
				{
					Array.Resize<byte>(ref numArray, num + 1);
					break;
				}
			}
			Encoding encoding = Encoding.GetEncoding("UNICODE");
			return encoding.GetString(numArray, 0, (int)numArray.Length);
		}

		public static bool WriteASCIIString(IntPtr address, string String)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(String);
			bool flag = Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, bytes, new UIntPtr((uint)bytes.Length), UIntPtr.Zero);
			return flag;
		}

		public static bool WriteBoolean(IntPtr address, bool value)
		{
			bool flag = Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, BitConverter.GetBytes(value), (UIntPtr)((long)1), UIntPtr.Zero);
			return flag;
		}

		public static bool WriteBytes(IntPtr address, byte[] val)
		{
			bool flag = Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, val, new UIntPtr((uint)val.Length), UIntPtr.Zero);
			return flag;
		}

		public static bool WriteDouble(IntPtr address, double value)
		{
			bool flag = Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, BitConverter.GetBytes(value), (UIntPtr)((long)8), UIntPtr.Zero);
			return flag;
		}

		public static bool WriteFlags8(IntPtr address, bool value, Memoryold.Startbit startbit)
		{
			int num = Convert.ToByte(value) * Convert.ToByte(Math.Pow(2, (double)startbit));
			byte num1 = (byte)num;
			bool flag = Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, BitConverter.GetBytes((short)num1), (UIntPtr)((long)1), UIntPtr.Zero);
			return flag;
		}

		public static bool WriteFloat(IntPtr address, float value)
		{
			bool flag = Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, BitConverter.GetBytes(value), (UIntPtr)((long)4), UIntPtr.Zero);
			return flag;
		}

		public static bool WriteInt16(IntPtr address, short value)
		{
			bool flag = Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, BitConverter.GetBytes(value), (UIntPtr)((long)2), UIntPtr.Zero);
			return flag;
		}

		public static bool WriteInt32(IntPtr address, int value)
		{
			bool flag = Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, BitConverter.GetBytes(value), (UIntPtr)((long)4), UIntPtr.Zero);
			return flag;
		}

		public static bool WriteInt64(IntPtr address, long value)
		{
			bool flag = Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, BitConverter.GetBytes(value), (UIntPtr)((long)8), UIntPtr.Zero);
			return flag;
		}

		public static bool WriteInt8(IntPtr address, byte value)
		{
			bool flag = Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, BitConverter.GetBytes((short)value), (UIntPtr)((long)1), UIntPtr.Zero);
			return flag;
		}

		public static bool WriteUnicodeString(IntPtr address, string String)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(String);
			bool flag = Kernel32.WriteProcessMemory(Memoryold.ProcessHandle, address, bytes, new UIntPtr((uint)bytes.Length), UIntPtr.Zero);
			return flag;
		}

		public class ExecuteBufferFunctionStatic
		{
			public IntPtr Address
			{
				get;
				set;
			}

			public IntPtr BufferAddress
			{
				get;
				set;
			}

			public int Size1
			{
				get;
			}

			public int Size2
			{
				get;
			}

			public IntPtr ThreadHandle
			{
				get;
				set;
			}

			public ExecuteBufferFunctionStatic()
			{
			}

			public void FreeMemory()
			{
				if (this.ThreadHandle != IntPtr.Zero)
				{
					Kernel32.WaitForSingleObject(this.ThreadHandle, 100);
				}
				Kernel32.VirtualFreeEx(Memoryold.ProcessHandle, this.Address, this.Size1, 2);
				Kernel32.VirtualFreeEx(Memoryold.ProcessHandle, this.BufferAddress, this.Size2, 2);
			}

			public void StartThread()
			{
				uint num;
				IntPtr intPtr = Kernel32.CreateRemoteThread(Memoryold.ProcessHandle, IntPtr.Zero, 0, this.Address, IntPtr.Zero, 0, out num);
				this.ThreadHandle = intPtr;
			}

			public void WriteFunction(byte[] array, byte[] argument, int Size1, int Size2)
			{
				IntPtr intPtr = Kernel32.VirtualAllocEx(Memoryold.ProcessHandle, IntPtr.Zero, Size1, 12288, 64);
				this.Address = intPtr;
				IntPtr intPtr1 = Kernel32.VirtualAllocEx(Memoryold.ProcessHandle, IntPtr.Zero, Size2, 12288, 64);
				this.BufferAddress = intPtr1;
				int num = 2;
				byte[] bytes = new byte[7];
				Memoryold.WriteBytes(intPtr1, argument);
				bytes = BitConverter.GetBytes((long)intPtr1);
				Array.Copy(bytes, 0, array, num, (int)bytes.Length);
				if (intPtr != IntPtr.Zero)
				{
					Memoryold.WriteBytes(intPtr, array);
				}
			}
		}

		public enum Startbit : byte
		{
			Bit0,
			Bit1,
			Bit2,
			Bit3,
			Bit4,
			Bit5,
			Bit6,
			Bit7
		}
	}
}