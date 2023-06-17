using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homies.Common.Validations
{
	public static class ValidationConstants
	{
		public class EventValidations
		{
			public const int MinEventNameLength = 5;
			public const int MaxEventNameLength = 20;
			public const int MinEventDescriptionLength = 15;
			public const int MaxEventDescriptionLength = 150;
		}

		
		public class TypeValidations
		{
			public const int MinTypeNameLength = 5;
			public const int MaxTypeNameLength = 15;
		}

		
	}
}
