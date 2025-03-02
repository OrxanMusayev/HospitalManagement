namespace PatientManagement.Infrastructure.Data.Configurations;

public class MedicalHistoryConfiguration: IEntityTypeConfiguration<MedicalHistory>
{
    public void Configure(EntityTypeBuilder<MedicalHistory> builder)
    {
        builder.Property(m => m.Description)
            .HasMaxLength(5000)
            .IsRequired();
    }
}