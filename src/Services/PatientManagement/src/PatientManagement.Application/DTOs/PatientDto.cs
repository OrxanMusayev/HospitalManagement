using PatientManagement.Domain.Entities;
using PatientManagement.Domain.ValueObjects;

namespace PatientManagement.Application.DTOs;

public class PatientDto
{
    public int  Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string? BloodType { get; set; }
    public AddressDto? Address { get; set; }
    public ContactInformationDto? ContactDetails { get; set; }
    public int? PrimaryDoctorId { get; set; }
    public string? PrimaryDoctor { get; set; }
}