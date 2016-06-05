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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarMateria frm = new AgregarMateria();
            frm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Alumnos frm = new Alumnos();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calificaciones frm = new Calificaciones();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
