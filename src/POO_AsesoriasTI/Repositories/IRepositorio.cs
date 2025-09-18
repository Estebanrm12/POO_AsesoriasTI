using System.Collections.Generic;

namespace POO_AsesoriasTI.Repositories
{
    public interface IRepositorio<T>
    {
        void Crear(T item);
        List<T> Listar();
        T? ObtenerPorId(int id);
        void Actualizar(T item);
        void Eliminar(int id);
    }
}
