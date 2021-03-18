using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exerciciofly
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new FlyweightFactory(
                new Livro { Genero = "Terror", Autor = "Stephen King" },
                new Livro { Genero = "Romance", Autor = "David Nicholls" },
                new Livro { Genero = "Aventura", Autor = "Brian Selznick" },
                new Livro { Genero = "Drama", Autor = "Anne Frank" }


            );
            factory.listaFlyweights();

            addLivroAoBancoDados(factory, new Livro
            {
                ISBN = "23768594329812",
                Titulo = "A Invenção de Hugo Cabret",
                Genero = "Aventura",
                Autor = "Brian Selznick"
            });

            addLivroAoBancoDados(factory, new Livro
            {
                ISBN = "8652309812584",
                Titulo = "IT - a coisa",
                Genero = "Terror",
                Autor = "Stephen King"
            });

            factory.listaFlyweights();

            Console.ReadKey();
        }


        public static void addLivroAoBancoDados(FlyweightFactory factory, Livro livro)
        {
            Console.WriteLine("\nAdicionando livro ao banco de dados.");

            var flyweight = factory.GetFlyweight(new Livro
            {
                Genero = livro.Genero,
                Autor = livro.Autor

            });

            flyweight.Operacao(livro);

            Console.ReadKey();
        }

       
    }
}

