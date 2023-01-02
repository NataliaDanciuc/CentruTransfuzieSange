using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CentruTransfuzieSange.Models;

namespace CentruTransfuzieSange.Data
{
    public class CentruTransfuzieSangeContext : DbContext
    {
        public CentruTransfuzieSangeContext (DbContextOptions<CentruTransfuzieSangeContext> options)
            : base(options)
        {
        }

        public DbSet<CentruTransfuzieSange.Models.MedicalService> MedicalService { get; set; } = default!;

        public DbSet<CentruTransfuzieSange.Models.Doctor> Doctor { get; set; }

        public DbSet<CentruTransfuzieSange.Models.Appointment> Appointment { get; set; }

        public DbSet<CentruTransfuzieSange.Models.Member> Member { get; set; }

        public DbSet<CentruTransfuzieSange.Models.Review> Review { get; set; }
    }
}
