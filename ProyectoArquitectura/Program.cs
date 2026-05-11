using System;
using ProyectoArquitectura.Runners;

namespace ProyectoArquitectura
{
    /// Punto de entrada del sistema
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos el manejador principal (Runner)
            RunnerGestionAdopcion sistemaCentral = new RunnerGestionAdopcion();

            // Arrancamos el menú del programa
            sistemaCentral.EjecutarSistema();
        }
    }
}
