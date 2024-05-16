#nullable disable

using Dapper;
using DausanCoreLib.Models;
using DausanCoreLib.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;


namespace DausanBigStore.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;
        private readonly IStore _store;
        private IBigStoreModel _product;
        private readonly IConfiguration _config;

        public string Title { get; set; }

        [BindProperty]
        public BigStoreModel Product { get; set; }

        [BindProperty]
        public SearchModel Search { get; set; }
        public IEnumerable<IBigStoreModel> ProductList; //=> _store.ProductList;

        public DashboardModel(ILogger<DashboardModel> logger, IStore store, IBigStoreModel product, IConfiguration config)
        {
            Title = "Welcome! " + DateTime.Now.ToString();
            _logger = logger;
            _store = store;
            _product = product;
            _config = config;
            var d = new SqlConnection(_config.GetConnectionString("DUA"));
            ProductList = d.Query<BigStoreModel>("displayProduct");
        }
        public IActionResult OnGet()
        {
            Title = string.Empty;
            Product = new();
            return Page();
        }
        public IActionResult OnPostAddProduct()
        {
            if (ModelState.IsValid)
            {
                var d = new SqlConnection(_config.GetConnectionString("DUA"));
                var sqlString = "createProduct";
                var parameters = new DynamicParameters();
                parameters.Add("@ProductCode", Product.ProductCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@ProductName", Product.ProductName, DbType.String, ParameterDirection.Input);
                parameters.Add("@ProductPrice", Product.ProductPrice, DbType.String, ParameterDirection.Input);

                d.Execute(sqlString, parameters);

                ProductList = d.Query<BigStoreModel>("displayProduct");
            }
            return Page();
        }

        public IActionResult OnGetEditProduct(string code)
        {

            if (string.IsNullOrEmpty(code))
            {
                Title = string.Empty;
                Product = new();
            }
            else
            {
                using var d = new SqlConnection(_config.GetConnectionString("DUA"));
                var sqlString = "findProductById";
                var parameters = new DynamicParameters();
                parameters.Add("@ProductCode", code, DbType.String, ParameterDirection.Input);
                var result = d.Query<BigStoreModel>(sqlString, parameters);
                Product = result.FirstOrDefault();
            }
            return Page();
        }
        public IActionResult OnGetDeleteProduct(string code)
        {


            Product = new();

            if (string.IsNullOrEmpty(code))
            {
            }
            else
            {
                //_store.DeleteStudent(id
                using var d = new SqlConnection(_config.GetConnectionString("DUA"));
                var sqlString = "delete";
                var parameters = new DynamicParameters();
                parameters.Add("@ProductCode", code, DbType.String, ParameterDirection.Input);

                d.Execute(sqlString, parameters);

                ProductList = d.Query<BigStoreModel>("displayProduct");
            }

            return RedirectToPage();
        }
        public IActionResult OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                var d = new SqlConnection(_config.GetConnectionString("DUA"));
                var sqlString = "update";
                var parameters = new DynamicParameters();
                parameters.Add("@ProductCode", Product.ProductCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@ProductName", Product.ProductName, DbType.String, ParameterDirection.Input);
                parameters.Add("@ProductPrice", Product.ProductPrice, DbType.String, ParameterDirection.Input);

                d.Execute(sqlString, parameters);

                ProductList = d.Query<BigStoreModel>("displayProduct");

            }
            return RedirectToPage();
        }
        public IActionResult OnPostSearchBigStore()
        {
            if (ModelState.IsValid)
            {
                _store.FindBigStoreByKeyword(Search.Keyword);
            }
            return RedirectToPage();
        }
        public IActionResult OnPostDisplayBigStore()
        {
            if (ModelState.IsValid)
            {
                Title = $"{Product.ProductName}  -  {Product.ProductCode}";

                _store.DisplayBigStore(Product);
            }
            return RedirectToPage();
        }


    }
}
