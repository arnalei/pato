#nullable disable
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using BaluranBlazorApp.Classes;

namespace BaluranBlazorApp.DBStore
{
    public class Indexdb
    {
        private readonly SqlConnection konek;
        private readonly IConfiguration config;

        public Indexdb(IConfiguration _config)
        {
            config = _config;
            konek = new SqlConnection(config.GetConnectionString("Baluran"));
        }
        public void Create(Profile NewPerson)
        {
            var sqlstring = "[dbo].[CreateProfile]";
            var parameter = new DynamicParameters();
            parameter.Add("@FirstName", NewPerson.FirstName, DbType.String, ParameterDirection.Input);
            parameter.Add("@LastName", NewPerson.LastName, DbType.String, ParameterDirection.Input);
            parameter.Add("@Email", NewPerson.Email, DbType.String, ParameterDirection.Input);
            konek.Execute(sqlstring, parameter,commandType: CommandType.StoredProcedure);
        }
    }
}

