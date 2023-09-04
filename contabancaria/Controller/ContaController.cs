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
            throw new NotImplementedException();
        }

        public void Cadastrar(Conta conta)
        {
            listaContas.Add(conta);
            Console.WriteLine($"A conta número {conta.GetNumero()} foi criada com sucesso!"); ;
        }

        public void Deletar(int numero)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Sacar(int numero, decimal valor)
        {
            throw new NotImplementedException();
        }
        public void Depositar(int numero, decimal valor)
        {
            throw new NotImplementedException();
        }

        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            throw new NotImplementedException();
        }

        //Métodos Auxiliares

        public int GerarNumero() 
        {
            return ++numero;
        }
    }
}
