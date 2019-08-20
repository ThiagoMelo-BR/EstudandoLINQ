using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_JOIN
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaFilmes = new List<Filmes>(){
                new Filmes { Id = 1, IdGenero = 1, Nome = "tubarão"},
                new Filmes { Id = 2, IdGenero = 2, Nome = "chuck"},
                new Filmes { Id = 3, IdGenero = 3, Nome = "pequena sereia"},
            };

            var listaGeneros = new List<Genero>()
            {
                new Genero {Id = 1, Nome = "suspense"},
                new Genero {Id = 2, Nome = "terror"},
                new Genero {Id = 3, Nome = "infatil"},
            };

            var sql = from f in listaFilmes
                      join g in listaGeneros on f.IdGenero equals g.Id
                      select new { f, g };

            foreach (var item in sql)
            {
                Console.WriteLine(item.f.Nome + " - " + item.g.Nome);
            }
            Console.ReadLine();
        }

        public class Filmes
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public int IdGenero { get; set; }
        }

        public class Genero
        {
            public int Id { get; set; }
            public string Nome { get; set; }

        }
    }
}
