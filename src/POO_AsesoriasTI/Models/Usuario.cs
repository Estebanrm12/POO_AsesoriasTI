namespace POO_AsesoriasTI.Models
{
    public abstract class Usuario
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Correo { get; private set; }

        protected Usuario(int id, string nombre, string correo)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Nombre requerido");
            Id = id;
            Nombre = nombre;
            Correo = correo;
        }

        public void SetNombre(string nuevo)
        {
            if (string.IsNullOrWhiteSpace(nuevo)) throw new ArgumentException("Nombre inválido");
            Nombre = nuevo;
        }
    }
}
