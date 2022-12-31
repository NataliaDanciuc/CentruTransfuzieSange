using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CentruTransfuzieSange.Data;
using CentruTransfuzieSange.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CentruTransfuzieSange.Pages.MedicalServices
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly CentruTransfuzieSange.Data.CentruTransfuzieSangeContext _context;

        public DetailsModel(CentruTransfuzieSange.Data.CentruTransfuzieSangeContext context)
        {
            _context = context;
        }

      public MedicalService MedicalService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MedicalService == null)
            {
                return NotFound();
            }

            var medicalservice = await _context.MedicalService.FirstOrDefaultAsync(m => m.ID == id);
            if (medicalservice == null)
            {
                return NotFound();
            }
            else 
            {
                MedicalService = medicalservice;
            }
            return Page();
        }
    }
}
