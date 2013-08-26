using System.Collections.Generic;

namespace rm.Validator
{
    /// <summary>
    /// Defines validate methods.
    /// </summary>
    /// <typeparam name="T">Type to validate.</typeparam>
    public interface IValidate<T>
    {
        /// <summary>
        /// Validate.
        /// </summary>
        bool IsValid(T input);
        /// <summary>
        /// Validate and also return errors if any.
        /// </summary>
        bool IsValid(T input, out IEnumerable<string> errors);
    }
}
