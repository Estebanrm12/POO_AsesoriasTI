using System;
using Xunit;
using POO_AsesoriasTI.Models;
using POO_AsesoriasTI.Repositories;

namespace POO_AsesoriasTI.Tests
{
    public class RepositorioTests
    {
        [Fact]
        public void CrearYListar_DeberiaAgregar()
        {
            var repo = new RepositorioAsesorias();
            var a = new Asesoria(1, "Prueba", "Juan", DateTime.Now, 100);
            repo.Crear(a);
            var all = repo.Listar();
            Assert.Single(all);
        }

        [Fact]
        public void Actualizar_DeberiaModificarCampos()
        {
            var repo = new RepositorioAsesorias();
            var a = new Asesoria(2, "A", "Juan", DateTime.Now, 50);
            repo.Crear(a);
            var mod = new Asesoria(2, "B", "Carlos", DateTime.Now.AddDays(1), 80);
            repo.Actualizar(mod);
            var got = repo.ObtenerPorId(2);
            Assert.Equal("B", got!.NombreAsesoria);
            Assert.Equal("Carlos", got.NombreAsesor);
        }

        [Fact]
        public void Eliminar_DeberiaQuitar()
        {
            var repo = new RepositorioAsesorias();
            repo.Crear(new Asesoria(3, "X", "Y", DateTime.Now, 10));
            repo.Eliminar(3);
            Assert.Null(repo.ObtenerPorId(3));
        }
    }
}
