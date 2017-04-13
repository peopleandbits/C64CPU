using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MOS6510.Execution;

namespace MOS6510.Commands.ArithmeticCommands
{
            
	/// <summary>
	/// $01
	/// </summary>
	class ORA_Izx : CommandBase, IExecution
    {
		public Disassembler Execute()
        {
			byte oper = GetNextMem();
			UInt16 indAddr =  (byte)(oper + Cpu.Regs.X);
			byte calcOp = GetIndirectMemoryByte(indAddr);
			Cpu.Regs.A |= calcOp;
			return GenerateIzxDisAsm(oper);
		}
    }

	/// <summary>
	/// $09
	/// </summary>
	class ORA_Imm : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			byte oper = GetNextMem();
			Cpu.Regs.A |= oper;
			return GenerateImmX2DisAsm(oper);
		}
	}

	/// <summary>
	/// $88
	/// </summary>
	class DEY : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.Y--;
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $C8
	/// </summary>
	class INY : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.Y++;
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $CE
	/// </summary>
	class DEC_Abs : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Lo = GetNextMem();
			Hi = GetNextMem();
			UInt16 addr = GetAddress();
			Cpu.Ram[addr]--;
			return GenerateAbsX4DisAsm(addr);
		}
	}

	/// <summary>
	/// $CA
	/// </summary>
	class DEX : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.X--;
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $E8
	/// </summary>
	class INX : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Cpu.Regs.X++;
			return GenerateNormalDisAsm();
		}
	}

	/// <summary>
	/// $EE
	/// </summary>
	class INC_Abs : CommandBase, IExecution
	{
		public Disassembler Execute()
		{
			Lo = GetNextMem();
			Hi = GetNextMem();
			UInt16 addr = GetAddress();
			Cpu.Ram[addr]++;
			return GenerateAbsX4DisAsm(addr);
		}
	}

    /// <summary>
    /// $69
    /// </summary>
    class ADC_Imm : CommandBase, IExecution
    {
        public Disassembler Execute()
        {
            Cpu.Regs.A += GetNextMem(); 
            return GenerateImmX2DisAsm(Cpu.Regs.A);
        }
    }

    /// <summary>
    /// $65
    /// </summary>
    class ADC_Zp : CommandBase, IExecution
    {
        public Disassembler Execute()
        {
            Cpu.Regs.A += GetZeroPageAbsoluteMemoryByte();
            return GenerateImmX2DisAsm(Cpu.Regs.A);
        }
    }
}
