using System.Collections.Generic;
using System.Web.Mvc;
using TrialAndErrorMVC.Models;

namespace TrialAndErrorMVC.Controllers
{
    public class ProductController : Controller
    {
        Repo repo = new Repo();
        
        [HttpGet]
        public ActionResult GetAll(List<Product> list)
        {
            list = repo.GetAll();
            return View(list);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product newProduct)
        {
            return View(newProduct);
        }

        public ActionResult Edit(int productId, string descriptionP, decimal priceP)
        {
            repo.EditProduct(productId, descriptionP, priceP);
            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var id = product.ProductId;
            var descript = product.ProductDescription;
            var price = product.Price;


            return RedirectToAction("GetAll");
        }

        //public ActionResult Delete(int ID)
        //{
        //    Product product = repo.FindProductById(ID);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int ID)
        //{
        //    Product product = repo.FindProductById(ID);
        //    repo.listOfProducts.Remove(product);
            
        //    return RedirectToAction("GetAll");
        //}
    }
}


//[HttpGet]
//public ActionResult GetAll()
//{
//    var productList = new List<Product>
//            {
//                new Product { ProductId = 1, ProductDescription = "Bjørn", Price = 100, IsInStore = true },
//                new Product { ProductId = 2, ProductDescription = "Hest", Price = 10330, IsInStore = true },
//                new Product { ProductId = 3, ProductDescription = "Bil", Price = 10220, IsInStore = false },
//                new Product { ProductId = 4, ProductDescription = "Bi", Price = 122300, IsInStore = true }
//            };

//    return View(productList);
//}

//public ActionResult Create(int productID, string descriptionP, decimal priceP, bool isItInStore)
//{
//    return View();
//}

//[HttpPost]
//public ActionResult Create(Product newProduct)
//{


//    if (ModelState.IsValid)
//    {
//        return RedirectToAction("Index");
//    }
//    else
//    {
//        return View(newProduct);
//    }
//}