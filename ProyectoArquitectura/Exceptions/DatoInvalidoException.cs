using System;
namespace ProyectoArquitectura.Exceptions;

    
    /// Excepción personalizada para manejar errores de validación de datos genéricos.
    public class DatoInvalidoException : Exception
    {
        /// Constructor por defecto que pasa un mensaje estándar a la clase base.
        public DatoInvalidoException() : base("El dato ingresado no es válido.")
        {
        }

        /// Constructor que permite pasar un mensaje personalizado cuando se lanza la excepción.
        public DatoInvalidoException(string message) : base(message)
        {
        }
    }
