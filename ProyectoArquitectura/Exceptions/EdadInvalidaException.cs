namespace ProyectoArquitectura.Exceptions;
    
    /// Excepción personalizada específica para cuando la edad de una mascota o persona es ilógica.
    public class EdadInvalidaException : Exception
    {
        /// Constructor que recibe el mensaje específico sobre la edad incorrecta.
        public EdadInvalidaException(string message) : base(message)
        {
        }
    }
