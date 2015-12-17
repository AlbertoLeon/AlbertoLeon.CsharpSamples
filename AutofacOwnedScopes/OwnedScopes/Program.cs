using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace OwnedScopes
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ProductContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ProductsService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ChangeNameCommandHandlerOwnedScope>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ChangeNameCommandHandlerSameScopeAsRoot>().AsSelf().InstancePerLifetimeScope();

            var container = builder.Build();

            var service = container.Resolve<ProductsService>();

            var ctx= container.Resolve<ProductContext>();

            service.CreateProduct("Water");

            var products = ctx.Products.ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product);
                Console.WriteLine();
            }

            var cmdHdlr = container.Resolve<ChangeNameCommandHandlerOwnedScope>();

            var cmd = new ChangeNameCommand
            {
                ProductId = 1,
                Name = "Fire"
            };

            cmdHdlr.Execute(cmd);

            foreach (var product in products)
            {
                Console.WriteLine(product);
                Console.WriteLine();
            }

            var cmdHdlrWithSameScopeAsRoot = container.Resolve<ChangeNameCommandHandlerSameScopeAsRoot>();

            var cmd2 = new ChangeNameCommand
            {
                ProductId = 1,
                Name = "Air"
            };


            cmdHdlrWithSameScopeAsRoot.Execute(cmd2);

            foreach (var product in products)
            {
                Console.WriteLine(product);
                Console.WriteLine();
            }

        }
    }
}
