using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApartmentsRentalManagement1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartmentsRentalManagement1.Pages.Apartments
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
            OccupanciesStatus.Add(new SelectListItem() { Text = "Unknown", Value = "Unknown" });
            OccupanciesStatus.Add(new SelectListItem() { Text = "Occupied", Value = "Occupied" });
            OccupanciesStatus.Add(new SelectListItem() { Text = "Available", Value = "Available" });
            OccupanciesStatus.Add(new SelectListItem() { Text = "Not Ready", Value = "Not Ready" });
            OccupanciesStatus.Add(new SelectListItem() { Text = "Needs Maintenance", Value = "Needs Maintenance" });

            ViewData["OccupancyStatus"] = OccupanciesStatus;

            return Page();
        }

        [BindProperty]
        public Apartment Apartment { get; set; }
        public List<SelectListItem> OccupanciesStatus { get; set; } = new List<SelectListItem>();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Apartment.Add(Apartment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}