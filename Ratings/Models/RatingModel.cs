using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ratings.Models
{
    public class RatingModel
    {
        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "OrgId is required.")]
        public int OrgId { get; set; }

        [Required(ErrorMessage = "OrgBranchId is required.")]
        public int OrgBranchId { get; set; }

        [Required(ErrorMessage = "OrgMemId is required.")]
        public int OrgMemId { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [StringLength(500, ErrorMessage = "ReviewText cannot exceed 500 characters.")]
        public string ReviewText { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public int  HelpfulCount { get; set;}
        [Required]
        public int ReportCount { get; set; }

        [Required]
        public bool IsVerified { get; set;}
    }

}