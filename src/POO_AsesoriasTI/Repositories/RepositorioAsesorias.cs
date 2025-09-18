using System;
using System.Collections.Generic;
using System.Linq;
using POO_AsesoriasTI.Models;

namespace POO_AsesoriasTI.Repositories
{
    public class RepositorioAsesorias
    {
        private readonly List<Asesoria> _asesorias = new();

        public void Crear(Asesoria asesoria)
        {
            if (_asesorias.Any(a => a.Id == asesoria.Id))
                throw new InvalidOperationException("Ya existe una asesoría con ese Id.");

            if (_asesorias.Any(a => a.Fecha == asesoria.Fecha))
                throw new InvalidOperationException("Ya existe una asesoría en esa fecha.");

            _asesorias.Add(asesoria);
        }

        public List<Asesoria> Listar() => new(_asesorias);

        public Asesoria? ObtenerPorId(int id) =>
            _asesorias.FirstOrDefault(a => a.Id == id);

        public void Actualizar(Asesoria asesoria)
        {
            var index = _asesorias.FindIndex(a => a.Id == asesoria.Id);
            if (index == -1)
                throw new InvalidOperationException("La asesoría no existe.");

            // Validar que no se cruce la fecha con otra asesoría
            if (_asesorias.Any(a => a.Id != asesoria.Id && a.Fecha == asesoria.Fecha))
                throw new InvalidOperationException("Ya existe otra asesoría en esa fecha.");

            _asesorias[index] = asesoria;
        }

        public bool Eliminar(int id)
        {
            var asesoria = ObtenerPorId(id);
            if (asesoria == null) return false;
            _asesorias.Remove(asesoria);
            return true;
        }
    }
}
