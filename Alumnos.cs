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
    public partial class Alumnos : Form
    {
        public Alumnos()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _NombreAlumno = txtAlumno.Text;
            string _ApellidoPaterno = txtPaterno.Text;
            string _ApellidoMaterno = txtMaterno.Text;
            string _Semestre = cbSemestre.Text;
            Conexion oConexion = new Conexion();
            List<SqlParameter> Parametros = new List<SqlParameter>();
            SqlParameter Apelliido_P = new SqlParameter()
            {
                ParameterName = "Apellido_P",
                Value = _ApellidoPaterno
            };
            Parametros.Add(Apelliido_P);

            SqlParameter Apellido_M = new SqlParameter() 
            {
                ParameterName = "Apellido_M",
                Value= _ApellidoMaterno
            };
            Parametros.Add(Apellido_M);
            SqlParameter Nombre = new SqlParameter() 
            {
                ParameterName = "Nombre",
                Value = _NombreAlumno
            };
            Parametros.Add(Nombre);
            SqlParameter Semestre = new SqlParameter()
            {
                ParameterName = "Semestre",
                Value = _Semestre
            };
            Parametros.Add(Semestre);
            oConexion.EjecutaNonQuery("Insertar_Alumno", Parametros);
            MessageBox.Show("Se a agregdo un alumno");
            Visualizar(dgvAlumnos);
            txtAlumno.Clear();
            txtMaterno.Clear();
            txtPaterno.Clear();
            cbSemestre.Text = "";





        }
        private void Visualizar(DataGridView dgv)
        {
            Conexion oConexion = new Conexion();
            dgv.DataSource = oConexion.ObtenerDatos("VisulizarAlumno");
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            Visualizar(dgvAlumnos);
        }

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int _id = Convert.ToInt32(dgvAlumnos.CurrentRow.Cells[0].Value);
            Conexion oConexion = new Conexion();
            List<SqlParameter> Parametros = new List<SqlParameter>();
            SqlParameter BajaAlumno = new SqlParameter()
            {
               Value = _id,
               ParameterName = "Id_Alumno"
            };
            Parametros.Add(BajaAlumno);
            oConexion.EjecutaNonQuery("BajaAlumno", Parametros);
            MessageBox.Show("Se a dado de baja al alumno");
            Visualizar(dgvAlumnos);


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int _id = Convert.ToInt32(dgvAlumnos.CurrentRow.Cells[0].Value);
            string _nombreAlumno = dgvAlumnos.CurrentRow.Cells[2].Value.ToString();
            string  _ApellidoP = dgvAlumnos.CurrentRow.Cells[3].Value.ToString();
            string _ApellidoM = dgvAlumnos.CurrentRow.Cells[4].Value.ToString();
            string _semestre = dgvAlumnos.CurrentRow.Cells[5].Value.ToString();
            Conexion oConexion = new Conexion();
            List<SqlParameter> Parametros = new List<SqlParameter>();
            SqlParameter Id_Alumno = new SqlParameter()
            {
                Value = _id,
                ParameterName = "Id_Alumno"
            };
            Parametros.Add(Id_Alumno);
            SqlParameter Apellido_P = new SqlParameter()
            {
                Value = _ApellidoP,
                ParameterName = "Apellido_P"
            };
            Parametros.Add(Apellido_P);
            SqlParameter Apellido_M = new SqlParameter()
            {
                Value = _ApellidoM,
                ParameterName = "Apellido_M"
            };
            Parametros.Add(Apellido_M);
            SqlParameter Nombre = new SqlParameter()
            {
                Value = _nombreAlumno,
                ParameterName = "Nombre"
            };
            Parametros.Add(Nombre);
            SqlParameter Semestre = new SqlParameter()
            {
                Value = _semestre,
                ParameterName="Semestre"
            };
            Parametros.Add(Semestre);
            oConexion.EjecutaNonQuery("actualizarAlumno", Parametros);
            MessageBox.Show("El alumno sido actualizado");
            Visualizar(dgvAlumnos);



        }
    }
}
