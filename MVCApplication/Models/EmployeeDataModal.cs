using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApplication.Models
{
    public class EmployeeDataModal
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Photo { get; set; }
        public string AlternateText { get; set; }
    }
}