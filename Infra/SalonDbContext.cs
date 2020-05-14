using Delux.Data.Reservation;
using Delux.Data.Technician;
using Delux.Data.Treatment;
using Microsoft.EntityFrameworkCore;

namespace Delux.Infra
{
    public class SalonDbContext : DbContext
    {
        public DbSet<BeauticianData> Beauticians { get; set; }
        public DbSet<HairdresserData> Hairdressers { get; set; }
        public DbSet<MasseuseData> Masseuses { get; set; }
        public DbSet<NailTechnicianData> NailTechnicians { get; set; }
        public DbSet<FacialTreatmentData> FacialTreatments { get; set; }
        public DbSet<HairTreatmentData> HairTreatments { get; set; }
        public DbSet<MassageTreatmentData> MassageTreatments { get; set; }
        public DbSet<NailTreatmentData> NailTreatments { get; set; }
        public DbSet<AppointmentData> Appointments { get; set; }


        public SalonDbContext(DbContextOptions<SalonDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<BeauticianData>().ToTable(nameof(Beauticians));
            builder.Entity<HairdresserData>().ToTable(nameof(Hairdressers));
            builder.Entity<MasseuseData>().ToTable(nameof(Masseuses));
            builder.Entity<NailTechnicianData>().ToTable(nameof(NailTechnicians));
            builder.Entity<FacialTreatmentData>().ToTable(nameof(FacialTreatments));
            builder.Entity<HairTreatmentData>().ToTable(nameof(HairTreatments));
            builder.Entity<MassageTreatmentData>().ToTable(nameof(MassageTreatments));
            builder.Entity<NailTreatmentData>().ToTable(nameof(NailTreatments));
            //builder.Entity<AppointmentData>().ToTable(nameof(Appointments))
                //.HasKey(x => new { x.TreatmentId, x.TechnicianId });

        }
    }
}