using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Features.OwnedInstances;

namespace OwnedScopes
{
    public class ChangeNameCommandHandlerSameScopeAsRoot
    {
        ProductContext _context;

        public ChangeNameCommandHandlerSameScopeAsRoot(ProductContext context)
        {
            _context = context;
        }

        public void Execute(ChangeNameCommand cmd)
        {
                var product = _context.Products.Single(x => x.Id == cmd.ProductId);

                product.Name = cmd.Name;

                _context.SaveChanges();

        }
    }
}
