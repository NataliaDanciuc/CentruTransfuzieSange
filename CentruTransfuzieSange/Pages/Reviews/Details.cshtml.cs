using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CentruTransfuzieSange.Data;
using CentruTransfuzieSange.Models;

namespace CentruTransfuzieSange.Pages.Reviews
{
    public class DetailsModel : PageModel
    {
        private readonly CentruTransfuzieSange.Data.CentruTransfuzieSangeContext _context;

        public DetailsModel(CentruTransfuzieSange.Data.CentruTransfuzieSangeContext context)
        {
            _context = context;
        }

      public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Review == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .Include(b => b.Member)
                .Include(b => b.Appointment)
                .Include(b => b.Doctor)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (review == null)
            {
                return NotFound();
            }
            else 
            {
                Review = review;
            }
            return Page();
        }
    }
}
