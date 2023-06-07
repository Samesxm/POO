namespace proyectoX
{
    public partial class Form1 : Form
    {
        //NOMBRE DEL ARCHIVO
        public static string nombreArchivo = "datos.txt";
        static formModificar modificar = new formModificar();
        string datos = "";
        public static void recargar()
        {
            StreamReader lectorLineas = new StreamReader(nombreArchivo);
            String linea;
            linea = lectorLineas.ReadLine();

            try
            {
                dgvDatos.Rows.Clear();
                while (linea != null)
                {
                    //DIVIDIENDO LA LINEA DEL BLOC DE NOTAS EN LOS ESPACIOS UTILIZADOS EN DATAGRIDVIEW
                    String[] lineaX = linea.Split(":");

                    //ASIGNANDO LOS DATOS AL DATAGRIDVIEW
                    dgvDatos.Rows.Add(lineaX[1], lineaX[2], lineaX[3], lineaX[4], lineaX[5]);

                    //REINICIANDO LA VARIABLE
                    linea = lectorLineas.ReadLine();
                }

                lectorLineas.Close();
            }catch(Exception e)
            {
                MessageBox.Show("Problema: " + e.Message, "Alerta" + "\nNo se encontraron datos. Verifique la fuente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }

            
        }
        public Form1()
        {
            InitializeComponent();
            recargar();        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //MANDAR A LLAMAR AL FORMULARIO 'REGISTRO' CUANDO SE PRESIONE EL BOTON AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formAgregar Agregar = new formAgregar();
            Agregar.Show();
            Agregar.TopMost = true;
        }

        //MANDAR A LLAMAR AL FORMULARIO 'MODIFICAR' CUANDO SE PRESIONE EL BOTON MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int numCol = dgvDatos.RowCount - 1;
            //CONFIRMANDO LA MODIFICACION DEL USUARIO ELEGIDO.
            if (MessageBox.Show("Seguro que quieres modificar este usurio?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                //numCol ES EL VALOR TOTAL DE FILAS QUE EXISTEN
                
                dgvDatos.Rows.RemoveAt(dgvDatos.CurrentRow.Index);
                for (int fila = 0; fila < dgvDatos.Rows.Count - 1; fila++)
                {
                    for (int col = 0; col < dgvDatos.Rows[fila].Cells.Count; col++)
                    {
                        string celda = dgvDatos.Rows[fila].Cells[col].Value.ToString();
                        datos = (datos + ":" + celda);
                    }

                    //SI ES LA FILA NUMERO 0, DEBE CREAR EL ARCHIVO DE NUEVO.
                    if (fila == 0)
                    {
                        StreamWriter escritorArchivo = new StreamWriter(nombreArchivo);
                        escritorArchivo.WriteLine(datos);
                        escritorArchivo.Close();
                    }
                    //SI EL ARCHIVO YA TIENE UNA LINEA INICIADA, SE DEBEN AGREGAR LAS SIGUIENTES
                    else
                    {
                        //CREANDO UN ESCRITOR DE LINEAS
                        StreamWriter escritorLineas = File.AppendText(nombreArchivo);
                        //ENVIANDO LOS DATOS AL ARCHIVO
                        escritorLineas.WriteLine(datos);
                        escritorLineas.Close();
                    }

                    //REINICIAR LA VARIABLE DATOS
                    datos = "";
                }
                modificar.Show();
            }

            int newNumCol = dgvDatos.RowCount;

            if (numCol > newNumCol)
            {
                MessageBox.Show("HAY MENOS CULUMNAS");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //CONFIRMANDO LA ELIMINCACION DEL USUARIO ELEGIDO.
            if (MessageBox.Show("Seguro que quieres eliminar este usurio?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                dgvDatos.Rows.RemoveAt(dgvDatos.CurrentRow.Index);

                for (int fila = 0; fila < dgvDatos.Rows.Count - 1; fila++)
                    {
                        for (int col = 0; col < dgvDatos.Rows[fila].Cells.Count; col++)
                        {
                            string celda = dgvDatos.Rows[fila].Cells[col].Value.ToString();
                            datos = (datos + ":" + celda);
                        }

                        //SI ES LA FILA NUMERO 0, DEBE CREAR EL ARCHIVO DE NUEVO.
                        if (fila == 0)
                        {
                            StreamWriter escritorArchivo = new StreamWriter(nombreArchivo);
                            escritorArchivo.WriteLine(datos);
                            escritorArchivo.Close();
                        }
                        //SI EL ARCHIVO YA TIENE UNA LINEA INICIADA, SE DEBEN AGREGAR LAS SIGUIENTES
                        else
                        {
                            //CREANDO UN ESCRITOR DE LINEAS
                            StreamWriter escritorLineas = File.AppendText(nombreArchivo);
                            //ENVIANDO LOS DATOS AL ARCHIVO
                            escritorLineas.WriteLine(datos);
                            escritorLineas.Close();
                        }

                        //REINICIAR LA VARIABLE DATOS
                        datos = "";
                    }

                MessageBox.Show("Usuario eliminado correctamente.", "ALerta");

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //OBTNER LA FILA QUE SE ENCUENTRE SELECCIONADA
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //HABILITAR LOS BOTONES 'MODIFICAR' Y 'ELIMINAR'
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

            //ENVIAR LOS DATOS YA EXISTENTES A LOS TEXBOX PARA MODIFICAR.
            try
            {
                //VALIDAR SI LA FILA SELECCIONADA ES VALIDA.
                if (dgvDatos.Rows[e.RowIndex].Cells[0].Value is null)
                {
                    MessageBox.Show("La fila seleccionada esta vacia. Por favor, seleccione otra.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    //DESHABILITAR BOTENES DE 'MODIFICAR' Y 'ELIMINAR' AL SELECCIONAR UNA FILA VACIA.
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;

                }
                else
                {
                    modificar.txtNombre.Text = dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString();
                    modificar.txtCelular.Text = dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    modificar.txtCorreo.Text = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
                    modificar.txtEdad.Text = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                    modificar.txtDomicilio.Text = dgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
                //modificar.txtNombre.Text = dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString();
                //modificar.txtCelular.Text = dgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString();
                //modificar.txtCorreo.Text = dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
                //modificar.txtEdad.Text = dgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString();
                //modificar.txtDomicilio.Text = dgvDatos.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("La fila seleccionada esta vacia.","Alerta");
            }
            
        }
    }
}