using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDeTenis {
    public class JogoDeTenis {
        public JogoDeTenis(Jogador jogador1, Jogador jogador2) {
            Jogador1 = jogador1;
            Jogador2 = jogador2;
        }

        public Jogador Jogador1 { get; set; }
        public Jogador Jogador2 { get; set; }
        public Jogador Vencedor { get; set; }

        public StatusJogo Status { get; set; }

        public void PontueJogador1() {
            PontueJogador(1);
        }

        public void PontueJogador2() {
            PontueJogador(2);
        }

        private void PontueJogador(int jogador) {


            Jogador daVez;
            Jogador adversario;
            if (jogador == 1) {
                daVez = Jogador1;
                adversario = Jogador2;
            }
            else {
                daVez = Jogador2;
                adversario = Jogador1;
                if (Status == StatusJogo.VantagemJogadorUm) {
                    Status = StatusJogo.Deuce;
                }
            }
            if (daVez.Pontos == 40) {

                Vencedor = daVez;
            }
            daVez.Pontue();


        }
    }

    public enum StatusJogo {
        Deuce,
        VantagemJogadorUm,
        VantagemJogadoDois
    }

    public class Jogador {
        private int _pontoIndex;
        public int Pontos {
            get { return PontosValidos[Math.Min(_pontoIndex, 3)]; }
            set {
                if (!PontosValidos.Contains(value)) {
                    throw new Exception("Valor invalido");
                }
                _pontoIndex = PontosValidos.IndexOf(value);
            }
        }

        public void Pontue() {
            _pontoIndex++;
        }

        private static readonly List<int> PontosValidos = new List<int> { 0, 15, 30, 40 };
    }
}
