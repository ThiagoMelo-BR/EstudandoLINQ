using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load(@"D:\Estudando C#\Estudando Linq\EstudandoLINQ\LinqXML\Data\AluraTunes.xml");

            var querXml = from m in root.Element("Musicas").Elements("Musica")
                          join g in root.Element("Generos").Elements("Genero")
                            on m.Element("GeneroId").Value equals g.Element("GeneroId").Value
                          select new
                          {
                              Musica = m.Element("Nome").Value,
                              Genero = m.Element("Nome").Value
                          };


            foreach (var musica in querXml)
            {
                Console.WriteLine("{0}\t{1}", musica.Musica, musica.Genero);
            }

            Console.ReadLine();

        }
    }
}
