using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupBY
{
    class Departamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }

    class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdDepartamento { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var listaDepartamentos = new List<Departamento>() {
                new Departamento {Id = 1, Descricao = "Cervejas"},
                new Departamento {Id = 2, Descricao = "Sucos"},
                new Departamento {Id = 3, Descricao = "Refrigerantes"}
            };

            var listaProdutos = new List<Produto>()
            {
                new Produto { Id = 1, Descricao = "Skol", IdDepartamento = 1},
                new Produto { Id = 2, Descricao = "Brahma", IdDepartamento = 1},
                new Produto { Id = 3, Descricao = "Coca Cola", IdDepartamento = 3},
                new Produto { Id = 4, Descricao = "Sukita", IdDepartamento = 3},
                new Produto { Id = 5, Descricao = "Pepsi", IdDepartamento = 3},
                new Produto { Id = 6, Descricao = "Uva Dell Valle", IdDepartamento = 2},
            };

            PrimeiraForma(listaDepartamentos, listaProdutos);
            Console.ReadLine();
        }

        private static void PrimeiraForma(List<Departamento> listaDepartamentos, List<Produto> listaProdutos)
        {
            var query = from depto in listaDepartamentos
                        select new
                        {
                            Desc_Depto = depto.Descricao,
                            QtdeProdutos = listaProdutos.Where(p => p.IdDepartamento == depto.Id).Distinct().Count()
                        };

            foreach (var item in query)
            {
                Console.WriteLine("{0}\t{1}", item.Desc_Depto.PadRight(20), item.QtdeProdutos);
            }
        }
    }
}
