using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApartmentsRentalManagement1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartmentsRentalManagement1.Pages.Payments
{
    public class CreateModel : PageModel
    {
        private readonly ApartmentsRentalManagement1Context _context;

        public CreateModel(ApartmentsRentalManagement1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            foreach (Employee staff in _context.Employee.ToList())
            {
                StaffMembers.Add(staff.EmployeeId, staff.Identification);
            }

            foreach (RentalContract rc in _context.RentalContract.ToList())
            {
                LoansContracts.Add(rc.RentalContractId, rc.Description);
            }

            return Page();
        }

        [BindProperty]
        public Payment Payment { get; set; }
        public Dictionary<int, string> StaffMembers { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> LoansContracts { get; set; } = new Dictionary<int, string>();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Payment.Add(Payment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}