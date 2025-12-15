using System;
using System.Data;
using CongresoModelo;
using Modelo;

namespace CONGRESO_WB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            pnlEstadisticas.Visible = false; // Ocultamos el panel por defecto

            string email = txtEmail.Text.Trim();
            string matricula = txtMatricula.Text.Trim();

            // Validamos que ambos campos tengan datos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matricula))
            {
                lblMensaje.Text = "⚠️ Por favor ingresa tu Correo Y tu Matrícula.";
                return;
            }

            try
            {
                ConsultasDAO dao = new ConsultasDAO();
                // Ahora enviamos los dos parámetros
                DataTable resultados = dao.ObtenerProgresoAlumno(email, matricula);

                if (resultados.Rows.Count > 0)
                {
                    gvAsistencias.DataSource = resultados;
                    gvAsistencias.DataBind();

                    // --- CALCULAMOS LAS MÉTRICAS PARA EL DASHBOARD ---
                    CalcularEstadisticas(resultados);
                }
                else
                {
                    gvAsistencias.DataSource = null;
                    gvAsistencias.DataBind();
                    lblMensaje.Text = "No encontramos datos. Verifica que el correo y la matrícula coincidan.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error en el sistema: " + ex.Message;
            }
        }

        // Método auxiliar para hacer las cuentas del Dashboard
        private void CalcularEstadisticas(DataTable dt)
        {
            int totalInscritos = dt.Rows.Count;
            int totalAsistidos = 0;

            // Recorremos la tabla para contar cuántos tienen asistencia > 0
            foreach (DataRow fila in dt.Rows)
            {
                int asistencias = Convert.ToInt32(fila["TotalAsistencias"]);
                if (asistencias > 0)
                {
                    totalAsistidos++;
                }
            }

            // Calculamos porcentaje (evitando división entre cero)
            double porcentaje = totalInscritos > 0 ? ((double)totalAsistidos / totalInscritos) * 100 : 0;

            // Llenamos las etiquetas del Frontend
            lblTotalInscritos.Text = totalInscritos.ToString();
            lblTotalAsistidos.Text = totalAsistidos.ToString();
            lblPorcentaje.Text = Math.Round(porcentaje, 1).ToString(); // Redondeamos a 1 decimal

            // Mostramos el panel
            pnlEstadisticas.Visible = true;
        }
    }
}