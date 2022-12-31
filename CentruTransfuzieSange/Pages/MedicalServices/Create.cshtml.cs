using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CentruTransfuzieSange.Data;
using CentruTransfuzieSange.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CentruTransfuzieSange.Pages.MedicalServices
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly CentruTransfuzieSange.Data.CentruTransfuzieSangeContext _context;

        public CreateModel(CentruTransfuzieSange.Data.CentruTransfuzieSangeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DoctorID"] = new SelectList(_context.Set<Doctor>(), "ID", "DoctorName");
            return Page();

        }

        [BindProperty]
        public MedicalService MedicalService { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MedicalService.Add(MedicalService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
