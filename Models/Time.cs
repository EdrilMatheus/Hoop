using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hoop.Model;

namespace hoop.Model
{
    public class Time
    {
        public int ID { get; set; }

        public String? Nome { get; set; }

        public int numeroJogadores { get; set; }

        public List<Jogador> Jogador { get; set; }

        public Time() {
            Jogador = new List<Jogador>();
    }
}
}