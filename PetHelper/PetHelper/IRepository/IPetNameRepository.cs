using PetHelper.Model;

namespace PetHelper.Repository.IRepository
{
  public interface IPetNameRepository
  {
    Task<IEnumerable<PetNameModel>> GetAllPetName();
    Task<PetNameModel?> GetByIdPetName(int id);
    Task<bool> CreatePetName(PetNameModel petName);
    Task<bool> UpdatePetName(PetNameModel petName);
    Task<bool> DeletePetName(int id);
  }
}
