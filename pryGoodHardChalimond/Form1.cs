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




            CArchivoTxt lector = new CArchivoTxt();
                List<string[]> listaCategorias = lector.LeerArchivoTxt("categorias.txt");

            List<string[]> listaArticulos = lector.LeerArchivoTxt("articulos.txt");
            try
            {
                listaCategorias = lector.LeerArchivoTxt("categorias.txt");
   
                txtInfo.AppendText("✔ Categorías leidas" + Environment.NewLine);

                listaArticulos = lector.LeerArchivoTxt("articulos.txt");
                txtInfo.AppendText("✔ Articulos leidos\n" + Environment.NewLine);


            }
            catch (Exception ex)
            {
                txtInfo.AppendText("⨹Error al leer archivos: " + ex.Message + Environment.NewLine);
                return; // Salir si falla la lectura
            }

            //  Migrar los datos a la base de datos
            try
            {

              CMigracion migrador = new CMigracion();
                txtInfo.AppendText("🔄 Iniciando migración...\n" + Environment.NewLine);
                txtInfo.AppendText("🔄 Migrando categorias...\n" + Environment.NewLine);
                migrador.MigrarCategorias(listaCategorias);
                txtInfo.AppendText("✔ Categorias migradas\n");

                txtInfo.AppendText("🔄 Migrando articulos...\n" + Environment.NewLine);

                migrador.MigrarArticulos(listaArticulos);
                txtInfo.AppendText("✔ Articulos migrados\n" + Environment.NewLine);

                txtInfo.AppendText("✔ Migracion existosa\n" + Environment.NewLine);


            }
            catch (Exception ex)
            {
                txtInfo.AppendText("⨹Error al conectar con la base de datos: " + ex.Message + Environment.NewLine);
            }
        }
    }
}
