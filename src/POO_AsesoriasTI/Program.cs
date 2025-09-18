using System;
using POO_AsesoriasTI.Models;
using POO_AsesoriasTI.Repositories;

namespace POO_AsesoriasTI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new RepositorioAsesorias();
            string opcion;

            do
            {
                Console.WriteLine("\n===== MENÚ PRINCIPAL =====");
                Console.WriteLine("1) Crear asesoría");
                Console.WriteLine("2) Listar asesorías");
                Console.WriteLine("3) Modificar asesoría");
                Console.WriteLine("4) Eliminar asesoría");
                Console.WriteLine("0) Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        Crear(repo);
                        break;
                    case "2":
                        Listar(repo);
                        break;
                    case "3":
                        Modificar(repo);
                        break;
                    case "4":
                        Eliminar(repo);
                        break;
                    case "0":
                        Console.WriteLine("👋 Saliendo...");
                        break;
                    default:
                        Console.WriteLine("⚠️ Opción inválida.");
                        break;
                }
            } while (opcion != "0");
        }

        // --- Métodos estáticos a nivel de clase (no son funciones locales) ---
        static void Crear(RepositorioAsesorias repo)
        {
            try
            {
                Console.Write("Id (entero): ");
                if (!int.TryParse(Console.ReadLine(), out var id))
                {
                    Console.WriteLine("Id inválido.");
                    return;
                }

                Console.Write("Nombre de la asesoría: ");
                var nombre = Console.ReadLine() ?? "";

                Console.Write("Nombre del asesor: ");
                var asesor = Console.ReadLine() ?? "";

                Console.Write("Fecha (yyyy-MM-dd HH:mm): ");
                if (!DateTime.TryParse(Console.ReadLine(), out var fecha))
                {
                    Console.WriteLine("Fecha inválida.");
                    return;
                }

                Console.Write("Valor (decimal): ");
                if (!decimal.TryParse(Console.ReadLine(), out var valor))
                {
                    Console.WriteLine("Valor inválido.");
                    return;
                }

                var a = new Asesoria(id, nombre, asesor, fecha, valor);
                repo.Crear(a); // usa el método público del repo (validaciones incluidas)
                Console.WriteLine("✅ Asesoría creada correctamente.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"⚠️ {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }

        static void Listar(RepositorioAsesorias repo)
        {
            var list = repo.Listar();
            if (list.Count == 0)
            {
                Console.WriteLine("No hay asesorías registradas.");
                return;
            }

            Console.WriteLine("\n--- LISTADO DE ASESORÍAS ---");
            foreach (var a in list)
                Console.WriteLine(a.ToDisplayString());
        }

        static void Modificar(RepositorioAsesorias repo)
        {
            try
            {
                Console.Write("Id de la asesoría a modificar: ");
                if (!int.TryParse(Console.ReadLine(), out var id)) { Console.WriteLine("Id inválido."); return; }

                var ex = repo.ObtenerPorId(id);
                if (ex == null) { Console.WriteLine("No encontrada."); return; }

                Console.Write($"Nuevo nombre (enter para mantener: {ex.NombreAsesoria}): ");
                var nNombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nNombre)) ex.SetNombreAsesoria(nNombre);

                Console.Write($"Nuevo asesor (enter para mantener: {ex.NombreAsesor}): ");
                var nAsesor = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nAsesor)) ex.SetNombreAsesor(nAsesor);

                Console.Write($"Nueva fecha (yyyy-MM-dd HH:mm) (enter para mantener: {ex.Fecha:yyyy-MM-dd HH:mm}): ");
                var nFecha = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nFecha) && DateTime.TryParse(nFecha, out var fecha)) ex.SetFecha(fecha);

                Console.Write($"Nuevo valor (enter para mantener: {ex.Valor}): ");
                var nValor = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nValor) && decimal.TryParse(nValor, out var valor)) ex.SetValor(valor);

                // Actualiza mediante la API del repositorio (valida conflictos horario)
                repo.Actualizar(ex);
                Console.WriteLine("✅ Asesoría modificada correctamente.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"⚠️ {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }

        static void Eliminar(RepositorioAsesorias repo)
        {
            Console.Write("Id a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) { Console.WriteLine("Id inválido."); return; }
            if (repo.Eliminar(id))
                Console.WriteLine("✅ Asesoría eliminada.");
            else
                Console.WriteLine("⚠️ No se encontró la asesoría.");
        }
    }
}
