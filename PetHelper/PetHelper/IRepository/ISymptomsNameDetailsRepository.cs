using PetHelper.Model;

namespace PetHelper.Repository.IRepository
{
  public interface IPetSymptomsRepository
  {
    Task<IEnumerable<PetSymptomsModel>> GetAllPetSymptoms();
    Task<PetSymptomsModel?> GetByIdPetSymptoms(int id);
    Task<bool> CreatePetSymptoms(PetSymptomsModel PetSymptoms);
    Task<bool> UpdatePetSymptoms(PetSymptomsModel PetSymptoms);
    Task<bool> DeletePetSymptoms(int id);
  }
}
