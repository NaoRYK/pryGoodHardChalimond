using pryGoodHardChalimond.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Windows.Forms; // Necesario para Application.StartupPath

namespace pryGoodHardChalimond.AccesoDatos
{
    /// Clase encargada de la migración de datos desde archivos TXT a la base de datos.
    class clsMigracion
    {
        /// Migra las categorías a la base de datos.
        /// <param name="listaCategorias">Lista de arrays de campos de categorías</param>
        public int MigrarCategorias(List<string[]> listaCategorias)
        {
            int count = 0;
            try
            {
                var conexion = new clsConexion();
                conexion.Abrir();
                var conn = conexion.ObtenerConexion();

                foreach (var campos in listaCategorias)
                {
                    string sql = "INSERT INTO Categorias (idCategoria, Nombre) VALUES (?, ?)";
                    using (var cmd = new System.Data.OleDb.OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", Convert.ToInt32(campos[0]));
                        cmd.Parameters.AddWithValue("?", campos[1]);
                        try 
                        {
                            cmd.ExecuteNonQuery();
                            count++;
                        }
                        catch (System.Data.OleDb.OleDbException)
                        {
                            // Ignorar errores de clave duplicada
                        }
                    }
                }

                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                throw ex; // Re-throw to handle it in the UI if needed
            }
            return count;
        }

        /// Migra los artículos a la base de datos.
        /// <param name="listaArticulos">Lista de arrays de campos de artículos</param>
        public int MigrarArticulos(List<string[]> listaArticulos)
        {
            int count = 0;
            try
            {
                var conexion = new clsConexion();
                conexion.Abrir();
                var conn = conexion.ObtenerConexion();

                foreach (var campos in listaArticulos)
                {
                    string sql = "INSERT INTO Articulos (idArticulo, Nombre, Precio, idCategoria, Stock) VALUES (?, ?, ?, ?, ?)";
                    using (var cmd = new System.Data.OleDb.OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", Convert.ToInt32(campos[0]));
                        cmd.Parameters.AddWithValue("?", campos[1]);
                        cmd.Parameters.AddWithValue("?", Convert.ToDecimal(campos[3]));
                        cmd.Parameters.AddWithValue("?", Convert.ToInt32(campos[2]));
                        cmd.Parameters.AddWithValue("?", Convert.ToInt32(campos[4]));
                   
                        try 
                        {
                            cmd.ExecuteNonQuery();
                            count++;
                        }
                        catch (System.Data.OleDb.OleDbException)
                        {
                            // Ignorar errores de clave duplicada
                        }
                    }
                }

                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }
    }
}