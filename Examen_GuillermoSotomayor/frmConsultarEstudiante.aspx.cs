using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_GuillermoSotomayor
{
    public partial class frmConsultarEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblError.Visible = false;
                    lblError.Text = string.Empty;
                }
            }
            catch(Exception ex)
            {
                lblError.Text = "Error al cargar la página";
            }
            
        }

        protected void btConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Valida())
                {
                    return;
                }
                ConsultaEstudiante();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Ocurrió un error inesperado: " + ex.Message;
            }
        }

        private void ConsultaEstudiante()
        {
            var idEstudiante = long.Parse(tx_codigo.Text);
            var objEstudiante = new GuillermoSotomayor.BLL.Logica().ConsultarEstudiante(idEstudiante);

            if(objEstudiante.Id == 0)
            {
                lblError.Visible = true;
                lblError.Text = "No existe el estudiante";
                return;
            }

            tx_Nombre.Text = objEstudiante.Nombre;
            tx_Nota1.Text = objEstudiante.Nota1.ToString();
            tx_Nota2.Text = objEstudiante.Nota2.ToString();
            tx_NotaProyecto.Text = objEstudiante.NotaProyecto.ToString();
            tx_Condicion.Text = objEstudiante.Condicion.ToString();
        }

        private bool Valida()
        {
            if (tx_codigo.Text.Equals(string.Empty))
            {
                lblError.Visible = true;
                lblError.Text = "Debe digitar un código para consultar";
                return false;
            }
            return true;
        }
    }
}