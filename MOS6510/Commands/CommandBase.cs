using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOS6510.Execution;

namespace MOS6510.Commands
{
    /// <summary>
    /// Base class for commands. Provides functions for stack, memory and disassembly.
    /// </summary>
    public abstract class CommandBase
    {
        public byte Hi { get; set; }
        public byte Lo { get; set; }
		public string Operand { get; set; }
		public string Name { get; set;	}
		public Commands.IndexingMode IndexingMode { get; set; }
		public string Description { get; set; }
		public static MOS6510.CPU.MOS6510Chip Cpu { get; set; }
		public byte Opcode { get; set; }

        #region stack ops
        public void Push(byte val)
        {
            if (Cpu.Regs.StackPtr == 0)
                throw new Helpers.C64Exception("Stack is full.");
			Cpu.Ram[Cpu.StackStartAddress + Cpu.Regs.StackPtr--] = val;
        }

        public byte Pop()
        {
			if (Cpu.Regs.StackPtr == 255)
                throw new Helpers.C64Exception("Nothing to pop because stack is empty.");
            return Cpu.Ram[Cpu.StackStartAddress + Cpu.Regs.StackPtr++];
        }
        #endregion

        #region mem ops
        public byte GetNextMem()
        {
			return Cpu.Ram[Cpu.Regs.PC++];
        }

        public void MemoryWrite(ushort p, byte A)
        {
            Cpu.Ram[p] = A;
        }

		/// <summary>
		/// Bit shift high byte and add the low byte for 16-bit address
		/// </summary>
		/// <returns>
		/// The address.
		/// </returns>
		public UInt16 GetAddress ()
		{
			UInt16 addr = (UInt16)(Hi << 8 | Lo);
			Operand = addr.ToString();
			return addr;
		}

		public byte GetAbsoluteMemoryByte ()
		{
			Lo = GetNextMem ();
			Hi = GetNextMem ();
			UInt16 addr = GetAddress ();
			return Cpu.Ram [addr];
		}

		public byte GetIndirectMemoryByte (UInt16 indirect)
		{
			byte l = Cpu.Ram[indirect];
			byte h = Cpu.Ram[indirect+1];
			UInt16 realAddr = (UInt16)(h << 8 | l);
			return Cpu.Ram[realAddr];
		}

        public byte GetZeroPageAbsoluteMemoryByte()
        {
            Lo = GetNextMem();
            Hi = 00;
            UInt16 addr = GetAddress();
            return Cpu.Ram[addr];
        }
        #endregion

		#region disassembly generation

		public Disassembler GenerateIzxDisAsm(byte elem)
		{	
			return Disassembler.Create(IndexingMode.Izx, Name, Opcode, new string[] {elem.ToString("X2")}, Cpu.Regs);
		}

		public Disassembler GenerateImmX2DisAsm(byte elem)
		{	
			return Disassembler.Create(IndexingMode.Imm, Name, Opcode, new string[] {elem.ToString("X2")}, Cpu.Regs);
		}

		public Disassembler GenerateAbsX4DisAsm(UInt16 addr)
		{
			return Disassembler.Create(IndexingMode.Abs, Name, Opcode, new string[] { addr.ToString("X4")}, Cpu.Regs);
		}

		public Disassembler GenerateNormalDisAsm()
		{
			return new Disassembler(Name, Opcode, Cpu.Regs);
		}

		#endregion
	}
}
