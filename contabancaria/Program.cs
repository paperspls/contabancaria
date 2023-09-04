using contabancaria.Controller;
using contabancaria.Model;
using System;

namespace contabancaria
{
    public class Program
    {
        private static ConsoleKeyInfo ConsoleKeyInfo;
        static void Main(string[] args)
        {
            int opcao, agencia, tipo, aniversario;
            string? titular;
            decimal saldo, limite;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            
            ContaController contas = new();


            ContaCorrente cc1 = new ContaCorrente(contas.GerarNumero(), 123, 1, "Victor", 1000000.00M, 1000.00M);
            contas.Cadastrar(cc1);

            ContaPoupanca cp1 = new ContaPoupanca(contas.GerarNumero(), 123, 2, "Pedro", 10000.00M, 29);
            contas.Cadastrar(cp1);
            

            while (true)
            {
                Console.WriteLine("\r\n  ______ ______ ______   ____          _   _  _____ ____   _____ \r\n |  ____|  ____|  ____| |  _ \\   /\\   | \\ | |/ ____/ __ \\ / ____|\r\n | |__  | |__  | |__    | |_) | /  \\  |  \\| | |   | |  | | (___  \r\n |  __| |  __| |  __|   |  _ < / /\\ \\ | . ` | |   | |  | |\\___ \\ \r\n | |    | |    | |      | |_) / ____ \\| |\\  | |___| |__| |____) |\r\n |_|    |_|    |_|      |____/_/    \\_\\_| \\_|\\_____\\____/|_____/ \r\n                                                                 \r\n                                                                 \r\n");
                Console.WriteLine("******************************************************************");
                Console.WriteLine("1- Criar Conta                                                    ");
                Console.WriteLine("2- Listar Todas as Contas                                         ");
                Console.WriteLine("3- Buscar Conta por Número                                        ");
                Console.WriteLine("4- Atualizar Dados da Conta                                       ");
                Console.WriteLine("5- Apagar Conta                                                   ");
                Console.WriteLine("6- Sacar                                                          ");
                Console.WriteLine("7- Depositar                                                      ");
                Console.WriteLine("8- Transferir Valores entre Contas                                ");
                Console.WriteLine("9- Negociar dívidas                                               ");
                Console.WriteLine("10- Sair                                                          ");
                Console.WriteLine("******************************************************************");
                Console.Write("Entre com a opção desejada: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 10)
                {
                    Console.WriteLine("\nFundo Falso & Finanças agradece a preferência!");
                    Sobre();
                    System.Environment.Exit(0);
                }

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("\nCriar conta\n");
                        Console.WriteLine("Seja bem-vindo a Fundo Falso & Finanças Bancos!\n");

                        //Infos da conta
                        Console.Write("Digite o Número da Agência: ");
                        agencia = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o Nome do Titular: ");
                        titular = Console.ReadLine();

                        titular ??= string.Empty;

                        do
                        {
                            Console.Write("Digite o Tipo da Conta: ");
                            tipo = Convert.ToInt32(Console.ReadLine());
                        } while (tipo != 1  && tipo != 2);
                        
                        Console.Write("Digite o Saldo da Conta: ");
                        saldo = Convert.ToDecimal(Console.ReadLine());
                        
                        switch(tipo)
                        {
                            case 1:
                                Console.Write("Digite o Limite da Conta: ");
                                limite = Convert.ToDecimal(Console.ReadLine());

                                contas.Cadastrar(new ContaCorrente(contas.GerarNumero(),
                                    agencia, tipo, titular, saldo, limite));
                                break;
                            case 2:
                                Console.Write("Digite o Aniversário da Conta: ");
                                aniversario = Convert.ToInt32(Console.ReadLine());
                                contas.Cadastrar(new ContaPoupanca(contas.GerarNumero(),
                                    agencia, tipo, titular, saldo, aniversario));
                                break;
                        }
                        KeyPress();
                        break;
                    case 2:
                        Console.WriteLine("\nListar Todas as Contas\n");
                        contas.ListarTodas();
                        KeyPress();
                        break;
                    case 3:
                        Console.WriteLine("\nBuscar Conta por Número\n");
                        KeyPress();
                        break;
                    case 4:
                        Console.WriteLine("\nAtualizar Dados da Conta\n");
                        KeyPress();
                        break;
                    case 5:
                        Console.WriteLine("\nApagar Conta\n");
                        KeyPress();
                        break;
                    case 6:
                        Console.WriteLine("\nSacar\n");
                        KeyPress();
                        break;
                    case 7:
                        Console.WriteLine("\nDepositar\n");
                        KeyPress();
                        break;
                    case 8:
                        Console.WriteLine("\nTransferir Valores entre Contas\n");
                        KeyPress();
                        break;
                    case 9:
                        Console.WriteLine("\nNegociar dívidas\n");
                        Console.WriteLine("Este recurso está indefinitivamente fora de serviço, lamentamos.\n");
                        KeyPress();
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!\n");
                        KeyPress();
                        break;
                }
            }

        }
        static void Sobre()
        {
            Console.WriteLine("******************************************************************");
            Console.WriteLine("Projeto Desenvolvido por:                            ");
            Console.WriteLine("Rhyan Magalhães - rhyan.magalhaes@outlook.com        ");
            Console.WriteLine("github.com/paperspls                         ");
            Console.WriteLine("******************************************************************");


        }
        static void KeyPress()
        {
            do
            {
                Console.Write("\nPressione Enter para Continuar...");
                ConsoleKeyInfo = Console.ReadKey();
            } while (ConsoleKeyInfo.Key != ConsoleKey.Enter);
        }
    }
}