using System.Collections.Generic;
using ProyectoArquitectura.Models;

namespace ProyectoArquitectura.Utilidades
{
    /// Clase que implementa la interfaz genérica IComparer para ordenar listas de mascotas por su edad.
    public class OrdenamientoMascotaPorEdad : IComparer<Mascota>
    {
        /// Método de la interfaz que compara dos mascotas.
        /// Regresa un valor entero: menor que 0 si x es menor que y, 0 si son iguales, y mayor que 0 si x es mayor.
        public int Compare(Mascota? x, Mascota? y)
        {
            // Si ambas son nulas, son iguales
            if (x == null && y == null) return 0;
            // Si solo la primera es nula, va primero
            if (x == null) return -1;
            // Si solo la segunda es nula, va primero la segunda
            if (y == null) return 1;

            // Uso del método CompareTo de los tipos(int)
            return x.Edad.CompareTo(y.Edad);
        }
    }
}
