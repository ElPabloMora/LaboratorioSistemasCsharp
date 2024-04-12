using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PabloMoraPlanilla
{
    //Tarea 2 calculo de plantilla 
    //Juan Pablo Mora Barrantes
    public partial class Form1 : Form
    {

        public string ruta = @"C:\Users\pablo\OneDrive\Documentos\Universidad\2024\I Cuatrimestre\Sistemas computacionales\Laboratorio 2\PabloMoraPlanilla\";
        public string archivo;
        public string archivo2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            //nombre del archivo
            archivo = "nominaElZAfiro.txt";
            archivo2 = "planillaElZAfiro.txt";

            //Aqui comprobamos si el archivo donde vamos a trabajar existe, ademas si es asi que muestre en el list view los datos de dicho archivo
            if (!File.Exists(ruta + archivo))
            {
                //Este metodo se ejecuta si el archivo no existe. Y lo crea
                crear();
                
            }
            //Sino va a leer los datos
            else
            {
                LeerArchivo();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

       
        public void Guardar()
        {
            archivo = "nominaElZAfiro.txt";
            archivo2 = "planillaElZAfiro.txt";



            try
            {
                if (File.Exists(ruta + archivo))
                {

                    StreamWriter escribir = new StreamWriter(ruta + archivo, true);
                    StreamWriter escribir2 = new StreamWriter(ruta + archivo2, true);
                    if (txtcedula.Text.Equals("") || txtnombre.Text.Equals("") || txtPrimerA.Text.Equals("") || txtSegundoA.Text.Equals(""))
                    {
                        MessageBox.Show("No ha ingresado los datos necesarios en Datos del Empleado", "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtcedula.Focus();
                    }
                    else if (txtHorasExtraordinarias.Text.Equals("") || txtHorasOrdinarias.Text.Equals("") || txtSalarioxHoras.Text.Equals(""))
                    {
                        MessageBox.Show("No ha ingresado los datos necesarios en Datos de Carga de Nomina Mensual", "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtHorasExtraordinarias.Focus();
                    }
                    else if (txtsi.Text.Equals("") && txtNo.Text.Equals("") || txtañoIngreso.Text.Equals(""))
                    {
                        MessageBox.Show("No ha ingresado los datos necesarios en Bonos", "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtsi.Focus();
                    }
                    else if (txtsi.Text == txtNo.Text)
                    {
                        MessageBox.Show("No se permite seleccionar las dos opciones en Bono", "Marque con X solo una opcion", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtsi.Focus();
                    }
                    else
                    {

                        // Por aqui 
                        escribir.WriteLine(txtcedula.Text + "," + txtnombre.Text + "," + txtPrimerA.Text + "," +
                             txtSegundoA.Text + "," + txtHorasOrdinarias.Text + "," + txtHorasExtraordinarias.Text + "," +
                            txtSalarioxHoras.Text + "," + txtsi.Text + "," + txtNo.Text + "," + txtañoIngreso.Text);
                        escribir.Close();

                       
                        

                        string empleado = (txtnombre.Text + " " + txtPrimerA.Text + " " + txtSegundoA.Text);

                        string salarioBruto = Convert.ToString(((int.Parse(txtHorasOrdinarias.Text)*4.35) * int.Parse(txtSalarioxHoras.Text)) + ((int.Parse(txtHorasExtraordinarias.Text)*4.35) * (int.Parse(txtSalarioxHoras.Text)*2)));

                        string impuestoDeVentas = Convert.ToString((double.Parse(salarioBruto) * 0.13));

                        string bono;

                        int años = (2024 - int.Parse(txtañoIngreso.Text));

                        if (txtsi.Text == "X")
                        {
                            if (9 > años && años > 2 )
                            {
                                bono = "1500";
                            }
                            else if (19 > años && años > 10)
                            {
                                bono = "11000";
                            }
                            else if ( años > 20)
                            {
                                bono = "60000";
                            }
                            else
                            {
                                bono = "500";
                            }
                        }
                        else
                        {
                            bono = "0";
                        }

                        string salarioneto = Convert.ToString((int.Parse(salarioBruto) + int.Parse(bono) - (double.Parse(salarioBruto) * 0.13)));

                        escribir2.WriteLine(txtcedula.Text + "," + empleado + "," + salarioBruto + "," + impuestoDeVentas + "," + salarioneto + "," + bono);

                        escribir2.Close();

                        limpiar();
                        LeerArchivo();
                        MessageBox.Show("Registro guardado correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
              
            }
            catch
            {

            }
        }

        public void crear()
        {
            archivo = "nominaElZAfiro.txt";
            archivo2 = "planillaElZAfiro.txt";
            FileStream archFlujo;
            archFlujo = File.Create(ruta + archivo);
            archFlujo.Close();
            FileStream archFlujo2;
            archFlujo2 = File.Create(ruta + archivo2);
            archFlujo2.Close();
        }

        public void LeerArchivo()
        {
            archivo = "nominaElZAfiro.txt";

            StreamReader lectura = new StreamReader(ruta + archivo);

            string nombre, apellido, apellido2;
            string cedula, horasOrdi, horasExtra, salarioxhora, añoIngreso;

            try
            {
                while (lectura.Peek() != -1)
                {
                    string linea = lectura.ReadLine();
                    string[] separador = linea.Split(',');

                    cedula = separador[0];
                    nombre = separador[1];
                    apellido = separador[2];
                    apellido2 = separador[3];
                    horasOrdi = separador[4];
                    horasExtra = separador[5];
                    salarioxhora = separador[6];
                    añoIngreso = separador[7];

                    if (string.IsNullOrEmpty(linea))
                    {
                        continue;
                    }

                    lsvContenido.Items.Add(cedula);
                    lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(nombre);
                    lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(apellido);
                    lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(apellido2);
                    lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(horasOrdi);
                    lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(horasExtra);
                    lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(salarioxhora);
                    lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(añoIngreso);
                }
                lectura.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un problema con " + "la escritura del archivo: " + ex.Message, "Guardar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void limpiar()
        {
            //Aqui borramos todas los campos del formulario para que el usuario pueda ingresar otros...
            txtcedula.Clear();
            txtnombre.Clear();
            txtPrimerA.Clear();
            txtSegundoA.Clear();
            txtañoIngreso.Clear();
            txtHorasExtraordinarias.Clear();
            txtHorasOrdinarias.Clear();
            txtNo.Clear();
            txtSalarioxHoras.Clear();
            txtsi.Clear();

            //Aqui limpiarmos el list view 
            lsvContenido.Clear();
            lsvContenido.Columns.Add("Cedula").Width = 60;
            lsvContenido.Columns.Add("Nombre").Width = 60;
            lsvContenido.Columns.Add("Primer Apellido").Width = 90;
            lsvContenido.Columns.Add("Segundo Apellido").Width = 107;
            lsvContenido.Columns.Add("Horas Ordinarias").Width = 99;
            lsvContenido.Columns.Add("Horas Extraordinarias").Width = 140;
            lsvContenido.Columns.Add("Salario Por Hora").Width = 91;
            lsvContenido.Columns.Add("Bono").Width = 60;

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
            LeerArchivo();
        }


        //Todos los eventos comprueban si son numero o letra en los textbox

        public bool validar_Numero(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e.Handled;
            
        }
        public bool validar_Letra(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e.Handled;
        }
        private void txtHorasOrdinarias_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_Numero(e);
        }
        private void txtañoIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_Numero(e);
        }

        private void txtHorasExtraordinarias_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_Numero(e);
        }

        private void txtSalarioxHoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_Numero(e);
        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_Numero(e);
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_Letra(e);
        }

        private void txtPrimerA_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_Letra(e);
        }

        private void txtSegundoA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtsi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar = 'X') && !char.IsControl(e.KeyChar) )
            {
                e.Handled = true; 
            }
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar_Letra(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtcedula.Text != "")
            { 
                consultar(); 
            }
            else
            {
                txtcedula.Focus();
                MessageBox.Show("Debe de ingresar una cedula para poder consultar un empleado  " + "Verifique...." );

            }
        }

        public void consultar()
        {
            archivo = "nominaElZAfiro.txt";

            StreamReader lectura;

            string cadena;
            string cedula = txtcedula.Text;
            bool encontrado;
            encontrado = false;
            string[] campos = new string[10];
            char[] separador = { ',' };

            try
            {
                lectura = File.OpenText(ruta + archivo);
                cadena = lectura.ReadLine();
                while (cadena != null && encontrado == false)
                {
                    campos = cadena.Split(separador);

                    if (campos[0].Trim().Equals(cedula))
                    {
                        lsvContenido.Clear();
                        lsvContenido.Columns.Add("Cedula").Width = 60;
                        lsvContenido.Columns.Add("Nombre").Width = 60;
                        lsvContenido.Columns.Add("Primer Apellido").Width = 90;
                        lsvContenido.Columns.Add("Segundo Apellido").Width = 107;
                        lsvContenido.Columns.Add("Horas Ordinarias").Width = 99;
                        lsvContenido.Columns.Add("Horas Extraordinarias").Width = 140;
                        lsvContenido.Columns.Add("Salario Por Hora").Width = 91;
                        lsvContenido.Columns.Add("Bono").Width = 60;

                        lsvContenido.Items.Add(cedula);
                        lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(campos[1]);
                        lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(campos[2]);
                        lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(campos[3]);
                        lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(campos[4]);
                        lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(campos[5]);
                        lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(campos[6]);
                        lsvContenido.Items[lsvContenido.Items.Count - 1].SubItems.Add(campos[7]);

                        encontrado = true;
                        lectura.Close();
                        MessageBox.Show("Se ha encontrado el usuario con el numero de cedula : " + txtcedula.Text + "Guardar");
                    }
                    else
                    {
                        cadena = lectura.ReadLine();
                    }
                }
                if (encontrado == false)
                {
                    MessageBox.Show("No se ha encontrado el usuario con el numero de cedula :  " + txtcedula.Text);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("No se ha encontrado el usuario con el numero de cedula : " + txtcedula.Text + ex.Message, "Guardar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
