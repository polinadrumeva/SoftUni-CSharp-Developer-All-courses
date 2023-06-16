namespace Library.Comon
{
	public static class Constants
	{
		public static class BookValidations
		{
			public const int TitleMinLength = 10;
			public const int TitleMaxLength = 50;
			public const int AuthorMinLength = 5;
			public const int AuthorMaxLength = 50;
			public const int DescriptionMinLength = 5;
			public const int DescriptionMaxLength = 5000;
			public const decimal RatingMinValue = 0.00m;
			public const decimal RatingMaxValue = 10.00m;
		}

	
		public static class CategoryValidations
		{
			public const int NameMinLength = 5;
			public const int NameMaxLength = 50;
		}

	}
}