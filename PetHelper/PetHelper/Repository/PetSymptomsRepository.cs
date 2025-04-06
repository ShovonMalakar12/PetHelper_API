using System.Data;
using System.Data.SqlClient;
using Dapper;
using PetHelper.Model;
using PetHelper.Repository.IRepository;

namespace PetHelper.Repository
{
  public class PetSymptomsRepository : IPetSymptomsRepository
  {
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public PetSymptomsRepository(IConfiguration configuration)
    {
      _configuration = configuration;
      _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<PetSymptomsModel>> GetAllPetSymptoms()
    {
      using var connection = new SqlConnection(_connectionString);
      return await connection.QueryAsync<PetSymptomsModel>(
          "sp_GetAllSymptomsNames",
          commandType: CommandType.StoredProcedure
      );
    }

    public async Task<PetSymptomsModel?> GetByIdPetSymptoms(int id)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
      parameters.Add("@Id", id);

      return await connection.QueryFirstOrDefaultAsync<PetSymptomsModel>(
          "sp_GetPetSymptomsById",
          parameters,
          commandType: CommandType.StoredProcedure
      );
    }

    public async Task<bool> CreatePetSymptoms(PetSymptomsModel PetSymptoms)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
      parameters.Add("@PetId", PetSymptoms.PetId);
      parameters.Add("@SymptomsName", PetSymptoms.SymptomsName);

      var rows = await connection.ExecuteAsync(
          "sp_CreatePetSymptoms",
          parameters,
          commandType: CommandType.StoredProcedure
      );

      return rows > 0;
    }

    public async Task<bool> UpdatePetSymptoms(PetSymptomsModel PetSymptoms)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
      parameters.Add("@PetId", PetSymptoms.PetId);
      parameters.Add("@SymptomsName", PetSymptoms.SymptomsName);

      var rows = await connection.ExecuteAsync(
          "sp_UpdatePetSymptoms",
          parameters,
          commandType: CommandType.StoredProcedure
      );

      return rows > 0;
    }

    public async Task<bool> DeletePetSymptoms(int id)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
      parameters.Add("@Id", id);

      var rows = await connection.ExecuteAsync(
          "sp_DeletePetSymptoms",
          parameters,
          commandType: CommandType.StoredProcedure
      );

      return rows > 0;
    }
  }
}
