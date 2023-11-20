using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var propertyInfo = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (propertyInfo == null)
            {
                return new ValidationResult($"Unknown property: {_comparisonProperty}");
            }

            var comparisonValue = (DateTime)propertyInfo.GetValue(validationContext.ObjectInstance);

            if ((DateTime)value <= comparisonValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

        public override bool IsValid(object value)
        {
            var propertyInfo = value.GetType().GetProperty(_comparisonProperty);

            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property {_comparisonProperty} not found");
            }

            var comparisonValue = (DateTime)propertyInfo.GetValue(value);

            if ((DateTime)value <= comparisonValue)
            {
                return false;
            }

            return true;
        }
    }
}
