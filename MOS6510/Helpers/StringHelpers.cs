using System;

namespace MOS6510.Helpers
{
	static class StringHelpers
	{
		public static string ExtractNumbers (string expr)
		{
			return string.Join (null, System.Text.RegularExpressions.Regex.Split (expr, "[^\\d]"));
		}
	}
}