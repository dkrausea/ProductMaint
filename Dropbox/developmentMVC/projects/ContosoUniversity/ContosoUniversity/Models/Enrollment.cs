using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int CourseID { get; set; } //fkey

        public int PersonID { get; set; } //fkey

        [DisplayFormat(DataFormatString = "{0:#.#}", ApplyFormatInEditMode = true, NullDisplayText = "No grade")]
        public decimal? Grade { get; set; }

        public virtual Course Course { get; set; } //nav prop for CourseID fkey
        public virtual Student Student { get; set; } //nav prop for PersonID fkey
    }
}