using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.Web.Mvc;

namespace Web.Models
{
    public class CompanyInput
    {
        [Required]
        public string CompanyName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

//        [DataType(DataType.Date)]
//        [Required]
//        public DateTime? BeginDate { get; set; }
//
//        [DataType(DataType.Date)]
//        [DateComesLater("BeginDate")]
//        public DateTime? EndDate { get; set; }
    }

    public class CompanyInputClient
    {
        [Required]
        public string CompanyName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

//        [DataType(DataType.Date)]
//        [Required]
//        public DateTime? BeginDate { get; set; }
//
//        [DataType(DataType.Date)]
//        [DateComesLaterClient("BeginDate")]
//        public DateTime? EndDate { get; set; }
    }

    public class DateComesLaterClientAttribute : DateComesLaterAttribute, IClientValidatable
    {
        public DateComesLaterClientAttribute(string otherDateProperty) : base(otherDateProperty) {}

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
                                                                               ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = GetErrorMessage(metadata.ContainerType, metadata.GetDisplayName()),
                ValidationType = "later",
            };

            rule.ValidationParameters.Add("other", "*." + OtherDateProperty);

            yield return rule;
        }
    }

    public class DateComesLaterAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "'{0}' must be after '{1}'";

        protected readonly string OtherDateProperty;

        public DateComesLaterAttribute(string otherDateProperty)
        {
            OtherDateProperty = otherDateProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = validationContext.ObjectType;

            var earlierDate = (DateTime?) type.GetProperty(OtherDateProperty).GetValue(instance, null);
            var date = (DateTime?) value;

            if (date > earlierDate)
                return ValidationResult.Success;

            string errorMessage = GetErrorMessage(validationContext.ObjectType, validationContext.DisplayName);

            return new ValidationResult(errorMessage);
        }

        protected string GetErrorMessage(Type containerType, string displayName)
        {
            ModelMetadata metadata = ModelMetadataProviders.Current.GetMetadataForProperty(null, containerType,
                                                                                           OtherDateProperty);
            var otherDisplayName = metadata.GetDisplayName();
            return ErrorMessage ?? string.Format(DefaultErrorMessage, displayName, otherDisplayName);
        }
    }
}