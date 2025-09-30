# POO_AsesoriasTI - Solución con persistencia JSON

Proyecto de consola .NET 8 para gestionar asesorías (CRUD) con persistencia en `asesorias.json`.

Ejecutar:
  dotnet build
  dotnet run --project src/POO_AsesoriasTI

Notas:
- Al iniciar, el repositorio carga `asesorias.json` si existe.
- Cada vez que crea/modifica/elimina una asesoría, se guarda el archivo automáticamente.
