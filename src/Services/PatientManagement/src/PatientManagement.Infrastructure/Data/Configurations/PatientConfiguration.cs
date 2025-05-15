using PatientManagement.Application.DTOs;

namespace PatientManagement.Infrastructure.Data.Configurations;

public class PatientConfiguration: IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne<Doctor>()
            .WithOne()
            .HasForeignKey<Patient>(p => p.PrimaryDoctorId);
        
        builder.OwnsOne<BloodType>(p => p.BloodType);

        builder.OwnsOne<Address>(p => p.Address);

        builder.OwnsOne<ContactInformation>(p => p.ContactDetails);
        
        builder.OwnsOne<MedicalHistory>(p => p.MedicalHistory);
    }
}