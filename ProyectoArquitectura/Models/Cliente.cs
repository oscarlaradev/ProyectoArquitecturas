using ProyectoArquitectura.Exceptions;

namespace ProyectoArquitectura.Models
{
    /// <summary>
    /// Clase Cliente que hereda de la clase abstracta Persona.
    /// Aquí se representa a alguien que adopta mascotas.
    /// </summary>
    public class Cliente : Persona
    {
        public string TelefonoDeContacto { get; set; } = string.Empty;

        /// <summary>
        /// Constructor de la clase Cliente con el uso de Excepciones Personalizadas.
        /// </summary>
        public Cliente(string nombre, int edad, string telefono)
        {
            // Validamos reglas y lanzamos excepciones personalizadas si no se cumplen
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new DatoInvalidoException("El nombre del cliente no puede estar vacío.");
            }
            
            if (edad < 18)
            {
                throw new EdadInvalidaException("El cliente debe ser mayor de edad (18 años) para poder adoptar.");
            }

            // Asignación de valores
            this.Nombre = nombre;
            this.Edad = edad;
            this.TelefonoDeContacto = telefono;
        }

        /// <summary>
        /// Método abstracto de la clase padre (Persona).
        /// </summary>
        public override string ObtenerRol()
        {
            return "Adoptante / Cliente";
        }
        
        /// <summary>
        /// Sobreescribimos el método ToString para añadir información exclusiva del cliente.
        /// </summary>
        public override string ToString()
        {
            // Usamos este return para aprovechar el código escrito en la clase padre
            return $"{base.ToString()} | Teléfono: {TelefonoDeContacto}";
        }
    }
}