using DocSeeker.API.DocSeeker.Domain.Models;
using DocSeeker.API.Security.Domain.Models;
using DocSeeker.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DocSeeker.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    

    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<New> News { get; set; }

    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<HourAvailable> HoursAvailable { get; set; }
    public DbSet<MedicalInformation> MedicalInformations { get; set; }

    public DbSet<Date> Dates { get; set; }

    public DbSet<Review> Reviews { get; set; }


    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Users

        // Constraints
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Dni).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Entity<User>().Property(p => p.cell1).IsRequired();
        builder.Entity<User>().Property(p => p.Birthday).IsRequired();
        builder.Entity<User>().Property(p => p.Genre).IsRequired();
        builder.Entity<User>()
                .HasDiscriminator<int>("Type")
                .HasValue<Patient>(1)
                .HasValue<Doctor>(2);

        //Patients
        builder.Entity<Patient>().ToTable("Users").HasBaseType<User>();

        //Doctors
        builder.Entity<Doctor>().ToTable("Users").HasBaseType<User>(); ;
        builder.Entity<Doctor>().Property(p => p.Area).IsRequired();
        builder.Entity<Doctor>().Property(p => p.Description).IsRequired();
        builder.Entity<Doctor>().Property(p => p.Patients).IsRequired();
        builder.Entity<Doctor>().Property(p => p.Years).IsRequired();
        builder.Entity<Doctor>().Property(p => p.Age).IsRequired();
        builder.Entity<Doctor>().Property(p => p.Cost).IsRequired();

       

        //News
        builder.Entity<New>().ToTable("News");
        builder.Entity<New>().HasKey(p => p.Id);
        builder.Entity<New>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<New>().Property(p => p.Image).IsRequired();
        builder.Entity<New>().Property(p => p.Title).IsRequired();
        builder.Entity<New>().Property(p => p.Info).IsRequired();
        builder.Entity<New>().Property(p => p.Description).IsRequired();
        builder.Entity<New>().Property(p => p.Views).IsRequired();

      



        //Dates
        builder.Entity<Date>().ToTable("Dates");
        builder.Entity<Date>().HasKey(p => p.Id);
        builder.Entity<Date>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Date>().Property(p => p.CDate).IsRequired();
        builder.Entity<Date>()
               .HasOne(p => p.CPatient)
               .WithMany(q => q.CDates)
               .HasForeignKey(id => id.IdPatient);
        builder.Entity<Date>()
               .HasOne(p => p.CDoctor)
               .WithMany(q => q.CDates)
               .HasForeignKey(id => id.DoctorId);



        //Reviews
        builder.Entity<Review>().ToTable("Reviews");
        builder.Entity<Review>().HasKey(p => p.Id);
        builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(p => p.ProfilePhotoUrl).IsRequired();
        builder.Entity<Review>().Property(p => p.CustomerReview).IsRequired();
        builder.Entity<Review>().Property(p => p.CustomerName).IsRequired();
        builder.Entity<Review>().Property(p => p.CustomerScore).IsRequired();
        builder.Entity<Review>()
               .HasOne(p => p.CPatient)
               .WithMany(q => q.CReviews)
               .HasForeignKey(id => id.IdPatient);
        builder.Entity<Review>()
               .HasOne(p => p.CDoctor)
               .WithMany(q => q.CReviews)
               .HasForeignKey(id => id.IdDoctor);

        


        //HourAvailable
        builder.Entity<HourAvailable>().ToTable("HourAvailables");
        builder.Entity<HourAvailable>().HasKey(p => p.Id);
        builder.Entity<HourAvailable>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<HourAvailable>().Property(p => p.Hours).IsRequired();
        builder.Entity<HourAvailable>().Property(p => p.Booked).IsRequired();

        builder.Entity<HourAvailable>()
               .HasOne(p => p.CDoctor)
               .WithMany(q => q.CHoursAvailable)
               .HasForeignKey(id => id.DoctorId);

       

        //MedicalInformation
        builder.Entity<MedicalInformation>().ToTable("MedicalHistories");
        builder.Entity<MedicalInformation>().HasKey(p => p.Id);
        builder.Entity<MedicalInformation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MedicalInformation>().Property(p => p.weight).IsRequired();
        builder.Entity<MedicalInformation>().Property(p => p.height).IsRequired();
        builder.Entity<MedicalInformation>().Property(p => p.bodyMass).IsRequired();
        builder.Entity<MedicalInformation>().Property(p => p.allergy).IsRequired();
        builder.Entity<MedicalInformation>().Property(p => p.pathological).IsRequired();

        builder.Entity<MedicalInformation>()
               .HasOne(p => p.CPatient)
               .WithMany(q => q.CMedicalInformation)
               .HasForeignKey(id => id.IdPatient);



        //Prescription
        builder.Entity<Prescription>().ToTable("Prescriptions");
        builder.Entity<Prescription>().HasKey(p => p.Id);
        builder.Entity<Prescription>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Prescription>().Property(p => p.DateIssue).IsRequired();
        builder.Entity<Prescription>().Property(p => p.DateExpiration).IsRequired();
        builder.Entity<Prescription>().Property(p => p.MedicalSpeciality).IsRequired();
        builder.Entity<Prescription>().Property(p => p.RecipCode).IsRequired();
        builder.Entity<Prescription>().Property(p => p.Condition).IsRequired();
        builder.Entity<Prescription>().Property(p => p.Rest).IsRequired();
        builder.Entity<Prescription>().Property(p => p.Drink).IsRequired();
        builder.Entity<Prescription>().Property(p => p.Food).IsRequired();
        builder.Entity<Prescription>().Property(p => p.Medicines).IsRequired();
        builder.Entity<Prescription>().Property(p => p.NumberDose).IsRequired();
        builder.Entity<Prescription>().Property(p => p.Meals).IsRequired();
        builder.Entity<Prescription>().Property(p => p.Hours).IsRequired();

        builder.Entity<Prescription>()
               .HasOne(p => p.CPatient)
               .WithMany(q => q.CPrescription)
               .HasForeignKey(id => id.IdPatient);
        

        // Apply Snake Case Naming Convention

        builder.UseSnakeCaseNamingConvention();
    }
}
