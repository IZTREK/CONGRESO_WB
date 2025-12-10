using Modelo;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace CongresoModelo
{
    public class ConsultasDAO
    {
        // Actualizamos el método para pedir también la matrícula.
        // Esto evita que un alumno "espíe" a otro solo sabiendo su correo.
        public DataTable ObtenerProgresoAlumno(string email, string matricula)
        {
            DataTable dt = new DataTable();

            using (OracleConnection conn = Conexion.GetConnection())
            {
                // Agregamos la condición "AND u.matricula = :matricula" a la query.
                string query = @"
                    SELECT 
                        e.nombre_evento AS Evento, 
                        e.lugar AS Lugar,
                        (SELECT COUNT(*) FROM asistencias a 
                         WHERE a.id_usuario = u.id_usuario 
                         AND a.id_evento = e.id_evento) AS TotalAsistencias,
                        e.cupo_actual
                    FROM inscripciones i
                    INNER JOIN usuarios u ON i.id_usuario = u.id_usuario
                    INNER JOIN eventos e ON i.id_evento = e.id_evento
                    WHERE u.email = :email 
                    AND u.matricula = :matricula";

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    // Definimos los parámetros explícitamente para evitar inyección SQL.
                    cmd.Parameters.Add(new OracleParameter("email", OracleDbType.Varchar2)).Value = email;
                    cmd.Parameters.Add(new OracleParameter("matricula", OracleDbType.Varchar2)).Value = matricula;

                    try
                    {
                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (OracleException ex)
                    {
                        if (ex.Number == 942)
                        {
                            throw new Exception("Error: Tablas no encontradas en la BD.");
                        }
                        throw ex;
                    }
                }
            }
            return dt;
        }
    }
}