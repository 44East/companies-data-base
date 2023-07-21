using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompaniesDataBase.Models.Entities;
using CompaniesDataBase.Services.Data;

namespace CompaniesDataBase.Pages.Companies
{
    public class DetailsModel : PageModel
    {
        private readonly CompaniesDataBase.Services.Data.CompaniesContext _context;

        public DetailsModel(CompaniesDataBase.Services.Data.CompaniesContext context)
        {
            _context = context;
        }

      public Company Company { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            else 
            {
                Company = company;
            }
            return Page();
        }
    }
}
