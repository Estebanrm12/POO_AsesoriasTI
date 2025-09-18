namespace POO_AsesoriasTI.Models
{
    public sealed class Asesor : Usuario
    {
        public string Especialidad { get; private set; }

        public Asesor(int id, string nombre, string correo, string especialidad)
            : base(id, nombre, correo)
        {
            Especialidad = especialidad;
        }

        public void SetEspecialidad(string esp)
        {
            if (string.IsNullOrWhiteSpace(esp)) throw new ArgumentException("Especialidad inválida");
            Especialidad = esp;
        }
    }
}
