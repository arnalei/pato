#nullable disable

using DausanCoreLib.Models;


namespace DausanCoreLib.Stores
{
    public interface IStore
    {
        IEnumerable<IBigStoreModel> ProductList { get; set; }
        IBigStoreModel FindBigStoreByName(string name);
        IBigStoreModel FindBigStoreByCode(string code);
        void FindBigStoreByKeyword(string keyword);
        void Delete(string code);
        void CreateBigStore(IBigStoreModel product);
        void UpdateBigStore(IBigStoreModel product);
        void DisplayBigStore(IBigStoreModel product);
    }
    public class Store : IStore
    {
        private IEnumerable<IBigStoreModel> _productlist;
        private IEnumerable<IBigStoreModel> _productdata;
        public Store()
        {
            _productdata = new List<BigStoreModel>()
            {
                new BigStoreModel() {ProductName = "Shoes", ProductPrice = "200"},
                new BigStoreModel() {ProductName = "dress", ProductPrice = "150"},
                new BigStoreModel() {ProductName = "sandals", ProductPrice = "150"},
                new BigStoreModel() {ProductName = "Shorts", ProductPrice = "70"},
                new BigStoreModel() {ProductName = "slippers", ProductPrice = "150"},
                new BigStoreModel() {ProductName = "Necklace", ProductPrice = "170"},
                new BigStoreModel() {ProductName = "bracelet", ProductPrice = "50"},
                new BigStoreModel() {ProductName = "shoelace", ProductPrice = "30"},
                new BigStoreModel() {ProductName = "hairtie", ProductPrice = "15"},
                new BigStoreModel() {ProductName = "earings", ProductPrice = "30"}
            };
            _productlist = _productdata.ToList();
        }
        public IEnumerable<IBigStoreModel> ProductList { get => _productlist; set => _productlist = value; }

        public void CreateBigStore(IBigStoreModel product)
        {
            _productlist = _productdata.Append(product).ToList();
        }

        public void Delete(string code)
        {
            _productdata = _productdata.Where(b => b.ProductCode != code).ToList();
            _productlist = _productdata;
        }

        public void DisplayBigStore(IBigStoreModel product)
        {
            _productlist = _productdata;
        }

        public IBigStoreModel FindBigStoreByCode(string code)
        {
            return _productdata.Where(b => b.ProductCode == code).FirstOrDefault();
        }

        public void FindBigStoreByKeyword(string keyword)
        {
            _productlist = _productdata.Where(s => s.ProductName.StartsWith(keyword, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public IBigStoreModel FindBigStoreByName(string name)
        {
            return _productdata.Where(b => b.ProductName == name).FirstOrDefault();
        }

        public void UpdateBigStore(IBigStoreModel product)
        {
            var item = _productdata.Where(s => s.ProductCode == product.ProductCode).FirstOrDefault();
            _productdata = _productdata.Where(s => s.ProductCode != product.ProductCode).ToList();
            _productdata = _productdata.Append(product).ToList();

            _productlist = _productdata;
        }
    }
}