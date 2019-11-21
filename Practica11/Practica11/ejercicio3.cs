using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica11
{
    class ejercicio3
    {
        static void Main(string[] args)
        {
            FileStream stream;
            BinaryWriter escribir;
            BinaryReader leer;
            int ancho = 20 + 9 + 4 + 16;
            int num1 = 0;
            int op;
            try
            {
                stream = new FileStream("ejericio3.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                escribir = new BinaryWriter(stream);
                leer = new BinaryReader(stream);
                num1 = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / ancho));
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Agregar alumno");
                    Console.WriteLine("2. Mostrar alumno");
                    Console.WriteLine("3. Buscar alumno");
                    Console.WriteLine("4. Salir");
                    op = Convert.ToInt32(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            try
                            {
                                num1 = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / ancho));
                                escribir.BaseStream.Seek(num1 * ancho, SeekOrigin.Begin);
                                Console.WriteLine("Datos de la persona:");
                                string carnet;
                                do
                                {
                                    Console.WriteLine("Carnet: ");
                                    carnet = Console.ReadLine();
                                } while (carnet.Length > 9);
                                Console.Write("Nombre: (20 caracteres maximo) ");
                                string nombre = Console.ReadLine();
                                if (nombre.Length > 20)
                                {
                                    nombre = nombre.Substring(0, 20);
                                }
                                else
                                {
                                    nombre.PadRight(20, ' ');
                                }
                                Console.Write("Edad:");
                                int edad = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("CUM:");
                                decimal cum = Convert.ToDecimal(Console.ReadLine());
                                escribir.Write(carnet);
                                escribir.Write(nombre);
                                escribir.Write(edad);
                                escribir.Write(cum);
                                Console.WriteLine();
                                Console.WriteLine("Datos almacenados...");
                                Console.ReadKey();
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 2:
                            try
                            {

                                Console.WriteLine("1. Todos los alumnos");
                                Console.WriteLine("2. Por CUM");
                                op = Convert.ToInt32(Console.ReadLine());
                                switch (op)
                                {
                                    case 1:
                                        try
                                        {
                                            try
                                            {
                                                num1 = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / ancho));
                                                escribir.BaseStream.Seek(0, SeekOrigin.Begin);
                                                Console.Clear();
                                                Console.WriteLine("Datos:");
                                                Console.WriteLine();
                                                Console.WriteLine("{0, -4} {1, -9} {2, -20} {3,-10} {4}", "N°", "Carnet", "Nombre", "edad", "CUM");
                                                int num = 1;

                                                do
                                                {
                                                    string carnet = leer.ReadString();
                                                    string nombre = leer.ReadString();
                                                    int edad = leer.ReadInt32();
                                                    decimal cum = leer.ReadDecimal();
                                                    Console.Write("{0, -5}", num);
                                                    Console.Write("{0, -10}", carnet);
                                                    Console.Write("{0, -21}", nombre);
                                                    Console.Write("{0, -11}", edad);
                                                    Console.Write("{0}", cum);
                                                    Console.WriteLine();
                                                    leer.BaseStream.Seek(num * ancho, SeekOrigin.Begin);
                                                    num++;
                                                } while (true);
                                            }
                                            catch (Exception)
                                            {
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            throw;
                                        }
                                        Console.WriteLine();
                                        Console.WriteLine("Presione cualquier tecla para regresar al menu principal");
                                        Console.ReadKey();
                                        break;
                                    case 2:
                                        decimal lim1 = 0, lim2 = 0;
                                        try
                                        {
                                            try
                                            {

                                                Console.WriteLine("Ingrese el rango de CUM que desea visualizar");
                                                Console.WriteLine("1. 8.00 - 10.00");
                                                Console.WriteLine("2. 7.00 - 7.99");
                                                Console.WriteLine("3. 5.00 - 6.99");
                                                Console.WriteLine("4. 3.00 - 4.99");
                                                Console.WriteLine("5. 0.00 - 2.99");
                                                op = Convert.ToInt32(Console.ReadLine());
                                                switch (op)
                                                {
                                                    case 1:
                                                        lim1 = 8.00m;
                                                        lim2 = 10.00m;
                                                        break;
                                                    case 2:
                                                        lim1 = 7.00m;
                                                        lim2 = 7.99m;
                                                        break;
                                                    case 3:
                                                        lim1 = 5.00m;
                                                        lim2 = 6.99m;
                                                        break;
                                                    case 4:
                                                        lim1 = 3.00m;
                                                        lim2 = 4.99m;
                                                        break;
                                                    case 5:
                                                        lim1 = 0.00m;
                                                        lim2 = 2.99m;
                                                        break;
                                                }
                                                num1 = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / ancho));
                                                escribir.BaseStream.Seek(0, SeekOrigin.Begin);
                                                Console.Clear();
                                                Console.WriteLine("Datos:");
                                                Console.WriteLine();
                                                Console.WriteLine("{0, -4} {1, -9} {2, -20} {3,-10} {4}", "N°", "Carnet", "Nombre", "edad", "CUM");
                                                int num = 1;

                                                do
                                                {

                                                    string carnet = leer.ReadString();
                                                    string nombre = leer.ReadString();
                                                    int edad = leer.ReadInt32();
                                                    decimal cum = leer.ReadDecimal();
                                                    if (cum > lim1 && cum < lim2)
                                                    {
                                                        Console.Write("{0, -5}", num);
                                                        Console.Write("{0, -10}", carnet);
                                                        Console.Write("{0, -21}", nombre);
                                                        Console.Write("{0, -11}", edad);
                                                        Console.Write("{0}", cum);
                                                        Console.WriteLine();
                                                    }
                                                    leer.BaseStream.Seek(num * ancho, SeekOrigin.Begin);
                                                    num++;
                                                } while (true);
                                            }
                                            catch (Exception)
                                            {
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            throw;
                                        }
                                        Console.WriteLine();
                                        Console.WriteLine("Presione cualquier tecla para regresar al menu principal");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine();
                            try
                            {
                                try
                                {
                                    Console.WriteLine("Ingrese el carnet de la persona a consultar");
                                    string c = Console.ReadLine();
                                    escribir.BaseStream.Seek(0, SeekOrigin.Begin);
                                    Console.WriteLine("Datos:");
                                    Console.WriteLine();
                                    Console.WriteLine("{0, -4} {1, -9} {2, -20} {3,-10} {4}", "N°", "Carnet", "Nombre", "edad", "CUM");
                                    int num = 1;
                                    do
                                    {
                                        string carnet = leer.ReadString();
                                        string nombre = leer.ReadString();
                                        int edad = leer.ReadInt32();
                                        decimal cum = leer.ReadDecimal();
                                        if (c == carnet)
                                        {
                                            Console.Write("{0, -5}", num);
                                            Console.Write("{0, -10}", carnet);
                                            Console.Write("{0, -21}", nombre);
                                            Console.Write("{0, -11}", edad);
                                            Console.Write("{0}", cum);
                                            Console.WriteLine();
                                        }
                                        leer.BaseStream.Seek(num * ancho, SeekOrigin.Begin);
                                        num++;
                                        Console.ReadKey();
                                    } while (true);
                                }
                                catch (Exception)
                                {
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                            break;
                    }
                } while (op != 4);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}