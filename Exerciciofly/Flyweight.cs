using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Exerciciofly
{
    class Flyweight
    {

        private Livro _compartilhado;

        public Flyweight(Livro livro)
        {
            this._compartilhado = livro;
        }

        public void Operacao(Livro unico)
        {
            string c = JsonConvert.SerializeObject(this._compartilhado);
            string u = JsonConvert.SerializeObject(unico);
            Console.WriteLine($"Elementos compartilhados: {c} Elemenos unicos: {u} state."); //separa e exibe os elementos compartilhados dos elementos unicos
        }
    }
}

