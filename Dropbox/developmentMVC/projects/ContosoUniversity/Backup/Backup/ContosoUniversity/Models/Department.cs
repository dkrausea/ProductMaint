﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required(ErrorMessage = "Budget is required.")]
        [Column(TypeName = "money")]  //Changes type from decimal to SQL Server type money
        public decimal? Budget { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Administrator")]
        public int? PersonID { get; set; } //fkey.  Named Administrator but hold an Instructor entity

        public virtual Instructor Administrator { get; set; }
        public virtual ICollection<Course> Courses { get; set; } //nav prop

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}