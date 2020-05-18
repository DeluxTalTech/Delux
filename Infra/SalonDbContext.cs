using Delux.Data.Client;
using Delux.Data.Reservation;
using Delux.Data.Technician;
using Delux.Data.Treatment;
using Microsoft.EntityFrameworkCore;

namespace Delux.Infra
{
    public class SalonDbContext : DbContext
    {
        public DbSet<TreatmentTypeData> TreatmentTypes { get; set; }
        public DbSet<TechnicianTypeData> TechnicianTypes { get; set; }
        public DbSet<TreatmentData> Treatments { get; set; }
        public DbSet<TechnicianData> Technicians { get; set; }
        public DbSet<ClientData> Clients { get; set; }
        //public DbSet<AppointmentData> Appointments { get; set; }


        public SalonDbContext(DbContextOptions<SalonDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<TreatmentTypeData>().ToTable(nameof(TreatmentTypes));
            builder.Entity<TechnicianTypeData>().ToTable(nameof(TechnicianTypes));
            builder.Entity<TreatmentData>().ToTable(nameof(Treatments))
                .HasKey(x => new {x.Id, x.TreatmentTypeId});
            builder.Entity<TechnicianData>().ToTable(nameof(Technicians))
                .HasKey(x => new { x.Id, x.TechnicianTypeId});
            builder.Entity<ClientData>().ToTable(nameof(Clients));
            //builder.Entity<AppointmentData>().ToTable(nameof(Appointments))
            //.HasKey(x => new { x.ClientId, x.TreatmentId, x.TechnicianId });

        }
    }
}