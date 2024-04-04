using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace solution2.Models
{
    public class NewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Patient name is required.")]
        [StringLength(100, ErrorMessage = "Patient name must be at most 100 characters.")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Gender ID is required.")]
        public GenderModel Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of birth is required.")]
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
    }
}