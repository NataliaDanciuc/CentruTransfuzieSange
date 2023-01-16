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
    
    public class IndexModel : PageModel
    {
        private readonly CentruTransfuzieSange.Data.CentruTransfuzieSangeContext _context;

        public IndexModel(CentruTransfuzieSange.Data.CentruTransfuzieSangeContext context)
        {
            _context = context;
        }

        public IList<MedicalService> MedicalService { get;set; } = default!;
        public int MedicalServiceID { get; set; }
        public int DoctorID { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? doctorID, string searchString)
        {

            CurrentFilter = searchString;
            MedicalService = await _context.MedicalService
                .Include(b=>b.Doctor)
                .ToListAsync();


            if (!String.IsNullOrEmpty(searchString))
            {
                MedicalService = (IList<MedicalService>)MedicalService.Where(b=>b.Doctor.DoctorName.Contains(searchString)
                                                     || b.ServiceName.Contains(searchString));
            }
        }
    }
}
