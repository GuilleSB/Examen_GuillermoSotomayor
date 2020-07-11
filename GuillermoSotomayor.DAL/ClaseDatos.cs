using GuillermoSotomayor.ETL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuillermoSotomayor.DAL
{
    public class ClaseDatos
    {
        public Database AbrirConexion()
        {
            string baseDatos = "Server=DESKTOP-05BM513\\SQLEXPRESS; Database=Examen1; persist security info = True; Integrated Security = SSPI;";
            return new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(baseDatos);
        }

        public void MantenimientoEstudiante(int accion,Estudiante Estudiante)
        {
            var data = AbrirConexion();
            var comm = data.GetStoredProcCommand("[dbo].[sp_MantEstudiantes]",
                                                    accion,
                                                    Estudiante.Nombre,
                                                    Estudiante.Nota1,
                                                    Estudiante.Nota2,
                                                    Estudiante.NotaProyecto,
                                                    Estudiante.Condicion,
                                                    Estudiante.Id
                                                    );
            data.ExecuteNonQuery(comm);
        }
        public Estudiante ConsultaEstudiante(long id)
        {
            Estudiante estudiante = new Estudiante();
            
            var data = AbrirConexion();
            var comm = data.GetStoredProcCommand("[dbo].[sp_ConsultaEstudiante]",id);
            var info = data.ExecuteReader(comm);
            
            while (info.Read())
            {
                estudiante = new Estudiante
                {
                    Id = long.Parse(info["Id"].ToString()),
                    Nombre = info["Nombre"].ToString(),
                    Nota1 = decimal.Parse(info["Nota1"].ToString()),
                    Nota2 = decimal.Parse(info["Nota2"].ToString()),
                    NotaProyecto = decimal.Parse(info["NotaProyecto"].ToString()),
                    Condicion = info["Condicion"].ToString()
                };
            }
            return estudiante;
        }
    }
}
