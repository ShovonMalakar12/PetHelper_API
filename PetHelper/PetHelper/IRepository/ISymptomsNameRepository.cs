using PetHelper.Model;

namespace PetHelper.Repository.IRepository
{
  public interface ISymptomsNameDetailsRepository
  {
    Task<IEnumerable<SymptomsNameDetailsModel>> GetAllSymptomsNameDetails();
    Task<SymptomsNameDetailsModel?> GetByIdSymptomsNameDetails(int id);
    Task<bool> CreateSymptomsNameDetails(SymptomsNameDetailsModel SymptomsNameDetails);
    Task<bool> UpdateSymptomsNameDetails(SymptomsNameDetailsModel SymptomsNameDetails);
    Task<bool> DeleteSymptomsNameDetails(int id);
  }
}
