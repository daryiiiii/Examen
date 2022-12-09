using EXAMEN_SEGUNDO_PARCIAL.MODELS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EXAMEN_SEGUNDO_PARCIAL.MODELS
{
    [Serializable]
    public class Persona
    {
        internal object listaPersona;

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Genero { get; set; }
        public double Altura { get; set;}
        public double Peso { get; set; }


        
        public ObservableCollection<Medicamentos> Lista_medicamentos { get; set; } = new ObservableCollection<Medicamentos>();
        public ObservableCollection<Vacunas> Lista_Vacunas { get; set; } = new ObservableCollection<Vacunas>();
        public ObservableCollection<Persona> Lista_Persona { get; set; } = new ObservableCollection<Persona>();

        public string toString()
        {
            return "Nombre: " + Nombre + "\n" + "Apellido: " + Apellido + "\n" +
                "Genero: " + Genero + "\n" + "Estatura" + Altura + "Peso: " + Peso + "\n\t";
        }
    }
    }

