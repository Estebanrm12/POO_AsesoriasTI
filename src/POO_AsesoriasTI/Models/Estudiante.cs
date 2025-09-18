namespace POO_AsesoriasTI.Models
{
    public sealed class Estudiante : Usuario
    {
        public string Carrera { get; private set; }

        public Estudiante(int id, string nombre, string correo, string carrera)
            : base(id, nombre, correo)
        {
            Carrera = carrera;
        }

        public void SetCarrera(string carrera)
        {
            if (string.IsNullOrWhiteSpace(carrera)) throw new ArgumentException("Carrera inválida");
            Carrera = carrera;
        }
    }
}
