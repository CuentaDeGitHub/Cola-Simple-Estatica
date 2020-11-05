using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ColaSimpleEstatica
{
    public partial class Form1 : Form
    {
        Cola MiCola;
        public Form1()
        {
            InitializeComponent();
            groupBox1.Visible = false;
        }

        private void btnEncolar_Click(object sender, EventArgs e)
        {
            try
            {
                string dato = txtDatos.Text;
                if(dato == "")
                {
                    MessageBox.Show("Dato no valido");
                    txtDatos.Clear();
                    return;
                }
                MiCola.Encolar(dato);
                lblCola.Text = MiCola.Imprimir();
                txtDatos.Clear();
            }
            catch
            {
                MessageBox.Show("Bruh");
            }

        }

        private void btnDesencolar_Click(object sender, EventArgs e)
        {
            try
            {
                MiCola.Desencolar();
                lblCola.Text = MiCola.Imprimir();
                txtDatos.Clear();
            }
            catch
            {
                MessageBox.Show("Bruh");
            }

        }

        private void btnFrente_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El dato en frente es : " + MiCola.Front());
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int maximo = int.Parse(txtTamaño.Text);
            if(maximo <= 0)
            {
                MessageBox.Show("Tamaño minimo : 1");
                txtTamaño.Clear();
                return;
            }
            MiCola = new Cola(maximo);
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Dialogo = new FolderBrowserDialog();
            if (Dialogo.ShowDialog() == DialogResult.OK)
            {
                string dato = lblCola.Text;
                int maximo = MiCola.arregloCola.Length;
                string[] DatosYTamaño = { dato, maximo +""};
                string nombreDelArchivo;
                if(txtArchivo.Text == "")
                {
                    nombreDelArchivo = "Cola";
                }
                else
                {
                    nombreDelArchivo = txtArchivo.Text;
                }
                string ruta = Dialogo.SelectedPath + "\\" + nombreDelArchivo + ".txt";
                using (var writer = new StreamWriter(ruta))
                {
                    writer.Close();
                }
                File.WriteAllLines(ruta, DatosYTamaño);
                MessageBox.Show("Datos guardados en la ruta : "+ ruta);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Seleccionar = new OpenFileDialog();
            if (Seleccionar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    int contador = 0;
                    string ruta = Seleccionar.FileName;
                    string[] DatosYTamaño = File.ReadAllLines(ruta);
                    string linea = DatosYTamaño[0];
                    int maximo = int.Parse(DatosYTamaño[1]);
                    string[] Lista = linea.Split(',');
                    MiCola = new Cola(maximo);
                    foreach (string i in Lista)
                    {
                        MiCola.Encolar(Lista[contador]);
                        contador++;

                    }
                    lblCola.Text = MiCola.Imprimir();
                }
                catch
                {
                    MessageBox.Show("Error al cargar el archivo");
                }
               
            }
        }

            
    }
}
