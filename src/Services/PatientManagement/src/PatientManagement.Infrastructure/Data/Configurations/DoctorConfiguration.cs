namespace PatientManagement.Infrastructure.Data.Configurations;

public class DoctorConfiguration: IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(p => p.Id);
    }
}