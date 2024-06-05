using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace VectoresParalelos
{
    internal class Program
    {
        static int sup = 0;
        static int contAlumnos = 0;
        static string[] nombre = new string[50];
        static int[] libreta = new int[50];
        static double[] notas = new double[50];

        static string[] nombreSup = new string[50];
        static int[] libretaSup = new int[50];
        static double[] notasSup = new double[50];
        static void Main(string[] args)
        {
            int libretaa;
            string nombree;
            double notaa;
            int op = 0;
            int opLibr;

            Console.WriteLine("Ingrese numero de libreta");
            libretaa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese nombre");
            nombree = Console.ReadLine();
            Console.WriteLine("Ingrese la nota");
            notaa = Convert.ToDouble(Console.ReadLine());

            while (libretaa != -1)
            {
                Console.Clear();
                IngresarDatos(libretaa, nombree, notaa);

                Console.WriteLine("Ingrese numero de libreta (-1 para salir)");
                libretaa = Convert.ToInt32(Console.ReadLine());
                if (libretaa != -1)
                {
                    Console.WriteLine("Ingrese nombre");
                    nombree = Console.ReadLine();
                    Console.WriteLine("Ingrese la nota");
                    notaa = Convert.ToDouble(Console.ReadLine());
                }

            }
            double prom = CalcularPromedio(notas);
            Console.Clear();
            Console.WriteLine("El promedio es: " + prom);
            Console.WriteLine("");
            Console.WriteLine("Alumnos que superaron el promedio:");
            SuperaronPromedio(prom, libreta, nombre, notas);
            

            Console.WriteLine("Dese buscar un alumno?");
            Console.WriteLine("1.SI\n2.NO");
            op = Convert.ToInt32(Console.ReadLine());
            if(op == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Ingrese el numero de libreta");
                opLibr = Convert.ToInt32(Console.ReadLine());
                int res = BuscarAlumno(opLibr);

                if ( res != -1)
                {
                    Console.WriteLine("NRO LIBRETA: " + libreta[res] + " | NOMBRE: " + nombre[res] + " | NOTA: " + notas[res]);
                }
                else Console.WriteLine("Alumno no existente");
            }
            Console.ReadKey();
        }
        public static void IngresarDatos(int lib, string nom, double not)
        {
            if (contAlumnos <= 50)
            {
                nombre[contAlumnos] = nom;
                libreta[contAlumnos] = lib;
                notas[contAlumnos] = not;
                contAlumnos++;
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

            MostrarSuperaronPromedio(libretaSup, nombreSup, notasSup);

        }
        public static void OrdenarSupPromedio(int[] libnreta, string[] nombre, double[] notas)
        {
            int aux, i, j;
            string auxN;
            double auxNota;

            for (i = 0; i < sup - 1; i++)
            {
                for (j = i + 1; j < sup; j++)
                {
                    if (libnreta[i] < libnreta[j])
                    {
                        aux = libnreta[i];
                        libnreta[i] = libnreta[j];
                        libnreta[j] = aux;

                        auxN = nombre[i];
                        nombre[i] = nombre[j];
                        nombre[j] = auxN;

                        auxNota = notas[i];
                        notas[i] = notas[j];
                        notas[j] = auxNota;
                    }

                }

            }
        }
        public static void MostrarSuperaronPromedio(int[] libretaS, string[] nombreS, double[] notaS)
        {
            for (int i = 0; i < sup; i++)
            {
                Console.WriteLine("NRO LIBRETA: " + libretaS[i] + " | NOMBRE: " + nombreS[i] + " | NOTA: " + notaS[i]);
            }
        }
        
        public static int BuscarAlumno(int alumno)
        {
            int pos = -1;
            int i = 0;
            while(pos == -1 &&  i < contAlumnos)
            {
                if (libreta[i] == alumno) 
                {
                    pos = i;
                }
                i++;
            }
            return pos;
        }
    }
}
