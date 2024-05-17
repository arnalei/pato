using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Numerics;


namespace SongcayawoninalIPT102ProjectFinal.Classes
{
    public class ConDb
    {
        private readonly SqlConnection sqlcon;
        private readonly IConfiguration con;
        public ConDb(IConfiguration _con)
        {
            con = _con;
            sqlcon = new SqlConnection(con.GetConnectionString("SW"));
        }
        public IEnumerable<Players> playerlist()
        {
            var sqlstring = "[dbo].[PlayerOptions]";
            return sqlcon.Query<Players>(sqlstring);
        }
        public void Create(Players player)
        {
            var sqlstring = "[dbo].[NewPlayerDetails]";
            var parameter = new DynamicParameters();
            parameter.Add("@PlayerName", player.PlayerName, DbType.String, ParameterDirection.Input);
            parameter.Add("@PlayerRank", player.PlayerRank, DbType.String, ParameterDirection.Input);
            parameter.Add("@PlayerClass", player.PlayerClass, DbType.String, ParameterDirection.Input);
            sqlcon.Execute(sqlstring, parameter, commandType: CommandType.StoredProcedure);
        }
        public void PlayerDetailsUpdate(Players player)
        {
            var sqlstring = "[dbo].[UpdatePlayerDetails]";
            var parameter = new DynamicParameters();
            parameter.Add("@PlayerId", player.PlayerId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@PlayerName", player.PlayerName, DbType.String, ParameterDirection.Input);
            parameter.Add("@PlayerRank", player.PlayerRank, DbType.String, ParameterDirection.Input);
            parameter.Add("@PlayerClass", player.PlayerClass, DbType.String, ParameterDirection.Input);
            sqlcon.Execute(sqlstring, parameter, commandType: CommandType.StoredProcedure);

        }
        public IEnumerable<Players> PickedPlayer(int PlayerId)
        {
            var sqlstring = "[dbo].[DisplayPlayerDetails]";
            var parameter = new { PlayerId = PlayerId };
            return sqlcon.Query<Players>(sqlstring, parameter);
        }
        public void PlayerDetailsDelete(int PlayerId)
        {
            var sqlstring = "[dbo].[DeletePlayerDetails]";
            var parameter = new { PlayerId = PlayerId };
            sqlcon.Execute(sqlstring, parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
