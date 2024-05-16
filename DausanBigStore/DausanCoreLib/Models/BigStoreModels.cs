#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DausanCoreLib.Models
{
    public interface IBigStoreModel
    {
        string ProductName { get; set; }
        string ProductCode { get; set; }
        string ProductPrice { get; set; }
    }
    public class BigStoreModel : IBigStoreModel
    {
        private string productname;
        private string productcode;
        private string productprice;

        public BigStoreModel()
        {
            ProductCode = Guid.NewGuid().ToString();
        }
        public string ProductName { get => productname; set => productname = value; }
        public string ProductCode { get => productcode; set => productcode = value; }
        public string ProductPrice { get => productprice; set => productprice = value; }
    }
}
