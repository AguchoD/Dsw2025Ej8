using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CuentaCorriente : CuentaBancaria
    {
        public decimal limiteDeDescubierto { get; set; }
        public string Tipo { get; } = "Cuenta Corriente"; 
        public CuentaCorriente(int numero, decimal saldo, string Tipo = "Cuenta corriente")
            : base(numero, saldo) { }
       
        public override void retiro(decimal monto)
        {
            validarEstado();
            validarMonto(monto);
            if (_saldo + limiteDeDescubierto < monto)
            {
                _estado= false;
                throw new SaldoInsuficienteException();
            }
            _saldo -= monto;
        }
        public override void depositar(decimal monto)
        {
            validarEstado();
            validarMonto(monto);
            _saldo += monto;
        }
    }
}
