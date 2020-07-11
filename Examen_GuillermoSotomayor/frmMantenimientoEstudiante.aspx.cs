using Examen_GuillermoSotomayor.Utlis;
using GuillermoSotomayor.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Examen_GuillermoSotomayor
{
    public partial class frmMantenimientoEstudiante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblError.Visible = false;
                    btConfirmar.Visible = false;
                    btCancelar.Visible = false;
                    btConsultar.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error al cargar a página";
            }
        }

        #region eventos
        protected void btAgregar_Click(object sender, EventArgs e)
        {
            accions.Text = "1";

            if (!Valida())
                return;
            Mantenimiento();
        }

        protected void btEditar_Click(object sender, EventArgs e)
        {
            AccionEditar();
        }
        protected void btEliminar_Click(object sender, EventArgs e)
        {
            AccionEliminar();
        }
        protected void btConfirmar_Click(object sender, EventArgs e)
        {
            if (!Valida())
                return;
            Mantenimiento();
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            AccionCancelar();
        }

        protected void btConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidaConsultar())
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

        #endregion

        #region metodos

        private void Mantenimiento()
        {
            int accion = Int32.Parse(accions.Text);
            try
            {
                switch (accion)
                {
                    case (int)Utilidades.Accion.Insertar:
                        var estudiante = new Estudiante
                        {
                            Nombre = tx_Nombre.Text,
                            Nota1 = decimal.Parse(tx_Nota1.Text),
                            Nota2 = decimal.Parse(tx_Nota2.Text),
                            NotaProyecto = decimal.Parse(tx_NotaProyecto.Text),
                        };
                        new GuillermoSotomayor.BLL.Logica()
                            .MantenimientoEstudiantes((int)Utilidades.Accion.Insertar, estudiante);
                        break;

                    case (int)Utilidades.Accion.Modificar:
                        estudiante = null;
                        estudiante = new Estudiante
                        {
                            Id = long.Parse(tx_codigo.Text),
                            Nombre = tx_Nombre.Text,
                            Nota1 = decimal.Parse(tx_Nota1.Text),
                            Nota2 = decimal.Parse(tx_Nota2.Text),
                            NotaProyecto = decimal.Parse(tx_NotaProyecto.Text),
                        };
                        new GuillermoSotomayor.BLL.Logica()
                            .MantenimientoEstudiantes((int)Utilidades.Accion.Modificar, estudiante);
                        break;

                    case (int)Utilidades.Accion.Eliminar:
                        estudiante = null;
                        estudiante = new Estudiante
                        {
                            Id = long.Parse(tx_codigo.Text),
                            Nombre = tx_Nombre.Text,
                            Nota1 = decimal.Parse(tx_Nota1.Text),
                            Nota2 = decimal.Parse(tx_Nota2.Text),
                            NotaProyecto = decimal.Parse(tx_NotaProyecto.Text),
                        };
                        new GuillermoSotomayor.BLL.Logica()
                            .MantenimientoEstudiantes((int)Utilidades.Accion.Eliminar, estudiante);
                        break;
                }
                lblError.Visible = true;
                lblError.CssClass = "alert alert-success";
                lblError.Text = "Accion realizada correctamente";
                Limpiar();
            } catch(Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Ocurrió un error inesperado: " + ex.Message;
            }
            
           
        }

        private void Limpiar()
        {
            tx_codigo.Text = string.Empty;
            tx_Nombre.Text = string.Empty;
            tx_Nota1.Text = string.Empty;
            tx_Nota2.Text = string.Empty;
            tx_NotaProyecto.Text = string.Empty;
        }

        private bool Valida()
        {
            if(Int32.Parse(accions.Text) != 1 && tx_codigo.Text.Equals(string.Empty))
            {
                lblError.CssClass = "alert alert-danger";
                lblError.Visible = true;
                lblError.Text = "Debe digiar un código si desea elminar/modificar el estudiante";
                return false;
            }

            if (Int32.Parse(accions.Text) == 1 && tx_Nombre.Text.Equals(string.Empty))
            {
                lblError.CssClass = "alert alert-danger";
                lblError.Visible = true;
                lblError.Text = "Debe digitar un nombre";
                return false;
            }

            if (Int32.Parse(accions.Text) != 1 && tx_Nota1.Text.Equals(string.Empty))
            {
                lblError.CssClass = "alert alert-danger";
                lblError.Visible = true;
                lblError.Text = "Debe digitar una nota";
                return false;
            }

            if (Int32.Parse(accions.Text) != 1 && tx_Nota2.Text.Equals(string.Empty))
            {
                lblError.CssClass = "alert alert-danger";
                lblError.Visible = true;
                lblError.Text = "Debe digitar una nota";
                return false;
            }

            if (Int32.Parse(accions.Text) != 1 && tx_NotaProyecto.Text.Equals(string.Empty))
            {
                lblError.CssClass = "alert alert-danger";
                lblError.Visible = true;
                lblError.Text = "Debe digitar una nota";
                return false;
            }
            return true;
        }

        private void ConsultaEstudiante()
        {
            lblError.Visible = false;
            var idEstudiante = Int32.Parse(tx_codigo.Text);
            var objEstudiante = new GuillermoSotomayor.BLL.Logica().ConsultarEstudiante(idEstudiante);

            if (objEstudiante.Id == 0)
            {
                lblError.Visible = true;
                lblError.Text = "No existe el estudiante";
                return;
            }

            tx_Nombre.Text = objEstudiante.Nombre;
            tx_Nota1.Text = objEstudiante.Nota1.ToString();
            tx_Nota2.Text = objEstudiante.Nota2.ToString();
            tx_NotaProyecto.Text = objEstudiante.NotaProyecto.ToString();
        }
        private bool ValidaConsultar()
        {
            if (tx_codigo.Text.Equals(string.Empty))
            {
                lblError.Visible = true;
                lblError.Text = "Debe digitar un código para consultar";
                return false;
            }
            return true;
        }

        private void AccionEditar()
        {
            accions.Text = "2";
            btAgregar.Visible = false;
            btEditar.Visible = false;
            btEliminar.Visible = false;
            tx_codigo.ReadOnly = false;
            btConfirmar.Visible = true;
            btConfirmar.CssClass = "btn btn-warning";

            btCancelar.Visible = true;
            btConsultar.Visible = true;
            lblError.Visible = false;


        }

        private void AccionEliminar()
        {
            accions.Text = "3";
            btAgregar.Visible = false;
            btEditar.Visible = false;
            btEliminar.Visible = false;
            tx_codigo.ReadOnly = false;

            tx_Nombre.ReadOnly = true;
            tx_Nota1.ReadOnly = true;
            tx_Nota2.ReadOnly = true;
            tx_NotaProyecto.ReadOnly = true;

            btConfirmar.Visible = true;
            btConfirmar.CssClass = "btn btn-danger";

            btCancelar.Visible = true;
            btConsultar.Visible = true;
            lblError.Visible = false;
        }

        private void AccionCancelar()
        {
            tx_codigo.ReadOnly = true;
            tx_Nombre.ReadOnly = false;
            tx_Nota1.ReadOnly = false;
            tx_Nota2.ReadOnly = false;
            tx_NotaProyecto.ReadOnly = false;

            btAgregar.Visible = true;
            btEditar.Visible = true;
            btEliminar.Visible = true;

            btConfirmar.Visible = false;
            btConfirmar.CssClass = "";
            btCancelar.Visible = false;
            btConsultar.Visible = false;
            Limpiar();
            lblError.Visible = false;
        }

        #endregion

        
    }
}