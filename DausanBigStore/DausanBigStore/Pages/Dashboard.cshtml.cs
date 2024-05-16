#nullable disable

using Dapper;
using DausanCoreLib.Models;
using DausanCoreLib.Stores;
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
            var d = new SqlConnection(_config.GetConnectionString("db"));
            ProductList = d.Query<BigStoreModel>("Select [ProductCode] as ProductCode, [ProductName] as ProductName, [ProductPrice] as ProductPrice from [DBO].[Product]");
        }
        public IActionResult OnGet()
        {
            Title = string.Empty;
            Product = new();
            return Page();
        }
        public IActionResult OnPostAdd()
        {
            if (ModelState.IsValid)
            {
                var d = new SqlConnection(_config.GetConnectionString("db"));
                var sqlString = "INSERT INTO [dbo].[Product] VALUES(@ProductCode ,@ProductName ,@ProductPrice);";
                var parameters = new DynamicParameters();
                parameters.Add("@ProductCode", Product.ProductCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@ProductName", Product.ProductName, DbType.String, ParameterDirection.Input);
                parameters.Add("@ProductPrice", Product.ProductPrice, DbType.String, ParameterDirection.Input);

                d.Execute(sqlString, parameters);

                ProductList = d.Query<BigStoreModel>("Select [ProductCode] as ProductCode, [ProductName] as ProductName, [ProductPrice] as ProductPrice from [DBO].[Product]");
            }
            return Page();
        }

        public IActionResult OnGetEdit(string code = null)
        {

            if (string.IsNullOrEmpty(code))
            {
                Title = string.Empty;
                Product = new();
            }
            else
            {
                using var d = new SqlConnection(_config.GetConnectionString("db"));
                var sqlString = "Select [ProductCode] as ProductCode, [ProductName] as ProductName, [ProductPrice] as ProductPrice from [dbo].[Product] where [ProductCode] = @ProductCode";
                var parameters = new DynamicParameters();

                parameters.Add("@ProductCode", code, DbType.String, ParameterDirection.Input);

                var result = d.Query<BigStoreModel>(sqlString, parameters);
                Product = result.FirstOrDefault();
            }
            return Page();
        }
        public IActionResult OnGetDelete(string code = null)
        {


            Product = new();

            if (string.IsNullOrEmpty(code))
            {
            }
            else
            {
                //_store.DeleteStudent(id
                using var d = new SqlConnection(_config.GetConnectionString("db"));
                var sqlString = "DELETE FROM [dbo].[Product] WHERE [ProductCode] = @ProductCode;";
                var parameters = new DynamicParameters();
                parameters.Add("@ProductCode", code, DbType.String, ParameterDirection.Input);

                d.Execute(sqlString, parameters);

                ProductList = d.Query<BigStoreModel>("SELECT [a].[ProductCode] AS ProductCode ,[a].[ProductName] AS ProductName, [a].[ProductPrice] as ProductPrice FROM [dbo].[Product] AS a WHERE [a].[ProductCode] = @ProductCode");
            }

            return RedirectToPage();
        }
        public IActionResult OnPostUpdate()
        {
            if (ModelState.IsValid)
            {
                var d = new SqlConnection(_config.GetConnectionString("db"));
                var sqlString = "Update [dbo].[Product] set [ProductName] = @ProductName, [ProductPrice] = @ProductPrice Where [ProductCode] = @ProductCode";
                var parameters = new DynamicParameters();
                parameters.Add("@ProductCode", Product.ProductCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@ProductName", Product.ProductName, DbType.String, ParameterDirection.Input);
                parameters.Add("@ProductPrice", Product.ProductPrice, DbType.String, ParameterDirection.Input);

                d.Execute(sqlString, parameters);

                ProductList = d.Query<BigStoreModel>("Select [ProductCode] as ProductCode, [ProductName] as ProductName, [ProductPrice] as ProductPrice from [DBO].[Product]");

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
