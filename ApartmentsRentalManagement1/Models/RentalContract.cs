using System;
using System.ComponentModel.DataAnnotations;

namespace ApartmentsRentalManagement1.Models
{
    public class RentalContract
    {
        [Display(Name = "Rent Contract Id")]
        public int      RentalContractId { get; set; }
        [Display(Name = "Contract #")]
        public int ContractNumber        { get; set; }
        [Display(Name = "Employee Id")]
        public int      EmployeeId       { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Contract Date")]
        public DateTime ContractDate     { get; set; }
        [Display(Name = "First Name")]
        public string   FirstName        { get; set; }
        [Display(Name = "Last Name")]
        public string   LastName         { get; set; }
        [Display(Name = "Marital Status")]
        public string   MaritalStatus    { get; set; }
        [Display(Name = "Children")]
        public int      NumberOfChildren { get; set; }
        [Display(Name = "Apartment")]
        public int      ApartmentId      { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Rent Start Date")]
        public DateTime RentStartDate    { get; set; }

        public string Description
        {
            get
            {
                return ContractNumber + " - " + FirstName + " " + LastName + " (renting since " + RentStartDate + ")";
            }
        }

        public Employee Employee { get; set; }
    }
}
