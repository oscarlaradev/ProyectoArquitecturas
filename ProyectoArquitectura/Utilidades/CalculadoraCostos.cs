namespace ProyectoArquitectura.Utilidades;

    /// Clase de utilidades para realizar operaciones matemáticas básicas.
    public static class CalculadoraCostos
    {
        /// Calcula el costo total sumando una cuota base y el costo del servicio médico.
        /// Regresa la suma de ambos valores.
        public static double CalcularTotalAdopcion(double cuotaAdopcion, double costoMedico)
        {
            // Operación básica de suma
            return cuotaAdopcion + costoMedico;
        }

        /// Aplica un descuento básico mediante una multiplicación y una resta.
        /// Regresa el total ya con el descuento aplicado.</returns>
        public static double AplicarDescuento(double total, double porcentajeDescuento)
        {
            // Regla de tres simple para obtener cuánto se va a descontar
            double descuento = (total * porcentajeDescuento) / 100;
            // Operación de resta
            return total - descuento;
        }
    }
