using ICES_ClassLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using Dapper;
namespace ICES_CSG.Pages
{
    [BindProperties]
    public class ICESCommentModel : PageModel
    {
        public int ICES { get; set; }
        public string ICESIDNO { get; set; }
        public string ICESName { get; set; }
        public string ICESInstitutionalEmail { get; set; }
        public IEnumerable<ICES_Comments> comments { get; set; }

        private readonly ILogger<ICESCommentModel> _logger;
        private readonly IConfiguration _ICESconfig;

        public ICESCommentModel(ILogger<ICESCommentModel> logger, IConfiguration ICESconfig)
        {
            _logger = logger;
            _ICESconfig = ICESconfig;
            var _ICES = new SqlConnection(_ICESconfig.GetConnectionString("ICES"));
            comments = _ICES.Query<ICES_Comments>("[ICESComDis]", commandType: CommandType.StoredProcedure);
        }
        public IActionResult OnPostICESSea()
        {
            var _ICES = new SqlConnection(_ICESconfig.GetConnectionString("ICES"));
            comments = _ICES.Query<ICES_Comments>("[ICESComSea]", new
            {
                @ICESSearch = $"%{ICESName}%"
            }, commandType: CommandType.StoredProcedure);
            return Page();
        }
        public IActionResult OnPostICESDel()
        {
            var _ICES = new SqlConnection(_ICESconfig.GetConnectionString("ICES"));
            _ICES.Query("[ICESComDel]", new
            {
                @ICES = ICES
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }
    }
}
