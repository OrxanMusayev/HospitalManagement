namespace PatientManagement.Infrastructure.Data.Configurations;

public class AppointmentConfiguration: IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(p => p.Id);
    }
}