using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //Primary key values are supplied by the user, not the database.
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Number of credits is required.")]
        [Range(0, 5, ErrorMessage = "Number of credits must be between 0 and 5.")]
        public int Credits { get; set; }

        [Display(Name = "Department")]
        public int DepartmentID { get; set; } //fkey


        //nav props
        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; } //A course can have many students enrolled in it.
        public virtual ICollection<Instructor> Instructors { get; set; }  // A course may be taught by multiple instructors.
    }
}