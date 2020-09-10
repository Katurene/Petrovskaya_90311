using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Petrovskaya_90311.DAL.Data;
using Petrovskaya_90311.DAL.Entities;

namespace Petrovskaya_90311.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly Petrovskaya_90311.DAL.Data.ApplicationDbContext _context;

        public EditModel(Petrovskaya_90311.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Animal Animal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Animal = await _context.Animals
                .Include(a => a.Group).FirstOrDefaultAsync(m => m.AnimalId == id);

            if (Animal == null)
            {
                return NotFound();
            }
           ViewData["AnimalGroupId"] = new SelectList(_context.AnimalGroups, "AnimalGroupId", "AnimalGroupId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(Animal.AnimalId))
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

        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.AnimalId == id);
        }
    }
}
