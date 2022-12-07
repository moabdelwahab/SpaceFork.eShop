﻿using FluentValidation.Results;

namespace SpaceFork.eShop.Ordering.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base($"One or more validation failures have occured")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failoureGroup => failoureGroup.Key, failoureGroup => failoureGroup.ToArray());
                
        }


        public IDictionary<string, string[]> Errors { get; }
    }
}
