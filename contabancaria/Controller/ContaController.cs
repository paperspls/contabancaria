using contabancaria.Model;
using contabancaria.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contabancaria.Controller
{
    public class ContaController : IContarepository
    {
        private readonly List<Conta> listaContas = new();
        int numero = 0;

        public void Atualizar(Conta conta)
        {
            var buscaConta = BuscarNaCollection(conta.GetNumero());

            if (buscaConta is not null) 
            {
                var index = listaContas.IndexOf(buscaConta);

                listaContas[index] = conta;

                Console.WriteLine($"A conta número {conta.GetNumero()} foi atualizada com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta número {numero} nao foi encontrada!");
                Console.ResetColor();
            }
        }
        public void Cadastrar(Conta conta)
        {
            listaContas.Add(conta);
            Console.WriteLine($"A conta número {conta.GetNumero()} foi criada com sucesso!"); ;
        }
        public void Deletar(int numero)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
            {
                if (listaContas.Remove(conta) == true)
                    Console.WriteLine($"A Conta número {numero} foi apagada com sucesso!");  
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta número {numero} nao foi encontrada!");
                Console.ResetColor();
            }
        }
        public void ListarTodas()
        {
            foreach(var conta in listaContas) 
            {
                conta.Visualizar();
            }
        }
        public void ProcurarPorNumero(int numero)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
                conta.Visualizar();
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta número {numero} nao foi encontrada!");
                Console.ResetColor();
            }
        }
        public void Sacar(int numero, decimal valor)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
            {
                if (conta.Sacar(valor) == true)
                    Console.WriteLine($"O saque na conta número {numero} foi efetuado com sucesso!");
            }
                
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta número {numero} nao foi encontrada!");
                Console.ResetColor();
            }
        }
        public void Depositar(int numero, decimal valor)
        {
            var conta = BuscarNaCollection(numero);

            if (conta is not null)
            {
                conta.Depositar(valor);
                Console.WriteLine($"O depósito na conta número {numero} foi efetuado com sucesso!");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta número {numero} nao foi encontrada!");
                Console.ResetColor();
            }
        }
        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            var contaOrigem = BuscarNaCollection(numeroOrigem);
            var contaDestino = BuscarNaCollection(numeroDestino);

            if (contaOrigem is not null && contaDestino is not null)
            {
                if (contaOrigem.Sacar(valor) == true)
                {
                    contaDestino.Depositar(valor);
                    Console.WriteLine($"A transferência foi efetuada com sucesso!");

                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Uma das contas nao foi encontrada!");
                Console.ResetColor();
            }
        }
        //Métodos Auxiliares
        public int GerarNumero() 
        {
            return ++numero;
        }

        //Método Buscar objeto conta na collection
        public Conta? BuscarNaCollection(int numero)
        {
            foreach(var conta in listaContas)
            {
                if(conta.GetNumero() == numero)
                    return conta;
            }

            return null;
        }

        public void ListarTodasPorTitular(string titular)
        {
            var contasPorTitular = from conta in listaContas
                                   where conta.GetTitular().Contains(titular)
                                   select conta;
            contasPorTitular.ToList().ForEach(c => c.Visualizar());
        }
    }
}
