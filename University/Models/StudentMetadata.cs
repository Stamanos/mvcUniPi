using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class StudentMetadata
    {
        private UniversityEntities db = new UniversityEntities();

        [Display(Name="Last Name")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 50 characters!")]
        public string LastName;

        [Display(Name = "First Name")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 50 characters!")]
        public string FirstName;

        [Display(Name = "Enrollment Date")]
       // [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EnrollmentDate;

        public List<Student> GetStudents(string lastname, DateTime datefrom, DateTime dateto)
        {
            return db.FN_sp_searchStudent(lastname, datefrom.ToString(), dateto.ToString()).ToList();
        }
    }
}