﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApartmentsRentalManagement1.Models;

namespace ApartmentsRentalManagement1.Pages.Apartments
{
    public class DetailsModel : PageModel
    {
        private readonly ApartmentsRentalManagement1.Models.ApartmentsRentalManagement1Context _context;

        public DetailsModel(ApartmentsRentalManagement1.Models.ApartmentsRentalManagement1Context context)
        {
            _context = context;
        }

        public Apartment Apartment { get; set; }

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
            return Page();
        }
    }
}
