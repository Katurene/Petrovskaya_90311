using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petrovskaya_90311.DAL.Data;
using Petrovskaya_90311.DAL.Entities;

namespace Petrovskaya_90311.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Petrovskaya_90311.DAL.Data.ApplicationDbContext _context;

        public CreateModel(Petrovskaya_90311.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AnimalGroupId"] = new SelectList(_context.AnimalGroups, "AnimalGroupId", "AnimalGroupId");
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Animals.Add(Animal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
