using System;
using System.Collections.Generic;
using System.Linq; // Necesario para algunas búsquedas y manipulaciones
using ProyectoArquitectura.Models;
using ProyectoArquitectura.Utilidades;
using ProyectoArquitectura.Exceptions;

namespace ProyectoArquitectura.Runners
{

    /// Runner principal que maneja toda la lógica del sistema.
    /// Integramos Creación, Lectura, Actualización, Eliminación, Búsqueda, Validación y Manejo de Archivos por ruta.
    public class RunnerGestionAdopcion
    {
        // Uso de lista genérica para manejar el inventario en memoria ram
        private List<Mascota> _inventarioMascotas;

        public RunnerGestionAdopcion()
        {
            // Inicializamos la lista vacía. Ahora el usuario decidirá cuándo y de dónde cargarla.
            _inventarioMascotas = new List<Mascota>();
        }

        /// Método principal que contiene el ciclo del (menú) del programa.
        public void EjecutarSistema()
        {
            bool salir = false;
            // Bucle del menú
            while (!salir)
            {
                
                Console.WriteLine(" |   SISTEMA DE GESTIÓN DE REFUGIO DE MASCOTAS   | ");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(" 1. Registrar / Insertar nueva mascota");
                Console.WriteLine(" 2. Consultar / Visualizar todas las mascotas");
                Console.WriteLine(" 3. Buscar mascota por ID");
                Console.WriteLine(" 4. Actualizar datos de una mascota");
                Console.WriteLine(" 5. Borrar mascota del registro");
                Console.WriteLine(" 6. Ordenar mascotas por edad");
                Console.WriteLine(" 7. Guardar datos en un archivo CSV (Ingresando tu ruta)");
                Console.WriteLine(" 8. Cargar datos desde un archivo CSV (Ingresando tu ruta)");
                Console.WriteLine(" 9. Registrar un Cliente");
                Console.WriteLine("10. Calcular costos");
                Console.WriteLine("11. Salir");
                Console.Write("Seleccione una opción a continuacion: ");

                string opcion = Console.ReadLine() ?? string.Empty;

                switch (opcion)
                {
                    case "1": 
                        RegistrarMascota(); 
                        break;
                    case "2": 
                        MostrarMascotas(); 
                        break;
                    case "3": 
                        BuscarMascota(); 
                        break;
                    case "4": 
                        EditarMascota(); 
                        break;
                    case "5": 
                        EliminarMascota(); 
                        break;
                    case "6": 
                        ManipularMascotas(); 
                        break;
                    case "7": 
                        GuardarYExportar(); 
                        break;
                    case "8": 
                        CargarArchivo(); 
                        break;
                    case "9": 
                        RegistrarCliente(); 
                        break;
                    case "10": 
                        CalcularCosto(); 
                        break;
                    case "11":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema adiosss");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }
        
        //operaciones Create , Read, Update, Delete  osea las (crud)

        /// Lógica para capturar datos de consola e instanciar (Registrar/Insertar) una Mascota.
        private void RegistrarMascota()
        {
            Console.WriteLine("\n--------- 1. REGISTRAR NUEVA MASCOTA -------------");
            
            // Try-Catch para capturar las excepciones (Validación)
            try
            {
                Console.Write("ID de registro (un número único): ");
                int id = int.Parse(Console.ReadLine() ?? "0");

                // Validación de ID duplicado
                if (_inventarioMascotas.Exists(m => m.Id == id))
                {
                    throw new DatoInvalidoException($"Ya existe una mascota con el ID {id}.");
                }

                Console.Write("Especie (ejemplo. Perro, Gato): ");
                string especie = Console.ReadLine() ?? string.Empty;

                Console.Write("Nombre de la mascota: ");
                string nombre = Console.ReadLine() ?? string.Empty;

                Console.Write("Edad en años: ");
                int edad = int.Parse(Console.ReadLine() ?? "-1");

                Console.Write("¿Está vacunado? (S/N): ");
                string? texto = Console.ReadLine();

                string vacInput;
                if (texto != null)
                {
                    vacInput = texto.ToUpper();
                }
                else
                {
                    vacInput = "N";
                }

                bool vacunado;
                if (vacInput == "S")
                {
                    vacunado = true;
                }
                else
                {
                    vacunado = false;
                }

                // Instanciación del objeto (invocará las validaciones estrictas en su constructor)
                Mascota nuevaMascota = new Mascota(id, especie, nombre, edad, vacunado);

                // Agregar a la lista genérica
                _inventarioMascotas.Add(nuevaMascota);
                Console.WriteLine("\nMascota insertada correctamente");
            }
            catch (EdadInvalidaException ex)
            {
                Console.WriteLine($"\nError de regla de edad {ex.Message}");
            }
            catch (DatoInvalidoException ex)
            {
                Console.WriteLine($"\nError de validacion {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError de formato por favor introduzca números válidos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError inesperado {ex.Message}");
            }
        }

        /// Recorre la lista de mascotas para visualizarlas/consultarlas.
        private void MostrarMascotas()
        {
            Console.WriteLine("\n---------- 2. INVENTARIO DE MASCOTAS ------------");
            
            if (_inventarioMascotas.Count == 0)
            {
                Console.WriteLine("No hay mascotas registradas actualmente.");
                return;
            }

            foreach (var mascota in _inventarioMascotas)
            {
                Console.WriteLine(mascota.ToString());
            }
        }

        /// BUSCAR: Encuentra una mascota específica usando su ID.
        private void BuscarMascota()
        {
            Console.WriteLine("\n----------- 3. BUSCAR MASCOTA -------------");
            Console.Write("Ingrese el ID de la mascota a buscar: ");
            
            if (int.TryParse(Console.ReadLine(), out int idBuscado))
            {
                // Uso de Find (Delegado/Lambda) para buscar en la lista genérica
                Mascota? mascotaEncontrada = _inventarioMascotas.Find(m => m.Id == idBuscado);

                if (mascotaEncontrada != null)
                {
                    Console.WriteLine("\nMASCOTA ENCONTRADA CORRECTAMENTE");
                    Console.WriteLine(mascotaEncontrada.ToString());
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró ninguna mascota con el ID {idBuscado}.");
                }
            }
            else
            {
                Console.WriteLine("\nEl ID debe ser numérico.");
            }
        }

        /// Busca una mascota y permite editar/actualizar sus campos.
        private void EditarMascota()
        {
            Console.WriteLine("\n------------ 4. EDITAR/ACTUALIZAR MASCOTA ---------------");
            Console.Write("Ingrese el ID de la mascota a editar: ");
            
            if (int.TryParse(Console.ReadLine(), out int idBuscado))
            {
                Mascota? mascotaAEditar = _inventarioMascotas.Find(m => m.Id == idBuscado);

                if (mascotaAEditar != null)
                {
                    Console.WriteLine($"Editando a: {mascotaAEditar.Nombre}");

                    try
                    {
                        Console.Write($"Nueva Especie [{mascotaAEditar.Especie}]: ");
                        string nuevaEspecie = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(nuevaEspecie)) mascotaAEditar.Especie = nuevaEspecie;

                        Console.Write($"Nuevo Nombre [{mascotaAEditar.Nombre}]: ");
                        string nuevoNombre = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(nuevoNombre)) mascotaAEditar.Nombre = nuevoNombre; // Validar en setter si existiera

                        Console.Write($"Nueva Edad [{mascotaAEditar.Edad}]: ");
                        string nuevaEdadStr = Console.ReadLine() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(nuevaEdadStr))
                        {
                            int nuevaEdad = int.Parse(nuevaEdadStr);
                            if (nuevaEdad < 0) throw new EdadInvalidaException("La edad no puede ser negativa.");
                            mascotaAEditar.Edad = nuevaEdad;
                        }

                        Console.Write($"¿Está vacunado? S/N [{ (mascotaAEditar.EstaVacunado ? "S" : "N") }]: ");
                        string nuevaVacuna = Console.ReadLine()?.ToUpper() ?? string.Empty;
                        
                        if (nuevaVacuna == "S") mascotaAEditar.EstaVacunado = true;
                        else if (nuevaVacuna == "N") mascotaAEditar.EstaVacunado = false;

                        Console.WriteLine("\nMascota actualizada correctamente!!!!!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nerror al actualizar {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró mascota con ID {idBuscado}.");
                }
            }
        }

        /// DELETE: Busca una mascota y la borra de la lista.
        private void EliminarMascota()
        {
            Console.WriteLine("\n--------- 5. ELIMINAR/BORRAR MASCOTA ----------");
            Console.Write("Ingrese el ID de la mascota a eliminar: ");
            
            if (int.TryParse(Console.ReadLine(), out int idBuscado))
            {
                Mascota? mascotaAEliminar = _inventarioMascotas.Find(m => m.Id == idBuscado);

                if (mascotaAEliminar != null)
                {
                    _inventarioMascotas.Remove(mascotaAEliminar);
                    Console.WriteLine($"\nLa mascota '{mascotaAEliminar.Nombre}' ha sido borrada del sistema.");
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró mascota con ID {idBuscado}.");
                }
            }
        }

        /// MANIPULAR: Utiliza el IComparer para ordenar la lista genérica.
        private void ManipularMascotas()
        {
            Console.WriteLine("\n---------- 6. ORDENAR POR EDAD -----------");
            if (_inventarioMascotas.Count == 0)
            {
                Console.WriteLine("La lista está vacía."); 
                return;
            }

            // Instanciamos nuestro "comparador"
            var comparadorPorEdad = new OrdenamientoMascotaPorEdad();
            _inventarioMascotas.Sort(comparadorPorEdad);

            Console.WriteLine("La lista en memoria ha sido ordenada por edad (Menor a Mayor).");
            MostrarMascotas();
        }
        
        // SISTEMA DE ARCHIVOS (CARGAR/GUARDAR)
        
        /// GUARDAR: Pide la ruta del archivo y guarda la lista CSV.
        private void GuardarYExportar()
        {
            Console.WriteLine("\n------------ 7.GUARDAR DATOS -------------");
            Console.Write("Ingrese la ruta del archivo para guardar (ej. C://datos//mascotas.csv o solo nombrearchivo.csv): ");
            string ruta = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(ruta))
            {
                GestorArchivosCsv.GuardarMascotasEnCsv(_inventarioMascotas, ruta);
            }
            else
            {
                Console.WriteLine("\nerror la ruta no puede estar vacía.");
            }
        }

        /// CARGAR: Pide la ruta del archivo y lee el CSV, reemplazando la lista actual.
        private void CargarArchivo()
        {
            Console.WriteLine("\n----------- 8. CARGAR/LEER ARCHIVO ----------");
            Console.WriteLine("Advertencia: se reemplazarán los datos actuales no guardados.");
            Console.Write("Ingrese la ruta del archivo a cargar (ejemplo: nombrearchivo.csv): ");
            string ruta = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(ruta))
            {
                // Sobrescribimos nuestra lista actual con los datos leídos por la clase estática de CSV
                _inventarioMascotas = GestorArchivosCsv.LeerMascotasDesdeCsv(ruta);
                Console.WriteLine($"\nSe han cargado {_inventarioMascotas.Count} mascotas.");
            }
            else
            {
                Console.WriteLine("\nLa ruta no puede estar vacía.");
            }
        }

        private void RegistrarCliente()
        {
            Console.WriteLine("\n----------- 9. REGISTRO DE CLIENTE -------------");
            try
            {
                Console.Write("Nombre del adoptante: "); 
                string nombre = Console.ReadLine() ?? string.Empty;
                
                Console.Write("Edad: "); 
                int edad = int.Parse(Console.ReadLine() ?? "0");
                
                Console.Write("Teléfono: "); 
                string tel = Console.ReadLine() ?? string.Empty;

                Persona unCliente = new Cliente(nombre, edad, tel);
                Console.WriteLine("\nCliente registrado temporalmente");
                Console.WriteLine(unCliente.ToString()); 
            }
            catch (EdadInvalidaException ex) { Console.WriteLine($"\nerror de regla de edad {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"\nerror generico {ex.Message}"); }
        }

        private void CalcularCosto()
        {
            Console.WriteLine("\n--------------- 10. CALCULADORA DE COSTOS DE ADOPCIÓN -------------");
            try
            {
                Console.Write("Ingrese la cuota base de adopción: $");
                double cuota = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Ingrese el costo de servicios médicos (vacunas): $");
                double costoMed = double.Parse(Console.ReadLine() ?? "0");

                double totalBruto = CalculadoraCostos.CalcularTotalAdopcion(cuota, costoMed);
                Console.WriteLine($"El costo total bruto es de: ${totalBruto}");

                Console.Write("\n¿Desea aplicar un descuento especial? Ingrese el porcentaje (0 a 100): ");
                double porcentaje = double.Parse(Console.ReadLine() ?? "0");

                double totalNeto = CalculadoraCostos.AplicarDescuento(totalBruto, porcentaje);
                Console.WriteLine($"\nEl cliente debe pagar un Total de: ${totalNeto}");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nerror debes ingresar cifras numéricas válidas.");
            }
        }
    }
}
