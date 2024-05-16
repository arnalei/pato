using ICES_ClassLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using Dapper;
namespace ICES_CSG.Pages
{
    [BindProperties]
    public class ICESAddLawsModel : PageModel
    {
        public int ICES { get; set; }
        public int ICES2 { get; set; }
        public string ICESLegislationNo { get; set; }
        public string ICESBillPolicy { get; set; }
        public string ICESName { get; set; }
        public string ICESProposedby { get; set; }
        public string ICESStatus { get; set; }
        public string ICESLegislationNo2 { get; set; }
        public string ICESBillPolicy2 { get; set; }
        public string ICESName2 { get; set; }
        public string ICESProposedby2 { get; set; }
        public string ICESStatus2 { get; set; }
        public IEnumerable<ICES_Laws> laws { get; set; }
        private readonly ILogger<ICESAddLawsModel> _logger;
        private readonly IConfiguration _ICESconfig;

        public ICESAddLawsModel(ILogger<ICESAddLawsModel> logger, IConfiguration ICESconfig)
        {
            _logger = logger;
            _ICESconfig = ICESconfig;
            var _ICES = new SqlConnection(_ICESconfig.GetConnectionString("ICES"));
            laws = _ICES.Query<ICES_Laws>("[ICESLawDis]", commandType: CommandType.StoredProcedure);
            
        }

        public IActionResult OnPostICESAdd()
        {
            var _ICES = new SqlConnection(_ICESconfig.GetConnectionString("ICES"));
            _ICES.Query("[ICESLawAdd]", new
            {
                
                @ICESLegislationNo= ICESLegislationNo,
                @ICESBillPolicy =ICESBillPolicy,
                @ICESName=ICESName,
                @ICESProposedby=ICESProposedby,
                @ICESStatus=ICESStatus
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }
        public IActionResult OnPostICESDel()
        {
            var _ICES = new SqlConnection(_ICESconfig.GetConnectionString("ICES"));
            _ICES.Query("[ICESLawDel]", new
            {
                @ICES= ICES2
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }
        public IActionResult OnPostICESUpd()
        {
            var _ICES = new SqlConnection(_ICESconfig.GetConnectionString("ICES"));
            _ICES.Query("[ICESLawUpd]", new
            {
                @ICES = ICES,
                @ICESLegislationNo = ICESLegislationNo,
                @ICESBillPolicy =ICESBillPolicy,
                @ICESName=ICESName,
                @ICESProposedby=ICESProposedby,
                @ICESStatus=ICESStatus
            }, commandType: CommandType.StoredProcedure);
            return RedirectToPage();
        }
        public IActionResult OnPostICESSea()
        {
            var _ICES = new SqlConnection(_ICESconfig.GetConnectionString("ICES"));
            laws = _ICES.Query<ICES_Laws>("[ICESLawSea]", new
            {
                @ICESSearch= $"%{ICESLegislationNo}%"
            }, commandType: CommandType.StoredProcedure);
            return Page();
        }
        public IActionResult OnPostICESEdi()
        {
            ICES = ICES2;
            ICESLegislationNo = ICESLegislationNo2;
            ICESBillPolicy=ICESBillPolicy2;
            ICESName=ICESName2;
            ICESProposedby=ICESProposedby2;
            ICESStatus = ICESStatus2;
            var _ICES = new SqlConnection(_ICESconfig.GetConnectionString("ICES"));
            laws = _ICES.Query<ICES_Laws>("[ICESLawDis]", commandType: CommandType.StoredProcedure);
            return Page();
        }

    }
}
