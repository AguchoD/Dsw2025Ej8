using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class CajaDeAhorro : CuentaBancaria
    {
        public decimal tasaDeInteres {  get; set; }

        public CajaDeAhorro(int numero, decimal saldoInicial,string Tipo ="Caja de ahorro")
            : base(numero, saldoInicial) { }

     
        public override void retiro(decimal monto)
        {
            validarEstado();
           validarMonto(monto);
            if (_saldo < monto)
            {
                _estado = false;
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
        public void AplicarInteres()
        {
            validarEstado();
            _saldo += _saldo * tasaDeInteres;
        }
    }
}
