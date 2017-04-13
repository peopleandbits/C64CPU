using System;

namespace MOS6510.Execution
{
	public interface IExecution
	{
		Disassembler Execute();
	}
}

