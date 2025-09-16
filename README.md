# Prueba Técnica Dev - Desarrollo de un Requerimiento
## Descripción
Aplicación desarrollada en Angular 19 y .NET 8 que cumple con los siguientes requerimientos:
1.  Frontend en Angular que muestra una tabla de clientes con el teléfono formateado.
2.  Backend en .NET con dos endpoints paginados: uno usando Stored Procedure y otro usando Entity Framework Core Linq.
3.  Prueba unitaria para el pipe de formato de teléfono.

## Instrucciones de Configuración

### 1. Base de Datos
- Ejecuta el script SQL `PruebaTecnicaDB.sql` en tu SQL Server LocalDB.
- El script crea la base de datos, tablas y el Stored Procedure necesario.

### 2. Backend (.NET API)
- Abre la solución `PruebaTecnica.Solution.sln` en Visual Studio 2022.
- Asegúrate de que la cadena de conexión en `appsettings.json` apunte a tu LocalDB:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=PruebaTecnicaDB;Trusted_Connection=true;TrustServerCertificate=true;"
  }
 
Ejecuta el proyecto PruebaTecnica.Api (F5). La API estará disponible en https://localhost:7203.

###  3. Frontend (Angular)
- Abre una terminal en la carpeta prueba-tecnica-ui.
- Ejecuta npm install para instalar dependencias.
- Ejecuta ng serve para iniciar la aplicación.
- Abre http://localhost:4200 en tu navegador.

#### 3.1. Configuración Pruebas Unitarias
 Para ejecutar las pruebas del pipe de teléfono, en la carpeta prueba-tecnica-ui ejecuta:
 - ng test