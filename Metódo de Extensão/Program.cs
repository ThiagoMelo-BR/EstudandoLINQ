using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Metódo_de_Extensão
{

    public static class LinqExtension
    {
        public static double FuncMediana<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource, double>> selector)
        {

            var totalRegistros = source.Count();

            if (totalRegistros == 0)
            {
                return 0;
            }


            var funcSelector = selector.Compile();

            var querOrdenada = source.Select(funcSelector).OrderBy(t => t);

            var primeiroRegistroMediana = 0d;
            var segundoRegistroMediana = 0d;

            if (totalRegistros >= 2)
            {
                primeiroRegistroMediana = querOrdenada.Skip((totalRegistros - 1) / 2).First();
                segundoRegistroMediana = querOrdenada.Skip((totalRegistros + 1) / 2).First();
            }
            else
            {
                primeiroRegistroMediana = querOrdenada.Skip(0).First();
                segundoRegistroMediana = querOrdenada.Skip(0).First();
            }


            var mediana = (Convert.ToDouble(primeiroRegistroMediana) + Convert.ToDouble(segundoRegistroMediana)) / 2;
            return mediana;

        }
    }

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

            var medianaFunc = listaProdutos.FuncMediana(p => p.Id);
            double mediana = Mediana(listaProdutos);            

            Console.WriteLine("Mediana: {0}", mediana);
            Console.WriteLine("Mediana: {0}", medianaFunc);
            Console.WriteLine("Média: {0}", listaProdutos.Count() != 0 ? listaProdutos.Average(p => p.Id) : 0);
            Console.ReadLine();

        }

        private static double Mediana(List<Produto> listaProdutos)
        {

            var totalRegistros = listaProdutos.Count();

            if (totalRegistros == 0)
            {
                return 0;
            }

            var primeiroRegistroMediana = new Produto();
            var segundoRegistroMediana = new Produto();

            if(totalRegistros >= 2)
            {
                primeiroRegistroMediana = listaProdutos.Skip((totalRegistros - 1) / 2).First();
                segundoRegistroMediana = listaProdutos.Skip((totalRegistros + 1) / 2).First();
            }
            else
            {
                primeiroRegistroMediana = listaProdutos.Skip(0).First();
                segundoRegistroMediana = listaProdutos.Skip(0).First();
            }            

            var mediana = (Convert.ToDouble(primeiroRegistroMediana.Id) + Convert.ToDouble(segundoRegistroMediana.Id)) / 2;
            return mediana;
        }
    }
}
