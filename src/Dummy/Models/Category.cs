using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Dummy.Models
{
    public class Category
    {
        private readonly List<Product> _products = new List<Product>();
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public ReadOnlyCollection<Product> Products => _products.AsReadOnly();

		public void AddProduct(Product product) => _products.Add(product);
		

    }
}