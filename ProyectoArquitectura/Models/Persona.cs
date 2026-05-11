namespace ProyectoArquitectura.Models
{

    /// Clase Abstracta Persona.
    /// Define las características básicas.
    public abstract class Persona
    {
        // Propiedades (Encapsulamiento)
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }

        /// Método abstracto que obligará a todas las clases hijas a implementar su propio comportamiento.
        public abstract string ObtenerRol();

        /// Sobrescritura (override) del método genérico ToString()
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Edad: {Edad}, Rol: {ObtenerRol()}";
        }
    }
}
