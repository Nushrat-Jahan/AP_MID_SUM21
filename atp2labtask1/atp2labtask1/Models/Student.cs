using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace atp2labtask1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Max Length 15 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please put Date of Birth")]
        public DateTime Dob { get; set; }
        [Required]
        [Range(0.0,4.0)]
        public double Cgpa { get; set; }
        [Required]
        public int Credit { get; set; }
        [Required(ErrorMessage = "Department Id is required")]
        public int DeptId { get; set; }
    }
}