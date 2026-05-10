namespace ProyectoArquitectura.Utilidades;
    /// <summary>
    /// Clase de utilidades para realizar operaciones matemáticas básicas.
    /// </summary>
    public static class CalculadoraCostos
    {
        /// <summary>
        /// Calcula el costo total sumando una cuota base y el costo del servicio médico.
        /// </summary>
        /// <param name="cuotaAdopcion">Costo base por adoptar.</param>
        /// <param name="costoMedico">Costo de vacunas y desparasitación.</param>
        /// <returns>La suma de ambos valores.</returns>
        public static double CalcularTotalAdopcion(double cuotaAdopcion, double costoMedico)
        {
            // Operación básica de suma
            return cuotaAdopcion + costoMedico;
        }

        /// <summary>
        /// Aplica un descuento básico mediante una multiplicación y una resta.
        /// </summary>
        /// <param name="total">Total a pagar.</param>
        /// <param name="porcentajeDescuento">Porcentaje a descontar (ejemplo 10 para 10%).</param>
        /// <returns>El total ya con el descuento aplicado.</returns>
        public static double AplicarDescuento(double total, double porcentajeDescuento)
        {
            // Regla de tres simple para obtener cuánto se va a descontar
            double descuento = (total * porcentajeDescuento) / 100;
            // Operación de resta
            return total - descuento;
        }
    }
