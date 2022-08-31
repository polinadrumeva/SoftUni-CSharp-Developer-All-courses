namespace ValidationAttributes.Utilities
{
    using System;

    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
