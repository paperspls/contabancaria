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
            int opcao, agencia, tipo, aniversario, numero, numeroDestino;
            string? titular;
            decimal saldo, limite, valor;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            
            ContaController contas = new();


            ContaCorrente cc1 = new ContaCorrente(contas.GerarNumero(), 123, 1, "Victor", 1000000.00M, 1000.00M);
            contas.Cadastrar(cc1);

            ContaPoupanca cp1 = new ContaPoupanca(contas.GerarNumero(), 123, 2, "Pedro", 10000.00M, 29);
            contas.Cadastrar(cp1);
            

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\r\n  ______ ______ ______   ____          _   _  _____ ____   _____ \r\n |  ____|  ____|  ____| |  _ \\   /\\   | \\ | |/ ____/ __ \\ / ____|\r\n | |__  | |__  | |__    | |_) | /  \\  |  \\| | |   | |  | | (___  \r\n |  __| |  __| |  __|   |  _ < / /\\ \\ | . ` | |   | |  | |\\___ \\ \r\n | |    | |    | |      | |_) / ____ \\| |\\  | |___| |__| |____) |\r\n |_|    |_|    |_|      |____/_/    \\_\\_| \\_|\\_____\\____/|_____/ \r\n                                                                 \r\n                                                                 \r\n");
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                Console.WriteLine("                                                                  ");
                Console.WriteLine("                  1- Criar Conta                                  ");
                Console.WriteLine("                  2- Listar Todas as Contas                       ");
                Console.WriteLine("                  3- Buscar Conta por Número                      ");
                Console.WriteLine("                  4- Atualizar Dados da Conta                     ");
                Console.WriteLine("                  5- Apagar Conta                                 ");
                Console.WriteLine("                  6- Sacar                                        ");
                Console.WriteLine("                  7- Depositar                                    ");
                Console.WriteLine("                  8- Transferir Valores entre Contas              ");
                Console.WriteLine("                  9- Negociar dívidas                             ");
                Console.WriteLine("                  10- Consulta por titular                        ");
                Console.WriteLine("                  11- Sair                                        ");
                Console.WriteLine("                                                                  ");
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                Console.Write("Entre com a opção desejada: ");
                
                try 
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite um valor inteiro entre 1 e 10.");
                    opcao = 0;
                    Console.ResetColor();
                }

                if (opcao == 11)
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
                        
                        //FAZER UM TRYCATCH AQ DPS
                        Console.Write("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.ProcurarPorNumero(numero);

                        KeyPress();
                        break;
                    case 4:
                        Console.WriteLine("\nAtualizar Dados da Conta\n");

                        Console.Write("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        var conta = contas.BuscarNaCollection(numero);

                        if( conta is not null)
                        {
                            Console.Write("Digite o Número da Agência: ");
                            agencia = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Digite o Nome do Titular: ");
                            titular = Console.ReadLine();

                            titular ??= string.Empty;

                           

                            Console.Write("Digite o Saldo da Conta: ");
                            saldo = Convert.ToDecimal(Console.ReadLine());

                            tipo = conta.GetTipo();

                            switch (tipo)
                            {
                                case 1:
                                    Console.Write("Digite o Limite da Conta: ");
                                    limite = Convert.ToDecimal(Console.ReadLine());

                                    contas.Atualizar(new ContaCorrente(numero,
                                        agencia, tipo, titular, saldo, limite));
                                    break;
                                case 2:
                                    Console.Write("Digite o Aniversário da Conta: ");
                                    aniversario = Convert.ToInt32(Console.ReadLine());
                                    contas.Atualizar(new ContaPoupanca(numero,
                                        agencia, tipo, titular, saldo, aniversario));
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A conta número {numero} nao foi encontrada!");
                            Console.ResetColor();
                        }

                        KeyPress();
                        break;
                    case 5:
                        Console.WriteLine("\nApagar Conta\n");
                        Console.Write("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.Deletar(numero);

                        KeyPress();
                        break;
                    case 6:
                        Console.WriteLine("\nSacar\n");

                        Console.Write("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o valor do Saque: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Sacar(numero, valor);

                        KeyPress();
                        break;
                    case 7:
                        Console.WriteLine("\nDepositar\n");

                        Console.Write("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o valor do Depósito: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Depositar(numero, valor);

                        KeyPress();
                        break;
                    case 8:
                        Console.WriteLine("\nTransferir Valores entre Contas\n");

                        Console.Write("Digite o número da Conta de Origem: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o número da Conta de Destino: ");
                        numeroDestino = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o valor da transferência: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Transferir(numero, numeroDestino, valor);

                        KeyPress();
                        break;
                    case 9:
                        Console.WriteLine("\nNegociar dívidas\n");
                        Console.WriteLine("Este recurso está indefinitivamente fora de serviço, lamentamos o transtorno.\n");
                        KeyPress();
                        break;
                    case 10:
                        Console.WriteLine("\nConsulta por titular\n");
                        Console.Write("Digite o Nome do Titular: ");
                        titular = Console.ReadLine();

                        titular ??= string.Empty;

                        contas.ListarTodasPorTitular(titular);

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
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine("Projeto Desenvolvido por:                            ");
            Console.WriteLine("Rhyan Magalhães - rhyan.magalhaes@outlook.com        ");
            Console.WriteLine("github.com/paperspls                         ");
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");


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