using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using DEAD_CL;
using Dapper;
using System.Data;
#nullable disable

namespace DEAD_FOOD.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public string DEAD_Id { get; set; }
        public string DEAD_Name { get; set; }
        public string DEAD_Price { get; set; }
        public int DEAD_duplicate { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;
        public IEnumerable<DEAD_CLass> list { get; set; }
        public IEnumerable<DEAD_CLass> list2 { get; set; }
        public IEnumerable<DEAD_CLass> list3 { get; set; }
        public IndexModel(ILogger<IndexModel> logger,IConfiguration config)
        {
            _logger = logger;
            _config = config;

            var DEAD_a = new SqlConnection(_config.GetConnectionString("DEAD_DB"));
            list = DEAD_a.Query<DEAD_CLass>("[DEAD_dis]", commandType: CommandType.StoredProcedure);
            list2 = DEAD_a.Query<DEAD_CLass>("[DEAD_dis2]", commandType: CommandType.StoredProcedure);
            list3 = DEAD_a.Query<DEAD_CLass>("[DEAD_sum2]", commandType: CommandType.StoredProcedure);

        }
        public IActionResult OnPostDEAD_add()
        {
            var DEAD_a = new SqlConnection(_config.GetConnectionString("DEAD_DB"));
            DEAD_a.Query("[DEAD_add2]", new
            {
                DEAD_Id = DEAD_Id,
                DEAD_Name = DEAD_Name,
                DEAD_Price = DEAD_Price
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }
        public IActionResult OnPostDEAD_del()
        {
            var DEAD_a = new SqlConnection(_config.GetConnectionString("DEAD_DB"));
            DEAD_a.Query("[DEAD_del2]", new
            {
                DEAD_duplicate = DEAD_duplicate
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }

    }
}