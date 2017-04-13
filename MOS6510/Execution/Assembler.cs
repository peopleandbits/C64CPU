using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using MOS6510.Helpers;
using MOS6510.CPU;
using System.Globalization;

namespace MOS6510.Execution
{
    /// <summary>
    /// Compiles human readable assembly into machine code.
    /// </summary>
	public class Assembler
	{
		public List<string> SourceCode { get; set; }
		public MOS6510Chip Cpu { get; set; }
		public byte[] NativeCode { get; set; }

		public Assembler (MOS6510Chip chip)
		{
			Cpu = chip;
		}

		public void Reset()
		{
			ResetSources();
			Cpu.Init();
		}

		public void ResetSources()
		{
			SourceCode = null;
			NativeCode = null;
		}

		public bool Go()
		{
			if(SourceCode != null && SourceCode.Count > 0)
			{
				NativeCode = Parse();
				Array.Copy (NativeCode, 0, Cpu.Ram, 0, NativeCode.Length);
				Cpu.Run();
				return true;
			}
			else 
				return false;
		}

		public void InsertSource(string source)
		{
			SourceCode = source.Split('\n').ToList<string>();
			for (int i = 0; i < SourceCode.Count; i++)
			{
				SourceCode[i] = SourceCode[i].Trim('\t');
			}
		}

		public List<string> LoadSource(string fileName)
		{
			SourceCode = new List<string>();

			using (StreamReader r = new StreamReader(fileName))
			{
				string line;
				while ((line = r.ReadLine()) != null)
				{
					SourceCode.Add(line);
				}
			}

			return SourceCode;
		}

		public byte[] Parse()
		{
			List<byte> asm = new List<byte>();

			foreach(var line in SourceCode)
			{
				var splitted = line.Trim(' ').Split(' ');
				// now opcode literal is in first position, and possible operands thereafter
				// let's find opcode

				var s = Enum.GetNames(typeof(Commands.Opcode)).Where(c => c.StartsWith(splitted[0])).ToList();
				if(splitted.Length == 1)
				{ 
					Commands.Opcode oc = (Commands.Opcode)Enum.Parse(typeof(Commands.Opcode), s.First());
					byte val = (byte)oc;
					asm.Add(val);
					continue;
				}

				if(splitted[1].StartsWith("#"))
				{
					// imm
					string imm = s.Where(c => c.Contains("IMM")).First();
					Commands.Opcode oc = (Commands.Opcode)Enum.Parse(typeof(Commands.Opcode), imm);
					asm.Add((byte)oc);
					asm.Add(byte.Parse(StringHelpers.ExtractNumbers(splitted[1]), NumberStyles.AllowHexSpecifier));
				}

				if(splitted[1].StartsWith("$"))
				{
					// abs
					string abs = s.Where(c => c.Contains("ABS")).First();
					Commands.Opcode oc = (Commands.Opcode)Enum.Parse(typeof(Commands.Opcode), abs);
					asm.Add((byte)oc);
					var val = StringHelpers.ExtractNumbers(splitted[1]);
					asm.Add(byte.Parse(val.Substring(2, 2), NumberStyles.AllowHexSpecifier));
					asm.Add(byte.Parse(val.Substring(0, 2), NumberStyles.AllowHexSpecifier));
				}
			}

			return asm.ToArray();
		}
	}
}

