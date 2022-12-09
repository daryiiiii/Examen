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
    public class ViewModelPersona : INotifyPropertyChanged
    {
        public ViewModelPersona()
        {
            AbrirArchivo();


            ControlPaciente = new Command(() => 

                {
                    persona1 = new Persona
                    {

                        Nombre = this.Nombre,
                        Apellido = this.apellido,
                        Genero = this.Genero,
                        Altura = this.Altura,
                        Peso = this.Peso,
                    };

                    //Rutina de Serializacion
                    BinaryFormatter formatter = new BinaryFormatter();
                    string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                        "cod.aut");
                    Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                    formatter.Serialize(archivo, persona1);
                    archivo.Close();

                    Guardar = "";
                    foreach (Persona tmp in listaPersona)

                    {
                        Guardar += tmp.toString();
                    }
            });



            Limpiar = new Command(() => {

                listaPersona = new ObservableCollection<Persona>();
                
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Cod.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, listaPersona);
                archivo.Close();

                Guardar = "";
           });

        }

        private void AbrirArchivo()

            //Estructura

        {

            try

            {
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "cod.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                persona1 = (Persona)formatter.Deserialize(archivo);
                archivo.Close();

                Nombre = persona1.Nombre;
                Apellido = persona1.Apellido;
                Genero = persona1.Genero;
                Altura = persona1.Altura;
                Peso = persona1.Peso;

                Guardar += persona1.toString();

            }
            catch (Exception e)

            {

            }
        }

        Persona persona1 = new Persona();
        ObservableCollection<Persona> listaPersona = new ObservableCollection<Persona>();


        string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, arg);
            }
        }
        string apellido;
        public string Apellido
        {
            get => Apellido;
            set
            {
                Apellido = value;
                var arg = new PropertyChangedEventArgs(nameof(Apellido));
                PropertyChanged?.Invoke(this, arg);
            }
        }



        String genero;
        public string Genero
        {
           get => Genero;
            set
            {
                Genero = value;
                var arg = new PropertyChangedEventArgs(nameof(Genero));
                PropertyChanged?.Invoke(this, arg);
            }
        }


        double Altura;
        public double altura
        {
           get => Altura;
            set
            {
                Altura = value;
                var arg = new PropertyChangedEventArgs(nameof(Altura));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        double Peso;
        public double peso
        {
           get => peso;
            set
            {
                Altura = value;
                var arg = new PropertyChangedEventArgs(nameof(Peso));
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


        public Command ControlPaciente { get; }

        public Command Limpiar { get; }

        public event PropertyChangedEventHandler PropertyChanged;

    }

}

