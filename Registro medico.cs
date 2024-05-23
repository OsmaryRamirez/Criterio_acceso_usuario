using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidadaa;
using Capa_Negocioo;
using Capa_Datoss;

namespace Capa_Presentacionn
{
    public partial class Registro_medico : Form
    {
        public Registro_medico()
        {
            InitializeComponent();
        }

        private void LimpiaTexto()
        {
            txt_nombre_medico.Text = "";
            txt_apellido_medico.Text = "";
            txt_cedula_medico.Text = "";
            txt_especialidad_medico.Text = "";
            txt_telefono_medico.Text = "";
            txt_correo_medico.Text = "";
            cmbusuario.Text = "";

        }

        private void ESTADOTEXTO(bool LESADO)
        {
            txt_nombre_medico.Enabled = LESADO;
            txt_apellido_medico.Enabled = LESADO;
            txt_cedula_medico.Enabled = LESADO;
            txt_especialidad_medico.Enabled = LESADO;
            txt_telefono_medico.Enabled = LESADO;
            txt_correo_medico.Enabled = LESADO;
            cmbusuario.Enabled = LESADO;
        }
        private void CARGAR_USUARIO()
        {
            Dusuario datos = new Dusuario();
            cmbusuario.DataSource = datos.Listar_Usuario();
            cmbusuario.ValueMember = "ID_usuario";
            cmbusuario.DisplayMember = "Nom_usuario";

        }

        private void formato_pac()
        {
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].HeaderText = "CODIGO";

            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[1].HeaderText = "NOMBRE DE USUARIO";

            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[2].HeaderText = "NOMBRE";

            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[3].HeaderText = "APELLIDO";

            dataGridView1.Columns[4].Width = 250;
            dataGridView1.Columns[4].HeaderText = "CEDULA";

            dataGridView1.Columns[5].Width = 250;
            dataGridView1.Columns[5].HeaderText = "ESPECIALIDAD";

            dataGridView1.Columns[6].Width = 250;
            dataGridView1.Columns[6].HeaderText = "TELEFONO";

            dataGridView1.Columns[7].Width = 250;
            dataGridView1.Columns[7].HeaderText = "CORREO";

            dataGridView1.Columns[8].Visible = false;

        }
        private void Listar_medico(string valor)
        {
            try
            {
                Dmedico datos = new Dmedico();
                dataGridView1.DataSource = datos.ListarMedicos(valor);
                this.formato_pac();
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error más amigable para los usuarios
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {

            this.LimpiaTexto();
            this.ESTADOTEXTO(true);
            txt_nombre_medico.Focus();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_nombre_medico.Text == string.Empty)
            {
                MessageBox.Show("Este campo es obligatorio.", "Aviso importante",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {
                string respuesta = "";
                Emedico eMedico = new Emedico();
                eMedico.Codigo_med = 0;
                eMedico.ID_usuario = Convert.ToInt32(cmbusuario.SelectedValue);
                eMedico.Nombre = txt_nombre_medico.Text.Trim();
                eMedico.Apellido = txt_apellido_medico.Text.Trim();
                eMedico.Cedula = txt_cedula_medico.Text.Trim();
                eMedico.Especialidad = txt_especialidad_medico.Text.Trim();
                eMedico.Telefono = txt_telefono_medico.Text.Trim();
                eMedico.Correo = txt_correo_medico.Text.Trim();


                Dmedico dat = new Dmedico();
                respuesta = dat.GuardarMedico(1, eMedico);


                if (respuesta == "Ok")
                {
                    this.Listar_medico("%");
                    MessageBox.Show("Datos guardados correctamente", "Aviso del sistema",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.LimpiaTexto();
                    this.ESTADOTEXTO(false);

                    txt_nombre_medico.Text = "";
                    txt_apellido_medico.Text = "";
                    txt_cedula_medico.Text = "";
                    txt_especialidad_medico.Text = "";
                    txt_telefono_medico.Text = "";
                    txt_correo_medico.Text = "";


                }
                else
                {
                    MessageBox.Show(respuesta, "Aviso del sistema ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Registro_medico_Load(object sender, EventArgs e)
        {
            this.CARGAR_USUARIO();
            this.Listar_medico("%");
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

            if (txt_nombre_medico.Text == string.Empty)
            {
                MessageBox.Show("Los campos son obligatorios.", "Aviso importante",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string respuesta = "";
                Emedico eMedico = new Emedico();
                // Obtén el ID del cliente seleccionado desde el DataGridView
                DataGridViewRow filaSeleccionada = dataGridView1.CurrentRow;
                if (filaSeleccionada != null)
                {
                    eMedico.Codigo_med = Convert.ToInt32(filaSeleccionada.Cells["Codigo_med"].Value); // Ajusta el nombre de la columna según tu DataGridView
                    eMedico.ID_usuario = Convert.ToInt32(filaSeleccionada.Cells["ID_usuario"].Value);
                }
                else
                {
                    MessageBox.Show("Selecciona un cliente para actualizar.", "Aviso importante",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sal del método si no hay fila seleccionada
                }

                eMedico.Nombre = txt_nombre_medico.Text.Trim();
                eMedico.Apellido = txt_apellido_medico.Text.Trim();
                eMedico.Cedula = txt_cedula_medico.Text.Trim();
                eMedico.Especialidad = txt_especialidad_medico.Text.Trim();
                eMedico.Telefono = txt_telefono_medico.Text.Trim();
                eMedico.Correo = txt_correo_medico.Text.Trim();
                respuesta = Nmedico.GuardarMedico(1, eMedico);
                this.Listar_medico("%");

                if (respuesta == "Ok")
                {
                    MessageBox.Show("Datos guardados correctamente", "Aviso del sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiaTexto();
                    this.ESTADOTEXTO(true);
                }
                else
                {
                    MessageBox.Show(respuesta, "Aviso del sistema",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Limpia los campos de entrada
                txt_nombre_medico.Text = "";
                txt_apellido_medico.Text = "";
                txt_cedula_medico.Text = "";
                txt_especialidad_medico.Text = "";
                txt_telefono_medico.Text = "";
                txt_correo_medico.Text = "";

            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listar_medico(txt_buscar.Text.Trim());
        }




    }
}
    

