using Domain.Entities.Empleados;

namespace AppCore.Interfaces
{
    public interface IEmpleadoServices
    {
        void Create(Empleado e);
        int Update(Empleado e);
        bool Delete(Empleado e);
        Empleado FindById(int id);
        Empleado[] FindAll();        
    }
}
