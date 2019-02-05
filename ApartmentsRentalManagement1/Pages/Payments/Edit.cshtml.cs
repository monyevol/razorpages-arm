using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ApartmentsRentalManagement1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartmentsRentalManagement1.Pages.Payments
{
    public class EditModel : PageModel
    {
        private readonly ApartmentsRentalManagement1Context _context;

        public EditModel(ApartmentsRentalManagement1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Payment Payment { get; set; }
        public Dictionary<int, string> StaffMembers { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> LoansContracts { get; set; } = new Dictionary<int, string>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payment = await _context.Payment.FirstOrDefaultAsync(m => m.PaymentId == id);

            if (Payment == null)
            {
                return NotFound();
            }
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(Payment.PaymentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PaymentExists(int id)
        {
            return _context.Payment.Any(e => e.PaymentId == id);
        }
    }
}
