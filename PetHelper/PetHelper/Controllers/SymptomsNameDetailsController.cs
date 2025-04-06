using Microsoft.AspNetCore.Mvc;
using PetHelper.Model;
using PetHelper.Repository.IRepository;

namespace PetHelper.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SymptomsNameDetailsController : ControllerBase
  {
    private readonly ISymptomsNameDetailsRepository _SymptomsNameDetailsRepository;

    public SymptomsNameDetailsController(ISymptomsNameDetailsRepository SymptomsNameDetailsRepository)
    {
      _SymptomsNameDetailsRepository = SymptomsNameDetailsRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSymptomsNameDetails()
    {
      var result = await _SymptomsNameDetailsRepository.GetAllSymptomsNameDetails();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdSymptomsNameDetails(int id)
    {
      var result = await _SymptomsNameDetailsRepository.GetByIdSymptomsNameDetails(id);
      if (result == null)
        return NotFound();
      return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSymptomsNameDetails(SymptomsNameDetailsModel model)
    {
      var success = await _SymptomsNameDetailsRepository.CreateSymptomsNameDetails(model);
      if (!success)
        return BadRequest("Failed to create pet name.");
      return Ok("Pet name created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSymptomsNameDetails(SymptomsNameDetailsModel model)
    {
      var success = await _SymptomsNameDetailsRepository.UpdateSymptomsNameDetails(model);
      if (!success)
        return BadRequest("Failed to update pet name.");
      return Ok("Pet name updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSymptomsNameDetails(int id)
    {
      var success = await _SymptomsNameDetailsRepository.DeleteSymptomsNameDetails(id);
      if (!success)
        return BadRequest("Failed to delete pet name.");
      return Ok("Pet name deleted successfully.");
    }
  }
}
