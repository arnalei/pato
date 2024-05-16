using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using AJJK_CL;
using System.Data;

namespace AJJK_Planner.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public int AJJK_EDIT_ID { get; set; }
        public int AJJK_EDIT_ID2 { get; set; }
        public string AJJK_Id { get; set; }
        public string AJJK_Name { get; set; }
        public string AJJK_Subject { get; set; }
        public string AJJK_Date { get; set; }
        public string AJJK_Description { get; set; }
        public string AJJK_Status { get; set; }
        public string AJJK_Id2 { get; set; }
        public string AJJK_Name2 { get; set; }
        public string AJJK_Subject2 { get; set; }
        public string AJJK_Date2 { get; set; }
        public string AJJK_Description2 { get; set; }
        public string AJJK_Status2 { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _AJJK_Config;
        public IEnumerable<AJJK_Class> List { get; set; }
        public IndexModel(ILogger<IndexModel> logger,IConfiguration AJJK_config)
        {
            _logger = logger;
            _AJJK_Config = AJJK_config;

            var AJJK_a = new SqlConnection(_AJJK_Config.GetConnectionString("AJJK_DB"));
            List = AJJK_a.Query<AJJK_Class>("[AJJK_dis]", commandType:CommandType.StoredProcedure);

        }
        public IActionResult OnPostAJJK_sea()
        {
            var AJJK_a = new SqlConnection(_AJJK_Config.GetConnectionString("AJJK_DB"));
            List = AJJK_a.Query<AJJK_Class>("[AJJK_sea]",new{
                @AJJK_Name=$"%{AJJK_Name2}%"
            }, commandType: CommandType.StoredProcedure);
            return Page();
        }
        public IActionResult OnPostAJJK_edi()
        {
            AJJK_EDIT_ID = AJJK_EDIT_ID2;
            AJJK_Id = AJJK_Id2;
            AJJK_Name =AJJK_Name2;
            AJJK_Subject=AJJK_Subject2;
            AJJK_Date=AJJK_Date2;
            AJJK_Description=AJJK_Description2;
            AJJK_Status=AJJK_Status2;
            var AJJK_a = new SqlConnection(_AJJK_Config.GetConnectionString("AJJK_DB"));
            List = AJJK_a.Query<AJJK_Class>("[AJJK_dis]", commandType: CommandType.StoredProcedure);
            return Page();
        }
        public IActionResult OnPostAJJK_add()
        {
            var AJJK_a = new SqlConnection(_AJJK_Config.GetConnectionString("AJJK_DB"));
            AJJK_a.Query("[AJJK_add]",new{
            @AJJK_Id=AJJK_Id,
            @AJJK_Name=AJJK_Name,
            @AJJK_Subject=AJJK_Subject,
            @AJJK_Date=AJJK_Date,
            @AJJK_Description=AJJK_Description,
            @AJJK_Status= AJJK_Status
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }
        public IActionResult OnPostAJJK_del()
        {
            var AJJK_a = new SqlConnection(_AJJK_Config.GetConnectionString("AJJK_DB"));
            AJJK_a.Query("[AJJK_del]",new{
                @AJJK_Id = AJJK_Id2
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }
        public IActionResult OnPostAJJK_upd()
        {
            var AJJK_a = new SqlConnection(_AJJK_Config.GetConnectionString("AJJK_DB"));
            AJJK_a.Query("[AJJK_upd]",new {
                @AJJK_EDIT_ID = AJJK_EDIT_ID,
            @AJJK_Id = AJJK_Id,
            @AJJK_Name = AJJK_Name,
            @AJJK_Subject = AJJK_Subject,
            @AJJK_Date = AJJK_Date,
            @AJJK_Description = AJJK_Description,
            @AJJK_Status = AJJK_Status
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }


    }
}