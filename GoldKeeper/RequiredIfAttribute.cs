using System;
using System.ComponentModel.DataAnnotations;

namespace GoldKeeper
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class RequiredIfAttribute : ValidationAttribute
    {
        public bool AllowEmptyStrings { get; set; }
        public bool AllowDefaultValue { get; set; }
        public string OtherPropertyName { get; private set; }

        public RequiredIfAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;
            var type = validationContext.ObjectType;
            var otherProperty = type.GetProperty(OtherPropertyName);
            var otherValue = otherProperty.GetValue(instance);

            var notEmptyValue = !AllowEmptyStrings && (value is string stringValue) ? stringValue.Trim().Length != 0 : true;
            var currentSet = AllowDefaultValue ? (value != null && notEmptyValue) : (value != null && notEmptyValue && !value.Equals(DefaultValue(type.GetProperty(validationContext.MemberName).PropertyType)));
            var otherSet = AllowDefaultValue ? (otherValue != null) : (otherValue != null && !otherValue.Equals(DefaultValue(otherProperty.PropertyType)));

            return currentSet || otherSet ? ValidationResult.Success : new ValidationResult(ErrorMessageString);
        }

        private object DefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
