using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeirosPassos
{
    class Program
    {
        static void Main(string[] args)
        {
            var livros = new List<Livro>{
                new Livro {Id = 1, Nome = "Livro dos Espíritos"},
                new Livro {Id = 2, Nome = "Evangelho Segundo o Espíritismo"},
                new Livro {Id = 3, Nome = "Minuto de sabedoria"}
            };

            foreach (var item in livros)
            {
                if (item.Nome.Contains("Livro"))
                {
                    Console.WriteLine(item.Nome);
                }

            }
            Console.WriteLine("---------------------");

            var novaLita = from g in livros
                           where g.Nome.Contains("Livro")
                           select g;

            foreach (var item in novaLita)
            {
                Console.WriteLine(item.Nome);
            }


            Console.ReadLine();
        }
    }
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

}
