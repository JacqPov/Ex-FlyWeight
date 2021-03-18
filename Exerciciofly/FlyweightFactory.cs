using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exerciciofly
{
    class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params Livro[] argumentos)
        {
            foreach (var elem in argumentos)
            {
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), this.getKey(elem)));
            }
        }

        public string getKey(Livro key) 
        {
            List<string> elementos = new List<string>();

            elementos.Add(key.Genero);
            elementos.Add(key.Autor);

            if (key.ISBN != null && key.Titulo != null) 
            {
                elementos.Add(key.Titulo);
                elementos.Add(key.ISBN);
            }

            elementos.Sort();

            return string.Join("_", elementos); //join concatena
        }

        public Flyweight GetFlyweight(Livro compartilhado)  //retorna uma instância existente ou cria uma nova
        {
            string key = this.getKey(compartilhado);

            if (flyweights.Where(t => t.Item2 == key).Count() == 0)
            {
                Console.WriteLine("Não foi possível encontrar os dados, crie uma nova lista de elementos."); 
                this.flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(compartilhado), key));
            }
            else
            {
                Console.WriteLine("Reutilizando uma lista existente.");
            }
            return this.flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }

        public void listaFlyweights()
        {
            var count = flyweights.Count;
            Console.WriteLine($"\nEu tenho {count} elementos:"); //mostra a quantidade de itens na lista
            foreach (var flyweight in flyweights)
            {
                Console.WriteLine(flyweight.Item2);
            }
        }
    }
}

