using System;
using System.Collections.Generic;
using System.IO;
using ProyectoArquitectura.Models;

namespace ProyectoArquitectura.Utilidades
{
    /// Clase encargada de manejar la lectura y escritura de archivos físicos en formato CSV.
    /// Utilizamos System.IO para manipular líneas de texto separadas por comas.
    public class GestorArchivosCsv
    {
        /// Escribe una lista de mascotas en un archivo CSV.
        public static void GuardarMascotasEnCsv(List<Mascota> lista, string rutaArchivo)
        {
            try
            {
                // Lista de cadenas donde cada elemento será una línea del bloc de notas/excel u otro editor 
                List<string> lineasCsv = new List<string>();
                
                // 1. Agregamos el encabezado del archivo CSV, o sea las columnas que se utilizaran
                lineasCsv.Add("Id,Especie,Nombre,Edad,EstaVacunado");

                // 2. Recorremos los objetos y los convertimos en un string separado por comas
                foreach (var mascota in lista)
                {
                    // El formato es el siguientee:  1,Perro,Firulais,3,True
                    
                    string linea = $"{mascota.Id},{mascota.Especie},{mascota.Nombre},{mascota.Edad},{mascota.EstaVacunado}";
                    lineasCsv.Add(linea);
                }

                // 3. Escribimos todas las líneas en el disco duro
                File.WriteAllLines(rutaArchivo, lineasCsv);
                
                Console.WriteLine($"\nExcelenteee archivo CSV: '{rutaArchivo}' guardado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al guardar el archivo CSV: {ex.Message}");
            }
        }

        /// Lee un archivo CSV, salta la cabecera y reconstruye la lista de Mascotas.
        public static List<Mascota> LeerMascotasDesdeCsv(string rutaArchivo)
        {
            List<Mascota> listaResultante = new List<Mascota>();
            
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    // Leemos todas las líneas del archivo en un arreglo de strings
                    string[] lineas = File.ReadAllLines(rutaArchivo);
                    bool esPrimeraLinea = true;

                    foreach (string linea in lineas)
                    {
                        // Omitimos la primera línea porque son los encabezados (Id, Especie, etc) 
                        if (esPrimeraLinea && linea.StartsWith("Id,"))
                        {
                            esPrimeraLinea = false;
                            continue;
                        }

                        // Separamos la línea en fragmentos usando la coma como delimitador
                        string[] datos = linea.Split(',');
                        
                        // Aseguramos que la línea tenga exactamente los 5 datos que esperamos
                        if (datos.Length == 5)
                        {
                            // Parseamos los tipos de dato (de string a int/bool)
                            int id = int.Parse(datos[0]);
                            string especie = datos[1];
                            string nombre = datos[2];
                            int edad = int.Parse(datos[3]);
                            bool vacunado = bool.Parse(datos[4]);

                            // Reconstruimos el objeto Mascota y lo agregamos a la lista
                            Mascota mascotaRecuperada = new Mascota(id, especie, nombre, edad, vacunado);
                            listaResultante.Add(mascotaRecuperada);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"\nEl archivo |{rutaArchivo}| no existe aún. Se iniciará con datos en blanco.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcurrió un error al leer el archivo CSV: {ex.Message}");
            }

            return listaResultante;
        }
    }
}
