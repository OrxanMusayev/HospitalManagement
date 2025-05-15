namespace PatientManagement.Web;

[Route("api/v1/[controller]")]
[ApiController]
public class PatientController: ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PatientDto>>> GetPatients()
    {
        var patients = await _patientService.GetPatientsAsync();
        return Ok(patients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDto>> GetPatientById(int id)
    {
        var patient = await _patientService.GetPatientByIdAsync(id);
        if(patient == null)
            return NotFound(new ProblemDetails
            {
                Title = "Patient not found",
                Status = 404,
                Detail = $"No patient found with ID {patient.Id}"
            });
        
        return Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient(PatientDto patient)
    {
        if(patient == null)
            return BadRequest(new ProblemDetails
            {
                Title = "Patient data is required!",
                Status = 404,
                Detail = $"No patient found with ID {patient.Id}"
            });
        
        await _patientService.AddPatient(patient);
        return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePatient(PatientDto patient)
    {
        var patients = await _patientService.GetPatientByIdAsync(patient.Id);
        if (patient == null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Patient not found",
                Status = 404,
                Detail = $"No patient found with ID {patient.Id}"
            });
        }
        
        await _patientService.UpdatePatient(patient);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patient = await _patientService.GetPatientByIdAsync(id);
        
        if (patient == null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Patient not found",
                Status = 404,
                Detail = $"No patient found with ID {id}"
            });
        }
        
        await _patientService.DeletePatientAsync(id);
        return NoContent();
    }
}