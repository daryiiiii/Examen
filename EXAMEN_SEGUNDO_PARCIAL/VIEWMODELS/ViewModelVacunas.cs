using EXAMEN_SEGUNDO_PARCIAL.MODELS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using Xamarin.Forms;

namespace EXAMEN_SEGUNDO_PARCIAL.VIEWMODELS
{
	public class ViewModelVacunas : INotifyPropertyChanged
    {
        public ViewModelVacunas()

        {

            AbrirArchivo();

           ControlVacuna = new Command(() => 
           {
                Vacunas Vacuna1 = new Vacunas()
                {

                    Tipo_de_vacuna = this.Tipo_de_vacuna,
                    Fecha_primera_aplicacion = this.Fecha_primera_aplicacion,
                    Dosis = this.Dosis,
                    Lugar_aplicacion = this.Lugar_de_aplicacion

                };

                persona1.Lista_Vacunas.Add(Vacuna1);

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "cod.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, Vacuna1);
                archivo.Close();

                Guardar = "";

                foreach (Vacunas x in persona1.Lista_Vacunas)
                {
                    Guardar += x.toString() ;
                }
            });


            Limpiar = new Command(() => {

                persona1.Lista_Vacunas = new ObservableCollection<Vacunas>();

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Ciculos.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, persona1.Lista_Vacunas);
                archivo.Close();

                Guardar = "";

            });
        }
        private void AbrirArchivo()
        {
            try

            {
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "cod.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);
                persona1 = (Persona)formatter.Deserialize(archivo);
                archivo.Close();

                Guardar = "";

                foreach (Vacunas x in persona1.Lista_Vacunas)
                {

                    Guardar += x.toString();

                }
            }

            catch (Exception e)

            {


            }

        }



        Persona persona1 = new Persona();

        string tipo_de_vacuna;
        public string Tipo_de_vacuna
        {
            get => tipo_de_vacuna;
            set
            {
                tipo_de_vacuna = value;
                var arg = new PropertyChangedEventArgs(nameof(Tipo_de_vacuna));
                PropertyChanged?.Invoke(this, arg);
            }
        }
        DateTime fecha_primera_aplicacion;
        public DateTime Fecha_primera_aplicacion
        {
            get => fecha_primera_aplicacion;
            set
            {
                fecha_primera_aplicacion = value;
                var arg = new PropertyChangedEventArgs(nameof(Fecha_primera_aplicacion));
                PropertyChanged?.Invoke(this, arg);
            }
        }


        double dosis;
        public double Dosis
        {
            get => dosis;
            set
            {
                dosis = value;
                var arg = new PropertyChangedEventArgs(nameof(Dosis));
                PropertyChanged?.Invoke(this, arg);
            }
        }


        string lugar_de_aplicacion;
        public string Lugar_de_aplicacion
        {
            get => lugar_de_aplicacion;
            set
            {
               lugar_de_aplicacion = value;
                var arg = new PropertyChangedEventArgs(nameof(Lugar_de_aplicacion));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        string guardar;
        public string Guardar

        {
            get => guardar;
            set
            {
                guardar = value;
                var arg = new PropertyChangedEventArgs(nameof(Guardar));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public Command ControlVacuna { get; }
        public Command Limpiar { get; }     
        public event PropertyChangedEventHandler PropertyChanged;
    }

}