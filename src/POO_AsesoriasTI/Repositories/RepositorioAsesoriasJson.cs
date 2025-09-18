using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using POO_AsesoriasTI.Models;

namespace POO_AsesoriasTI.Repositories
{
    public class RepositorioAsesoriasJson
    {
        private readonly string _path;
        public RepositorioAsesoriasJson(string path) { _path = path; }

        public void ImportarDesde(IEnumerable<Asesoria> list)
        {
            var dto = new List<object>();
            foreach (var a in list)
            {
                dto.Add(new {
                    a.Id,
                    NombreAsesoria = a.NombreAsesoria,
                    NombreAsesor = a.NombreAsesor,
                    Fecha = a.Fecha,
                    Valor = a.Valor
                });
            }
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(dto, options);
            File.WriteAllText(_path, json);
        }
    }
}
