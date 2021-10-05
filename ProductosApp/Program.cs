using AppCore.Interfaces;
using AppCore.Services;
using Autofac;
using Domain.Interfaces;
using Infraestructure.Empleados;
using ProductosApp.Formularios;
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

            var container = builder.Build();

            App.EnableVisualStyles();
            App.SetCompatibleTextRenderingDefault(false);
            App.Run(new FrmMain(container.Resolve<IEmpleadoServices>()));
        }
    }
}
