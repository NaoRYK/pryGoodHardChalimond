using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms; // Necesario para Application.StartupPath

namespace pryGoodHardChalimond.AccesoDatos
{
    /// <summary>
    /// Clase encargada de gestionar la conexión a la base de datos Access 'Distriubuidora.accdb'.
    /// </summary>
    class clsConexion
    {
        // Cadena de conexión a la base de datos Access.
        // Usa Application.StartupPath para ubicar el archivo en la carpeta de la aplicación.
        private readonly string cadenaConexion;
        private OleDbConnection conexion;

        /// Inicializa la conexión con la base de datos Access.
        public clsConexion()
        {
            // Construye la ruta completa al archivo de base de datos
            string rutaBD = Path.Combine(Application.StartupPath, "..", "..", "Datos", "Distribuidora.accdb");
            cadenaConexion = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={rutaBD};Persist Security Info=False;";
            conexion = new OleDbConnection(cadenaConexion);
        }

        /// Abre la conexión a la base de datos.
        public void Abrir()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        /// Cierra la conexión a la base de datos.
        public void Cerrar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        /// Obtiene el objeto OleDbConnection para ejecutar comandos SQL.
        /// <returns>Objeto OleDbConnection</returns>
        public OleDbConnection ObtenerConexion()
        {
            return conexion;
        }


    }
}
