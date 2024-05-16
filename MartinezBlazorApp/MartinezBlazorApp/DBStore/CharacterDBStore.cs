#nullable disable
using MartinezBlazorApp.Classes;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace MartinezBlazorApp.DBStore
{
    public class CharacterDBStore
    {
        private readonly SqlConnection connection;
        private readonly IConfiguration config;

        public CharacterDBStore(IConfiguration _config)
        {
            config = _config;
            connection = new SqlConnection(config.GetConnectionString("nalie"));  
        }

        public IEnumerable<Character> List()
        {
            var sqlstr = "DisplayCharacter";
            return connection.Query<Character>(sqlstr);
        }
        public void Delete(int Id)
        {
            var sqlstr = "Delete";
            var parameter = new { CharacterId = Id };
            connection.Execute(sqlstr, parameter, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Character> SearchById(int Id)
        {
            var sqlstr = "SearchCharacter";
            var parameter = new { CharacterId = Id };
            return connection.Query<Character>(sqlstr, parameter);
        }
        public void Update(Character character)
        {
            var sqlstr = "Update";
            var parameter = new DynamicParameters();
            parameter.Add("@CharacterId", character.CharacterId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@CharacterName", character.CharacterName, DbType.String, ParameterDirection.Input);
            parameter.Add("@Gender", character.Gender, DbType.String, ParameterDirection.Input);
            parameter.Add("@Age", character.Age, DbType.String, ParameterDirection.Input);
            parameter.Add("@Description", character.Description, DbType.String, ParameterDirection.Input);
            connection.Execute(sqlstr, parameter, commandType: CommandType.StoredProcedure);
        }
    }
}