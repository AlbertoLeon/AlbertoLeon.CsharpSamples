using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Features.OwnedInstances;

namespace OwnedScopes
{
    public class ChangeNameCommandHandlerOwnedScope
    {
        Func<Owned<ProductContext>> _contextFactory;

        public ChangeNameCommandHandlerOwnedScope(Func<Owned<ProductContext>> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Execute(ChangeNameCommand cmd)
        {
            using (var contextFactoryInstance = _contextFactory())
            {
                var ctx = contextFactoryInstance.Value;

                var product = ctx.Products.Single(x => x.Id == cmd.ProductId);

                product.Name = cmd.Name;

                ctx.SaveChanges();
            }
        }
    }
}
