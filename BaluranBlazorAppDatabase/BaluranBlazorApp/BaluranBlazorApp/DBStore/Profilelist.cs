using BaluranBlazorApp.Classes;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;


namespace BaluranBlazorApp.DBStore
{
    public class Profilelist
    {
        private readonly SqlConnection connection;
        private readonly IConfiguration config;

        public Profilelist(IConfiguration _config)
        {
            config = _config;
            connection = new SqlConnection(config.GetConnectionString("Baluran"));
        }
        public IEnumerable<Profile> list()
        {
            var sqlstr = "ReadProfile";
            return connection.Query<Profile>(sqlstr);
        }
        public IEnumerable<Profile> SearchProfileId(int id)
        {
            var sqlstr = "SearchProfileId";
            var parameter = new { Id = id };
            return connection.Query<Profile>(sqlstr, parameter);
        }
        public void Delete(int id)
        {
            var sqlstr = "DeleteProfile";
            var parameter = new { Id = id };
            connection.Execute(sqlstr, parameter, commandType: CommandType.StoredProcedure);
        }
        public void Update(Profile  profile)
        {
            var sqlstr = "UpdateProfile";
            var parameter = new DynamicParameters();
            parameter.Add("@Id", profile.Id, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@FirstName", profile.FirstName, DbType.String, ParameterDirection.Input);
            parameter.Add("@LastName", profile.LastName, DbType.String, ParameterDirection.Input);
            parameter.Add("@Email", profile.Email, DbType.String, ParameterDirection.Input);
            connection.Execute(sqlstr, parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
