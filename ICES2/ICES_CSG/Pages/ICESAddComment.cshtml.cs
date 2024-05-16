using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using Dapper;
namespace ICES_CSG.Pages
{
    [BindProperties]
    public class ICESAddCommentModel : PageModel
    {
        public int ICES { get; set; }
        public string ICESIDNO { get; set; }
        public string ICESName { get; set; }
        public string ICESInstitutionalEmail { get; set; }
        public string ICESComment { get; set; }
        private readonly ILogger<ICESAddCommentModel> _logger;
        private readonly IConfiguration _ICESconfig;

        public ICESAddCommentModel(ILogger<ICESAddCommentModel> logger, IConfiguration ICESconfig)
        {
            _logger = logger;
            _ICESconfig = ICESconfig;
        }
        public IActionResult OnPostICESAdd()
        {
            var _ICES = new SqlConnection(_ICESconfig.GetConnectionString("ICES"));
            _ICES.Query("[ICESComAdd]", new
            {
                @ICESComment= ICESComment,
                @ICESIDNO = ICESIDNO,
                @ICESName = ICESName,
                @ICESInstitutionalEmail = ICESInstitutionalEmail
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }
    }
}
