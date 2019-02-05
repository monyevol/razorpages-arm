using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ApartmentsRentalManagement1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartmentsRentalManagement1.Pages.Apartments
{
    public class EditModel : PageModel
    {
        private readonly ApartmentsRentalManagement1Context _context;

        public EditModel(ApartmentsRentalManagement1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Apartment Apartment { get; set; }
        public List<SelectListItem> OccupanciesStatus { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Apartment = await _context.Apartment.FirstOrDefaultAsync(m => m.ApartmentId == id);

            if (Apartment == null)
            {
                return NotFound();
            }

            OccupanciesStatus.Add(new SelectListItem() { Text = "Unknown", Value = "Unknown" });
            OccupanciesStatus.Add(new SelectListItem() { Text = "Occupied", Value = "Occupied" });
            OccupanciesStatus.Add(new SelectListItem() { Text = "Available", Value = "Available" });
            OccupanciesStatus.Add(new SelectListItem() { Text = "Not Ready", Value = "Not Ready" });
            OccupanciesStatus.Add(new SelectListItem() { Text = "Needs Maintenance", Value = "Needs Maintenance" });

            ViewData["OccupancyStatus"] = OccupanciesStatus;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Apartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentExists(Apartment.ApartmentId))
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

        private bool ApartmentExists(int id)
        {
            return _context.Apartment.Any(e => e.ApartmentId == id);
        }
    }
}
