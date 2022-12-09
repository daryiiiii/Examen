using EXAMEN_SEGUNDO_PARCIAL.MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMEN_SEGUNDO_PARCIAL.MODELS
{
    [Serializable]
    public class Vacunas
    {
        public string Tipo_de_vacuna { get; set; } 
        public DateTime Fecha_primera_aplicacion { get; set; }
        public double Dosis { get; set; }
        public string Lugar_aplicacion { get; set; }

        public string toString()
        {
            return "Vacuna: " + Tipo_de_vacuna + "\n" + "Fecha de primera dosis: " + Fecha_primera_aplicacion + "\n" +
                "Numero de dosis: " + Dosis + "\n" + "Lugar de aplicacion" + Lugar_aplicacion;
        }
    }
}
