using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boleta
{
    public partial class Calificaciones : Form
    {
        public Calificaciones()
        {
            InitializeComponent();
        }
        private void visualizar_Alumnos(ComboBox cbx)
        {
            Conexion oConexion = new Conexion();
            cbx.DataSource = oConexion.TraerDatos("Buscar_Alumnos");
        }
        private void visualizar_Materias(ComboBox cbx)
        {
            Conexion oConexion = new Conexion();
            cbx.DataSource = oConexion.TraerDatos("Buscar_Materias");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Calificaciones_Load(object sender, EventArgs e)
        {
            visualizar_Alumnos(cbAlumnos);
            visualizar_Materias(cbMaterias);
        }
    }
}
