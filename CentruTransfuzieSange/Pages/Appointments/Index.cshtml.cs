using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CentruTransfuzieSange.Data;
using CentruTransfuzieSange.Models;
using System.Drawing.Text;
using CentruTransfuzieSange.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CentruTransfuzieSange.Pages.Appointments
{
    [Authorize(Roles = "Doctor")]
    public class IndexModel : PageModel
    {
        private readonly CentruTransfuzieSange.Data.CentruTransfuzieSangeContext _context;

        public IndexModel(CentruTransfuzieSange.Data.CentruTransfuzieSangeContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get; set; } = default!;

        public AppointmentIndexData AppointmentData { get; set; }
        public int AppointmentID { get; set; }
        public int DoctorID { get; set;}
       
        public async Task OnGetAsync(int? id, int? doctorID)
        {
            AppointmentData = new AppointmentIndexData();
            AppointmentData.Appointments=await _context.Appointment
               .Include(a => a.MedicalService)
                .Include(a => a.Member)
                 .Include(a => a.Doctor)
                .ToListAsync();

            if(id != null)
            {
                AppointmentID=id.Value;
                Appointment appointment = AppointmentData.Appointments
                    .Where(a => a.ID == id.Value).Single();
               
                AppointmentData.Doctor = (ICollection<Doctor>)appointment.Doctor;
            }
            }
            
           
        }
    }

