using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectoresPWindForms
{
    public partial class Form1 : Form
    {
        static int sup = 0;
        static int contAlumnos = 0;
        static string[] nombre = new string[50];
        static int[] libreta = new int[50];
        static double[] notas = new double[50];

        static string[] nombreSup = new string[50];
        static int[] libretaSup = new int[50];
        static double[] notasSup = new double[50];
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            int libreta;
            double nota;
            string nombre;

            libreta = Convert.ToInt32(tbNroLibreta.Text);
            nota = Convert.ToDouble(tbNota.Text);
            nombre = tbNombre.Text;
            IngresarDatos(libreta, nombre, nota);

            tbNombre.Clear();
            tbNota.Clear();
            tbNroLibreta.Clear();

        }

        public void IngresarDatos(int lib, string nom, double not)
        {
            if (contAlumnos <= 50)
            {
                nombre[contAlumnos] = nom;
                libreta[contAlumnos] = lib;
                notas[contAlumnos] = not;
                contAlumnos++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string cadena = $"Promedio: {CalcularPromedio(notas):f2}";
            listBox1.Items.Add(cadena);
            for (int i = 0; i < contAlumnos; i++)
            {
                listBox1.Items.Add("NRO LIBRETA: "+libreta[i] + "    " + "NOMBRE: " + nombre[i] + "    " + "NOTA: " + notas[i]);
            }
        }

        public static double CalcularPromedio(double[] nota)
        {
            double promedio = 0, acum = 0;
            for (int i = 0; i < contAlumnos; i++)
            {
                acum = acum + nota[i];
            }
            promedio = acum / contAlumnos;

            return promedio;
        }

        public static void SuperaronPromedio(double prom, int[] libnreta, string[] nombre, double[] notas)
        {
            sup =0;
            string auxNombre;
            int aux2Libreta = 0;
            double aux3Nota = 0;
            for (int i = 0; i < contAlumnos; i++)
            {
                auxNombre = nombre[i];
                aux2Libreta = libnreta[i];
                aux3Nota = notas[i];

                if (aux3Nota > prom)
                {
                    nombreSup[sup] = auxNombre;
                    libretaSup[sup] = aux2Libreta;
                    notasSup[sup] = aux3Nota;
                    sup++;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SuperaronPromedio(CalcularPromedio(notas), libreta, nombre, notas);
            string cadena = $"Promedio: {CalcularPromedio(notas):f2}";
            listBox1.Items.Add(cadena);
            for (int i = 0; i < sup; i++)
            {
                listBox1.Items.Add("NRO LIBRETA: " + libretaSup[i] + "    " + "NOMBRE: " + nombreSup[i] + "    " + "NOTA: " + notasSup[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int aux, i, j;
            string auxN;
            double auxNota;

            for (i = 0; i < sup - 1; i++)
            {
                for (j = i + 1; j < sup; j++)
                {
                    if (libretaSup[i] < libretaSup[j])
                    {
                        aux = libretaSup[i];
                        libretaSup[i] = libretaSup[j];
                        libretaSup[j] = aux;

                        auxN = nombreSup[i];
                        nombreSup[i] = nombreSup[j];
                        nombreSup[j] = auxN;

                        auxNota = notasSup[i];
                        notasSup[i] = notasSup[j];
                        notasSup[j] = auxNota;
                    }

                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
