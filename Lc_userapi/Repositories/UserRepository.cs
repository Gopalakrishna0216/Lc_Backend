
using Dapper;
using Lc_userapi.Models;
using Lc_userapi.Repositories;
using System.Data;
using System.Data.SqlClient;


       public class UserRepository : IUserRespository
      {

       private readonly string _connectionstring;
       public UserRepository(IConfiguration configuration) 
       {
        _connectionstring = configuration.GetConnectionString("DefaultConnection");
       }
          
        public async Task AddAsync(userClass Uc)
        {
        var connection = new SqlConnection(_connectionstring);
        {
            // await connection.ExecuteAsync("INSERT INTO userClasses (firstName,lastName,email) VALUES (@firstName,@lastName, @email)", Uc);
            var parameters = new DynamicParameters();
            parameters.Add("@firstName", Uc.firstName);
            parameters.Add("@lastName", Uc.lastName);
            parameters.Add("@email",Uc.Email);
            parameters.Add("@dateOfBirth", Uc.dob);
            parameters.Add("@Gender", Uc.gender);
            parameters.Add("@place",Uc.place);
            await connection.ExecuteAsync("sp_addUsertable",parameters,commandType:CommandType.StoredProcedure);
        }
        }

        public async Task DeleteAsync(int id)
        {

        var connection = new SqlConnection(_connectionstring);
        {
           // await connection.ExecuteAsync("Delete from userClasses where userId = @Id", new { Id = id });
           await connection.ExecuteAsync("sp_deleteUser",new { Id = id},commandType:CommandType.StoredProcedure);
        }


        }

        public async Task<IEnumerable<userClass>> GetallAsync()
        {
          var connection = new SqlConnection(_connectionstring);
        {
            // return await connection.QueryAsync<userClass>("select userId, firstName,lastName,email from userClasses ");
            return await connection.QueryAsync<userClass>("sp_getAllUsers",commandType:CommandType.StoredProcedure);
        }
        }

        public async Task<userClass?> GetbyIdAsync(int id)
        {
            var connection = new SqlConnection(_connectionstring);
        {
            //  return await connection.QueryFirstOrDefaultAsync<userClass>
            //  ( "Select *from userClasses where userId = @Id", new { Id = id });

            return await connection.QueryFirstOrDefaultAsync<userClass>(
            "getbyUserId", new { Id = id }, commandType: CommandType.StoredProcedure);

        }
            
        }

        public async Task UpdateAsync(userClass Uc)
        {
        var connection = new SqlConnection(_connectionstring);
        {
            // await connection.ExecuteAsync("Update userClasses Set firstName = @firstName, lastName = @lastName, email = @email where userId = @userId", Uc);
            await connection.ExecuteAsync(
             "sp_updateSp",
             new
             {
                 userId = Uc.userId,
                 firstName = Uc.firstName,
                 lastName = Uc.lastName,
                 email = Uc.Email,
                 dateOfBirth = Uc.dob,
                 Gender = Uc.gender,
                 place = Uc.place,
             },
             commandType: CommandType.StoredProcedure);
        }


    }
    }

