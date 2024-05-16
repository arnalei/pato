using DEAD_CL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using Dapper;
namespace DEAD_FOOD.Pages
{
    [BindProperties]
    public class DEAD_adminModel : PageModel
    {
        public string DEAD_Id { get; set; }
        public string DEAD_Name { get; set; }
        public string DEAD_Price { get; set; }
        public string DEAD_Id2 { get; set; }
        public string DEAD_Name2 { get; set; }
        public string DEAD_Price2 { get; set; }
        private readonly ILogger<DEAD_adminModel> _logger;
        private readonly IConfiguration _config;
        public IEnumerable<DEAD_CLass> list { get; set; }
        public DEAD_adminModel(ILogger<DEAD_adminModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

            var DEAD_a = new SqlConnection(_config.GetConnectionString("DEAD_DB"));
            list = DEAD_a.Query<DEAD_CLass>("[DEAD_dis]", commandType: CommandType.StoredProcedure);
        }
        public IActionResult OnPostDEAD_sea()
        {
            var DEAD_a = new SqlConnection(_config.GetConnectionString("DEAD_DB"));
            list = DEAD_a.Query<DEAD_CLass>("[DEAD_sea]",new
            {
                @DEAD_Name=$"%{DEAD_Name2}%"
            }, commandType: CommandType.StoredProcedure);
            return Page();
        }
        public IActionResult OnPostDEAD_edi()
        {
            DEAD_Id=DEAD_Id2;
            DEAD_Name=DEAD_Name2;
            DEAD_Price = DEAD_Price2;
            var DEAD_a = new SqlConnection(_config.GetConnectionString("DEAD_DB"));
            list = DEAD_a.Query<DEAD_CLass>("[DEAD_dis]", commandType: CommandType.StoredProcedure);
            return Page();
        }
        public IActionResult OnPostDEAD_add()
        {
            var DEAD_a = new SqlConnection(_config.GetConnectionString("DEAD_DB"));
            DEAD_a.Query("[DEAD_add]",new {
            DEAD_Id=DEAD_Id,
            DEAD_Name=DEAD_Name,
            DEAD_Price= DEAD_Price
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }
        public IActionResult OnPostDEAD_del()
        {
            var DEAD_a = new SqlConnection(_config.GetConnectionString("DEAD_DB"));
            DEAD_a.Query("[DEAD_del]",new {
                DEAD_Id = DEAD_Id2
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }
        public IActionResult OnPostDEAD_upd()
        {
            var DEAD_a = new SqlConnection(_config.GetConnectionString("DEAD_DB"));
            DEAD_a.Query("[DEAD_upd]",new {
                DEAD_Id = DEAD_Id,
                DEAD_Name = DEAD_Name,
                DEAD_Price = DEAD_Price
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }
    }
}
