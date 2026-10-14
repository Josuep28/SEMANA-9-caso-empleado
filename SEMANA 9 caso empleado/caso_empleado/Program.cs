using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_empleado
{
    internal class Program
    {
        internal class Program
        {
            static int maxEmp = 50;
            static string[] nombresEmp = new string[maxEmp];
            static string[] correoEmp = new string[maxEmp];
            static int contEmp = 0;
            static string rutaArchivo = "empleados_datos.txt"
    static public void Titulo()
            {
                Console.WriteLine("*******************************");
                Console.WriteLine("****SISTEMA DE ARREGLOS Y CADENAS****");
                Console.WriteLine("*******************************");
            }
            static public void RegistrarEmp()
            {
                Console.WriteLine("******REGISTRO DE EMPLEADO******");
                if (contEmp >= maxEmp)
                {
                    Console.WriteLine("Capacidad maxima alcanzada");
                    return;
                }
                Console.WriteLine("Ingresar nombres y apellidos: ");
                string nombres = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(nombres))
                {
                    Console.WriteLine("El nombre no puede estar vacío");
                    return;
                }
                string nombresMayus = nombres.ToUpper();
                string[] partes = nombresMayus.Split(' ');
                string primerNombre = partes[0];
                string ultimoApellido = partes[partes.Length - 1];
                string correo = $"{primerNombre.ToLower()}{ultimoApellido.ToLower()}@upn.edu.pe";
                nombresEmp[contEmp] = nombresMayus;
                correoEmp[contEmp] = correo;
                contEmp++;
                Console.WriteLine("Empleado registrado correctamente.");
                Console.WriteLine("Correo corporativo: " + correo);
            }
            static public void buscarEmp()
            {
                Console.WriteLine("******BUSCAR EMPLEADO******");
                Console.WriteLine("***************************");
                if (contEmp == 0)
                {
                    Console.WriteLine("No hay empleados registrados");
                    return;
                }
                Console.WriteLine("Ingrese el nombre del empleado");
                string buscarNombre = Console.ReadLine()?.Trim().ToUpper();
                if (string.IsNullOrEmpty(buscarNombre))
                    return;
                bool encontrado = false;
                for (int i = 0; i < contEmp; i++)
                {
                    if (nombresEmp[i].Contains(buscarNombre))
                    {
                        Console.WriteLine("Nombre: " + nombresEmp[i] + "correo: " + correoEmp[i]);
                        encontrado = true;
                    }
                }
                if (!encontrado)
                    Console.WriteLine("Empleado no encontrado");
            }
            static public void ordenarAlfa()
            {
                if (contEmp <= 1)
                {
                    Console.WriteLine("No hay suficientes empleados para ordenar");
                    return;
                }
                for (int i = 0; i < contEmp - 1; i++)
                {
                    for (int j = 0; j < contEmp - 1 - i; j++)
                    {
                        if (string.Compare(nombresEmp[j], nombresEmp[j + 1]) > 0)
                        {
                            string tempNombre = nombresEmp[j];
                            nombresEmp[j] = nombresEmp[j + 1];
                            nombresEmp[j + 1] = tempNombre;
                            string tempCorreo = correoEmp[j];
                            correoEmp[j] = correoEmp[j + 1];
                            correoEmp[j + 1] = tempCorreo;
                        }
                    }
                }
            }
            static public void Guardar_datos_archivo()
            {
                Console.WriteLine("*******GUARDAR DATOS EN ARCHIVO*******");
                Console.WriteLine("*************************************");
                if (contEmp == 0)
                {
                    Console.WriteLine("No hay empleados registrados para guardar.");
                    return;
                }
                string rutaArchivo = "empleados.txt";
                using (System.IO.StreamWriter archivo = new System.IO.StreamWriter(rutaArchivo))
                {
                    for (int i = 0; i < contEmp; i++)
                    {
                        archivo.WriteLine($"{nombresEmp[i]},{correoEmp[i]}");
                    }
                }
                Console.WriteLine($"Datos guardados en el archivo '{rutaArchivo}' correctamente.");
            }
            static public void mostrar()
            {
                Console.WriteLine("******Listado de empleados******");
                Console.WriteLine("********************************");
                if (contEmp == 0)
                {
                    Console.WriteLine("No hay empleados registrados");
                    return;
                }
                Console.WriteLine("Nombres y apellidos\t\tCorreo corporativo");
                for (int i = 0; i < contEmp; i++)
                {
                    Console.WriteLine(nombresEmp[i] + "\t\t" + correoEmp[i]);
                }
            }
            static public void LeerDatos()
            {
                Console.WriteLine("*******LEER DATOS DESDE ARCHIVO*******");
                Console.WriteLine("*************************************");
                if (!System.IO.File.Exists(rutaArchivo))
                {
                    Console.WriteLine($"El archivo '{rutaArchivo}' no existe.");
                    return;
                }
                string[] lineas = System.IO.File.ReadAllLines(rutaArchivo);
                if (lineas.Length == 0)
                {
                    Console.WriteLine("El archivo está vacío.");
                    return;
                }
                Console.WriteLine("Nombres y Apellidos\t\tCorreo corporativo");
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');
                    if (datos.Length == 2)
                    {
                        Console.WriteLine($"Empleado: {datos[0]} - Correo: {datos[1]}");
                    }
                }
            }
            static public void CargarDatos()
            {
                Console.WriteLine("********Cargar datos desde archivo*******");
                Console.WriteLine("*****************************************");
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine("Archivo no existe");
                    return;
                }
                string[] lineas = File.ReadAllLines(rutaArchivo);
                for (int i = 0; i < lineas.Length && contEmp < maxEmp; i++)
                {
                    string[] partes = lineas[i].Split(',');
                    if (partes.Length == 2)
                    {
                        nombresEmp[contEmp] = partes[0];
                        correoEmp[contEmp] = partes[1];
                        contEmp++;
                    }
                }
            }
            static void Main(string[] args)
            {
                int opc = 0;
                while (opc != 8)
                {
                    Console.Clear();
                    Console.WriteLine("[1]Registrar Empleado: ");
                    Console.WriteLine("[2]Buscar Empleado: ");
                    Console.WriteLine("[3]Ordenar alfabeticamente: ");
                    Console.WriteLine("[4]Mostrar empleados: ");
                    Console.WriteLine("[5]Guardar datos en archivo: ");
                    Console.WriteLine("[6]Leer datos desde archivo: ");
                    Console.WriteLine("[7]Cargar datos desde arhivo: ");
                    Console.WriteLine("Ingresar opcion ");

                    if (!int.TryParse(Console.ReadLine(), out opc))
                    {
                        Console.WriteLine("Error! Ingrese una opcion numerica");
                        continue;
                    }
                    switch (opc)
                    {
                        case 1:
                            RegistrarEmp();
                            break;
                        case 2:
                            buscarEmp();
                            break;
                        case 3:
                            ordenarAlfa();
                            break;
                        case 4:
                            mostrar();
                            break;
                        case 5:
                            Guardar_datos_archivo();
                            break;
                        case 6:
                            LeerDatos();
                            break;
                        case 7:
                            CargarDatos();
                            break;
                        default:
                            Console.WriteLine("Opcion no válida");
                            break;
                    }
                    Console.ReadKey();
                }
            }
        }
    }
