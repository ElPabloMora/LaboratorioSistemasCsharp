using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace PabloMoraPlanilla
{
    public class CreateArchi : Form
    {
        public string archivo;
        public string ruta;

        public CreateArchi(string archivo, string ruta)
        {
            this.archivo = archivo;
            this.ruta = ruta;
        }

    }
        
    
}
