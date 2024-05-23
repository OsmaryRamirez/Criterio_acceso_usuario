using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Entidadaa;
using Capa_Negocioo;
 

namespace Capa_Presentacionn
{
    public partial class Inicio : Form
    {
        Eusuarios obje = new Eusuarios();
        Nusuario objn = new Nusuario();
        Registro_medico registro = new Registro_medico();

        public static string Nom_usuario;
        public static string Contraseña;

        void listar()
        {
            DataTable dt = new DataTable();
            obje.Nom_usuario = txt_usuario.Text;
            obje.Contraseña = txt_contraseña.Text;
            dt = objn.nusuario(obje);

            if (dt.Rows.Count > 0)
            {

                MessageBox.Show( "Bienvenido " + dt.Rows[0][3].ToString() , "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Nom_usuario = dt.Rows[0][1].ToString();
                Contraseña = dt.Rows[0][2].ToString();

                registro.ShowDialog();
                Inicio login = new Inicio();
                login.ShowDialog();
                if (login.DialogResult == DialogResult.OK)
                    Application.Run(new Registro_medico());

                txt_usuario.Clear();
                txt_contraseña.Clear();


            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

            public Inicio()
        {
            InitializeComponent();
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_acceder_Click(object sender, EventArgs e)
        {
            listar();
        }
    }
}
