using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApartmentsRentalManagement1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartmentsRentalManagement1.Pages.RentalContracts
{
    public class EditModel : PageModel
    {
        private readonly ApartmentsRentalManagement1Context _context;

        public EditModel(ApartmentsRentalManagement1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public RentalContract RentalContract { get; set; }
        public List<SelectListItem> MaritalsStatus { get; set; } = new List<SelectListItem>();
        public Dictionary<int, string> Residences { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> StaffMembers { get; set; } = new Dictionary<int, string>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RentalContract = await _context.RentalContract.FirstOrDefaultAsync(m => m.RentalContractId == id);

            if (RentalContract == null)
            {
                return NotFound();
            }

            MaritalsStatus.Add(new SelectListItem() { Text = "Unknown", Value = "Unknown" });
            MaritalsStatus.Add(new SelectListItem() { Text = "Single", Value = "Single" });
            MaritalsStatus.Add(new SelectListItem() { Text = "Widdow", Value = "Widdow" });
            MaritalsStatus.Add(new SelectListItem() { Text = "Married", Value = "Married" });
            MaritalsStatus.Add(new SelectListItem() { Text = "Divorced", Value = "Divorced" });
            MaritalsStatus.Add(new SelectListItem() { Text = "Separated", Value = "Separated" });

            ViewData["MaritalStatus"] = MaritalsStatus;

            foreach (Employee staff in _context.Employee.ToList())
            {
                StaffMembers.Add(staff.EmployeeId, staff.Identification); // new SelectListItem() { Text = staff.Identification, Value = staff.Identification });
            }

            foreach (Apartment aprt in _context.Apartment.ToList())
            {
                Residences.Add(aprt.ApartmentId, aprt.Residence);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RentalContract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalContractExists(RentalContract.RentalContractId))
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

        private bool RentalContractExists(int id)
        {
            return _context.RentalContract.Any(e => e.RentalContractId == id);
        }
    }
}
