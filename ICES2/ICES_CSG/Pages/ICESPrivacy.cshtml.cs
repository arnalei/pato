using Dapper;
using ICES_ClassLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace ICES_CSG.Pages
{
    public class PrivacyModel : PageModel
    {
        public IEnumerable<ICES_Laws> laws { get; set; }
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IConfiguration _ICESconfig;

        public PrivacyModel(ILogger<PrivacyModel> logger, IConfiguration ICESconfig)
        {
            _logger = logger;
            _ICESconfig = ICESconfig;
            var _ICES = new SqlConnection(_ICESconfig.GetConnectionString("ICES"));
            laws = _ICES.Query<ICES_Laws>("[ICESLawDis]", commandType: CommandType.StoredProcedure);
        }



    }
}