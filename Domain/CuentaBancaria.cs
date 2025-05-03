using System.Security.Cryptography.X509Certificates;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public int _numero { get; }
    public decimal _saldo { get; protected set; }
    public bool _estado { get; protected set; } = true;
    string Tipo { get; set; }


    protected CuentaBancaria(int numero, decimal saldo)
    {
        _numero = numero;
        _saldo = saldo;
    }
     

    public void validarMonto(decimal monto)
    {
        if (monto <= 0)
        {
            throw new MontoNoValidoException();
        }
    }
    public void validarEstado()
    {
        if (!_estado)
        {
            throw new CuentaNoActivaException("suspendida");
        }
    }
    public abstract void depositar(decimal monto);
    public abstract void retiro(decimal monto);
}

    /*public void Depositar(decimal monto)
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            monto -= monto * _comision;
            _saldo += monto;
        }
    }

    public void Retirar(decimal monto)
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo -= monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            if (_saldo - monto >= -_limiteDeDescubierto)
            {
                _saldo -= monto;
            }
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
            }
        }
    }

    public void AplicarInteres()
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }
}
    */