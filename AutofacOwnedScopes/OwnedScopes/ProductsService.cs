using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnedScopes
{
    public class ProductsService
    {
        private readonly ProductContext _context;

        public ProductsService(ProductContext context)
        {
            _context = context;
        }

        public void CreateProduct(string name)
        {
            Product product = new Product
            {
                Name = name
            };

            _context.Products.Add(product);

            _context.SaveChanges();
        }

        public void ChangeName(int id, string currentName)
        {
            var product = _context.Products.Single(x => x.Id == id);
            product.Name = currentName;

            _context.SaveChanges();
        }
    }
}
