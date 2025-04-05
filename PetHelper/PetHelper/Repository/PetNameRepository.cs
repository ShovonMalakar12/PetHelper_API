using System.Data;
using System.Data.SqlClient;
using Dapper;
using PetHelper.Model;
using PetHelper.Repository.IRepository;

namespace PetHelper.Repository
{
  public class PetNameRepository : IPetNameRepository
  {
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public PetNameRepository(IConfiguration configuration)
    {
      _configuration = configuration;
      _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<PetNameModel>> GetAllPetName()
    {
      using var connection = new SqlConnection(_connectionString);
      return await connection.QueryAsync<PetNameModel>(
          "sp_GetAllPetNames",
          commandType: CommandType.StoredProcedure
      );
    }

    public async Task<PetNameModel?> GetByIdPetName(int id)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
      parameters.Add("@Id", id);

      return await connection.QueryFirstOrDefaultAsync<PetNameModel>(
          "sp_GetPetNameById",
          parameters,
          commandType: CommandType.StoredProcedure
      );
    }

    public async Task<bool> CreatePetName(PetNameModel petName)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
      parameters.Add("@Name", petName.Name);
      parameters.Add("@ImageUrl", petName.ImageUrl);

      var rows = await connection.ExecuteAsync(
          "sp_CreatePetName",
          parameters,
          commandType: CommandType.StoredProcedure
      );

      return rows > 0;
    }

    public async Task<bool> UpdatePetName(PetNameModel petName)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
      parameters.Add("@Id", petName.Id);
      parameters.Add("@Name", petName.Name);
      parameters.Add("@ImageUrl", petName.ImageUrl);

      var rows = await connection.ExecuteAsync(
          "sp_UpdatePetName",
          parameters,
          commandType: CommandType.StoredProcedure
      );

      return rows > 0;
    }

    public async Task<bool> DeletePetName(int id)
    {
      using var connection = new SqlConnection(_connectionString);
      var parameters = new DynamicParameters();
      parameters.Add("@Id", id);

      var rows = await connection.ExecuteAsync(
          "sp_DeletePetName",
          parameters,
          commandType: CommandType.StoredProcedure
      );

      return rows > 0;
    }
  }
}
