using System;
using System.Collections.Generic;
using System.Text;

namespace GuillermoSotomayor.ETL
{
    public class Estudiante
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal NotaProyecto { get; set; }
        public string Condicion { get; set; }

    }
}
