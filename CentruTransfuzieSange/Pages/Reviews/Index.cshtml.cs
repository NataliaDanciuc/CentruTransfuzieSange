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
    public class IndexModel : PageModel
    {
        private readonly CentruTransfuzieSange.Data.CentruTransfuzieSangeContext _context;

        public IndexModel(CentruTransfuzieSange.Data.CentruTransfuzieSangeContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Review != null)
            {
                Review = await _context.Review
                    .Include(b => b.Doctor)
                    .Include(b => b.Appointment)
                    .Include(b => b.Member)
                    .ToListAsync();
            }
        }
    }
}
