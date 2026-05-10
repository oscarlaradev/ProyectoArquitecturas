namespace ProyectoArquitectura.Exceptions;
    /// <summary>
    /// Excepción personalizada específica para cuando la edad de una mascota o persona es ilógica.
    /// </summary>
    public class EdadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor que recibe el mensaje específico sobre la edad incorrecta.
        /// </summary>
        /// <param name="message">Mensaje del error.</param>
        public EdadInvalidaException(string message) : base(message)
        {
        }
    }
