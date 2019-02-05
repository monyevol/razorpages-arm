using System;
using System.ComponentModel.DataAnnotations;

namespace ApartmentsRentalManagement1.Models
{
    public class Payment
    {
        [Display(Name = "Payment Id")]
        public int      PaymentId        { get; set; }
        [Display(Name = "Receipt #")]
        public int      ReceiptNumber    { get; set; }
        [Display(Name = "Employee Id")]
        public int      EmployeeId       { get; set; }
        [Display(Name = "Rent Contract Id")]
        public int      RentalContractId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate      { get; set; }
        public int      Amount           { get; set; }
        public string   Notes            { get; set; }

        public Employee Employee { get; set; }
        public RentalContract RentalContract { get; set; }
    }
}
