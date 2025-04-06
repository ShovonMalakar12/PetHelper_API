using Microsoft.AspNetCore.Mvc;
using PetHelper.Model;
using PetHelper.Repository.IRepository;

namespace PetHelper.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PetSymptomsController : ControllerBase
  {
    private readonly IPetSymptomsRepository _PetSymptomsRepository;

    public PetSymptomsController(IPetSymptomsRepository PetSymptomsRepository)
    {
      _PetSymptomsRepository = PetSymptomsRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result = await _PetSymptomsRepository.GetAllPetSymptoms();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var result = await _PetSymptomsRepository.GetByIdPetSymptoms(id);
      if (result == null)
        return NotFound();
      return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PetSymptomsModel model)
    {
      var success = await _PetSymptomsRepository.CreatePetSymptoms(model);
      if (!success)
        return BadRequest("Failed to create pet name.");
      return Ok("Pet name created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> Update(PetSymptomsModel model)
    {
      var success = await _PetSymptomsRepository.UpdatePetSymptoms(model);
      if (!success)
        return BadRequest("Failed to update pet name.");
      return Ok("Pet name updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var success = await _PetSymptomsRepository.DeletePetSymptoms(id);
      if (!success)
        return BadRequest("Failed to delete pet name.");
      return Ok("Pet name deleted successfully.");
    }
  }
}
