using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOS6510.CPU
{
	public class StatusRegister : StatusRegisterBase
	{
		/// <summary>
		/// Carry
		/// </summary>
		/// <value>
		/// <c>true</c> = carry
		/// </value>
		public bool C { get { return base.GetFlag (SRFlags.C); } set { base.SetFlag (SRFlags.C, value); } }

		/// <summary>
		/// Zero
		/// </summary>
		/// <value>
		/// <c>true</c> = result zero
		/// </value>
		public bool Z { get { return base.GetFlag (SRFlags.Z); } set { base.SetFlag (SRFlags.Z, value); } }

		/// <summary>
		/// IRQ Disable
		/// </summary>
		/// <value>
		/// <c>true</c> = disabled
		/// </value>
		public bool I { get { return base.GetFlag (SRFlags.I); } set { base.SetFlag (SRFlags.I, value); } }

		/// <summary>
		/// Decimal Mode
		/// </summary>
		/// <value>
		/// <c>true</c> = enabled
		/// </value>
		public bool D { get { return base.GetFlag (SRFlags.D); } set { base.SetFlag (SRFlags.D, value); } }

		/// <summary>
		/// BRK Command
		/// </summary>
		/// <value>
		/// 
		/// </value>
		public bool B { get { return base.GetFlag (SRFlags.B); } set { base.SetFlag (SRFlags.B, value); } }

		/// <summary>
		/// Overflow
		/// </summary>
		/// <value>
		/// <c>true</c> = overflow
		/// </value>
		public bool V { get { return base.GetFlag (SRFlags.V); } set { base.SetFlag (SRFlags.V, value); } }

		/// <summary>
		/// Negative
		/// </summary>
		/// <value>
		/// <c>true</c> = neg
		/// </value>
		public bool N { get { return base.GetFlag (SRFlags.N); } set { base.SetFlag (SRFlags.N, value); } }
	}
}
