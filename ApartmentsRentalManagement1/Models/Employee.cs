﻿using System.ComponentModel.DataAnnotations;

namespace ApartmentsRentalManagement1.Models
{
    public class Employee
    {
        [Display(Name = "Employee Id")]
        public int    EmployeeId      { get; set; }
        [Display(Name = "Employee #")]
        public string EmployeeNumber  { get; set; }
        [Display(Name = "First Name")]
        public string FirstName       { get; set; }
        [Display(Name = "Last Name")]
        public string LastName        { get; set; }
        [Display(Name = "Employment Title")]
        public string EmploymentTitle { get; set; }

        public string Identification
        {
            get
            {
                return EmployeeNumber + " - " + FirstName + " " + LastName + " (" + EmploymentTitle + ")";
            }
        }
    }
}
