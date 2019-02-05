using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApartmentsRentalManagement1.Models;

namespace ApartmentsRentalManagement1.Pages.RentalContracts
{
    public class DeleteModel : PageModel
    {
        private readonly ApartmentsRentalManagement1.Models.ApartmentsRentalManagement1Context _context;

        public DeleteModel(ApartmentsRentalManagement1.Models.ApartmentsRentalManagement1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public RentalContract RentalContract { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RentalContract = await _context.RentalContract.FindAsync(id);

            if (RentalContract != null)
            {
                _context.RentalContract.Remove(RentalContract);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
