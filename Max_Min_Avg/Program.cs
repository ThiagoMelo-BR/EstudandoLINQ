using System;
using System.Collections.Generic;
using System.Linq;

namespace Max_Min_Avg
{
    class Program
    {
        public class Departamento
        {
            public int Id { get; set; }
            public string Descricao { get; set; }
        }

        public class Produto
        {
            public int Id { get; set; }
            public string Descricao { get; set; }
            public int IdDepartamento { get; set; }
            public Departamento Departamento { get; set; }
        }

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

            var query = (from prod in listaProdutos
                         group prod by 1 into agrupado
                         select new
                         {
                             Min = agrupado.Min(p => p.Id),
                             Max = agrupado.Max(p => p.Id),
                             Avg = agrupado.Average(p => p.Id),
                         }).Single();

            Console.WriteLine("Valor mínimo: {0}\nValor Máximo: {1}\nValor médio: {2}", query.Min, query.Max, query.Avg);

            Console.ReadLine();
        }
    }
}
