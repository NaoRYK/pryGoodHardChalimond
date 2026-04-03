using pryGoodHardChalimond.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Windows.Forms; // Necesario para Application.StartupPath

namespace pryGoodHardChalimond.AccesoDatos
{
    /// Clase encargada de la migración de datos desde archivos TXT a la base de datos.
    class CMigracion
    {
        /// Migra las categorías a la base de datos.
        /// <param name="listaCategorias">Lista de arrays de campos de categorías</param>
        public void MigrarCategorias(List<string[]> listaCategorias)
        {
            try
            {
                var conexion = new CConexion();
                conexion.Abrir();
                var conn = conexion.ObtenerConexion();

                foreach (var campos in listaCategorias)
                {
                    string sql = "INSERT INTO Categorias (idCategoria, Nombre) VALUES (?, ?)";
                    using (var cmd = new System.Data.OleDb.OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", Convert.ToInt32(campos[0]));
                        cmd.Parameters.AddWithValue("?", campos[1]);
                        cmd.ExecuteNonQuery();
                    }
                }

                conexion.Cerrar();
            }
            catch (Exception ex)
            {
            }
        }

        /// Migra los artículos a la base de datos.
        /// <param name="listaArticulos">Lista de arrays de campos de artículos</param>
        public void MigrarArticulos(List<string[]> listaArticulos)
        {
            try
            {
                var conexion = new CConexion();
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
                   
                        cmd.ExecuteNonQuery();
                    }
                }

                conexion.Cerrar();
            }
            catch (Exception ex)
            {
            }
        }
    }
}