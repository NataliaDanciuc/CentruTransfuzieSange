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

namespace CentruTransfuzieSange.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly CentruTransfuzieSange.Data.CentruTransfuzieSangeContext _context;

        public EditModel(CentruTransfuzieSange.Data.CentruTransfuzieSangeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Appointment == null)
            {
                return NotFound();
            }

            var appointment =  await _context.Appointment.FirstOrDefaultAsync(m => m.ID == id);
            if (appointment == null)
            {
                return NotFound();
            }
            Appointment = appointment;
           ViewData["DoctorID"] = new SelectList(_context.Doctor, "ID", "DoctorName");
           ViewData["MedicalServiceID"] = new SelectList(_context.MedicalService, "ID", "ServiceName");
           
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

            _context.Attach(Appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(Appointment.ID))
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

        private bool AppointmentExists(int id)
        {
          return _context.Appointment.Any(e => e.ID == id);
        }
    }
}
