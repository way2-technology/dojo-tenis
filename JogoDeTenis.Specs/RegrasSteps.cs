using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace JogoDeTenis.Specs {
    [Binding]
    public class RegrasSteps {
        private JogoDeTenis _jogo;
        private Jogador _jogador;

        [Given(@"que eu tenho um jogador")]
        public void DadoQueEuTenhoUmJogador() {
            _jogador = new Jogador();
        }

        [When(@"eu seto (.*) como ponto do jogador")]
        public void QuandoEuSetoComoPontoDoJogador(int pontos) {
            try {
                _jogador.Pontos = pontos;
            }
            catch (Exception e) {
                ScenarioContext.Current.Add("Pontos_exception", e);
            }
        }

        [Then(@"nao deve ocorrer erro")]
        public void EntaoNaoDeveOcorrerErro() {

            Assert.IsFalse(ScenarioContext.Current.ContainsKey("Pontos_exception"));
        }

        [Then(@"deve ocorrer erro")]
        public void EntaoDeveOcorrerErro() {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey("Pontos_exception"));
            var exception = ScenarioContext.Current.Get<Exception>("Pontos_exception");
            Assert.AreEqual("Valor invalido", exception.Message);
        }

        [Given(@"que eu tenho um novo jogo")]
        public void DadoQueEuTenhoUmNovoJogo() {
            var j1 = new Jogador();
            var j2 = new Jogador();
            _jogo = new JogoDeTenis(j1, j2);
        }

        [Then(@"deve ter dois jogadores")]
        public void EntaoDeveTerDoisJogadores() {
            Assert.IsNotNull(_jogo.Jogador1);
            Assert.IsNotNull(_jogo.Jogador2);
        }

        [Then(@"o jogador um deve ter (.*) pontos")]
        public void EntaoOJogadorUmDeveTerPontos(int ignore) {
            Assert.AreEqual(0, _jogo.Jogador1.Pontos);
        }

        [Then(@"o jogador dois deve ter (.*) pontos")]
        public void EntaoOJogadorDoisDeveTerPontos(int ignore) {
            Assert.AreEqual(0, _jogo.Jogador1.Pontos);
        }

        [Given(@"o jogador um tem quarenta pontos")]
        public void DadoOJogadorUmTemQuarentaPontos()
        {
            _jogo.Jogador1.Pontos = 40;
        }

        [When(@"o jogador um pontua")]
        public void QuandoOJogadorUmPontua() {
            _jogo.PontueJogador1();
        }

        [Then(@"o jogador um ganha o jogo")]
        public void EntaoOJogadorUmGanhaOJogo() {
            Assert.IsNotNull(_jogo.Vencedor);
            Assert.AreEqual(_jogo.Jogador1, _jogo.Vencedor);
        }

        [Given(@"o jogador dois tem quarenta pontos")]
        public void DadoOJogadorDoisTemQuarentaPontos() {
            _jogo.Jogador2.Pontos = 40;
        }

        [When(@"o jogador dois pontua")]
        public void QuandoOJogadorDoisPontua() {
            _jogo.PontueJogador2();
        }

        [Then(@"o jogador dois ganha o jogo")]
        public void EntaoOJogadorDoisGanhaOJogo() {
            Assert.IsNotNull(_jogo.Vencedor);
            Assert.AreEqual(_jogo.Jogador2, _jogo.Vencedor);
        }

        [Then(@"o jogo esta deuce")]
        public void EntaoOJogoEstaDeuce()
        {
            Assert.IsTrue(_jogo.Status== StatusJogo.Deuce);
        }

        [Given(@"o jogo esta em deuce")]
        public void DadoOJogoEstaEmDeuce()
        {
            _jogo.Status = StatusJogo.Deuce;
        }

        [Then(@"o jogo vai para vantagem Jogador Um")]
        public void EntaoOJogoVaiParaVantagemJogadorUm() {
            _jogo.Status = StatusJogo.VantagemJogadorUm;
        }

        [When(@"o jogador tem (.*)")]
        public void QuandoOJogadorTem(int pontos)
        {
            _jogador.Pontos = pontos;
        }

        [When(@"ele pontua")]
        public void QuandoElePontua() {
            _jogador.Pontue();
        }

        [Then(@"vai para (.*)")]
        public void EntaoVaiPara(int valorEsperado) {
            Assert.AreEqual(valorEsperado, _jogador.Pontos);
        }

        [Given(@"o jogo esta em vantagem do jogador um")]
        public void DadoOJogoEstaEmVantagemDoJogadorUm() {
            _jogo.Status = StatusJogo.VantagemJogadorUm;
        }

        [Then(@"o jogo vai para deuce")]
        public void EntaoOJogoVaiParaDeuce() {
            Assert.AreEqual(StatusJogo.Deuce,_jogo.Status);
        }


    }
}
