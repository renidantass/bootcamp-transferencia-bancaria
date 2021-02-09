using bootcamp_transferencia_bancaria.Enums;
using System;

namespace bootcamp_transferencia_bancaria.Classes
{
    public class Conta
    {
        public TipoConta TipoConta { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public double Credito { get; set; }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito) 
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }
        
        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1)) {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine(this);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine(this);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString() 
        {
            return $"{Nome} tem o saldo de R$ {Saldo} e crédito de R$ {Credito}";
        }
    }
}