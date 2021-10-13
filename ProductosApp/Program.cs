using AppCore.Interfaces;
using AppCore.Services;
using Autofac;
using Domain.Interfaces;
using Infraestructure.Empleados;
using Infraestructure.Productos;
using ProductosApp.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            builder.RegisterType<EmpleadoService>().As<IEmpleadoService>();
            builder.RegisterType<ProductoListModel>().As<IProductoModel>();
            builder.RegisterType<ProductoService>().As<IProductoService>();
            var container = builder.Build();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmGestionEmpleados(container.Resolve<IEmpleadoService>()));
        }
    }
}
