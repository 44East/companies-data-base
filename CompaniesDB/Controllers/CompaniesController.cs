using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompaniesDataBase.Models.Entities;
using CompaniesDataBase.Services.Data;
using CompaniesDataBase.Models.DTO;
using System.ComponentModel.Design;

namespace CompaniesDB.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly CompaniesContext _context;

        public CompaniesController(CompaniesContext context)
        {
            _context = context;
        }
        #region Company
        // GET: Companies
        public async Task<IActionResult> Index()
        {
              return _context.Companies != null ? 
                          View(await _context.Companies.ToListAsync()) :
                          Problem("Entity set 'CompaniesContext.Companies'  is null.");
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id, int? employeeId = default)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.Employees)
                .Include(c => c.Orders)
                .Include(c => c.Notes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            else
            {
                if (company.Employees.Count() > 0)
                {
                    company.CurrentEmployee = employeeId.HasValue ? company.Employees.FirstOrDefault(e => e.Id == employeeId.Value) : company.Employees.First();
                }
                else
                {
                    company.CurrentEmployee = new Employee();
                }
            }
            

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,City,State,Phone")] CompanyDTO company)
        {
            if (ModelState.IsValid)
            {
                var entry = _context.Add(new Company());
                entry.CurrentValues.SetValues(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }



        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,City,State,Phone")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { Id = id });
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Companies == null)
            {
                return Problem("Entity set 'CompaniesContext.Companies'  is null.");
            }
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
          return (_context.Companies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion

        #region Employee
        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.Include(e => e.Notes).Include(e => e.Company).FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return PartialView("Employees/_EmployeeDetailsPartial", employee);
        }
        [HttpPost, ActionName("CreateEmployee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee(int? companyId, [Bind("FirstName, LastName, Title, Position, BirthDate")] EmployeeDTO employee)
        {
            if (companyId == null || employee == null || !ModelState.IsValid) 
            {
                return Problem("company id is not available or an employee data is not correct.");
            }
            var entry = _context.Add(new Employee() { CompanyId = companyId.Value });
            entry.CurrentValues.SetValues(employee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Details), new { Id = companyId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEmployee(int? id, [Bind("FirstName, LastName, Title, Position, BirthDate")] EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var currentEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (currentEmployee == null)
            {
                return NotFound();
            }

            var entry = _context.Update(currentEmployee);
            entry.CurrentValues.SetValues(employee);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Details), new {Id = currentEmployee.CompanyId, employeeId = currentEmployee.Id});
        }
        [HttpPost, ActionName("DeleteEpmloyee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmployee(EmployeeDTO dto, int? id)
        {
            if (_context.Employees == null || !ModelState.IsValid)
            {
                return Problem("Entity set 'CompaniesContext.Employees' or Employee are null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            int companyId = default;
            if (employee != null)
            {
                companyId = employee.CompanyId;
                _context.Notes.RemoveRange(await _context.Notes.Where(n => n.EmployeeId == employee.Id).ToArrayAsync());
                _context.Employees.Remove(employee);
            }
            else
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Id = companyId});
        }
        #endregion
        #region Notes
        [HttpPost, ActionName("CreateNote")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNote([Bind("InvoiceNumber, CompanyId, EmployeeId")] NoteDTO note)
        {
            if (!ModelState.IsValid)
            {
                return Problem(ModelState.ToString());
            }
            var entry = _context.Add(new Note());
            entry.CurrentValues.SetValues(note);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Details), new { Id = note.CompanyId });


        }
        [HttpPost, ActionName("DeleteNote")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNote(int[]? selectedItems)
        {
            if(selectedItems == null || _context.Notes == null) 
            {
                return Problem("Entity set 'CompaniesContext.Notes' or id's are null.");
            }
            int companyId = default;
            foreach (var id in selectedItems)
            {
                var note = await _context.Notes.FindAsync(id);
                
                if (note != null)
                {
                    companyId = note.CompanyId;
                    _context.Notes.Remove(note);
                }
            }

            await _context.SaveChangesAsync();
                       
            return RedirectToAction(nameof(Details), new { Id = companyId });
        }
        #endregion
    }
}
