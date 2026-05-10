using System;
namespace ProyectoArquitectura.Exceptions;

    /// <summary>
    /// Excepción personalizada para manejar errores de validación de datos genéricos.
    /// </summary>
    public class DatoInvalidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto que pasa un mensaje estándar a la clase base.
        /// </summary>
        public DatoInvalidoException() : base("El dato ingresado no es válido.")
        {
        }

        /// <summary>
        /// Constructor que permite pasar un mensaje personalizado cuando se lanza la excepción.
        /// </summary>
        /// <param name="message">El mensaje descriptivo del error.</param>
        public DatoInvalidoException(string message) : base(message)
        {
        }
    }
