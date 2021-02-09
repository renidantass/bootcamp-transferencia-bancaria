using System;
using System.Collections.Generic;
using bootcamp_transferencia_bancaria.Classes;
using bootcamp_transferencia_bancaria.Enums;

namespace bootcamp_transferencia_bancaria
{
    class Program
    {
        static List<Conta> Contas = new List<Conta>();

        static void Main(string[] args)
        {
            Conta conta = new Conta(TipoConta.PessoaFisica, "Reni", 20.00, 9000.00);
            Conta conta1 = new Conta(TipoConta.PessoaJuridica, "Eireli Qualquer", 0.00, 0.00);

            conta.Transferir(9000.00, conta1);

            Console.WriteLine(conta.ToString());


            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentException("Opção inválida");
                }
            }
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());


            Console.WriteLine("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            Contas[indiceContaOrigem].Transferir(valorTransferencia, Contas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depoistado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            Contas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());


            Contas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            if (Contas.Count < 1)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
            } else
            {
                foreach (Conta conta in Contas)
                {
                    Console.WriteLine(conta);
                    Console.WriteLine();
                }
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta física ou 2 para Juridica: ");

            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta((TipoConta)entradaTipoConta, entradaNome, entradaSaldo, entradaCredito);
            Contas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informação a opção desejada: ");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
