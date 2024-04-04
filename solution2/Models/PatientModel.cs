using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace solution2.Models
{
    public class PatientModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Patient name is required.")]
        [StringLength(100, ErrorMessage = "Patient name must be at most 100 characters.")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Gender ID is required.")]
        public int? GenderId { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please enter your date of birth.")]
        [MinimumAge(18, ErrorMessage = "You must be at least 18 years old.")]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Height is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Height must be a non-negative value.")]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Weight must be a non-negative value.")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "BMI is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "BMI must be a non-negative value.")]
        public decimal BMI { get; set; }

        [Display(Name = "Created On")]
        public DateTime? created_on { get; set; }

        [Display(Name = "Updated On")]
        public DateTime? updated_on { get; set; }

        [Display(Name = "Created By")]
        public long? create_by { get; set; }

        [Display(Name = "Updated By")]
        public long? updated_by { get; set; }

        public virtual GenderModel Gender { get; set; }
    }

    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dateOfBirth;
                if (DateTime.TryParse(value.ToString(), out dateOfBirth))
                {
                    if (dateOfBirth.AddYears(_minimumAge) > DateTime.Today)
                    {
                        return new ValidationResult(ErrorMessage ?? $"You must be at least {_minimumAge} years old.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}