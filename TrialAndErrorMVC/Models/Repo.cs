using System.Collections.Generic;
using System.Linq;

namespace TrialAndErrorMVC.Models
{
    public class Repo
    {
        public List<Product> listOfProducts = new List<Product>();
        public object _lock = new object();

        Product A = new Product { ProductId = 1, ProductDescription = "Bjørn", Price = 223213, IsInStore = true };
        Product B = new Product { ProductId = 2, ProductDescription = "Hest", Price = 112312300, IsInStore = true };
        Product C = new Product { ProductId = 3, ProductDescription = "Bi", Price = 10123120, IsInStore = false };
        Product D = new Product { ProductId = 4, ProductDescription = "VBkl", Price = 1023120, IsInStore = true };
        Product E = new Product { ProductId = 5, ProductDescription = "Beheh", Price = 10213230, IsInStore = false };

        public void Add(Product product)
        {
            listOfProducts.Add(product);
        }

        public void PopulateList()
        {
            listOfProducts.Add(A);
            listOfProducts.Add(B);
            listOfProducts.Add(C);
            listOfProducts.Add(D);
            listOfProducts.Add(E);
        }

        public List<Product> GetAll()
        {
            PopulateList();
            return listOfProducts.ToList();
        }

        public Product FindProductById(int productId)
        {
            lock (_lock)
            {
                PopulateList();
                Product _product = new Product();
                _product = null;
                foreach (var nProduct in listOfProducts)
                {
                    if (nProduct.ProductId == productId)
                    {
                        _product = nProduct;
                    }
                }
                return _product;
            }
        }

        public void EditProduct(int _productId, string _description, decimal _price)
        {
            Product product = FindProductById(_productId);
            lock (_lock)
            {
                if (product != null)
                {
                    product.ProductId = _productId;
                    product.ProductDescription = _description;
                    product.Price = _price;
                }
            }

        }

    }
}


//public static List<Product> products = new List<Product>();

//public void AddProduct(Product product)
//{
//    products.Add(product);
//}

//public List<Product> GetProducts()
//{
//    List<Product> returnData = new List<Product>();
//    foreach (Product _product in products)
//    {
//        returnData.Add(_product);
//    }
//    return returnData;
//}

//public List<Product> GetProductById(int getId)
//{
//    List<Product> returnData = new List<Product>();

//    foreach (Product _prroducts in products)
//    {
//        if (_prroducts.ProductId == getId)
//        {
//            returnData.Add(_prroducts);
//        }
//    }

//    return returnData;
//}