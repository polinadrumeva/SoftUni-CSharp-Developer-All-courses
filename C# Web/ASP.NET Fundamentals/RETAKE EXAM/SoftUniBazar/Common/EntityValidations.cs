using Humanizer;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;

namespace SoftUniBazar.Common
{
	public static class EntityValidations
	{
		public static class Ad
		{
			public const int NameMinLength = 5;
			public const int NameMaxLength = 25;

			public const int DescriptionMinLength = 15;
			public const int DescriptionMaxLength = 250;

		}

		public static class Category
		{
			public const int NameMinLength = 3;
			public const int NameMaxLength = 15;
		}

	}
}
