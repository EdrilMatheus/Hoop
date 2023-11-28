using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hoop.Model;

namespace hoop.Model
{
    public class Pelada
    {
        public int ID { get; set; }

        public DateTime dataPelada  { get; set; }

        public List<Time> Times { get; set; }

        public List<Jogador> Jogadores { get; set; }

        public int Duracao { get; set; }

        public int Pontuacao {get; set;}

        public Pelada() {
            Times = new List<Time>();
            Jogadores = new List<Jogador>();
    }
}
}