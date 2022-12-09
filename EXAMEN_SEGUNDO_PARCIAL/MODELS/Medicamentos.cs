using EXAMEN_SEGUNDO_PARCIAL.MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXAMEN_SEGUNDO_PARCIAL.MODELS
{
    [Serializable]
    public class Medicamentos
    {
        public string Tipo_de_medicamento { get; set; }
        public Double Dosis { get; set; }
        public TimeSpan Horario { get; set; }
        public int duracion_del_tratamiento { get; set; }

        public string toString()
        {
            return "Medicamento: " + Tipo_de_medicamento + "\n" + "Dosis: " + Dosis + "\n" +
                "Horario: " + Horario + "\n" + "Duracion del Tratamiento" + duracion_del_tratamiento + "\n\t";
        }
    }
}
