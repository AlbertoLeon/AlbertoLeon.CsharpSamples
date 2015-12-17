using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnedScopes
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public virtual DbSet<Product> Products { get; set; }
    }
}
