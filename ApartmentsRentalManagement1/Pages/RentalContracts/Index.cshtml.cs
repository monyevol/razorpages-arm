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
    public class IndexModel : PageModel
    {
        private readonly ApartmentsRentalManagement1.Models.ApartmentsRentalManagement1Context _context;

        public IndexModel(ApartmentsRentalManagement1.Models.ApartmentsRentalManagement1Context context)
        {
            _context = context;
        }

        public IList<RentalContract> RentalContract { get;set; }

        public async Task OnGetAsync()
        {
            RentalContract = await _context.RentalContract.ToListAsync();
        }
    }
}
