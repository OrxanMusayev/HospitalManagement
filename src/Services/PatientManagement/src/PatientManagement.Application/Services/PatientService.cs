using PatientManagement.Application.DTOs;
using PatientManagement.Application.Interfaces;
using PatientManagement.Application.Utilities;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Enums;
using PatientManagement.Domain.ValueObjects;

namespace PatientManagement.Application.Services;

public class PatientService: IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PatientService(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<List<PatientDto>> GetPatientsAsync()
    {
        var patients = await _patientRepository.GetAll();
        var patientDtos = patients.Select(p => new PatientDto()
        {
            Name = p.Name,
            Surname = p.Surname,
            DateOfBirth = p.DateOfBirth,
            BloodType = p.BloodType.ToString(),
            Gender = p.Gender.ToString(),
            Address = p.Address != null ? new AddressDto()
            {
                City = p.Address.City,
                Street = p.Address.Street,
            } : null,
            ContactDetails = p.ContactDetails != null ? new ContactInformationDto()
            {
                PhoneNumber = p.ContactDetails.PhoneNumber,
                Email = p.ContactDetails.Email,
            } : null,
            PrimaryDoctor = p.Doctor?.GetFullName() ?? "No assigned doctor"
        }).ToList();

        return patientDtos;

    }

    public async Task<PatientDto> GetPatientByIdAsync(int id)
    {
        var patient = await _patientRepository.GetById(id);
        var patientDto = new PatientDto()
        {
            Id = patient.Id,
            Name = patient.Name,
            Surname = patient.Surname,
            DateOfBirth = patient.DateOfBirth,
            BloodType = patient.BloodType.ToString(),
            Gender = patient.Gender.ToString(),
            Address = new AddressDto()
            {
                City = patient.Address.City,
                Street = patient.Address.Street,
            },
            ContactDetails = new ContactInformationDto()
            {
                PhoneNumber = patient.ContactDetails.PhoneNumber,
                Email = patient.ContactDetails.Email,
            },
            PrimaryDoctor = patient.Doctor.GetFullName()
        };
        return patientDto;
    }

    public async Task AddPatient(PatientDto patientDto)
    {
        var patient = new Patient()
        {
            Name = patientDto.Name,
            Surname = patientDto.Surname,
            DateOfBirth = patientDto.DateOfBirth,
            Gender = Enum.Parse<Gender>(patientDto.Gender),
            BloodType = BloodTypeMapper.FromCombinedString(patientDto.BloodType),
            
            Address = new Address(patientDto.Address.City, patientDto.Address.Street, patientDto.Address.PostalCode),
            
            ContactDetails = new ContactInformation()
            {
                PhoneNumber = patientDto.ContactDetails.PhoneNumber,
                Email = patientDto.ContactDetails.Email,
            },
            PrimaryDoctorId = patientDto.PrimaryDoctorId
        };
        await _patientRepository.AddAsync(patient);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeletePatientAsync(int id)
    {
        await _patientRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdatePatient(PatientDto patientDto)
    {
        var patient = await _patientRepository.GetById(patientDto.Id);

        patient.Name = patientDto.Name;
        patient.Surname = patientDto.Surname;
        patient.DateOfBirth = patientDto.DateOfBirth;
        patient.Gender = Enum.Parse<Gender>(patientDto.Gender);
        patient.BloodType = BloodTypeMapper.FromCombinedString(patientDto.BloodType);

        patient.Address =
            new Address(patientDto.Address.City, patientDto.Address.Street, patientDto.Address.PostalCode);

        patient.ContactDetails = new ContactInformation()
        {
            PhoneNumber = patientDto.ContactDetails.PhoneNumber,
            Email = patientDto.ContactDetails.Email,
        };
        
        _patientRepository.Update(patient);
        await _unitOfWork.SaveChangesAsync();
    }
}