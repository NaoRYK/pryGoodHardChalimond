using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Necesario para Application.StartupPath

namespace pryGoodHardChalimond.AccesoDatos
{
    class CArchivoTxt
    { /// Lee un archivo TXT ubicado en la carpeta 'Datos' del proyecto.
      /// Cada línea se separa por ';' y se almacena como un array de campos.
      /// <param name="nombreArchivo">Nombre del archivo TXT (ej: "productos.txt")</param>
      /// <returns>Lista de arrays de campos leídos</returns>
        public List<string[]> LeerArchivoTxt(string nombreArchivo)
        {
            // Construye la ruta completa al archivo dentro de la carpeta 'Datos'
            string rutaCarpetaDatos = Path.Combine(Application.StartupPath, "Datos");
            string rutaArchivo = Path.Combine(rutaCarpetaDatos, nombreArchivo);

            var registros = new List<string[]>();
            foreach (var linea in File.ReadLines(rutaArchivo))
            {
                // Divide cada línea por ';'
                string[] campos = linea.Split(';');
                registros.Add(campos);
            }
            return registros;
        }
    }
}
