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
    public class IndexModel : PageModel
    {
        private readonly CompaniesDataBase.Services.Data.CompaniesContext _context;

        public IndexModel(CompaniesDataBase.Services.Data.CompaniesContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Companies != null)
            {
                Company = await _context.Companies.ToListAsync();
            }
        }
    }
}
