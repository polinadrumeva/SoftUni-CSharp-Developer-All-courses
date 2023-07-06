namespace HouseRantingSystem.Common
{
	public static class EntityValidation
	{
		public static class Category
		{
			public const int NameMaxLength = 50;
			public const int NameMinLength = 3;
		}

		public static class House
		{
			public const int TitleMaxLength = 50;
			public const int TitleMinLength = 10;
			public const int DescriptionMaxLength = 500;
			public const int DescriptionMinLength = 50;
			public const int AddressMaxLength = 150;
			public const int AddressMinLength = 30;
			public const decimal PricePerMonthMinValue = 0;
			public const decimal PricePerMonthMaxValue = 2000;
		}

		public static class Agent
		{ 
			public const int PhoneNumberMaxLength = 15;
			public const int PhoneNumberMinLength = 7;

		}
	}
}