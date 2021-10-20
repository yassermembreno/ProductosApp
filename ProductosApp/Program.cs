using AppCore.Interfaces;
using AppCore.Processes;
using AppCore.Services;
using Autofac;
using Domain.Interfaces;
using Infraestructure.Empleados;
using Infraestructure.Inventories;
using ProductosApp.Demos;
using ProductosApp.Formularios;
using ProductosApp.Formularios.Inventories;
using System;
using App = System.Windows.Forms.Application;
namespace ProductosApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EmpleadoModel>().As<IEmpleadoModel>();
            builder.RegisterType<EmpleadoServices>().As<IEmpleadoServices>();

            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductService>().As<IProductService>();

            builder.RegisterType<ItemRepository>().As<IItemRepository>();
            builder.RegisterType<ItemService>().As<IItemService>();

            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderService>().As<IOrderService>();

            builder.RegisterType<OrderItemRepository>().As<IOrderItemRepository>();
            builder.RegisterType<OrderItemService>().As<IOrderItemService>();

            builder.RegisterType<PEPSInventoryCalculator>().As<IInventoryCalculator>();
            var container = builder.Build();

            App.EnableVisualStyles();
            App.SetCompatibleTextRenderingDefault(false);
            App.Run(new FrmInventoryManagement(container.Resolve<IProductService>(), container.Resolve<IOrderService>(),
                                               container.Resolve<IOrderItemService>(), container.Resolve<IItemService>(),
                                                container.Resolve<IInventoryCalculator>()));

            //App.Run(new FrmDemos());
        }
    }
}
