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

namespace CentruTransfuzieSange.Pages.Reviews
{
    [Authorize(Roles = "Doctor")]
    public class CreateModel : PageModel
    {
        private readonly CentruTransfuzieSange.Data.CentruTransfuzieSangeContext _context;

        public CreateModel(CentruTransfuzieSange.Data.CentruTransfuzieSangeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "ID", "DoctorName");
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            ViewData["AppointmentID"] = new SelectList(_context.Appointment, "ID", "ID");


            return Page();
        }

        [BindProperty]
        public Review Review { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
