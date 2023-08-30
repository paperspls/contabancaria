namespace contabancaria
{
    public class Program
    {
        static void Main(string[] args)
        {
            int opcao;

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\r\n  ______ ______ ______   ____          _   _  _____ ____   _____ \r\n |  ____|  ____|  ____| |  _ \\   /\\   | \\ | |/ ____/ __ \\ / ____|\r\n | |__  | |__  | |__    | |_) | /  \\  |  \\| | |   | |  | | (___  \r\n |  __| |  __| |  __|   |  _ < / /\\ \\ | . ` | |   | |  | |\\___ \\ \r\n | |    | |    | |      | |_) / ____ \\| |\\  | |___| |__| |____) |\r\n |_|    |_|    |_|      |____/_/    \\_\\_| \\_|\\_____\\____/|_____/ \r\n                                                                 \r\n                                                                 \r\n");
                Console.WriteLine("******************************************************************");
                Console.WriteLine("1- Criar Conta                                       ");
                Console.WriteLine("2- Listar Todas as Contas                            ");
                Console.WriteLine("3- Buscar Conta por Número                           ");
                Console.WriteLine("4- Atualizar Dados da Conta                          ");
                Console.WriteLine("5- Apagar Conta                                      ");
                Console.WriteLine("6- Sacar                                             ");
                Console.WriteLine("7- Depositar                                         ");
                Console.WriteLine("8- Transferir Valores entre Contas                   ");
                Console.WriteLine("9- Negociar dívidas                                  ");
                Console.WriteLine("10- Sair                                             ");
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
                        break;
                    case 2:
                        Console.WriteLine("\nListar Todas as Contas\n");
                        break;
                    case 3:
                        Console.WriteLine("\nBuscar Conta por Número\n");
                        break;
                    case 4:
                        Console.WriteLine("\nAtualizar Dados da Conta\n");
                        break;
                    case 5:
                        Console.WriteLine("\nApagar Conta\n");
                        break;
                    case 6:
                        Console.WriteLine("\nSacar\n");
                        break;
                    case 7:
                        Console.WriteLine("\nDepositar\n");
                        break;
                    case 8:
                        Console.WriteLine("\nTransferir Valores entre Contas\n");
                        break;
                    case 9:
                        Console.WriteLine("\nNegociar dívidas\n");
                        Console.WriteLine("Este recurso está indefinitivamente fora de serviço, lamentamos.\n");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                }
            }

        }
        static void Sobre()
        {
            Console.WriteLine("*****************************************************");
            Console.WriteLine("Projeto Desenvolvido por:                            ");
            Console.WriteLine("Rhyan Magalhães - rhyan.magalhaes@outlook.com        ");
            Console.WriteLine("github.com/paperspls                         ");
            Console.WriteLine("*****************************************************");


        }
    }
}