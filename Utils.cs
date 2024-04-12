using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace PabloMoraPlanilla
{
    public class Utils
    {
        public string archivo;
        public string ruta = @"C:\Users\pablo\OneDrive\Documentos\Universidad\2024\I Cuatrimestre\Sistemas computacionales\Laboratorio 2\PabloMoraPlanilla\";
        public double cedula;
        public string nombre;
        public string apellido1;
        public string apellido2;
        public double horasOrdinarias;
        public double horasExtraordinarias;
        public double salarioxhora;
        public string si;
        public string no;
        public double añoIngreso;

        public void crear()
        {
            archivo = "nominaElZAfiro.txt";
            FileStream archFlujo;
            archFlujo = File.Create(ruta + archivo);
            archFlujo.Close();
        }
        public void Guardar()
        {
            archivo = "nominaElZAfiro.txt";
            

            try
            {
                if (File.Exists(ruta + archivo) == false)
                {


                    Guardar();
                    crear();

                }
                else
                {

                    StreamWriter escribir = new StreamWriter(ruta + archivo, true);
                    if (this.cedula.Equals("") || this.nombre.Equals("") || this.apellido1.Equals("") || this.apellido2.Equals(""))
                    {
                        MessageBox.Show("No ha ingresado los datos necesarios en Datos del Empleado", "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        
                    }
                    else if (this.horasOrdinarias.Equals("") || this.horasExtraordinarias.Equals("") || this.salarioxhora.Equals(""))
                    {
                        MessageBox.Show("No ha ingresado los datos necesarios en Datos de Carga de Nomina Mensual", "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        
                    }
                    else if (this.si.Equals("") && this.no.Equals("") || this.añoIngreso.Equals(""))
                    {
                        MessageBox.Show("No ha ingresado los datos necesarios en Bonos", "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        
                    }
                    else if (this.si == this.no)
                    {
                        MessageBox.Show("No se permite seleccionar las dos opciones en Bono", "Marque con X solo una opcion", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                       
                    }
                    else
                    {

                        // Por aqui 
                        escribir.WriteLine(this.cedula + "," + this.nombre + "," + this.apellido1 + "," +
                             this.apellido2 + "," + this.horasOrdinarias + "," + this.horasExtraordinarias + "," +
                            this.salarioxhora + "," + this.si + "," + this.no + "," + this.añoIngreso);
                        escribir.Close();
                        MessageBox.Show("Registro guardado correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch
            {

            }
        }

        public Utils(double cedula, string nombre, string apellido1, string apellido2, double horasOrdinarias, double horasExtraordinarias,
            double salarioxhora, string si, string no, double añoIngreso)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.horasOrdinarias = horasOrdinarias;
            this.horasExtraordinarias = horasExtraordinarias;
            this.salarioxhora = salarioxhora;
            this.si = si;
            this.no = no;
            this.añoIngreso = añoIngreso;
        }
    }
        
    
}
