namespace ProyectoArquitectura.Models
{
    /// <summary>
    /// Clase Abstracta Persona.
    /// Define las características básicas.
    /// </summary>
    public abstract class Persona
    {
        // Propiedades (Encapsulamiento)
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }

        /// <summary>
        /// Método abstracto que obligará a todas las clases hijas a implementar su propio comportamiento.
        /// </summary>
        public abstract string ObtenerRol();

        /// <summary>
        /// Sobrescritura (override) del método genérico ToString()
        /// </summary>
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Edad: {Edad}, Rol: {ObtenerRol()}";
        }
    }
}