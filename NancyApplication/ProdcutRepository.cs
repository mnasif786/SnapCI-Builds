using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;


namespace NancyApplication
{
    public class ProdcutRepository
    {

        private DataClasses1DataContext _nancyDb   = new DataClasses1DataContext();

        public List<Product> Products = new List<Product>();
        public void Save(Product product)
        {
            _nancyDb.tbl_Products.InsertOnSubmit(new tbl_Product() { Id = product.Id, Title = product.Title, Price = (decimal)product.Price} );
            _nancyDb.SubmitChanges();
        }

        public List<Product> GetAll()
        {
            var products = new List<Product>();

            _nancyDb.tbl_Products.ToList().ForEach(
                x => products.Add(new Product {Id = x.Id, Title = x.Title, Price = (double) x.Price}));

            return products;
        }

        public Product Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}