using pryGoodHardChalimond.AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryGoodHardChalimond
{
    public partial class frmMigracion: Form
    {
        public frmMigracion()
        {
            InitializeComponent();
        }

        private void btnMigration_Click(object sender, EventArgs e)
        {
            txtInfo.Clear();




            clsArchivoTxt lector = new clsArchivoTxt();
            List<string[]> listaCategorias = null;
            List<string[]> listaArticulos = null;

            try
            {
                listaCategorias = lector.LeerArchivoTxt("categorias.txt");
                listaArticulos = lector.LeerArchivoTxt("articulos.txt");
            }
            catch (Exception ex)
            {
                txtInfo.AppendText("Error al leer archivos: " + ex.Message + Environment.NewLine);
                return; // Salir si falla la lectura
            }

            //  Migrar los datos a la base de datos
            try
            {
                clsMigracion migrador = new clsMigracion();
                
                txtInfo.AppendText("Migrando datos de Categorias..." + Environment.NewLine);
                int cantCategorias = migrador.MigrarCategorias(listaCategorias);
                txtInfo.AppendText("Se incorporaron: " + cantCategorias + " registros nuevos." + Environment.NewLine + Environment.NewLine);

                txtInfo.AppendText("Migrando datos de Articulos..." + Environment.NewLine);
                int cantArticulos = migrador.MigrarArticulos(listaArticulos);
                txtInfo.AppendText("Se incorporaron: " + cantArticulos + " registros nuevos." + Environment.NewLine + Environment.NewLine);

                txtInfo.AppendText("Migración finalizada." + Environment.NewLine);
            }
            catch (Exception ex)
            {
                txtInfo.AppendText("Error al conectar con la base de datos: " + ex.Message + Environment.NewLine);
            }
        }
    }
}
