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
    public partial class formAgregar : Form
    {
        //NOMBRE DEL ARCHIVO
        public static string nombreArhivo = "datos.txt";
        public formAgregar()
        {
            InitializeComponent();
        }

        //ENVIANDO LOS DATOS INGRESADOS AL ARCHIVO '.TXT'
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //VALIDA SI TODOS LOS TEXBOX TIENEN INFORMACION
            if (txtNombre.Text != "" && txtCelular.Text != "" && txtCorreo.Text != "" && txtDomicilio.Text != "" && txtDomicilio.Text != "")
            {
                //AGRUPAR TODA LA INFORMACION EN UNA SOLA VARIABLE
                String datos = (":" + txtNombre.Text + ":" + txtCelular.Text + ":" + txtCorreo.Text + ":" + txtEdad.Text + ":" + txtDomicilio.Text);

                //CREANDO UN ESCRITOR DE LINEAS
                StreamWriter escritorLineas = File.AppendText(nombreArhivo);
                //ENVIANDO LOS DATOS AL ARCHIVO
                escritorLineas.WriteLine(datos);
                escritorLineas.Close();

                MessageBox.Show("Datos agregados correctamente.", "Alerta");

                Form1.recargar();
                this.Close();
            }
            else
            {
                MessageBox.Show("Falta informacion.", "Alerta");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
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
