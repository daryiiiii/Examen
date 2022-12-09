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
    public class ViewModelMedicamentos : INotifyPropertyChanged
    {
        public ViewModelMedicamentos()

        {
            AbrirArchivo();

            ControlMedicamentos = new Command(() =>

            {

                Medicamentos Medicamento1 = new Medicamentos()

                {

                    Tipo_de_medicamento = this.Tipo_de_medicamento,
                    Dosis = this.Dosis,
                    Horario = this.Horario,
                    duracion_del_tratamiento = this.Duracion_del_tratamiento

                };

                persona1.Lista_medicamentos.Add(Medicamento1);

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "cod.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None); //error
                formatter.Serialize(archivo, Medicamento1);
                archivo.Close();

                Guardar = "";

                foreach (Medicamentos x in persona1.Lista_medicamentos)
                {
                    Guardar += x.toString();
                }

            });


            Limpiar = new Command(() =>
            {
                persona1.Lista_medicamentos = new ObservableCollection<Medicamentos>();
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Ciculos.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, persona1.Lista_medicamentos);
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

                foreach (Medicamentos x in persona1.Lista_medicamentos)

                {

                    Guardar += x.toString();

                }
            }

            catch (Exception e)

            {
            }
        }

        Persona persona1 = new Persona();
        string tipo_de_medicamento;

        public string Tipo_de_medicamento

        {
            get => tipo_de_medicamento;
            set
            {
                tipo_de_medicamento = value;
                var arg = new PropertyChangedEventArgs(nameof(Tipo_de_medicamento));
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

        TimeSpan horario;
        public TimeSpan Horario
        {
            get => horario;
            set
            {
                horario = value;
                var arg = new PropertyChangedEventArgs(nameof(Horario));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        int duracion_del_tratamiento;
        public int Duracion_del_tratamiento

        {
            get => duracion_del_tratamiento;
            set
            {
                duracion_del_tratamiento = value;
                var arg = new PropertyChangedEventArgs(nameof(Duracion_del_tratamiento));
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



        public Command ControlMedicamentos { get; }
        public Command Limpiar { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

 