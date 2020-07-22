using System;

namespace CodeCheater.Infrastructure.ValidationException
{
    public class ApplicationValidationException : Exception
    {
        public ApplicationValidationException(string validationMessage) : base(validationMessage) { }
    }
}
