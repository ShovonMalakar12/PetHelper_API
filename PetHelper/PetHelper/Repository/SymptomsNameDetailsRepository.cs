using System.Data;
using System.Data.SqlClient;
using Dapper;
using PetHelper.Model;
using PetHelper.Repository.IRepository;

namespace PetHelper.Repository
{
  public class SymptomsNameDetailsRepository : ISymptomsNameDetailsRepository
  {
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public SymptomsNameDetailsRepository(IConfiguration configuration)
    {
      _configuration = configuration;
      _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<SymptomsNameDetailsModel>> GetAllSymptomsNameDetails()
    {
      using var connection = new SqlConnection(_connectionString);
      return await connection.QueryAsync<SymptomsNameDetailsModel>(
          "sp_GetAllSymptomsNameDetails",
          commandType: CommandType.StoredProcedure
      );
    }

    public async Task<SymptomsNameDetailsModel?> GetByIdSymptomsNameDetails(int SymptomDetailsId)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
      parameters.Add("@Id", SymptomDetailsId);

      return await connection.QueryFirstOrDefaultAsync<SymptomsNameDetailsModel>(
          "sp_GetSymptomsNameDetailsById",
          parameters,
          commandType: CommandType.StoredProcedure
      );
    }

    public async Task<bool> CreateSymptomsNameDetails(SymptomsNameDetailsModel SymptomsNameDetails)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
      parameters.Add("@PetId", SymptomsNameDetails.PetId);
      parameters.Add("@SymptomsId", SymptomsNameDetails.SymptomsId);
      parameters.Add("@SymptomsDetails", SymptomsNameDetails.SymptomsDetails);
    

      var rows = await connection.ExecuteAsync(
          "sp_CreateSymptomsNameDetails",
          parameters,
          commandType: CommandType.StoredProcedure
      );

      return rows > 0;
    }

    public async Task<bool> UpdateSymptomsNameDetails(SymptomsNameDetailsModel SymptomsNameDetails)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
            parameters.Add("@PetId", SymptomsNameDetails.PetId);
            parameters.Add("@SymptomsId", SymptomsNameDetails.SymptomsId);
            parameters.Add("@SymptomsDetails", SymptomsNameDetails.SymptomsDetails);

      var rows = await connection.ExecuteAsync(
          "sp_UpdateSymptomsNameDetails",
          parameters,
          commandType: CommandType.StoredProcedure
      );

      return rows > 0;
    }

    public async Task<bool> DeleteSymptomsNameDetails(int SymptomDetailsId)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
            parameters.Add("@Id", SymptomDetailsId);

            var rows = await connection.ExecuteAsync(
          "sp_DeleteSymptomsNameDetails",
          parameters,
          commandType: CommandType.StoredProcedure
      );

      return rows > 0;
    }
  }
}
