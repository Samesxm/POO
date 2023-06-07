using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoX
{
    public partial class formModificar : Form
    {
        //NOMBRE DEL ARCHIVO
        public static string nombreArhivo = "datos.txt";
        public formModificar()
        {
            InitializeComponent();
        }

        //VALIDANDO QUE EN EL CAMPO 'CELULAR' SOLO SE INGRESEN CARACTERES NUMERICOS.
        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //VALIDANDO QUE EN EL CAMPO 'EDAD' SOLO SE INGRESEN CARACTERES NUMERICOS.
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtCelular.Text != "" && txtCorreo.Text != "" && txtDomicilio.Text != "" && txtDomicilio.Text != "")
            {
                //AGRUPAR TODA LA INFORMACION EN UNA SOLA VARIABLE
                String datos = (":" + txtNombre.Text + ":" + txtCelular.Text + ":" + txtCorreo.Text + ":" + txtEdad.Text + ":" + txtDomicilio.Text);

                //CREANDO UN ESCRITOR DE LINEAS
                StreamWriter escritorLineas = File.AppendText(nombreArhivo);
                //ENVIANDO LOS DATOS AL ARCHIVO
                escritorLineas.WriteLine(datos);
                escritorLineas.Close();

                MessageBox.Show("Datos actualizados correctamente.", "Alerta");

                Form1.recargar();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Falta informacion.","Alerta");
            }
        }

        private void formModificar_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(cerrar);
        }

        private void cerrar(object sender, EventArgs e)
        {

        }

        //EVITANDO QUE SE PRESIONE : Y ARRUINE EL CODIGO.
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ':')
            {
                e.Handled = true;
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ':')
            {
                e.Handled = true;
            }
        }

        private void txtDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ':')
            {
                e.Handled = true;
            }
        }
    }
}
