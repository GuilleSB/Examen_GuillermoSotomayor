using GuillermoSotomayor.ETL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuillermoSotomayor.BLL
{
    public class Logica
    {
        public void MantenimientoEstudiantes(int accion, Estudiante estudiante)
        { 
            if (accion !=3){
                var calculaNota = (estudiante.Nota1 + estudiante.Nota2 + estudiante.NotaProyecto) / 3;
                estudiante.Condicion = (calculaNota >= 70) ? "APROBADO" : "REPROBADO";
            }
            new DAL.ClaseDatos().MantenimientoEstudiante(accion, estudiante);
        }

        public Estudiante ConsultarEstudiante(long id)
        {
            return new DAL.ClaseDatos().ConsultaEstudiante(id);
        }
    }
}
