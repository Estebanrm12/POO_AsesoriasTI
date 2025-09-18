using System;

namespace POO_AsesoriasTI.Models
{
    public class Asesoria
    {
        public int Id { get; }
        public string NombreAsesoria { get; private set; }
        public string NombreAsesor { get; private set; }
        public DateTime Fecha { get; private set; }
        public decimal Valor { get; private set; }

        public Asesoria(int id, string nombreAsesoria, string nombreAsesor, DateTime fecha, decimal valor)
        {
            Id = id;
            SetNombreAsesoria(nombreAsesoria);
            SetNombreAsesor(nombreAsesor);
            SetFecha(fecha);
            SetValor(valor);
        }

        // Métodos setters con validación
        public void SetNombreAsesoria(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la asesoría no puede estar vacío.");
            NombreAsesoria = nombre;
        }

        public void SetNombreAsesor(string asesor)
        {
            if (string.IsNullOrWhiteSpace(asesor))
                throw new ArgumentException("El nombre del asesor no puede estar vacío.");
            NombreAsesor = asesor;
        }

        public void SetFecha(DateTime fecha)
        {
            if (fecha < DateTime.Now)
                throw new ArgumentException("La fecha no puede ser en el pasado.");
            Fecha = fecha;
        }

        public void SetValor(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("El valor debe ser positivo.");
            Valor = valor;
        }

        public string ToDisplayString()
        {
            return $"[{Id}] {NombreAsesoria} - {NombreAsesor} - {Fecha:yyyy-MM-dd HH:mm} - ${Valor}";
        }
    }
}
