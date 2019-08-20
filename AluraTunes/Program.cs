using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            //FiltrandoRegistros();
            //TotalizandoDeFormaBurra();
            GroupBy();

            Console.ReadLine();
        }

        private static void GroupBy()
        {
            using (var context = new AluraTunesEntities())
            {
                var query = from inf in context.ItemNotaFiscal
                            where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                            group inf by inf.Faixa.Album into agrupado
                            let vendasporalbum = agrupado.Sum(f => f.Quantidade * f.PrecoUnitario)
                            orderby vendasporalbum descending
                            select new
                            {
                                Nome = agrupado.Key.Titulo,
                                Total = vendasporalbum
                            };

                foreach (var inf in query)
                {
                    Console.WriteLine("{0}\t{1}",
                    inf.Nome.PadRight(40),
                    inf.Total);
                }
            }
        }

        private static void TotalizandoDeFormaBurra()
        {
            decimal total = 0;

            using (var context = new AluraTunesEntities())
            {
                var query = from inf in context.ItemNotaFiscal
                            where inf.Faixa.Album.Artista.Nome == "Led Zeppelin"
                            select inf;

                foreach (var inf in query)
                {
                    total += (inf.Quantidade * inf.PrecoUnitario);

                    Console.WriteLine("{0}\t{1}\t{2}",
                        inf.Faixa.Album.Titulo.PadRight(40),
                        inf.Quantidade,
                        inf.PrecoUnitario);
                }
                Console.WriteLine("Total :" + total);

                //86,13
            }
        }

        private static void FiltrandoRegistros()
        {
            var textoBusca = "Amor";

            using (var context = new AluraTunesEntities())
            {
                var albuns = context.Album.ToList();

                var query = from albun in context.Album
                            join faixa in context.Faixa
                                on albun.AlbumId equals faixa.AlbumId
                            /*Condição IN LINE
                             Mas poderia estar abaixo
                             query = query.orderby(f => f.nome)
                             
                             */
                            where (!string.IsNullOrEmpty(textoBusca) ? faixa.Nome.Contains(textoBusca) : true)
                            orderby faixa.Nome descending
                            select new
                            {
                                albun,
                                faixa
                            };

                //query = query.OrderBy(f => f.faixa.Nome).ThenByDescending(f => f.faixa.TipoMidiaId);

                query = query.Take(5);


                context.Database.Log = Console.WriteLine;

                foreach (var item in query)
                {
                    Console.WriteLine("{0}\t{1}", item.faixa.Nome, item.albun.Titulo);
                }

            }
        }
    }
}
