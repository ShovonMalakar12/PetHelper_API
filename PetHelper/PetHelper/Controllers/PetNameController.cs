using Microsoft.AspNetCore.Mvc;
using PetHelper.Model;
using PetHelper.Repository.IRepository;

namespace PetHelper.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PetNameController : ControllerBase
  {
    private readonly IPetNameRepository _petNameRepository;

    public PetNameController(IPetNameRepository petNameRepository)
    {
      _petNameRepository = petNameRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result = await _petNameRepository.GetAllPetName();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var result = await _petNameRepository.GetByIdPetName(id);
      if (result == null)
        return NotFound();
      return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PetNameModel model)
    {
      var success = await _petNameRepository.CreatePetName(model);
      if (!success)
        return BadRequest("Failed to create pet name.");
      return Ok("Pet name created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> Update(PetNameModel model)
    {
      var success = await _petNameRepository.UpdatePetName(model);
      if (!success)
        return BadRequest("Failed to update pet name.");
      return Ok("Pet name updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var success = await _petNameRepository.DeletePetName(id);
      if (!success)
        return BadRequest("Failed to delete pet name.");
      return Ok("Pet name deleted successfully.");
    }
  }
}
