#language: pt-br

Funcionalidade: Regras

Esquema do Cenario: Pontos do Jogador, valores validos
    Dado que eu tenho um jogador
    Quando eu seto <pontos> como ponto do jogador
    Entao nao deve ocorrer erro
    Exemplos: 
    | pontos |
    | 0      |
    | 15     |
    | 30     |
    | 40     |

Esquema do Cenario: Pontos do Jogador, valores invalidos
    Dado que eu tenho um jogador
    Quando eu seto <pontos> como ponto do jogador
    Entao deve ocorrer erro
    Exemplos: 
    | pontos |
    | 1      |
    | 16     |
    | 32     |
    | 45     |

Cenario: Novo Jogo, jogador tem jogador
    Dado que eu tenho um novo jogo
    Entao deve ter dois jogadores
    E o jogador um deve ter 0 pontos
    E o jogador dois deve ter 0 pontos

Cenario: jogador um marca ponto
    Dado que eu tenho um novo jogo
    E o jogador um tem quarenta pontos
    Quando o jogador um pontua
    Entao o jogador um ganha o jogo

Cenario: jogador dois marca ponto
    Dado que eu tenho um novo jogo
    E o jogador dois tem quarenta pontos
    Quando o jogador dois pontua
    Entao o jogador dois ganha o jogo

Cenario: ambos jogadores atingem 40 pontos, ocorre deuce
    Dado que eu tenho um novo jogo
    E o jogador um tem quarenta pontos
    E o jogador dois tem quarenta pontos
    Entao o jogo esta deuce

Cenario: jogo em deuce, quem pontua esta em vantagem
    Dado que eu tenho um novo jogo
    E o jogo esta em deuce
    Quando o jogador um pontua
    Entao o jogo vai para vantagem Jogador Um

Cenario: vantagem do jogador um
    Dado que eu tenho um novo jogo
    E o jogo esta em vantagem do jogador um
    Quando o jogador dois pontua
    Entao o jogo vai para deuce

Esquema do Cenario: Pontos do Jogador, nova pontuacao
    Dado que eu tenho um jogador
    Quando o jogador tem <pontos> 
    E ele pontua
    Entao vai para <novoponto>
    Exemplos: 
    | pontos | novoponto |
    | 0      | 15        |
    | 15     | 30        |
    | 30     | 40        |
    | 40     | 40        |