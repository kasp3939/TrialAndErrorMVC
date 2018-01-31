using System.ComponentModel.DataAnnotations;

namespace TrialAndErrorMVC.Models
{
    public class Product
    {
        [Display(Name ="Produkt ID")]
        public int ProductId { get; set; }
        [Display(Name ="Produkt Beskrivelse")]
        public string ProductDescription { get; set; }
        [Display(Name = "Pris")]
        public decimal Price { get; set; }
       
        

        public Product()
        { }

        public Product(int _productId, string _productDescription, decimal _price)
        {
            ProductId = _productId;
            ProductDescription = _productDescription;
            Price = _price;
            
        }
    }
}