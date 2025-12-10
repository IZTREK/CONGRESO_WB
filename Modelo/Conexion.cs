using System;
using Oracle.ManagedDataAccess.Client;

namespace Modelo
{
    public static class Conexion
    {
        // Definimos nuestra cadena de conexión.
        // Apuntamos directamente al contenedor Docker (localhost:1521) y al servicio 'FREEPDB1'
        // que configuramos en el archivo docker-compose.
        private static string connectionString = "User Id=congreso_user;Password=congreso_pass;Data Source=localhost:1521/FREEPDB1;";

        public static OracleConnection GetConnection()
        {
            try
            {
                // Creamos la instancia de la conexión usando nuestra cadena configurada.
                OracleConnection conexion = new OracleConnection(connectionString);

                // Abrimos la conexión. Si el Docker no está corriendo, aquí es donde tronará
                // y nos mandará al catch.
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                // Si algo falla (como que el contenedor esté apagado), lanzamos un error claro
                // para no perder tiempo adivinando qué pasó.
                throw new Exception("Error conectando a Oracle: " + ex.Message);
            }
        }
    }
}