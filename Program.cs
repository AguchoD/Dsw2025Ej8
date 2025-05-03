using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cuentas = new List<CuentaBancaria>();

            var CuentaAhorro1 = new CajaDeAhorro(1111, 0m) { tasaDeInteres = 0.04m };
            var CuentaAhorro2 = new CajaDeAhorro(2222, 100m) { tasaDeInteres = 0.05m };
            var CuentaCorriente1 = new CuentaCorriente(3333,100m) { limiteDeDescubierto = 200m };
            var CuentaCorriente2 = new CuentaCorriente(4444, 0m) { limiteDeDescubierto = 100m };
            cuentas.AddRange(new CuentaBancaria[] { CuentaAhorro1, CuentaAhorro2, CuentaCorriente1, CuentaCorriente2 });

            
            void Ejecutar(Action accion, string descripcion)
            {
                try
                {
                    accion();
                    Console.WriteLine($"-----La solicitud ha sido procesada correctamente: {descripcion}\n");
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error ({descripcion}): {ex.Message}\n");
                    Console.ReadLine();
                }
            }

            
            Ejecutar(() => CuentaAhorro1.depositar(100m), "Depósito 100 en cuentadeahorro1 ");
            Ejecutar(() => CuentaAhorro1.depositar(0m), "Depósito 0 en cuentadeahorro1 (MontoNoValido)");

            
            Ejecutar(() => CuentaAhorro2.retiro(200m), "Retiro 200 en CuentaAhorro2");
            Ejecutar(() => CuentaAhorro2.retiro(500), "Retiro 500 en CuentaAhorro2 (SaldoInsuficiente)");

           
            Ejecutar(() => CuentaAhorro2.depositar(300m), "Depósito 300 en CuentaAhorro2 suspendida (CuentaNoActiva)");

           
            Ejecutar(() => CuentaAhorro1.AplicarInteres(), "Aplicar interés en CuentaAhorro1");

            
            Ejecutar(() => CuentaCorriente1.retiro(250m), "Retiro 250 en CuentaCorriente1 (dentro de descubierto)");
            Ejecutar(() => CuentaCorriente1.retiro(100m), "Retiro 100 en CuentaCorriente1 (excede descubierto)");

            
            Ejecutar(() => CuentaCorriente2.depositar(-100m), "Depósito -100 en cuentaCorriente2 (MontoNoValido)");


            Console.WriteLine("\n--- Resumen de Cuentas ---");
            foreach (var cuenta in cuentas)
            {
                var resumen = new { cuenta._numero,cuenta._saldo};
                Console.WriteLine($"Cuenta: {resumen._numero}, Saldo: {resumen._saldo:C}");
            }
        }
    }
}
