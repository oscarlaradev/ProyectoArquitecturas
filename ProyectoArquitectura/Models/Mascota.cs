using System;
using ProyectoArquitectura.Exceptions;

namespace ProyectoArquitectura.Models
{

    /// Clase Mascota con lo esencial.
    public class Mascota
    {
        // Propiedades de la mascota
        public int Id { get; set; }
        public string Especie { get; set; } = string.Empty; // Ejemplo: Perro, Gato, Conejo
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }
        public bool EstaVacunado { get; set; }

        /// Constructor vacío necesario para que gestorarchivos pueda deserializar el objeto.
        public Mascota() { }

        /// Constructor con parametros para instanciar fácilmente en el código.
        /// Incluye validaciones y uso de Excepciones.
        public Mascota(int id, string especie, string nombre, int edad, bool vacunado)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new DatoInvalidoException("La mascota debe tener un nombre válido.");
                
            if (edad < 0)
                throw new EdadInvalidaException("La edad de la mascota no puede ser un número negativo.");

            Id = id;
            Especie = especie;
            Nombre = nombre;
            Edad = edad;
            EstaVacunado = vacunado;
        }

        /// Sobrescritura para mostrar fácilmente los datos en consola.
        public override string ToString()
        {
            string estadoVacuna = EstaVacunado ? "Sí" : "No";
            return $"[{Id}] {Especie} | Nombre: {Nombre} | Edad: {Edad} años | Vacunado: {estadoVacuna}";
        }
    }
}
