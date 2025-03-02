namespace PatientManagement.Infrastructure.Data.Configurations;

public class PatientConfiguration: IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.Id);
    }
}