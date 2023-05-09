using System;
using System.Collections.Generic;

namespace DesafioFundamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao estacionamento!");
            Console.WriteLine("Digite o valor inicial da hora estacionada:");
            decimal precoInicial = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor adicional por hora estacionada:");
            decimal precoPorHora = decimal.Parse(Console.ReadLine());

            myParking estacionamento = new myParking(precoInicial, precoPorHora);

            int opcao = 0;
            do
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar veículo");
                Console.WriteLine("2 - Listar veículos estacionados");
                Console.WriteLine("3 - Remover veículo");
                Console.WriteLine("4 - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        estacionamento.AdicionarVeiculo();
                        break;
                    case 2:
                        estacionamento.ListarVeiculos();
                        break;
                    case 3:
                        estacionamento.RemoverVeiculo();
                        break;
                    case 4:
                        Console.WriteLine("Obrigado por utilizar o estacionamento!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 4);
            
        }
        
    }

    public class myParking
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public myParking(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();
            veiculos.Add(placa);
            Console.WriteLine($"O veículo {placa} foi estacionado com sucesso.");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());

                decimal valorTotal = precoInicial + precoPorHora * horas;
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Count > 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}

