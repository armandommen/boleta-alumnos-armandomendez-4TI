using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Boleta
{
    public partial class AgregarMateria : Form
    {
        
        public AgregarMateria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _Nombre = txtNombreMateria.Text;
            string _Semestre = cBSemetre.Text;
            Conexion oConexion = new Conexion();

            List<SqlParameter> Parametros = new List<SqlParameter>();
            SqlParameter Nombre_Materia = new SqlParameter()
            {
                ParameterName = "Nombre_Materia",
                Value = _Nombre
            };
            Parametros.Add(Nombre_Materia);
            SqlParameter Semestre = new SqlParameter()
            {
                ParameterName = "Semestre",
                Value = _Semestre
            };
            Parametros.Add(Semestre);
            oConexion.EjecutaNonQuery("AgregarMateria", Parametros);
            MessageBox.Show("SE A AGREGADO UNA MATERIA");
            Visualizar(dgvMateria);
            txtNombreMateria.Clear();
            cBSemetre.Text = "";
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int _id = Convert.ToInt32(dgvMateria.CurrentRow.Cells[0].Value);
            Conexion oConexion = new Conexion();
            List<SqlParameter> Parametros = new List<SqlParameter>();
            SqlParameter BajaMateria = new SqlParameter()
            {
                
                Value = _id,
                ParameterName = "Id_Materia"

            };
            Parametros.Add(BajaMateria);
            oConexion.EjecutaNonQuery("BajaMateria", Parametros);
            MessageBox.Show("La materia se ha dado de baja");
            Visualizar(dgvMateria);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Visualizar(DataGridView dgv)
        {
            Conexion oConexion = new Conexion();
            dgv.DataSource = oConexion.ObtenerDatos("VisulizarMateria");
        }


        private void AgregarMateria_Load(object sender, EventArgs e)
        {
            Visualizar(dgvMateria);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            int _id = Convert.ToInt32(dgvMateria.CurrentRow.Cells[0].Value);
            string _nombremateria = dgvMateria.CurrentRow.Cells[1].Value.ToString();
            string _semestre = dgvMateria.CurrentRow.Cells[2].Value.ToString();

            Conexion oConexion = new Conexion();
            List<SqlParameter> Parametros = new List<SqlParameter>();
            SqlParameter Id_Materia = new SqlParameter()
            {
                Value = _id,
                ParameterName = "Id_Materia"

            };
            Parametros.Add(Id_Materia);
            SqlParameter Nombre_Materia = new SqlParameter()
            {
                Value = _nombremateria,
                ParameterName = "Nombre_Materia"
            };
            Parametros.Add(Nombre_Materia);
            SqlParameter Semestre = new SqlParameter()
            {
                Value = _semestre,
                ParameterName = "Semestre"
            };
            Parametros.Add(Semestre);
            oConexion.EjecutaNonQuery("ActualizarMateria", Parametros);
            MessageBox.Show("La materia se a actualizado");
            Visualizar(dgvMateria);
           



        }
    }
}
