using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentruTransfuzieSange.Data;
using CentruTransfuzieSange.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CentruTransfuzieSange.Pages.Reviews
{
    [Authorize(Roles = "Doctor")]
    public class EditModel : PageModel
    {
        private readonly CentruTransfuzieSange.Data.CentruTransfuzieSangeContext _context;

        public EditModel(CentruTransfuzieSange.Data.CentruTransfuzieSangeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review =  await _context.Review
                .Include(b => b.Member)
                .Include(b => b.Appointment)
                .Include(b => b.Doctor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (review == null)
            {
                return NotFound();
            }
            Review = review;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(Review.ID))
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

        private bool ReviewExists(int id)
        {
          return _context.Review.Any(e => e.ID == id);
        }
    }
}
