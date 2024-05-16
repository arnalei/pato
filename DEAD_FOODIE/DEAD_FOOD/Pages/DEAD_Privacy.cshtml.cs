using DEAD_CL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using Dapper;
namespace DEAD_FOOD.Pages
{
    public class PrivacyModel : PageModel
    {
        public string DEAD_Name { get; set; }
        public string DEAD_Price { get; set; }
        public int DEAD_duplicate { get; set; }
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IConfiguration _config;
        public IEnumerable<DEAD_CLass> list3 { get; set; }
        public IEnumerable<DEAD_CLass> list2 { get; set; }
        public PrivacyModel(ILogger<PrivacyModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

            var DEAD_a = new SqlConnection(_config.GetConnectionString("DEAD_DB"));
            list3 = DEAD_a.Query<DEAD_CLass>("[DEAD_sum2]", commandType: CommandType.StoredProcedure);
            list2 = DEAD_a.Query<DEAD_CLass>("[DEAD_dis2]", commandType: CommandType.StoredProcedure);
        }
    }
}