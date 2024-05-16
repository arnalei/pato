#nullable disable
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using MartinezBlazorApp.Classes;

namespace MartinezBlazorApp.DBStore
{
    public class IndexDBStore
    {
        private readonly SqlConnection sqlConnection;
        private readonly IConfiguration config;

        public IndexDBStore(IConfiguration _config)
        {
            config = _config;
            sqlConnection = new SqlConnection(config.GetConnectionString("nalie"));
        }
        public void Create(Character NewPerson)
        {
            var sqlstring = "[dbo].[NewCharacter]";
            var parameter = new DynamicParameters();
            parameter.Add("@CharacterName", NewPerson.CharacterName, DbType.String, ParameterDirection.Input);
            parameter.Add("@Gender", NewPerson.Gender, DbType.String, ParameterDirection.Input);
            parameter.Add("@Age", NewPerson.Age, DbType.String, ParameterDirection.Input);
            parameter.Add("@Description", NewPerson.Description, DbType.String, ParameterDirection.Input);
            sqlConnection.Execute(sqlstring, parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
