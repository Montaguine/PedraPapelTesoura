using FluentAssertions;
using PedraPapelTesoura;
using System.Runtime.Intrinsics.X86;

namespace PedraPapeTesouraTest
{
    /*
     A cada rodada, a forma jogada por cada jogador é verificada e o programa determina um vencedor ou empate.

    [x] Pedra quebra tesoura;
    [x] Tesoura corta papel;
    [x] Papel cobre pedra;
    [x] O jogo empata se ambos os jogadores usarem a mesma forma.

     */

    public class JogoJonKenPonTests
    {
        JogoService sut;
        public JogoJonKenPonTests()
        {
            sut = new JogoService();
        }

        [Fact]
        public void Jogo_deve_empatar_caso_ambos_os_jogadores_usem_a_mesma_forma()
        {
            // Arrange
            var forma1 = Forma.Pedra;
            var forma2 = Forma.Pedra;

            // Act
            var resultado = sut.Jogar(forma1, forma2);

            // Assert
            resultado.Should().BeNull();
        }

        [Theory]
/*        [InlineData(Forma.Pedra, Forma.Lagarto, Forma.Pedra, "Pedra esmaga lagarto")]
        [InlineData(Forma.Lagarto, Forma.Spock, Forma.Lagarto, "Lagarto envenena Spock")]
        [InlineData(Forma.Spock, Forma.Tesoura, Forma.Spock, "Spock quebra tesoura")]
        [InlineData(Forma.Tesoura, Forma.Lagarto, Forma.Tesoura, "Tesoura decapita lagarto")]
        [InlineData(Forma.Lagarto, Forma.Papel, Forma.Lagarto, "Lagarto come papel")]
        [InlineData(Forma.Papel, Forma.Spock, Forma.Papel, "Papel contesta Spock")]
*/        [InlineData(Forma.Spock, Forma.Pedra, Forma.Pedra, "Spock vaporiza pedra")]
        public void Resultado_jogo_deve_ser_conforme_esperado(Forma forma1, Forma forma2, Forma resultadoEsperado, string requisito)
        {
            // Arrange / Act
            var resultado = sut.Jogar(forma1, forma2);

            // Assert
            resultado.Should().Be(resultadoEsperado, requisito);
        }

        [Theory]
        [InlineData(Forma.Lagarto, Forma.Papel, Forma.Tesoura, "Lagarto come papel")]
        [InlineData(Forma.Lagarto, Forma.Spock, Forma.Spock, "Lagarto envenena Spock")]
        [InlineData(Forma.Papel, Forma.Spock, Forma.Pedra, "Papel contesta Spock")]
        [InlineData(Forma.Pedra, Forma.Lagarto, Forma.Lagarto, "Pedra esmaga lagarto")]
        [InlineData(Forma.Spock, Forma.Pedra, Forma.Tesoura, "Spock vaporiza pedra")]
        [InlineData(Forma.Spock, Forma.Tesoura, Forma.Pedra, "Spock quebra tesoura")]
        [InlineData(Forma.Tesoura, Forma.Lagarto, Forma.Spock, "Tesoura decapita lagarto")]
        [InlineData(Forma.Lagarto, Forma.Lagarto, Forma.Papel, "Empate")]
        public void Jogo_nao_deve_aceitar_combinacoes_erradas(Forma forma1, Forma forma2, Forma resultadoEsperado, string requisito)
        {
            // Arrange / Act
            var resultado = sut.Jogar(forma1, forma2);

            // Assert
            resultado.Should().NotBe(resultadoEsperado, requisito);
        }


        [Fact]
        public void Tentativa_de_jogar_com_formas_inválidas_deve_resultar_em_exception()
        {
            // Arrange 
            var forma1 = "Spock";
            var forma2 = "Preda";

            // Act 
            
            Action action = () => sut.Jogar(forma1, forma2);

            action.Should().ThrowExactly<InvalidOperationException>();
            
            // Assert
            //Assert.Throws<InvalidOperationException>(() => sut.Jogar(forma1, forma2));
        }
    }
}