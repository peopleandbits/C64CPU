using System;
using System.Linq;
using System.Text;
using MOS6510.Commands;

namespace MOS6510.Execution
{
    /// <summary>
    /// Transforms machine code into human readable assembly language.
    /// </summary>
	public class Disassembler
	{
		public string Span { get; set; }
		public byte Opcode { get; set; }
		public CPU.Registers RegisterSnapshot {	get; set; }

		public Disassembler (string span, byte opcode, CPU.Registers regSnapShot)
		{
			Span = span;
			Opcode = opcode;
			RegisterSnapshot = regSnapShot;
		}

		public static Disassembler Create(Commands.IndexingMode imode, string name, byte opcode, string[] operands, CPU.Registers regSnapShot)
		{
			string span = string.Empty;

			switch(imode)
			{
				case IndexingMode.Imm:
					span = string.Format("{0} #${1}", name, string.Join(", ", operands));  
					break;

				case IndexingMode.Abs:
					span = string.Format("{0} ${1}", name, string.Join(", ", operands));  
					break;

				case IndexingMode.Abx:
					span = string.Format("{0} ${1},X", name, string.Join(", ", operands));  
					break;

				case IndexingMode.Aby:
					span = string.Format("{0} ${1},Y", name, string.Join(", ", operands));  
					break;

				case IndexingMode.Ind:
					span = string.Format("{0} (${1})", name, string.Join(", ", operands));  
					break;

				case IndexingMode.Izx:
					span = string.Format("{0} (${1},X)", name, string.Join(", ", operands));  
					break;

				case IndexingMode.Izy:
					span = string.Format("{0} (${1}),Y", name, string.Join(", ", operands));  
					break;

				case IndexingMode.Zp:
					span = string.Format("{0} ${1}", name, string.Join(", ", operands));  
					break;

				case IndexingMode.Zpx:
					span = string.Format("{0} ${1},X", name, string.Join(", ", operands));  
					break;

				case IndexingMode.Zpy:
					span = string.Format("{0} ${1},Y", name, string.Join(", ", operands));  
					break;

				case IndexingMode.Rel:
					span = string.Format("{0} ${1} (PC)", name, string.Join(", ", operands));  
					break;

				case IndexingMode.None:
					span = name;  
					break;

			}

			return new Disassembler(span, opcode, regSnapShot);
		}
	}
}

