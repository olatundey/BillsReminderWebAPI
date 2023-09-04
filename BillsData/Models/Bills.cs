using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BillssData.Models
{
	public class Bills
	{
        [Key]
        public int BillID { get; set; }

        //public Guid UserID { get; set; }

        [Required]
        public string? BillName { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        //[Display(Name = "Due Date")]
        //[CustomValidation(typeof(Bills), "ValidateFutureDate")]
        public DateTime DueDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        //public static ValidationResult ValidateFutureDate(DateTime date, ValidationContext context)
        //{
        //    if (date.Date < DateTime.Now.Date)
        //    {
        //        return new ValidationResult("Due date must be a future date.");
        //    }
        //    return ValidationResult.Success;
        //}

    }
}

