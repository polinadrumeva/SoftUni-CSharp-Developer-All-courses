SELECT IsoCode, CountryName, Capital FROM Countries

SELECT IsoCode,CountryName, Capital, Capital + ', ' + CountryName AS [Full] FROM Countries
